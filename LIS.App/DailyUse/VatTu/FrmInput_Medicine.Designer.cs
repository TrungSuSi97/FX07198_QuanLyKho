using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.ThucThi.VatTu
{
    partial class FrmInput_Medicine
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInput_Medicine));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.bvPhieuNhap = new CustomBindingNavigator();
            this.btnTaoPhieu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSuaPhieu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLuuPhieu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnXoaPhieu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnInPhieu = new System.Windows.Forms.ToolStripButton();
            this.txtNgayLapPhieu = new System.Windows.Forms.TextBox();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.txtNguoiLapPhieu = new System.Windows.Forms.TextBox();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.txtSoPhieuNhap = new System.Windows.Forms.TextBox();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.btnXemDanhSach = new TPH.Controls.TPHNormalButton();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.dtgChiTietNhap = new CustomDatagridView();
            this.Chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaVatTu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenVatTu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoHSD = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.HanSuDung = new CustomCalendarColumn();
            this.HangTang = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.QuyCach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonViQuyCach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhomVatTu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhaCungCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bvChiTietNhap = new CustomBindingNavigator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSuaVatTu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnXoaVatTu = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.chkHangTang = new System.Windows.Forms.CheckBox();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.label12 = new DevExpress.XtraEditors.LabelControl();
            this.btnNhapKho = new TPH.Controls.TPHNormalButton();
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.dtpHanSuDung = new System.Windows.Forms.DateTimePicker();
            this.label10 = new DevExpress.XtraEditors.LabelControl();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label9 = new DevExpress.XtraEditors.LabelControl();
            this.txtVatTu = new System.Windows.Forms.TextBox();
            this.cboVatTu = new CustomComboBox();
            this.label8 = new DevExpress.XtraEditors.LabelControl();
            this.txtNhomVatTu = new System.Windows.Forms.TextBox();
            this.cboNhomVatTu = new CustomComboBox();
            this.label7 = new DevExpress.XtraEditors.LabelControl();
            this.txtNhaCungCap = new System.Windows.Forms.TextBox();
            this.cboNhaCungCap = new CustomComboBox();
            this.label6 = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new DevExpress.XtraEditors.PanelControl();
            this.panel4 = new DevExpress.XtraEditors.PanelControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTimSoPhieu = new System.Windows.Forms.TextBox();
            this.label11 = new DevExpress.XtraEditors.LabelControl();
            this.panel3 = new DevExpress.XtraEditors.PanelControl();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bvPhieuNhap)).BeginInit();
            this.bvPhieuNhap.SuspendLayout();
            this.gbDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgChiTietNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvChiTietNhap)).BeginInit();
            this.bvChiTietNhap.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "NHẬP KHO THUỐC";
            // 
            // pnContaint
            // 
            this.pnContaint.Controls.Add(this.panel3);
            this.pnContaint.Controls.Add(this.panel2);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.GhostWhite;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGhiChu);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.bvPhieuNhap);
            this.groupBox1.Controls.Add(this.txtNgayLapPhieu);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNguoiLapPhieu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSoPhieuNhap);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpNgayNhap);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(774, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phiếu nhập";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(89, 59);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(426, 27);
            this.txtGhiChu.TabIndex = 19;
            this.txtGhiChu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGhiChu_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Ghi chú";
            // 
            // bvPhieuNhap
            // 
            this.bvPhieuNhap.AddNewItem = null;
            this.bvPhieuNhap.CountItem = null;
            this.bvPhieuNhap.CountItemFormat = "/ {0}";
            this.bvPhieuNhap.DeleteItem = null;
            this.bvPhieuNhap.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvPhieuNhap.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvPhieuNhap.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bvPhieuNhap.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bvPhieuNhap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTaoPhieu,
            this.toolStripSeparator4,
            this.btnSuaPhieu,
            this.toolStripSeparator5,
            this.btnLuuPhieu,
            this.toolStripSeparator6,
            this.btnXoaPhieu,
            this.toolStripSeparator3,
            this.btnInPhieu});
            this.bvPhieuNhap.Location = new System.Drawing.Point(3, 86);
            this.bvPhieuNhap.MoveFirstItem = null;
            this.bvPhieuNhap.MoveLastItem = null;
            this.bvPhieuNhap.MoveNextItem = null;
            this.bvPhieuNhap.MovePreviousItem = null;
            this.bvPhieuNhap.Name = "bvPhieuNhap";
            this.bvPhieuNhap.PositionItem = null;
            this.bvPhieuNhap.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.bvPhieuNhap.Size = new System.Drawing.Size(768, 25);
            this.bvPhieuNhap.TabIndex = 16;
            this.bvPhieuNhap.Text = "bindingNavigator2";
            // 
            // btnTaoPhieu
            // 
            this.btnTaoPhieu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTaoPhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnTaoPhieu.Image")));
            this.btnTaoPhieu.Name = "btnTaoPhieu";
            this.btnTaoPhieu.RightToLeftAutoMirrorImage = true;
            this.btnTaoPhieu.Size = new System.Drawing.Size(111, 22);
            this.btnTaoPhieu.Text = "Tạo phiếu nhập";
            this.btnTaoPhieu.Click += new System.EventHandler(this.btnTaoPhieu_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSuaPhieu
            // 
            this.btnSuaPhieu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSuaPhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnSuaPhieu.Image")));
            this.btnSuaPhieu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSuaPhieu.Name = "btnSuaPhieu";
            this.btnSuaPhieu.Size = new System.Drawing.Size(82, 22);
            this.btnSuaPhieu.Text = "Sửa phiếu";
            this.btnSuaPhieu.Click += new System.EventHandler(this.btnSuaPhieu_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnLuuPhieu
            // 
            this.btnLuuPhieu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLuuPhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuPhieu.Image")));
            this.btnLuuPhieu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLuuPhieu.Name = "btnLuuPhieu";
            this.btnLuuPhieu.Size = new System.Drawing.Size(82, 22);
            this.btnLuuPhieu.Text = "Lưu phiếu";
            this.btnLuuPhieu.Click += new System.EventHandler(this.btnLuuPhieu_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnXoaPhieu
            // 
            this.btnXoaPhieu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaPhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaPhieu.Image")));
            this.btnXoaPhieu.Name = "btnXoaPhieu";
            this.btnXoaPhieu.RightToLeftAutoMirrorImage = true;
            this.btnXoaPhieu.Size = new System.Drawing.Size(82, 22);
            this.btnXoaPhieu.Text = "Xóa phiếu";
            this.btnXoaPhieu.ToolTipText = "Xóa sản phẩm";
            this.btnXoaPhieu.Click += new System.EventHandler(this.btnXoaPhieu_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnInPhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnInPhieu.Image")));
            this.btnInPhieu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(102, 22);
            this.btnInPhieu.Text = "In phiếu nhập";
            // 
            // txtNgayLapPhieu
            // 
            this.txtNgayLapPhieu.Location = new System.Drawing.Point(621, 59);
            this.txtNgayLapPhieu.Name = "txtNgayLapPhieu";
            this.txtNgayLapPhieu.ReadOnly = true;
            this.txtNgayLapPhieu.Size = new System.Drawing.Size(146, 27);
            this.txtNgayLapPhieu.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(517, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ngày lập phiếu";
            // 
            // txtNguoiLapPhieu
            // 
            this.txtNguoiLapPhieu.Location = new System.Drawing.Point(621, 26);
            this.txtNguoiLapPhieu.Name = "txtNguoiLapPhieu";
            this.txtNguoiLapPhieu.ReadOnly = true;
            this.txtNguoiLapPhieu.Size = new System.Drawing.Size(146, 27);
            this.txtNguoiLapPhieu.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(517, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Người lập phiếu";
            // 
            // txtSoPhieuNhap
            // 
            this.txtSoPhieuNhap.Location = new System.Drawing.Point(297, 26);
            this.txtSoPhieuNhap.Name = "txtSoPhieuNhap";
            this.txtSoPhieuNhap.ReadOnly = true;
            this.txtSoPhieuNhap.Size = new System.Drawing.Size(218, 27);
            this.txtSoPhieuNhap.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số phiếu nhập";
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayNhap.Location = new System.Drawing.Point(89, 26);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(105, 27);
            this.dtpNgayNhap.TabIndex = 1;
            this.dtpNgayNhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpNgayNhap_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày nhập";
            // 
            // btnXemDanhSach
            // 
            this.btnXemDanhSach.BackColor = System.Drawing.Color.Transparent;
            this.btnXemDanhSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemDanhSach.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnXemDanhSach.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemDanhSach.ForeColor = System.Drawing.Color.Black;
            this.btnXemDanhSach.Image = ((System.Drawing.Image)(resources.GetObject("btnXemDanhSach.Image")));
            this.btnXemDanhSach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemDanhSach.Location = new System.Drawing.Point(73, 87);
            this.btnXemDanhSach.Name = "btnXemDanhSach";
            this.btnXemDanhSach.Size = new System.Drawing.Size(92, 27);
            this.btnXemDanhSach.TabIndex = 17;
            this.btnXemDanhSach.Text = "Danh sách";
            this.btnXemDanhSach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXemDanhSach.UseHightLight = true;
            this.btnXemDanhSach.UseVisualStyleBackColor = false;
            this.btnXemDanhSach.Click += new System.EventHandler(this.btnXemDanhSach_Click);
            // 
            // gbDetail
            // 
            this.gbDetail.Controls.Add(this.dtgChiTietNhap);
            this.gbDetail.Controls.Add(this.bvChiTietNhap);
            this.gbDetail.Controls.Add(this.panel1);
            this.gbDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDetail.Location = new System.Drawing.Point(3, 3);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(953, 403);
            this.gbDetail.TabIndex = 1;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "Chi tiết phiếu nhập";
            // 
            // dtgChiTietNhap
            // 
            this.dtgChiTietNhap.AlignColumns = "";
            this.dtgChiTietNhap.AllignNumberText = false;
            this.dtgChiTietNhap.AllowUserToAddRows = false;
            this.dtgChiTietNhap.AllowUserToDeleteRows = false;
            this.dtgChiTietNhap.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgChiTietNhap.CheckBoldColumn = false;
            this.dtgChiTietNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgChiTietNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Chon,
            this.MaVatTu,
            this.TenVatTu,
            this.SoLuong,
            this.DonViTinh,
            this.GiaNhap,
            this.CoHSD,
            this.HanSuDung,
            this.HangTang,
            this.QuyCach,
            this.DonViQuyCach,
            this.TenNhomVatTu,
            this.TenNhaCungCap});
            this.dtgChiTietNhap.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(228)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgChiTietNhap.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgChiTietNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgChiTietNhap.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgChiTietNhap.Location = new System.Drawing.Point(3, 91);
            this.dtgChiTietNhap.MarkOddEven = true;
            this.dtgChiTietNhap.MultiSelect = false;
            this.dtgChiTietNhap.Name = "dtgChiTietNhap";
            this.dtgChiTietNhap.NumberAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgChiTietNhap.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgChiTietNhap.RowTemplate.Height = 28;
            this.dtgChiTietNhap.Size = new System.Drawing.Size(947, 284);
            this.dtgChiTietNhap.TabIndex = 1;
            this.dtgChiTietNhap.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            // 
            // Chon
            // 
            this.Chon.HeaderText = "";
            this.Chon.Name = "Chon";
            this.Chon.Width = 25;
            // 
            // MaVatTu
            // 
            this.MaVatTu.DataPropertyName = "MaThuoc";
            this.MaVatTu.HeaderText = "Mã thuốc";
            this.MaVatTu.Name = "MaVatTu";
            this.MaVatTu.Width = 90;
            // 
            // TenVatTu
            // 
            this.TenVatTu.DataPropertyName = "TenThuoc";
            this.TenVatTu.HeaderText = "Tên thuốc";
            this.TenVatTu.Name = "TenVatTu";
            this.TenVatTu.Width = 200;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuongNhap";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            // 
            // DonViTinh
            // 
            this.DonViTinh.DataPropertyName = "DonViTinh";
            this.DonViTinh.HeaderText = "Đơn vị tính";
            this.DonViTinh.Name = "DonViTinh";
            // 
            // GiaNhap
            // 
            this.GiaNhap.DataPropertyName = "GiaNhap";
            dataGridViewCellStyle1.Format = "0,###";
            this.GiaNhap.DefaultCellStyle = dataGridViewCellStyle1;
            this.GiaNhap.HeaderText = "Giá nhập";
            this.GiaNhap.Name = "GiaNhap";
            // 
            // CoHSD
            // 
            this.CoHSD.DataPropertyName = "CoHSD";
            this.CoHSD.HeaderText = "Có HSD";
            this.CoHSD.Name = "CoHSD";
            this.CoHSD.Width = 80;
            // 
            // HanSuDung
            // 
            this.HanSuDung.DataPropertyName = "HanSuDung";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.HanSuDung.DefaultCellStyle = dataGridViewCellStyle2;
            this.HanSuDung.HeaderText = "Hạn sử dụng";
            this.HanSuDung.Name = "HanSuDung";
            this.HanSuDung.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HanSuDung.Width = 110;
            // 
            // HangTang
            // 
            this.HangTang.DataPropertyName = "HangTang";
            this.HangTang.HeaderText = "Hàng tặng";
            this.HangTang.Name = "HangTang";
            // 
            // QuyCach
            // 
            this.QuyCach.DataPropertyName = "SLQuiCachCap1";
            this.QuyCach.HeaderText = "Quy cách";
            this.QuyCach.Name = "QuyCach";
            this.QuyCach.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.QuyCach.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DonViQuyCach
            // 
            this.DonViQuyCach.DataPropertyName = "DVTQuiCachCap1";
            this.DonViQuyCach.HeaderText = "ĐVT quy cách";
            this.DonViQuyCach.Name = "DonViQuyCach";
            this.DonViQuyCach.Width = 120;
            // 
            // TenNhomVatTu
            // 
            this.TenNhomVatTu.DataPropertyName = "TenNhomThuoc";
            this.TenNhomVatTu.HeaderText = "Nhóm thuốc";
            this.TenNhomVatTu.Name = "TenNhomVatTu";
            this.TenNhomVatTu.Width = 150;
            // 
            // TenNhaCungCap
            // 
            this.TenNhaCungCap.DataPropertyName = "TenNhaCungCap";
            this.TenNhaCungCap.HeaderText = "Nhà cung cấp";
            this.TenNhaCungCap.Name = "TenNhaCungCap";
            this.TenNhaCungCap.Width = 150;
            // 
            // bvChiTietNhap
            // 
            this.bvChiTietNhap.AddNewItem = null;
            this.bvChiTietNhap.CountItem = this.bindingNavigatorCountItem;
            this.bvChiTietNhap.CountItemFormat = "/ {0}";
            this.bvChiTietNhap.DeleteItem = null;
            this.bvChiTietNhap.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvChiTietNhap.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvChiTietNhap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.btnSuaVatTu,
            this.toolStripSeparator1,
            this.btnXoaVatTu});
            this.bvChiTietNhap.Location = new System.Drawing.Point(3, 375);
            this.bvChiTietNhap.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bvChiTietNhap.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bvChiTietNhap.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bvChiTietNhap.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bvChiTietNhap.Name = "bvChiTietNhap";
            this.bvChiTietNhap.PositionItem = this.bindingNavigatorPositionItem;
            this.bvChiTietNhap.Size = new System.Drawing.Size(947, 25);
            this.bvChiTietNhap.TabIndex = 2;
            this.bvChiTietNhap.Text = "CustomBindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(27, 22);
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
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
            // btnSuaVatTu
            // 
            this.btnSuaVatTu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSuaVatTu.Image = ((System.Drawing.Image)(resources.GetObject("btnSuaVatTu.Image")));
            this.btnSuaVatTu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSuaVatTu.Name = "btnSuaVatTu";
            this.btnSuaVatTu.Size = new System.Drawing.Size(90, 22);
            this.btnSuaVatTu.Text = "Sửa chi tiết";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnXoaVatTu
            // 
            this.btnXoaVatTu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaVatTu.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaVatTu.Image")));
            this.btnXoaVatTu.Name = "btnXoaVatTu";
            this.btnXoaVatTu.RightToLeftAutoMirrorImage = true;
            this.btnXoaVatTu.Size = new System.Drawing.Size(83, 22);
            this.btnXoaVatTu.Text = "Xóa thuốc";
            this.btnXoaVatTu.ToolTipText = "Xóa sản phẩm";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkHangTang);
            this.panel1.Controls.Add(this.txtGiaNhap);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.btnNhapKho);
            this.panel1.Controls.Add(this.txtDonViTinh);
            this.panel1.Controls.Add(this.dtpHanSuDung);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtSoLuong);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtVatTu);
            this.panel1.Controls.Add(this.cboVatTu);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtNhomVatTu);
            this.panel1.Controls.Add(this.cboNhomVatTu);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtNhaCungCap);
            this.panel1.Controls.Add(this.cboNhaCungCap);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(947, 68);
            this.panel1.TabIndex = 0;
            // 
            // chkHangTang
            // 
            this.chkHangTang.AutoSize = true;
            this.chkHangTang.Location = new System.Drawing.Point(857, 7);
            this.chkHangTang.Name = "chkHangTang";
            this.chkHangTang.Size = new System.Drawing.Size(87, 24);
            this.chkHangTang.TabIndex = 38;
            this.chkHangTang.Text = "Hàng tặng";
            this.chkHangTang.UseVisualStyleBackColor = true;
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Location = new System.Drawing.Point(456, 36);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(51, 27);
            this.txtGiaNhap.TabIndex = 37;
            this.txtGiaNhap.Text = "0";
            this.txtGiaNhap.Enter += new System.EventHandler(this.txtGiaNhap_Enter);
            this.txtGiaNhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiaNhap_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(413, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 20);
            this.label12.TabIndex = 36;
            this.label12.Text = "Đ. Giá";
            // 
            // btnNhapKho
            // 
            this.btnNhapKho.BackColor = System.Drawing.Color.Transparent;
            this.btnNhapKho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNhapKho.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnNhapKho.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapKho.ForeColor = System.Drawing.Color.Black;
            this.btnNhapKho.Image = ((System.Drawing.Image)(resources.GetObject("btnNhapKho.Image")));
            this.btnNhapKho.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapKho.Location = new System.Drawing.Point(860, 36);
            this.btnNhapKho.Name = "btnNhapKho";
            this.btnNhapKho.Size = new System.Drawing.Size(83, 28);
            this.btnNhapKho.TabIndex = 35;
            this.btnNhapKho.Text = "Nhập kho";
            this.btnNhapKho.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNhapKho.UseHightLight = true;
            this.btnNhapKho.UseVisualStyleBackColor = false;
            this.btnNhapKho.Click += new System.EventHandler(this.btnNhapKho_Click);
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.txtDonViTinh.Location = new System.Drawing.Point(605, 36);
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.ReadOnly = true;
            this.txtDonViTinh.Size = new System.Drawing.Size(37, 27);
            this.txtDonViTinh.TabIndex = 34;
            // 
            // dtpHanSuDung
            // 
            this.dtpHanSuDung.CustomFormat = "dd/MM/yyyy";
            this.dtpHanSuDung.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHanSuDung.Location = new System.Drawing.Point(727, 37);
            this.dtpHanSuDung.Name = "dtpHanSuDung";
            this.dtpHanSuDung.ShowCheckBox = true;
            this.dtpHanSuDung.Size = new System.Drawing.Size(127, 27);
            this.dtpHanSuDung.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(642, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 20);
            this.label10.TabIndex = 31;
            this.label10.Text = "Hạn sử dụng";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(568, 36);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(36, 27);
            this.txtSoLuong.TabIndex = 30;
            this.txtSoLuong.Text = "0";
            this.txtSoLuong.Enter += new System.EventHandler(this.txtSoLuong_Enter);
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(508, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 20);
            this.label9.TabIndex = 28;
            this.label9.Text = "Số lượng";
            // 
            // txtVatTu
            // 
            this.txtVatTu.Location = new System.Drawing.Point(163, 37);
            this.txtVatTu.Name = "txtVatTu";
            this.txtVatTu.Size = new System.Drawing.Size(250, 27);
            this.txtVatTu.TabIndex = 27;
            // 
            // cboVatTu
            // 
            this.cboVatTu.AutoComplete = false;
            this.cboVatTu.AutoDropdown = false;
            this.cboVatTu.BackColorEven = System.Drawing.Color.White;
            this.cboVatTu.BackColorOdd = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.cboVatTu.ColumnNames = "";
            this.cboVatTu.ColumnWidthDefault = 75;
            this.cboVatTu.ColumnWidths = "";
            this.cboVatTu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboVatTu.FormattingEnabled = true;
            this.cboVatTu.LinkedColumnIndex1 = 0;
            this.cboVatTu.LinkedColumnIndex2 = 0;
            this.cboVatTu.LinkedTextBox1 = null;
            this.cboVatTu.LinkedTextBox2 = null;
            this.cboVatTu.Location = new System.Drawing.Point(99, 36);
            this.cboVatTu.Name = "cboVatTu";
            this.cboVatTu.Size = new System.Drawing.Size(63, 28);
            this.cboVatTu.TabIndex = 26;
            this.cboVatTu.SelectionChangeCommitted += new System.EventHandler(this.cboVatTu_SelectionChangeCommitted);
            this.cboVatTu.Enter += new System.EventHandler(this.cboVatTu_Enter);
            this.cboVatTu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboVatTu_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 20);
            this.label8.TabIndex = 25;
            this.label8.Text = "Thuốc";
            // 
            // txtNhomVatTu
            // 
            this.txtNhomVatTu.Location = new System.Drawing.Point(571, 5);
            this.txtNhomVatTu.Name = "txtNhomVatTu";
            this.txtNhomVatTu.Size = new System.Drawing.Size(283, 27);
            this.txtNhomVatTu.TabIndex = 24;
            // 
            // cboNhomVatTu
            // 
            this.cboNhomVatTu.AutoComplete = false;
            this.cboNhomVatTu.AutoDropdown = false;
            this.cboNhomVatTu.BackColorEven = System.Drawing.Color.White;
            this.cboNhomVatTu.BackColorOdd = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.cboNhomVatTu.ColumnNames = "";
            this.cboNhomVatTu.ColumnWidthDefault = 75;
            this.cboNhomVatTu.ColumnWidths = "";
            this.cboNhomVatTu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboNhomVatTu.FormattingEnabled = true;
            this.cboNhomVatTu.LinkedColumnIndex1 = 0;
            this.cboNhomVatTu.LinkedColumnIndex2 = 0;
            this.cboNhomVatTu.LinkedTextBox1 = null;
            this.cboNhomVatTu.LinkedTextBox2 = null;
            this.cboNhomVatTu.Location = new System.Drawing.Point(502, 4);
            this.cboNhomVatTu.Name = "cboNhomVatTu";
            this.cboNhomVatTu.Size = new System.Drawing.Size(68, 28);
            this.cboNhomVatTu.TabIndex = 23;
            this.cboNhomVatTu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboNhomVatTu_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(413, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "Nhóm thuốc";
            // 
            // txtNhaCungCap
            // 
            this.txtNhaCungCap.Location = new System.Drawing.Point(163, 5);
            this.txtNhaCungCap.Name = "txtNhaCungCap";
            this.txtNhaCungCap.Size = new System.Drawing.Size(250, 27);
            this.txtNhaCungCap.TabIndex = 21;
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.AutoComplete = false;
            this.cboNhaCungCap.AutoDropdown = false;
            this.cboNhaCungCap.BackColorEven = System.Drawing.Color.White;
            this.cboNhaCungCap.BackColorOdd = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.cboNhaCungCap.ColumnNames = "";
            this.cboNhaCungCap.ColumnWidthDefault = 75;
            this.cboNhaCungCap.ColumnWidths = "";
            this.cboNhaCungCap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboNhaCungCap.FormattingEnabled = true;
            this.cboNhaCungCap.LinkedColumnIndex1 = 0;
            this.cboNhaCungCap.LinkedColumnIndex2 = 0;
            this.cboNhaCungCap.LinkedTextBox1 = null;
            this.cboNhaCungCap.LinkedTextBox2 = null;
            this.cboNhaCungCap.Location = new System.Drawing.Point(99, 4);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(63, 28);
            this.cboNhaCungCap.TabIndex = 20;
            this.cboNhaCungCap.SelectionChangeCommitted += new System.EventHandler(this.cboNhaCungCap_SelectionChangeCommitted);
            this.cboNhaCungCap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboNhaCungCap_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "Nhà cung cấp";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(4, 6);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(959, 120);
            this.panel2.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(179, 3);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.panel4.Size = new System.Drawing.Size(777, 114);
            this.panel4.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTimSoPhieu);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.btnXemDanhSach);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(50);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(176, 114);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tìm phiếu nhập";
            // 
            // txtTimSoPhieu
            // 
            this.txtTimSoPhieu.Location = new System.Drawing.Point(3, 59);
            this.txtTimSoPhieu.Name = "txtTimSoPhieu";
            this.txtTimSoPhieu.Size = new System.Drawing.Size(164, 27);
            this.txtTimSoPhieu.TabIndex = 5;
            this.txtTimSoPhieu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimSoPhieu_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(-1, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 20);
            this.label11.TabIndex = 4;
            this.label11.Text = "Số phiếu nhập";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gbDetail);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 126);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(3);
            this.panel3.Size = new System.Drawing.Size(959, 409);
            this.panel3.TabIndex = 3;
            // 
            // FrmInput_Medicine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1008, 661);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmInput_Medicine";
            this.Text = "Nhập kho thuốc";
            this.Load += new System.EventHandler(this.FrmInput_Medicine_Load);
            this.pnContaint.ResumeLayout(false);
            this.pnLabel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bvPhieuNhap)).EndInit();
            this.bvPhieuNhap.ResumeLayout(false);
            this.bvPhieuNhap.PerformLayout();
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgChiTietNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvChiTietNhap)).EndInit();
            this.bvChiTietNhap.ResumeLayout(false);
            this.bvChiTietNhap.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNgayLapPhieu;
        private DevExpress.XtraEditors.LabelControl label4;
        private System.Windows.Forms.TextBox txtNguoiLapPhieu;
        private DevExpress.XtraEditors.LabelControl label3;
        private System.Windows.Forms.TextBox txtSoPhieuNhap;
        private DevExpress.XtraEditors.LabelControl label2;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private DevExpress.XtraEditors.LabelControl label1;
        private TPH.Controls.TPHNormalButton btnXemDanhSach;
        private System.Windows.Forms.ToolStripButton btnTaoPhieu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnSuaPhieu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnLuuPhieu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnXoaPhieu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnInPhieu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private DevExpress.XtraEditors.LabelControl label5;
        private CustomBindingNavigator bvPhieuNhap;
        private System.Windows.Forms.GroupBox gbDetail;
        private DevExpress.XtraEditors.PanelControl panel1;
        private System.Windows.Forms.TextBox txtNhaCungCap;
        private CustomComboBox cboNhaCungCap;
        private DevExpress.XtraEditors.LabelControl label6;
        private System.Windows.Forms.TextBox txtSoLuong;
        private DevExpress.XtraEditors.LabelControl label9;
        private System.Windows.Forms.TextBox txtVatTu;
        private CustomComboBox cboVatTu;
        private DevExpress.XtraEditors.LabelControl label8;
        private System.Windows.Forms.TextBox txtNhomVatTu;
        private CustomComboBox cboNhomVatTu;
        private DevExpress.XtraEditors.LabelControl label7;
        private DevExpress.XtraEditors.LabelControl label10;
        private System.Windows.Forms.TextBox txtDonViTinh;
        private System.Windows.Forms.DateTimePicker dtpHanSuDung;
        private TPH.Controls.TPHNormalButton btnNhapKho;
        private CustomDatagridView dtgChiTietNhap;
        private CustomBindingNavigator bvChiTietNhap;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton btnSuaVatTu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnXoaVatTu;
        private DevExpress.XtraEditors.PanelControl panel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTimSoPhieu;
        private DevExpress.XtraEditors.LabelControl label11;
        private DevExpress.XtraEditors.PanelControl panel3;
        private DevExpress.XtraEditors.PanelControl panel4;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private DevExpress.XtraEditors.LabelControl label12;
        private System.Windows.Forms.CheckBox chkHangTang;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaVatTu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenVatTu;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaNhap;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CoHSD;
        private CustomCalendarColumn HanSuDung;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HangTang;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuyCach;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonViQuyCach;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhomVatTu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhaCungCap;
    }
}