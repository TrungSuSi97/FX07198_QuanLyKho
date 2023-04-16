namespace TPH.LIS.App.DailyUse.BenhNhan.Logs
{
    partial class ucNhatKyChinhSuaDanhMuc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucNhatKyChinhSuaDanhMuc));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.customLable4 = new TPH.LIS.Common.Controls.CustomLable();
            this.btnSearchSEQ = new TPH.Controls.TPHNormalButton();
            this.dtpToDate = new TPH.LIS.Common.Controls.CustomDateTimePicker();
            this.dtpFromDate = new TPH.LIS.Common.Controls.CustomDateTimePicker();
            this.customLable2 = new TPH.LIS.Common.Controls.CustomLable();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgLogList = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.ThoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiThucHien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHanhDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPcThucHien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bvList = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLogList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvList)).BeginInit();
            this.bvList.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.customLable4);
            this.groupBox1.Controls.Add(this.btnSearchSEQ);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.customLable2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(770, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tìm kiếm";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(19, 22);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(103, 20);
            this.checkBox1.TabIndex = 95;
            this.checkBox1.Text = "Tìm từ ngày";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(133, 59);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(379, 24);
            this.comboBox1.TabIndex = 94;
            // 
            // customLable4
            // 
            this.customLable4.AutoSize = true;
            this.customLable4.BindFieldName = null;
            this.customLable4.Color = System.Drawing.Color.Black;
            this.customLable4.ForeColorClicked = System.Drawing.Color.White;
            this.customLable4.GetControl = null;
            this.customLable4.Location = new System.Drawing.Point(16, 62);
            this.customLable4.Name = "customLable4";
            this.customLable4.OldValue = null;
            this.customLable4.ShadowDepth = 3;
            this.customLable4.Size = new System.Drawing.Size(76, 16);
            this.customLable4.Softness = 1.5F;
            this.customLable4.TabIndex = 93;
            this.customLable4.Text = "Danh mục:";
            this.customLable4.UseShadow = false;
            this.customLable4.UseZoom = false;
            // 
            // btnSearchSEQ
            // 
            this.btnSearchSEQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnSearchSEQ.BackColorHover = System.Drawing.Color.Empty;
            this.btnSearchSEQ.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnSearchSEQ.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnSearchSEQ.BorderRadius = 5;
            this.btnSearchSEQ.BorderSize = 1;
            this.btnSearchSEQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchSEQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchSEQ.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchSEQ.ForceColorHover = System.Drawing.Color.Empty;
            this.btnSearchSEQ.ForeColor = System.Drawing.Color.Black;
            this.btnSearchSEQ.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchSEQ.Image")));
            this.btnSearchSEQ.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearchSEQ.Location = new System.Drawing.Point(535, 16);
            this.btnSearchSEQ.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnSearchSEQ.Name = "btnSearchSEQ";
            this.btnSearchSEQ.Size = new System.Drawing.Size(87, 67);
            this.btnSearchSEQ.TabIndex = 92;
            this.btnSearchSEQ.Text = "Tìm kiếm";
            this.btnSearchSEQ.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearchSEQ.TextColor = System.Drawing.Color.Black;
            this.btnSearchSEQ.UseHightLight = false;
            this.btnSearchSEQ.UseVisualStyleBackColor = false;
            this.btnSearchSEQ.Click += new System.EventHandler(this.btnSearchSEQ_Click);
            // 
            // dtpToDate
            // 
            this.dtpToDate.AllowMoveFocus = true;
            this.dtpToDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.IsEndDate = true;
            this.dtpToDate.IsStartDate = false;
            this.dtpToDate.Location = new System.Drawing.Point(345, 19);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(167, 23);
            this.dtpToDate.TabIndex = 3;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.AllowMoveFocus = true;
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.IsEndDate = false;
            this.dtpFromDate.IsStartDate = true;
            this.dtpFromDate.Location = new System.Drawing.Point(133, 19);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(167, 23);
            this.dtpFromDate.TabIndex = 2;
            // 
            // customLable2
            // 
            this.customLable2.AutoSize = true;
            this.customLable2.BindFieldName = null;
            this.customLable2.Color = System.Drawing.Color.Black;
            this.customLable2.ForeColorClicked = System.Drawing.Color.White;
            this.customLable2.GetControl = null;
            this.customLable2.Location = new System.Drawing.Point(308, 25);
            this.customLable2.Name = "customLable2";
            this.customLable2.OldValue = null;
            this.customLable2.ShadowDepth = 3;
            this.customLable2.Size = new System.Drawing.Size(32, 16);
            this.customLable2.Softness = 1.5F;
            this.customLable2.TabIndex = 1;
            this.customLable2.Text = "đến";
            this.customLable2.UseShadow = false;
            this.customLable2.UseZoom = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgLogList);
            this.groupBox2.Controls.Add(this.bvList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(770, 517);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kết quả tìm kiếm";
            // 
            // dtgLogList
            // 
            this.dtgLogList.AlignColumns = null;
            this.dtgLogList.AllignNumberText = false;
            this.dtgLogList.AllowUserToAddRows = false;
            this.dtgLogList.AllowUserToDeleteRows = false;
            this.dtgLogList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgLogList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgLogList.CheckBoldColumn = false;
            this.dtgLogList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLogList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ThoiGian,
            this.NguoiThucHien,
            this.colHanhDong,
            this.colMota,
            this.colMaDanhMuc,
            this.colPcThucHien,
            this.ID});
            this.dtgLogList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgLogList.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgLogList.Location = new System.Drawing.Point(3, 19);
            this.dtgLogList.MarkOddEven = false;
            this.dtgLogList.Name = "dtgLogList";
            this.dtgLogList.ReadOnly = true;
            this.dtgLogList.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgLogList.Size = new System.Drawing.Size(764, 470);
            this.dtgLogList.TabIndex = 0;
            // 
            // ThoiGian
            // 
            this.ThoiGian.DataPropertyName = "ThoiGianThucHien";
            dataGridViewCellStyle1.Format = "HH:mm dd/MM/yyyy";
            this.ThoiGian.DefaultCellStyle = dataGridViewCellStyle1;
            this.ThoiGian.HeaderText = "T.Gian thực hiện";
            this.ThoiGian.Name = "ThoiGian";
            this.ThoiGian.ReadOnly = true;
            this.ThoiGian.Width = 150;
            // 
            // NguoiThucHien
            // 
            this.NguoiThucHien.DataPropertyName = "NguoiThucHien";
            this.NguoiThucHien.HeaderText = "Người thực hiện";
            this.NguoiThucHien.Name = "NguoiThucHien";
            this.NguoiThucHien.ReadOnly = true;
            // 
            // colHanhDong
            // 
            this.colHanhDong.DataPropertyName = "HanhDong";
            this.colHanhDong.HeaderText = "Hành động";
            this.colHanhDong.Name = "colHanhDong";
            this.colHanhDong.ReadOnly = true;
            // 
            // colMota
            // 
            this.colMota.DataPropertyName = "NoiDung";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colMota.DefaultCellStyle = dataGridViewCellStyle2;
            this.colMota.HeaderText = "Chi tiết";
            this.colMota.Name = "colMota";
            this.colMota.ReadOnly = true;
            this.colMota.Width = 350;
            // 
            // colMaDanhMuc
            // 
            this.colMaDanhMuc.DataPropertyName = "MaDanhMuc";
            this.colMaDanhMuc.HeaderText = "Mã danh mục";
            this.colMaDanhMuc.Name = "colMaDanhMuc";
            this.colMaDanhMuc.ReadOnly = true;
            // 
            // colPcThucHien
            // 
            this.colPcThucHien.DataPropertyName = "PcThucHien";
            this.colPcThucHien.HeaderText = "Pc thực hiện";
            this.colPcThucHien.Name = "colPcThucHien";
            this.colPcThucHien.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // bvList
            // 
            this.bvList.AddNewItem = null;
            this.bvList.CountItem = this.bindingNavigatorCountItem;
            this.bvList.CountItemFormat = "/ {0}";
            this.bvList.DeleteItem = null;
            this.bvList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.bvList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bvList.Location = new System.Drawing.Point(3, 489);
            this.bvList.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bvList.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bvList.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bvList.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bvList.Name = "bvList";
            this.bvList.PositionItem = this.bindingNavigatorPositionItem;
            this.bvList.Size = new System.Drawing.Size(764, 25);
            this.bvList.TabIndex = 79;
            this.bvList.Text = "customBindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(33, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(58, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ucNhatKyChinhSuaDanhMuc
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucNhatKyChinhSuaDanhMuc";
            this.Size = new System.Drawing.Size(770, 615);
            this.Load += new System.EventHandler(this.ucLogThongTinHanhChinh_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLogList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvList)).EndInit();
            this.bvList.ResumeLayout(false);
            this.bvList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Common.Controls.CustomLable customLable2;
        private TPH.Controls.TPHNormalButton btnSearchSEQ;
        public Common.Controls.CustomDateTimePicker dtpToDate;
        public Common.Controls.CustomDateTimePicker dtpFromDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private Common.Controls.CustomDatagridView dtgLogList;
        private System.Windows.Forms.TextBox txtUserSua;
        private Common.Controls.CustomBindingNavigator bvList;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ComboBox comboBox1;
        private Common.Controls.CustomLable customLable4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGian;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiThucHien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHanhDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMota;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPcThucHien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}
