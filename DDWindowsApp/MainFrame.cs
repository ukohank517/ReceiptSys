using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDWindowsApp
{
    public partial class MainFrame : UserControl
    {
        public MainFrame()
        {
            InitializeComponent();
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {

        }

        private void buttonSearchClicked(object sender, EventArgs e)
        {
            if (textJAN.Text == "aa")
            {
                //表更新
                //AppPanel.
                AppPanel.tableFrame.situationTable.Rows.Add(AppPanel.boxCount+1, textJAN.Text, "OrderId", "Line");

                //件数増える。
                AppPanel.boxCount++;
                labelNumDetail.Text = AppPanel.boxCount + "件/" + AppPanel.BOXMAXNUM + "件中";

                //box名前、box中の番号を管理
                if(AppPanel.boxCount == AppPanel.BOXMAXNUM)
                {
                    //MAXに達したら、件数更新して、Fin表示する
                    AppPanel.boxCount = 0;
                    //AppPanel.boxName = ??;//boxも変更
                    labelNumDetail.Text = AppPanel.boxCount + "件/" + AppPanel.BOXMAXNUM + "件中";

                    //fin表示
                    AppPanel.mainFrame.Visible = false;
                    AppPanel.finFrame.Visible = true;
                }



            }
            else if (textJAN.Text == "not sal")
            {
                //not sal
                AppPanel.mainFrame.Visible = false;
                AppPanel.notSALFrame.Visible = true;

            }
            else if (textJAN.Text == "air")
            {
                //pring air
                AppPanel.mainFrame.Visible = false;
                AppPanel.printAirFrame.Visible = true;
            }
            else if (textJAN.Text == "3flore")
            {
                //3階商品
                AppPanel.mainFrame.Visible = false;
                AppPanel.sentThreeFrame.Visible = true;
            }
            
            else//not hit
            {
                AppPanel.mainFrame.Visible = false;
                AppPanel.notHitFrame.Visible = true;
            }
            textJAN.ResetText();
        }

        private void labelNumDetail_Click(object sender, EventArgs e)
        {

        }
    }
}
