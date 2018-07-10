namespace OneSide
{
    partial class AppPanel
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.messagepanel = new System.Windows.Forms.Panel();
            this.tablepanel = new System.Windows.Forms.Panel();
            this.panelDB = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // messagepanel
            // 
            this.messagepanel.Location = new System.Drawing.Point(12, 12);
            this.messagepanel.Name = "messagepanel";
            this.messagepanel.Size = new System.Drawing.Size(337, 310);
            this.messagepanel.TabIndex = 0;
            // 
            // tablepanel
            // 
            this.tablepanel.Location = new System.Drawing.Point(364, 12);
            this.tablepanel.Name = "tablepanel";
            this.tablepanel.Size = new System.Drawing.Size(696, 310);
            this.tablepanel.TabIndex = 1;
            // 
            // panelDB
            // 
            this.panelDB.Location = new System.Drawing.Point(12, 328);
            this.panelDB.Name = "panelDB";
            this.panelDB.Size = new System.Drawing.Size(1048, 441);
            this.panelDB.TabIndex = 2;
            // 
            // AppPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 781);
            this.Controls.Add(this.panelDB);
            this.Controls.Add(this.tablepanel);
            this.Controls.Add(this.messagepanel);
            this.Name = "AppPanel";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.AppPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel messagepanel;
        private System.Windows.Forms.Panel tablepanel;
        private System.Windows.Forms.Panel panelDB;
    }
}

