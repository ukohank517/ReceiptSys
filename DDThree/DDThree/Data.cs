using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDThree
{
    class Data
    {
        //定数：
        //public const int a;

        //変数:
        //public static int b;


        //すべての変数をここに
        public const int GOODSMAXNUM = 16; //ボックス内グッズの数
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
        public static String nowSentway = "";
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
        public static List<int> NuminB = new List<int>();
        //public static List<bool> isPluralinB = new List<bool>();

        //public static List<List<String>> DescriptioninBPlural = new List<List<string>>();
        //public static List<List<int>> NuminBPlural = new List<List<int>>();

        //DBの情報
        public const string dbpath = "\\\\192.168.1.37\\share\\DB_ForTest\\DB_sample.xlsx";
        public static List<DateTime> dbDate = new List<DateTime>();    //日付
        public static List<string> dbBoxNo = new List<string>();       //BoxNo
        public static List<string> dbSKU = new List<string>();         //SKU
        public static List<string> dbstore = new List<string>();       //在庫 or not

        //-----複数注文をする人用の変数(table専用)--------------
        public static List<string> pluralDate = new List<string>();//注文日日
        public static List<int> pluralLineNo = new List<int>();//行番号
        public static string pluralBoxNo = "";//頭にPを付けて文字列とする
        public static List<string> pluralOrderID = new List<string>();//注文番号
        public static List<int> pluralAim = new List<int>();//目標個数
        public static List<int> pluralStock = new List<int>();//現在個数 
        public static List<bool> pluralInThree = new List<bool>();//3階に在庫あるかどうか
        public static List<string> pluralDescription = new List<string>();//商品名


    }
}
