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
    public partial class SingleTable : UserControl
    {
        public SingleTable()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = Data.singleItemfrom.Count;
            if (i == 0) return;
            i--;

            Data.singleItemfrom.RemoveAt(i);
            Data.singleItemto.RemoveAt(i);
 
            AppPanel.singleTable.dataGridView1.Rows.RemoveAt(i);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PrintHelper printHelper = new PrintHelper();
            ReadWriteHelper readWriteHelper = new ReadWriteHelper();

            for(int i = 0; i< Data.singleItemfrom.Count(); i++)
            {
                printHelper.singlePrint(Data.singleItemfrom[i], Data.singleItemto[i], i+1);
            }
            Data.sigleItemNumberintxt += Data.singleItemfrom.Count();
            readWriteHelper.savetotxt();
            AppPanel.singleFrame.intxtlabel.Text = (Convert.ToString(Data.sigleItemNumberintxt) + "件");

            Data.singleItemfrom.Clear();
            Data.singleItemto.Clear();
            AppPanel.singleTable.dataGridView1.Rows.Clear();
        }
    }
}
