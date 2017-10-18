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
            if (to == "nothit")
            {
                AppPanel.mainFrame.Visible = false;
                AppPanel.notHitFrame.Visible = true;
            }
        }

        public void checkSKU(string janCode)
        {
            for(int i = 0; i < Data.dbBoxNo.Count; i++)
            {
                //手元のデータで照会したところ、まだ発送してない。
                if(janCode==Data.dbSKU[i] && Data.dbBoxNo[i]=="")
                {
                    //本当に出荷済みかどうかを確認
                    bool notSend = CheckHelper.CheckFileBoxNo(i);
                    if (notSend) continue;   //notSendの中に何かがある。
                   
                    Console.WriteLine("やはり出荷してないので、複数かどうか確認します");
                    //出荷してないので、複数かどかを確認
                    bool pluralBook = CheckHelper.CheckPlural(i);
                    if (pluralBook)
                    {
                        //複数注文処理
                        Console.WriteLine("複数ですよ！");
                        CheckHelper.PluralProcess(i);
                        //画面表示
                        AppPanel.mainFrame.Visible = false;
                        AppPanel.tableFrame.Visible = false;
                        AppPanel.pluralFrame.Visible = true;
                        AppPanel.pluralTableFrame.Visible = true;

                        return;
                    }
                    
                    //複数注文ではない
                    

                }
            }

            changeWindowTo("nothit");
            return;
        }
    }
}
