namespace TPH.LIS.App.AppCode
{
    partial class ucSearchLookupEditor_District
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lueTinh = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gvTinh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcLueMaNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvLueTenTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLueIDTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lueTinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTinh)).BeginInit();
            this.SuspendLayout();
            // 
            // lueTinh
            // 
            this.lueTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lueTinh.Location = new System.Drawing.Point(0, 0);
            this.lueTinh.Name = "lueTinh";
            this.lueTinh.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lueTinh.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject1.Options.UseFont = true;
            serializableAppearanceObject2.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject2.Options.UseFont = true;
            serializableAppearanceObject3.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject3.Options.UseFont = true;
            serializableAppearanceObject4.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject4.Options.UseFont = true;
            this.lueTinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.lueTinh.Properties.NullText = "";
            this.lueTinh.Properties.PopupView = this.gvTinh;
            this.lueTinh.Properties.ShowFooter = false;
            this.lueTinh.Properties.Popup += new System.EventHandler(this.lueTinh_Properties_Popup);
            this.lueTinh.Properties.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lueTinh_KeyPress);
            this.lueTinh.Size = new System.Drawing.Size(127, 22);
            this.lueTinh.TabIndex = 334;
            // 
            // gvTinh
            // 
            this.gvTinh.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvTinh.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvTinh.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvTinh.Appearance.DetailTip.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.DetailTip.Options.UseFont = true;
            this.gvTinh.Appearance.Empty.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.Empty.Options.UseFont = true;
            this.gvTinh.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.EvenRow.Options.UseFont = true;
            this.gvTinh.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvTinh.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.FilterPanel.Options.UseFont = true;
            this.gvTinh.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.FixedLine.Options.UseFont = true;
            this.gvTinh.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.FocusedCell.Options.UseFont = true;
            this.gvTinh.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.FocusedRow.Options.UseFont = true;
            this.gvTinh.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.FooterPanel.Options.UseFont = true;
            this.gvTinh.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.GroupButton.Options.UseFont = true;
            this.gvTinh.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.GroupFooter.Options.UseFont = true;
            this.gvTinh.Appearance.GroupPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.GroupPanel.Options.UseFont = true;
            this.gvTinh.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.gvTinh.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvTinh.Appearance.GroupRow.Options.UseFont = true;
            this.gvTinh.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvTinh.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvTinh.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvTinh.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.HorzLine.Options.UseFont = true;
            this.gvTinh.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.OddRow.Options.UseFont = true;
            this.gvTinh.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.Preview.Options.UseFont = true;
            this.gvTinh.Appearance.Row.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.Row.Options.UseFont = true;
            this.gvTinh.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.RowSeparator.Options.UseFont = true;
            this.gvTinh.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.SelectedRow.Options.UseFont = true;
            this.gvTinh.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.TopNewRow.Options.UseFont = true;
            this.gvTinh.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.VertLine.Options.UseFont = true;
            this.gvTinh.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvTinh.Appearance.ViewCaption.Options.UseFont = true;
            this.gvTinh.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcLueMaNhap,
            this.gvLueTenTinh,
            this.gcLueIDTinh});
            this.gvTinh.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvTinh.Name = "gvTinh";
            this.gvTinh.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvTinh.OptionsView.ColumnAutoWidth = false;
            this.gvTinh.OptionsView.ShowGroupPanel = false;
            // 
            // gcLueMaNhap
            // 
            this.gcLueMaNhap.Caption = "Mã Quận/Huyện";
            this.gcLueMaNhap.FieldName = "MaNhap";
            this.gcLueMaNhap.Name = "gcLueMaNhap";
            this.gcLueMaNhap.Visible = true;
            this.gcLueMaNhap.VisibleIndex = 0;
            this.gcLueMaNhap.Width = 104;
            // 
            // gvLueTenTinh
            // 
            this.gvLueTenTinh.Caption = "Tên Quận/Huyện";
            this.gvLueTenTinh.FieldName = "QuanHuyen";
            this.gvLueTenTinh.Name = "gvLueTenTinh";
            this.gvLueTenTinh.Visible = true;
            this.gvLueTenTinh.VisibleIndex = 1;
            this.gvLueTenTinh.Width = 275;
            // 
            // gcLueIDTinh
            // 
            this.gcLueIDTinh.Caption = "ID";
            this.gcLueIDTinh.FieldName = "AutoID";
            this.gcLueIDTinh.Name = "gcLueIDTinh";
            this.gcLueIDTinh.Visible = true;
            this.gcLueIDTinh.VisibleIndex = 2;
            this.gcLueIDTinh.Width = 162;
            // 
            // ucSearchLookupEditor_District
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lueTinh);
            this.Name = "ucSearchLookupEditor_District";
            this.Size = new System.Drawing.Size(127, 23);
            this.Enter += new System.EventHandler(this.ucDevLookupEditor_Enter);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ucDevLookupEditor_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.lueTinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit lueTinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTinh;
        private DevExpress.XtraGrid.Columns.GridColumn gcLueMaNhap;
        private DevExpress.XtraGrid.Columns.GridColumn gvLueTenTinh;
        private DevExpress.XtraGrid.Columns.GridColumn gcLueIDTinh;
    }
}
