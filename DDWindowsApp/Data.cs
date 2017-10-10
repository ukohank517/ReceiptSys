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
        public static int boxName;         //boxの名前
        public static int boxCount;        //box内現在ある件数

        public const string dbpath = "\\\\192.168.1.37\\share\\DB_ForTest\\DB_sample.xlsx";
        public static List<string> dbBoxNo = new List<string>();
        public static List<string> dbSKU = new List<string>();

        
    }
}
