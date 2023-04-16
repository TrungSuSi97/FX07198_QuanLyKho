﻿namespace TPH.LIS.App.AppCode
{
    partial class ucSearchLookupEditor_DanhSachDichVu
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
            this.lueChiDinh = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gvLueChiDinhDichVu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcLueMaDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLueTenDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLueMagotat = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lueChiDinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLueChiDinhDichVu)).BeginInit();
            this.SuspendLayout();
            // 
            // lueChiDinh
            // 
            this.lueChiDinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lueChiDinh.Location = new System.Drawing.Point(0, 0);
            this.lueChiDinh.Name = "lueChiDinh";
            this.lueChiDinh.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lueChiDinh.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject1.Options.UseFont = true;
            serializableAppearanceObject2.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject2.Options.UseFont = true;
            serializableAppearanceObject3.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject3.Options.UseFont = true;
            serializableAppearanceObject4.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject4.Options.UseFont = true;
            this.lueChiDinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.lueChiDinh.Properties.NullText = "";
            this.lueChiDinh.Properties.PopupView = this.gvLueChiDinhDichVu;
            this.lueChiDinh.Properties.Popup += new System.EventHandler(this.lueChiDinh_Properties_Popup);
            this.lueChiDinh.Properties.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lueChiDinh_KeyPress);
            this.lueChiDinh.Size = new System.Drawing.Size(127, 22);
            this.lueChiDinh.TabIndex = 341;
            this.lueChiDinh.EditValueChanged += new System.EventHandler(this.lueChiDinh_EditValueChanged);
            // 
            // gvLueChiDinhDichVu
            // 
            this.gvLueChiDinhDichVu.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.DetailTip.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.DetailTip.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.Empty.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.Empty.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.EvenRow.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.FilterPanel.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.FixedLine.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.FocusedCell.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.FocusedRow.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.FooterPanel.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.GroupButton.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.GroupFooter.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.GroupPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.GroupPanel.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.gvLueChiDinhDichVu.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvLueChiDinhDichVu.Appearance.GroupRow.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvLueChiDinhDichVu.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.HorzLine.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.OddRow.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.Preview.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.Row.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.Row.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.RowSeparator.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.SelectedRow.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.TopNewRow.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.VertLine.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLueChiDinhDichVu.Appearance.ViewCaption.Options.UseFont = true;
            this.gvLueChiDinhDichVu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcLueMaDichVu,
            this.gcLueTenDichVu,
            this.gcLueMagotat});
            this.gvLueChiDinhDichVu.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvLueChiDinhDichVu.Name = "gvLueChiDinhDichVu";
            this.gvLueChiDinhDichVu.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvLueChiDinhDichVu.OptionsView.ColumnAutoWidth = false;
            this.gvLueChiDinhDichVu.OptionsView.ShowGroupPanel = false;
            // 
            // gcLueMaDichVu
            // 
            this.gcLueMaDichVu.Caption = "Mã dịch vụ";
            this.gcLueMaDichVu.FieldName = "madichvu";
            this.gcLueMaDichVu.Name = "gcLueMaDichVu";
            this.gcLueMaDichVu.Visible = true;
            this.gcLueMaDichVu.VisibleIndex = 2;
            this.gcLueMaDichVu.Width = 104;
            // 
            // gcLueTenDichVu
            // 
            this.gcLueTenDichVu.Caption = "Tên dịch vụ";
            this.gcLueTenDichVu.FieldName = "tendichvu";
            this.gcLueTenDichVu.Name = "gcLueTenDichVu";
            this.gcLueTenDichVu.Visible = true;
            this.gcLueTenDichVu.VisibleIndex = 1;
            this.gcLueTenDichVu.Width = 301;
            // 
            // gcLueMagotat
            // 
            this.gcLueMagotat.Caption = "Nhập nhanh";
            this.gcLueMagotat.FieldName = "magotat";
            this.gcLueMagotat.Name = "gcLueMagotat";
            this.gcLueMagotat.Visible = true;
            this.gcLueMagotat.VisibleIndex = 0;
            this.gcLueMagotat.Width = 94;
            // 
            // ucSearchLookupEditor_DanhSachDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lueChiDinh);
            this.Name = "ucSearchLookupEditor_DanhSachDichVu";
            this.Size = new System.Drawing.Size(127, 23);
            this.Enter += new System.EventHandler(this.ucDevLookupEditor_Enter);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ucDevLookupEditor_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.lueChiDinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLueChiDinhDichVu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit lueChiDinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLueChiDinhDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn gcLueMaDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn gcLueTenDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn gcLueMagotat;
    }
}
