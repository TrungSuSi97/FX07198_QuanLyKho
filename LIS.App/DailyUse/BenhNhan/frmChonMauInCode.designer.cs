namespace TPH.LIS.App.DailyUse.BenhNhan
{
    partial class frmChonMauInCode
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.txtSLIn = new System.Windows.Forms.NumericUpDown();
            this.btnClose = new TPH.Controls.TPHNormalButton();
            this.btnDongY = new TPH.Controls.TPHNormalButton();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.dtgDanhSachChonMau = new System.Windows.Forms.DataGridView();
            this.colChon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colTenLoaiMau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTGLayMau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaNhomCLS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaLoaiMau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSLIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDanhSachChonMau)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Appearance.Options.UseFont = true;
            this.label1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "CHỌN LOẠI MẪU ĐỂ IN CODE";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSLIn);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnDongY);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 382);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 41);
            this.panel1.TabIndex = 0;
            // 
            // txtSLIn
            // 
            this.txtSLIn.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSLIn.Location = new System.Drawing.Point(184, 10);
            this.txtSLIn.Margin = new System.Windows.Forms.Padding(0);
            this.txtSLIn.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.txtSLIn.Name = "txtSLIn";
            this.txtSLIn.ReadOnly = true;
            this.txtSLIn.Size = new System.Drawing.Size(47, 23);
            this.txtSLIn.TabIndex = 0;
            this.txtSLIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSLIn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSLIn.Click += new System.EventHandler(this.txtSLIn_Click);
            this.txtSLIn.Enter += new System.EventHandler(this.txtSLIn_Enter);
            this.txtSLIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSLIn_KeyPress_1);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackColorHover = System.Drawing.Color.Empty;
            this.btnClose.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnClose.BorderRadius = 5;
            this.btnClose.BorderSize = 1;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForceColorHover = System.Drawing.Color.Empty;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::TPH.LIS.App.Properties.Resources.close_circle_16x16;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(361, 5);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.TextColor = System.Drawing.Color.Black;
            this.btnClose.UseHightLight = true;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDongY
            // 
            this.btnDongY.BackColor = System.Drawing.Color.Transparent;
            this.btnDongY.BackColorHover = System.Drawing.Color.Empty;
            this.btnDongY.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnDongY.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnDongY.BorderRadius = 5;
            this.btnDongY.BorderSize = 1;
            this.btnDongY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDongY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDongY.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDongY.ForceColorHover = System.Drawing.Color.Empty;
            this.btnDongY.ForeColor = System.Drawing.Color.Black;
            this.btnDongY.Image = global::TPH.LIS.App.Properties.Resources.barcodes_24x24;
            this.btnDongY.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDongY.Location = new System.Drawing.Point(247, 5);
            this.btnDongY.Margin = new System.Windows.Forms.Padding(0);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(108, 28);
            this.btnDongY.TabIndex = 1;
            this.btnDongY.Text = "In barcode";
            this.btnDongY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDongY.TextColor = System.Drawing.Color.Black;
            this.btnDongY.UseHightLight = true;
            this.btnDongY.UseVisualStyleBackColor = false;
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số bản in mỗi loại mẫu (copy)";
            // 
            // dtgDanhSachChonMau
            // 
            this.dtgDanhSachChonMau.AllowUserToAddRows = false;
            this.dtgDanhSachChonMau.AllowUserToDeleteRows = false;
            this.dtgDanhSachChonMau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDanhSachChonMau.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChon,
            this.colTenLoaiMau,
            this.colTGLayMau,
            this.colMaNhomCLS,
            this.colSL,
            this.colMaLoaiMau});
            this.dtgDanhSachChonMau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDanhSachChonMau.Location = new System.Drawing.Point(0, 22);
            this.dtgDanhSachChonMau.Margin = new System.Windows.Forms.Padding(0);
            this.dtgDanhSachChonMau.Name = "dtgDanhSachChonMau";
            this.dtgDanhSachChonMau.RowHeadersWidth = 25;
            this.dtgDanhSachChonMau.Size = new System.Drawing.Size(522, 360);
            this.dtgDanhSachChonMau.TabIndex = 1;
            // 
            // colChon
            // 
            this.colChon.DataPropertyName = "Chon";
            this.colChon.HeaderText = "";
            this.colChon.Name = "colChon";
            this.colChon.Width = 30;
            // 
            // colTenLoaiMau
            // 
            this.colTenLoaiMau.DataPropertyName = "TenNhomLoaiMau";
            this.colTenLoaiMau.HeaderText = "Loại mẫu";
            this.colTenLoaiMau.Name = "colTenLoaiMau";
            this.colTenLoaiMau.ReadOnly = true;
            // 
            // colTGLayMau
            // 
            this.colTGLayMau.DataPropertyName = "thoigianlaymau";
            dataGridViewCellStyle1.Format = "HH:mm dd/MM/yyyy";
            this.colTGLayMau.DefaultCellStyle = dataGridViewCellStyle1;
            this.colTGLayMau.HeaderText = "TG Lấy mẫu";
            this.colTGLayMau.Name = "colTGLayMau";
            this.colTGLayMau.ReadOnly = true;
            this.colTGLayMau.Width = 150;
            // 
            // colMaNhomCLS
            // 
            this.colMaNhomCLS.DataPropertyName = "MaNhomCLS";
            this.colMaNhomCLS.HeaderText = "Mã nhóm";
            this.colMaNhomCLS.Name = "colMaNhomCLS";
            // 
            // colSL
            // 
            this.colSL.DataPropertyName = "SL";
            this.colSL.HeaderText = "Số lượng";
            this.colSL.Name = "colSL";
            // 
            // colMaLoaiMau
            // 
            this.colMaLoaiMau.DataPropertyName = "LoaiMau";
            this.colMaLoaiMau.HeaderText = "Mã loại mẫu";
            this.colMaLoaiMau.Name = "colMaLoaiMau";
            this.colMaLoaiMau.ReadOnly = true;
            this.colMaLoaiMau.Visible = false;
            this.colMaLoaiMau.Width = 150;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TenNhomLoaiMau";
            this.dataGridViewTextBoxColumn1.HeaderText = "Loại mẫu";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 250;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "thoigianlaymau";
            dataGridViewCellStyle2.Format = "HH:mm dd/MM/yyyy";
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.HeaderText = "TG Lấy mẫu";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "LoaiMau";
            this.dataGridViewTextBoxColumn3.HeaderText = "Mã loại mẫu";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // frmChonMauInCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(522, 423);
            this.Controls.Add(this.dtgDanhSachChonMau);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChonMauInCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn mẫu in";
            this.Load += new System.EventHandler(this.frmChonMauInCode_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChonMauInCode_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSLIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDanhSachChonMau)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.PanelControl panel1;
        private TPH.Controls.TPHNormalButton btnClose;
        private TPH.Controls.TPHNormalButton btnDongY;
        private DevExpress.XtraEditors.LabelControl label2;
        public System.Windows.Forms.DataGridView dtgDanhSachChonMau;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.NumericUpDown txtSLIn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenLoaiMau;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTGLayMau;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNhomCLS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaLoaiMau;
    }
}