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
    public partial class Fin : UserControl
    {
        public Fin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonConfirm_Clicked(object sender, EventArgs e)
        {
            AppPanel.tableFrame.situationTable.Rows.Clear();
            AppPanel.finFrame.Visible = false;
            AppPanel.mainFrame.Visible = true;
        }
    }
}
