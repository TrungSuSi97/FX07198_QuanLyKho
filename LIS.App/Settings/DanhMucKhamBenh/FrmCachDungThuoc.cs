using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;

namespace TPH.LIS.App.CauHinh.DanhMucKhamBenh
{
    public partial class FrmCachDungThuoc : Form
    {
        public FrmCachDungThuoc()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        SqlDataAdapter daCachDung = new SqlDataAdapter();
        DataTable dtCachDung = new DataTable();
        private void FrmCachDungThuoc_Load(object sender, EventArgs e)
        {
            sysConfig.Get_DM_Thuoc_CachDung(daCachDung, dtgCachDung, bvCachDung, "", ref dtCachDung);
        }

        private void dtgCachDung_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataProvider.UpdateData(daCachDung, ref dtCachDung, dtgCachDung, "", "");
        }

        private void btnDelCachDung_Click(object sender, EventArgs e)
        {
            if (dtgCachDung.RowCount > 0)
            {
                string _MaCachDung = dtgCachDung.CurrentRow.Cells["ID"].Value.ToString().Trim();
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa cách dùng \"" + _MaCachDung.ToUpper() + "\" đang chọn?"))
                {
                    if (LabServices_Helper.Check_NotExits("select MaGocThuoc from DM_Thuoc where CachDung = '" + _MaCachDung + "'") == false)
                    {
                        CustomMessageBox.MSG_Waring_OK("Cách dùngc đang sử dụng, không thể xóa!");
                    }
                    else
                    {
                        dtgCachDung.Rows.RemoveAt(dtgCachDung.CurrentRow.Index);
                    }
                }
            }
        }
    }
}
