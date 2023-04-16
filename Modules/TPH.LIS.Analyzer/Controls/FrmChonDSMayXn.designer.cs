namespace TPH.LIS.Analyzer.Controls
{
    partial class FrmChonDSMayXn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChonDSMayXn));
            this.label1 = new System.Windows.Forms.Label();
            this.gcMayXN = new DevExpress.XtraGrid.GridControl();
            this.gvMayXN = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIDMayXn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xolTenMayXN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHuy = new TPH.Controls.TPHNormalButton();
            this.btnDongY = new TPH.Controls.TPHNormalButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcMayXN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMayXN)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(241)))), ((int)(((byte)(238)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(434, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "CHỌN MÁY XÉT NGHIỆM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gcMayXN
            // 
            this.gcMayXN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMayXN.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.gcMayXN.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gcMayXN.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.gcMayXN.Location = new System.Drawing.Point(0, 23);
            this.gcMayXN.MainView = this.gvMayXN;
            this.gcMayXN.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.gcMayXN.Name = "gcMayXN";
            this.gcMayXN.Size = new System.Drawing.Size(434, 302);
            this.gcMayXN.TabIndex = 361;
            this.gcMayXN.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMayXN});
            // 
            // gvMayXN
            // 
            this.gvMayXN.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvMayXN.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvMayXN.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvMayXN.Appearance.DetailTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.DetailTip.Options.UseFont = true;
            this.gvMayXN.Appearance.Empty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.Empty.Options.UseFont = true;
            this.gvMayXN.Appearance.EvenRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.EvenRow.Options.UseFont = true;
            this.gvMayXN.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvMayXN.Appearance.FilterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.FilterPanel.Options.UseFont = true;
            this.gvMayXN.Appearance.FixedLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.FixedLine.Options.UseFont = true;
            this.gvMayXN.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvMayXN.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvMayXN.Appearance.FocusedCell.Options.UseFont = true;
            this.gvMayXN.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.FocusedRow.Options.UseFont = true;
            this.gvMayXN.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvMayXN.Appearance.FooterPanel.Options.UseFont = true;
            this.gvMayXN.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvMayXN.Appearance.GroupButton.Options.UseFont = true;
            this.gvMayXN.Appearance.GroupFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvMayXN.Appearance.GroupFooter.Options.UseFont = true;
            this.gvMayXN.Appearance.GroupPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.GroupPanel.Options.UseFont = true;
            this.gvMayXN.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvMayXN.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvMayXN.Appearance.GroupRow.Options.UseFont = true;
            this.gvMayXN.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvMayXN.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvMayXN.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvMayXN.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvMayXN.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.HorzLine.Options.UseFont = true;
            this.gvMayXN.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.OddRow.Options.UseFont = true;
            this.gvMayXN.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.Preview.Options.UseFont = true;
            this.gvMayXN.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.Row.Options.UseFont = true;
            this.gvMayXN.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.RowSeparator.Options.UseFont = true;
            this.gvMayXN.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvMayXN.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvMayXN.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvMayXN.Appearance.SelectedRow.Options.UseFont = true;
            this.gvMayXN.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvMayXN.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.TopNewRow.Options.UseFont = true;
            this.gvMayXN.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.VertLine.Options.UseFont = true;
            this.gvMayXN.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.ViewCaption.Options.UseFont = true;
            this.gvMayXN.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIDMayXn,
            this.xolTenMayXN});
            this.gvMayXN.DetailHeight = 284;
            this.gvMayXN.GridControl = this.gcMayXN;
            this.gvMayXN.Name = "gvMayXN";
            this.gvMayXN.OptionsSelection.CheckBoxSelectorColumnWidth = 26;
            this.gvMayXN.OptionsSelection.MultiSelect = true;
            this.gvMayXN.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvMayXN.OptionsView.ColumnAutoWidth = false;
            this.gvMayXN.OptionsView.RowAutoHeight = true;
            this.gvMayXN.OptionsView.ShowAutoFilterRow = true;
            this.gvMayXN.OptionsView.ShowGroupPanel = false;
            // 
            // colIDMayXn
            // 
            this.colIDMayXn.Caption = "ID Máy XN";
            this.colIDMayXn.FieldName = "idmay";
            this.colIDMayXn.MinWidth = 17;
            this.colIDMayXn.Name = "colIDMayXn";
            this.colIDMayXn.OptionsColumn.AllowEdit = false;
            this.colIDMayXn.OptionsColumn.ReadOnly = true;
            this.colIDMayXn.Visible = true;
            this.colIDMayXn.VisibleIndex = 1;
            this.colIDMayXn.Width = 62;
            // 
            // xolTenMayXN
            // 
            this.xolTenMayXN.Caption = "Tên máy xét nghiệm";
            this.xolTenMayXN.FieldName = "tenmay";
            this.xolTenMayXN.MinWidth = 17;
            this.xolTenMayXN.Name = "xolTenMayXN";
            this.xolTenMayXN.OptionsColumn.AllowEdit = false;
            this.xolTenMayXN.OptionsColumn.ReadOnly = true;
            this.xolTenMayXN.Visible = true;
            this.xolTenMayXN.VisibleIndex = 2;
            this.xolTenMayXN.Width = 243;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnHuy);
            this.panel1.Controls.Add(this.btnDongY);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 325);
            this.panel1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 43);
            this.panel1.TabIndex = 362;
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnHuy.BackColorHover = System.Drawing.Color.Empty;
            this.btnHuy.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnHuy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnHuy.BorderRadius = 5;
            this.btnHuy.BorderSize = 1;
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForceColorHover = System.Drawing.Color.Empty;
            this.btnHuy.ForeColor = System.Drawing.Color.Black;
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(220, 5);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(89, 33);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "     Hủy";
            this.btnHuy.TextColor = System.Drawing.Color.Black;
            this.btnHuy.UseHightLight = true;
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnDongY
            // 
            this.btnDongY.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDongY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnDongY.BackColorHover = System.Drawing.Color.Empty;
            this.btnDongY.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnDongY.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnDongY.BorderRadius = 5;
            this.btnDongY.BorderSize = 1;
            this.btnDongY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDongY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDongY.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDongY.ForceColorHover = System.Drawing.Color.Empty;
            this.btnDongY.ForeColor = System.Drawing.Color.Black;
            this.btnDongY.Image = ((System.Drawing.Image)(resources.GetObject("btnDongY.Image")));
            this.btnDongY.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDongY.Location = new System.Drawing.Point(126, 5);
            this.btnDongY.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(89, 33);
            this.btnDongY.TabIndex = 0;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDongY.TextColor = System.Drawing.Color.Black;
            this.btnDongY.UseHightLight = true;
            this.btnDongY.UseVisualStyleBackColor = false;
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // FrmChonDSMayXn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(434, 368);
            this.Controls.Add(this.gcMayXN);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChonDSMayXn";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn máy xét nghiệm";
            this.Load += new System.EventHandler(this.FrmChonDSMayXn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcMayXN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMayXN)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMayXN;
        private DevExpress.XtraGrid.Columns.GridColumn colIDMayXn;
        private DevExpress.XtraGrid.Columns.GridColumn xolTenMayXN;
        private System.Windows.Forms.Panel panel1;
        private TPH.Controls.TPHNormalButton btnDongY;
        private TPH.Controls.TPHNormalButton btnHuy;
        public DevExpress.XtraGrid.GridControl gcMayXN;
    }
}