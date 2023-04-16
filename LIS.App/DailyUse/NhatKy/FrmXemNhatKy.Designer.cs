namespace TPH.LIS.App.DailyUse.NhatKy
{
    partial class FrmXemNhatKy
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Thông tin bệnh nhân");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Thông tin hành chính", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Kết quả xét nghiệm");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Đổi SID kết quả từ máy");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Kết quả xét nghiệm - Danh sách", 1, 2);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Nhật ký thao tác cận lâm sàng", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Nhật ký đăng nhập hệ thống", 1, 2);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Nhật ký thao tác phần mềm", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Nhật ký danh mục", 1, 2);
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Nhật ký chỉnh sửa danh mục", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmXemNhatKy));
            this.splitContainer1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treLoaiNhatKy = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.customLable1 = new TPH.LIS.Common.Controls.CustomLable();
            this.customLable2 = new TPH.LIS.Common.Controls.CustomLable();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            this.pnMenu.SuspendLayout();
            this.xtraScrollableControlMain.SuspendLayout();
            this.pnFormControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(80, 22);
            this.lblTitle.Text = "NHẬT KÝ";
            // 
            // pnContaint
            // 
            this.pnContaint.Controls.Add(this.splitContainer1);
            this.pnContaint.Location = new System.Drawing.Point(0, 0);
            this.pnContaint.Size = new System.Drawing.Size(1008, 662);
            // 
            // pnLabel
            // 
            this.pnLabel.Size = new System.Drawing.Size(1008, 0);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(582, 0);
            this.btnClose.Size = new System.Drawing.Size(29, 0);
            // 
            // lblMainESC
            // 
            this.lblMainESC.Location = new System.Drawing.Point(611, 0);
            this.lblMainESC.Size = new System.Drawing.Size(397, 0);
            // 
            // pnMenu
            // 
            this.pnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnMenu.Size = new System.Drawing.Size(1008, 0);
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(130)))), ((int)(((byte)(167)))));
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(1008, 0);
            // 
            // ucGroupHeaderChonMain
            // 
            this.ucGroupHeaderChonMain.Location = new System.Drawing.Point(82, 1);
            this.ucGroupHeaderChonMain.Size = new System.Drawing.Size(10, 0);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Location = new System.Drawing.Point(900, 1);
            this.pnFormControl.Size = new System.Drawing.Size(106, 0);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treLoaiNhatKy);
            this.splitContainer1.Panel1.Controls.Add(this.customLable1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.customLable2);
            this.splitContainer1.Size = new System.Drawing.Size(1004, 658);
            this.splitContainer1.SplitterPosition = 332;
            this.splitContainer1.TabIndex = 0;
            // 
            // treLoaiNhatKy
            // 
            this.treLoaiNhatKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treLoaiNhatKy.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treLoaiNhatKy.ImageIndex = 0;
            this.treLoaiNhatKy.ImageList = this.imageList1;
            this.treLoaiNhatKy.ItemHeight = 25;
            this.treLoaiNhatKy.Location = new System.Drawing.Point(0, 27);
            this.treLoaiNhatKy.Name = "treLoaiNhatKy";
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "nodThongTinBenhNhan";
            treeNode1.Text = "Thông tin bệnh nhân";
            treeNode2.Name = "NodeRoot";
            treeNode2.Text = "Thông tin hành chính";
            treeNode3.ImageIndex = 1;
            treeNode3.Name = "nodKetQuaXeNghiem";
            treeNode3.SelectedImageKey = "Selected.png";
            treeNode3.Text = "Kết quả xét nghiệm";
            treeNode4.ImageKey = "Log.ico";
            treeNode4.Name = "nodDoiSIDKetQuaMay";
            treeNode4.SelectedImageKey = "Selected.png";
            treeNode4.Text = "Đổi SID kết quả từ máy";
            treeNode5.ImageIndex = 1;
            treeNode5.Name = "nodKetQua_DanhSach";
            treeNode5.SelectedImageIndex = 2;
            treeNode5.Text = "Kết quả xét nghiệm - Danh sách";
            treeNode6.Name = "nodNhatKyCanLamSang";
            treeNode6.Text = "Nhật ký thao tác cận lâm sàng";
            treeNode7.ImageIndex = 1;
            treeNode7.Name = "nodNhatDangNhap";
            treeNode7.SelectedImageIndex = 2;
            treeNode7.Text = "Nhật ký đăng nhập hệ thống";
            treeNode8.Name = "nodNhatKySuDungPhanMem";
            treeNode8.Text = "Nhật ký thao tác phần mềm";
            treeNode9.ImageIndex = 1;
            treeNode9.Name = "nodeNhatKyDanhMucXetNghiem";
            treeNode9.SelectedImageIndex = 2;
            treeNode9.Text = "Nhật ký danh mục";
            treeNode10.Name = "nodeNhatKydanhMuc";
            treeNode10.Text = "Nhật ký chỉnh sửa danh mục";
            this.treLoaiNhatKy.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode6,
            treeNode8,
            treeNode10});
            this.treLoaiNhatKy.SelectedImageKey = "Selected.png";
            this.treLoaiNhatKy.Size = new System.Drawing.Size(332, 631);
            this.treLoaiNhatKy.TabIndex = 1;
            this.treLoaiNhatKy.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treLoaiNhatKy_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Root.png");
            this.imageList1.Images.SetKeyName(1, "Log.ico");
            this.imageList1.Images.SetKeyName(2, "Selected.png");
            // 
            // customLable1
            // 
            this.customLable1.BackColor = System.Drawing.Color.LightGray;
            this.customLable1.BindFieldName = null;
            this.customLable1.Color = System.Drawing.Color.Black;
            this.customLable1.Dock = System.Windows.Forms.DockStyle.Top;
            this.customLable1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLable1.ForeColorClicked = System.Drawing.Color.White;
            this.customLable1.GetControl = null;
            this.customLable1.Location = new System.Drawing.Point(0, 0);
            this.customLable1.Name = "customLable1";
            this.customLable1.OldValue = null;
            this.customLable1.ShadowDepth = 3;
            this.customLable1.Size = new System.Drawing.Size(332, 27);
            this.customLable1.Softness = 1.5F;
            this.customLable1.TabIndex = 0;
            this.customLable1.Text = "Loại nhật ký";
            this.customLable1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.customLable1.UseShadow = false;
            this.customLable1.UseZoom = false;
            // 
            // customLable2
            // 
            this.customLable2.BackColor = System.Drawing.Color.LightGray;
            this.customLable2.BindFieldName = null;
            this.customLable2.Color = System.Drawing.Color.Black;
            this.customLable2.Dock = System.Windows.Forms.DockStyle.Top;
            this.customLable2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLable2.ForeColorClicked = System.Drawing.Color.White;
            this.customLable2.GetControl = null;
            this.customLable2.Location = new System.Drawing.Point(0, 0);
            this.customLable2.Name = "customLable2";
            this.customLable2.OldValue = null;
            this.customLable2.ShadowDepth = 3;
            this.customLable2.Size = new System.Drawing.Size(668, 27);
            this.customLable2.Softness = 1.5F;
            this.customLable2.TabIndex = 1;
            this.customLable2.Text = "Chi tiết nhật ký";
            this.customLable2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.customLable2.UseShadow = false;
            this.customLable2.UseZoom = false;
            // 
            // FrmXemNhatKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1008, 662);
            this.Name = "FrmXemNhatKy";
            this.Text = "FrmXemNhatKy";
            this.Load += new System.EventHandler(this.FrmXemNhatKy_Load);
            this.pnContaint.ResumeLayout(false);
            this.pnLabel.ResumeLayout(false);
            this.pnMenu.ResumeLayout(false);
            this.xtraScrollableControlMain.ResumeLayout(false);
            this.xtraScrollableControlMain.PerformLayout();
            this.pnFormControl.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainer1;
        private System.Windows.Forms.TreeView treLoaiNhatKy;
        private Common.Controls.CustomLable customLable1;
        private Common.Controls.CustomLable customLable2;
        private System.Windows.Forms.ImageList imageList1;
    }
}