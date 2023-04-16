using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.Data;
using TPH.LIS.Common.Extensions;
using System.Data.SqlClient;

namespace TPH.LIS.Patient.Controls
{
    public partial class ucTechUpdate : UserControl
    {
        public ucTechUpdate()
        {
            InitializeComponent();
        }

        private void btnCapNhatGioXNContheoCha_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGioXNConTheoCha_MaTiepNhan.Text))
            {
                var sqlPara = new SqlParameter[]
                {
                     WorkingServices.GetParaFromOject("@MatiepNhan", txtGioXNConTheoCha_MaTiepNhan.Text)
                };
                var iCount = (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "tech_Update_LayNhanMauTheoCha", sqlPara);
                if (iCount > -1)
                {
                    MessageBox.Show(string.Format("Cập nhật hoàn thành {0} record(s)", iCount));
                }

            }
            else
                MessageBox.Show("Hãy nhập mã tiếp nhận");
        }

        private void btnCapNhatLoaiMau_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCapNhatLoaiMau_MaXN.Text) && !string.IsNullOrEmpty(txtCapNhatLoaiMau_MaTiepNhan.Text))
            {
                var sqlPara = new SqlParameter[]
                {
                     WorkingServices.GetParaFromOject("@MatiepNhan", txtCapNhatLoaiMau_MaTiepNhan.Text),
                     WorkingServices.GetParaFromOject("@MaXN", txtCapNhatLoaiMau_MaXN.Text),
                     WorkingServices.GetParaFromOject("@CapNhatXnCon", chkCapNhatLoaiMauChoCon.Checked),
                     WorkingServices.GetParaFromOject("@DungLoaiMau2", chkDungMaLoaiMau2.Checked)
                };
                var iCount = (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "tech_Update_MaLoaiMau", sqlPara);
                if (iCount > -1)
                {
                    MessageBox.Show(string.Format("Cập nhật hoàn thành {0} record(s)", iCount));
                }

            }
            else
                MessageBox.Show("Hãy nhập đủ thông tin cần cập nhật");
        }
    }
}
