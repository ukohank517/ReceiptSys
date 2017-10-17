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
                //手元のデータで照会したところ、まだ発送してない。
                if(janCode==Data.dbSKU[i] && Data.dbBoxNo[i]==null)
                {
                    //ファイル開く操作
                    Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                    ExcelApp.Visible = false;
                    Microsoft.Office.Interop.Excel.Workbook workbook = ExcelApp.Workbooks.Open(Data.dbpath);
                    Worksheet sheet = workbook.Sheets[1];
                    sheet.Select();



                    bool notSend = CheckHelper.CheckFileBoxNo(i);
                    if (!notSend) continue;     //出荷済みなら、飛ばそう


                    bool pluralBook = CheckHelper.CheckPlural(i);
                    if (pluralBook)
                    {
                        //複数注文処理
                        CheckHelper.PluralProcess(i);
                        //画面表示



                        //ファイル関連の後処理
                        workbook.Close();
                        ExcelApp.Quit();
                        return;
                    }



                    //複数注文ではない


                    //ファイル関連の後処理
                    workbook.Close();
                    ExcelApp.Quit();
                }
            }

            changeWindowTo("nothit");
            return;
        }
    }
}
