using System;
using TPH.LIS.TestResult.Services;
using System.Data;
using TPH.LIS.Common.Extensions;
using TPH.Common.Converter;
using System.Data.SqlClient;
using TPH.LIS.Common.Controls;
using TPH.LIS.Data;
using System.Collections.Generic;
using System.Linq;
using TPH.WriteLog;
using TPH.LIS.TestResult.Model;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Constants;

namespace TPH.LIS.ResultConvert.Repository
{
    public class ResultConvertRepository : IResultConvertRepository
    {
        #region Tính toán kết quả
        private readonly ITestResultService _xetnghiem = new TestResultService();

        public bool CalculateResult_XetNghiem(DataTable dtChiDinh,
            DataTable dtCalculate, string gioiTinh, string maSinhLy, string tuoi, string userId)
        {

            if (dtCalculate.Rows.Count <= 0 || dtChiDinh.Rows.Count <= 0) return false;
            bool haveCal = false;
            //Xử lý tính toán định lượng
            var dataCalDinhLuong = WorkingServices.SearchResult_OnDatatable(dtCalculate, string.Format("{0} = '{1}'"
             , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Cachtinhtoan)
             , CommonConfigConstant.TinhToanKetQua));
            if (dataCalDinhLuong.Rows.Count > 0)
            {
                var gioiTinhFlat = 2;
                if (gioiTinh.Trim().Equals("f", StringComparison.OrdinalIgnoreCase))
                {
                    gioiTinhFlat = 1;
                }
                else if (gioiTinh.Trim().Equals("m", StringComparison.OrdinalIgnoreCase))
                    gioiTinhFlat = 0;

                string dieuKienNho = string.Empty,
                    giaTriThayTheNho = string.Empty,
                    dieuKienLon = string.Empty,
                    giaTriThayTheLon = string.Empty;

                var round = 2;
                for (var i = 0; i < dtChiDinh.Rows.Count; i++)
                {
                    string a = string.Empty,
                        b = string.Empty,
                        c = string.Empty,
                        d = string.Empty,
                        e = string.Empty,
                        formular = string.Empty;

                    var result = dtChiDinh.Rows[i]["KetQua"].ToString().Trim();
                    var maXn = dtChiDinh.Rows[i]["MaXN"].ToString().Trim();
                    var low = dtChiDinh.Rows[i]["NguongDuoi"].ToString().Trim();
                    var high = dtChiDinh.Rows[i]["NguongTren"].ToString().Trim();
                    var userNhap = dtChiDinh.Rows[i]["UserNhapKQ"].ToString().Trim();
                    var roundNhanHS = dtChiDinh.Rows[i]["lamtron"].ToString().Trim();

                    if (!string.IsNullOrWhiteSpace(result)) continue;

                    Get_TestCode(maXn, gioiTinhFlat, maSinhLy, ref a, ref b, ref c, ref d, ref e, ref formular, ref round,
                        ref dieuKienNho, ref giaTriThayTheNho, ref dieuKienLon, ref giaTriThayTheLon, dataCalDinhLuong, dtChiDinh, tuoi, CommonConfigConstant.TinhToanKetQua);
                    if (!string.IsNullOrEmpty(formular))
                    {
                        if (!a.Equals("none", StringComparison.OrdinalIgnoreCase) ||
                            !b.Equals("none", StringComparison.OrdinalIgnoreCase) ||
                            !c.Equals("none", StringComparison.OrdinalIgnoreCase) ||
                            !d.Equals("none", StringComparison.OrdinalIgnoreCase) ||
                            !e.Equals("none", StringComparison.OrdinalIgnoreCase))
                        {

                            formular = formular.ToLower().Trim();
                            var validateresult = Check_GetResult(dtChiDinh, tuoi, a, b, c, d, e, ref formular);
                            if (!validateresult)
                                result = "";
                            else
                                result = Evaluate(formular);

                            if (string.IsNullOrWhiteSpace(result)) continue;

                            result = Math.Round(double.Parse(result), round).ToString();
                            string formatString = "";
                            for (int ir = 0; ir < round; ir++)
                            {
                                formatString += (string.IsNullOrEmpty(formatString) ? "." : "") + "0";
                            }

                            formatString = "{0:0" + formatString + "}";
                            result = string.Format(formatString, double.Parse(result));

                            if (!string.IsNullOrWhiteSpace(dieuKienNho))
                            {
                                if (double.Parse(dieuKienNho) > double.Parse(result))
                                {
                                    result = giaTriThayTheNho;
                                }
                            }
                            else if (!string.IsNullOrWhiteSpace(dieuKienLon))
                            {
                                if (double.Parse(dieuKienLon) < double.Parse(result))
                                {
                                    result = giaTriThayTheLon;
                                }
                            }

                            var co = LabResultService.SetColor(result, high, low, string.Empty);
                            var obUpdate = new UpdateResultNormalInfo
                            {
                                maTiepNhan = dtChiDinh.Rows[i]["MaTiepNhan"].ToString().Trim(),
                                maXN = maXn,
                                ketQua = result,
                                capNhatghiChu = false,
                                ghiChu = string.Empty,
                                co = co.ToString(),
                                userNhap = userId,
                                suaKQ = !string.IsNullOrWhiteSpace(userNhap),
                                round = roundNhanHS,
                                userUpdate = userId,
                                Qcout = false
                            };

                            _xetnghiem.CapNhat_KQ_XN(obUpdate);
                            _xetnghiem.CapNhat_DuKQ_XN(dtChiDinh.Rows[i]["MaTiepNhan"].ToString().Trim());
                            haveCal = true;
                        }
                    }
                }
            }
            //Xử lý tính toán định tính
            var dataCalDinhTinhSoSanh = WorkingServices.SearchResult_OnDatatable(dtCalculate, string.Format("{0} = '{1}'"
             , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Cachtinhtoan)
             , CommonConfigConstant.TinhToanKetQuaSoSanh));
            if (dataCalDinhTinhSoSanh.Rows.Count > 0)
            {
                var gioiTinhFlat = 2;
                if (gioiTinh.Trim().Equals("f", StringComparison.OrdinalIgnoreCase))
                {
                    gioiTinhFlat = 1;
                }
                else if (gioiTinh.Trim().Equals("m", StringComparison.OrdinalIgnoreCase))
                    gioiTinhFlat = 0;

                string dieuKienNho = string.Empty,
                    giaTriThayTheNho = string.Empty,
                    dieuKienLon = string.Empty,
                    giaTriThayTheLon = string.Empty;
                var round = 2;
                for (var i = 0; i < dtChiDinh.Rows.Count; i++)
                {
                    string a = string.Empty,
                        b = string.Empty,
                        c = string.Empty,
                        d = string.Empty,
                        e = string.Empty,
                        formular = string.Empty;

                    var result = dtChiDinh.Rows[i]["KetQua"].ToString().Trim();
                    var maXn = dtChiDinh.Rows[i]["MaXN"].ToString().Trim();
                    var low = dtChiDinh.Rows[i]["NguongDuoi"].ToString().Trim();
                    var high = dtChiDinh.Rows[i]["NguongTren"].ToString().Trim();
                    var userNhap = dtChiDinh.Rows[i]["UserNhapKQ"].ToString().Trim();
                    var roundNhanHS = dtChiDinh.Rows[i]["lamtron"].ToString().Trim();

                    if (!string.IsNullOrWhiteSpace(result)) continue;

                    Get_TestCode(maXn, gioiTinhFlat, maSinhLy, ref a, ref b, ref c, ref d, ref e, ref formular, ref round,
                        ref dieuKienNho, ref giaTriThayTheNho, ref dieuKienLon, ref giaTriThayTheLon
                        , dataCalDinhTinhSoSanh, dtChiDinh, tuoi, CommonConfigConstant.TinhToanKetQuaSoSanh);
                    if (!string.IsNullOrEmpty(formular))
                    {
                        if (!a.Equals("none", StringComparison.OrdinalIgnoreCase) ||
                            !b.Equals("none", StringComparison.OrdinalIgnoreCase) ||
                            !c.Equals("none", StringComparison.OrdinalIgnoreCase) ||
                            !d.Equals("none", StringComparison.OrdinalIgnoreCase) ||
                            !e.Equals("none", StringComparison.OrdinalIgnoreCase))
                        {
                            var validateresult = Check_GetResult(dtChiDinh, tuoi, a, b, c, d, e, ref formular);
                            if (!validateresult)
                                result = "";
                            else
                                result = formular;

                            if (string.IsNullOrWhiteSpace(result)) continue;

                            var co = LabResultService.SetColor(result, high, low, string.Empty);

                            var obUpdate = new UpdateResultNormalInfo
                            {
                                maTiepNhan = dtChiDinh.Rows[i]["MaTiepNhan"].ToString().Trim(),
                                maXN = maXn,
                                ketQua = result,
                                capNhatghiChu = false,
                                ghiChu = string.Empty,
                                co = co.ToString(),
                                userNhap = userId,
                                suaKQ = !string.IsNullOrWhiteSpace(userNhap),
                                round = roundNhanHS,
                                userUpdate = userId,
                                Qcout = false
                            };
                            _xetnghiem.CapNhat_KQ_XN(obUpdate);

                            _xetnghiem.CapNhat_DuKQ_XN(dtChiDinh.Rows[i]["MaTiepNhan"].ToString().Trim());
                            haveCal = true;
                        }
                    }
                }
            }

