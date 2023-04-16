namespace TPH.LIS.Analyzer.Controls
{
    partial class ucLayKetQuaMayTuDong
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblmaTaiKhoan = new System.Windows.Forms.Label();
            this.chkXacNhanKetQuaTuDong = new System.Windows.Forms.CheckBox();
            this.btnThucHien = new System.Windows.Forms.Button();
            this.lblStastus = new System.Windows.Forms.Label();
            this.tmLayKetQuaTuDong = new System.Windows.Forms.Timer();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gcMayXN = new DevExpress.XtraGrid.GridControl();
            this.gvMayXN = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIDMayXn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xolTenMayXN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkChiKetQuaThuong = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpNgayXN = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.gcMayXN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMayXN)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(368, 22);
            this.label3.TabIndex = 364;
            this.label3.Text = "Máy xét nghiệm đã khai báo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 367;
            this.label2.Text = "Tài khoản đăng nhập:";
            // 
            // lblmaTaiKhoan
            // 
            this.lblmaTaiKhoan.AutoSize = true;
            this.lblmaTaiKhoan.Location = new System.Drawing.Point(122, 292);
            this.lblmaTaiKhoan.Name = "lblmaTaiKhoan";
            this.lblmaTaiKhoan.Size = new System.Drawing.Size(55, 13);
            this.lblmaTaiKhoan.TabIndex = 368;
            this.lblmaTaiKhoan.Text = "Tài khoản";
            // 
            // chkXacNhanKetQuaTuDong
            // 
            this.chkXacNhanKetQuaTuDong.AutoSize = true;
            this.chkXacNhanKetQuaTuDong.Checked = true;
            this.chkXacNhanKetQuaTuDong.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXacNhanKetQuaTuDong.Location = new System.Drawing.Point(6, 318);
            this.chkXacNhanKetQuaTuDong.Name = "chkXacNhanKetQuaTuDong";
            this.chkXacNhanKetQuaTuDong.Size = new System.Drawing.Size(151, 17);
            this.chkXacNhanKetQuaTuDong.TabIndex = 369;
            this.chkXacNhanKetQuaTuDong.Text = "Xác nhận kết quả tự động";
            this.chkXacNhanKetQuaTuDong.UseVisualStyleBackColor = true;
            // 
            // btnThucHien
            // 
            this.btnThucHien.Location = new System.Drawing.Point(6, 375);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(160, 45);
            this.btnThucHien.TabIndex = 370;
            this.btnThucHien.Text = "Thực hiện";
            this.btnThucHien.UseVisualStyleBackColor = true;
            this.btnThucHien.Click += new System.EventHandler(this.btnThuHien_Click);
            // 
            // lblStastus
            // 
            this.lblStastus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStastus.ForeColor = System.Drawing.Color.Red;
            this.lblStastus.Location = new System.Drawing.Point(172, 375);
            this.lblStastus.Name = "lblStastus";
            this.lblStastus.Size = new System.Drawing.Size(186, 45);
            this.lblStastus.TabIndex = 371;
            this.lblStastus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmLayKetQuaTuDong
            // 
            this.tmLayKetQuaTuDong.Interval = 7000;
            this.tmLayKetQuaTuDong.Tick += new System.EventHandler(this.timergetResult_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(172, 349);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(186, 23);
            this.progressBar1.TabIndex = 372;
            this.progressBar1.Visible = false;
            // 
            // gcMayXN
            // 
            this.gcMayXN.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcMayXN.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.gcMayXN.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gcMayXN.Location = new System.Drawing.Point(0, 22);
            this.gcMayXN.MainView = this.gvMayXN;
            this.gcMayXN.Name = "gcMayXN";
            this.gcMayXN.Size = new System.Drawing.Size(368, 267);
            this.gcMayXN.TabIndex = 373;
            this.gcMayXN.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMayXN});
            // 
            // gvMayXN
            // 
            this.gvMayXN.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvMayXN.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvMayXN.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvMayXN.Appearance.DetailTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.DetailTip.Options.UseFont = true;
            this.gvMayXN.Appearance.Empty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.Empty.Options.UseFont = true;
            this.gvMayXN.Appearance.EvenRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.EvenRow.Options.UseFont = true;
            this.gvMayXN.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvMayXN.Appearance.FilterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.FilterPanel.Options.UseFont = true;
            this.gvMayXN.Appearance.FixedLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.FixedLine.Options.UseFont = true;
            this.gvMayXN.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvMayXN.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvMayXN.Appearance.FocusedCell.Options.UseFont = true;
            this.gvMayXN.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.FocusedRow.Options.UseFont = true;
            this.gvMayXN.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvMayXN.Appearance.FooterPanel.Options.UseFont = true;
            this.gvMayXN.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvMayXN.Appearance.GroupButton.Options.UseFont = true;
            this.gvMayXN.Appearance.GroupFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvMayXN.Appearance.GroupFooter.Options.UseFont = true;
            this.gvMayXN.Appearance.GroupPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.GroupPanel.Options.UseFont = true;
            this.gvMayXN.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvMayXN.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvMayXN.Appearance.GroupRow.Options.UseFont = true;
            this.gvMayXN.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvMayXN.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvMayXN.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvMayXN.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvMayXN.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.HorzLine.Options.UseFont = true;
            this.gvMayXN.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.OddRow.Options.UseFont = true;
            this.gvMayXN.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.Preview.Options.UseFont = true;
            this.gvMayXN.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.Row.Options.UseFont = true;
            this.gvMayXN.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.RowSeparator.Options.UseFont = true;
            this.gvMayXN.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvMayXN.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvMayXN.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvMayXN.Appearance.SelectedRow.Options.UseFont = true;
            this.gvMayXN.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvMayXN.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.TopNewRow.Options.UseFont = true;
            this.gvMayXN.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.VertLine.Options.UseFont = true;
            this.gvMayXN.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.ViewCaption.Options.UseFont = true;
            this.gvMayXN.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIDMayXn,
            this.xolTenMayXN});
            this.gvMayXN.GridControl = this.gcMayXN;
            this.gvMayXN.Name = "gvMayXN";
            this.gvMayXN.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gvMayXN.OptionsSelection.MultiSelect = true;
            this.gvMayXN.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvMayXN.OptionsSelection.UseIndicatorForSelection = false;
            this.gvMayXN.OptionsView.ColumnAutoWidth = false;
            this.gvMayXN.OptionsView.RowAutoHeight = true;
            this.gvMayXN.OptionsView.ShowAutoFilterRow = true;
            this.gvMayXN.OptionsView.ShowGroupPanel = false;
            this.gvMayXN.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gvMayXN_ShowingEditor);
            // 
            // colIDMayXn
            // 
            this.colIDMayXn.Caption = "ID Máy XN";
            this.colIDMayXn.FieldName = "idmay";
            this.colIDMayXn.Name = "colIDMayXn";
            this.colIDMayXn.OptionsColumn.AllowEdit = false;
            this.colIDMayXn.OptionsColumn.ReadOnly = true;
            this.colIDMayXn.Visible = true;
            this.colIDMayXn.VisibleIndex = 1;
            this.colIDMayXn.Width = 72;
            // 
            // xolTenMayXN
            // 
            this.xolTenMayXN.Caption = "Tên máy xét nghiệm";
            this.xolTenMayXN.FieldName = "tenmay";
            this.xolTenMayXN.Name = "xolTenMayXN";
            this.xolTenMayXN.OptionsColumn.AllowEdit = false;
            this.xolTenMayXN.OptionsColumn.ReadOnly = true;
            this.xolTenMayXN.Visible = true;
            this.xolTenMayXN.VisibleIndex = 2;
            this.xolTenMayXN.Width = 190;
            // 
            // chkChiKetQuaThuong
            // 
            this.chkChiKetQuaThuong.AutoSize = true;
            this.chkChiKetQuaThuong.Checked = true;
            this.chkChiKetQuaThuong.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChiKetQuaThuong.Location = new System.Drawing.Point(172, 318);
            this.chkChiKetQuaThuong.Name = "chkChiKetQuaThuong";
            this.chkChiKetQuaThuong.Size = new System.Drawing.Size(186, 17);
            this.chkChiKetQuaThuong.TabIndex = 374;
            this.chkChiKetQuaThuong.Text = "Chỉ xác nhận kết quả bình thường";
            this.chkChiKetQuaThuong.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 375;
            this.label1.Text = "Ngày";
            // 
            // dtpNgayXN
            // 
            this.dtpNgayXN.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayXN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayXN.Location = new System.Drawing.Point(41, 349);
            this.dtpNgayXN.Name = "dtpNgayXN";
            this.dtpNgayXN.Size = new System.Drawing.Size(125, 20);
            this.dtpNgayXN.TabIndex = 376;
            // 
            // ucLayKetQuaMayTuDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpNgayXN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkChiKetQuaThuong);
            this.Controls.Add(this.gcMayXN);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblStastus);
            this.Controls.Add(this.btnThucHien);
            this.Controls.Add(this.chkXacNhanKetQuaTuDong);
            this.Controls.Add(this.lblmaTaiKhoan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Name = "ucLayKetQuaMayTuDong";
            this.Size = new System.Drawing.Size(368, 428);
            ((System.ComponentModel.ISupportInitialize)(this.gcMayXN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMayXN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblmaTaiKhoan;
        private System.Windows.Forms.CheckBox chkXacNhanKetQuaTuDong;
        private System.Windows.Forms.Button btnThucHien;
        private System.Windows.Forms.Label lblStastus;
        private System.Windows.Forms.Timer tmLayKetQuaTuDong;
        private System.Windows.Forms.ProgressBar progressBar1;
        private DevExpress.XtraGrid.GridControl gcMayXN;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMayXN;
        private DevExpress.XtraGrid.Columns.GridColumn colIDMayXn;
        private DevExpress.XtraGrid.Columns.GridColumn xolTenMayXN;
        private System.Windows.Forms.CheckBox chkChiKetQuaThuong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNgayXN;
    }
}
