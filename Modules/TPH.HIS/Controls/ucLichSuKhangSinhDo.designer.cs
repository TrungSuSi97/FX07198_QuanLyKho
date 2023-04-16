namespace TPH.HIS.Controls
{
    partial class ucLichSuKhangSinhDo
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
            this.gcKhangDinhDo = new DevExpress.XtraGrid.GridControl();
            this.bgvKSD = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gbStandard = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colKSD_MaKhangSinh = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colKSD_TenKhangSinh = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colKSD_MaYeuCau = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colKSD_TenYeuCau = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colKSD_KyThuat = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkGhepDuongKinh = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gcKhangDinhDo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgvKSD)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcKhangDinhDo
            // 
            this.gcKhangDinhDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcKhangDinhDo.Location = new System.Drawing.Point(0, 23);
            this.gcKhangDinhDo.MainView = this.bgvKSD;
            this.gcKhangDinhDo.Name = "gcKhangDinhDo";
            this.gcKhangDinhDo.Size = new System.Drawing.Size(873, 554);
            this.gcKhangDinhDo.TabIndex = 16;
            this.gcKhangDinhDo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bgvKSD});
            // 
            // bgvKSD
            // 
            this.bgvKSD.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 10F);
            this.bgvKSD.Appearance.FocusedRow.Options.UseFont = true;
            this.bgvKSD.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.bgvKSD.Appearance.GroupRow.Options.UseFont = true;
            this.bgvKSD.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.bgvKSD.Appearance.HeaderPanel.Options.UseFont = true;
            this.bgvKSD.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.bgvKSD.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bgvKSD.Appearance.Row.Font = new System.Drawing.Font("Arial", 10F);
            this.bgvKSD.Appearance.Row.Options.UseFont = true;
            this.bgvKSD.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 10F);
            this.bgvKSD.Appearance.SelectedRow.Options.UseFont = true;
            this.bgvKSD.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gbStandard});
            this.bgvKSD.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colKSD_MaKhangSinh,
            this.colKSD_TenKhangSinh,
            this.colKSD_MaYeuCau,
            this.colKSD_TenYeuCau,
            this.colKSD_KyThuat});
            this.bgvKSD.GridControl = this.gcKhangDinhDo;
            this.bgvKSD.GroupCount = 2;
            this.bgvKSD.Name = "bgvKSD";
            this.bgvKSD.OptionsView.AllowCellMerge = true;
            this.bgvKSD.OptionsView.ColumnAutoWidth = false;
            this.bgvKSD.OptionsView.ShowAutoFilterRow = true;
            this.bgvKSD.OptionsView.ShowGroupPanel = false;
            this.bgvKSD.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colKSD_TenYeuCau, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colKSD_KyThuat, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.bgvKSD.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.bgvKSD_CellMerge);
            this.bgvKSD.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.bgvKSD_RowCellStyle);
            // 
            // gbStandard
            // 
            this.gbStandard.Columns.Add(this.colKSD_MaKhangSinh);
            this.gbStandard.Columns.Add(this.colKSD_TenKhangSinh);
            this.gbStandard.Columns.Add(this.colKSD_MaYeuCau);
            this.gbStandard.Columns.Add(this.colKSD_TenYeuCau);
            this.gbStandard.Columns.Add(this.colKSD_KyThuat);
            this.gbStandard.Name = "gbStandard";
            this.gbStandard.VisibleIndex = 0;
            this.gbStandard.Width = 296;
            // 
            // colKSD_MaKhangSinh
            // 
            this.colKSD_MaKhangSinh.Caption = "Mã kháng sinh";
            this.colKSD_MaKhangSinh.FieldName = "MaKhangSinh";
            this.colKSD_MaKhangSinh.Name = "colKSD_MaKhangSinh";
            this.colKSD_MaKhangSinh.OptionsColumn.AllowEdit = false;
            this.colKSD_MaKhangSinh.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colKSD_MaKhangSinh.OptionsColumn.ReadOnly = true;
            this.colKSD_MaKhangSinh.Visible = true;
            this.colKSD_MaKhangSinh.Width = 111;
            // 
            // colKSD_TenKhangSinh
            // 
            this.colKSD_TenKhangSinh.Caption = "Tên kháng sinh";
            this.colKSD_TenKhangSinh.FieldName = "TenKhangSinh";
            this.colKSD_TenKhangSinh.Name = "colKSD_TenKhangSinh";
            this.colKSD_TenKhangSinh.OptionsColumn.AllowEdit = false;
            this.colKSD_TenKhangSinh.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colKSD_TenKhangSinh.Visible = true;
            this.colKSD_TenKhangSinh.Width = 185;
            // 
            // colKSD_MaYeuCau
            // 
            this.colKSD_MaYeuCau.Caption = "Mã yêu cầu";
            this.colKSD_MaYeuCau.FieldName = "MaYeuCau";
            this.colKSD_MaYeuCau.Name = "colKSD_MaYeuCau";
            this.colKSD_MaYeuCau.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colKSD_MaYeuCau.Width = 109;
            // 
            // colKSD_TenYeuCau
            // 
            this.colKSD_TenYeuCau.Caption = "Chỉ định";
            this.colKSD_TenYeuCau.FieldName = "TenYeuCau";
            this.colKSD_TenYeuCau.Name = "colKSD_TenYeuCau";
            this.colKSD_TenYeuCau.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colKSD_TenYeuCau.Width = 112;
            // 
            // colKSD_KyThuat
            // 
            this.colKSD_KyThuat.Caption = "Kỹ thuật";
            this.colKSD_KyThuat.FieldName = "KyThuat";
            this.colKSD_KyThuat.Name = "colKSD_KyThuat";
            this.colKSD_KyThuat.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colKSD_KyThuat.Width = 81;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkGhepDuongKinh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(873, 23);
            this.panel1.TabIndex = 17;
            // 
            // chkGhepDuongKinh
            // 
            this.chkGhepDuongKinh.AutoSize = true;
            this.chkGhepDuongKinh.Location = new System.Drawing.Point(52, 1);
            this.chkGhepDuongKinh.Name = "chkGhepDuongKinh";
            this.chkGhepDuongKinh.Size = new System.Drawing.Size(190, 20);
            this.chkGhepDuongKinh.TabIndex = 0;
            this.chkGhepDuongKinh.Text = "Ghép kết quả đường kính";
            this.chkGhepDuongKinh.UseVisualStyleBackColor = true;
            // 
            // ucLichSuKhangSinhDo
            // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gcKhangDinhDo);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucLichSuKhangSinhDo";
            this.Size = new System.Drawing.Size(873, 577);
            ((System.ComponentModel.ISupportInitialize)(this.gcKhangDinhDo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgvKSD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcKhangDinhDo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bgvKSD;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbStandard;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKSD_MaKhangSinh;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKSD_TenKhangSinh;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKSD_MaYeuCau;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKSD_TenYeuCau;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKSD_KyThuat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkGhepDuongKinh;
    }
}
