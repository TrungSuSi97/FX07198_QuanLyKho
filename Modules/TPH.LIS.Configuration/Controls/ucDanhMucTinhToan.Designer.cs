namespace TPH.LIS.Configuration.Controls
{
    partial class ucDanhMucTinhToan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDanhMucTinhToan));
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.lueLoaiTinhToan = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gvLoaiTinhToan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLoaiTinhToan_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoaiTinhToan_NoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ucSearchLookupEditor_DanhSachXetNghiem1 = new TPH.LIS.Configuration.Controls.ucSearchLookupEditor_DanhSachXetNghiem();
            this.btnXoa = new TPH.Controls.TPHNormalButton();
            this.btnLamMoi = new TPH.Controls.TPHNormalButton();
            this.btnThem = new TPH.Controls.TPHNormalButton();
            this.gcDanhSach = new DevExpress.XtraGrid.GridControl();
            this.gvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTenLoaiTinhToan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.ucGroupHeader2 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.ucGroupHeader1 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueLoaiTinhToan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLoaiTinhToan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.splitContainerControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 20);
            this.panel2.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(766, 46);
            this.panel2.TabIndex = 366;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.splitContainerControl1.Panel1.Appearance.Options.UseFont = true;
            this.splitContainerControl1.Panel1.Controls.Add(this.lueLoaiTinhToan);
            this.splitContainerControl1.Panel1.Controls.Add(this.label1);
            this.splitContainerControl1.Panel1.Controls.Add(this.label6);
            this.splitContainerControl1.Panel1.Controls.Add(this.ucSearchLookupEditor_DanhSachXetNghiem1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.splitContainerControl1.Panel2.Appearance.Options.UseFont = true;
            this.splitContainerControl1.Panel2.Controls.Add(this.btnXoa);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnLamMoi);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnThem);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(764, 44);
            this.splitContainerControl1.SplitterPosition = 453;
            this.splitContainerControl1.TabIndex = 45;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // lueLoaiTinhToan
            // 
            this.lueLoaiTinhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lueLoaiTinhToan.EditValue = "";
            this.lueLoaiTinhToan.Location = new System.Drawing.Point(336, 12);
            this.lueLoaiTinhToan.Name = "lueLoaiTinhToan";
            this.lueLoaiTinhToan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueLoaiTinhToan.Properties.NullText = "";
            this.lueLoaiTinhToan.Properties.PopupView = this.gvLoaiTinhToan;
            this.lueLoaiTinhToan.Size = new System.Drawing.Size(108, 20);
            this.lueLoaiTinhToan.TabIndex = 46;
            // 
            // gvLoaiTinhToan
            // 
            this.gvLoaiTinhToan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLoaiTinhToan_ID,
            this.colLoaiTinhToan_NoiDung});
            this.gvLoaiTinhToan.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvLoaiTinhToan.Name = "gvLoaiTinhToan";
            this.gvLoaiTinhToan.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvLoaiTinhToan.OptionsView.ShowGroupPanel = false;
            // 
            // colLoaiTinhToan_ID
            // 
            this.colLoaiTinhToan_ID.Caption = "ID loại tính toán";
            this.colLoaiTinhToan_ID.FieldName = "Id";
            this.colLoaiTinhToan_ID.Name = "colLoaiTinhToan_ID";
            this.colLoaiTinhToan_ID.Visible = true;
            this.colLoaiTinhToan_ID.VisibleIndex = 0;
            this.colLoaiTinhToan_ID.Width = 87;
            // 
            // colLoaiTinhToan_NoiDung
            // 
            this.colLoaiTinhToan_NoiDung.Caption = "Nội dung";
            this.colLoaiTinhToan_NoiDung.FieldName = "NoiDung";
            this.colLoaiTinhToan_NoiDung.Name = "colLoaiTinhToan_NoiDung";
            this.colLoaiTinhToan_NoiDung.Visible = true;
            this.colLoaiTinhToan_NoiDung.VisibleIndex = 1;
            this.colLoaiTinhToan_NoiDung.Width = 1241;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 45;
            this.label1.Text = "Loại tính toán";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 16);
            this.label6.TabIndex = 33;
            this.label6.Text = "XN tính toán";
            // 
            // ucSearchLookupEditor_DanhSachXetNghiem1
            // 
            this.ucSearchLookupEditor_DanhSachXetNghiem1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSearchLookupEditor_DanhSachXetNghiem1.CatchEnterKey = false;
            this.ucSearchLookupEditor_DanhSachXetNghiem1.CatchTabKey = false;
            this.ucSearchLookupEditor_DanhSachXetNghiem1.ChiDinh_EditValueChanged = null;
            this.ucSearchLookupEditor_DanhSachXetNghiem1.ChiDinh_Keypress = null;
            this.ucSearchLookupEditor_DanhSachXetNghiem1.ControlBack = null;
            this.ucSearchLookupEditor_DanhSachXetNghiem1.ControlNext = null;
            this.ucSearchLookupEditor_DanhSachXetNghiem1.DataSource = null;
            this.ucSearchLookupEditor_DanhSachXetNghiem1.DisplayMember = "";
            this.ucSearchLookupEditor_DanhSachXetNghiem1.Location = new System.Drawing.Point(90, 10);
            this.ucSearchLookupEditor_DanhSachXetNghiem1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.ucSearchLookupEditor_DanhSachXetNghiem1.Name = "ucSearchLookupEditor_DanhSachXetNghiem1";
            this.ucSearchLookupEditor_DanhSachXetNghiem1.SelectedValue = null;
            this.ucSearchLookupEditor_DanhSachXetNghiem1.Size = new System.Drawing.Size(140, 22);
            this.ucSearchLookupEditor_DanhSachXetNghiem1.TabIndex = 44;
            this.ucSearchLookupEditor_DanhSachXetNghiem1.ValueMember = "";
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXoa.BackColorHover = System.Drawing.Color.Empty;
            this.btnXoa.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXoa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXoa.BorderRadius = 5;
            this.btnXoa.BorderSize = 1;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXoa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(94, 2);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(88, 39);
            this.btnXoa.TabIndex = 42;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnXoa.UseHightLight = true;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLamMoi.BackColorHover = System.Drawing.Color.Empty;
            this.btnLamMoi.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLamMoi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnLamMoi.BorderRadius = 5;
            this.btnLamMoi.BorderSize = 1;
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForceColorHover = System.Drawing.Color.Empty;
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLamMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoi.Image")));
            this.btnLamMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLamMoi.Location = new System.Drawing.Point(190, 2);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(101, 39);
            this.btnLamMoi.TabIndex = 43;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLamMoi.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnLamMoi.UseHightLight = true;
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThem.BackColorHover = System.Drawing.Color.Empty;
            this.btnThem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThem.BorderRadius = 5;
            this.btnThem.BorderSize = 1;
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(-2, 2);
            this.btnThem.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(88, 39);
            this.btnThem.TabIndex = 41;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnThem.UseHightLight = true;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // gcDanhSach
            // 
            this.gcDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhSach.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.gcDanhSach.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gcDanhSach.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcDanhSach.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcDanhSach.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcDanhSach.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcDanhSach.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcDanhSach.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.gcDanhSach.EmbeddedNavigator.TextStringFormat = "{0} of {1}";
            this.gcDanhSach.Location = new System.Drawing.Point(0, 118);
            this.gcDanhSach.MainView = this.gvDanhSach;
            this.gcDanhSach.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.gcDanhSach.Name = "gcDanhSach";
            this.gcDanhSach.Size = new System.Drawing.Size(766, 348);
            this.gcDanhSach.TabIndex = 369;
            this.gcDanhSach.UseEmbeddedNavigator = true;
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
            this.gvDanhSach.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 10F);
            this.gvDanhSach.Appearance.FocusedRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhSach.Appearance.FooterPanel.Options.UseFont = true;
            this.gvDanhSach.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhSach.Appearance.GroupButton.Options.UseFont = true;
            this.gvDanhSach.Appearance.GroupFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhSach.Appearance.GroupFooter.Options.UseFont = true;
            this.gvDanhSach.Appearance.GroupPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSach.Appearance.GroupPanel.Options.UseFont = true;
            this.gvDanhSach.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.gvDanhSach.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvDanhSach.Appearance.GroupRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvDanhSach.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.gvDanhSach.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvDanhSach.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.HorzLine.Options.UseFont = true;
            this.gvDanhSach.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.OddRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.Preview.Options.UseFont = true;
            this.gvDanhSach.Appearance.Row.Font = new System.Drawing.Font("Arial", 10F);
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
            this.colTenLoaiTinhToan});
            this.gvDanhSach.DetailHeight = 284;
            this.gvDanhSach.GridControl = this.gcDanhSach;
            this.gvDanhSach.GroupCount = 1;
            this.gvDanhSach.Name = "gvDanhSach";
            this.gvDanhSach.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvDanhSach.OptionsSelection.CheckBoxSelectorColumnWidth = 26;
            this.gvDanhSach.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gvDanhSach.OptionsView.ColumnAutoWidth = false;
            this.gvDanhSach.OptionsView.RowAutoHeight = true;
            this.gvDanhSach.OptionsView.ShowAutoFilterRow = true;
            this.gvDanhSach.OptionsView.ShowGroupPanel = false;
            this.gvDanhSach.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTenLoaiTinhToan, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvDanhSach.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvDanhSach_CellValueChanged);
            // 
            // colTenLoaiTinhToan
            // 
            this.colTenLoaiTinhToan.Caption = "Loại tính toán";
            this.colTenLoaiTinhToan.FieldName = "tenloaitinhtoan";
            this.colTenLoaiTinhToan.Name = "colTenLoaiTinhToan";
            this.colTenLoaiTinhToan.Visible = true;
            this.colTenLoaiTinhToan.VisibleIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(445, 32);
            this.label3.TabIndex = 370;
            this.label3.Text = "Giới tính: 0 (Nam); 1 (Nữ); 2 (Tất cả)\r\nPhép toán điều kiện: < | > | <= | >= | <>" +
    " | =  (có thể kết hợp + | - | * | /)";
            // 
            // ucGroupHeader2
            // 
            this.ucGroupHeader2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeader2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader2.ForeColor = System.Drawing.Color.Yellow;
            this.ucGroupHeader2.GroupCaption = "THÊM XÉT NGHIỆM TÍNH TOÁN";
            this.ucGroupHeader2.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader2.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeader2.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.ucGroupHeader2.Name = "ucGroupHeader2";
            this.ucGroupHeader2.Size = new System.Drawing.Size(766, 20);
            this.ucGroupHeader2.TabIndex = 379;
            // 
            // ucGroupHeader1
            // 
            this.ucGroupHeader1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader1.ForeColor = System.Drawing.Color.Yellow;
            this.ucGroupHeader1.GroupCaption = "DANH SÁCH XÉT NGHIỆM TÍNH TOÁN";
            this.ucGroupHeader1.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader1.Location = new System.Drawing.Point(0, 66);
            this.ucGroupHeader1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.ucGroupHeader1.Name = "ucGroupHeader1";
            this.ucGroupHeader1.Size = new System.Drawing.Size(766, 20);
            this.ucGroupHeader1.TabIndex = 380;
            // 
            // ucDanhMucTinhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gcDanhSach);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ucGroupHeader1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ucGroupHeader2);
            this.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.Name = "ucDanhMucTinhToan";
            this.Size = new System.Drawing.Size(766, 466);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            this.splitContainerControl1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueLoaiTinhToan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLoaiTinhToan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private TPH.Controls.TPHNormalButton btnLamMoi;
        private TPH.Controls.TPHNormalButton btnXoa;
        private TPH.Controls.TPHNormalButton btnThem;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraGrid.GridControl gcDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSach;
        private ucSearchLookupEditor_DanhSachXetNghiem ucSearchLookupEditor_DanhSachXetNghiem1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.Label label3;
        private Common.Controls.ucGroupHeader ucGroupHeader2;
        private Common.Controls.ucGroupHeader ucGroupHeader1;
        private DevExpress.XtraEditors.SearchLookUpEdit lueLoaiTinhToan;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLoaiTinhToan;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiTinhToan_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiTinhToan_NoiDung;
        private DevExpress.XtraGrid.Columns.GridColumn colTenLoaiTinhToan;
    }
}
