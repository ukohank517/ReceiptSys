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
        /// true : (既に入荷、存在)番号あり、他のパソコンが既に操作 false : (まだ入荷じゃない、存在しない)番号無し、他のパソコンも操作してない。
        /// </summary>
        /// <param name="lineNo"></param>
        /// <returns></returns>
        public static bool CheckIfExsit(int lineNo)
        {
            using (var book=new XLWorkbook(Data.dbpath,XLEventTracking.Disabled))
            {
                var sheet1 = book.Worksheet(1);
                string detail = Convert.ToString(sheet1.Cell("B" + Convert.ToString(lineNo + 2)).Value);

                if (detail != "")
                {
                    Data.dbBoxNo[lineNo] = detail;
                    return true;
                }
                else
                {
                    Data.nowLineNo = Convert.ToString(sheet1.Cell("D" + Convert.ToString(lineNo + 2)).Value);
                    Data.nowName = Convert.ToString(sheet1.Cell("H" + Convert.ToString(lineNo + 2)).Value);
                    Data.nowAdress1 = Convert.ToString(sheet1.Cell("I" + Convert.ToString(lineNo + 2)).Value);
                    Data.nowAdress2 = Convert.ToString(sheet1.Cell("J" + Convert.ToString(lineNo + 2)).Value);
                    Data.nowAdress3 = Convert.ToString(sheet1.Cell("K" + Convert.ToString(lineNo + 2)).Value);
                    Data.nowAdress4 = Convert.ToString(sheet1.Cell("L" + Convert.ToString(lineNo + 2)).Value);
                    Data.nowPostID = Convert.ToString(sheet1.Cell("M" + Convert.ToString(lineNo + 2)).Value);
                    Data.nowTEL = Convert.ToString(sheet1.Cell("P" + Convert.ToString(lineNo + 2)).Value);
                    Data.nowCountry = Convert.ToString(sheet1.Cell("N" + Convert.ToString(lineNo + 2)).Value);
                    Data.nowCountryCode = Convert.ToString(sheet1.Cell("O" + Convert.ToString(lineNo + 2)).Value);
                    Data.nowDescription = Convert.ToString(sheet1.Cell("Q" + Convert.ToString(lineNo + 2)).Value);
                    Data.nowSentway = Convert.ToString(sheet1.Cell("F" + Convert.ToString(lineNo + 2)).Value);
                    Data.nownum = Convert.ToInt32(sheet1.Cell("R" + Convert.ToString(lineNo + 2)).Value);
                }
            }
            return false;
        }



        /// <summary>
        /// 複数注文かどうかだけ確認してくれる。
        /// </summary>
        /// <param name="lineNo"></param>
        /// <returns>true: 複数の注文     false: 複数ではない注文</returns>
        public static bool CheckPlural(int lineNo)
        {
            using (var book = new XLWorkbook(Data.dbpath,XLEventTracking.Disabled))
            {
                var sheet1 = book.Worksheet(1);
                string plural = Convert.ToString(sheet1.Cell("S" + Convert.ToString(lineNo + 2)).Value);//複数の違う内容の注文かどうか
                string num = Convert.ToString(sheet1.Cell("R" + Convert.ToString(lineNo + 2)).Value);//同じ商品を複数注文
                if (plural != "" || num != "1") return true;//何かしらの情報が複数である
            }
            return false;
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
                    if (before == "") break;
                    if (before == now) beginIndex--;
                    else break;
                }
                int endIndex = lineNo;
                while (true)
                {
                    if (endIndex >= Data.dbBoxNo.Count - 1) break;
                    string now = Convert.ToString(sheet1.Cell("S"+Convert.ToString(endIndex+2)).Value);
                    string after = Convert.ToString(sheet1.Cell("S"+Convert.ToString(endIndex+2+1)).Value);
                    if (now == "") break;
                    if (now == after) endIndex++;
                    else break;
                }
                string sentway = Convert.ToString(sheet1.Cell("F" + Convert.ToString(lineNo + 2)).Value);
                AppPanel.pluralFrame.label2.Text = "発送方法は"+sentway +"だよ";
                

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
                    string ifinthree = Convert.ToString(sheet1.Cell("E" + Convert.ToString(i + 2)).Value);
                    string description = Convert.ToString(sheet1.Cell("Q" + Convert.ToString(i + 2)).Value);

                    Data.pluralDate.Add(date);
                    Data.pluralLineNo.Add(line);
                    Data.pluralOrderID.Add(orderId);
                    Data.pluralAim.Add(aim);
                    Data.pluralDescription.Add(description);
                    if (ifinthree != "") Data.pluralInThree.Add(true);//在庫
                    else Data.pluralInThree.Add(false);
                    


                    //ヒットした行の商品に、入荷数+1の処理
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
                    int aim = Convert.ToInt32(sheet1.Cell("R" + Convert.ToString(i + 2)).Value);
                    if (Data.pluralStock[i - beginIndex]==aim)
                    {
                        sheet1.Cell("B" + Convert.ToString(i + 2)).SetValue(Data.boxName);
                    }
                    sheet1.Cell("V1").SetValue("既に使用された最新のbox↓");
                    sheet1.Cell("V2").SetValue(Data.boxName);
                    sheet1.Cell("W1").SetValue("既に使用された最新の複数box↓");
                    sheet1.Cell("W2").SetValue(Data.pluralCount);
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
        }

        /// <summary>
        /// 発送方法チェックする
        /// </summary>
        /// <param name="lineNo"></param>
        /// <returns>0:*, 1:e, 2:c, 3:その他</returns>
        public static int SALCheck(int lineNo)
        {
            string way;
            using (var book = new XLWorkbook(Data.dbpath, XLEventTracking.Disabled))
            {
                var sheet1 = book.Worksheet(1);
                way = Convert.ToString(sheet1.Cell("F" + Convert.ToString(lineNo + 2)).Value);
            }
            if (way == "*") return 0;
            if (way == "air") return 0;
            if (way == "e") return 1;
            if (way == "c") return 2;
            return 3;
        }


        /// <summary>
        /// 2週間以上の商品であるかどうかを確認
        /// </summary>
        /// <param name="lineNo"></param>
        /// <returns>true: 2週間以上、 false: 2週間以内</returns>
        public static bool TimeCheck(int lineNo)
        {

            using (var book = new XLWorkbook(Data.dbpath, XLEventTracking.Disabled))
            {
                var sheet1 = book.Worksheet(1);
                var str = sheet1.Cell("A" + Convert.ToString(lineNo + 2)).Value;
                DateTime aaaa = Convert.ToDateTime(str);
                
                DateTime goodsTime = new DateTime(1900, 1, 1, 0, 0, 0);
                                        
                DateTime today = DateTime.Today;
                
                TimeSpan goodsSpan = today - aaaa;
                TimeSpan defaltSpan = new TimeSpan(14, 0, 0, 0);

                if (goodsSpan < defaltSpan) return false;
                else return true;
            }
        }


    }
}
