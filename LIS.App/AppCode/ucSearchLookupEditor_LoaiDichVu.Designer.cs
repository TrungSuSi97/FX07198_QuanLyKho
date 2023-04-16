namespace TPH.LIS.App.AppCode
{
    partial class ucSearchLookupEditor_LoaiDichVu
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
            this.lueLoaiChiDinh = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gvLueLoaiDichVu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gvLueLoaiChuNang_MaNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueGcMaPhanLoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueGcTenPhanLoai = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lueLoaiChiDinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLueLoaiDichVu)).BeginInit();
            this.SuspendLayout();
            // 
            // lueLoaiChiDinh
            // 
            this.lueLoaiChiDinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lueLoaiChiDinh.Location = new System.Drawing.Point(0, 0);
            this.lueLoaiChiDinh.Name = "lueLoaiChiDinh";
            this.lueLoaiChiDinh.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lueLoaiChiDinh.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject1.Options.UseFont = true;
            serializableAppearanceObject2.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject2.Options.UseFont = true;
            serializableAppearanceObject3.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject3.Options.UseFont = true;
            serializableAppearanceObject4.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject4.Options.UseFont = true;
            this.lueLoaiChiDinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.lueLoaiChiDinh.Properties.NullText = "";
            this.lueLoaiChiDinh.Properties.PopupView = this.gvLueLoaiDichVu;
            this.lueLoaiChiDinh.Properties.Popup += new System.EventHandler(this.lueLoaiChiDinh_Properties_Popup);
            this.lueLoaiChiDinh.Properties.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lueLoaiChiDinh_KeyPress);
            this.lueLoaiChiDinh.Size = new System.Drawing.Size(127, 22);
            this.lueLoaiChiDinh.TabIndex = 337;
            // 
            // gvLueLoaiDichVu
            // 
            this.gvLueLoaiDichVu.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.DetailTip.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.DetailTip.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.Empty.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.Empty.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.EvenRow.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.FilterPanel.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.FixedLine.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.FocusedCell.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.FocusedRow.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.FooterPanel.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.GroupButton.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.GroupFooter.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.GroupPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.GroupPanel.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.gvLueLoaiDichVu.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvLueLoaiDichVu.Appearance.GroupRow.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvLueLoaiDichVu.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.HorzLine.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.OddRow.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.Preview.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.Row.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.Row.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.RowSeparator.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.SelectedRow.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.TopNewRow.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.VertLine.Options.UseFont = true;
            this.gvLueLoaiDichVu.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueLoaiDichVu.Appearance.ViewCaption.Options.UseFont = true;
            this.gvLueLoaiDichVu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gvLueLoaiChuNang_MaNhap,
            this.lueGcMaPhanLoai,
            this.lueGcTenPhanLoai});
            this.gvLueLoaiDichVu.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvLueLoaiDichVu.Name = "gvLueLoaiDichVu";
            this.gvLueLoaiDichVu.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvLueLoaiDichVu.OptionsView.ColumnAutoWidth = false;
            this.gvLueLoaiDichVu.OptionsView.ShowGroupPanel = false;
            this.gvLueLoaiDichVu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lueLoaiChiDinh_KeyPress);
            // 
            // gvLueLoaiChuNang_MaNhap
            // 
            this.gvLueLoaiChuNang_MaNhap.Caption = "ID";
            this.gvLueLoaiChuNang_MaNhap.FieldName = "MaNhap";
            this.gvLueLoaiChuNang_MaNhap.Name = "gvLueLoaiChuNang_MaNhap";
            this.gvLueLoaiChuNang_MaNhap.Visible = true;
            this.gvLueLoaiChuNang_MaNhap.VisibleIndex = 0;
            // 
            // lueGcMaPhanLoai
            // 
            this.lueGcMaPhanLoai.Caption = "Mã loại chỉ định";
            this.lueGcMaPhanLoai.FieldName = "MaPhanLoai";
            this.lueGcMaPhanLoai.Name = "lueGcMaPhanLoai";
            this.lueGcMaPhanLoai.Width = 104;
            // 
            // lueGcTenPhanLoai
            // 
            this.lueGcTenPhanLoai.Caption = "Tên loại chỉ định";
            this.lueGcTenPhanLoai.FieldName = "TenPhanLoai";
            this.lueGcTenPhanLoai.Name = "lueGcTenPhanLoai";
            this.lueGcTenPhanLoai.Visible = true;
            this.lueGcTenPhanLoai.VisibleIndex = 1;
            this.lueGcTenPhanLoai.Width = 275;
            // 
            // ucSearchLookupEditor_LoaiDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lueLoaiChiDinh);
            this.Name = "ucSearchLookupEditor_LoaiDichVu";
            this.Size = new System.Drawing.Size(127, 23);
            this.Enter += new System.EventHandler(this.ucDevLookupEditor_Enter);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ucDevLookupEditor_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.lueLoaiChiDinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLueLoaiDichVu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit lueLoaiChiDinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLueLoaiDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn gvLueLoaiChuNang_MaNhap;
        private DevExpress.XtraGrid.Columns.GridColumn lueGcMaPhanLoai;
        private DevExpress.XtraGrid.Columns.GridColumn lueGcTenPhanLoai;
    }
}
