using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using ClosedXML.Excel;
using System.Globalization;

namespace DDWindowsApp
{
    class CheckHelper
    {
        /// <summary>
        /// 手元がヒットしてないが、データベースの中に本当に入ってないかどうかを確認
        /// false: 入荷済み、Dataのデータを更新
        /// true : 番号あり、他のパソコンが既に操作 false : 番号無し、他のパソコンも操作してない。
        /// </summary>
        /// <param name="lineNo"></param>
        /// <returns></returns>
        public static bool CheckFileBoxNo(int lineNo)
        {
            Console.WriteLine("check" + lineNo);
            bool flag = false;  　　//やはり空白
            using (var book=new XLWorkbook(Data.dbpath,XLEventTracking.Disabled))
            {
                var sheet1 = book.Worksheet(1);
                string detail = Convert.ToString(sheet1.Cell("B" + Convert.ToString(lineNo + 2)).Value);

                if (detail != "")
                {
                    Data.dbBoxNo[lineNo] = detail;
                    flag = true;
                }
                
                book.Save();
            }
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
            using (var book = new XLWorkbook(Data.dbpath,XLEventTracking.Disabled))
            {
                var sheet1 = book.Worksheet(1);
                string plural = Convert.ToString(sheet1.Cell("S" + Convert.ToString(lineNo + 2)).Value);//複数の違う内容の注文かどうか
                string num = Convert.ToString(sheet1.Cell("R" + Convert.ToString(lineNo + 2)).Value);//同じ商品を複数注文
                if (plural != "" || num != "1") flag = true;//何かしらの情報が複数である
                book.Save();
               
            }
            return flag;
        }




        /// <summary>
        /// 複数注文の商品について、ファイルに更新、複数注文専用画面を更新
        /// </summary>
        /// <param name="lineNo"></param>
        public static void PluralProcess(int lineNo) 
        {

            using (var book=new XLWorkbook(Data.dbpath, XLEventTracking.Disabled))
            {
                var sheet1 = book.Worksheet(1);

                int beginIndex = lineNo;
                while (true)
                {
                    if (beginIndex == 1) break;
                    string before = Convert.ToString(sheet1.Cell("S" + Convert.ToString(beginIndex + 2 - 1)).Value);
                    string now = Convert.ToString(sheet1.Cell("S" + Convert.ToString(beginIndex + 2)).Value);
                    if (before == now) beginIndex--;
                    else break;
                }
                int endIndex = lineNo;
                while (true)
                {
                    if (endIndex >= Data.dbBoxNo.Count - 1) break;
                    string now = Convert.ToString(sheet1.Cell("S"+Convert.ToString(endIndex+2)).Value);
                    string after = Convert.ToString(sheet1.Cell("S"+Convert.ToString(endIndex+2+1)).Value);
                    if (now == after) endIndex++;
                    else break;
                }

                Console.WriteLine(beginIndex + " " + endIndex);

                //その人専用のボックス更新、内容がpluralBox保存
                Data.pluralBoxNo = Convert.ToString(sheet1.Cell("T" + Convert.ToString(lineNo + 2)).Value);
                if (Data.pluralBoxNo == "")
                {
                    Data.pluralBoxNo = 'P' + Convert.ToString(Data.pluralCount);
                    Data.PluralBoxRenew();
                }
                Data.PluralRenew();
                for(int i = beginIndex; i <= endIndex; i++)
                {
                    string date = Convert.ToString(sheet1.Cell("A" + Convert.ToString(i + 2)).Value);
                    int line = Convert.ToInt32(sheet1.Cell("D" + Convert.ToString(i + 2)).Value);
                    string orderId = Convert.ToString(sheet1.Cell("G" + Convert.ToString(i + 2)).Value);
                    int aim = Convert.ToInt32(sheet1.Cell("R" + Convert.ToString(i + 2)).Value);
                    string stock = Convert.ToString(sheet1.Cell("U" + Convert.ToString(i + 2)).Value);

                    Data.pluralDate.Add(date);
                    Data.pluralLineNo.Add(line);
                    Data.pluralOrderID.Add(orderId);
                    Data.pluralAim.Add(aim);
                    if (i == lineNo)
                    {
                        if (stock == "") Data.pluralStock.Add(1);
                        else Data.pluralStock.Add(Convert.ToInt32(stock) + 1);
                    }
                    else
                    {
                        if (stock == "") Data.pluralStock.Add(0);
                        else Data.pluralStock.Add(Convert.ToInt32(stock));
                    }
                }
                //複数人用のデータ情報をエクセルに書き込む
                for(int i = beginIndex; i <= endIndex; i++)//入荷数とボックスナンバーだけで
                {
                    sheet1.Cell("U" + Convert.ToString(i + 2)).SetValue(Data.pluralStock[i - beginIndex]);//stock
                    sheet1.Cell("T" + Convert.ToString(i + 2)).SetValue(Data.pluralBoxNo);//boxNo
                    Console.WriteLine(Data.pluralStock[i - beginIndex] + " " + Data.pluralBoxNo);
                }
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //book.Save();//実際使用するとき、コメント外してね
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            }
            //table更新
            AppPanel.pluralTableFrame.pluralTable.Rows.Clear();
            AppPanel.pluralFrame.buttonPrint.Enabled = true;
            for (int i = 0; i < Data.pluralDate.Count; i++)
            {
                AppPanel.pluralTableFrame.pluralTable.Rows.Add(Data.pluralBoxNo, Data.pluralDate[i], Data.pluralLineNo[i], Data.pluralOrderID[i], Data.pluralAim[i], Data.pluralStock[i]);
                if (Data.pluralAim != Data.pluralStock)
                {
                    AppPanel.pluralFrame.buttonPrint.Enabled = false;
                }
            }
            //return flag;
        }

