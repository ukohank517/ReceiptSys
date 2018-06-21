using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneSide
{
    public partial class MessageFrame : UserControl
    {
        public MessageFrame()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            ReadWriteHelper readWriteHelper = new ReadWriteHelper();

            AppPanel.messageFrame.Visible = false;

            if (Data.nowMode == 1) AppPanel.singleFrame.Visible = true;
            else AppPanel.mainFrame.Visible = true;

            if(button.Text == "印刷" || button.Text == "再更新")
            {
                //待ち状態にする
                Cursor.Current = Cursors.WaitCursor;

                Console.WriteLine("印刷して、ボックスを更新する！");
               
                try
                {
                    //ファイルへ書き込む
                    readWriteHelper.writefileAfterDeal();
                }
                catch
                {
                    WindowChangeHelper windowChangeHelper = new WindowChangeHelper();
                    String errormessage = "Excelファイルを開けませんでした。状況を確認したうえ、再更新をおこなってください。";
                    windowChangeHelper.toError(errormessage, "再更新");
                }

                DealHelper dealHelper = new DealHelper();
                dealHelper.printProcess();

                Data.FinishOneBox();
                AppPanel.boxTable.dataGridView1.Rows.Clear();
                AppPanel.mainFrame.Hint.Text = "印刷完了";
            }
            if (Data.nowMode == 2) AppPanel.boxTable.Visible = true;
            else AppPanel.singleTable.Visible = true;

            AppPanel.pluralTable.Visible = false;


            //終了処理
            if (Data.IndexinBfrom.Count == Data.GOODSMAXNUM)
            {
                WindowChangeHelper windowChangeHelper = new WindowChangeHelper();
                windowChangeHelper.tofinishbox();

            }

        }

    }
}
