namespace OneSide
{
    partial class MessageFrame
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
            this.textbox = new System.Windows.Forms.TextBox();
            this.button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textbox
            // 
            this.textbox.Font = new System.Drawing.Font("MS UI Gothic", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textbox.Location = new System.Drawing.Point(31, 20);
            this.textbox.Multiline = true;
            this.textbox.Name = "textbox";
            this.textbox.ReadOnly = true;
            this.textbox.Size = new System.Drawing.Size(262, 98);
            this.textbox.TabIndex = 0;
            // 
            // button
            // 
            this.button.Font = new System.Drawing.Font("MS UI Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button.Location = new System.Drawing.Point(200, 185);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(104, 33);
            this.button.TabIndex = 2;
            this.button.Text = "button";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // MessageFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button);
            this.Controls.Add(this.textbox);
            this.Name = "MessageFrame";
            this.Size = new System.Drawing.Size(337, 237);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textbox;
        public System.Windows.Forms.Button button;
    }
}
