﻿using TPH.LIS.Common;

namespace TPH.LIS.App
{
    partial class FrmMessageBox_Process
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMessageBox_Process));
            this.lblMsg = new DevExpress.XtraEditors.LabelControl();
            this.proBar = new System.Windows.Forms.ProgressBar();
            this.lblDoing = new DevExpress.XtraEditors.LabelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.btnOK = new TPH.Controls.TPHNormalButton();
            this.lblList = new DevExpress.XtraEditors.LabelControl();
            this.lblPercent = new DevExpress.XtraEditors.LabelControl();
            this.lblStepWorking = new DevExpress.XtraEditors.LabelControl();
            this.lblTime = new DevExpress.XtraEditors.LabelControl();
            this.txtList = new System.Windows.Forms.TextBox();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.btnMinimumsize = new TPH.Controls.TPHNormalButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMsg.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.Appearance.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblMsg.Appearance.Options.UseBackColor = true;
            this.lblMsg.Appearance.Options.UseFont = true;
            this.lblMsg.Appearance.Options.UseForeColor = true;
            this.lblMsg.Location = new System.Drawing.Point(14, 48);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(42, 18);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "label1";
            // 
            // proBar
            // 
            this.proBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.proBar.Location = new System.Drawing.Point(23, 171);
            this.proBar.Name = "proBar";
            this.proBar.Size = new System.Drawing.Size(379, 23);
            this.proBar.TabIndex = 3;
            // 
            // lblDoing
            // 
            this.lblDoing.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblDoing.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblDoing.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoing.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.lblDoing.Appearance.Options.UseBackColor = true;
            this.lblDoing.Appearance.Options.UseFont = true;
            this.lblDoing.Appearance.Options.UseForeColor = true;
            this.lblDoing.Location = new System.Drawing.Point(3, 137);
            this.lblDoing.Name = "lblDoing";
            this.lblDoing.Size = new System.Drawing.Size(64, 16);
            this.lblDoing.TabIndex = 4;
            this.lblDoing.Text = "Tiến trình:";
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Appearance.Options.UseBackColor = true;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitle.Location = new System.Drawing.Point(37, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(95, 19);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "TPH.LabIMS";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnOK.BackColorHover = System.Drawing.Color.Empty;
            this.btnOK.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.btnOK.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnOK.BorderRadius = 5;
            this.btnOK.BorderSize = 1;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForceColorHover = System.Drawing.Color.Empty;
            this.btnOK.ForeColor = System.Drawing.Color.Black;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(169, 169);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(76, 28);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "Đồng ý";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.TextColor = System.Drawing.Color.Black;
            this.btnOK.UseHightLight = true;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblList
            // 
            this.lblList.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblList.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblList.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblList.Appearance.Options.UseBackColor = true;
            this.lblList.Appearance.Options.UseFont = true;
            this.lblList.Appearance.Options.UseForeColor = true;
            this.lblList.Location = new System.Drawing.Point(19, 44);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(65, 21);
            this.lblList.TabIndex = 9;
            this.lblList.Text = "Message";
            this.lblList.Visible = false;
            // 
            // lblPercent
            // 
            this.lblPercent.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPercent.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblPercent.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercent.Appearance.ForeColor = System.Drawing.Color.Sienna;
            this.lblPercent.Appearance.Options.UseBackColor = true;
            this.lblPercent.Appearance.Options.UseFont = true;
            this.lblPercent.Appearance.Options.UseForeColor = true;
            this.lblPercent.Location = new System.Drawing.Point(13, 153);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(33, 15);
            this.lblPercent.TabIndex = 10;
            this.lblPercent.Text = "100 %";
            // 
            // lblStepWorking
            // 
            this.lblStepWorking.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblStepWorking.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblStepWorking.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStepWorking.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStepWorking.Appearance.Options.UseBackColor = true;
            this.lblStepWorking.Appearance.Options.UseFont = true;
            this.lblStepWorking.Appearance.Options.UseForeColor = true;
            this.lblStepWorking.Location = new System.Drawing.Point(74, 137);
            this.lblStepWorking.Name = "lblStepWorking";
            this.lblStepWorking.Size = new System.Drawing.Size(25, 16);
            this.lblStepWorking.TabIndex = 11;
            this.lblStepWorking.Text = "step";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Appearance.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lblTime.Appearance.Options.UseBackColor = true;
            this.lblTime.Appearance.Options.UseFont = true;
            this.lblTime.Appearance.Options.UseForeColor = true;
            this.lblTime.Location = new System.Drawing.Point(375, 194);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 12);
            this.lblTime.TabIndex = 12;
            // 
            // txtList
            // 
            this.txtList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtList.BackColor = System.Drawing.Color.White;
            this.txtList.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtList.Location = new System.Drawing.Point(24, 68);
            this.txtList.Multiline = true;
            this.txtList.Name = "txtList";
            this.txtList.Size = new System.Drawing.Size(382, 70);
            this.txtList.TabIndex = 8;
            this.txtList.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Appearance.Options.UseBackColor = true;
            this.panel1.Controls.Add(this.btnMinimumsize);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 33);
            this.panel1.TabIndex = 13;
            // 
            // btnMinimumsize
            // 
            this.btnMinimumsize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimumsize.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnMinimumsize.BackColorHover = System.Drawing.Color.Empty;
            this.btnMinimumsize.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.btnMinimumsize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMinimumsize.BackgroundImage")));
            this.btnMinimumsize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimumsize.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnMinimumsize.BorderRadius = 5;
            this.btnMinimumsize.BorderSize = 1;
            this.btnMinimumsize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimumsize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimumsize.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimumsize.ForceColorHover = System.Drawing.Color.Empty;
            this.btnMinimumsize.ForeColor = System.Drawing.Color.DarkRed;
            this.btnMinimumsize.Location = new System.Drawing.Point(395, -1);
            this.btnMinimumsize.Name = "btnMinimumsize";
            this.btnMinimumsize.Size = new System.Drawing.Size(22, 22);
            this.btnMinimumsize.TabIndex = 6;
            this.btnMinimumsize.Text = "-";
            this.btnMinimumsize.TextColor = System.Drawing.Color.DarkRed;
            this.btnMinimumsize.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnMinimumsize.UseHightLight = true;
            this.btnMinimumsize.UseVisualStyleBackColor = true;
            this.btnMinimumsize.Visible = false;
            this.btnMinimumsize.Click += new System.EventHandler(this.btnMinimumsize_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 29);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FrmMessageBox_Process
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(420, 209);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblStepWorking);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.lblDoing);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblList);
            this.Controls.Add(this.txtList);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.proBar);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmMessageBox_Process";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMessageBox_Process_FormClosing);
            this.Load += new System.EventHandler(this.FrmMessageBox_Load);
            this.Shown += new System.EventHandler(this.FrmMessageBox_Process_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ProgressBar proBar;
        public DevExpress.XtraEditors.LabelControl lblDoing;
        public TPH.Controls.TPHNormalButton btnOK;
        public System.Windows.Forms.TextBox txtList;
        public DevExpress.XtraEditors.LabelControl lblList;
        public DevExpress.XtraEditors.LabelControl lblMsg;
        private TPH.Controls.TPHNormalButton btnMinimumsize;
        public DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblPercent;
        public DevExpress.XtraEditors.LabelControl lblStepWorking;
        public DevExpress.XtraEditors.LabelControl lblTime;
        private DevExpress.XtraEditors.PanelControl panel1;
    }
}