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

                for (int i = 0; i < range.RowCount()-1; i++)
                {
                    Data.dbBoxNo.Add(Convert.ToString(sheet1.Cell(i + 2, 2).Value));
                    Data.dbSKU.Add(Convert.ToString(sheet1.Cell(i + 2, 3).Value));
                }

                book.Save();
            }
            Console.WriteLine("finished");
        }

        /// <summary>
        /// 入荷処理
        /// </summary>
        public void Arrival(int i)
        {
            //プログラムの持ってるリストを更新する。
            //ファイルに入ってるデータを出荷済み登録する。
            //画面の右側の表を更新
        }



    }
}
