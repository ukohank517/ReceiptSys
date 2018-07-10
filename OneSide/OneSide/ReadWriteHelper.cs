using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;


namespace OneSide
{
    class ReadWriteHelper
    {
        //アプリの初期設定
        public void InitialRead()
        {
            using (var book = new XLWorkbook(Data.dppath, XLEventTracking.Disabled))
            {
                var sheet1 = book.Worksheet(1);
                var range = sheet1.RangeUsed();

                if(Convert.ToString(sheet1.Cell(1,22).Value) != "")
                    Data.boxName[0] = Convert.ToInt32(sheet1.Cell(1, 22).Value) + 1;
                if(Convert.ToString(sheet1.Cell(1,23).Value) != "")
                    Data.pluralBoxName[0] = Convert.ToInt32(sheet1.Cell(1, 23).Value) + 1;
                if (Convert.ToString(sheet1.Cell(1, 24).Value) != "")
                    Data.boxName[1] = Convert.ToInt32(sheet1.Cell(1, 24).Value) + 1;
                if (Convert.ToString(sheet1.Cell(1, 25).Value) != "")
                    Data.pluralBoxName[1] = Convert.ToInt32(sheet1.Cell(1, 25).Value) + 1;


                /*
                 * A    B       C   D       E        F          G           H       I       J       K       L       M           N       O           P           Q       R       S   T        U      V                           W                                X                          Y
                 * 日付	BOX No	SKU	行番号	在庫	発送方法	注文番号	名前	住所1	住所2	住所3	住所4	郵便番号	国名	国コード	電話番号	商品名	個数	[]	複数box	在庫数	既に使用された最新のbox↓	既に使用された最新の複数box↓	既に使用された最新のbox↓	既に使用された最新の複数box↓
                 * 
                 */
                for (int i = 0; i< range.RowCount(); i++)
                {
                    Data.errorline++;
                    Data.errorcolum = 0;
                    if (Convert.ToString(sheet1.Cell(i + 2, 1).Value) == "") break;
                    Data.dbindex.Add(i+2);
                    Data.dbDate.Add(Convert.ToDateTime(sheet1.Cell(i + 2, 1).Value)); Data.errorcolum++;
                    Data.dbBoxNo.Add(Convert.ToString(sheet1.Cell(i + 2, 2).Value)); Data.errorcolum++;
                    Data.dbSKU.Add(Convert.ToString(sheet1.Cell(i + 2, 3).Value)); Data.errorcolum++;
                    Data.dbLineNo.Add(Convert.ToString(sheet1.Cell(i + 2, 4).Value)); Data.errorcolum++;
                    Data.dbIfstore.Add(Convert.ToString(sheet1.Cell(i + 2, 5).Value)); Data.errorcolum++;
                    Data.dbSendway.Add(Convert.ToString(sheet1.Cell(i + 2, 6).Value)); Data.errorcolum++;
                    Data.dbOrderID.Add(Convert.ToString(sheet1.Cell(i + 2, 7).Value)); Data.errorcolum++;
                    Data.dbName.Add(Convert.ToString(sheet1.Cell(i + 2, 8).Value)); Data.errorcolum++;
                    Data.dbAdress1.Add(Convert.ToString(sheet1.Cell(i + 2, 9).Value)); Data.errorcolum++;
                    Data.dbAdress2.Add(Convert.ToString(sheet1.Cell(i + 2, 10).Value)); Data.errorcolum++;
                    Data.dbAdress3.Add(Convert.ToString(sheet1.Cell(i + 2, 11).Value)); Data.errorcolum++;
                    Data.dbAdress4.Add(Convert.ToString(sheet1.Cell(i + 2, 12).Value)); Data.errorcolum++;
                    Data.dbPostID.Add(Convert.ToString(sheet1.Cell(i + 2, 13).Value)); Data.errorcolum++;
                    Data.dbCountry.Add(Convert.ToString(sheet1.Cell(i + 2, 14).Value)); Data.errorcolum++;
                    Data.dbCode.Add(Convert.ToString(sheet1.Cell(i + 2, 15).Value)); Data.errorcolum++;
                    Data.dbTel.Add(Convert.ToString(sheet1.Cell(i + 2, 16).Value)); Data.errorcolum++;
                    Data.dbItem.Add(Convert.ToString(sheet1.Cell(i + 2, 17).Value)); Data.errorcolum++;
                    Data.dbAim.Add(Convert.ToInt32(sheet1.Cell(i + 2, 18).Value)); Data.errorcolum++;
                    Data.dbIfplural.Add(Convert.ToString(sheet1.Cell(i + 2, 19).Value)); Data.errorcolum++;
                    Data.dbPluraName.Add(Convert.ToString(sheet1.Cell(i + 2, 20).Value)); Data.errorcolum++;
                    if (Convert.ToString(sheet1.Cell(i + 2, 21).Value) == "")Data.dbNum.Add(0);
                    else Data.dbNum.Add(Convert.ToInt32(sheet1.Cell(i + 2, 21).Value));
                    Data.errorcolum++;
                    Data.dbDealNumber.Add(0);// 初期はすべて0で初期化
                }

                DealHelper dealHelper = new DealHelper();
                dealHelper.showDBtable();
            }


            
        }

