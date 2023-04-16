using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.CauHinh.DanhMucCLS
{
    partial class frmDMCLS_NoiSoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMCLS_NoiSoi));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panel2 = new DevExpress.XtraEditors.PanelControl();
            this.dtgBieuMau = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.MaSoMau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoTat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMauNoiSoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.txtsearch = new System.Windows.Forms.ToolStripTextBox();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSave = new TPH.Controls.TPHNormalButton();
            this.btnAddMauNoiSoi = new TPH.Controls.TPHNormalButton();
            this.tnXoaMau = new TPH.Controls.TPHNormalButton();
            this.btnSuaMau = new TPH.Controls.TPHNormalButton();
            this.splitContainer2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ricTrang1 = new RicherTextBox.RicherTextBox();
            this.panel3 = new DevExpress.XtraEditors.PanelControl();
            this.ricKetLuan = new RicherTextBox.RicherTextBox();
            this.cboNhomNoiSoi = new TPH.LIS.Common.Controls.CustomComboBox();
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
            this.tabDMNoiSoi = new System.Windows.Forms.TabControl();
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
            this.tabMayNoiSoi = new System.Windows.Forms.TabPage();
            this.dtgMayNS = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new DevExpress.XtraEditors.PanelControl();
            this.btnThemMayNS = new TPH.Controls.TPHNormalButton();
            this.label12 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenMayNS = new System.Windows.Forms.TextBox();
            this.bvMayNS = new TPH.LIS.Common.Controls.CustomBindingNavigator();
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
            this.tabKyThuat = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.bvKyThuat = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnXoaKyThuatHP = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLamMoiKyThuatHP = new System.Windows.Forms.ToolStripButton();
            this.dtgKyThuat = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.MaKyThuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKyThuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bvKetQua = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.btnXoaKetQuaHP = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLamMoiKetQuaHP = new System.Windows.Forms.ToolStripButton();
            this.dtgKetQua = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.tabDMNoiSoi.SuspendLayout();
            this.tabNhom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMaNhomCLS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvMaNhomCLS)).BeginInit();
            this.bvMaNhomCLS.SuspendLayout();
            this.tabDanhMucBieuMau.SuspendLayout();
            this.tabMayNoiSoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMayNS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel4)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bvMayNS)).BeginInit();
            this.bvMayNS.SuspendLayout();
            this.tabKyThuat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3.Panel1)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3.Panel2)).BeginInit();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bvKyThuat)).BeginInit();
            this.bvKyThuat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgKyThuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvKetQua)).BeginInit();
            this.bvKetQua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgKetQua)).BeginInit();
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
            this.lblTitle.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 18, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(234, 37);
            this.lblTitle.Text = "DANH MỤC BIỂU MẪU NỘI SOI";
            // 
            // pnContaint
            // 
            this.pnContaint.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnContaint.Appearance.Options.UseBackColor = true;
            this.pnContaint.Controls.Add(this.tabDMNoiSoi);
            this.pnContaint.Location = new System.Drawing.Point(0, 30);
            this.pnContaint.Margin = new System.Windows.Forms.Padding(0);
            this.pnContaint.Padding = new System.Windows.Forms.Padding(0);
            this.pnContaint.Size = new System.Drawing.Size(1336, 738);
            // 
            // pnLabel
            // 
            this.pnLabel.Margin = new System.Windows.Forms.Padding(41, 12, 41, 12);
            this.pnLabel.Padding = new System.Windows.Forms.Padding(55, 48, 55, 12);
            this.pnLabel.Size = new System.Drawing.Size(1336, 10);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Crimson;
            this.btnClose.Location = new System.Drawing.Point(929, 48);
            this.btnClose.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.btnClose.Size = new System.Drawing.Size(29, 0);
            this.btnClose.TextColor = System.Drawing.Color.Crimson;
            // 
            // lblMainESC
            // 
            this.lblMainESC.Appearance.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainESC.Appearance.Options.UseFont = true;
            this.lblMainESC.ImageOptions.Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lblMainESC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblMainESC.ImageOptions.Image")));
            this.lblMainESC.Location = new System.Drawing.Point(958, 48);
            this.lblMainESC.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            // 
            // pnMenu
            // 
            this.pnMenu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnMenu.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnMenu.Appearance.Options.UseBackColor = true;
            this.pnMenu.Location = new System.Drawing.Point(0, 10);
            this.pnMenu.Size = new System.Drawing.Size(1336, 20);
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.xtraScrollableControlMain.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(1336, 19);
            // 
            // ucGroupHeaderChonMain
            // 
            this.ucGroupHeaderChonMain.Location = new System.Drawing.Point(236, 1);
            this.ucGroupHeaderChonMain.Size = new System.Drawing.Size(10, 18);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnFormControl.Appearance.Options.UseBackColor = true;
            this.pnFormControl.Location = new System.Drawing.Point(1228, 1);
            this.pnFormControl.Size = new System.Drawing.Size(106, 18);
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
            this.splitContainer1.Location = new System.Drawing.Point(41, 18);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
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
            this.splitContainer1.Size = new System.Drawing.Size(16038, 520);
            this.splitContainer1.SplitterPosition = 4635;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgBieuMau);
            this.panel2.Controls.Add(this.bvBieuMau);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 210);
            this.panel2.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(4635, 310);
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
            this.TenMauNoiSoi,
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
            this.dtgBieuMau.Location = new System.Drawing.Point(2, 2);
            this.dtgBieuMau.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.dtgBieuMau.MarkOddEven = true;
            this.dtgBieuMau.MultiSelect = false;
            this.dtgBieuMau.Name = "dtgBieuMau";
            this.dtgBieuMau.RowHeadersVisible = false;
            this.dtgBieuMau.RowHeadersWidth = 20;
            this.dtgBieuMau.RowTemplate.Height = 28;
            this.dtgBieuMau.Size = new System.Drawing.Size(4631, 281);
            this.dtgBieuMau.TabIndex = 0;
            // 
            // MaSoMau
            // 
            this.MaSoMau.DataPropertyName = "MaSoMauNoiSoi";
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
            // TenMauNoiSoi
            // 
            this.TenMauNoiSoi.DataPropertyName = "TenMauNoiSoi";
            this.TenMauNoiSoi.HeaderText = "Tên mẫu nội soi";
            this.TenMauNoiSoi.Name = "TenMauNoiSoi";
            this.TenMauNoiSoi.Width = 200;
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
            this.ChanDoanMacDinh.Visible = false;
            this.ChanDoanMacDinh.Width = 250;
            // 
            // KetluanMacDinh
            // 
            this.KetluanMacDinh.DataPropertyName = "KetluanMacDinh";
            this.KetluanMacDinh.HeaderText = "Kết luận mặc định";
            this.KetluanMacDinh.Name = "KetluanMacDinh";
            this.KetluanMacDinh.Visible = false;
            this.KetluanMacDinh.Width = 200;
            // 
            // DeNghi
            // 
            this.DeNghi.DataPropertyName = "DeNghi";
            this.DeNghi.HeaderText = "Đề nghị";
            this.DeNghi.Name = "DeNghi";
            this.DeNghi.Visible = false;
            this.DeNghi.Width = 150;
            // 
            // SoLuongHinh
            // 
            this.SoLuongHinh.DataPropertyName = "SoLuongHinh";
            dataGridViewCellStyle4.Format = "N0";
            this.SoLuongHinh.DefaultCellStyle = dataGridViewCellStyle4;
            this.SoLuongHinh.HeaderText = "SL hình";
            this.SoLuongHinh.Name = "SoLuongHinh";
            this.SoLuongHinh.Visible = false;
            // 
            // SoTrangIn
            // 
            this.SoTrangIn.DataPropertyName = "SoTrangIn";
            dataGridViewCellStyle5.Format = "N0";
            this.SoTrangIn.DefaultCellStyle = dataGridViewCellStyle5;
            this.SoTrangIn.HeaderText = "Số trang";
            this.SoTrangIn.Name = "SoTrangIn";
            this.SoTrangIn.Visible = false;
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
            this.txtsearch});
            this.bvBieuMau.Location = new System.Drawing.Point(2, 283);
            this.bvBieuMau.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bvBieuMau.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bvBieuMau.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bvBieuMau.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bvBieuMau.Name = "bvBieuMau";
            this.bvBieuMau.Padding = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.bvBieuMau.PositionItem = this.bindingNavigatorPositionItem;
            this.bvBieuMau.Size = new System.Drawing.Size(4631, 25);
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(553, 23);
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
            // txtsearch
            // 
            this.txtsearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(1156, 25);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnAddMauNoiSoi);
            this.panel1.Controls.Add(this.tnXoaMau);
            this.panel1.Controls.Add(this.btnSuaMau);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(4635, 210);
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
            this.btnSave.Location = new System.Drawing.Point(2565, 36);
            this.btnSave.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(905, 138);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Lưu";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextColor = System.Drawing.Color.Black;
            this.btnSave.UseHightLight = true;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddMauNoiSoi
            // 
            this.btnAddMauNoiSoi.BackColor = System.Drawing.Color.Transparent;
            this.btnAddMauNoiSoi.BackColorHover = System.Drawing.Color.Empty;
            this.btnAddMauNoiSoi.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnAddMauNoiSoi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnAddMauNoiSoi.BorderRadius = 5;
            this.btnAddMauNoiSoi.BorderSize = 1;
            this.btnAddMauNoiSoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddMauNoiSoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMauNoiSoi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMauNoiSoi.ForceColorHover = System.Drawing.Color.Empty;
            this.btnAddMauNoiSoi.ForeColor = System.Drawing.Color.Black;
            this.btnAddMauNoiSoi.Image = ((System.Drawing.Image)(resources.GetObject("btnAddMauNoiSoi.Image")));
            this.btnAddMauNoiSoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddMauNoiSoi.Location = new System.Drawing.Point(96, 36);
            this.btnAddMauNoiSoi.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.btnAddMauNoiSoi.Name = "btnAddMauNoiSoi";
            this.btnAddMauNoiSoi.Size = new System.Drawing.Size(1399, 138);
            this.btnAddMauNoiSoi.TabIndex = 19;
            this.btnAddMauNoiSoi.Text = "Thêm mới";
            this.btnAddMauNoiSoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddMauNoiSoi.TextColor = System.Drawing.Color.Black;
            this.btnAddMauNoiSoi.UseHightLight = true;
            this.btnAddMauNoiSoi.UseVisualStyleBackColor = true;
            this.btnAddMauNoiSoi.Click += new System.EventHandler(this.btnAddMauNoiSoi_Click);
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
            this.tnXoaMau.Location = new System.Drawing.Point(3552, 36);
            this.tnXoaMau.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.tnXoaMau.Name = "tnXoaMau";
            this.tnXoaMau.Size = new System.Drawing.Size(905, 138);
            this.tnXoaMau.TabIndex = 4;
            this.tnXoaMau.Text = "Xóa";
            this.tnXoaMau.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tnXoaMau.TextColor = System.Drawing.Color.Black;
            this.tnXoaMau.UseHightLight = true;
            this.tnXoaMau.UseVisualStyleBackColor = true;
            // 
            // btnSuaMau
            // 
            this.btnSuaMau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSuaMau.BackColorHover = System.Drawing.Color.Empty;
            this.btnSuaMau.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSuaMau.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnSuaMau.BorderRadius = 5;
            this.btnSuaMau.BorderSize = 1;
            this.btnSuaMau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaMau.FlatAppearance.BorderSize = 0;
            this.btnSuaMau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaMau.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnSuaMau.ForceColorHover = System.Drawing.Color.Empty;
            this.btnSuaMau.ForeColor = System.Drawing.Color.Black;
            this.btnSuaMau.Image = ((System.Drawing.Image)(resources.GetObject("btnSuaMau.Image")));
            this.btnSuaMau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaMau.Location = new System.Drawing.Point(1577, 36);
            this.btnSuaMau.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.btnSuaMau.Name = "btnSuaMau";
            this.btnSuaMau.Size = new System.Drawing.Size(905, 138);
            this.btnSuaMau.TabIndex = 3;
            this.btnSuaMau.Text = "Sửa";
            this.btnSuaMau.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuaMau.TextColor = System.Drawing.Color.Black;
            this.btnSuaMau.UseHightLight = true;
            this.btnSuaMau.UseVisualStyleBackColor = false;
            this.btnSuaMau.Click += new System.EventHandler(this.btnSuaMau_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
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
            this.splitContainer2.Size = new System.Drawing.Size(11393, 520);
            this.splitContainer2.SplitterPosition = 4553;
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
            this.ricTrang1.Location = new System.Drawing.Point(0, 1584);
            this.ricTrang1.Margin = new System.Windows.Forms.Padding(55, 24, 55, 24);
            this.ricTrang1.Name = "ricTrang1";
            this.ricTrang1.OutdentVisible = false;
            this.ricTrang1.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset20" +
    "4 Microsoft Sans Serif;}}\r\n{\\*\\generator Riched20 10.0.22621}\\viewkind4\\uc1 \r\n\\p" +
    "ard\\f0\\fs18\\lang1049\\par\r\n}\r\n";
            this.ricTrang1.SaveVisible = false;
            this.ricTrang1.SeparatorAlignVisible = false;
            this.ricTrang1.SeparatorBoldUnderlineItalicVisible = false;
            this.ricTrang1.SeparatorFontColorVisible = false;
            this.ricTrang1.SeparatorFontVisible = false;
            this.ricTrang1.SeparatorIndentAndBulletsVisible = false;
            this.ricTrang1.SeparatorInsertVisible = false;
            this.ricTrang1.SeparatorSaveLoadVisible = false;
            this.ricTrang1.Size = new System.Drawing.Size(4553, 0);
            this.ricTrang1.TabIndex = 1;
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
            this.panel3.Controls.Add(this.cboNhomNoiSoi);
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
            this.panel3.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(4553, 1584);
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
            this.ricKetLuan.Location = new System.Drawing.Point(987, 630);
            this.ricKetLuan.Margin = new System.Windows.Forms.Padding(55, 30, 55, 30);
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
            this.ricKetLuan.Size = new System.Drawing.Size(3511, 786);
            this.ricKetLuan.TabIndex = 25;
            this.ricKetLuan.ToolStripVisible = false;
            this.ricKetLuan.UnderlineVisible = false;
            this.ricKetLuan.WordWrapVisible = false;
            this.ricKetLuan.ZoomFactorTextVisible = false;
            this.ricKetLuan.ZoomInVisible = false;
            this.ricKetLuan.ZoomOutVisible = false;
            // 
            // cboNhomNoiSoi
            // 
            this.cboNhomNoiSoi.AutoComplete = false;
            this.cboNhomNoiSoi.AutoDropdown = false;
            this.cboNhomNoiSoi.BackColorEven = System.Drawing.Color.White;
            this.cboNhomNoiSoi.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboNhomNoiSoi.ColumnNames = "MaNhomNoiSoi,TenNhomNoiSoi";
            this.cboNhomNoiSoi.ColumnWidthDefault = 75;
            this.cboNhomNoiSoi.ColumnWidths = "35,150";
            this.cboNhomNoiSoi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboNhomNoiSoi.FormattingEnabled = true;
            this.cboNhomNoiSoi.LinkedColumnIndex = 0;
            this.cboNhomNoiSoi.LinkedColumnIndex1 = 0;
            this.cboNhomNoiSoi.LinkedColumnIndex2 = 0;
            this.cboNhomNoiSoi.LinkedTextBox = null;
            this.cboNhomNoiSoi.LinkedTextBox1 = null;
            this.cboNhomNoiSoi.LinkedTextBox2 = null;
            this.cboNhomNoiSoi.Location = new System.Drawing.Point(1673, 12);
            this.cboNhomNoiSoi.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.cboNhomNoiSoi.Name = "cboNhomNoiSoi";
            this.cboNhomNoiSoi.Size = new System.Drawing.Size(2185, 21);
            this.cboNhomNoiSoi.TabIndex = 24;
            this.cboNhomNoiSoi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboNhomNoiSoi_KeyPress);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(2345, 474);
            this.lblSex.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
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
            this.label9.Location = new System.Drawing.Point(2, 1566);
            this.label9.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "NỘI DUNG ";
            // 
            // txtSoTrangMota
            // 
            this.txtSoTrangMota.BackColor = System.Drawing.Color.White;
            this.txtSoTrangMota.Location = new System.Drawing.Point(6665, 294);
            this.txtSoTrangMota.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.txtSoTrangMota.MaxLength = 1;
            this.txtSoTrangMota.Name = "txtSoTrangMota";
            this.txtSoTrangMota.ReadOnly = true;
            this.txtSoTrangMota.Size = new System.Drawing.Size(525, 20);
            this.txtSoTrangMota.TabIndex = 18;
            this.txtSoTrangMota.Visible = false;
            this.txtSoTrangMota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoTrangMota_KeyPress);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6624, 180);
            this.label8.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Số mô tả";
            this.label8.Visible = false;
            // 
            // txtGoTat
            // 
            this.txtGoTat.BackColor = System.Drawing.Color.White;
            this.txtGoTat.Location = new System.Drawing.Point(4869, 12);
            this.txtGoTat.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.txtGoTat.MaxLength = 20;
            this.txtGoTat.Name = "txtGoTat";
            this.txtGoTat.ReadOnly = true;
            this.txtGoTat.Size = new System.Drawing.Size(1677, 20);
            this.txtGoTat.TabIndex = 22;
            this.txtGoTat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGoTat_KeyPress);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(4224, 36);
            this.label11.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
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
            this.txtDeNghi.Location = new System.Drawing.Point(4265, 456);
            this.txtDeNghi.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.txtDeNghi.Name = "txtDeNghi";
            this.txtDeNghi.ReadOnly = true;
            this.txtDeNghi.Size = new System.Drawing.Size(182, 20);
            this.txtDeNghi.TabIndex = 12;
            this.txtDeNghi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDeNghi_KeyPress);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3429, 474);
            this.label5.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Đề nghị";
            // 
            // txtSLHinh
            // 
            this.txtSLHinh.BackColor = System.Drawing.Color.White;
            this.txtSLHinh.Location = new System.Drawing.Point(7447, 12);
            this.txtSLHinh.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.txtSLHinh.MaxLength = 1;
            this.txtSLHinh.Name = "txtSLHinh";
            this.txtSLHinh.ReadOnly = true;
            this.txtSLHinh.Size = new System.Drawing.Size(443, 20);
            this.txtSLHinh.TabIndex = 16;
            this.txtSLHinh.Text = "2";
            this.txtSLHinh.Visible = false;
            this.txtSLHinh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSLHinh_KeyPress);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6994, 36);
            this.label7.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Số lượng hình";
            this.label7.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(151, 588);
            this.label3.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
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
            this.txtTenBieuMau.Location = new System.Drawing.Point(1673, 168);
            this.txtTenBieuMau.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.txtTenBieuMau.Name = "txtTenBieuMau";
            this.txtTenBieuMau.ReadOnly = true;
            this.txtTenBieuMau.Size = new System.Drawing.Size(2774, 20);
            this.txtTenBieuMau.TabIndex = 1;
            this.txtTenBieuMau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenBieuMau_KeyPress);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(151, 192);
            this.label1.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên biểu mẫu";
            // 
            // txtTenChiDinh
            // 
            this.txtTenChiDinh.BackColor = System.Drawing.Color.White;
            this.txtTenChiDinh.Location = new System.Drawing.Point(6747, 294);
            this.txtTenChiDinh.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.txtTenChiDinh.Name = "txtTenChiDinh";
            this.txtTenChiDinh.ReadOnly = true;
            this.txtTenChiDinh.Size = new System.Drawing.Size(772, 20);
            this.txtTenChiDinh.TabIndex = 10;
            this.txtTenChiDinh.Visible = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(151, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nhóm nội soi";
            // 
            // txtGioiTinh
            // 
            this.txtGioiTinh.BackColor = System.Drawing.Color.White;
            this.txtGioiTinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGioiTinh.Location = new System.Drawing.Point(1769, 456);
            this.txtGioiTinh.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.txtGioiTinh.MaxLength = 1;
            this.txtGioiTinh.Name = "txtGioiTinh";
            this.txtGioiTinh.ReadOnly = true;
            this.txtGioiTinh.Size = new System.Drawing.Size(443, 20);
            this.txtGioiTinh.TabIndex = 14;
            this.txtGioiTinh.TextChanged += new System.EventHandler(this.txtGioiTinh_TextChanged);
            this.txtGioiTinh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGioiTinh_KeyPress);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(151, 474);
            this.label6.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
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
            this.txtTieuDePhieuIn.Location = new System.Drawing.Point(1673, 312);
            this.txtTieuDePhieuIn.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.txtTieuDePhieuIn.Name = "txtTieuDePhieuIn";
            this.txtTieuDePhieuIn.ReadOnly = true;
            this.txtTieuDePhieuIn.Size = new System.Drawing.Size(2774, 20);
            this.txtTieuDePhieuIn.TabIndex = 6;
            this.txtTieuDePhieuIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTieuDePhieuIn_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(151, 336);
            this.label2.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
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
            this.ricTrang2.Margin = new System.Windows.Forms.Padding(55, 30, 55, 30);
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
            this.ricTrang2.Size = new System.Drawing.Size(6830, 502);
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
            this.label10.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
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
            // tabDMNoiSoi
            // 
            this.tabDMNoiSoi.Controls.Add(this.tabNhom);
            this.tabDMNoiSoi.Controls.Add(this.tabDanhMucBieuMau);
            this.tabDMNoiSoi.Controls.Add(this.tabMayNoiSoi);
            this.tabDMNoiSoi.Controls.Add(this.tabKyThuat);
            this.tabDMNoiSoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDMNoiSoi.Location = new System.Drawing.Point(0, 0);
            this.tabDMNoiSoi.Margin = new System.Windows.Forms.Padding(0);
            this.tabDMNoiSoi.Name = "tabDMNoiSoi";
            this.tabDMNoiSoi.SelectedIndex = 0;
            this.tabDMNoiSoi.Size = new System.Drawing.Size(1336, 738);
            this.tabDMNoiSoi.TabIndex = 2;
            // 
            // tabNhom
            // 
            this.tabNhom.Controls.Add(this.dtgMaNhomCLS);
            this.tabNhom.Controls.Add(this.bvMaNhomCLS);
            this.tabNhom.Location = new System.Drawing.Point(4, 22);
            this.tabNhom.Margin = new System.Windows.Forms.Padding(0);
            this.tabNhom.Name = "tabNhom";
            this.tabNhom.Size = new System.Drawing.Size(1328, 712);
            this.tabNhom.TabIndex = 0;
            this.tabNhom.Text = "Nhóm nội soi";
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
            this.dtgMaNhomCLS.Location = new System.Drawing.Point(0, 0);
            this.dtgMaNhomCLS.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.dtgMaNhomCLS.MarkOddEven = true;
            this.dtgMaNhomCLS.MultiSelect = false;
            this.dtgMaNhomCLS.Name = "dtgMaNhomCLS";
            this.dtgMaNhomCLS.RowHeadersWidth = 20;
            this.dtgMaNhomCLS.RowTemplate.Height = 28;
            this.dtgMaNhomCLS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgMaNhomCLS.Size = new System.Drawing.Size(1328, 687);
            this.dtgMaNhomCLS.TabIndex = 5;
            this.dtgMaNhomCLS.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgMaNhomCLS_DataBindingComplete);
            // 
            // MaNhomCLS
            // 
            this.MaNhomCLS.DataPropertyName = "MaNhomNoiSoi";
            this.MaNhomCLS.HeaderText = "Mã nhóm";
            this.MaNhomCLS.Name = "MaNhomCLS";
            // 
            // TenNhomCLS
            // 
            this.TenNhomCLS.DataPropertyName = "TenNhomNoiSoi";
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
            this.bvMaNhomCLS.Location = new System.Drawing.Point(0, 687);
            this.bvMaNhomCLS.MoveFirstItem = this.toolStripButton1;
            this.bvMaNhomCLS.MoveLastItem = this.toolStripButton4;
            this.bvMaNhomCLS.MoveNextItem = this.toolStripButton3;
            this.bvMaNhomCLS.MovePreviousItem = this.toolStripButton2;
            this.bvMaNhomCLS.Name = "bvMaNhomCLS";
            this.bvMaNhomCLS.Padding = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.bvMaNhomCLS.PositionItem = this.toolStripTextBox1;
            this.bvMaNhomCLS.Size = new System.Drawing.Size(1328, 25);
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
            this.toolStripTextBox1.Size = new System.Drawing.Size(553, 23);
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
            this.tabDanhMucBieuMau.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.tabDanhMucBieuMau.Name = "tabDanhMucBieuMau";
            this.tabDanhMucBieuMau.Padding = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.tabDanhMucBieuMau.Size = new System.Drawing.Size(16120, 556);
            this.tabDanhMucBieuMau.TabIndex = 1;
            this.tabDanhMucBieuMau.Text = "Danh muc biểu mẫu";
            this.tabDanhMucBieuMau.UseVisualStyleBackColor = true;
            // 
            // tabMayNoiSoi
            // 
            this.tabMayNoiSoi.Controls.Add(this.dtgMayNS);
            this.tabMayNoiSoi.Controls.Add(this.panel4);
            this.tabMayNoiSoi.Controls.Add(this.bvMayNS);
            this.tabMayNoiSoi.Location = new System.Drawing.Point(4, 22);
            this.tabMayNoiSoi.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.tabMayNoiSoi.Name = "tabMayNoiSoi";
            this.tabMayNoiSoi.Size = new System.Drawing.Size(16120, 556);
            this.tabMayNoiSoi.TabIndex = 2;
            this.tabMayNoiSoi.Text = "Máy nội soi";
            this.tabMayNoiSoi.UseVisualStyleBackColor = true;
            // 
            // dtgMayNS
            // 
            this.dtgMayNS.AlignColumns = "";
            this.dtgMayNS.AllignNumberText = false;
            this.dtgMayNS.AllowUserToAddRows = false;
            this.dtgMayNS.AllowUserToDeleteRows = false;
            this.dtgMayNS.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgMayNS.CheckBoldColumn = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgMayNS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgMayNS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMayNS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dtgMayNS.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(231)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMayNS.DefaultCellStyle = dataGridViewCellStyle8;
            this.dtgMayNS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgMayNS.GridColor = System.Drawing.Color.LightSteelBlue;
            this.dtgMayNS.Location = new System.Drawing.Point(0, 258);
            this.dtgMayNS.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.dtgMayNS.MarkOddEven = true;
            this.dtgMayNS.MultiSelect = false;
            this.dtgMayNS.Name = "dtgMayNS";
            this.dtgMayNS.RowHeadersWidth = 20;
            this.dtgMayNS.RowTemplate.Height = 28;
            this.dtgMayNS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgMayNS.Size = new System.Drawing.Size(16120, 273);
            this.dtgMayNS.TabIndex = 7;
            this.dtgMayNS.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgMayNS_DataBindingComplete);
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
            this.panel4.Controls.Add(this.btnThemMayNS);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.txtTenMayNS);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(16120, 258);
            this.panel4.TabIndex = 8;
            // 
            // btnThemMayNS
            // 
            this.btnThemMayNS.BackColor = System.Drawing.Color.Transparent;
            this.btnThemMayNS.BackColorHover = System.Drawing.Color.Empty;
            this.btnThemMayNS.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnThemMayNS.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThemMayNS.BorderRadius = 5;
            this.btnThemMayNS.BorderSize = 1;
            this.btnThemMayNS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemMayNS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMayNS.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMayNS.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThemMayNS.ForeColor = System.Drawing.Color.Black;
            this.btnThemMayNS.Image = ((System.Drawing.Image)(resources.GetObject("btnThemMayNS.Image")));
            this.btnThemMayNS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemMayNS.Location = new System.Drawing.Point(4361, 36);
            this.btnThemMayNS.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.btnThemMayNS.Name = "btnThemMayNS";
            this.btnThemMayNS.Size = new System.Drawing.Size(1509, 156);
            this.btnThemMayNS.TabIndex = 6;
            this.btnThemMayNS.Text = "Thêm mới";
            this.btnThemMayNS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemMayNS.TextColor = System.Drawing.Color.Black;
            this.btnThemMayNS.UseHightLight = true;
            this.btnThemMayNS.UseVisualStyleBackColor = true;
            this.btnThemMayNS.Click += new System.EventHandler(this.btnThemMayNS_Click);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(55, 72);
            this.label12.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Tên máy";
            // 
            // txtTenMayNS
            // 
            this.txtTenMayNS.Location = new System.Drawing.Point(905, 54);
            this.txtTenMayNS.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.txtTenMayNS.Name = "txtTenMayNS";
            this.txtTenMayNS.Size = new System.Drawing.Size(3145, 20);
            this.txtTenMayNS.TabIndex = 0;
            this.txtTenMayNS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenMayNS_KeyPress);
            // 
            // bvMayNS
            // 
            this.bvMayNS.AddNewItem = null;
            this.bvMayNS.CountItem = this.toolStripLabel2;
            this.bvMayNS.CountItemFormat = "/ {0}";
            this.bvMayNS.DeleteItem = null;
            this.bvMayNS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvMayNS.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bvMayNS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bvMayNS.Location = new System.Drawing.Point(0, 531);
            this.bvMayNS.MoveFirstItem = this.toolStripButton5;
            this.bvMayNS.MoveLastItem = this.toolStripButton8;
            this.bvMayNS.MoveNextItem = this.toolStripButton7;
            this.bvMayNS.MovePreviousItem = this.toolStripButton6;
            this.bvMayNS.Name = "bvMayNS";
            this.bvMayNS.Padding = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.bvMayNS.PositionItem = this.toolStripTextBox2;
            this.bvMayNS.Size = new System.Drawing.Size(16120, 25);
            this.bvMayNS.TabIndex = 6;
            this.bvMayNS.Text = "bindingNavigator1";
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
            this.toolStripTextBox2.Size = new System.Drawing.Size(553, 23);
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
            // tabKyThuat
            // 
            this.tabKyThuat.Controls.Add(this.splitContainer3);
            this.tabKyThuat.Location = new System.Drawing.Point(4, 22);
            this.tabKyThuat.Margin = new System.Windows.Forms.Padding(41, 12, 41, 12);
            this.tabKyThuat.Name = "tabKyThuat";
            this.tabKyThuat.Padding = new System.Windows.Forms.Padding(41, 12, 41, 12);
            this.tabKyThuat.Size = new System.Drawing.Size(16120, 556);
            this.tabKyThuat.TabIndex = 3;
            this.tabKyThuat.Text = "Kỹ thuật tìm HP - Kết quả";
            this.tabKyThuat.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(41, 12);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(41, 12, 41, 12);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.bvKyThuat);
            this.splitContainer3.Panel1.Controls.Add(this.dtgKyThuat);
            this.splitContainer3.Panel1.Padding = new System.Windows.Forms.Padding(41, 12, 41, 12);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.bvKetQua);
            this.splitContainer3.Panel2.Controls.Add(this.dtgKetQua);
            this.splitContainer3.Panel2.Padding = new System.Windows.Forms.Padding(41, 12, 41, 12);
            this.splitContainer3.Size = new System.Drawing.Size(16038, 532);
            this.splitContainer3.SplitterPosition = 7365;
            this.splitContainer3.TabIndex = 0;
            // 
            // bvKyThuat
            // 
            this.bvKyThuat.AddNewItem = null;
            this.bvKyThuat.CountItem = this.bindingNavigatorCountItem1;
            this.bvKyThuat.CountItemFormat = "/ {0}";
            this.bvKyThuat.DeleteItem = null;
            this.bvKyThuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvKyThuat.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvKyThuat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1,
            this.bindingNavigatorSeparator5,
            this.btnXoaKyThuatHP,
            this.toolStripSeparator15,
            this.btnLamMoiKyThuatHP});
            this.bvKyThuat.Location = new System.Drawing.Point(41, 495);
            this.bvKyThuat.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.bvKyThuat.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.bvKyThuat.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.bvKyThuat.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.bvKyThuat.Name = "bvKyThuat";
            this.bvKyThuat.Padding = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.bvKyThuat.PositionItem = this.bindingNavigatorPositionItem1;
            this.bvKyThuat.Size = new System.Drawing.Size(7283, 25);
            this.bvKyThuat.TabIndex = 1;
            this.bvKyThuat.Text = "CustomBindingNavigator1";
            // 
            // bindingNavigatorCountItem1
            // 
            this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
            this.bindingNavigatorCountItem1.Size = new System.Drawing.Size(30, 22);
            this.bindingNavigatorCountItem1.Text = "/ {0}";
            this.bindingNavigatorCountItem1.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem1.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem1.Text = "Move previous";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleName = "Position";
            this.bindingNavigatorPositionItem1.AutoSize = false;
            this.bindingNavigatorPositionItem1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(635, 23);
            this.bindingNavigatorPositionItem1.Text = "0";
            this.bindingNavigatorPositionItem1.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem1.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem1.Text = "Move last";
            // 
            // bindingNavigatorSeparator5
            // 
            this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
            this.bindingNavigatorSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnXoaKyThuatHP
            // 
            this.btnXoaKyThuatHP.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaKyThuatHP.Image")));
            this.btnXoaKyThuatHP.Name = "btnXoaKyThuatHP";
            this.btnXoaKyThuatHP.RightToLeftAutoMirrorImage = true;
            this.btnXoaKyThuatHP.Size = new System.Drawing.Size(97, 22);
            this.btnXoaKyThuatHP.Text = "Xóa kỹ thuật";
            this.btnXoaKyThuatHP.Click += new System.EventHandler(this.btnXoaKyThuatHP_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 25);
            // 
            // btnLamMoiKyThuatHP
            // 
            this.btnLamMoiKyThuatHP.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoiKyThuatHP.Image")));
            this.btnLamMoiKyThuatHP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLamMoiKyThuatHP.Name = "btnLamMoiKyThuatHP";
            this.btnLamMoiKyThuatHP.Size = new System.Drawing.Size(78, 22);
            this.btnLamMoiKyThuatHP.Text = "Làm mới";
            this.btnLamMoiKyThuatHP.Click += new System.EventHandler(this.btnLamMoiKyThuatHP_Click);
            // 
            // dtgKyThuat
            // 
            this.dtgKyThuat.AlignColumns = "";
            this.dtgKyThuat.AllignNumberText = false;
            this.dtgKyThuat.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgKyThuat.CheckBoldColumn = false;
            this.dtgKyThuat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKyThuat,
            this.TenKyThuat});
            this.dtgKyThuat.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(132)))), ((int)(((byte)(176)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgKyThuat.DefaultCellStyle = dataGridViewCellStyle9;
            this.dtgKyThuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgKyThuat.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgKyThuat.Location = new System.Drawing.Point(41, 12);
            this.dtgKyThuat.Margin = new System.Windows.Forms.Padding(41, 12, 41, 12);
            this.dtgKyThuat.MarkOddEven = true;
            this.dtgKyThuat.MultiSelect = false;
            this.dtgKyThuat.Name = "dtgKyThuat";
            this.dtgKyThuat.RowHeadersWidth = 40;
            this.dtgKyThuat.RowTemplate.Height = 28;
            this.dtgKyThuat.Size = new System.Drawing.Size(7283, 508);
            this.dtgKyThuat.TabIndex = 0;
            this.dtgKyThuat.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgKyThuat_DataBindingComplete);
            // 
            // MaKyThuat
            // 
            this.MaKyThuat.DataPropertyName = "MaKyThuat";
            this.MaKyThuat.HeaderText = "Mã kỹ thuật";
            this.MaKyThuat.Name = "MaKyThuat";
            // 
            // TenKyThuat
            // 
            this.TenKyThuat.DataPropertyName = "TenKyThuat";
            this.TenKyThuat.HeaderText = "Tên kỹ thuật";
            this.TenKyThuat.Name = "TenKyThuat";
            this.TenKyThuat.Width = 200;
            // 
            // bvKetQua
            // 
            this.bvKetQua.AddNewItem = null;
            this.bvKetQua.CountItem = this.toolStripLabel3;
            this.bvKetQua.CountItemFormat = "/ {0}";
            this.bvKetQua.DeleteItem = null;
            this.bvKetQua.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvKetQua.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvKetQua.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton9,
            this.toolStripButton10,
            this.toolStripSeparator11,
            this.toolStripTextBox3,
            this.toolStripLabel3,
            this.toolStripSeparator12,
            this.toolStripButton11,
            this.toolStripButton12,
            this.toolStripSeparator13,
            this.btnXoaKetQuaHP,
            this.toolStripSeparator14,
            this.btnLamMoiKetQuaHP});
            this.bvKetQua.Location = new System.Drawing.Point(41, 495);
            this.bvKetQua.MoveFirstItem = this.toolStripButton9;
            this.bvKetQua.MoveLastItem = this.toolStripButton12;
            this.bvKetQua.MoveNextItem = this.toolStripButton11;
            this.bvKetQua.MovePreviousItem = this.toolStripButton10;
            this.bvKetQua.Name = "bvKetQua";
            this.bvKetQua.Padding = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.bvKetQua.PositionItem = this.toolStripTextBox3;
            this.bvKetQua.Size = new System.Drawing.Size(8581, 25);
            this.bvKetQua.TabIndex = 3;
            this.bvKetQua.Text = "CustomBindingNavigator2";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(30, 22);
            this.toolStripLabel3.Text = "/ {0}";
            this.toolStripLabel3.ToolTipText = "Total number of items";
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.RightToLeftAutoMirrorImage = true;
            this.toolStripButton9.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton9.Text = "Move first";
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.RightToLeftAutoMirrorImage = true;
            this.toolStripButton10.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton10.Text = "Move previous";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox3
            // 
            this.toolStripTextBox3.AccessibleName = "Position";
            this.toolStripTextBox3.AutoSize = false;
            this.toolStripTextBox3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox3.Name = "toolStripTextBox3";
            this.toolStripTextBox3.Size = new System.Drawing.Size(635, 23);
            this.toolStripTextBox3.Text = "0";
            this.toolStripTextBox3.ToolTipText = "Current position";
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton11
            // 
            this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton11.Image")));
            this.toolStripButton11.Name = "toolStripButton11";
            this.toolStripButton11.RightToLeftAutoMirrorImage = true;
            this.toolStripButton11.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton11.Text = "Move next";
            // 
            // toolStripButton12
            // 
            this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton12.Image")));
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.RightToLeftAutoMirrorImage = true;
            this.toolStripButton12.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton12.Text = "Move last";
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // btnXoaKetQuaHP
            // 
            this.btnXoaKetQuaHP.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaKetQuaHP.Image")));
            this.btnXoaKetQuaHP.Name = "btnXoaKetQuaHP";
            this.btnXoaKetQuaHP.RightToLeftAutoMirrorImage = true;
            this.btnXoaKetQuaHP.Size = new System.Drawing.Size(110, 22);
            this.btnXoaKetQuaHP.Text = "Xóa định nghĩa";
            this.btnXoaKetQuaHP.Click += new System.EventHandler(this.btnXoaKetQuaHP_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // btnLamMoiKetQuaHP
            // 
            this.btnLamMoiKetQuaHP.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoiKetQuaHP.Image")));
            this.btnLamMoiKetQuaHP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLamMoiKetQuaHP.Name = "btnLamMoiKetQuaHP";
            this.btnLamMoiKetQuaHP.Size = new System.Drawing.Size(78, 22);
            this.btnLamMoiKetQuaHP.Text = "Làm mới";
            this.btnLamMoiKetQuaHP.Click += new System.EventHandler(this.btnLamMoiKetQuaHP_Click);
            // 
            // dtgKetQua
            // 
            this.dtgKetQua.AlignColumns = "";
            this.dtgKetQua.AllignNumberText = false;
            this.dtgKetQua.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgKetQua.CheckBoldColumn = false;
            this.dtgKetQua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dtgKetQua.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(132)))), ((int)(((byte)(176)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgKetQua.DefaultCellStyle = dataGridViewCellStyle10;
            this.dtgKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgKetQua.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgKetQua.Location = new System.Drawing.Point(41, 12);
            this.dtgKetQua.Margin = new System.Windows.Forms.Padding(41, 12, 41, 12);
            this.dtgKetQua.MarkOddEven = true;
            this.dtgKetQua.MultiSelect = false;
            this.dtgKetQua.Name = "dtgKetQua";
            this.dtgKetQua.RowHeadersWidth = 40;
            this.dtgKetQua.RowTemplate.Height = 28;
            this.dtgKetQua.Size = new System.Drawing.Size(8581, 508);
            this.dtgKetQua.TabIndex = 2;
            this.dtgKetQua.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgKetQua_DataBindingComplete);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "MaKetQua";
            this.dataGridViewTextBoxColumn3.HeaderText = "Mã kết quả";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "GiaTri";
            this.dataGridViewTextBoxColumn4.HeaderText = "Giá trị";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // frmDMCLS_NoiSoi
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(129)))), ((int)(((byte)(176)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1336, 768);
            this.Margin = new System.Windows.Forms.Padding(41, 30, 41, 30);
            this.Name = "frmDMCLS_NoiSoi";
            this.Text = "Biểu mẫu nội soi";
            this.Load += new System.EventHandler(this.frmDMCLS_NoiSoi_Load);
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
            this.tabDMNoiSoi.ResumeLayout(false);
            this.tabNhom.ResumeLayout(false);
            this.tabNhom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMaNhomCLS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvMaNhomCLS)).EndInit();
            this.bvMaNhomCLS.ResumeLayout(false);
            this.bvMaNhomCLS.PerformLayout();
            this.tabDanhMucBieuMau.ResumeLayout(false);
            this.tabMayNoiSoi.ResumeLayout(false);
            this.tabMayNoiSoi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMayNS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel4)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bvMayNS)).EndInit();
            this.bvMayNS.ResumeLayout(false);
            this.bvMayNS.PerformLayout();
            this.tabKyThuat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3.Panel1)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3.Panel2)).EndInit();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bvKyThuat)).EndInit();
            this.bvKyThuat.ResumeLayout(false);
            this.bvKyThuat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgKyThuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvKetQua)).EndInit();
            this.bvKetQua.ResumeLayout(false);
            this.bvKetQua.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgKetQua)).EndInit();
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
        private TPH.Controls.TPHNormalButton btnAddMauNoiSoi;
        private RicherTextBox.RicherTextBox ricTrang1;
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
        private System.Windows.Forms.ToolStripTextBox txtsearch;
        private TPH.Controls.TPHNormalButton btnSave;
        private System.Windows.Forms.TextBox txtGoTat;
        private DevExpress.XtraEditors.LabelControl label11;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.LabelControl lblSex;
        private System.Windows.Forms.TabControl tabDMNoiSoi;
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
        private CustomComboBox cboNhomNoiSoi;
        private System.Windows.Forms.TabPage tabMayNoiSoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private CustomBindingNavigator bvMayNS;
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
        private System.Windows.Forms.TextBox txtTenMayNS;
        private TPH.Controls.TPHNormalButton btnThemMayNS;
        private RicherTextBox.RicherTextBox ricKetLuan;
        private CustomDatagridView dtgBieuMau;
        private CustomDatagridView dtgMaNhomCLS;
        private CustomDatagridView dtgMayNS;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSoMau;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoTat;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMauNoiSoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuDePhieuKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiTinhSuDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChanDoanMacDinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn KetluanMacDinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeNghi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongHinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTrangIn;
        private System.Windows.Forms.TabPage tabKyThuat;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer3;
        private CustomBindingNavigator bvKyThuat;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
        private System.Windows.Forms.ToolStripButton btnXoaKyThuatHP;
        private CustomDatagridView dtgKyThuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKyThuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKyThuat;
        private CustomBindingNavigator bvKetQua;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton toolStripButton11;
        private System.Windows.Forms.ToolStripButton toolStripButton12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton btnXoaKetQuaHP;
        private CustomDatagridView dtgKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripButton btnLamMoiKyThuatHP;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton btnLamMoiKetQuaHP;
    }
}