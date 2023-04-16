using System;
using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.Common.Constants;

namespace TPH.LIS.App
{
    public partial class FrmMessageError : Form
    {
        public FrmMessageError()
        {
            InitializeComponent();
        }

        public string Msg
        {
            get;
            set;
        }

        public string ErrDetail
        {
            get;
            set;
        }

        public string FormCaption
        {
            get;
            set;
        }

        /// <summary>
        /// 1: Chi tiết; Bỏ qua; Thoát - 2: Chi tiết; Đóng
        /// </summary>
        public int ShowType = 1;

        private void FrmMessageError_Load(object sender, EventArgs e)
        {
            lblMsg.Text = Msg;
           // this.Text = _caption;
            this.Size = new Size(464, 200);
            txtDetail.Text = ErrDetail;

            if (ShowType == 2)
            {
                btnOK.Text = MessageConstant.Closed;
                lblMsg.TextAlign = ContentAlignment.MiddleCenter;
                //lblMsg.Font = new Font("Times New Roman", 14, FontStyle.Bold);
                pbIcon.Visible = true;
                lblMsg.ForeColor = Color.Maroon;
                btnIgnore.Visible = false;
                lblWarning.Visible = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ShowType == 1)
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
            if (btnDetail.Text.Equals(MessageConstant.Detail, StringComparison.OrdinalIgnoreCase))
            {
                btnDetail.Text = MessageConstant.HideDetail;
                this.Size = new Size(466, 380);
                txtDetail.Visible = true;
            }
            else
            {
                btnDetail.Text = MessageConstant.Detail;
                txtDetail.Visible = false;
                this.Size = new Size(466, 200);
            }

            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}