namespace TPH.LIS.Statistic.Controls
{
    partial class ucTongHopBenhNhan_KhoaPhong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTongHopBenhNhan_KhoaPhong));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInBaoCao = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.gcThongKeTheoKhoa = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridColumn42 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn34 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcThongKeTheoKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
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
            this.btnInBaoCao.Location = new System.Drawing.Point(346, 2);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.Size = new System.Drawing.Size(105, 34);
            this.btnInBaoCao.TabIndex = 40;
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
            this.btnXuatExcel.Location = new System.Drawing.Point(200, 2);
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
            this.btnThongKe.Location = new System.Drawing.Point(76, 2);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(105, 34);
            this.btnThongKe.TabIndex = 37;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // gcThongKeTheoKhoa
            // 
            this.gcThongKeTheoKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcThongKeTheoKhoa.Location = new System.Drawing.Point(0, 0);
            this.gcThongKeTheoKhoa.MainView = this.bandedGridView1;
            this.gcThongKeTheoKhoa.Name = "gcThongKeTheoKhoa";
            this.gcThongKeTheoKhoa.Size = new System.Drawing.Size(564, 284);
            this.gcThongKeTheoKhoa.TabIndex = 38;
            this.gcThongKeTheoKhoa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F);
            this.bandedGridView1.Appearance.EvenRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.bandedGridView1.Appearance.FilterPanel.Options.UseFont = true;
            this.bandedGridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bandedGridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.bandedGridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Red;
            this.bandedGridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.bandedGridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.bandedGridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.bandedGridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bandedGridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.bandedGridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9F);
            this.bandedGridView1.Appearance.GroupButton.Options.UseFont = true;
            this.bandedGridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bandedGridView1.Appearance.GroupFooter.Options.UseFont = true;
            this.bandedGridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bandedGridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.bandedGridView1.Appearance.GroupRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.bandedGridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.bandedGridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.bandedGridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.bandedGridView1.Appearance.HorzLine.Options.UseFont = true;
            this.bandedGridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.bandedGridView1.Appearance.OddRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.bandedGridView1.Appearance.Row.Options.UseFont = true;
            this.bandedGridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.bandedGridView1.Appearance.RowSeparator.Options.UseFont = true;
            this.bandedGridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.bandedGridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bandedGridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.bandedGridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.bandedGridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.bandedGridView1.Appearance.TopNewRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.bandedGridView1.Appearance.VertLine.Options.UseFont = true;
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridColumn42,
            this.gridColumn32,
            this.gridColumn34,
            this.gridColumn35});
            this.bandedGridView1.GridControl = this.gcThongKeTheoKhoa;
            this.bandedGridView1.GroupCount = 1;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsSelection.MultiSelect = true;
            this.bandedGridView1.OptionsView.ShowFooter = true;
            this.bandedGridView1.OptionsView.ShowGroupPanel = false;
            this.bandedGridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn35, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn42
            // 
            this.gridColumn42.Caption = "Mã khoa";
            this.gridColumn42.FieldName = "MaKhoaPhong";
            this.gridColumn42.Name = "gridColumn42";
            this.gridColumn42.Visible = true;
            this.gridColumn42.Width = 82;
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "Số TT";
            this.gridColumn32.FieldName = "STT";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.Visible = true;
            this.gridColumn32.Width = 52;
            // 
            // gridColumn34
            // 
            this.gridColumn34.Caption = "Tên khoa";
            this.gridColumn34.FieldName = "TenKhoaPhong";
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.OptionsColumn.AllowEdit = false;
            this.gridColumn34.OptionsColumn.ReadOnly = true;
            this.gridColumn34.Visible = true;
            this.gridColumn34.Width = 258;
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "Khu";
            this.gridColumn35.FieldName = "TenBoPhan";
            this.gridColumn35.Name = "gridColumn35";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Thông tin khoa";
            this.gridBand1.Columns.Add(this.gridColumn32);
            this.gridBand1.Columns.Add(this.gridColumn42);
            this.gridBand1.Columns.Add(this.gridColumn34);
            this.gridBand1.Columns.Add(this.gridColumn35);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 415;
            // 
            // ucTongHopBenhNhan_KhoaPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcThongKeTheoKhoa);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucTongHopBenhNhan_KhoaPhong";
            this.Size = new System.Drawing.Size(564, 325);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcThongKeTheoKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnInBaoCao;
        private DevExpress.XtraGrid.GridControl gcThongKeTheoKhoa;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn42;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn32;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn34;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn35;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
    }
}
