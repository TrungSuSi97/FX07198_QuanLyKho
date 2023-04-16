using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.CauHinh.VatTu
{
    partial class frmDM_VatTu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDM_VatTu));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bvVatTu = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnXoaVatTu = new System.Windows.Forms.ToolStripButton();
            this.dtgVatTu = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.MaVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNhomVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLoaiVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoHSD = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.XuatQCDG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gQuiCachDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DVTQuiCach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLDongGoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DVTDongGoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLDGTieuHao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DVTTieuHao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLanDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuHaoTrenLan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new TPH.Controls.TPHNormalButton();
            this.btnSave = new TPH.Controls.TPHNormalButton();
            this.btnEdit = new TPH.Controls.TPHNormalButton();
            this.btnAddNew = new TPH.Controls.TPHNormalButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new DevExpress.XtraEditors.LabelControl();
            this.txtSLDung = new System.Windows.Forms.TextBox();
            this.label11 = new DevExpress.XtraEditors.LabelControl();
            this.cboDonViTinhTH = new CustomComboBox();
            this.label9 = new DevExpress.XtraEditors.LabelControl();
            this.label12 = new DevExpress.XtraEditors.LabelControl();
            this.txtLuongTH = new System.Windows.Forms.TextBox();
            this.txtSLDGTieuHao = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new DevExpress.XtraEditors.LabelControl();
            this.cboDonViTinhDG = new CustomComboBox();
            this.label7 = new DevExpress.XtraEditors.LabelControl();
            this.txtSlDongGoi = new System.Windows.Forms.TextBox();
            this.chkXuatQCDG = new System.Windows.Forms.CheckBox();
            this.label6 = new DevExpress.XtraEditors.LabelControl();
            this.cboDonViTinh = new CustomComboBox();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.txtQuiCachDG = new System.Windows.Forms.TextBox();
            this.chkCoHSD = new System.Windows.Forms.CheckBox();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.cboLoaiVT = new CustomComboBox();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.cboNhomVT = new CustomComboBox();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenVatTu = new System.Windows.Forms.TextBox();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaVT = new System.Windows.Forms.TextBox();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bvVatTu)).BeginInit();
            this.bvVatTu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVatTu)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(1000, 33);
            this.lblTitle.Text = "DANH MỤC VẬT TƯ";
            // 
            // pnContaint
            // 
            this.pnContaint.Controls.Add(this.dtgVatTu);
            this.pnContaint.Controls.Add(this.bvVatTu);
            this.pnContaint.Controls.Add(this.panel1);
            this.pnContaint.Size = new System.Drawing.Size(1008, 541);
            // 
            // pnLabel
            // 
            this.pnLabel.Size = new System.Drawing.Size(1008, 48);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Crimson;
            // 
            // bvVatTu
            // 
            this.bvVatTu.AddNewItem = null;
            this.bvVatTu.CountItem = this.bindingNavigatorCountItem;
            this.bvVatTu.CountItemFormat = "/ {0}";
            this.bvVatTu.DeleteItem = null;
            this.bvVatTu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvVatTu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvVatTu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.btnXoaVatTu});
            this.bvVatTu.Location = new System.Drawing.Point(298, 510);
            this.bvVatTu.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bvVatTu.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bvVatTu.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bvVatTu.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bvVatTu.Name = "bvVatTu";
            this.bvVatTu.PositionItem = this.bindingNavigatorPositionItem;
            this.bvVatTu.Size = new System.Drawing.Size(706, 25);
            this.bvVatTu.TabIndex = 0;
            this.bvVatTu.Text = "bindingNavigator1";
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
            // btnXoaVatTu
            // 
            this.btnXoaVatTu.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaVatTu.Image")));
            this.btnXoaVatTu.Name = "btnXoaVatTu";
            this.btnXoaVatTu.RightToLeftAutoMirrorImage = true;
            this.btnXoaVatTu.Size = new System.Drawing.Size(78, 22);
            this.btnXoaVatTu.Text = "Xóa vật tư";
            // 
            // dtgVatTu
            // 
            this.dtgVatTu.AlignColumns = "";
            this.dtgVatTu.AllignNumberText = false;
            this.dtgVatTu.AllowUserToAddRows = false;
            this.dtgVatTu.AllowUserToDeleteRows = false;
            this.dtgVatTu.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgVatTu.CheckBoldColumn = false;
            this.dtgVatTu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVatTu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaVT,
            this.TenVT,
            this.MaNhomVT,
            this.MaLoaiVT,
            this.CoHSD,
            this.XuatQCDG,
            this.gQuiCachDG,
            this.DVTQuiCach,
            this.SLDongGoi,
            this.DVTDongGoi,
            this.SLDGTieuHao,
            this.DVTTieuHao,
            this.SoLanDung,
            this.TieuHaoTrenLan});
            this.dtgVatTu.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(132)))), ((int)(((byte)(176)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgVatTu.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtgVatTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgVatTu.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgVatTu.Location = new System.Drawing.Point(298, 6);
            this.dtgVatTu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgVatTu.MarkOddEven = true;
            this.dtgVatTu.MultiSelect = false;
            this.dtgVatTu.Name = "dtgVatTu";
            this.dtgVatTu.NumberAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgVatTu.RowHeadersWidth = 40;
            this.dtgVatTu.Size = new System.Drawing.Size(706, 504);
            this.dtgVatTu.TabIndex = 1;
            this.dtgVatTu.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            // 
            // MaVT
            // 
            this.MaVT.DataPropertyName = "MaVatTu";
            this.MaVT.HeaderText = "Mã VT";
            this.MaVT.Name = "MaVT";
            // 
            // TenVT
            // 
            this.TenVT.DataPropertyName = "TenVatTu";
            this.TenVT.HeaderText = "Tên vật tư";
            this.TenVT.Name = "TenVT";
            this.TenVT.Width = 250;
            // 
            // MaNhomVT
            // 
            this.MaNhomVT.DataPropertyName = "MaNhomVT";
            this.MaNhomVT.HeaderText = "Nhóm VT";
            this.MaNhomVT.Name = "MaNhomVT";
            // 
            // MaLoaiVT
            // 
            this.MaLoaiVT.DataPropertyName = "MaLoaiVT";
            this.MaLoaiVT.HeaderText = "Loại VT";
            this.MaLoaiVT.Name = "MaLoaiVT";
            // 
            // CoHSD
            // 
            this.CoHSD.DataPropertyName = "CoHSD";
            this.CoHSD.HeaderText = "Có HSD";
            this.CoHSD.Name = "CoHSD";
            this.CoHSD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CoHSD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // XuatQCDG
            // 
            this.XuatQCDG.DataPropertyName = "XuatTheQCDG";
            this.XuatQCDG.HeaderText = "Xuất QCĐG";
            this.XuatQCDG.Name = "XuatQCDG";
            this.XuatQCDG.Width = 120;
            // 
            // gQuiCachDG
            // 
            this.gQuiCachDG.DataPropertyName = "QuiCachDongGoi";
            this.gQuiCachDG.HeaderText = "Qui cách";
            this.gQuiCachDG.Name = "gQuiCachDG";
            // 
            // DVTQuiCach
            // 
            this.DVTQuiCach.DataPropertyName = "DonViTinh";
            this.DVTQuiCach.HeaderText = "Đơn vị qui cách";
            this.DVTQuiCach.Name = "DVTQuiCach";
            this.DVTQuiCach.Width = 170;
            // 
            // SLDongGoi
            // 
            this.SLDongGoi.DataPropertyName = "SLDongGoi";
            this.SLDongGoi.HeaderText = "Số lượng ĐG";
            this.SLDongGoi.Name = "SLDongGoi";
            this.SLDongGoi.Width = 150;
            // 
            // DVTDongGoi
            // 
            this.DVTDongGoi.DataPropertyName = "DVTDongGoi";
            this.DVTDongGoi.HeaderText = "Đơn vị DG";
            this.DVTDongGoi.Name = "DVTDongGoi";
            // 
            // SLDGTieuHao
            // 
            this.SLDGTieuHao.DataPropertyName = "SLDGTieuHao";
            this.SLDGTieuHao.HeaderText = "SL ĐG tiêu hao";
            this.SLDGTieuHao.Name = "SLDGTieuHao";
            this.SLDGTieuHao.Width = 160;
            // 
            // DVTTieuHao
            // 
            this.DVTTieuHao.DataPropertyName = "DVTTieuHao";
            this.DVTTieuHao.HeaderText = "ĐVT tiêu hao";
            this.DVTTieuHao.Name = "DVTTieuHao";
            this.DVTTieuHao.Width = 150;
            // 
            // SoLanDung
            // 
            this.SoLanDung.DataPropertyName = "SLCoTheDung";
            this.SoLanDung.HeaderText = "Số lần có thể dùng";
            this.SoLanDung.Name = "SoLanDung";
            this.SoLanDung.Width = 190;
            // 
            // TieuHaoTrenLan
            // 
            this.TieuHaoTrenLan.DataPropertyName = "TieuHao";
            this.TieuHaoTrenLan.HeaderText = "Tiêu hao /1 lần";
            this.TieuHaoTrenLan.Name = "TieuHaoTrenLan";
            this.TieuHaoTrenLan.Width = 160;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnAddNew);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.chkXuatQCDG);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboDonViTinh);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtQuiCachDG);
            this.panel1.Controls.Add(this.chkCoHSD);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboLoaiVT);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboNhomVT);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTenVatTu);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtMaVT);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(4, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 529);
            this.panel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(210, 7);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 33);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseHightLight = true;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(218, 489);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(62, 33);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Lưu";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseHightLight = true;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnEdit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.Black;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(116, 7);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(62, 33);
            this.btnEdit.TabIndex = 20;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseHightLight = true;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnAddNew.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.ForeColor = System.Drawing.Color.Black;
            this.btnAddNew.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew.Image")));
            this.btnAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNew.Location = new System.Drawing.Point(21, 7);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(62, 33);
            this.btnAddNew.TabIndex = 19;
            this.btnAddNew.Text = "Thêm";
            this.btnAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNew.UseHightLight = true;
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtSLDung);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cboDonViTinhTH);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtLuongTH);
            this.groupBox2.Controls.Add(this.txtSLDGTieuHao);
            this.groupBox2.Location = new System.Drawing.Point(11, 339);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(272, 141);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Qui cách khi tính tiêu hao";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 20);
            this.label13.TabIndex = 18;
            this.label13.Text = "Số lần có thể dùng";
            // 
            // txtSLDung
            // 
            this.txtSLDung.Location = new System.Drawing.Point(140, 68);
            this.txtSLDung.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSLDung.Name = "txtSLDung";
            this.txtSLDung.Size = new System.Drawing.Size(70, 27);
            this.txtSLDung.TabIndex = 17;
            this.txtSLDung.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSLDung_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(146, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 20);
            this.label11.TabIndex = 14;
            this.label11.Text = "ĐVT";
            // 
            // cboDonViTinhTH
            // 
            this.cboDonViTinhTH.AutoComplete = false;
            this.cboDonViTinhTH.AutoDropdown = false;
            this.cboDonViTinhTH.BackColorEven = System.Drawing.Color.White;
            this.cboDonViTinhTH.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboDonViTinhTH.ColumnNames = "";
            this.cboDonViTinhTH.ColumnWidthDefault = 75;
            this.cboDonViTinhTH.ColumnWidths = "";
            this.cboDonViTinhTH.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboDonViTinhTH.FormattingEnabled = true;
            this.cboDonViTinhTH.LinkedColumnIndex1 = 0;
            this.cboDonViTinhTH.LinkedColumnIndex2 = 0;
            this.cboDonViTinhTH.LinkedTextBox1 = null;
            this.cboDonViTinhTH.LinkedTextBox2 = null;
            this.cboDonViTinhTH.Location = new System.Drawing.Point(187, 33);
            this.cboDonViTinhTH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboDonViTinhTH.Name = "cboDonViTinhTH";
            this.cboDonViTinhTH.Size = new System.Drawing.Size(51, 28);
            this.cboDonViTinhTH.TabIndex = 13;
            this.cboDonViTinhTH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDonViTinhTH_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "Lượng tiêu hao / 1 lần";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 20);
            this.label12.TabIndex = 12;
            this.label12.Text = "Số lượng ĐG";
            // 
            // txtLuongTH
            // 
            this.txtLuongTH.Location = new System.Drawing.Point(140, 104);
            this.txtLuongTH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLuongTH.Name = "txtLuongTH";
            this.txtLuongTH.Size = new System.Drawing.Size(70, 27);
            this.txtLuongTH.TabIndex = 15;
            this.txtLuongTH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLuongTH_KeyPress);
            // 
            // txtSLDGTieuHao
            // 
            this.txtSLDGTieuHao.Location = new System.Drawing.Point(92, 33);
            this.txtSLDGTieuHao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSLDGTieuHao.Name = "txtSLDGTieuHao";
            this.txtSLDGTieuHao.Size = new System.Drawing.Size(48, 27);
            this.txtSLDGTieuHao.TabIndex = 11;
            this.txtSLDGTieuHao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSLDGTieuHao_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboDonViTinhDG);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtSlDongGoi);
            this.groupBox1.Location = new System.Drawing.Point(11, 247);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(272, 74);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết qui cách ĐG";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(146, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "ĐVT";
            // 
            // cboDonViTinhDG
            // 
            this.cboDonViTinhDG.AutoComplete = false;
            this.cboDonViTinhDG.AutoDropdown = false;
            this.cboDonViTinhDG.BackColorEven = System.Drawing.Color.White;
            this.cboDonViTinhDG.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboDonViTinhDG.ColumnNames = "";
            this.cboDonViTinhDG.ColumnWidthDefault = 75;
            this.cboDonViTinhDG.ColumnWidths = "";
            this.cboDonViTinhDG.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboDonViTinhDG.FormattingEnabled = true;
            this.cboDonViTinhDG.LinkedColumnIndex1 = 0;
            this.cboDonViTinhDG.LinkedColumnIndex2 = 0;
            this.cboDonViTinhDG.LinkedTextBox1 = null;
            this.cboDonViTinhDG.LinkedTextBox2 = null;
            this.cboDonViTinhDG.Location = new System.Drawing.Point(187, 33);
            this.cboDonViTinhDG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboDonViTinhDG.Name = "cboDonViTinhDG";
            this.cboDonViTinhDG.Size = new System.Drawing.Size(51, 28);
            this.cboDonViTinhDG.TabIndex = 13;
            this.cboDonViTinhDG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDonViTinhDG_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Số lượng ĐG";
            // 
            // txtSlDongGoi
            // 
            this.txtSlDongGoi.Location = new System.Drawing.Point(92, 33);
            this.txtSlDongGoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSlDongGoi.Name = "txtSlDongGoi";
            this.txtSlDongGoi.Size = new System.Drawing.Size(48, 27);
            this.txtSlDongGoi.TabIndex = 11;
            this.txtSlDongGoi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSlDongGoi_KeyPress);
            // 
            // chkXuatQCDG
            // 
            this.chkXuatQCDG.AutoSize = true;
            this.chkXuatQCDG.Location = new System.Drawing.Point(108, 167);
            this.chkXuatQCDG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkXuatQCDG.Name = "chkXuatQCDG";
            this.chkXuatQCDG.Size = new System.Drawing.Size(93, 24);
            this.chkXuatQCDG.TabIndex = 13;
            this.chkXuatQCDG.Text = "Xuất QCĐG";
            this.chkXuatQCDG.UseVisualStyleBackColor = true;
            this.chkXuatQCDG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkXuatQCDG_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(150, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "ĐVT";
            // 
            // cboDonViTinh
            // 
            this.cboDonViTinh.AutoComplete = false;
            this.cboDonViTinh.AutoDropdown = false;
            this.cboDonViTinh.BackColorEven = System.Drawing.Color.White;
            this.cboDonViTinh.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboDonViTinh.ColumnNames = "";
            this.cboDonViTinh.ColumnWidthDefault = 75;
            this.cboDonViTinh.ColumnWidths = "";
            this.cboDonViTinh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboDonViTinh.FormattingEnabled = true;
            this.cboDonViTinh.LinkedColumnIndex1 = 0;
            this.cboDonViTinh.LinkedColumnIndex2 = 0;
            this.cboDonViTinh.LinkedTextBox1 = null;
            this.cboDonViTinh.LinkedTextBox2 = null;
            this.cboDonViTinh.Location = new System.Drawing.Point(202, 205);
            this.cboDonViTinh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboDonViTinh.Name = "cboDonViTinh";
            this.cboDonViTinh.Size = new System.Drawing.Size(82, 28);
            this.cboDonViTinh.TabIndex = 11;
            this.cboDonViTinh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDonViTinh_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Qui cách";
            // 
            // txtQuiCachDG
            // 
            this.txtQuiCachDG.Location = new System.Drawing.Point(77, 205);
            this.txtQuiCachDG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQuiCachDG.Name = "txtQuiCachDG";
            this.txtQuiCachDG.Size = new System.Drawing.Size(69, 27);
            this.txtQuiCachDG.TabIndex = 9;
            this.txtQuiCachDG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuiCachDG_KeyPress);
            // 
            // chkCoHSD
            // 
            this.chkCoHSD.AutoSize = true;
            this.chkCoHSD.Location = new System.Drawing.Point(11, 167);
            this.chkCoHSD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkCoHSD.Name = "chkCoHSD";
            this.chkCoHSD.Size = new System.Drawing.Size(71, 24);
            this.chkCoHSD.TabIndex = 8;
            this.chkCoHSD.Text = "Có HSD";
            this.chkCoHSD.UseVisualStyleBackColor = true;
            this.chkCoHSD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkCoHSD_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(150, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Loại VT";
            // 
            // cboLoaiVT
            // 
            this.cboLoaiVT.AutoComplete = false;
            this.cboLoaiVT.AutoDropdown = false;
            this.cboLoaiVT.BackColorEven = System.Drawing.Color.White;
            this.cboLoaiVT.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboLoaiVT.ColumnNames = "";
            this.cboLoaiVT.ColumnWidthDefault = 75;
            this.cboLoaiVT.ColumnWidths = "";
            this.cboLoaiVT.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboLoaiVT.FormattingEnabled = true;
            this.cboLoaiVT.LinkedColumnIndex1 = 0;
            this.cboLoaiVT.LinkedColumnIndex2 = 0;
            this.cboLoaiVT.LinkedTextBox1 = null;
            this.cboLoaiVT.LinkedTextBox2 = null;
            this.cboLoaiVT.Location = new System.Drawing.Point(202, 125);
            this.cboLoaiVT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboLoaiVT.Name = "cboLoaiVT";
            this.cboLoaiVT.Size = new System.Drawing.Size(82, 28);
            this.cboLoaiVT.TabIndex = 6;
            this.cboLoaiVT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboLoaiVT_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nhóm VT";
            // 
            // cboNhomVT
            // 
            this.cboNhomVT.AutoComplete = false;
            this.cboNhomVT.AutoDropdown = false;
            this.cboNhomVT.BackColorEven = System.Drawing.Color.White;
            this.cboNhomVT.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboNhomVT.ColumnNames = "";
            this.cboNhomVT.ColumnWidthDefault = 75;
            this.cboNhomVT.ColumnWidths = "";
            this.cboNhomVT.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboNhomVT.FormattingEnabled = true;
            this.cboNhomVT.LinkedColumnIndex1 = 0;
            this.cboNhomVT.LinkedColumnIndex2 = 0;
            this.cboNhomVT.LinkedTextBox1 = null;
            this.cboNhomVT.LinkedTextBox2 = null;
            this.cboNhomVT.Location = new System.Drawing.Point(77, 125);
            this.cboNhomVT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboNhomVT.Name = "cboNhomVT";
            this.cboNhomVT.Size = new System.Drawing.Size(69, 28);
            this.cboNhomVT.TabIndex = 4;
            this.cboNhomVT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboNhomVT_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên VT";
            // 
            // txtTenVatTu
            // 
            this.txtTenVatTu.Location = new System.Drawing.Point(76, 87);
            this.txtTenVatTu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenVatTu.Name = "txtTenVatTu";
            this.txtTenVatTu.Size = new System.Drawing.Size(208, 27);
            this.txtTenVatTu.TabIndex = 2;
            this.txtTenVatTu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenVatTu_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã VT";
            // 
            // txtMaVT
            // 
            this.txtMaVT.Location = new System.Drawing.Point(77, 49);
            this.txtMaVT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaVT.Name = "txtMaVT";
            this.txtMaVT.Size = new System.Drawing.Size(69, 27);
            this.txtMaVT.TabIndex = 0;
            this.txtMaVT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaVT_KeyPress);
            // 
            // frmDM_VatTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1150, 700);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "frmDM_VatTu";
            this.Text = "Danh mục vật tư";
            this.Load += new System.EventHandler(this.frmDM_VatTu_Load);
            this.pnContaint.ResumeLayout(false);
            this.pnContaint.PerformLayout();
            this.pnLabel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bvVatTu)).EndInit();
            this.bvVatTu.ResumeLayout(false);
            this.bvVatTu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVatTu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TPH.LIS.Common.Controls.CustomBindingNavigator bvVatTu;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton btnXoaVatTu;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private DevExpress.XtraEditors.PanelControl panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LabelControl label8;
        private CustomComboBox cboDonViTinhDG;
        private DevExpress.XtraEditors.LabelControl label7;
        private System.Windows.Forms.TextBox txtSlDongGoi;
        private System.Windows.Forms.CheckBox chkXuatQCDG;
        private DevExpress.XtraEditors.LabelControl label6;
        private CustomComboBox cboDonViTinh;
        private DevExpress.XtraEditors.LabelControl label5;
        private System.Windows.Forms.TextBox txtQuiCachDG;
        private System.Windows.Forms.CheckBox chkCoHSD;
        private DevExpress.XtraEditors.LabelControl label4;
        private CustomComboBox cboLoaiVT;
        private DevExpress.XtraEditors.LabelControl label3;
        private CustomComboBox cboNhomVT;
        private DevExpress.XtraEditors.LabelControl label2;
        private System.Windows.Forms.TextBox txtTenVatTu;
        private DevExpress.XtraEditors.LabelControl label1;
        private System.Windows.Forms.TextBox txtMaVT;
        private DevExpress.XtraEditors.LabelControl label9;
        private System.Windows.Forms.TextBox txtLuongTH;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.LabelControl label13;
        private System.Windows.Forms.TextBox txtSLDung;
        private DevExpress.XtraEditors.LabelControl label11;
        private CustomComboBox cboDonViTinhTH;
        private DevExpress.XtraEditors.LabelControl label12;
        private System.Windows.Forms.TextBox txtSLDGTieuHao;
        private TPH.Controls.TPHNormalButton btnCancel;
        private TPH.Controls.TPHNormalButton btnSave;
        private TPH.Controls.TPHNormalButton btnEdit;
        private TPH.Controls.TPHNormalButton btnAddNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhomVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoaiVT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CoHSD;
        private System.Windows.Forms.DataGridViewCheckBoxColumn XuatQCDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn gQuiCachDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DVTQuiCach;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLDongGoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DVTDongGoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLDGTieuHao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DVTTieuHao;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLanDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuHaoTrenLan;
        private CustomDatagridView dtgVatTu;
    }
}