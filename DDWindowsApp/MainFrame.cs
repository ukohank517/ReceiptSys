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

            //アプリ立ち上がった時の処理をここに
            Data.boxName = 100;
            Data.boxCount = 0;
            AppPanel.tableFrame.situationTable.Rows.Add(16, 5000, "4905040277305", "203-8052704-9329916", "20000");


            //helper 設定
            ReadWriteHelper rwhelper = new ReadWriteHelper();        

            //前準備:データベースから、必要なdbBoxNoとdbSKUを取ってくる
            rwhelper.TakeFromDBData();

            //昨日の結果DB(多くても16)を読み込んで、表を更新、

        }

        private void buttonSearchClicked(object sender, EventArgs e)
        {   
            string janCode = textJAN.Text;
            WindowChangeHelper windowChange = new WindowChangeHelper();
            if (janCode == "")
                windowChange.changeWindowTo("nothit");

            windowChange.checkSKU(janCode.Replace(Environment.NewLine,"").Trim());
            /*
            if (textJAN.Text == "aa")
            {
                //表更新
                //AppPanel.
                AppPanel.tableFrame.situationTable.Rows.Add(Data.boxCount+1, textJAN.Text, "OrderId", "Line");

                //件数増える。
                Data.boxCount++;
                labelNumDetail.Text = Data.boxCount + "件/" + Data.GOODSMAXNUM + "件中";

                //box名前、box中の番号を管理
                if(Data.boxCount == Data.BOXMAXNUM)
                {
                    //MAXに達したら、件数更新して、Fin表示する
                    Data.boxCount = 0;
                    //AppPanel.boxName = ??;//boxも変更
                    labelNumDetail.Text = Data.boxCount + "件/" + Data.GOODSMAXNUM + "件中";

                    //fin表示
                    AppPanel.mainFrame.Visible = false;
                    AppPanel.finFrame.Visible = true;
                }
            }
            */
            textJAN.ResetText();
        }

        private void labelNumDetail_Click(object sender, EventArgs e)
        {

        }
    }
}
