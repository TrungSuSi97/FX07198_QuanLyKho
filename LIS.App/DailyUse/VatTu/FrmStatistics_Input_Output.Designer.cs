using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.ThucThi.VatTu
{
    partial class FrmStatistics_Input_Output
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStatistics_Input_Output));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnXemDanhSach = new TPH.Controls.TPHNormalButton();
            this.txtVatTu = new System.Windows.Forms.TextBox();
            this.txtNhomVatTu = new System.Windows.Forms.TextBox();
            this.cboNhomVatTu = new CustomComboBox();
            this.txtLoaiVatTu = new System.Windows.Forms.TextBox();
            this.cboLoaiVatTu = new CustomComboBox();
            this.txtNhaCungCap = new System.Windows.Forms.TextBox();
            this.txtNguoiLap = new System.Windows.Forms.TextBox();
            this.label8 = new DevExpress.XtraEditors.LabelControl();
            this.cboVatTu = new CustomComboBox();
            this.label7 = new DevExpress.XtraEditors.LabelControl();
            this.label6 = new DevExpress.XtraEditors.LabelControl();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.cboNguoiLap = new CustomComboBox();
            this.cboNhaCungCap = new CustomComboBox();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtgDetail = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.MaVatTu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenVatTu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TonDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Xuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TonCuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhaCungCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bvDetail = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvDetail)).BeginInit();
            this.bvDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "THỐNG KÊ NHẬP XUẤT TỒN KHO THUỐC";
            // 
            // pnContaint
            // 
            this.pnContaint.Controls.Add(this.splitContainer1);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.GhostWhite;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 6);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Horizontal = true;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(959, 529);
            this.splitContainer1.SplitterPosition = 112;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnXemDanhSach);
            this.groupBox1.Controls.Add(this.txtVatTu);
            this.groupBox1.Controls.Add(this.txtNhomVatTu);
            this.groupBox1.Controls.Add(this.cboNhomVatTu);
            this.groupBox1.Controls.Add(this.txtLoaiVatTu);
            this.groupBox1.Controls.Add(this.cboLoaiVatTu);
            this.groupBox1.Controls.Add(this.txtNhaCungCap);
            this.groupBox1.Controls.Add(this.txtNguoiLap);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboVatTu);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboNguoiLap);
            this.groupBox1.Controls.Add(this.cboNhaCungCap);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(959, 112);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tìm kiếm";
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
            this.btnXemDanhSach.Location = new System.Drawing.Point(6, 81);
            this.btnXemDanhSach.Name = "btnXemDanhSach";
            this.btnXemDanhSach.Size = new System.Drawing.Size(92, 27);
            this.btnXemDanhSach.TabIndex = 40;
            this.btnXemDanhSach.Text = "Thống kê";
            this.btnXemDanhSach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXemDanhSach.UseHightLight = true;
            this.btnXemDanhSach.UseVisualStyleBackColor = false;
            this.btnXemDanhSach.Click += new System.EventHandler(this.btnXemDanhSach_Click);
            // 
            // txtVatTu
            // 
            this.txtVatTu.Location = new System.Drawing.Point(364, 80);
            this.txtVatTu.Name = "txtVatTu";
            this.txtVatTu.ReadOnly = true;
            this.txtVatTu.Size = new System.Drawing.Size(589, 27);
            this.txtVatTu.TabIndex = 39;
            // 
            // txtNhomVatTu
            // 
            this.txtNhomVatTu.Location = new System.Drawing.Point(749, 50);
            this.txtNhomVatTu.Name = "txtNhomVatTu";
            this.txtNhomVatTu.ReadOnly = true;
            this.txtNhomVatTu.Size = new System.Drawing.Size(204, 27);
            this.txtNhomVatTu.TabIndex = 38;
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
            this.cboNhomVatTu.Enabled = false;
            this.cboNhomVatTu.FormattingEnabled = true;
            this.cboNhomVatTu.LinkedColumnIndex1 = 0;
            this.cboNhomVatTu.LinkedColumnIndex2 = 0;
            this.cboNhomVatTu.LinkedTextBox1 = null;
            this.cboNhomVatTu.LinkedTextBox2 = null;
            this.cboNhomVatTu.Location = new System.Drawing.Point(660, 48);
            this.cboNhomVatTu.Name = "cboNhomVatTu";
            this.cboNhomVatTu.Size = new System.Drawing.Size(85, 28);
            this.cboNhomVatTu.TabIndex = 37;
            // 
            // txtLoaiVatTu
            // 
            this.txtLoaiVatTu.Location = new System.Drawing.Point(749, 19);
            this.txtLoaiVatTu.Name = "txtLoaiVatTu";
            this.txtLoaiVatTu.ReadOnly = true;
            this.txtLoaiVatTu.Size = new System.Drawing.Size(204, 27);
            this.txtLoaiVatTu.TabIndex = 36;
            // 
            // cboLoaiVatTu
            // 
            this.cboLoaiVatTu.AutoComplete = false;
            this.cboLoaiVatTu.AutoDropdown = false;
            this.cboLoaiVatTu.BackColorEven = System.Drawing.Color.White;
            this.cboLoaiVatTu.BackColorOdd = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.cboLoaiVatTu.ColumnNames = "";
            this.cboLoaiVatTu.ColumnWidthDefault = 75;
            this.cboLoaiVatTu.ColumnWidths = "";
            this.cboLoaiVatTu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboLoaiVatTu.FormattingEnabled = true;
            this.cboLoaiVatTu.LinkedColumnIndex1 = 0;
            this.cboLoaiVatTu.LinkedColumnIndex2 = 0;
            this.cboLoaiVatTu.LinkedTextBox1 = null;
            this.cboLoaiVatTu.LinkedTextBox2 = null;
            this.cboLoaiVatTu.Location = new System.Drawing.Point(660, 18);
            this.cboLoaiVatTu.Name = "cboLoaiVatTu";
            this.cboLoaiVatTu.Size = new System.Drawing.Size(85, 28);
            this.cboLoaiVatTu.TabIndex = 35;
            this.cboLoaiVatTu.SelectionChangeCommitted += new System.EventHandler(this.cboLoaiVatTu_SelectionChangeCommitted);
            this.cboLoaiVatTu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboLoaiVatTu_KeyPress);
            // 
            // txtNhaCungCap
            // 
            this.txtNhaCungCap.Location = new System.Drawing.Point(364, 50);
            this.txtNhaCungCap.Name = "txtNhaCungCap";
            this.txtNhaCungCap.ReadOnly = true;
            this.txtNhaCungCap.Size = new System.Drawing.Size(207, 27);
            this.txtNhaCungCap.TabIndex = 32;
            // 
            // txtNguoiLap
            // 
            this.txtNguoiLap.Location = new System.Drawing.Point(364, 20);
            this.txtNguoiLap.Name = "txtNguoiLap";
            this.txtNguoiLap.ReadOnly = true;
            this.txtNguoiLap.Size = new System.Drawing.Size(207, 27);
            this.txtNguoiLap.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(185, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 20);
            this.label8.TabIndex = 30;
            this.label8.Text = "Vật tư:";
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
            this.cboVatTu.Enabled = false;
            this.cboVatTu.FormattingEnabled = true;
            this.cboVatTu.LinkedColumnIndex1 = 0;
            this.cboVatTu.LinkedColumnIndex2 = 0;
            this.cboVatTu.LinkedTextBox1 = null;
            this.cboVatTu.LinkedTextBox2 = null;
            this.cboVatTu.Location = new System.Drawing.Point(276, 79);
            this.cboVatTu.Name = "cboVatTu";
            this.cboVatTu.Size = new System.Drawing.Size(85, 28);
            this.cboVatTu.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(575, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "Nhóm vật tư:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(575, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "Loại vật tư:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Nhà cung cấp:";
            // 
            // cboNguoiLap
            // 
            this.cboNguoiLap.AutoComplete = false;
            this.cboNguoiLap.AutoDropdown = false;
            this.cboNguoiLap.BackColorEven = System.Drawing.Color.White;
            this.cboNguoiLap.BackColorOdd = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.cboNguoiLap.ColumnNames = "";
            this.cboNguoiLap.ColumnWidthDefault = 75;
            this.cboNguoiLap.ColumnWidths = "";
            this.cboNguoiLap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboNguoiLap.FormattingEnabled = true;
            this.cboNguoiLap.LinkedColumnIndex1 = 0;
            this.cboNguoiLap.LinkedColumnIndex2 = 0;
            this.cboNguoiLap.LinkedTextBox1 = null;
            this.cboNguoiLap.LinkedTextBox2 = null;
            this.cboNguoiLap.Location = new System.Drawing.Point(276, 19);
            this.cboNguoiLap.Name = "cboNguoiLap";
            this.cboNguoiLap.Size = new System.Drawing.Size(85, 28);
            this.cboNguoiLap.TabIndex = 23;
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
            this.cboNhaCungCap.Location = new System.Drawing.Point(276, 49);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(85, 28);
            this.cboNhaCungCap.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Người lập:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Đến ngày:";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(74, 50);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(106, 27);
            this.dtpToDate.TabIndex = 2;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Từ ngày:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(74, 21);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(106, 27);
            this.dtpFromDate.TabIndex = 0;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtgDetail);
            this.groupBox3.Controls.Add(this.bvDetail);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(959, 413);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kết quả thống kê";
            // 
            // dtgDetail
            // 
            this.dtgDetail.AlignColumns = "";
            this.dtgDetail.AllignNumberText = false;
            this.dtgDetail.AllowUserToAddRows = false;
            this.dtgDetail.AllowUserToDeleteRows = false;
            this.dtgDetail.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgDetail.CheckBoldColumn = false;
            this.dtgDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaVatTu,
            this.TenVatTu,
            this.TonDau,
            this.Nhap,
            this.Xuat,
            this.TonCuoi,
            this.DonViTinh,
            this.TenNhaCungCap});
            this.dtgDetail.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(228)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDetail.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtgDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDetail.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgDetail.Location = new System.Drawing.Point(3, 23);
            this.dtgDetail.MarkOddEven = true;
            this.dtgDetail.MultiSelect = false;
            this.dtgDetail.Name = "dtgDetail";
            this.dtgDetail.NumberAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgDetail.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgDetail.RowTemplate.Height = 28;
            this.dtgDetail.Size = new System.Drawing.Size(953, 362);
            this.dtgDetail.TabIndex = 3;
            this.dtgDetail.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            // 
            // MaVatTu
            // 
            this.MaVatTu.DataPropertyName = "MaVatTu";
            this.MaVatTu.HeaderText = "Mã vật tư";
            this.MaVatTu.Name = "MaVatTu";
            this.MaVatTu.ReadOnly = true;
            this.MaVatTu.Width = 90;
            // 
            // TenVatTu
            // 
            this.TenVatTu.DataPropertyName = "TenVatTu";
            this.TenVatTu.HeaderText = "Tên vật tư";
            this.TenVatTu.Name = "TenVatTu";
            this.TenVatTu.ReadOnly = true;
            this.TenVatTu.Width = 200;
            // 
            // TonDau
            // 
            this.TonDau.DataPropertyName = "TonDau";
            this.TonDau.HeaderText = "Tồn đầu";
            this.TonDau.Name = "TonDau";
            this.TonDau.ReadOnly = true;
            // 
            // Nhap
            // 
            this.Nhap.DataPropertyName = "Nhap";
            this.Nhap.HeaderText = "Nhập";
            this.Nhap.Name = "Nhap";
            this.Nhap.ReadOnly = true;
            // 
            // Xuat
            // 
            this.Xuat.DataPropertyName = "Xuat";
            this.Xuat.HeaderText = "Xuất";
            this.Xuat.Name = "Xuat";
            this.Xuat.ReadOnly = true;
            // 
            // TonCuoi
            // 
            this.TonCuoi.DataPropertyName = "TonCuoi";
            this.TonCuoi.HeaderText = "Tồn cuối";
            this.TonCuoi.Name = "TonCuoi";
            this.TonCuoi.ReadOnly = true;
            this.TonCuoi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TonCuoi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DonViTinh
            // 
            this.DonViTinh.DataPropertyName = "DonViTinh";
            this.DonViTinh.HeaderText = "Đơn vị tính";
            this.DonViTinh.Name = "DonViTinh";
            this.DonViTinh.ReadOnly = true;
            this.DonViTinh.Width = 120;
            // 
            // TenNhaCungCap
            // 
            this.TenNhaCungCap.DataPropertyName = "TenNhaCungCap";
            this.TenNhaCungCap.HeaderText = "Nhà cung cấp";
            this.TenNhaCungCap.Name = "TenNhaCungCap";
            this.TenNhaCungCap.ReadOnly = true;
            this.TenNhaCungCap.Width = 150;
            // 
            // bvDetail
            // 
            this.bvDetail.AddNewItem = null;
            this.bvDetail.CountItem = this.toolStripLabel1;
            this.bvDetail.CountItemFormat = "/ {0}";
            this.bvDetail.DeleteItem = null;
            this.bvDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvDetail.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripTextBox1,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator3,
            this.btnExport});
            this.bvDetail.Location = new System.Drawing.Point(3, 385);
            this.bvDetail.MoveFirstItem = this.toolStripButton1;
            this.bvDetail.MoveLastItem = this.toolStripButton4;
            this.bvDetail.MoveNextItem = this.toolStripButton3;
            this.bvDetail.MovePreviousItem = this.toolStripButton2;
            this.bvDetail.Name = "bvDetail";
            this.bvDetail.PositionItem = this.toolStripTextBox1;
            this.bvDetail.Size = new System.Drawing.Size(953, 25);
            this.bvDetail.TabIndex = 2;
            this.bvDetail.Text = "TPH.LIS.Common.Controls.CustomBindingNavigator2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(27, 22);
            this.toolStripLabel1.Text = "/ {0}";
            this.toolStripLabel1.ToolTipText = "Total number of items";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeftAutoMirrorImage = true;
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Move first";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.RightToLeftAutoMirrorImage = true;
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Move previous";
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
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(50, 23);
            this.toolStripTextBox1.Text = "0";
            this.toolStripTextBox1.ToolTipText = "Current position";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.RightToLeftAutoMirrorImage = true;
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Move next";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.RightToLeftAutoMirrorImage = true;
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Move last";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(79, 22);
            this.btnExport.Text = "Xuất excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FrmStatistics_Input_Output
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1008, 661);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmStatistics_Input_Output";
            this.Text = "Thống kê kho thuốc";
            this.Load += new System.EventHandler(this.FrmInput_List_Load);
            this.pnContaint.ResumeLayout(false);
            this.pnLabel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvDetail)).EndInit();
            this.bvDetail.ResumeLayout(false);
            this.bvDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LabelControl label4;
        private DevExpress.XtraEditors.LabelControl label2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private DevExpress.XtraEditors.LabelControl label1;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private CustomComboBox cboNhaCungCap;
        private DevExpress.XtraEditors.LabelControl label8;
        private CustomComboBox cboVatTu;
        private DevExpress.XtraEditors.LabelControl label7;
        private DevExpress.XtraEditors.LabelControl label6;
        private DevExpress.XtraEditors.LabelControl label5;
        private CustomComboBox cboNguoiLap;
        private System.Windows.Forms.TextBox txtNhaCungCap;
        private System.Windows.Forms.TextBox txtNguoiLap;
        private System.Windows.Forms.TextBox txtNhomVatTu;
        private CustomComboBox cboNhomVatTu;
        private System.Windows.Forms.TextBox txtLoaiVatTu;
        private CustomComboBox cboLoaiVatTu;
        private System.Windows.Forms.TextBox txtVatTu;
        private TPH.Controls.TPHNormalButton btnXemDanhSach;
        private System.Windows.Forms.GroupBox groupBox3;
        private CustomBindingNavigator bvDetail;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private CustomDatagridView dtgDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaVatTu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenVatTu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TonDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Xuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn TonCuoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhaCungCap;
        private System.Windows.Forms.ToolStripButton btnExport;
    }
}