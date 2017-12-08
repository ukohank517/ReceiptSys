using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace DDWindowsApp
{
    class ExcelPrint
    {
        public String _xslFile = @"\\\\192.168.1.37\\share\\DB_ForTest\\invoice.xlsx";  // XLSファイル名
        public int _sheetNo = 1;                        // シートNo.
        public int _col = 1;                            // データ書き込みカラム
        public int _line = 1;                           // データ書き込み開始行
        public String _printer = "Invoice";                    // 出力プリンター


        public String _Name = "";
        public String _Address1 = "";
        public String _Address2 = "";
        public String _Address3 = "";
        public String _Address4 = "";
        public String _PostNo = "";
        public String _Country = "";
        public String _TEL = "";
        public String _FAX = "";

        public int _sum = 1;//全部で何行入ってるのか
        public String[] _description = new String[10];
        public int[] _num = new int[10];//注文個数
        public int _unitP = 10;


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
                objCell = objWorkSheet.Cells[_line + 2, _col + 1];//3,B
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = "Name:" + _Name;
                Marshal.ReleaseComObject(objRange);     // オブジェクト参照を解放
                Marshal.ReleaseComObject(objCell);      // オブジェクト参照を解放

                objCell = objWorkSheet.Cells[_line + 3, _col + 1];
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = "Address1: " + _Address1;
                Marshal.ReleaseComObject(objRange);
                Marshal.ReleaseComObject(objCell);

                objCell = objWorkSheet.Cells[_line + 4, _col + 1];
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = "Address2: " + _Address2;
                Marshal.ReleaseComObject(objRange);
                Marshal.ReleaseComObject(objCell);

                objCell = objWorkSheet.Cells[_line + 5, _col + 1];
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = "Address3: " + _Address3;
                Marshal.ReleaseComObject(objRange);
                Marshal.ReleaseComObject(objCell);

                objCell = objWorkSheet.Cells[_line + 6, _col + 1];
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = "Address4: " + _Address4;
                Marshal.ReleaseComObject(objRange);
                Marshal.ReleaseComObject(objCell);

                objCell = objWorkSheet.Cells[_line + 7, _col + 1];
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = "郵便番号: " + _PostNo;
                Marshal.ReleaseComObject(objRange);
                Marshal.ReleaseComObject(objCell);

                objCell = objWorkSheet.Cells[_line + 8, _col + 1];
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = "国: " + _Country;
                Marshal.ReleaseComObject(objRange);
                Marshal.ReleaseComObject(objCell);

                objCell = objWorkSheet.Cells[_line + 9, _col + 1];
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = "TEL: " + _TEL;
                Marshal.ReleaseComObject(objRange);
                Marshal.ReleaseComObject(objCell);

                objCell = objWorkSheet.Cells[_line + 10, _col + 1];
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = _FAX;
                Marshal.ReleaseComObject(objRange);
                Marshal.ReleaseComObject(objCell);

                objCell = objWorkSheet.Cells[_line + 24, _col + 1];//3,B
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = _Name;
                Marshal.ReleaseComObject(objRange);     // オブジェクト参照を解放
                Marshal.ReleaseComObject(objCell);      // オブジェクト参照を解放

                objCell = objWorkSheet.Cells[_line + 25, _col + 1];
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = _Address1;
                Marshal.ReleaseComObject(objRange);
                Marshal.ReleaseComObject(objCell);

                objCell = objWorkSheet.Cells[_line + 26, _col + 1];
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = _Address2;
                Marshal.ReleaseComObject(objRange);
                Marshal.ReleaseComObject(objCell);

                objCell = objWorkSheet.Cells[_line + 27, _col + 1];
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = _Address3;
                Marshal.ReleaseComObject(objRange);
                Marshal.ReleaseComObject(objCell);

                objCell = objWorkSheet.Cells[_line + 28, _col + 1];
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = _Address4;
                Marshal.ReleaseComObject(objRange);
                Marshal.ReleaseComObject(objCell);

                objCell = objWorkSheet.Cells[_line + 29, _col + 1];
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = _PostNo;
                Marshal.ReleaseComObject(objRange);
                Marshal.ReleaseComObject(objCell);

                objCell = objWorkSheet.Cells[_line + 30, _col + 1];
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = _Country;
                Marshal.ReleaseComObject(objRange);
                Marshal.ReleaseComObject(objCell);

                objCell = objWorkSheet.Cells[_line + 31, _col + 1];
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = _TEL;
                Marshal.ReleaseComObject(objRange);
                Marshal.ReleaseComObject(objCell);

                objCell = objWorkSheet.Cells[_line + 32, _col + 1];
                objRange = objWorkSheet.get_Range(objCell, objCell);
                objRange.Value2 = _FAX;
                Marshal.ReleaseComObject(objRange);
                Marshal.ReleaseComObject(objCell);

                
                int totalNum = 0;
                for (int i = 0; i < _sum; i++)
                    totalNum += _num[i];
                if (totalNum == 0) totalNum = 1;
                _unitP = 10 / totalNum;
                

                for (int i = 0; i < _sum; i++)
                {
                    objCell = objWorkSheet.Cells[_line + 37 + i, _col + 1];
                    objRange = objWorkSheet.get_Range(objCell, objCell);
                    objRange.Value2 = _description[i];
                    Marshal.ReleaseComObject(objRange);
                    Marshal.ReleaseComObject(objCell);

                    objCell = objWorkSheet.Cells[_line + 37 + i, _col + 4];
                    objRange = objWorkSheet.get_Range(objCell, objCell);
                    objRange.Value2 = Convert.ToString(_num[i]);


                    Marshal.ReleaseComObject(objRange);
                    Marshal.ReleaseComObject(objCell);

                    objCell = objWorkSheet.Cells[_line + 37 + i, _col + 6];
                    objRange = objWorkSheet.get_Range(objCell, objCell);
                    objRange.Value2 = Convert.ToString(_unitP);
                    Marshal.ReleaseComObject(objRange);
                    Marshal.ReleaseComObject(objCell);

                    objCell = objWorkSheet.Cells[_line + 37 + i, _col + 7];
                    objRange = objWorkSheet.get_Range(objCell, objCell);
                    objRange.Value2 = Convert.ToString(_num[i] * _unitP);
                    Marshal.ReleaseComObject(objRange);
                    Marshal.ReleaseComObject(objCell);
                }

                objCell = objWorkSheet.Cells[_line + 52, _col + 7];
                objRange = objWorkSheet.get_Range(objCell, objCell);
                if ((_unitP) == 0)
                    objRange.Value2 = "10";
                else
                    objRange.Value2 = Convert.ToString(_unitP*totalNum);
                Marshal.ReleaseComObject(objRange);
                Marshal.ReleaseComObject(objCell);


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