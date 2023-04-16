namespace TPH.LIS.Analyzer.Controls
{
    partial class ucCoCanhBaoTheoMay
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblThongTinMay = new System.Windows.Forms.Label();
            this.dtgContent = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgContent)).BeginInit();
            this.SuspendLayout();
            // 
            // lblThongTinMay
            // 
            this.lblThongTinMay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblThongTinMay.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblThongTinMay.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongTinMay.ForeColor = System.Drawing.Color.Black;
            this.lblThongTinMay.Location = new System.Drawing.Point(0, 0);
            this.lblThongTinMay.Name = "lblThongTinMay";
            this.lblThongTinMay.Size = new System.Drawing.Size(234, 25);
            this.lblThongTinMay.TabIndex = 0;
            this.lblThongTinMay.Text = "Máy XN: 7001 - CellDyn Ruby";
            this.lblThongTinMay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtgContent
            // 
            this.dtgContent.AllowUserToAddRows = false;
            this.dtgContent.AllowUserToDeleteRows = false;
            this.dtgContent.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgContent.ColumnHeadersVisible = false;
            this.dtgContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colNoiDung,
            this.colThoiGian,
            this.colRecordID});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgContent.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgContent.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgContent.Location = new System.Drawing.Point(0, 25);
            this.dtgContent.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.dtgContent.Name = "dtgContent";
            this.dtgContent.ReadOnly = true;
            this.dtgContent.RowHeadersVisible = false;
            this.dtgContent.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgContent.RowTemplate.DividerHeight = 1;
            this.dtgContent.RowTemplate.Height = 26;
            this.dtgContent.Size = new System.Drawing.Size(234, 20);
            this.dtgContent.TabIndex = 1;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "MaXnMay";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colID.DefaultCellStyle = dataGridViewCellStyle1;
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 180;
            // 
            // colNoiDung
            // 
            this.colNoiDung.DataPropertyName = "KetQua";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colNoiDung.DefaultCellStyle = dataGridViewCellStyle2;
            this.colNoiDung.HeaderText = "Nội dung";
            this.colNoiDung.Name = "colNoiDung";
            this.colNoiDung.ReadOnly = true;
            this.colNoiDung.Width = 50;
            // 
            // colThoiGian
            // 
            this.colThoiGian.DataPropertyName = "TgCoKetQua";
            dataGridViewCellStyle3.Format = "HH:mm:ss dd/MM/yyyy";
            this.colThoiGian.DefaultCellStyle = dataGridViewCellStyle3;
            this.colThoiGian.HeaderText = "Thời gian";
            this.colThoiGian.Name = "colThoiGian";
            this.colThoiGian.ReadOnly = true;
            this.colThoiGian.Width = 135;
            // 
            // colRecordID
            // 
            this.colRecordID.DataPropertyName = "id";
            this.colRecordID.HeaderText = "Id Dữ liệu";
            this.colRecordID.Name = "colRecordID";
            this.colRecordID.ReadOnly = true;
            this.colRecordID.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MaXnMay";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 130;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "KetQua";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn2.HeaderText = "Nội dung";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 350;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TgCoKetQua";
            dataGridViewCellStyle7.Format = "HH:mm:ss dd/MM/yyyy";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn3.HeaderText = "Thời gian";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn4.HeaderText = "Id Dữ liệu";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // ucCoCanhBaoTheoMay
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.dtgContent);
            this.Controls.Add(this.lblThongTinMay);
            this.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.Name = "ucCoCanhBaoTheoMay";
            this.Size = new System.Drawing.Size(234, 45);
            ((System.ComponentModel.ISupportInitialize)(this.dtgContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblThongTinMay;
        private System.Windows.Forms.DataGridView dtgContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThoiGian;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecordID;
    }
}
