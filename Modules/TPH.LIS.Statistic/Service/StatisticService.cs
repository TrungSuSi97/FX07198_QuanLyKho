using System;
using System.Collections.Generic;
using System.Data;
using TPH.LIS.Statistic.Models;
using TPH.LIS.Statistic.Repository;
using TPH.LIS.Statistics.Models;

namespace TPH.LIS.Statistic.Service
{
    public class StatisticService : IStatisticService
    {
        private readonly IStatisticRepository _iStatistic = new StatisticRepository();
        public DataTable ThongKeBenhNhanXetNghiem(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongKeBenhNhanXetNghiem(condit);
        }
        public DataTable ThongKeXetNghiemThucHien(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongKeXetNghiemThucHien(condit);
        }
        public DataTable ThongXetNghiemThucHien_DoiTuong(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongXetNghiemThucHien_DoiTuong(condit);
        }
        public DataTable ThongXetNghiem_TheoNhom(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongXetNghiem_TheoNhom(condit);
        }
        public DataTable ThongKeTuongDichVu(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongKeTuongDichVu(condit);
        }
        public DataTable ThongKeChiTiet_BenhNhan(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongKeChiTiet_BenhNhan(condit);
        }
        public DataTable ThongKeChiTiet_BSThucHien(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongKeChiTiet_BSThucHien(condit);
        }
        public bool CapNhatChietKhau_BS(NormalStatisticCondit condit)
        {
            return _iStatistic.CapNhatChietKhau_BS(condit);
        }
        public DataTable ThongKeChiTiet_BSChiDinh(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongKeChiTiet_TongHopBSChiDinh(condit);
        }
        public DataTable ThongKeXetNghiem_TheoNgay(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongKeXetNghiem_TheoNgay(condit);
        }

        public DataTable ThongKeNguoiThucHien(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongKeNguoiThucHien(condit);
        }
        public DataTable ThongKeXetNghiemMay_TheoKetQuaXN(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongKeXetNghiemMay_TheoKetQuaXN(condit);
        }
        public DataTable ThongKeXetNghiemMay(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongKeXetNghiemMay(condit);
        }
        public DataTable ThongKeXetNghiemMay_ChayLay(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongKeXetNghiemMay_ChayLay(condit);
        }
        public DataTable ThongKeXetNghiem_TAT(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongKeXetNghiem_TAT(condit);
        }
        public DataTable ThongXetNghiemThucHien_BenhNhan_SoPhieu(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongXetNghiemThucHien_BenhNhan_SoPhieu(condit);
        }
        public DataTable ThongXetNghiem_SLSS_RLCH_XHH_NoiVien_SoLuong(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongXetNghiem_SLSS_RLCH_XHH_NoiVien_SoLuong(condit);
        }
        public DataTable ThongXetNghiem_SLSS_RLCH_XHH_NoiVien_NCC(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongXetNghiem_SLSS_RLCH_XHH_NoiVien_NCC(condit);
        }
        public DataTable ThongXetNghiem_SLSS_RLCH_XHH_NgoaiVien(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongXetNghiem_SLSS_RLCH_XHH_NgoaiVien(condit);
        }
        //Sàng lọc sơ sinh
        public DataTable ThongXetNghiem_SLSS_XHH_NoiVien_SoLuong(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongXetNghiem_SLSS_XHH_NoiVien_SoLuong(condit);
        }
        public DataTable ThongXetNghiem_SLSS_XHH_NoiVien_NCC(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongXetNghiem_SLSS_XHH_NoiVien_NCC(condit);
        }
        public DataTable ThongXetNghiem_SLSS_MienPhi_NgoaiVien(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongXetNghiem_SLSS_MienPhi_NgoaiVien(condit);
        }
        public DataTable ThongXetNghiem_SLSS_MienPhi_NoiVien(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongXetNghiem_SLSS_MienPhi_NoiVien(condit);
        }

        public DataTable ThongXetNghiem_SLSS_DonVi_TuDen(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongXetNghiem_SLSS_DonVi_TuDen(condit);
        }
        public DataTable ThongXetNghiem_SLSS_DonVi_TGChanDoan(NormalStatisticCondit condit)
        {
            return _iStatistic.ThongXetNghiem_SLSS_DonVi_TGChanDoan(condit);
        }

        public DataTable DashBoard_TongHopmauTheoBoPhan(DateTime tuNgayNhanMau, DateTime denNgayNhanMau, List<string> lstBoPhanAllow)
        {
            return _iStatistic.DashBoard_TongHopmauTheoBoPhan(tuNgayNhanMau, denNgayNhanMau, lstBoPhanAllow);
        }
        public DataTable DashBoard_TongHopmauTheoBenhNhan(DateTime tuNgayNhanMau, DateTime denNgayNhanMau)
        {
            return _iStatistic.DashBoard_TongHopmauTheoBenhNhan(tuNgayNhanMau, denNgayNhanMau);
        }
        public DataTable DashBoard_DanhSachTAT(DateTime ngayNhanMau, List<string> lstBoPhanAllow, List<string> lstKhuVucAllow)
        {
            return _iStatistic.DashBoard_DanhSachTAT(ngayNhanMau, lstBoPhanAllow, lstKhuVucAllow);
        }
        public DataTable DashBoard_DanhSachTAT_BenhNhan(DateTime ngayNhanMau, List<string> lstKhuVucAllow)
        {
            return _iStatistic.DashBoard_DanhSachTAT_BenhNhan(ngayNhanMau, lstKhuVucAllow);
        }
        #region báo cáo thu tiền
        public BaoCaoThuTienModel BaoCaoThuTien(StatisticsCashierCondition condit)
        {
            return _iStatistic.BaoCaoThuTien(condit);
        }
        public DataTable DanhSachDaKetChuyen(StatisticsCashierCondition condit)
        {
            return _iStatistic.DanhSachDaKetChuyen(condit);
        }
        #endregion
    }
}
