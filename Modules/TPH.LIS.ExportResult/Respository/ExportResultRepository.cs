using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;
using TPH.LIS.ExportResult.Constants;
using TPH.LIS.ExportResult.Models;

namespace TPH.LIS.ExportResult.Respository
{
    public class ExportResultRepository : IExportResultRepository
    {
        private DataTable DataCallSP(ExportCondition condit, string spName)
        {
            //  @ThoiGianThongKe int
            //,@Tungay datetime
            //, @DenNgay datetime
            //, @KhoaPhong varchar(250)
            //,@KhuVuc varchar(250)
            //, @DoiTuong varchar(250)
            //, @BSChiDinh varchar(250)
            //, @NhanVienNhapThongTin varchar(250)
            //, @NguonNhap varchar(250)
            //, @NhanVienNhapChiDinh varchar(250)
            //, @NhanVienInKetQua varchar(250)
            //, @NhanVienXacNhanKetQua varchar(250)
            //, @NhomXetNghiem varchar(250)
            //, @BoPhanXetNghiem varchar(250)
            //, @XetNghiem varchar(250)
            //, @ProfileXetNghiem varchar(250)
            //, @LoaiXetNghiem int
            //, @KetQua nvarchar(250)
            //, @GhiChu nvarchar(250)
            //, @XetNghiemCoKetQua bit
            //, @XetNghiemDaXacNhan bit
            //, @MayXetNghiem varchar(250)
            // ,@ServerThongKe varchar(250)
            //, @checkUserAllowKhuVuc bit
            //, @checkUserAllowBoPhan bit
            //, @checkUserAllowNhom bit
            //, @UserAllow varchar(20)
            var resultData = new DataTable();
            var lstTringKey = new Dictionary<string, int>();
            int rowIndex = -1;
            int dayStep = 4;
            var haveSum = false;
            if (condit.SumColumns != null)
            {
                if (resultData.Rows.Count == 0)
                {
                    if (condit.SumColumns.Count > 0)
                    {
                        haveSum = true;
                    }
                }
            }
            for (DateTime date = condit.TuNgay.Date; date <= condit.DenNgay.Date; date = date.AddDays(dayStep + 1))
            {
                var startOfDate = WorkingServices.StartOfDay(date);
                if (startOfDate < condit.TuNgay)
                    startOfDate = condit.TuNgay;

                var endOfDate = WorkingServices.EndOfDay(date.AddDays(dayStep));
                if (endOfDate > condit.DenNgay)
                    endOfDate = condit.DenNgay;

                var paFromDate = WorkingServices.GetParaFromOject("@Tungay", SqlDbType.DateTime);
                paFromDate.Value = startOfDate;
                var paToDate = WorkingServices.GetParaFromOject("@DenNgay", SqlDbType.DateTime);
                paToDate.Value = endOfDate;
                CustomMessageBox.ShowAlert(string.Format("Đang tổng hợp số liệu:{0}Từ {1} đến {2}"
                    , Environment.NewLine, startOfDate.ToString("dd/MM/yyyy HH:mm:ss"), endOfDate.ToString("dd/MM/yyyy HH:mm:ss")), 4, true);

                var sqlPara = new System.Data.SqlClient.SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@ThoiGianXuat", (int)condit.ThoiGianXuat )
                    , paFromDate
                    , paToDate
                    , WorkingServices.GetParaFromOject("@KhoaPhong",condit.KhoaPhong == null ?(object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.KhoaPhong))
                    , WorkingServices.GetParaFromOject("@KhuVuc",condit.KhuVuc  == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.KhuVuc))
                    , WorkingServices.GetParaFromOject("@DoiTuong",condit.DoiTuong == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.DoiTuong))
                    , WorkingServices.GetParaFromOject("@BSChiDinh",condit.BSChiDinh == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.BSChiDinh))
                    , WorkingServices.GetParaFromOject("@NguonNhap",condit.NguonNhap == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.NguonNhap))
                    , WorkingServices.GetParaFromOject("@NhanVienInKetQua",condit.NhanVienInKetQua == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.NhanVienInKetQua))
                    , WorkingServices.GetParaFromOject("@NhanVienXacNhanKetQua",condit.NhanVienXacNhanKetQua == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.NhanVienXacNhanKetQua))
                    , WorkingServices.GetParaFromOject("@NhomXetNghiem",condit.NhomXetNghiem == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.NhomXetNghiem))
                    , WorkingServices.GetParaFromOject("@BoPhanXetNghiem",condit.BoPhanXetNghiem == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.BoPhanXetNghiem))
                    , WorkingServices.GetParaFromOject("@XetNghiem",condit.XetNghiem == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.XetNghiem))
                    , WorkingServices.GetParaFromOject("@ProfileXetNghiem",condit.ProfileXetNghiem == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.ProfileXetNghiem))
                    , WorkingServices.GetParaFromOject("@LoaiDichVu", (int)condit.LoaiDichVu )
                    , WorkingServices.GetParaFromOject("@KetQua ",string.IsNullOrEmpty(condit.KetQua)? (object)DBNull.Value: condit.KetQua)
                    , WorkingServices.GetParaFromOject("@GhiChu ",string.IsNullOrEmpty(condit.GhiChu)? (object)DBNull.Value: condit.GhiChu)
                    , WorkingServices.GetParaFromOject("@XetNghiemCoKetQua", condit.XetNghiemCoKetQua )
                    , WorkingServices.GetParaFromOject("@XetNghiemChuaCoKetQua", condit.XetNghiemChuaCoKetQua )
                    , WorkingServices.GetParaFromOject("@XetNghiemDaXacNhan", condit.XetNghiemDaXacNhan )
                    , WorkingServices.GetParaFromOject("@MayXetNghiem",condit.MayXetNghiem == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.MayXetNghiem))
                    , WorkingServices.GetParaFromOject("@ServerThongKe",condit.ServerName == null ? (object)DBNull.Value:  condit.ServerName)
                    , WorkingServices.GetParaFromOject("@checkUserAllowKhuVuc", condit.KiemTraPhanQuyenKhuVuc )
                    , WorkingServices.GetParaFromOject("@checkUserAllowBoPhan", condit.KiemTraPhanQuyenBoPhan )
                    , WorkingServices.GetParaFromOject("@checkUserAllowNhom", condit.KiemTraPhanQuyenNhom )
                    , WorkingServices.GetParaFromOject("@UserAllow",string.IsNullOrEmpty(condit.UserKiemTraPhanQuyen)? (object)DBNull.Value: condit.UserKiemTraPhanQuyen)
                    , WorkingServices.GetParaFromOject("@loaiXetNghiemIn",condit.LoaiXetNghiem == null? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQL(condit.LoaiXetNghiem.Cast<int>().ToArray(), false))
                    , WorkingServices.GetParaFromOject("@lstMaViKhuan",condit.MaViKhuan == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.MaViKhuan))
                    , WorkingServices.GetParaFromOject("@lstMaLoaiMau",condit.MaLoaiMau == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.MaLoaiMau))
                };
                var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure
                       , spName
                       , true
                       , 180
                       , sqlPara);
                if (ds != null)
                {
                    var dataTemp = ds.Tables[0];
                    if (dataTemp.Rows.Count > 0)
                    {
                        //Kiểm tra có xử lý sum không
                        if (haveSum)
                        {
                            foreach (DataRow drTemp in dataTemp.Rows)
                            {
                                var drResult = resultData.NewRow();
                                var keyNew = string.Empty;
                                for (int i = 0; i < dataTemp.Columns.Count; i++)
                                {
                                    var colName = dataTemp.Columns[i].ColumnName;
                                    if (haveSum)
                                    {
                                        if (!condit.SumColumns.Where(x => x.Equals(colName.Trim(), StringComparison.OrdinalIgnoreCase)).Any())
                                        {
                                            keyNew += string.Format("|^^|{0}", drTemp[i]);
                                        }
                                    }
                                }
                                var found = lstTringKey.Where(x => x.Key.Equals(keyNew, StringComparison.OrdinalIgnoreCase));
                                if (!found.Any())
                                {
                                    // Dòng chưa có trong dữ liệu
                                    rowIndex++;
                                    lstTringKey.Add(keyNew, rowIndex);
                                    if (resultData.Rows.Count == 0)
                                    {
                                        resultData = dataTemp.Clone();
                                    }
                                    var dr = resultData.NewRow();

                                    foreach (DataColumn dtc2 in resultData.Columns)
                                    {
                                        if (dtc2.ColumnName.Equals("tungay", StringComparison.OrdinalIgnoreCase))
                                            dr[dtc2.ColumnName] = condit.TuNgay;
                                        else if (dtc2.ColumnName.Equals("denngay", StringComparison.OrdinalIgnoreCase))
                                            dr[dtc2.ColumnName] = condit.DenNgay;
                                        else
                                            dr[dtc2.ColumnName] = drTemp[dtc2.ColumnName];
                                    }
                                    resultData.Rows.Add(dr);
                                }
                                else
                                {
                                    // tìm index và xử lý cộng
                                    var dic = found.First();
                                    foreach (string str in condit.SumColumns)
                                    {
                                        if (resultData.Columns.Contains(str))
                                        {
                                            //lấy các giá trị sum 
                                            var currentSum = double.Parse(resultData.Rows[dic.Value][str].ToString());
                                            var nextSum = double.Parse(drTemp[str].ToString());
                                            resultData.Rows[dic.Value][str] = currentSum + nextSum;
                                        }
                                    }
                                    resultData.AcceptChanges();
                                }
                            }
                        }
                        else
                        {
                            if (resultData.Rows.Count == 0)
                            {
                                resultData = dataTemp.Clone();
                            }
                            foreach (DataRow drTemp in dataTemp.Rows)
                            {
                                var drResult = resultData.NewRow();
                                for (int i = 0; i < dataTemp.Columns.Count; i++)
                                {
                                    var colName = dataTemp.Columns[i].ColumnName;
                                    if (colName.Equals("tungay", StringComparison.OrdinalIgnoreCase))
                                        drResult[colName] = condit.TuNgay;
                                    else if (colName.Equals("denngay", StringComparison.OrdinalIgnoreCase))
                                        drResult[colName] = condit.DenNgay;
                                    else
                                        drResult[colName] = drTemp[colName];
                                }
                                resultData.Rows.Add(drResult);
                            }
                        }
                    }
                }
            }
            CustomMessageBox.CloseAlert();
            return resultData;
        }
        public DataTable XuatKEtQuaThuongQui(ExportCondition condit)
        {
            return DataCallSP(condit, ExportResultStoredProcedure.expKetQuaXetNghiem_ThuongQui);
        }
        public DataTable XuatThongTinMau_Normal(ExportCondition condit)
        {
            return DataCallSP(condit, ExportResultStoredProcedure.expKetQuaXetNghiem_ThongTinMau);
        }
        public DataTable XuatThongTinMau_SoGiaoNhan(ExportCondition condit)
        {
            return DataCallSP(condit, ExportResultStoredProcedure.expKetQuaXetNghiem_SoGiaoNhan);
        }
        public DataTable XuatThongTinMau_SoTuChoimau(ExportCondition condit)
        {
            return DataCallSP(condit, ExportResultStoredProcedure.expKetQuaXetNghiem_SoTuChoimau);
        }
        public DataTable XuatThongTinMau_GiaoNhanPhieuKQ(ExportCondition condit)
        {
            return DataCallSP(condit, ExportResultStoredProcedure.expKetQuaXetNghiem_SoGiaoNhanKetQua);
        }
        public DataTable XuatKetQuaViSinh_KSD(ExportCondition condit)
        {
            return DataCallSP(condit, ExportResultStoredProcedure.expKetQuaXetNghiem_ViSinhKSD);
        }
        public DataTable DanhSachExport_SangLoc_SoSinh(ExportCondition condit)
        {
            return DataCallSP(condit, ExportResultStoredProcedure.expExport_SangLoc_SoSinh);
        }
        public DataTable DanhSachExport_SangLoc_TruocSinh(ExportCondition condit)
        {
            return DataCallSP(condit, ExportResultStoredProcedure.expExport_SangLoc_TruocSinh);
        }
      
        public DataTable XuatKetQuaViSinh_ThongTinMau(ExportCondition condit)
        {
            return DataCallSP(condit, ExportResultStoredProcedure.expKetQuaXetNghiem_ViSinh_ThongTinMau);
        }
        public DataTable XuatThongTinMau_ViSinh(ExportCondition condit)
        {
            return DataCallSP(condit, ExportResultStoredProcedure.expKetQuaXetNghiem_ViSinh);
        }
        public DataTable XuatThongTinMau_ViSinh_PhieuTienTrinh(ExportCondition condit)
        {
            return DataCallSP(condit, ExportResultStoredProcedure.expKetQuaXetNghiem_ViSinh_PhieuTienTrinh);
        }
        public DataTable XuatThongTinMau_ViSinhThuongQui(ExportCondition condit)
        {
            return DataCallSP(condit, ExportResultStoredProcedure.expKetQuaXetNghiem_ViSinhThuongQui);
        }
    }
}
