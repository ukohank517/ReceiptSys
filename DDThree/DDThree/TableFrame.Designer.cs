namespace DDThree
{
    partial class TableFrame
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
            this.situationTable = new System.Windows.Forms.DataGridView();
            this.ColumnNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBoxNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnJAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.situationTable)).BeginInit();
            this.SuspendLayout();
            // 
            // situationTable
            // 
            this.situationTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.situationTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNo,
            this.ColumnBoxNo,
            this.ColumnJAN,
            this.ColumnOrder,
            this.ColumnLine});
            this.situationTable.Location = new System.Drawing.Point(0, 0);
            this.situationTable.Name = "situationTable";
            this.situationTable.RowTemplate.Height = 21;
            this.situationTable.Size = new System.Drawing.Size(450, 200);
            this.situationTable.TabIndex = 0;
            // 
            // ColumnNo
            // 
            this.ColumnNo.HeaderText = "No.";
            this.ColumnNo.Name = "ColumnNo";
            this.ColumnNo.ReadOnly = true;
            this.ColumnNo.Width = 50;
            // 
            // ColumnBoxNo
            // 
            this.ColumnBoxNo.HeaderText = "BOX";
            this.ColumnBoxNo.Name = "ColumnBoxNo";
            this.ColumnBoxNo.Width = 55;
            // 
            // ColumnJAN
            // 
            this.ColumnJAN.HeaderText = "JANコード";
            this.ColumnJAN.Name = "ColumnJAN";
            this.ColumnJAN.ReadOnly = true;
            // 
            // ColumnOrder
            // 
            this.ColumnOrder.HeaderText = "OrderID";
            this.ColumnOrder.Name = "ColumnOrder";
            this.ColumnOrder.ReadOnly = true;
            this.ColumnOrder.Width = 130;
            // 
            // ColumnLine
            // 
            this.ColumnLine.HeaderText = "行番号";
            this.ColumnLine.Name = "ColumnLine";
            this.ColumnLine.ReadOnly = true;
            this.ColumnLine.Width = 70;
            // 
            // TableFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.situationTable);
            this.Name = "TableFrame";
            this.Size = new System.Drawing.Size(450, 200);
            ((System.ComponentModel.ISupportInitialize)(this.situationTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView situationTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBoxNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnJAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLine;
    }
}
