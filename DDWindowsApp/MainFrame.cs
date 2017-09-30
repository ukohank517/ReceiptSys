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

       

        /*
        private void label2_Click(object sender, EventArgs e)
        {

        }
        */
        private void MainFrame_Load(object sender, EventArgs e)
        {

        }

        private void buttonSearchClicked(object sender, EventArgs e)
        {

            if (textJAN.Text == "000000")
            {
                //件数増える。
                AppPanel.boxCount++;
                labelNumDetail.Text = AppPanel.boxCount + "件/20件中";

            }
            else if (textJAN.Text == "not sal")
            {
                //not sal
                AppPanel.mainFrame.Visible = false;
                AppPanel.notSALFrame.Visible = true;

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
