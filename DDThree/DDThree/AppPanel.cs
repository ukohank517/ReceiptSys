using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDThree
{
    public partial class AppPanel : Form
    {
        //staticで宣言することでインスタンスを固定
        public static MainFrame mainFrame;


        public static TableFrame tableFrame;

        public AppPanel()
        {
            InitializeComponent();
            mainFrame = new MainFrame();
            tableFrame = new TableFrame();

            panel.Controls.Add(mainFrame);

            panelTable.Controls.Add(tableFrame);

            mainFrame.Visible = true;

            tableFrame.Visible = true;
        }
    }
}
