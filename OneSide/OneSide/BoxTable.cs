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
    public partial class BoxTable : UserControl
    {
        public BoxTable()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = Data.IndexinBfrom.Count;
            if (i == 0) return;
            i--;//0index

            for(int index = Data.IndexinBfrom[i]; index <= Data.IndexinBto[i]; index ++)
            {
                Data.dbBoxNo[index] = "";
                Data.dbPluraName[index] = "";
                Data.dbNum[index] = 0;
            }


            Data.IndexinBfrom.RemoveAt(i) ;
            Data.IndexinBto.RemoveAt(i);

            
            AppPanel.boxTable.dataGridView1.Rows.RemoveAt(i);
        }
    }
}
// 4969133202254