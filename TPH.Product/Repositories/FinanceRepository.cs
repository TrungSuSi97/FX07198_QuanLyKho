using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;
using TPH.Product.Model;

namespace TPH.Product.Repositories
{
    public class FinanceRepository : IFinanceRepository
    {
        #region dm tai san cd
        public bool ThemTSCD(TaiSanCdModel model)
        {
            var sqlPara = new SqlParameter[]
            {
            WorkingServices.GetParaFromOject("@MaTaiSan", model.MaTaiSan)
            , WorkingServices.GetParaFromOject("@TenTaiSan", model.TenTaiSan)
            , WorkingServices.GetParaFromOject("@Quantity", model.Quantity)
            , WorkingServices.GetParaFromOject("@TinhTrang", model.TinhTrang)
            , WorkingServices.GetParaFromOject("@DonViSuDung", model.DonViSuDung)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_ins_ThemTSCD"
             , sqlPara) > 0;
        }
        public bool XoaTSCD(TaiSanCdModel model)
        {
            var sqlPara = new SqlParameter[]
            {
            WorkingServices.GetParaFromOject("@MaTaiSan", model.MaTaiSan)
              };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_del_XoaTSCD"
             , sqlPara) > 0;
        }
        public bool SuaTSCD(TaiSanCdModel model)
        {
            var sqlPara = new SqlParameter[]
            {
            WorkingServices.GetParaFromOject("@MaTaiSan", model.MaTaiSan)
            , WorkingServices.GetParaFromOject("@TenTaiSan", model.TenTaiSan)
            , WorkingServices.GetParaFromOject("@Quantity", model.Quantity)
            , WorkingServices.GetParaFromOject("@TinhTrang", model.TinhTrang)
            , WorkingServices.GetParaFromOject("@DonViSuDung", model.DonViSuDung)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_upd_SuaTSCD"
             , sqlPara) > 0;

        }
        public DataTable GetDS_TSCD(TaiSanCdModel model)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaTaiSan", model.MaTaiSan)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "FX_sel_GetDS_TSCD", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        #endregion

