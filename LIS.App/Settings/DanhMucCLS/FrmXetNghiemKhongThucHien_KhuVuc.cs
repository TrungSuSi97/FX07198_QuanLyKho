using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Patient.Services;
using TPH.LIS.TestResult.Services;

namespace TPH.LIS.App.Settings.DanhMucCLS
{
    public partial class FrmXetNghiemKhongThucHien_KhuVuc : FrmTemplate
    {
        public FrmXetNghiemKhongThucHien_KhuVuc()
        {
            InitializeComponent();
        }
        private readonly IPatientInformationService _patient = new PatientInformationService();
        private readonly ITestResultService _xetNghiem = new TestResultService();
        private readonly ISystemConfigService _sysConfig = new SystemConfigService();
        private void Load_KhuVuc()
        {
            var data = _sysConfig.Data_dm_khuvuc(string.Empty);
            gcKHuVuc.DataSource = data;
            cboKhuNha.DataSource = data.Copy();
            cboKhuNha.ValueMember = "MaKhuVuc";
            cboKhuNha.DisplayMember = "TenKhuVuc";
            cboKhuNha.SelectedIndex = -1;
        }

        private void Load_XetNghiem()
        {
          var  DataDMXetNghiem = _sysConfig.GetDM_XetNghiem_CoNhomCLSVaProfile(true);
            var queryData = from p in DataDMXetNghiem.AsEnumerable()
                            where (CommonAppVarsAndFunctions.NhomClsXetNghiem.Contains(p.Field<string>("FilterGroup")))
                            select p;
            if (queryData.Any())
            {
                if (gvGuiMau.RowCount > 0)
                {
                    var data = (DataTable)gcGuiMau.DataSource;
                    var lst = new List<string>();
                    foreach (DataRow dataRow in data.Rows)
                    {
                        lst.Add(dataRow["MaXn"].ToString());
                    }
                    queryData = queryData.Where(f1 => lst.All(f2 => !f2.Equals(f1["MaXN"].ToString(), StringComparison.OrdinalIgnoreCase)));

                }
                if (queryData.Any())
                    gcTestCode.DataSource = queryData.CopyToDataTable();
                gvTestCode.ExpandAllGroups();
            }
        }

        private void Load_XetNghiemGuiMau()
        {
            gcGuiMau.DataSource = null;
            if (gvKhuVuc.FocusedRowHandle >-1)
            {
                var maKhuVuc = gvKhuVuc.GetFocusedRowCellValue(colMaKHuVuc).ToString();
                var data = _sysConfig.Data_dm_khuvuc_xnkhongthuchien(maKhuVuc, string.Empty, string.Empty);
                gcGuiMau.DataSource = data;
                gvGuiMau.ExpandAllGroups();
            }
        }
        private void ThemXetNghiem()
        {
            if (gvKhuVuc.FocusedRowHandle > -1 && gvTestCode.SelectedRowsCount > 0 && cboKhuNha.SelectedIndex > -1)
            {
                var maKhuVuc = gvKhuVuc.GetFocusedRowCellValue(colMaKHuVuc).ToString();
                var makhuVucNhan = cboKhuNha.SelectedValue.ToString();
                if (maKhuVuc.Equals(makhuVucNhan))
                    CustomMessageBox.MSG_Waring_OK("Không thể khai báo gửi cho cùng khu vực");
                else
                {
                    foreach (var item in gvTestCode.GetSelectedRows())
                    {
                        if (gvTestCode.GetRowCellValue(item, clTestCode) != null)
                        {
                            var maXn = gvTestCode.GetRowCellValue(item, clTestCode).ToString();
                            _sysConfig.Insert_dm_khuvuc_xnkhongthuchien(new Configuration.Models.DM_KHUVUC_XNKHONGTHUCHIEN()
                            {
                                Makhuvuc = maKhuVuc,
                                Maxn = maXn,
                                Makhuvucnhan = makhuVucNhan,
                                Nguoinhap = CommonAppVarsAndFunctions.UserID,
                                Pcnhap = Environment.MachineName
                            });
                        }
                    }
                    Load_XetNghiemGuiMau();
                    Load_XetNghiem();
                }
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy chọn đủ nơi gửi, xét nghiệm, nơi nhận.");
        }
        private void XoaXetNghiem()
        {
            if(gvGuiMau.SelectedRowsCount >0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa các xét nghiệm gửi đang chọn?"))
                {
                    foreach (var item in gvGuiMau.GetSelectedRows())
                    {
                        if (gvGuiMau.GetRowCellValue(item, colGuiMau_MaXN) != null)
                        {
                            var makhuVuc = gvGuiMau.GetRowCellValue(item, colGuiMau_MaKhuVuc).ToString();
                            var makhuVucNhan = gvGuiMau.GetRowCellValue(item, colGuiMau_MaKhuVucNhan).ToString();
                            var maXn = gvGuiMau.GetRowCellValue(item, colGuiMau_MaXN).ToString();
                            _sysConfig.Delete_dm_khuvuc_xnkhongthuchien(makhuVuc, maXn, makhuVucNhan, CommonAppVarsAndFunctions.UserID, Environment.MachineName);
                        }
                    }
                    Load_XetNghiemGuiMau();
                    Load_XetNghiem();
                }
            }
        }
        private void FrmXetNghiemKhongThucHien_KhuVuc_Load(object sender, EventArgs e)
        {
            Load_KhuVuc();
            Load_XetNghiemGuiMau();
            Load_XetNghiem();
            gvKhuVuc.FocusedRowChanged += GvKhuVuc_FocusedRowChanged;
            gvKhuVuc.FocusedColumnChanged += GvKhuVuc_FocusedColumnChanged;
        }

        private void GvKhuVuc_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            Load_XetNghiemGuiMau();
            Load_XetNghiem();
        }

        private void GvKhuVuc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Load_XetNghiemGuiMau();
            Load_XetNghiem();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemXetNghiem();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaXetNghiem();
        }
    }
}
