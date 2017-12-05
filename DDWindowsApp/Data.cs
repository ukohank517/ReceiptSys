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
        public const int GOODSMAXNUM = 3; //ボックス内グッズの数
        public const int BOXMAXNUM = 5000;
        public const int PLURALBOXMAX = 5000;//複数口注文する人用ボックス

        //現在の情報
        public static int boxName;         //boxの名前
        public static int boxCount;        //box内現在ある件数
        public static int pluralCount = 0; //更新起動時はファイルから読み込む

        //現在見てる行の情報
        public static String nowLineNo = "";
        public static String nowName = "";
        public static String nowAdress1 = "";
        public static String nowAdress2 = "";
        public static String nowAdress3 = "";
        public static String nowAdress4 = "";
        public static String nowPostID = "";
        public static String nowTEL = "";
        public static String nowDescription = "";
        public static String nowCountry = "";
        public static int nownum = 0;


        //box内の情報
        public static List<String> NameinB = new List<string>();
        public static List<String> Address1inB = new List<string>();
        public static List<String> Address2inB = new List<string>();
        public static List<String> Address3inB = new List<string>();
        public static List<String> Address4inB = new List<string>();
        public static List<String> PostIDinB = new List<string>();
        public static List<String> CountryinB = new List<string>();
        public static List<String> TELinB = new List<string>();
        public static List<String> DescriptioninB = new List<string>();
        public static List<bool> isPluralinB = new List<bool>();

        public static List<String> DescriptioninBPlural = new List<string>();
        public static List<String> NuminBPlural = new List<string>();

        //DBの情報
        public const string dbpath = "\\\\192.168.1.37\\share\\DB_ForTest\\DB_sample.xlsx";
        public static List<DateTime> dbDate = new List<DateTime>();    //日付
        public static List<string> dbBoxNo = new List<string>();       //BoxNo
        public static List<string> dbSKU = new List<string>();         //SKU
       

        //-----複数注文をする人用の変数(table専用)--------------
        public static List<string> pluralDate = new List<string>();//注文日日
        public static List<int> pluralLineNo = new List<int>();//行番号
        public static string pluralBoxNo = "";//頭にPを付けて文字列とする
        public static List<string> pluralOrderID = new List<string>();//注文番号
        public static List<int> pluralAim = new List<int>();//目標個数
        public static List<int> pluralStock = new List<int>();//現在個数 
        public static List<bool> pluralInThree = new List<bool>();//3階に在庫あるかどうか
        public static List<string> pluralDescription = new List<string>();//商品名

        public static void EmptyBox()
        {
            NameinB.Clear();
            Address1inB.Clear();
            Address2inB.Clear();
            Address3inB.Clear();
            Address4inB.Clear();
            PostIDinB.Clear();
            CountryinB.Clear();
            TELinB.Clear();
            DescriptioninB.Clear();
            isPluralinB.Clear();
        }

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
            pluralInThree.Clear();
            pluralDescription.Clear();
        }
    }
}
