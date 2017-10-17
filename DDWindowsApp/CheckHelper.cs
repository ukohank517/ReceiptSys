using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
namespace DDWindowsApp
{
    class CheckHelper
    {
        /// <summary>
        /// 手元がヒットしてないが、データベースの中に本当に入ってないかどうかを確認
        /// false: 入荷済み、Dataのデータを更新
        /// true : やはりヒットしてない。 
        /// </summary>
        /// <param name="lineNo"></param>
        /// <returns></returns>
        public static bool CheckFileBoxNo(int lineNo)
        {
            
            bool flag = true;
            //ファイル開く操作
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            ExcelApp.Visible = false;
            Microsoft.Office.Interop.Excel.Workbook workbook = ExcelApp.Workbooks.Open(Data.dbpath);
            Worksheet sheet = workbook.Sheets[1];
            sheet.Select();

            //----------ファイルの中のbox noは入ってるかどうかを確認------------
            Microsoft.Office.Interop.Excel.Range range = sheet.get_Range("B" + Convert.ToString(lineNo + 2));
            //既に発送ならデータ更新
            if (range.Value != null)
            {
                Data.dbBoxNo[lineNo] = Convert.ToString(range.Value);//本当は他のパソコンで既に操作している
                flag = false ;
            }
            //ファイル関連の後処理
            workbook.Close();
            ExcelApp.Quit();

            return flag;
        }


        /// <summary>
        /// 複数注文かどうかだけ確認してくれる。
        /// </summary>
        /// <param name="lineNo"></param>
        /// <returns>true: 複数の注文     false: 複数ではない注文</returns>
        public static bool CheckPlural(int lineNo)
        {
            bool flag = false;
            //ファイル開く操作
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            ExcelApp.Visible = false;
            Microsoft.Office.Interop.Excel.Workbook workbook = ExcelApp.Workbooks.Open(Data.dbpath);
            Worksheet sheet = workbook.Sheets[1];
            sheet.Select();

            Microsoft.Office.Interop.Excel.Range plural = sheet.get_Range("S" + Convert.ToString(lineNo + 2));//複数の違う内容の注文かどうか
            Microsoft.Office.Interop.Excel.Range num = sheet.get_Range("R" + Convert.ToString(lineNo + 2));//複数個、同じ注文商品
            if (plural.Value != null || num.Value != 1) flag = true;//何かしらの情報が複数

            workbook.Close();
            ExcelApp.Quit();
            return flag;
        }





        public static bool PluralProcess(int lineNo) 
        {
            bool flag = false;
            //ファイル開く操作
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            ExcelApp.Visible = false;
            Microsoft.Office.Interop.Excel.Workbook workbook = ExcelApp.Workbooks.Open(Data.dbpath);
            Worksheet sheet = workbook.Sheets[1];
            sheet.Select();

            int beginIndex = lineNo;//一番最初の注文番号ライン
            while (true)
            {
                if (beginIndex == 1) break;
                Microsoft.Office.Interop.Excel.Range now = sheet.get_Range("S" + Convert.ToString(beginIndex + 2));
                Microsoft.Office.Interop.Excel.Range before = sheet.get_Range("S" + Convert.ToString(beginIndex + 2 - 1));

                //Console.WriteLine("now"+Convert.ToString(now.Value));
                //Console.WriteLine("before"+Convert.ToString(before.Value));
                if (before.Value == now.Value) beginIndex--;
                else break;
            }
            int endIndex = lineNo;
            while (true)
            {
                if (endIndex >= Data.dbBoxNo.Count - 1) break;
                Microsoft.Office.Interop.Excel.Range now = sheet.get_Range("S" + Convert.ToString(endIndex + 2));
                Microsoft.Office.Interop.Excel.Range after = sheet.get_Range("S" + Convert.ToString(endIndex + 2 + 1));
                Console.WriteLine(Convert.ToString(now.Value) + " " + Convert.ToString(after));
                if (now.Value == after.Value) endIndex++;
                else break;
            }
            Console.WriteLine(beginIndex + " " + endIndex);
            //その人の専用のボックスが存在するかどうかを確認
            Microsoft.Office.Interop.Excel.Range pBoxNo = sheet.get_Range("T" + Convert.ToString(lineNo+2));
            if (pBoxNo.Value != null) AppPanel.pluralBoxNo = pBoxNo.Value;
            else
            {
                AppPanel.pluralBoxNo = 'P' + Convert.ToString(Data.pluralCount);
                Data.PluralBoxRenew();
            }
            for(int i = beginIndex; i <= endIndex; i++)
            {
                Microsoft.Office.Interop.Excel.Range date = sheet.get_Range("A" + Convert.ToString(i + 2));
                Microsoft.Office.Interop.Excel.Range line= sheet.get_Range("D" + Convert.ToString(i + 2));
                Microsoft.Office.Interop.Excel.Range orderId = sheet.get_Range("G" + Convert.ToString(i + 2));
                Microsoft.Office.Interop.Excel.Range aim = sheet.get_Range("R" + Convert.ToString(i + 2));
                Microsoft.Office.Interop.Excel.Range stock = sheet.get_Range("U" + Convert.ToString(i + 2));


                Console.WriteLine(Convert.ToString(date.Value));

                AppPanel.pluralDate.Add(Convert.ToString(date.Value));
                
                /*
                Data.pluralDate.Add(Convert.ToString(date.Value));
                Data.pluralLineNo.Add(Convert.ToInt32(line.Value));
                Data.pluralOrderID.Add(Convert.ToString(orderId.Value));
                Data.pluralAim.Add(Convert.ToInt32(aim.Value));
                if (stock.Value != null)
                    Data.pluralStock.Add(Convert.ToInt32(stock.Value));
                else Data.pluralStock.Add(0);
                */
                //Console.WriteLine(Data.pluralDate[0]);
            }
            
            

            workbook.Close();
            ExcelApp.Quit();
            return flag;
        }

    }
}
