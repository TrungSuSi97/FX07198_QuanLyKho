namespace TPH.LIS.App.DailyUse.BenhNhan
{
    partial class FrmChonLoaiKQSL
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

        #region Windows Form Designer generated code

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
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.btnThucHien = new TPH.Controls.TPHNormalButton();
            this.cboLoaiImport = new System.Windows.Forms.ComboBox();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.lueLoaiMau = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gvLisColumn = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIDMayXn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenMayXn = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lueLoaiMau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLisColumn)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.label1.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.label1.Appearance.Options.UseBackColor = true;
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Appearance.Options.UseForeColor = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "LOẠI IMPORT";
            // 
            // btnThucHien
            // 
            this.btnThucHien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThucHien.BackColorHover = System.Drawing.Color.Empty;
            this.btnThucHien.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThucHien.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThucHien.BorderRadius = 5;
            this.btnThucHien.BorderSize = 1;
            this.btnThucHien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThucHien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThucHien.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThucHien.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThucHien.ForeColor = System.Drawing.Color.Black;
            this.btnThucHien.Image = global::TPH.LIS.App.Properties.Resources.Check_Green_2_24x24;
            this.btnThucHien.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnThucHien.Location = new System.Drawing.Point(377, 33);
            this.btnThucHien.Margin = new System.Windows.Forms.Padding(0);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(100, 59);
            this.btnThucHien.TabIndex = 4;
            this.btnThucHien.Text = "Thực hiện";
            this.btnThucHien.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnThucHien.TextColor = System.Drawing.Color.Black;
            this.btnThucHien.UseHightLight = true;
            this.btnThucHien.UseVisualStyleBackColor = false;
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            // 
            // cboLoaiImport
            // 
            this.cboLoaiImport.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoaiImport.FormattingEnabled = true;
            this.cboLoaiImport.Location = new System.Drawing.Point(102, 33);
            this.cboLoaiImport.Margin = new System.Windows.Forms.Padding(0);
            this.cboLoaiImport.Name = "cboLoaiImport";
            this.cboLoaiImport.Size = new System.Drawing.Size(266, 32);
            this.cboLoaiImport.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.label2.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.label2.Appearance.Options.UseBackColor = true;
            this.label2.Appearance.Options.UseFont = true;
            this.label2.Appearance.Options.UseForeColor = true;
            this.label2.Location = new System.Drawing.Point(5, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mẫu Import";
            // 
            // label3
            // 
            this.label3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.label3.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.label3.Appearance.Options.UseBackColor = true;
            this.label3.Appearance.Options.UseFont = true;
            this.label3.Appearance.Options.UseForeColor = true;
            this.label3.Location = new System.Drawing.Point(5, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Máy xét nghiệm";
            // 
            // lueLoaiMau
            // 
            this.lueLoaiMau.Location = new System.Drawing.Point(102, 70);
            this.lueLoaiMau.Margin = new System.Windows.Forms.Padding(0);
            this.lueLoaiMau.Name = "lueLoaiMau";
            this.lueLoaiMau.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lueLoaiMau.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject1.Options.UseFont = true;
            serializableAppearanceObject2.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject2.Options.UseFont = true;
            serializableAppearanceObject3.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject3.Options.UseFont = true;
            serializableAppearanceObject4.Font = new System.Drawing.Font("Arial", 9.25F);
            serializableAppearanceObject4.Options.UseFont = true;
            this.lueLoaiMau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.lueLoaiMau.Properties.NullText = "";
            this.lueLoaiMau.Properties.PopupView = this.gvLisColumn;
            this.lueLoaiMau.Properties.Popup += new System.EventHandler(this.lueLoaiMau_Properties_Popup);
            this.lueLoaiMau.Properties.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lueLoaiMau_KeyPress);
            this.lueLoaiMau.Size = new System.Drawing.Size(265, 22);
            this.lueLoaiMau.TabIndex = 341;
            // 
            // gvLisColumn
            // 
            this.gvLisColumn.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvLisColumn.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvLisColumn.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvLisColumn.Appearance.DetailTip.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.DetailTip.Options.UseFont = true;
            this.gvLisColumn.Appearance.Empty.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.Empty.Options.UseFont = true;
            this.gvLisColumn.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.EvenRow.Options.UseFont = true;
            this.gvLisColumn.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvLisColumn.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.FilterPanel.Options.UseFont = true;
            this.gvLisColumn.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.FixedLine.Options.UseFont = true;
            this.gvLisColumn.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.FocusedCell.Options.UseFont = true;
            this.gvLisColumn.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.FocusedRow.Options.UseFont = true;
            this.gvLisColumn.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.FooterPanel.Options.UseFont = true;
            this.gvLisColumn.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.GroupButton.Options.UseFont = true;
            this.gvLisColumn.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.GroupFooter.Options.UseFont = true;
            this.gvLisColumn.Appearance.GroupPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.GroupPanel.Options.UseFont = true;
            this.gvLisColumn.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.gvLisColumn.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvLisColumn.Appearance.GroupRow.Options.UseFont = true;
            this.gvLisColumn.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvLisColumn.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvLisColumn.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvLisColumn.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.HorzLine.Options.UseFont = true;
            this.gvLisColumn.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.OddRow.Options.UseFont = true;
            this.gvLisColumn.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.Preview.Options.UseFont = true;
            this.gvLisColumn.Appearance.Row.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.Row.Options.UseFont = true;
            this.gvLisColumn.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.RowSeparator.Options.UseFont = true;
            this.gvLisColumn.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.SelectedRow.Options.UseFont = true;
            this.gvLisColumn.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.TopNewRow.Options.UseFont = true;
            this.gvLisColumn.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.VertLine.Options.UseFont = true;
            this.gvLisColumn.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9.25F);
            this.gvLisColumn.Appearance.ViewCaption.Options.UseFont = true;
            this.gvLisColumn.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIDMayXn,
            this.colTenMayXn});
            this.gvLisColumn.DetailHeight = 284;
            this.gvLisColumn.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvLisColumn.Name = "gvLisColumn";
            this.gvLisColumn.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvLisColumn.OptionsView.ColumnAutoWidth = false;
            this.gvLisColumn.OptionsView.ShowGroupPanel = false;
            // 
            // colIDMayXn
            // 
            this.colIDMayXn.Caption = "Id máy";
            this.colIDMayXn.FieldName = "idmay";
            this.colIDMayXn.MinWidth = 17;
            this.colIDMayXn.Name = "colIDMayXn";
            this.colIDMayXn.Visible = true;
            this.colIDMayXn.VisibleIndex = 0;
            this.colIDMayXn.Width = 89;
            // 
            // colTenMayXn
            // 
            this.colTenMayXn.Caption = "Tên máy";
            this.colTenMayXn.FieldName = "tenmay";
            this.colTenMayXn.MinWidth = 17;
            this.colTenMayXn.Name = "colTenMayXn";
            this.colTenMayXn.Visible = true;
            this.colTenMayXn.VisibleIndex = 1;
            this.colTenMayXn.Width = 236;
            // 
            // FrmChonLoaiKQSL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(491, 102);
            this.Controls.Add(this.lueLoaiMau);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboLoaiImport);
            this.Controls.Add(this.btnThucHien);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChonLoaiKQSL";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmChonLoaiKQSL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lueLoaiMau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLisColumn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl label1;
        private TPH.Controls.TPHNormalButton btnThucHien;
        private System.Windows.Forms.ComboBox cboLoaiImport;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.LabelControl label3;
        private DevExpress.XtraEditors.SearchLookUpEdit lueLoaiMau;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLisColumn;
        private DevExpress.XtraGrid.Columns.GridColumn colIDMayXn;
        private DevExpress.XtraGrid.Columns.GridColumn colTenMayXn;
    }
}