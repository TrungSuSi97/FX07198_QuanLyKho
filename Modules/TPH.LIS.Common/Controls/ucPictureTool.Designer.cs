namespace TPH.LIS.Common.Controls
{
    partial class ucPictureTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPictureTool));
            this.pnPicture1 = new System.Windows.Forms.Panel();
            this.pbHinhKetQua = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnThemHinh = new TPH.Controls.TPHNormalButton();
            this.btnZoom = new TPH.Controls.TPHNormalButton();
            this.btnXoaHinh = new TPH.Controls.TPHNormalButton();
            this.btnPaste = new TPH.Controls.TPHNormalButton();
            this.pnPicture1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHinhKetQua)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnPicture1
            // 
            this.pnPicture1.Controls.Add(this.pbHinhKetQua);
            this.pnPicture1.Controls.Add(this.panel2);
            this.pnPicture1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPicture1.Location = new System.Drawing.Point(0, 0);
            this.pnPicture1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnPicture1.Name = "pnPicture1";
            this.pnPicture1.Size = new System.Drawing.Size(252, 167);
            this.pnPicture1.TabIndex = 6;
            // 
            // pbHinhKetQua
            // 
            this.pbHinhKetQua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbHinhKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbHinhKetQua.Location = new System.Drawing.Point(0, 0);
            this.pbHinhKetQua.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pbHinhKetQua.Name = "pbHinhKetQua";
            this.pbHinhKetQua.Size = new System.Drawing.Size(222, 167);
            this.pbHinhKetQua.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbHinhKetQua.TabIndex = 4;
            this.pbHinhKetQua.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnThemHinh);
            this.panel2.Controls.Add(this.btnZoom);
            this.panel2.Controls.Add(this.btnXoaHinh);
            this.panel2.Controls.Add(this.btnPaste);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(222, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(30, 167);
            this.panel2.TabIndex = 97;
            // 
            // btnThemHinh
            // 
            this.btnThemHinh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThemHinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnThemHinh.BackColorHover = System.Drawing.Color.Empty;
            this.btnThemHinh.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnThemHinh.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThemHinh.BorderRadius = 5;
            this.btnThemHinh.BorderSize = 1;
            this.btnThemHinh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemHinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemHinh.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemHinh.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThemHinh.ForeColor = System.Drawing.Color.Black;
            this.btnThemHinh.Image = ((System.Drawing.Image)(resources.GetObject("btnThemHinh.Image")));
            this.btnThemHinh.Location = new System.Drawing.Point(2, 26);
            this.btnThemHinh.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnThemHinh.Name = "btnThemHinh";
            this.btnThemHinh.Size = new System.Drawing.Size(25, 24);
            this.btnThemHinh.TabIndex = 0;
            this.btnThemHinh.TextColor = System.Drawing.Color.Black;
            this.btnThemHinh.UseHightLight = true;
            this.btnThemHinh.UseVisualStyleBackColor = true;
            this.btnThemHinh.Click += new System.EventHandler(this.btnThemHinh_Click);
            // 
            // btnZoom
            // 
            this.btnZoom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnZoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnZoom.BackColorHover = System.Drawing.Color.Empty;
            this.btnZoom.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnZoom.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnZoom.BorderRadius = 5;
            this.btnZoom.BorderSize = 1;
            this.btnZoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoom.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoom.ForceColorHover = System.Drawing.Color.Empty;
            this.btnZoom.ForeColor = System.Drawing.Color.Black;
            this.btnZoom.Image = ((System.Drawing.Image)(resources.GetObject("btnZoom.Image")));
            this.btnZoom.Location = new System.Drawing.Point(2, 113);
            this.btnZoom.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Size = new System.Drawing.Size(25, 24);
            this.btnZoom.TabIndex = 3;
            this.btnZoom.TextColor = System.Drawing.Color.Black;
            this.btnZoom.UseHightLight = true;
            this.btnZoom.UseVisualStyleBackColor = true;
            this.btnZoom.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // btnXoaHinh
            // 
            this.btnXoaHinh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXoaHinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnXoaHinh.BackColorHover = System.Drawing.Color.Empty;
            this.btnXoaHinh.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnXoaHinh.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXoaHinh.BorderRadius = 5;
            this.btnXoaHinh.BorderSize = 1;
            this.btnXoaHinh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaHinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaHinh.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaHinh.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXoaHinh.ForeColor = System.Drawing.Color.Black;
            this.btnXoaHinh.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaHinh.Image")));
            this.btnXoaHinh.Location = new System.Drawing.Point(2, 84);
            this.btnXoaHinh.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnXoaHinh.Name = "btnXoaHinh";
            this.btnXoaHinh.Size = new System.Drawing.Size(25, 24);
            this.btnXoaHinh.TabIndex = 1;
            this.btnXoaHinh.TextColor = System.Drawing.Color.Black;
            this.btnXoaHinh.UseHightLight = true;
            this.btnXoaHinh.UseVisualStyleBackColor = true;
            this.btnXoaHinh.Click += new System.EventHandler(this.btnXoaHinh_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPaste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnPaste.BackColorHover = System.Drawing.Color.Empty;
            this.btnPaste.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnPaste.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnPaste.BorderRadius = 5;
            this.btnPaste.BorderSize = 1;
            this.btnPaste.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaste.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaste.ForceColorHover = System.Drawing.Color.Empty;
            this.btnPaste.ForeColor = System.Drawing.Color.Black;
            this.btnPaste.Image = ((System.Drawing.Image)(resources.GetObject("btnPaste.Image")));
            this.btnPaste.Location = new System.Drawing.Point(2, 55);
            this.btnPaste.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(25, 24);
            this.btnPaste.TabIndex = 2;
            this.btnPaste.TextColor = System.Drawing.Color.Black;
            this.btnPaste.UseHightLight = true;
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // ucPictureTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pnPicture1);
            this.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.Name = "ucPictureTool";
            this.Size = new System.Drawing.Size(252, 167);
            this.pnPicture1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHinhKetQua)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnPicture1;
        private System.Windows.Forms.PictureBox pbHinhKetQua;
        private System.Windows.Forms.Panel panel2;
        private TPH.Controls.TPHNormalButton btnThemHinh;
        private TPH.Controls.TPHNormalButton btnZoom;
        private TPH.Controls.TPHNormalButton btnXoaHinh;
        private TPH.Controls.TPHNormalButton btnPaste;
    }
}
