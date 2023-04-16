namespace TPH.LIS.Statistic.Controls
{
    partial class ucTongHopBenhNhan_DoiTuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTongHopBenhNhan_DoiTuong));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInBaoCao = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.gcXnDoiTuong = new DevExpress.XtraGrid.GridControl();
            this.gvXnDoiTuong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colXnDoituong_MaXN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colXnDoiTuong_PhanLoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colXnDoituong_NVNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcXnDoiTuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvXnDoiTuong)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnInBaoCao);
            this.panel1.Controls.Add(this.btnXuatExcel);
            this.panel1.Controls.Add(this.btnThongKe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 284);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 41);
            this.panel1.TabIndex = 37;
            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnInBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInBaoCao.Image = ((System.Drawing.Image)(resources.GetObject("btnInBaoCao.Image")));
            this.btnInBaoCao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInBaoCao.Location = new System.Drawing.Point(360, 3);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.Size = new System.Drawing.Size(105, 34);
            this.btnInBaoCao.TabIndex = 39;
            this.btnInBaoCao.Text = "In báo cáo";
            this.btnInBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInBaoCao.UseVisualStyleBackColor = true;
            this.btnInBaoCao.Click += new System.EventHandler(this.btnInBaoCao_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXuatExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatExcel.Image")));
            this.btnXuatExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXuatExcel.Location = new System.Drawing.Point(217, 3);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(127, 34);
            this.btnXuatExcel.TabIndex = 38;
            this.btnXuatExcel.Text = "Xuất ra excel ";
            this.btnXuatExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btnThongKe.Image")));
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.Location = new System.Drawing.Point(96, 3);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(105, 34);
            this.btnThongKe.TabIndex = 37;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // gcXnDoiTuong
            // 
            this.gcXnDoiTuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcXnDoiTuong.Location = new System.Drawing.Point(0, 0);
            this.gcXnDoiTuong.MainView = this.gvXnDoiTuong;
            this.gcXnDoiTuong.Name = "gcXnDoiTuong";
            this.gcXnDoiTuong.Size = new System.Drawing.Size(564, 284);
            this.gcXnDoiTuong.TabIndex = 38;
            this.gcXnDoiTuong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvXnDoiTuong});
            // 
            // gvXnDoiTuong
            // 
            this.gvXnDoiTuong.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXnDoiTuong.Appearance.EvenRow.Options.UseFont = true;
            this.gvXnDoiTuong.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXnDoiTuong.Appearance.FilterPanel.Options.UseFont = true;
            this.gvXnDoiTuong.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvXnDoiTuong.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXnDoiTuong.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Red;
            this.gvXnDoiTuong.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvXnDoiTuong.Appearance.FocusedCell.Options.UseFont = true;
            this.gvXnDoiTuong.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvXnDoiTuong.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXnDoiTuong.Appearance.FocusedRow.Options.UseFont = true;
            this.gvXnDoiTuong.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvXnDoiTuong.Appearance.FooterPanel.Options.UseFont = true;
            this.gvXnDoiTuong.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXnDoiTuong.Appearance.GroupButton.Options.UseFont = true;
            this.gvXnDoiTuong.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvXnDoiTuong.Appearance.GroupFooter.Options.UseFont = true;
            this.gvXnDoiTuong.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvXnDoiTuong.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvXnDoiTuong.Appearance.GroupRow.Options.UseFont = true;
            this.gvXnDoiTuong.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvXnDoiTuong.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvXnDoiTuong.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvXnDoiTuong.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXnDoiTuong.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvXnDoiTuong.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXnDoiTuong.Appearance.HorzLine.Options.UseFont = true;
            this.gvXnDoiTuong.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXnDoiTuong.Appearance.OddRow.Options.UseFont = true;
            this.gvXnDoiTuong.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXnDoiTuong.Appearance.Row.Options.UseFont = true;
            this.gvXnDoiTuong.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXnDoiTuong.Appearance.RowSeparator.Options.UseFont = true;
            this.gvXnDoiTuong.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvXnDoiTuong.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvXnDoiTuong.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvXnDoiTuong.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvXnDoiTuong.Appearance.SelectedRow.Options.UseFont = true;
            this.gvXnDoiTuong.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvXnDoiTuong.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXnDoiTuong.Appearance.TopNewRow.Options.UseFont = true;
            this.gvXnDoiTuong.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXnDoiTuong.Appearance.VertLine.Options.UseFont = true;
            this.gvXnDoiTuong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colXnDoituong_MaXN,
            this.gridColumn28,
            this.colXnDoiTuong_PhanLoai,
            this.gridColumn33,
            this.colXnDoituong_NVNhap});
            this.gvXnDoiTuong.GridControl = this.gcXnDoiTuong;
            this.gvXnDoiTuong.GroupCount = 1;
            this.gvXnDoiTuong.Name = "gvXnDoiTuong";
            this.gvXnDoiTuong.OptionsSelection.MultiSelect = true;
            this.gvXnDoiTuong.OptionsView.ShowFooter = true;
            this.gvXnDoiTuong.OptionsView.ShowGroupPanel = false;
            this.gvXnDoiTuong.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colXnDoituong_NVNhap, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colXnDoituong_MaXN
            // 
            this.colXnDoituong_MaXN.Caption = "Mã số";
            this.colXnDoituong_MaXN.FieldName = "MaXN";
            this.colXnDoituong_MaXN.Name = "colXnDoituong_MaXN";
            this.colXnDoituong_MaXN.Visible = true;
            this.colXnDoituong_MaXN.VisibleIndex = 0;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "Xét nghiệm";
            this.gridColumn28.FieldName = "TenXN";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsColumn.AllowEdit = false;
            this.gridColumn28.OptionsColumn.ReadOnly = true;
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 1;
            this.gridColumn28.Width = 192;
            // 
            // colXnDoiTuong_PhanLoai
            // 
            this.colXnDoiTuong_PhanLoai.Caption = "Phân loại";
            this.colXnDoiTuong_PhanLoai.FieldName = "MaBoPhan";
            this.colXnDoiTuong_PhanLoai.Name = "colXnDoiTuong_PhanLoai";
            this.colXnDoiTuong_PhanLoai.Visible = true;
            this.colXnDoiTuong_PhanLoai.VisibleIndex = 2;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "Tổng số";
            this.gridColumn33.DisplayFormat.FormatString = "{0:N0}";
            this.gridColumn33.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn33.FieldName = "SoLuong";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.OptionsColumn.AllowEdit = false;
            this.gridColumn33.OptionsColumn.ReadOnly = true;
            this.gridColumn33.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoLuong", "{0:N0}")});
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 3;
            this.gridColumn33.Width = 97;
            // 
            // colXnDoituong_NVNhap
            // 
            this.colXnDoituong_NVNhap.Caption = "NV Thực hiện";
            this.colXnDoituong_NVNhap.FieldName = "NVThucHien";
            this.colXnDoituong_NVNhap.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DisplayText;
            this.colXnDoituong_NVNhap.Name = "colXnDoituong_NVNhap";
            this.colXnDoituong_NVNhap.Visible = true;
            this.colXnDoituong_NVNhap.VisibleIndex = 7;
            // 
            // ucTongHopBenhNhan_DoiTuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcXnDoiTuong);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucTongHopBenhNhan_DoiTuong";
            this.Size = new System.Drawing.Size(564, 325);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcXnDoiTuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvXnDoiTuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnInBaoCao;
        private DevExpress.XtraGrid.GridControl gcXnDoiTuong;
        private DevExpress.XtraGrid.Views.Grid.GridView gvXnDoiTuong;
        private DevExpress.XtraGrid.Columns.GridColumn colXnDoituong_MaXN;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn colXnDoiTuong_PhanLoai;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraGrid.Columns.GridColumn colXnDoituong_NVNhap;
    }
}
