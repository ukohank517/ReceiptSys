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

            //helper 設定
            ReadWriteHelper rwhelper = new ReadWriteHelper();        

            //前準備:データベースから、必要なdbBoxNoとdbSKUを取ってくる
            rwhelper.TakeFromDBData();
        }

        private void buttonSearchClicked(object sender, EventArgs e)
        {   
            string janCode = textJAN.Text;
            WindowChangeHelper windowChange = new WindowChangeHelper();
            if (janCode == "")
                windowChange.changeWindowTo("nothit");

            windowChange.checkSKU(janCode.Replace(Environment.NewLine,"").Trim());//行頭末の空白、改行コードを取り除いて、渡す

            textJAN.ResetText();
        }

        private void labelNumDetail_Click(object sender, EventArgs e)
        {

        }
    }
}
