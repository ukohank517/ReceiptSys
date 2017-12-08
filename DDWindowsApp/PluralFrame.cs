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
    public partial class PluralFrame : UserControl
    {
        public PluralFrame()
        {
            InitializeComponent();
        }

        private void buttonConfirmClicked(object sender, EventArgs e)
        {
            pluralinBox();
            //changeWindow();
        }

        private void buttonPrintClicked(object sender, EventArgs e)
        {
            pluralinBox();
            
        }
        private void pluralinBox()
        {
            //追加処理
            if (buttonPrint.Enabled == true)
            {
                buttonPrint.Enabled = false;

                Console.WriteLine("追加せんかい！");
                Data.boxCount++;
                AppPanel.mainFrame.labelNumDetail.Text = Data.boxCount + "件/" + Data.GOODSMAXNUM + "件中";

                int NO = Data.boxCount;
                int BOX = Data.boxName;
                String Order = Data.pluralBoxNo;


                Console.WriteLine("%%%%%%%%%%%after%%%%%%%%%%%%%%");
                Console.WriteLine(Data.DescriptioninBPlural.Count());
                for (int iii = 0; iii < Data.DescriptioninBPlural.Count(); iii++)
                {
                    for (int jjj = 0; jjj < Data.DescriptioninBPlural[iii].Count(); jjj++)
                    {
                        Console.Write(Data.DescriptioninBPlural[iii][jjj]); Console.Write("   ");
                    }
                    Console.WriteLine();
                }


                //画面の右側の表を更新
                AppPanel.tableFrame.situationTable.Rows.Add(NO, BOX, "複数注文ボックス", Order, "---");
                Data.NameinB.Add(Data.nowName);
                Data.Address1inB.Add(Data.nowAdress1);
                Data.Address2inB.Add(Data.nowAdress2);
                Data.Address3inB.Add(Data.nowAdress3);
                Data.Address4inB.Add(Data.nowAdress4);
                Data.PostIDinB.Add(Data.nowPostID);
                Data.CountryinB.Add(Data.nowCountry);
                Data.TELinB.Add(Data.nowTEL);

                List<String> de = new List<string>() ;
                List<int> nu = new List<int>();
                for (int i = 0; i < Data.pluralDescription.Count(); i++) {
                    de.Add(Data.pluralDescription[i]);
                    nu.Add(Data.pluralAim[i]);
                }


                Data.DescriptioninBPlural.Add(de);
                Data.NuminBPlural.Add(nu);
                Data.DescriptioninB.Add(Convert.ToString(Data.NuminBPlural.Count() -1));

                Data.isPluralinB.Add(true);
                Console.WriteLine("%%%%%%%%%%%after%%%%%%%%%%%%%%");
                Console.WriteLine(Data.DescriptioninBPlural.Count());
                for(int iii = 0; iii < Data.DescriptioninBPlural.Count(); iii++)
                {
                    for(int jjj = 0; jjj < Data.DescriptioninBPlural[iii].Count(); jjj++)
                    {
                        Console.Write(Data.DescriptioninBPlural[iii][jjj]);Console.Write("   ");
                    }
                    Console.WriteLine();
                }
                //box情報更新
                if (Data.boxCount == Data.GOODSMAXNUM)
                {

                    AppPanel.pluralFrame.Visible = false;
                    AppPanel.finFrame.Visible = true;
                    AppPanel.pluralTableFrame.Visible = false;
                    AppPanel.tableFrame.Visible = true;
                }
                else
                    changeWindow();
                Data.RenewBox();
               
                return;
            }
            else { changeWindow(); }

        }


        private void changeWindow()
        {
            AppPanel.pluralTableFrame.Visible = false;
            AppPanel.pluralFrame.Visible = false;
            AppPanel.mainFrame.Visible = true;
            AppPanel.tableFrame.Visible = true;
        }
    }
}
