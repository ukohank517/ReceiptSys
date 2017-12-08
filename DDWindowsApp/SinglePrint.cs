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
    public partial class SinglePrint : UserControl
    {
        public SinglePrint()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //全クリア
            AppPanel.singlePringFrame.Visible = false;
            AppPanel.mainFrame.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //印刷処理

            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\n' };

            string[] word = this.textBox1.Text.Split(delimiterChars);
            List<String> words = new List<string>(); 
            for(int i = 0; i< word.Length; i++)
            {
                if (word[i] != "")
                    words.Add(word[i]);
                    
            }
            if (words.Count() % 2 == 1) this.textBox1.Text += "フォーマットが違います。";
            else
            {
                ExcelPrint objExcel = new ExcelPrint();
                objExcel._Name = this.textName.Text;
                objExcel._Address1 = this.textAddress1.Text;
                objExcel._Address2 = this.textAddress2.Text;
                objExcel._Address3 = this.textAddress3.Text;
                objExcel._Address4 = this.textAddress4.Text;
                objExcel._PostNo = this.textPost.Text;
                objExcel._Country = this.textCountry.Text;
                objExcel._TEL = this.textTEL.Text;
                objExcel._sum = words.Count() / 2;
                for (int i = 0; i < words.Count() / 2; i++)
                {
                    objExcel._description[i] = words[2*i];
                    int a = 0;
                    bool re = int.TryParse(words[2 * i + 1], out a);
                    objExcel._num[i] = a;
                }
                objExcel.Print();
            }
            Console.WriteLine(this.textBox1.Text);
        }
    }
}
