namespace TPH.LIS.App
{
    partial class FrmTemplate
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTemplate));
            this.pnContaint = new DevExpress.XtraEditors.PanelControl();
            this.pnMenu = new DevExpress.XtraEditors.PanelControl();
            this.xtraScrollableControlMain = new DevExpress.XtraEditors.XtraScrollableControl();
            this.pnFormControl = new DevExpress.XtraEditors.PanelControl();
            this.btnMinimize = new TPH.Controls.TPHIconButton();
            this.btnMaximize = new TPH.Controls.TPHIconButton();
            this.tphIconButton1 = new TPH.Controls.TPHIconButton();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.ucGroupHeaderChonMain = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnButtonMenu = new DevExpress.XtraEditors.PanelControl();
            this.btnThuNhoMenu = new TPH.Controls.TPHNormalButton();
            this.pnR = new DevExpress.XtraEditors.PanelControl();
            this.pnL = new DevExpress.XtraEditors.PanelControl();
            this.imgLMenu = new System.Windows.Forms.ImageList(this.components);
            this.pnLabel = new TPH.LIS.Common.Controls.GradientPanel();
            this.btnClose = new TPH.Controls.TPHNormalButton();
            this.lblMainESC = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnContaint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnMenu)).BeginInit();
            this.pnMenu.SuspendLayout();
            this.xtraScrollableControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnFormControl)).BeginInit();
            this.pnFormControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnButtonMenu)).BeginInit();
            this.pnButtonMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnL)).BeginInit();
            this.pnLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnContaint
            // 
            this.pnContaint.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnContaint.Appearance.Options.UseBackColor = true;
            this.pnContaint.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnContaint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContaint.Location = new System.Drawing.Point(0, 28);
            this.pnContaint.Name = "pnContaint";
            this.pnContaint.Padding = new System.Windows.Forms.Padding(2);
            this.pnContaint.Size = new System.Drawing.Size(1184, 633);
            this.pnContaint.TabIndex = 1;
            // 
            // pnMenu
            // 
            this.pnMenu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnMenu.Appearance.BackColor2 = System.Drawing.Color.WhiteSmoke;
            this.pnMenu.Appearance.Options.UseBackColor = true;
            this.pnMenu.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnMenu.Controls.Add(this.xtraScrollableControlMain);
            this.pnMenu.Controls.Add(this.pnButtonMenu);
            this.pnMenu.Controls.Add(this.pnR);
            this.pnMenu.Controls.Add(this.pnL);
            this.pnMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnMenu.Location = new System.Drawing.Point(0, 1);
            this.pnMenu.Margin = new System.Windows.Forms.Padding(0);
            this.pnMenu.Name = "pnMenu";
            this.pnMenu.Size = new System.Drawing.Size(1184, 27);
            this.pnMenu.TabIndex = 2;
            this.pnMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnMenu_MouseDown);
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.xtraScrollableControlMain.Controls.Add(this.pnFormControl);
            this.xtraScrollableControlMain.Controls.Add(this.lblTitle);
            this.xtraScrollableControlMain.Controls.Add(this.ucGroupHeaderChonMain);
            this.xtraScrollableControlMain.Controls.Add(this.pictureBox1);
            this.xtraScrollableControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControlMain.Location = new System.Drawing.Point(0, 1);
            this.xtraScrollableControlMain.Name = "xtraScrollableControlMain";
            this.xtraScrollableControlMain.Padding = new System.Windows.Forms.Padding(2, 1, 2, 0);
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(1184, 26);
            this.xtraScrollableControlMain.TabIndex = 6;
            this.xtraScrollableControlMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xtraScrollableControlMain_MouseDown);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnFormControl.Appearance.Options.UseBackColor = true;
            this.pnFormControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnFormControl.Controls.Add(this.btnMinimize);
            this.pnFormControl.Controls.Add(this.btnMaximize);
            this.pnFormControl.Controls.Add(this.tphIconButton1);
            this.pnFormControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnFormControl.Location = new System.Drawing.Point(1076, 1);
            this.pnFormControl.Margin = new System.Windows.Forms.Padding(0);
            this.pnFormControl.Name = "pnFormControl";
            this.pnFormControl.Size = new System.Drawing.Size(106, 25);
            this.pnFormControl.TabIndex = 379;
            // 
            // btnMinimize
            // 
            this.btnMinimize._1_Size = new System.Drawing.Size(32, 20);
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(182)))), ((int)(((byte)(216)))));
            this.btnMinimize.ButtonBackColorStyle = TPH.Controls.ctrls.Solid;
            this.btnMinimize.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnMinimize.ButtonBorderSize = 0;
            this.btnMinimize.ButtonRadius = 0;
            this.btnMinimize.ButtonStyle = TPH.Controls.bd.IconButton;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(171)))), ((int)(((byte)(203)))));
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(160)))), ((int)(((byte)(190)))));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btnMinimize.IconColor = System.Drawing.Color.White;
            this.btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnMinimize.IconSize = 24;
            this.btnMinimize.Location = new System.Drawing.Point(7, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(32, 20);
            this.btnMinimize.TabIndex = 4;
            this.btnMinimize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMinimize.UseHoverColor = true;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize._1_Size = new System.Drawing.Size(32, 20);
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(150)))), ((int)(((byte)(248)))));
            this.btnMaximize.ButtonBackColorStyle = TPH.Controls.ctrls.Solid;
            this.btnMaximize.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnMaximize.ButtonBorderSize = 0;
            this.btnMaximize.ButtonRadius = 0;
            this.btnMaximize.ButtonStyle = TPH.Controls.bd.IconButton;
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(141)))), ((int)(((byte)(233)))));
            this.btnMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(132)))), ((int)(((byte)(218)))));
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaximize.ForeColor = System.Drawing.Color.White;
            this.btnMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.btnMaximize.IconColor = System.Drawing.Color.White;
            this.btnMaximize.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnMaximize.IconSize = 24;
            this.btnMaximize.Location = new System.Drawing.Point(41, 0);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(32, 20);
            this.btnMaximize.TabIndex = 3;
            this.btnMaximize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMaximize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMaximize.UseHoverColor = true;
            this.btnMaximize.UseVisualStyleBackColor = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // tphIconButton1
            // 
            this.tphIconButton1._1_Size = new System.Drawing.Size(29, 20);
            this.tphIconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tphIconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(93)))), ((int)(((byte)(133)))));
            this.tphIconButton1.ButtonBackColorStyle = TPH.Controls.ctrls.Solid;
            this.tphIconButton1.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tphIconButton1.ButtonBorderSize = 0;
            this.tphIconButton1.ButtonRadius = 0;
            this.tphIconButton1.ButtonStyle = TPH.Controls.bd.IconButton;
            this.tphIconButton1.FlatAppearance.BorderSize = 0;
            this.tphIconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(87)))), ((int)(((byte)(125)))));
            this.tphIconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(81)))), ((int)(((byte)(117)))));
            this.tphIconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tphIconButton1.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tphIconButton1.ForeColor = System.Drawing.Color.White;
            this.tphIconButton1.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.tphIconButton1.IconColor = System.Drawing.Color.White;
            this.tphIconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.tphIconButton1.IconSize = 24;
            this.tphIconButton1.Location = new System.Drawing.Point(76, 0);
            this.tphIconButton1.Name = "tphIconButton1";
            this.tphIconButton1.Size = new System.Drawing.Size(29, 20);
            this.tphIconButton1.TabIndex = 2;
            this.tphIconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tphIconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tphIconButton1.UseHoverColor = true;
            this.tphIconButton1.UseVisualStyleBackColor = false;
            this.tphIconButton1.Click += new System.EventHandler(this.tphIconButton1_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Options.UseBackColor = true;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.Location = new System.Drawing.Point(27, 1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(5, 3, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(89, 22);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TÊN FORM";
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            // 
            // ucGroupHeaderChonMain
            // 
            this.ucGroupHeaderChonMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeaderChonMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucGroupHeaderChonMain.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeaderChonMain.ForeColor = System.Drawing.Color.Yellow;
            this.ucGroupHeaderChonMain.GroupCaption = "CHỌN";
            this.ucGroupHeaderChonMain.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ucGroupHeaderChonMain.Location = new System.Drawing.Point(27, 1);
            this.ucGroupHeaderChonMain.Margin = new System.Windows.Forms.Padding(41, 18, 41, 18);
            this.ucGroupHeaderChonMain.MaximumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeaderChonMain.MinimumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeaderChonMain.Name = "ucGroupHeaderChonMain";
            this.ucGroupHeaderChonMain.Size = new System.Drawing.Size(0, 23);
            this.ucGroupHeaderChonMain.TabIndex = 378;
            this.ucGroupHeaderChonMain.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.TabIndex = 380;
            this.pictureBox1.TabStop = false;
            // 
            // pnButtonMenu
            // 
            this.pnButtonMenu.Controls.Add(this.btnThuNhoMenu);
            this.pnButtonMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnButtonMenu.Location = new System.Drawing.Point(0, 0);
            this.pnButtonMenu.Name = "pnButtonMenu";
            this.pnButtonMenu.Size = new System.Drawing.Size(1184, 1);
            this.pnButtonMenu.TabIndex = 0;
            this.pnButtonMenu.Visible = false;
            // 
            // btnThuNhoMenu
            // 
            this.btnThuNhoMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.btnThuNhoMenu.BackColorHover = System.Drawing.Color.Empty;
            this.btnThuNhoMenu.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.btnThuNhoMenu.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThuNhoMenu.BorderRadius = -2;
            this.btnThuNhoMenu.BorderSize = 1;
            this.btnThuNhoMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThuNhoMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThuNhoMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThuNhoMenu.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThuNhoMenu.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThuNhoMenu.ForeColor = System.Drawing.Color.White;
            this.btnThuNhoMenu.Location = new System.Drawing.Point(2, 1);
            this.btnThuNhoMenu.Name = "btnThuNhoMenu";
            this.btnThuNhoMenu.Size = new System.Drawing.Size(1180, 0);
            this.btnThuNhoMenu.TabIndex = 0;
            this.btnThuNhoMenu.Text = "MENU";
            this.btnThuNhoMenu.TextColor = System.Drawing.Color.White;
            this.btnThuNhoMenu.UseHightLight = true;
            this.btnThuNhoMenu.UseVisualStyleBackColor = false;
            this.btnThuNhoMenu.Click += new System.EventHandler(this.btnThuNhoMenu_Click);
            // 
            // pnR
            // 
            this.pnR.Location = new System.Drawing.Point(0, 625);
            this.pnR.Name = "pnR";
            this.pnR.Size = new System.Drawing.Size(10, 10);
            this.pnR.TabIndex = 2;
            this.pnR.Visible = false;
            // 
            // pnL
            // 
            this.pnL.Location = new System.Drawing.Point(0, 628);
            this.pnL.Name = "pnL";
            this.pnL.Size = new System.Drawing.Size(10, 10);
            this.pnL.TabIndex = 1;
            this.pnL.Visible = false;
            // 
            // imgLMenu
            // 
            this.imgLMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLMenu.ImageStream")));
            this.imgLMenu.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLMenu.Images.SetKeyName(0, "menu_collapse_left-512_24x24.png");
            this.imgLMenu.Images.SetKeyName(1, "menu_expansion-512_24x24.png");
            // 
            // pnLabel
            // 
            this.pnLabel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnLabel.BottomColor = System.Drawing.Color.Empty;
            this.pnLabel.Controls.Add(this.btnClose);
            this.pnLabel.Controls.Add(this.lblMainESC);
            this.pnLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLabel.GradientDegree = 0F;
            this.pnLabel.Location = new System.Drawing.Point(0, 0);
            this.pnLabel.Name = "pnLabel";
            this.pnLabel.Size = new System.Drawing.Size(1184, 1);
            this.pnLabel.TabIndex = 0;
            this.pnLabel.TopColor = System.Drawing.Color.Empty;
            this.pnLabel.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackColorHover = System.Drawing.Color.Empty;
            this.btnClose.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnClose.BorderRadius = 0;
            this.btnClose.BorderSize = 0;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForceColorHover = System.Drawing.Color.Empty;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(832, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(29, 1);
            this.btnClose.TabIndex = 1;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.TextColor = System.Drawing.Color.White;
            this.btnClose.UseHightLight = true;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblMainESC
            // 
            this.lblMainESC.Appearance.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainESC.Appearance.Options.UseFont = true;
            this.lblMainESC.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMainESC.ImageOptions.Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lblMainESC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblMainESC.ImageOptions.Image")));
            this.lblMainESC.Location = new System.Drawing.Point(861, 0);
            this.lblMainESC.Name = "lblMainESC";
            this.lblMainESC.Size = new System.Drawing.Size(323, 16);
            this.lblMainESC.TabIndex = 2;
            this.lblMainESC.Text = "Nhấn phím ESC để đóng form hoặc click dấu [x] trên thanh tiêu đề";
            this.lblMainESC.Visible = false;
            // 
            // FrmTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.ControlBox = false;
            this.Controls.Add(this.pnContaint);
            this.Controls.Add(this.pnMenu);
            this.Controls.Add(this.pnLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTemplate";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTemplate";
            this.Activated += new System.EventHandler(this.FrmTemplate_Activated);
            this.Load += new System.EventHandler(this.frmTemplate_Load);
            this.Shown += new System.EventHandler(this.FrmTemplate_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pnContaint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnMenu)).EndInit();
            this.pnMenu.ResumeLayout(false);
            this.xtraScrollableControlMain.ResumeLayout(false);
            this.xtraScrollableControlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnFormControl)).EndInit();
            this.pnFormControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnButtonMenu)).EndInit();
            this.pnButtonMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnL)).EndInit();
            this.pnLabel.ResumeLayout(false);
            this.pnLabel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.LabelControl lblTitle;
        public DevExpress.XtraEditors.PanelControl pnContaint;
        public Common.Controls.GradientPanel pnLabel;
        public TPH.Controls.TPHNormalButton btnClose;
        public DevExpress.XtraEditors.LabelControl lblMainESC;
        public DevExpress.XtraEditors.PanelControl pnMenu;
        private DevExpress.XtraEditors.PanelControl pnButtonMenu;
        private TPH.Controls.TPHNormalButton btnThuNhoMenu;
        private System.Windows.Forms.ImageList imgLMenu;
        private DevExpress.XtraEditors.PanelControl pnR;
        private DevExpress.XtraEditors.PanelControl pnL;
        public DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControlMain;
        public Common.Controls.ucGroupHeader ucGroupHeaderChonMain;
        public DevExpress.XtraEditors.PanelControl pnFormControl;
        public Controls.TPHIconButton btnMinimize;
        public Controls.TPHIconButton btnMaximize;
        public Controls.TPHIconButton tphIconButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}