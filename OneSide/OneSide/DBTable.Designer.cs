namespace OneSide
{
    partial class DBTable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBoxNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLineNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSendway = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrderNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 13F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDate,
            this.ColumnBoxNo,
            this.ColumnSKU,
            this.ColumnLineNO,
            this.ColumnSendway,
            this.ColumnOrderNO,
            this.ColumnNum,
            this.ColumnStore});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 15F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(1042, 435);
            this.dataGridView1.TabIndex = 0;
            // 
            // ColumnDate
            // 
            this.ColumnDate.HeaderText = "日付";
            this.ColumnDate.Name = "ColumnDate";
            this.ColumnDate.ReadOnly = true;
            this.ColumnDate.Width = 135;
            // 
            // ColumnBoxNo
            // 
            this.ColumnBoxNo.HeaderText = "BoxNo";
            this.ColumnBoxNo.Name = "ColumnBoxNo";
            this.ColumnBoxNo.ReadOnly = true;
            this.ColumnBoxNo.Width = 70;
            // 
            // ColumnSKU
            // 
            this.ColumnSKU.HeaderText = "SKU";
            this.ColumnSKU.Name = "ColumnSKU";
            this.ColumnSKU.ReadOnly = true;
            this.ColumnSKU.Width = 150;
            // 
            // ColumnLineNO
            // 
            this.ColumnLineNO.HeaderText = "行番号";
            this.ColumnLineNO.Name = "ColumnLineNO";
            this.ColumnLineNO.ReadOnly = true;
            this.ColumnLineNO.Width = 90;
            // 
            // ColumnSendway
            // 
            this.ColumnSendway.HeaderText = "発送方法";
            this.ColumnSendway.Name = "ColumnSendway";
            this.ColumnSendway.ReadOnly = true;
            this.ColumnSendway.Width = 110;
            // 
            // ColumnOrderNO
            // 
            this.ColumnOrderNO.HeaderText = "複数注文";
            this.ColumnOrderNO.Name = "ColumnOrderNO";
            this.ColumnOrderNO.ReadOnly = true;
            this.ColumnOrderNO.Width = 210;
            // 
            // ColumnNum
            // 
            this.ColumnNum.HeaderText = "個数";
            this.ColumnNum.Name = "ColumnNum";
            this.ColumnNum.ReadOnly = true;
            // 
            // ColumnStore
            // 
            this.ColumnStore.HeaderText = "在庫数";
            this.ColumnStore.Name = "ColumnStore";
            this.ColumnStore.ReadOnly = true;
            // 
            // DBTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "DBTable";
            this.Size = new System.Drawing.Size(1048, 441);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBoxNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLineNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSendway;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStore;
    }
}
