using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSide
{
    /// <summary>
    /// すべての変数をここに保存する。
    /// </summary>
    class Data
    {
        //--------------------------設定変数--------------------------
        public const int GOODSMAXNUM = 16; // ボックス内のグッズの数
        public const int DELAYDAYS = 14;
        public const int BOXMAXNUM = 10000;
        public const int PLURALBOXMAX = 10000; // 複数口注文する人用のボックス
        public const string dppath = "\\\\192.168.1.37\\share\\DB_ForTest\\DB_sample_backup.xlsx";
        public static int nowMode = 2; // 1はsingle , 2は通常モード
        public const string txtpath = "\\\\192.168.1.37\\share\\DB_ForTest\\herehere.txt";

        //--------------------------地区コード--------------------------
        public static List<string> areaCode1 = new List<string>()
        {
            "KP","KR","TW","CN","PW","PH","HK","MH","MO","FM",
            "MN","AF","IN","ID","KH","SG","LK","TH","NP","PK",
            "BD","TP","BT","BN","VN","MY","MM","MV","LA","MP",
            "GU"
        };
        public static List<string> areaCode3 = new List<string>()
        {
            "AR","UY","EC","GY","CO","SR","CL","PY","FK","GF",
            "BR","VE","PE","BO","SH","DZ","AO","UG","EG","ET",
            "ER","GH","GA","CM","GM","GN","GW","KE","CI","KM",
            "CG","CD","ST","ZM","SL","DJ","ZW","SD","SZ","SC",
            "GQ","SN","SH","SO","TZ","CF","TN","TG","NG","NA",
            "NE","BF","BI","BJ","BW","MG","MW","ML","ZA","SS",
            "MU","MR","MZ","MA","LY","LR","RW","LS","RE"
        };



        //--------------------------現在の情報--------------------------
        public static int boxName=0;   // boxの名前
        public static int pluralBoxName=0; // 複数口注文する人用のボックス

        //--------------------------DBの情報--------------------------
        public static List<int> dbindex = new List<int>();             //必要の部分だけ取ってくるため、そのExcelの行の番号を保存する
        public static List<DateTime> dbDate = new List<DateTime>();    //日付
        public static List<String> dbBoxNo = new List<string>();       //BoxNo
        public static List<String> dbSKU = new List<string>();         //SKU
        public static List<String> dbLineNo = new List<string>();      //行番号
        public static List<String> dbIfstore = new List<string>();     //在庫 or not
        public static List<String> dbSendway = new List<string>();     //発送方法
        public static List<String> dbOrderID = new List<string>();     //注文番号
        public static List<String> dbName = new List<string>();        //お客さんの名前
        public static List<String> dbAdress1 = new List<string>();     //住所1
        public static List<String> dbAdress2 = new List<string>();     //住所2
        public static List<String> dbAdress3 = new List<string>();     //住所3
        public static List<String> dbAdress4 = new List<string>();     //住所4
        public static List<String> dbPostID = new List<string>();      //郵便番号
        public static List<String> dbCountry = new List<string>();     //国名
        public static List<String> dbCode = new List<string>();        //国コード
        public static List<String> dbTel = new List<string>();         //電話番号
        public static List<String> dbItem = new List<string>();        //商品名
        public static List<int> dbAim = new List<int>();               //この商品の注文個数
        public static List<String> dbIfplural = new List<string>();    //上下の行と複数の注文をしているのかどうか
        public static List<String> dbPluraName = new List<string>();   //複数注文商品の場合、その名前を保存する。
        public static List<int> dbNum = new List<int>();               //この商品の現在入手した個数


        //単品印刷の行番号
        public static List<int> singleItemfrom = new List<int>();
        public static List<int> singleItemto = new List<int>();
        public static int sigleItemNumberintxt = 0;
        

        //--------------------------box内の情報 (商品が入手したのち、発送前。)--------------------------
        /// <summary>
        /// 以下の処理は、もし複数口の注文があった場合、
        /// 　　　1. fromの番号とtoの番号を比較すること
        /// 　　　2. 上記のdbAimを確認すること
        /// で確認が可能
        /// </summary>
        public static List<int> IndexinBfrom = new List<int>();   //そのindexはここから　//これは上のリストのindexである。
        public static List<int> IndexinBto = new List<int>();     //そのindexはここまで


        public static List<int> beforefrom = new List<int>();
        public static List<int> beforeto = new List<int>();

        public static void FinishOneBox()
        {
            beforefrom.Clear();
            beforeto.Clear();
            for(int i =0; i < IndexinBfrom.Count; i++)
            {
                beforefrom.Add(IndexinBfrom[i]);
                beforeto.Add(IndexinBto[i]);
            }

            //box内の情報を空にする
            IndexinBfrom.Clear();
            IndexinBto.Clear();

            //box更新
            boxName++;
            boxName %= BOXMAXNUM;
        }
        
    }
    
}


/*
 * 
 * テスト用:
   4901008302683 
   4901008304601 

 * 
 * 
 */
