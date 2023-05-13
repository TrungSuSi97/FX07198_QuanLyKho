using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH.LIS.App.QuanLyHangHoa
{
    public class FrmDonHangOld : FrmTemplateCommon
    {
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.TextBox txtHTTT;
        private Controls.TPHNormalButton btnXoaDH;
        private Controls.TPHNormalButton btnTaoDH;
        private DevExpress.XtraEditors.LabelControl txtMaDH;
        private System.Windows.Forms.TextBox txtMaHH;
        private System.Windows.Forms.TextBox txtTenHH;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private Common.Controls.ucGroupHeader ucGroupHeader3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private Common.Controls.ucGroupHeader ucGroupHeader2;
        private Common.Controls.ucGroupHeader ucGroupHeader1;
        private System.Windows.Forms.TextBox txtDiaChi;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox txtPhone;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.TextBox textBox4;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private System.Windows.Forms.TextBox txtGhiChu;
        private AppCode.ucSearchLookupEditor_DanhMucDonVi ucSearchLookupEditor_DanhMucDonVi1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.DateTimePicker dtpNgayTao;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private System.Windows.Forms.TextBox txtThoiGianTao;
        private Controls.TPHNormalButton btnSuaDH;
        private Controls.TPHNormalButton tphNormalButton1;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private AppCode.ucSearchLookupEditor_DanhMucHangHoa ucSearchLookupEditor_DanhMucHangHoa1;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private AppCode.ucSearchLookupEditor_DanhMucHangHoa ucSearchLookupEditor_DanhMucHangHoa2;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private Controls.TPHNormalButton tphNormalButton2;
        private System.Windows.Forms.TextBox textBox7;
        public DevExpress.XtraGrid.GridControl gcDH;
        public DevExpress.XtraGrid.Views.Grid.GridView gvDH;
        public DevExpress.XtraGrid.Columns.GridColumn colItemCode;
        public DevExpress.XtraGrid.Columns.GridColumn colItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colDV;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEditDonVi;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colDM;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEditDanhmuc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colGia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        public DevExpress.XtraGrid.GridControl gcDSDH;
        public DevExpress.XtraGrid.Views.Grid.GridView gvDSDH;
        public DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        public DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        public DevExpress.XtraGrid.GridControl gcDSDH_CT;
        public DevExpress.XtraGrid.Views.Grid.GridView gvDSDH_CT;
        public DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        public DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private System.Windows.Forms.TextBox textBox8;
        private AppCode.ucSearchLookupEditor_DanhMucDonVi ucSearchLookupEditor_DanhMucDonVi2;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private Controls.TPHNormalButton tphNormalButton3;
        private System.Windows.Forms.TextBox txtOrderID;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDonHangOld));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ucGroupHeader2 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ucGroupHeader1 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtHTTT = new System.Windows.Forms.TextBox();
            this.btnXoaDH = new TPH.Controls.TPHNormalButton();
            this.btnTaoDH = new TPH.Controls.TPHNormalButton();
            this.txtMaDH = new DevExpress.XtraEditors.LabelControl();
            this.txtMaHH = new System.Windows.Forms.TextBox();
            this.txtTenHH = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.ucGroupHeader3 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.ucSearchLookupEditor_DanhMucDonVi1 = new TPH.LIS.App.AppCode.ucSearchLookupEditor_DanhMucDonVi();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dtpNgayTao = new System.Windows.Forms.DateTimePicker();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtThoiGianTao = new System.Windows.Forms.TextBox();
            this.btnSuaDH = new TPH.Controls.TPHNormalButton();
            this.tphNormalButton1 = new TPH.Controls.TPHNormalButton();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.ucSearchLookupEditor_DanhMucHangHoa1 = new TPH.LIS.App.AppCode.ucSearchLookupEditor_DanhMucHangHoa();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.ucSearchLookupEditor_DanhMucHangHoa2 = new TPH.LIS.App.AppCode.ucSearchLookupEditor_DanhMucHangHoa();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.tphNormalButton2 = new TPH.Controls.TPHNormalButton();
            this.gcDH = new DevExpress.XtraGrid.GridControl();
            this.gvDH = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEditDonVi = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEditDanhmuc = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gcDSDH = new DevExpress.XtraGrid.GridControl();
            this.gvDSDH = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDSDH_CT = new DevExpress.XtraGrid.GridControl();
            this.gvDSDH_CT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.ucSearchLookupEditor_DanhMucDonVi2 = new TPH.LIS.App.AppCode.ucSearchLookupEditor_DanhMucDonVi();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.tphNormalButton3 = new TPH.Controls.TPHNormalButton();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEditDonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEditDanhmuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDSDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDSDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDSDH_CT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDSDH_CT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel1)).BeginInit();
            this.splitContainerControl2.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel2)).BeginInit();
            this.splitContainerControl2.Panel2.SuspendLayout();
            this.splitContainerControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(1200, 25);
            this.lblTitle.Text = "QUẢN LÝ ĐƠN HÀNG";
            // 
            // pnContaint
            // 
            this.pnContaint.Controls.Add(this.xtraTabControl1);
            this.pnContaint.Size = new System.Drawing.Size(1199, 586);
            // 
            // pnLabel
            // 
            this.pnLabel.Size = new System.Drawing.Size(1200, 25);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Location = new System.Drawing.Point(774, 0);
            // 
            // lblMainESC
            // 
            this.lblMainESC.Location = new System.Drawing.Point(803, 0);
            // 
            // pnMenu
            // 
            this.pnMenu.Size = new System.Drawing.Size(1, 586);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(4, 4);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage2;
            this.xtraTabControl1.Size = new System.Drawing.Size(1191, 578);
            this.xtraTabControl1.TabIndex = 183;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage2,
            this.xtraTabPage1});
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.panel4);
            this.xtraTabPage2.Controls.Add(this.panel3);
            this.xtraTabPage2.Controls.Add(this.panel2);
            this.xtraTabPage2.Controls.Add(this.panel1);
            this.xtraTabPage2.Controls.Add(this.ucGroupHeader3);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1189, 553);
            this.xtraTabPage2.Text = "Đơn hàng";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.gcDH);
            this.panel4.Controls.Add(this.ucGroupHeader2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(333, 216);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(856, 337);
            this.panel4.TabIndex = 188;
            // 
            // ucGroupHeader2
            // 
            this.ucGroupHeader2.BackColor = System.Drawing.Color.Transparent;
            this.ucGroupHeader2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(218)))), ((int)(((byte)(89)))));
            this.ucGroupHeader2.GroupCaption = "CHI TIẾT ĐƠN HÀNG";
            this.ucGroupHeader2.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader2.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeader2.Margin = new System.Windows.Forms.Padding(0);
            this.ucGroupHeader2.MaximumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader2.MinimumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader2.Name = "ucGroupHeader2";
            this.ucGroupHeader2.Size = new System.Drawing.Size(856, 23);
            this.ucGroupHeader2.TabIndex = 185;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tphNormalButton2);
            this.panel3.Controls.Add(this.textBox7);
            this.panel3.Controls.Add(this.labelControl13);
            this.panel3.Controls.Add(this.labelControl12);
            this.panel3.Controls.Add(this.ucSearchLookupEditor_DanhMucHangHoa2);
            this.panel3.Controls.Add(this.labelControl11);
            this.panel3.Controls.Add(this.ucSearchLookupEditor_DanhMucHangHoa1);
            this.panel3.Controls.Add(this.ucGroupHeader1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 216);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(333, 337);
            this.panel3.TabIndex = 187;
            // 
            // ucGroupHeader1
            // 
            this.ucGroupHeader1.BackColor = System.Drawing.Color.Transparent;
            this.ucGroupHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(218)))), ((int)(((byte)(89)))));
            this.ucGroupHeader1.GroupCaption = "KHAI BÁO SẢN PHẨM";
            this.ucGroupHeader1.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader1.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeader1.Margin = new System.Windows.Forms.Padding(0);
            this.ucGroupHeader1.MaximumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader1.MinimumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader1.Name = "ucGroupHeader1";
            this.ucGroupHeader1.Size = new System.Drawing.Size(333, 23);
            this.ucGroupHeader1.TabIndex = 185;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(-29, -99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 186;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtOrderID);
            this.panel1.Controls.Add(this.tphNormalButton1);
            this.panel1.Controls.Add(this.btnSuaDH);
            this.panel1.Controls.Add(this.labelControl10);
            this.panel1.Controls.Add(this.txtThoiGianTao);
            this.panel1.Controls.Add(this.dtpNgayTao);
            this.panel1.Controls.Add(this.labelControl4);
            this.panel1.Controls.Add(this.labelControl8);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.labelControl7);
            this.panel1.Controls.Add(this.txtGhiChu);
            this.panel1.Controls.Add(this.txtPhone);
            this.panel1.Controls.Add(this.labelControl6);
            this.panel1.Controls.Add(this.txtDiaChi);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.labelControl5);
            this.panel1.Controls.Add(this.txtHTTT);
            this.panel1.Controls.Add(this.ucSearchLookupEditor_DanhMucDonVi1);
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.btnXoaDH);
            this.panel1.Controls.Add(this.btnTaoDH);
            this.panel1.Controls.Add(this.txtMaDH);
            this.panel1.Controls.Add(this.txtMaHH);
            this.panel1.Controls.Add(this.txtTenHH);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1189, 193);
            this.panel1.TabIndex = 185;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.ForeColor = System.Drawing.Color.Black;
            this.txtDiaChi.Location = new System.Drawing.Point(404, 41);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(0);
            this.txtDiaChi.MaxLength = 50;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(197, 23);
            this.txtDiaChi.TabIndex = 183;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(361, 45);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(38, 15);
            this.labelControl1.TabIndex = 184;
            this.labelControl1.Text = "Địa chỉ";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(627, 43);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(114, 15);
            this.labelControl5.TabIndex = 182;
            this.labelControl5.Text = "Hình thức thanh toán";
            // 
            // txtHTTT
            // 
            this.txtHTTT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHTTT.Location = new System.Drawing.Point(755, 39);
            this.txtHTTT.Margin = new System.Windows.Forms.Padding(0);
            this.txtHTTT.MaxLength = 20;
            this.txtHTTT.Name = "txtHTTT";
            this.txtHTTT.Size = new System.Drawing.Size(174, 22);
            this.txtHTTT.TabIndex = 181;
            // 
            // btnXoaDH
            // 
            this.btnXoaDH.BackColor = System.Drawing.Color.White;
            this.btnXoaDH.BackColorHover = System.Drawing.Color.Empty;
            this.btnXoaDH.BackgroundColor = System.Drawing.Color.White;
            this.btnXoaDH.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXoaDH.BorderRadius = 5;
            this.btnXoaDH.BorderSize = 1;
            this.btnXoaDH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaDH.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoaDH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDH.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaDH.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXoaDH.ForeColor = System.Drawing.Color.Black;
            this.btnXoaDH.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaDH.Image")));
            this.btnXoaDH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaDH.Location = new System.Drawing.Point(395, 152);
            this.btnXoaDH.Margin = new System.Windows.Forms.Padding(0);
            this.btnXoaDH.Name = "btnXoaDH";
            this.btnXoaDH.Size = new System.Drawing.Size(112, 26);
            this.btnXoaDH.TabIndex = 175;
            this.btnXoaDH.Text = "Xóa đơn hàng";
            this.btnXoaDH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaDH.TextColor = System.Drawing.Color.Black;
            this.btnXoaDH.UseHightLight = true;
            this.btnXoaDH.UseVisualStyleBackColor = false;
            // 
            // btnTaoDH
            // 
            this.btnTaoDH.BackColor = System.Drawing.Color.White;
            this.btnTaoDH.BackColorHover = System.Drawing.Color.Empty;
            this.btnTaoDH.BackgroundColor = System.Drawing.Color.White;
            this.btnTaoDH.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnTaoDH.BorderRadius = 5;
            this.btnTaoDH.BorderSize = 1;
            this.btnTaoDH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoDH.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoDH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoDH.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoDH.ForceColorHover = System.Drawing.Color.Empty;
            this.btnTaoDH.ForeColor = System.Drawing.Color.Black;
            this.btnTaoDH.Image = ((System.Drawing.Image)(resources.GetObject("btnTaoDH.Image")));
            this.btnTaoDH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoDH.Location = new System.Drawing.Point(17, 152);
            this.btnTaoDH.Margin = new System.Windows.Forms.Padding(0);
            this.btnTaoDH.Name = "btnTaoDH";
            this.btnTaoDH.Size = new System.Drawing.Size(111, 26);
            this.btnTaoDH.TabIndex = 174;
            this.btnTaoDH.Text = "Tạo đơn hàng";
            this.btnTaoDH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTaoDH.TextColor = System.Drawing.Color.Black;
            this.btnTaoDH.UseHightLight = true;
            this.btnTaoDH.UseVisualStyleBackColor = false;
            // 
            // txtMaDH
            // 
            this.txtMaDH.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.txtMaDH.Appearance.Options.UseFont = true;
            this.txtMaDH.Location = new System.Drawing.Point(30, 17);
            this.txtMaDH.Name = "txtMaDH";
            this.txtMaDH.Size = new System.Drawing.Size(72, 15);
            this.txtMaDH.TabIndex = 172;
            this.txtMaDH.Text = "Mã đơn hàng";
            // 
            // txtMaHH
            // 
            this.txtMaHH.Enabled = false;
            this.txtMaHH.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaHH.Location = new System.Drawing.Point(107, 13);
            this.txtMaHH.Margin = new System.Windows.Forms.Padding(0);
            this.txtMaHH.MaxLength = 20;
            this.txtMaHH.Name = "txtMaHH";
            this.txtMaHH.Size = new System.Drawing.Size(125, 23);
            this.txtMaHH.TabIndex = 170;
            // 
            // txtTenHH
            // 
            this.txtTenHH.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenHH.ForeColor = System.Drawing.Color.Black;
            this.txtTenHH.Location = new System.Drawing.Point(404, 9);
            this.txtTenHH.Margin = new System.Windows.Forms.Padding(0);
            this.txtTenHH.MaxLength = 50;
            this.txtTenHH.Name = "txtTenHH";
            this.txtTenHH.Size = new System.Drawing.Size(197, 23);
            this.txtTenHH.TabIndex = 171;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(311, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(88, 15);
            this.labelControl2.TabIndex = 173;
            this.labelControl2.Text = "Tên khách hàng";
            this.labelControl2.Click += new System.EventHandler(this.labelControl2_Click);
            // 
            // ucGroupHeader3
            // 
            this.ucGroupHeader3.BackColor = System.Drawing.Color.Transparent;
            this.ucGroupHeader3.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(218)))), ((int)(((byte)(89)))));
            this.ucGroupHeader3.GroupCaption = "KHAI BÁO ĐƠN HÀNG";
            this.ucGroupHeader3.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader3.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeader3.Margin = new System.Windows.Forms.Padding(0);
            this.ucGroupHeader3.MaximumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader3.MinimumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader3.Name = "ucGroupHeader3";
            this.ucGroupHeader3.Size = new System.Drawing.Size(1189, 23);
            this.ucGroupHeader3.TabIndex = 184;
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.splitContainerControl2);
            this.xtraTabPage1.Controls.Add(this.splitContainerControl1);
            this.xtraTabPage1.Controls.Add(this.groupBox1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1189, 553);
            this.xtraTabPage1.Text = "Danh sách đơn hàng";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.ForeColor = System.Drawing.Color.Black;
            this.txtPhone.Location = new System.Drawing.Point(755, 9);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(0);
            this.txtPhone.MaxLength = 50;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(174, 23);
            this.txtPhone.TabIndex = 185;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(685, 13);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(56, 15);
            this.labelControl6.TabIndex = 186;
            this.labelControl6.Text = "Điện thoại";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(60, 73);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(42, 15);
            this.labelControl7.TabIndex = 188;
            this.labelControl7.Text = "Ghi chú";
            this.labelControl7.Click += new System.EventHandler(this.labelControl7_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(107, 69);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(0);
            this.txtGhiChu.MaxLength = 20;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(174, 22);
            this.txtGhiChu.TabIndex = 187;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(51, 105);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(51, 15);
            this.labelControl8.TabIndex = 190;
            this.labelControl8.Text = "Tổng tiền";
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(107, 101);
            this.textBox4.Margin = new System.Windows.Forms.Padding(0);
            this.textBox4.MaxLength = 20;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(174, 22);
            this.textBox4.TabIndex = 189;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(319, 101);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(80, 15);
            this.labelControl3.TabIndex = 177;
            this.labelControl3.Text = "Người tạo đơn";
            // 
            // ucSearchLookupEditor_DanhMucDonVi1
            // 
            this.ucSearchLookupEditor_DanhMucDonVi1.CatchEnterKey = false;
            this.ucSearchLookupEditor_DanhMucDonVi1.CatchTabKey = false;
            this.ucSearchLookupEditor_DanhMucDonVi1.ControlBack = null;
            this.ucSearchLookupEditor_DanhMucDonVi1.ControlNext = null;
            this.ucSearchLookupEditor_DanhMucDonVi1.DisplayMember = "";
            this.ucSearchLookupEditor_DanhMucDonVi1.Location = new System.Drawing.Point(405, 100);
            this.ucSearchLookupEditor_DanhMucDonVi1.Name = "ucSearchLookupEditor_DanhMucDonVi1";
            this.ucSearchLookupEditor_DanhMucDonVi1.SelectedValue = null;
            this.ucSearchLookupEditor_DanhMucDonVi1.Size = new System.Drawing.Size(196, 23);
            this.ucSearchLookupEditor_DanhMucDonVi1.TabIndex = 178;
            this.ucSearchLookupEditor_DanhMucDonVi1.ValueMember = "";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(29, 43);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(73, 15);
            this.labelControl4.TabIndex = 191;
            this.labelControl4.Text = "Ngày tạo đơn";
            // 
            // dtpNgayTao
            // 
            this.dtpNgayTao.Location = new System.Drawing.Point(107, 42);
            this.dtpNgayTao.Name = "dtpNgayTao";
            this.dtpNgayTao.Size = new System.Drawing.Size(170, 20);
            this.dtpNgayTao.TabIndex = 193;
            this.dtpNgayTao.Value = new System.DateTime(2023, 5, 13, 0, 0, 0, 0);
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(302, 73);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(97, 15);
            this.labelControl10.TabIndex = 197;
            this.labelControl10.Text = "Thời gian tạo đơn";
            // 
            // txtThoiGianTao
            // 
            this.txtThoiGianTao.Enabled = false;
            this.txtThoiGianTao.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThoiGianTao.Location = new System.Drawing.Point(405, 69);
            this.txtThoiGianTao.Margin = new System.Windows.Forms.Padding(0);
            this.txtThoiGianTao.MaxLength = 20;
            this.txtThoiGianTao.Name = "txtThoiGianTao";
            this.txtThoiGianTao.Size = new System.Drawing.Size(196, 22);
            this.txtThoiGianTao.TabIndex = 196;
            // 
            // btnSuaDH
            // 
            this.btnSuaDH.BackColor = System.Drawing.Color.White;
            this.btnSuaDH.BackColorHover = System.Drawing.Color.Empty;
            this.btnSuaDH.BackgroundColor = System.Drawing.Color.White;
            this.btnSuaDH.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnSuaDH.BorderRadius = 5;
            this.btnSuaDH.BorderSize = 1;
            this.btnSuaDH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaDH.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSuaDH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaDH.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaDH.ForceColorHover = System.Drawing.Color.Empty;
            this.btnSuaDH.ForeColor = System.Drawing.Color.Black;
            this.btnSuaDH.Image = ((System.Drawing.Image)(resources.GetObject("btnSuaDH.Image")));
            this.btnSuaDH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaDH.Location = new System.Drawing.Point(138, 152);
            this.btnSuaDH.Margin = new System.Windows.Forms.Padding(0);
            this.btnSuaDH.Name = "btnSuaDH";
            this.btnSuaDH.Size = new System.Drawing.Size(118, 26);
            this.btnSuaDH.TabIndex = 198;
            this.btnSuaDH.Text = "Sửa đơn hàng";
            this.btnSuaDH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuaDH.TextColor = System.Drawing.Color.Black;
            this.btnSuaDH.UseHightLight = true;
            this.btnSuaDH.UseVisualStyleBackColor = false;
            // 
            // tphNormalButton1
            // 
            this.tphNormalButton1.BackColor = System.Drawing.Color.White;
            this.tphNormalButton1.BackColorHover = System.Drawing.Color.Empty;
            this.tphNormalButton1.BackgroundColor = System.Drawing.Color.White;
            this.tphNormalButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.tphNormalButton1.BorderRadius = 5;
            this.tphNormalButton1.BorderSize = 1;
            this.tphNormalButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tphNormalButton1.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.tphNormalButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tphNormalButton1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tphNormalButton1.ForceColorHover = System.Drawing.Color.Empty;
            this.tphNormalButton1.ForeColor = System.Drawing.Color.Black;
            this.tphNormalButton1.Image = ((System.Drawing.Image)(resources.GetObject("tphNormalButton1.Image")));
            this.tphNormalButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tphNormalButton1.Location = new System.Drawing.Point(266, 152);
            this.tphNormalButton1.Margin = new System.Windows.Forms.Padding(0);
            this.tphNormalButton1.Name = "tphNormalButton1";
            this.tphNormalButton1.Size = new System.Drawing.Size(118, 26);
            this.tphNormalButton1.TabIndex = 199;
            this.tphNormalButton1.Text = "Lưu thông tin";
            this.tphNormalButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tphNormalButton1.TextColor = System.Drawing.Color.Black;
            this.tphNormalButton1.UseHightLight = true;
            this.tphNormalButton1.UseVisualStyleBackColor = false;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(17, 48);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(57, 15);
            this.labelControl11.TabIndex = 187;
            this.labelControl11.Text = "Danh mục";
            // 
            // ucSearchLookupEditor_DanhMucHangHoa1
            // 
            this.ucSearchLookupEditor_DanhMucHangHoa1.CatchEnterKey = false;
            this.ucSearchLookupEditor_DanhMucHangHoa1.CatchTabKey = false;
            this.ucSearchLookupEditor_DanhMucHangHoa1.ControlBack = null;
            this.ucSearchLookupEditor_DanhMucHangHoa1.ControlNext = null;
            this.ucSearchLookupEditor_DanhMucHangHoa1.DisplayMember = "";
            this.ucSearchLookupEditor_DanhMucHangHoa1.Location = new System.Drawing.Point(85, 40);
            this.ucSearchLookupEditor_DanhMucHangHoa1.Name = "ucSearchLookupEditor_DanhMucHangHoa1";
            this.ucSearchLookupEditor_DanhMucHangHoa1.SelectedValue = null;
            this.ucSearchLookupEditor_DanhMucHangHoa1.Size = new System.Drawing.Size(242, 23);
            this.ucSearchLookupEditor_DanhMucHangHoa1.TabIndex = 186;
            this.ucSearchLookupEditor_DanhMucHangHoa1.ValueMember = "";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(17, 93);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(57, 15);
            this.labelControl12.TabIndex = 189;
            this.labelControl12.Text = "Sản phẩm";
            // 
            // ucSearchLookupEditor_DanhMucHangHoa2
            // 
            this.ucSearchLookupEditor_DanhMucHangHoa2.CatchEnterKey = false;
            this.ucSearchLookupEditor_DanhMucHangHoa2.CatchTabKey = false;
            this.ucSearchLookupEditor_DanhMucHangHoa2.ControlBack = null;
            this.ucSearchLookupEditor_DanhMucHangHoa2.ControlNext = null;
            this.ucSearchLookupEditor_DanhMucHangHoa2.DisplayMember = "";
            this.ucSearchLookupEditor_DanhMucHangHoa2.Location = new System.Drawing.Point(85, 85);
            this.ucSearchLookupEditor_DanhMucHangHoa2.Name = "ucSearchLookupEditor_DanhMucHangHoa2";
            this.ucSearchLookupEditor_DanhMucHangHoa2.SelectedValue = null;
            this.ucSearchLookupEditor_DanhMucHangHoa2.Size = new System.Drawing.Size(242, 23);
            this.ucSearchLookupEditor_DanhMucHangHoa2.TabIndex = 188;
            this.ucSearchLookupEditor_DanhMucHangHoa2.ValueMember = "";
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(17, 129);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(51, 15);
            this.labelControl13.TabIndex = 190;
            this.labelControl13.Text = "Số lượng";
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(85, 125);
            this.textBox7.Margin = new System.Windows.Forms.Padding(0);
            this.textBox7.MaxLength = 20;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(101, 22);
            this.textBox7.TabIndex = 200;
            // 
            // tphNormalButton2
            // 
            this.tphNormalButton2.BackColor = System.Drawing.Color.White;
            this.tphNormalButton2.BackColorHover = System.Drawing.Color.Empty;
            this.tphNormalButton2.BackgroundColor = System.Drawing.Color.White;
            this.tphNormalButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.tphNormalButton2.BorderRadius = 5;
            this.tphNormalButton2.BorderSize = 1;
            this.tphNormalButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tphNormalButton2.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.tphNormalButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tphNormalButton2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tphNormalButton2.ForceColorHover = System.Drawing.Color.Empty;
            this.tphNormalButton2.ForeColor = System.Drawing.Color.Black;
            this.tphNormalButton2.Image = ((System.Drawing.Image)(resources.GetObject("tphNormalButton2.Image")));
            this.tphNormalButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tphNormalButton2.Location = new System.Drawing.Point(17, 197);
            this.tphNormalButton2.Margin = new System.Windows.Forms.Padding(0);
            this.tphNormalButton2.Name = "tphNormalButton2";
            this.tphNormalButton2.Size = new System.Drawing.Size(127, 42);
            this.tphNormalButton2.TabIndex = 200;
            this.tphNormalButton2.Text = "Thêm sản phẩm";
            this.tphNormalButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tphNormalButton2.TextColor = System.Drawing.Color.Black;
            this.tphNormalButton2.UseHightLight = true;
            this.tphNormalButton2.UseVisualStyleBackColor = false;
            // 
            // gcDH
            // 
            this.gcDH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDH.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Arial", 8F);
            this.gcDH.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gcDH.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcDH.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcDH.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcDH.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcDH.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcDH.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0);
            this.gcDH.EmbeddedNavigator.TextStringFormat = "Dòng {0}/{1}";
            this.gcDH.Location = new System.Drawing.Point(0, 23);
            this.gcDH.MainView = this.gvDH;
            this.gcDH.Margin = new System.Windows.Forms.Padding(0);
            this.gcDH.Name = "gcDH";
            this.gcDH.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEditDonVi,
            this.repositoryItemGridLookUpEditDanhmuc});
            this.gcDH.Size = new System.Drawing.Size(856, 314);
            this.gcDH.TabIndex = 186;
            this.gcDH.UseEmbeddedNavigator = true;
            this.gcDH.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDH});
            // 
            // gvDH
            // 
            this.gvDH.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItemCode,
            this.colItemName,
            this.colDV,
            this.colDM,
            this.colGia});
            this.gvDH.DetailHeight = 284;
            this.gvDH.GridControl = this.gcDH;
            this.gvDH.GroupFormat = "{0}: [#image]{1}  -  {2}";
            this.gvDH.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GiaRieng", null, "{0:N0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TienCong", null, "{0:N0}")});
            this.gvDH.Name = "gvDH";
            this.gvDH.OptionsSelection.CheckBoxSelectorColumnWidth = 26;
            this.gvDH.OptionsSelection.MultiSelect = true;
            this.gvDH.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvDH.OptionsView.ColumnAutoWidth = false;
            this.gvDH.OptionsView.ShowFooter = true;
            this.gvDH.OptionsView.ShowGroupPanel = false;
            // 
            // colItemCode
            // 
            this.colItemCode.Caption = "Mã hàng hóa";
            this.colItemCode.FieldName = "itemcode";
            this.colItemCode.MinWidth = 17;
            this.colItemCode.Name = "colItemCode";
            this.colItemCode.OptionsColumn.ReadOnly = true;
            this.colItemCode.Visible = true;
            this.colItemCode.VisibleIndex = 1;
            this.colItemCode.Width = 90;
            // 
            // colItemName
            // 
            this.colItemName.Caption = "Tên hàng hóa";
            this.colItemName.FieldName = "itemname";
            this.colItemName.MinWidth = 17;
            this.colItemName.Name = "colItemName";
            this.colItemName.Visible = true;
            this.colItemName.VisibleIndex = 2;
            this.colItemName.Width = 182;
            // 
            // colDV
            // 
            this.colDV.Caption = "Đon vị";
            this.colDV.ColumnEdit = this.repositoryItemGridLookUpEditDonVi;
            this.colDV.FieldName = "madonvi";
            this.colDV.MinWidth = 17;
            this.colDV.Name = "colDV";
            this.colDV.Visible = true;
            this.colDV.VisibleIndex = 4;
            this.colDV.Width = 102;
            // 
            // repositoryItemGridLookUpEditDonVi
            // 
            this.repositoryItemGridLookUpEditDonVi.AutoHeight = false;
            this.repositoryItemGridLookUpEditDonVi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEditDonVi.DisplayMember = "tendonvi";
            this.repositoryItemGridLookUpEditDonVi.Name = "repositoryItemGridLookUpEditDonVi";
            this.repositoryItemGridLookUpEditDonVi.NullText = "[Chưa chọn]";
            this.repositoryItemGridLookUpEditDonVi.PopupView = this.repositoryItemGridLookUpEdit1View;
            this.repositoryItemGridLookUpEditDonVi.ValueMember = "madonvi";
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colDM
            // 
            this.colDM.Caption = "Danh mục";
            this.colDM.ColumnEdit = this.repositoryItemGridLookUpEditDanhmuc;
            this.colDM.FieldName = "madanhmuc";
            this.colDM.Name = "colDM";
            this.colDM.Visible = true;
            this.colDM.VisibleIndex = 3;
            this.colDM.Width = 209;
            // 
            // repositoryItemGridLookUpEditDanhmuc
            // 
            this.repositoryItemGridLookUpEditDanhmuc.AutoHeight = false;
            this.repositoryItemGridLookUpEditDanhmuc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEditDanhmuc.DisplayMember = "tendanhmuc";
            this.repositoryItemGridLookUpEditDanhmuc.Name = "repositoryItemGridLookUpEditDanhmuc";
            this.repositoryItemGridLookUpEditDanhmuc.NullText = "[Chưa chọn]";
            this.repositoryItemGridLookUpEditDanhmuc.PopupView = this.gridView1;
            this.repositoryItemGridLookUpEditDanhmuc.ValueMember = "madanhmuc";
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colGia
            // 
            this.colGia.Caption = "Giá";
            this.colGia.DisplayFormat.FormatString = "{0:0,0}";
            this.colGia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGia.FieldName = "cost";
            this.colGia.Name = "colGia";
            this.colGia.Visible = true;
            this.colGia.VisibleIndex = 5;
            this.colGia.Width = 96;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tphNormalButton3);
            this.groupBox1.Controls.Add(this.ucSearchLookupEditor_DanhMucDonVi2);
            this.groupBox1.Controls.Add(this.labelControl17);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.labelControl16);
            this.groupBox1.Controls.Add(this.dateTimePicker3);
            this.groupBox1.Controls.Add(this.labelControl15);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.labelControl14);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1189, 130);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều kiện";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gcDSDH);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1189, 166);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách đơn hàng";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gcDSDH_CT);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1189, 247);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chi tiết đơn hàng";
            // 
            // gcDSDH
            // 
            this.gcDSDH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDSDH.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Arial", 8F);
            this.gcDSDH.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gcDSDH.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcDSDH.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcDSDH.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcDSDH.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcDSDH.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcDSDH.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0);
            this.gcDSDH.EmbeddedNavigator.TextStringFormat = "Dòng {0}/{1}";
            this.gcDSDH.Location = new System.Drawing.Point(3, 16);
            this.gcDSDH.MainView = this.gvDSDH;
            this.gcDSDH.Margin = new System.Windows.Forms.Padding(0);
            this.gcDSDH.Name = "gcDSDH";
            this.gcDSDH.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit1,
            this.repositoryItemGridLookUpEdit2});
            this.gcDSDH.Size = new System.Drawing.Size(1183, 147);
            this.gcDSDH.TabIndex = 187;
            this.gcDSDH.UseEmbeddedNavigator = true;
            this.gcDSDH.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDSDH});
            // 
            // gvDSDH
            // 
            this.gvDSDH.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gvDSDH.DetailHeight = 284;
            this.gvDSDH.GridControl = this.gcDSDH;
            this.gvDSDH.GroupFormat = "{0}: [#image]{1}  -  {2}";
            this.gvDSDH.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GiaRieng", null, "{0:N0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TienCong", null, "{0:N0}")});
            this.gvDSDH.Name = "gvDSDH";
            this.gvDSDH.OptionsSelection.CheckBoxSelectorColumnWidth = 26;
            this.gvDSDH.OptionsSelection.MultiSelect = true;
            this.gvDSDH.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvDSDH.OptionsView.ColumnAutoWidth = false;
            this.gvDSDH.OptionsView.ShowFooter = true;
            this.gvDSDH.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã hàng hóa";
            this.gridColumn1.FieldName = "itemcode";
            this.gridColumn1.MinWidth = 17;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 90;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên hàng hóa";
            this.gridColumn2.FieldName = "itemname";
            this.gridColumn2.MinWidth = 17;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 182;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Đon vị";
            this.gridColumn3.ColumnEdit = this.repositoryItemGridLookUpEdit1;
            this.gridColumn3.FieldName = "madonvi";
            this.gridColumn3.MinWidth = 17;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 102;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.DisplayMember = "tendonvi";
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.NullText = "[Chưa chọn]";
            this.repositoryItemGridLookUpEdit1.PopupView = this.gridView4;
            this.repositoryItemGridLookUpEdit1.ValueMember = "madonvi";
            // 
            // gridView4
            // 
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Danh mục";
            this.gridColumn4.ColumnEdit = this.repositoryItemGridLookUpEdit2;
            this.gridColumn4.FieldName = "madanhmuc";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 209;
            // 
            // repositoryItemGridLookUpEdit2
            // 
            this.repositoryItemGridLookUpEdit2.AutoHeight = false;
            this.repositoryItemGridLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit2.DisplayMember = "tendanhmuc";
            this.repositoryItemGridLookUpEdit2.Name = "repositoryItemGridLookUpEdit2";
            this.repositoryItemGridLookUpEdit2.NullText = "[Chưa chọn]";
            this.repositoryItemGridLookUpEdit2.PopupView = this.gridView3;
            this.repositoryItemGridLookUpEdit2.ValueMember = "madanhmuc";
            // 
            // gridView3
            // 
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Giá";
            this.gridColumn5.DisplayFormat.FormatString = "{0:0,0}";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "cost";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 96;
            // 
            // gcDSDH_CT
            // 
            this.gcDSDH_CT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDSDH_CT.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Arial", 8F);
            this.gcDSDH_CT.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gcDSDH_CT.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcDSDH_CT.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcDSDH_CT.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcDSDH_CT.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcDSDH_CT.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcDSDH_CT.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0);
            this.gcDSDH_CT.EmbeddedNavigator.TextStringFormat = "Dòng {0}/{1}";
            this.gcDSDH_CT.Location = new System.Drawing.Point(3, 16);
            this.gcDSDH_CT.MainView = this.gvDSDH_CT;
            this.gcDSDH_CT.Margin = new System.Windows.Forms.Padding(0);
            this.gcDSDH_CT.Name = "gcDSDH_CT";
            this.gcDSDH_CT.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit3,
            this.repositoryItemGridLookUpEdit4});
            this.gcDSDH_CT.Size = new System.Drawing.Size(1183, 228);
            this.gcDSDH_CT.TabIndex = 187;
            this.gcDSDH_CT.UseEmbeddedNavigator = true;
            this.gcDSDH_CT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDSDH_CT});
            // 
            // gvDSDH_CT
            // 
            this.gvDSDH_CT.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.gvDSDH_CT.DetailHeight = 284;
            this.gvDSDH_CT.GridControl = this.gcDSDH_CT;
            this.gvDSDH_CT.GroupFormat = "{0}: [#image]{1}  -  {2}";
            this.gvDSDH_CT.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GiaRieng", null, "{0:N0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TienCong", null, "{0:N0}")});
            this.gvDSDH_CT.Name = "gvDSDH_CT";
            this.gvDSDH_CT.OptionsSelection.CheckBoxSelectorColumnWidth = 26;
            this.gvDSDH_CT.OptionsSelection.MultiSelect = true;
            this.gvDSDH_CT.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvDSDH_CT.OptionsView.ColumnAutoWidth = false;
            this.gvDSDH_CT.OptionsView.ShowFooter = true;
            this.gvDSDH_CT.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Mã hàng hóa";
            this.gridColumn6.FieldName = "itemcode";
            this.gridColumn6.MinWidth = 17;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 90;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Tên hàng hóa";
            this.gridColumn7.FieldName = "itemname";
            this.gridColumn7.MinWidth = 17;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 182;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Đon vị";
            this.gridColumn8.ColumnEdit = this.repositoryItemGridLookUpEdit3;
            this.gridColumn8.FieldName = "madonvi";
            this.gridColumn8.MinWidth = 17;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 102;
            // 
            // repositoryItemGridLookUpEdit3
            // 
            this.repositoryItemGridLookUpEdit3.AutoHeight = false;
            this.repositoryItemGridLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit3.DisplayMember = "tendonvi";
            this.repositoryItemGridLookUpEdit3.Name = "repositoryItemGridLookUpEdit3";
            this.repositoryItemGridLookUpEdit3.NullText = "[Chưa chọn]";
            this.repositoryItemGridLookUpEdit3.PopupView = this.gridView6;
            this.repositoryItemGridLookUpEdit3.ValueMember = "madonvi";
            // 
            // gridView6
            // 
            this.gridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView6.Name = "gridView6";
            this.gridView6.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView6.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Danh mục";
            this.gridColumn9.ColumnEdit = this.repositoryItemGridLookUpEdit4;
            this.gridColumn9.FieldName = "madanhmuc";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 3;
            this.gridColumn9.Width = 209;
            // 
            // repositoryItemGridLookUpEdit4
            // 
            this.repositoryItemGridLookUpEdit4.AutoHeight = false;
            this.repositoryItemGridLookUpEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit4.DisplayMember = "tendanhmuc";
            this.repositoryItemGridLookUpEdit4.Name = "repositoryItemGridLookUpEdit4";
            this.repositoryItemGridLookUpEdit4.NullText = "[Chưa chọn]";
            this.repositoryItemGridLookUpEdit4.PopupView = this.gridView7;
            this.repositoryItemGridLookUpEdit4.ValueMember = "madanhmuc";
            // 
            // gridView7
            // 
            this.gridView7.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView7.Name = "gridView7";
            this.gridView7.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView7.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Giá";
            this.gridColumn10.DisplayFormat.FormatString = "{0:0,0}";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "cost";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 5;
            this.gridColumn10.Width = 96;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Location = new System.Drawing.Point(-29, -99);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(200, 100);
            this.splitContainerControl1.TabIndex = 1;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 130);
            this.splitContainerControl2.Name = "splitContainerControl2";
            // 
            // splitContainerControl2.Panel1
            // 
            this.splitContainerControl2.Panel1.Controls.Add(this.groupBox2);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            // 
            // splitContainerControl2.Panel2
            // 
            this.splitContainerControl2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(1189, 423);
            this.splitContainerControl2.SplitterPosition = 166;
            this.splitContainerControl2.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(56, 14);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(170, 20);
            this.dateTimePicker2.TabIndex = 195;
            this.dateTimePicker2.Value = new System.DateTime(2023, 5, 13, 0, 0, 0, 0);
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Location = new System.Drawing.Point(6, 19);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(44, 15);
            this.labelControl14.TabIndex = 194;
            this.labelControl14.Text = "Từ ngày";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Location = new System.Drawing.Point(261, 14);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(170, 20);
            this.dateTimePicker3.TabIndex = 197;
            this.dateTimePicker3.Value = new System.DateTime(2023, 5, 13, 0, 0, 0, 0);
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Location = new System.Drawing.Point(232, 19);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(23, 15);
            this.labelControl15.TabIndex = 196;
            this.labelControl15.Text = "Đến";
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl16.Appearance.Options.UseFont = true;
            this.labelControl16.Location = new System.Drawing.Point(6, 49);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(72, 15);
            this.labelControl16.TabIndex = 198;
            this.labelControl16.Text = "Mã đơn hàng";
            // 
            // textBox8
            // 
            this.textBox8.Enabled = false;
            this.textBox8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(96, 45);
            this.textBox8.Margin = new System.Windows.Forms.Padding(0);
            this.textBox8.MaxLength = 20;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(125, 23);
            this.textBox8.TabIndex = 199;
            // 
            // ucSearchLookupEditor_DanhMucDonVi2
            // 
            this.ucSearchLookupEditor_DanhMucDonVi2.CatchEnterKey = false;
            this.ucSearchLookupEditor_DanhMucDonVi2.CatchTabKey = false;
            this.ucSearchLookupEditor_DanhMucDonVi2.ControlBack = null;
            this.ucSearchLookupEditor_DanhMucDonVi2.ControlNext = null;
            this.ucSearchLookupEditor_DanhMucDonVi2.DisplayMember = "";
            this.ucSearchLookupEditor_DanhMucDonVi2.Location = new System.Drawing.Point(318, 45);
            this.ucSearchLookupEditor_DanhMucDonVi2.Name = "ucSearchLookupEditor_DanhMucDonVi2";
            this.ucSearchLookupEditor_DanhMucDonVi2.SelectedValue = null;
            this.ucSearchLookupEditor_DanhMucDonVi2.Size = new System.Drawing.Size(196, 23);
            this.ucSearchLookupEditor_DanhMucDonVi2.TabIndex = 201;
            this.ucSearchLookupEditor_DanhMucDonVi2.ValueMember = "";
            // 
            // labelControl17
            // 
            this.labelControl17.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl17.Appearance.Options.UseFont = true;
            this.labelControl17.Location = new System.Drawing.Point(232, 49);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(80, 15);
            this.labelControl17.TabIndex = 200;
            this.labelControl17.Text = "Người tạo đơn";
            // 
            // tphNormalButton3
            // 
            this.tphNormalButton3.BackColor = System.Drawing.Color.White;
            this.tphNormalButton3.BackColorHover = System.Drawing.Color.Empty;
            this.tphNormalButton3.BackgroundColor = System.Drawing.Color.White;
            this.tphNormalButton3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.tphNormalButton3.BorderRadius = 5;
            this.tphNormalButton3.BorderSize = 1;
            this.tphNormalButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tphNormalButton3.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.tphNormalButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tphNormalButton3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tphNormalButton3.ForceColorHover = System.Drawing.Color.Empty;
            this.tphNormalButton3.ForeColor = System.Drawing.Color.Black;
            this.tphNormalButton3.Image = ((System.Drawing.Image)(resources.GetObject("tphNormalButton3.Image")));
            this.tphNormalButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tphNormalButton3.Location = new System.Drawing.Point(3, 82);
            this.tphNormalButton3.Margin = new System.Windows.Forms.Padding(0);
            this.tphNormalButton3.Name = "tphNormalButton3";
            this.tphNormalButton3.Size = new System.Drawing.Size(100, 35);
            this.tphNormalButton3.TabIndex = 202;
            this.tphNormalButton3.Text = "Tìm kiếm";
            this.tphNormalButton3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tphNormalButton3.TextColor = System.Drawing.Color.Black;
            this.tphNormalButton3.UseHightLight = true;
            this.tphNormalButton3.UseVisualStyleBackColor = false;
            // 
            // txtOrderID
            // 
            this.txtOrderID.Enabled = false;
            this.txtOrderID.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderID.Location = new System.Drawing.Point(244, 13);
            this.txtOrderID.Margin = new System.Windows.Forms.Padding(0);
            this.txtOrderID.MaxLength = 20;
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(37, 23);
            this.txtOrderID.TabIndex = 200;
            this.txtOrderID.Visible = false;
            // 
            // FrmDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(1200, 611);
            this.Name = "FrmDonHang";
            this.Text = "QUẢN LÝ ĐƠN HÀNG";
            this.pnContaint.ResumeLayout(false);
            this.pnLabel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEditDonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEditDanhmuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDSDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDSDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDSDH_CT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDSDH_CT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel1)).EndInit();
            this.splitContainerControl2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel2)).EndInit();
            this.splitContainerControl2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }
    }
}
