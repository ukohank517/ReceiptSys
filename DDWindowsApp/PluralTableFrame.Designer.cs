namespace DDWindowsApp
{
    partial class PluralTableFrame
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
            this.pluralTable = new System.Windows.Forms.DataGridView();
            this.ColumnBoxNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pluralTable)).BeginInit();
            this.SuspendLayout();
            // 
            // pluralTable
            // 
            this.pluralTable.AllowUserToOrderColumns = true;
            this.pluralTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pluralTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnBoxNo,
            this.ColumnDate,
            this.ColumnLineNo,
            this.ColumnOrderId,
            this.ColumnAim,
            this.ColumnStock});
            this.pluralTable.Location = new System.Drawing.Point(3, 3);
            this.pluralTable.Name = "pluralTable";
            this.pluralTable.RowTemplate.Height = 21;
            this.pluralTable.Size = new System.Drawing.Size(444, 197);
            this.pluralTable.TabIndex = 0;
            // 
            // ColumnBoxNo
            // 
            this.ColumnBoxNo.HeaderText = "Box";
            this.ColumnBoxNo.Name = "ColumnBoxNo";
            this.ColumnBoxNo.Width = 40;
            // 
            // ColumnDate
            // 
            this.ColumnDate.HeaderText = "日付";
            this.ColumnDate.Name = "ColumnDate";
            this.ColumnDate.Width = 60;
            // 
            // ColumnLineNo
            // 
            this.ColumnLineNo.HeaderText = "行番号";
            this.ColumnLineNo.Name = "ColumnLineNo";
            this.ColumnLineNo.Width = 70;
            // 
            // ColumnOrderId
            // 
            this.ColumnOrderId.HeaderText = "OrderId";
            this.ColumnOrderId.Name = "ColumnOrderId";
            this.ColumnOrderId.Width = 140;
            // 
            // ColumnAim
            // 
            this.ColumnAim.HeaderText = "目標";
            this.ColumnAim.Name = "ColumnAim";
            this.ColumnAim.Width = 40;
            // 
            // ColumnStock
            // 
            this.ColumnStock.HeaderText = "在庫";
            this.ColumnStock.Name = "ColumnStock";
            this.ColumnStock.Width = 50;
            // 
            // PluralTableFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pluralTable);
            this.Name = "PluralTableFrame";
            this.Size = new System.Drawing.Size(450, 200);
            ((System.ComponentModel.ISupportInitialize)(this.pluralTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView pluralTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBoxNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAim;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStock;
    }
}
