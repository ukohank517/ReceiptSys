using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace DDWindowsApp
{
    class ReadWriteHelper
    {
        /*
         * memo:
         * Excel関連:
         * https://qiita.com/kyama0922/items/f0c6449d8734889d1e83
         * https://www.ipentec.com/document/document.aspx?page=csharp-open-read-excel-book-and-sheet
         */
        public void TakeFromDBData()
        {

            Console.WriteLine("取り出し開始");
            Microsoft.Office.Interop.Excel.Application ExcelAppp = new Microsoft.Office.Interop.Excel.Application();
            // Excelの非表示
            ExcelAppp.Visible = false;
            
            //エクセルファイルのオープンと、ワークブックの作成
            Microsoft.Office.Interop.Excel.Workbook workbook = ExcelAppp.Workbooks.Open(Data.dbpath);

            //1シート目の選択
            Microsoft.Office.Interop.Excel.Worksheet sheet = workbook.Sheets[1];
            sheet.Select();

            //A1セルから右への連続データ数
            //int column_count = sheet.get_Range("A1").End[Microsoft.Office.Interop.Excel.XlDirection.xlToRight].Column;
            //Console.WriteLine("右への連続データ数は:"+column_count);

            //縦セルからの連続データ数（データベースの中の全データ数）
            int row_count = sheet.get_Range("C1").End[Microsoft.Office.Interop.Excel.XlDirection.xlDown].Row;
            for(int i = 0; i < row_count-1; i++)//目録を削除
            {
                Range range = ExcelAppp.get_Range("B"+Convert.ToString(i+2), Type.Missing);
                if (range == null)
                    Data.dbBoxNo.Add("");
                else Data.dbBoxNo.Add(Convert.ToString(range.Value));

                range = ExcelAppp.get_Range("C"+Convert.ToString(i+2), Type.Missing);
                if (range == null)
                    Data.dbSKU.Add("");
                else Data.dbSKU.Add(Convert.ToString(range.Value));
            }

            //ワークブックを閉じる
            workbook.Close();
            //エクセルを閉じる
            ExcelAppp.Quit();

            Console.WriteLine("取り出し完了");
        }

    }
}
