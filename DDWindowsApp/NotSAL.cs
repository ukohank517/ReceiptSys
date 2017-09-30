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
    public partial class NotSAL : UserControl
    {
        public NotSAL()
        {
            InitializeComponent();
        }

        //自分のメソッドの内容
        private void buttonConfirmClicked(object sender, EventArgs e)
        {
            
            AppPanel.notSALFrame.Visible = false;
            AppPanel.mainFrame.Visible = true;
        }
    }
}
