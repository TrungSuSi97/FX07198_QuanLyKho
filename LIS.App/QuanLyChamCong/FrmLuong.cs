using System;
using System.Data;
using TPH.Common.Converter;
using TPH.Language;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.User.Models;
using TPH.LIS.User.Services.UserManagement;

namespace TPH.LIS.App.QuanLyChamCong
{
    public partial class FrmLuong : FrmTemplateCommon
    {
        public FrmLuong()
        {
            InitializeComponent();
        }
        private readonly IUserManagementService _IUserService = new UserManagementService();
        private readonly ISystemConfigService iConfig = new SystemConfigService();

        private void FrmLuong_Load(object sender, EventArgs e)
        {
            Load_NhanVien();
            Load_BoPhan();
            Load_ChucVu();
            Load_Nam();
            Load_Thang();
            LoadLuoiLuong();
            Load_LuongNhanVien();

        }
        private void Load_Nam()
        {
            ucSearchLookupEditor_Nam1.Load_Nam();
            ucSearchLookupEditor_Nam1.CatchEnterKey = true;
            ucSearchLookupEditor_Nam1.CatchTabKey = true;

            ucSearchLookupEditor_Nam2.Load_Nam();
            ucSearchLookupEditor_Nam2.CatchEnterKey = true;
            ucSearchLookupEditor_Nam2.CatchTabKey = true;
        }
        private void Load_Thang()
        {
            ucSearchLookupEditor_Thang1.Load_Thang();
            ucSearchLookupEditor_Thang1.CatchEnterKey = true;
            ucSearchLookupEditor_Thang1.CatchTabKey = true;

            ucSearchLookupEditor_Thang2.Load_Thang();
            ucSearchLookupEditor_Thang2.CatchEnterKey = true;
            ucSearchLookupEditor_Thang2.CatchTabKey = true;

        }

        private void Load_NhanVien()
        {
            ucSearchLookupEditor_NhanVien1.Load_NhanVien();
            ucSearchLookupEditor_NhanVien1.CatchEnterKey = true;
            ucSearchLookupEditor_NhanVien1.CatchTabKey = true;
        }
        private void Load_BoPhan()
        {
            ucSearchLookupEditor_BoPhan1.Load_BoPhan();
            ucSearchLookupEditor_BoPhan1.CatchEnterKey = true;
            ucSearchLookupEditor_BoPhan1.CatchTabKey = true;
        }
        private void Load_ChucVu()
        {
            ucSearchLookupEditor_ChucVu1.Load_ChucVu();
            ucSearchLookupEditor_ChucVu1.CatchEnterKey = true;
            ucSearchLookupEditor_ChucVu1.CatchTabKey = true;
        }

