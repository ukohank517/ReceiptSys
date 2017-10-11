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

        public static int boxName;         //boxの名前
        public static int boxCount;        //box内現在ある件数

        public static int pluralCount = 0; //更新

        public const string dbpath = "\\\\192.168.1.37\\share\\DB_ForTest\\DB_sample.xlsx";
        public static List<string> dbBoxNo = new List<string>();
        public static List<string> dbSKU = new List<string>();

        //----複数口注文する客用リスト-----
        public static List<DateTime> pluralDate;
        public static List<int> pluralLineNo;
        public static List<int> pluralBoxNo;//頭にDを付けて文字列とする
        public static List<string> pluralOrderID;
        public static List<int> pluralAim;
        public static List<int> pluralStock;


        public static void PluralReset()
        {
            pluralDate.Clear();
            pluralLineNo.Clear();
            pluralBoxNo.Clear();
            pluralOrderID.Clear();
            pluralAim.Clear();
            pluralStock.Clear();
        }
        public static void PluralBoxRenew()
        {

        }
    }
}
