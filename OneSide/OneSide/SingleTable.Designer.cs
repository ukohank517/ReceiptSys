namespace OneSide
{
    partial class SingleTable
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSendway = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNo,
            this.ColumnDate,
            this.ColumnOrderID,
            this.ColumnSendway,
            this.ColumnLine});
            this.dataGridView1.Font = new System.Drawing.Font("MS UI Gothic", 13F, System.Drawing.FontStyle.Bold);
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(690, 268);
            this.dataGridView1.TabIndex = 0;
            // 
            // ColumnNo
            // 
            this.ColumnNo.HeaderText = "No";
            this.ColumnNo.Name = "ColumnNo";
            this.ColumnNo.Width = 80;
            // 
            // ColumnDate
            // 
            this.ColumnDate.HeaderText = "日付";
            this.ColumnDate.Name = "ColumnDate";
            this.ColumnDate.Width = 150;
            // 
            // ColumnOrderID
            // 
            this.ColumnOrderID.HeaderText = "注文番号";
            this.ColumnOrderID.Name = "ColumnOrderID";
            this.ColumnOrderID.Width = 200;
            // 
            // ColumnSendway
            // 
            this.ColumnSendway.HeaderText = "発送方法";
            this.ColumnSendway.Name = "ColumnSendway";
            this.ColumnSendway.Width = 120;
            // 
            // ColumnLine
            // 
            this.ColumnLine.HeaderText = "行番号";
            this.ColumnLine.Name = "ColumnLine";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(21, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "表印刷";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("MS UI Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.Location = new System.Drawing.Point(522, 277);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 33);
            this.button2.TabIndex = 2;
            this.button2.Text = "最終行削除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SingleTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SingleTable";
            this.Size = new System.Drawing.Size(696, 313);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSendway;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLine;
    }
}
