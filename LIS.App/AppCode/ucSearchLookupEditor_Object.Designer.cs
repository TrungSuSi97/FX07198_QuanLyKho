namespace TPH.LIS.App.AppCode
{
    partial class ucSearchLookupEditor_Object
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
            this.lueDoiTuong = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gvDoiTuong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcLueMaDoiTuongDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLueTenDoiTuongDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lueDoiTuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDoiTuong)).BeginInit();
            this.SuspendLayout();
            // 
            // lueDoiTuong
            // 
            this.lueDoiTuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lueDoiTuong.Location = new System.Drawing.Point(0, 0);
            this.lueDoiTuong.Name = "lueDoiTuong";
            this.lueDoiTuong.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lueDoiTuong.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject1.Options.UseFont = true;
            serializableAppearanceObject2.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject2.Options.UseFont = true;
            serializableAppearanceObject3.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject3.Options.UseFont = true;
            serializableAppearanceObject4.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject4.Options.UseFont = true;
            this.lueDoiTuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.lueDoiTuong.Properties.NullText = "";
            this.lueDoiTuong.Properties.PopupView = this.gvDoiTuong;
            this.lueDoiTuong.Properties.Popup += new System.EventHandler(this.lueDoiTuong_Properties_Popup);
            this.lueDoiTuong.Properties.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lueDoiTuong_KeyPress);
            this.lueDoiTuong.Size = new System.Drawing.Size(127, 22);
            this.lueDoiTuong.TabIndex = 336;
            // 
            // gvDoiTuong
            // 
            this.gvDoiTuong.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvDoiTuong.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvDoiTuong.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvDoiTuong.Appearance.DetailTip.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.DetailTip.Options.UseFont = true;
            this.gvDoiTuong.Appearance.Empty.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.Empty.Options.UseFont = true;
            this.gvDoiTuong.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.EvenRow.Options.UseFont = true;
            this.gvDoiTuong.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvDoiTuong.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.FilterPanel.Options.UseFont = true;
            this.gvDoiTuong.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.FixedLine.Options.UseFont = true;
            this.gvDoiTuong.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.FocusedCell.Options.UseFont = true;
            this.gvDoiTuong.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.FocusedRow.Options.UseFont = true;
            this.gvDoiTuong.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.FooterPanel.Options.UseFont = true;
            this.gvDoiTuong.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.GroupButton.Options.UseFont = true;
            this.gvDoiTuong.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.GroupFooter.Options.UseFont = true;
            this.gvDoiTuong.Appearance.GroupPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.GroupPanel.Options.UseFont = true;
            this.gvDoiTuong.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.gvDoiTuong.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvDoiTuong.Appearance.GroupRow.Options.UseFont = true;
            this.gvDoiTuong.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvDoiTuong.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvDoiTuong.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvDoiTuong.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.HorzLine.Options.UseFont = true;
            this.gvDoiTuong.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.OddRow.Options.UseFont = true;
            this.gvDoiTuong.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.Preview.Options.UseFont = true;
            this.gvDoiTuong.Appearance.Row.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.Row.Options.UseFont = true;
            this.gvDoiTuong.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.RowSeparator.Options.UseFont = true;
            this.gvDoiTuong.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.SelectedRow.Options.UseFont = true;
            this.gvDoiTuong.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.TopNewRow.Options.UseFont = true;
            this.gvDoiTuong.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.VertLine.Options.UseFont = true;
            this.gvDoiTuong.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDoiTuong.Appearance.ViewCaption.Options.UseFont = true;
            this.gvDoiTuong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcLueMaDoiTuongDichVu,
            this.gcLueTenDoiTuongDichVu});
            this.gvDoiTuong.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvDoiTuong.Name = "gvDoiTuong";
            this.gvDoiTuong.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvDoiTuong.OptionsView.ColumnAutoWidth = false;
            this.gvDoiTuong.OptionsView.ShowGroupPanel = false;
            // 
            // gcLueMaDoiTuongDichVu
            // 
            this.gcLueMaDoiTuongDichVu.Caption = "Mã đối tượng";
            this.gcLueMaDoiTuongDichVu.FieldName = "MaDoiTuongDichVu";
            this.gcLueMaDoiTuongDichVu.Name = "gcLueMaDoiTuongDichVu";
            this.gcLueMaDoiTuongDichVu.Visible = true;
            this.gcLueMaDoiTuongDichVu.VisibleIndex = 0;
            this.gcLueMaDoiTuongDichVu.Width = 104;
            // 
            // gcLueTenDoiTuongDichVu
            // 
            this.gcLueTenDoiTuongDichVu.Caption = "Tên đối tượng";
            this.gcLueTenDoiTuongDichVu.FieldName = "TenDoiTuongDichVu";
            this.gcLueTenDoiTuongDichVu.Name = "gcLueTenDoiTuongDichVu";
            this.gcLueTenDoiTuongDichVu.Visible = true;
            this.gcLueTenDoiTuongDichVu.VisibleIndex = 1;
            this.gcLueTenDoiTuongDichVu.Width = 275;
            // 
            // ucSearchLookupEditor_Object
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lueDoiTuong);
            this.Name = "ucSearchLookupEditor_Object";
            this.Size = new System.Drawing.Size(127, 23);
            this.Enter += new System.EventHandler(this.ucDevLookupEditor_Enter);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ucDevLookupEditor_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.lueDoiTuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDoiTuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SearchLookUpEdit lueDoiTuong;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDoiTuong;
        private DevExpress.XtraGrid.Columns.GridColumn gcLueMaDoiTuongDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn gcLueTenDoiTuongDichVu;
    }
}
