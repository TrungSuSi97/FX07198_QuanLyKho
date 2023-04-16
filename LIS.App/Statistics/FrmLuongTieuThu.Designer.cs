using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.ThongKe
{
    partial class FrmLuongTieuThu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLuongTieuThu));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtgHCXN = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.STT3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaVatTu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenVatTu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hcTieuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hcDVTieuHao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iscate3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bvHCXN = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnHC_XN = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnXuatHCXN = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenVatTu_XN = new System.Windows.Forms.TextBox();
            this.cboVatTu_XN = new TPH.LIS.Common.Controls.CustomComboBox();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            this.pnMenu.SuspendLayout();
            this.xtraScrollableControlMain.SuspendLayout();
            this.pnFormControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHCXN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvHCXN)).BeginInit();
            this.bvHCXN.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(302, 22);
            this.lblTitle.Text = "THỐNG KÊ LƯỢNG SỬ DỤNG VẬT TƯ";
            // 
            // pnContaint
            // 
            this.pnContaint.Controls.Add(this.tabControl1);
            this.pnContaint.Controls.Add(this.groupBox1);
            this.pnContaint.Location = new System.Drawing.Point(0, 0);
            this.pnContaint.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnContaint.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnContaint.Size = new System.Drawing.Size(986, 455);
            // 
            // pnLabel
            // 
            this.pnLabel.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnLabel.Size = new System.Drawing.Size(986, 0);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Crimson;
            this.btnClose.Location = new System.Drawing.Point(560, 0);
            this.btnClose.Size = new System.Drawing.Size(29, 0);
            this.btnClose.TextColor = System.Drawing.Color.Crimson;
            // 
            // lblMainESC
            // 
            this.lblMainESC.Location = new System.Drawing.Point(589, 0);
            this.lblMainESC.Size = new System.Drawing.Size(397, 0);
            // 
            // pnMenu
            // 
            this.pnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnMenu.Size = new System.Drawing.Size(986, 0);
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(986, 0);
            // 
            // ucGroupHeaderChonMain
            // 
            this.ucGroupHeaderChonMain.Location = new System.Drawing.Point(304, 1);
            this.ucGroupHeaderChonMain.Size = new System.Drawing.Size(10, 0);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Location = new System.Drawing.Point(878, 1);
            this.pnFormControl.Size = new System.Drawing.Size(106, 0);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpDateTo);
            this.groupBox1.Controls.Add(this.dtpDateFrom);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(982, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thời gian";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(237, 16);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(99, 21);
            this.dtpDateTo.TabIndex = 7;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(64, 16);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(95, 21);
            this.dtpDateFrom.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Từ ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "đến ngày";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(2, 52);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(982, 402);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtgHCXN);
            this.tabPage1.Controls.Add(this.bvHCXN);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(974, 374);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hóa chất xét nghiệm";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dtgHCXN
            // 
            this.dtgHCXN.AlignColumns = "";
            this.dtgHCXN.AllignNumberText = false;
            this.dtgHCXN.AllowUserToAddRows = false;
            this.dtgHCXN.AllowUserToDeleteRows = false;
            this.dtgHCXN.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgHCXN.CheckBoldColumn = false;
            this.dtgHCXN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHCXN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT3,
            this.MaVatTu,
            this.TenVatTu,
            this.thSoLuong,
            this.hcTieuThu,
            this.hcDVTieuHao,
            this.iscate3});
            this.dtgHCXN.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(132)))), ((int)(((byte)(176)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgHCXN.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgHCXN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgHCXN.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgHCXN.Location = new System.Drawing.Point(3, 81);
            this.dtgHCXN.MarkOddEven = true;
            this.dtgHCXN.MultiSelect = false;
            this.dtgHCXN.Name = "dtgHCXN";
            this.dtgHCXN.ReadOnly = true;
            this.dtgHCXN.RowHeadersVisible = false;
            this.dtgHCXN.RowHeadersWidth = 35;
            this.dtgHCXN.Size = new System.Drawing.Size(968, 291);
            this.dtgHCXN.TabIndex = 5;
            // 
            // STT3
            // 
            this.STT3.DataPropertyName = "No1";
            this.STT3.HeaderText = "STT";
            this.STT3.Name = "STT3";
            this.STT3.ReadOnly = true;
            this.STT3.Width = 50;
            // 
            // MaVatTu
            // 
            this.MaVatTu.DataPropertyName = "MaVatTu";
            this.MaVatTu.HeaderText = "Mã vật tư";
            this.MaVatTu.Name = "MaVatTu";
            this.MaVatTu.ReadOnly = true;
            this.MaVatTu.Visible = false;
            // 
            // TenVatTu
            // 
            this.TenVatTu.DataPropertyName = "TenVatTu";
            this.TenVatTu.HeaderText = "Tên vật tư";
            this.TenVatTu.Name = "TenVatTu";
            this.TenVatTu.ReadOnly = true;
            this.TenVatTu.Width = 250;
            // 
            // thSoLuong
            // 
            this.thSoLuong.DataPropertyName = "SoLuong";
            this.thSoLuong.HeaderText = "Số lượng XN";
            this.thSoLuong.Name = "thSoLuong";
            this.thSoLuong.ReadOnly = true;
            this.thSoLuong.Width = 115;
            // 
            // hcTieuThu
            // 
            this.hcTieuThu.DataPropertyName = "LuongTieuThu";
            dataGridViewCellStyle1.Format = "0.###";
            this.hcTieuThu.DefaultCellStyle = dataGridViewCellStyle1;
            this.hcTieuThu.HeaderText = "Lượng tiêu thụ";
            this.hcTieuThu.Name = "hcTieuThu";
            this.hcTieuThu.ReadOnly = true;
            this.hcTieuThu.Width = 130;
            // 
            // hcDVTieuHao
            // 
            this.hcDVTieuHao.DataPropertyName = "DVTTieuHao";
            this.hcDVTieuHao.HeaderText = "ĐVT";
            this.hcDVTieuHao.Name = "hcDVTieuHao";
            this.hcDVTieuHao.ReadOnly = true;
            // 
            // iscate3
            // 
            this.iscate3.DataPropertyName = "iscate";
            this.iscate3.HeaderText = "iscate";
            this.iscate3.Name = "iscate3";
            this.iscate3.ReadOnly = true;
            this.iscate3.Visible = false;
            // 
            // bvHCXN
            // 
            this.bvHCXN.AddNewItem = null;
            this.bvHCXN.CountItem = this.toolStripLabel2;
            this.bvHCXN.CountItemFormat = "/ {0}";
            this.bvHCXN.DeleteItem = null;
            this.bvHCXN.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvHCXN.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton7,
            this.toolStripSeparator6,
            this.toolStripTextBox2,
            this.toolStripLabel2,
            this.toolStripSeparator7,
            this.toolStripButton8,
            this.toolStripSeparator8,
            this.btnHC_XN,
            this.toolStripSeparator9,
            this.btnXuatHCXN});
            this.bvHCXN.Location = new System.Drawing.Point(3, 56);
            this.bvHCXN.MoveFirstItem = null;
            this.bvHCXN.MoveLastItem = null;
            this.bvHCXN.MoveNextItem = this.toolStripButton8;
            this.bvHCXN.MovePreviousItem = this.toolStripButton7;
            this.bvHCXN.Name = "bvHCXN";
            this.bvHCXN.PositionItem = this.toolStripTextBox2;
            this.bvHCXN.Size = new System.Drawing.Size(968, 25);
            this.bvHCXN.TabIndex = 4;
            this.bvHCXN.Text = "bindingNavigator3";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(30, 22);
            this.toolStripLabel2.Text = "/ {0}";
            this.toolStripLabel2.ToolTipText = "Total number of items";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.RightToLeftAutoMirrorImage = true;
            this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton7.Text = "Move previous";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.AccessibleName = "Position";
            this.toolStripTextBox2.AutoSize = false;
            this.toolStripTextBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(38, 23);
            this.toolStripTextBox2.Text = "0";
            this.toolStripTextBox2.ToolTipText = "Current position";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.RightToLeftAutoMirrorImage = true;
            this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton8.Text = "Move next";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // btnHC_XN
            // 
            this.btnHC_XN.Image = ((System.Drawing.Image)(resources.GetObject("btnHC_XN.Image")));
            this.btnHC_XN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHC_XN.Name = "btnHC_XN";
            this.btnHC_XN.Size = new System.Drawing.Size(79, 22);
            this.btnHC_XN.Text = "Thống kê";
            this.btnHC_XN.Click += new System.EventHandler(this.btnHC_XN_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // btnXuatHCXN
            // 
            this.btnXuatHCXN.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatHCXN.Image")));
            this.btnXuatHCXN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXuatHCXN.Name = "btnXuatHCXN";
            this.btnXuatHCXN.Size = new System.Drawing.Size(87, 22);
            this.btnXuatHCXN.Text = "Xuất Excel";
            this.btnXuatHCXN.Click += new System.EventHandler(this.btnXuatHCXN_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtTenVatTu_XN);
            this.groupBox2.Controls.Add(this.cboVatTu_XN);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(968, 54);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hóa chất thống kê";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Hóa chất";
            // 
            // txtTenVatTu_XN
            // 
            this.txtTenVatTu_XN.Location = new System.Drawing.Point(171, 22);
            this.txtTenVatTu_XN.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtTenVatTu_XN.Name = "txtTenVatTu_XN";
            this.txtTenVatTu_XN.ReadOnly = true;
            this.txtTenVatTu_XN.Size = new System.Drawing.Size(370, 21);
            this.txtTenVatTu_XN.TabIndex = 1;
            // 
            // cboVatTu_XN
            // 
            this.cboVatTu_XN.AutoComplete = false;
            this.cboVatTu_XN.AutoDropdown = false;
            this.cboVatTu_XN.BackColorEven = System.Drawing.Color.White;
            this.cboVatTu_XN.BackColorOdd = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.cboVatTu_XN.ColumnNames = "";
            this.cboVatTu_XN.ColumnWidthDefault = 75;
            this.cboVatTu_XN.ColumnWidths = "";
            this.cboVatTu_XN.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboVatTu_XN.FormattingEnabled = true;
            this.cboVatTu_XN.LinkedColumnIndex = 0;
            this.cboVatTu_XN.LinkedColumnIndex1 = 0;
            this.cboVatTu_XN.LinkedColumnIndex2 = 0;
            this.cboVatTu_XN.LinkedTextBox = null;
            this.cboVatTu_XN.LinkedTextBox1 = null;
            this.cboVatTu_XN.LinkedTextBox2 = null;
            this.cboVatTu_XN.Location = new System.Drawing.Point(62, 22);
            this.cboVatTu_XN.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.cboVatTu_XN.Name = "cboVatTu_XN";
            this.cboVatTu_XN.Size = new System.Drawing.Size(104, 22);
            this.cboVatTu_XN.TabIndex = 0;
            // 
            // FrmLuongTieuThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(986, 455);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "FrmLuongTieuThu";
            this.Text = "Thống kê lượng sử dụng vật tư";
            this.Load += new System.EventHandler(this.FrmLuongTieuThu_Load);
            this.pnContaint.ResumeLayout(false);
            this.pnLabel.ResumeLayout(false);
            this.pnMenu.ResumeLayout(false);
            this.xtraScrollableControlMain.ResumeLayout(false);
            this.xtraScrollableControlMain.PerformLayout();
            this.pnFormControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHCXN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvHCXN)).EndInit();
            this.bvHCXN.ResumeLayout(false);
            this.bvHCXN.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private DevExpress.XtraEditors.LabelControl label5;
        private DevExpress.XtraEditors.LabelControl label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private CustomDatagridView dtgHCXN;
        private CustomBindingNavigator bvHCXN;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnHC_XN;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton btnXuatHCXN;
        private System.Windows.Forms.GroupBox groupBox2;
        private CustomComboBox cboVatTu_XN;
        private System.Windows.Forms.TextBox txtTenVatTu_XN;
        private DevExpress.XtraEditors.LabelControl label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT3;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaVatTu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenVatTu;
        private System.Windows.Forms.DataGridViewTextBoxColumn thSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn hcTieuThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn hcDVTieuHao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn iscate3;
    }
}