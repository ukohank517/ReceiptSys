namespace DDThree
{
    partial class MainFrame
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelJAN = new System.Windows.Forms.Label();
            this.textBoxJAN = new System.Windows.Forms.TextBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelKen = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelJAN
            // 
            this.labelJAN.AutoSize = true;
            this.labelJAN.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelJAN.Location = new System.Drawing.Point(21, 69);
            this.labelJAN.Name = "labelJAN";
            this.labelJAN.Size = new System.Drawing.Size(40, 16);
            this.labelJAN.TabIndex = 1;
            this.labelJAN.Text = "JAN:";
            // 
            // textBoxJAN
            // 
            this.textBoxJAN.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxJAN.Location = new System.Drawing.Point(67, 66);
            this.textBoxJAN.Name = "textBoxJAN";
            this.textBoxJAN.Size = new System.Drawing.Size(178, 23);
            this.textBoxJAN.TabIndex = 0;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxCount.Location = new System.Drawing.Point(251, 66);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(27, 23);
            this.textBoxCount.TabIndex = 2;
            // 
            // labelKen
            // 
            this.labelKen.AutoSize = true;
            this.labelKen.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelKen.Location = new System.Drawing.Point(284, 69);
            this.labelKen.Name = "labelKen";
            this.labelKen.Size = new System.Drawing.Size(24, 16);
            this.labelKen.TabIndex = 3;
            this.labelKen.Text = "件";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonConfirm.Location = new System.Drawing.Point(67, 154);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 4;
            this.buttonConfirm.Text = "検索";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirmClicked);
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.labelKen);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.textBoxJAN);
            this.Controls.Add(this.labelJAN);
            this.Name = "MainFrame";
            this.Size = new System.Drawing.Size(360, 200);
            this.Load += new System.EventHandler(this.MainFrame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelJAN;
        private System.Windows.Forms.TextBox textBoxJAN;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelKen;
        private System.Windows.Forms.Button buttonConfirm;
    }
}
