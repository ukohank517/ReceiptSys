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
    class DealHelper
    {
        WindowChangeHelper windowChangeHelper = new WindowChangeHelper();
        public void nothit(string sku)
        {
            if (sku == "") sku = "##########";
            //windowChangeHelper.toError("この商品見つからないんだよね。。" + "\r\n SKU:" + sku);
            DialogResult dr = MessageBox.Show("この商品見つかりません:\r\n SKU"+sku, "ER", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        public void notfour(int index)
        {
            //windowChangeHelper.toError("これは四階商品ちゃうくない？");
            DialogResult dr = MessageBox.Show("三階の在庫商品", "ER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Console.WriteLine("TODO: 三階商品が来る時のDB処理(でもなさそう)?");
        }

        public void pluralProcesure(int index)
        {
            string orderid = Data.dbIfplural[index];
            int from = index;
            int to = index;

            if(orderid != "")
            {
                for(int i = index; i >= 0; i--)
                {
                    if (Data.dbIfplural[i] == orderid)
                    {
                        from = i;
                    }
                    else break;
                }
                for(int i = index; i< Data.dbIfplural.Count; i++)
                {
                    if (Data.dbIfplural[i] == orderid)
                    {
                        to = i;
                    }
                    else break;
                }
            }

            // 検索するものの数が+1;
            Data.dbNum[index]++;
            //############
            windowChangeHelper.toplural(from, to, index);
        }

        public void usePluralBox(int indexfrom, int indexto)
        {
            for (int i = indexfrom; i <= indexto; i++)
            {
                Data.dbPluraName[i] = "P" + Convert.ToString(Data.pluralBoxName);
            }
            Data.pluralBoxName++;
            Data.pluralBoxName %= Data.PLURALBOXMAX;
        }
    

        public bool finwithoutthree(int indexfrom, int indexto)
        {
            bool ret = true;
            for (int i = indexfrom; i <= indexto; i++)
            {
                String aim = Convert.ToString(Data.dbAim[i]);
                String num = Convert.ToString(Data.dbNum[i]);
                if ((aim != num) && Data.dbIfstore[i] != "在庫")
                {
                    ret = false;
                    break;
                }
            }
            return ret;
        }
        public bool showPluralBox(int indexfrom, int indexto)
        {
            AppPanel.boxTable.Visible = false;
            AppPanel.pluralTable.Visible = true;

            bool ret = true;

            //表の画面処理
            AppPanel.pluralTable.dataGridView1.Rows.Clear();
            for (int i = indexfrom; i <= indexto; i++)
            {
                String box = Data.dbPluraName[i];
                String orderid = Data.dbOrderID[i];
                String sku = Data.dbSKU[i];
                String lineNo = Data.dbLineNo[i];
                String aim = Convert.ToString(Data.dbAim[i]);
                String num = Convert.ToString(Data.dbNum[i]);

                if (aim != num) ret = false;

                AppPanel.pluralTable.dataGridView1.Rows.Add(box, orderid, sku, lineNo, aim, num);
            }

            return ret;
        }

        
        public void putintobox(int indexfrom, int indexto)
        {
            Data.IndexinBfrom.Add(indexfrom);
            Data.IndexinBto.Add(indexto);
            String boxName = Convert.ToString(Data.boxName);
            String sku = Data.dbSKU[indexfrom];
            String orderid = Data.dbOrderID[indexfrom];
            String sentway = Data.dbSendway[indexfrom];
            String lineNo = Data.dbLineNo[indexfrom];
            String NO = Convert.ToString(Data.IndexinBfrom.Count());

            //複数口の処理
            if (indexfrom != indexto || Data.dbAim[indexfrom] != 1)
            {
                sku = "複数注文の" + Data.dbPluraName[indexfrom];
                lineNo += "~" + Data.dbLineNo[indexto];
            }

            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine(indexfrom);
            Console.WriteLine(indexto);
           
            for(int i = indexfrom; i<= indexto; i++)
            {
                Data.dbBoxNo[i] = boxName;
            }

            AppPanel.mainFrame.Hint.Text = Convert.ToString(Data.IndexinBfrom.Count + "件目処理済み");
            AppPanel.boxTable.dataGridView1.Rows.Add(boxName, NO, sku, orderid, sentway, lineNo);

            AppPanel.boxTable.dataGridView1.CurrentCell = AppPanel.boxTable.dataGridView1[1, Data.IndexinBfrom.Count()-1];
        }

        public void cancelProcess(int index)
        {
            Data.dbNum[index]++;
            if (Data.dbNum[index] == Data.dbAim[index])
            {
                Data.dbBoxNo[index] = "cancel";
            }
            //windowChangeHelper.toError("一番最初にヒットした注文はキャンセルされています。もう一度検索をかけてください。 \r\n 行番号: " + Data.dbLineNo[index], "確認");
            DialogResult dr = MessageBox.Show("一番最初にヒットした注文はキャンセルされています。\r\n 処理済み/目標(件): " + Convert.ToString(Data.dbNum[index]) + "/" + Convert.ToString(Data.dbAim[index]) + " \r\n もう一度検索を掛けてみてください\r\n （行番号: " + Data.dbLineNo[index] + ")", "ER", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void sendwayDiffProcess(int index)
        {
            string errorMessage = "送信方法は特殊な【" + Data.dbSendway[index] + "】になります。ここでは処理できない。";
            if (Data.dbIfplural[index] != "" || Data.dbAim[index] != 1) errorMessage += "\r\n しかもこの商品は複数注文の一つです。";
            errorMessage += "\r\n 行番号:" + Data.dbLineNo[index];
            Data.dbBoxNo[index] = "special";
            windowChangeHelper.toError(errorMessage);
        }

        public void overtimeProcess(int index)
        {
            string errorMessage = "行番号: " + Data.dbLineNo[index] + "   2週間前の注文" +
                "\r\n 今頃のお客様の気持ち:: " +
                "\r\n僕、嫌われたのかな？( ；∀；)";
            Data.dbBoxNo[index] = "overtime";
            windowChangeHelper.toError(errorMessage);
        }


        public void printProcess()
        {
            Console.WriteLine("印刷を始まります～");

            Console.WriteLine("----商品の一覧-----");
            for(int i = 0; i < Data.IndexinBfrom.Count; i++)
            {
                int from = Data.IndexinBfrom[i];
                int to = Data.IndexinBto[i];
            }

            Console.WriteLine("グリーンラベルを印刷する");
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(green_Print);
            pd.PrintController = new System.Drawing.Printing.StandardPrintController();
            pd.PrinterSettings.PrinterName = "GreenLabel";
            pd.Print();
            if(Data.IndexinBfrom.Count > 8)
            {
                PrintDocument pd2 = new PrintDocument();
                pd2.PrintPage += new PrintPageEventHandler(green_Print2);
                pd2.PrintController = new System.Drawing.Printing.StandardPrintController();
                pd2.PrinterSettings.PrinterName = "GreenLabel";
                pd2.Print();
            }

            Console.WriteLine("インボイスを印刷する");
            
            for(int i = 0; i < Data.IndexinBfrom.Count; i++)
            {
                int from = Data.IndexinBfrom[i];
                int to = Data.IndexinBto[i];


                ExcelPrint objExcel = new ExcelPrint();
                objExcel._Name = Data.dbName[from];
                objExcel._Address1 = Data.dbAdress1[from];
                objExcel._Address2 = Data.dbAdress2[from];
                objExcel._Address3 = Data.dbAdress3[from];
                objExcel._Address4 = Data.dbAdress4[from];
                objExcel._PostNo = Data.dbPostID[from];
                objExcel._Country = Data.dbCountry[from];
                objExcel._TEL = Data.dbTel[from];
                objExcel._Count = Convert.ToString(i+1);
                objExcel._lineNo = Convert.ToString(Data.dbLineNo[from]) + "~" + Convert.ToString(Data.dbLineNo[to]);
          
                //発送方法処理
                if(Data.dbSendway[from] == "air")
                {
                    objExcel._FAX = "AIR";
                    objExcel._sendway = "air";
                }

                //地帯コード処理
                for (int code = 0; code<Data.areaCode1.Count; code++)
                {
                    if(Data.dbCode[from] == Data.areaCode1[code])
                    {
                        objExcel._Count += "/①";
                        break;
                    }
                }
                for(int code = 0; code < Data.areaCode3.Count; code++)
                {
                    if(Data.dbCode[from] == Data.areaCode3[code])
                    {
                        objExcel._Count += "/③";
                        break;
                    }
                }

                //個数計算
                objExcel._num = 0;
                for(int j = from; j <= to; j++)
                {
                    objExcel._num += Data.dbAim[j];
                }
                objExcel._description = Data.dbItem[from];
                objExcel.Print();
            }
            
            
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

            for(int no = 0;  no< 8; no++)
            {
                if (no + 1 > Data.IndexinBfrom.Count()) break;

                int from = Data.IndexinBfrom[no];
                int to = Data.IndexinBto[no];
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
                } else if (word.Length >= 2)
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
                for(int code = 0; code < Data.areaCode1.Count; code++)
                {
                    if(Data.dbCode[from] == Data.areaCode1[code])
                    {
                        e.Graphics.DrawString("/①", font, brush, new Point(typex + i * minx + 5, datey + j * miny));
                    }
                }
                for(int code =0; code < Data.areaCode3.Count; code++)
                {
                    if(Data.dbCode[from] == Data.areaCode3[code])
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
                if (no + 1 > Data.IndexinBfrom.Count()) break;

                int from = Data.IndexinBfrom[no];
                int to = Data.IndexinBto[no];
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



         public void tosingleprocess()
        {
            ReadWriteHelper readWriteHelper = new ReadWriteHelper();

            //txtファイル読み込み
            readWriteHelper.readtxt();
            //数字更新
            AppPanel.singleFrame.intxtlabel.Text = Convert.ToString(Data.sigleItemNumberintxt) + "件";            
        }

    }
}
