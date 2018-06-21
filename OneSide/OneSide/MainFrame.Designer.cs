namespace OneSide
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
            this.singlePirnt = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Hint = new System.Windows.Forms.Label();
            this.reprintbutton = new System.Windows.Forms.Button();
            this.textBoxNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // singlePirnt
            // 
            this.singlePirnt.Font = new System.Drawing.Font("MS UI Gothic", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.singlePirnt.Location = new System.Drawing.Point(3, 3);
            this.singlePirnt.Name = "singlePirnt";
            this.singlePirnt.Size = new System.Drawing.Size(118, 34);
            this.singlePirnt.TabIndex = 0;
            this.singlePirnt.Text = "単品印刷へ";
            this.singlePirnt.UseVisualStyleBackColor = false;
            this.singlePirnt.Click += new System.EventHandler(this.singlePirnt_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("MS UI Gothic", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(65, 96);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(198, 25);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(7, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "JAN:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(188, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "検索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Hint
            // 
            this.Hint.AutoSize = true;
            this.Hint.Font = new System.Drawing.Font("MS UI Gothic", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Hint.Location = new System.Drawing.Point(0, 219);
            this.Hint.Name = "Hint";
            this.Hint.Size = new System.Drawing.Size(119, 18);
            this.Hint.TabIndex = 4;
            this.Hint.Text = "アプリ起動成功";
            // 
            // reprintbutton
            // 
            this.reprintbutton.Location = new System.Drawing.Point(284, 3);
            this.reprintbutton.Name = "reprintbutton";
            this.reprintbutton.Size = new System.Drawing.Size(53, 23);
            this.reprintbutton.TabIndex = 5;
            this.reprintbutton.Text = "再印刷";
            this.reprintbutton.UseVisualStyleBackColor = true;
            this.reprintbutton.Click += new System.EventHandler(this.reprintbutton_Click);
            // 
            // textBoxNum
            // 
            this.textBoxNum.Location = new System.Drawing.Point(188, 127);
            this.textBoxNum.Name = "textBoxNum";
            this.textBoxNum.Size = new System.Drawing.Size(26, 19);
            this.textBoxNum.TabIndex = 6;
            this.textBoxNum.Text = "1";
            this.textBoxNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "件";
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNum);
            this.Controls.Add(this.reprintbutton);
            this.Controls.Add(this.Hint);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.singlePirnt);
            this.Name = "MainFrame";
            this.Size = new System.Drawing.Size(337, 296);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button singlePirnt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label Hint;
        private System.Windows.Forms.Button reprintbutton;
        private System.Windows.Forms.TextBox textBoxNum;
        private System.Windows.Forms.Label label2;
    }
}
