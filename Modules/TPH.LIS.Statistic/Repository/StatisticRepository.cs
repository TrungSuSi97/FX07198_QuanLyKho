using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TPH.Cashier.CashierContanst;
using TPH.Language;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;
using TPH.LIS.Statistic.Constants;
using TPH.LIS.Statistic.Models;
using TPH.LIS.Statistics.Models;

namespace TPH.LIS.Statistic.Repository
{
    public class StatisticRepository : IStatisticRepository
    {
        private DataTable DataCallSP(NormalStatisticCondit condit, string spName)
        {
            var resultData = new DataTable();
            var lstTringKey = new Dictionary<string, int>();
            int rowIndex = -1;
            int dayStep = 0;
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

                var paFromDate = new System.Data.SqlClient.SqlParameter("@Tungay", SqlDbType.DateTime);
                paFromDate.Value = startOfDate;
                var paToDate = new System.Data.SqlClient.SqlParameter("@DenNgay", SqlDbType.DateTime);
                paToDate.Value = endOfDate;
                CustomMessageBox.ShowAlert(string.Format(
                    LanguageExtension.GetResourceValueFromValue("Đang tổng hợp số liệu:{0}Từ {1} đến {2}",
                        LanguageExtension.AppLanguage)
                    , Environment.NewLine, startOfDate.ToString("dd/MM/yyyy HH:mm:ss"),
                    endOfDate.ToString("dd/MM/yyyy HH:mm:ss")), 4);
                var sqlPara = new[]
                    {
                    WorkingServices.GetParaFromOject("@ThoiGianThongKe", (int)condit.ThoiGianThongKe)
                    , paFromDate
                    , paToDate
                    , WorkingServices.GetParaFromOject("@KhoaPhong",condit.KhoaPhong == null ?(object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.KhoaPhong))
                    , WorkingServices.GetParaFromOject("@KhuVuc",condit.KhuVuc  == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.KhuVuc))
                    , WorkingServices.GetParaFromOject("@DoiTuong",condit.DoiTuong == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.DoiTuong))
                    , WorkingServices.GetParaFromOject("@BSChiDinh",condit.BSChiDinh == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.BSChiDinh))
                    , WorkingServices.GetParaFromOject("@NhanVienNhapThongTin",condit.NhanVienNhapThongTin == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.NhanVienNhapThongTin))
                    , WorkingServices.GetParaFromOject("@NguonNhap",condit.NguonNhap == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.NguonNhap))
                    , WorkingServices.GetParaFromOject("@NhanVienNhapChiDinh",condit.NhanVienNhapChiDinh == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.NhanVienNhapChiDinh))
                    , WorkingServices.GetParaFromOject("@NhanVienInKetQua",condit.NhanVienInKetQua == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.NhanVienInKetQua))
                    , WorkingServices.GetParaFromOject("@NhanVienXacNhanKetQua",condit.NhanVienXacNhanKetQua == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.NhanVienXacNhanKetQua))
                    , WorkingServices.GetParaFromOject("@NhomXetNghiem",condit.NhomXetNghiem == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.NhomXetNghiem))
                    , WorkingServices.GetParaFromOject("@BoPhanXetNghiem",condit.BoPhanXetNghiem == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.BoPhanXetNghiem))
                    , WorkingServices.GetParaFromOject("@XetNghiem",condit.XetNghiem == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.XetNghiem))
                    , WorkingServices.GetParaFromOject("@ProfileXetNghiem",condit.ProfileXetNghiem == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.ProfileXetNghiem))
                    , WorkingServices.GetParaFromOject("@LoaiXetNghiem", (int)condit.LoaiXetNghiem )
                    , WorkingServices.GetParaFromOject("@KetQua ",string.IsNullOrEmpty(condit.KetQua)? (object)DBNull.Value: condit.KetQua)
                    , WorkingServices.GetParaFromOject("@GhiChu ",string.IsNullOrEmpty(condit.GhiChu)? (object)DBNull.Value: condit.GhiChu)
                    , WorkingServices.GetParaFromOject("@XetNghiemCoKetQua", condit.XetNghiemCoKetQua )
                    , WorkingServices.GetParaFromOject("@XetNghiemDaXacNhan", condit.XetNghiemDaXacNhan )
                    , WorkingServices.GetParaFromOject("@MayXetNghiem",condit.MayXetNghiem == null ? (object)DBNull.Value:  Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.MayXetNghiem))
                    , WorkingServices.GetParaFromOject("@ServerThongKe",condit.ServerName == null ? (object)DBNull.Value:  condit.ServerName)
                    , WorkingServices.GetParaFromOject("@checkUserAllowKhuVuc", condit.KiemTraPhanQuyenKhuVuc )
                    , WorkingServices.GetParaFromOject("@checkUserAllowBoPhan", condit.KiemTraPhanQuyenBoPhan )
                    , WorkingServices.GetParaFromOject("@checkUserAllowNhom", condit.KiemTraPhanQuyenNhom )
                    , WorkingServices.GetParaFromOject("@UserAllow",string.IsNullOrEmpty(condit.UserKiemTraPhanQuyen)? (object)DBNull.Value: condit.UserKiemTraPhanQuyen)
                    };
                var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure
                 , spName
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
                                        if (!condit.SumColumns.Any(x => x.Equals(colName.Trim(), StringComparison.OrdinalIgnoreCase)))
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
                    else
                    {
                        //Kiểm tra gán các đột để tránh không có data trả về data ko co cột
                        if (resultData.Rows.Count == 0)
                        {
                            resultData = dataTemp.Clone();
                        }
                    }
                }
            }
            CustomMessageBox.CloseAlert();
            return resultData;
        }
        private string ConvertConditForNormal(NormalStatisticCondit condit, string aliasBenhNhanTiepNhan
            , string aliasBenhNhanXetNghiem, string aliasKetQuaXn)
        {
            string returnCondit = string.Empty;
            var sb = new StringBuilder();
            //Thời gian thống kê
            if (condit.ThoiGianThongKe == Constants.EnumThoiGianThongKe.ThoiGianInKetQuaDauTien)
                sb.AppendFormat(" where {0}.thoigianindautien between '{1}' and '{2}'", aliasBenhNhanXetNghiem, condit.TuNgay.ToString("yyyy-MM-dd HH:mm:00"), condit.DenNgay.ToString("yyyy-MM-dd HH:mm:59"));
            else if (condit.ThoiGianThongKe == Constants.EnumThoiGianThongKe.ThoiGianDangKyHis)
                sb.AppendFormat(" where {0}.NgayDK between '{1}' and '{2}'", aliasBenhNhanTiepNhan, condit.TuNgay.ToString("yyyy-MM-dd HH:mm:00"), condit.DenNgay.ToString("yyyy-MM-dd HH:mm:59"));
            else
                sb.AppendFormat(" where {0}.ThoiGianNhap between '{1}' and '{2}'", aliasBenhNhanTiepNhan, condit.TuNgay.ToString("yyyy-MM-dd HH:mm:00"), condit.DenNgay.ToString("yyyy-MM-dd HH:mm:59"));

            //Khoa phòng chỉ định
            var khoaPhong = Utilities.ConvertStrinArryToInClauseSQL(condit.KhoaPhong, true);
            if (!string.IsNullOrEmpty(khoaPhong))
                sb.AppendFormat("\n and {0}.MaDonVi in ({1})", aliasBenhNhanTiepNhan, khoaPhong);
            var khuVuc = Utilities.ConvertStrinArryToInClauseSQL(condit.KhuVuc, true);
            if (!string.IsNullOrEmpty(khuVuc))
                sb.AppendFormat("\n and exists (Select kp.MaKhoaPhong from {{TPH_Standard}}_Dictionary.dbo.DM_KHOAPHONG kp where kp.mabophan in ({1}) and {0}.MaDonVi = kp.MaKhoaPhong )", aliasBenhNhanTiepNhan, khuVuc);
            //Đối tượng dịch vụ
            var doiTuong = Utilities.ConvertStrinArryToInClauseSQL(condit.DoiTuong, true);
            if (!string.IsNullOrEmpty(doiTuong))
                sb.AppendFormat("\n and {0}.DoiTuongDichVu in ({1})", aliasBenhNhanTiepNhan, doiTuong);
            //BS Chỉ định
            var bacSi = Utilities.ConvertStrinArryToInClauseSQL(condit.BSChiDinh, true);
            if (!string.IsNullOrEmpty(bacSi))
                sb.AppendFormat("\n and {0}.BacSiCD in ({1})", aliasBenhNhanTiepNhan, bacSi);
            //Nhan vien nhập thông tin
            var nhanvienNhapThongTin = Utilities.ConvertStrinArryToInClauseSQL(condit.NhanVienNhapThongTin, true);
            if (!string.IsNullOrEmpty(bacSi))
                sb.AppendFormat("\n and {0}.UserNhap in ({1})", aliasBenhNhanTiepNhan, bacSi);
            //Nguồn nhập
            var nguonNhap = Utilities.ConvertStrinArryToInClauseSQL(condit.NguonNhap, true);
            if (!string.IsNullOrEmpty(nguonNhap))
                sb.AppendFormat("\n and {0}.nguonnhap in ({1})", aliasBenhNhanTiepNhan, nguonNhap);
            //Nhân viên nhập chỉ định
            var nhanvienNhapChiDinh = Utilities.ConvertStrinArryToInClauseSQL(condit.NhanVienNhapChiDinh, true);
            if (!string.IsNullOrEmpty(nhanvienNhapChiDinh))
                sb.AppendFormat("\n and {0}.UserNhapCD in ({1})", aliasKetQuaXn, nhanvienNhapChiDinh);
            //Nhân viên in kết quả
            var nhanvienInKetQua = Utilities.ConvertStrinArryToInClauseSQL(condit.NhanVienInKetQua, true);
            if (!string.IsNullOrEmpty(nhanvienInKetQua))
                sb.AppendFormat("\n and {0}.NguoiInXN in ({1})", aliasKetQuaXn, nhanvienInKetQua);
            //Nhân viên xác nhận kết quả
            var nhanvienXacNhanKetQua = Utilities.ConvertStrinArryToInClauseSQL(condit.NhanVienXacNhanKetQua, true);
            if (!string.IsNullOrEmpty(nhanvienXacNhanKetQua))
                sb.AppendFormat("\n and {0}.NguoiXacNhan in ({1})", aliasKetQuaXn, nhanvienXacNhanKetQua);
            //Nhóm xét nghiệm
            var nhomXetNghiem = Utilities.ConvertStrinArryToInClauseSQL(condit.NhomXetNghiem, true);
            if (!string.IsNullOrEmpty(nhomXetNghiem))
                sb.AppendFormat("\n and {0}.MaNhomCLS in ({1})", aliasKetQuaXn, nhomXetNghiem);
            //Bộ phận xét nghiệm
            var bophanXetNghiem = Utilities.ConvertStrinArryToInClauseSQL(condit.BoPhanXetNghiem, true);
            if (!string.IsNullOrEmpty(bophanXetNghiem))
                sb.AppendFormat("\n and exists (select nh.MaNhomCLS from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom nh where nh.MaBoPhan in ({1}) and nh.MaNhomCLS = {0}.MaNhomCLS)", aliasKetQuaXn, bophanXetNghiem);
            //Xét nghiệm
            var xetNghiem = Utilities.ConvertStrinArryToInClauseSQL(condit.XetNghiem, true);
            if (!string.IsNullOrEmpty(xetNghiem))
                sb.AppendFormat("\n and {0}.MaXn in ({1})", aliasKetQuaXn, xetNghiem);
            //Profile xét nghiệm
            var xetNghiemProfile = Utilities.ConvertStrinArryToInClauseSQL(condit.ProfileXetNghiem, true);
            if (!string.IsNullOrEmpty(xetNghiemProfile))
                sb.AppendFormat("\n and exists (select pr.MaXn from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Profile_ChiTiet pr where pr.ProfileID in ({1}) and pr.MaXN = {0}.MaXn)", aliasKetQuaXn, xetNghiemProfile);
            //Loại xét nghiệm
            if (condit.LoaiXetNghiem == Constants.EnumDieuKienXetNghiem.XetNghiemChiSo)
                sb.AppendFormat("\n and exists (select xw.MaXn from {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem xw where xw.KhongSD = 0 and xw.MaXn = {0}.MaXn)", aliasKetQuaXn);
            else if (condit.LoaiXetNghiem == Constants.EnumDieuKienXetNghiem.XetNghiemDichVu)
                sb.AppendFormat("\n and exists (select xw.MaXn from {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem xw where xw.KhongSD = 1 and xw.MaXn = {0}.MaXn)", aliasKetQuaXn); ;
            //Kết quả xét nghiệm
            if (!string.IsNullOrEmpty(condit.KetQua))
                sb.AppendFormat("\n and {0}.KetQua like N'{1}'", aliasKetQuaXn, Utilities.ConvertSqlString(condit.KetQua));
            //ghi chú xét nghiệm
            if (!string.IsNullOrEmpty(condit.GhiChu))
                sb.AppendFormat("\n and {0}.GhiChu like N'{1}'", aliasKetQuaXn, Utilities.ConvertSqlString(condit.GhiChu));
            //Xét nghiệm có kết quả
            if (condit.XetNghiemCoKetQua)
                sb.AppendFormat("\n and (case when {0}.XNChinh  = 1 then (select count (*) from {1}ketqua_cls_xetnghiem kq2 where (kq2.ProfileID = isnull({0}.ProfileID, '-NULL-') or kq2.IdChiDinhHis = isnull({0}.IdChiDinhHis, '-NULL-') or kq2.MaCapTren = isnull({0}.MaXn_HIS, '-NULL-')) and kq2.MaTiepNhan = {0}.MaTiepNhan and kq2.KetQua is not null) when {0}.KetQua is null or rtrim({0}.KetQua) ='' then 0 else 1 end ) > 0 ", aliasKetQuaXn, condit.ServerName);
            //Xét nghiệm đã xác nhận
            if (condit.XetNghiemDaXacNhan)
                sb.AppendFormat("\n and ({0}.XacNhanKQ = 1 or  ({0}.XnChinh = 1 and exists (select maxn from {1}ketqua_cls_xetnghiem kq2 where kq2.MaCapTren = {0}.MaXN_HIS and kq2.XacNhanKQ = 1 and kq2.MaTiepNhan = k.MaTiepNhan))) ", aliasKetQuaXn, condit.ServerName);
            //Máy xét nghiệm
            var mayXetNghiem = Utilities.ConvertStrinArryToInClauseSQL(condit.MayXetNghiem, false);
            if (!string.IsNullOrEmpty(mayXetNghiem))
            {
                //sb.AppendFormat("\n and isnull ( (case when nullif(rtrim({0}.modules),'') is null  then null else cast({0}.IDMayXetNghiem as varchar(5)) + '_' + rtrim({0}.modules) end), cast({0}.IDMayXetNghiem as varchar(5))) in ({1})", aliasKetQuaXn, mayXetNghiem);
                sb.AppendFormat("\n and isnull (nullif(rtrim({0}.modules),''), {0}.IDMayXetNghiem) in ({1})", aliasKetQuaXn, mayXetNghiem);
            }
            return sb.ToString();
        }

        private string ConvertConditForAnalyzer(NormalStatisticCondit condit, string aliasKetQuaMayXn, string aliasDanhMucXn)
        {
            string returnCondit = string.Empty;
            var sb = new StringBuilder();
            //Thời gian thống kê
            if (condit.ThoiGianThongKe == Constants.EnumThoiGianThongKe.ThoiGianDangKyHis)
                sb.AppendFormat(" where {0}.ngayxn between '{1}' and '{2}'", aliasKetQuaMayXn, condit.TuNgay.ToString("yyyy-MM-dd HH:mm:00"), condit.DenNgay.ToString("yyyy-MM-dd HH:mm:59"));
            else
                sb.AppendFormat(" where {0}.thoigiantumay between '{1}' and '{2}'", aliasKetQuaMayXn, condit.TuNgay.ToString("yyyy-MM-dd HH:mm:00"), condit.DenNgay.ToString("yyyy-MM-dd HH:mm:59"));
            //Nhóm xét nghiệm
            var nhomXetNghiem = Utilities.ConvertStrinArryToInClauseSQL(condit.NhomXetNghiem, true);
            if (!string.IsNullOrEmpty(nhomXetNghiem))
                sb.AppendFormat("\n and {0}.MaNhomCLS in ({1})", aliasDanhMucXn, nhomXetNghiem);
            //Bộ phận xét nghiệm
            var bophanXetNghiem = Utilities.ConvertStrinArryToInClauseSQL(condit.BoPhanXetNghiem, true);
            if (!string.IsNullOrEmpty(bophanXetNghiem))
                sb.AppendFormat("\n and  exists (select nh.MaNhomCLS from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom nh where nh.MaBoPhan in ({1}) and nh.MaNhomCLS  = {0}.MaNhomCLS)", aliasDanhMucXn, bophanXetNghiem);
            //Xét nghiệm
            var xetNghiem = Utilities.ConvertStrinArryToInClauseSQL(condit.XetNghiem, true);
            if (!string.IsNullOrEmpty(xetNghiem))
                sb.AppendFormat("\n and {0}.MaXn in ({1})", aliasKetQuaMayXn, xetNghiem);
            //Profile xét nghiệm
            var xetNghiemProfile = Utilities.ConvertStrinArryToInClauseSQL(condit.ProfileXetNghiem, true);
            if (!string.IsNullOrEmpty(xetNghiemProfile))
                sb.AppendFormat("\n and exists (select pr.MaXn from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Profile_ChiTiet pr where pr.ProfileID in ({1}) and r.MaXn = {0}.MaXn )", aliasKetQuaMayXn, xetNghiemProfile);
            //Loại xét nghiệm
            if (condit.LoaiXetNghiem == Constants.EnumDieuKienXetNghiem.XetNghiemChiSo)
                sb.AppendFormat("\n and exists (select xw.MaXn from {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem xw where xw.KhongSD = 0 and xw.MaXn = {0}.MaXn)", aliasKetQuaMayXn);
            else if (condit.LoaiXetNghiem == Constants.EnumDieuKienXetNghiem.XetNghiemDichVu)
                sb.AppendFormat("\n and exists (select xw.MaXn from {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem xw where xw.KhongSD = 1 and xw.MaXn = {0}.MaXn)", aliasKetQuaMayXn);
            //Kết quả xét nghiệm
            if (!string.IsNullOrEmpty(condit.KetQua))
                sb.AppendFormat("\n and {0}.KetQua like N'{1}'", aliasKetQuaMayXn, Utilities.ConvertSqlString(condit.KetQua));
            //Xét nghiệm có kết quả
            if (condit.XetNghiemCoKetQua)
                sb.AppendFormat("\n and  {0}.KetQua is null and len(rtrim({0}.KetQua)) > 0 ", aliasKetQuaMayXn);
            //Máy xét nghiệm
            var mayXetNghiem = Utilities.ConvertStrinArryToInClauseSQL(condit.MayXetNghiem, false);
            if (!string.IsNullOrEmpty(mayXetNghiem))
            {
                sb.AppendFormat("\n and isnull (nullif(rtrim({0}.modulename),''), {0}.IdMay) in ({1})", aliasKetQuaMayXn, mayXetNghiem);
            }
            return sb.ToString();

        }
        public DataTable ThongKeBenhNhanXetNghiem(NormalStatisticCondit condit)
        {   
            return DataCallSP(condit, StatisticStoredProcedures.statsXetNghiem_TongHopBenhNhan);
        }
        public DataTable ThongKeChiTiet_BenhNhan(NormalStatisticCondit condit)
        {
            var sb = new StringBuilder();
            sb.Append("select tx.UserInXN , Th.TenNhanVien as NguoiThucHien,T.MaTiepNhan, T.TenBN,T.Tuoi,T.DiaChi, Case when T.GioiTinh = 'M' then N'Nam' when T.GioiTinh = 'F' then N'Nữ' else N'?' end as GioiTinh, D.TenDoiTuongDichVu,N.TenNhanVien as BacSiCD, T.DoiTuongDichVu , Sum(K.GiaRieng) as TongTien, Count(distinct K.MaXN) as SoLuong,cast (0 as bit) as isCate");
            sb.AppendFormat("\n from {0}BenhNhan_TiepNhan T inner join {0}KetQua_CLS_XetNghiem K on T.MaTiepNhan = K.MaTiepNhan inner join {0}BenhNhan_CLS_XetNghiem tx on tx.MaTiepNhan = t.MaTiepNhan ", condit.ServerName);
            sb.Append("\n left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu D on d.MaDoiTuongDichVu = T.DoiTuongDichVu ");
            sb.Append("\n left join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN N on N.MaNhanVien = T.BacSiCD");
            sb.Append("\n left join (select nd.MaNguoiDung,nv.TenNhanVien from {{TPH_Standard}}_System.dbo.QL_NguoiDung nd inner join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on nd.MaNhanVien = nv.MaNhanVien) as th on th.MaNguoiDung = tx.UserInXN ");
            //Ghép với điều kiện
            sb.AppendFormat("\n{0}", ConvertConditForNormal(condit, "T", "TX", "K"));
            sb.Append("\n and Tx.DaInKQXN = 1");
            sb.Append("\n group by tx.UserInXN, Th.TenNhanVien, T.MaTiepNhan,T.TenBN, T.Tuoi,T.DiaChi,D.TenDoiTuongDichVu,N.TenNhanVien,T.DoiTuongDichVu,T.GioiTinh");
            sb.Append("\n order by  tx.UserInXN, T.MaTiepNhan,T.TenBN, D.TenDoiTuongDichVu asc");
            return DataProvider.ExecuteDataset(CommandType.Text, sb.ToString()).Tables[0];
        }
        public DataTable ThongKeXetNghiemThucHien(NormalStatisticCondit condit)
        {
            return DataCallSP(condit, StatisticStoredProcedures.statsXetNghiem_TongHopXetNghiem);
        }
        public DataTable ThongXetNghiemThucHien_DoiTuong(NormalStatisticCondit condit)
        {
            return DataCallSP(condit, StatisticStoredProcedures.statsXetNghiem_TongHopXetNghiem_DoiTuong);
        }
        public DataTable ThongXetNghiem_TheoNhom(NormalStatisticCondit condit)
        {
            
            var sb = new StringBuilder();
            sb.Append("select isnull(b.ThuTuIn,bp.ThuTuIn) as ThuTuIn ,bp.MaBoPhan,bp.TenBoPhan, sum(isnull(TienCong,0)) as TienCong");
            sb.Append("\n , sum(isnull(TienCong,0)) as TienCong");
            sb.Append("\n ,Sum(isnull(TongTien,0)) as TongTien, sum(isnull(SoLuong,0)) as SoLuong, sum(isnull(SoLuongHeSo,0)) as SoLuongHeSo,sum(isnull(DuongTinh,0)) as DuongTinh");
            sb.Append("\n ,sum(isnull(PF,0)) as PF");
            sb.Append("\n ,sum(isnull(PV,0)) as PV");
            sb.Append("\n ,sum(isnull(PhoiHop,0)) as PhoiHop");
            sb.Append("\n ,sum(isnull(NoiTru,0)) as NoiTru");
            sb.AppendFormat("\n ,cast ('{0}' as datetime) as TuNgay,cast ('{1}' as datetime) as DenNgay ", condit.TuNgay.ToString("yyyy-MM-dd HH:mm:ss"), condit.DenNgay.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.Append("\n from");
            sb.Append("\n (");
            sb.Append("\n select a.ThuTuIn");
            sb.Append("\n ,case when MaXN in ('KST_SotRetTC', 'MD_HIVNhanh') then MaXN else MaBoPhan end as MaBoPhan");
            sb.Append("\n ,case when MaXN in ('KST_SotRetTC', 'MD_HIVNhanh') then TenXN else TenBoPhan end as TenBoPhan");
            sb.Append("\n , sum(TienCong) as TienCong");
            sb.Append("\n ,Sum(TongTien) as TongTien, sum(SoLuong) as SoLuong, sum(SoLuongHeSo) as SoLuongHeSo,sum(DuongTinh) as DuongTinh");
            sb.Append("\n ,sum(PF) as PF");
            sb.Append("\n ,sum(PV) as PV");
            sb.Append("\n ,sum(PhoiHop) as PhoiHop");
            sb.Append("\n ,sum(NoiTru) as NoiTru");
            sb.Append("\n , IsCate");
            sb.Append("\n from(");
            sb.Append("\n  Select dx.SapXep, K.MaXN, K.TenXN, K.MaNhomCLS, C.TenNhomCLS, case when  k.MaXN  = 'MD_HIVNhanh' then 3 else b.SapXep end as ThuTuIn, b.MaBoPhan, b.TenBoPhan, sum(K.TienCong) as TienCong");
            sb.Append("\n , K.GiaRieng");
            sb.Append("\n , Sum(k.GiaRieng) as TongTien, cast(Count(k.MaXN) as float) as SoLuong, cast(Count(k.MaXN) as float) * k.HeSoXN as SoLuongHeSo");
            sb.Append("\n , cast(0 as bit) as IsCate");
            sb.Append("\n , case when ltrim(rtrim(k.KetQua)) = N'Dương tính' and k.MaXN in ('KST_SotRetTC', 'MD_HIVNhanh')   then 1 else 0 end as DuongTinh");
            sb.Append("\n , case when ltrim(rtrim(k.KetQua)) = N'Dương tính' and k.MaXN in ('KST_SotRetTC') and k.GhiChu = 'P.F'  then 1 else 0 end as PF");
            sb.Append("\n , case when ltrim(rtrim(k.KetQua)) = N'Dương tính' and k.MaXN in ('KST_SotRetTC') and k.GhiChu = 'P.V'  then 1 else 0 end as PV");
            sb.Append("\n , case when ltrim(rtrim(k.KetQua)) = N'Dương tính' and k.MaXN in ('KST_SotRetTC') and k.GhiChu = N'Phối hợp'  then 1 else 0 end as PhoiHop");
            sb.Append("\n , sum(case when kh.mabophan = 'NT' then 1 else 0 end) as NoiTru");
            sb.AppendFormat("\n from {0}BenhNhan_TiepNhan(nolock)T inner join {0}KetQua_CLS_XetNghiem(nolock) K on T.MaTiepNhan = K.MaTiepNhan", condit.ServerName);
            sb.AppendFormat("\n inner join {0}BenhNhan_CLS_XetNghiem(nolock) tx on T.MaTiepNhan = tx.MaTiepNhan", condit.ServerName);
            sb.Append("\n inner join DM_XetNghiem(nolock) dx on K.maxn = dx.maxn");
            sb.Append("\n inner join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom(nolock) C on K.MaNHomCLS = C.MaNhomCLS");
            sb.Append("\n left join {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_BOPHAN b on b.MaBoPhan = c.MaBoPhan");
            sb.Append("\n left join {{TPH_Standard}}_Dictionary.dbo.DM_KHOAPHONG kh on kh.MaKhoaPhong = t.MaDonVi");
            //Ghép với điều kiện
            sb.AppendFormat("\n{0}", ConvertConditForNormal(condit, "T", "TX", "K"));
            sb.Append("\n group by dx.SapXep, K.MaXN, K.TenXN, K.MaNhomCLS, C.TenNhomCLS, k.HeSoXN, b.MaBoPhan, b.TenBoPhan, b.SapXep, K.GiaRieng, k.KetQua, k.GhiChu, kh.mabophan");
            sb.Append("\n ) as A");
            sb.Append("\n group by");
            sb.Append("\n a.ThuTuIn, MaXN, TenXN, MaNhomCLS, TenNhomCLS, MaBoPhan, TenBoPhan,IsCate");
            sb.Append("\n ) as B right join ( select SapXep as ThuTuIn, MaBoPhan, TenBoPhan from {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_BOPHAN where KhongSd = 0 union all select ThuTuIn, MaXN as MaBoPhan, TenXN as TenBoPhan from  {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem where MaXN in ('KST_SotRetTC','MD_HIVNhanh')) as  bp on bp.MaBoPhan = b.MaBoPhan");
            sb.Append("\n group by isnull(b.ThuTuIn,bp.ThuTuIn), bp.MaBoPhan, bp.TenBoPhan,b.IsCate");
            sb.Append("\n order by isnull(b.ThuTuIn,bp.ThuTuIn) asc");
            return DataProvider.ExecuteDataset(CommandType.Text, sb.ToString()).Tables[0];
        }
        public DataTable ThongKeTuongDichVu(NormalStatisticCondit condit)
        {
            return DataCallSP(condit, StatisticStoredProcedures.statsXetNghiem_TongHopXetNghiem_DoiTuongDichVu);
        }
       
        public DataTable ThongKeChiTiet_BSThucHien(NormalStatisticCondit condit)
        {
            var dtTemp = DataCallSP(condit, StatisticStoredProcedures.statsXetNghiem_TongHopXetNghiem_BacSiChiDinh);

            DataTable dtResult = WorkingServices.DataTable_DistinctValue(dtTemp,
                new string[] { "NgayTiepNhan", "MaTiepNhan", "TenBN", "BacSiCD", "TenNhanVien", "TuNgay", "DenNgay" });
            dtResult.Columns.Add("TenXN", typeof(string));
            dtResult.Columns.Add("TongTien", typeof(double));
            dtResult.Columns.Add("TienCong", typeof(double));

            double sumTongTien = 0, sumTienCong = 0;
            string matiepNhanMain = string.Empty;
            string matiepNhanDetail = string.Empty;
            string tenXn = string.Empty;

            foreach (DataRow dr in dtResult.Rows)
            {
                tenXn = string.Empty;
                matiepNhanMain = dr["MatiepNhan"].ToString().Trim();

                DataTable dtTempResultDetail = dtTemp.Clone();
                dtTemp.Select("MaTiepNhan = '" + matiepNhanMain + "'").CopyToDataTable(dtTempResultDetail, LoadOption.OverwriteChanges);
                sumTongTien = double.Parse(dtTempResultDetail.Compute("Sum(TongTien)", "").ToString());
                sumTienCong = double.Parse(dtTempResultDetail.Compute("Sum(TienCong)", "").ToString());

                for (int i = 0; i < dtTempResultDetail.Rows.Count; i++)
                {
                    tenXn += (string.IsNullOrEmpty(tenXn) ? dtTempResultDetail.Rows[i]["TenXN"].ToString().Trim() : " | " + dtTempResultDetail.Rows[i]["TenXN"].ToString().Trim());
                }

                dr["TongTien"] = sumTongTien;
                dr["TienCong"] = sumTienCong;
                dr["TenXN"] = tenXn;
                dtResult.AcceptChanges();
            }

            return dtResult;
        }
        public bool CapNhatChietKhau_BS(NormalStatisticCondit condit)
        {
            var sb = new StringBuilder();
            sb.Append("update ketqua_cls_xetnghiem");
            sb.Append("\n set ChietKhau=c.Chietkhau,TienCong=c.TienCong");
            sb.AppendFormat("\n from {0}benhnhan_tiepnhan t inner join {0}ketqua_cls_xetnghiem k on t.MaTiepNhan=k.MaTiepNhan inner join {0}BenhNhan_CLS_XetNghiem tx on T.MaTiepNhan = tx.MaTiepNhan", condit.ServerName);
            sb.AppendFormat("\ninner join QL_NhanVien_ChietKhau c on t.BacSiCD=c.MaNhanVien and c.MaLoaiDichVu='{0}' and c.MaDichVu=k.MaXN\n", "ClsXetNghiem");
            //Ghép với điều kiện
            sb.AppendFormat("\n{0}", ConvertConditForNormal(condit, "T", "TX", "K"));
            sb.Append("\n and c.tiencong<>k.TienCong");
            return DataProvider.ExecuteQuery(sb.ToString());
        }
        public DataTable ThongKeChiTiet_TongHopBSChiDinh(NormalStatisticCondit condit)
        {
            return DataCallSP(condit, StatisticStoredProcedures.statsXetNghiem_TongHopXetNghiem_TongHopBacSiChiDinh);
        }
        public DataTable ThongKeXetNghiem_TheoNgay(NormalStatisticCondit condit)
        {
            return DataCallSP(condit, StatisticStoredProcedures.statsXetNghiem_TongHopXetNghiem_TheoNgay);
        }

        public DataTable ThongKeNguoiThucHien(NormalStatisticCondit condit)
        {
            var sb = new StringBuilder();
            sb.Append("select isnull(N.TenNhanVien,N'Chưa in') as TenNhanVien, isnull(Tx.UserInXN,'None') as UserInXN ,k.MaNhomCLS,nh.TenNhomCLS, Sum(K.GiaRieng) as TongTien, Count(distinct K.MaTiepNhan) as SoLuong, cast (0 as bit) as IsCate");
            sb.AppendFormat("\n from {0}BenhNhan_TiepNhan T inner join {0}KetQua_CLS_XetNghiem K on T.MaTiepNhan = K.MaTiepNhan  inner join {0}BenhNhan_CLS_XetNghiem tx on T.MaTiepNhan = tx.MaTiepNhan", condit.ServerName);
            sb.Append("\n left join (Select d.MaNguoiDung, NV.TenNhanVien from {{TPH_Standard}}_System.dbo.QL_NguoiDung d inner join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on nv.MaNhanVien = d.MaNhanVien) as N on N.MaNguoiDung = Tx.UserInXN ");
            sb.Append("\n left join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom nh on nh.MaNhomCLS = k.MaNhomCLS");
            //Ghép với điều kiện
            sb.AppendFormat("\n{0}", ConvertConditForNormal(condit, "T", "TX", "K"));
            sb.Append("\n group by N.TenNhanVien, Tx.UserInXN, k.MaNhomCLS,nh.TenNhomCLS");
            sb.Append("\n order by nh.TenNhomCLS,N.TenNhanVien");
            return DataProvider.ExecuteDataset(CommandType.Text, sb.ToString()).Tables[0];
        }
        public DataTable ThongKeXetNghiemMay(NormalStatisticCondit condit)
        {
            return DataCallSP(condit, StatisticStoredProcedures.statsXetNghiem_TongHopXetNghiemTuMay);
        }
        public DataTable ThongKeXetNghiemMay_TheoKetQuaXN(NormalStatisticCondit condit)
        {
            return DataCallSP(condit, StatisticStoredProcedures.statsTongHopXetNghiemTheoMay_BenhNhan);
        }
        public DataTable ThongKeXetNghiemMay_ChayLay(NormalStatisticCondit condit)
        {
            var sb = new StringBuilder();
            sb.Append("Select k.sid, k.ngayxn");
            sb.Append("\n , k.idmay,k.mamay,m.tenmay,m.moduleid,k.modules, dx.MaXN, dx.TenXN, dx.MaNhomCLS, C.TenNhomCLS");
            sb.Append("\n ,dx.SapXep,k.ketqua, rtrim(k.sid) + '-|-' + rtrim(dx.MaXN)   as RunKey");
            sb.AppendFormat("\n from {0}h_ketquamay K", condit.ServerName);
            sb.Append("\n inner join {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem (nolock)m on isnull(k.modules, cast(k.idmay as varchar(5))) = isnull(m.moduleid, cast(m.idmay as varchar(5)))");
            sb.Append("\n left join {{TPH_Standard}}_Dictionary.dbo.h_bangmamayxn b on b.mamay = k.mamay and b.idmay = k.idmay");
            sb.Append("\n left join {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem dx on b.maxn = dx.maxn");
            sb.Append("\n left join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom C on dx.MaNHomCLS = C.MaNhomCLS");
            //Ghép với điều kiện
            sb.AppendFormat("\n{0}", ConvertConditForAnalyzer(condit, "K", "DX"));
            sb.Append("\n and k.maxn is not null");
            sb.Append("\n group by k.sid,k.ketqua,k.ngayxn,dx.MaXN, dx.TenXN");
            sb.Append("\n , dx.MaNhomCLS, C.TenNhomCLS,dx.SapXep,k.idmay,k.mamay,m.tenmay,m.moduleid,k.modules");
            sb.Append("\n order by k.sid,k.ketqua, k.ngayxn,k.idmay, dx.SapXep asc, dx.MaXN asc");

            return DataProvider.ExecuteDataset(CommandType.Text, sb.ToString()).Tables[0];

        }
        public DataTable ThongKeXetNghiem_TAT(NormalStatisticCondit condit)
        {
            return DataCallSP(condit, StatisticStoredProcedures.statsXetNghiem_TongHopTAT);
        }
        public DataTable ThongXetNghiemThucHien_BenhNhan_SoPhieu(NormalStatisticCondit condit)
        {
            return DataCallSP(condit, StatisticStoredProcedures.statsTongHopXetNghiemTheoMay_BenhNhan_SoPhieu);
        }
        public DataTable ThongXetNghiem_SLSS_RLCH_XHH_NoiVien_SoLuong(NormalStatisticCondit condit)
        {
            return DataCallSP(condit, StatisticStoredProcedures.statsXetNghiem_RLCH_XHH_NoiVien_SL);
        }
        public DataTable ThongXetNghiem_SLSS_RLCH_XHH_NoiVien_NCC(NormalStatisticCondit condit)
        {
            return DataCallSP(condit, StatisticStoredProcedures.statsXetNghiem_RLCH_XHH_NoiVien_NCC);
        }
        public DataTable ThongXetNghiem_SLSS_RLCH_XHH_NgoaiVien(NormalStatisticCondit condit)
        {
            return DataCallSP(condit, StatisticStoredProcedures.statsXetNghiem_RLCH_XHH_NgoaiVien);
        }
        //Sàng lọc sơ sinh
        public DataTable ThongXetNghiem_SLSS_XHH_NoiVien_SoLuong(NormalStatisticCondit condit)
        {
            return DataCallSP(condit, StatisticStoredProcedures.statsXetNghiem_SLSS_XHH_NoiVien_SL);
        }
        public DataTable ThongXetNghiem_SLSS_XHH_NoiVien_NCC(NormalStatisticCondit condit)
        {
            return DataCallSP(condit, StatisticStoredProcedures.statsXetNghiem_SLSS_XHH_NoiVien_NCC);
        }
        public DataTable ThongXetNghiem_SLSS_MienPhi_NgoaiVien(NormalStatisticCondit condit)
        {
            return DataCallSP(condit, StatisticStoredProcedures.statsXetNghiem_SLSS_MienPhi_NgoaiVien);
        }
        public DataTable ThongXetNghiem_SLSS_MienPhi_NoiVien(NormalStatisticCondit condit)
        {
            return DataCallSP(condit, StatisticStoredProcedures.statsXetNghiem_SLSS_MienPhi_NoiVien);
        }

        public DataTable ThongXetNghiem_SLSS_DonVi_TuDen(NormalStatisticCondit condit)
        {
            return DataCallSP(condit, StatisticStoredProcedures.statsXetNghiem_SLSS_DonVi_TuDen);
        }
        public DataTable ThongXetNghiem_SLSS_DonVi_TGChanDoan(NormalStatisticCondit condit)
        {
            return DataCallSP(condit, StatisticStoredProcedures.statsXetNghiem_SLSS_DonVi_TGChanDoan);
        }

        public DataTable DashBoard_TongHopmauTheoBoPhan(DateTime tuNgayNhanMau, DateTime denNgayNhanMau, List<string> lstBoPhanAllow)
        {
            var paFromDate = new System.Data.SqlClient.SqlParameter("@TuNgayNhanMau", SqlDbType.DateTime);
            paFromDate.Value = tuNgayNhanMau;
            var paToDate = new System.Data.SqlClient.SqlParameter("@DeNgayNhanMau", SqlDbType.DateTime);
            paToDate.Value = denNgayNhanMau;
            var sqlPara = new System.Data.SqlClient.SqlParameter[]
            {
                paFromDate
                ,
                paToDate
                ,
                new System.Data.SqlClient.SqlParameter ("@lstBoPhan", string.Join(",", lstBoPhanAllow))
            };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, StatisticStoredProcedures.statDashboard_TheoNgayNhanMau, sqlPara);
            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }
        public DataTable DashBoard_TongHopmauTheoBenhNhan(DateTime tuNgayNhanMau, DateTime denNgayNhanMau)
        {
            var paFromDate = new System.Data.SqlClient.SqlParameter("@TuNgayNhanMau", SqlDbType.DateTime);
            paFromDate.Value = tuNgayNhanMau;
            var paToDate = new System.Data.SqlClient.SqlParameter("@DeNgayNhanMau", SqlDbType.DateTime);
            paToDate.Value = denNgayNhanMau;
            var sqlPara = new System.Data.SqlClient.SqlParameter[]
            {
                paFromDate
                ,
                paToDate
            };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, StatisticStoredProcedures.statDashboard_TheoBenhNhan, sqlPara);
            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }
        public DataTable DashBoard_DanhSachTAT(DateTime ngayNhanMau, List<string> lstBoPhanAllow, List<string> lstKhuVucAllow)
        {
            var paFromDate = new System.Data.SqlClient.SqlParameter("@NgayNhanMau", SqlDbType.DateTime);
            paFromDate.Value = ngayNhanMau;
            var sqlPara = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter ("@lstBoPhan", string.Join(",", lstBoPhanAllow))
                 ,
                new System.Data.SqlClient.SqlParameter ("@khuVuc", string.Join(",", lstKhuVucAllow))
                ,    paFromDate
            };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, StatisticStoredProcedures.statDashBoard_TAT, sqlPara);
            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }
        public DataTable DashBoard_DanhSachTAT_BenhNhan(DateTime ngayNhanMau, List<string> lstKhuVucAllow)
        {
            var paFromDate = new System.Data.SqlClient.SqlParameter("@NgayNhanMau", SqlDbType.DateTime);
            paFromDate.Value = ngayNhanMau;
            var sqlPara = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter ("@khuVuc", string.Join(",", lstKhuVucAllow))
                ,    paFromDate
            };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, StatisticStoredProcedures.statDashBoard_TAT_TheoBN, sqlPara);
            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }
        #region báo cáo thu tiền
        public BaoCaoThuTienModel BaoCaoThuTien(StatisticsCashierCondition condit)
        {
            var returnObj = new BaoCaoThuTienModel();

            StringBuilder sb = new StringBuilder();

            sb.Append("select p.ThanhToan, p.TongTien, p.ConLai, p.DaThuTien, p.ThaoTac, tn.TenBN  from p_payment p left join benhnhan_tiepnhan tn on p.MaTiepNhan = tn.MaTiepNhan");
            sb.AppendFormat("\n where p.DaKetChuyen = 0 and p.NgayThanhToan between '{0} 00:00:00' and '{0} 23:59:59'", condit.NgayThuTien.ToString("yyyy-MM-dd"));
            sb.AppendFormat("\n and p.ThuNgan = '{0}'", condit.ThuNgan);
            var data = DataProvider.ExecuteDataset(CommandType.Text, sb.ToString()).Tables[0];

            if (data.Rows.Count > 0)
            {
                //Tính số biên lai thu
                var dataSearch = WorkingServices.SearchResult_OnDatatable_NoneSort(data, string.Format("DaThuTien = true and ThaoTac = {0}", (int)EnumThaoTacThuPhi.ThuTien));
                if (dataSearch.Rows.Count > 0)
                {
                    returnObj.TongBienLaiThu = dataSearch.Rows.Count;
                    returnObj.TongTienDoanhThu = dataSearch.AsEnumerable()
                            .Sum(r => double.Parse(r["TongTien"].ToString()));
                    //.Where(r => r.Field<string>("COLUMNX") == "blah" && r.Field<string>("COLUMNY") == "blah")

                    returnObj.TongTienConNo = dataSearch.AsEnumerable()
                            .Sum(r => double.Parse(r["ConLai"].ToString()));
                    returnObj.TongTienDaThu = dataSearch.AsEnumerable()
                            .Sum(r => double.Parse(r["ThanhToan"].ToString()));
                }

                //Tính số tiền chưa thu
                dataSearch = WorkingServices.SearchResult_OnDatatable_NoneSort(data, string.Format("DaThuTien = false and ThaoTac = {0}", (int)EnumThaoTacThuPhi.ThuTien));
                if (dataSearch.Rows.Count > 0)
                {
                    returnObj.TongBienLaiChuaThu = dataSearch.Rows.Count;
                    returnObj.TongTienChuaThu = dataSearch.AsEnumerable()
                            .Sum(r => double.Parse(r["TongTien"].ToString()));
                }

                //Tính số tiền đã hoàn
                dataSearch = WorkingServices.SearchResult_OnDatatable_NoneSort(data, string.Format("ThaoTac = {0}", (int)EnumThaoTacThuPhi.HoanTien));
                if (dataSearch.Rows.Count > 0)
                {
                    returnObj.TongBienLaiHoan = dataSearch.Rows.Count;
                    returnObj.TongTienHoan = dataSearch.AsEnumerable()
                            .Sum(r => double.Parse(r["TongTien"].ToString()));
                }
                returnObj.TongTienThuThuc = returnObj.TongTienDaThu - returnObj.TongTienHoan;
            }

            return returnObj;
        }
        public DataTable DanhSachDaKetChuyen(StatisticsCashierCondition condit)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from p_payment_lock p");
            sb.AppendFormat("\n where p.NgayThuTien between '{0} 00:00:00' and '{1} 23:59:59'", condit.TuNgay.ToString("yyyy-MM-dd"), condit.DenNgay.ToString("yyyy-MM-dd"));
            if (condit.ThuNgan != null && !string.IsNullOrEmpty(condit.ThuNgan))
                sb.AppendFormat("\n and p.ThuNgan = '{0}'", condit.ThuNgan);
            if (condit.MayTinhNhap != null && !string.IsNullOrEmpty(condit.MayTinhNhap))
                sb.AppendFormat("\n and p.MayTinh = '{0}'", condit.MayTinhNhap);
            return DataProvider.ExecuteDataset(CommandType.Text, sb.ToString()).Tables[0];
        }
        #endregion
    }
}
