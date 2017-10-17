using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/***参考文献
 * 画面遷移関連
 * http://punyo-er-met.hateblo.jp/entry/2016/04/10/103632
 * 
 * textBox中の文字制限
 * http://dobon.net/vb/dotnet/control/numerictextbox.html
 * 
 * Excel関連
 * https://www.ipentec.com/document/document.aspx?page=csharp-open-read-excel-book-and-sheet
 * 
 * 
 ***/


namespace DDWindowsApp
{
    public partial class AppPanel : Form
    {
        //staticで宣言することでインスタンスを固定
        public static MainFrame mainFrame;
        public static PluralFrame pluralFrame;
        public static NotHit notHitFrame;
        public static NotSAL notSALFrame;
        public static PrintAir printAirFrame;
        public static SentThree sentThreeFrame;
        public static Fin finFrame;

        public static TableFrame tableFrame;
        public static PluralTableFrame pluralTableFrame;


        //checkhelperページで定義し、（表示できればいいので。あとはファイルに書き込む。）
        public static List<string> pluralDate;//注文日にち
        public static List<int> pluralLineNo;//行バン後う
        public static string pluralBoxNo;//頭にPを付けて文字列とする
        public static List<string> pluralOrderID;//注文番号
        public static List<int> pluralAim;//目標個数
        public static List<int> pluralStock;//現在個数


        public AppPanel()
        {
            InitializeComponent();
            mainFrame = new MainFrame();
            pluralFrame = new PluralFrame();
            notHitFrame = new NotHit();
            notSALFrame = new NotSAL();
            printAirFrame = new PrintAir();
            sentThreeFrame = new SentThree();
            finFrame = new Fin();

            tableFrame = new TableFrame();
            pluralTableFrame = new PluralTableFrame();

            //パネルにすべてのコントロールを追加
            panel.Controls.Add(mainFrame);
            panel.Controls.Add(pluralFrame);
            panel.Controls.Add(notHitFrame);
            panel.Controls.Add(notSALFrame);
            panel.Controls.Add(printAirFrame);
            panel.Controls.Add(sentThreeFrame);
            panel.Controls.Add(finFrame);

            //テーブル専用パネルにテーブルを追加
            panelTable.Controls.Add(tableFrame);
            panelTable.Controls.Add(pluralTableFrame);

            //立ち上がった時、コントロールmainのみが見える。
            mainFrame.Visible = true;
            pluralFrame.Visible = false;
            notHitFrame.Visible = false;
            notSALFrame.Visible = false;
            printAirFrame.Visible = false;
            sentThreeFrame.Visible = false;
            finFrame.Visible = false;

            tableFrame.Visible = true;
            pluralTableFrame.Visible = false;
        }

        public static void PluralReset()
        {
            pluralDate.Clear();
            pluralLineNo.Clear();
            pluralOrderID.Clear();
            pluralAim.Clear();
            pluralStock.Clear();
        }


    }
}
