namespace TPH.LIS.Statistic.Controls
{
    partial class ucDashBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDashBoard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radloadAutomatic = new System.Windows.Forms.RadioButton();
            this.dtpNgayManual = new System.Windows.Forms.DateTimePicker();
            this.btnLamMoiDS = new TPH.Controls.TPHNormalButton();
            this.radLoadmanual = new System.Windows.Forms.RadioButton();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnXemTheoBieuDo = new TPH.Controls.TPHNormalButton();
            this.btnXemTheoLuoi = new TPH.Controls.TPHNormalButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabXemTheoDanhSach = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.timerReLoad = new System.Windows.Forms.Timer(this.components);
            this.timerCount = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.btnXemTheoBieuDo);
            this.panel1.Controls.Add(this.btnXemTheoLuoi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(145, 700);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.radloadAutomatic);
            this.panel2.Controls.Add(this.dtpNgayManual);
            this.panel2.Controls.Add(this.btnLamMoiDS);
            this.panel2.Controls.Add(this.radLoadmanual);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 495);
            this.panel2.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(145, 183);
            this.panel2.TabIndex = 0;
            // 
            // radloadAutomatic
            // 
            this.radloadAutomatic.AutoSize = true;
            this.radloadAutomatic.Checked = true;
            this.radloadAutomatic.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radloadAutomatic.ForeColor = System.Drawing.Color.White;
            this.radloadAutomatic.Location = new System.Drawing.Point(2, 2);
            this.radloadAutomatic.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.radloadAutomatic.Name = "radloadAutomatic";
            this.radloadAutomatic.Size = new System.Drawing.Size(130, 19);
            this.radloadAutomatic.TabIndex = 5;
            this.radloadAutomatic.TabStop = true;
            this.radloadAutomatic.Text = "Lấy dữ liệu tự động";
            this.radloadAutomatic.UseVisualStyleBackColor = true;
            // 
            // dtpNgayManual
            // 
            this.dtpNgayManual.CalendarFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayManual.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayManual.Enabled = false;
            this.dtpNgayManual.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayManual.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayManual.Location = new System.Drawing.Point(11, 56);
            this.dtpNgayManual.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.dtpNgayManual.Name = "dtpNgayManual";
            this.dtpNgayManual.Size = new System.Drawing.Size(115, 23);
            this.dtpNgayManual.TabIndex = 0;
            // 
            // btnLamMoiDS
            // 
            this.btnLamMoiDS.BackColor = System.Drawing.Color.Transparent;
            this.btnLamMoiDS.BackColorHover = System.Drawing.Color.Empty;
            this.btnLamMoiDS.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnLamMoiDS.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnLamMoiDS.BorderRadius = 5;
            this.btnLamMoiDS.BorderSize = 1;
            this.btnLamMoiDS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoiDS.Enabled = false;
            this.btnLamMoiDS.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLamMoiDS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiDS.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoiDS.ForceColorHover = System.Drawing.Color.Empty;
            this.btnLamMoiDS.ForeColor = System.Drawing.Color.White;
            this.btnLamMoiDS.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoiDS.Image")));
            this.btnLamMoiDS.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLamMoiDS.Location = new System.Drawing.Point(11, 84);
            this.btnLamMoiDS.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnLamMoiDS.Name = "btnLamMoiDS";
            this.btnLamMoiDS.Size = new System.Drawing.Size(114, 61);
            this.btnLamMoiDS.TabIndex = 6;
            this.btnLamMoiDS.Text = "Làm mới";
            this.btnLamMoiDS.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLamMoiDS.TextColor = System.Drawing.Color.White;
            this.btnLamMoiDS.UseHightLight = true;
            this.btnLamMoiDS.UseVisualStyleBackColor = false;
            this.btnLamMoiDS.Click += new System.EventHandler(this.btnLamMoiDS_Click);
            // 
            // radLoadmanual
            // 
            this.radLoadmanual.AutoSize = true;
            this.radLoadmanual.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLoadmanual.ForeColor = System.Drawing.Color.White;
            this.radLoadmanual.Location = new System.Drawing.Point(2, 32);
            this.radLoadmanual.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.radLoadmanual.Name = "radLoadmanual";
            this.radLoadmanual.Size = new System.Drawing.Size(135, 19);
            this.radLoadmanual.TabIndex = 4;
            this.radLoadmanual.Text = "Lấy dữ liệu thủ công";
            this.radLoadmanual.UseVisualStyleBackColor = true;
            this.radLoadmanual.CheckedChanged += new System.EventHandler(this.radLoadmanual_CheckedChanged);
            // 
            // lblTime
            // 
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTime.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(0, 678);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(145, 22);
            this.lblTime.TabIndex = 0;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnXemTheoBieuDo
            // 
            this.btnXemTheoBieuDo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnXemTheoBieuDo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnXemTheoBieuDo.BackColorHover = System.Drawing.Color.Empty;
            this.btnXemTheoBieuDo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnXemTheoBieuDo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXemTheoBieuDo.BorderRadius = 5;
            this.btnXemTheoBieuDo.BorderSize = 1;
            this.btnXemTheoBieuDo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemTheoBieuDo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnXemTheoBieuDo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemTheoBieuDo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemTheoBieuDo.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXemTheoBieuDo.ForeColor = System.Drawing.Color.White;
            this.btnXemTheoBieuDo.Image = ((System.Drawing.Image)(resources.GetObject("btnXemTheoBieuDo.Image")));
            this.btnXemTheoBieuDo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnXemTheoBieuDo.Location = new System.Drawing.Point(13, 274);
            this.btnXemTheoBieuDo.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnXemTheoBieuDo.Name = "btnXemTheoBieuDo";
            this.btnXemTheoBieuDo.Size = new System.Drawing.Size(114, 71);
            this.btnXemTheoBieuDo.TabIndex = 1;
            this.btnXemTheoBieuDo.Text = "Xem theo \r\nbiểu đồ";
            this.btnXemTheoBieuDo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnXemTheoBieuDo.TextColor = System.Drawing.Color.White;
            this.btnXemTheoBieuDo.UseHightLight = true;
            this.btnXemTheoBieuDo.UseVisualStyleBackColor = true;
            // 
            // btnXemTheoLuoi
            // 
            this.btnXemTheoLuoi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnXemTheoLuoi.BackColor = System.Drawing.Color.Transparent;
            this.btnXemTheoLuoi.BackColorHover = System.Drawing.Color.Empty;
            this.btnXemTheoLuoi.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnXemTheoLuoi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXemTheoLuoi.BorderRadius = 5;
            this.btnXemTheoLuoi.BorderSize = 1;
            this.btnXemTheoLuoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemTheoLuoi.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnXemTheoLuoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemTheoLuoi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemTheoLuoi.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXemTheoLuoi.ForeColor = System.Drawing.Color.White;
            this.btnXemTheoLuoi.Image = ((System.Drawing.Image)(resources.GetObject("btnXemTheoLuoi.Image")));
            this.btnXemTheoLuoi.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnXemTheoLuoi.Location = new System.Drawing.Point(13, 180);
            this.btnXemTheoLuoi.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnXemTheoLuoi.Name = "btnXemTheoLuoi";
            this.btnXemTheoLuoi.Size = new System.Drawing.Size(114, 71);
            this.btnXemTheoLuoi.TabIndex = 0;
            this.btnXemTheoLuoi.Text = "Xem theo \r\ndanh sách";
            this.btnXemTheoLuoi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnXemTheoLuoi.TextColor = System.Drawing.Color.White;
            this.btnXemTheoLuoi.UseHightLight = true;
            this.btnXemTheoLuoi.UseVisualStyleBackColor = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabXemTheoDanhSach);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(145, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1155, 700);
            this.tabControl1.TabIndex = 2;
            // 
            // tabXemTheoDanhSach
            // 
            this.tabXemTheoDanhSach.AutoScroll = true;
            this.tabXemTheoDanhSach.Location = new System.Drawing.Point(4, 24);
            this.tabXemTheoDanhSach.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.tabXemTheoDanhSach.Name = "tabXemTheoDanhSach";
            this.tabXemTheoDanhSach.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabXemTheoDanhSach.Size = new System.Drawing.Size(1147, 672);
            this.tabXemTheoDanhSach.TabIndex = 0;
            this.tabXemTheoDanhSach.Text = "Xem theo danh sách";
            this.tabXemTheoDanhSach.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1147, 672);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Xem theo biểu đồ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // timerReLoad
            // 
            this.timerReLoad.Interval = 10000;
            this.timerReLoad.Tick += new System.EventHandler(this.timerReLoad_Tick);
            // 
            // timerCount
            // 
            this.timerCount.Interval = 1000;
            this.timerCount.Tick += new System.EventHandler(this.timerCount_Tick);
            // 
            // ucDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.Name = "ucDashBoard";
            this.Size = new System.Drawing.Size(1300, 700);
            this.Load += new System.EventHandler(this.ucDashBoard_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private TPH.Controls.TPHNormalButton btnXemTheoLuoi;
        private TPH.Controls.TPHNormalButton btnXemTheoBieuDo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabXemTheoDanhSach;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Timer timerReLoad;
        private System.Windows.Forms.DateTimePicker dtpNgayManual;
        private System.Windows.Forms.Timer timerCount;
        private System.Windows.Forms.RadioButton radloadAutomatic;
        private System.Windows.Forms.RadioButton radLoadmanual;
        private TPH.Controls.TPHNormalButton btnLamMoiDS;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Panel panel2;
    }
}
