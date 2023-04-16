namespace TPH.LIS.App.AppCode
{
    partial class ucSearchLookupEditor_Location
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
            this.lueDonVi = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gvDonVi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcLueMaKhoaPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLueTenKhoaPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lueDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDonVi)).BeginInit();
            this.SuspendLayout();
            // 
            // lueDonVi
            // 
            this.lueDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lueDonVi.Location = new System.Drawing.Point(0, 0);
            this.lueDonVi.Name = "lueDonVi";
            this.lueDonVi.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lueDonVi.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject1.Options.UseFont = true;
            serializableAppearanceObject2.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject2.Options.UseFont = true;
            serializableAppearanceObject3.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject3.Options.UseFont = true;
            serializableAppearanceObject4.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject4.Options.UseFont = true;
            this.lueDonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.lueDonVi.Properties.NullText = "";
            this.lueDonVi.Properties.PopupView = this.gvDonVi;
            this.lueDonVi.Properties.Popup += new System.EventHandler(this.lueDonVi_Properties_Popup);
            this.lueDonVi.Size = new System.Drawing.Size(127, 22);
            this.lueDonVi.TabIndex = 332;
            this.lueDonVi.EditValueChanged += new System.EventHandler(this.lueDonVi_EditValueChanged);
            // 
            // gvDonVi
            // 
            this.gvDonVi.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvDonVi.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvDonVi.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvDonVi.Appearance.DetailTip.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.DetailTip.Options.UseFont = true;
            this.gvDonVi.Appearance.Empty.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.Empty.Options.UseFont = true;
            this.gvDonVi.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.EvenRow.Options.UseFont = true;
            this.gvDonVi.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvDonVi.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.FilterPanel.Options.UseFont = true;
            this.gvDonVi.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.FixedLine.Options.UseFont = true;
            this.gvDonVi.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.FocusedCell.Options.UseFont = true;
            this.gvDonVi.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.FocusedRow.Options.UseFont = true;
            this.gvDonVi.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.FooterPanel.Options.UseFont = true;
            this.gvDonVi.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.GroupButton.Options.UseFont = true;
            this.gvDonVi.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.GroupFooter.Options.UseFont = true;
            this.gvDonVi.Appearance.GroupPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.GroupPanel.Options.UseFont = true;
            this.gvDonVi.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.gvDonVi.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvDonVi.Appearance.GroupRow.Options.UseFont = true;
            this.gvDonVi.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvDonVi.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvDonVi.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvDonVi.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.HorzLine.Options.UseFont = true;
            this.gvDonVi.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.OddRow.Options.UseFont = true;
            this.gvDonVi.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.Preview.Options.UseFont = true;
            this.gvDonVi.Appearance.Row.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.Row.Options.UseFont = true;
            this.gvDonVi.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.RowSeparator.Options.UseFont = true;
            this.gvDonVi.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.SelectedRow.Options.UseFont = true;
            this.gvDonVi.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.TopNewRow.Options.UseFont = true;
            this.gvDonVi.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.VertLine.Options.UseFont = true;
            this.gvDonVi.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDonVi.Appearance.ViewCaption.Options.UseFont = true;
            this.gvDonVi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcLueMaKhoaPhong,
            this.gcLueTenKhoaPhong});
            this.gvDonVi.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvDonVi.Name = "gvDonVi";
            this.gvDonVi.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvDonVi.OptionsView.ColumnAutoWidth = false;
            this.gvDonVi.OptionsView.ShowGroupPanel = false;
            // 
            // gcLueMaKhoaPhong
            // 
            this.gcLueMaKhoaPhong.Caption = "Mã đơn vị";
            this.gcLueMaKhoaPhong.FieldName = "MaKhoaPhong";
            this.gcLueMaKhoaPhong.Name = "gcLueMaKhoaPhong";
            this.gcLueMaKhoaPhong.Visible = true;
            this.gcLueMaKhoaPhong.VisibleIndex = 0;
            this.gcLueMaKhoaPhong.Width = 104;
            // 
            // gcLueTenKhoaPhong
            // 
            this.gcLueTenKhoaPhong.Caption = "Tên đơn vị";
            this.gcLueTenKhoaPhong.FieldName = "TenKhoaPhong";
            this.gcLueTenKhoaPhong.Name = "gcLueTenKhoaPhong";
            this.gcLueTenKhoaPhong.Visible = true;
            this.gcLueTenKhoaPhong.VisibleIndex = 1;
            this.gcLueTenKhoaPhong.Width = 275;
            // 
            // ucSearchLookupEditor_Location
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lueDonVi);
            this.Name = "ucSearchLookupEditor_Location";
            this.Size = new System.Drawing.Size(127, 23);
            this.Enter += new System.EventHandler(this.ucDevLookupEditor_Enter);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ucDevLookupEditor_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.lueDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDonVi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit lueDonVi;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn gcLueMaKhoaPhong;
        private DevExpress.XtraGrid.Columns.GridColumn gcLueTenKhoaPhong;
    }
}
