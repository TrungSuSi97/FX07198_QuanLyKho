namespace TPH.LIS.App.CauHinh.VatTu
{
    partial class frmDM_VatTu_NhomLoai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDM_VatTu_NhomLoai));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.dtgLoaiVatTu = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.MaLoaiVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoaiVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bvLoaiVT = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnXoaLoaiVT = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThemMoiLoaiVatTu = new TPH.Controls.TPHNormalButton();
            this.txtTenLoai = new System.Windows.Forms.TextBox();
            this.txtMaLoai = new System.Windows.Forms.TextBox();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.dtgNhomVT = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.MaNhomVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhomVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.N_MaLoaiVatTu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bvNhomVT = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnXoaNhomVT = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtN_MaLoaiVatTu = new System.Windows.Forms.TextBox();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.btnThemMoiNhomVatTu = new TPH.Controls.TPHNormalButton();
            this.txtTenNhom = new System.Windows.Forms.TextBox();
            this.txtMaNhom = new System.Windows.Forms.TextBox();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLoaiVatTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvLoaiVT)).BeginInit();
            this.bvLoaiVT.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNhomVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvNhomVT)).BeginInit();
            this.bvNhomVT.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(1000, 33);
            this.lblTitle.Text = "DANH MỤC LOẠI - NHÓM VẬT TƯ";
            // 
            // pnContaint
            // 
            this.pnContaint.Controls.Add(this.splitContainer1);
            this.pnContaint.Size = new System.Drawing.Size(1008, 541);
            // 
            // pnLabel
            // 
            this.pnLabel.Size = new System.Drawing.Size(1008, 48);
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
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dtgLoaiVatTu);
            this.splitContainer1.Panel1.Controls.Add(this.bvLoaiVT);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dtgNhomVT);
            this.splitContainer1.Panel2.Controls.Add(this.bvNhomVT);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1000, 529);
            this.splitContainer1.SplitterPosition = 500;
            this.splitContainer1.TabIndex = 0;
            // 
            // dtgLoaiVatTu
            // 
            this.dtgLoaiVatTu.AlignColumns = "";
            this.dtgLoaiVatTu.AllignNumberText = false;
            this.dtgLoaiVatTu.AllowUserToAddRows = false;
            this.dtgLoaiVatTu.AllowUserToDeleteRows = false;
            this.dtgLoaiVatTu.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgLoaiVatTu.CheckBoldColumn = false;
            this.dtgLoaiVatTu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLoaiVatTu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLoaiVT,
            this.TenLoaiVT});
            this.dtgLoaiVatTu.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(228)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgLoaiVatTu.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtgLoaiVatTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgLoaiVatTu.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgLoaiVatTu.Location = new System.Drawing.Point(0, 104);
            this.dtgLoaiVatTu.MarkOddEven = true;
            this.dtgLoaiVatTu.MultiSelect = false;
            this.dtgLoaiVatTu.Name = "dtgLoaiVatTu";
            this.dtgLoaiVatTu.NumberAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgLoaiVatTu.RowTemplate.Height = 28;
            this.dtgLoaiVatTu.Size = new System.Drawing.Size(500, 400);
            this.dtgLoaiVatTu.TabIndex = 2;
            this.dtgLoaiVatTu.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dtgLoaiVatTu.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgLoaiVatTu_CellEnter);
            // 
            // MaLoaiVT
            // 
            this.MaLoaiVT.DataPropertyName = "MaLoaiVT";
            this.MaLoaiVT.HeaderText = "Mã loại vật tư";
            this.MaLoaiVT.Name = "MaLoaiVT";
            this.MaLoaiVT.Width = 130;
            // 
            // TenLoaiVT
            // 
            this.TenLoaiVT.DataPropertyName = "TenLoaiVT";
            this.TenLoaiVT.HeaderText = "Tên loại vật tư";
            this.TenLoaiVT.Name = "TenLoaiVT";
            this.TenLoaiVT.Width = 300;
            // 
            // bvLoaiVT
            // 
            this.bvLoaiVT.AddNewItem = null;
            this.bvLoaiVT.CountItem = this.bindingNavigatorCountItem;
            this.bvLoaiVT.CountItemFormat = "/ {0}";
            this.bvLoaiVT.DeleteItem = null;
            this.bvLoaiVT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvLoaiVT.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvLoaiVT.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.btnXoaLoaiVT});
            this.bvLoaiVT.Location = new System.Drawing.Point(0, 504);
            this.bvLoaiVT.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bvLoaiVT.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bvLoaiVT.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bvLoaiVT.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bvLoaiVT.Name = "bvLoaiVT";
            this.bvLoaiVT.PositionItem = this.bindingNavigatorPositionItem;
            this.bvLoaiVT.Size = new System.Drawing.Size(500, 25);
            this.bvLoaiVT.TabIndex = 1;
            this.bvLoaiVT.Text = "bindingNavigator1";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(44, 23);
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
            // btnXoaLoaiVT
            // 
            this.btnXoaLoaiVT.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaLoaiVT.Image")));
            this.btnXoaLoaiVT.Name = "btnXoaLoaiVT";
            this.btnXoaLoaiVT.RightToLeftAutoMirrorImage = true;
            this.btnXoaLoaiVT.Size = new System.Drawing.Size(84, 22);
            this.btnXoaLoaiVT.Text = "Xóa loại VT";
            this.btnXoaLoaiVT.Click += new System.EventHandler(this.btnXoaLoaiVT_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThemMoiLoaiVatTu);
            this.groupBox1.Controls.Add(this.txtTenLoai);
            this.groupBox1.Controls.Add(this.txtMaLoai);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(500, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh mục loại vật tư";
            // 
            // btnThemMoiLoaiVatTu
            // 
            this.btnThemMoiLoaiVatTu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemMoiLoaiVatTu.BackColor = System.Drawing.Color.Transparent;
            this.btnThemMoiLoaiVatTu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemMoiLoaiVatTu.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnThemMoiLoaiVatTu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMoiLoaiVatTu.ForeColor = System.Drawing.Color.Black;
            this.btnThemMoiLoaiVatTu.Image = ((System.Drawing.Image)(resources.GetObject("btnThemMoiLoaiVatTu.Image")));
            this.btnThemMoiLoaiVatTu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemMoiLoaiVatTu.Location = new System.Drawing.Point(402, 63);
            this.btnThemMoiLoaiVatTu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThemMoiLoaiVatTu.Name = "btnThemMoiLoaiVatTu";
            this.btnThemMoiLoaiVatTu.Size = new System.Drawing.Size(92, 33);
            this.btnThemMoiLoaiVatTu.TabIndex = 6;
            this.btnThemMoiLoaiVatTu.Text = "Thêm mới";
            this.btnThemMoiLoaiVatTu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemMoiLoaiVatTu.UseHightLight = true;
            this.btnThemMoiLoaiVatTu.UseVisualStyleBackColor = true;
            this.btnThemMoiLoaiVatTu.Click += new System.EventHandler(this.btnThemMoiLoaiVatTu_Click);
            // 
            // txtTenLoai
            // 
            this.txtTenLoai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenLoai.Location = new System.Drawing.Point(250, 31);
            this.txtTenLoai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenLoai.Name = "txtTenLoai";
            this.txtTenLoai.Size = new System.Drawing.Size(244, 27);
            this.txtTenLoai.TabIndex = 3;
            // 
            // txtMaLoai
            // 
            this.txtMaLoai.Location = new System.Drawing.Point(61, 31);
            this.txtMaLoai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaLoai.Name = "txtMaLoai";
            this.txtMaLoai.Size = new System.Drawing.Size(127, 27);
            this.txtMaLoai.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên loại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã loại";
            // 
            // dtgNhomVT
            // 
            this.dtgNhomVT.AlignColumns = "";
            this.dtgNhomVT.AllignNumberText = false;
            this.dtgNhomVT.AllowUserToAddRows = false;
            this.dtgNhomVT.AllowUserToDeleteRows = false;
            this.dtgNhomVT.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgNhomVT.CheckBoldColumn = false;
            this.dtgNhomVT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgNhomVT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNhomVT,
            this.TenNhomVT,
            this.N_MaLoaiVatTu});
            this.dtgNhomVT.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(132)))), ((int)(((byte)(176)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgNhomVT.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgNhomVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgNhomVT.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgNhomVT.Location = new System.Drawing.Point(0, 104);
            this.dtgNhomVT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgNhomVT.MarkOddEven = true;
            this.dtgNhomVT.MultiSelect = false;
            this.dtgNhomVT.Name = "dtgNhomVT";
            this.dtgNhomVT.NumberAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgNhomVT.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgNhomVT.RowHeadersWidth = 40;
            this.dtgNhomVT.Size = new System.Drawing.Size(496, 400);
            this.dtgNhomVT.TabIndex = 4;
            this.dtgNhomVT.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dtgNhomVT.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgNhomVT_DataBindingComplete);
            // 
            // MaNhomVT
            // 
            this.MaNhomVT.DataPropertyName = "MaNhomVT";
            this.MaNhomVT.HeaderText = "Mã nhóm VT";
            this.MaNhomVT.Name = "MaNhomVT";
            this.MaNhomVT.Width = 120;
            // 
            // TenNhomVT
            // 
            this.TenNhomVT.DataPropertyName = "TenNhomVT";
            this.TenNhomVT.HeaderText = "Tên nhóm vật tư";
            this.TenNhomVT.Name = "TenNhomVT";
            this.TenNhomVT.Width = 150;
            // 
            // N_MaLoaiVatTu
            // 
            this.N_MaLoaiVatTu.DataPropertyName = "MaLoaiVT";
            this.N_MaLoaiVatTu.HeaderText = "Mã loại VT";
            this.N_MaLoaiVatTu.Name = "N_MaLoaiVatTu";
            this.N_MaLoaiVatTu.Width = 110;
            // 
            // bvNhomVT
            // 
            this.bvNhomVT.AddNewItem = null;
            this.bvNhomVT.CountItem = this.toolStripLabel1;
            this.bvNhomVT.CountItemFormat = "/ {0}";
            this.bvNhomVT.DeleteItem = null;
            this.bvNhomVT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvNhomVT.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvNhomVT.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator1,
            this.toolStripTextBox1,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripSeparator3,
            this.btnXoaNhomVT});
            this.bvNhomVT.Location = new System.Drawing.Point(0, 504);
            this.bvNhomVT.MoveFirstItem = this.toolStripButton3;
            this.bvNhomVT.MoveLastItem = this.toolStripButton6;
            this.bvNhomVT.MoveNextItem = this.toolStripButton5;
            this.bvNhomVT.MovePreviousItem = this.toolStripButton4;
            this.bvNhomVT.Name = "bvNhomVT";
            this.bvNhomVT.PositionItem = this.toolStripTextBox1;
            this.bvNhomVT.Size = new System.Drawing.Size(496, 25);
            this.bvNhomVT.TabIndex = 3;
            this.bvNhomVT.Text = "bindingNavigator2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(27, 22);
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
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(44, 23);
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
            // btnXoaNhomVT
            // 
            this.btnXoaNhomVT.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaNhomVT.Image")));
            this.btnXoaNhomVT.Name = "btnXoaNhomVT";
            this.btnXoaNhomVT.RightToLeftAutoMirrorImage = true;
            this.btnXoaNhomVT.Size = new System.Drawing.Size(93, 22);
            this.btnXoaNhomVT.Text = "Xóa nhóm VT";
            this.btnXoaNhomVT.Click += new System.EventHandler(this.btnXoaNhomVT_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtN_MaLoaiVatTu);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnThemMoiNhomVatTu);
            this.groupBox2.Controls.Add(this.txtTenNhom);
            this.groupBox2.Controls.Add(this.txtMaNhom);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(496, 104);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh mục nhóm vật tư";
            // 
            // txtN_MaLoaiVatTu
            // 
            this.txtN_MaLoaiVatTu.BackColor = System.Drawing.Color.PaleGreen;
            this.txtN_MaLoaiVatTu.Location = new System.Drawing.Point(87, 66);
            this.txtN_MaLoaiVatTu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtN_MaLoaiVatTu.Name = "txtN_MaLoaiVatTu";
            this.txtN_MaLoaiVatTu.Size = new System.Drawing.Size(78, 27);
            this.txtN_MaLoaiVatTu.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Loại vật tư";
            // 
            // btnThemMoiNhomVatTu
            // 
            this.btnThemMoiNhomVatTu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemMoiNhomVatTu.BackColor = System.Drawing.Color.Transparent;
            this.btnThemMoiNhomVatTu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemMoiNhomVatTu.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnThemMoiNhomVatTu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMoiNhomVatTu.ForeColor = System.Drawing.Color.Black;
            this.btnThemMoiNhomVatTu.Image = ((System.Drawing.Image)(resources.GetObject("btnThemMoiNhomVatTu.Image")));
            this.btnThemMoiNhomVatTu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemMoiNhomVatTu.Location = new System.Drawing.Point(398, 63);
            this.btnThemMoiNhomVatTu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThemMoiNhomVatTu.Name = "btnThemMoiNhomVatTu";
            this.btnThemMoiNhomVatTu.Size = new System.Drawing.Size(92, 33);
            this.btnThemMoiNhomVatTu.TabIndex = 6;
            this.btnThemMoiNhomVatTu.Text = "Thêm mới";
            this.btnThemMoiNhomVatTu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemMoiNhomVatTu.UseHightLight = true;
            this.btnThemMoiNhomVatTu.UseVisualStyleBackColor = true;
            this.btnThemMoiNhomVatTu.Click += new System.EventHandler(this.btnThemMoiNhomVatTu_Click);
            // 
            // txtTenNhom
            // 
            this.txtTenNhom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenNhom.Location = new System.Drawing.Point(240, 31);
            this.txtTenNhom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenNhom.Name = "txtTenNhom";
            this.txtTenNhom.Size = new System.Drawing.Size(250, 27);
            this.txtTenNhom.TabIndex = 3;
            // 
            // txtMaNhom
            // 
            this.txtMaNhom.Location = new System.Drawing.Point(87, 31);
            this.txtMaNhom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaNhom.Name = "txtMaNhom";
            this.txtMaNhom.Size = new System.Drawing.Size(78, 27);
            this.txtMaNhom.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên nhóm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mã nhóm";
            // 
            // frmDM_VatTu_NhomLoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1150, 700);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "frmDM_VatTu_NhomLoai";
            this.Text = "Nhóm vật tư";
            this.Load += new System.EventHandler(this.frmDM_VatTu_NhomLoai_Load);
            this.pnContaint.ResumeLayout(false);
            this.pnLabel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLoaiVatTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvLoaiVT)).EndInit();
            this.bvLoaiVT.ResumeLayout(false);
            this.bvLoaiVT.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNhomVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvNhomVT)).EndInit();
            this.bvNhomVT.ResumeLayout(false);
            this.bvNhomVT.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTenLoai;
        private System.Windows.Forms.TextBox txtMaLoai;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.LabelControl label1;
        private TPH.Controls.TPHNormalButton btnThemMoiLoaiVatTu;
        private System.Windows.Forms.GroupBox groupBox2;
        private TPH.Controls.TPHNormalButton btnThemMoiNhomVatTu;
        private System.Windows.Forms.TextBox txtTenNhom;
        private System.Windows.Forms.TextBox txtMaNhom;
        private DevExpress.XtraEditors.LabelControl label3;
        private DevExpress.XtraEditors.LabelControl label4;
        private TPH.LIS.Common.Controls.CustomBindingNavigator bvLoaiVT;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton btnXoaLoaiVT;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private TPH.LIS.Common.Controls.CustomBindingNavigator bvNhomVT;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnXoaNhomVT;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private TPH.LIS.Common.Controls.CustomDatagridView dtgNhomVT;
        private System.Windows.Forms.TextBox txtN_MaLoaiVatTu;
        private DevExpress.XtraEditors.LabelControl label5;
        private TPH.LIS.Common.Controls.CustomDatagridView dtgLoaiVatTu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoaiVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoaiVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhomVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhomVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn N_MaLoaiVatTu;
    }
}