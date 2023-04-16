namespace TPH.LIS.Statistic.Controls
{
    partial class ucXetNghiemChayLai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucXetNghiemChayLai));
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnXuatExcel = new TPH.Controls.TPHNormalButton();
            this.btnThongKe = new TPH.Controls.TPHNormalButton();
            this.gcXetnghiemChayLai = new DevExpress.XtraGrid.GridControl();
            this.gvXetnghiemChayLai = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcXetnghiemChayLai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvXetnghiemChayLai)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.btnXuatExcel);
            this.panel1.Controls.Add(this.btnThongKe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 279);
            this.panel1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 46);
            this.panel1.TabIndex = 37;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 6);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(86, 19);
            this.progressBar1.TabIndex = 39;
            this.progressBar1.Visible = false;
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
            this.btnXuatExcel.Location = new System.Drawing.Point(306, 3);
            this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(108, 38);
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
            this.btnThongKe.Location = new System.Drawing.Point(190, 3);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(108, 38);
            this.btnThongKe.TabIndex = 37;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThongKe.TextColor = System.Drawing.Color.Black;
            this.btnThongKe.UseHightLight = true;
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // gcXetnghiemChayLai
            // 
            this.gcXetnghiemChayLai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcXetnghiemChayLai.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.gcXetnghiemChayLai.Location = new System.Drawing.Point(0, 0);
            this.gcXetnghiemChayLai.MainView = this.gvXetnghiemChayLai;
            this.gcXetnghiemChayLai.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.gcXetnghiemChayLai.Name = "gcXetnghiemChayLai";
            this.gcXetnghiemChayLai.Size = new System.Drawing.Size(564, 279);
            this.gcXetnghiemChayLai.TabIndex = 38;
            this.gcXetnghiemChayLai.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvXetnghiemChayLai});
            // 
            // gvXetnghiemChayLai
            // 
            this.gvXetnghiemChayLai.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXetnghiemChayLai.Appearance.EvenRow.Options.UseFont = true;
            this.gvXetnghiemChayLai.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXetnghiemChayLai.Appearance.FilterPanel.Options.UseFont = true;
            this.gvXetnghiemChayLai.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvXetnghiemChayLai.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXetnghiemChayLai.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Red;
            this.gvXetnghiemChayLai.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvXetnghiemChayLai.Appearance.FocusedCell.Options.UseFont = true;
            this.gvXetnghiemChayLai.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvXetnghiemChayLai.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXetnghiemChayLai.Appearance.FocusedRow.Options.UseFont = true;
            this.gvXetnghiemChayLai.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvXetnghiemChayLai.Appearance.FooterPanel.Options.UseFont = true;
            this.gvXetnghiemChayLai.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXetnghiemChayLai.Appearance.GroupButton.Options.UseFont = true;
            this.gvXetnghiemChayLai.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvXetnghiemChayLai.Appearance.GroupFooter.Options.UseFont = true;
            this.gvXetnghiemChayLai.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvXetnghiemChayLai.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvXetnghiemChayLai.Appearance.GroupRow.Options.UseFont = true;
            this.gvXetnghiemChayLai.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvXetnghiemChayLai.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvXetnghiemChayLai.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvXetnghiemChayLai.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXetnghiemChayLai.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvXetnghiemChayLai.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXetnghiemChayLai.Appearance.HorzLine.Options.UseFont = true;
            this.gvXetnghiemChayLai.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXetnghiemChayLai.Appearance.OddRow.Options.UseFont = true;
            this.gvXetnghiemChayLai.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXetnghiemChayLai.Appearance.Row.Options.UseFont = true;
            this.gvXetnghiemChayLai.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXetnghiemChayLai.Appearance.RowSeparator.Options.UseFont = true;
            this.gvXetnghiemChayLai.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvXetnghiemChayLai.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvXetnghiemChayLai.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvXetnghiemChayLai.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvXetnghiemChayLai.Appearance.SelectedRow.Options.UseFont = true;
            this.gvXetnghiemChayLai.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvXetnghiemChayLai.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXetnghiemChayLai.Appearance.TopNewRow.Options.UseFont = true;
            this.gvXetnghiemChayLai.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvXetnghiemChayLai.Appearance.VertLine.Options.UseFont = true;
            this.gvXetnghiemChayLai.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn16,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25});
            this.gvXetnghiemChayLai.DetailHeight = 284;
            this.gvXetnghiemChayLai.GridControl = this.gcXetnghiemChayLai;
            this.gvXetnghiemChayLai.GroupCount = 1;
            this.gvXetnghiemChayLai.Name = "gvXetnghiemChayLai";
            this.gvXetnghiemChayLai.OptionsSelection.MultiSelect = true;
            this.gvXetnghiemChayLai.OptionsView.ColumnAutoWidth = false;
            this.gvXetnghiemChayLai.OptionsView.ShowGroupPanel = false;
            this.gvXetnghiemChayLai.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn16, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Máy xét nghiệm";
            this.gridColumn16.FieldName = "tenmay";
            this.gridColumn16.MinWidth = 17;
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.ReadOnly = true;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 0;
            this.gridColumn16.Width = 86;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Ngày ra kết quả";
            this.gridColumn19.DisplayFormat.FormatString = "{0:dd/MM/yyyy}";
            this.gridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn19.FieldName = "thoigiantumay";
            this.gridColumn19.GroupFormat.FormatString = "{0:dd/MM/yyyy}";
            this.gridColumn19.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn19.MinWidth = 17;
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.ReadOnly = true;
            this.gridColumn19.Width = 82;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Ngày nhận";
            this.gridColumn20.DisplayFormat.FormatString = "{0:dd/MM/yyyy}";
            this.gridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn20.FieldName = "ngayxn";
            this.gridColumn20.MinWidth = 17;
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.OptionsColumn.ReadOnly = true;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 0;
            this.gridColumn20.Width = 100;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Mã máy";
            this.gridColumn21.FieldName = "mamay";
            this.gridColumn21.MinWidth = 17;
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.OptionsColumn.ReadOnly = true;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 2;
            this.gridColumn21.Width = 58;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Mã XN";
            this.gridColumn22.FieldName = "MaXN";
            this.gridColumn22.MinWidth = 17;
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.OptionsColumn.ReadOnly = true;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 3;
            this.gridColumn22.Width = 56;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Xét nghiệm";
            this.gridColumn23.FieldName = "TenXN";
            this.gridColumn23.MinWidth = 17;
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.ReadOnly = true;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 4;
            this.gridColumn23.Width = 115;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "Nhóm";
            this.gridColumn24.FieldName = "TenNhomCLS";
            this.gridColumn24.FieldNameSortGroup = "ThuTuIn";
            this.gridColumn24.MinWidth = 17;
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.OptionsColumn.ReadOnly = true;
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 1;
            this.gridColumn24.Width = 77;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "Số lượng";
            this.gridColumn25.DisplayFormat.FormatString = "{0:N0}";
            this.gridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn25.FieldName = "ketqua";
            this.gridColumn25.MinWidth = 17;
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.OptionsColumn.ReadOnly = true;
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 5;
            this.gridColumn25.Width = 52;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // ucXetNghiemChayLai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gcXetnghiemChayLai);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.Name = "ucXetNghiemChayLai";
            this.Size = new System.Drawing.Size(564, 325);
            this.Load += new System.EventHandler(this.ucXetNghiemChayLai_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcXetnghiemChayLai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvXetnghiemChayLai)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private TPH.Controls.TPHNormalButton btnXuatExcel;
        private TPH.Controls.TPHNormalButton btnThongKe;
        private DevExpress.XtraGrid.GridControl gcXetnghiemChayLai;
        private DevExpress.XtraGrid.Views.Grid.GridView gvXetnghiemChayLai;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
