namespace TPH.LIS.Analyzer.Controls
{
    partial class ucCoCanhBaoTuMayTheoSeq
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCoCanhBaoTuMayTheoSeq));
            this.pnDanhSachMay = new System.Windows.Forms.Panel();
            this.ucCoCanhBaoTheoMay1 = new TPH.LIS.Analyzer.Controls.ucCoCanhBaoTheoMay();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUpdateDaXem = new TPH.Controls.TPHNormalButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblbarcode = new System.Windows.Forms.Label();
            this.pnDanhSachMay.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnDanhSachMay
            // 
            this.pnDanhSachMay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnDanhSachMay.Controls.Add(this.ucCoCanhBaoTheoMay1);
            this.pnDanhSachMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDanhSachMay.Location = new System.Drawing.Point(0, 35);
            this.pnDanhSachMay.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnDanhSachMay.Name = "pnDanhSachMay";
            this.pnDanhSachMay.Size = new System.Drawing.Size(235, 1);
            this.pnDanhSachMay.TabIndex = 0;
            // 
            // ucCoCanhBaoTheoMay1
            // 
            this.ucCoCanhBaoTheoMay1.AutoSize = true;
            this.ucCoCanhBaoTheoMay1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucCoCanhBaoTheoMay1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucCoCanhBaoTheoMay1.Location = new System.Drawing.Point(0, 0);
            this.ucCoCanhBaoTheoMay1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.ucCoCanhBaoTheoMay1.Name = "ucCoCanhBaoTheoMay1";
            this.ucCoCanhBaoTheoMay1.Size = new System.Drawing.Size(235, 31);
            this.ucCoCanhBaoTheoMay1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.btnUpdateDaXem);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblbarcode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(235, 35);
            this.panel2.TabIndex = 0;
            // 
            // btnUpdateDaXem
            // 
            this.btnUpdateDaXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateDaXem.BackColor = System.Drawing.Color.Orange;
            this.btnUpdateDaXem.BackColorHover = System.Drawing.Color.Empty;
            this.btnUpdateDaXem.BackgroundColor = System.Drawing.Color.Orange;
            this.btnUpdateDaXem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdateDaXem.BackgroundImage")));
            this.btnUpdateDaXem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUpdateDaXem.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdateDaXem.BorderRadius = 5;
            this.btnUpdateDaXem.BorderSize = 1;
            this.btnUpdateDaXem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateDaXem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateDaXem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateDaXem.ForceColorHover = System.Drawing.Color.Empty;
            this.btnUpdateDaXem.ForeColor = System.Drawing.Color.Black;
            this.btnUpdateDaXem.Location = new System.Drawing.Point(3, 3);
            this.btnUpdateDaXem.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnUpdateDaXem.Name = "btnUpdateDaXem";
            this.btnUpdateDaXem.Size = new System.Drawing.Size(34, 28);
            this.btnUpdateDaXem.TabIndex = 2;
            this.btnUpdateDaXem.TextColor = System.Drawing.Color.Black;
            this.btnUpdateDaXem.UseHightLight = true;
            this.btnUpdateDaXem.UseVisualStyleBackColor = false;
            this.btnUpdateDaXem.Click += new System.EventHandler(this.btnUpdateDaXem_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 6);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label1.Size = new System.Drawing.Size(82, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "BARCODE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Visible = false;
            // 
            // lblbarcode
            // 
            this.lblbarcode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblbarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblbarcode.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbarcode.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblbarcode.Location = new System.Drawing.Point(0, 0);
            this.lblbarcode.Name = "lblbarcode";
            this.lblbarcode.Padding = new System.Windows.Forms.Padding(2);
            this.lblbarcode.Size = new System.Drawing.Size(235, 35);
            this.lblbarcode.TabIndex = 1;
            this.lblbarcode.Text = "123456789012345";
            this.lblbarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblbarcode.Visible = false;
            // 
            // ucCoCanhBaoTuMayTheoSeq
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.pnDanhSachMay);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.Name = "ucCoCanhBaoTuMayTheoSeq";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.Size = new System.Drawing.Size(235, 38);
            this.pnDanhSachMay.ResumeLayout(false);
            this.pnDanhSachMay.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnDanhSachMay;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblbarcode;
        private System.Windows.Forms.Label label1;
        private ucCoCanhBaoTheoMay ucCoCanhBaoTheoMay1;
        private TPH.Controls.TPHNormalButton btnUpdateDaXem;
    }
}
