namespace TPH.LIS.App.Settings.HeThong
{
    partial class FrmDanhMuc_ChonBieuMau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDanhMuc_ChonBieuMau));
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.btnLưuNoiDung = new TPH.Controls.TPHNormalButton();
            this.btnXoaMau = new TPH.Controls.TPHNormalButton();
            this.btnThemMau = new TPH.Controls.TPHNormalButton();
            this.cboLoaiBieuMau = new System.Windows.Forms.ComboBox();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gcMau = new DevExpress.XtraGrid.GridControl();
            this.gvMau = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIDMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemRichTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.colIDLoaiMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNhomBieuMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ricKetLuan = new RicherTextBox.RicherTextBox();
            this.pnChon = new DevExpress.XtraEditors.PanelControl();
            this.btnChon = new TPH.Controls.TPHNormalButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnContaint)).BeginInit();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnMenu)).BeginInit();
            this.pnMenu.SuspendLayout();
            this.xtraScrollableControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnFormControl)).BeginInit();
            this.pnFormControl.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnChon)).BeginInit();
            this.pnChon.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Options.UseBackColor = true;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Size = new System.Drawing.Size(88, 22);
            this.lblTitle.Text = "CHỌN MẪU";
            // 
            // pnContaint
            // 
            this.pnContaint.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnContaint.Appearance.Options.UseBackColor = true;
            this.pnContaint.Controls.Add(this.groupBox2);
            this.pnContaint.Controls.Add(this.gbInfo);
            this.pnContaint.Location = new System.Drawing.Point(0, 26);
            this.pnContaint.Size = new System.Drawing.Size(758, 660);
            // 
            // pnLabel
            // 
            this.pnLabel.Padding = new System.Windows.Forms.Padding(4, 11, 4, 3);
            this.pnLabel.Size = new System.Drawing.Size(758, 0);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(402, 11);
            this.btnClose.Size = new System.Drawing.Size(29, 0);
            // 
            // lblMainESC
            // 
            this.lblMainESC.Appearance.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainESC.Appearance.Options.UseFont = true;
            this.lblMainESC.ImageOptions.Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lblMainESC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblMainESC.ImageOptions.Image")));
            this.lblMainESC.Location = new System.Drawing.Point(431, 11);
            // 
            // pnMenu
            // 
            this.pnMenu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnMenu.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnMenu.Appearance.Options.UseBackColor = true;
            this.pnMenu.Size = new System.Drawing.Size(758, 26);
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.xtraScrollableControlMain.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(758, 25);
            // 
            // ucGroupHeaderChonMain
            // 
            this.ucGroupHeaderChonMain.Location = new System.Drawing.Point(90, 1);
            this.ucGroupHeaderChonMain.Size = new System.Drawing.Size(10, 24);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnFormControl.Appearance.Options.UseBackColor = true;
            this.pnFormControl.Location = new System.Drawing.Point(650, 1);
            this.pnFormControl.Size = new System.Drawing.Size(106, 24);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Enabled = false;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(171)))), ((int)(((byte)(203)))));
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(160)))), ((int)(((byte)(190)))));
            this.btnMinimize.Visible = false;
            // 
            // btnMaximize
            // 
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(141)))), ((int)(((byte)(233)))));
            this.btnMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(132)))), ((int)(((byte)(218)))));
            this.btnMaximize.Visible = false;
            // 
            // tphIconButton1
            // 
            this.tphIconButton1.FlatAppearance.BorderSize = 0;
            this.tphIconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(87)))), ((int)(((byte)(125)))));
            this.tphIconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(81)))), ((int)(((byte)(117)))));
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.btnLưuNoiDung);
            this.gbInfo.Controls.Add(this.btnXoaMau);
            this.gbInfo.Controls.Add(this.btnThemMau);
            this.gbInfo.Controls.Add(this.cboLoaiBieuMau);
            this.gbInfo.Controls.Add(this.label1);
            this.gbInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbInfo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInfo.Location = new System.Drawing.Point(2, 2);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(754, 60);
            this.gbInfo.TabIndex = 0;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Thông tin";
            // 
            // btnLưuNoiDung
            // 
            this.btnLưuNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLưuNoiDung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLưuNoiDung.BackColorHover = System.Drawing.Color.Empty;
            this.btnLưuNoiDung.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLưuNoiDung.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnLưuNoiDung.BorderRadius = 5;
            this.btnLưuNoiDung.BorderSize = 1;
            this.btnLưuNoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLưuNoiDung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLưuNoiDung.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLưuNoiDung.ForceColorHover = System.Drawing.Color.Empty;
            this.btnLưuNoiDung.ForeColor = System.Drawing.Color.Black;
            this.btnLưuNoiDung.Image = global::TPH.LIS.App.Properties.Resources.Save;
            this.btnLưuNoiDung.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLưuNoiDung.Location = new System.Drawing.Point(490, 23);
            this.btnLưuNoiDung.Name = "btnLưuNoiDung";
            this.btnLưuNoiDung.Size = new System.Drawing.Size(134, 29);
            this.btnLưuNoiDung.TabIndex = 4;
            this.btnLưuNoiDung.Text = "Lưu nội dung";
            this.btnLưuNoiDung.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLưuNoiDung.TextColor = System.Drawing.Color.Black;
            this.btnLưuNoiDung.UseHightLight = true;
            this.btnLưuNoiDung.UseVisualStyleBackColor = false;
            this.btnLưuNoiDung.Click += new System.EventHandler(this.btnLưuNoiDung_Click);
            // 
            // btnXoaMau
            // 
            this.btnXoaMau.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXoaMau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXoaMau.BackColorHover = System.Drawing.Color.Empty;
            this.btnXoaMau.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXoaMau.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXoaMau.BorderRadius = 5;
            this.btnXoaMau.BorderSize = 1;
            this.btnXoaMau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaMau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaMau.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaMau.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXoaMau.ForeColor = System.Drawing.Color.Black;
            this.btnXoaMau.Image = global::TPH.LIS.App.Properties.Resources.DeleteRed_16x16;
            this.btnXoaMau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaMau.Location = new System.Drawing.Point(637, 23);
            this.btnXoaMau.Name = "btnXoaMau";
            this.btnXoaMau.Size = new System.Drawing.Size(114, 29);
            this.btnXoaMau.TabIndex = 3;
            this.btnXoaMau.Text = "Xóa mẫu chọn";
            this.btnXoaMau.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaMau.TextColor = System.Drawing.Color.Black;
            this.btnXoaMau.UseHightLight = true;
            this.btnXoaMau.UseVisualStyleBackColor = false;
            this.btnXoaMau.Click += new System.EventHandler(this.btnXoaMau_Click);
            // 
            // btnThemMau
            // 
            this.btnThemMau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThemMau.BackColorHover = System.Drawing.Color.Empty;
            this.btnThemMau.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThemMau.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThemMau.BorderRadius = 5;
            this.btnThemMau.BorderSize = 1;
            this.btnThemMau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemMau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMau.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMau.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThemMau.ForeColor = System.Drawing.Color.Black;
            this.btnThemMau.Image = global::TPH.LIS.App.Properties.Resources.add2_16x16;
            this.btnThemMau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemMau.Location = new System.Drawing.Point(367, 23);
            this.btnThemMau.Name = "btnThemMau";
            this.btnThemMau.Size = new System.Drawing.Size(110, 29);
            this.btnThemMau.TabIndex = 2;
            this.btnThemMau.Text = "Thêm mẫu";
            this.btnThemMau.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemMau.TextColor = System.Drawing.Color.Black;
            this.btnThemMau.UseHightLight = true;
            this.btnThemMau.UseVisualStyleBackColor = false;
            this.btnThemMau.Click += new System.EventHandler(this.btnThemMau_Click);
            // 
            // cboLoaiBieuMau
            // 
            this.cboLoaiBieuMau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiBieuMau.FormattingEnabled = true;
            this.cboLoaiBieuMau.Location = new System.Drawing.Point(114, 25);
            this.cboLoaiBieuMau.Name = "cboLoaiBieuMau";
            this.cboLoaiBieuMau.Size = new System.Drawing.Size(247, 23);
            this.cboLoaiBieuMau.TabIndex = 1;
            this.cboLoaiBieuMau.SelectedIndexChanged += new System.EventHandler(this.cboLoaiBieuMau_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại biểu mẫu:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gcMau);
            this.groupBox2.Controls.Add(this.ricKetLuan);
            this.groupBox2.Controls.Add(this.pnChon);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(2, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(754, 596);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            // 
            // gcMau
            // 
            this.gcMau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMau.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcMau.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.gcMau.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcMau.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gcMau.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcMau.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.gcMau.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcMau.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.gcMau.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcMau.EmbeddedNavigator.TextStringFormat = " {0} of {1}";
            this.gcMau.Location = new System.Drawing.Point(3, 256);
            this.gcMau.MainView = this.gvMau;
            this.gcMau.Name = "gcMau";
            this.gcMau.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRichTextEdit1});
            this.gcMau.Size = new System.Drawing.Size(748, 302);
            this.gcMau.TabIndex = 27;
            this.gcMau.UseEmbeddedNavigator = true;
            this.gcMau.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMau});
            // 
            // gvMau
            // 
            this.gvMau.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIDMau,
            this.colNoiDung,
            this.colIDLoaiMau,
            this.colNhomBieuMau});
            this.gvMau.GridControl = this.gcMau;
            this.gvMau.GroupCount = 1;
            this.gvMau.Name = "gvMau";
            this.gvMau.OptionsSelection.MultiSelect = true;
            this.gvMau.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvMau.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gvMau.OptionsView.ColumnAutoWidth = false;
            this.gvMau.OptionsView.RowAutoHeight = true;
            this.gvMau.OptionsView.ShowGroupPanel = false;
            this.gvMau.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNhomBieuMau, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvMau.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvMau_FocusedRowChanged);
            this.gvMau.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gvMau_FocusedColumnChanged);
            // 
            // colIDMau
            // 
            this.colIDMau.Caption = "ID mẫu";
            this.colIDMau.FieldName = "ID";
            this.colIDMau.Name = "colIDMau";
            this.colIDMau.OptionsColumn.ReadOnly = true;
            this.colIDMau.Visible = true;
            this.colIDMau.VisibleIndex = 1;
            // 
            // colNoiDung
            // 
            this.colNoiDung.Caption = "Nội dung";
            this.colNoiDung.ColumnEdit = this.repositoryItemRichTextEdit1;
            this.colNoiDung.FieldName = "NoiDung";
            this.colNoiDung.Name = "colNoiDung";
            this.colNoiDung.OptionsColumn.ReadOnly = true;
            this.colNoiDung.Visible = true;
            this.colNoiDung.VisibleIndex = 2;
            this.colNoiDung.Width = 557;
            // 
            // repositoryItemRichTextEdit1
            // 
            this.repositoryItemRichTextEdit1.Name = "repositoryItemRichTextEdit1";
            this.repositoryItemRichTextEdit1.ShowCaretInReadOnly = false;
            // 
            // colIDLoaiMau
            // 
            this.colIDLoaiMau.Caption = "ID Loại mẫu";
            this.colIDLoaiMau.FieldName = "IdLoaiMau";
            this.colIDLoaiMau.Name = "colIDLoaiMau";
            this.colIDLoaiMau.OptionsColumn.ReadOnly = true;
            // 
            // colNhomBieuMau
            // 
            this.colNhomBieuMau.Caption = "Nhóm biểu mẫu";
            this.colNhomBieuMau.FieldName = "NhomBieuMau";
            this.colNhomBieuMau.Name = "colNhomBieuMau";
            this.colNhomBieuMau.OptionsColumn.ReadOnly = true;
            this.colNhomBieuMau.Visible = true;
            this.colNhomBieuMau.VisibleIndex = 3;
            // 
            // ricKetLuan
            // 
            this.ricKetLuan.AlignCenterVisible = true;
            this.ricKetLuan.AlignLeftVisible = true;
            this.ricKetLuan.AlignRightVisible = true;
            this.ricKetLuan.BoldVisible = true;
            this.ricKetLuan.BulletsVisible = false;
            this.ricKetLuan.ChooseFontVisible = true;
            this.ricKetLuan.Dock = System.Windows.Forms.DockStyle.Top;
            this.ricKetLuan.FindReplaceVisible = false;
            this.ricKetLuan.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ricKetLuan.FontColorVisible = true;
            this.ricKetLuan.FontFamilyVisible = true;
            this.ricKetLuan.FontSizeVisible = true;
            this.ricKetLuan.GroupAlignmentVisible = true;
            this.ricKetLuan.GroupBoldUnderlineItalicVisible = true;
            this.ricKetLuan.GroupFontColorVisible = true;
            this.ricKetLuan.GroupFontNameAndSizeVisible = true;
            this.ricKetLuan.GroupIndentationAndBulletsVisible = false;
            this.ricKetLuan.GroupInsertVisible = false;
            this.ricKetLuan.GroupSaveAndLoadVisible = false;
            this.ricKetLuan.GroupZoomVisible = false;
            this.ricKetLuan.INDENT = 10;
            this.ricKetLuan.IndentVisible = false;
            this.ricKetLuan.InsertPictureVisible = false;
            this.ricKetLuan.ItalicVisible = true;
            this.ricKetLuan.LoadVisible = false;
            this.ricKetLuan.Location = new System.Drawing.Point(3, 17);
            this.ricKetLuan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ricKetLuan.Name = "ricKetLuan";
            this.ricKetLuan.OutdentVisible = false;
            this.ricKetLuan.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset20" +
    "4 Microsoft Sans Serif;}}\r\n{\\*\\generator Riched20 10.0.22621}\\viewkind4\\uc1 \r\n\\p" +
    "ard\\f0\\fs18\\lang1049\\par\r\n}\r\n";
            this.ricKetLuan.SaveVisible = false;
            this.ricKetLuan.SeparatorAlignVisible = true;
            this.ricKetLuan.SeparatorBoldUnderlineItalicVisible = true;
            this.ricKetLuan.SeparatorFontColorVisible = true;
            this.ricKetLuan.SeparatorFontVisible = true;
            this.ricKetLuan.SeparatorIndentAndBulletsVisible = false;
            this.ricKetLuan.SeparatorInsertVisible = false;
            this.ricKetLuan.SeparatorSaveLoadVisible = false;
            this.ricKetLuan.Size = new System.Drawing.Size(748, 239);
            this.ricKetLuan.TabIndex = 26;
            this.ricKetLuan.ToolStripVisible = true;
            this.ricKetLuan.UnderlineVisible = true;
            this.ricKetLuan.WordWrapVisible = true;
            this.ricKetLuan.ZoomFactorTextVisible = false;
            this.ricKetLuan.ZoomInVisible = false;
            this.ricKetLuan.ZoomOutVisible = false;
            // 
            // pnChon
            // 
            this.pnChon.Controls.Add(this.btnChon);
            this.pnChon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnChon.Location = new System.Drawing.Point(3, 558);
            this.pnChon.Name = "pnChon";
            this.pnChon.Size = new System.Drawing.Size(748, 35);
            this.pnChon.TabIndex = 2;
            // 
            // btnChon
            // 
            this.btnChon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnChon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnChon.BackColorHover = System.Drawing.Color.Empty;
            this.btnChon.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnChon.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnChon.BorderRadius = 5;
            this.btnChon.BorderSize = 1;
            this.btnChon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChon.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChon.ForceColorHover = System.Drawing.Color.Empty;
            this.btnChon.ForeColor = System.Drawing.Color.Black;
            this.btnChon.Image = global::TPH.LIS.App.Properties.Resources.check_white_16x16;
            this.btnChon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChon.Location = new System.Drawing.Point(313, 3);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(122, 29);
            this.btnChon.TabIndex = 3;
            this.btnChon.Text = "Lấy mẫu chọn";
            this.btnChon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChon.TextColor = System.Drawing.Color.Black;
            this.btnChon.UseHightLight = true;
            this.btnChon.UseVisualStyleBackColor = false;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // FrmDanhMuc_ChonBieuMau
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(129)))), ((int)(((byte)(176)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(758, 686);
            this.Name = "FrmDanhMuc_ChonBieuMau";
            this.Text = "FrmDanhMuc_ChonBieuMau";
            this.Load += new System.EventHandler(this.FrmDanhMuc_ChonBieuMau_Load);
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
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcMau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnChon)).EndInit();
            this.pnChon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.ComboBox cboLoaiBieuMau;
        private DevExpress.XtraEditors.LabelControl label1;
        private TPH.Controls.TPHNormalButton btnThemMau;
        private TPH.Controls.TPHNormalButton btnXoaMau;
        private DevExpress.XtraEditors.PanelControl pnChon;
        private TPH.Controls.TPHNormalButton btnChon;
        private RicherTextBox.RicherTextBox ricKetLuan;
        private DevExpress.XtraGrid.GridControl gcMau;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMau;
        private DevExpress.XtraGrid.Columns.GridColumn colIDMau;
        private DevExpress.XtraGrid.Columns.GridColumn colNoiDung;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colIDLoaiMau;
        private DevExpress.XtraGrid.Columns.GridColumn colNhomBieuMau;
        private TPH.Controls.TPHNormalButton btnLưuNoiDung;
    }
}