using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneSide
{
    public partial class AppPanel : Form
    {
        //staticで宣言するこででインスタンスを固定する
        public static MainFrame mainFrame;
        public static MessageFrame messageFrame;
        public static SingleFrame singleFrame;

        public static BoxTable boxTable;
        public static PluralTable pluralTable;
        public static SingleTable singleTable;

        public AppPanel()
        {
            InitializeComponent();
            mainFrame = new MainFrame();
            messageFrame = new MessageFrame();
            singleFrame = new SingleFrame();

            boxTable = new BoxTable();
            pluralTable = new PluralTable();
            singleTable = new SingleTable();

            //パネルにすべてのコントロールを追加
            messagepanel.Controls.Add(mainFrame);
            messagepanel.Controls.Add(messageFrame);
            messagepanel.Controls.Add(singleFrame);

            tablepanel.Controls.Add(boxTable);
            tablepanel.Controls.Add(pluralTable);
            tablepanel.Controls.Add(singleTable);

            //立ち上がった時、mainFrame boxTableのみを表示する。
            mainFrame.Visible = true;
            messageFrame.Visible = false;
            singleFrame.Visible = false;
            singleTable.Visible = false;
            boxTable.Visible = true;
            pluralTable.Visible = false;

        }

        /// <summary>
        /// アプリが起動する時の動作処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppPanel_Load(object sender, EventArgs e)
        {
            try
            {
                ReadWriteHelper readWriteHelper = new ReadWriteHelper();
                readWriteHelper.InitialRead();
            }
            catch
            {
                WindowChangeHelper windowChangeHelper = new WindowChangeHelper();
                windowChangeHelper.torestart();
            }
        }
    }
}
