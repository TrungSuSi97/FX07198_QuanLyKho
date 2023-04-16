namespace TPH.LIS.App.AppCode
{
    partial class ucSearchLookupEditor_Profile
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
            this.lueData = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcLueMa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLueTen = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lueData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            this.SuspendLayout();
            // 
            // lueData
            // 
            this.lueData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lueData.Location = new System.Drawing.Point(0, 0);
            this.lueData.Name = "lueData";
            this.lueData.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lueData.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject1.Options.UseFont = true;
            serializableAppearanceObject2.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject2.Options.UseFont = true;
            serializableAppearanceObject3.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject3.Options.UseFont = true;
            serializableAppearanceObject4.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject4.Options.UseFont = true;
            this.lueData.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.lueData.Properties.NullText = "";
            this.lueData.Properties.PopupView = this.gvData;
            this.lueData.Properties.Popup += new System.EventHandler(this.lueDoiTuong_Properties_Popup);
            this.lueData.Properties.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lueDoiTuong_KeyPress);
            this.lueData.Size = new System.Drawing.Size(127, 22);
            this.lueData.TabIndex = 336;
            // 
            // gvData
            // 
            this.gvData.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvData.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvData.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvData.Appearance.DetailTip.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.DetailTip.Options.UseFont = true;
            this.gvData.Appearance.Empty.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.Empty.Options.UseFont = true;
            this.gvData.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.EvenRow.Options.UseFont = true;
            this.gvData.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvData.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.FilterPanel.Options.UseFont = true;
            this.gvData.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.FixedLine.Options.UseFont = true;
            this.gvData.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.FocusedCell.Options.UseFont = true;
            this.gvData.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.FocusedRow.Options.UseFont = true;
            this.gvData.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.FooterPanel.Options.UseFont = true;
            this.gvData.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.GroupButton.Options.UseFont = true;
            this.gvData.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.GroupFooter.Options.UseFont = true;
            this.gvData.Appearance.GroupPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.GroupPanel.Options.UseFont = true;
            this.gvData.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.gvData.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvData.Appearance.GroupRow.Options.UseFont = true;
            this.gvData.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvData.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvData.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvData.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.HorzLine.Options.UseFont = true;
            this.gvData.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.OddRow.Options.UseFont = true;
            this.gvData.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.Preview.Options.UseFont = true;
            this.gvData.Appearance.Row.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.Row.Options.UseFont = true;
            this.gvData.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.RowSeparator.Options.UseFont = true;
            this.gvData.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.SelectedRow.Options.UseFont = true;
            this.gvData.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.TopNewRow.Options.UseFont = true;
            this.gvData.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.VertLine.Options.UseFont = true;
            this.gvData.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvData.Appearance.ViewCaption.Options.UseFont = true;
            this.gvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcLueMa,
            this.gcLueTen});
            this.gvData.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvData.Name = "gvData";
            this.gvData.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvData.OptionsView.ColumnAutoWidth = false;
            this.gvData.OptionsView.ShowGroupPanel = false;
            // 
            // gcLueMa
            // 
            this.gcLueMa.Caption = "ID";
            this.gcLueMa.FieldName = "profileid";
            this.gcLueMa.Name = "gcLueMa";
            this.gcLueMa.Visible = true;
            this.gcLueMa.VisibleIndex = 0;
            this.gcLueMa.Width = 104;
            // 
            // gcLueTen
            // 
            this.gcLueTen.Caption = "Tên";
            this.gcLueTen.FieldName = "profilename";
            this.gcLueTen.Name = "gcLueTen";
            this.gcLueTen.Visible = true;
            this.gcLueTen.VisibleIndex = 1;
            this.gcLueTen.Width = 275;
            // 
            // ucSearchLookupEditor_Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lueData);
            this.Name = "ucSearchLookupEditor_Profile";
            this.Size = new System.Drawing.Size(127, 23);
            this.Enter += new System.EventHandler(this.ucDevLookupEditor_Enter);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ucDevLookupEditor_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.lueData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SearchLookUpEdit lueData;
        private DevExpress.XtraGrid.Views.Grid.GridView gvData;
        private DevExpress.XtraGrid.Columns.GridColumn gcLueMa;
        private DevExpress.XtraGrid.Columns.GridColumn gcLueTen;
    }
}
