namespace TPH.LIS.App.QuanLyTaiChinh
{
    partial class FrmTaiSanCoDinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTaiSanCoDinh));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gcTSCD1 = new DevExpress.XtraGrid.GridControl();
            this.gvTSCD1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaTS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenTS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTinhTrang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDonViSD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemGridLookUpEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ucGroupHeader1 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtDVSD = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtTT = new System.Windows.Forms.TextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnRefreshItem = new TPH.Controls.TPHNormalButton();
            this.btnXoaItem = new TPH.Controls.TPHNormalButton();
            this.btnThemItem = new TPH.Controls.TPHNormalButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaTS = new System.Windows.Forms.TextBox();
            this.txtTenTS = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.ucGroupHeader3 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gcTSCD2 = new DevExpress.XtraGrid.GridControl();
            this.gvTSCD2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemGridLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTimKiemTSCD = new TPH.Controls.TPHNormalButton();
            this.txtMaDHTK = new System.Windows.Forms.TextBox();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTSCD1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTSCD1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            this.panel1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTSCD2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTSCD2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(1108, 25);
            this.lblTitle.Text = "QUẢN LÝ TÀI SẢN CỐ ĐỊNH";
            // 
            // pnContaint
            // 
            this.pnContaint.Controls.Add(this.xtraTabControl1);
            this.pnContaint.Size = new System.Drawing.Size(1107, 573);
            // 
            // pnLabel
            // 
            this.pnLabel.Size = new System.Drawing.Size(1108, 25);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Location = new System.Drawing.Point(682, 0);
            // 
            // lblMainESC
            // 
            this.lblMainESC.Location = new System.Drawing.Point(711, 0);
            // 
            // pnMenu
            // 
            this.pnMenu.Size = new System.Drawing.Size(1, 573);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(4, 4);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage2;
            this.xtraTabControl1.Size = new System.Drawing.Size(1099, 565);
            this.xtraTabControl1.TabIndex = 128;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage2,
            this.xtraTabPage1});
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gcTSCD1);
            this.xtraTabPage2.Controls.Add(this.ucGroupHeader1);
            this.xtraTabPage2.Controls.Add(this.panel1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1097, 540);
            this.xtraTabPage2.Text = "Quản lý tài sản cố định";
            // 
            // gcTSCD1
            // 
            this.gcTSCD1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTSCD1.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Arial", 8F);
            this.gcTSCD1.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gcTSCD1.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcTSCD1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcTSCD1.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcTSCD1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcTSCD1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcTSCD1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0);
            this.gcTSCD1.EmbeddedNavigator.TextStringFormat = "Dòng {0}/{1}";
            this.gcTSCD1.Location = new System.Drawing.Point(0, 237);
            this.gcTSCD1.MainView = this.gvTSCD1;
            this.gcTSCD1.Margin = new System.Windows.Forms.Padding(0);
            this.gcTSCD1.Name = "gcTSCD1";
            this.gcTSCD1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit3,
            this.repositoryItemGridLookUpEdit4});
            this.gcTSCD1.Size = new System.Drawing.Size(1097, 303);
            this.gcTSCD1.TabIndex = 188;
            this.gcTSCD1.UseEmbeddedNavigator = true;
            this.gcTSCD1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTSCD1});
            // 
            // gvTSCD1
            // 
            this.gvTSCD1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaTS,
            this.colTenTS,
            this.colQuantity,
            this.colTinhTrang,
            this.colDonViSD});
            this.gvTSCD1.DetailHeight = 284;
            this.gvTSCD1.GridControl = this.gcTSCD1;
            this.gvTSCD1.GroupFormat = "{0}: [#image]{1}  -  {2}";
            this.gvTSCD1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GiaRieng", null, "{0:N0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TienCong", null, "{0:N0}")});
            this.gvTSCD1.Name = "gvTSCD1";
            this.gvTSCD1.OptionsSelection.CheckBoxSelectorColumnWidth = 26;
            this.gvTSCD1.OptionsSelection.MultiSelect = true;
            this.gvTSCD1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvTSCD1.OptionsView.ColumnAutoWidth = false;
            this.gvTSCD1.OptionsView.ShowFooter = true;
            this.gvTSCD1.OptionsView.ShowGroupPanel = false;
            this.gvTSCD1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvTSCD1_CellValueChanged);
            // 
            // colMaTS
            // 
            this.colMaTS.Caption = "Mã tài sản";
            this.colMaTS.FieldName = "mataisan";
            this.colMaTS.MinWidth = 17;
            this.colMaTS.Name = "colMaTS";
            this.colMaTS.OptionsColumn.ReadOnly = true;
            this.colMaTS.Visible = true;
            this.colMaTS.VisibleIndex = 1;
            this.colMaTS.Width = 90;
            // 
            // colTenTS
            // 
            this.colTenTS.Caption = "Tên tài sản";
            this.colTenTS.FieldName = "tentaisan";
            this.colTenTS.Name = "colTenTS";
            this.colTenTS.Visible = true;
            this.colTenTS.VisibleIndex = 2;
            this.colTenTS.Width = 191;
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "Số lượng";
            this.colQuantity.FieldName = "quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 5;
            this.colQuantity.Width = 112;
            // 
            // colTinhTrang
            // 
            this.colTinhTrang.Caption = "Tình trạng";
            this.colTinhTrang.FieldName = "tinhtrang";
            this.colTinhTrang.Name = "colTinhTrang";
            this.colTinhTrang.Visible = true;
            this.colTinhTrang.VisibleIndex = 3;
            this.colTinhTrang.Width = 114;
            // 
            // colDonViSD
            // 
            this.colDonViSD.Caption = "Đơn vị sử dụng";
            this.colDonViSD.FieldName = "donvisudung";
            this.colDonViSD.Name = "colDonViSD";
            this.colDonViSD.Visible = true;
            this.colDonViSD.VisibleIndex = 4;
            this.colDonViSD.Width = 174;
            // 
            // repositoryItemGridLookUpEdit3
            // 
            this.repositoryItemGridLookUpEdit3.AutoHeight = false;
            this.repositoryItemGridLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit3.DisplayMember = "tendonvi";
            this.repositoryItemGridLookUpEdit3.Name = "repositoryItemGridLookUpEdit3";
            this.repositoryItemGridLookUpEdit3.NullText = "[Chưa chọn]";
            this.repositoryItemGridLookUpEdit3.PopupView = this.gridView2;
            this.repositoryItemGridLookUpEdit3.ValueMember = "madonvi";
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemGridLookUpEdit4
            // 
            this.repositoryItemGridLookUpEdit4.AutoHeight = false;
            this.repositoryItemGridLookUpEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit4.DisplayMember = "tendanhmuc";
            this.repositoryItemGridLookUpEdit4.Name = "repositoryItemGridLookUpEdit4";
            this.repositoryItemGridLookUpEdit4.NullText = "[Chưa chọn]";
            this.repositoryItemGridLookUpEdit4.PopupView = this.gridView5;
            this.repositoryItemGridLookUpEdit4.ValueMember = "madanhmuc";
            // 
            // gridView5
            // 
            this.gridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            // 
            // ucGroupHeader1
            // 
            this.ucGroupHeader1.BackColor = System.Drawing.Color.Transparent;
            this.ucGroupHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(218)))), ((int)(((byte)(89)))));
            this.ucGroupHeader1.GroupCaption = "DANH MỤC TÀI SẢN CỐ ĐỊNH";
            this.ucGroupHeader1.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader1.Location = new System.Drawing.Point(0, 214);
            this.ucGroupHeader1.Margin = new System.Windows.Forms.Padding(0);
            this.ucGroupHeader1.MaximumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader1.MinimumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader1.Name = "ucGroupHeader1";
            this.ucGroupHeader1.Size = new System.Drawing.Size(1097, 23);
            this.ucGroupHeader1.TabIndex = 103;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelControl4);
            this.panel1.Controls.Add(this.txtDVSD);
            this.panel1.Controls.Add(this.txtQuantity);
            this.panel1.Controls.Add(this.labelControl5);
            this.panel1.Controls.Add(this.txtTT);
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.btnRefreshItem);
            this.panel1.Controls.Add(this.btnXoaItem);
            this.panel1.Controls.Add(this.btnThemItem);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.txtMaTS);
            this.panel1.Controls.Add(this.txtTenTS);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.ucGroupHeader3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1097, 214);
            this.panel1.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(421, 64);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(84, 15);
            this.labelControl4.TabIndex = 185;
            this.labelControl4.Text = "Đơn vị sử dụng";
            // 
            // txtDVSD
            // 
            this.txtDVSD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDVSD.Location = new System.Drawing.Point(522, 60);
            this.txtDVSD.Margin = new System.Windows.Forms.Padding(0);
            this.txtDVSD.MaxLength = 20;
            this.txtDVSD.Name = "txtDVSD";
            this.txtDVSD.Size = new System.Drawing.Size(183, 22);
            this.txtDVSD.TabIndex = 184;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.ForeColor = System.Drawing.Color.Black;
            this.txtQuantity.Location = new System.Drawing.Point(101, 91);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(0);
            this.txtQuantity.MaxLength = 50;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(269, 23);
            this.txtQuantity.TabIndex = 183;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(450, 37);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(55, 15);
            this.labelControl5.TabIndex = 182;
            this.labelControl5.Text = "Tình trạng";
            // 
            // txtTT
            // 
            this.txtTT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTT.Location = new System.Drawing.Point(522, 33);
            this.txtTT.Margin = new System.Windows.Forms.Padding(0);
            this.txtTT.MaxLength = 20;
            this.txtTT.Name = "txtTT";
            this.txtTT.Size = new System.Drawing.Size(183, 22);
            this.txtTT.TabIndex = 181;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(39, 95);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(51, 15);
            this.labelControl3.TabIndex = 177;
            this.labelControl3.Text = "Số lượng";
            // 
            // btnRefreshItem
            // 
            this.btnRefreshItem.BackColor = System.Drawing.Color.White;
            this.btnRefreshItem.BackColorHover = System.Drawing.Color.Empty;
            this.btnRefreshItem.BackgroundColor = System.Drawing.Color.White;
            this.btnRefreshItem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnRefreshItem.BorderRadius = 5;
            this.btnRefreshItem.BorderSize = 1;
            this.btnRefreshItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshItem.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefreshItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshItem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshItem.ForceColorHover = System.Drawing.Color.Empty;
            this.btnRefreshItem.ForeColor = System.Drawing.Color.Black;
            this.btnRefreshItem.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshItem.Image")));
            this.btnRefreshItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefreshItem.Location = new System.Drawing.Point(263, 167);
            this.btnRefreshItem.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefreshItem.Name = "btnRefreshItem";
            this.btnRefreshItem.Size = new System.Drawing.Size(109, 38);
            this.btnRefreshItem.TabIndex = 176;
            this.btnRefreshItem.Text = "Làm mới";
            this.btnRefreshItem.TextColor = System.Drawing.Color.Black;
            this.btnRefreshItem.UseHightLight = true;
            this.btnRefreshItem.UseVisualStyleBackColor = false;
            this.btnRefreshItem.Click += new System.EventHandler(this.btnRefreshItem_Click);
            // 
            // btnXoaItem
            // 
            this.btnXoaItem.BackColor = System.Drawing.Color.White;
            this.btnXoaItem.BackColorHover = System.Drawing.Color.Empty;
            this.btnXoaItem.BackgroundColor = System.Drawing.Color.White;
            this.btnXoaItem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXoaItem.BorderRadius = 5;
            this.btnXoaItem.BorderSize = 1;
            this.btnXoaItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaItem.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoaItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaItem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaItem.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXoaItem.ForeColor = System.Drawing.Color.Black;
            this.btnXoaItem.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaItem.Image")));
            this.btnXoaItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaItem.Location = new System.Drawing.Point(139, 167);
            this.btnXoaItem.Margin = new System.Windows.Forms.Padding(0);
            this.btnXoaItem.Name = "btnXoaItem";
            this.btnXoaItem.Size = new System.Drawing.Size(109, 38);
            this.btnXoaItem.TabIndex = 175;
            this.btnXoaItem.Text = "Xóa";
            this.btnXoaItem.TextColor = System.Drawing.Color.Black;
            this.btnXoaItem.UseHightLight = true;
            this.btnXoaItem.UseVisualStyleBackColor = false;
            this.btnXoaItem.Click += new System.EventHandler(this.btnXoaItem_Click);
            // 
            // btnThemItem
            // 
            this.btnThemItem.BackColor = System.Drawing.Color.White;
            this.btnThemItem.BackColorHover = System.Drawing.Color.Empty;
            this.btnThemItem.BackgroundColor = System.Drawing.Color.White;
            this.btnThemItem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThemItem.BorderRadius = 5;
            this.btnThemItem.BorderSize = 1;
            this.btnThemItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemItem.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemItem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemItem.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThemItem.ForeColor = System.Drawing.Color.Black;
            this.btnThemItem.Image = ((System.Drawing.Image)(resources.GetObject("btnThemItem.Image")));
            this.btnThemItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemItem.Location = new System.Drawing.Point(14, 167);
            this.btnThemItem.Margin = new System.Windows.Forms.Padding(0);
            this.btnThemItem.Name = "btnThemItem";
            this.btnThemItem.Size = new System.Drawing.Size(109, 38);
            this.btnThemItem.TabIndex = 174;
            this.btnThemItem.Text = "Thêm";
            this.btnThemItem.TextColor = System.Drawing.Color.Black;
            this.btnThemItem.UseHightLight = true;
            this.btnThemItem.UseVisualStyleBackColor = false;
            this.btnThemItem.Click += new System.EventHandler(this.btnThemItem_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(34, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 15);
            this.labelControl1.TabIndex = 172;
            this.labelControl1.Text = "Mã tài sản";
            // 
            // txtMaTS
            // 
            this.txtMaTS.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaTS.Location = new System.Drawing.Point(101, 33);
            this.txtMaTS.Margin = new System.Windows.Forms.Padding(0);
            this.txtMaTS.MaxLength = 20;
            this.txtMaTS.Name = "txtMaTS";
            this.txtMaTS.Size = new System.Drawing.Size(125, 23);
            this.txtMaTS.TabIndex = 170;
            // 
            // txtTenTS
            // 
            this.txtTenTS.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenTS.ForeColor = System.Drawing.Color.Black;
            this.txtTenTS.Location = new System.Drawing.Point(101, 60);
            this.txtTenTS.Margin = new System.Windows.Forms.Padding(0);
            this.txtTenTS.MaxLength = 50;
            this.txtTenTS.Name = "txtTenTS";
            this.txtTenTS.Size = new System.Drawing.Size(269, 23);
            this.txtTenTS.TabIndex = 171;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(29, 64);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 15);
            this.labelControl2.TabIndex = 173;
            this.labelControl2.Text = "Tên tài sản";
            // 
            // ucGroupHeader3
            // 
            this.ucGroupHeader3.BackColor = System.Drawing.Color.Transparent;
            this.ucGroupHeader3.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(218)))), ((int)(((byte)(89)))));
            this.ucGroupHeader3.GroupCaption = "KHAI BÁO TÀI SẢN CỐ ĐỊNH";
            this.ucGroupHeader3.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader3.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeader3.Margin = new System.Windows.Forms.Padding(0);
            this.ucGroupHeader3.MaximumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader3.MinimumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader3.Name = "ucGroupHeader3";
            this.ucGroupHeader3.Size = new System.Drawing.Size(1097, 23);
            this.ucGroupHeader3.TabIndex = 102;
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.groupBox2);
            this.xtraTabPage1.Controls.Add(this.groupBox1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1283, 603);
            this.xtraTabPage1.Text = "Danh sách tài sản cố định";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gcTSCD2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1283, 468);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách TSCD";
            // 
            // gcTSCD2
            // 
            this.gcTSCD2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTSCD2.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Arial", 8F);
            this.gcTSCD2.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gcTSCD2.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcTSCD2.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcTSCD2.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcTSCD2.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcTSCD2.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcTSCD2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0);
            this.gcTSCD2.EmbeddedNavigator.TextStringFormat = "Dòng {0}/{1}";
            this.gcTSCD2.Location = new System.Drawing.Point(3, 16);
            this.gcTSCD2.MainView = this.gvTSCD2;
            this.gcTSCD2.Margin = new System.Windows.Forms.Padding(0);
            this.gcTSCD2.Name = "gcTSCD2";
            this.gcTSCD2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit1,
            this.repositoryItemGridLookUpEdit2});
            this.gcTSCD2.Size = new System.Drawing.Size(1277, 449);
            this.gcTSCD2.TabIndex = 187;
            this.gcTSCD2.UseEmbeddedNavigator = true;
            this.gcTSCD2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTSCD2});
            // 
            // gvTSCD2
            // 
            this.gvTSCD2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn14,
            this.colOrderID,
            this.gridColumn2,
            this.gridColumn3});
            this.gvTSCD2.DetailHeight = 284;
            this.gvTSCD2.GridControl = this.gcTSCD2;
            this.gvTSCD2.GroupFormat = "{0}: [#image]{1}  -  {2}";
            this.gvTSCD2.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GiaRieng", null, "{0:N0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TienCong", null, "{0:N0}")});
            this.gvTSCD2.Name = "gvTSCD2";
            this.gvTSCD2.OptionsSelection.CheckBoxSelectorColumnWidth = 26;
            this.gvTSCD2.OptionsSelection.MultiSelect = true;
            this.gvTSCD2.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvTSCD2.OptionsView.ColumnAutoWidth = false;
            this.gvTSCD2.OptionsView.ShowFooter = true;
            this.gvTSCD2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã tài sản";
            this.gridColumn1.FieldName = "mataisan";
            this.gridColumn1.MinWidth = 17;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 90;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Tên tài sản";
            this.gridColumn14.FieldName = "tentaisan";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            this.gridColumn14.Width = 191;
            // 
            // colOrderID
            // 
            this.colOrderID.Caption = "Số lượng";
            this.colOrderID.FieldName = "quantity";
            this.colOrderID.Name = "colOrderID";
            this.colOrderID.Visible = true;
            this.colOrderID.VisibleIndex = 5;
            this.colOrderID.Width = 112;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tình trạng";
            this.gridColumn2.FieldName = "tinhtrang";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 114;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Đơn vị sử dụng";
            this.gridColumn3.FieldName = "donvisudung";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 174;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTimKiemTSCD);
            this.groupBox1.Controls.Add(this.txtMaDHTK);
            this.groupBox1.Controls.Add(this.labelControl16);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1283, 135);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều kiện";
            // 
            // btnTimKiemTSCD
            // 
            this.btnTimKiemTSCD.BackColor = System.Drawing.Color.White;
            this.btnTimKiemTSCD.BackColorHover = System.Drawing.Color.Empty;
            this.btnTimKiemTSCD.BackgroundColor = System.Drawing.Color.White;
            this.btnTimKiemTSCD.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnTimKiemTSCD.BorderRadius = 5;
            this.btnTimKiemTSCD.BorderSize = 1;
            this.btnTimKiemTSCD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiemTSCD.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiemTSCD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiemTSCD.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemTSCD.ForceColorHover = System.Drawing.Color.Empty;
            this.btnTimKiemTSCD.ForeColor = System.Drawing.Color.Black;
            this.btnTimKiemTSCD.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiemTSCD.Image")));
            this.btnTimKiemTSCD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiemTSCD.Location = new System.Drawing.Point(6, 85);
            this.btnTimKiemTSCD.Margin = new System.Windows.Forms.Padding(0);
            this.btnTimKiemTSCD.Name = "btnTimKiemTSCD";
            this.btnTimKiemTSCD.Size = new System.Drawing.Size(100, 35);
            this.btnTimKiemTSCD.TabIndex = 202;
            this.btnTimKiemTSCD.Text = "Tìm kiếm";
            this.btnTimKiemTSCD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiemTSCD.TextColor = System.Drawing.Color.Black;
            this.btnTimKiemTSCD.UseHightLight = true;
            this.btnTimKiemTSCD.UseVisualStyleBackColor = false;
            this.btnTimKiemTSCD.Click += new System.EventHandler(this.btnTimKiemTSCD_Click);
            // 
            // txtMaDHTK
            // 
            this.txtMaDHTK.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDHTK.Location = new System.Drawing.Point(96, 25);
            this.txtMaDHTK.Margin = new System.Windows.Forms.Padding(0);
            this.txtMaDHTK.MaxLength = 20;
            this.txtMaDHTK.Name = "txtMaDHTK";
            this.txtMaDHTK.Size = new System.Drawing.Size(125, 23);
            this.txtMaDHTK.TabIndex = 199;
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl16.Appearance.Options.UseFont = true;
            this.labelControl16.Location = new System.Drawing.Point(6, 29);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(72, 15);
            this.labelControl16.TabIndex = 198;
            this.labelControl16.Text = "Mã đơn hàng";
            // 
            // FrmTaiSanCoDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 598);
            this.Name = "FrmTaiSanCoDinh";
            this.Text = "QUẢN LÝ TÀI SẢN CỐ ĐỊNH";
            this.pnContaint.ResumeLayout(false);
            this.pnLabel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcTSCD1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTSCD1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.xtraTabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcTSCD2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTSCD2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private Common.Controls.ucGroupHeader ucGroupHeader1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.TextBox txtTT;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private Controls.TPHNormalButton btnRefreshItem;
        private Controls.TPHNormalButton btnXoaItem;
        private Controls.TPHNormalButton btnThemItem;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox txtMaTS;
        private System.Windows.Forms.TextBox txtTenTS;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private Common.Controls.ucGroupHeader ucGroupHeader3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.TPHNormalButton btnTimKiemTSCD;
        private System.Windows.Forms.TextBox txtMaDHTK;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private System.Windows.Forms.GroupBox groupBox2;
        public DevExpress.XtraGrid.GridControl gcTSCD2;
        public DevExpress.XtraGrid.Views.Grid.GridView gvTSCD2;
        public DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderID;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.TextBox txtDVSD;
        private System.Windows.Forms.TextBox txtQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        public DevExpress.XtraGrid.GridControl gcTSCD1;
        public DevExpress.XtraGrid.Views.Grid.GridView gvTSCD1;
        public DevExpress.XtraGrid.Columns.GridColumn colMaTS;
        private DevExpress.XtraGrid.Columns.GridColumn colTenTS;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colTinhTrang;
        private DevExpress.XtraGrid.Columns.GridColumn colDonViSD;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
    }
}