        private void btnCalLuong_Click(object sender, EventArgs e)
        {
            TinhToanLuong();
            LoadLuoiLuong();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadLuoiLuong();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportToExcel.Export(gcLuong, string.Format("LuongNhanVien_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")));
        }
        private void TinhToanLuong()
        {
            int Month = NumberConverter.ToInt(ucSearchLookupEditor_Thang2.SelectedValue);
            int Year = NumberConverter.ToInt(ucSearchLookupEditor_Nam2.SelectedValue);
            if (Month == 0 || Year == 0)
                return;
            if (CustomMessageBox.MSG_Question_YesNo_GetNo
                (string.Format(LanguageExtension.GetResourceValueFromKey("BanmuontinhtoanluongthangMONGOACNHONKHONGDONGNGOACNHONnamMONGOACNHONMOTDONGNGOACNHONHOI", LanguageExtension.AppLanguage), Month, Year)))
                return;
            var firstDayOfMonth = new DateTime(Year, Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            var dtDsNhanVienCC = _IUserService.DanhSachNhanVienChamCong(string.Empty, firstDayOfMonth, lastDayOfMonth);
            var dtNhanVienDistinct = WorkingServices.DataTable_DistinctValue(dtDsNhanVienCC, "MaNhanVien");
            int soNgayTrongThang = DateTime.DaysInMonth(Year, Month);

            foreach (DataRow item in dtNhanVienDistinct.Rows)
            {
                CapNhatLuongNhanVien(item, dtDsNhanVienCC, soNgayTrongThang, Year, Month);


            }
        }
        private void CapNhatLuongNhanVien(DataRow item, DataTable dtDsNhanVienCC, int soNgayTrongThang, int Year, int Month)
        {
            var model = new UserLuongModel();
            var dtLuongNV = WorkingServices.SearchResult_OnDatatable(dtDsNhanVienCC, string.Format("MaNhanVien = '{0}'", item[0].ToString()));
            var chucVu = StringConverter.ToString(dtLuongNV.Rows[0]["MaNhomNhanVien"]);

            model.SoNgayLam = WorkingServices.SearchResult_OnDatatable(dtLuongNV, string.Format("isDiLam = 1")).Rows.Count;
            model.SoNgayDiMuon = WorkingServices.SearchResult_OnDatatable(dtLuongNV, string.Format("isDenMuon = 1")).Rows.Count;
            model.SoNgayTangCa = WorkingServices.SearchResult_OnDatatable(dtLuongNV, string.Format("isTangCa = 1")).Rows.Count;
            model.MaNhanVien = StringConverter.ToString(dtLuongNV.Rows[0]["MaNhanVien"]);
            model.Year = Year;
            model.Month = Month;
            model.LuongCoBan = NumberConverter.ToDecimal(dtLuongNV.Rows[0]["Luong"]);


            var luongMotNgay = model.LuongCoBan / soNgayTrongThang;
            if (model.SoNgayLam == soNgayTrongThang)
                model.LuongThang = model.LuongCoBan;
            else
                model.LuongThang = Math.Round(luongMotNgay * model.SoNgayLam);

            if (model.SoNgayTangCa > 0)
                model.LuongTangCa = Math.Round((luongMotNgay * 50) / 100);

            if (chucVu.Equals("TP"))
                model.LuongChucVu = Math.Round((model.LuongThang * 25) / 100);
            else if (chucVu.Equals("PGD"))
                model.LuongChucVu = Math.Round((model.LuongThang * 50) / 100);

            if (model.SoNgayDiMuon > 0)
                model.LuongDiTre = Math.Round(-(luongMotNgay * 20) / 100);

            model.LuongThucNhan = Math.Round(model.LuongThang + model.LuongChucVu + model.LuongTangCa + model.LuongDiTre);
            _IUserService.CapNhatLuongNhanVien(model);
        }

        private void btnKhoaSo_Click(object sender, EventArgs e)
        {
        }

        private void LoadLuoiLuong()
        {
            gcLuong.DataSource = null;
            UserLuongModel model = new UserLuongModel()
            {
                Month = NumberConverter.ToInt(ucSearchLookupEditor_Thang1.SelectedValue),
                Year = NumberConverter.ToInt(ucSearchLookupEditor_Nam1.SelectedValue),
                MaNhanVien = StringConverter.ToString(ucSearchLookupEditor_NhanVien1.SelectedValue),
                MaBoPhan = StringConverter.ToString(ucSearchLookupEditor_BoPhan1.SelectedValue),
                MaChucVu = StringConverter.ToString(ucSearchLookupEditor_ChucVu1.SelectedValue)
            };
            var data = _IUserService.DuLieuLuong(model);
            gcLuong.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(data, true);

        }

        private void btnRefreshBacSi_Click(object sender, EventArgs e)
        {
            Load_LuongNhanVien();
        }
        private void Load_LuongNhanVien()
        {
            var data = iConfig.Data_ql_nhanvien(string.Empty, string.Empty);
            gcNhanVien.DataSource = data;
            gvNhanVien.ExpandAllGroups();
        }

        private void gvNhanVien_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle > -1)
            {
                var obj = iConfig.Get_Info_ql_nhanvien(gvNhanVien.GetRowCellValue(e.RowHandle, colMaNhanVien).ToString(), string.Empty);
                obj.Luong = NumberConverter.ToDecimal(gvNhanVien.GetRowCellValue(e.RowHandle, colLuong));
                iConfig.Update_ql_luong_nhanvien(obj);
            }
        }
    }
}
