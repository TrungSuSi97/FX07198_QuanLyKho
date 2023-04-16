namespace TPH.LIS.Configuration.Controls
{
    partial class ucDanhMucBoPhan_Nhom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDanhMucBoPhan_Nhom));
            this.gcDanhMucBoPhan = new DevExpress.XtraGrid.GridControl();
            this.gvDanhMucBoPhan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLamMoiBoPhan = new TPH.Controls.TPHNormalButton();
            this.btnXoaBoPhan = new TPH.Controls.TPHNormalButton();
            this.txtMaBoPhan = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.txtTenBoPhan = new System.Windows.Forms.TextBox();
            this.btnThemBoPhan = new TPH.Controls.TPHNormalButton();
            this.gcDanhMucNhom = new DevExpress.XtraGrid.GridControl();
            this.gvDanhMucNhom = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ucGroupHeader3 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numThuTuInNhom = new System.Windows.Forms.NumericUpDown();
            this.btnLamMoiNhom = new TPH.Controls.TPHNormalButton();
            this.btnXoaNhom = new TPH.Controls.TPHNormalButton();
            this.btnThemNhom = new TPH.Controls.TPHNormalButton();
            this.cboBoPhan = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMaNhomCLS = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTenNhomCLS = new System.Windows.Forms.TextBox();
            this.customButton1 = new TPH.Controls.TPHNormalButton();
            this.customButton2 = new TPH.Controls.TPHNormalButton();
            this.customButton3 = new TPH.Controls.TPHNormalButton();
            this.customButton4 = new TPH.Controls.TPHNormalButton();
            this.ucGroupHeader1 = new TPH.LIS.Common.Controls.ucGroupHeader();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhMucBoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhMucBoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhMucNhom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhMucNhom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThuTuInNhom)).BeginInit();
            this.SuspendLayout();
            // 
            // gcDanhMucBoPhan
            // 
            this.gcDanhMucBoPhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhMucBoPhan.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.gcDanhMucBoPhan.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gcDanhMucBoPhan.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcDanhMucBoPhan.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcDanhMucBoPhan.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcDanhMucBoPhan.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcDanhMucBoPhan.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcDanhMucBoPhan.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0);
            this.gcDanhMucBoPhan.EmbeddedNavigator.TextStringFormat = "{0} of {1}";
            this.gcDanhMucBoPhan.Location = new System.Drawing.Point(197, 23);
            this.gcDanhMucBoPhan.MainView = this.gvDanhMucBoPhan;
            this.gcDanhMucBoPhan.Margin = new System.Windows.Forms.Padding(0);
            this.gcDanhMucBoPhan.Name = "gcDanhMucBoPhan";
            this.gcDanhMucBoPhan.Size = new System.Drawing.Size(598, 224);
            this.gcDanhMucBoPhan.TabIndex = 362;
            this.gcDanhMucBoPhan.UseEmbeddedNavigator = true;
            this.gcDanhMucBoPhan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhMucBoPhan,
            this.gridView1});
            this.gcDanhMucBoPhan.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gc_ProcessGridKey);
            // 
            // gvDanhMucBoPhan
            // 
            this.gvDanhMucBoPhan.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhMucBoPhan.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhMucBoPhan.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhMucBoPhan.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.DetailTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhMucBoPhan.Appearance.DetailTip.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.Empty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhMucBoPhan.Appearance.Empty.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.EvenRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhMucBoPhan.Appearance.EvenRow.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhMucBoPhan.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.FilterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhMucBoPhan.Appearance.FilterPanel.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.FixedLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhMucBoPhan.Appearance.FixedLine.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvDanhMucBoPhan.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhMucBoPhan.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvDanhMucBoPhan.Appearance.FocusedCell.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 10F);
            this.gvDanhMucBoPhan.Appearance.FocusedRow.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhMucBoPhan.Appearance.FooterPanel.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhMucBoPhan.Appearance.GroupButton.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.GroupFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhMucBoPhan.Appearance.GroupFooter.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.GroupPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhMucBoPhan.Appearance.GroupPanel.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.gvDanhMucBoPhan.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvDanhMucBoPhan.Appearance.GroupRow.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvDanhMucBoPhan.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.gvDanhMucBoPhan.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhMucBoPhan.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhMucBoPhan.Appearance.HorzLine.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhMucBoPhan.Appearance.OddRow.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhMucBoPhan.Appearance.Preview.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.Row.Font = new System.Drawing.Font("Arial", 10F);
            this.gvDanhMucBoPhan.Appearance.Row.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhMucBoPhan.Appearance.RowSeparator.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvDanhMucBoPhan.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhMucBoPhan.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvDanhMucBoPhan.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvDanhMucBoPhan.Appearance.SelectedRow.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvDanhMucBoPhan.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhMucBoPhan.Appearance.TopNewRow.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhMucBoPhan.Appearance.VertLine.Options.UseFont = true;
            this.gvDanhMucBoPhan.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhMucBoPhan.Appearance.ViewCaption.Options.UseFont = true;
            this.gvDanhMucBoPhan.DetailHeight = 284;
            this.gvDanhMucBoPhan.GridControl = this.gcDanhMucBoPhan;
            this.gvDanhMucBoPhan.Name = "gvDanhMucBoPhan";
            this.gvDanhMucBoPhan.OptionsSelection.CheckBoxSelectorColumnWidth = 26;
            this.gvDanhMucBoPhan.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gvDanhMucBoPhan.OptionsView.ColumnAutoWidth = false;
            this.gvDanhMucBoPhan.OptionsView.RowAutoHeight = true;
            this.gvDanhMucBoPhan.OptionsView.ShowAutoFilterRow = true;
            this.gvDanhMucBoPhan.OptionsView.ShowGroupPanel = false;
            this.gvDanhMucBoPhan.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvDanhMucBoPhan_CellValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 284;
            this.gridView1.GridControl = this.gcDanhMucBoPhan;
            this.gridView1.Name = "gridView1";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnLamMoiBoPhan);
            this.panel1.Controls.Add(this.btnXoaBoPhan);
            this.panel1.Controls.Add(this.txtMaBoPhan);
            this.panel1.Controls.Add(this.label30);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Controls.Add(this.txtTenBoPhan);
            this.panel1.Controls.Add(this.btnThemBoPhan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 224);
            this.panel1.TabIndex = 363;
            // 
            // btnLamMoiBoPhan
            // 
            this.btnLamMoiBoPhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLamMoiBoPhan.BackColorHover = System.Drawing.Color.Empty;
            this.btnLamMoiBoPhan.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLamMoiBoPhan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnLamMoiBoPhan.BorderRadius = 5;
            this.btnLamMoiBoPhan.BorderSize = 1;
            this.btnLamMoiBoPhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoiBoPhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiBoPhan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoiBoPhan.ForceColorHover = System.Drawing.Color.Empty;
            this.btnLamMoiBoPhan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLamMoiBoPhan.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoiBoPhan.Image")));
            this.btnLamMoiBoPhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLamMoiBoPhan.Location = new System.Drawing.Point(70, 181);
            this.btnLamMoiBoPhan.Margin = new System.Windows.Forms.Padding(0);
            this.btnLamMoiBoPhan.Name = "btnLamMoiBoPhan";
            this.btnLamMoiBoPhan.Size = new System.Drawing.Size(122, 38);
            this.btnLamMoiBoPhan.TabIndex = 36;
            this.btnLamMoiBoPhan.Text = "Làm mới     ";
            this.btnLamMoiBoPhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLamMoiBoPhan.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnLamMoiBoPhan.UseHightLight = true;
            this.btnLamMoiBoPhan.UseVisualStyleBackColor = false;
            this.btnLamMoiBoPhan.Click += new System.EventHandler(this.btnLamMoiBoPhan_Click);
            // 
            // btnXoaBoPhan
            // 
            this.btnXoaBoPhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXoaBoPhan.BackColorHover = System.Drawing.Color.Empty;
            this.btnXoaBoPhan.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXoaBoPhan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXoaBoPhan.BorderRadius = 5;
            this.btnXoaBoPhan.BorderSize = 1;
            this.btnXoaBoPhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaBoPhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaBoPhan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaBoPhan.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXoaBoPhan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnXoaBoPhan.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaBoPhan.Image")));
            this.btnXoaBoPhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaBoPhan.Location = new System.Drawing.Point(70, 135);
            this.btnXoaBoPhan.Margin = new System.Windows.Forms.Padding(0);
            this.btnXoaBoPhan.Name = "btnXoaBoPhan";
            this.btnXoaBoPhan.Size = new System.Drawing.Size(122, 38);
            this.btnXoaBoPhan.TabIndex = 35;
            this.btnXoaBoPhan.Text = "Xóa bộ phận ";
            this.btnXoaBoPhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaBoPhan.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnXoaBoPhan.UseHightLight = true;
            this.btnXoaBoPhan.UseVisualStyleBackColor = false;
            this.btnXoaBoPhan.Click += new System.EventHandler(this.btnXoaBoPhan_Click);
            // 
            // txtMaBoPhan
            // 
            this.txtMaBoPhan.Location = new System.Drawing.Point(4, 24);
            this.txtMaBoPhan.Margin = new System.Windows.Forms.Padding(0);
            this.txtMaBoPhan.Name = "txtMaBoPhan";
            this.txtMaBoPhan.Size = new System.Drawing.Size(186, 23);
            this.txtMaBoPhan.TabIndex = 23;
            this.txtMaBoPhan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaBoPhan_KeyPress);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(4, 9);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(82, 16);
            this.label30.TabIndex = 22;
            this.label30.Text = "Mã bộ phận";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(4, 46);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(88, 16);
            this.label32.TabIndex = 24;
            this.label32.Text = "Tên bộ phận";
            // 
            // txtTenBoPhan
            // 
            this.txtTenBoPhan.Location = new System.Drawing.Point(4, 62);
            this.txtTenBoPhan.Margin = new System.Windows.Forms.Padding(0);
            this.txtTenBoPhan.Name = "txtTenBoPhan";
            this.txtTenBoPhan.Size = new System.Drawing.Size(187, 23);
            this.txtTenBoPhan.TabIndex = 25;
            // 
            // btnThemBoPhan
            // 
            this.btnThemBoPhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThemBoPhan.BackColorHover = System.Drawing.Color.Empty;
            this.btnThemBoPhan.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThemBoPhan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThemBoPhan.BorderRadius = 5;
            this.btnThemBoPhan.BorderSize = 1;
            this.btnThemBoPhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemBoPhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemBoPhan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemBoPhan.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThemBoPhan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnThemBoPhan.Image = ((System.Drawing.Image)(resources.GetObject("btnThemBoPhan.Image")));
            this.btnThemBoPhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemBoPhan.Location = new System.Drawing.Point(70, 89);
            this.btnThemBoPhan.Margin = new System.Windows.Forms.Padding(0);
            this.btnThemBoPhan.Name = "btnThemBoPhan";
            this.btnThemBoPhan.Size = new System.Drawing.Size(122, 38);
            this.btnThemBoPhan.TabIndex = 21;
            this.btnThemBoPhan.Text = "Thêm bộ phận";
            this.btnThemBoPhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemBoPhan.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnThemBoPhan.UseHightLight = true;
            this.btnThemBoPhan.UseVisualStyleBackColor = false;
            this.btnThemBoPhan.Click += new System.EventHandler(this.btnThemBoPhan_Click);
            // 
            // gcDanhMucNhom
            // 
            this.gcDanhMucNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhMucNhom.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.gcDanhMucNhom.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gcDanhMucNhom.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcDanhMucNhom.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcDanhMucNhom.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcDanhMucNhom.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcDanhMucNhom.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcDanhMucNhom.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0);
            this.gcDanhMucNhom.EmbeddedNavigator.TextStringFormat = "{0} of {1}";
            this.gcDanhMucNhom.Location = new System.Drawing.Point(197, 23);
            this.gcDanhMucNhom.MainView = this.gvDanhMucNhom;
            this.gcDanhMucNhom.Margin = new System.Windows.Forms.Padding(0);
            this.gcDanhMucNhom.Name = "gcDanhMucNhom";
            this.gcDanhMucNhom.Size = new System.Drawing.Size(598, 283);
            this.gcDanhMucNhom.TabIndex = 365;
            this.gcDanhMucNhom.UseEmbeddedNavigator = true;
            this.gcDanhMucNhom.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhMucNhom,
            this.gridView2});
            this.gcDanhMucNhom.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gc_ProcessGridKey);
            // 
            // gvDanhMucNhom
            // 
            this.gvDanhMucNhom.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhMucNhom.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhMucNhom.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhMucNhom.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.DetailTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhMucNhom.Appearance.DetailTip.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.Empty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhMucNhom.Appearance.Empty.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.EvenRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhMucNhom.Appearance.EvenRow.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhMucNhom.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.FilterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhMucNhom.Appearance.FilterPanel.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.FixedLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhMucNhom.Appearance.FixedLine.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvDanhMucNhom.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhMucNhom.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvDanhMucNhom.Appearance.FocusedCell.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 10F);
            this.gvDanhMucNhom.Appearance.FocusedRow.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhMucNhom.Appearance.FooterPanel.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhMucNhom.Appearance.GroupButton.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.GroupFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhMucNhom.Appearance.GroupFooter.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.GroupPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhMucNhom.Appearance.GroupPanel.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.gvDanhMucNhom.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvDanhMucNhom.Appearance.GroupRow.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvDanhMucNhom.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.gvDanhMucNhom.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhMucNhom.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhMucNhom.Appearance.HorzLine.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhMucNhom.Appearance.OddRow.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhMucNhom.Appearance.Preview.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.Row.Font = new System.Drawing.Font("Arial", 10F);
            this.gvDanhMucNhom.Appearance.Row.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhMucNhom.Appearance.RowSeparator.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvDanhMucNhom.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhMucNhom.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvDanhMucNhom.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvDanhMucNhom.Appearance.SelectedRow.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvDanhMucNhom.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhMucNhom.Appearance.TopNewRow.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhMucNhom.Appearance.VertLine.Options.UseFont = true;
            this.gvDanhMucNhom.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhMucNhom.Appearance.ViewCaption.Options.UseFont = true;
            this.gvDanhMucNhom.DetailHeight = 284;
            this.gvDanhMucNhom.GridControl = this.gcDanhMucNhom;
            this.gvDanhMucNhom.Name = "gvDanhMucNhom";
            this.gvDanhMucNhom.OptionsSelection.CheckBoxSelectorColumnWidth = 26;
            this.gvDanhMucNhom.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gvDanhMucNhom.OptionsView.ColumnAutoWidth = false;
            this.gvDanhMucNhom.OptionsView.RowAutoHeight = true;
            this.gvDanhMucNhom.OptionsView.ShowAutoFilterRow = true;
            this.gvDanhMucNhom.OptionsView.ShowGroupPanel = false;
            this.gvDanhMucNhom.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvDanhMucNhom_CellValueChanged);
            // 
            // gridView2
            // 
            this.gridView2.DetailHeight = 284;
            this.gridView2.GridControl = this.gcDanhMucNhom;
            this.gridView2.Name = "gridView2";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.splitContainerControl1.Appearance.Options.UseFont = true;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.splitContainerControl1.Panel1.Appearance.Options.UseFont = true;
            this.splitContainerControl1.Panel1.Controls.Add(this.gcDanhMucBoPhan);
            this.splitContainerControl1.Panel1.Controls.Add(this.panel1);
            this.splitContainerControl1.Panel1.Controls.Add(this.ucGroupHeader3);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.splitContainerControl1.Panel2.Appearance.Options.UseFont = true;
            this.splitContainerControl1.Panel2.Controls.Add(this.gcDanhMucNhom);
            this.splitContainerControl1.Panel2.Controls.Add(this.panel2);
            this.splitContainerControl1.Panel2.Controls.Add(this.ucGroupHeader1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(795, 563);
            this.splitContainerControl1.SplitterPosition = 247;
            this.splitContainerControl1.TabIndex = 366;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // ucGroupHeader3
            // 
            this.ucGroupHeader3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeader3.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader3.ForeColor = System.Drawing.Color.Yellow;
            this.ucGroupHeader3.GroupCaption = "DANH MỤC BỘ PHẬN";
            this.ucGroupHeader3.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader3.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeader3.Margin = new System.Windows.Forms.Padding(0);
            this.ucGroupHeader3.MaximumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader3.MinimumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader3.Name = "ucGroupHeader3";
            this.ucGroupHeader3.Size = new System.Drawing.Size(795, 23);
            this.ucGroupHeader3.TabIndex = 370;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.numThuTuInNhom);
            this.panel2.Controls.Add(this.btnLamMoiNhom);
            this.panel2.Controls.Add(this.btnXoaNhom);
            this.panel2.Controls.Add(this.btnThemNhom);
            this.panel2.Controls.Add(this.cboBoPhan);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtMaNhomCLS);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtTenNhomCLS);
            this.panel2.Controls.Add(this.customButton1);
            this.panel2.Controls.Add(this.customButton2);
            this.panel2.Controls.Add(this.customButton3);
            this.panel2.Controls.Add(this.customButton4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(197, 283);
            this.panel2.TabIndex = 365;
            // 
            // numThuTuInNhom
            // 
            this.numThuTuInNhom.Location = new System.Drawing.Point(70, 73);
            this.numThuTuInNhom.Margin = new System.Windows.Forms.Padding(0);
            this.numThuTuInNhom.Name = "numThuTuInNhom";
            this.numThuTuInNhom.Size = new System.Drawing.Size(64, 23);
            this.numThuTuInNhom.TabIndex = 366;
            // 
            // btnLamMoiNhom
            // 
            this.btnLamMoiNhom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLamMoiNhom.BackColorHover = System.Drawing.Color.Empty;
            this.btnLamMoiNhom.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLamMoiNhom.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnLamMoiNhom.BorderRadius = 5;
            this.btnLamMoiNhom.BorderSize = 1;
            this.btnLamMoiNhom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoiNhom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiNhom.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoiNhom.ForceColorHover = System.Drawing.Color.Empty;
            this.btnLamMoiNhom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLamMoiNhom.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoiNhom.Image")));
            this.btnLamMoiNhom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLamMoiNhom.Location = new System.Drawing.Point(69, 241);
            this.btnLamMoiNhom.Margin = new System.Windows.Forms.Padding(0);
            this.btnLamMoiNhom.Name = "btnLamMoiNhom";
            this.btnLamMoiNhom.Size = new System.Drawing.Size(122, 38);
            this.btnLamMoiNhom.TabIndex = 43;
            this.btnLamMoiNhom.Text = "Làm mới      ";
            this.btnLamMoiNhom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLamMoiNhom.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnLamMoiNhom.UseHightLight = true;
            this.btnLamMoiNhom.UseVisualStyleBackColor = false;
            this.btnLamMoiNhom.Click += new System.EventHandler(this.btnLamMoiNhom_Click);
            // 
            // btnXoaNhom
            // 
            this.btnXoaNhom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXoaNhom.BackColorHover = System.Drawing.Color.Empty;
            this.btnXoaNhom.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXoaNhom.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXoaNhom.BorderRadius = 5;
            this.btnXoaNhom.BorderSize = 1;
            this.btnXoaNhom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaNhom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaNhom.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaNhom.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXoaNhom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnXoaNhom.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaNhom.Image")));
            this.btnXoaNhom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaNhom.Location = new System.Drawing.Point(69, 195);
            this.btnXoaNhom.Margin = new System.Windows.Forms.Padding(0);
            this.btnXoaNhom.Name = "btnXoaNhom";
            this.btnXoaNhom.Size = new System.Drawing.Size(122, 38);
            this.btnXoaNhom.TabIndex = 42;
            this.btnXoaNhom.Text = "Xóa nhóm    ";
            this.btnXoaNhom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaNhom.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnXoaNhom.UseHightLight = true;
            this.btnXoaNhom.UseVisualStyleBackColor = false;
            this.btnXoaNhom.Click += new System.EventHandler(this.btnXoaNhom_Click);
            // 
            // btnThemNhom
            // 
            this.btnThemNhom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThemNhom.BackColorHover = System.Drawing.Color.Empty;
            this.btnThemNhom.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThemNhom.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThemNhom.BorderRadius = 5;
            this.btnThemNhom.BorderSize = 1;
            this.btnThemNhom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemNhom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemNhom.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNhom.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThemNhom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnThemNhom.Image = ((System.Drawing.Image)(resources.GetObject("btnThemNhom.Image")));
            this.btnThemNhom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemNhom.Location = new System.Drawing.Point(69, 149);
            this.btnThemNhom.Margin = new System.Windows.Forms.Padding(0);
            this.btnThemNhom.Name = "btnThemNhom";
            this.btnThemNhom.Size = new System.Drawing.Size(122, 38);
            this.btnThemNhom.TabIndex = 41;
            this.btnThemNhom.Text = "Thêm nhóm  ";
            this.btnThemNhom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemNhom.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnThemNhom.UseHightLight = true;
            this.btnThemNhom.UseVisualStyleBackColor = false;
            this.btnThemNhom.Click += new System.EventHandler(this.btnThemNhom_Click);
            // 
            // cboBoPhan
            // 
            this.cboBoPhan.FormattingEnabled = true;
            this.cboBoPhan.Location = new System.Drawing.Point(70, 7);
            this.cboBoPhan.Margin = new System.Windows.Forms.Padding(0);
            this.cboBoPhan.Name = "cboBoPhan";
            this.cboBoPhan.Size = new System.Drawing.Size(122, 24);
            this.cboBoPhan.TabIndex = 40;
            this.cboBoPhan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboBoPhan_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 16);
            this.label14.TabIndex = 39;
            this.label14.Text = "Bộ phận";
            // 
            // txtMaNhomCLS
            // 
            this.txtMaNhomCLS.Location = new System.Drawing.Point(70, 41);
            this.txtMaNhomCLS.Margin = new System.Windows.Forms.Padding(0);
            this.txtMaNhomCLS.Name = "txtMaNhomCLS";
            this.txtMaNhomCLS.Size = new System.Drawing.Size(122, 23);
            this.txtMaNhomCLS.TabIndex = 34;
            this.txtMaNhomCLS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaNhomCLS_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 33;
            this.label6.Text = "Mã nhóm";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 75);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(58, 16);
            this.label20.TabIndex = 38;
            this.label20.Text = "Sắp xếp";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 16);
            this.label7.TabIndex = 35;
            this.label7.Text = "Tên nhóm";
            // 
            // txtTenNhomCLS
            // 
            this.txtTenNhomCLS.Location = new System.Drawing.Point(3, 122);
            this.txtTenNhomCLS.Margin = new System.Windows.Forms.Padding(0);
            this.txtTenNhomCLS.Name = "txtTenNhomCLS";
            this.txtTenNhomCLS.Size = new System.Drawing.Size(189, 23);
            this.txtTenNhomCLS.TabIndex = 36;
            this.txtTenNhomCLS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenNhomCLS_KeyPress);
            // 
            // customButton1
            // 
            this.customButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.customButton1.BackColorHover = System.Drawing.Color.Empty;
            this.customButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.customButton1.BorderColor = System.Drawing.Color.DarkGray;
            this.customButton1.BorderRadius = 5;
            this.customButton1.BorderSize = 1;
            this.customButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.customButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customButton1.ForceColorHover = System.Drawing.Color.Empty;
            this.customButton1.ForeColor = System.Drawing.Color.Black;
            this.customButton1.Location = new System.Drawing.Point(-348, 128);
            this.customButton1.Margin = new System.Windows.Forms.Padding(0);
            this.customButton1.Name = "customButton1";
            this.customButton1.Size = new System.Drawing.Size(33, 22);
            this.customButton1.TabIndex = 32;
            this.customButton1.Text = "-";
            this.customButton1.TextColor = System.Drawing.Color.Black;
            this.customButton1.UseHightLight = true;
            this.customButton1.UseVisualStyleBackColor = false;
            // 
            // customButton2
            // 
            this.customButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.customButton2.BackColorHover = System.Drawing.Color.Empty;
            this.customButton2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.customButton2.BorderColor = System.Drawing.Color.DarkGray;
            this.customButton2.BorderRadius = 5;
            this.customButton2.BorderSize = 1;
            this.customButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.customButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customButton2.ForceColorHover = System.Drawing.Color.Empty;
            this.customButton2.ForeColor = System.Drawing.Color.Black;
            this.customButton2.Location = new System.Drawing.Point(-348, 102);
            this.customButton2.Margin = new System.Windows.Forms.Padding(0);
            this.customButton2.Name = "customButton2";
            this.customButton2.Size = new System.Drawing.Size(33, 22);
            this.customButton2.TabIndex = 31;
            this.customButton2.Text = "+";
            this.customButton2.TextColor = System.Drawing.Color.Black;
            this.customButton2.UseHightLight = true;
            this.customButton2.UseVisualStyleBackColor = false;
            // 
            // customButton3
            // 
            this.customButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.customButton3.BackColorHover = System.Drawing.Color.Empty;
            this.customButton3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.customButton3.BorderColor = System.Drawing.Color.DarkGray;
            this.customButton3.BorderRadius = 5;
            this.customButton3.BorderSize = 1;
            this.customButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.customButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customButton3.ForceColorHover = System.Drawing.Color.Empty;
            this.customButton3.ForeColor = System.Drawing.Color.Black;
            this.customButton3.Location = new System.Drawing.Point(-477, 128);
            this.customButton3.Margin = new System.Windows.Forms.Padding(0);
            this.customButton3.Name = "customButton3";
            this.customButton3.Size = new System.Drawing.Size(33, 22);
            this.customButton3.TabIndex = 29;
            this.customButton3.Text = "-";
            this.customButton3.TextColor = System.Drawing.Color.Black;
            this.customButton3.UseHightLight = true;
            this.customButton3.UseVisualStyleBackColor = false;
            // 
            // customButton4
            // 
            this.customButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.customButton4.BackColorHover = System.Drawing.Color.Empty;
            this.customButton4.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.customButton4.BorderColor = System.Drawing.Color.DarkGray;
            this.customButton4.BorderRadius = 5;
            this.customButton4.BorderSize = 1;
            this.customButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.customButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customButton4.ForceColorHover = System.Drawing.Color.Empty;
            this.customButton4.ForeColor = System.Drawing.Color.Black;
            this.customButton4.Location = new System.Drawing.Point(-477, 102);
            this.customButton4.Margin = new System.Windows.Forms.Padding(0);
            this.customButton4.Name = "customButton4";
            this.customButton4.Size = new System.Drawing.Size(33, 22);
            this.customButton4.TabIndex = 28;
            this.customButton4.Text = "+";
            this.customButton4.TextColor = System.Drawing.Color.Black;
            this.customButton4.UseHightLight = true;
            this.customButton4.UseVisualStyleBackColor = false;
            // 
            // ucGroupHeader1
            // 
            this.ucGroupHeader1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader1.ForeColor = System.Drawing.Color.Yellow;
            this.ucGroupHeader1.GroupCaption = "DANH MỤC NHÓM";
            this.ucGroupHeader1.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader1.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeader1.Margin = new System.Windows.Forms.Padding(0);
            this.ucGroupHeader1.MaximumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader1.MinimumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader1.Name = "ucGroupHeader1";
            this.ucGroupHeader1.Size = new System.Drawing.Size(795, 23);
            this.ucGroupHeader1.TabIndex = 371;
            // 
            // ucDanhMucBoPhan_Nhom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.splitContainerControl1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucDanhMucBoPhan_Nhom";
            this.Size = new System.Drawing.Size(795, 563);
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhMucBoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhMucBoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhMucNhom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhMucNhom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThuTuInNhom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gcDanhMucBoPhan;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhMucBoPhan;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMaBoPhan;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtTenBoPhan;
        private TPH.Controls.TPHNormalButton btnThemBoPhan;
        private DevExpress.XtraGrid.GridControl gcDanhMucNhom;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhMucNhom;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.Panel panel2;
        private TPH.Controls.TPHNormalButton customButton1;
        private TPH.Controls.TPHNormalButton customButton2;
        private TPH.Controls.TPHNormalButton customButton3;
        private TPH.Controls.TPHNormalButton customButton4;
        private System.Windows.Forms.ComboBox cboBoPhan;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMaNhomCLS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTenNhomCLS;
        private TPH.Controls.TPHNormalButton btnLamMoiBoPhan;
        private TPH.Controls.TPHNormalButton btnXoaBoPhan;
        private TPH.Controls.TPHNormalButton btnLamMoiNhom;
        private TPH.Controls.TPHNormalButton btnXoaNhom;
        private TPH.Controls.TPHNormalButton btnThemNhom;
        private System.Windows.Forms.NumericUpDown numThuTuInNhom;
        private Common.Controls.ucGroupHeader ucGroupHeader3;
        private Common.Controls.ucGroupHeader ucGroupHeader1;
    }
}
