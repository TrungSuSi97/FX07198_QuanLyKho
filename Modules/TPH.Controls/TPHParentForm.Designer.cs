namespace TPH.Controls
{
    partial class TPHParentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TPHParentForm));
            this.pnMenu = new TPH.Controls.TPHGradientPanel();
            this.pnMenuContent = new System.Windows.Forms.Panel();
            this.pnLogo = new System.Windows.Forms.Panel();
            this.pnTPHLogo = new System.Windows.Forms.Panel();
            this.lblTPHCopyright = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnDesktop = new System.Windows.Forms.Panel();
            this.tabMain = new TPH.Controls.TPHTabControl();
            this.pnMoveTabHeader = new System.Windows.Forms.Panel();
            this.btnNext = new TPH.Controls.TPHNormalButton();
            this.btnPrevious = new TPH.Controls.TPHNormalButton();
            this.pnTabHeader = new System.Windows.Forms.Panel();
            this.pnMainHeader = new System.Windows.Forms.Panel();
            this.pnMainFooter = new TPH.Controls.TPHGradientPanel();
            this.pnContent.SuspendLayout();
            this.pnTitleBar.SuspendLayout();
            this.pnMenu.SuspendLayout();
            this.pnTPHLogo.SuspendLayout();
            this.pnDesktop.SuspendLayout();
            this.pnMoveTabHeader.SuspendLayout();
            this.pnMainHeader.SuspendLayout();
            this.pnMainFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnContent
            // 
            this.pnContent.BackColor = System.Drawing.Color.Transparent;
            this.pnContent.Controls.Add(this.pnDesktop);
            this.pnContent.Controls.Add(this.pnMenu);
            this.pnContent.Controls.Add(this.pnMainFooter);
            this.pnContent.Location = new System.Drawing.Point(1, 1);
            this.pnContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnContent.Size = new System.Drawing.Size(1182, 659);
            this.pnContent.Controls.SetChildIndex(this.pnMainFooter, 0);
            this.pnContent.Controls.SetChildIndex(this.pnMenu, 0);
            this.pnContent.Controls.SetChildIndex(this.pnTitleBar, 0);
            this.pnContent.Controls.SetChildIndex(this.pnDesktop, 0);
            // 
            // pnTitleBar
            // 
            this.pnTitleBar.Controls.Add(this.pnMainHeader);
            this.pnTitleBar.Controls.Add(this.pnMoveTabHeader);
            this.pnTitleBar.Location = new System.Drawing.Point(200, 0);
            this.pnTitleBar.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.pnTitleBar.Size = new System.Drawing.Size(982, 30);
            this.pnTitleBar.Controls.SetChildIndex(this.pnMoveTabHeader, 0);
            this.pnTitleBar.Controls.SetChildIndex(this.lblTitleChildForm, 0);
            this.pnTitleBar.Controls.SetChildIndex(this.iconCurrentChildForm, 0);
            this.pnTitleBar.Controls.SetChildIndex(this.pnMainHeader, 0);
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm._1_Size = new System.Drawing.Size(43, 26);
            this.iconCurrentChildForm.FlatAppearance.BorderSize = 0;
            this.iconCurrentChildForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.iconCurrentChildForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.iconCurrentChildForm.IconSize = 45;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(0, 4);
            this.iconCurrentChildForm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.iconCurrentChildForm.Size = new System.Drawing.Size(43, 26);
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.Dock = System.Windows.Forms.DockStyle.None;
            this.lblTitleChildForm.Location = new System.Drawing.Point(895, 3);
            this.lblTitleChildForm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleChildForm.Size = new System.Drawing.Size(10, 23);
            this.lblTitleChildForm.Visible = false;
            // 
            // pnMenu
            // 
            this.pnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnMenu.BackgroundImage")));
            this.pnMenu.BottomColor = System.Drawing.Color.Empty;
            this.pnMenu.Controls.Add(this.pnMenuContent);
            this.pnMenu.Controls.Add(this.pnLogo);
            this.pnMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnMenu.GradientDegree = -300F;
            this.pnMenu.Location = new System.Drawing.Point(0, 0);
            this.pnMenu.Name = "pnMenu";
            this.pnMenu.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.pnMenu.Size = new System.Drawing.Size(200, 632);
            this.pnMenu.TabIndex = 3;
            this.pnMenu.TopColor = System.Drawing.Color.Empty;
            // 
            // pnMenuContent
            // 
            this.pnMenuContent.AutoScroll = true;
            this.pnMenuContent.BackColor = System.Drawing.Color.Transparent;
            this.pnMenuContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMenuContent.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnMenuContent.Location = new System.Drawing.Point(3, 47);
            this.pnMenuContent.Name = "pnMenuContent";
            this.pnMenuContent.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnMenuContent.Size = new System.Drawing.Size(194, 582);
            this.pnMenuContent.TabIndex = 9;
            // 
            // pnLogo
            // 
            this.pnLogo.BackColor = System.Drawing.Color.Transparent;
            this.pnLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLogo.Location = new System.Drawing.Point(3, 3);
            this.pnLogo.Name = "pnLogo";
            this.pnLogo.Size = new System.Drawing.Size(194, 44);
            this.pnLogo.TabIndex = 0;
            this.pnLogo.Click += new System.EventHandler(this.pnLogo_Click);
            // 
            // pnTPHLogo
            // 
            this.pnTPHLogo.Controls.Add(this.lblTPHCopyright);
            this.pnTPHLogo.Controls.Add(this.panel1);
            this.pnTPHLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnTPHLogo.Location = new System.Drawing.Point(0, 0);
            this.pnTPHLogo.Name = "pnTPHLogo";
            this.pnTPHLogo.Size = new System.Drawing.Size(435, 27);
            this.pnTPHLogo.TabIndex = 0;
            // 
            // lblTPHCopyright
            // 
            this.lblTPHCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTPHCopyright.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTPHCopyright.ForeColor = System.Drawing.Color.Transparent;
            this.lblTPHCopyright.Location = new System.Drawing.Point(28, 0);
            this.lblTPHCopyright.Name = "lblTPHCopyright";
            this.lblTPHCopyright.Size = new System.Drawing.Size(407, 27);
            this.lblTPHCopyright.TabIndex = 2;
            this.lblTPHCopyright.Text = "Copyright © 2017 TPH Solutions All Rights Reserved.";
            this.lblTPHCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panel1.Size = new System.Drawing.Size(28, 27);
            this.panel1.TabIndex = 1;
            // 
            // pnDesktop
            // 
            this.pnDesktop.BackColor = System.Drawing.Color.Transparent;
            this.pnDesktop.Controls.Add(this.tabMain);
            this.pnDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDesktop.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnDesktop.Location = new System.Drawing.Point(200, 30);
            this.pnDesktop.Name = "pnDesktop";
            this.pnDesktop.Size = new System.Drawing.Size(982, 602);
            this.pnDesktop.TabIndex = 4;
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Margin = new System.Windows.Forms.Padding(0);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Drawing.Point(0, 0);
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(982, 602);
            this.tabMain.TabIndex = 1;
            // 
            // pnMoveTabHeader
            // 
            this.pnMoveTabHeader.Controls.Add(this.btnNext);
            this.pnMoveTabHeader.Controls.Add(this.btnPrevious);
            this.pnMoveTabHeader.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnMoveTabHeader.Location = new System.Drawing.Point(815, 4);
            this.pnMoveTabHeader.Name = "pnMoveTabHeader";
            this.pnMoveTabHeader.Padding = new System.Windows.Forms.Padding(5, 1, 0, 3);
            this.pnMoveTabHeader.Size = new System.Drawing.Size(61, 26);
            this.pnMoveTabHeader.TabIndex = 0;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnNext.BackColorHover = System.Drawing.Color.Empty;
            this.btnNext.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnNext.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnNext.BorderRadius = 0;
            this.btnNext.BorderSize = 1;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForceColorHover = System.Drawing.Color.Empty;
            this.btnNext.ForeColor = System.Drawing.Color.Black;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(19, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(15, 16);
            this.btnNext.TabIndex = 9;
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNext.TextColor = System.Drawing.Color.Black;
            this.btnNext.UseHightLight = true;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnPrevious.BackColorHover = System.Drawing.Color.Empty;
            this.btnPrevious.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnPrevious.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnPrevious.BorderRadius = 0;
            this.btnPrevious.BorderSize = 1;
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.ForceColorHover = System.Drawing.Color.Empty;
            this.btnPrevious.ForeColor = System.Drawing.Color.Black;
            this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
            this.btnPrevious.Location = new System.Drawing.Point(3, 5);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(15, 16);
            this.btnPrevious.TabIndex = 8;
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrevious.TextColor = System.Drawing.Color.Black;
            this.btnPrevious.UseHightLight = true;
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // pnTabHeader
            // 
            this.pnTabHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnTabHeader.Location = new System.Drawing.Point(3, 0);
            this.pnTabHeader.Name = "pnTabHeader";
            this.pnTabHeader.Size = new System.Drawing.Size(1, 22);
            this.pnTabHeader.TabIndex = 0;
            this.pnTabHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTabHeader_MouseDown);
            // 
            // pnMainHeader
            // 
            this.pnMainHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.pnMainHeader.Controls.Add(this.pnTabHeader);
            this.pnMainHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMainHeader.Location = new System.Drawing.Point(43, 4);
            this.pnMainHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnMainHeader.Name = "pnMainHeader";
            this.pnMainHeader.Size = new System.Drawing.Size(772, 26);
            this.pnMainHeader.TabIndex = 0;
            this.pnMainHeader.DoubleClick += new System.EventHandler(this.pnMainHeader_DoubleClick);
            this.pnMainHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTabHeader_MouseDown);
            // 
            // pnMainFooter
            // 
            this.pnMainFooter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnMainFooter.BackgroundImage")));
            this.pnMainFooter.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnMainFooter.Controls.Add(this.pnTPHLogo);
            this.pnMainFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnMainFooter.GradientDegree = 135F;
            this.pnMainFooter.Location = new System.Drawing.Point(0, 632);
            this.pnMainFooter.Name = "pnMainFooter";
            this.pnMainFooter.Size = new System.Drawing.Size(1182, 27);
            this.pnMainFooter.TabIndex = 0;
            this.pnMainFooter.TopColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(50)))), ((int)(((byte)(84)))));
            // 
            // TPHParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.FormSize = new System.Drawing.Size(1200, 700);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TPHParentForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TPH.LabIMS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TPHParentForm_Load);
            this.SizeChanged += new System.EventHandler(this.TPHParrentForm_SizeChanged);
            this.pnContent.ResumeLayout(false);
            this.pnTitleBar.ResumeLayout(false);
            this.pnMenu.ResumeLayout(false);
            this.pnTPHLogo.ResumeLayout(false);
            this.pnDesktop.ResumeLayout(false);
            this.pnMoveTabHeader.ResumeLayout(false);
            this.pnMainHeader.ResumeLayout(false);
            this.pnMainFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public TPHGradientPanel pnMenu;
        public System.Windows.Forms.Panel pnMenuContent;
        public System.Windows.Forms.Panel pnDesktop;
        private TPH.Controls.TPHNormalButton btnNext;
        private TPH.Controls.TPHNormalButton btnPrevious;
        private System.Windows.Forms.Panel pnTabHeader;
        public System.Windows.Forms.Panel pnMoveTabHeader;
        public System.Windows.Forms.Panel pnMainHeader;
        public TPHTabControl tabMain;
        public TPHGradientPanel pnMainFooter;
        public TPHDropdownMenuStrip tphDropMenuDefault;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel pnLogo;
        public System.Windows.Forms.Panel pnTPHLogo;
        public System.Windows.Forms.Label lblTPHCopyright;
    }
}