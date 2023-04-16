namespace TPH.LIS.App.AppCode
{
    partial class ucSearchLookupEditor_DoiChieuSHPT
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
            this.lueBSChiDinh = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gvNguoiKyTen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaNguoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChucVu = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lueBSChiDinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNguoiKyTen)).BeginInit();
            this.SuspendLayout();
            // 
            // lueBSChiDinh
            // 
            this.lueBSChiDinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lueBSChiDinh.Location = new System.Drawing.Point(0, 0);
            this.lueBSChiDinh.Name = "lueBSChiDinh";
            this.lueBSChiDinh.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lueBSChiDinh.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject1.Options.UseFont = true;
            serializableAppearanceObject2.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject2.Options.UseFont = true;
            serializableAppearanceObject3.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject3.Options.UseFont = true;
            serializableAppearanceObject4.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject4.Options.UseFont = true;
            this.lueBSChiDinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.lueBSChiDinh.Properties.NullText = "";
            this.lueBSChiDinh.Properties.PopupView = this.gvNguoiKyTen;
            this.lueBSChiDinh.Properties.Popup += new System.EventHandler(this.lueBSChiDinh_Properties_Popup);
            this.lueBSChiDinh.Properties.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lueBSChiDinh_KeyPress);
            this.lueBSChiDinh.Size = new System.Drawing.Size(127, 22);
            this.lueBSChiDinh.TabIndex = 333;
            // 
            // gvNguoiKyTen
            // 
            this.gvNguoiKyTen.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.DetailTip.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.DetailTip.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.Empty.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.EvenRow.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.FilterPanel.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.FixedLine.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.FocusedCell.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.FocusedRow.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.FooterPanel.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.GroupButton.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.GroupFooter.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.GroupPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.GroupPanel.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.gvNguoiKyTen.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvNguoiKyTen.Appearance.GroupRow.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvNguoiKyTen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.HorzLine.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.OddRow.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.Preview.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.Row.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.Row.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.RowSeparator.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.SelectedRow.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.TopNewRow.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.VertLine.Options.UseFont = true;
            this.gvNguoiKyTen.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvNguoiKyTen.Appearance.ViewCaption.Options.UseFont = true;
            this.gvNguoiKyTen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaNguoiDung,
            this.colTenNhanVien,
            this.colChucVu});
            this.gvNguoiKyTen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvNguoiKyTen.Name = "gvNguoiKyTen";
            this.gvNguoiKyTen.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvNguoiKyTen.OptionsView.ColumnAutoWidth = false;
            this.gvNguoiKyTen.OptionsView.ShowGroupPanel = false;
            // 
            // colMaNguoiDung
            // 
            this.colMaNguoiDung.Caption = "Tài khoản";
            this.colMaNguoiDung.FieldName = "MaNguoiDung";
            this.colMaNguoiDung.Name = "colMaNguoiDung";
            this.colMaNguoiDung.Visible = true;
            this.colMaNguoiDung.VisibleIndex = 0;
            this.colMaNguoiDung.Width = 104;
            // 
            // colTenNhanVien
            // 
            this.colTenNhanVien.Caption = "Họ tên";
            this.colTenNhanVien.FieldName = "TenNhanVien";
            this.colTenNhanVien.Name = "colTenNhanVien";
            this.colTenNhanVien.Visible = true;
            this.colTenNhanVien.VisibleIndex = 1;
            this.colTenNhanVien.Width = 275;
            // 
            // colChucVu
            // 
            this.colChucVu.Caption = "Chức vụ";
            this.colChucVu.FieldName = "ChucVu";
            this.colChucVu.Name = "colChucVu";
            this.colChucVu.OptionsColumn.ReadOnly = true;
            this.colChucVu.Visible = true;
            this.colChucVu.VisibleIndex = 2;
            this.colChucVu.Width = 246;
            // 
            // ucSearchLookupEditor_DoiChieuSHPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lueBSChiDinh);
            this.Name = "ucSearchLookupEditor_DoiChieuSHPT";
            this.Size = new System.Drawing.Size(127, 23);
            this.Enter += new System.EventHandler(this.ucDevLookupEditor_Enter);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ucDevLookupEditor_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.lueBSChiDinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNguoiKyTen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit lueBSChiDinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNguoiKyTen;
        private DevExpress.XtraGrid.Columns.GridColumn colMaNguoiDung;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn colChucVu;
    }
}
