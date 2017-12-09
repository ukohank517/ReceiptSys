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
    public partial class NotFour : UserControl
    {
        public NotFour()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppPanel.notFourFrame.Visible = false;
            AppPanel.mainFrame.Visible = true;
        }
    }
}
