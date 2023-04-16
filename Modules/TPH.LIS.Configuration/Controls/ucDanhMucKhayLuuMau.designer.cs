namespace TPH.LIS.Configuration.Controls
{
    partial class ucDanhMucKhayLuuMau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDanhMucKhayLuuMau));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.numDoc = new System.Windows.Forms.NumericUpDown();
            this.numNgang = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXoa = new TPH.Controls.TPHNormalButton();
            this.txtMaDanhMuc = new System.Windows.Forms.TextBox();
            this.btnLamMoi = new TPH.Controls.TPHNormalButton();
            this.btnThem = new TPH.Controls.TPHNormalButton();
            this.label30 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.ucSearchLookupEditor_DanhSachTuLuuMau1 = new TPH.LIS.Configuration.Controls.ucSearchLookupEditor_DanhSachTuLuuMau();
            this.txtTenDanhMuc = new System.Windows.Forms.TextBox();
            this.gcDanhSach = new DevExpress.XtraGrid.GridControl();
            this.gvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ucGroupHeader2 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.ucGroupHeader1 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNgang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.numDoc);
            this.panel2.Controls.Add(this.numNgang);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.txtMaDanhMuc);
            this.panel2.Controls.Add(this.btnLamMoi);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Controls.Add(this.label30);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label32);
            this.panel2.Controls.Add(this.ucSearchLookupEditor_DanhSachTuLuuMau1);
            this.panel2.Controls.Add(this.txtTenDanhMuc);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 20);
            this.panel2.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(766, 66);
            this.panel2.TabIndex = 366;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Dọc";
            // 
            // numDoc
            // 
            this.numDoc.Location = new System.Drawing.Point(281, 38);
            this.numDoc.Name = "numDoc";
            this.numDoc.Size = new System.Drawing.Size(114, 20);
            this.numDoc.TabIndex = 46;
            // 
            // numNgang
            // 
            this.numNgang.Location = new System.Drawing.Point(87, 38);
            this.numNgang.Name = "numNgang";
            this.numNgang.Size = new System.Drawing.Size(98, 20);
            this.numNgang.TabIndex = 45;
            this.numNgang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numNgang_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Ngang";
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
            this.btnXoa.Location = new System.Drawing.Point(527, 30);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(88, 29);
            this.btnXoa.TabIndex = 42;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnXoa.UseHightLight = true;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtMaDanhMuc
            // 
            this.txtMaDanhMuc.Location = new System.Drawing.Point(281, 6);
            this.txtMaDanhMuc.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtMaDanhMuc.Name = "txtMaDanhMuc";
            this.txtMaDanhMuc.Size = new System.Drawing.Size(114, 20);
            this.txtMaDanhMuc.TabIndex = 36;
            this.txtMaDanhMuc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaDanhMuc_KeyPress);
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
            this.btnLamMoi.Location = new System.Drawing.Point(626, 29);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(101, 29);
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
            this.btnThem.Location = new System.Drawing.Point(422, 30);
            this.btnThem.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(88, 29);
            this.btnThem.TabIndex = 41;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnThem.UseHightLight = true;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(201, 10);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(48, 13);
            this.label30.TabIndex = 35;
            this.label30.Text = "Mã khay";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Tủ lưu mẫu";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(419, 10);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(52, 13);
            this.label32.TabIndex = 37;
            this.label32.Text = "Tên khay";
            // 
            // ucSearchLookupEditor_DanhSachTuLuuMau1
            // 
            this.ucSearchLookupEditor_DanhSachTuLuuMau1.CatchEnterKey = true;
            this.ucSearchLookupEditor_DanhSachTuLuuMau1.CatchTabKey = false;
            this.ucSearchLookupEditor_DanhSachTuLuuMau1.ControlBack = null;
            this.ucSearchLookupEditor_DanhSachTuLuuMau1.ControlNext = this.txtMaDanhMuc;
            this.ucSearchLookupEditor_DanhSachTuLuuMau1.DisplayMember = "";
            this.ucSearchLookupEditor_DanhSachTuLuuMau1.Location = new System.Drawing.Point(87, 5);
            this.ucSearchLookupEditor_DanhSachTuLuuMau1.Name = "ucSearchLookupEditor_DanhSachTuLuuMau1";
            this.ucSearchLookupEditor_DanhSachTuLuuMau1.SelectedText = null;
            this.ucSearchLookupEditor_DanhSachTuLuuMau1.SelectedValue = null;
            this.ucSearchLookupEditor_DanhSachTuLuuMau1.Size = new System.Drawing.Size(98, 22);
            this.ucSearchLookupEditor_DanhSachTuLuuMau1.TabIndex = 34;
            this.ucSearchLookupEditor_DanhSachTuLuuMau1.ValueMember = "";
            // 
            // txtTenDanhMuc
            // 
            this.txtTenDanhMuc.Location = new System.Drawing.Point(495, 6);
            this.txtTenDanhMuc.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtTenDanhMuc.Name = "txtTenDanhMuc";
            this.txtTenDanhMuc.Size = new System.Drawing.Size(232, 20);
            this.txtTenDanhMuc.TabIndex = 38;
            this.txtTenDanhMuc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenDanhMuc_KeyPress);
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
            this.gcDanhSach.Location = new System.Drawing.Point(0, 106);
            this.gcDanhSach.MainView = this.gvDanhSach;
            this.gcDanhSach.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.gcDanhSach.Name = "gcDanhSach";
            this.gcDanhSach.Size = new System.Drawing.Size(766, 360);
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
            this.gvDanhSach.DetailHeight = 284;
            this.gvDanhSach.GridControl = this.gcDanhSach;
            this.gvDanhSach.Name = "gvDanhSach";
            this.gvDanhSach.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvDanhSach.OptionsSelection.CheckBoxSelectorColumnWidth = 26;
            this.gvDanhSach.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gvDanhSach.OptionsView.ColumnAutoWidth = false;
            this.gvDanhSach.OptionsView.RowAutoHeight = true;
            this.gvDanhSach.OptionsView.ShowAutoFilterRow = true;
            this.gvDanhSach.OptionsView.ShowGroupPanel = false;
            this.gvDanhSach.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvDanhSach_CellValueChanged);
            // 
            // ucGroupHeader2
            // 
            this.ucGroupHeader2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeader2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader2.ForeColor = System.Drawing.Color.Yellow;
            this.ucGroupHeader2.GroupCaption = "THÊM KHAY LƯU MẪU";
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
            this.ucGroupHeader1.GroupCaption = "DANH SÁCH KHAY LƯU MẪU";
            this.ucGroupHeader1.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader1.Location = new System.Drawing.Point(0, 86);
            this.ucGroupHeader1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.ucGroupHeader1.Name = "ucGroupHeader1";
            this.ucGroupHeader1.Size = new System.Drawing.Size(766, 20);
            this.ucGroupHeader1.TabIndex = 380;
            // 
            // ucDanhMucKhayLuuMau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gcDanhSach);
            this.Controls.Add(this.ucGroupHeader1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ucGroupHeader2);
            this.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.Name = "ucDanhMucKhayLuuMau";
            this.Size = new System.Drawing.Size(766, 466);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNgang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private TPH.Controls.TPHNormalButton btnLamMoi;
        private TPH.Controls.TPHNormalButton btnXoa;
        private TPH.Controls.TPHNormalButton btnThem;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraGrid.GridControl gcDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSach;
        private Common.Controls.ucGroupHeader ucGroupHeader2;
        private Common.Controls.ucGroupHeader ucGroupHeader1;
        private ucSearchLookupEditor_DanhSachTuLuuMau ucSearchLookupEditor_DanhSachTuLuuMau1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numDoc;
        private System.Windows.Forms.NumericUpDown numNgang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaDanhMuc;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtTenDanhMuc;
    }
}
