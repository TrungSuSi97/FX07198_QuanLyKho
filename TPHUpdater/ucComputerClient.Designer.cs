namespace TPH.LabIMS.Updater
{
    partial class ucComputerClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucComputerClient));
            this.Version = new System.Windows.Forms.Label();
            this.lblversion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenMayTinh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtThoiGianTruyCap = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnDetailOfFile = new TPH.Controls.TPHNormalButton();
            this.btnYeuCauCapNhat = new TPH.Controls.TPHNormalButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Version
            // 
            this.Version.AutoSize = true;
            this.Version.Location = new System.Drawing.Point(76, 1);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(55, 16);
            this.Version.TabIndex = 1;
            this.Version.Text = "Version";
            // 
            // lblversion
            // 
            this.lblversion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblversion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblversion.Location = new System.Drawing.Point(77, 18);
            this.lblversion.Name = "lblversion";
            this.lblversion.Size = new System.Drawing.Size(88, 41);
            this.lblversion.TabIndex = 2;
            this.lblversion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tên máy tính";
            // 
            // txtTenMayTinh
            // 
            this.txtTenMayTinh.Location = new System.Drawing.Point(4, 81);
            this.txtTenMayTinh.Name = "txtTenMayTinh";
            this.txtTenMayTinh.ReadOnly = true;
            this.txtTenMayTinh.Size = new System.Drawing.Size(161, 23);
            this.txtTenMayTinh.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Truy cập gần nhất";
            // 
            // txtThoiGianTruyCap
            // 
            this.txtThoiGianTruyCap.Location = new System.Drawing.Point(4, 127);
            this.txtThoiGianTruyCap.Name = "txtThoiGianTruyCap";
            this.txtThoiGianTruyCap.ReadOnly = true;
            this.txtThoiGianTruyCap.Size = new System.Drawing.Size(161, 23);
            this.txtThoiGianTruyCap.TabIndex = 7;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Normal");
            this.imageList1.Images.SetKeyName(1, "Waiting");
            this.imageList1.Images.SetKeyName(2, "Old");
            this.imageList1.Images.SetKeyName(3, "Ok");
            // 
            // btnDetailOfFile
            // 
            this.btnDetailOfFile.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetailOfFile.Location = new System.Drawing.Point(139, 59);
            this.btnDetailOfFile.Name = "btnDetailOfFile";
            this.btnDetailOfFile.Size = new System.Drawing.Size(26, 21);
            this.btnDetailOfFile.TabIndex = 9;
            this.btnDetailOfFile.Text = "...";
            this.btnDetailOfFile.UseVisualStyleBackColor = true;
            this.btnDetailOfFile.Click += new System.EventHandler(this.btnDetailOfFile_Click);
            // 
            // btnYeuCauCapNhat
            // 
            this.btnYeuCauCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYeuCauCapNhat.Image = ((System.Drawing.Image)(resources.GetObject("btnYeuCauCapNhat.Image")));
            this.btnYeuCauCapNhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnYeuCauCapNhat.Location = new System.Drawing.Point(17, 152);
            this.btnYeuCauCapNhat.Name = "btnYeuCauCapNhat";
            this.btnYeuCauCapNhat.Size = new System.Drawing.Size(134, 29);
            this.btnYeuCauCapNhat.TabIndex = 8;
            this.btnYeuCauCapNhat.Text = "Yêu cầu cập nhật";
            this.btnYeuCauCapNhat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnYeuCauCapNhat.UseVisualStyleBackColor = true;
            this.btnYeuCauCapNhat.Click += new System.EventHandler(this.btnYeuCauCapNhat_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ucComputerClient
            // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnDetailOfFile);
            this.Controls.Add(this.btnYeuCauCapNhat);
            this.Controls.Add(this.txtThoiGianTruyCap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTenMayTinh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblversion);
            this.Controls.Add(this.Version);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucComputerClient";
            this.Size = new System.Drawing.Size(169, 187);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Version;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private TPH.Controls.TPHNormalButton btnYeuCauCapNhat;
        public System.Windows.Forms.Label lblversion;
        public System.Windows.Forms.TextBox txtTenMayTinh;
        public System.Windows.Forms.TextBox txtThoiGianTruyCap;
        private System.Windows.Forms.ImageList imageList1;
        private TPH.Controls.TPHNormalButton btnDetailOfFile;
    }
}