        #region hop dong
        public bool ThemHD(HopDongModel model)
        {
            var sqlPara = new SqlParameter[]
            {
            WorkingServices.GetParaFromOject("@MaHopDong", model.MaHopDong)
            , WorkingServices.GetParaFromOject("@NoiDung", model.NoiDung)
            , WorkingServices.GetParaFromOject("@ThoiGianKyKet", model.ThoiGianKyKet)
            , WorkingServices.GetParaFromOject("@ThoiGianKetThuc", model.ThoiGianKetThuc)
            , WorkingServices.GetParaFromOject("@ThoiGianThucHien", model.ThoiGianThucHien)
            , WorkingServices.GetParaFromOject("@TinhTrang", model.TinhTrang)
            , WorkingServices.GetParaFromOject("@GhiChu", model.GhiChu)

            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_ins_ThemHD"
             , sqlPara) > 0;
        }
        public bool XoaHD(HopDongModel model)
        {
            var sqlPara = new SqlParameter[]
            {
            WorkingServices.GetParaFromOject("@MaHopDong", model.MaHopDong)
              };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_del_XoaHD"
             , sqlPara) > 0;
        }
        public bool SuaHD(HopDongModel model)
        {
            var sqlPara = new SqlParameter[]
            {
            WorkingServices.GetParaFromOject("@MaHopDong", model.MaHopDong)
            , WorkingServices.GetParaFromOject("@NoiDung", model.NoiDung)
            , WorkingServices.GetParaFromOject("@ThoiGianKyKet", model.ThoiGianKyKet)
            , WorkingServices.GetParaFromOject("@ThoiGianKetThuc", model.ThoiGianKetThuc)
            , WorkingServices.GetParaFromOject("@ThoiGianThucHien", model.ThoiGianThucHien)
            , WorkingServices.GetParaFromOject("@TinhTrang", model.TinhTrang)
            , WorkingServices.GetParaFromOject("@GhiChu", model.GhiChu)

            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_upd_SuaHD"
             , sqlPara) > 0;

        }
        public DataTable GetDS_HD(HopDongModel model)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaHopDong", model.MaHopDong)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "FX_sel_GetDS_HD", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        #endregion

        #region công nợ
        public bool ThemCN(CongNoModel model)
        {
            var sqlPara = new SqlParameter[]
            {
            WorkingServices.GetParaFromOject("@MaCongNo", model.MaCongNo)
            , WorkingServices.GetParaFromOject("@LoaiHoaDon", model.LoaiHoaDon)
            , WorkingServices.GetParaFromOject("@MaHoaDon", model.MaHoaDon)
            , WorkingServices.GetParaFromOject("@ThongTinKhachHang", model.ThongTinKhachHang)
            , WorkingServices.GetParaFromOject("@CongNoPhaiTra", model.CongNoPhaiTra)
            , WorkingServices.GetParaFromOject("@ThoiHanTra", model.ThoiHanTra)

            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_ins_ThemCN"
             , sqlPara) > 0;
        }
        public bool XoaCN(CongNoModel model)
        {
            var sqlPara = new SqlParameter[]
            {
            WorkingServices.GetParaFromOject("@MaCongNo", model.MaCongNo)
              };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_del_XoaCN"
             , sqlPara) > 0;
        }
        public bool SuaCN(CongNoModel model)
        {
            var sqlPara = new SqlParameter[]
            {
            WorkingServices.GetParaFromOject("@MaCongNo", model.MaCongNo)
            , WorkingServices.GetParaFromOject("@LoaiHoaDon", model.LoaiHoaDon)
            , WorkingServices.GetParaFromOject("@MaHoaDon", model.MaHoaDon)
            , WorkingServices.GetParaFromOject("@ThongTinKhachHang", model.ThongTinKhachHang)
            , WorkingServices.GetParaFromOject("@CongNoPhaiTra", model.CongNoPhaiTra)
            , WorkingServices.GetParaFromOject("@ThoiHanTra", model.ThoiHanTra)

            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_upd_SuaCN"
             , sqlPara) > 0;

        }
        public DataTable GetDS_CN(CongNoModel model)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaCongNo", model.MaCongNo)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "FX_sel_GetDS_CN", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        #endregion
        #region ngân sách
        public bool ThemNganSach(NganSachModel model)
        {
            var sqlPara = new SqlParameter[]
            {
            WorkingServices.GetParaFromOject("@MaNganSach", model.MaNganSach)
            , WorkingServices.GetParaFromOject("@TienMatHienCo", model.TienMatHienCo)
            , WorkingServices.GetParaFromOject("@NguonVonBank", model.NguonVonBank)
            , WorkingServices.GetParaFromOject("@TienHangKho", model.TienHangKho)
            , WorkingServices.GetParaFromOject("@DoanhThuDaBan", model.DoanhThuDaBan)
            , WorkingServices.GetParaFromOject("@NganSachNhapHang", model.NganSachNhapHang)

            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_ins_ThemNganSach"
             , sqlPara) > 0;
        }
        public bool XoaNganSach(NganSachModel model)
        {
            var sqlPara = new SqlParameter[]
            {
            WorkingServices.GetParaFromOject("@MaNganSach", model.MaNganSach)
              };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_del_XoaNganSach"
             , sqlPara) > 0;
        }
        public bool SuaNganSach(NganSachModel model)
        {
            var sqlPara = new SqlParameter[]
            {
            WorkingServices.GetParaFromOject("@MaNganSach", model.MaNganSach)
            , WorkingServices.GetParaFromOject("@TienMatHienCo", model.TienMatHienCo)
            , WorkingServices.GetParaFromOject("@NguonVonBank", model.NguonVonBank)
            , WorkingServices.GetParaFromOject("@TienHangKho", model.TienHangKho)
            , WorkingServices.GetParaFromOject("@DoanhThuDaBan", model.DoanhThuDaBan)
            , WorkingServices.GetParaFromOject("@NganSachNhapHang", model.NganSachNhapHang)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_upd_SuaNganSach"
             , sqlPara) > 0;

        }
        public DataTable GetDS_NganSach(NganSachModel model)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaNganSach", model.MaNganSach)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "FX_sel_GetDS_NganSach", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }

        #endregion
    }
}
