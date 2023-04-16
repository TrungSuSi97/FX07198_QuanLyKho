using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;

namespace TPH.LIS.App.Settings.HeThong
{
    public partial class FrmDanhMuc_NgayNghi : FrmTemplate
    {
        private readonly ISystemConfigService iSystem = new SystemConfigService();
        DataTable dataNgayNghi = new DataTable();
        SqlDataAdapter daNgayNghi = new SqlDataAdapter();
        public FrmDanhMuc_NgayNghi()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var objInsert = new DM_NGAYNGHI();
            objInsert.Ngaynghi = dtpNgayNghi.Value;
            objInsert.Ghichu = txtGhiChu.Text;
            iSystem.Insert_dm_ngaynghi(objInsert);
            Load_DSNgayNghi();
        }
        private void Load_DSNgayNghi()
        {
            iSystem.Get_Data_dm_ngaynghi(dtgNgayNghi, bvNgayNghi, ref daNgayNghi, ref dataNgayNghi, string.Empty);
        }

        private void dtgNgayNghi_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataProvider.UpdateData(daNgayNghi, ref dataNgayNghi, string.Empty, string.Empty);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa ngày nghỉ?"))
            {
                bvNgayNghi.BindingSource.RemoveCurrent();
            }
        }

        private void FrmDanhMuc_NgayNghi_Load(object sender, EventArgs e)
        {
            Load_DSNgayNghi();
        }
    }
}