            return haveCal;
        }
        public bool CalculateDuyetKQ(DataTable dtChiDinh, DataTable dtCalculate)
        {
            //Tính toán xem trong các chỉ định có chỉ định nào ko phù hợp tinh toán ko?
            //Nếu có ko phù hợp thì ko cho Duyệt, trả về true là ko phù hợp
            //Lọc các chỉ định ko có ket quả
            bool result = false;
            dtChiDinh = WorkingServices.SearchResult_OnDatatable(dtChiDinh, "(KetQua <> '' or KetQua is not null)");
            if (dtChiDinh.Rows.Count <= 0) return result;
            //dtChiDinh = dtChiDinh.AsEnumerable().Where(t => !string.IsNullOrEmpty(t.Field<string>("KetQua"))).CopyToDataTable();
            //Lọc các công thức ko có Formular
            //string sqlSearch = "MaXN1 <> '{0}' and MaXN2 <> '{0}' and MaXN3 <> '{0}' and MaXN4 <> '{0}' and MaXN5 <> '{0}'";
            //dtCalculate = WorkingServices.SearchResult_OnDatatable(dtCalculate, string.Format(sqlSearch, "None"));

            dtCalculate = dtCalculate.AsEnumerable().Where(t => !string.IsNullOrEmpty(t.Field<string>("CongThucTinh"))
                    || (t.Field<string>("MaXN1") != "None"
                    && t.Field<string>("MaXN2") != "None" && t.Field<string>("MaXN3") != "None"
                    && t.Field<string>("MaXN4") != "None" && t.Field<string>("MaXN5") != "None")).CopyToDataTable();

            if (dtCalculate.Rows.Count <= 0 || dtChiDinh.Rows.Count <= 0) return false;
            var thongBao = string.Empty;
            var coTiepTucDuyet = "\n\n\nCÓ TIẾP TỤC DUYỆT?";
            //Xử lý định tính trước
            //Tìm dữ liệu khai báo định tính
            var dataCalDinhTinh= WorkingServices.SearchResult_OnDatatable(dtCalculate, string.Format("{0} = '{1}'"
               , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Cachtinhtoan)
               , CommonConfigConstant.DuyetKetQuaDinhTinh));
            if (dataCalDinhTinh.Rows.Count > 0)
            {
                foreach (DataRow drDT in dataCalDinhTinh.Rows)
                {
                    var maxn = drDT["MaXN"].ToString();
                    var dtF = WorkingServices.SearchResult_OnDatatable(dtChiDinh, string.Format("MaXN = '{0}'", maxn));
                    if(dtF.Rows.Count >0)
                    {
                        var arrFConfit = drDT["CongThucTinh"].ToString().Split('|').ToList();
                        var thongBaoDT = drDT["Noidungthongbao"].ToString().Split('|').ToList();
                        var ketQua = dtF.Rows[0]["KetQua"].ToString();
                        //Kiểm tra tuyệt đối trước
                        if (arrFConfit.Where(x => x.Trim().Equals(ketQua, StringComparison.OrdinalIgnoreCase)).Any())
                        {
                            thongBao += thongBaoDT + "\n";
                        }
                        else
                        {
                            for (var i = 0; i < arrFConfit.Count; i++)
                            {
                                if (ketQua.ToLower().Contains(arrFConfit[i].Trim().ToLower()))
                                {
                                    if ((arrFConfit[i].Trim().ToLower().Equals("reactive") && ketQua.ToLower().Contains("nonreactive")))
                                        continue;
                                    else
                                    {
                                        thongBao += thongBaoDT + "\n";
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            var dataCalDinhLuong = WorkingServices.SearchResult_OnDatatable(dtCalculate, string.Format("{0} = '{1}'"
              , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Cachtinhtoan)
              , CommonConfigConstant.DuyetKetQua));
            if (dataCalDinhLuong.Rows.Count > 0)
            {
                foreach (DataRow drCalculate in dataCalDinhLuong.Rows)
                {
                    double? kqTinhToan =
                        KetQuaTinhToanDuyetKetQua(drCalculate, dtChiDinh);
                    if (kqTinhToan == null) continue;
                    string a, b, c, d, e = string.Empty;
                    List<string> lstMaXN = new List<string>();
                    a = StringConverter.ToString(drCalculate["MaXN1"]);
                    if (!a.Equals("None", StringComparison.OrdinalIgnoreCase))
                        lstMaXN.Add(a);
                    b = StringConverter.ToString(drCalculate["MaXN2"]);
                    if (!b.Equals("None", StringComparison.OrdinalIgnoreCase))
                        lstMaXN.Add(b);
                    c = StringConverter.ToString(drCalculate["MaXN3"]);
                    if (!c.Equals("None", StringComparison.OrdinalIgnoreCase))
                        lstMaXN.Add(c);
                    d = StringConverter.ToString(drCalculate["MaXN4"]);
                    if (!d.Equals("None", StringComparison.OrdinalIgnoreCase))
                        lstMaXN.Add(d);
                    e = StringConverter.ToString(drCalculate["MaXN5"]);
                    if (!e.Equals("None", StringComparison.OrdinalIgnoreCase))
                        lstMaXN.Add(e);
                    var canTren = StringConverter.ToString(drCalculate["SoSanhCanTren"]);
                    var canDuoi = StringConverter.ToString(drCalculate["SoSanhCanDuoi"]); ;
                    var ThongBaoCanTren = StringConverter.ToString(drCalculate["ThongBaoCanTren"]);
                    var ThongBaoCanDuoi = StringConverter.ToString(drCalculate["ThongBaoCanDuoi"]);
                    bool layTrongKhoang = NumberConverter.ToBool(drCalculate["LayTrongKhoang"]);

                    if (layTrongKhoang)
                    {
                        if (string.IsNullOrEmpty(canTren) || string.IsNullOrEmpty(canDuoi))
                            continue;
                        if (kqTinhToan >= double.Parse(canDuoi) && kqTinhToan <= double.Parse(canTren))
                        {
                            thongBao += ThongBaoCanDuoi + "\n";
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(canTren))
                        {
                            if (kqTinhToan > double.Parse(canTren))
                            {
                                thongBao += ThongBaoCanTren + "\n";
                            }
                        }
                        if (!string.IsNullOrEmpty(canDuoi))
                        {
                            if (kqTinhToan < double.Parse(canDuoi))
                            {
                                thongBao += ThongBaoCanDuoi + "\n";
                            }
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(thongBao))
            {
                thongBao += coTiepTucDuyet;
                return CustomMessageBox.MSG_Question_YesNo_GetNo(thongBao);
            }
            return result;
        }
        private void Get_TestCode(string maXn, int gioiTinh, string masinhly, ref string a, ref string b, ref string c, ref string d,
            ref string e, ref string formular, ref int round, ref string dieuKienNho, ref string giaTriThayTheNho,
            ref string dieuKienLon, ref string giaTriThayTheLon, DataTable dtCongThucTinh, DataTable dtChiDinh, string tuoi
            , string loaiTinhToan)
        {
            var gioiTinhCheck = 2;
            var sinhLyCheck = string.Empty;
            maXn = maXn.Trim().ToLower();
            var dtCongThucTinhTheoXN = WorkingServices.SearchResult_OnDatatable_NoneSort(dtCongThucTinh, string.Format("MaXN = '{0}'", maXn));
            if (dtCongThucTinhTheoXN.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCongThucTinhTheoXN.Rows)
                {
                    var dieuKienLayCongThucTinh = string.Empty;
                    var maxnCheck = dr["MaXN"].ToString().Trim().ToLower();
                    gioiTinhCheck =
                        NumberConverter.ToInt(string.IsNullOrWhiteSpace(dr["GioiTinh"].ToString().Trim())
                            ? "2"
                            : dr["GioiTinh"].ToString().Trim());
                    sinhLyCheck = dr["MaSinhLy"].ToString().Trim();
                    if (maxnCheck.Equals(maXn)
                        && (gioiTinh.Equals(gioiTinhCheck) || gioiTinhCheck == 2) && (sinhLyCheck.Trim().Equals(masinhly, StringComparison.OrdinalIgnoreCase) || string.IsNullOrEmpty(sinhLyCheck)))
                    {
                        Set_Calculate_Column(ref a, ref b, ref c, ref d, ref e, ref formular
                            , ref round, ref dieuKienNho, ref giaTriThayTheNho, ref dieuKienLon, ref giaTriThayTheLon, ref dieuKienLayCongThucTinh, dr);
                        if (CheckExistsTestInDataCalaulate(a, dtChiDinh, loaiTinhToan.Equals(CommonConfigConstant.TinhToanKetQuaSoSanh))
                           && CheckExistsTestInDataCalaulate(b, dtChiDinh, loaiTinhToan.Equals(CommonConfigConstant.TinhToanKetQuaSoSanh))
                           && CheckExistsTestInDataCalaulate(c, dtChiDinh, loaiTinhToan.Equals(CommonConfigConstant.TinhToanKetQuaSoSanh))
                           && CheckExistsTestInDataCalaulate(d, dtChiDinh, loaiTinhToan.Equals(CommonConfigConstant.TinhToanKetQuaSoSanh))
                           && CheckExistsTestInDataCalaulate(e, dtChiDinh, loaiTinhToan.Equals(CommonConfigConstant.TinhToanKetQuaSoSanh))
                           )
                        {
                            var tempDieuKienLayCongThucTinh = dieuKienLayCongThucTinh.ToLower().Trim().Replace("none", "");
                            if (!string.IsNullOrEmpty(tempDieuKienLayCongThucTinh))
                            {
                                dieuKienLayCongThucTinh = dieuKienLayCongThucTinh.ToLower();
                                //Kiểm tra thỏa điều kiện lấy công thức không
                                var getValueForCondit = Check_GetResult(dtChiDinh, tuoi, a, b, c, d, e, ref dieuKienLayCongThucTinh);
                                if (loaiTinhToan.Equals(CommonConfigConstant.TinhToanKetQuaSoSanh))
                                {
                                    bool haveValid = false;

                                    //Xử lý or trước
                                    var arrConit = dieuKienLayCongThucTinh.Split(new string[] { "or" }, StringSplitOptions.RemoveEmptyEntries);
                                    if (arrConit.Length > 0)
                                    {
                                        foreach (var item in arrConit)
                                        {
                                            if (KiemTraThoaManLayDieuKien(item))
                                            {
                                                haveValid = true;
                                                break;
                                            }
                                        }
                                    }
                                    if (!haveValid)
                                    {
                                        //Xử lý and 
                                        arrConit = dieuKienLayCongThucTinh.Split(new string[] { "and" }, StringSplitOptions.RemoveEmptyEntries);
                                        if (arrConit.Length > 0)
                                        {
                                            int countValid = 0;
                                            foreach (var item in arrConit)
                                            {
                                                if (KiemTraThoaManLayDieuKien(item))
                                                {
                                                    countValid++;
                                                }
                                            }
                                            haveValid = countValid == arrConit.Length;
                                        }
                                    }
                                    if (haveValid)
                                        break;
                                }
                                else
                                {
                                    if (getValueForCondit)
                                    {
                                        if (KiemTraThoaManLayDieuKien(dieuKienLayCongThucTinh))
                                            break;
                                        else
                                            continue;
                                    }
                                }
                            }
                            else
                                break;
                        }
                        else
                            formular = string.Empty;
                    }
                }
            }
            else
                formular = string.Empty;
        }
        private bool KiemTraThoaManLayDieuKien(string dieuKienLay)
        {
            if (string.IsNullOrEmpty(dieuKienLay))
                return true;
            else
            {
                try
                {
                    var table = new DataTable();
                    table.Columns.Add("Cal", typeof(Boolean));
                    table.Columns[0].Expression = dieuKienLay;
                    var r = table.NewRow();
                    table.Rows.Add(r);
                    var result = (Boolean)r[0];
                    return result;
                }
                catch (Exception ex)
                {
                    LogService.RecordLogError("Unknow", "CalculateResult", ex, 0, ex.Message, string.Format("KiemTraThoaManLayDieuKien: {0}", dieuKienLay));
                    return false;
                }
            }
        }
        private bool CheckExistsTestInDataCalaulate(string testcheck, DataTable dtChiDinh, bool alloCheckNull)
        {
            if (testcheck.Contains("{") || testcheck.Equals("none", StringComparison.OrdinalIgnoreCase) || string.IsNullOrEmpty(testcheck))
                return true;
            else
            {
                var data = WorkingServices.SearchResult_OnDatatable_NoneSort(dtChiDinh, string.Format("MaXN = '{0}'", testcheck));
                if (data.Rows.Count > 0)
                {
                    if (string.IsNullOrEmpty(data.Rows[0]["KetQua"].ToString()) && !alloCheckNull)
                        return false;
                    else
                        return true;
                }
                return false;
            }
        }
        private void Set_Calculate_Column(ref string a, ref string b, ref string c, ref string d,
            ref string e, ref string formular, ref int round, ref string dieuKienNho, ref string giaTriThayTheNho,
            ref string dieuKienLon, ref string giaTriThayTheLon, ref string dieuKienLayCongThuc, DataRow dr)
        {
            a = dr["MaXN1"].ToString().Trim();
            b = dr["MaXN2"].ToString().Trim();
            c = dr["MaXN3"].ToString().Trim();
            d = dr["MaXN4"].ToString().Trim();
            e = dr["MaXN5"].ToString().Trim();
            formular = dr["CongThucTinh"].ToString().Trim();
            round = NumberConverter.ToInt(string.IsNullOrWhiteSpace(dr["LamTron"].ToString()) ? "0" : dr["LamTron"].ToString());
            dieuKienNho = dr["DieuKienNho"].ToString().Trim();
            giaTriThayTheNho = dr["GiaTriThayTheNho"].ToString().Trim();
            dieuKienLon = dr["DieuKienLon"].ToString().Trim();
            giaTriThayTheLon = dr["GiaTriThayTheLon"].ToString().Trim();
            dieuKienLayCongThuc = dr["DieuKienLayCongThuc"].ToString().Trim();
        }
        private bool Check_GetResult(DataTable dtChiDinh, string tuoi, string a, string b
            , string c, string d, string e, ref string formular)
        {
            var valueIsvalidated = true;

            a = (a.Equals("none", StringComparison.OrdinalIgnoreCase) ? string.Empty : a);
            b = (b.Equals("none", StringComparison.OrdinalIgnoreCase) ? string.Empty : b);
            c = (c.Equals("none", StringComparison.OrdinalIgnoreCase) ? string.Empty : c);
            d = (d.Equals("none", StringComparison.OrdinalIgnoreCase) ? string.Empty : d);
            e = (e.Equals("none", StringComparison.OrdinalIgnoreCase) ? string.Empty : e);
            bool fullA = false, fullB = false, fullC = false, fullD = false, fullE = false;
            fullA = string.IsNullOrWhiteSpace(a);
            fullB = string.IsNullOrWhiteSpace(b);
            fullC = string.IsNullOrWhiteSpace(c);
            fullD = string.IsNullOrWhiteSpace(d);
            fullE = string.IsNullOrWhiteSpace(e);

            //Check set {Age }

            if (a.Equals("{Age}", StringComparison.OrdinalIgnoreCase))
            {
                a = tuoi;
                fullA = true;
            }
            if (b.Equals("{Age}", StringComparison.OrdinalIgnoreCase))
            {
                b = tuoi;
                fullB = true;
            }
            if (c.Equals("{Age}", StringComparison.OrdinalIgnoreCase))
            {
                c = tuoi;
                fullC = true;
            }
            if (d.Equals("{Age}", StringComparison.OrdinalIgnoreCase))
            {
                d = tuoi;
                fullD = true;
            }
            if (e.Equals("{Age}", StringComparison.OrdinalIgnoreCase))
            {
                e = tuoi;
                fullE = true;
            }

            //Check set result
            for (var i = 0; i < dtChiDinh.Rows.Count; i++)
            {
                if (fullA && fullB && fullC && fullD && fullE)
                {
                    break;
                }
                else
                {
                    var val = dtChiDinh.Rows[i]["KetQua"].ToString().Trim();
                    var maXn = dtChiDinh.Rows[i]["MaXN"].ToString().Trim();
                    if (WorkingServices.IsNumeric(val) || string.IsNullOrEmpty(val))
                    {
                        if (a.Equals(maXn, StringComparison.OrdinalIgnoreCase))
                        {
                            a = val;
                            fullA = true;
                        }
                        else if (b.Equals(maXn, StringComparison.OrdinalIgnoreCase))
                        {
                            b = val;
                            fullB = true;
                        }
                        else if (c.Equals(maXn, StringComparison.OrdinalIgnoreCase))
                        {
                            c = val;
                            fullC = true;
                        }
                        else if (d.Equals(maXn, StringComparison.OrdinalIgnoreCase))
                        {
                            d = val;
                            fullD = true;
                        }
                        else if (e.Equals(maXn, StringComparison.OrdinalIgnoreCase))
                        {
                            e = val;
                            fullE = true;
                        }
                    }
                }
            }

            //Kiểm tra các giá trị hợp lệ không
            if (formular.Contains("{a}"))
            {
                if (WorkingServices.IsNumeric(a))
                    formular = formular.Replace("{a}", a);
                else
                    valueIsvalidated = false;
            }
            if (formular.Contains("{b}"))
            {
                if (WorkingServices.IsNumeric(b))
                    formular = formular.Replace("{b}", b);
                else
                    valueIsvalidated = false;
            }
            if (formular.Contains("{c}"))
            {
                if (WorkingServices.IsNumeric(c))
                    formular = formular.Replace("{c}", c);
                else
                    valueIsvalidated = false;

            }
            if (formular.Contains("{d}"))
            {
                if (WorkingServices.IsNumeric(d))
                    formular = formular.Replace("{d}", d);
                else
                    valueIsvalidated = false;
            }
            if (formular.Contains("{e}"))
            {
                if (WorkingServices.IsNumeric(d))
                    formular = formular.Replace("{e}", e);
                else
                    valueIsvalidated = false;
            }
            return valueIsvalidated;
        }
        private double? KetQuaTinhToanDuyetKetQua(DataRow drCalculate, DataTable dtChiDinh)
        {
            string result;
            string a, b, c, d, e, formular = string.Empty;
            bool inorge = false;
            a = StringConverter.ToString(drCalculate["MaXN1"]);
            b = StringConverter.ToString(drCalculate["MaXN2"]);
            c = StringConverter.ToString(drCalculate["MaXN3"]);
            d = StringConverter.ToString(drCalculate["MaXN4"]);
            e = StringConverter.ToString(drCalculate["MaXN5"]);
            formular = StringConverter.ToString(drCalculate["CongThucTinh"]).ToLower();

            Check_GetResult(dtChiDinh, string.Empty, a, b, c, d, e, ref formular);
            if (formular.Contains("{a}"))
            {
                if (WorkingServices.IsNumeric(a))
                    formular = formular.Replace("{a}", a);
                else
                    inorge = true;
            }
            if (formular.Contains("{b}"))
            {
                if (WorkingServices.IsNumeric(b))
                    formular = formular.Replace("{b}", b);
                else
                    inorge = true;
            }
            if (formular.Contains("{c}"))
            {
                if (WorkingServices.IsNumeric(c))
                    formular = formular.Replace("{c}", c);
                else
                    inorge = true;
            }
            if (formular.Contains("{d}"))
            {
                if (WorkingServices.IsNumeric(d))
                    formular = formular.Replace("{d}", d);
                else
                    inorge = true;
            }
            if (formular.Contains("{e}"))
            {
                if (WorkingServices.IsNumeric(e))
                    formular = formular.Replace("{e}", e);
                else
                    inorge = true;
            }
            if (inorge)
                result = "";
            else
            {
                result = Evaluate(XulybieuThucCon(formular));
            }
            if (string.IsNullOrWhiteSpace(result)) return null;
            return double.Parse(result);
        }
        public string Evaluate(string expression)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(expression))
            {
                try
                {
                    result = EvaluateExpression.EvalExpression(XulybieuThucCon(expression)).ToString();
                }
                catch
                {
                    result = string.Empty;
                }
            }
            return result;
        }
        public string XulybieuThucCon(string formular)
        {
            var returnFormular = formular;
            var dic = LayChuoiBieuThu(formular, "{min(", ")}");
            if (dic.Count > 0)
            {
                foreach (var dicItem in dic)
                {
                    //Xử lý tìm min max
                    //Tách từng phần tử trong biễu thức => tính toán kết quả nếu cần thiết
                    var arr = dicItem.Key.Split(new string[] { "{min(", ")}", "," }, StringSplitOptions.RemoveEmptyEntries);
                    var arrValue = new double[arr.Length];
                    for (int i = 0; i < arr.Length; i++)
                    {
                        var calval = double.Parse(Evaluate(arr[i]));
                        arrValue[i] = calval;
                    }
                    returnFormular = returnFormular.Replace(dicItem.Key, arrValue.Min().ToString());
                }
            }

            dic = LayChuoiBieuThu(formular, "{max(", ")}");
            if (dic.Count > 0)
            {
                foreach (var dicItem in dic)
                {
                    //Xử lý tìm min max
                    //Tách từng phần tử trong biễu thức => tính toán kết quả nếu cần thiết
                    var arr = dicItem.Key.Split(new string[] { "{max(", ")}", "," }, StringSplitOptions.RemoveEmptyEntries);
                    var arrValue = new double[arr.Length];
                    for (int i = 0; i < arr.Length; i++)
                    {
                        var calval = double.Parse(Evaluate(arr[i]));
                        arrValue[i] = calval;
                    }
                    returnFormular = returnFormular.Replace(dicItem.Key, arrValue.Max().ToString());
                }
            }
            return returnFormular;
        }
        private Dictionary<string, string> LayChuoiBieuThu(string formular, string keyStart, string keyEnd)
        {
            //biểu thức min, max
            //{min(a,c,d,e,f)}
            //tìm vị trí bắt đầu  của chuỗi {min(

            var dic = new Dictionary<string, string>();
            for (int i = 0; i < formular.Length; i++)
            {
                var indexStart = formular.IndexOf(keyStart, i);
                if (indexStart > -1)
                {
                    var indexStartofEnd = formular.IndexOf(keyEnd, indexStart);
                    if (indexStartofEnd + 1 <= formular.Length - 1 && indexStartofEnd > -1)
                    {
                        var subFormular = formular.Substring(indexStart, indexStartofEnd - indexStart + keyEnd.Length);
                        if (!dic.Where(x => x.Key.Equals(subFormular)).Any())
                        {
                            dic.Add(subFormular, string.Empty);
                        }
                        i = indexStartofEnd + keyEnd.Length;
                    }
                }
            }
            return dic;
        }
        #endregion

    }
}
