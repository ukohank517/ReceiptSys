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
            AppPanel.tableFrame.situationTable.Rows.Clear();
            AppPanel.finFrame.Visible = false;
            AppPanel.mainFrame.Visible = true;

            //GreenLabel印刷
            Console.WriteLine("printグリーンラベル");           
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(green_Print);
            pd.PrinterSettings.PrinterName = "GreenLabel";
            pd.Print();
            pd.Print();

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
                if (Data.isPluralinB[i] == false)
                {
                    objExcel._sum = 1;
                    objExcel._num[0] = 1;
                    objExcel._description[0] = Data.DescriptioninB[i];
                }
                else
                {
                    objExcel._sum = Data.DescriptioninBPlural[Convert.ToInt32(Data.DescriptioninB[i])].Count();
                    for(int j = 0; j < objExcel._sum; j++)
                    {
                        objExcel._description[j] = Data.DescriptioninBPlural[Convert.ToInt32(Data.DescriptioninB[i])][j];
                        objExcel._num[j] = Data.NuminBPlural[Convert.ToInt32(Data.DescriptioninB[i])][j];
                    }
                }
                objExcel.Print();
            }
            Data.EmptyBox();

            //ExcelPrint objExcel = new ExcelPrint();
            //objExcel._B2 = "Shipping Address: xxxxxxxxxx";//ExcelPring.csも弄らないといけない。
            //objExcel.Print();
            
        }

        /// <summary>
        /// (-1100,0)      (-100,0)
        /// (-1100,700)
        /// |------------------------------------------------------------------------
        /// |                                                                 ↑　　　
        /// |  |←----------------------minx-----------------→|              |　　　　
        /// |  Cosmetics     ＼                                 Cosmetics     |
        /// |                  }lh                                            |
        /// |  (non alcohol) ／         USD                                   |
        /// |                            g      10                            |
        /// |                         -                                       |
        /// |                        ↑                                       |
        /// |                        wy                                      miny
        /// |                        ↓                                       |
        /// |                         -       USD                             |
        /// |                            g      10                            | 
        /// |                            |← wx→|                            |
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


            int typex = -1100; int typey = 145;
            int weightx = -950; int weighty = 180;
            int datex = -1030; int datey = 370;
            int minx = 293;
            int miny = 410;

            int wx = 45;
            int wy = 80;
            int lh = 20;

            DateTime dtToday = DateTime.Today;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    e.Graphics.DrawString("Cosmetics", font, brush, new Point(typex + i * minx, typey + j * miny));
                    e.Graphics.DrawString("(non alcohol)", font, brush, new Point(typex + i * minx, typey + j * miny + lh));
                    e.Graphics.DrawString("80g", font, brush, new Point(weightx + i * minx, weighty + j * miny));
                    e.Graphics.DrawString("USD", font, brush, new Point(weightx + i * minx + wx, weighty + j * miny - lh));
                    e.Graphics.DrawString("10", font, brush, new Point(weightx + i * minx + wx, weighty + j * miny));
                    e.Graphics.DrawString("g", font, brush, new Point(weightx + i * minx, weighty + j * miny + wy));
                    e.Graphics.DrawString("USD", font, brush, new Point(weightx + i * minx + wx, weighty + j * miny + wy - lh));
                    e.Graphics.DrawString("10", font, brush, new Point(weightx + i * minx + 2 + wx, weighty + j * miny + wy));
                    e.Graphics.DrawString(dtToday.ToString("d")+"/Manabu Hano", font, brush, new Point(datex + i * minx, datey + j * miny));
                }
            }
         font.Dispose();
        }


    }
}
