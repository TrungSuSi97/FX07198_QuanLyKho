using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TPH.LIS.Common.Extensions
{
    public partial class FrmMessageError : Form
    {
        public FrmMessageError()
        {
            InitializeComponent();
        }
        private string _sMsg;

        public string Msg
        {
            get { return _sMsg; }
            set { _sMsg = value; }
        }
        private string _ErrDetail;

        public string ErrDetail
        {
            get { return _ErrDetail; }
            set { _ErrDetail = value; }
        }
        private string _caption;

        public string FormCaption
        {
            get { return _caption; }
            set { _caption = value; }
        }
        private int _ShowType = 1;
        /// <summary>
        /// 1: Chi tiết; Bỏ qua; Thoát - 2: Chi tiết; Đóng
        /// </summary>
        public int ShowType
        {
            get { return _ShowType; }
            set { _ShowType = value; }
        }

        private void FrmMessageError_Load(object sender, EventArgs e)
        {
            lblMsg.Text = _sMsg;
           // this.Text = _caption;
            this.Size = new Size(464, 200);
            txtDetail.Text = _ErrDetail;
            if (_ShowType == 2)
            {
                btnOK.Text = "Đóng";
                lblMsg.TextAlign = ContentAlignment.MiddleCenter;
                lblMsg.Font = new Font("Times New Roman", 14, FontStyle.Bold);
                pbIcon.Visible = true;
                lblMsg.ForeColor = Color.Maroon;
                btnIgnore.Visible = false;
                lblWarning.Visible = false;
            }
        }
        int i = 0;
        void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 10)
            {
                this.Close();
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_ShowType == 1)
            {
                Application.Exit();
            }
            else
            {
                this.Close();
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (btnDetail.Text == "Chi tiết")
            {
                btnDetail.Text = "Ẩn chi tiết";
                btnDetail.Width = 90;
                this.Size = new Size(466, 380);
                txtDetail.Visible = true;
                this.CenterToScreen();
            }
            else
            {
                btnDetail.Text = "Chi tiết";
                btnDetail.Width = 73;
                txtDetail.Visible = false;
                this.Size = new Size(466, 200);
                this.CenterToScreen();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}