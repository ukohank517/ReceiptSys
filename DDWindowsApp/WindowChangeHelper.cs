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
                bool finish = false;
                bool tothree = false;
                for(int i = 0; i < Data.pluralStock.Count()+1; i++)
                {
                    if (i == Data.pluralStock.Count()) { finish = true;break; }
                    if (Data.pluralStock[i] != Data.pluralAim[i])
                    {
                        if (Data.pluralInThree[i] == true) tothree = true;
                        else { finish = false; break; }
                    }
                }
                if (finish == true)//終了
                {
                    if (tothree == true)//三階へ送信
                    {
                        AppPanel.pluralFrame.Visible = false;
                        AppPanel.sentThreeFrame.Visible = true;
                    }
                    else//印刷ボタンを有効に
                    {
                        AppPanel.pluralFrame.buttonPrint.Enabled = true;
                    }
                }
                
            }
            if(to == "notsal")
            {
                AppPanel.notSALFrame.textBox1.Text = "行番号" + Data.nowLineNo;
                AppPanel.mainFrame.Visible = false;
                AppPanel.notSALFrame.Visible = true;
            }
            if (to == "overtime")
            {
                //左にovertimeFrameを表示、右も消しましょう
                AppPanel.overTimeFrame.textBox1.Text = "行番号" + Data.nowLineNo;
                AppPanel.mainFrame.Visible = false;
                AppPanel.overTimeFrame.Visible = true;
                AppPanel.tableFrame.Visible = false;
            }
            if (to == "cancel")
            {
                AppPanel.isCanselFrame.textBox1.Text = "行番号:"+ Data.nowLineNo;
                AppPanel.mainFrame.Visible = false;
                AppPanel.isCanselFrame.Visible = true;
            }
            if(to == "notfour")
            {
                AppPanel.mainFrame.Visible = false;
                AppPanel.notFourFrame.Visible = true;
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
                    if (Data.dbstore[i] != "")
                    {
                        changeWindowTo("notfour");
                        return;
                    }
                    //本当に入荷済みかどうかを確認
                    bool deal = CheckHelper.CheckIfExsit(i);
                    if (deal) continue;   //この商品が既に処理されている。

                    //まだ入荷処理されていないので、複数かどかを確認
                    bool pluralBook = CheckHelper.CheckPlural(i);
                    if (pluralBook)//複数注文処理
                    {
                        CheckHelper.PluralProcess(i);
                        changeWindowTo("plural");
                        return;
                    }

                    //複数注文ではない
                    //sal以外の動作？？？？
                    int issal = CheckHelper.SALCheck(i);
                    if(issal == 2)
                    {
                        changeWindowTo("cancel");
                        rwhelper.ChangeStatus(i, "cancel");
                        return;
                    }
                    else if (issal != 0)//0はsal 
                    {
                        //TODO ※とairの分岐すべき？
                        changeWindowTo("notsal");
                        rwhelper.ChangeStatus(i, "notsal");
                        return;
                    }


                    //通常のsal処理
                    bool overtime = CheckHelper.TimeCheck(i);
                    if (overtime)
                    {
                        changeWindowTo("overtime");//2週間以上の商品なので、急いで出品
                        rwhelper.ChangeStatus(i, "overtime");
                        return;
                    }
                    else
                    {//初めての入荷処理
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
