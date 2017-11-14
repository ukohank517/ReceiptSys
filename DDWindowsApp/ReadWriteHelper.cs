using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using ClosedXML.Excel;

namespace DDWindowsApp
{
    class ReadWriteHelper
    {
        /*
         * memo:
         * Excel関連:
         * http://sourcechord.hatenablog.com/entry/2015/06/21/180557
         * http://nineworks2.blog.fc2.com/?tag=ClosedXML&page=3
         * https://closedxml.codeplex.com/wikipage?title=Showcase&referringTitle=Documentation
         * https://closedxml.codeplex.com/wikipage?title=Hello%20World&referringTitle=Documentation
         * https://www.projectgroup.info/tips/Microsoft.NET/tips_0005.html
         */
        public void TakeFromDBData()
        {

            Console.WriteLine("取り出し開始");
            using (var book = new XLWorkbook(Data.dbpath,XLEventTracking.Disabled))
            {
                var sheet1 = book.Worksheet(1);
                var range = sheet1.RangeUsed();

                Console.WriteLine(range.ColumnCount() + " " + range.RowCount());
                /*
        public const string dbpath = "\\\\192.168.1.37\\share\\DB_ForTest\\DB_sample.xlsx";
        public static List<DateTime> dbDate = new List<DateTime>();    //日付
        public static List<string> dbBoxNo = new List<string>();       //BoxNo
        public static List<string> dbSKU = new List<string>();         //SKU
        public static List<int> dbLineNo = new List<int>();      //行番号
        public static List<string> dbStoreStatus = new List<string>(); //在庫か、入荷版なのか
        public static List<string> dbSentWay = new List<string>();     //発送方法
        public static List<string> dbOrderID = new List<string>();     //オーダーID
        public static List<int> dbNumber = new List<int>();            //注文個数
        public static List<String> dbPlural = new List<String>();      //複数違う注文商品しているのかどうか
        public static List<String> dbPluralBoxNumber = new List<String>();//複数注文用boxNo,頭にPを付けた文字列。
        
                 */
                for (int i = 0; i < range.RowCount()-1; i++)
                {
                    Data.dbDate.Add(Convert.ToDateTime(sheet1.Cell(i + 2, 1).Value));
                    Data.dbBoxNo.Add(Convert.ToString(sheet1.Cell(i + 2, 2).Value));
                    Data.dbSKU.Add(Convert.ToString(sheet1.Cell(i + 2, 3).Value));
                    Data.dbLineNo.Add(Convert.ToInt32(sheet1.Cell(i + 2, 4).Value));
                    Data.dbStoreStatus.Add(Convert.ToString(sheet1.Cell(i + 2, 5).Value));
                    Data.dbSentWay.Add(Convert.ToString(sheet1.Cell(i + 2, 6).Value));
                    Data.dbOrderID.Add(Convert.ToString(sheet1.Cell(i + 2, 7).Value));
                    Data.dbNumber.Add(Convert.ToInt32(sheet1.Cell(i + 2, 18).Value));
                    Data.dbPlural.Add(Convert.ToString(sheet1.Cell(i + 2, 19).Value));
                    Data.dbPluralBoxNumber.Add(Convert.ToString(sheet1.Cell(i + 2, 20).Value));
                    Data.dbPluralStore.Add(Convert.ToInt32(sheet1.Cell(1 + 2, 21).Value));

                        }
                Console.WriteLine(Convert.ToString(sheet1.Cell(2, 2).Value));
                Console.WriteLine(Convert.ToString(sheet1.Cell("B2").Value));
                book.Save();
            }
            Console.WriteLine("finished");
        }

        /// <summary>
        /// 入荷処理
        /// </summary>
        public void Arrival(int i)
        {
            //box情報更新
            if (Data.boxCount == Data.GOODSMAXNUM)
            {
                Data.boxCount = 0;
                Data.boxName++;
                Data.boxName %= Data.BOXMAXNUM;
            }
            int NO = Data.boxCount;
            int BOX = Data.boxName;
            String JAN = Data.dbSKU[i];
            String Order = "";
            int line=i+2;

            //プログラムの持ってるリスト、ファイルの出荷済みを更新する。
            Data.dbBoxNo[i]=Convert.ToString(Data.boxName);//リスト
            using (var book = new XLWorkbook(Data.dbpath, XLEventTracking.Disabled))//ファイル
            {
                var sheet1 = book.Worksheet(1);
                sheet1.Cell("B" + Convert.ToString(i + 2)).SetValue(Data.boxName);
                Order = Convert.ToString(sheet1.Cell("B" + Convert.ToString(i + 2)).Value);
                book.Save();
            }

            //画面の右側の表を更新
            AppPanel.tableFrame.situationTable.Rows.Add(NO, BOX, JAN, Order, line);

        }

        /// <summary>
        /// 入力した行番号のboxnoに、入力したstringで埋める（特殊発送方法）
        /// </summary>
        public void ChangeStatus(int line, String box)
        {
            using (var book = new XLWorkbook(Data.dbpath, XLEventTracking.Disabled))
            {
                var sheet1 = book.Worksheet(1);
                sheet1.Cell("B" + Convert.ToString(line + 2)).SetValue(box);
                book.Save();
            }
        }

    }
}
