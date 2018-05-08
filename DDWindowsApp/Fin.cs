using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

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
            Console.WriteLine("show you the way to send ");
            for(int i = 0; i < Data.SendwayinB.Count; i++)
            {
                Console.WriteLine(Data.SendwayinB[i]);
            }

            Cursor.Current = Cursors.WaitCursor;

            AppPanel.tableFrame.situationTable.Rows.Clear();
            AppPanel.finFrame.Visible = false;
            AppPanel.mainFrame.Visible = true;

            //GreenLabel印刷
            Console.WriteLine("printグリーンラベル");           
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(green_Print);
            pd.PrintController = new System.Drawing.Printing.StandardPrintController();
            pd.PrinterSettings.PrinterName = "GreenLabel";
            pd.Print();
            if (Data.DescriptioninB.Count > 8)
            {
                PrintDocument pd2 = new PrintDocument();
                pd2.PrintPage += new PrintPageEventHandler(green_Print2);
                pd2.PrintController = new System.Drawing.Printing.StandardPrintController();
                pd2.PrinterSettings.PrinterName = "GreenLabel";
                pd2.Print();
            }
            //invoice印刷
            Console.WriteLine("printインボイス");    
            
            for (int i = 0; i < Data.GOODSMAXNUM; i++)
            {

                ExcelPrint objExcel = new ExcelPrint();
                objExcel._Name = Data.NameinB[i];
                objExcel._Address1 = Data.Address1inB[i];
                objExcel._Address2 = Data.Address2inB[i];
                objExcel._Address3 = Data.Address3inB[i];
                objExcel._Address4 = Data.Address4inB[i];
                objExcel._PostNo = Data.PostIDinB[i];
                objExcel._Country = Data.CountryinB[i];
                objExcel._TEL = Data.TELinB[i];
                objExcel._Count = Convert.ToString(i+1);
                if(Data.SendwayinB[i] == "air")
                {
                    objExcel._FAX = "AIR";
                    objExcel._sendway = "air";
                }
                for (int co = 0; co< Data.areaCode1.Count; co++)
                {
                    if(Data.CountryCodeinB[i] == Data.areaCode1[co])
                    {
                        objExcel._Count += "/①";
                        break;
                    }
                }
                for(int co = 0; co < Data.areaCode3.Count; co++)
                {
                    if(Data.CountryCodeinB[i] == Data.areaCode3[co])
                    {
                        objExcel._Count += "/③";
                        break;
                    }
                }
                objExcel._num = Data.NuminB[i];
                objExcel._description = Data.DescriptioninB[i];
                objExcel.Print();
            }
            
            Data.EmptyBox();
        }

        /// <summary>
        /// (-1100,0)      (-100,0)
        /// (-1100,700)
        /// |------------------------------------------------------------------------
        /// |                                                                 ↑　　　
        /// |  |←----------------------minx-----------------→|              |　　　　
        /// |  Cosmetics     ＼                                 Cosmetics     |
        /// |                  }lh                                            |
        /// |  (non alcohol) ／                 USD                           |
        /// |                            g      10                            |
        /// |                         -                                       |
        /// |                        ↑                                       |
        /// |                        wy                                      miny
        /// |                        ↓                                       |
        /// |                         -            USD                        |
        /// |                          |<wwx>| g      10                      | 
        /// |                                 |← wx→|                       |
        /// |                                                                 |
        /// |                                                                 |
        /// |            2017/01/01/Manabu Hano                               |  
        /// |                                                                 |
        /// |                                                                 ↓
        /// |----------------------------------------------------------------------------------------------------
        /// |  Cosmetics
        /// |  (non alcohol)                   USD
        /// |                            g      10
        /// |
        /// |
        /// |
        /// |                                  USD 
        /// |                            g      10
        /// |
        /// |
        /// |
        /// |            2017/01/01/Manabu Hano   
        /// |
        /// |
        /// |
        /// |-------------------------------------------------------------------------
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void green_Print(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Calibri", 9.0f);
            Brush brush = new SolidBrush(Color.Black);
            e.Graphics.RotateTransform(270.0F);


            //-------紙の内容を書く。--------------------------


            int typex = -1100; int typey = 215;
            int weightx = -1000; int weighty = 230;
            int datex = -1030; int datey = 365;
            int minx = 293;
            int miny = 415;

            int wx = 35;
            int wwx = 40;
            int wy = 65;
            int lh = 20;

            IDictionary<int, string> goodsnum = new Dictionary<int,string>();
            goodsnum.Add(1, "");
            goodsnum.Add(2, "two piece");
            goodsnum.Add(3, "three piece");
            goodsnum.Add(4, "four piece");
            goodsnum.Add(5, "five piece");
            goodsnum.Add(6, "six piece");
            goodsnum.Add(7, "seven piece");
            goodsnum.Add(8, "eight piece");
            goodsnum.Add(9, "nine piece");
            goodsnum.Add(10, "ten piece");

            
            DateTime dtToday = DateTime.Today;

            char[] delimiterChars = { '(', ')' };

            
            for(int times = 0; times < 8; times++)
            {
                if (times+1 > Data.DescriptioninB.Count()) break;
               
                int i = times / 2;
                int j = times % 2;
                
                int unitp = 10 / Data.NuminB[times];

                string des1 = "";
                string des2 = "";
                string des3 = goodsnum[Data.NuminB[times]];
                string[] word = Data.DescriptioninB[times].Split(delimiterChars);
                if(word.Length == 1)
                {
                    des1 = word[0];
                    des2 = "";
                }
                if(word.Length >= 2)
                {
                    des1 = word[0];
                    des2 = word[1];
                }

                e.Graphics.DrawString(des1, font, brush, new Point(typex + i * minx, typey + j * miny));
                e.Graphics.DrawString("(" + des2 + ")", font, brush, new Point(typex + i * minx, typey + j * miny + lh));
                e.Graphics.DrawString(des3, font, brush, new Point(typex + i * minx, typey + j * miny + lh + lh));
                e.Graphics.DrawString("  g", font, brush, new Point(weightx + i * minx, weighty + j * miny));
                e.Graphics.DrawString("USD", font, brush, new Point(weightx + i * minx + wx, weighty + j * miny - lh));
                e.Graphics.DrawString(Convert.ToString(unitp), font, brush, new Point(weightx + i * minx + wx, weighty + j * miny));
                //e.Graphics.DrawString("  g", font, brush, new Point(weightx + i * minx + wwx, weighty + j * miny + wy));
                e.Graphics.DrawString("USD", font, brush, new Point(weightx + i * minx + wwx + wx, weighty + j * miny + wy - lh));
                e.Graphics.DrawString(Convert.ToString(unitp * Data.NuminB[times]), font, brush, new Point(weightx + i * minx + 2 + wx + wwx, weighty + j * miny + wy - 10));
                e.Graphics.DrawString(Convert.ToString(times+1), font, brush, new Point(typex + i * minx, datey + j * miny));
                e.Graphics.DrawString(dtToday.ToString("d")+"/Manabu Hano", font, brush, new Point(datex + i * minx, datey + j * miny));
                for(int co = 0; co < Data.areaCode1.Count; co++)
                {
                    if (Data.CountryCodeinB[times] == Data.areaCode1[co])
                    {
                        e.Graphics.DrawString("/①", font, brush, new Point(typex + i * minx + 5, datey + j * miny));
                        break;
                    }
                }
                for(int co = 0; co < Data.areaCode3.Count; co++)
                {
                    if(Data.CountryCodeinB[times] == Data.areaCode3[co])
                    {
                        e.Graphics.DrawString("/③", font, brush, new Point(typex + i * minx + 5, datey + j * miny));
                        break;
                    }
                }
            }
         font.Dispose();
        }

        private void green_Print2(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Calibri", 9.0f);
            Brush brush = new SolidBrush(Color.Black);
            e.Graphics.RotateTransform(270.0F);


            //-------紙の内容を書く。--------------------------


            int typex = -1100; int typey = 215;
            int weightx = -1000; int weighty = 230;
            int datex = -1030; int datey = 365;
            int minx = 293;
            int miny = 415;

            int wx = 35;
            int wwx = 40;
            int wy = 65;
            int lh = 20;

            IDictionary<int, string> goodsnum = new Dictionary<int, string>();
            goodsnum.Add(1, "one piece");
            goodsnum.Add(2, "two piece");
            goodsnum.Add(3, "three piece");
            goodsnum.Add(4, "four piece");
            goodsnum.Add(5, "five piece");
            goodsnum.Add(6, "six piece");
            goodsnum.Add(7, "seven piece");
            goodsnum.Add(8, "eight piece");
            goodsnum.Add(9, "nine piece");
            goodsnum.Add(10, "ten piece");


            DateTime dtToday = DateTime.Today;

            char[] delimiterChars = { '(', ')' };


            for (int times = 0; times < 8; times++)
            {
                if (times + 9 > Data.DescriptioninB.Count()) break;

                int i = times / 2;
                int j = times % 2;

                int unitp = 10 / Data.NuminB[times+8];

                string des1 = "";
                string des2 = "";
                string des3 = goodsnum[Data.NuminB[times+8]]; 
                string[] word = Data.DescriptioninB[times+8].Split(delimiterChars);
                if (word.Length == 1)
                {
                    des1 = word[0];
                    des2 = "";
                }
                if (word.Length >= 2)
                {
                    des1 = word[0];
                    des2 = word[1];
                }

                e.Graphics.DrawString(des1, font, brush, new Point(typex + i * minx, typey + j * miny));
                e.Graphics.DrawString("(" + des2 + ")", font, brush, new Point(typex + i * minx, typey + j * miny + lh));
                e.Graphics.DrawString(des3, font, brush, new Point(typex + i * minx, typey + j * miny + lh + lh));
                e.Graphics.DrawString("  g", font, brush, new Point(weightx + i * minx, weighty + j * miny));
                e.Graphics.DrawString("USD", font, brush, new Point(weightx + i * minx + wx, weighty + j * miny - lh));
                e.Graphics.DrawString(Convert.ToString(unitp), font, brush, new Point(weightx + i * minx + wx, weighty + j * miny));
                //e.Graphics.DrawString("  g", font, brush, new Point(weightx + i * minx, weighty + j * miny + wy));
                e.Graphics.DrawString("USD", font, brush, new Point(weightx + i * minx + wx + wwx, weighty + j * miny + wy - lh));
                e.Graphics.DrawString(Convert.ToString(unitp * Data.NuminB[times + 8]), font, brush, new Point(weightx + i * minx + 2 + wx + wwx, weighty + j * miny + wy - 10));
                e.Graphics.DrawString(Convert.ToString(times+9), font, brush, new Point(typex + i * minx, datey + j * miny));
                e.Graphics.DrawString(dtToday.ToString("d") + "/Manabu Hano", font, brush, new Point(datex + i * minx, datey + j * miny));
            }
            font.Dispose();
        }


    }
}
