using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.CauHinh.DanhMucDichVuKhac
{
    partial class Frm_OrtherItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_OrtherItems));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgNhom = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.MaNhomCLS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhomCLS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MauKQ = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bvNhom = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeleteNhom = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.txtMauKetQua = new System.Windows.Forms.TextBox();
            this.label10 = new DevExpress.XtraEditors.LabelControl();
            this.cboMauKQ = new TPH.LIS.Common.Controls.CustomComboBox();
            this.btnThemNhom = new TPH.Controls.TPHNormalButton();
            this.txtTenNhom = new System.Windows.Forms.TextBox();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaNhom = new System.Windows.Forms.TextBox();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgDichVu = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.dMaNhom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.madvkhac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tendvkhac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MauKetQua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeNghi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaChuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThuTuIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bvDichVu = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.panel2 = new DevExpress.XtraEditors.PanelControl();
            this.rchMauKetQua = new RicherTextBox.RicherTextBox();
            this.panel3 = new DevExpress.XtraEditors.PanelControl();
            this.txtThuTuIn = new System.Windows.Forms.TextBox();
            this.label8 = new DevExpress.XtraEditors.LabelControl();
            this.label9 = new DevExpress.XtraEditors.LabelControl();
            this.txtGiaChuan = new System.Windows.Forms.TextBox();
            this.label6 = new DevExpress.XtraEditors.LabelControl();
            this.btnLuuDV = new TPH.Controls.TPHNormalButton();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.btnThemMoiDV = new TPH.Controls.TPHNormalButton();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.btnXoaDV = new TPH.Controls.TPHNormalButton();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.btnSuaDV = new TPH.Controls.TPHNormalButton();
            this.label7 = new DevExpress.XtraEditors.LabelControl();
            this.txtDeNghi = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtTenDichVu = new System.Windows.Forms.TextBox();
            this.txtMaDichVu = new System.Windows.Forms.TextBox();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            this.pnMenu.SuspendLayout();
            this.xtraScrollableControlMain.SuspendLayout();
            this.pnFormControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNhom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvNhom)).BeginInit();
            this.bvNhom.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvDichVu)).BeginInit();
            this.bvDichVu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(255, 21);
            this.lblTitle.Text = "CẤU HÌNH DANH MỤC  DỊCH VỤ";
            // 
            // pnContaint
            // 
            this.pnContaint.Controls.Add(this.splitContainer1);
            this.pnContaint.Location = new System.Drawing.Point(0, 57);
            this.pnContaint.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnContaint.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnContaint.Size = new System.Drawing.Size(839, 327);
            // 
            // pnLabel
            // 
            this.pnLabel.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnLabel.Size = new System.Drawing.Size(839, 31);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Crimson;
            this.btnClose.Location = new System.Drawing.Point(413, 0);
            this.btnClose.Size = new System.Drawing.Size(29, 31);
            this.btnClose.TextColor = System.Drawing.Color.Crimson;
            // 
            // lblMainESC
            // 
            this.lblMainESC.Location = new System.Drawing.Point(442, 0);
            this.lblMainESC.Size = new System.Drawing.Size(397, 31);
            // 
            // pnMenu
            // 
            this.pnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnMenu.Location = new System.Drawing.Point(0, 31);
            this.pnMenu.Size = new System.Drawing.Size(839, 26);
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(839, 25);
            // 
            // ucGroupHeaderChonMain
            // 
            this.ucGroupHeaderChonMain.Location = new System.Drawing.Point(257, 1);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Location = new System.Drawing.Point(731, 1);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(171)))), ((int)(((byte)(203)))));
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(160)))), ((int)(((byte)(190)))));
            // 
            // btnMaximize
            // 
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(141)))), ((int)(((byte)(233)))));
            this.btnMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(132)))), ((int)(((byte)(218)))));
            // 
            // tphIconButton1
            // 
            this.tphIconButton1.FlatAppearance.BorderSize = 0;
            this.tphIconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(87)))), ((int)(((byte)(125)))));
            this.tphIconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(81)))), ((int)(((byte)(117)))));
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(2, 1);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(835, 325);
            this.splitContainer1.SplitterPosition = 278;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgNhom);
            this.groupBox1.Controls.Add(this.bvNhom);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(278, 325);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhóm dịch vụ";
            // 
            // dtgNhom
            // 
            this.dtgNhom.AlignColumns = "";
            this.dtgNhom.AllignNumberText = false;
            this.dtgNhom.AllowUserToAddRows = false;
            this.dtgNhom.AllowUserToDeleteRows = false;
            this.dtgNhom.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgNhom.CheckBoldColumn = false;
            this.dtgNhom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNhomCLS,
            this.TenNhomCLS,
            this.MauKQ});
            this.dtgNhom.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(132)))), ((int)(((byte)(176)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgNhom.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtgNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgNhom.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgNhom.Location = new System.Drawing.Point(3, 107);
            this.dtgNhom.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.dtgNhom.MarkOddEven = true;
            this.dtgNhom.MultiSelect = false;
            this.dtgNhom.Name = "dtgNhom";
            this.dtgNhom.RowHeadersWidth = 40;
            this.dtgNhom.RowTemplate.Height = 28;
            this.dtgNhom.Size = new System.Drawing.Size(272, 191);
            this.dtgNhom.TabIndex = 1;
            this.dtgNhom.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgNhom_CellEnter);
            this.dtgNhom.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgNhom_DataBindingComplete);
            // 
            // MaNhomCLS
            // 
            this.MaNhomCLS.DataPropertyName = "MaNhomCLS";
            this.MaNhomCLS.HeaderText = "Mã nhóm";
            this.MaNhomCLS.Name = "MaNhomCLS";
            // 
            // TenNhomCLS
            // 
            this.TenNhomCLS.DataPropertyName = "TenNhomCLS";
            this.TenNhomCLS.HeaderText = "Tên nhóm";
            this.TenNhomCLS.Name = "TenNhomCLS";
            this.TenNhomCLS.Width = 250;
            // 
            // MauKQ
            // 
            this.MauKQ.DataPropertyName = "MauKQ";
            this.MauKQ.HeaderText = "Mẫu KQ";
            this.MauKQ.Name = "MauKQ";
            this.MauKQ.Width = 200;
            // 
            // bvNhom
            // 
            this.bvNhom.AddNewItem = null;
            this.bvNhom.CountItem = this.bindingNavigatorCountItem;
            this.bvNhom.CountItemFormat = "/ {0}";
            this.bvNhom.DeleteItem = null;
            this.bvNhom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvNhom.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvNhom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.btnDeleteNhom});
            this.bvNhom.Location = new System.Drawing.Point(3, 298);
            this.bvNhom.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bvNhom.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bvNhom.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bvNhom.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bvNhom.Name = "bvNhom";
            this.bvNhom.PositionItem = this.bindingNavigatorPositionItem;
            this.bvNhom.Size = new System.Drawing.Size(272, 25);
            this.bvNhom.TabIndex = 0;
            this.bvNhom.Text = "CustomBindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(30, 22);
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
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(43, 23);
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
            // btnDeleteNhom
            // 
            this.btnDeleteNhom.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteNhom.Image")));
            this.btnDeleteNhom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteNhom.Name = "btnDeleteNhom";
            this.btnDeleteNhom.Size = new System.Drawing.Size(84, 22);
            this.btnDeleteNhom.Text = "Xóa nhóm";
            this.btnDeleteNhom.Click += new System.EventHandler(this.btnDeleteNhom_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMauKetQua);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cboMauKQ);
            this.panel1.Controls.Add(this.btnThemNhom);
            this.panel1.Controls.Add(this.txtTenNhom);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtMaNhom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 92);
            this.panel1.TabIndex = 2;
            // 
            // txtMauKetQua
            // 
            this.txtMauKetQua.Location = new System.Drawing.Point(143, 47);
            this.txtMauKetQua.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtMauKetQua.Name = "txtMauKetQua";
            this.txtMauKetQua.Size = new System.Drawing.Size(122, 20);
            this.txtMauKetQua.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Mẫu phiếu KQ";
            // 
            // cboMauKQ
            // 
            this.cboMauKQ.AutoComplete = false;
            this.cboMauKQ.AutoDropdown = false;
            this.cboMauKQ.BackColorEven = System.Drawing.Color.White;
            this.cboMauKQ.BackColorOdd = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.cboMauKQ.ColumnNames = "";
            this.cboMauKQ.ColumnWidthDefault = 75;
            this.cboMauKQ.ColumnWidths = "";
            this.cboMauKQ.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboMauKQ.FormattingEnabled = true;
            this.cboMauKQ.LinkedColumnIndex = 0;
            this.cboMauKQ.LinkedColumnIndex1 = 0;
            this.cboMauKQ.LinkedColumnIndex2 = 0;
            this.cboMauKQ.LinkedTextBox = null;
            this.cboMauKQ.LinkedTextBox1 = null;
            this.cboMauKQ.LinkedTextBox2 = null;
            this.cboMauKQ.Location = new System.Drawing.Point(83, 46);
            this.cboMauKQ.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.cboMauKQ.Name = "cboMauKQ";
            this.cboMauKQ.Size = new System.Drawing.Size(58, 21);
            this.cboMauKQ.TabIndex = 5;
            this.cboMauKQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMauKQ_KeyPress);
            // 
            // btnThemNhom
            // 
            this.btnThemNhom.BackColor = System.Drawing.Color.Transparent;
            this.btnThemNhom.BackColorHover = System.Drawing.Color.Empty;
            this.btnThemNhom.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnThemNhom.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThemNhom.BorderRadius = 5;
            this.btnThemNhom.BorderSize = 1;
            this.btnThemNhom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemNhom.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNhom.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThemNhom.ForeColor = System.Drawing.Color.Black;
            this.btnThemNhom.Image = ((System.Drawing.Image)(resources.GetObject("btnThemNhom.Image")));
            this.btnThemNhom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemNhom.Location = new System.Drawing.Point(181, 70);
            this.btnThemNhom.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnThemNhom.Name = "btnThemNhom";
            this.btnThemNhom.Size = new System.Drawing.Size(84, 18);
            this.btnThemNhom.TabIndex = 4;
            this.btnThemNhom.Text = "Thêm mới";
            this.btnThemNhom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemNhom.TextColor = System.Drawing.Color.Black;
            this.btnThemNhom.UseHightLight = true;
            this.btnThemNhom.UseVisualStyleBackColor = false;
            this.btnThemNhom.Click += new System.EventHandler(this.txtThemNhom_Click);
            // 
            // txtTenNhom
            // 
            this.txtTenNhom.Location = new System.Drawing.Point(59, 25);
            this.txtTenNhom.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtTenNhom.Name = "txtTenNhom";
            this.txtTenNhom.Size = new System.Drawing.Size(206, 20);
            this.txtTenNhom.TabIndex = 3;
            this.txtTenNhom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenNhom_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên nhóm";
            // 
            // txtMaNhom
            // 
            this.txtMaNhom.Location = new System.Drawing.Point(59, 5);
            this.txtMaNhom.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtMaNhom.Name = "txtMaNhom";
            this.txtMaNhom.Size = new System.Drawing.Size(122, 20);
            this.txtMaNhom.TabIndex = 1;
            this.txtMaNhom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnMaNhom_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã nhóm";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgDichVu);
            this.groupBox2.Controls.Add(this.bvDichVu);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(554, 325);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết nhóm";
            // 
            // dtgDichVu
            // 
            this.dtgDichVu.AlignColumns = "";
            this.dtgDichVu.AllignNumberText = false;
            this.dtgDichVu.AllowUserToAddRows = false;
            this.dtgDichVu.AllowUserToDeleteRows = false;
            this.dtgDichVu.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgDichVu.CheckBoldColumn = false;
            this.dtgDichVu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dMaNhom,
            this.madvkhac,
            this.tendvkhac,
            this.MauKetQua,
            this.GhiChu,
            this.DeNghi,
            this.GiaChuan,
            this.ThuTuIn});
            this.dtgDichVu.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(132)))), ((int)(((byte)(176)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDichVu.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDichVu.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgDichVu.Location = new System.Drawing.Point(3, 168);
            this.dtgDichVu.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.dtgDichVu.MarkOddEven = true;
            this.dtgDichVu.MultiSelect = false;
            this.dtgDichVu.Name = "dtgDichVu";
            this.dtgDichVu.ReadOnly = true;
            this.dtgDichVu.RowHeadersWidth = 40;
            this.dtgDichVu.RowTemplate.Height = 28;
            this.dtgDichVu.Size = new System.Drawing.Size(548, 130);
            this.dtgDichVu.TabIndex = 4;
            // 
            // dMaNhom
            // 
            this.dMaNhom.DataPropertyName = "MaNhomCLS";
            this.dMaNhom.HeaderText = "Mã nhóm";
            this.dMaNhom.Name = "dMaNhom";
            this.dMaNhom.ReadOnly = true;
            // 
            // madvkhac
            // 
            this.madvkhac.DataPropertyName = "madvkhac";
            this.madvkhac.HeaderText = "Mã dịch vụ";
            this.madvkhac.Name = "madvkhac";
            this.madvkhac.ReadOnly = true;
            // 
            // tendvkhac
            // 
            this.tendvkhac.DataPropertyName = "tendvkhac";
            this.tendvkhac.HeaderText = "Tên dịch vụ";
            this.tendvkhac.Name = "tendvkhac";
            this.tendvkhac.ReadOnly = true;
            this.tendvkhac.Width = 250;
            // 
            // MauKetQua
            // 
            this.MauKetQua.DataPropertyName = "MauKetQua";
            this.MauKetQua.HeaderText = "Mẫu kết quả";
            this.MauKetQua.Name = "MauKetQua";
            this.MauKetQua.ReadOnly = true;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            // 
            // DeNghi
            // 
            this.DeNghi.DataPropertyName = "DeNghi";
            this.DeNghi.HeaderText = "Đề nghị";
            this.DeNghi.Name = "DeNghi";
            this.DeNghi.ReadOnly = true;
            // 
            // GiaChuan
            // 
            this.GiaChuan.DataPropertyName = "GiaChuan";
            this.GiaChuan.HeaderText = "Giá chuẩn";
            this.GiaChuan.Name = "GiaChuan";
            this.GiaChuan.ReadOnly = true;
            // 
            // ThuTuIn
            // 
            this.ThuTuIn.DataPropertyName = "ThuTuIn";
            this.ThuTuIn.HeaderText = "Thứ tự in";
            this.ThuTuIn.Name = "ThuTuIn";
            this.ThuTuIn.ReadOnly = true;
            // 
            // bvDichVu
            // 
            this.bvDichVu.AddNewItem = null;
            this.bvDichVu.CountItem = this.toolStripLabel1;
            this.bvDichVu.CountItemFormat = "/ {0}";
            this.bvDichVu.DeleteItem = null;
            this.bvDichVu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvDichVu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvDichVu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator1,
            this.toolStripTextBox1,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripSeparator3});
            this.bvDichVu.Location = new System.Drawing.Point(3, 298);
            this.bvDichVu.MoveFirstItem = this.toolStripButton3;
            this.bvDichVu.MoveLastItem = this.toolStripButton6;
            this.bvDichVu.MoveNextItem = this.toolStripButton5;
            this.bvDichVu.MovePreviousItem = this.toolStripButton4;
            this.bvDichVu.Name = "bvDichVu";
            this.bvDichVu.PositionItem = this.toolStripTextBox1;
            this.bvDichVu.Size = new System.Drawing.Size(548, 25);
            this.bvDichVu.TabIndex = 5;
            this.bvDichVu.Text = "CustomBindingNavigator2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(30, 22);
            this.toolStripLabel1.Text = "/ {0}";
            this.toolStripLabel1.ToolTipText = "Total number of items";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.RightToLeftAutoMirrorImage = true;
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Move first";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.RightToLeftAutoMirrorImage = true;
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Move previous";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AccessibleName = "Position";
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(43, 23);
            this.toolStripTextBox1.Text = "0";
            this.toolStripTextBox1.ToolTipText = "Current position";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.RightToLeftAutoMirrorImage = true;
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "Move next";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.RightToLeftAutoMirrorImage = true;
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "Move last";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rchMauKetQua);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 15);
            this.panel2.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(548, 153);
            this.panel2.TabIndex = 3;
            // 
            // rchMauKetQua
            // 
            this.rchMauKetQua.AlignCenterVisible = false;
            this.rchMauKetQua.AlignLeftVisible = false;
            this.rchMauKetQua.AlignRightVisible = false;
            this.rchMauKetQua.BoldVisible = false;
            this.rchMauKetQua.BulletsVisible = false;
            this.rchMauKetQua.ChooseFontVisible = true;
            this.rchMauKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchMauKetQua.FindReplaceVisible = false;
            this.rchMauKetQua.FontColorVisible = false;
            this.rchMauKetQua.FontFamilyVisible = true;
            this.rchMauKetQua.FontSizeVisible = true;
            this.rchMauKetQua.GroupAlignmentVisible = false;
            this.rchMauKetQua.GroupBoldUnderlineItalicVisible = false;
            this.rchMauKetQua.GroupFontColorVisible = false;
            this.rchMauKetQua.GroupFontNameAndSizeVisible = true;
            this.rchMauKetQua.GroupIndentationAndBulletsVisible = false;
            this.rchMauKetQua.GroupInsertVisible = false;
            this.rchMauKetQua.GroupSaveAndLoadVisible = false;
            this.rchMauKetQua.GroupZoomVisible = false;
            this.rchMauKetQua.INDENT = 10;
            this.rchMauKetQua.IndentVisible = false;
            this.rchMauKetQua.InsertPictureVisible = false;
            this.rchMauKetQua.ItalicVisible = true;
            this.rchMauKetQua.LoadVisible = false;
            this.rchMauKetQua.Location = new System.Drawing.Point(285, 0);
            this.rchMauKetQua.Name = "rchMauKetQua";
            this.rchMauKetQua.OutdentVisible = false;
            this.rchMauKetQua.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset20" +
    "4 Microsoft Sans Serif;}}\r\n{\\*\\generator Riched20 10.0.22000}\\viewkind4\\uc1 \r\n\\p" +
    "ard\\f0\\fs18\\lang1049\\par\r\n}\r\n";
            this.rchMauKetQua.SaveVisible = false;
            this.rchMauKetQua.SeparatorAlignVisible = false;
            this.rchMauKetQua.SeparatorBoldUnderlineItalicVisible = false;
            this.rchMauKetQua.SeparatorFontColorVisible = false;
            this.rchMauKetQua.SeparatorFontVisible = true;
            this.rchMauKetQua.SeparatorIndentAndBulletsVisible = false;
            this.rchMauKetQua.SeparatorInsertVisible = false;
            this.rchMauKetQua.SeparatorSaveLoadVisible = false;
            this.rchMauKetQua.Size = new System.Drawing.Size(263, 153);
            this.rchMauKetQua.TabIndex = 10;
            this.rchMauKetQua.ToolStripVisible = true;
            this.rchMauKetQua.UnderlineVisible = false;
            this.rchMauKetQua.WordWrapVisible = false;
            this.rchMauKetQua.ZoomFactorTextVisible = false;
            this.rchMauKetQua.ZoomInVisible = false;
            this.rchMauKetQua.ZoomOutVisible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtThuTuIn);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txtGiaChuan);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.btnLuuDV);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.btnThemMoiDV);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btnXoaDV);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btnSuaDV);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtDeNghi);
            this.panel3.Controls.Add(this.txtGhiChu);
            this.panel3.Controls.Add(this.txtTenDichVu);
            this.panel3.Controls.Add(this.txtMaDichVu);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(285, 153);
            this.panel3.TabIndex = 29;
            // 
            // txtThuTuIn
            // 
            this.txtThuTuIn.Location = new System.Drawing.Point(221, 90);
            this.txtThuTuIn.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtThuTuIn.Name = "txtThuTuIn";
            this.txtThuTuIn.Size = new System.Drawing.Size(60, 20);
            this.txtThuTuIn.TabIndex = 28;
            this.txtThuTuIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThuTuIn_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Giá chuẩn";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(164, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Thứ tự in";
            // 
            // txtGiaChuan
            // 
            this.txtGiaChuan.Location = new System.Drawing.Point(68, 90);
            this.txtGiaChuan.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtGiaChuan.Name = "txtGiaChuan";
            this.txtGiaChuan.Size = new System.Drawing.Size(60, 20);
            this.txtGiaChuan.TabIndex = 26;
            this.txtGiaChuan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiaChuan_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Đề nghị";
            // 
            // btnLuuDV
            // 
            this.btnLuuDV.BackColor = System.Drawing.Color.Transparent;
            this.btnLuuDV.BackColorHover = System.Drawing.Color.Empty;
            this.btnLuuDV.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnLuuDV.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnLuuDV.BorderRadius = 5;
            this.btnLuuDV.BorderSize = 1;
            this.btnLuuDV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuDV.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuDV.ForceColorHover = System.Drawing.Color.Empty;
            this.btnLuuDV.ForeColor = System.Drawing.Color.Black;
            this.btnLuuDV.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuDV.Image")));
            this.btnLuuDV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuuDV.Location = new System.Drawing.Point(162, 123);
            this.btnLuuDV.Name = "btnLuuDV";
            this.btnLuuDV.Size = new System.Drawing.Size(57, 19);
            this.btnLuuDV.TabIndex = 24;
            this.btnLuuDV.Text = "Lưu";
            this.btnLuuDV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuuDV.TextColor = System.Drawing.Color.Black;
            this.btnLuuDV.UseHightLight = true;
            this.btnLuuDV.UseVisualStyleBackColor = true;
            this.btnLuuDV.Click += new System.EventHandler(this.btnLuuDV_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ghi chú";
            // 
            // btnThemMoiDV
            // 
            this.btnThemMoiDV.BackColor = System.Drawing.Color.Transparent;
            this.btnThemMoiDV.BackColorHover = System.Drawing.Color.Empty;
            this.btnThemMoiDV.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnThemMoiDV.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThemMoiDV.BorderRadius = 5;
            this.btnThemMoiDV.BorderSize = 1;
            this.btnThemMoiDV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemMoiDV.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMoiDV.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThemMoiDV.ForeColor = System.Drawing.Color.Black;
            this.btnThemMoiDV.Image = ((System.Drawing.Image)(resources.GetObject("btnThemMoiDV.Image")));
            this.btnThemMoiDV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemMoiDV.Location = new System.Drawing.Point(6, 123);
            this.btnThemMoiDV.Name = "btnThemMoiDV";
            this.btnThemMoiDV.Size = new System.Drawing.Size(90, 19);
            this.btnThemMoiDV.TabIndex = 23;
            this.btnThemMoiDV.Text = "Thêm mới";
            this.btnThemMoiDV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemMoiDV.TextColor = System.Drawing.Color.Black;
            this.btnThemMoiDV.UseHightLight = true;
            this.btnThemMoiDV.UseVisualStyleBackColor = true;
            this.btnThemMoiDV.Click += new System.EventHandler(this.btnThemMoiDV_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên dịch vụ";
            // 
            // btnXoaDV
            // 
            this.btnXoaDV.BackColor = System.Drawing.Color.Transparent;
            this.btnXoaDV.BackColorHover = System.Drawing.Color.Empty;
            this.btnXoaDV.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnXoaDV.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXoaDV.BorderRadius = 5;
            this.btnXoaDV.BorderSize = 1;
            this.btnXoaDV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaDV.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaDV.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXoaDV.ForeColor = System.Drawing.Color.Black;
            this.btnXoaDV.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaDV.Image")));
            this.btnXoaDV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaDV.Location = new System.Drawing.Point(225, 123);
            this.btnXoaDV.Name = "btnXoaDV";
            this.btnXoaDV.Size = new System.Drawing.Size(53, 19);
            this.btnXoaDV.TabIndex = 22;
            this.btnXoaDV.Text = "Xóa";
            this.btnXoaDV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaDV.TextColor = System.Drawing.Color.Black;
            this.btnXoaDV.UseHightLight = true;
            this.btnXoaDV.UseVisualStyleBackColor = true;
            this.btnXoaDV.Click += new System.EventHandler(this.btnXoaDV_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mã dịch vụ";
            // 
            // btnSuaDV
            // 
            this.btnSuaDV.BackColor = System.Drawing.Color.Transparent;
            this.btnSuaDV.BackColorHover = System.Drawing.Color.Empty;
            this.btnSuaDV.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnSuaDV.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnSuaDV.BorderRadius = 5;
            this.btnSuaDV.BorderSize = 1;
            this.btnSuaDV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaDV.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnSuaDV.ForceColorHover = System.Drawing.Color.Empty;
            this.btnSuaDV.ForeColor = System.Drawing.Color.Black;
            this.btnSuaDV.Image = ((System.Drawing.Image)(resources.GetObject("btnSuaDV.Image")));
            this.btnSuaDV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaDV.Location = new System.Drawing.Point(101, 123);
            this.btnSuaDV.Name = "btnSuaDV";
            this.btnSuaDV.Size = new System.Drawing.Size(56, 19);
            this.btnSuaDV.TabIndex = 21;
            this.btnSuaDV.Text = "Sửa";
            this.btnSuaDV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuaDV.TextColor = System.Drawing.Color.Black;
            this.btnSuaDV.UseHightLight = true;
            this.btnSuaDV.UseVisualStyleBackColor = false;
            this.btnSuaDV.Click += new System.EventHandler(this.btnSuaDV_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(209, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Mẫu kết quả";
            // 
            // txtDeNghi
            // 
            this.txtDeNghi.Location = new System.Drawing.Point(68, 68);
            this.txtDeNghi.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtDeNghi.Name = "txtDeNghi";
            this.txtDeNghi.Size = new System.Drawing.Size(213, 20);
            this.txtDeNghi.TabIndex = 8;
            this.txtDeNghi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDeNghi_KeyPress);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(68, 46);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(213, 20);
            this.txtGhiChu.TabIndex = 6;
            this.txtGhiChu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGhiChu_KeyPress);
            // 
            // txtTenDichVu
            // 
            this.txtTenDichVu.Location = new System.Drawing.Point(68, 24);
            this.txtTenDichVu.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtTenDichVu.Name = "txtTenDichVu";
            this.txtTenDichVu.Size = new System.Drawing.Size(213, 20);
            this.txtTenDichVu.TabIndex = 3;
            this.txtTenDichVu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenDichVu_KeyPress);
            // 
            // txtMaDichVu
            // 
            this.txtMaDichVu.Location = new System.Drawing.Point(68, 3);
            this.txtMaDichVu.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtMaDichVu.Name = "txtMaDichVu";
            this.txtMaDichVu.Size = new System.Drawing.Size(122, 20);
            this.txtMaDichVu.TabIndex = 1;
            this.txtMaDichVu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaDichVu_KeyPress);
            // 
            // Frm_OrtherItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(839, 384);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Name = "Frm_OrtherItems";
            this.Text = "Cấu hình danh mục dịch vụ";
            this.Load += new System.EventHandler(this.Frm_OrtherItems_Load);
            this.pnContaint.ResumeLayout(false);
            this.pnLabel.ResumeLayout(false);
            this.pnMenu.ResumeLayout(false);
            this.xtraScrollableControlMain.ResumeLayout(false);
            this.xtraScrollableControlMain.PerformLayout();
            this.pnFormControl.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNhom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvNhom)).EndInit();
            this.bvNhom.ResumeLayout(false);
            this.bvNhom.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvDichVu)).EndInit();
            this.bvDichVu.ResumeLayout(false);
            this.bvDichVu.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private CustomDatagridView dtgNhom;
        private CustomBindingNavigator bvNhom;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private DevExpress.XtraEditors.PanelControl panel1;
        private TPH.Controls.TPHNormalButton btnThemNhom;
        private System.Windows.Forms.TextBox txtTenNhom;
        private DevExpress.XtraEditors.LabelControl label2;
        private System.Windows.Forms.TextBox txtMaNhom;
        private DevExpress.XtraEditors.LabelControl label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.PanelControl panel2;
        private System.Windows.Forms.TextBox txtDeNghi;
        private DevExpress.XtraEditors.LabelControl label6;
        private System.Windows.Forms.TextBox txtGhiChu;
        private DevExpress.XtraEditors.LabelControl label5;
        private System.Windows.Forms.TextBox txtTenDichVu;
        private DevExpress.XtraEditors.LabelControl label3;
        private System.Windows.Forms.TextBox txtMaDichVu;
        private DevExpress.XtraEditors.LabelControl label4;
        private RicherTextBox.RicherTextBox rchMauKetQua;
        private DevExpress.XtraEditors.LabelControl label7;
        private System.Windows.Forms.TextBox txtGiaChuan;
        private DevExpress.XtraEditors.LabelControl label8;
        private TPH.Controls.TPHNormalButton btnLuuDV;
        private TPH.Controls.TPHNormalButton btnThemMoiDV;
        private TPH.Controls.TPHNormalButton btnXoaDV;
        private TPH.Controls.TPHNormalButton btnSuaDV;
        private CustomBindingNavigator bvDichVu;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private CustomDatagridView dtgDichVu;
        private System.Windows.Forms.TextBox txtThuTuIn;
        private DevExpress.XtraEditors.LabelControl label9;
        private System.Windows.Forms.TextBox txtMauKetQua;
        private DevExpress.XtraEditors.LabelControl label10;
        private CustomComboBox cboMauKQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhomCLS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhomCLS;
        private System.Windows.Forms.DataGridViewComboBoxColumn MauKQ;
        private System.Windows.Forms.ToolStripButton btnDeleteNhom;
        private DevExpress.XtraEditors.PanelControl panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dMaNhom;
        private System.Windows.Forms.DataGridViewTextBoxColumn madvkhac;
        private System.Windows.Forms.DataGridViewTextBoxColumn tendvkhac;
        private System.Windows.Forms.DataGridViewTextBoxColumn MauKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeNghi;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaChuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThuTuIn;
    }
}