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
    public partial class PluralFrame : UserControl
    {
        public PluralFrame()
        {
            InitializeComponent();
        }

        private void buttonConfirmClicked(object sender, EventArgs e)
        {
            changeWindow();
        }

        private void buttonPrintClicked(object sender, EventArgs e)
        {
            //印刷処理
            changeWindow();
        }

        private void changeWindow()
        {
            AppPanel.pluralTableFrame.Visible = false;
            AppPanel.pluralFrame.Visible = false;
            AppPanel.mainFrame.Visible = true;
            AppPanel.tableFrame.Visible = true;
        }
    }
}
