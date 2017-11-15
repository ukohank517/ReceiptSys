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
        /// 入ってるなら手元のDBを更新、入ってないなら複数を確認して、ファイルを更新、手元も更新。
        /// false: 入荷済み、Dataのデータを更新
        /// true : (既に入荷、存在)番号あり、他のパソコンが既に操作 false : (まだ入荷じゃない、存在しない)番号無し、他のパソコンも操作してない。
        /// </summary>
        /// <param name="lineNo"></param>
        /// <returns></returns>
        public static bool CheckIfExsit(int lineNo)
        {
            bool flag = false;  　　//やはり空白
            using (var book=new XLWorkbook(Data.dbpath,XLEventTracking.Disabled))
            {
                var sheet1 = book.Worksheet(1);
                string detail = Convert.ToString(sheet1.Cell("B" + Convert.ToString(lineNo + 2)).Value);
                Data.dbPlural[lineNo] = Convert.ToString(sheet1.Cell("T" + Convert.ToString(lineNo + 2)).Value);
                Data.dbPluralStore[lineNo] = Convert.ToString(sheet1.Cell("U" + Convert.ToString(lineNo + 2)).Value);
                if (detail != "")//他のパソコンでは既に操作済み
                {
                    Data.dbBoxNo[lineNo] = detail;
                    flag = true;
                }
                else//どこも操作していない
                {
                    //Excel更新
                    sheet1.Cell("B" + Convert.ToString(lineNo + 2)).SetValue("dealing");//これによって他のExcelがアクセスしないようにする
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
            Console.WriteLine(lineNo);
            Console.Write("before function"); Console.WriteLine(Data.dbPlural[lineNo]);
            bool flag = false;

            string plural = Data.dbPlural[lineNo]; //この客が違う注文してるかどか
            int num = Data.dbNumber[lineNo];//この商品の注文個数
               
            if (plural != "" || num != 1) flag = true;//何かしらの情報が複数である

            Console.WriteLine("複数情報について");

            Console.Write("注文日  :"); Console.WriteLine(Data.dbDate[lineNo]);
            Console.Write("boxNo   :"); Console.WriteLine(Data.dbBoxNo[lineNo]);
            Console.Write("SKU     :"); Console.WriteLine(Data.dbSKU[lineNo]);
            Console.Write("行番号  :"); Console.WriteLine(Data.dbLineNo[lineNo]);
            Console.Write("在庫状況:"); Console.WriteLine(Data.dbStoreStatus[lineNo]);
            Console.Write("送り方法;"); Console.WriteLine(Data.dbSentWay[lineNo]);
            Console.Write("注文番号:"); Console.WriteLine(Data.dbOrderID[lineNo]);
            Console.Write("注文個数:"); Console.WriteLine(Data.dbNumber[lineNo]);
            Console.Write("複数状況:"); Console.WriteLine(Data.dbPlural[lineNo]);
            Console.Write("複数箱名:"); Console.WriteLine(Data.dbPluralBoxNumber[lineNo]);
            Console.Write("複在庫数:"); Console.WriteLine(Data.dbPluralStore[lineNo]);

            return flag;
        }




        /// <summary>
        /// 複数注文の商品について、ファイルに更新、複数注文専用画面を更新
        /// </summary>
        /// <param name="lineNo"></param>
        public static void PluralProcess(int lineNo) 
        {
            int beginIndex = lineNo;
            while (true)
            {
                if (beginIndex == 0) break;
                if (Data.dbPlural[beginIndex] == "") break;
                if (Data.dbPlural[beginIndex] == Data.dbPlural[beginIndex-1]) beginIndex--;
                else break;
            }
            int endIndex = lineNo;
            while (true)
            {
                if (endIndex >= Data.dbBoxNo.Count - 1) break;
                if (Data.dbPlural[endIndex] == "") break;
                if (Data.dbPlural[endIndex] == Data.dbPlural[endIndex + 1]) endIndex++;
                else break;
            }
            Console.WriteLine(beginIndex + " " + endIndex);
            //その人専用のボックスを作成、内容がpluralBoxに保存
             using (var book=new XLWorkbook(Data.dbpath, XLEventTracking.Disabled))
            {
                var sheet1 = book.Worksheet(1);
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
                    int aim = Convert.ToInt32(sheet1.Cell("R" + Convert.ToString(i + 2)).Value);
                    Console.WriteLine("aim->" +aim);
                    if (Data.pluralStock[i - beginIndex]==aim)
                    {
                        sheet1.Cell("B" + Convert.ToString(i + 2)).SetValue(Data.pluralBoxNo);
                    }

                }
                book.Save();
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


        /// <summary>
        /// 2週間以上の商品であるかどうかを確認
        /// </summary>
        /// <param name="lineNo"></param>
        /// <returns>true: 2週間以上、 false: 2週間以内</returns>
        /// 
        public static bool TimeCheck(int lineNo)
        {

            using (var book = new XLWorkbook(Data.dbpath, XLEventTracking.Disabled))
            {
                var sheet1 = book.Worksheet(1);
                var str = sheet1.Cell("A" + Convert.ToString(lineNo + 2)).Value;
                Console.WriteLine("---->"+str + "<------");
                Console.WriteLine();
                DateTime aaaa = Convert.ToDateTime(str);
                
                Console.WriteLine("--->"+aaaa);
                DateTime goodsTime = new DateTime(1900, 1, 1, 0, 0, 0);
                        
                //goodsTime += new TimeSpan(aaaa - 2, 0, 0, 0);
                
                DateTime today = DateTime.Today;
                
                TimeSpan goodsSpan = today - aaaa;
                TimeSpan defaltSpan = new TimeSpan(14, 0, 0, 0);
                Console.WriteLine(goodsSpan);
                if (goodsSpan < defaltSpan)
                {
                    Console.WriteLine("2週間以内");
                    book.Save();
                    return false;
                }
                else
                {
                    Console.WriteLine("2週間以上");
                    book.Save();
                    return true;
                }
            }
        }


    }
}
