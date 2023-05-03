namespace TPH.LIS.App.AppCode
{
    partial class ucSearchLookupEditor_Thang
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
            this.lueNhanVien = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gvBS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcLueMaBS = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lueNhanVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBS)).BeginInit();
            this.SuspendLayout();
            // 
            // lueNhanVien
            // 
            this.lueNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lueNhanVien.Location = new System.Drawing.Point(0, 0);
            this.lueNhanVien.Name = "lueNhanVien";
            this.lueNhanVien.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lueNhanVien.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject1.Options.UseFont = true;
            serializableAppearanceObject2.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject2.Options.UseFont = true;
            serializableAppearanceObject3.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject3.Options.UseFont = true;
            serializableAppearanceObject4.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject4.Options.UseFont = true;
            this.lueNhanVien.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.lueNhanVien.Properties.NullText = "";
            this.lueNhanVien.Properties.PopupView = this.gvBS;
            this.lueNhanVien.Properties.Popup += new System.EventHandler(this.lueBSChiDinh_Properties_Popup);
            this.lueNhanVien.Properties.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lueBSChiDinh_KeyPress);
            this.lueNhanVien.Size = new System.Drawing.Size(127, 22);
            this.lueNhanVien.TabIndex = 333;
            // 
            // gvBS
            // 
            this.gvBS.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvBS.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvBS.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvBS.Appearance.DetailTip.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.DetailTip.Options.UseFont = true;
            this.gvBS.Appearance.Empty.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.Empty.Options.UseFont = true;
            this.gvBS.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.EvenRow.Options.UseFont = true;
            this.gvBS.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvBS.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.FilterPanel.Options.UseFont = true;
            this.gvBS.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.FixedLine.Options.UseFont = true;
            this.gvBS.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.FocusedCell.Options.UseFont = true;
            this.gvBS.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.FocusedRow.Options.UseFont = true;
            this.gvBS.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.FooterPanel.Options.UseFont = true;
            this.gvBS.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.GroupButton.Options.UseFont = true;
            this.gvBS.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.GroupFooter.Options.UseFont = true;
            this.gvBS.Appearance.GroupPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.GroupPanel.Options.UseFont = true;
            this.gvBS.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.gvBS.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvBS.Appearance.GroupRow.Options.UseFont = true;
            this.gvBS.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvBS.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvBS.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvBS.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.HorzLine.Options.UseFont = true;
            this.gvBS.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.OddRow.Options.UseFont = true;
            this.gvBS.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.Preview.Options.UseFont = true;
            this.gvBS.Appearance.Row.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.Row.Options.UseFont = true;
            this.gvBS.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.RowSeparator.Options.UseFont = true;
            this.gvBS.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.SelectedRow.Options.UseFont = true;
            this.gvBS.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.TopNewRow.Options.UseFont = true;
            this.gvBS.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.VertLine.Options.UseFont = true;
            this.gvBS.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvBS.Appearance.ViewCaption.Options.UseFont = true;
            this.gvBS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcLueMaBS});
            this.gvBS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvBS.Name = "gvBS";
            this.gvBS.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvBS.OptionsView.ColumnAutoWidth = false;
            this.gvBS.OptionsView.ShowGroupPanel = false;
            // 
            // gcLueMaBS
            // 
            this.gcLueMaBS.Caption = "Tháng";
            this.gcLueMaBS.FieldName = "MaThang";
            this.gcLueMaBS.Name = "gcLueMaBS";
            this.gcLueMaBS.Visible = true;
            this.gcLueMaBS.VisibleIndex = 0;
            this.gcLueMaBS.Width = 104;
            // 
            // ucSearchLookupEditor_Thang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lueNhanVien);
            this.Name = "ucSearchLookupEditor_Thang";
            this.Size = new System.Drawing.Size(127, 23);
            this.Enter += new System.EventHandler(this.ucDevLookupEditor_Enter);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ucDevLookupEditor_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.lueNhanVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit lueNhanVien;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBS;
        private DevExpress.XtraGrid.Columns.GridColumn gcLueMaBS;
    }
}
