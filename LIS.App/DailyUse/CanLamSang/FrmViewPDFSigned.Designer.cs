namespace TPH.LIS.App.DailyUse.CanLamSang
{
    partial class FrmViewPDFSigned
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmViewPDFSigned));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcDanhSach = new DevExpress.XtraGrid.GridControl();
            this.gvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaTiepNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coluseraction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayTaoPhieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLanKQ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDaUpLoad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThoiGianUpload = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayKy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoTa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoaiPhieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new DevExpress.XtraEditors.PanelControl();
            this.btnDownLoadPDF = new TPH.Controls.TPHNormalButton();
            this.btnInFile = new TPH.Controls.TPHNormalButton();
            this.btnUpload = new TPH.Controls.TPHNormalButton();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.dtpNgayIn = new System.Windows.Forms.DateTimePicker();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.txtmaBN = new System.Windows.Forms.TextBox();
            this.btnXemFile = new TPH.Controls.TPHNormalButton();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.pnSignInfo = new DevExpress.XtraEditors.PanelControl();
            this.pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
            ((System.ComponentModel.ISupportInitialize)(this.pnContaint)).BeginInit();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnMenu)).BeginInit();
            this.pnMenu.SuspendLayout();
            this.xtraScrollableControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnFormControl)).BeginInit();
            this.pnFormControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnSignInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblTitle.Appearance.Options.UseBackColor = true;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Size = new System.Drawing.Size(189, 22);
            this.lblTitle.Text = "KẾT QUẢ ĐÃ XUẤT PDF";
            // 
            // pnContaint
            // 
            this.pnContaint.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnContaint.Appearance.Options.UseBackColor = true;
            this.pnContaint.Controls.Add(this.pdfViewer1);
            this.pnContaint.Controls.Add(this.pnSignInfo);
            this.pnContaint.Controls.Add(this.groupControl1);
            this.pnContaint.Location = new System.Drawing.Point(0, 28);
            this.pnContaint.Size = new System.Drawing.Size(800, 422);
            // 
            // pnLabel
            // 
            this.pnLabel.Size = new System.Drawing.Size(800, 1);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(448, 0);
            // 
            // lblMainESC
            // 
            this.lblMainESC.Appearance.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainESC.Appearance.Options.UseFont = true;
            this.lblMainESC.ImageOptions.Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lblMainESC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblMainESC.ImageOptions.Image")));
            this.lblMainESC.Location = new System.Drawing.Point(477, 0);
            // 
            // pnMenu
            // 
            this.pnMenu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnMenu.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnMenu.Appearance.Options.UseBackColor = true;
            this.pnMenu.Location = new System.Drawing.Point(0, 1);
            this.pnMenu.Size = new System.Drawing.Size(800, 27);
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.xtraScrollableControlMain.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(800, 26);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnFormControl.Appearance.Options.UseBackColor = true;
            this.pnFormControl.Location = new System.Drawing.Point(692, 1);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(171)))), ((int)(((byte)(203)))));
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(160)))), ((int)(((byte)(190)))));
            // 
            // btnMaximize
            // 
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(141)))), ((int)(((byte)(233)))));
            this.btnMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(132)))), ((int)(((byte)(218)))));
            // 
            // tphIconButton1
            // 
            this.tphIconButton1.FlatAppearance.BorderSize = 0;
            this.tphIconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(87)))), ((int)(((byte)(125)))));
            this.tphIconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(81)))), ((int)(((byte)(117)))));
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcDanhSach);
            this.groupControl1.Controls.Add(this.panel2);
            this.groupControl1.Controls.Add(this.panel1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(398, 418);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Danh sách lần in kết quả";
            // 
            // gcDanhSach
            // 
            this.gcDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhSach.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.gcDanhSach.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gcDanhSach.Location = new System.Drawing.Point(2, 128);
            this.gcDanhSach.MainView = this.gvDanhSach;
            this.gcDanhSach.Name = "gcDanhSach";
            this.gcDanhSach.Size = new System.Drawing.Size(394, 247);
            this.gcDanhSach.TabIndex = 361;
            this.gcDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhSach});
            // 
            // gvDanhSach
            // 
            this.gvDanhSach.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSach.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvDanhSach.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSach.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvDanhSach.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSach.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvDanhSach.Appearance.DetailTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSach.Appearance.DetailTip.Options.UseFont = true;
            this.gvDanhSach.Appearance.Empty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSach.Appearance.Empty.Options.UseFont = true;
            this.gvDanhSach.Appearance.EvenRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSach.Appearance.EvenRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSach.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvDanhSach.Appearance.FilterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSach.Appearance.FilterPanel.Options.UseFont = true;
            this.gvDanhSach.Appearance.FixedLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSach.Appearance.FixedLine.Options.UseFont = true;
            this.gvDanhSach.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvDanhSach.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvDanhSach.Appearance.FocusedCell.Options.UseFont = true;
            this.gvDanhSach.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.FocusedRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhSach.Appearance.FooterPanel.Options.UseFont = true;
            this.gvDanhSach.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhSach.Appearance.GroupButton.Options.UseFont = true;
            this.gvDanhSach.Appearance.GroupFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhSach.Appearance.GroupFooter.Options.UseFont = true;
            this.gvDanhSach.Appearance.GroupPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSach.Appearance.GroupPanel.Options.UseFont = true;
            this.gvDanhSach.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhSach.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvDanhSach.Appearance.GroupRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvDanhSach.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhSach.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvDanhSach.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.HorzLine.Options.UseFont = true;
            this.gvDanhSach.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.OddRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.Preview.Options.UseFont = true;
            this.gvDanhSach.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.Row.Options.UseFont = true;
            this.gvDanhSach.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.RowSeparator.Options.UseFont = true;
            this.gvDanhSach.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvDanhSach.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvDanhSach.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvDanhSach.Appearance.SelectedRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvDanhSach.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.TopNewRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.VertLine.Options.UseFont = true;
            this.gvDanhSach.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.ViewCaption.Options.UseFont = true;
            this.gvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaTiepNhan,
            this.coluseraction,
            this.colNgayTaoPhieu,
            this.colLanKQ,
            this.colDaUpLoad,
            this.colThoiGianUpload,
            this.colNgayKy,
            this.colID,
            this.colArchive,
            this.colMoTa,
            this.colLoaiPhieu});
            this.gvDanhSach.GridControl = this.gcDanhSach;
            this.gvDanhSach.Name = "gvDanhSach";
            this.gvDanhSach.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gvDanhSach.OptionsSelection.MultiSelect = true;
            this.gvDanhSach.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvDanhSach.OptionsView.ColumnAutoWidth = false;
            this.gvDanhSach.OptionsView.RowAutoHeight = true;
            this.gvDanhSach.OptionsView.ShowAutoFilterRow = true;
            this.gvDanhSach.OptionsView.ShowGroupPanel = false;
            // 
            // colMaTiepNhan
            // 
            this.colMaTiepNhan.Caption = "Mã tiếp nhận";
            this.colMaTiepNhan.FieldName = "MaTiepNhan";
            this.colMaTiepNhan.Name = "colMaTiepNhan";
            this.colMaTiepNhan.OptionsColumn.ReadOnly = true;
            this.colMaTiepNhan.Visible = true;
            this.colMaTiepNhan.VisibleIndex = 1;
            this.colMaTiepNhan.Width = 141;
            // 
            // coluseraction
            // 
            this.coluseraction.Caption = "Người in";
            this.coluseraction.FieldName = "useraction";
            this.coluseraction.Name = "coluseraction";
            this.coluseraction.OptionsColumn.AllowEdit = false;
            this.coluseraction.OptionsColumn.ReadOnly = true;
            this.coluseraction.Visible = true;
            this.coluseraction.VisibleIndex = 2;
            this.coluseraction.Width = 79;
            // 
            // colNgayTaoPhieu
            // 
            this.colNgayTaoPhieu.Caption = "Ngày in";
            this.colNgayTaoPhieu.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.colNgayTaoPhieu.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayTaoPhieu.FieldName = "NgayTaoPhieu";
            this.colNgayTaoPhieu.Name = "colNgayTaoPhieu";
            this.colNgayTaoPhieu.OptionsColumn.AllowEdit = false;
            this.colNgayTaoPhieu.Visible = true;
            this.colNgayTaoPhieu.VisibleIndex = 3;
            this.colNgayTaoPhieu.Width = 137;
            // 
            // colLanKQ
            // 
            this.colLanKQ.Caption = "Lần in";
            this.colLanKQ.FieldName = "LanKQ";
            this.colLanKQ.Name = "colLanKQ";
            this.colLanKQ.OptionsColumn.AllowEdit = false;
            this.colLanKQ.Visible = true;
            this.colLanKQ.VisibleIndex = 4;
            // 
            // colDaUpLoad
            // 
            this.colDaUpLoad.Caption = "Đã upload";
            this.colDaUpLoad.FieldName = "DaUpLoad";
            this.colDaUpLoad.Name = "colDaUpLoad";
            this.colDaUpLoad.OptionsColumn.AllowEdit = false;
            this.colDaUpLoad.Visible = true;
            this.colDaUpLoad.VisibleIndex = 5;
            // 
            // colThoiGianUpload
            // 
            this.colThoiGianUpload.Caption = "Thời gian upload";
            this.colThoiGianUpload.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.colThoiGianUpload.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colThoiGianUpload.FieldName = "ThoiGianUpload";
            this.colThoiGianUpload.Name = "colThoiGianUpload";
            this.colThoiGianUpload.OptionsColumn.AllowEdit = false;
            this.colThoiGianUpload.Visible = true;
            this.colThoiGianUpload.VisibleIndex = 6;
            this.colThoiGianUpload.Width = 132;
            // 
            // colNgayKy
            // 
            this.colNgayKy.Caption = "Ngày ký số";
            this.colNgayKy.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.colNgayKy.FieldName = "NgayKy";
            this.colNgayKy.Name = "colNgayKy";
            this.colNgayKy.OptionsColumn.AllowEdit = false;
            this.colNgayKy.Visible = true;
            this.colNgayKy.VisibleIndex = 7;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ReadOnly = true;
            this.colID.Visible = true;
            this.colID.VisibleIndex = 8;
            // 
            // colArchive
            // 
            this.colArchive.Caption = "Đã chuyển bảng lưu";
            this.colArchive.FieldName = "Archive";
            this.colArchive.Name = "colArchive";
            this.colArchive.OptionsColumn.AllowEdit = false;
            this.colArchive.Visible = true;
            this.colArchive.VisibleIndex = 11;
            this.colArchive.Width = 135;
            // 
            // colMoTa
            // 
            this.colMoTa.Caption = "Mô tả";
            this.colMoTa.FieldName = "MoTa";
            this.colMoTa.Name = "colMoTa";
            this.colMoTa.Visible = true;
            this.colMoTa.VisibleIndex = 9;
            // 
            // colLoaiPhieu
            // 
            this.colLoaiPhieu.Caption = "Loại phiếu";
            this.colLoaiPhieu.FieldName = "LoaiPhieu";
            this.colLoaiPhieu.Name = "colLoaiPhieu";
            this.colLoaiPhieu.Visible = true;
            this.colLoaiPhieu.VisibleIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDownLoadPDF);
            this.panel2.Controls.Add(this.btnInFile);
            this.panel2.Controls.Add(this.btnUpload);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(2, 375);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(394, 41);
            this.panel2.TabIndex = 363;
            // 
            // btnDownLoadPDF
            // 
            this.btnDownLoadPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnDownLoadPDF.BackColorHover = System.Drawing.Color.Empty;
            this.btnDownLoadPDF.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnDownLoadPDF.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnDownLoadPDF.BorderRadius = 5;
            this.btnDownLoadPDF.BorderSize = 1;
            this.btnDownLoadPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDownLoadPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownLoadPDF.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownLoadPDF.ForceColorHover = System.Drawing.Color.Empty;
            this.btnDownLoadPDF.ForeColor = System.Drawing.Color.Black;
            this.btnDownLoadPDF.Image = global::TPH.LIS.App.Properties.Resources.printer_blue_24x24;
            this.btnDownLoadPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownLoadPDF.Location = new System.Drawing.Point(253, 3);
            this.btnDownLoadPDF.Name = "btnDownLoadPDF";
            this.btnDownLoadPDF.Size = new System.Drawing.Size(127, 34);
            this.btnDownLoadPDF.TabIndex = 4;
            this.btnDownLoadPDF.Text = "Download PDF";
            this.btnDownLoadPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDownLoadPDF.TextColor = System.Drawing.Color.Black;
            this.btnDownLoadPDF.UseHightLight = true;
            this.btnDownLoadPDF.UseVisualStyleBackColor = false;
            this.btnDownLoadPDF.Click += new System.EventHandler(this.btnDownLoadPDF_Click);
            // 
            // btnInFile
            // 
            this.btnInFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnInFile.BackColorHover = System.Drawing.Color.Empty;
            this.btnInFile.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnInFile.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnInFile.BorderRadius = 5;
            this.btnInFile.BorderSize = 1;
            this.btnInFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInFile.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInFile.ForceColorHover = System.Drawing.Color.Empty;
            this.btnInFile.ForeColor = System.Drawing.Color.Black;
            this.btnInFile.Image = global::TPH.LIS.App.Properties.Resources.printer_blue_24x24;
            this.btnInFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInFile.Location = new System.Drawing.Point(122, 3);
            this.btnInFile.Name = "btnInFile";
            this.btnInFile.Size = new System.Drawing.Size(127, 34);
            this.btnInFile.TabIndex = 3;
            this.btnInFile.Text = "In file kết quả";
            this.btnInFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInFile.TextColor = System.Drawing.Color.Black;
            this.btnInFile.UseHightLight = true;
            this.btnInFile.UseVisualStyleBackColor = false;
            this.btnInFile.Click += new System.EventHandler(this.btnInFile_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnUpload.BackColorHover = System.Drawing.Color.Empty;
            this.btnUpload.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnUpload.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnUpload.BorderRadius = 5;
            this.btnUpload.BorderSize = 1;
            this.btnUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.ForceColorHover = System.Drawing.Color.Empty;
            this.btnUpload.ForeColor = System.Drawing.Color.Black;
            this.btnUpload.Image = global::TPH.LIS.App.Properties.Resources.document_small_upload1;
            this.btnUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpload.Location = new System.Drawing.Point(12, 3);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(102, 34);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "Upload file";
            this.btnUpload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpload.TextColor = System.Drawing.Color.Black;
            this.btnUpload.UseHightLight = true;
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpNgayIn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtmaBN);
            this.panel1.Controls.Add(this.btnXemFile);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBarcode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 105);
            this.panel1.TabIndex = 362;
            // 
            // dtpNgayIn
            // 
            this.dtpNgayIn.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayIn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.dtpNgayIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayIn.Location = new System.Drawing.Point(114, 69);
            this.dtpNgayIn.Name = "dtpNgayIn";
            this.dtpNgayIn.Size = new System.Drawing.Size(164, 27);
            this.dtpNgayIn.TabIndex = 5;
            this.dtpNgayIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpNgayIn_KeyPress);
            // 
            // label3
            // 
            this.label3.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Appearance.Options.UseFont = true;
            this.label3.Location = new System.Drawing.Point(5, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày in";
            // 
            // label2
            // 
            this.label2.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Appearance.Options.UseFont = true;
            this.label2.Location = new System.Drawing.Point(5, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã BN";
            // 
            // txtmaBN
            // 
            this.txtmaBN.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmaBN.Location = new System.Drawing.Point(114, 37);
            this.txtmaBN.Name = "txtmaBN";
            this.txtmaBN.Size = new System.Drawing.Size(164, 26);
            this.txtmaBN.TabIndex = 3;
            this.txtmaBN.Click += new System.EventHandler(this.txtBarcode_Click);
            this.txtmaBN.Enter += new System.EventHandler(this.txtBarcode_Enter);
            this.txtmaBN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarcode_KeyPress);
            this.txtmaBN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtmaBN_KeyUp);
            // 
            // btnXemFile
            // 
            this.btnXemFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXemFile.BackColorHover = System.Drawing.Color.Empty;
            this.btnXemFile.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXemFile.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXemFile.BorderRadius = 5;
            this.btnXemFile.BorderSize = 1;
            this.btnXemFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemFile.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemFile.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXemFile.ForeColor = System.Drawing.Color.Black;
            this.btnXemFile.Image = ((System.Drawing.Image)(resources.GetObject("btnXemFile.Image")));
            this.btnXemFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemFile.Location = new System.Drawing.Point(284, 42);
            this.btnXemFile.Name = "btnXemFile";
            this.btnXemFile.Size = new System.Drawing.Size(106, 55);
            this.btnXemFile.TabIndex = 1;
            this.btnXemFile.Text = "Xem file";
            this.btnXemFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXemFile.TextColor = System.Drawing.Color.Black;
            this.btnXemFile.UseHightLight = true;
            this.btnXemFile.UseVisualStyleBackColor = false;
            this.btnXemFile.Click += new System.EventHandler(this.btnXemFile_Click);
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "BARCODE";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(114, 5);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(164, 26);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.Click += new System.EventHandler(this.txtBarcode_Click);
            this.txtBarcode.Enter += new System.EventHandler(this.txtBarcode_Enter);
            this.txtBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarcode_KeyPress);
            this.txtBarcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyUp);
            // 
            // pnSignInfo
            // 
            this.pnSignInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnSignInfo.Location = new System.Drawing.Point(400, 369);
            this.pnSignInfo.Name = "pnSignInfo";
            this.pnSignInfo.Size = new System.Drawing.Size(398, 51);
            this.pnSignInfo.TabIndex = 3;
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer1.Location = new System.Drawing.Point(400, 2);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.Size = new System.Drawing.Size(398, 367);
            this.pdfViewer1.TabIndex = 4;
            // 
            // FrmViewPDFSigned
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(129)))), ((int)(((byte)(176)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmViewPDFSigned";
            this.Text = "FrmViewPDFFiles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmViewPDFFiles_FormClosing);
            this.Load += new System.EventHandler(this.FrmViewPDFFiles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnContaint)).EndInit();
            this.pnContaint.ResumeLayout(false);
            this.pnLabel.ResumeLayout(false);
            this.pnLabel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnMenu)).EndInit();
            this.pnMenu.ResumeLayout(false);
            this.xtraScrollableControlMain.ResumeLayout(false);
            this.xtraScrollableControlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnFormControl)).EndInit();
            this.pnFormControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnSignInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSach;
        private DevExpress.XtraGrid.Columns.GridColumn colMaTiepNhan;
        private DevExpress.XtraGrid.Columns.GridColumn coluseraction;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayTaoPhieu;
        private DevExpress.XtraGrid.Columns.GridColumn colLanKQ;
        private DevExpress.XtraGrid.Columns.GridColumn colDaUpLoad;
        private DevExpress.XtraGrid.Columns.GridColumn colThoiGianUpload;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayKy;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colArchive;
        private DevExpress.XtraGrid.Columns.GridColumn colMoTa;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiPhieu;
        private DevExpress.XtraEditors.PanelControl panel2;
        private Controls.TPHNormalButton btnDownLoadPDF;
        private Controls.TPHNormalButton btnInFile;
        private Controls.TPHNormalButton btnUpload;
        private DevExpress.XtraEditors.PanelControl panel1;
        private System.Windows.Forms.DateTimePicker dtpNgayIn;
        private DevExpress.XtraEditors.LabelControl label3;
        private DevExpress.XtraEditors.LabelControl label2;
        private System.Windows.Forms.TextBox txtmaBN;
        private Controls.TPHNormalButton btnXemFile;
        private DevExpress.XtraEditors.LabelControl label1;
        private System.Windows.Forms.TextBox txtBarcode;
        private DevExpress.XtraEditors.PanelControl pnSignInfo;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
    }
}