        /// <summary>
        /// 発送方法チェックする
        /// </summary>
        /// <param name="lineNo"></param>
        /// <returns>0:SAL, 1:air, 2:その他</returns>
        public static int SALCheck(int lineNo)
        {
            char way;
            using (var book = new XLWorkbook(Data.dbpath, XLEventTracking.Disabled))
            {
                var sheet1 = book.Worksheet(1);
                way = Convert.ToChar(sheet1.Cell("F" + Convert.ToString(lineNo + 2)).Value);
                book.Save();
            }
            if (way == '*') return 0;
            if (way == 'e') return 2;
            return 1;
        }

        public static bool TimeCheck(int lineNo)
        {
            DateTime T = new DateTime();
            DateTime today = DateTime.Today;

            using (var book = new XLWorkbook(Data.dbpath, XLEventTracking.Disabled))
            {
                /*
                 * 参考してね！！！！！！！！！
                //https://msdn.microsoft.com/ja-jp/library/system.datetime(v=vs.110).aspx
                ！！！！！！！！！！！！！！！！！！！！！！！！！！！！！

                */
                var sheet1 = book.Worksheet(1);
                var aaaa = sheet1.Cell("A" + Convert.ToString(lineNo + 2)).Value;
                //string dateString = Convert.ToString(aaaa);
                string dateString = "115216";
                string[] formats = { "yyyyMMdd", "HHmmss" };
                DateTime parsedDate;
                if (DateTime.TryParseExact(dateString, formats, null,
                           DateTimeStyles.AllowWhiteSpaces |
                           DateTimeStyles.AdjustToUniversal,
                           out parsedDate))


                    //String D = Convert.ToString(sheet1.Cell("A" + Convert.ToString(lineNo + 2)).Value);
                    Console.WriteLine("time !!" + parsedDate + "!!time");
                else Console.WriteLine("fail");
                book.Save();
            }

            TimeSpan ts = today - T;
            Console.WriteLine(today);
            return true;
        }

    }
}
