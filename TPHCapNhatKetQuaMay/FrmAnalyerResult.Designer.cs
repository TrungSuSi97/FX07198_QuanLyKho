namespace TPHCapNhatKetQuaMay
{
    partial class FrmAnalyerResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnalyerResult));
            this.lblTitle = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.gbDanhSachMayXN = new System.Windows.Forms.GroupBox();
            this.chkMayXetNghiem = new TPH.LIS.Common.Controls.CustomCheckedListBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.chkAllAnalyzer = new System.Windows.Forms.CheckBox();
            this.chkCapNhat_KetQuaLoi = new System.Windows.Forms.CheckBox();
            this.chkCapNhat_KetChaySau = new System.Windows.Forms.CheckBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.progressBarKetQuaMayTuDong = new System.Windows.Forms.ProgressBar();
            this.timerCount = new System.Windows.Forms.Timer(this.components);
            this.lbl3 = new System.Windows.Forms.Label();
            this.numTgUpload = new System.Windows.Forms.NumericUpDown();
            this.pnDieuKienCapNhat = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.chkDeKetQuaChuaDuyet = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nuGioHanGioKQLoi = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.chkUploadWhenStart = new System.Windows.Forms.CheckBox();
            this.chkMinisizeWihenStartWithWindows = new System.Windows.Forms.CheckBox();
            this.chkStartWithWindows = new System.Windows.Forms.CheckBox();
            this.nuTimeToResume = new System.Windows.Forms.NumericUpDown();
            this.lbl7 = new System.Windows.Forms.Label();
            this.nuTimeToPause = new System.Windows.Forms.NumericUpDown();
            this.lbl6 = new System.Windows.Forms.Label();
            this.numSoNgayCapNhat = new System.Windows.Forms.NumericUpDown();
            this.lbl4 = new System.Windows.Forms.Label();
            this.timerResetUpload = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new TPH.Controls.TPHNormalButton();
            this.btnMinimize = new TPH.Controls.TPHNormalButton();
            this.btnStop = new TPH.Controls.TPHNormalButton();
            this.btnStart = new TPH.Controls.TPHNormalButton();
            this.label2 = new System.Windows.Forms.Label();
            this.chkDanhSachMayKhaiBaoTheoPC = new System.Windows.Forms.CheckBox();
            this.gbDanhSachMayXN.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTgUpload)).BeginInit();
            this.pnDieuKienCapNhat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuGioHanGioKQLoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuTimeToResume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuTimeToPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNgayCapNhat)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(693, 35);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "CẬP NHẬT KẾT QUẢ TỪ MÁY XÉT NGHIỆM";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            this.lblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseMove);
            this.lblTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseUp);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(156, 44);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 16);
            this.label15.TabIndex = 9;
            this.label15.Text = "đến ngày";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(225, 39);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(106, 23);
            this.dtpToDate.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(161, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 16);
            this.label13.TabIndex = 7;
            this.label13.Text = "Từ ngày";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(225, 11);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(106, 23);
            this.dtpFromDate.TabIndex = 6;
            // 
            // gbDanhSachMayXN
            // 
            this.gbDanhSachMayXN.Controls.Add(this.chkMayXetNghiem);
            this.gbDanhSachMayXN.Controls.Add(this.panel9);
            this.gbDanhSachMayXN.Location = new System.Drawing.Point(367, 46);
            this.gbDanhSachMayXN.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.gbDanhSachMayXN.Name = "gbDanhSachMayXN";
            this.gbDanhSachMayXN.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbDanhSachMayXN.Size = new System.Drawing.Size(324, 264);
            this.gbDanhSachMayXN.TabIndex = 10;
            this.gbDanhSachMayXN.TabStop = false;
            this.gbDanhSachMayXN.Text = "Danh sách máy";
            // 
            // chkMayXetNghiem
            // 
            this.chkMayXetNghiem.CheckOnClick = true;
            this.chkMayXetNghiem.DataSource = null;
            this.chkMayXetNghiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkMayXetNghiem.FormattingEnabled = true;
            this.chkMayXetNghiem.Location = new System.Drawing.Point(3, 41);
            this.chkMayXetNghiem.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.chkMayXetNghiem.Name = "chkMayXetNghiem";
            this.chkMayXetNghiem.Size = new System.Drawing.Size(318, 221);
            this.chkMayXetNghiem.TabIndex = 3;
            this.chkMayXetNghiem.Value = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.chkAllAnalyzer);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(3, 18);
            this.panel9.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(318, 23);
            this.panel9.TabIndex = 1;
            // 
            // chkAllAnalyzer
            // 
            this.chkAllAnalyzer.AutoSize = true;
            this.chkAllAnalyzer.Checked = true;
            this.chkAllAnalyzer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllAnalyzer.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllAnalyzer.Location = new System.Drawing.Point(3, 0);
            this.chkAllAnalyzer.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.chkAllAnalyzer.Name = "chkAllAnalyzer";
            this.chkAllAnalyzer.Size = new System.Drawing.Size(154, 19);
            this.chkAllAnalyzer.TabIndex = 0;
            this.chkAllAnalyzer.Text = "Tất cả máy xét nghiệm";
            this.chkAllAnalyzer.UseVisualStyleBackColor = true;
            // 
            // chkCapNhat_KetQuaLoi
            // 
            this.chkCapNhat_KetQuaLoi.AutoSize = true;
            this.chkCapNhat_KetQuaLoi.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCapNhat_KetQuaLoi.Checked = true;
            this.chkCapNhat_KetQuaLoi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCapNhat_KetQuaLoi.Location = new System.Drawing.Point(225, 69);
            this.chkCapNhat_KetQuaLoi.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.chkCapNhat_KetQuaLoi.Name = "chkCapNhat_KetQuaLoi";
            this.chkCapNhat_KetQuaLoi.Size = new System.Drawing.Size(15, 14);
            this.chkCapNhat_KetQuaLoi.TabIndex = 12;
            this.chkCapNhat_KetQuaLoi.UseVisualStyleBackColor = true;
            // 
            // chkCapNhat_KetChaySau
            // 
            this.chkCapNhat_KetChaySau.AutoSize = true;
            this.chkCapNhat_KetChaySau.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCapNhat_KetChaySau.Checked = true;
            this.chkCapNhat_KetChaySau.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCapNhat_KetChaySau.Location = new System.Drawing.Point(225, 89);
            this.chkCapNhat_KetChaySau.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.chkCapNhat_KetChaySau.Name = "chkCapNhat_KetChaySau";
            this.chkCapNhat_KetChaySau.Size = new System.Drawing.Size(15, 14);
            this.chkCapNhat_KetChaySau.TabIndex = 11;
            this.chkCapNhat_KetChaySau.UseVisualStyleBackColor = true;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrangThai.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.Location = new System.Drawing.Point(10, 22);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(300, 76);
            this.lblTrangThai.TabIndex = 16;
            this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBarKetQuaMayTuDong
            // 
            this.progressBarKetQuaMayTuDong.Location = new System.Drawing.Point(10, 102);
            this.progressBarKetQuaMayTuDong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBarKetQuaMayTuDong.Name = "progressBarKetQuaMayTuDong";
            this.progressBarKetQuaMayTuDong.Size = new System.Drawing.Size(300, 13);
            this.progressBarKetQuaMayTuDong.TabIndex = 17;
            this.progressBarKetQuaMayTuDong.Visible = false;
            // 
            // timerCount
            // 
            this.timerCount.Interval = 1000;
            this.timerCount.Tick += new System.EventHandler(this.timerCount_Tick);
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(90, 155);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(126, 16);
            this.lbl3.TabIndex = 18;
            this.lbl3.Text = "Thời gian quét (giây)";
            // 
            // numTgUpload
            // 
            this.numTgUpload.Location = new System.Drawing.Point(225, 152);
            this.numTgUpload.Margin = new System.Windows.Forms.Padding(4);
            this.numTgUpload.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.numTgUpload.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTgUpload.Name = "numTgUpload";
            this.numTgUpload.Size = new System.Drawing.Size(52, 23);
            this.numTgUpload.TabIndex = 20;
            this.numTgUpload.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // pnDieuKienCapNhat
            // 
            this.pnDieuKienCapNhat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnDieuKienCapNhat.Controls.Add(this.label2);
            this.pnDieuKienCapNhat.Controls.Add(this.chkDanhSachMayKhaiBaoTheoPC);
            this.pnDieuKienCapNhat.Controls.Add(this.label1);
            this.pnDieuKienCapNhat.Controls.Add(this.chkDeKetQuaChuaDuyet);
            this.pnDieuKienCapNhat.Controls.Add(this.label6);
            this.pnDieuKienCapNhat.Controls.Add(this.nuGioHanGioKQLoi);
            this.pnDieuKienCapNhat.Controls.Add(this.label5);
            this.pnDieuKienCapNhat.Controls.Add(this.lbl5);
            this.pnDieuKienCapNhat.Controls.Add(this.chkUploadWhenStart);
            this.pnDieuKienCapNhat.Controls.Add(this.chkMinisizeWihenStartWithWindows);
            this.pnDieuKienCapNhat.Controls.Add(this.chkStartWithWindows);
            this.pnDieuKienCapNhat.Controls.Add(this.nuTimeToResume);
            this.pnDieuKienCapNhat.Controls.Add(this.lbl7);
            this.pnDieuKienCapNhat.Controls.Add(this.nuTimeToPause);
            this.pnDieuKienCapNhat.Controls.Add(this.lbl6);
            this.pnDieuKienCapNhat.Controls.Add(this.numSoNgayCapNhat);
            this.pnDieuKienCapNhat.Controls.Add(this.lbl4);
            this.pnDieuKienCapNhat.Controls.Add(this.chkCapNhat_KetQuaLoi);
            this.pnDieuKienCapNhat.Controls.Add(this.numTgUpload);
            this.pnDieuKienCapNhat.Controls.Add(this.chkCapNhat_KetChaySau);
            this.pnDieuKienCapNhat.Controls.Add(this.lbl3);
            this.pnDieuKienCapNhat.Controls.Add(this.label15);
            this.pnDieuKienCapNhat.Controls.Add(this.dtpToDate);
            this.pnDieuKienCapNhat.Controls.Add(this.label13);
            this.pnDieuKienCapNhat.Controls.Add(this.dtpFromDate);
            this.pnDieuKienCapNhat.Location = new System.Drawing.Point(6, 22);
            this.pnDieuKienCapNhat.Name = "pnDieuKienCapNhat";
            this.pnDieuKienCapNhat.Size = new System.Drawing.Size(349, 364);
            this.pnDieuKienCapNhat.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 16);
            this.label1.TabIndex = 37;
            this.label1.Text = "Cập nhật đè kết quả chưa duyệt";
            // 
            // chkDeKetQuaChuaDuyet
            // 
            this.chkDeKetQuaChuaDuyet.AutoSize = true;
            this.chkDeKetQuaChuaDuyet.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDeKetQuaChuaDuyet.Checked = true;
            this.chkDeKetQuaChuaDuyet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDeKetQuaChuaDuyet.Location = new System.Drawing.Point(225, 108);
            this.chkDeKetQuaChuaDuyet.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.chkDeKetQuaChuaDuyet.Name = "chkDeKetQuaChuaDuyet";
            this.chkDeKetQuaChuaDuyet.Size = new System.Drawing.Size(15, 14);
            this.chkDeKetQuaChuaDuyet.TabIndex = 36;
            this.chkDeKetQuaChuaDuyet.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "Lấy kết quả chạy lần sau cùng";
            // 
            // nuGioHanGioKQLoi
            // 
            this.nuGioHanGioKQLoi.Location = new System.Drawing.Point(225, 205);
            this.nuGioHanGioKQLoi.Margin = new System.Windows.Forms.Padding(4);
            this.nuGioHanGioKQLoi.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.nuGioHanGioKQLoi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuGioHanGioKQLoi.Name = "nuGioHanGioKQLoi";
            this.nuGioHanGioKQLoi.Size = new System.Drawing.Size(52, 23);
            this.nuGioHanGioKQLoi.TabIndex = 35;
            this.nuGioHanGioKQLoi.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(49, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "Lấy lại kết quả trạng thái lỗi";
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl5.Location = new System.Drawing.Point(60, 208);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(156, 16);
            this.lbl5.TabIndex = 33;
            this.lbl5.Text = "Lấy kết quả lỗi trong (giờ)";
            // 
            // chkUploadWhenStart
            // 
            this.chkUploadWhenStart.AutoSize = true;
            this.chkUploadWhenStart.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUploadWhenStart.ForeColor = System.Drawing.Color.Black;
            this.chkUploadWhenStart.Location = new System.Drawing.Point(15, 339);
            this.chkUploadWhenStart.Name = "chkUploadWhenStart";
            this.chkUploadWhenStart.Size = new System.Drawing.Size(162, 20);
            this.chkUploadWhenStart.TabIndex = 32;
            this.chkUploadWhenStart.Text = "Upload khi khởi động";
            this.chkUploadWhenStart.UseVisualStyleBackColor = false;
            this.chkUploadWhenStart.CheckedChanged += new System.EventHandler(this.chkUploadWhenStart_CheckedChanged);
            // 
            // chkMinisizeWihenStartWithWindows
            // 
            this.chkMinisizeWihenStartWithWindows.AutoSize = true;
            this.chkMinisizeWihenStartWithWindows.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMinisizeWihenStartWithWindows.ForeColor = System.Drawing.Color.Black;
            this.chkMinisizeWihenStartWithWindows.Location = new System.Drawing.Point(14, 313);
            this.chkMinisizeWihenStartWithWindows.Name = "chkMinisizeWihenStartWithWindows";
            this.chkMinisizeWihenStartWithWindows.Size = new System.Drawing.Size(169, 20);
            this.chkMinisizeWihenStartWithWindows.TabIndex = 31;
            this.chkMinisizeWihenStartWithWindows.Text = "Thu nhỏ khi khởi động";
            this.chkMinisizeWihenStartWithWindows.UseVisualStyleBackColor = false;
            this.chkMinisizeWihenStartWithWindows.CheckedChanged += new System.EventHandler(this.chkMinisizeWihenStartWithWindows_CheckedChanged);
            // 
            // chkStartWithWindows
            // 
            this.chkStartWithWindows.AutoSize = true;
            this.chkStartWithWindows.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStartWithWindows.ForeColor = System.Drawing.Color.Black;
            this.chkStartWithWindows.Location = new System.Drawing.Point(14, 286);
            this.chkStartWithWindows.Name = "chkStartWithWindows";
            this.chkStartWithWindows.Size = new System.Drawing.Size(187, 20);
            this.chkStartWithWindows.TabIndex = 30;
            this.chkStartWithWindows.Text = "Khởi động cùng windows";
            this.chkStartWithWindows.UseVisualStyleBackColor = false;
            this.chkStartWithWindows.CheckedChanged += new System.EventHandler(this.chkStartWithWindows_CheckedChanged);
            // 
            // nuTimeToResume
            // 
            this.nuTimeToResume.Location = new System.Drawing.Point(225, 258);
            this.nuTimeToResume.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.nuTimeToResume.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuTimeToResume.Name = "nuTimeToResume";
            this.nuTimeToResume.Size = new System.Drawing.Size(52, 23);
            this.nuTimeToResume.TabIndex = 28;
            this.nuTimeToResume.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl7.Location = new System.Drawing.Point(11, 263);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(205, 16);
            this.lbl7.TabIndex = 27;
            this.lbl7.Text = "Khởi động upload sau dừng (phút)";
            // 
            // nuTimeToPause
            // 
            this.nuTimeToPause.Location = new System.Drawing.Point(225, 231);
            this.nuTimeToPause.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.nuTimeToPause.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuTimeToPause.Name = "nuTimeToPause";
            this.nuTimeToPause.Size = new System.Drawing.Size(52, 23);
            this.nuTimeToPause.TabIndex = 25;
            this.nuTimeToPause.Value = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl6.Location = new System.Drawing.Point(55, 233);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(161, 16);
            this.lbl6.TabIndex = 24;
            this.lbl6.Text = "Tự dừng upload sau (phút)";
            // 
            // numSoNgayCapNhat
            // 
            this.numSoNgayCapNhat.Location = new System.Drawing.Point(225, 179);
            this.numSoNgayCapNhat.Margin = new System.Windows.Forms.Padding(4);
            this.numSoNgayCapNhat.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.numSoNgayCapNhat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoNgayCapNhat.Name = "numSoNgayCapNhat";
            this.numSoNgayCapNhat.Size = new System.Drawing.Size(52, 23);
            this.numSoNgayCapNhat.TabIndex = 23;
            this.numSoNgayCapNhat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.Location = new System.Drawing.Point(107, 182);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(109, 16);
            this.lbl4.TabIndex = 22;
            this.lbl4.Text = "Số ngày cập nhật";
            // 
            // timerResetUpload
            // 
            this.timerResetUpload.Interval = 1000;
            this.timerResetUpload.Tick += new System.EventHandler(this.timerResetUpload_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Cập nhật kết quả máy đang chạy ...";
            this.notifyIcon1.BalloonTipTitle = "TPH.AnalyzerResult";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "TPH cập nhật kết quả máy.\r\nDouble click để mở!";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(83)))), ((int)(((byte)(133)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblTimer});
            this.statusStrip1.Location = new System.Drawing.Point(3, 502);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(693, 22);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel1.Image")));
            this.toolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(678, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Copyright © 2017 TPH Solutions All Rights Reserved.";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // lblTimer
            // 
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTimer.ForeColor = System.Drawing.Color.White;
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnDieuKienCapNhat);
            this.groupBox1.Location = new System.Drawing.Point(2, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 392);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Các lựa chọn cập nhật kết quả";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTrangThai);
            this.groupBox2.Controls.Add(this.progressBarKetQuaMayTuDong);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(367, 318);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 120);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trạng thái";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(83)))), ((int)(((byte)(133)))));
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(693, 35);
            this.panel1.TabIndex = 25;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackColorHover = System.Drawing.Color.Empty;
            this.btnClose.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.BorderRadius = 5;
            this.btnClose.BorderSize = 1;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForceColorHover = System.Drawing.Color.Empty;
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Location = new System.Drawing.Point(658, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 30);
            this.btnClose.TabIndex = 4;
            this.btnClose.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.UseHightLight = true;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.BackColorHover = System.Drawing.Color.Empty;
            this.btnMinimize.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnMinimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMinimize.BackgroundImage")));
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimize.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMinimize.BorderRadius = 5;
            this.btnMinimize.BorderSize = 1;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForceColorHover = System.Drawing.Color.Empty;
            this.btnMinimize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMinimize.Location = new System.Drawing.Point(618, 1);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(34, 30);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnMinimize.UseHightLight = true;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.SystemColors.Control;
            this.btnStop.BackColorHover = System.Drawing.Color.Empty;
            this.btnStop.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnStop.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnStop.BorderRadius = 5;
            this.btnStop.BorderSize = 1;
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.Enabled = false;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForceColorHover = System.Drawing.Color.Empty;
            this.btnStop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop.Location = new System.Drawing.Point(367, 449);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(136, 47);
            this.btnStop.TabIndex = 14;
            this.btnStop.Text = "    DỪNG";
            this.btnStop.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnStop.UseHightLight = true;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.Control;
            this.btnStart.BackColorHover = System.Drawing.Color.Empty;
            this.btnStart.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnStart.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnStart.BorderRadius = 5;
            this.btnStart.BorderSize = 1;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForceColorHover = System.Drawing.Color.Empty;
            this.btnStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.Location = new System.Drawing.Point(223, 449);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(136, 47);
            this.btnStart.TabIndex = 13;
            this.btnStart.Text = "THỰC HIỆN";
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStart.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnStart.UseHightLight = true;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 16);
            this.label2.TabIndex = 39;
            this.label2.Text = "Danh sách máy khai báo theo pc";
            // 
            // chkDanhSachMayKhaiBaoTheoPC
            // 
            this.chkDanhSachMayKhaiBaoTheoPC.AutoSize = true;
            this.chkDanhSachMayKhaiBaoTheoPC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDanhSachMayKhaiBaoTheoPC.Checked = true;
            this.chkDanhSachMayKhaiBaoTheoPC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDanhSachMayKhaiBaoTheoPC.Location = new System.Drawing.Point(225, 126);
            this.chkDanhSachMayKhaiBaoTheoPC.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.chkDanhSachMayKhaiBaoTheoPC.Name = "chkDanhSachMayKhaiBaoTheoPC";
            this.chkDanhSachMayKhaiBaoTheoPC.Size = new System.Drawing.Size(15, 14);
            this.chkDanhSachMayKhaiBaoTheoPC.TabIndex = 38;
            this.chkDanhSachMayKhaiBaoTheoPC.UseVisualStyleBackColor = true;
            // 
            // FrmAnalyerResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(699, 527);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gbDanhSachMayXN);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmAnalyerResult";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TPH.LabIMS - Cập nhật kết quả từ mày";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAnalyerResult_FormClosing);
            this.Load += new System.EventHandler(this.FrmAnalyerResult_Load);
            this.Shown += new System.EventHandler(this.FrmAnalyerResult_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmAnalyerResult_SizeChanged);
            this.gbDanhSachMayXN.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTgUpload)).EndInit();
            this.pnDieuKienCapNhat.ResumeLayout(false);
            this.pnDieuKienCapNhat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuGioHanGioKQLoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuTimeToResume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuTimeToPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNgayCapNhat)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.GroupBox gbDanhSachMayXN;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.CheckBox chkAllAnalyzer;
        private TPH.LIS.Common.Controls.CustomCheckedListBox chkMayXetNghiem;
        private System.Windows.Forms.CheckBox chkCapNhat_KetQuaLoi;
        private System.Windows.Forms.CheckBox chkCapNhat_KetChaySau;
        private TPH.Controls.TPHNormalButton btnStart;
        private TPH.Controls.TPHNormalButton btnStop;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ProgressBar progressBarKetQuaMayTuDong;
        private System.Windows.Forms.Timer timerCount;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.NumericUpDown numTgUpload;
        private System.Windows.Forms.Panel pnDieuKienCapNhat;
        private System.Windows.Forms.NumericUpDown numSoNgayCapNhat;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.NumericUpDown nuTimeToResume;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.NumericUpDown nuTimeToPause;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.Timer timerResetUpload;
        private System.Windows.Forms.CheckBox chkMinisizeWihenStartWithWindows;
        private System.Windows.Forms.CheckBox chkStartWithWindows;
        private System.Windows.Forms.CheckBox chkUploadWhenStart;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.NumericUpDown nuGioHanGioKQLoi;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripStatusLabel lblTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private TPH.Controls.TPHNormalButton btnClose;
        private TPH.Controls.TPHNormalButton btnMinimize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkDeKetQuaChuaDuyet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkDanhSachMayKhaiBaoTheoPC;
    }
}

