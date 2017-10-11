using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace DDWindowsApp
{
    class WindowChangeHelper
    {
        public void changeWindowTo(string to)
        {
            if(to == "nothit")
            AppPanel.mainFrame.Visible = false;
            AppPanel.notHitFrame.Visible = true;
        }

        public void checkSKU(string janCode)
        {
            for(int i = 0; i < Data.dbBoxNo.Count; i++)
            {
                if(janCode==Data.dbSKU[i] && Data.dbBoxNo[i]==null)
                {
                    //ファイル開く操作
                    Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                    ExcelApp.Visible = false;
                    Microsoft.Office.Interop.Excel.Workbook workbook = ExcelApp.Workbooks.Open(Data.dbpath);
                    Worksheet sheet = workbook.Sheets[1];
                    sheet.Select();

                    //---------------ファイルの中から本当に未発送かどうかチェック----------
                    Microsoft.Office.Interop.Excel.Range range = sheet.get_Range("B" + Convert.ToString(i + 2));
                    //既発送ならデータ更新更新
                    if (range.Value != null)
                    {
                        Data.dbBoxNo[i] = Convert.ToString(range.Value);//本当は他のパソコンで既に操作している。
                        Console.WriteLine("data->" + Data.dbBoxNo[i] + "<-");
                        continue;
                    }
                    //未発送なら複数口チェック
                    Console.WriteLine("未発送");
                    Microsoft.Office.Interop.Excel.Range plural = sheet.get_Range("S" + Convert.ToString(i + 2));//種類が複数かどうか
                    Microsoft.Office.Interop.Excel.Range num = sheet.get_Range("R" + Convert.ToString(i + 2));   //個数
                    if (plural.Value != null)//複数回の注文（違う商品で同じ客）
                    {
                        Console.WriteLine("複数だよ！");
                        
                        //この客の注文について
                        int beginIndex = i;//一番最初の注文番号ライン
                        while (true)
                        {
                            if (beginIndex == 1) break;
                            Microsoft.Office.Interop.Excel.Range now = sheet.get_Range("S" + Convert.ToString(beginIndex + 2));
                            Microsoft.Office.Interop.Excel.Range before = sheet.get_Range("S" + Convert.ToString(beginIndex + 2 - 1));
                            if (before.Value == now.Value) beginIndex--;
                            else break;
                        }
                        int endIndex = i;//一番最後の注文番号ライン
                        while (true)
                        {
                            if (endIndex >= Data.dbBoxNo.Count-1) break;
                            Microsoft.Office.Interop.Excel.Range now = sheet.get_Range("S" + Convert.ToString(endIndex + 2));
                            Microsoft.Office.Interop.Excel.Range after = sheet.get_Range("S" + Convert.ToString(endIndex + 2 + 1));
                            if (now.Value == after.Value) endIndex++;
                            else break;
                        }
                        Console.WriteLine(beginIndex + " " + endIndex + " ");
                        Microsoft.Office.Interop.Excel.Range box = sheet.get_Range("T" + Convert.ToString(i + 2));
                        if (box.Value == null)
                        {
                            for(int index = beginIndex; index <= endIndex; index++)
                            {
                                box = sheet.get_Range("T" + Convert.ToString(i + 2));
                                box.Value = 
                            }
                        }

                        for(int index = beginIndex;index<= endIndex; index++)
                        {
                            Microsoft.Office.Interop.Excel.Range date = sheet.get_Range("A" + Convert.ToString(index + 2));
                            Microsoft.Office.Interop.Excel.Range lineNo = sheet.get_Range("D" + Convert.ToString(index + 2));
                            Microsoft.Office.Interop.Excel.Range boxNo = sheet.get_Range("B" + Convert.ToString(index + 2));
                            Microsoft.Office.Interop.Excel.Range orderID = sheet.get_Range("G" + Convert.ToString(index + 2));
                            Microsoft.Office.Interop.Excel.Range aimNum = sheet.get_Range("R" + Convert.ToString(index + 2));
                            Microsoft.Office.Interop.Excel.Range stockNum = sheet.get_Range("U" + Convert.ToString(index + 2));
                        }

                    }

                    //発送方法チェック

                    
                    
                    //後処理
                    workbook.Close();
                    ExcelApp.Quit();
                    //本当じゃないならdbboxnum,dbskuを変更,continue
                    
                    //本当なら
                    //2個口チェック
                        //2個なら、2個系処理
                    //発送方法チェック
                }
            }

            changeWindowTo("nothit");
            return;
        }
    }
}
