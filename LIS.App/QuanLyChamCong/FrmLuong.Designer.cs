namespace TPH.LIS.App.QuanLyChamCong
{
    partial class FrmLuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLuong));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExcel = new TPH.Controls.TPHNormalButton();
            this.btnTimKiem = new TPH.Controls.TPHNormalButton();
            this.ucSearchLookupEditor_ChucVu1 = new TPH.LIS.App.AppCode.ucSearchLookupEditor_ChucVu();
            this.ucSearchLookupEditor_NhanVien1 = new TPH.LIS.App.AppCode.ucSearchLookupEditor_NhanVien();
            this.ucSearchLookupEditor_BoPhan1 = new TPH.LIS.App.AppCode.ucSearchLookupEditor_BoPhan();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.ucGroupHeader3 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.ucGroupHeader1 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.gcDuLieuCC = new DevExpress.XtraGrid.GridControl();
            this.gvDuLieuCC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDuLieuCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDuLieuCC)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(918, 25);
            this.lblTitle.Text = "Lương";
            // 
            // pnContaint
            // 
            this.pnContaint.Controls.Add(this.xtraTabControl1);
            this.pnContaint.Size = new System.Drawing.Size(917, 561);
            // 
            // pnLabel
            // 
            this.pnLabel.Size = new System.Drawing.Size(918, 25);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Location = new System.Drawing.Point(492, 0);
            // 
            // lblMainESC
            // 
            this.lblMainESC.Location = new System.Drawing.Point(521, 0);
            // 
            // pnMenu
            // 
            this.pnMenu.Size = new System.Drawing.Size(1, 561);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(4, 4);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(909, 553);
            this.xtraTabControl1.TabIndex = 126;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gcDuLieuCC);
            this.xtraTabPage2.Controls.Add(this.ucGroupHeader1);
            this.xtraTabPage2.Controls.Add(this.panel1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(907, 528);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(237, 324);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.ucSearchLookupEditor_ChucVu1);
            this.panel1.Controls.Add(this.ucSearchLookupEditor_NhanVien1);
            this.panel1.Controls.Add(this.ucSearchLookupEditor_BoPhan1);
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.labelControl4);
            this.panel1.Controls.Add(this.labelControl5);
            this.panel1.Controls.Add(this.ucGroupHeader3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(907, 214);
            this.panel1.TabIndex = 1;
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.White;
            this.btnExcel.BackColorHover = System.Drawing.Color.Empty;
            this.btnExcel.BackgroundColor = System.Drawing.Color.White;
            this.btnExcel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnExcel.BorderRadius = 5;
            this.btnExcel.BorderSize = 1;
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.ForceColorHover = System.Drawing.Color.Empty;
            this.btnExcel.ForeColor = System.Drawing.Color.Black;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(140, 152);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(0);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(124, 38);
            this.btnExcel.TabIndex = 125;
            this.btnExcel.Text = "Xuất excel";
            this.btnExcel.TextColor = System.Drawing.Color.Black;
            this.btnExcel.UseHightLight = true;
            this.btnExcel.UseVisualStyleBackColor = false;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.White;
            this.btnTimKiem.BackColorHover = System.Drawing.Color.Empty;
            this.btnTimKiem.BackgroundColor = System.Drawing.Color.White;
            this.btnTimKiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnTimKiem.BorderRadius = 5;
            this.btnTimKiem.BorderSize = 1;
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForceColorHover = System.Drawing.Color.Empty;
            this.btnTimKiem.ForeColor = System.Drawing.Color.Black;
            this.btnTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiem.Image")));
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(21, 152);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(0);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(109, 38);
            this.btnTimKiem.TabIndex = 124;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.TextColor = System.Drawing.Color.Black;
            this.btnTimKiem.UseHightLight = true;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // ucSearchLookupEditor_ChucVu1
            // 
            this.ucSearchLookupEditor_ChucVu1.CatchEnterKey = false;
            this.ucSearchLookupEditor_ChucVu1.CatchTabKey = false;
            this.ucSearchLookupEditor_ChucVu1.ControlBack = null;
            this.ucSearchLookupEditor_ChucVu1.ControlNext = null;
            this.ucSearchLookupEditor_ChucVu1.DisplayMember = "";
            this.ucSearchLookupEditor_ChucVu1.Location = new System.Drawing.Point(111, 89);
            this.ucSearchLookupEditor_ChucVu1.Name = "ucSearchLookupEditor_ChucVu1";
            this.ucSearchLookupEditor_ChucVu1.SelectedValue = null;
            this.ucSearchLookupEditor_ChucVu1.Size = new System.Drawing.Size(127, 23);
            this.ucSearchLookupEditor_ChucVu1.TabIndex = 123;
            this.ucSearchLookupEditor_ChucVu1.ValueMember = "";
            // 
            // ucSearchLookupEditor_NhanVien1
            // 
            this.ucSearchLookupEditor_NhanVien1.CatchEnterKey = false;
            this.ucSearchLookupEditor_NhanVien1.CatchTabKey = false;
            this.ucSearchLookupEditor_NhanVien1.ControlBack = null;
            this.ucSearchLookupEditor_NhanVien1.ControlNext = null;
            this.ucSearchLookupEditor_NhanVien1.DisplayMember = "";
            this.ucSearchLookupEditor_NhanVien1.Location = new System.Drawing.Point(111, 30);
            this.ucSearchLookupEditor_NhanVien1.Name = "ucSearchLookupEditor_NhanVien1";
            this.ucSearchLookupEditor_NhanVien1.SelectedValue = null;
            this.ucSearchLookupEditor_NhanVien1.Size = new System.Drawing.Size(127, 23);
            this.ucSearchLookupEditor_NhanVien1.TabIndex = 122;
            this.ucSearchLookupEditor_NhanVien1.ValueMember = "";
            // 
            // ucSearchLookupEditor_BoPhan1
            // 
            this.ucSearchLookupEditor_BoPhan1.CatchEnterKey = false;
            this.ucSearchLookupEditor_BoPhan1.CatchTabKey = false;
            this.ucSearchLookupEditor_BoPhan1.ControlBack = null;
            this.ucSearchLookupEditor_BoPhan1.ControlNext = null;
            this.ucSearchLookupEditor_BoPhan1.DisplayMember = "";
            this.ucSearchLookupEditor_BoPhan1.Location = new System.Drawing.Point(111, 60);
            this.ucSearchLookupEditor_BoPhan1.Name = "ucSearchLookupEditor_BoPhan1";
            this.ucSearchLookupEditor_BoPhan1.SelectedValue = null;
            this.ucSearchLookupEditor_BoPhan1.Size = new System.Drawing.Size(127, 23);
            this.ucSearchLookupEditor_BoPhan1.TabIndex = 121;
            this.ucSearchLookupEditor_BoPhan1.ValueMember = "";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(21, 68);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 15);
            this.labelControl3.TabIndex = 119;
            this.labelControl3.Text = "Bộ phận";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(21, 97);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 15);
            this.labelControl4.TabIndex = 120;
            this.labelControl4.Text = "Chức vụ";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Arial", 8.75F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(21, 38);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(72, 15);
            this.labelControl5.TabIndex = 118;
            this.labelControl5.Text = "Mã nhân viên";
            // 
            // ucGroupHeader3
            // 
            this.ucGroupHeader3.BackColor = System.Drawing.Color.Transparent;
            this.ucGroupHeader3.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(218)))), ((int)(((byte)(89)))));
            this.ucGroupHeader3.GroupCaption = "ĐIỀU KIỆN";
            this.ucGroupHeader3.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader3.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeader3.Margin = new System.Windows.Forms.Padding(0);
            this.ucGroupHeader3.MaximumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader3.MinimumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader3.Name = "ucGroupHeader3";
            this.ucGroupHeader3.Size = new System.Drawing.Size(907, 23);
            this.ucGroupHeader3.TabIndex = 102;
            // 
            // ucGroupHeader1
            // 
            this.ucGroupHeader1.BackColor = System.Drawing.Color.Transparent;
            this.ucGroupHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(218)))), ((int)(((byte)(89)))));
            this.ucGroupHeader1.GroupCaption = "DỮ LIỆU LƯƠNG";
            this.ucGroupHeader1.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader1.Location = new System.Drawing.Point(0, 214);
            this.ucGroupHeader1.Margin = new System.Windows.Forms.Padding(0);
            this.ucGroupHeader1.MaximumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader1.MinimumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader1.Name = "ucGroupHeader1";
            this.ucGroupHeader1.Size = new System.Drawing.Size(907, 23);
            this.ucGroupHeader1.TabIndex = 103;
            // 
            // gcDuLieuCC
            // 
            this.gcDuLieuCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDuLieuCC.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Arial", 8F);
            this.gcDuLieuCC.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gcDuLieuCC.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcDuLieuCC.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcDuLieuCC.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcDuLieuCC.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcDuLieuCC.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcDuLieuCC.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0);
            this.gcDuLieuCC.EmbeddedNavigator.TextStringFormat = "Dòng {0}/{1}";
            this.gcDuLieuCC.Location = new System.Drawing.Point(0, 237);
            this.gcDuLieuCC.MainView = this.gvDuLieuCC;
            this.gcDuLieuCC.Margin = new System.Windows.Forms.Padding(0);
            this.gcDuLieuCC.Name = "gcDuLieuCC";
            this.gcDuLieuCC.Size = new System.Drawing.Size(907, 291);
            this.gcDuLieuCC.TabIndex = 104;
            this.gcDuLieuCC.UseEmbeddedNavigator = true;
            this.gcDuLieuCC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDuLieuCC});
            // 
            // gvDuLieuCC
            // 
            this.gvDuLieuCC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.gvDuLieuCC.DetailHeight = 284;
            this.gvDuLieuCC.GridControl = this.gcDuLieuCC;
            this.gvDuLieuCC.GroupFormat = "{0}: [#image]{1}  -  {2}";
            this.gvDuLieuCC.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GiaRieng", null, "{0:N0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TienCong", null, "{0:N0}")});
            this.gvDuLieuCC.Name = "gvDuLieuCC";
            this.gvDuLieuCC.OptionsSelection.CheckBoxSelectorColumnWidth = 26;
            this.gvDuLieuCC.OptionsSelection.MultiSelect = true;
            this.gvDuLieuCC.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvDuLieuCC.OptionsView.ColumnAutoWidth = false;
            this.gvDuLieuCC.OptionsView.ShowFooter = true;
            this.gvDuLieuCC.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã nhân viên";
            this.gridColumn1.FieldName = "manhanvien";
            this.gridColumn1.MinWidth = 17;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 90;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Họ tên";
            this.gridColumn2.FieldName = "tennhanvien";
            this.gridColumn2.MinWidth = 17;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 270;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Chức vụ";
            this.gridColumn3.FieldName = "tennhomnhanvien";
            this.gridColumn3.MinWidth = 17;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 115;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Bộ phận";
            this.gridColumn4.FieldName = "tenbophan";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tổng số ngày đi làm";
            this.gridColumn5.FieldName = "songaydilam";
            this.gridColumn5.MinWidth = 17;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 142;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Tổng số ngày đến muộn";
            this.gridColumn6.FieldName = "songaydenmuon";
            this.gridColumn6.MinWidth = 17;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 148;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Tổng số ngày nghỉ";
            this.gridColumn7.FieldName = "songaynghi";
            this.gridColumn7.MinWidth = 17;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 134;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Ngày tăng ca";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "ngaytangca";
            this.gridColumn8.MinWidth = 17;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            this.gridColumn8.Width = 84;
            // 
            // FrmLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 586);
            this.Name = "FrmLuong";
            this.Text = "Lương";
            this.pnContaint.ResumeLayout(false);
            this.pnLabel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDuLieuCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDuLieuCC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        public DevExpress.XtraGrid.GridControl gcDuLieuCC;
        public DevExpress.XtraGrid.Views.Grid.GridView gvDuLieuCC;
        public DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        public DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        public DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private Common.Controls.ucGroupHeader ucGroupHeader1;
        private System.Windows.Forms.Panel panel1;
        private Controls.TPHNormalButton btnExcel;
        private Controls.TPHNormalButton btnTimKiem;
        private AppCode.ucSearchLookupEditor_ChucVu ucSearchLookupEditor_ChucVu1;
        private AppCode.ucSearchLookupEditor_NhanVien ucSearchLookupEditor_NhanVien1;
        private AppCode.ucSearchLookupEditor_BoPhan ucSearchLookupEditor_BoPhan1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private Common.Controls.ucGroupHeader ucGroupHeader3;
    }
}