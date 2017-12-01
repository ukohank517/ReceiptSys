using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp1
{
    class ExcelPrint
    {
        public String _xslFile = @"\\\\192.168.1.37\\share\\DB_ForTest\\invoice.xlsx";  // XLSファイル名
        public int _sheetNo = 1;                        // シートNo.
        public int _col = 1;                            // データ書き込みカラム
        public int _line = 1;                           // データ書き込み開始行
        public String _printer = "";                    // 出力プリンター

        public String _B2 = "";                         // A1
        public String _E3 = "";                         // A2

        // -----------------------------------------------------------------------------
        // 印刷実行
        // -----------------------------------------------------------------------------
        public void Print()
        {
            // Excel.Applicationを有効にするため参照の追加を行なってください
            // [参照の追加],[COM],[Microsoft Excel *.* Object Library]
            // 参照設定に[Excel](ファイル名:Interop.Excel.dll)が追加されます
            Excel.Application objExcel = null;
            Excel.Workbooks objWorkBooks = null;
            Excel.Workbook objWorkBook = null;
            Excel.Worksheet objWorkSheet = null;
            Excel.Range objRange = null;
            object objCell = null;

            try
            {
                // EXCEL開始処理
                try
                {
                    objExcel = new Excel.Application();
                }
                catch
                {
                    throw new Exception(
                        "Microsoft Office Excelがインストールされていないため\n" +
                        "印刷できません。");
                }

                if (System.IO.File.Exists(_xslFile) == false)
                {
                    throw new Exception(
                        "エクセルファイルが見つかりませんでした。\n" + _xslFile);
                }

                objExcel.WindowState = Excel.XlWindowState.xlMinimized;
                objExcel.Visible = false;
                objExcel.DisplayAlerts = false;

                objWorkBooks = objExcel.Workbooks;
                objWorkBook = objWorkBooks.Open(_xslFile,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);
                objWorkSheet = (Excel.Worksheet)objWorkBook.Sheets[_sheetNo];

                // EXCEL出力処理
                objCell = objWorkSheet.Cells[_line + 1, _col + 1];//2,B
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = _B2;
                Marshal.ReleaseComObject(objRange);     // オブジェクト参照を解放
                Marshal.ReleaseComObject(objCell);      // オブジェクト参照を解放

                objCell = objWorkSheet.Cells[_line + 2, _col + 4];//3,E
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = _E3;
                Marshal.ReleaseComObject(objRange);     // オブジェクト参照を解放
                Marshal.ReleaseComObject(objCell);      // オブジェクト参照を解放



                // 印刷実行
                if (_printer != "")
                {
                    objWorkSheet.PrintOut(
                        Type.Missing, Type.Missing, 1, Type.Missing,
                        _printer, Type.Missing, true, Type.Missing);
                }
                else
                {
                    objWorkSheet.PrintOut(
                        Type.Missing, Type.Missing, 1, Type.Missing,
                        Type.Missing, Type.Missing, true, Type.Missing);
                }

                objWorkBook.Saved = true;   // 保存済みとする

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // EXCEL終了処理
                if (objWorkSheet != null)
                {
                    Marshal.ReleaseComObject(objWorkSheet);     // オブジェクト参照を解放
                    objWorkSheet = null;                        // オブジェクト解放
                }

                if (objWorkBook != null)
                {
                    objWorkBook.Close(false,
                        Type.Missing, Type.Missing);            //ファイルを閉じる
                    Marshal.ReleaseComObject(objWorkBook);      // オブジェクト参照を解放
                    objWorkBook = null;                         // オブジェクト解放
                }

                if (objWorkBooks != null)
                {
                    Marshal.ReleaseComObject(objWorkBooks);     // オブジェクト参照を解放
                    objWorkBooks = null;                        // オブジェクト解放
                }
                if (objExcel != null)
                {
                    objExcel.Quit();                            // EXCELを閉じる

                    Marshal.ReleaseComObject(objExcel);         // オブジェクト参照を解放
                    objExcel = null;                            // オブジェクト解放
                }

                System.GC.Collect();                            // オブジェクトを確実に削除
            }
        }
    }
}