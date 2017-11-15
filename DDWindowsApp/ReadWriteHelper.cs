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

         //アプリの初期設定
        public void TakeFromDBData()
        {

            Console.WriteLine("取り出し開始");
            using (var book = new XLWorkbook(Data.dbpath,XLEventTracking.Disabled))
            {
                var sheet1 = book.Worksheet(1);
                var range = sheet1.RangeUsed();

                Console.WriteLine(range.ColumnCount() + " " + range.RowCount());
              
                for (int i = 0; i < range.RowCount()-1; i++)
                {
                    Data.dbDate.Add(Convert.ToDateTime(sheet1.Cell(i + 2, 1).Value));
                    Console.WriteLine("tilldate");
                    Data.dbBoxNo.Add(Convert.ToString(sheet1.Cell(i + 2, 2).Value));
                    Console.WriteLine("tillboxno");
                    Data.dbSKU.Add(Convert.ToString(sheet1.Cell(i + 2, 3).Value));
                    Console.WriteLine("tillsku");
                    Data.dbLineNo.Add(Convert.ToInt32(sheet1.Cell(i + 2, 4).Value));
                    Console.WriteLine("tilllineno");
                    Data.dbStoreStatus.Add(Convert.ToString(sheet1.Cell(i + 2, 5).Value));
                    Console.WriteLine("tillstorestatus");
                    Data.dbSentWay.Add(Convert.ToString(sheet1.Cell(i + 2, 6).Value));
                    Console.WriteLine("tillsentway");
                    Data.dbOrderID.Add(Convert.ToString(sheet1.Cell(i + 2, 7).Value));
                    Console.WriteLine("tillorderid");
                    Data.dbNumber.Add(Convert.ToInt32(sheet1.Cell(i + 2, 18).Value));
                    Console.WriteLine("tillnumber");
                    Data.dbPlural.Add(Convert.ToString(sheet1.Cell(i + 2, 19).Value));
                    Console.WriteLine("tillplural");
                    Data.dbPluralBoxNumber.Add(Convert.ToString(sheet1.Cell(i + 2, 20).Value));
                    Console.WriteLine("tillpluralboxnumber");
                    Data.dbPluralStore.Add(Convert.ToString(sheet1.Cell(i + 2, 21).Value));
                    Console.WriteLine("tillpluralstore");
                    }
                /*
                Console.Write("注文日  :");Console.WriteLine(Data.dbDate[267]);
                Console.Write("boxNo   :");Console.WriteLine(Data.dbBoxNo[267]);
                Console.Write("SKU     :");Console.WriteLine(Data.dbSKU[267]);
                Console.Write("行番号  :");Console.WriteLine(Data.dbLineNo[267]);
                Console.Write("在庫状況:");Console.WriteLine(Data.dbStoreStatus[267]);
                Console.Write("送り方法;");Console.WriteLine(Data.dbSentWay[267]);
                Console.Write("注文番号:");Console.WriteLine(Data.dbOrderID[267]);
                Console.Write("注文個数:");Console.WriteLine(Data.dbNumber[267]);
                Console.Write("複数状況:");Console.WriteLine(Data.dbPlural[267]);
                Console.Write("複数箱名:");Console.WriteLine(Data.dbPluralBoxNumber[267]);
                Console.Write("複在庫数:");Console.WriteLine(Data.dbPluralStore[267]);
                */
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
