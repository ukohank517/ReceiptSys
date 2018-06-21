using System.Drawing;

namespace OneSide
{
    partial class BoxTable
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
            this.ColumnBoxName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnJAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSendway = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLineNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnBoxName,
            this.ColumnNo,
            this.ColumnJAN,
            this.ColumnOrderID,
            this.ColumnSendway,
            this.ColumnLineNO});
            this.dataGridView1.Font = new System.Drawing.Font("MS UI Gothic", 13F, System.Drawing.FontStyle.Bold);
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(690, 257);
            this.dataGridView1.TabIndex = 0;
            // 
            // ColumnBoxName
            // 
            this.ColumnBoxName.HeaderText = "Box名";
            this.ColumnBoxName.Name = "ColumnBoxName";
            this.ColumnBoxName.ReadOnly = true;
            // 
            // ColumnNo
            // 
            this.ColumnNo.HeaderText = "No.";
            this.ColumnNo.Name = "ColumnNo";
            this.ColumnNo.ReadOnly = true;
            this.ColumnNo.Width = 50;
            // 
            // ColumnJAN
            // 
            this.ColumnJAN.HeaderText = "JANコード";
            this.ColumnJAN.Name = "ColumnJAN";
            this.ColumnJAN.ReadOnly = true;
            this.ColumnJAN.Width = 150;
            // 
            // ColumnOrderID
            // 
            this.ColumnOrderID.HeaderText = "注文番号";
            this.ColumnOrderID.Name = "ColumnOrderID";
            this.ColumnOrderID.ReadOnly = true;
            this.ColumnOrderID.Width = 120;
            // 
            // ColumnSendway
            // 
            this.ColumnSendway.HeaderText = "発送方法";
            this.ColumnSendway.Name = "ColumnSendway";
            this.ColumnSendway.ReadOnly = true;
            this.ColumnSendway.Width = 120;
            // 
            // ColumnLineNO
            // 
            this.ColumnLineNO.HeaderText = "行番号";
            this.ColumnLineNO.Name = "ColumnLineNO";
            this.ColumnLineNO.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(508, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "最終行削除";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BoxTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BoxTable";
            this.Size = new System.Drawing.Size(696, 313);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBoxName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnJAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSendway;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLineNO;
        private System.Windows.Forms.Button button1;
    }
}
