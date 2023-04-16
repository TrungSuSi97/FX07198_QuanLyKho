using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.CauHinh.HeThong
{
    partial class frmConfigVideoDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigVideoDevice));
            this.cboFramRate = new System.Windows.Forms.ComboBox();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.cboSignalSource = new System.Windows.Forms.ComboBox();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.btnSaveConfig = new TPH.Controls.TPHNormalButton();
            this.cboVideostandard = new System.Windows.Forms.ComboBox();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.lstDeviceList = new System.Windows.Forms.ListView();
            this.lsDeviceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnVideo = new DevExpress.XtraEditors.PanelControl();
            this.btnStart = new TPH.Controls.TPHNormalButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSnapshot = new TPH.Controls.TPHNormalButton();
            this.chkAutoCofig = new System.Windows.Forms.CheckBox();
            this.chkWebcam = new System.Windows.Forms.CheckBox();
            this.cboFrameSize = new System.Windows.Forms.ComboBox();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.cboVideoCompressor = new System.Windows.Forms.ComboBox();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.btnCapture = new TPH.Controls.TPHNormalButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.wmpPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.label6 = new DevExpress.XtraEditors.LabelControl();
            this.cboDeviceAlias = new TPH.LIS.Common.Controls.CustomComboBox();
            this.label7 = new DevExpress.XtraEditors.LabelControl();
            this.txtRecordPath = new System.Windows.Forms.TextBox();
            this.cboCategory = new TPH.LIS.Common.Controls.CustomComboBox();
            this.label8 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radNoiSoi = new System.Windows.Forms.RadioButton();
            this.radSieuAm = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnContaint)).BeginInit();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnMenu)).BeginInit();
            this.pnMenu.SuspendLayout();
            this.xtraScrollableControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnFormControl)).BeginInit();
            this.pnFormControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmpPlayer)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblTitle.Appearance.Options.UseBackColor = true;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(310, 21);
            this.lblTitle.Text = "CẤU HÌNH CHO THIẾT BỊ BẮT HÌNH ẢNH";
            // 
            // pnContaint
            // 
            this.pnContaint.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnContaint.Appearance.Options.UseBackColor = true;
            this.pnContaint.Controls.Add(this.groupBox1);
            this.pnContaint.Controls.Add(this.cboCategory);
            this.pnContaint.Controls.Add(this.label8);
            this.pnContaint.Controls.Add(this.txtRecordPath);
            this.pnContaint.Controls.Add(this.label7);
            this.pnContaint.Controls.Add(this.cboDeviceAlias);
            this.pnContaint.Controls.Add(this.label6);
            this.pnContaint.Controls.Add(this.wmpPlayer);
            this.pnContaint.Controls.Add(this.pictureBox4);
            this.pnContaint.Controls.Add(this.pictureBox3);
            this.pnContaint.Controls.Add(this.pictureBox2);
            this.pnContaint.Controls.Add(this.btnCapture);
            this.pnContaint.Controls.Add(this.cboVideoCompressor);
            this.pnContaint.Controls.Add(this.label5);
            this.pnContaint.Controls.Add(this.cboFrameSize);
            this.pnContaint.Controls.Add(this.label2);
            this.pnContaint.Controls.Add(this.chkWebcam);
            this.pnContaint.Controls.Add(this.chkAutoCofig);
            this.pnContaint.Controls.Add(this.btnSnapshot);
            this.pnContaint.Controls.Add(this.pictureBox1);
            this.pnContaint.Controls.Add(this.pnVideo);
            this.pnContaint.Controls.Add(this.btnStart);
            this.pnContaint.Controls.Add(this.cboFramRate);
            this.pnContaint.Controls.Add(this.label4);
            this.pnContaint.Controls.Add(this.cboSignalSource);
            this.pnContaint.Controls.Add(this.label3);
            this.pnContaint.Controls.Add(this.btnSaveConfig);
            this.pnContaint.Controls.Add(this.cboVideostandard);
            this.pnContaint.Controls.Add(this.label1);
            this.pnContaint.Controls.Add(this.lstDeviceList);
            this.pnContaint.Location = new System.Drawing.Point(0, 53);
            this.pnContaint.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnContaint.Size = new System.Drawing.Size(758, 371);
            // 
            // pnLabel
            // 
            this.pnLabel.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnLabel.Size = new System.Drawing.Size(758, 27);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Crimson;
            this.btnClose.Location = new System.Drawing.Point(406, 0);
            this.btnClose.Size = new System.Drawing.Size(29, 27);
            this.btnClose.TextColor = System.Drawing.Color.Crimson;
            // 
            // lblMainESC
            // 
            this.lblMainESC.Appearance.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainESC.Appearance.Options.UseFont = true;
            this.lblMainESC.ImageOptions.Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lblMainESC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblMainESC.ImageOptions.Image")));
            this.lblMainESC.Location = new System.Drawing.Point(435, 0);
            // 
            // pnMenu
            // 
            this.pnMenu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnMenu.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnMenu.Appearance.Options.UseBackColor = true;
            this.pnMenu.Location = new System.Drawing.Point(0, 27);
            this.pnMenu.Size = new System.Drawing.Size(758, 26);
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.xtraScrollableControlMain.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(758, 25);
            // 
            // ucGroupHeaderChonMain
            // 
            this.ucGroupHeaderChonMain.Location = new System.Drawing.Point(312, 1);
            this.ucGroupHeaderChonMain.Size = new System.Drawing.Size(10, 24);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnFormControl.Appearance.Options.UseBackColor = true;
            this.pnFormControl.Location = new System.Drawing.Point(650, 1);
            this.pnFormControl.Size = new System.Drawing.Size(106, 24);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(171)))), ((int)(((byte)(203)))));
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(160)))), ((int)(((byte)(190)))));
            // 
            // btnMaximize
            // 
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(141)))), ((int)(((byte)(233)))));
            this.btnMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(132)))), ((int)(((byte)(218)))));
            // 
            // tphIconButton1
            // 
            this.tphIconButton1.FlatAppearance.BorderSize = 0;
            this.tphIconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(87)))), ((int)(((byte)(125)))));
            this.tphIconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(81)))), ((int)(((byte)(117)))));
            // 
            // cboFramRate
            // 
            this.cboFramRate.FormattingEnabled = true;
            this.cboFramRate.Location = new System.Drawing.Point(106, 184);
            this.cboFramRate.Name = "cboFramRate";
            this.cboFramRate.Size = new System.Drawing.Size(104, 21);
            this.cboFramRate.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(21, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Tần số khung";
            // 
            // cboSignalSource
            // 
            this.cboSignalSource.FormattingEnabled = true;
            this.cboSignalSource.Location = new System.Drawing.Point(106, 135);
            this.cboSignalSource.Name = "cboSignalSource";
            this.cboSignalSource.Size = new System.Drawing.Size(104, 21);
            this.cboSignalSource.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(21, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Ngõ vào";
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveConfig.BackColorHover = System.Drawing.Color.Empty;
            this.btnSaveConfig.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnSaveConfig.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnSaveConfig.BorderRadius = 5;
            this.btnSaveConfig.BorderSize = 1;
            this.btnSaveConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveConfig.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveConfig.ForceColorHover = System.Drawing.Color.Empty;
            this.btnSaveConfig.ForeColor = System.Drawing.Color.Black;
            this.btnSaveConfig.Location = new System.Drawing.Point(134, 296);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(77, 20);
            this.btnSaveConfig.TabIndex = 18;
            this.btnSaveConfig.Text = "Lưu cấu hình";
            this.btnSaveConfig.TextColor = System.Drawing.Color.Black;
            this.btnSaveConfig.UseHightLight = true;
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // cboVideostandard
            // 
            this.cboVideostandard.FormattingEnabled = true;
            this.cboVideostandard.Location = new System.Drawing.Point(106, 110);
            this.cboVideostandard.Name = "cboVideostandard";
            this.cboVideostandard.Size = new System.Drawing.Size(104, 21);
            this.cboVideostandard.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(21, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Chuẩn video";
            // 
            // lstDeviceList
            // 
            this.lstDeviceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lsDeviceName});
            this.lstDeviceList.FullRowSelect = true;
            this.lstDeviceList.GridLines = true;
            this.lstDeviceList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstDeviceList.HideSelection = false;
            this.lstDeviceList.Location = new System.Drawing.Point(20, 42);
            this.lstDeviceList.MultiSelect = false;
            this.lstDeviceList.Name = "lstDeviceList";
            this.lstDeviceList.Size = new System.Drawing.Size(192, 65);
            this.lstDeviceList.TabIndex = 15;
            this.lstDeviceList.UseCompatibleStateImageBehavior = false;
            this.lstDeviceList.View = System.Windows.Forms.View.Details;
            this.lstDeviceList.SelectedIndexChanged += new System.EventHandler(this.lstDeviceList_SelectedIndexChanged);
            // 
            // lsDeviceName
            // 
            this.lsDeviceName.Text = "Tên thiết bị";
            this.lsDeviceName.Width = 250;
            // 
            // pnVideo
            // 
            this.pnVideo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pnVideo.Location = new System.Drawing.Point(223, 5);
            this.pnVideo.Name = "pnVideo";
            this.pnVideo.Size = new System.Drawing.Size(269, 196);
            this.pnVideo.TabIndex = 24;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.BackColorHover = System.Drawing.Color.Empty;
            this.btnStart.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnStart.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnStart.BorderRadius = 5;
            this.btnStart.BorderSize = 1;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForceColorHover = System.Drawing.Color.Empty;
            this.btnStart.ForeColor = System.Drawing.Color.Black;
            this.btnStart.Location = new System.Drawing.Point(222, 207);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(83, 21);
            this.btnStart.TabIndex = 23;
            this.btnStart.Text = "Preview";
            this.btnStart.TextColor = System.Drawing.Color.Black;
            this.btnStart.UseHightLight = true;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(501, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 92);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // btnSnapshot
            // 
            this.btnSnapshot.BackColor = System.Drawing.Color.Transparent;
            this.btnSnapshot.BackColorHover = System.Drawing.Color.Empty;
            this.btnSnapshot.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnSnapshot.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnSnapshot.BorderRadius = 5;
            this.btnSnapshot.BorderSize = 1;
            this.btnSnapshot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSnapshot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSnapshot.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnapshot.ForceColorHover = System.Drawing.Color.Empty;
            this.btnSnapshot.ForeColor = System.Drawing.Color.Black;
            this.btnSnapshot.Location = new System.Drawing.Point(408, 207);
            this.btnSnapshot.Name = "btnSnapshot";
            this.btnSnapshot.Size = new System.Drawing.Size(83, 21);
            this.btnSnapshot.TabIndex = 26;
            this.btnSnapshot.Text = "Shot";
            this.btnSnapshot.TextColor = System.Drawing.Color.Black;
            this.btnSnapshot.UseHightLight = true;
            this.btnSnapshot.UseVisualStyleBackColor = true;
            this.btnSnapshot.Click += new System.EventHandler(this.btnSnapshot_Click);
            // 
            // chkAutoCofig
            // 
            this.chkAutoCofig.AutoSize = true;
            this.chkAutoCofig.Location = new System.Drawing.Point(21, 276);
            this.chkAutoCofig.Name = "chkAutoCofig";
            this.chkAutoCofig.Size = new System.Drawing.Size(168, 17);
            this.chkAutoCofig.TabIndex = 27;
            this.chkAutoCofig.Text = "Tự lưu cấu hình khi khởi động";
            this.chkAutoCofig.UseVisualStyleBackColor = true;
            this.chkAutoCofig.Visible = false;
            this.chkAutoCofig.CheckedChanged += new System.EventHandler(this.chkAutoCofig_CheckedChanged);
            this.chkAutoCofig.Click += new System.EventHandler(this.chkAutoCofig_Click);
            // 
            // chkWebcam
            // 
            this.chkWebcam.AutoSize = true;
            this.chkWebcam.Location = new System.Drawing.Point(21, 299);
            this.chkWebcam.Name = "chkWebcam";
            this.chkWebcam.Size = new System.Drawing.Size(111, 17);
            this.chkWebcam.TabIndex = 28;
            this.chkWebcam.Text = "Cấu hình webcam";
            this.chkWebcam.UseVisualStyleBackColor = true;
            this.chkWebcam.CheckedChanged += new System.EventHandler(this.chkWebcam_CheckedChanged);
            // 
            // cboFrameSize
            // 
            this.cboFrameSize.FormattingEnabled = true;
            this.cboFrameSize.Location = new System.Drawing.Point(106, 207);
            this.cboFrameSize.Name = "cboFrameSize";
            this.cboFrameSize.Size = new System.Drawing.Size(104, 21);
            this.cboFrameSize.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(21, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Khung hình";
            // 
            // cboVideoCompressor
            // 
            this.cboVideoCompressor.FormattingEnabled = true;
            this.cboVideoCompressor.Location = new System.Drawing.Point(106, 159);
            this.cboVideoCompressor.Name = "cboVideoCompressor";
            this.cboVideoCompressor.Size = new System.Drawing.Size(104, 21);
            this.cboVideoCompressor.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(21, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Bộ mã nén";
            // 
            // btnCapture
            // 
            this.btnCapture.BackColor = System.Drawing.Color.Transparent;
            this.btnCapture.BackColorHover = System.Drawing.Color.Empty;
            this.btnCapture.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnCapture.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnCapture.BorderRadius = 5;
            this.btnCapture.BorderSize = 1;
            this.btnCapture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapture.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapture.ForceColorHover = System.Drawing.Color.Empty;
            this.btnCapture.ForeColor = System.Drawing.Color.Black;
            this.btnCapture.Location = new System.Drawing.Point(315, 207);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(83, 21);
            this.btnCapture.TabIndex = 33;
            this.btnCapture.Text = "Record";
            this.btnCapture.TextColor = System.Drawing.Color.Black;
            this.btnCapture.UseHightLight = true;
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(631, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(125, 92);
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(501, 101);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(125, 92);
            this.pictureBox3.TabIndex = 35;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(631, 101);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(125, 92);
            this.pictureBox4.TabIndex = 36;
            this.pictureBox4.TabStop = false;
            // 
            // wmpPlayer
            // 
            this.wmpPlayer.Enabled = true;
            this.wmpPlayer.Location = new System.Drawing.Point(585, 318);
            this.wmpPlayer.Name = "wmpPlayer";
            this.wmpPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmpPlayer.OcxState")));
            this.wmpPlayer.Size = new System.Drawing.Size(297, 231);
            this.wmpPlayer.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(21, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Máy";
            // 
            // cboDeviceAlias
            // 
            this.cboDeviceAlias.AutoComplete = false;
            this.cboDeviceAlias.AutoDropdown = false;
            this.cboDeviceAlias.BackColorEven = System.Drawing.Color.White;
            this.cboDeviceAlias.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboDeviceAlias.ColumnNames = "";
            this.cboDeviceAlias.ColumnWidthDefault = 75;
            this.cboDeviceAlias.ColumnWidths = "";
            this.cboDeviceAlias.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboDeviceAlias.FormattingEnabled = true;
            this.cboDeviceAlias.LinkedColumnIndex = 0;
            this.cboDeviceAlias.LinkedColumnIndex1 = 0;
            this.cboDeviceAlias.LinkedColumnIndex2 = 0;
            this.cboDeviceAlias.LinkedTextBox = null;
            this.cboDeviceAlias.LinkedTextBox1 = null;
            this.cboDeviceAlias.LinkedTextBox2 = null;
            this.cboDeviceAlias.Location = new System.Drawing.Point(106, 252);
            this.cboDeviceAlias.Name = "cboDeviceAlias";
            this.cboDeviceAlias.Size = new System.Drawing.Size(104, 21);
            this.cboDeviceAlias.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(220, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Đường dẫn lưu thử video";
            // 
            // txtRecordPath
            // 
            this.txtRecordPath.Location = new System.Drawing.Point(223, 246);
            this.txtRecordPath.Name = "txtRecordPath";
            this.txtRecordPath.Size = new System.Drawing.Size(270, 20);
            this.txtRecordPath.TabIndex = 42;
            // 
            // cboCategory
            // 
            this.cboCategory.AutoComplete = false;
            this.cboCategory.AutoDropdown = false;
            this.cboCategory.BackColorEven = System.Drawing.Color.White;
            this.cboCategory.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboCategory.ColumnNames = "";
            this.cboCategory.ColumnWidthDefault = 75;
            this.cboCategory.ColumnWidths = "";
            this.cboCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.LinkedColumnIndex = 0;
            this.cboCategory.LinkedColumnIndex1 = 0;
            this.cboCategory.LinkedColumnIndex2 = 0;
            this.cboCategory.LinkedTextBox = null;
            this.cboCategory.LinkedTextBox1 = null;
            this.cboCategory.LinkedTextBox2 = null;
            this.cboCategory.Location = new System.Drawing.Point(106, 229);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(104, 21);
            this.cboCategory.TabIndex = 44;
            this.cboCategory.SelectionChangeCommitted += new System.EventHandler(this.cboCategory_SelectionChangeCommitted);
            this.cboCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboCategory_KeyPress);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(21, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Nhóm";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radNoiSoi);
            this.groupBox1.Controls.Add(this.radSieuAm);
            this.groupBox1.Location = new System.Drawing.Point(8, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(213, 36);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loại";
            // 
            // radNoiSoi
            // 
            this.radNoiSoi.AutoSize = true;
            this.radNoiSoi.Location = new System.Drawing.Point(73, 14);
            this.radNoiSoi.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.radNoiSoi.Name = "radNoiSoi";
            this.radNoiSoi.Size = new System.Drawing.Size(57, 17);
            this.radNoiSoi.TabIndex = 1;
            this.radNoiSoi.TabStop = true;
            this.radNoiSoi.Text = "Nội soi";
            this.radNoiSoi.UseVisualStyleBackColor = true;
            // 
            // radSieuAm
            // 
            this.radSieuAm.AutoSize = true;
            this.radSieuAm.Checked = true;
            this.radSieuAm.Location = new System.Drawing.Point(5, 14);
            this.radSieuAm.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.radSieuAm.Name = "radSieuAm";
            this.radSieuAm.Size = new System.Drawing.Size(63, 17);
            this.radSieuAm.TabIndex = 0;
            this.radSieuAm.TabStop = true;
            this.radSieuAm.Text = "Siêu âm";
            this.radSieuAm.UseVisualStyleBackColor = true;
            // 
            // frmConfigVideoDevice
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(129)))), ((int)(((byte)(176)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(758, 424);
            this.Name = "frmConfigVideoDevice";
            this.Text = "Cấu hình thiết bị";
            this.Load += new System.EventHandler(this.frmConfigVideoDevice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnContaint)).EndInit();
            this.pnContaint.ResumeLayout(false);
            this.pnContaint.PerformLayout();
            this.pnLabel.ResumeLayout(false);
            this.pnLabel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnMenu)).EndInit();
            this.pnMenu.ResumeLayout(false);
            this.xtraScrollableControlMain.ResumeLayout(false);
            this.xtraScrollableControlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnFormControl)).EndInit();
            this.pnFormControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmpPlayer)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboFramRate;
        private DevExpress.XtraEditors.LabelControl label4;
        private System.Windows.Forms.ComboBox cboSignalSource;
        private DevExpress.XtraEditors.LabelControl label3;
        private TPH.Controls.TPHNormalButton btnSaveConfig;
        private System.Windows.Forms.ComboBox cboVideostandard;
        private DevExpress.XtraEditors.LabelControl label1;
        private System.Windows.Forms.ListView lstDeviceList;
        private System.Windows.Forms.ColumnHeader lsDeviceName;
        private DevExpress.XtraEditors.PanelControl pnVideo;
        private TPH.Controls.TPHNormalButton btnStart;
        private TPH.Controls.TPHNormalButton btnSnapshot;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkAutoCofig;
        private System.Windows.Forms.CheckBox chkWebcam;
        private System.Windows.Forms.ComboBox cboFrameSize;
        private DevExpress.XtraEditors.LabelControl label2;
        private System.Windows.Forms.ComboBox cboVideoCompressor;
        private DevExpress.XtraEditors.LabelControl label5;
        private TPH.Controls.TPHNormalButton btnCapture;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private AxWMPLib.AxWindowsMediaPlayer wmpPlayer;
        private DevExpress.XtraEditors.LabelControl label6;
        private CustomComboBox cboDeviceAlias;
        private System.Windows.Forms.TextBox txtRecordPath;
        private DevExpress.XtraEditors.LabelControl label7;
        private CustomComboBox cboCategory;
        private DevExpress.XtraEditors.LabelControl label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radNoiSoi;
        private System.Windows.Forms.RadioButton radSieuAm;
    }
}