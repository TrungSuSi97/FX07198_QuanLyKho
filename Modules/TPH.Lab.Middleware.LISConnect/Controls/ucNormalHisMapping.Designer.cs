namespace TPH.Lab.Middleware.LISConnect.Controls
{
    partial class ucNormalHisMapping
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucNormalHisMapping));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcDanhSachLIS = new DevExpress.XtraGrid.GridControl();
            this.gvDanhSachLIS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLIS_LISID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLIS_TenDMLIS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLIS_HISID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLIS_NguoiNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLIS_TGMapping = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLIS_CategoryID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLIS_HISProviderID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLIS_MaCaptren = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLamMoidanhSachLIS = new TPH.Controls.TPHNormalButton();
            this.ucGroupHeader1 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gcDanhSachHIS = new DevExpress.XtraGrid.GridControl();
            this.gvDanhSachHIS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colHIS_HISID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHIS_ItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHIS_MasterID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHIS_InternalPatient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMappingHIS = new TPH.Controls.TPHNormalButton();
            this.btnLoadDSHIS = new TPH.Controls.TPHNormalButton();
            this.btnDongBoLIS = new TPH.Controls.TPHNormalButton();
            this.ucGroupHeader2 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.ucGroupHeader5 = new TPH.LIS.Common.Controls.ucGroupHeader();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSachLIS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSachLIS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSachHIS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSachHIS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 29);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.gcDanhSachLIS);
            this.splitContainerControl1.Panel1.Controls.Add(this.panel2);
            this.splitContainerControl1.Panel1.Controls.Add(this.ucGroupHeader1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.progressBar1);
            this.splitContainerControl1.Panel2.Controls.Add(this.gcDanhSachHIS);
            this.splitContainerControl1.Panel2.Controls.Add(this.panel1);
            this.splitContainerControl1.Panel2.Controls.Add(this.ucGroupHeader2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1012, 508);
            this.splitContainerControl1.SplitterPosition = 506;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gcDanhSachLIS
            // 
            this.gcDanhSachLIS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhSachLIS.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.gcDanhSachLIS.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gcDanhSachLIS.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcDanhSachLIS.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcDanhSachLIS.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcDanhSachLIS.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcDanhSachLIS.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcDanhSachLIS.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.gcDanhSachLIS.EmbeddedNavigator.TextStringFormat = "{0} of {1}";
            this.gcDanhSachLIS.Location = new System.Drawing.Point(0, 20);
            this.gcDanhSachLIS.MainView = this.gvDanhSachLIS;
            this.gcDanhSachLIS.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.gcDanhSachLIS.Name = "gcDanhSachLIS";
            this.gcDanhSachLIS.Size = new System.Drawing.Size(506, 449);
            this.gcDanhSachLIS.TabIndex = 371;
            this.gcDanhSachLIS.UseEmbeddedNavigator = true;
            this.gcDanhSachLIS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhSachLIS,
            this.gridView2});
            // 
            // gvDanhSachLIS
            // 
            this.gvDanhSachLIS.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSachLIS.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSachLIS.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSachLIS.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.DetailTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSachLIS.Appearance.DetailTip.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.Empty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSachLIS.Appearance.Empty.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.EvenRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSachLIS.Appearance.EvenRow.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSachLIS.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.FilterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSachLIS.Appearance.FilterPanel.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.FixedLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSachLIS.Appearance.FixedLine.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvDanhSachLIS.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSachLIS.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvDanhSachLIS.Appearance.FocusedCell.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 10F);
            this.gvDanhSachLIS.Appearance.FocusedRow.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhSachLIS.Appearance.FooterPanel.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhSachLIS.Appearance.GroupButton.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.GroupFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhSachLIS.Appearance.GroupFooter.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.GroupPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSachLIS.Appearance.GroupPanel.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.gvDanhSachLIS.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvDanhSachLIS.Appearance.GroupRow.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvDanhSachLIS.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.gvDanhSachLIS.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSachLIS.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSachLIS.Appearance.HorzLine.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSachLIS.Appearance.OddRow.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSachLIS.Appearance.Preview.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.Row.Font = new System.Drawing.Font("Arial", 10F);
            this.gvDanhSachLIS.Appearance.Row.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSachLIS.Appearance.RowSeparator.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvDanhSachLIS.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSachLIS.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvDanhSachLIS.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvDanhSachLIS.Appearance.SelectedRow.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvDanhSachLIS.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSachLIS.Appearance.TopNewRow.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSachLIS.Appearance.VertLine.Options.UseFont = true;
            this.gvDanhSachLIS.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSachLIS.Appearance.ViewCaption.Options.UseFont = true;
            this.gvDanhSachLIS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLIS_LISID,
            this.colLIS_TenDMLIS,
            this.colLIS_HISID,
            this.colLIS_NguoiNhap,
            this.colLIS_TGMapping,
            this.colLIS_CategoryID,
            this.colLIS_HISProviderID,
            this.colLIS_MaCaptren});
            this.gvDanhSachLIS.DetailHeight = 284;
            this.gvDanhSachLIS.GridControl = this.gcDanhSachLIS;
            this.gvDanhSachLIS.Name = "gvDanhSachLIS";
            this.gvDanhSachLIS.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvDanhSachLIS.OptionsSelection.CheckBoxSelectorColumnWidth = 26;
            this.gvDanhSachLIS.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gvDanhSachLIS.OptionsView.ColumnAutoWidth = false;
            this.gvDanhSachLIS.OptionsView.RowAutoHeight = true;
            this.gvDanhSachLIS.OptionsView.ShowAutoFilterRow = true;
            this.gvDanhSachLIS.OptionsView.ShowGroupPanel = false;
            this.gvDanhSachLIS.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvDanhSachLIS_CellValueChanged);
            this.gvDanhSachLIS.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvDanhSachLIS_CellValueChanging);
            // 
            // colLIS_LISID
            // 
            this.colLIS_LISID.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
            this.colLIS_LISID.AppearanceCell.Options.UseBackColor = true;
            this.colLIS_LISID.Caption = "Mã LIS";
            this.colLIS_LISID.FieldName = "lisid";
            this.colLIS_LISID.MinWidth = 17;
            this.colLIS_LISID.Name = "colLIS_LISID";
            this.colLIS_LISID.OptionsColumn.ReadOnly = true;
            this.colLIS_LISID.Visible = true;
            this.colLIS_LISID.VisibleIndex = 0;
            this.colLIS_LISID.Width = 83;
            // 
            // colLIS_TenDMLIS
            // 
            this.colLIS_TenDMLIS.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
            this.colLIS_TenDMLIS.AppearanceCell.Options.UseBackColor = true;
            this.colLIS_TenDMLIS.Caption = "Tên danh mục LIS";
            this.colLIS_TenDMLIS.FieldName = "itemname";
            this.colLIS_TenDMLIS.MinWidth = 17;
            this.colLIS_TenDMLIS.Name = "colLIS_TenDMLIS";
            this.colLIS_TenDMLIS.OptionsColumn.ReadOnly = true;
            this.colLIS_TenDMLIS.Visible = true;
            this.colLIS_TenDMLIS.VisibleIndex = 1;
            this.colLIS_TenDMLIS.Width = 198;
            // 
            // colLIS_HISID
            // 
            this.colLIS_HISID.Caption = "Mã HIS";
            this.colLIS_HISID.FieldName = "hisid";
            this.colLIS_HISID.MinWidth = 17;
            this.colLIS_HISID.Name = "colLIS_HISID";
            this.colLIS_HISID.Visible = true;
            this.colLIS_HISID.VisibleIndex = 2;
            this.colLIS_HISID.Width = 99;
            // 
            // colLIS_NguoiNhap
            // 
            this.colLIS_NguoiNhap.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
            this.colLIS_NguoiNhap.AppearanceCell.Options.UseBackColor = true;
            this.colLIS_NguoiNhap.Caption = "Người nhập";
            this.colLIS_NguoiNhap.FieldName = "NguoiNhap";
            this.colLIS_NguoiNhap.MinWidth = 17;
            this.colLIS_NguoiNhap.Name = "colLIS_NguoiNhap";
            this.colLIS_NguoiNhap.OptionsColumn.ReadOnly = true;
            this.colLIS_NguoiNhap.Visible = true;
            this.colLIS_NguoiNhap.VisibleIndex = 4;
            this.colLIS_NguoiNhap.Width = 100;
            // 
            // colLIS_TGMapping
            // 
            this.colLIS_TGMapping.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
            this.colLIS_TGMapping.AppearanceCell.Options.UseBackColor = true;
            this.colLIS_TGMapping.Caption = "TG nhập";
            this.colLIS_TGMapping.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.colLIS_TGMapping.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLIS_TGMapping.FieldName = "TGNhap";
            this.colLIS_TGMapping.MinWidth = 17;
            this.colLIS_TGMapping.Name = "colLIS_TGMapping";
            this.colLIS_TGMapping.OptionsColumn.ReadOnly = true;
            this.colLIS_TGMapping.Visible = true;
            this.colLIS_TGMapping.VisibleIndex = 5;
            // 
            // colLIS_CategoryID
            // 
            this.colLIS_CategoryID.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
            this.colLIS_CategoryID.AppearanceCell.Options.UseBackColor = true;
            this.colLIS_CategoryID.Caption = "ID danh mục LIS";
            this.colLIS_CategoryID.FieldName = "CategoryID";
            this.colLIS_CategoryID.MinWidth = 17;
            this.colLIS_CategoryID.Name = "colLIS_CategoryID";
            this.colLIS_CategoryID.OptionsColumn.ReadOnly = true;
            this.colLIS_CategoryID.Visible = true;
            this.colLIS_CategoryID.VisibleIndex = 6;
            this.colLIS_CategoryID.Width = 104;
            // 
            // colLIS_HISProviderID
            // 
            this.colLIS_HISProviderID.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
            this.colLIS_HISProviderID.AppearanceCell.Options.UseBackColor = true;
            this.colLIS_HISProviderID.Caption = "ID HIS kết nối";
            this.colLIS_HISProviderID.FieldName = "HisProviderID";
            this.colLIS_HISProviderID.MinWidth = 17;
            this.colLIS_HISProviderID.Name = "colLIS_HISProviderID";
            this.colLIS_HISProviderID.OptionsColumn.ReadOnly = true;
            this.colLIS_HISProviderID.Visible = true;
            this.colLIS_HISProviderID.VisibleIndex = 7;
            this.colLIS_HISProviderID.Width = 88;
            // 
            // colLIS_MaCaptren
            // 
            this.colLIS_MaCaptren.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
            this.colLIS_MaCaptren.AppearanceCell.Options.UseBackColor = true;
            this.colLIS_MaCaptren.Caption = "Mã cấp trên";
            this.colLIS_MaCaptren.FieldName = "MasterID";
            this.colLIS_MaCaptren.MinWidth = 17;
            this.colLIS_MaCaptren.Name = "colLIS_MaCaptren";
            this.colLIS_MaCaptren.OptionsColumn.ReadOnly = true;
            this.colLIS_MaCaptren.Visible = true;
            this.colLIS_MaCaptren.VisibleIndex = 3;
            this.colLIS_MaCaptren.Width = 79;
            // 
            // gridView2
            // 
            this.gridView2.DetailHeight = 284;
            this.gridView2.GridControl = this.gcDanhSachLIS;
            this.gridView2.Name = "gridView2";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLamMoidanhSachLIS);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("Arial", 10F);
            this.panel2.Location = new System.Drawing.Point(0, 469);
            this.panel2.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(506, 37);
            this.panel2.TabIndex = 373;
            // 
            // btnLamMoidanhSachLIS
            // 
            this.btnLamMoidanhSachLIS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLamMoidanhSachLIS.BackColor = System.Drawing.SystemColors.Control;
            this.btnLamMoidanhSachLIS.BackColorHover = System.Drawing.Color.Empty;
            this.btnLamMoidanhSachLIS.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnLamMoidanhSachLIS.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoidanhSachLIS.BorderRadius = 5;
            this.btnLamMoidanhSachLIS.BorderSize = 1;
            this.btnLamMoidanhSachLIS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoidanhSachLIS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoidanhSachLIS.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoidanhSachLIS.ForceColorHover = System.Drawing.Color.Empty;
            this.btnLamMoidanhSachLIS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLamMoidanhSachLIS.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoidanhSachLIS.Image")));
            this.btnLamMoidanhSachLIS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLamMoidanhSachLIS.Location = new System.Drawing.Point(189, 5);
            this.btnLamMoidanhSachLIS.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnLamMoidanhSachLIS.Name = "btnLamMoidanhSachLIS";
            this.btnLamMoidanhSachLIS.Size = new System.Drawing.Size(152, 25);
            this.btnLamMoidanhSachLIS.TabIndex = 44;
            this.btnLamMoidanhSachLIS.Text = "Đọc danh sách LIS";
            this.btnLamMoidanhSachLIS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLamMoidanhSachLIS.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnLamMoidanhSachLIS.UseHightLight = true;
            this.btnLamMoidanhSachLIS.UseVisualStyleBackColor = true;
            this.btnLamMoidanhSachLIS.Click += new System.EventHandler(this.btnLamMoidanhSachLIS_Click);
            // 
            // ucGroupHeader1
            // 
            this.ucGroupHeader1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader1.ForeColor = System.Drawing.Color.Yellow;
            this.ucGroupHeader1.GroupCaption = "DANH MỤC MAPPING TRÊN LIS";
            this.ucGroupHeader1.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader1.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeader1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.ucGroupHeader1.Name = "ucGroupHeader1";
            this.ucGroupHeader1.Size = new System.Drawing.Size(506, 20);
            this.ucGroupHeader1.TabIndex = 378;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar1.Location = new System.Drawing.Point(109, 226);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(311, 19);
            this.progressBar1.TabIndex = 373;
            this.progressBar1.Visible = false;
            // 
            // gcDanhSachHIS
            // 
            this.gcDanhSachHIS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhSachHIS.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.gcDanhSachHIS.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gcDanhSachHIS.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcDanhSachHIS.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcDanhSachHIS.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcDanhSachHIS.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcDanhSachHIS.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcDanhSachHIS.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.gcDanhSachHIS.EmbeddedNavigator.TextStringFormat = "{0} of {1}";
            this.gcDanhSachHIS.Location = new System.Drawing.Point(0, 20);
            this.gcDanhSachHIS.MainView = this.gvDanhSachHIS;
            this.gcDanhSachHIS.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.gcDanhSachHIS.Name = "gcDanhSachHIS";
            this.gcDanhSachHIS.Size = new System.Drawing.Size(496, 449);
            this.gcDanhSachHIS.TabIndex = 371;
            this.gcDanhSachHIS.UseEmbeddedNavigator = true;
            this.gcDanhSachHIS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhSachHIS,
            this.gridView1});
            // 
            // gvDanhSachHIS
            // 
            this.gvDanhSachHIS.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSachHIS.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSachHIS.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSachHIS.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.DetailTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSachHIS.Appearance.DetailTip.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.Empty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSachHIS.Appearance.Empty.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.EvenRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSachHIS.Appearance.EvenRow.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSachHIS.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.FilterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSachHIS.Appearance.FilterPanel.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.FixedLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSachHIS.Appearance.FixedLine.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvDanhSachHIS.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSachHIS.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvDanhSachHIS.Appearance.FocusedCell.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 10F);
            this.gvDanhSachHIS.Appearance.FocusedRow.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhSachHIS.Appearance.FooterPanel.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhSachHIS.Appearance.GroupButton.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.GroupFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhSachHIS.Appearance.GroupFooter.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.GroupPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSachHIS.Appearance.GroupPanel.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.gvDanhSachHIS.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvDanhSachHIS.Appearance.GroupRow.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvDanhSachHIS.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.gvDanhSachHIS.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSachHIS.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSachHIS.Appearance.HorzLine.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSachHIS.Appearance.OddRow.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSachHIS.Appearance.Preview.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.Row.Font = new System.Drawing.Font("Arial", 10F);
            this.gvDanhSachHIS.Appearance.Row.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSachHIS.Appearance.RowSeparator.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvDanhSachHIS.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSachHIS.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvDanhSachHIS.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvDanhSachHIS.Appearance.SelectedRow.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvDanhSachHIS.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSachHIS.Appearance.TopNewRow.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSachHIS.Appearance.VertLine.Options.UseFont = true;
            this.gvDanhSachHIS.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSachHIS.Appearance.ViewCaption.Options.UseFont = true;
            this.gvDanhSachHIS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHIS_HISID,
            this.colHIS_ItemName,
            this.colHIS_MasterID,
            this.colHIS_InternalPatient});
            this.gvDanhSachHIS.DetailHeight = 284;
            this.gvDanhSachHIS.GridControl = this.gcDanhSachHIS;
            this.gvDanhSachHIS.Name = "gvDanhSachHIS";
            this.gvDanhSachHIS.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvDanhSachHIS.OptionsSelection.CheckBoxSelectorColumnWidth = 26;
            this.gvDanhSachHIS.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gvDanhSachHIS.OptionsView.ColumnAutoWidth = false;
            this.gvDanhSachHIS.OptionsView.RowAutoHeight = true;
            this.gvDanhSachHIS.OptionsView.ShowAutoFilterRow = true;
            this.gvDanhSachHIS.OptionsView.ShowGroupPanel = false;
            // 
            // colHIS_HISID
            // 
            this.colHIS_HISID.Caption = "Mã danh mục HIS";
            this.colHIS_HISID.MinWidth = 17;
            this.colHIS_HISID.Name = "colHIS_HISID";
            this.colHIS_HISID.Visible = true;
            this.colHIS_HISID.VisibleIndex = 0;
            this.colHIS_HISID.Width = 113;
            // 
            // colHIS_ItemName
            // 
            this.colHIS_ItemName.Caption = "Tên danh mục HIS";
            this.colHIS_ItemName.MinWidth = 17;
            this.colHIS_ItemName.Name = "colHIS_ItemName";
            this.colHIS_ItemName.Visible = true;
            this.colHIS_ItemName.VisibleIndex = 1;
            this.colHIS_ItemName.Width = 233;
            // 
            // colHIS_MasterID
            // 
            this.colHIS_MasterID.Caption = "Mã cấp trên";
            this.colHIS_MasterID.MinWidth = 17;
            this.colHIS_MasterID.Name = "colHIS_MasterID";
            this.colHIS_MasterID.Visible = true;
            this.colHIS_MasterID.VisibleIndex = 2;
            this.colHIS_MasterID.Width = 105;
            // 
            // colHIS_InternalPatient
            // 
            this.colHIS_InternalPatient.Caption = "Nội trú";
            this.colHIS_InternalPatient.MinWidth = 17;
            this.colHIS_InternalPatient.Name = "colHIS_InternalPatient";
            this.colHIS_InternalPatient.Visible = true;
            this.colHIS_InternalPatient.VisibleIndex = 3;
            this.colHIS_InternalPatient.Width = 136;
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 284;
            this.gridView1.GridControl = this.gcDanhSachHIS;
            this.gridView1.Name = "gridView1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMappingHIS);
            this.panel1.Controls.Add(this.btnLoadDSHIS);
            this.panel1.Controls.Add(this.btnDongBoLIS);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Arial", 10F);
            this.panel1.Location = new System.Drawing.Point(0, 469);
            this.panel1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 37);
            this.panel1.TabIndex = 372;
            // 
            // btnMappingHIS
            // 
            this.btnMappingHIS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMappingHIS.BackColor = System.Drawing.SystemColors.Control;
            this.btnMappingHIS.BackColorHover = System.Drawing.Color.Empty;
            this.btnMappingHIS.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnMappingHIS.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMappingHIS.BorderRadius = 5;
            this.btnMappingHIS.BorderSize = 1;
            this.btnMappingHIS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMappingHIS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMappingHIS.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMappingHIS.ForceColorHover = System.Drawing.Color.Empty;
            this.btnMappingHIS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMappingHIS.Image = ((System.Drawing.Image)(resources.GetObject("btnMappingHIS.Image")));
            this.btnMappingHIS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMappingHIS.Location = new System.Drawing.Point(13, 6);
            this.btnMappingHIS.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnMappingHIS.Name = "btnMappingHIS";
            this.btnMappingHIS.Size = new System.Drawing.Size(185, 25);
            this.btnMappingHIS.TabIndex = 45;
            this.btnMappingHIS.Text = "Mapping dòng đang chọn";
            this.btnMappingHIS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMappingHIS.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnMappingHIS.UseHightLight = true;
            this.btnMappingHIS.UseVisualStyleBackColor = true;
            this.btnMappingHIS.Click += new System.EventHandler(this.btnMappingHIS_Click);
            // 
            // btnLoadDSHIS
            // 
            this.btnLoadDSHIS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLoadDSHIS.BackColor = System.Drawing.SystemColors.Control;
            this.btnLoadDSHIS.BackColorHover = System.Drawing.Color.Empty;
            this.btnLoadDSHIS.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnLoadDSHIS.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoadDSHIS.BorderRadius = 5;
            this.btnLoadDSHIS.BorderSize = 1;
            this.btnLoadDSHIS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadDSHIS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadDSHIS.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDSHIS.ForceColorHover = System.Drawing.Color.Empty;
            this.btnLoadDSHIS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLoadDSHIS.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadDSHIS.Image")));
            this.btnLoadDSHIS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadDSHIS.Location = new System.Drawing.Point(329, 6);
            this.btnLoadDSHIS.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnLoadDSHIS.Name = "btnLoadDSHIS";
            this.btnLoadDSHIS.Size = new System.Drawing.Size(155, 25);
            this.btnLoadDSHIS.TabIndex = 44;
            this.btnLoadDSHIS.Text = "Đọc danh sách HIS";
            this.btnLoadDSHIS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoadDSHIS.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnLoadDSHIS.UseHightLight = true;
            this.btnLoadDSHIS.UseVisualStyleBackColor = true;
            this.btnLoadDSHIS.Click += new System.EventHandler(this.btnLoadDSHIS_Click);
            // 
            // btnDongBoLIS
            // 
            this.btnDongBoLIS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDongBoLIS.BackColor = System.Drawing.SystemColors.Control;
            this.btnDongBoLIS.BackColorHover = System.Drawing.Color.Empty;
            this.btnDongBoLIS.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnDongBoLIS.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDongBoLIS.BorderRadius = 5;
            this.btnDongBoLIS.BorderSize = 1;
            this.btnDongBoLIS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDongBoLIS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDongBoLIS.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDongBoLIS.ForceColorHover = System.Drawing.Color.Empty;
            this.btnDongBoLIS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDongBoLIS.Image = ((System.Drawing.Image)(resources.GetObject("btnDongBoLIS.Image")));
            this.btnDongBoLIS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDongBoLIS.Location = new System.Drawing.Point(198, 6);
            this.btnDongBoLIS.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnDongBoLIS.Name = "btnDongBoLIS";
            this.btnDongBoLIS.Size = new System.Drawing.Size(131, 25);
            this.btnDongBoLIS.TabIndex = 43;
            this.btnDongBoLIS.Text = "Đồng bộ về LIS";
            this.btnDongBoLIS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDongBoLIS.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnDongBoLIS.UseHightLight = true;
            this.btnDongBoLIS.UseVisualStyleBackColor = true;
            this.btnDongBoLIS.Click += new System.EventHandler(this.btnDongBoLIS_Click);
            // 
            // ucGroupHeader2
            // 
            this.ucGroupHeader2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeader2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader2.ForeColor = System.Drawing.Color.Yellow;
            this.ucGroupHeader2.GroupCaption = "DANH MỤC NHẬN TỪ HIS";
            this.ucGroupHeader2.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader2.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeader2.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.ucGroupHeader2.Name = "ucGroupHeader2";
            this.ucGroupHeader2.Size = new System.Drawing.Size(496, 20);
            this.ucGroupHeader2.TabIndex = 379;
            // 
            // ucGroupHeader5
            // 
            this.ucGroupHeader5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeader5.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader5.ForeColor = System.Drawing.Color.Yellow;
            this.ucGroupHeader5.GroupCaption = "DANH MỤC";
            this.ucGroupHeader5.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ucGroupHeader5.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeader5.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.ucGroupHeader5.Name = "ucGroupHeader5";
            this.ucGroupHeader5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.ucGroupHeader5.Size = new System.Drawing.Size(1012, 29);
            this.ucGroupHeader5.TabIndex = 377;
            // 
            // ucNormalHisMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ucGroupHeader5);
            this.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.Name = "ucNormalHisMapping";
            this.Size = new System.Drawing.Size(1012, 537);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSachLIS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSachLIS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSachHIS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSachHIS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gcDanhSachLIS;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSachLIS;
        private DevExpress.XtraGrid.Columns.GridColumn colLIS_LISID;
        private DevExpress.XtraGrid.Columns.GridColumn colLIS_TenDMLIS;
        private DevExpress.XtraGrid.Columns.GridColumn colLIS_HISID;
        private DevExpress.XtraGrid.Columns.GridColumn colLIS_NguoiNhap;
        private DevExpress.XtraGrid.Columns.GridColumn colLIS_TGMapping;
        private DevExpress.XtraGrid.Columns.GridColumn colLIS_CategoryID;
        private DevExpress.XtraGrid.Columns.GridColumn colLIS_HISProviderID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl gcDanhSachHIS;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSachHIS;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colHIS_HISID;
        private DevExpress.XtraGrid.Columns.GridColumn colHIS_ItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colHIS_MasterID;
        private DevExpress.XtraGrid.Columns.GridColumn colHIS_InternalPatient;
        private System.Windows.Forms.Panel panel1;
        private TPH.Controls.TPHNormalButton btnLoadDSHIS;
        private TPH.Controls.TPHNormalButton btnDongBoLIS;
        private TPH.Controls.TPHNormalButton btnMappingHIS;
        private System.Windows.Forms.Panel panel2;
        private TPH.Controls.TPHNormalButton btnLamMoidanhSachLIS;
        private System.Windows.Forms.ProgressBar progressBar1;
        private DevExpress.XtraGrid.Columns.GridColumn colLIS_MaCaptren;
        private LIS.Common.Controls.ucGroupHeader ucGroupHeader1;
        private LIS.Common.Controls.ucGroupHeader ucGroupHeader2;
        private LIS.Common.Controls.ucGroupHeader ucGroupHeader5;
    }
}
