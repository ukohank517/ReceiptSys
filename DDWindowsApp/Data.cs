using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDWindowsApp
{
    class Data
    {
        //すべての変数をここに
        public const int GOODSMAXNUM = 16; //ボックス内グッズの数
        public const int BOXMAXNUM = 5000;
        public const int PLURALBOXMAX = 5000;//複数口注文する人用ボックス

        //現在の情報
        public static int boxName;         //boxの名前
        public static int boxCount;        //box内現在ある件数
        public static int pluralCount = 0; //更新起動時はファイルから読み込む
        //DBの情報
        public const string dbpath = "\\\\192.168.1.37\\share\\DB_ForTest\\DB_sample.xlsx";
        public static List<DateTime> dbDate = new List<DateTime>();    //日付
        public static List<string> dbBoxNo = new List<string>();       //BoxNo
        public static List<string> dbSKU = new List<string>();         //SKU
        public static List<int> dbLineNo = new List<int>();      //行番号
        public static List<string> dbStoreStatus = new List<string>(); //在庫か、入荷版なのか
        public static List<string> dbSentWay = new List<string>();     //発送方法
        public static List<string> dbOrderID = new List<string>();     //オーダーID
        public static List<int> dbNumber = new List<int>();            //注文個数
        public static List<String> dbPlural = new List<String>();      //複数違う注文商品しているのかどうか
        public static List<String> dbPluralBoxNumber = new List<String>();//複数注文用boxNo,頭にPを付けた文字列。
        public static List<String> dbPluralStore = new List<String>();       //複数注口商品の現在数(存在しない場合もあるのでstringにした)

        //-----複数注文をする人用の変数(table専用)--------------
        public static List<string> pluralDate = new List<string>();//注文日にち
        public static List<int> pluralLineNo = new List<int>();//行番号
        public static string pluralBoxNo = "";//頭にPを付けて文字列とする
        public static List<string> pluralOrderID = new List<string>();//注文番号
        public static List<int> pluralAim = new List<int>();//目標個数
        public static List<int> pluralStock = new List<int>();//現在個数 

        public static void RenewBox()
        {
            if(boxCount == GOODSMAXNUM)
            {
                boxName++;
                boxName %= BOXMAXNUM;
                boxCount = 0;
            }
        }

        public static void PluralBoxRenew()
        {
            pluralCount++;
            pluralCount %= PLURALBOXMAX;
        }
        public static void PluralRenew()
        {
            pluralDate.Clear();
            pluralLineNo.Clear();
            pluralOrderID.Clear();
            pluralAim.Clear();
            pluralStock.Clear();
        }
    }
}
