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

namespace OneSide
{
    public partial class MainFrame : UserControl
    {
        public MainFrame()
        {
            InitializeComponent();
        }

        private void singlePirnt_Click(object sender, EventArgs e)
        {
            Data.nowMode = 1;
            AppPanel.mainFrame.Visible = false;
            AppPanel.boxTable.Visible = false;
            AppPanel.singleFrame.Visible = true;
            AppPanel.singleTable.Visible = true;
            DealHelper dealHelper = new DealHelper();
            dealHelper.tosingleprocess();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //待機状態
            Cursor.Current = Cursors.WaitCursor;
            DealHelper dealHelper = new DealHelper();
            WindowChangeHelper windowChangeHelper = new WindowChangeHelper();


            string sku = textBox1.Text.Replace(Environment.NewLine,"").Trim();//行頭末の空白、改行コードを取り除いて、渡す
            int lugguageNum = Convert.ToInt32(textBoxNum.Text.Replace(Environment.NewLine, "").Trim());
            
            int index = -1;

            //バーの中を空に。
            textBox1.Text = "";
            textBoxNum.Text = "1";

            /// ##################TODO####################

            for (int i = 0; i < Data.dbSKU.Count; i++)
            {
                // 検索するSKUと同じもの　かつ　　未発送　　　　　　　かつ    　　目標数>在庫数
                if ((Data.dbSKU[i] == sku) && (Data.dbBoxNo[i] == "") && (Data.dbAim[i] > Data.dbNum[i]))
                {
                    index = i;
                    if (Data.dbIfstore[index] == "在庫")
                        continue;
                    else break;
                }
            }
            //nothit
            if(index == -1)
            {
                dealHelper.nothit(sku);
                return;
            }

            AppPanel.dBTable.dataGridView1.CurrentCell = AppPanel.dBTable.dataGridView1[3, index];
            AppPanel.dBTable.dataGridView1.Rows[index].Selected = true;
            Clipboard.SetText(Data.dbOrderID[index]);
            
            //notfour
            if (Data.dbIfstore[index] == "在庫")
            {
                dealHelper.notfour(index);
                return;
            }


            //cacel
            if(Data.dbSendway[index] == "c")
            {
                dealHelper.cancelProcess(index);
                Data.dbDealNumber[index]++;
                return;
            }

            //plural
            if (Data.dbIfplural[index] != "" || Data.dbAim[index] != 1)
            {
                dealHelper.pluralProcesure(index);
                Data.dbDealNumber[index]++;
                return;
            }

            //sendwayが違う時
            if (Data.dbSendway[index] != "air" && Data.dbSendway[index] != "*")
            {
                //data.dbdealnumberのやつは、複数の可能性もあるので、複数じゃない時のみsendwaydiffprocess二書き込んだ。
                dealHelper.sendwayDiffProcess(index);
                return;
            }

            //overtime
            //DateTime goodsTime = new DateTime(1900, 1, 1, 0, 0, 0);
            TimeSpan overTimeSpan = new TimeSpan(Data.DELAYDAYS, 0, 0, 0);//2週間はオーバータイム
            TimeSpan goodsTimeSpan = DateTime.Today - Data.dbDate[index];

            if (goodsTimeSpan > overTimeSpan)
            {
                Data.dbDealNumber[index]++;
                dealHelper.overtimeProcess(index);
                return;
            }

            Data.dbDealNumber[index]++;
            //normaldeal
            dealHelper.putintobox(index, index);
            //終了処理
            if (Data.IndexinBfrom.Count == Data.GOODSMAXNUM)
            {
                windowChangeHelper.tofinishbox();

            }
        }








        /// <summary>
        /// 再印刷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reprintbutton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Console.WriteLine("TODO:再印刷");

            Console.WriteLine("印刷を始まります～");

            Console.WriteLine("----商品の一覧-----");

            if (Data.beforefrom.Count == 0) return;

            for (int i = 0; i < Data.beforefrom.Count; i++)
            {
                int from = Data.beforefrom[i];
                int to = Data.beforeto[i];
            }

            Console.WriteLine("グリーンラベルを印刷する");
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(green_Print);
            pd.PrintController = new System.Drawing.Printing.StandardPrintController();
            pd.PrinterSettings.PrinterName = "GreenLabel";
            pd.Print();
            if (Data.beforefrom.Count > 8)
            {
                PrintDocument pd2 = new PrintDocument();
                pd2.PrintPage += new PrintPageEventHandler(green_Print2);
                pd2.PrintController = new System.Drawing.Printing.StandardPrintController();
                pd2.PrinterSettings.PrinterName = "GreenLabel";
                pd2.Print();
            }

            Console.WriteLine("インボイスを印刷する");

            for (int i = 0; i < Data.beforefrom.Count; i++)
            {
                int from = Data.beforefrom[i];
                int to = Data.beforeto[i];
                if (from == -1) continue;
                if (to == -1) continue;


                bool flag = false;
                for (int j = 0; j < Data.AlreadyDonefrom.Count(); j++){
                    if(from == Data.AlreadyDonefrom[j])
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag) continue;


                ExcelPrint objExcel = new ExcelPrint();
                objExcel._Name = Data.dbName[from];
                objExcel._Address1 = Data.dbAdress1[from];
                objExcel._Address2 = Data.dbAdress2[from];
                objExcel._Address3 = Data.dbAdress3[from];
                objExcel._Address4 = Data.dbAdress4[from];
                objExcel._PostNo = Data.dbPostID[from];
                objExcel._Country = Data.dbCountry[from];
                objExcel._TEL = Data.dbTel[from];
                objExcel._Count = Convert.ToString(i + 1);

                //発送方法処理
                if (Data.dbSendway[from] == "air")
                {
                    objExcel._FAX = "AIR";
                    objExcel._sendway = "air";
                }

                //地帯コード処理
                for (int code = 0; code < Data.areaCode1.Count; code++)
                {
                    if (Data.dbCode[from] == Data.areaCode1[code])
                    {
                        objExcel._Count += "/①";
                        break;
                    }
                }
                for (int code = 0; code < Data.areaCode3.Count; code++)
                {
                    if (Data.dbCode[from] == Data.areaCode3[code])
                    {
                        objExcel._Count += "/③";
                        break;
                    }
                }

                //個数計算
                objExcel._num = 0;
                for (int j = from; j <= to; j++)
                {
                    objExcel._num += Data.dbAim[j];
                }
                objExcel._description = Data.dbItem[from];
                objExcel.Print();
            }

        }


