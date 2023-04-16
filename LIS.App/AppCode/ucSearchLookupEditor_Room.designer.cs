namespace TPH.LIS.App.AppCode
{
    partial class ucSearchLookupEditor_Room
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
            this.luePhong = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gvPhong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcLueMaPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLueTenPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLueMaKhoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLueTenKhoa = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.luePhong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // luePhong
            // 
            this.luePhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luePhong.Location = new System.Drawing.Point(0, 0);
            this.luePhong.Name = "luePhong";
            this.luePhong.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.luePhong.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject1.Options.UseFont = true;
            serializableAppearanceObject2.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject2.Options.UseFont = true;
            serializableAppearanceObject3.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject3.Options.UseFont = true;
            serializableAppearanceObject4.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject4.Options.UseFont = true;
            this.luePhong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.luePhong.Properties.NullText = "";
            this.luePhong.Properties.PopupView = this.gvPhong;
            this.luePhong.Properties.Popup += new System.EventHandler(this.luePhong_Properties_Popup);
            this.luePhong.Size = new System.Drawing.Size(127, 22);
            this.luePhong.TabIndex = 332;
            this.luePhong.EditValueChanged += new System.EventHandler(this.luePhong_EditValueChanged);
            // 
            // gvPhong
            // 
            this.gvPhong.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvPhong.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvPhong.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvPhong.Appearance.DetailTip.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.DetailTip.Options.UseFont = true;
            this.gvPhong.Appearance.Empty.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.Empty.Options.UseFont = true;
            this.gvPhong.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.EvenRow.Options.UseFont = true;
            this.gvPhong.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvPhong.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.FilterPanel.Options.UseFont = true;
            this.gvPhong.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.FixedLine.Options.UseFont = true;
            this.gvPhong.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.FocusedCell.Options.UseFont = true;
            this.gvPhong.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.FocusedRow.Options.UseFont = true;
            this.gvPhong.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.FooterPanel.Options.UseFont = true;
            this.gvPhong.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.GroupButton.Options.UseFont = true;
            this.gvPhong.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.GroupFooter.Options.UseFont = true;
            this.gvPhong.Appearance.GroupPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.GroupPanel.Options.UseFont = true;
            this.gvPhong.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.gvPhong.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvPhong.Appearance.GroupRow.Options.UseFont = true;
            this.gvPhong.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvPhong.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvPhong.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvPhong.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.HorzLine.Options.UseFont = true;
            this.gvPhong.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.OddRow.Options.UseFont = true;
            this.gvPhong.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.Preview.Options.UseFont = true;
            this.gvPhong.Appearance.Row.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.Row.Options.UseFont = true;
            this.gvPhong.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.RowSeparator.Options.UseFont = true;
            this.gvPhong.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.SelectedRow.Options.UseFont = true;
            this.gvPhong.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.TopNewRow.Options.UseFont = true;
            this.gvPhong.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.VertLine.Options.UseFont = true;
            this.gvPhong.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvPhong.Appearance.ViewCaption.Options.UseFont = true;
            this.gvPhong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcLueMaPhong,
            this.gcLueTenPhong,
            this.gcLueMaKhoa,
            this.gcLueTenKhoa});
            this.gvPhong.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvPhong.GroupCount = 1;
            this.gvPhong.Name = "gvPhong";
            this.gvPhong.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvPhong.OptionsView.ColumnAutoWidth = false;
            this.gvPhong.OptionsView.ShowAutoFilterRow = true;
            this.gvPhong.OptionsView.ShowGroupPanel = false;
            this.gvPhong.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcLueTenKhoa, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gcLueMaPhong
            // 
            this.gcLueMaPhong.Caption = "Mã phòng";
            this.gcLueMaPhong.FieldName = "maphong";
            this.gcLueMaPhong.Name = "gcLueMaPhong";
            this.gcLueMaPhong.Visible = true;
            this.gcLueMaPhong.VisibleIndex = 0;
            this.gcLueMaPhong.Width = 104;
            // 
            // gcLueTenPhong
            // 
            this.gcLueTenPhong.Caption = "Tên phòng";
            this.gcLueTenPhong.FieldName = "tenphong";
            this.gcLueTenPhong.Name = "gcLueTenPhong";
            this.gcLueTenPhong.Visible = true;
            this.gcLueTenPhong.VisibleIndex = 1;
            this.gcLueTenPhong.Width = 275;
            // 
            // gcLueMaKhoa
            // 
            this.gcLueMaKhoa.Caption = "Mã khoa";
            this.gcLueMaKhoa.FieldName = "makhoaphong";
            this.gcLueMaKhoa.Name = "gcLueMaKhoa";
            this.gcLueMaKhoa.OptionsColumn.AllowEdit = false;
            this.gcLueMaKhoa.Visible = true;
            this.gcLueMaKhoa.VisibleIndex = 2;
            this.gcLueMaKhoa.Width = 125;
            // 
            // gcLueTenKhoa
            // 
            this.gcLueTenKhoa.Caption = "Tên khoa";
            this.gcLueTenKhoa.FieldName = "tenkhoaphong";
            this.gcLueTenKhoa.Name = "gcLueTenKhoa";
            this.gcLueTenKhoa.Visible = true;
            this.gcLueTenKhoa.VisibleIndex = 3;
            // 
            // ucSearchLookupEditor_Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.luePhong);
            this.Name = "ucSearchLookupEditor_Room";
            this.Size = new System.Drawing.Size(127, 23);
            this.Enter += new System.EventHandler(this.ucDevLookupEditor_Enter);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ucDevLookupEditor_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.luePhong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPhong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit luePhong;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPhong;
        private DevExpress.XtraGrid.Columns.GridColumn gcLueMaPhong;
        private DevExpress.XtraGrid.Columns.GridColumn gcLueTenPhong;
        private DevExpress.XtraGrid.Columns.GridColumn gcLueMaKhoa;
        private DevExpress.XtraGrid.Columns.GridColumn gcLueTenKhoa;
    }
}
