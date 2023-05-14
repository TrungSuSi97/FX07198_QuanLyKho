namespace TPH.LIS.App.QuanLyHangHoa
{
    partial class FrmTonKho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTonKho));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTimKiemDSDH = new TPH.Controls.TPHNormalButton();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gcDSDH = new DevExpress.XtraGrid.GridControl();
            this.gvDSDH = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemGridLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ucSearchLookupEditor_HangHoaSanPham1 = new TPH.LIS.App.AppCode.ucSearchLookupEditor_HangHoaSanPham();
            this.ucSearchLookupEditor_DanhMucHangHoa1 = new TPH.LIS.App.AppCode.ucSearchLookupEditor_DanhMucHangHoa();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDSDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDSDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(1122, 25);
            this.lblTitle.Text = "TỒN KHO";
            // 
            // pnContaint
            // 
            this.pnContaint.Controls.Add(this.xtraTabControl1);
            this.pnContaint.Size = new System.Drawing.Size(1121, 591);
            // 
            // pnLabel
            // 
            this.pnLabel.Size = new System.Drawing.Size(1122, 25);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Location = new System.Drawing.Point(696, 0);
            // 
            // lblMainESC
            // 
            this.lblMainESC.Location = new System.Drawing.Point(725, 0);
            // 
            // pnMenu
            // 
            this.pnMenu.Size = new System.Drawing.Size(1, 591);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(4, 4);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1113, 583);
            this.xtraTabControl1.TabIndex = 184;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.groupBox2);
            this.xtraTabPage1.Controls.Add(this.groupBox1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1111, 558);
            this.xtraTabPage1.Text = "Tồn kho";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucSearchLookupEditor_HangHoaSanPham1);
            this.groupBox1.Controls.Add(this.ucSearchLookupEditor_DanhMucHangHoa1);
            this.groupBox1.Controls.Add(this.labelControl12);
            this.groupBox1.Controls.Add(this.labelControl11);
            this.groupBox1.Controls.Add(this.btnTimKiemDSDH);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.labelControl15);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.labelControl14);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1111, 165);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều kiện";
            // 
            // btnTimKiemDSDH
            // 
            this.btnTimKiemDSDH.BackColor = System.Drawing.Color.White;
            this.btnTimKiemDSDH.BackColorHover = System.Drawing.Color.Empty;
            this.btnTimKiemDSDH.BackgroundColor = System.Drawing.Color.White;
            this.btnTimKiemDSDH.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnTimKiemDSDH.BorderRadius = 5;
            this.btnTimKiemDSDH.BorderSize = 1;
            this.btnTimKiemDSDH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiemDSDH.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiemDSDH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiemDSDH.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemDSDH.ForceColorHover = System.Drawing.Color.Empty;
            this.btnTimKiemDSDH.ForeColor = System.Drawing.Color.Black;
            this.btnTimKiemDSDH.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiemDSDH.Image")));
            this.btnTimKiemDSDH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiemDSDH.Location = new System.Drawing.Point(6, 111);
            this.btnTimKiemDSDH.Margin = new System.Windows.Forms.Padding(0);
            this.btnTimKiemDSDH.Name = "btnTimKiemDSDH";
            this.btnTimKiemDSDH.Size = new System.Drawing.Size(100, 35);
            this.btnTimKiemDSDH.TabIndex = 202;
            this.btnTimKiemDSDH.Text = "Tìm kiếm";
            this.btnTimKiemDSDH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiemDSDH.TextColor = System.Drawing.Color.Black;
            this.btnTimKiemDSDH.UseHightLight = true;
            this.btnTimKiemDSDH.UseVisualStyleBackColor = false;
            this.btnTimKiemDSDH.Click += new System.EventHandler(this.btnTimKiemDSDH_Click);
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(318, 14);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(138, 20);
            this.dtpToDate.TabIndex = 197;
            this.dtpToDate.Value = new System.DateTime(2023, 5, 13, 0, 0, 0, 0);
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Location = new System.Drawing.Point(289, 19);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(23, 15);
            this.labelControl15.TabIndex = 196;
            this.labelControl15.Text = "Đến";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(96, 14);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(125, 20);
            this.dtpFromDate.TabIndex = 195;
            this.dtpFromDate.Value = new System.DateTime(2023, 5, 13, 0, 0, 0, 0);
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Location = new System.Drawing.Point(34, 19);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(44, 15);
            this.labelControl14.TabIndex = 194;
            this.labelControl14.Text = "Từ ngày";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gcDSDH);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1111, 393);
            this.groupBox2.TabIndex = 205;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách nhập hàng";
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
            this.gcDSDH.Size = new System.Drawing.Size(1105, 374);
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
            this.colInID,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
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
            this.gridColumn1.Caption = "Mã sản phẩm";
            this.gridColumn1.FieldName = "itemcode";
            this.gridColumn1.MinWidth = 17;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 90;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ngày tạo";
            this.gridColumn2.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "datein";
            this.gridColumn2.MinWidth = 17;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 163;
            // 
            // colInID
            // 
            this.colInID.Caption = "Tên danh mục";
            this.colInID.FieldName = "tendanhmuc";
            this.colInID.Name = "colInID";
            this.colInID.Visible = true;
            this.colInID.VisibleIndex = 5;
            this.colInID.Width = 79;
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
            // ucSearchLookupEditor_HangHoaSanPham1
            // 
            this.ucSearchLookupEditor_HangHoaSanPham1.CatchEnterKey = false;
            this.ucSearchLookupEditor_HangHoaSanPham1.CatchTabKey = false;
            this.ucSearchLookupEditor_HangHoaSanPham1.ControlBack = null;
            this.ucSearchLookupEditor_HangHoaSanPham1.ControlNext = null;
            this.ucSearchLookupEditor_HangHoaSanPham1.DisplayMember = "";
            this.ucSearchLookupEditor_HangHoaSanPham1.Location = new System.Drawing.Point(357, 44);
            this.ucSearchLookupEditor_HangHoaSanPham1.Name = "ucSearchLookupEditor_HangHoaSanPham1";
            this.ucSearchLookupEditor_HangHoaSanPham1.SelectedValue = null;
            this.ucSearchLookupEditor_HangHoaSanPham1.Size = new System.Drawing.Size(180, 23);
            this.ucSearchLookupEditor_HangHoaSanPham1.TabIndex = 206;
            this.ucSearchLookupEditor_HangHoaSanPham1.ValueMember = "";
            // 
            // ucSearchLookupEditor_DanhMucHangHoa1
            // 
            this.ucSearchLookupEditor_DanhMucHangHoa1.CatchEnterKey = false;
            this.ucSearchLookupEditor_DanhMucHangHoa1.CatchTabKey = false;
            this.ucSearchLookupEditor_DanhMucHangHoa1.ControlBack = null;
            this.ucSearchLookupEditor_DanhMucHangHoa1.ControlNext = null;
            this.ucSearchLookupEditor_DanhMucHangHoa1.DisplayMember = "";
            this.ucSearchLookupEditor_DanhMucHangHoa1.Location = new System.Drawing.Point(96, 44);
            this.ucSearchLookupEditor_DanhMucHangHoa1.Name = "ucSearchLookupEditor_DanhMucHangHoa1";
            this.ucSearchLookupEditor_DanhMucHangHoa1.SelectedValue = null;
            this.ucSearchLookupEditor_DanhMucHangHoa1.Size = new System.Drawing.Size(180, 23);
            this.ucSearchLookupEditor_DanhMucHangHoa1.TabIndex = 205;
            this.ucSearchLookupEditor_DanhMucHangHoa1.ValueMember = "";
            this.ucSearchLookupEditor_DanhMucHangHoa1.EditValueChanged += new System.EventHandler(this.ucSearchLookupEditor_DanhMucHangHoa1_EditValueChanged_1);
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(289, 52);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(57, 15);
            this.labelControl12.TabIndex = 204;
            this.labelControl12.Text = "Sản phẩm";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(21, 52);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(57, 15);
            this.labelControl11.TabIndex = 203;
            this.labelControl11.Text = "Danh mục";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tên đơn vị";
            this.gridColumn3.FieldName = "tendonvi";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tổng số lượng hàng";
            this.gridColumn4.FieldName = "tongsoluonghang";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            this.gridColumn4.Width = 105;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Số lượng hàng đã xuất";
            this.gridColumn5.FieldName = "tongsoluonghangdaxuat";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            this.gridColumn5.Width = 118;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Số lượng hàng còn lại";
            this.gridColumn6.FieldName = "tongsoluonghangconlai";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            this.gridColumn6.Width = 113;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Tên sản phẩm";
            this.gridColumn7.FieldName = "itemname";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 78;
            // 
            // FrmTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 616);
            this.Name = "FrmTonKho";
            this.Text = "TỒN KHO";
            this.Load += new System.EventHandler(this.FrmDonHang_Load);
            this.pnContaint.ResumeLayout(false);
            this.pnLabel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDSDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDSDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.TPHNormalButton btnTimKiemDSDH;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private System.Windows.Forms.GroupBox groupBox2;
        public DevExpress.XtraGrid.GridControl gcDSDH;
        public DevExpress.XtraGrid.Views.Grid.GridView gvDSDH;
        public DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        public DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colInID;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private AppCode.ucSearchLookupEditor_HangHoaSanPham ucSearchLookupEditor_HangHoaSanPham1;
        private AppCode.ucSearchLookupEditor_DanhMucHangHoa ucSearchLookupEditor_DanhMucHangHoa1;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
    }
}