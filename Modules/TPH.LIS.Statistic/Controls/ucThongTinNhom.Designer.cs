namespace TPH.LIS.Statistic.Controls
{
    partial class ucThongTinNhom
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colDaLayMau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDaLayMauDu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDaNhanMau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDaNhanMauDu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYeuCauLayLai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDaCoKetQua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDuKetQua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDaDuyet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDaLayMau,
            this.colDaLayMauDu,
            this.colDaNhanMau,
            this.colDaNhanMauDu,
            this.colYeuCauLayLai,
            this.colDaCoKetQua,
            this.colDuKetQua,
            this.colDaDuyet,
            this.colDain});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 29);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(962, 110);
            this.dataGridView1.TabIndex = 0;
            // 
            // colDaLayMau
            // 
            this.colDaLayMau.HeaderText = "ĐÃ LẤY MẪU";
            this.colDaLayMau.Name = "colDaLayMau";
            // 
            // colDaLayMauDu
            // 
            this.colDaLayMauDu.HeaderText = "LẤY MẪU ĐỦ";
            this.colDaLayMauDu.Name = "colDaLayMauDu";
            // 
            // colDaNhanMau
            // 
            this.colDaNhanMau.HeaderText = "ĐÃ NHẬN MẪU";
            this.colDaNhanMau.Name = "colDaNhanMau";
            // 
            // colDaNhanMauDu
            // 
            this.colDaNhanMauDu.HeaderText = "NHẬN MẪU ĐỦ";
            this.colDaNhanMauDu.Name = "colDaNhanMauDu";
            // 
            // colYeuCauLayLai
            // 
            this.colYeuCauLayLai.HeaderText = "YÊU CẦU LẤY LẠI";
            this.colYeuCauLayLai.Name = "colYeuCauLayLai";
            // 
            // colDaCoKetQua
            // 
            this.colDaCoKetQua.HeaderText = "ĐÃ CÓ KẾT QUẢ";
            this.colDaCoKetQua.Name = "colDaCoKetQua";
            // 
            // colDuKetQua
            // 
            this.colDuKetQua.HeaderText = "ĐỦ KẾT QUẢ";
            this.colDuKetQua.Name = "colDuKetQua";
            // 
            // colDaDuyet
            // 
            this.colDaDuyet.HeaderText = "ĐÃ DUYỆT";
            this.colDaDuyet.Name = "colDaDuyet";
            // 
            // colDain
            // 
            this.colDain.HeaderText = "ĐÃ IN";
            this.colDain.Name = "colDain";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(962, 29);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(793, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "TÊN BỘ PHẬN:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucThongTinNhom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.Name = "ucThongTinNhom";
            this.Size = new System.Drawing.Size(962, 139);
            this.Load += new System.EventHandler(this.ucThongTinNhom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDaLayMau;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDaLayMauDu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDaNhanMau;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDaNhanMauDu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYeuCauLayLai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDaCoKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDuKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDaDuyet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDain;
    }
}
