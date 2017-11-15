using System;
using System.Diagnostics;
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
            Console.WriteLine("change windows to >>" + to);
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
            if(to == "notsal")
            {
                AppPanel.mainFrame.Visible = false;
                AppPanel.notSALFrame.Visible = true;
            }
            if (to == "overtime")
            {
                //左にovertimeFrameを表示、右も消しましょう
                AppPanel.mainFrame.Visible = false;
                AppPanel.overTimeFrame.Visible = true;
                AppPanel.tableFrame.Visible = false;
            }
        }

        public void checkSKU(string janCode)
        {
            ReadWriteHelper rwhelper = new ReadWriteHelper();
            for(int i = 0; i < Data.dbBoxNo.Count; i++)
            {
                //手元のデータで照会したところ、まだ発送してない。
                if(janCode==Data.dbSKU[i] && Data.dbBoxNo[i]=="")
                {
                    Console.WriteLine("---------------");
                    Console.Write("check"); Console.WriteLine(i);
                    Console.WriteLine("-----------");

                    //本当に入荷済みかどうかを確認
                    bool deal = CheckHelper.CheckIfExsit(i);
                    if (deal) continue;   //この商品が既に処理されている。

                    Console.WriteLine("beforebefore chekck");
                    Console.WriteLine(Data.dbPlural[9]);
                    
                    //まだ入荷処理されていないので、複数かどかを確認
                    bool pluralBook = CheckHelper.CheckPlural(i);
                    if (pluralBook)//複数注文処理
                    {
                        CheckHelper.PluralProcess(i);
                        changeWindowTo("plural");//画面表示
                        return;
                    }


                    Console.WriteLine("not plural  fdsahjkfhasklhflkj");

                    //複数注文ではない
                    //sal以外の動作？？？？
                    int issal = CheckHelper.SALCheck(i);
                    if (issal != 0)//0はsal 
                    {
                        //TODO ※とairの分岐すべき？
                        changeWindowTo("notsal");
                        rwhelper.ChangeStatus(i, "notsal");
                        return;
                    }


                    //通常のsal処理
                    //4973307009730 
                    bool overtime = CheckHelper.TimeCheck(i);
                    if (overtime)
                    {
                        changeWindowTo("overtime");//2週間以上の商品なので、急いで出品
                        rwhelper.ChangeStatus(i, "overtime");
                        return;
                    }
                    else
                    {//初めての入荷処理x
                        rwhelper.Arrival(i);
                        return;
                    }
                    

                }
            }

            changeWindowTo("nothit");
            return;
        }
    }
}
