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
    public partial class SingleFrame : UserControl
    {
        public SingleFrame()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Data.nowMode = 2;
            textBox1.ResetText();
            AppPanel.singleFrame.Visible = false;
            AppPanel.mainFrame.Visible = true;
            AppPanel.boxTable.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowChangeHelper windowChangeHelper = new WindowChangeHelper();
            ReadWriteHelper readWriteHelper = new ReadWriteHelper();

            string linefrom = textBox1.Text;
            string lineto = textBox1.Text;
            if (textBox2.Text != "") lineto = textBox2.Text;

            int indexfrom = -1;
            int indexto = -1;

            


            for (int i = 0; i < Data.dbLineNo.Count; i++)
            {
                if((linefrom == Data.dbLineNo[i] && indexfrom != -1) || (lineto == Data.dbLineNo[i] && indexto != -1))
                {
                    windowChangeHelper.toError("同じ行番号は複数存在する？");
                    return;
                }
                if (linefrom == Data.dbLineNo[i]) indexfrom = i;
                if (lineto == Data.dbLineNo[i]) indexto = i;
            }


            if(indexfrom != -1 && indexto != -1)
            {
                for(int i = indexfrom; i <= indexto; i++)
                {
                    if(Data.dbIfplural[i] != Data.dbIfplural[indexfrom])
                    {
                        windowChangeHelper.toError("同じ人の注文ではない行が入ってます");
                        return;
                    }
                }
                textBox1.Text = "";
                textBox2.Text = "";


                Data.singleItemfrom.Add(indexfrom);
                Data.singleItemto.Add(indexto);

                String no = Convert.ToString(Data.singleItemto.Count());
                String date = Convert.ToString(Data.dbDate[indexfrom]);
                String orderid = Convert.ToString(Data.dbOrderID[indexfrom]);
                String sendway = Convert.ToString(Data.dbSendway[indexfrom]);
                String lineno = Convert.ToString(Data.dbLineNo[indexfrom]) + "~" + Convert.ToString(Data.dbLineNo[indexto]);

                AppPanel.singleTable.dataGridView1.Rows.Add(no, date, orderid, sendway, lineno);

                return;
            }


            windowChangeHelper.toError("入力した行番号、見つからんねん。( ；∀；)");
            return;

        }


        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if ((e.KeyChar < '0' || '9' < e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back) return;
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReadWriteHelper readWriteHelper = new ReadWriteHelper();
            readWriteHelper.combine();
        }
    }
}
