namespace TPH.LIS.Analyzer.Controls
{
    partial class ucLuoiKetQuaMay
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLuoiKetQuaMay));
            this.gcAnalyzerResult = new DevExpress.XtraGrid.GridControl();
            this.gvAnalyzerResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSeq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDList = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblMayXN = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoadDanhSach = new TPH.Controls.TPHNormalButton();
            this.btnXoaDongDangChon = new TPH.Controls.TPHNormalButton();
            this.btnCancel = new TPH.Controls.TPHNormalButton();
            this.btnSave = new TPH.Controls.TPHNormalButton();
            this.bvAnalyzerResult = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lblAutorefresh = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.timerAutorefresh = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gcAnalyzerResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAnalyzerResult)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bvAnalyzerResult)).BeginInit();
            this.bvAnalyzerResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcAnalyzerResult
            // 
            this.gcAnalyzerResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAnalyzerResult.Location = new System.Drawing.Point(0, 55);
            this.gcAnalyzerResult.MainView = this.gvAnalyzerResult;
            this.gcAnalyzerResult.Name = "gcAnalyzerResult";
            this.gcAnalyzerResult.Size = new System.Drawing.Size(763, 253);
            this.gcAnalyzerResult.TabIndex = 3;
            this.gcAnalyzerResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAnalyzerResult});
            // 
            // gvAnalyzerResult
            // 
            this.gvAnalyzerResult.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvAnalyzerResult.Appearance.EvenRow.Options.UseFont = true;
            this.gvAnalyzerResult.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.gvAnalyzerResult.Appearance.FilterPanel.Options.UseFont = true;
            this.gvAnalyzerResult.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvAnalyzerResult.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.gvAnalyzerResult.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvAnalyzerResult.Appearance.FocusedCell.Options.UseFont = true;
            this.gvAnalyzerResult.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.gvAnalyzerResult.Appearance.FocusedRow.Options.UseFont = true;
            this.gvAnalyzerResult.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvAnalyzerResult.Appearance.FooterPanel.Options.UseFont = true;
            this.gvAnalyzerResult.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9F);
            this.gvAnalyzerResult.Appearance.GroupButton.Options.UseFont = true;
            this.gvAnalyzerResult.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvAnalyzerResult.Appearance.GroupFooter.Options.UseFont = true;
            this.gvAnalyzerResult.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.gvAnalyzerResult.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvAnalyzerResult.Appearance.GroupRow.Options.UseFont = true;
            this.gvAnalyzerResult.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvAnalyzerResult.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.gvAnalyzerResult.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvAnalyzerResult.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F);
            this.gvAnalyzerResult.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvAnalyzerResult.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvAnalyzerResult.Appearance.HorzLine.Options.UseFont = true;
            this.gvAnalyzerResult.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvAnalyzerResult.Appearance.OddRow.Options.UseFont = true;
            this.gvAnalyzerResult.Appearance.Preview.Font = new System.Drawing.Font("Arial", 12F);
            this.gvAnalyzerResult.Appearance.Preview.Options.UseFont = true;
            this.gvAnalyzerResult.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.gvAnalyzerResult.Appearance.Row.Options.UseFont = true;
            this.gvAnalyzerResult.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.gvAnalyzerResult.Appearance.RowSeparator.Options.UseFont = true;
            this.gvAnalyzerResult.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvAnalyzerResult.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.gvAnalyzerResult.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvAnalyzerResult.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvAnalyzerResult.Appearance.SelectedRow.Options.UseFont = true;
            this.gvAnalyzerResult.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvAnalyzerResult.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvAnalyzerResult.Appearance.TopNewRow.Options.UseFont = true;
            this.gvAnalyzerResult.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvAnalyzerResult.Appearance.VertLine.Options.UseFont = true;
            this.gvAnalyzerResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSID,
            this.colSeq,
            this.colnum,
            this.colIDList});
            this.gvAnalyzerResult.DetailHeight = 284;
            this.gvAnalyzerResult.GridControl = this.gcAnalyzerResult;
            this.gvAnalyzerResult.Name = "gvAnalyzerResult";
            this.gvAnalyzerResult.OptionsCustomization.AllowSort = false;
            this.gvAnalyzerResult.OptionsView.ColumnAutoWidth = false;
            this.gvAnalyzerResult.OptionsView.ShowGroupPanel = false;
            this.gvAnalyzerResult.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colnum, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvAnalyzerResult.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gvAnalyzerResult_SelectionChanged);
            this.gvAnalyzerResult.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvAnalyzerResult_FocusedRowChanged);
            this.gvAnalyzerResult.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gvAnalyzerResult_FocusedColumnChanged);
            // 
            // colSID
            // 
            this.colSID.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.colSID.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.colSID.AppearanceCell.Options.UseFont = true;
            this.colSID.AppearanceCell.Options.UseForeColor = true;
            this.colSID.AppearanceCell.Options.UseTextOptions = true;
            this.colSID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSID.AppearanceHeader.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.colSID.AppearanceHeader.Options.UseFont = true;
            this.colSID.AppearanceHeader.Options.UseTextOptions = true;
            this.colSID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSID.Caption = "Barcode";
            this.colSID.FieldName = "sid";
            this.colSID.MinWidth = 17;
            this.colSID.Name = "colSID";
            this.colSID.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colSID.Visible = true;
            this.colSID.VisibleIndex = 0;
            this.colSID.Width = 132;
            // 
            // colSeq
            // 
            this.colSeq.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.colSeq.AppearanceCell.Options.UseFont = true;
            this.colSeq.AppearanceCell.Options.UseTextOptions = true;
            this.colSeq.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSeq.AppearanceHeader.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.colSeq.AppearanceHeader.Options.UseFont = true;
            this.colSeq.AppearanceHeader.Options.UseTextOptions = true;
            this.colSeq.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSeq.Caption = "Seq";
            this.colSeq.FieldName = "seq";
            this.colSeq.MinWidth = 17;
            this.colSeq.Name = "colSeq";
            this.colSeq.OptionsColumn.AllowEdit = false;
            this.colSeq.OptionsColumn.ReadOnly = true;
            this.colSeq.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colSeq.Visible = true;
            this.colSeq.VisibleIndex = 1;
            this.colSeq.Width = 72;
            // 
            // colnum
            // 
            this.colnum.Caption = "Num";
            this.colnum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colnum.FieldName = "num";
            this.colnum.MinWidth = 17;
            this.colnum.Name = "colnum";
            this.colnum.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.colnum.Width = 64;
            // 
            // colIDList
            // 
            this.colIDList.Caption = "ID list";
            this.colIDList.FieldName = "idlist";
            this.colIDList.MinWidth = 17;
            this.colIDList.Name = "colIDList";
            this.colIDList.OptionsColumn.AllowEdit = false;
            this.colIDList.Width = 64;
            // 
            // lblMayXN
            // 
            this.lblMayXN.BackColor = System.Drawing.Color.Silver;
            this.lblMayXN.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMayXN.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMayXN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblMayXN.Location = new System.Drawing.Point(0, 0);
            this.lblMayXN.Name = "lblMayXN";
            this.lblMayXN.Size = new System.Drawing.Size(763, 23);
            this.lblMayXN.TabIndex = 4;
            this.lblMayXN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLoadDanhSach);
            this.panel1.Controls.Add(this.btnXoaDongDangChon);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 32);
            this.panel1.TabIndex = 6;
            // 
            // btnLoadDanhSach
            // 
            this.btnLoadDanhSach.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLoadDanhSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLoadDanhSach.BackColorHover = System.Drawing.Color.Empty;
            this.btnLoadDanhSach.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLoadDanhSach.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnLoadDanhSach.BorderRadius = 5;
            this.btnLoadDanhSach.BorderSize = 1;
            this.btnLoadDanhSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadDanhSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadDanhSach.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDanhSach.ForceColorHover = System.Drawing.Color.Empty;
            this.btnLoadDanhSach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnLoadDanhSach.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadDanhSach.Image")));
            this.btnLoadDanhSach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadDanhSach.Location = new System.Drawing.Point(92, 2);
            this.btnLoadDanhSach.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnLoadDanhSach.Name = "btnLoadDanhSach";
            this.btnLoadDanhSach.Size = new System.Drawing.Size(104, 28);
            this.btnLoadDanhSach.TabIndex = 8;
            this.btnLoadDanhSach.Text = "Làm mới";
            this.btnLoadDanhSach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoadDanhSach.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnLoadDanhSach.UseHightLight = true;
            this.btnLoadDanhSach.UseVisualStyleBackColor = false;
            this.btnLoadDanhSach.Click += new System.EventHandler(this.btnLoadDanhSach_Click);
            // 
            // btnXoaDongDangChon
            // 
            this.btnXoaDongDangChon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXoaDongDangChon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXoaDongDangChon.BackColorHover = System.Drawing.Color.Empty;
            this.btnXoaDongDangChon.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXoaDongDangChon.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXoaDongDangChon.BorderRadius = 5;
            this.btnXoaDongDangChon.BorderSize = 1;
            this.btnXoaDongDangChon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaDongDangChon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDongDangChon.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaDongDangChon.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXoaDongDangChon.ForeColor = System.Drawing.Color.Red;
            this.btnXoaDongDangChon.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaDongDangChon.Image")));
            this.btnXoaDongDangChon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaDongDangChon.Location = new System.Drawing.Point(203, 2);
            this.btnXoaDongDangChon.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnXoaDongDangChon.Name = "btnXoaDongDangChon";
            this.btnXoaDongDangChon.Size = new System.Drawing.Size(163, 28);
            this.btnXoaDongDangChon.TabIndex = 7;
            this.btnXoaDongDangChon.Text = "Xóa dòng đang chọn";
            this.btnXoaDongDangChon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaDongDangChon.TextColor = System.Drawing.Color.Red;
            this.btnXoaDongDangChon.UseHightLight = true;
            this.btnXoaDongDangChon.UseVisualStyleBackColor = false;
            this.btnXoaDongDangChon.Click += new System.EventHandler(this.btnXoaDongDangChon_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnCancel.BackColorHover = System.Drawing.Color.Empty;
            this.btnCancel.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.BorderSize = 1;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForceColorHover = System.Drawing.Color.Empty;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(372, 2);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(155, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Xóa tất cả dòng";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.UseHightLight = true;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnSave.BackColorHover = System.Drawing.Color.Empty;
            this.btnSave.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnSave.BorderRadius = 5;
            this.btnSave.BorderSize = 1;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForceColorHover = System.Drawing.Color.Empty;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(533, 2);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(138, 28);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Lưu kết quả";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSave.UseHightLight = true;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // bvAnalyzerResult
            // 
            this.bvAnalyzerResult.AddNewItem = null;
            this.bvAnalyzerResult.CountItem = this.bindingNavigatorCountItem;
            this.bvAnalyzerResult.DeleteItem = null;
            this.bvAnalyzerResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvAnalyzerResult.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.bvAnalyzerResult.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bvAnalyzerResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.toolStripLabel1,
            this.lblAutorefresh,
            this.toolStripLabel2});
            this.bvAnalyzerResult.Location = new System.Drawing.Point(0, 308);
            this.bvAnalyzerResult.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bvAnalyzerResult.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bvAnalyzerResult.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bvAnalyzerResult.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bvAnalyzerResult.Name = "bvAnalyzerResult";
            this.bvAnalyzerResult.PositionItem = this.bindingNavigatorPositionItem;
            this.bvAnalyzerResult.Size = new System.Drawing.Size(763, 27);
            this.bvAnalyzerResult.TabIndex = 7;
            this.bvAnalyzerResult.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(44, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(43, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(117, 24);
            this.toolStripLabel1.Text = "Tự làm mới sau:";
            // 
            // lblAutorefresh
            // 
            this.lblAutorefresh.ForeColor = System.Drawing.Color.Crimson;
            this.lblAutorefresh.Name = "lblAutorefresh";
            this.lblAutorefresh.Size = new System.Drawing.Size(0, 24);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(16, 24);
            this.toolStripLabel2.Text = "s";
            // 
            // timerAutorefresh
            // 
            this.timerAutorefresh.Enabled = true;
            this.timerAutorefresh.Interval = 1000;
            this.timerAutorefresh.Tick += new System.EventHandler(this.timerAutorefresh_Tick);
            // 
            // ucLuoiKetQuaMay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gcAnalyzerResult);
            this.Controls.Add(this.bvAnalyzerResult);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblMayXN);
            this.Name = "ucLuoiKetQuaMay";
            this.Size = new System.Drawing.Size(763, 335);
            ((System.ComponentModel.ISupportInitialize)(this.gcAnalyzerResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAnalyzerResult)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bvAnalyzerResult)).EndInit();
            this.bvAnalyzerResult.ResumeLayout(false);
            this.bvAnalyzerResult.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcAnalyzerResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAnalyzerResult;
        private DevExpress.XtraGrid.Columns.GridColumn colSID;
        private DevExpress.XtraGrid.Columns.GridColumn colSeq;
        private DevExpress.XtraGrid.Columns.GridColumn colnum;
        private System.Windows.Forms.Label lblMayXN;
        private System.Windows.Forms.Panel panel1;
        private TPH.Controls.TPHNormalButton btnXoaDongDangChon;
        private TPH.Controls.TPHNormalButton btnCancel;
        private TPH.Controls.TPHNormalButton btnSave;
        private TPH.Controls.TPHNormalButton btnLoadDanhSach;
        private System.Windows.Forms.BindingNavigator bvAnalyzerResult;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private DevExpress.XtraGrid.Columns.GridColumn colIDList;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel lblAutorefresh;
        private System.Windows.Forms.Timer timerAutorefresh;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
    }
}
