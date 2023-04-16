namespace TPH.Excel
{
    partial class FrmReadExcelData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReadExcelData));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new TPH.Controls.TPHNormalButton();
            this.btnReadFile = new TPH.Controls.TPHNormalButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tabDataSheet = new System.Windows.Forms.TabControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtKyTuTachChuoi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExportXML = new TPH.Controls.TPHNormalButton();
            this.btnGetData = new TPH.Controls.TPHNormalButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1156, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐỌC DỮ LIỆU EXCEL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPath);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.btnReadFile);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1156, 23);
            this.panel1.TabIndex = 1;
            // 
            // txtPath
            // 
            this.txtPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPath.Location = new System.Drawing.Point(89, 0);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(896, 23);
            this.txtPath.TabIndex = 1;
            this.txtPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPath_KeyPress);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnBrowse.BackColorHover = System.Drawing.Color.Empty;
            this.btnBrowse.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnBrowse.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnBrowse.BorderRadius = 5;
            this.btnBrowse.BorderSize = 1;
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.ForceColorHover = System.Drawing.Color.Empty;
            this.btnBrowse.ForeColor = System.Drawing.Color.Black;
            this.btnBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowse.Image")));
            this.btnBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowse.Location = new System.Drawing.Point(985, 0);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(91, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Tìm file";
            this.btnBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowse.TextColor = System.Drawing.Color.Black;
            this.btnBrowse.UseHightLight = true;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnReadFile
            // 
            this.btnReadFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnReadFile.BackColorHover = System.Drawing.Color.Empty;
            this.btnReadFile.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnReadFile.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnReadFile.BorderRadius = 5;
            this.btnReadFile.BorderSize = 1;
            this.btnReadFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReadFile.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReadFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadFile.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadFile.ForceColorHover = System.Drawing.Color.Empty;
            this.btnReadFile.ForeColor = System.Drawing.Color.Black;
            this.btnReadFile.Image = ((System.Drawing.Image)(resources.GetObject("btnReadFile.Image")));
            this.btnReadFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReadFile.Location = new System.Drawing.Point(1076, 0);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(80, 23);
            this.btnReadFile.TabIndex = 2;
            this.btnReadFile.Text = "Đọc file";
            this.btnReadFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReadFile.TextColor = System.Drawing.Color.Black;
            this.btnReadFile.UseHightLight = true;
            this.btnReadFile.UseVisualStyleBackColor = true;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Đường dẫn:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabDataSheet
            // 
            this.tabDataSheet.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabDataSheet.Location = new System.Drawing.Point(0, 52);
            this.tabDataSheet.Name = "tabDataSheet";
            this.tabDataSheet.SelectedIndex = 0;
            this.tabDataSheet.Size = new System.Drawing.Size(1156, 531);
            this.tabDataSheet.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtKyTuTachChuoi);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnExportXML);
            this.panel2.Controls.Add(this.btnGetData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 583);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1156, 38);
            this.panel2.TabIndex = 3;
            // 
            // txtKyTuTachChuoi
            // 
            this.txtKyTuTachChuoi.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKyTuTachChuoi.Location = new System.Drawing.Point(453, 1);
            this.txtKyTuTachChuoi.Name = "txtKyTuTachChuoi";
            this.txtKyTuTachChuoi.PasswordChar = ';';
            this.txtKyTuTachChuoi.Size = new System.Drawing.Size(100, 32);
            this.txtKyTuTachChuoi.TabIndex = 5;
            this.txtKyTuTachChuoi.Text = ";";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(331, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ký tự tách chuỗi:";
            // 
            // btnExportXML
            // 
            this.btnExportXML.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExportXML.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnExportXML.BackColorHover = System.Drawing.Color.Empty;
            this.btnExportXML.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnExportXML.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnExportXML.BorderRadius = 5;
            this.btnExportXML.BorderSize = 1;
            this.btnExportXML.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportXML.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportXML.ForceColorHover = System.Drawing.Color.Empty;
            this.btnExportXML.ForeColor = System.Drawing.Color.Black;
            this.btnExportXML.Image = ((System.Drawing.Image)(resources.GetObject("btnExportXML.Image")));
            this.btnExportXML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportXML.Location = new System.Drawing.Point(760, 4);
            this.btnExportXML.Name = "btnExportXML";
            this.btnExportXML.Size = new System.Drawing.Size(104, 27);
            this.btnExportXML.TabIndex = 3;
            this.btnExportXML.Text = "Xuất XML";
            this.btnExportXML.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportXML.TextColor = System.Drawing.Color.Black;
            this.btnExportXML.UseHightLight = true;
            this.btnExportXML.UseVisualStyleBackColor = true;
            this.btnExportXML.Click += new System.EventHandler(this.btnExportXML_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGetData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnGetData.BackColorHover = System.Drawing.Color.Empty;
            this.btnGetData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnGetData.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnGetData.BorderRadius = 5;
            this.btnGetData.BorderSize = 1;
            this.btnGetData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetData.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.ForceColorHover = System.Drawing.Color.Empty;
            this.btnGetData.ForeColor = System.Drawing.Color.Black;
            this.btnGetData.Image = ((System.Drawing.Image)(resources.GetObject("btnGetData.Image")));
            this.btnGetData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetData.Location = new System.Drawing.Point(571, 4);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(181, 27);
            this.btnGetData.TabIndex = 2;
            this.btnGetData.Text = "Lấy sheet đang chọn";
            this.btnGetData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGetData.TextColor = System.Drawing.Color.Black;
            this.btnGetData.UseHightLight = true;
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // FrmReadExcelData
            // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1156, 621);
            this.Controls.Add(this.tabDataSheet);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReadExcelData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đọc dữ liệu excel";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPath;
        private TPH.Controls.TPHNormalButton btnBrowse;
        private TPH.Controls.TPHNormalButton btnReadFile;
        private System.Windows.Forms.TabControl tabDataSheet;
        private System.Windows.Forms.Panel panel2;
        private TPH.Controls.TPHNormalButton btnGetData;
        private TPH.Controls.TPHNormalButton btnExportXML;
        private System.Windows.Forms.TextBox txtKyTuTachChuoi;
        private System.Windows.Forms.Label label4;
    }
}