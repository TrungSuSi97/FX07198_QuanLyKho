namespace TPH.LIS.App.AppCode
{
    partial class ucShowAlertTestResult
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
            this.dtgKetQuaXN = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.coltenXetNghiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colketQua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBatThuong = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNguongThamChieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonviTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLoadKetQua = new TPH.Controls.TPHNormalButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgKetQuaXN)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgKetQuaXN
            // 
            this.dtgKetQuaXN.AlignColumns = null;
            this.dtgKetQuaXN.AllignNumberText = false;
            this.dtgKetQuaXN.AllowUserToAddRows = false;
            this.dtgKetQuaXN.AllowUserToDeleteRows = false;
            this.dtgKetQuaXN.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgKetQuaXN.CheckBoldColumn = false;
            this.dtgKetQuaXN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgKetQuaXN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coltenXetNghiem,
            this.colketQua,
            this.colBatThuong,
            this.colNguongThamChieu,
            this.colDonviTinh});
            this.dtgKetQuaXN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgKetQuaXN.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgKetQuaXN.Location = new System.Drawing.Point(0, 0);
            this.dtgKetQuaXN.MarkOddEven = false;
            this.dtgKetQuaXN.Name = "dtgKetQuaXN";
            this.dtgKetQuaXN.ReadOnly = true;
            this.dtgKetQuaXN.Size = new System.Drawing.Size(426, 146);
            this.dtgKetQuaXN.TabIndex = 0;
            // 
            // coltenXetNghiem
            // 
            this.coltenXetNghiem.DataPropertyName = "TenXN";
            this.coltenXetNghiem.HeaderText = "Tên xét nghiệm";
            this.coltenXetNghiem.Name = "coltenXetNghiem";
            this.coltenXetNghiem.ReadOnly = true;
            this.coltenXetNghiem.Width = 180;
            // 
            // colketQua
            // 
            this.colketQua.DataPropertyName = "KetQua";
            this.colketQua.HeaderText = "Kết quả";
            this.colketQua.Name = "colketQua";
            this.colketQua.ReadOnly = true;
            // 
            // colBatThuong
            // 
            this.colBatThuong.DataPropertyName = "BatThuong";
            this.colBatThuong.HeaderText = "Bất thường";
            this.colBatThuong.Name = "colBatThuong";
            this.colBatThuong.ReadOnly = true;
            this.colBatThuong.Width = 80;
            // 
            // colNguongThamChieu
            // 
            this.colNguongThamChieu.DataPropertyName = "CSBT";
            this.colNguongThamChieu.HeaderText = "Ngưỡng tham chiếu";
            this.colNguongThamChieu.Name = "colNguongThamChieu";
            this.colNguongThamChieu.ReadOnly = true;
            this.colNguongThamChieu.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colNguongThamChieu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colNguongThamChieu.Width = 150;
            // 
            // colDonviTinh
            // 
            this.colDonviTinh.DataPropertyName = "DonVi";
            this.colDonviTinh.HeaderText = "ĐV Tính";
            this.colDonviTinh.Name = "colDonviTinh";
            this.colDonviTinh.ReadOnly = true;
            // 
            // btnLoadKetQua
            // 
            this.btnLoadKetQua.BackColor = System.Drawing.Color.Gold;
            this.btnLoadKetQua.BackColorHover = System.Drawing.Color.Empty;
            this.btnLoadKetQua.BackgroundColor = System.Drawing.Color.Gold;
            this.btnLoadKetQua.BackgroundImage = global::TPH.LIS.App.Properties.Resources.Refresh__1_;
            this.btnLoadKetQua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLoadKetQua.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnLoadKetQua.BorderRadius = 5;
            this.btnLoadKetQua.BorderSize = 1;
            this.btnLoadKetQua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadKetQua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadKetQua.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadKetQua.ForceColorHover = System.Drawing.Color.Empty;
            this.btnLoadKetQua.ForeColor = System.Drawing.Color.Black;
            this.btnLoadKetQua.Location = new System.Drawing.Point(1, 1);
            this.btnLoadKetQua.Name = "btnLoadKetQua";
            this.btnLoadKetQua.Size = new System.Drawing.Size(39, 21);
            this.btnLoadKetQua.TabIndex = 34;
            this.btnLoadKetQua.TextColor = System.Drawing.Color.Black;
            this.btnLoadKetQua.UseHightLight = true;
            this.btnLoadKetQua.UseVisualStyleBackColor = false;
            this.btnLoadKetQua.Click += new System.EventHandler(this.btnLoadKetQua_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TenXN";
            this.dataGridViewTextBoxColumn1.HeaderText = "Tên xét nghiệm";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 180;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "KetQua";
            this.dataGridViewTextBoxColumn2.HeaderText = "Kết quả";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CSBT";
            this.dataGridViewTextBoxColumn3.HeaderText = "Ngưỡng tham chiếu";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DonVi";
            this.dataGridViewTextBoxColumn4.HeaderText = "Đơn vị tính";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // ucShowAlertTestResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLoadKetQua);
            this.Controls.Add(this.dtgKetQuaXN);
            this.Name = "ucShowAlertTestResult";
            this.Size = new System.Drawing.Size(426, 146);
            ((System.ComponentModel.ISupportInitialize)(this.dtgKetQuaXN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public Common.Controls.CustomDatagridView dtgKetQuaXN;
        private TPH.Controls.TPHNormalButton btnLoadKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltenXetNghiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colketQua;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colBatThuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNguongThamChieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonviTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
