namespace TPH.LIS.App
{
    partial class FrmTemplateCommon
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
            this.pnContaint = new System.Windows.Forms.Panel();
            this.pnMenu = new System.Windows.Forms.Panel();
            this.pnButtonMenu = new System.Windows.Forms.Panel();
            this.btnThuNhoMenu = new System.Windows.Forms.Button();
            this.pnR = new System.Windows.Forms.Panel();
            this.pnL = new System.Windows.Forms.Panel();
            this.imgLMenu = new System.Windows.Forms.ImageList(this.components);
            this.pnLabel = new TPH.LIS.Common.Controls.GradientPanel();
            this.btnClose = new TPH.LIS.Common.Controls.CustomButton();
            this.lblMainESC = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnMenu.SuspendLayout();
            this.pnButtonMenu.SuspendLayout();
            this.pnLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnContaint
            // 
            this.pnContaint.BackColor = System.Drawing.Color.Transparent;
            this.pnContaint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContaint.Location = new System.Drawing.Point(1, 25);
            this.pnContaint.Name = "pnContaint";
            this.pnContaint.Padding = new System.Windows.Forms.Padding(4);
            this.pnContaint.Size = new System.Drawing.Size(1293, 636);
            this.pnContaint.TabIndex = 1;
            // 
            // pnMenu
            // 
            this.pnMenu.BackColor = System.Drawing.Color.White;
            this.pnMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnMenu.Controls.Add(this.pnButtonMenu);
            this.pnMenu.Controls.Add(this.pnR);
            this.pnMenu.Controls.Add(this.pnL);
            this.pnMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnMenu.Location = new System.Drawing.Point(0, 25);
            this.pnMenu.Name = "pnMenu";
            this.pnMenu.Size = new System.Drawing.Size(1, 636);
            this.pnMenu.TabIndex = 2;
            this.pnMenu.Visible = false;
            // 
            // pnButtonMenu
            // 
            this.pnButtonMenu.Controls.Add(this.btnThuNhoMenu);
            this.pnButtonMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnButtonMenu.Location = new System.Drawing.Point(0, 0);
            this.pnButtonMenu.Name = "pnButtonMenu";
            this.pnButtonMenu.Size = new System.Drawing.Size(1, 1);
            this.pnButtonMenu.TabIndex = 0;
            this.pnButtonMenu.Visible = false;
            // 
            // btnThuNhoMenu
            // 
            this.btnThuNhoMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.btnThuNhoMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThuNhoMenu.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThuNhoMenu.ForeColor = System.Drawing.Color.White;
            this.btnThuNhoMenu.Location = new System.Drawing.Point(0, 0);
            this.btnThuNhoMenu.Name = "btnThuNhoMenu";
            this.btnThuNhoMenu.Size = new System.Drawing.Size(1, 1);
            this.btnThuNhoMenu.TabIndex = 0;
            this.btnThuNhoMenu.Text = "MENU";
            this.btnThuNhoMenu.UseVisualStyleBackColor = false;
            this.btnThuNhoMenu.Click += new System.EventHandler(this.btnThuNhoMenu_Click);
            // 
            // pnR
            // 
            this.pnR.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnR.BackgroundImage")));
            this.pnR.Location = new System.Drawing.Point(0, 625);
            this.pnR.Name = "pnR";
            this.pnR.Size = new System.Drawing.Size(10, 10);
            this.pnR.TabIndex = 2;
            this.pnR.Visible = false;
            // 
            // pnL
            // 
            this.pnL.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnL.BackgroundImage")));
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
            this.pnLabel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnLabel.BottomColor = System.Drawing.Color.Silver;
            this.pnLabel.Controls.Add(this.btnClose);
            this.pnLabel.Controls.Add(this.lblMainESC);
            this.pnLabel.Controls.Add(this.lblTitle);
            this.pnLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLabel.GradientDegree = 45F;
            this.pnLabel.Location = new System.Drawing.Point(0, 0);
            this.pnLabel.Name = "pnLabel";
            this.pnLabel.Size = new System.Drawing.Size(1294, 25);
            this.pnLabel.TabIndex = 0;
            this.pnLabel.TopColor = System.Drawing.Color.White;
            this.pnLabel.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(868, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(29, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseHightLight = true;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblMainESC
            // 
            this.lblMainESC.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMainESC.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainESC.Image = ((System.Drawing.Image)(resources.GetObject("lblMainESC.Image")));
            this.lblMainESC.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblMainESC.Location = new System.Drawing.Point(897, 0);
            this.lblMainESC.Name = "lblMainESC";
            this.lblMainESC.Size = new System.Drawing.Size(397, 25);
            this.lblMainESC.TabIndex = 2;
            this.lblMainESC.Text = "Nhấn phím ESC để đóng form hoặc click dấu [x] trên thanh tiêu đề";
            this.lblMainESC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMainESC.Visible = false;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1294, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TÊN FORM";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 661);
            this.Controls.Add(this.pnContaint);
            this.Controls.Add(this.pnMenu);
            this.Controls.Add(this.pnLabel);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmTemplate";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTemplate";
            this.Load += new System.EventHandler(this.frmTemplate_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmTemplate_KeyUp);
            this.pnMenu.ResumeLayout(false);
            this.pnButtonMenu.ResumeLayout(false);
            this.pnLabel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Panel pnContaint;
        public Common.Controls.GradientPanel pnLabel;
        public TPH.LIS.Common.Controls.CustomButton btnClose;
        public System.Windows.Forms.Label lblMainESC;
        public System.Windows.Forms.Panel pnMenu;
        private System.Windows.Forms.Panel pnButtonMenu;
        private System.Windows.Forms.Button btnThuNhoMenu;
        private System.Windows.Forms.ImageList imgLMenu;
        private System.Windows.Forms.Panel pnR;
        private System.Windows.Forms.Panel pnL;
    }
}