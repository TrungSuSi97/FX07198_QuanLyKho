namespace TPH.LIS.App.QuanLyChamCong
{
    partial class FrmChamCong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChamCong));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ucGroupHeader2 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.ucGroupHeader1 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.btnVaoLam = new TPH.Controls.TPHNormalButton();
            this.btnRaVe = new TPH.Controls.TPHNormalButton();
            this.gcResult = new DevExpress.XtraGrid.GridControl();
            this.gvResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaChiDinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenChiDinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKetQua = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenPhanLoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNhomChiDinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DaThuTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTgNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaBienLai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.pnContaint)).BeginInit();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnMenu)).BeginInit();
            this.pnMenu.SuspendLayout();
            this.xtraScrollableControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnFormControl)).BeginInit();
            this.pnFormControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
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
            this.lblTitle.Size = new System.Drawing.Size(93, 22);
            this.lblTitle.Text = "Chấm công";
            // 
            // pnContaint
            // 
            this.pnContaint.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnContaint.Appearance.Options.UseBackColor = true;
            this.pnContaint.Controls.Add(this.xtraTabControl1);
            this.pnContaint.Location = new System.Drawing.Point(0, 28);
            this.pnContaint.Size = new System.Drawing.Size(916, 565);
            // 
            // pnLabel
            // 
            this.pnLabel.Size = new System.Drawing.Size(916, 1);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(564, 0);
            // 
            // lblMainESC
            // 
            this.lblMainESC.Appearance.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainESC.Appearance.Options.UseFont = true;
            this.lblMainESC.ImageOptions.Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lblMainESC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblMainESC.ImageOptions.Image")));
            this.lblMainESC.Location = new System.Drawing.Point(593, 0);
            // 
            // pnMenu
            // 
            this.pnMenu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnMenu.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnMenu.Appearance.Options.UseBackColor = true;
            this.pnMenu.Location = new System.Drawing.Point(0, 1);
            this.pnMenu.Size = new System.Drawing.Size(916, 27);
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.xtraScrollableControlMain.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(916, 26);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnFormControl.Appearance.Options.UseBackColor = true;
            this.pnFormControl.Location = new System.Drawing.Point(808, 1);
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
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.btnVaoLam);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnRaVe);
            this.splitContainerControl1.Panel1.Controls.Add(this.ucGroupHeader2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gcResult);
            this.splitContainerControl1.Panel2.Controls.Add(this.ucGroupHeader1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(910, 536);
            this.splitContainerControl1.SplitterPosition = 288;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // ucGroupHeader2
            // 
            this.ucGroupHeader2.BackColor = System.Drawing.Color.Transparent;
            this.ucGroupHeader2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(218)))), ((int)(((byte)(89)))));
            this.ucGroupHeader2.GroupCaption = "THÔNG TIN CÁ NHÂN";
            this.ucGroupHeader2.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader2.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeader2.Margin = new System.Windows.Forms.Padding(0);
            this.ucGroupHeader2.MaximumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader2.MinimumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader2.Name = "ucGroupHeader2";
            this.ucGroupHeader2.Size = new System.Drawing.Size(910, 23);
            this.ucGroupHeader2.TabIndex = 99;
            // 
            // ucGroupHeader1
            // 
            this.ucGroupHeader1.BackColor = System.Drawing.Color.Transparent;
            this.ucGroupHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(218)))), ((int)(((byte)(89)))));
            this.ucGroupHeader1.GroupCaption = "THEO DÕI CHẤM CÔNG";
            this.ucGroupHeader1.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader1.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeader1.Margin = new System.Windows.Forms.Padding(0);
            this.ucGroupHeader1.MaximumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader1.MinimumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader1.Name = "ucGroupHeader1";
            this.ucGroupHeader1.Size = new System.Drawing.Size(910, 23);
            this.ucGroupHeader1.TabIndex = 100;
            // 
            // btnVaoLam
            // 
            this.btnVaoLam.BackColor = System.Drawing.Color.DarkCyan;
            this.btnVaoLam.BackColorHover = System.Drawing.Color.Empty;
            this.btnVaoLam.BackgroundColor = System.Drawing.Color.DarkCyan;
            this.btnVaoLam.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnVaoLam.BorderRadius = 5;
            this.btnVaoLam.BorderSize = 1;
            this.btnVaoLam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVaoLam.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnVaoLam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVaoLam.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVaoLam.ForceColorHover = System.Drawing.Color.Empty;
            this.btnVaoLam.ForeColor = System.Drawing.Color.White;
            this.btnVaoLam.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVaoLam.Location = new System.Drawing.Point(7, 243);
            this.btnVaoLam.Margin = new System.Windows.Forms.Padding(0);
            this.btnVaoLam.Name = "btnVaoLam";
            this.btnVaoLam.Size = new System.Drawing.Size(107, 38);
            this.btnVaoLam.TabIndex = 101;
            this.btnVaoLam.Text = "Vào làm";
            this.btnVaoLam.TextColor = System.Drawing.Color.White;
            this.btnVaoLam.UseHightLight = true;
            this.btnVaoLam.UseVisualStyleBackColor = false;
            this.btnVaoLam.Click += new System.EventHandler(this.btnVaoLam_Click);
            // 
            // btnRaVe
            // 
            this.btnRaVe.BackColor = System.Drawing.Color.DarkCyan;
            this.btnRaVe.BackColorHover = System.Drawing.Color.Empty;
            this.btnRaVe.BackgroundColor = System.Drawing.Color.DarkCyan;
            this.btnRaVe.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnRaVe.BorderRadius = 5;
            this.btnRaVe.BorderSize = 1;
            this.btnRaVe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRaVe.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRaVe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRaVe.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRaVe.ForceColorHover = System.Drawing.Color.Empty;
            this.btnRaVe.ForeColor = System.Drawing.Color.White;
            this.btnRaVe.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRaVe.Location = new System.Drawing.Point(119, 243);
            this.btnRaVe.Margin = new System.Windows.Forms.Padding(0);
            this.btnRaVe.Name = "btnRaVe";
            this.btnRaVe.Size = new System.Drawing.Size(107, 38);
            this.btnRaVe.TabIndex = 100;
            this.btnRaVe.Text = "Ra về";
            this.btnRaVe.TextColor = System.Drawing.Color.White;
            this.btnRaVe.UseHightLight = true;
            this.btnRaVe.UseVisualStyleBackColor = false;
            this.btnRaVe.Click += new System.EventHandler(this.btnRaVe_Click);
            // 
            // gcResult
            // 
            this.gcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcResult.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Arial", 8F);
            this.gcResult.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gcResult.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcResult.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcResult.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcResult.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcResult.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcResult.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0);
            this.gcResult.EmbeddedNavigator.TextStringFormat = "Dòng {0}/{1}";
            this.gcResult.Location = new System.Drawing.Point(0, 23);
            this.gcResult.MainView = this.gvResult;
            this.gcResult.Margin = new System.Windows.Forms.Padding(0);
            this.gcResult.Name = "gcResult";
            this.gcResult.Size = new System.Drawing.Size(910, 215);
            this.gcResult.TabIndex = 101;
            this.gcResult.UseEmbeddedNavigator = true;
            this.gcResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvResult});
            // 
            // gvResult
            // 
            this.gvResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaChiDinh,
            this.TenChiDinh,
            this.colKetQua,
            this.TenPhanLoai,
            this.colTenNhomChiDinh,
            this.DaThuTien,
            this.colTgNhap,
            this.colUserNhap,
            this.colMaBienLai});
            this.gvResult.DetailHeight = 284;
            this.gvResult.GridControl = this.gcResult;
            this.gvResult.GroupFormat = "{0}: [#image]{1}  -  {2}";
            this.gvResult.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GiaRieng", null, "{0:N0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TienCong", null, "{0:N0}")});
            this.gvResult.Name = "gvResult";
            this.gvResult.OptionsSelection.CheckBoxSelectorColumnWidth = 26;
            this.gvResult.OptionsSelection.MultiSelect = true;
            this.gvResult.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvResult.OptionsView.ColumnAutoWidth = false;
            this.gvResult.OptionsView.ShowFooter = true;
            this.gvResult.OptionsView.ShowGroupPanel = false;
            // 
            // MaChiDinh
            // 
            this.MaChiDinh.Caption = "Mã chỉ định";
            this.MaChiDinh.FieldName = "MaChiDinh";
            this.MaChiDinh.MinWidth = 17;
            this.MaChiDinh.Name = "MaChiDinh";
            this.MaChiDinh.OptionsColumn.ReadOnly = true;
            this.MaChiDinh.Visible = true;
            this.MaChiDinh.VisibleIndex = 3;
            this.MaChiDinh.Width = 80;
            // 
            // TenChiDinh
            // 
            this.TenChiDinh.Caption = "Tên chỉ định";
            this.TenChiDinh.FieldName = "TenChiDinh";
            this.TenChiDinh.MinWidth = 17;
            this.TenChiDinh.Name = "TenChiDinh";
            this.TenChiDinh.OptionsColumn.AllowEdit = false;
            this.TenChiDinh.OptionsColumn.ReadOnly = true;
            this.TenChiDinh.Visible = true;
            this.TenChiDinh.VisibleIndex = 1;
            this.TenChiDinh.Width = 300;
            // 
            // colKetQua
            // 
            this.colKetQua.Caption = "Kết quả";
            this.colKetQua.FieldName = "KetQua";
            this.colKetQua.MinWidth = 17;
            this.colKetQua.Name = "colKetQua";
            this.colKetQua.OptionsColumn.ReadOnly = true;
            this.colKetQua.Visible = true;
            this.colKetQua.VisibleIndex = 2;
            this.colKetQua.Width = 99;
            // 
            // TenPhanLoai
            // 
            this.TenPhanLoai.Caption = "Dịch vụ";
            this.TenPhanLoai.FieldName = "TenPhanLoai";
            this.TenPhanLoai.FieldNameSortGroup = "ThuTuPhanLoai";
            this.TenPhanLoai.MinWidth = 17;
            this.TenPhanLoai.Name = "TenPhanLoai";
            this.TenPhanLoai.OptionsColumn.AllowEdit = false;
            this.TenPhanLoai.OptionsColumn.ReadOnly = true;
            this.TenPhanLoai.Visible = true;
            this.TenPhanLoai.VisibleIndex = 10;
            this.TenPhanLoai.Width = 64;
            // 
            // colTenNhomChiDinh
            // 
            this.colTenNhomChiDinh.Caption = "Nhóm";
            this.colTenNhomChiDinh.FieldName = "TenNhomChiDinh";
            this.colTenNhomChiDinh.FieldNameSortGroup = "ThuTuIn";
            this.colTenNhomChiDinh.MinWidth = 17;
            this.colTenNhomChiDinh.Name = "colTenNhomChiDinh";
            this.colTenNhomChiDinh.OptionsColumn.AllowEdit = false;
            this.colTenNhomChiDinh.OptionsColumn.ReadOnly = true;
            this.colTenNhomChiDinh.Visible = true;
            this.colTenNhomChiDinh.VisibleIndex = 4;
            this.colTenNhomChiDinh.Width = 64;
            // 
            // DaThuTien
            // 
            this.DaThuTien.Caption = "Đã thu tiền";
            this.DaThuTien.FieldName = "DaThuTien";
            this.DaThuTien.MinWidth = 17;
            this.DaThuTien.Name = "DaThuTien";
            this.DaThuTien.OptionsColumn.ReadOnly = true;
            this.DaThuTien.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.DaThuTien.Visible = true;
            this.DaThuTien.VisibleIndex = 7;
            this.DaThuTien.Width = 72;
            // 
            // colTgNhap
            // 
            this.colTgNhap.Caption = "Tg Nhập";
            this.colTgNhap.DisplayFormat.FormatString = "HH:mm dd/MM/yyyy";
            this.colTgNhap.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colTgNhap.FieldName = "ThoiGianNhap";
            this.colTgNhap.MinWidth = 17;
            this.colTgNhap.Name = "colTgNhap";
            this.colTgNhap.OptionsColumn.ReadOnly = true;
            this.colTgNhap.Visible = true;
            this.colTgNhap.VisibleIndex = 5;
            this.colTgNhap.Width = 129;
            // 
            // colUserNhap
            // 
            this.colUserNhap.Caption = "Người nhập";
            this.colUserNhap.FieldName = "UserNhap";
            this.colUserNhap.MinWidth = 17;
            this.colUserNhap.Name = "colUserNhap";
            this.colUserNhap.OptionsColumn.ReadOnly = true;
            this.colUserNhap.Visible = true;
            this.colUserNhap.VisibleIndex = 6;
            this.colUserNhap.Width = 78;
            // 
            // colMaBienLai
            // 
            this.colMaBienLai.Caption = "Mã biên lai";
            this.colMaBienLai.FieldName = "IDBienLai";
            this.colMaBienLai.MinWidth = 17;
            this.colMaBienLai.Name = "colMaBienLai";
            this.colMaBienLai.OptionsColumn.AllowEdit = false;
            this.colMaBienLai.OptionsColumn.ReadOnly = true;
            this.colMaBienLai.Visible = true;
            this.colMaBienLai.VisibleIndex = 9;
            this.colMaBienLai.Width = 64;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(2, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(912, 561);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.splitContainerControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(910, 536);
            this.xtraTabPage1.Text = "CHẤM CÔNG";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(910, 536);
            this.xtraTabPage2.Text = "XUẤT DỮ LIỆU CHẤM CÔNG";
            // 
            // FrmChamCong
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(129)))), ((int)(((byte)(176)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 593);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmChamCong";
            this.Text = "Chấm công";
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private Common.Controls.ucGroupHeader ucGroupHeader2;
        private Common.Controls.ucGroupHeader ucGroupHeader1;
        private Controls.TPHNormalButton btnVaoLam;
        private Controls.TPHNormalButton btnRaVe;
        public DevExpress.XtraGrid.GridControl gcResult;
        public DevExpress.XtraGrid.Views.Grid.GridView gvResult;
        public DevExpress.XtraGrid.Columns.GridColumn MaChiDinh;
        public DevExpress.XtraGrid.Columns.GridColumn TenChiDinh;
        private DevExpress.XtraGrid.Columns.GridColumn colKetQua;
        private DevExpress.XtraGrid.Columns.GridColumn TenPhanLoai;
        public DevExpress.XtraGrid.Columns.GridColumn colTenNhomChiDinh;
        private DevExpress.XtraGrid.Columns.GridColumn DaThuTien;
        private DevExpress.XtraGrid.Columns.GridColumn colTgNhap;
        private DevExpress.XtraGrid.Columns.GridColumn colUserNhap;
        public DevExpress.XtraGrid.Columns.GridColumn colMaBienLai;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
    }
}