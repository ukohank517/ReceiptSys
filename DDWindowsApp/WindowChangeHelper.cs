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
                    Console.WriteLine("手持ちではヒットしたよ！");
                    //ファイルの中から本当にからかどうかチェック
                    Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                    ExcelApp.Visible = false;
                    Microsoft.Office.Interop.Excel.Workbook workbook = ExcelApp.Workbooks.Open(Data.dbpath);

                    //--------------TODO LIST--------------------

                    //-------------------------------------------

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
