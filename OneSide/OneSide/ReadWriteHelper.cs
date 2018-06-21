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

                if(Convert.ToString(sheet1.Cell(2,22).Value) != "")
                    Data.boxName = Convert.ToInt32(sheet1.Cell(2, 22).Value) + 1;
                if(Convert.ToString(sheet1.Cell(2,23).Value) != "")
                    Data.pluralBoxName = Convert.ToInt32(sheet1.Cell(2, 23).Value) + 1;
                

                for(int i = 0; i< range.RowCount(); i++)
                {
                    if (Convert.ToString(sheet1.Cell(i + 2, 1).Value) == "") break;
                    Data.dbindex.Add(i+2);
                    Data.dbDate.Add(Convert.ToDateTime(sheet1.Cell(i + 2, 1).Value));
                    Data.dbBoxNo.Add(Convert.ToString(sheet1.Cell(i + 2, 2).Value));
                    Data.dbSKU.Add(Convert.ToString(sheet1.Cell(i + 2, 3).Value));
                    Data.dbLineNo.Add(Convert.ToString(sheet1.Cell(i + 2, 4).Value));
                    Data.dbIfstore.Add(Convert.ToString(sheet1.Cell(i + 2, 5).Value));
                    Data.dbSendway.Add(Convert.ToString(sheet1.Cell(i + 2, 6).Value));
                    Data.dbOrderID.Add(Convert.ToString(sheet1.Cell(i + 2, 7).Value));
                    Data.dbName.Add(Convert.ToString(sheet1.Cell(i + 2, 8).Value));
                    Data.dbAdress1.Add(Convert.ToString(sheet1.Cell(i + 2, 9).Value));
                    Data.dbAdress2.Add(Convert.ToString(sheet1.Cell(i + 2, 10).Value));
                    Data.dbAdress3.Add(Convert.ToString(sheet1.Cell(i + 2, 11).Value));
                    Data.dbAdress4.Add(Convert.ToString(sheet1.Cell(i + 2, 12).Value));
                    Data.dbPostID.Add(Convert.ToString(sheet1.Cell(i + 2, 13).Value));
                    Data.dbCountry.Add(Convert.ToString(sheet1.Cell(i + 2, 14).Value));
                    Data.dbCode.Add(Convert.ToString(sheet1.Cell(i + 2, 15).Value));
                    Data.dbTel.Add(Convert.ToString(sheet1.Cell(i + 2, 16).Value));
                    Data.dbItem.Add(Convert.ToString(sheet1.Cell(i + 2, 17).Value));
                    Data.dbAim.Add(Convert.ToInt32(sheet1.Cell(i + 2, 18).Value));
                    Data.dbIfplural.Add(Convert.ToString(sheet1.Cell(i + 2, 19).Value));
                    Data.dbPluraName.Add(Convert.ToString(sheet1.Cell(i + 2, 20).Value));
                    if (Convert.ToString(sheet1.Cell(i + 2, 21).Value) == "")Data.dbNum.Add(0);
                    else Data.dbNum.Add(Convert.ToInt32(sheet1.Cell(i + 2, 21).Value));
                }
            }
        }

        public void writefileAfterDeal()
        {
            //2台動作する時:
            //1. indexinBfrom の情報の中boxNOに入ってるものがあれば、それをErrorMessageに出力して、処理をしないようにする。
            //2. データを一方的に書き込むじゃなくて、書き込んでからの読み込む処理も必要。
            using (var book = new XLWorkbook(Data.dppath, XLEventTracking.Disabled))
            {
                var sheet1 = book.Worksheet(1);

                sheet1.Cell("V2").SetValue(Data.boxName);
                sheet1.Cell("W2").SetValue(Data.pluralBoxName);

                for (int i = 0; i < Data.dbNum.Count; i++)
                {
                    int index = Data.dbindex[i];

                    sheet1.Cell("B" + Convert.ToString(index)).SetValue(Data.dbBoxNo[i]);
                    sheet1.Cell("T" + Convert.ToString(index)).SetValue(Data.dbPluraName[i]);
                    if(Data.dbNum[i] != 0)sheet1.Cell("U" + Convert.ToString(index)).SetValue(Data.dbNum[i]);
                    //Console.WriteLine("see here");
                    //Console.WriteLine(Data.dbBoxNo[index], " ", Data.dbPluraName[index], " ", Data.dbNum[index]);
                }
                book.Save();
            }
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