        public void writefileAfterDeal()
        {
            //2台動作する時:
            //1. indexinBfrom の情報の中boxNOに入ってるものがあれば、それをErrorMessageに出力して、処理をしないようにする。
            //2. データを一方的に書き込むじゃなくて、書き込んでからの読み込む処理も必要。
            //自分があって、dbなければ書き込む。dbあって、自分なければ更新してエラー
            using (var book = new XLWorkbook(Data.dppath, XLEventTracking.Disabled))
            {
                var sheet1 = book.Worksheet(1);

                //boxの使用状況を保存
                if (Data.SIN == 0)
                {
                    sheet1.Cell("V1").SetValue(Data.boxName[0]);
                    sheet1.Cell("W1").SetValue(Data.pluralBoxName[0]);
                }
                else if(Data.SIN == 1)
                {
                    sheet1.Cell("X1").SetValue(Data.boxName[1]);
                    sheet1.Cell("Y1").SetValue(Data.pluralBoxName[1]);
                }

                //さっき処理したものの処理
                for (int i = 0; i < Data.dbNum.Count; i++)
                {
                    int excelline = Data.dbindex[i];
                    String boxno_excel = Convert.ToString(sheet1.Cell("B" + Convert.ToString(excelline)).Value);
                    String pluralname_excel = Convert.ToString(sheet1.Cell("T" + Convert.ToString(excelline)).Value);
                    int num_excel = 0;
                    if (Convert.ToString(sheet1.Cell("U" + Convert.ToString(excelline)).Value) != "")
                        num_excel = Convert.ToInt32(sheet1.Cell("U" + Convert.ToString(excelline)).Value);





                    //自分が処理してないものはdb基準に更新
                    if (Data.dbDealNumber[i] == 0)
                    {
                        Data.dbBoxNo[i] = boxno_excel;
                        Data.dbPluraName[i] = pluralname_excel;
                        Data.dbNum[i] = num_excel;
                        continue;
                    }
                    //これより下のものすべてが今処理したものになる。                   



                    //自分だけ追加したものはdbに更新
                    else if((boxno_excel=="" )&&( ((num_excel ==0)&&( Data.dbNum[i] == 0)) || num_excel + Data.dbDealNumber[i] == Data.dbNum[i] )&& (pluralname_excel=="" || pluralname_excel == Data.dbPluraName[i]))
                    {
                        sheet1.Cell("B" + Convert.ToString(excelline)).SetValue(Data.dbBoxNo[i]);
                        sheet1.Cell("T" + Convert.ToString(excelline)).SetValue(Data.dbPluraName[i]);
                        sheet1.Cell("U" + Convert.ToString(excelline)).SetValue(Data.dbNum[i]);
                        Data.dbDealNumber[i] = 0;
                        continue;
                    }

                    //c商品は個数を更新した後、自分の持ってる情報をdbに更新
                    else if(Data.dbSendway[i] == "c" && num_excel + Data.dbDealNumber[i] != Data.dbNum[i])
                    {
                        Data.dbNum[i] = num_excel + Data.dbDealNumber[i];
                        if (Data.dbNum[i] >= Data.dbAim[i]) Data.dbSendway[i] = "cancel";

                        sheet1.Cell("B" + Convert.ToString(excelline)).SetValue(Data.dbBoxNo[i]);
                        sheet1.Cell("T" + Convert.ToString(excelline)).SetValue(Data.dbPluraName[i]);
                        if (Data.dbNum[i] != 0) sheet1.Cell("U" + Convert.ToString(excelline)).SetValue(Data.dbNum[i]);
                        Data.dbDealNumber[i] = 0;
                        continue;
                    }

                    //それ以外はダブルものだけが残る。
                    else
                    {
                        Console.WriteLine("excel inside:");
                        Console.WriteLine(num_excel);
                        Console.WriteLine("dealed:");
                        Console.WriteLine(Data.dbDealNumber[i]);
                        Console.WriteLine("now num:");
                        Console.WriteLine(Data.dbNum[i]);

                        //boxに入れてるものの処理
                        String erstr1 = "";//boxの中からものを取り出す処理
                        String erstr2 = "";//複数の中からものを取り出す処理
                        for(int idx = 0; idx < Data.IndexinBfrom.Count; idx++)
                        {
                            if(Data.IndexinBfrom[idx] <=i && i <= Data.IndexinBto[idx])
                            {
                                erstr1 = "ナンバーリング【" + Convert.ToString(idx+1) + "】の商品をboxの中から取り出してください。";
                                Data.IndexinBfrom[idx] = -1;
                                Data.IndexinBto[idx] = -1;
                                break;
                            }
                        }
                        if (Data.dbPluraName[i] != "") erstr2 = "複数ボックス【" + Data.dbPluraName[i] + "】の中から商品SKU:【" + Data.dbSKU[i] +  "】のものを取り除いてください。";

                        Console.WriteLine("erstrの中身:");
                        Console.WriteLine(erstr1);
                        Console.WriteLine(erstr2);
                        if (erstr1 != "")
                        {
                            DialogResult dialogplural = MessageBox.Show(erstr1, "ER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (erstr2 != "")
                        {
                            DialogResult dialogplural = MessageBox.Show(erstr2, "ER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                book.Save();
            }
            DealHelper dealHelper = new DealHelper();
            AppPanel.dBTable.dataGridView1.Rows.Clear();
            dealHelper.showDBtable();

        }



        public void readtxt()
        {
            string text = File.ReadAllText(Data.txtpath, System.Text.Encoding.GetEncoding("Shift_JIS"));
            Console.WriteLine(text);
            List<string> lines = new List<string>();
            string[] del = { "\r\n" };

            for (int i = 0; i < text.Split(del, StringSplitOptions.None).Count(); i++)
            {
                if (text.Split(del, StringSplitOptions.None)[i] != "") {
                    lines.Add(text.Split(del, StringSplitOptions.None)[i]);
                    Console.WriteLine(" ->" + text.Split(del, StringSplitOptions.None)[i] + "<- ");
                }
            }
            Data.sigleItemNumberintxt = lines.Count();
        }
        public void savetotxt()
        {
            Encoding sjis = Encoding.GetEncoding("Shift_JIS");
            StreamWriter writer = new StreamWriter(Data.txtpath, true, sjis);
            for(int i = 0; i < Data.singleItemfrom.Count(); i++)
            {
                writer.WriteLine(Data.singleItemfrom[i] + " " + Data.singleItemto[i]);
            }
            writer.Close();
        }

        public void combine()
        {
            string txt = File.ReadAllText(Data.txtpath, System.Text.Encoding.GetEncoding("Shift_JIS"));
            List<string> lines = new List<string>();
            string[] del = { "\r\n" };
            for(int i = 0; i < txt.Split(del, StringSplitOptions.None).Count(); i++)
            {
                if (txt.Split(del, StringSplitOptions.None)[i] != "")
                    lines.Add(txt.Split(del, StringSplitOptions.None)[i]);
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (var book = new XLWorkbook(Data.dppath, XLEventTracking.Disabled))
                {
                    var sheet1 = book.Worksheet(1);

                    for(int i = 0; i < lines.Count; i++)
                    {
                        int indexfrom = 0;
                        int indexto = 0;
                        indexfrom = Convert.ToInt32(lines[i].Split(' ')[0]);
                        indexto = Convert.ToInt32(lines[i].Split(' ')[1]);

                        for (int j = indexfrom;j <= indexto; j++)
                        {
                            sheet1.Cell("B" + Convert.ToString(j+2)).SetValue("single");
                        }

                    }
                    book.Save();
                }
                Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                StreamWriter writer = new StreamWriter(@"\\\\192.168.1.37\\share\\DB_ForTest\\herehere.txt", false, sjis);
                //writer.WriteLine();
                writer.Close();

                Data.sigleItemNumberintxt = 0;
                AppPanel.singleFrame.intxtlabel.Text = "0件";

            }
            catch
            {
                WindowChangeHelper windowChangeHelper = new WindowChangeHelper();
                windowChangeHelper.torestart();
            }
        }
    }
}

