using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using TPH.Common.Converter;
using TPH.LIS.User.Services.UserManagement;
using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.QuanLyChamCong
{
    public partial class FrmChamCongNew : FrmTemplateCommon
    {
        private readonly IUserManagementService _IUserService = new UserManagementService();

        public FrmChamCongNew()
        {
            InitializeComponent();
        }

        private void btnVaoLam_Click(object sender, EventArgs e)
        {
            ChamCongVaoLam();
            LoadLuoiChamCong();
        }

        private void ChamCongVaoLam()
        {
            if (_IUserService.Insert_User_ChamCong(CommonAppVarsAndFunctions.UserID))
            {
                CustomMessageBox.MSG_Information_OK("Bạn đã chấm công vào làm.");
            }


        }
        private void ChamCongRaVe()
        {
            if (_IUserService.User_ChamCongRaVe(CommonAppVarsAndFunctions.UserID))
            {
                CustomMessageBox.MSG_Information_OK("Bạn đã chấm công ra về.");
            }
        }

        private void btnRaVe_Click(object sender, EventArgs e)
        {
            ChamCongRaVe();
            LoadLuoiChamCong();
        }

        private void Clear_BindingInformation()
        {
            ucSearchLookupEditor_BoPhan1.DataBindings.Clear();
            ucSearchLookupEditor_BoPhan1.SelectedValue = null;

            ucSearchLookupEditor_ChucVu1.DataBindings.Clear();
            ucSearchLookupEditor_ChucVu1.SelectedValue = null;

            ucSearchLookupEditor_NhanVien1.DataBindings.Clear();
            ucSearchLookupEditor_NhanVien1.SelectedValue = null;
        }

        private void FrmChamCongNew_Load(object sender, EventArgs e)
        {

            Clear_BindingInformation();
            Load_NhanVien();
            Load_BoPhan();
            Load_ChucVu();
            LoadThongTinCaNhan();
            LoadLuoiChamCong();
            searchDuLieuCC();
        }
        private void LoadLuoiChamCong()
        {
            gcResult.DataSource = null;
            var data = WorkingServices.ConvertColumnNameToLower_Upper
                (_IUserService.DanhSachChamCong(CommonAppVarsAndFunctions.UserID), true);

            foreach (DataRow item in data.Rows)
            {
                if (DateTimeConverter.ToDateTime(item["ThoiGianVaoLam"]) != DateTime.MinValue
                    && DateTimeConverter.ToDateTime(item["ThoiGianRaVe"]) != DateTime.MinValue)
                {
                    TimeSpan variable = DateTimeConverter.ToDateTime(item["ThoiGianRaVe"]) -
                        DateTimeConverter.ToDateTime(item["ThoiGianVaoLam"]);
                    item["GioLamViec"] = variable.TotalHours.ToString("0.00");
                }
                else
                    item["GioLamViec"] = 0;
            }
            gcResult.DataSource = data;
        }

        private void LoadThongTinCaNhan()
        {
            txtManNV.Text = CommonAppVarsAndFunctions.UserID;
            txtTen.Text = CommonAppVarsAndFunctions.UserName;
            txtBP.Text = CommonAppVarsAndFunctions.TenBoPhan;
            txtCV.Text = CommonAppVarsAndFunctions.TenNhomNhanVien;


        }

        private void Load_NhanVien()
        {
            ucSearchLookupEditor_NhanVien1.Load_NhanVien();
            ucSearchLookupEditor_NhanVien1.CatchEnterKey = true;
            ucSearchLookupEditor_NhanVien1.CatchTabKey = true;
            //ucSearchLookupEditor_NhanVien1.ControlNext = ucSearchLookupEditor_CongTacVien;
            //ucSearchLookupEditor_NhanVien1.ControlBack = ucSearchLookupEditor_Object1;
        }
        private void Load_BoPhan()
        {
            ucSearchLookupEditor_BoPhan1.Load_BoPhan();
            ucSearchLookupEditor_BoPhan1.CatchEnterKey = true;
            ucSearchLookupEditor_BoPhan1.CatchTabKey = true;
            //ucSearchLookupEditor_NhanVien1.ControlNext = ucSearchLookupEditor_CongTacVien;
            //ucSearchLookupEditor_NhanVien1.ControlBack = ucSearchLookupEditor_Object1;
        }
        private void Load_ChucVu()
        {
            ucSearchLookupEditor_ChucVu1.Load_ChucVu();
            ucSearchLookupEditor_ChucVu1.CatchEnterKey = true;
            ucSearchLookupEditor_ChucVu1.CatchTabKey = true;
            //ucSearchLookupEditor_NhanVien1.ControlNext = ucSearchLookupEditor_CongTacVien;
            //ucSearchLookupEditor_NhanVien1.ControlBack = ucSearchLookupEditor_Object1;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportToExcel.Export(gcDuLieuCC, string.Format("DuLieuChamCong_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")));
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            searchDuLieuCC();
        }
        private void searchDuLieuCC()
        {
            gcDuLieuCC.DataSource = null;
            var maNV = StringConverter.ToString(ucSearchLookupEditor_NhanVien1.SelectedValue);
            var maboPhan = StringConverter.ToString(ucSearchLookupEditor_BoPhan1.SelectedValue);
            var maChucVu = StringConverter.ToString(ucSearchLookupEditor_ChucVu1.SelectedValue);

            gcDuLieuCC.DataSource = WorkingServices.ConvertColumnNameToLower_Upper
             (_IUserService.DuLieuChamCong(maNV, maboPhan, maChucVu), true);
        }

        private void btnTangCa_Click(object sender, EventArgs e)
        {
            TangCa();
        }

        private void TangCa()
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetNo("Bạn muốn tăng ca ngày hôm nay?")) return;
            var maNV = StringConverter.ToString(CommonAppVarsAndFunctions.UserID);

            if (_IUserService.CheckTangCa5Ngay(maNV))
            {
                CustomMessageBox.MSG_Information_OK("Bạn đã tăng ca 5 ngày?");
                return;
            }

            if (_IUserService.Udp_TangCa(maNV))
            {
                CustomMessageBox.MSG_Information_OK("Bạn đã tăng ca thành công?");
            }
            
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadLuoiChamCong();
        }
    }
}
