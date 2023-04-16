using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.CauHinh.DanhMucCLS
{
    partial class frmDMCLS_SieuAm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMCLS_SieuAm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panel2 = new DevExpress.XtraEditors.PanelControl();
            this.dtgBieuMau = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.MaSoMau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoTat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMauSieuAm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuDePhieuKetQua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinhSuDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChanDoanMacDinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KetluanMacDinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeNghi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongHinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTrangIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bvBieuMau = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLoadBieuMau = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSave = new TPH.Controls.TPHNormalButton();
            this.btnAddMauSieuAm = new TPH.Controls.TPHNormalButton();
            this.tnXoaMau = new TPH.Controls.TPHNormalButton();
            this.btnSuaMau = new TPH.Controls.TPHNormalButton();
            this.splitContainer2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ricTrang1 = new RicherTextBox.RicherTextBox();
            this.panel3 = new DevExpress.XtraEditors.PanelControl();
            this.ricKetLuan = new RicherTextBox.RicherTextBox();
            this.cboNhomSieuAm = new TPH.LIS.Common.Controls.CustomComboBox();
            this.lblSex = new DevExpress.XtraEditors.LabelControl();
            this.label9 = new DevExpress.XtraEditors.LabelControl();
            this.txtSoTrangMota = new System.Windows.Forms.TextBox();
            this.label8 = new DevExpress.XtraEditors.LabelControl();
            this.txtGoTat = new System.Windows.Forms.TextBox();
            this.label11 = new DevExpress.XtraEditors.LabelControl();
            this.txtDeNghi = new System.Windows.Forms.TextBox();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.txtSLHinh = new System.Windows.Forms.TextBox();
            this.label7 = new DevExpress.XtraEditors.LabelControl();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenBieuMau = new System.Windows.Forms.TextBox();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenChiDinh = new System.Windows.Forms.TextBox();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.txtGioiTinh = new System.Windows.Forms.TextBox();
            this.label6 = new DevExpress.XtraEditors.LabelControl();
            this.txtTieuDePhieuIn = new System.Windows.Forms.TextBox();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.ricTrang2 = new RicherTextBox.RicherTextBox();
            this.label10 = new DevExpress.XtraEditors.LabelControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabNhom = new System.Windows.Forms.TabPage();
            this.dtgMaNhomCLS = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.MaNhomCLS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhomCLS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bvMaNhomCLS = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefreshMaNhomCLS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeleteMaNhomCLS = new System.Windows.Forms.ToolStripButton();
            this.tabDanhMucBieuMau = new System.Windows.Forms.TabPage();
            this.tabMaySieuAm = new System.Windows.Forms.TabPage();
            this.dtgMaySA = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new DevExpress.XtraEditors.PanelControl();
            this.btnThemMaySA = new TPH.Controls.TPHNormalButton();
            this.label12 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenMaySA = new System.Windows.Forms.TextBox();
            this.bvMaySA = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefreshMayXN = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeleteMayXN = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnContaint)).BeginInit();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnMenu)).BeginInit();
            this.pnMenu.SuspendLayout();
            this.xtraScrollableControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnFormControl)).BeginInit();
            this.pnFormControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1.Panel1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1.Panel2)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBieuMau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvBieuMau)).BeginInit();
            this.bvBieuMau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2.Panel1)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2.Panel2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel3)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabNhom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMaNhomCLS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvMaNhomCLS)).BeginInit();
            this.bvMaNhomCLS.SuspendLayout();
            this.tabDanhMucBieuMau.SuspendLayout();
            this.tabMaySieuAm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMaySA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel4)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bvMaySA)).BeginInit();
            this.bvMaySA.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblTitle.Appearance.Options.UseBackColor = true;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Size = new System.Drawing.Size(241, 22);
            this.lblTitle.Text = "DANH MỤC BIỂU MẪU SIÊU ÂM";
            // 
            // pnContaint
            // 
            this.pnContaint.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnContaint.Appearance.Options.UseBackColor = true;
            this.pnContaint.Controls.Add(this.tabControl1);
            this.pnContaint.Location = new System.Drawing.Point(0, 659);
            this.pnContaint.Size = new System.Drawing.Size(1134, 2);
            // 
            // pnLabel
            // 
            this.pnLabel.Size = new System.Drawing.Size(1134, 38);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(782, 0);
            this.btnClose.Size = new System.Drawing.Size(29, 38);
            // 
            // lblMainESC
            // 
            this.lblMainESC.Appearance.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainESC.Appearance.Options.UseFont = true;
            this.lblMainESC.ImageOptions.Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lblMainESC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblMainESC.ImageOptions.Image")));
            this.lblMainESC.Location = new System.Drawing.Point(811, 0);
            // 
            // pnMenu
            // 
            this.pnMenu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnMenu.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnMenu.Appearance.Options.UseBackColor = true;
            this.pnMenu.Location = new System.Drawing.Point(0, 38);
            this.pnMenu.Size = new System.Drawing.Size(1134, 621);
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.xtraScrollableControlMain.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(1134, 620);
            // 
            // ucGroupHeaderChonMain
            // 
            this.ucGroupHeaderChonMain.Location = new System.Drawing.Point(243, 1);
            this.ucGroupHeaderChonMain.Size = new System.Drawing.Size(10, 619);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnFormControl.Appearance.Options.UseBackColor = true;
            this.pnFormControl.Location = new System.Drawing.Point(1026, 1);
            this.pnFormControl.Size = new System.Drawing.Size(106, 619);
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
            this.splitContainer1.Location = new System.Drawing.Point(3, 4);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1166, 0);
            this.splitContainer1.SplitterPosition = 408;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgBieuMau);
            this.panel2.Controls.Add(this.bvBieuMau);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(408, 0);
            this.panel2.TabIndex = 20;
            // 
            // dtgBieuMau
            // 
            this.dtgBieuMau.AlignColumns = "";
            this.dtgBieuMau.AllignNumberText = false;
            this.dtgBieuMau.AllowUserToAddRows = false;
            this.dtgBieuMau.AllowUserToDeleteRows = false;
            this.dtgBieuMau.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgBieuMau.CheckBoldColumn = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgBieuMau.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgBieuMau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBieuMau.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSoMau,
            this.GoTat,
            this.TenMauSieuAm,
            this.TieuDePhieuKetQua,
            this.GioiTinhSuDung,
            this.ChanDoanMacDinh,
            this.KetluanMacDinh,
            this.DeNghi,
            this.SoLuongHinh,
            this.SoTrangIn});
            this.dtgBieuMau.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(231)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgBieuMau.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgBieuMau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgBieuMau.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgBieuMau.Location = new System.Drawing.Point(2, 1);
            this.dtgBieuMau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgBieuMau.MarkOddEven = true;
            this.dtgBieuMau.MultiSelect = false;
            this.dtgBieuMau.Name = "dtgBieuMau";
            this.dtgBieuMau.RowHeadersVisible = false;
            this.dtgBieuMau.RowHeadersWidth = 20;
            this.dtgBieuMau.RowTemplate.Height = 28;
            this.dtgBieuMau.Size = new System.Drawing.Size(404, 0);
            this.dtgBieuMau.TabIndex = 0;
            // 
            // MaSoMau
            // 
            this.MaSoMau.DataPropertyName = "MaSoMau";
            this.MaSoMau.HeaderText = "Mã số";
            this.MaSoMau.Name = "MaSoMau";
            this.MaSoMau.Visible = false;
            // 
            // GoTat
            // 
            this.GoTat.DataPropertyName = "GoTat";
            this.GoTat.HeaderText = "Gõ tắt";
            this.GoTat.Name = "GoTat";
            this.GoTat.Width = 80;
            // 
            // TenMauSieuAm
            // 
            this.TenMauSieuAm.DataPropertyName = "TenMauSieuAm";
            this.TenMauSieuAm.HeaderText = "Tên mẫu siêu âm";
            this.TenMauSieuAm.Name = "TenMauSieuAm";
            this.TenMauSieuAm.Width = 200;
            // 
            // TieuDePhieuKetQua
            // 
            this.TieuDePhieuKetQua.DataPropertyName = "TieuDePhieuKetQua";
            this.TieuDePhieuKetQua.HeaderText = "Tiêu đề phiếu kết quả";
            this.TieuDePhieuKetQua.Name = "TieuDePhieuKetQua";
            this.TieuDePhieuKetQua.Width = 250;
            // 
            // GioiTinhSuDung
            // 
            this.GioiTinhSuDung.DataPropertyName = "GioiTinhSuDung";
            this.GioiTinhSuDung.HeaderText = "Giới tính";
            this.GioiTinhSuDung.Name = "GioiTinhSuDung";
            // 
            // ChanDoanMacDinh
            // 
            this.ChanDoanMacDinh.DataPropertyName = "ChanDoanMacDinh";
            this.ChanDoanMacDinh.HeaderText = "Chẩn đoán mặc định";
            this.ChanDoanMacDinh.Name = "ChanDoanMacDinh";
            this.ChanDoanMacDinh.Width = 250;
            // 
            // KetluanMacDinh
            // 
            this.KetluanMacDinh.DataPropertyName = "KetluanMacDinh";
            this.KetluanMacDinh.HeaderText = "Kết luận mặc định";
            this.KetluanMacDinh.Name = "KetluanMacDinh";
            this.KetluanMacDinh.Width = 200;
            // 
            // DeNghi
            // 
            this.DeNghi.DataPropertyName = "DeNghi";
            this.DeNghi.HeaderText = "Đề nghị";
            this.DeNghi.Name = "DeNghi";
            this.DeNghi.Width = 150;
            // 
            // SoLuongHinh
            // 
            this.SoLuongHinh.DataPropertyName = "SoLuongHinh";
            dataGridViewCellStyle4.Format = "N0";
            this.SoLuongHinh.DefaultCellStyle = dataGridViewCellStyle4;
            this.SoLuongHinh.HeaderText = "SL hình";
            this.SoLuongHinh.Name = "SoLuongHinh";
            // 
            // SoTrangIn
            // 
            this.SoTrangIn.DataPropertyName = "SoTrangIn";
            dataGridViewCellStyle5.Format = "N0";
            this.SoTrangIn.DefaultCellStyle = dataGridViewCellStyle5;
            this.SoTrangIn.HeaderText = "Số trang";
            this.SoTrangIn.Name = "SoTrangIn";
            // 
            // bvBieuMau
            // 
            this.bvBieuMau.AddNewItem = null;
            this.bvBieuMau.CountItem = this.bindingNavigatorCountItem;
            this.bvBieuMau.CountItemFormat = "/ {0}";
            this.bvBieuMau.DeleteItem = null;
            this.bvBieuMau.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvBieuMau.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvBieuMau.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bvBieuMau.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.btnLoadBieuMau});
            this.bvBieuMau.Location = new System.Drawing.Point(2, -26);
            this.bvBieuMau.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bvBieuMau.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bvBieuMau.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bvBieuMau.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bvBieuMau.Name = "bvBieuMau";
            this.bvBieuMau.PositionItem = this.bindingNavigatorPositionItem;
            this.bvBieuMau.Size = new System.Drawing.Size(404, 25);
            this.bvBieuMau.TabIndex = 1;
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
            // btnLoadBieuMau
            // 
            this.btnLoadBieuMau.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLoadBieuMau.Image = global::TPH.LIS.App.Properties.Resources.Refresh__1_;
            this.btnLoadBieuMau.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadBieuMau.Name = "btnLoadBieuMau";
            this.btnLoadBieuMau.Size = new System.Drawing.Size(23, 22);
            this.btnLoadBieuMau.Text = "toolStripButton9";
            this.btnLoadBieuMau.Click += new System.EventHandler(this.btnLoadBieuMau_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnAddMauSieuAm);
            this.panel1.Controls.Add(this.tnXoaMau);
            this.panel1.Controls.Add(this.btnSuaMau);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(408, 36);
            this.panel1.TabIndex = 19;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackColorHover = System.Drawing.Color.Empty;
            this.btnSave.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnSave.BorderRadius = 5;
            this.btnSave.BorderSize = 1;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForceColorHover = System.Drawing.Color.Empty;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(188, 6);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(67, 23);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Lưu";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextColor = System.Drawing.Color.Black;
            this.btnSave.UseHightLight = true;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddMauSieuAm
            // 
            this.btnAddMauSieuAm.BackColor = System.Drawing.Color.Transparent;
            this.btnAddMauSieuAm.BackColorHover = System.Drawing.Color.Empty;
            this.btnAddMauSieuAm.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnAddMauSieuAm.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnAddMauSieuAm.BorderRadius = 5;
            this.btnAddMauSieuAm.BorderSize = 1;
            this.btnAddMauSieuAm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddMauSieuAm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMauSieuAm.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMauSieuAm.ForceColorHover = System.Drawing.Color.Empty;
            this.btnAddMauSieuAm.ForeColor = System.Drawing.Color.Black;
            this.btnAddMauSieuAm.Image = ((System.Drawing.Image)(resources.GetObject("btnAddMauSieuAm.Image")));
            this.btnAddMauSieuAm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddMauSieuAm.Location = new System.Drawing.Point(6, 6);
            this.btnAddMauSieuAm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddMauSieuAm.Name = "btnAddMauSieuAm";
            this.btnAddMauSieuAm.Size = new System.Drawing.Size(105, 23);
            this.btnAddMauSieuAm.TabIndex = 19;
            this.btnAddMauSieuAm.Text = "Thêm mới";
            this.btnAddMauSieuAm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddMauSieuAm.TextColor = System.Drawing.Color.Black;
            this.btnAddMauSieuAm.UseHightLight = true;
            this.btnAddMauSieuAm.UseVisualStyleBackColor = true;
            this.btnAddMauSieuAm.Click += new System.EventHandler(this.btnAddMauSieuAm_Click);
            // 
            // tnXoaMau
            // 
            this.tnXoaMau.BackColor = System.Drawing.Color.Transparent;
            this.tnXoaMau.BackColorHover = System.Drawing.Color.Empty;
            this.tnXoaMau.BackgroundColor = System.Drawing.Color.Transparent;
            this.tnXoaMau.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.tnXoaMau.BorderRadius = 5;
            this.tnXoaMau.BorderSize = 1;
            this.tnXoaMau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tnXoaMau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tnXoaMau.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tnXoaMau.ForceColorHover = System.Drawing.Color.Empty;
            this.tnXoaMau.ForeColor = System.Drawing.Color.Black;
            this.tnXoaMau.Image = ((System.Drawing.Image)(resources.GetObject("tnXoaMau.Image")));
            this.tnXoaMau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tnXoaMau.Location = new System.Drawing.Point(261, 6);
            this.tnXoaMau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tnXoaMau.Name = "tnXoaMau";
            this.tnXoaMau.Size = new System.Drawing.Size(62, 23);
            this.tnXoaMau.TabIndex = 4;
            this.tnXoaMau.Text = "Xóa";
            this.tnXoaMau.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tnXoaMau.TextColor = System.Drawing.Color.Black;
            this.tnXoaMau.UseHightLight = true;
            this.tnXoaMau.UseVisualStyleBackColor = true;
            // 
            // btnSuaMau
            // 
            this.btnSuaMau.BackColor = System.Drawing.Color.Yellow;
            this.btnSuaMau.BackColorHover = System.Drawing.Color.Empty;
            this.btnSuaMau.BackgroundColor = System.Drawing.Color.Yellow;
            this.btnSuaMau.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnSuaMau.BorderRadius = 5;
            this.btnSuaMau.BorderSize = 1;
            this.btnSuaMau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaMau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaMau.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnSuaMau.ForceColorHover = System.Drawing.Color.Empty;
            this.btnSuaMau.ForeColor = System.Drawing.Color.Crimson;
            this.btnSuaMau.Image = ((System.Drawing.Image)(resources.GetObject("btnSuaMau.Image")));
            this.btnSuaMau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaMau.Location = new System.Drawing.Point(117, 6);
            this.btnSuaMau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSuaMau.Name = "btnSuaMau";
            this.btnSuaMau.Size = new System.Drawing.Size(65, 23);
            this.btnSuaMau.TabIndex = 3;
            this.btnSuaMau.Text = "Sửa";
            this.btnSuaMau.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuaMau.TextColor = System.Drawing.Color.Crimson;
            this.btnSuaMau.UseHightLight = true;
            this.btnSuaMau.UseVisualStyleBackColor = false;
            this.btnSuaMau.Click += new System.EventHandler(this.btnSuaMau_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ricTrang1);
            this.splitContainer2.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ricTrang2);
            this.splitContainer2.Panel2.Controls.Add(this.label10);
            this.splitContainer2.Size = new System.Drawing.Size(748, 0);
            this.splitContainer2.SplitterPosition = 332;
            this.splitContainer2.TabIndex = 0;
            // 
            // ricTrang1
            // 
            this.ricTrang1.AlignCenterVisible = false;
            this.ricTrang1.AlignLeftVisible = false;
            this.ricTrang1.AlignRightVisible = false;
            this.ricTrang1.BoldVisible = false;
            this.ricTrang1.BulletsVisible = false;
            this.ricTrang1.ChooseFontVisible = false;
            this.ricTrang1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ricTrang1.FindReplaceVisible = false;
            this.ricTrang1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ricTrang1.FontColorVisible = false;
            this.ricTrang1.FontFamilyVisible = false;
            this.ricTrang1.FontSizeVisible = false;
            this.ricTrang1.GroupAlignmentVisible = false;
            this.ricTrang1.GroupBoldUnderlineItalicVisible = false;
            this.ricTrang1.GroupFontColorVisible = false;
            this.ricTrang1.GroupFontNameAndSizeVisible = false;
            this.ricTrang1.GroupIndentationAndBulletsVisible = false;
            this.ricTrang1.GroupInsertVisible = false;
            this.ricTrang1.GroupSaveAndLoadVisible = false;
            this.ricTrang1.GroupZoomVisible = false;
            this.ricTrang1.INDENT = 10;
            this.ricTrang1.IndentVisible = false;
            this.ricTrang1.InsertPictureVisible = false;
            this.ricTrang1.ItalicVisible = false;
            this.ricTrang1.LoadVisible = false;
            this.ricTrang1.Location = new System.Drawing.Point(0, 262);
            this.ricTrang1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ricTrang1.Name = "ricTrang1";
            this.ricTrang1.OutdentVisible = false;
            this.ricTrang1.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset20" +
    "4 Times New Roman CYR;}}\r\n{\\*\\generator Riched20 10.0.22621}\\viewkind4\\uc1 \r\n\\pa" +
    "rd\\f0\\fs18\\lang1049\\par\r\n}\r\n";
            this.ricTrang1.SaveVisible = false;
            this.ricTrang1.SeparatorAlignVisible = false;
            this.ricTrang1.SeparatorBoldUnderlineItalicVisible = false;
            this.ricTrang1.SeparatorFontColorVisible = false;
            this.ricTrang1.SeparatorFontVisible = false;
            this.ricTrang1.SeparatorIndentAndBulletsVisible = false;
            this.ricTrang1.SeparatorInsertVisible = false;
            this.ricTrang1.SeparatorSaveLoadVisible = false;
            this.ricTrang1.Size = new System.Drawing.Size(332, 0);
            this.ricTrang1.TabIndex = 26;
            this.ricTrang1.ToolStripVisible = false;
            this.ricTrang1.UnderlineVisible = false;
            this.ricTrang1.WordWrapVisible = false;
            this.ricTrang1.ZoomFactorTextVisible = false;
            this.ricTrang1.ZoomInVisible = false;
            this.ricTrang1.ZoomOutVisible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ricKetLuan);
            this.panel3.Controls.Add(this.cboNhomSieuAm);
            this.panel3.Controls.Add(this.lblSex);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txtSoTrangMota);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtGoTat);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.txtDeNghi);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtSLHinh);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtTenBieuMau);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtTenChiDinh);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtGioiTinh);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtTieuDePhieuIn);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(332, 262);
            this.panel3.TabIndex = 2;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // ricKetLuan
            // 
            this.ricKetLuan.AlignCenterVisible = false;
            this.ricKetLuan.AlignLeftVisible = false;
            this.ricKetLuan.AlignRightVisible = false;
            this.ricKetLuan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ricKetLuan.BoldVisible = false;
            this.ricKetLuan.BulletsVisible = false;
            this.ricKetLuan.ChooseFontVisible = false;
            this.ricKetLuan.FindReplaceVisible = false;
            this.ricKetLuan.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ricKetLuan.FontColorVisible = false;
            this.ricKetLuan.FontFamilyVisible = false;
            this.ricKetLuan.FontSizeVisible = false;
            this.ricKetLuan.GroupAlignmentVisible = false;
            this.ricKetLuan.GroupBoldUnderlineItalicVisible = false;
            this.ricKetLuan.GroupFontColorVisible = false;
            this.ricKetLuan.GroupFontNameAndSizeVisible = false;
            this.ricKetLuan.GroupIndentationAndBulletsVisible = false;
            this.ricKetLuan.GroupInsertVisible = false;
            this.ricKetLuan.GroupSaveAndLoadVisible = false;
            this.ricKetLuan.GroupZoomVisible = false;
            this.ricKetLuan.INDENT = 10;
            this.ricKetLuan.IndentVisible = false;
            this.ricKetLuan.InsertPictureVisible = false;
            this.ricKetLuan.ItalicVisible = false;
            this.ricKetLuan.LoadVisible = false;
            this.ricKetLuan.Location = new System.Drawing.Point(72, 128);
            this.ricKetLuan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ricKetLuan.Name = "ricKetLuan";
            this.ricKetLuan.OutdentVisible = false;
            this.ricKetLuan.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset20" +
    "4 Microsoft Sans Serif;}}\r\n{\\*\\generator Riched20 10.0.22621}\\viewkind4\\uc1 \r\n\\p" +
    "ard\\f0\\fs18\\lang1049\\par\r\n}\r\n";
            this.ricKetLuan.SaveVisible = false;
            this.ricKetLuan.SeparatorAlignVisible = false;
            this.ricKetLuan.SeparatorBoldUnderlineItalicVisible = false;
            this.ricKetLuan.SeparatorFontColorVisible = false;
            this.ricKetLuan.SeparatorFontVisible = false;
            this.ricKetLuan.SeparatorIndentAndBulletsVisible = false;
            this.ricKetLuan.SeparatorInsertVisible = false;
            this.ricKetLuan.SeparatorSaveLoadVisible = false;
            this.ricKetLuan.Size = new System.Drawing.Size(256, 109);
            this.ricKetLuan.TabIndex = 25;
            this.ricKetLuan.ToolStripVisible = false;
            this.ricKetLuan.UnderlineVisible = false;
            this.ricKetLuan.WordWrapVisible = false;
            this.ricKetLuan.ZoomFactorTextVisible = false;
            this.ricKetLuan.ZoomInVisible = false;
            this.ricKetLuan.ZoomOutVisible = false;
            // 
            // cboNhomSieuAm
            // 
            this.cboNhomSieuAm.AutoComplete = false;
            this.cboNhomSieuAm.AutoDropdown = false;
            this.cboNhomSieuAm.BackColorEven = System.Drawing.Color.White;
            this.cboNhomSieuAm.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboNhomSieuAm.ColumnNames = "MaNhomSieuAm,TenNhomSieuAm";
            this.cboNhomSieuAm.ColumnWidthDefault = 75;
            this.cboNhomSieuAm.ColumnWidths = "35,150";
            this.cboNhomSieuAm.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboNhomSieuAm.FormattingEnabled = true;
            this.cboNhomSieuAm.LinkedColumnIndex = 0;
            this.cboNhomSieuAm.LinkedColumnIndex1 = 0;
            this.cboNhomSieuAm.LinkedColumnIndex2 = 0;
            this.cboNhomSieuAm.LinkedTextBox = null;
            this.cboNhomSieuAm.LinkedTextBox1 = null;
            this.cboNhomSieuAm.LinkedTextBox2 = null;
            this.cboNhomSieuAm.Location = new System.Drawing.Point(132, 3);
            this.cboNhomSieuAm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboNhomSieuAm.Name = "cboNhomSieuAm";
            this.cboNhomSieuAm.Size = new System.Drawing.Size(138, 21);
            this.cboNhomSieuAm.TabIndex = 24;
            this.cboNhomSieuAm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboNhomSieuAm_KeyPress);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(185, 100);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(34, 13);
            this.lblSex.TabIndex = 23;
            this.lblSex.Text = "G.Tính";
            // 
            // label9
            // 
            this.label9.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Appearance.Options.UseBackColor = true;
            this.label9.Appearance.Options.UseFont = true;
            this.label9.Appearance.Options.UseForeColor = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label9.Location = new System.Drawing.Point(2, 244);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "NỘI DUNG ";
            // 
            // txtSoTrangMota
            // 
            this.txtSoTrangMota.BackColor = System.Drawing.Color.White;
            this.txtSoTrangMota.Location = new System.Drawing.Point(486, 47);
            this.txtSoTrangMota.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoTrangMota.MaxLength = 1;
            this.txtSoTrangMota.Name = "txtSoTrangMota";
            this.txtSoTrangMota.ReadOnly = true;
            this.txtSoTrangMota.Size = new System.Drawing.Size(42, 20);
            this.txtSoTrangMota.TabIndex = 18;
            this.txtSoTrangMota.Visible = false;
            this.txtSoTrangMota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoTrangMota_KeyPress);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(483, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Số mô tả";
            this.label8.Visible = false;
            // 
            // txtGoTat
            // 
            this.txtGoTat.BackColor = System.Drawing.Color.White;
            this.txtGoTat.Location = new System.Drawing.Point(331, 4);
            this.txtGoTat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGoTat.MaxLength = 20;
            this.txtGoTat.Name = "txtGoTat";
            this.txtGoTat.ReadOnly = true;
            this.txtGoTat.Size = new System.Drawing.Size(120, 20);
            this.txtGoTat.TabIndex = 22;
            this.txtGoTat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGoTat_KeyPress);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(278, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Gõ tắt";
            // 
            // txtDeNghi
            // 
            this.txtDeNghi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeNghi.BackColor = System.Drawing.Color.White;
            this.txtDeNghi.Location = new System.Drawing.Point(338, 97);
            this.txtDeNghi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDeNghi.Name = "txtDeNghi";
            this.txtDeNghi.ReadOnly = true;
            this.txtDeNghi.Size = new System.Drawing.Size(0, 20);
            this.txtDeNghi.TabIndex = 12;
            this.txtDeNghi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDeNghi_KeyPress);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(268, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Đề nghị";
            // 
            // txtSLHinh
            // 
            this.txtSLHinh.BackColor = System.Drawing.Color.White;
            this.txtSLHinh.Location = new System.Drawing.Point(513, 4);
            this.txtSLHinh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSLHinh.MaxLength = 1;
            this.txtSLHinh.Name = "txtSLHinh";
            this.txtSLHinh.ReadOnly = true;
            this.txtSLHinh.Size = new System.Drawing.Size(36, 20);
            this.txtSLHinh.TabIndex = 16;
            this.txtSLHinh.Text = "2";
            this.txtSLHinh.Visible = false;
            this.txtSLHinh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSLHinh_KeyPress);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(480, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Số lượng hình";
            this.label7.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Kết luận";
            // 
            // txtTenBieuMau
            // 
            this.txtTenBieuMau.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenBieuMau.BackColor = System.Drawing.Color.White;
            this.txtTenBieuMau.Location = new System.Drawing.Point(132, 35);
            this.txtTenBieuMau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenBieuMau.Name = "txtTenBieuMau";
            this.txtTenBieuMau.ReadOnly = true;
            this.txtTenBieuMau.Size = new System.Drawing.Size(197, 20);
            this.txtTenBieuMau.TabIndex = 1;
            this.txtTenBieuMau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenBieuMau_KeyPress);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên biểu mẫu";
            // 
            // txtTenChiDinh
            // 
            this.txtTenChiDinh.BackColor = System.Drawing.Color.White;
            this.txtTenChiDinh.Location = new System.Drawing.Point(492, 47);
            this.txtTenChiDinh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenChiDinh.Name = "txtTenChiDinh";
            this.txtTenChiDinh.ReadOnly = true;
            this.txtTenChiDinh.Size = new System.Drawing.Size(60, 20);
            this.txtTenChiDinh.TabIndex = 10;
            this.txtTenChiDinh.Visible = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(11, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nhóm siêu âm";
            // 
            // txtGioiTinh
            // 
            this.txtGioiTinh.BackColor = System.Drawing.Color.White;
            this.txtGioiTinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGioiTinh.Location = new System.Drawing.Point(132, 97);
            this.txtGioiTinh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGioiTinh.MaxLength = 1;
            this.txtGioiTinh.Name = "txtGioiTinh";
            this.txtGioiTinh.ReadOnly = true;
            this.txtGioiTinh.Size = new System.Drawing.Size(36, 20);
            this.txtGioiTinh.TabIndex = 14;
            this.txtGioiTinh.TextChanged += new System.EventHandler(this.txtGioiTinh_TextChanged);
            this.txtGioiTinh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGioiTinh_KeyPress);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(11, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Dùng cho (F/M/A)";
            // 
            // txtTieuDePhieuIn
            // 
            this.txtTieuDePhieuIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTieuDePhieuIn.BackColor = System.Drawing.Color.White;
            this.txtTieuDePhieuIn.Location = new System.Drawing.Point(132, 66);
            this.txtTieuDePhieuIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTieuDePhieuIn.Name = "txtTieuDePhieuIn";
            this.txtTieuDePhieuIn.ReadOnly = true;
            this.txtTieuDePhieuIn.Size = new System.Drawing.Size(197, 20);
            this.txtTieuDePhieuIn.TabIndex = 6;
            this.txtTieuDePhieuIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTieuDePhieuIn_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tiêu đề phiếu in";
            // 
            // ricTrang2
            // 
            this.ricTrang2.AlignCenterVisible = false;
            this.ricTrang2.AlignLeftVisible = false;
            this.ricTrang2.AlignRightVisible = false;
            this.ricTrang2.BoldVisible = false;
            this.ricTrang2.BulletsVisible = false;
            this.ricTrang2.ChooseFontVisible = false;
            this.ricTrang2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ricTrang2.FindReplaceVisible = false;
            this.ricTrang2.FontColorVisible = false;
            this.ricTrang2.FontFamilyVisible = false;
            this.ricTrang2.FontSizeVisible = false;
            this.ricTrang2.GroupAlignmentVisible = false;
            this.ricTrang2.GroupBoldUnderlineItalicVisible = false;
            this.ricTrang2.GroupFontColorVisible = false;
            this.ricTrang2.GroupFontNameAndSizeVisible = false;
            this.ricTrang2.GroupIndentationAndBulletsVisible = false;
            this.ricTrang2.GroupInsertVisible = false;
            this.ricTrang2.GroupSaveAndLoadVisible = false;
            this.ricTrang2.GroupZoomVisible = false;
            this.ricTrang2.INDENT = 10;
            this.ricTrang2.IndentVisible = false;
            this.ricTrang2.InsertPictureVisible = false;
            this.ricTrang2.ItalicVisible = false;
            this.ricTrang2.LoadVisible = false;
            this.ricTrang2.Location = new System.Drawing.Point(0, 18);
            this.ricTrang2.Margin = new System.Windows.Forms.Padding(4);
            this.ricTrang2.Name = "ricTrang2";
            this.ricTrang2.OutdentVisible = false;
            this.ricTrang2.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset20" +
    "4 Microsoft Sans Serif;}}\r\n{\\*\\generator Riched20 10.0.22621}\\viewkind4\\uc1 \r\n\\p" +
    "ard\\f0\\fs18\\lang1049\\par\r\n}\r\n";
            this.ricTrang2.SaveVisible = false;
            this.ricTrang2.SeparatorAlignVisible = false;
            this.ricTrang2.SeparatorBoldUnderlineItalicVisible = false;
            this.ricTrang2.SeparatorFontColorVisible = false;
            this.ricTrang2.SeparatorFontVisible = false;
            this.ricTrang2.SeparatorIndentAndBulletsVisible = false;
            this.ricTrang2.SeparatorInsertVisible = false;
            this.ricTrang2.SeparatorSaveLoadVisible = false;
            this.ricTrang2.Size = new System.Drawing.Size(406, 0);
            this.ricTrang2.TabIndex = 2;
            this.ricTrang2.ToolStripVisible = false;
            this.ricTrang2.UnderlineVisible = false;
            this.ricTrang2.WordWrapVisible = false;
            this.ricTrang2.ZoomFactorTextVisible = false;
            this.ricTrang2.ZoomInVisible = false;
            this.ricTrang2.ZoomOutVisible = false;
            // 
            // label10
            // 
            this.label10.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.label10.Appearance.Options.UseBackColor = true;
            this.label10.Appearance.Options.UseFont = true;
            this.label10.Appearance.Options.UseForeColor = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(145, 18);
            this.label10.TabIndex = 1;
            this.label10.Text = "NỘI DUNG TRANG 2";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "104.ico");
            this.imageList1.Images.SetKeyName(1, "070.ico");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabNhom);
            this.tabControl1.Controls.Add(this.tabDanhMucBieuMau);
            this.tabControl1.Controls.Add(this.tabMaySieuAm);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1130, 0);
            this.tabControl1.TabIndex = 2;
            // 
            // tabNhom
            // 
            this.tabNhom.Controls.Add(this.dtgMaNhomCLS);
            this.tabNhom.Controls.Add(this.bvMaNhomCLS);
            this.tabNhom.Location = new System.Drawing.Point(4, 22);
            this.tabNhom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabNhom.Name = "tabNhom";
            this.tabNhom.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabNhom.Size = new System.Drawing.Size(1122, 0);
            this.tabNhom.TabIndex = 0;
            this.tabNhom.Text = "Nhóm siêu âm";
            this.tabNhom.UseVisualStyleBackColor = true;
            // 
            // dtgMaNhomCLS
            // 
            this.dtgMaNhomCLS.AlignColumns = "";
            this.dtgMaNhomCLS.AllignNumberText = false;
            this.dtgMaNhomCLS.AllowUserToDeleteRows = false;
            this.dtgMaNhomCLS.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgMaNhomCLS.CheckBoldColumn = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgMaNhomCLS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgMaNhomCLS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMaNhomCLS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNhomCLS,
            this.TenNhomCLS});
            this.dtgMaNhomCLS.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(231)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMaNhomCLS.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgMaNhomCLS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgMaNhomCLS.GridColor = System.Drawing.Color.LightSteelBlue;
            this.dtgMaNhomCLS.Location = new System.Drawing.Point(3, 4);
            this.dtgMaNhomCLS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgMaNhomCLS.MarkOddEven = true;
            this.dtgMaNhomCLS.MultiSelect = false;
            this.dtgMaNhomCLS.Name = "dtgMaNhomCLS";
            this.dtgMaNhomCLS.RowHeadersWidth = 20;
            this.dtgMaNhomCLS.RowTemplate.Height = 28;
            this.dtgMaNhomCLS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgMaNhomCLS.Size = new System.Drawing.Size(1116, 0);
            this.dtgMaNhomCLS.TabIndex = 5;
            this.dtgMaNhomCLS.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgMaNhomCLS_DataBindingComplete);
            // 
            // MaNhomCLS
            // 
            this.MaNhomCLS.DataPropertyName = "MaNhomSieuAm";
            this.MaNhomCLS.HeaderText = "Mã nhóm";
            this.MaNhomCLS.Name = "MaNhomCLS";
            // 
            // TenNhomCLS
            // 
            this.TenNhomCLS.DataPropertyName = "TenNhomSieuAm";
            this.TenNhomCLS.HeaderText = "Tên nhóm";
            this.TenNhomCLS.Name = "TenNhomCLS";
            this.TenNhomCLS.Width = 300;
            // 
            // bvMaNhomCLS
            // 
            this.bvMaNhomCLS.AddNewItem = null;
            this.bvMaNhomCLS.CountItem = this.toolStripLabel1;
            this.bvMaNhomCLS.CountItemFormat = "/ {0}";
            this.bvMaNhomCLS.DeleteItem = null;
            this.bvMaNhomCLS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvMaNhomCLS.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bvMaNhomCLS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripTextBox1,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator3,
            this.toolStripSeparator4,
            this.btnRefreshMaNhomCLS,
            this.toolStripSeparator5,
            this.btnDeleteMaNhomCLS});
            this.bvMaNhomCLS.Location = new System.Drawing.Point(3, -29);
            this.bvMaNhomCLS.MoveFirstItem = this.toolStripButton1;
            this.bvMaNhomCLS.MoveLastItem = this.toolStripButton4;
            this.bvMaNhomCLS.MoveNextItem = this.toolStripButton3;
            this.bvMaNhomCLS.MovePreviousItem = this.toolStripButton2;
            this.bvMaNhomCLS.Name = "bvMaNhomCLS";
            this.bvMaNhomCLS.PositionItem = this.toolStripTextBox1;
            this.bvMaNhomCLS.Size = new System.Drawing.Size(1116, 25);
            this.bvMaNhomCLS.TabIndex = 4;
            this.bvMaNhomCLS.Text = "bindingNavigator1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(33, 22);
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
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRefreshMaNhomCLS
            // 
            this.btnRefreshMaNhomCLS.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshMaNhomCLS.Image")));
            this.btnRefreshMaNhomCLS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshMaNhomCLS.Name = "btnRefreshMaNhomCLS";
            this.btnRefreshMaNhomCLS.Size = new System.Drawing.Size(81, 22);
            this.btnRefreshMaNhomCLS.Text = "Làm mới";
            this.btnRefreshMaNhomCLS.Click += new System.EventHandler(this.btnRefreshMaNhomCLS_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDeleteMaNhomCLS
            // 
            this.btnDeleteMaNhomCLS.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteMaNhomCLS.Image")));
            this.btnDeleteMaNhomCLS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteMaNhomCLS.Name = "btnDeleteMaNhomCLS";
            this.btnDeleteMaNhomCLS.Size = new System.Drawing.Size(51, 22);
            this.btnDeleteMaNhomCLS.Text = "Xoá";
            // 
            // tabDanhMucBieuMau
            // 
            this.tabDanhMucBieuMau.Controls.Add(this.splitContainer1);
            this.tabDanhMucBieuMau.Location = new System.Drawing.Point(4, 22);
            this.tabDanhMucBieuMau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabDanhMucBieuMau.Name = "tabDanhMucBieuMau";
            this.tabDanhMucBieuMau.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabDanhMucBieuMau.Size = new System.Drawing.Size(1172, 0);
            this.tabDanhMucBieuMau.TabIndex = 1;
            this.tabDanhMucBieuMau.Text = "Danh muc biểu mẫu";
            this.tabDanhMucBieuMau.UseVisualStyleBackColor = true;
            // 
            // tabMaySieuAm
            // 
            this.tabMaySieuAm.Controls.Add(this.dtgMaySA);
            this.tabMaySieuAm.Controls.Add(this.panel4);
            this.tabMaySieuAm.Controls.Add(this.bvMaySA);
            this.tabMaySieuAm.Location = new System.Drawing.Point(4, 22);
            this.tabMaySieuAm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabMaySieuAm.Name = "tabMaySieuAm";
            this.tabMaySieuAm.Size = new System.Drawing.Size(1172, 0);
            this.tabMaySieuAm.TabIndex = 2;
            this.tabMaySieuAm.Text = "Máy siêu âm";
            this.tabMaySieuAm.UseVisualStyleBackColor = true;
            // 
            // dtgMaySA
            // 
            this.dtgMaySA.AlignColumns = "";
            this.dtgMaySA.AllignNumberText = false;
            this.dtgMaySA.AllowUserToAddRows = false;
            this.dtgMaySA.AllowUserToDeleteRows = false;
            this.dtgMaySA.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgMaySA.CheckBoldColumn = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgMaySA.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgMaySA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMaySA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dtgMaySA.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(231)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMaySA.DefaultCellStyle = dataGridViewCellStyle8;
            this.dtgMaySA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgMaySA.GridColor = System.Drawing.Color.LightSteelBlue;
            this.dtgMaySA.Location = new System.Drawing.Point(0, 44);
            this.dtgMaySA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgMaySA.MarkOddEven = true;
            this.dtgMaySA.MultiSelect = false;
            this.dtgMaySA.Name = "dtgMaySA";
            this.dtgMaySA.RowHeadersWidth = 20;
            this.dtgMaySA.RowTemplate.Height = 28;
            this.dtgMaySA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgMaySA.Size = new System.Drawing.Size(1172, 0);
            this.dtgMaySA.TabIndex = 7;
            this.dtgMaySA.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgMaySA_DataBindingComplete);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "IDMay";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã máy";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TenMay";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên máy";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnThemMaySA);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.txtTenMaySA);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1172, 44);
            this.panel4.TabIndex = 8;
            // 
            // btnThemMaySA
            // 
            this.btnThemMaySA.BackColor = System.Drawing.Color.Transparent;
            this.btnThemMaySA.BackColorHover = System.Drawing.Color.Empty;
            this.btnThemMaySA.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnThemMaySA.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThemMaySA.BorderRadius = 5;
            this.btnThemMaySA.BorderSize = 1;
            this.btnThemMaySA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemMaySA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMaySA.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMaySA.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThemMaySA.ForeColor = System.Drawing.Color.Black;
            this.btnThemMaySA.Image = ((System.Drawing.Image)(resources.GetObject("btnThemMaySA.Image")));
            this.btnThemMaySA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemMaySA.Location = new System.Drawing.Point(318, 6);
            this.btnThemMaySA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThemMaySA.Name = "btnThemMaySA";
            this.btnThemMaySA.Size = new System.Drawing.Size(109, 27);
            this.btnThemMaySA.TabIndex = 6;
            this.btnThemMaySA.Text = "Thêm mới";
            this.btnThemMaySA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemMaySA.TextColor = System.Drawing.Color.Black;
            this.btnThemMaySA.UseHightLight = true;
            this.btnThemMaySA.UseVisualStyleBackColor = true;
            this.btnThemMaySA.Click += new System.EventHandler(this.btnThemMaySA_Click);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(4, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Tên máy";
            // 
            // txtTenMaySA
            // 
            this.txtTenMaySA.Location = new System.Drawing.Point(85, 9);
            this.txtTenMaySA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenMaySA.Name = "txtTenMaySA";
            this.txtTenMaySA.Size = new System.Drawing.Size(214, 20);
            this.txtTenMaySA.TabIndex = 0;
            this.txtTenMaySA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenMaySA_KeyPress);
            // 
            // bvMaySA
            // 
            this.bvMaySA.AddNewItem = null;
            this.bvMaySA.CountItem = this.toolStripLabel2;
            this.bvMaySA.CountItemFormat = "/ {0}";
            this.bvMaySA.DeleteItem = null;
            this.bvMaySA.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvMaySA.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bvMaySA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripSeparator6,
            this.toolStripTextBox2,
            this.toolStripLabel2,
            this.toolStripSeparator7,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripSeparator8,
            this.toolStripSeparator9,
            this.btnRefreshMayXN,
            this.toolStripSeparator10,
            this.btnDeleteMayXN});
            this.bvMaySA.Location = new System.Drawing.Point(0, -25);
            this.bvMaySA.MoveFirstItem = this.toolStripButton5;
            this.bvMaySA.MoveLastItem = this.toolStripButton8;
            this.bvMaySA.MoveNextItem = this.toolStripButton7;
            this.bvMaySA.MovePreviousItem = this.toolStripButton6;
            this.bvMaySA.Name = "bvMaySA";
            this.bvMaySA.PositionItem = this.toolStripTextBox2;
            this.bvMaySA.Size = new System.Drawing.Size(1172, 25);
            this.bvMaySA.TabIndex = 6;
            this.bvMaySA.Text = "bindingNavigator1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(33, 22);
            this.toolStripLabel2.Text = "/ {0}";
            this.toolStripLabel2.ToolTipText = "Total number of items";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.RightToLeftAutoMirrorImage = true;
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "Move first";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.RightToLeftAutoMirrorImage = true;
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "Move previous";
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
            this.toolStripTextBox2.Size = new System.Drawing.Size(44, 23);
            this.toolStripTextBox2.Text = "0";
            this.toolStripTextBox2.ToolTipText = "Current position";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.RightToLeftAutoMirrorImage = true;
            this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton7.Text = "Move next";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.RightToLeftAutoMirrorImage = true;
            this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton8.Text = "Move last";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRefreshMayXN
            // 
            this.btnRefreshMayXN.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshMayXN.Image")));
            this.btnRefreshMayXN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshMayXN.Name = "btnRefreshMayXN";
            this.btnRefreshMayXN.Size = new System.Drawing.Size(81, 22);
            this.btnRefreshMayXN.Text = "Làm mới";
            this.btnRefreshMayXN.Click += new System.EventHandler(this.btnRefreshMayXN_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDeleteMayXN
            // 
            this.btnDeleteMayXN.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteMayXN.Image")));
            this.btnDeleteMayXN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteMayXN.Name = "btnDeleteMayXN";
            this.btnDeleteMayXN.Size = new System.Drawing.Size(51, 22);
            this.btnDeleteMayXN.Text = "Xoá";
            this.btnDeleteMayXN.Click += new System.EventHandler(this.btnDeleteMayXN_Click);
            // 
            // frmDMCLS_SieuAm
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(129)))), ((int)(((byte)(176)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1134, 661);
            this.Name = "frmDMCLS_SieuAm";
            this.Text = "Biểu mẫu siêu âm";
            this.Load += new System.EventHandler(this.frmDMCLS_SieuAm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnContaint)).EndInit();
            this.pnContaint.ResumeLayout(false);
            this.pnLabel.ResumeLayout(false);
            this.pnLabel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnMenu)).EndInit();
            this.pnMenu.ResumeLayout(false);
            this.xtraScrollableControlMain.ResumeLayout(false);
            this.xtraScrollableControlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnFormControl)).EndInit();
            this.pnFormControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1.Panel1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1.Panel2)).EndInit();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBieuMau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvBieuMau)).EndInit();
            this.bvBieuMau.ResumeLayout(false);
            this.bvBieuMau.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2.Panel1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2.Panel2)).EndInit();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel3)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabNhom.ResumeLayout(false);
            this.tabNhom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMaNhomCLS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvMaNhomCLS)).EndInit();
            this.bvMaNhomCLS.ResumeLayout(false);
            this.bvMaNhomCLS.PerformLayout();
            this.tabDanhMucBieuMau.ResumeLayout(false);
            this.tabMaySieuAm.ResumeLayout(false);
            this.tabMaySieuAm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMaySA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel4)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bvMaySA)).EndInit();
            this.bvMaySA.ResumeLayout(false);
            this.bvMaySA.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainer1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer2;
        private System.Windows.Forms.TextBox txtSoTrangMota;
        private DevExpress.XtraEditors.LabelControl label8;
        private System.Windows.Forms.TextBox txtSLHinh;
        private DevExpress.XtraEditors.LabelControl label7;
        private System.Windows.Forms.TextBox txtGioiTinh;
        private DevExpress.XtraEditors.LabelControl label6;
        private System.Windows.Forms.TextBox txtDeNghi;
        private DevExpress.XtraEditors.LabelControl label5;
        private System.Windows.Forms.TextBox txtTenChiDinh;
        private DevExpress.XtraEditors.LabelControl label4;
        private DevExpress.XtraEditors.LabelControl label3;
        private System.Windows.Forms.TextBox txtTieuDePhieuIn;
        private DevExpress.XtraEditors.LabelControl label2;
        private TPH.Controls.TPHNormalButton tnXoaMau;
        private TPH.Controls.TPHNormalButton btnSuaMau;
        private System.Windows.Forms.TextBox txtTenBieuMau;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.PanelControl panel2;
        private DevExpress.XtraEditors.PanelControl panel1;
        private DevExpress.XtraEditors.LabelControl label9;
        private DevExpress.XtraEditors.LabelControl label10;
        private TPH.Controls.TPHNormalButton btnAddMauSieuAm;
        private RicherTextBox.RicherTextBox ricTrang2;
        private CustomBindingNavigator bvBieuMau;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private TPH.Controls.TPHNormalButton btnSave;
        private System.Windows.Forms.TextBox txtGoTat;
        private DevExpress.XtraEditors.LabelControl label11;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.LabelControl lblSex;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabNhom;
        private System.Windows.Forms.TabPage tabDanhMucBieuMau;
        private DevExpress.XtraEditors.PanelControl panel3;
        private CustomBindingNavigator bvMaNhomCLS;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnRefreshMaNhomCLS;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnDeleteMaNhomCLS;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhomCLS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhomCLS;
        private CustomComboBox cboNhomSieuAm;
        private System.Windows.Forms.TabPage tabMaySieuAm;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private CustomBindingNavigator bvMaySA;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton btnRefreshMayXN;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton btnDeleteMayXN;
        private DevExpress.XtraEditors.PanelControl panel4;
        private DevExpress.XtraEditors.LabelControl label12;
        private System.Windows.Forms.TextBox txtTenMaySA;
        private TPH.Controls.TPHNormalButton btnThemMaySA;
        private RicherTextBox.RicherTextBox ricKetLuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSoMau;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoTat;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMauSieuAm;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuDePhieuKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiTinhSuDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChanDoanMacDinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn KetluanMacDinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeNghi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongHinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTrangIn;
        private CustomDatagridView dtgBieuMau;
        private CustomDatagridView dtgMaNhomCLS;
        private CustomDatagridView dtgMaySA;
        private System.Windows.Forms.ToolStripButton btnLoadBieuMau;
        private RicherTextBox.RicherTextBox ricTrang1;
    }
}