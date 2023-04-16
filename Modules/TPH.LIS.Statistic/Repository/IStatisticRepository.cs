using System;
using System.Collections.Generic;
using System.Data;
using TPH.LIS.Statistic.Models;
using TPH.LIS.Statistics.Models;

namespace TPH.LIS.Statistic.Repository
{
    public interface IStatisticRepository
    {
        DataTable ThongKeBenhNhanXetNghiem(NormalStatisticCondit condit);
        DataTable ThongKeXetNghiemThucHien(NormalStatisticCondit condit);
        DataTable ThongXetNghiemThucHien_DoiTuong(NormalStatisticCondit condit);
        DataTable ThongXetNghiem_TheoNhom(NormalStatisticCondit condit);
        DataTable ThongKeTuongDichVu(NormalStatisticCondit condit);
        DataTable ThongKeChiTiet_BenhNhan(NormalStatisticCondit condit);
        DataTable ThongKeChiTiet_BSThucHien(NormalStatisticCondit condit);
        bool CapNhatChietKhau_BS(NormalStatisticCondit condit);
        DataTable ThongKeChiTiet_TongHopBSChiDinh(NormalStatisticCondit condit);
        DataTable ThongKeXetNghiem_TheoNgay(NormalStatisticCondit condit);

        DataTable ThongKeNguoiThucHien(NormalStatisticCondit condit);
        DataTable ThongKeXetNghiemMay_TheoKetQuaXN(NormalStatisticCondit condit);
        DataTable ThongKeXetNghiemMay(NormalStatisticCondit condit);
        DataTable ThongKeXetNghiemMay_ChayLay(NormalStatisticCondit condit);
        DataTable ThongKeXetNghiem_TAT(NormalStatisticCondit condit);
        DataTable ThongXetNghiemThucHien_BenhNhan_SoPhieu(NormalStatisticCondit condit);
        DataTable ThongXetNghiem_SLSS_RLCH_XHH_NoiVien_SoLuong(NormalStatisticCondit condit);
        DataTable ThongXetNghiem_SLSS_RLCH_XHH_NoiVien_NCC(NormalStatisticCondit condit);
        DataTable ThongXetNghiem_SLSS_RLCH_XHH_NgoaiVien(NormalStatisticCondit condit);
        //Sàng lọc sơ sinh
        DataTable ThongXetNghiem_SLSS_XHH_NoiVien_SoLuong(NormalStatisticCondit condit);
        DataTable ThongXetNghiem_SLSS_XHH_NoiVien_NCC(NormalStatisticCondit condit);
        DataTable ThongXetNghiem_SLSS_MienPhi_NgoaiVien(NormalStatisticCondit condit);
        DataTable ThongXetNghiem_SLSS_MienPhi_NoiVien(NormalStatisticCondit condit);
        DataTable ThongXetNghiem_SLSS_DonVi_TuDen(NormalStatisticCondit condit);
        DataTable ThongXetNghiem_SLSS_DonVi_TGChanDoan(NormalStatisticCondit condit);
        DataTable DashBoard_TongHopmauTheoBoPhan(DateTime tuNgayNhanMau, DateTime denNgayNhanMau, List<string> lstBoPhanAllow);
        DataTable DashBoard_TongHopmauTheoBenhNhan(DateTime tuNgayNhanMau, DateTime denNgayNhanMau);
        DataTable DashBoard_DanhSachTAT(DateTime ngayNhanMau, List<string> lstBoPhanAllow, List<string> lstKhuVucAllow);
        DataTable DashBoard_DanhSachTAT_BenhNhan(DateTime ngayNhanMau, List<string> lstKhuVucAllow);
        #region báo cáo thu tiền
        BaoCaoThuTienModel BaoCaoThuTien(StatisticsCashierCondition condit);
        DataTable DanhSachDaKetChuyen(StatisticsCashierCondition condit);
        #endregion
    }
}
