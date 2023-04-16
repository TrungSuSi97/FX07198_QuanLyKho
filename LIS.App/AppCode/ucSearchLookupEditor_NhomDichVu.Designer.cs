namespace TPH.LIS.App.AppCode
{
    partial class ucSearchLookupEditor_NhomDichVu
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
            this.lueNhomChiDinh = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gvLueNhomDichVu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcLueMaNhomDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLueTenNhomDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lueNhomChiDinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLueNhomDichVu)).BeginInit();
            this.SuspendLayout();
            // 
            // lueNhomChiDinh
            // 
            this.lueNhomChiDinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lueNhomChiDinh.Location = new System.Drawing.Point(0, 0);
            this.lueNhomChiDinh.Name = "lueNhomChiDinh";
            this.lueNhomChiDinh.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lueNhomChiDinh.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject1.Options.UseFont = true;
            serializableAppearanceObject2.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject2.Options.UseFont = true;
            serializableAppearanceObject3.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject3.Options.UseFont = true;
            serializableAppearanceObject4.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject4.Options.UseFont = true;
            this.lueNhomChiDinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.lueNhomChiDinh.Properties.NullText = "";
            this.lueNhomChiDinh.Properties.PopupView = this.gvLueNhomDichVu;
            this.lueNhomChiDinh.Properties.Popup += new System.EventHandler(this.lueNhomChiDinh_Properties_Popup);
            this.lueNhomChiDinh.Properties.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lueNhomChiDinh_KeyPress);
            this.lueNhomChiDinh.Size = new System.Drawing.Size(127, 22);
            this.lueNhomChiDinh.TabIndex = 339;
            // 
            // gvLueNhomDichVu
            // 
            this.gvLueNhomDichVu.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.DetailTip.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.DetailTip.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.Empty.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.Empty.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.EvenRow.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.FilterPanel.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.FixedLine.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.FocusedCell.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.FocusedRow.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.FooterPanel.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.GroupButton.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.GroupFooter.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.GroupPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.GroupPanel.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.gvLueNhomDichVu.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvLueNhomDichVu.Appearance.GroupRow.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvLueNhomDichVu.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.HorzLine.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.OddRow.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.Preview.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.Row.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.Row.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.RowSeparator.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.SelectedRow.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.TopNewRow.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.VertLine.Options.UseFont = true;
            this.gvLueNhomDichVu.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueNhomDichVu.Appearance.ViewCaption.Options.UseFont = true;
            this.gvLueNhomDichVu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcLueMaNhomDichVu,
            this.gcLueTenNhomDichVu});
            this.gvLueNhomDichVu.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvLueNhomDichVu.Name = "gvLueNhomDichVu";
            this.gvLueNhomDichVu.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvLueNhomDichVu.OptionsView.ColumnAutoWidth = false;
            this.gvLueNhomDichVu.OptionsView.ShowGroupPanel = false;
            this.gvLueNhomDichVu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lueNhomChiDinh_KeyPress);
            // 
            // gcLueMaNhomDichVu
            // 
            this.gcLueMaNhomDichVu.Caption = "Mã nhóm chỉ định";
            this.gcLueMaNhomDichVu.FieldName = "manhomdichvu";
            this.gcLueMaNhomDichVu.Name = "gcLueMaNhomDichVu";
            this.gcLueMaNhomDichVu.Visible = true;
            this.gcLueMaNhomDichVu.VisibleIndex = 0;
            this.gcLueMaNhomDichVu.Width = 104;
            // 
            // gcLueTenNhomDichVu
            // 
            this.gcLueTenNhomDichVu.Caption = "Tên nhóm chỉ định";
            this.gcLueTenNhomDichVu.FieldName = "tennhomdichvu";
            this.gcLueTenNhomDichVu.Name = "gcLueTenNhomDichVu";
            this.gcLueTenNhomDichVu.Visible = true;
            this.gcLueTenNhomDichVu.VisibleIndex = 1;
            this.gcLueTenNhomDichVu.Width = 275;
            // 
            // ucSearchLookupEditor_NhomDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lueNhomChiDinh);
            this.Name = "ucSearchLookupEditor_NhomDichVu";
            this.Size = new System.Drawing.Size(127, 23);
            this.Enter += new System.EventHandler(this.ucDevLookupEditor_Enter);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ucDevLookupEditor_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.lueNhomChiDinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLueNhomDichVu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit lueNhomChiDinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLueNhomDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn gcLueMaNhomDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn gcLueTenNhomDichVu;
    }
}
