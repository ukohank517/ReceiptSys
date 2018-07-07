using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace OneSide
{
    class PrintHelper
    {
        int from;
        int to;
        public void singlePrint(int indexfrom, int indexto, int nowindex)
        {
            this.from = indexfrom;
            this.to = indexto;

            for (int index = indexfrom; index <= indexto; index++)
            {
                Console.WriteLine(Data.dbDate[index] + " " + Data.dbBoxNo[index] + " " + Data.dbSKU[index] + " " +
                    Data.dbLineNo[index] + " " + Data.dbIfstore[index] + " " + Data.dbSendway[index] + " " +
                    Data.dbOrderID[index] + " " + Data.dbName[index] + " " + Data.dbAdress1[index] + " " +
                    Data.dbAdress2[index] + " " + Data.dbAdress3[index] + " " + Data.dbAdress4[index] + " " +
                    Data.dbPostID[index] + " " + Data.dbCountry[index] + " " + Data.dbCode[index] + " " +
                    Data.dbTel[index] + " " + Data.dbItem[index] + " " + Data.dbAim[index]);
            }
            
            //return;

            /*
             * 下記のコードはdealhelperのprintprocessをコピーしたものである
             * 動作確認する必要あり。
             */
            Console.WriteLine("単品印刷をはじまりますー");
            Console.WriteLine("greenlabel必要ないので飛ばす");

            Console.WriteLine("invoiceを印刷");
            
            ExcelPrint objExcel = new ExcelPrint();
            objExcel._Name = Data.dbName[this.from];
            objExcel._Address1 = Data.dbAdress1[this.from];
            objExcel._Address2 = Data.dbAdress2[this.from];
            objExcel._Address3 = Data.dbAdress3[this.from];
            objExcel._Address4 = Data.dbAdress4[this.from];
            objExcel._PostNo = Data.dbPostID[this.from];
            objExcel._Country = Data.dbCountry[this.from];
            objExcel._TEL = Data.dbTel[this.from];
            objExcel._Count = Convert.ToString(nowindex);
            objExcel._lineNo = Convert.ToString(Data.dbLineNo[this.from]) + "~" + Convert.ToString(Data.dbLineNo[this.to]);

            //発送方法処理
            if (Data.dbSendway[this.from] == "air"){objExcel._FAX = "AIR";objExcel._sendway = "air";}
            //地帯コード処理
            for (int code = 0; code < Data.areaCode1.Count; code++){if (Data.dbCode[from] == Data.areaCode1[code]){objExcel._Count += "/①";break;}}
            for (int code = 0; code < Data.areaCode3.Count; code++){if (Data.dbCode[from] == Data.areaCode3[code]){objExcel._Count += "/③";break;}}
            //個数計算
            objExcel._num = 0;
            for (int j = this.from; j <= this.to; j++){objExcel._num += Data.dbAim[j];}
            objExcel._description = Data.dbItem[this.from];
            objExcel.Print();
        }


    }
}
