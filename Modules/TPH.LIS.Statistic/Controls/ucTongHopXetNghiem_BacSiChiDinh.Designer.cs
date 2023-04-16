namespace TPH.LIS.Statistic.Controls
{
    partial class ucTongHopXetNghiem_BacSiChiDinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTongHopXetNghiem_BacSiChiDinh));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnXuatExcel = new TPH.Controls.TPHNormalButton();
            this.btnThongKe = new TPH.Controls.TPHNormalButton();
            this.gcChiDinh = new DevExpress.XtraGrid.GridControl();
            this.gvChiDinh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TenBN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenChiDinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BacSiCD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTongTienCTBS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TienCong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ngaytiepnhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcChiDinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChiDinh)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnXuatExcel);
            this.panel1.Controls.Add(this.btnThongKe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 279);
            this.panel1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 46);
            this.panel1.TabIndex = 37;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXuatExcel.BackColorHover = System.Drawing.Color.Empty;
            this.btnXuatExcel.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXuatExcel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXuatExcel.BorderRadius = 5;
            this.btnXuatExcel.BorderSize = 1;
            this.btnXuatExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Arial", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXuatExcel.ForeColor = System.Drawing.Color.Black;
            this.btnXuatExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatExcel.Image")));
            this.btnXuatExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXuatExcel.Location = new System.Drawing.Point(286, 4);
            this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(110, 39);
            this.btnXuatExcel.TabIndex = 38;
            this.btnXuatExcel.Text = "Xuất excel ";
            this.btnXuatExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXuatExcel.TextColor = System.Drawing.Color.Black;
            this.btnXuatExcel.UseHightLight = true;
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThongKe.BackColorHover = System.Drawing.Color.Empty;
            this.btnThongKe.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThongKe.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThongKe.BorderRadius = 5;
            this.btnThongKe.BorderSize = 1;
            this.btnThongKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Arial", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThongKe.ForeColor = System.Drawing.Color.Black;
            this.btnThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btnThongKe.Image")));
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.Location = new System.Drawing.Point(168, 4);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(110, 39);
            this.btnThongKe.TabIndex = 37;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThongKe.TextColor = System.Drawing.Color.Black;
            this.btnThongKe.UseHightLight = true;
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // gcChiDinh
            // 
            this.gcChiDinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcChiDinh.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.gcChiDinh.Location = new System.Drawing.Point(0, 0);
            this.gcChiDinh.MainView = this.gvChiDinh;
            this.gcChiDinh.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.gcChiDinh.Name = "gcChiDinh";
            this.gcChiDinh.Size = new System.Drawing.Size(564, 279);
            this.gcChiDinh.TabIndex = 38;
            this.gcChiDinh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvChiDinh});
            // 
            // gvChiDinh
            // 
            this.gvChiDinh.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvChiDinh.Appearance.EvenRow.Options.UseFont = true;
            this.gvChiDinh.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.gvChiDinh.Appearance.FilterPanel.Options.UseFont = true;
            this.gvChiDinh.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvChiDinh.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.gvChiDinh.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Red;
            this.gvChiDinh.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvChiDinh.Appearance.FocusedCell.Options.UseFont = true;
            this.gvChiDinh.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvChiDinh.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvChiDinh.Appearance.FocusedRow.Options.UseFont = true;
            this.gvChiDinh.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvChiDinh.Appearance.FooterPanel.Options.UseFont = true;
            this.gvChiDinh.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9F);
            this.gvChiDinh.Appearance.GroupButton.Options.UseFont = true;
            this.gvChiDinh.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvChiDinh.Appearance.GroupFooter.Options.UseFont = true;
            this.gvChiDinh.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvChiDinh.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvChiDinh.Appearance.GroupRow.Options.UseFont = true;
            this.gvChiDinh.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvChiDinh.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvChiDinh.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvChiDinh.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvChiDinh.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvChiDinh.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvChiDinh.Appearance.HorzLine.Options.UseFont = true;
            this.gvChiDinh.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvChiDinh.Appearance.OddRow.Options.UseFont = true;
            this.gvChiDinh.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.gvChiDinh.Appearance.Row.Options.UseFont = true;
            this.gvChiDinh.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.gvChiDinh.Appearance.RowSeparator.Options.UseFont = true;
            this.gvChiDinh.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvChiDinh.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvChiDinh.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvChiDinh.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvChiDinh.Appearance.SelectedRow.Options.UseFont = true;
            this.gvChiDinh.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvChiDinh.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvChiDinh.Appearance.TopNewRow.Options.UseFont = true;
            this.gvChiDinh.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvChiDinh.Appearance.VertLine.Options.UseFont = true;
            this.gvChiDinh.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TenBN,
            this.TenChiDinh,
            this.BacSiCD,
            this.colTongTienCTBS,
            this.TienCong,
            this.ngaytiepnhan});
            this.gvChiDinh.DetailHeight = 284;
            this.gvChiDinh.GridControl = this.gcChiDinh;
            this.gvChiDinh.GroupCount = 1;
            this.gvChiDinh.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TongTien", this.colTongTienCTBS, "{0:N0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TienCong", this.TienCong, "{0:N0}")});
            this.gvChiDinh.Name = "gvChiDinh";
            this.gvChiDinh.OptionsSelection.MultiSelect = true;
            this.gvChiDinh.OptionsView.ShowFooter = true;
            this.gvChiDinh.OptionsView.ShowGroupPanel = false;
            this.gvChiDinh.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.BacSiCD, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // TenBN
            // 
            this.TenBN.Caption = "Tên bệnh nhân";
            this.TenBN.FieldName = "TenBN";
            this.TenBN.MinWidth = 17;
            this.TenBN.Name = "TenBN";
            this.TenBN.OptionsColumn.AllowEdit = false;
            this.TenBN.OptionsColumn.ReadOnly = true;
            this.TenBN.Visible = true;
            this.TenBN.VisibleIndex = 1;
            this.TenBN.Width = 141;
            // 
            // TenChiDinh
            // 
            this.TenChiDinh.Caption = "Xét nghiệm";
            this.TenChiDinh.FieldName = "TenXN";
            this.TenChiDinh.MinWidth = 17;
            this.TenChiDinh.Name = "TenChiDinh";
            this.TenChiDinh.OptionsColumn.AllowEdit = false;
            this.TenChiDinh.OptionsColumn.ReadOnly = true;
            this.TenChiDinh.Visible = true;
            this.TenChiDinh.VisibleIndex = 2;
            this.TenChiDinh.Width = 434;
            // 
            // BacSiCD
            // 
            this.BacSiCD.Caption = "Bác sĩ chỉ định";
            this.BacSiCD.FieldName = "TenNhanVien";
            this.BacSiCD.MinWidth = 17;
            this.BacSiCD.Name = "BacSiCD";
            this.BacSiCD.OptionsColumn.AllowEdit = false;
            this.BacSiCD.OptionsColumn.ReadOnly = true;
            this.BacSiCD.Visible = true;
            this.BacSiCD.VisibleIndex = 2;
            this.BacSiCD.Width = 64;
            // 
            // colTongTienCTBS
            // 
            this.colTongTienCTBS.Caption = "Thành tiền";
            this.colTongTienCTBS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTongTienCTBS.FieldName = "TongTien";
            this.colTongTienCTBS.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTongTienCTBS.MinWidth = 17;
            this.colTongTienCTBS.Name = "colTongTienCTBS";
            this.colTongTienCTBS.OptionsColumn.AllowEdit = false;
            this.colTongTienCTBS.OptionsColumn.ReadOnly = true;
            this.colTongTienCTBS.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TongTien", "{0:N0}")});
            this.colTongTienCTBS.Visible = true;
            this.colTongTienCTBS.VisibleIndex = 3;
            this.colTongTienCTBS.Width = 69;
            // 
            // TienCong
            // 
            this.TienCong.Caption = "Chiết khấu";
            this.TienCong.DisplayFormat.FormatString = "{0:N0}";
            this.TienCong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TienCong.FieldName = "TienCong";
            this.TienCong.GroupFormat.FormatString = "{0:N0}";
            this.TienCong.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TienCong.MinWidth = 17;
            this.TienCong.Name = "TienCong";
            this.TienCong.OptionsColumn.AllowEdit = false;
            this.TienCong.OptionsColumn.ReadOnly = true;
            this.TienCong.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TienCong", "{0:N0}")});
            this.TienCong.Width = 68;
            // 
            // ngaytiepnhan
            // 
            this.ngaytiepnhan.Caption = "Ngày chỉ định";
            this.ngaytiepnhan.FieldName = "NgayTiepNhan";
            this.ngaytiepnhan.MinWidth = 17;
            this.ngaytiepnhan.Name = "ngaytiepnhan";
            this.ngaytiepnhan.Visible = true;
            this.ngaytiepnhan.VisibleIndex = 0;
            this.ngaytiepnhan.Width = 77;
            // 
            // ucTongHopXetNghiem_BacSiChiDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gcChiDinh);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.Name = "ucTongHopXetNghiem_BacSiChiDinh";
            this.Size = new System.Drawing.Size(564, 325);
            this.Load += new System.EventHandler(this.ucTongHopXetNghiem_BacSiChiDinh_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcChiDinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChiDinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private TPH.Controls.TPHNormalButton btnXuatExcel;
        private TPH.Controls.TPHNormalButton btnThongKe;
        private DevExpress.XtraGrid.GridControl gcChiDinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gvChiDinh;
        private DevExpress.XtraGrid.Columns.GridColumn TenBN;
        private DevExpress.XtraGrid.Columns.GridColumn TenChiDinh;
        private DevExpress.XtraGrid.Columns.GridColumn BacSiCD;
        private DevExpress.XtraGrid.Columns.GridColumn colTongTienCTBS;
        private DevExpress.XtraGrid.Columns.GridColumn TienCong;
        private DevExpress.XtraGrid.Columns.GridColumn ngaytiepnhan;
    }
}
