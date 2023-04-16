namespace TPH.LIS.Configuration.Controls
{
    partial class ucDanhSachNhom
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
            this.gcDanhSach = new DevExpress.XtraGrid.GridControl();
            this.gvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaNhomCLS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNhom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThuTuIn = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).BeginInit();
            this.SuspendLayout();
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
            this.gcDanhSach.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcDanhSach.EmbeddedNavigator.TextStringFormat = "{0} of {1}";
            this.gcDanhSach.Location = new System.Drawing.Point(0, 0);
            this.gcDanhSach.MainView = this.gvDanhSach;
            this.gcDanhSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcDanhSach.Name = "gcDanhSach";
            this.gcDanhSach.Size = new System.Drawing.Size(530, 227);
            this.gcDanhSach.TabIndex = 363;
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
            this.colMaNhomCLS,
            this.colTenNhom,
            this.colThuTuIn});
            this.gvDanhSach.DetailHeight = 284;
            this.gvDanhSach.GridControl = this.gcDanhSach;
            this.gvDanhSach.Name = "gvDanhSach";
            this.gvDanhSach.OptionsSelection.CheckBoxSelectorColumnWidth = 25;
            this.gvDanhSach.OptionsSelection.MultiSelect = true;
            this.gvDanhSach.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvDanhSach.OptionsView.ColumnAutoWidth = false;
            this.gvDanhSach.OptionsView.RowAutoHeight = true;
            this.gvDanhSach.OptionsView.ShowAutoFilterRow = true;
            this.gvDanhSach.OptionsView.ShowGroupPanel = false;
            this.gvDanhSach.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colThuTuIn, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvDanhSach.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvDanhSach_FocusedRowChanged);
            this.gvDanhSach.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gvDanhSach_FocusedColumnChanged);
            // 
            // colMaNhomCLS
            // 
            this.colMaNhomCLS.Caption = "Mã nhóm";
            this.colMaNhomCLS.FieldName = "manhomcls";
            this.colMaNhomCLS.MinWidth = 17;
            this.colMaNhomCLS.Name = "colMaNhomCLS";
            this.colMaNhomCLS.OptionsColumn.ReadOnly = true;
            this.colMaNhomCLS.Visible = true;
            this.colMaNhomCLS.VisibleIndex = 1;
            this.colMaNhomCLS.Width = 93;
            // 
            // colTenNhom
            // 
            this.colTenNhom.Caption = "Tên nhóm";
            this.colTenNhom.FieldName = "tennhomcls";
            this.colTenNhom.FieldNameSortGroup = "thutuin,SapXep";
            this.colTenNhom.MinWidth = 17;
            this.colTenNhom.Name = "colTenNhom";
            this.colTenNhom.OptionsColumn.AllowEdit = false;
            this.colTenNhom.OptionsColumn.ReadOnly = true;
            this.colTenNhom.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.colTenNhom.Visible = true;
            this.colTenNhom.VisibleIndex = 2;
            this.colTenNhom.Width = 347;
            // 
            // colThuTuIn
            // 
            this.colThuTuIn.Caption = "Thứ tự in";
            this.colThuTuIn.FieldName = "thutuin";
            this.colThuTuIn.MinWidth = 17;
            this.colThuTuIn.Name = "colThuTuIn";
            this.colThuTuIn.OptionsColumn.AllowEdit = false;
            this.colThuTuIn.OptionsColumn.ReadOnly = true;
            this.colThuTuIn.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.colThuTuIn.Width = 78;
            // 
            // ucDanhSachNhom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gcDanhSach);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucDanhSachNhom";
            this.Size = new System.Drawing.Size(530, 227);
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSach;
        private DevExpress.XtraGrid.Columns.GridColumn colMaNhomCLS;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNhom;
        private DevExpress.XtraGrid.Columns.GridColumn colThuTuIn;
    }
}
