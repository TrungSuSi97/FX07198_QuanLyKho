namespace TPH.LIS.App.AppCode
{
    partial class ucSearchLookupEditor_SinhLy
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
            this.lueDanhSach = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.collue_MaSinhLy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collue_TenSinhLy = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lueDanhSach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // lueDanhSach
            // 
            this.lueDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lueDanhSach.Location = new System.Drawing.Point(0, 0);
            this.lueDanhSach.Name = "lueDanhSach";
            this.lueDanhSach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lueDanhSach.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject1.Options.UseFont = true;
            serializableAppearanceObject2.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject2.Options.UseFont = true;
            serializableAppearanceObject3.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject3.Options.UseFont = true;
            serializableAppearanceObject4.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject4.Options.UseFont = true;
            this.lueDanhSach.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.lueDanhSach.Properties.NullText = "";
            this.lueDanhSach.Properties.PopupView = this.gvDanhSach;
            this.lueDanhSach.Properties.Popup += new System.EventHandler(this.lueDanhSach_Properties_Popup);
            this.lueDanhSach.Properties.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lueDanhSach_KeyPress);
            this.lueDanhSach.Size = new System.Drawing.Size(127, 22);
            this.lueDanhSach.TabIndex = 336;
            // 
            // gvDanhSach
            // 
            this.gvDanhSach.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvDanhSach.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvDanhSach.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvDanhSach.Appearance.DetailTip.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.DetailTip.Options.UseFont = true;
            this.gvDanhSach.Appearance.Empty.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.Empty.Options.UseFont = true;
            this.gvDanhSach.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.EvenRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvDanhSach.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.FilterPanel.Options.UseFont = true;
            this.gvDanhSach.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.FixedLine.Options.UseFont = true;
            this.gvDanhSach.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.FocusedCell.Options.UseFont = true;
            this.gvDanhSach.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.FocusedRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.FooterPanel.Options.UseFont = true;
            this.gvDanhSach.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.GroupButton.Options.UseFont = true;
            this.gvDanhSach.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.GroupFooter.Options.UseFont = true;
            this.gvDanhSach.Appearance.GroupPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.GroupPanel.Options.UseFont = true;
            this.gvDanhSach.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.gvDanhSach.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvDanhSach.Appearance.GroupRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvDanhSach.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvDanhSach.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.HorzLine.Options.UseFont = true;
            this.gvDanhSach.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.OddRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.Preview.Options.UseFont = true;
            this.gvDanhSach.Appearance.Row.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.Row.Options.UseFont = true;
            this.gvDanhSach.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.RowSeparator.Options.UseFont = true;
            this.gvDanhSach.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.SelectedRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.TopNewRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.VertLine.Options.UseFont = true;
            this.gvDanhSach.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvDanhSach.Appearance.ViewCaption.Options.UseFont = true;
            this.gvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.collue_MaSinhLy,
            this.collue_TenSinhLy});
            this.gvDanhSach.DetailHeight = 150;
            this.gvDanhSach.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvDanhSach.Name = "gvDanhSach";
            this.gvDanhSach.OptionsFind.FindNullPrompt = "Tìm ở đây...";
            this.gvDanhSach.OptionsFind.ShowClearButton = false;
            this.gvDanhSach.OptionsFind.ShowCloseButton = false;
            this.gvDanhSach.OptionsFind.ShowFindButton = false;
            this.gvDanhSach.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvDanhSach.OptionsView.ColumnAutoWidth = false;
            this.gvDanhSach.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gvDanhSach.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gvDanhSach.OptionsView.ShowGroupPanel = false;
            // 
            // collue_MaSinhLy
            // 
            this.collue_MaSinhLy.Caption = "Mã sinh lý";
            this.collue_MaSinhLy.FieldName = "MaSinhLy";
            this.collue_MaSinhLy.Name = "collue_MaSinhLy";
            this.collue_MaSinhLy.Visible = true;
            this.collue_MaSinhLy.VisibleIndex = 0;
            this.collue_MaSinhLy.Width = 100;
            // 
            // collue_TenSinhLy
            // 
            this.collue_TenSinhLy.Caption = "Tên sinh lý";
            this.collue_TenSinhLy.FieldName = "TenSinhLy";
            this.collue_TenSinhLy.Name = "collue_TenSinhLy";
            this.collue_TenSinhLy.Visible = true;
            this.collue_TenSinhLy.VisibleIndex = 1;
            this.collue_TenSinhLy.Width = 250;
            // 
            // ucSearchLookupEditor_SinhLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lueDanhSach);
            this.Name = "ucSearchLookupEditor_SinhLy";
            this.Size = new System.Drawing.Size(127, 23);
            this.Enter += new System.EventHandler(this.ucDevLookupEditor_Enter);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ucDevLookupEditor_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.lueDanhSach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit lueDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSach;
        private DevExpress.XtraGrid.Columns.GridColumn collue_MaSinhLy;
        private DevExpress.XtraGrid.Columns.GridColumn collue_TenSinhLy;
    }
}
