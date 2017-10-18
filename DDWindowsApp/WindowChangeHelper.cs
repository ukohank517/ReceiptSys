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
            if (to == "plural")
            {
                AppPanel.mainFrame.Visible = false;
                AppPanel.tableFrame.Visible = false;
                AppPanel.pluralFrame.Visible = true;
                AppPanel.pluralTableFrame.Visible = true;
            }
            if(to=="notsal")
            {
                AppPanel.mainFrame.Visible = false;
                AppPanel.notSALFrame.Visible = true;
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
                        changeWindowTo("plural");//画面表示
                        return;
                    }

                    //sal以外の動作？？？？
                    //複数注文ではない
                    int issal = CheckHelper.SALCheck(i);
                    if(issal != 0)
                    {
                        changeWindowTo("notsal");
                    }


                    //4973307009730 
                    bool overtime = CheckHelper.TimeCheck(i);
                    return;

                }
            }

            changeWindowTo("nothit");
            return;
        }
    }
}
