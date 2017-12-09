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
            using (var book = new XLWorkbook(Data.dbpath,XLEventTracking.Disabled))
            {
                var sheet1 = book.Worksheet(1);
                var range = sheet1.RangeUsed();
              
                for (int i = 0; i < range.RowCount()-1; i++)
                {
                    Data.dbDate.Add(Convert.ToDateTime(sheet1.Cell(i + 2, 1).Value));
                    Data.dbBoxNo.Add(Convert.ToString(sheet1.Cell(i + 2, 2).Value));
                    Data.dbSKU.Add(Convert.ToString(sheet1.Cell(i + 2, 3).Value));
                    Data.dbstore.Add(Convert.ToString(sheet1.Cell(i + 2, 5).Value));
                }
                book.Save();
            }
        }

        /// <summary>
        /// 例外なしの入荷処理
        /// </summary>
        public void Arrival(int i)
        {
            Data.boxCount++;
            AppPanel.mainFrame.labelNumDetail.Text = Data.boxCount + "件/" + Data.GOODSMAXNUM + "件中";


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
                Order = Convert.ToString(sheet1.Cell("G" + Convert.ToString(i + 2)).Value);
                line = Convert.ToInt32(sheet1.Cell("D" + Convert.ToString(i + 2)).Value);
                sheet1.Cell("B" + Convert.ToString(i + 2)).SetValue(Data.boxName);
                book.Save();
            }

            //画面の右側の表を更新
            AppPanel.tableFrame.situationTable.Rows.Add(NO, BOX, JAN, Order, line);

            Data.NameinB.Add(Data.nowName);
            Data.Address1inB.Add(Data.nowAdress1);
            Data.Address2inB.Add(Data.nowAdress2);
            Data.Address3inB.Add(Data.nowAdress3);
            Data.Address4inB.Add(Data.nowAdress4);
            Data.PostIDinB.Add(Data.nowPostID);
            Data.CountryinB.Add(Data.nowCountry);
            Data.TELinB.Add(Data.nowTEL);
            Data.DescriptioninB.Add(Data.nowDescription);
            Data.NuminB.Add(1);

            //box情報更新
            if (Data.boxCount == Data.GOODSMAXNUM)
            {
                AppPanel.mainFrame.Visible = false;
                AppPanel.finFrame.Visible = true;
            }

            Data.RenewBox();
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
