namespace TPH.LIS.Configuration.Controls
{
    partial class ucDanhMucBienDichKetQuaMay
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDanhMucBienDichKetQuaMay));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucGroupHeader2 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.numIdMayXN = new System.Windows.Forms.NumericUpDown();
            this.label52 = new System.Windows.Forms.Label();
            this.btnXoa = new TPH.Controls.TPHNormalButton();
            this.btnThem = new TPH.Controls.TPHNormalButton();
            this.btnLamMoi = new TPH.Controls.TPHNormalButton();
            this.cboLoaiBienDich = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaXNMay = new TPH.LIS.Common.Controls.CustomTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.gcDanhSach = new DevExpress.XtraGrid.GridControl();
            this.gvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ucGroupHeader1 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIdMayXN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ucGroupHeader2);
            this.panel1.Controls.Add(this.numIdMayXN);
            this.panel1.Controls.Add(this.label52);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.btnLamMoi);
            this.panel1.Controls.Add(this.cboLoaiBienDich);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtMaXNMay);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(912, 170);
            this.panel1.TabIndex = 0;
            // 
            // ucGroupHeader2
            // 
            this.ucGroupHeader2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeader2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader2.ForeColor = System.Drawing.Color.Yellow;
            this.ucGroupHeader2.GroupCaption = "THÊM MỚI BIÊN DỊCH";
            this.ucGroupHeader2.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader2.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeader2.Margin = new System.Windows.Forms.Padding(0);
            this.ucGroupHeader2.MaximumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader2.MinimumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader2.Name = "ucGroupHeader2";
            this.ucGroupHeader2.Size = new System.Drawing.Size(910, 23);
            this.ucGroupHeader2.TabIndex = 50;
            // 
            // numIdMayXN
            // 
            this.numIdMayXN.Location = new System.Drawing.Point(174, 69);
            this.numIdMayXN.Margin = new System.Windows.Forms.Padding(0);
            this.numIdMayXN.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numIdMayXN.Name = "numIdMayXN";
            this.numIdMayXN.Size = new System.Drawing.Size(219, 21);
            this.numIdMayXN.TabIndex = 48;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(523, 37);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(235, 90);
            this.label52.TabIndex = 47;
            this.label52.Text = resources.GetString("label52.Text");
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXoa.BackColorHover = System.Drawing.Color.Empty;
            this.btnXoa.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXoa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXoa.BorderRadius = 5;
            this.btnXoa.BorderSize = 1;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXoa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(318, 131);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(112, 32);
            this.btnXoa.TabIndex = 45;
            this.btnXoa.Text = "        Xóa cài đặt";
            this.btnXoa.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnXoa.UseHightLight = true;
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThem.BackColorHover = System.Drawing.Color.Empty;
            this.btnThem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThem.BorderRadius = 5;
            this.btnThem.BorderSize = 1;
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(190, 131);
            this.btnThem.Margin = new System.Windows.Forms.Padding(0);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 32);
            this.btnThem.TabIndex = 44;
            this.btnThem.Text = "Thêm cài đặt";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnThem.UseHightLight = true;
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLamMoi.BackColorHover = System.Drawing.Color.Empty;
            this.btnLamMoi.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLamMoi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnLamMoi.BorderRadius = 5;
            this.btnLamMoi.BorderSize = 1;
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForceColorHover = System.Drawing.Color.Empty;
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLamMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoi.Image")));
            this.btnLamMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLamMoi.Location = new System.Drawing.Point(438, 131);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(0);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(112, 32);
            this.btnLamMoi.TabIndex = 46;
            this.btnLamMoi.Text = "     Làm mới";
            this.btnLamMoi.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnLamMoi.UseHightLight = true;
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // cboLoaiBienDich
            // 
            this.cboLoaiBienDich.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiBienDich.FormattingEnabled = true;
            this.cboLoaiBienDich.Location = new System.Drawing.Point(174, 37);
            this.cboLoaiBienDich.Margin = new System.Windows.Forms.Padding(0);
            this.cboLoaiBienDich.Name = "cboLoaiBienDich";
            this.cboLoaiBienDich.Size = new System.Drawing.Size(219, 23);
            this.cboLoaiBienDich.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Loại biên dịch";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "ID máy xét nghiệm";
            // 
            // txtMaXNMay
            // 
            this.txtMaXNMay.BackColorEnter = System.Drawing.Color.Yellow;
            this.txtMaXNMay.BindFieldName = null;
            this.txtMaXNMay.ForceColorEnter = System.Drawing.Color.DarkRed;
            this.txtMaXNMay.Location = new System.Drawing.Point(174, 99);
            this.txtMaXNMay.Margin = new System.Windows.Forms.Padding(0);
            this.txtMaXNMay.Name = "txtMaXNMay";
            this.txtMaXNMay.OldValue = null;
            this.txtMaXNMay.Size = new System.Drawing.Size(219, 21);
            this.txtMaXNMay.TabIndex = 15;
            this.txtMaXNMay.UseFocusColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Mã xét nghiệm của máy";
            // 
            // gcDanhSach
            // 
            this.gcDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhSach.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.gcDanhSach.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gcDanhSach.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcDanhSach.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcDanhSach.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcDanhSach.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcDanhSach.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcDanhSach.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0);
            this.gcDanhSach.EmbeddedNavigator.TextStringFormat = "{0} of {1}";
            this.gcDanhSach.Location = new System.Drawing.Point(0, 193);
            this.gcDanhSach.MainView = this.gvDanhSach;
            this.gcDanhSach.Margin = new System.Windows.Forms.Padding(0);
            this.gcDanhSach.Name = "gcDanhSach";
            this.gcDanhSach.Size = new System.Drawing.Size(912, 363);
            this.gcDanhSach.TabIndex = 371;
            this.gcDanhSach.UseEmbeddedNavigator = true;
            this.gcDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhSach,
            this.gridView2});
            // 
            // gvDanhSach
            // 
            this.gvDanhSach.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSach.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvDanhSach.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSach.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvDanhSach.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSach.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvDanhSach.Appearance.DetailTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSach.Appearance.DetailTip.Options.UseFont = true;
            this.gvDanhSach.Appearance.Empty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSach.Appearance.Empty.Options.UseFont = true;
            this.gvDanhSach.Appearance.EvenRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSach.Appearance.EvenRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSach.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvDanhSach.Appearance.FilterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSach.Appearance.FilterPanel.Options.UseFont = true;
            this.gvDanhSach.Appearance.FixedLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSach.Appearance.FixedLine.Options.UseFont = true;
            this.gvDanhSach.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvDanhSach.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvDanhSach.Appearance.FocusedCell.Options.UseFont = true;
            this.gvDanhSach.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 10F);
            this.gvDanhSach.Appearance.FocusedRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhSach.Appearance.FooterPanel.Options.UseFont = true;
            this.gvDanhSach.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhSach.Appearance.GroupButton.Options.UseFont = true;
            this.gvDanhSach.Appearance.GroupFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvDanhSach.Appearance.GroupFooter.Options.UseFont = true;
            this.gvDanhSach.Appearance.GroupPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvDanhSach.Appearance.GroupPanel.Options.UseFont = true;
            this.gvDanhSach.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.gvDanhSach.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvDanhSach.Appearance.GroupRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvDanhSach.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.gvDanhSach.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvDanhSach.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvDanhSach.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gvDanhSach.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.HorzLine.Options.UseFont = true;
            this.gvDanhSach.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.OddRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.Preview.Options.UseFont = true;
            this.gvDanhSach.Appearance.Row.Font = new System.Drawing.Font("Arial", 10F);
            this.gvDanhSach.Appearance.Row.Options.UseFont = true;
            this.gvDanhSach.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.RowSeparator.Options.UseFont = true;
            this.gvDanhSach.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvDanhSach.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvDanhSach.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvDanhSach.Appearance.SelectedRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvDanhSach.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.TopNewRow.Options.UseFont = true;
            this.gvDanhSach.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.VertLine.Options.UseFont = true;
            this.gvDanhSach.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F);
            this.gvDanhSach.Appearance.ViewCaption.Options.UseFont = true;
            this.gvDanhSach.DetailHeight = 284;
            this.gvDanhSach.GridControl = this.gcDanhSach;
            this.gvDanhSach.Name = "gvDanhSach";
            this.gvDanhSach.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvDanhSach.OptionsSelection.CheckBoxSelectorColumnWidth = 26;
            this.gvDanhSach.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gvDanhSach.OptionsView.ColumnAutoWidth = false;
            this.gvDanhSach.OptionsView.RowAutoHeight = true;
            this.gvDanhSach.OptionsView.ShowAutoFilterRow = true;
            this.gvDanhSach.OptionsView.ShowGroupPanel = false;
            // 
            // gridView2
            // 
            this.gridView2.DetailHeight = 284;
            this.gridView2.GridControl = this.gcDanhSach;
            this.gridView2.Name = "gridView2";
            // 
            // ucGroupHeader1
            // 
            this.ucGroupHeader1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader1.ForeColor = System.Drawing.Color.Yellow;
            this.ucGroupHeader1.GroupCaption = "DANH SÁCH BIÊN DỊCH";
            this.ucGroupHeader1.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader1.Location = new System.Drawing.Point(0, 170);
            this.ucGroupHeader1.Margin = new System.Windows.Forms.Padding(0);
            this.ucGroupHeader1.MaximumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader1.MinimumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader1.Name = "ucGroupHeader1";
            this.ucGroupHeader1.Size = new System.Drawing.Size(912, 23);
            this.ucGroupHeader1.TabIndex = 372;
            // 
            // ucDanhMucBienDichKetQuaMay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gcDanhSach);
            this.Controls.Add(this.ucGroupHeader1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucDanhMucBienDichKetQuaMay";
            this.Size = new System.Drawing.Size(912, 556);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIdMayXN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboLoaiBienDich;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private Common.Controls.CustomTextBox txtMaXNMay;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.GridControl gcDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private TPH.Controls.TPHNormalButton btnXoa;
        private TPH.Controls.TPHNormalButton btnThem;
        private TPH.Controls.TPHNormalButton btnLamMoi;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.NumericUpDown numIdMayXN;
        private Common.Controls.ucGroupHeader ucGroupHeader2;
        private Common.Controls.ucGroupHeader ucGroupHeader1;
    }
}
