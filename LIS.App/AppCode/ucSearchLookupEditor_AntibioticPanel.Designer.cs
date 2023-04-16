namespace TPH.LIS.App.AppCode
{
    partial class ucSearchLookupEditor_AntibioticPanel
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lueAntibioticPanel = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gvLueAntibitocPanel = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcLueMaBoKhangSinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLueTenBoKhangSinh = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lueAntibioticPanel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLueAntibitocPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // lueAntibioticPanel
            // 
            this.lueAntibioticPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lueAntibioticPanel.Location = new System.Drawing.Point(0, 0);
            this.lueAntibioticPanel.Name = "lueAntibioticPanel";
            this.lueAntibioticPanel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lueAntibioticPanel.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject1.Options.UseFont = true;
            this.lueAntibioticPanel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lueAntibioticPanel.Properties.NullText = "";
            this.lueAntibioticPanel.Properties.View = this.gvLueAntibitocPanel;
            this.lueAntibioticPanel.Properties.Popup += new System.EventHandler(this.lueChiDinh_Properties_Popup);
            this.lueAntibioticPanel.Properties.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lueChiDinh_KeyPress);
            this.lueAntibioticPanel.Size = new System.Drawing.Size(127, 22);
            this.lueAntibioticPanel.TabIndex = 341;
            this.lueAntibioticPanel.EditValueChanged += new System.EventHandler(this.lueAntibioticPanel_EditValueChanged);
            this.lueAntibioticPanel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lueAntibioticPanel_KeyPress);
            // 
            // gvLueAntibitocPanel
            // 
            this.gvLueAntibitocPanel.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.DetailTip.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.DetailTip.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.Empty.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.Empty.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.EvenRow.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.FilterPanel.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.FixedLine.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.FocusedCell.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.FocusedRow.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.FooterPanel.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.GroupButton.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.GroupFooter.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.GroupPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.GroupPanel.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.gvLueAntibitocPanel.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvLueAntibitocPanel.Appearance.GroupRow.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvLueAntibitocPanel.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.HorzLine.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.OddRow.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.Preview.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.Row.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.Row.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.RowSeparator.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.SelectedRow.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.TopNewRow.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.VertLine.Options.UseFont = true;
            this.gvLueAntibitocPanel.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueAntibitocPanel.Appearance.ViewCaption.Options.UseFont = true;
            this.gvLueAntibitocPanel.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcLueMaBoKhangSinh,
            this.gcLueTenBoKhangSinh});
            this.gvLueAntibitocPanel.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvLueAntibitocPanel.Name = "gvLueAntibitocPanel";
            this.gvLueAntibitocPanel.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvLueAntibitocPanel.OptionsView.ColumnAutoWidth = false;
            this.gvLueAntibitocPanel.OptionsView.ShowGroupPanel = false;
            // 
            // gcLueMaBoKhangSinh
            // 
            this.gcLueMaBoKhangSinh.Caption = "Mã bộ kháng sinh";
            this.gcLueMaBoKhangSinh.FieldName = "mabokhangsinh";
            this.gcLueMaBoKhangSinh.Name = "gcLueMaBoKhangSinh";
            this.gcLueMaBoKhangSinh.Visible = true;
            this.gcLueMaBoKhangSinh.VisibleIndex = 0;
            this.gcLueMaBoKhangSinh.Width = 104;
            // 
            // gcLueTenBoKhangSinh
            // 
            this.gcLueTenBoKhangSinh.Caption = "Tên bộ kháng sinh";
            this.gcLueTenBoKhangSinh.FieldName = "tenbokhangsinh";
            this.gcLueTenBoKhangSinh.Name = "gcLueTenBoKhangSinh";
            this.gcLueTenBoKhangSinh.Visible = true;
            this.gcLueTenBoKhangSinh.VisibleIndex = 1;
            this.gcLueTenBoKhangSinh.Width = 301;
            // 
            // ucSearchLookupEditor_AntibioticPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lueAntibioticPanel);
            this.Name = "ucSearchLookupEditor_AntibioticPanel";
            this.Size = new System.Drawing.Size(127, 23);
            this.Enter += new System.EventHandler(this.ucDevLookupEditor_Enter);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ucDevLookupEditor_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.lueAntibioticPanel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLueAntibitocPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit lueAntibioticPanel;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLueAntibitocPanel;
        private DevExpress.XtraGrid.Columns.GridColumn gcLueMaBoKhangSinh;
        private DevExpress.XtraGrid.Columns.GridColumn gcLueTenBoKhangSinh;
    }
}
