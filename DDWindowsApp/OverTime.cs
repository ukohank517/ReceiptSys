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
    public partial class OverTime : UserControl
    {
        public OverTime()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonConfirmClicked(object sender, EventArgs e)
        {
            //パネルの左を戻して、右も表示させる
            AppPanel.overTimeFrame.Visible = false;
            AppPanel.mainFrame.Visible = true;
            AppPanel.tableFrame.Visible = true;

            //TODO 印刷処理
        }
    }
}
