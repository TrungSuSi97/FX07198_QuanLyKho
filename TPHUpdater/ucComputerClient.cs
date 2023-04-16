using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TPH.LabIMS.Updater
{
    public partial class ucComputerClient : UserControl
    {
        
        public ucComputerClient()
        {
            InitializeComponent();
        }
        bool huyYeuCauCapNhat = false;
        public bool isHuyYeuCau
        {
            get
            {
                return huyYeuCauCapNhat;
            }
            set
            {
                huyYeuCauCapNhat = value;
                if (huyYeuCauCapNhat)
                {
                    btnYeuCauCapNhat.Text = "Hủy cập nhật";
                    pictureBox1.Image = imageList1.Images["Waiting"];
                }
                else
                {
                    btnYeuCauCapNhat.Text = "Yêu càu cập nhật";
                    pictureBox1.Image = imageList1.Images["Normal"];
                }
            }
        }
        private void btnYeuCauCapNhat_Click(object sender, EventArgs e)
        {
            if (isHuyYeuCau)
            {
                if (MessageBox.Show(string.Format("Hủy yêu cầu cập nhật cho máy tính: {0}", txtTenMayTinh.Text), "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ActionFileWithDatabase.Update_ForceUpdate(txtTenMayTinh.Text, false);
                    isHuyYeuCau = false;
                }
            }
            else
            {
                if (MessageBox.Show(string.Format("Yêu cầu cập nhật cho máy tính: {0}", txtTenMayTinh.Text), "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ActionFileWithDatabase.Update_ForceUpdate(txtTenMayTinh.Text, true);
                    isHuyYeuCau = true;
                }
            }
        }

        private void btnDetailOfFile_Click(object sender, EventArgs e)
        {
            var data = ActionFileWithDatabase.DataKhuVucMayTinh(txtTenMayTinh.Text);
            if(data.Rows.Count >0)
            {
                var xmlString = data.Rows[0]["FileInfo"].ToString();
                StringReader theReader = new StringReader(xmlString);
                DataSet theDataSet = new DataSet();
                theDataSet.ReadXml(theReader);
                var f = new FrmDetailFileInPc();
                f.dtgChiTietFile.AutoGenerateColumns = true;
                f.dtgChiTietFile.DataSource = theDataSet.Tables[0];
                f.dtgChiTietFile.AutoResizeColumns();
                f.ShowDialog();
            }
        }
    }
}
