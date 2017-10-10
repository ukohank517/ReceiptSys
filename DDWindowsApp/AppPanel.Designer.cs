namespace DDWindowsApp
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
            this.panel = new System.Windows.Forms.Panel();
            this.panelTable = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            boxNoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(12, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(360, 200);
            this.panel.TabIndex = 0;
            // 
            // panelTable
            // 
            this.panelTable.Location = new System.Drawing.Point(379, 13);
            this.panelTable.Name = "panelTable";
            this.panelTable.Size = new System.Drawing.Size(450, 200);
            this.panelTable.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "現在のBox：";
            // 
            // boxNoLabel
            // 
            boxNoLabel.AllowDrop = true;
            boxNoLabel.AutoSize = true;
            boxNoLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            boxNoLabel.Location = new System.Drawing.Point(89, 223);
            boxNoLabel.Name = "boxNoLabel";
            boxNoLabel.Size = new System.Drawing.Size(33, 16);
            boxNoLabel.TabIndex = 3;
            boxNoLabel.Text = "Box";
            // 
            // AppPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 248);
            this.Controls.Add(boxNoLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelTable);
            this.Controls.Add(this.panel);
            this.Name = "AppPanel";
            this.Text = "App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panelTable;
        private System.Windows.Forms.Label label1;
        public static System.Windows.Forms.Label boxNoLabel;
    }
}

