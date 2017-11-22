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
    public partial class IsCansel : UserControl
    {
        public IsCansel()
        {
            InitializeComponent();
        }

        private void ButtonConfirmPressed(object sender, EventArgs e)
        {
            AppPanel.isCanselFrame.Visible = false;
            AppPanel.mainFrame.Visible = true;
        }
    }
}