        private void green_Print(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Calibri", 9.0F);
            Brush brush = new SolidBrush(Color.Black);
            e.Graphics.RotateTransform(270.0F);

            //------紙の内容を書く。(ハード設置)-----
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

            for (int no = 0; no < 8; no++)
            {
                if (no + 1 > Data.beforefrom.Count()) break;

                int from = Data.beforefrom[no];
                int to = Data.beforeto[no];
                if (from == -1) continue;
                if (to == -1) continue;


                bool flag = false;
                for(int idx = 0; idx < Data.AlreadyDonefrom.Count(); idx++)
                {
                    if (from == Data.AlreadyDonefrom[idx])
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag) continue;

                int i = no / 2;
                int j = no % 2;

                //個数計算
                int number = 0;
                for (int k = from; k <= to; k++)
                {
                    Console.WriteLine("-----####-#-###-#-#-#---");
                    Console.WriteLine(Data.dbAim[k]);
                    number += Data.dbAim[k];
                }

                int unitp = 10 / number;

                string des1 = "";
                string des2 = "";
                string des3 = goodsnum[number];
                string[] word = Data.dbItem[from].Split(delimiterChars);
                if (word.Length == 1)
                {
                    des1 = word[0];
                    des2 = "";
                }
                else if (word.Length >= 2)
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
                e.Graphics.DrawString(Convert.ToString(unitp * number), font, brush, new Point(weightx + i * minx + 2 + wx + wwx, weighty + j * miny + wy - 10));
                e.Graphics.DrawString(Convert.ToString(no + 1), font, brush, new Point(typex + i * minx, datey + j * miny));
                e.Graphics.DrawString(dtToday.ToString("d") + "/Manabu Hano", font, brush, new Point(datex + i * minx, datey + j * miny));
                for (int code = 0; code < Data.areaCode1.Count; code++)
                {
                    if (Data.dbCode[from] == Data.areaCode1[code])
                    {
                        e.Graphics.DrawString("/①", font, brush, new Point(typex + i * minx + 5, datey + j * miny));
                    }
                }
                for (int code = 0; code < Data.areaCode3.Count; code++)
                {
                    if (Data.dbCode[from] == Data.areaCode3[code])
                    {
                        e.Graphics.DrawString("/③", font, brush, new Point(typex + i * minx + 5, datey + j * miny));
                    }
                }
            }
            font.Dispose();
        }

        private void green_Print2(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Calibri", 9.0F);
            Brush brush = new SolidBrush(Color.Black);
            e.Graphics.RotateTransform(270.0F);

            //------紙の内容を書く。(ハード設置)-----
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

            for (int no = 8; no < 16; no++)
            {
                if (no + 1 > Data.beforefrom.Count()) break;

                int from = Data.beforefrom[no];
                int to = Data.beforeto[no];
                if (from == -1) continue;
                if (to == -1) continue;

                bool flag = false;
                for (int idx = 0; idx < Data.AlreadyDonefrom.Count(); idx++)
                {
                    if (from == Data.AlreadyDonefrom[idx])
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag) continue;


                int i = (no - 8) / 2;
                int j = (no - 8) % 2;

                //個数計算
                int number = 0;
                for (int k = from; k <= to; k++)
                {
                    number += Data.dbAim[k];
                }

                int unitp = 10 / number;

                string des1 = "";
                string des2 = "";
                string des3 = goodsnum[number];
                string[] word = Data.dbItem[from].Split(delimiterChars);
                if (word.Length == 1)
                {
                    des1 = word[0];
                    des2 = "";
                }
                else if (word.Length >= 2)
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
                e.Graphics.DrawString(Convert.ToString(unitp * number), font, brush, new Point(weightx + i * minx + 2 + wx + wwx, weighty + j * miny + wy - 10));
                e.Graphics.DrawString(Convert.ToString(no + 1), font, brush, new Point(typex + i * minx, datey + j * miny));
                e.Graphics.DrawString(dtToday.ToString("d") + "/Manabu Hano", font, brush, new Point(datex + i * minx, datey + j * miny));
                for (int code = 0; code < Data.areaCode1.Count; code++)
                {
                    if (Data.dbCode[from] == Data.areaCode1[code])
                    {
                        e.Graphics.DrawString("/①", font, brush, new Point(typex + i * minx + 5, datey + j * miny));
                    }
                }
                for (int code = 0; code < Data.areaCode3.Count; code++)
                {
                    if (Data.dbCode[from] == Data.areaCode3[code])
                    {
                        e.Graphics.DrawString("/③", font, brush, new Point(typex + i * minx + 5, datey + j * miny));
                    }
                }
            }
            font.Dispose();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back) return;
                e.Handled = true;
            }
        }


    }
}
