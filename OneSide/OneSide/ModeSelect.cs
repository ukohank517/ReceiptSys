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
    public partial class ModeSelect : UserControl
    {
        public ModeSelect()
        {
            InitializeComponent();
        }

        //左モード
        private void button1_Click(object sender, EventArgs e)
        {
            Data.SIN = 0;
            init();
        }

        //右モード
        private void button2_Click(object sender, EventArgs e)
        {
            Data.SIN = 1;
            init();
        }

        private void init()
        {
            AppPanel.modeSelect.Visible = false;
            AppPanel.mainFrame.Visible = true;
            AppPanel.singleFrame.Visible = false;
            AppPanel.singleTable.Visible = false;
            AppPanel.boxTable.Visible = true;
            AppPanel.pluralTable.Visible = false;

            Console.WriteLine("boxname:");
            Console.WriteLine(Data.boxName[Data.SIN]);
            Console.WriteLine("pluralname:");
            Console.WriteLine(Data.pluralBoxName[Data.SIN]);
        }
    }
}
