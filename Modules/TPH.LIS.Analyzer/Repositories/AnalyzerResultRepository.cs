using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.AnalyzerChart.Constants;
using TPH.Common.Converter;
using TPH.Lab.BusinessService.Models;
using TPH.Language;
using TPH.LIS.Analyzer.Model;
using TPH.LIS.Common;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;
using TPH.LIS.Log;
using TPH.LIS.Log.Services.WorkingLog;
using TPH.LIS.Patient.Model;
using TPH.LIS.Patient.Services;
using TPH.LIS.TestResult.Model;
using TPH.LIS.TestResult.Services;
using TPH.WriteLog;

namespace TPH.LIS.Analyzer.Repositories
{
    public class AnalyzerResultRepository : IAnalyzerResultRepository
    {

        private readonly ITestResultService _xetnghiem = new TestResultService();
        private readonly IWorkingLogService _iWorkingLog = new WorkingLogService();
        private readonly IPatientInformationService informationService = new PatientInformationService();
        private readonly IAnalyzerConfigRepository _analyzerConfigRepository = new AnalyzerConfigRepository();
        private readonly ISystemConfigService systemConfigService = new SystemConfigService();
        private readonly IBacteriumAntibioticService sysConfigAntibiotic = new BacteriumAntibioticService();
        int limitListMaTiepNhan = 2;
        public int Update_KQMay_Barcode(string fromSid, DateTime dtFromDate, string toSid, DateTime dtToDate, string userUpdate, string IDlist)
        {
            if (_iWorkingLog.WriteLog_ChangeInstrumentSid(fromSid, toSid, dtFromDate, dtToDate, userUpdate) > -1)
            {
                //@NgayXNMoi datetime
                //,@MaTiepNhanMoi varchar(25)
                //, @BarcodeMoi varchar(12)
                //, @NgayXNCu datetime
                //, @MaTiepNhanCu varchar(25)
                var para = new SqlParameter[]
                {
                    new SqlParameter("@NgayXNMoi",dtToDate.ToString("yyyy-MM-dd") )
                    , new  SqlParameter("@MaTiepNhanMoi", ConfigurationDetail.Get_MaTiepNhan(toSid.Trim(), dtToDate))
                    , new SqlParameter("@BarcodeMoi",toSid.Trim())
                    , new SqlParameter("@NgayXNCu",dtFromDate.ToString("yyyy-MM-dd"))
                    , new SqlParameter("@MaTiepNhanCu",fromSid.Trim() )
                    , new SqlParameter("@IDlist", string.IsNullOrEmpty(IDlist) ?(object)DBNull.Value: IDlist)
                };
                return
                    (int)
                        DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpKetQuaMay_DoiBarcode", para);
            }
            return -1;
        }
        private int Check_UpdateTrangThai(string id, string trangThai, string trangThaiHienTai, ref StringBuilder sbCapNhaTrangThai)
        {
            if (trangThai.Equals(trangThaiHienTai.Trim()))
            {
                return 0;
            }
            else
            {
                sbCapNhaTrangThai.Append(string.IsNullOrEmpty(sbCapNhaTrangThai.ToString()) ? string.Empty : ";\n");
                sbCapNhaTrangThai.Append(Update_KQMay_TrangThai(id, trangThai));
                return 1;
            }
        }
        public string Update_KQMay_TrangThai(string id, string trangThai, bool forExcute = false)
        {
            if (forExcute)
            {
                var sqlPara = new SqlParameter[]
                {
                    new SqlParameter("@ID", id),
                    new SqlParameter("@TrangThai",trangThai )
                };
                DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpCapNhat_TrangThaiKQ_May", sqlPara);
                return string.Empty;
            }
            return string.Format("exec udpCapNhat_TrangThaiKQ_May @ID = {0}, @TrangThai = N'{1}'", id, trangThai.Trim());
        }
        public DataTable Data_Analyzer_Result(DateTime dateTuNgay, DateTime dateDenNgay
            , string barcode, string trangthai, string idMayXn, string[] nhomXn, string maXn
            , string userAllow, bool lanChaySau, int[] statusId, bool history = false
            , int topSelect = -1, int limitHour = -1, bool toolAuto = false, int loaiMay = -1)
        {
            if (toolAuto)
            {
                //@dateTuNgay as DATETIME
                //, @dateDenNgay as DateTime
                //, @trangthai as nvarchar(50)
                //, @idMayXn as nvarchar(max)
                //, @nhomXn as varchar(150)
                //, @maXn as varchar(150)
                //, @statusId as nvarchar(150)

                var sqlPara = new SqlParameter[]
              {
                new SqlParameter("@dateTuNgay", dateTuNgay)
                , new SqlParameter("@dateDenNgay", dateDenNgay)
                , new SqlParameter("@trangthai", string.IsNullOrEmpty(trangthai)? null: trangthai)
                , new SqlParameter("@idMayXn", string.IsNullOrEmpty(idMayXn)? null: idMayXn.Replace("'",""))
                , new SqlParameter("@nhomXn", nhomXn == null ? null: Utilities.ConvertStrinArryToInClauseSQL(nhomXn,false))
                , new SqlParameter("@maXn", string.IsNullOrEmpty(maXn)? null: maXn.Replace("'",""))
                , new SqlParameter("@statusId", Utilities.ConvertStrinArryToInClauseSQL(statusId,false))
              };
                var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure
                 , "selKetQuaMayXetNghiem_ToolAuto"
                 , !toolAuto
                 , sqlPara);
                if (ds != null)
                {
                    var data = ds.Tables[0];
                    foreach (DataColumn dtc in data.Columns)
                    {
                        dtc.ColumnName = dtc.ColumnName.ToLower();
                    }

                    return data;
                }
                else
                    return null;
            }
            else
            {
                var sqlPara = new SqlParameter[]
               {
                new SqlParameter("@history", history)
                , new SqlParameter("@dateTuNgay", dateTuNgay)
                , new SqlParameter("@dateDenNgay", dateDenNgay)
                , new SqlParameter("@barcode", string.IsNullOrEmpty(barcode)? null: barcode)
                , new SqlParameter("@trangthai", string.IsNullOrEmpty(trangthai)? null: trangthai)
                , new SqlParameter("@idMayXn", string.IsNullOrEmpty(idMayXn)? null: idMayXn.Replace("'",""))
                , new SqlParameter("@nhomXn", nhomXn == null ? null: Utilities.ConvertStrinArryToInClauseSQL(nhomXn,false))
                , new SqlParameter("@maXn", string.IsNullOrEmpty(maXn)? null: maXn.Replace("'",""))
                , new SqlParameter("@userAllow", userAllow)
                , new SqlParameter("@lanChaySau", lanChaySau)
                , new SqlParameter("@statusId", Utilities.ConvertStrinArryToInClauseSQL(statusId,false))
                , new SqlParameter("@topSelect", topSelect)
                , new SqlParameter("@limitHour", limitHour)
                , new SqlParameter("@loaimay", loaiMay)
               };
                var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure
                 , "selKetQuaMayXetNghiem"
                 , !toolAuto
                 , sqlPara);
                if (ds != null)
                {
                    var data = ds.Tables[0];
                    foreach (DataColumn dtc in data.Columns)
                    {
                        dtc.ColumnName = dtc.ColumnName.ToLower();
                    }

                    return data;
                }
                else
                    return null;
            }
        }
        private int Check_Update_AnalyzerResult(DataRow dr, int trangThai, DataTable dtconvertResult
            , string clsXetNghiemDinhDangKetqua, string userId, string khuVucThucHien
            , List<TrangThaiKetQua> lstTrangThaiXetNghiem, List<DM_XETNGHIEM_CSBT> lstCauHinh_CSBT
            , BENHNHAN_TIEPNHAN objBenhNhan, BENHNHAN_MAUSANGLOC objSangLocSS
            , EnumKieuLayKetQuaMay kieuLay
            , ref List<string> finishList
            , ref StringBuilder sbCapNhaTrangThai, bool toolAuto, bool deKetQuaChuaDuyet, bool tuXacNhan, bool khongXacNhanKQbatThuong)
        {
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            var loaiXetNghiem = NumberConverter.ToInt(dr["LoaiXetNghiem"]);
            if (loaiXetNghiem == (int)TestType.EnumTestType.SHPTGen || loaiXetNghiem == (int)TestType.EnumTestType.SHPTTacNhan)
            {
                return Check_Update_AnalyzerResult_Gen(dr, trangThai, dtconvertResult, clsXetNghiemDinhDangKetqua, userId, khuVucThucHien
                                                    , lstTrangThaiXetNghiem, lstCauHinh_CSBT, objBenhNhan, objSangLocSS, kieuLay, ref finishList
                                                    , ref sbCapNhaTrangThai, toolAuto);
            }
            else
            {
                var maTiepNhan = ConfigurationDetail.Get_MaTiepNhan(StringConverter.ToString(dr["SID"]),
                          DateTimeConverter.ToDateTime(dr["NgayXN"]));
                var seq = StringConverter.ToString(dr["Seq"]);
                var resultType = StringConverter.ToString(dr["resulttype"]);
                int returnVal = 0;
                if (!resultType.Trim().Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    var id = StringConverter.ToString(dr["ID"]);
                    var maXn = StringConverter.ToString(dr["MaXN"]).Trim();
                    var maxnCheck = maXn.Replace("%", "Per");
                    var layDinhTinh = bool.Parse(dr["LayDinhTinh"].ToString() == "0" ? false.ToString() : dr["LayDinhTinh"].ToString());
                    var layDinhLuong = bool.Parse(dr["LayDinhLuong"].ToString() == "0" ? false.ToString() : dr["LayDinhLuong"].ToString());

                    var ketQuaGoc = (layDinhLuong ? StringConverter.ToString(dr["KetQua"]) : string.Empty);
                    var dinhtinh = (layDinhTinh ? StringConverter.ToString(dr["dinhtinh"]) : string.Empty);

                    var maXnMay = StringConverter.ToString(dr["MaMay"]);
                    var idMay = StringConverter.ToString(dr["IDMay"]);

                    var statusId = NumberConverter.ToInt(dr["status_id"]);
                    var chothem = bool.Parse(dr["chothem"].ToString() == "0" ? false.ToString() : dr["chothem"].ToString());
                    var trangthaiCheck = LanguageExtension.GetResourceValueFromValue(StringConverter.ToString(dr["trangthai"]), LanguageExtension.AppLanguage) ;
                    var xnChinh = StringConverter.ToString(dr["MasterTest"]);
                    var modulename = StringConverter.ToString(dr["modules"]);
                    var layCo = bool.Parse(string.IsNullOrEmpty(dr["GetFlag"].ToString()) ? false.ToString() : dr["GetFlag"].ToString());
                    var flag = (layCo ? StringConverter.ToString(dr["FlagDescription"]) : string.Empty);
                    var chapNhanKieuLay = false;
                    if (kieuLay == EnumKieuLayKetQuaMay.TatCa)
                        chapNhanKieuLay = true;
                    else if (kieuLay == EnumKieuLayKetQuaMay.ChiTuMayThongThuong)
                        chapNhanKieuLay = statusId.Equals(0);
                    else if (kieuLay == EnumKieuLayKetQuaMay.ChiTuPhanMemTrungGian)
                        chapNhanKieuLay = statusId.Equals(2);
                    var isHinhAnh = bool.Parse(dr["isimage"].ToString() == "0" ? false.ToString() : dr["isimage"].ToString());
                    var chuoiHinhAnh = StringConverter.ToString(dr["imagestring"]);
                    var giaoThucBieuDo = StringConverter.ToString(dr["GiaoThucBieuDo"]);
                    var quyTrinhMau = StringConverter.ToString(dr["QuyTrinhMau"]);
                    var quyTrinhKSD = StringConverter.ToString(dr["QuyTrinhKSD"]);
                    var maCaptren = StringConverter.ToString(dr["dekhangkhangsinh"]);
                    var qcout = NumberConverter.ToBool(dr["QCOut"]);
                    var objtrangThaiHientai = new ThongTinHienTaiCuaXetNghiem()
                    {
                        MaTiepNhan = maTiepNhan,
                        MaXn = maXn,
                        IDMay = idMay,
                        ModuleName = modulename,
                        ToolAuto = toolAuto
                    };
                    if (string.IsNullOrEmpty(maXn))
                    {
                        //Cập nhật => chưa map mã máy xn
                        return Check_UpdateTrangThai(id, TestingResultStatusConstant.ChuaNhapMa, trangthaiCheck, ref sbCapNhaTrangThai);
                    }
                    else if ((!string.IsNullOrEmpty(ketQuaGoc) || (!string.IsNullOrEmpty(dinhtinh))) && chapNhanKieuLay
                         && (trangthaiCheck.Equals(TestingResultStatusConstant.ChapNhan, StringComparison.OrdinalIgnoreCase)
                         || trangthaiCheck.Equals(TestingResultStatusConstant.ChuaNhapChiDinh, StringComparison.OrdinalIgnoreCase)
                         || trangthaiCheck.Equals(TestingResultStatusConstant.DaCapNhatKetQua, StringComparison.OrdinalIgnoreCase)
                         || trangthaiCheck.Equals(TestingResultStatusConstant.ChuaNhapThongTin, StringComparison.OrdinalIgnoreCase)))
                    {
                        var posneg = string.Empty;
                        if (finishList.Contains(maxnCheck))
                        {
                            trangThai = 4;
                        }
                        else
                        {
                            if (isHinhAnh)
                            {
                                returnVal = _xetnghiem.CapNhat_HinhAnh_MayXN(maTiepNhan, idMay, maXn, chuoiHinhAnh, null);
                                Update_KQMay_TrangThai(id, TestingResultStatusConstant.DaCapNhatKetQua, true);
                                finishList.Add(maXn);
                                trangThai = -1;
                            }
                            else
                            {
                                LayGiaTriSoSanh_KiemTraTrangThaiXetNghiem(lstTrangThaiXetNghiem, lstCauHinh_CSBT, objBenhNhan, objSangLocSS, objtrangThaiHientai);
                            }
                        }
                        //Kiểm tra giá trị trả về sau khi lấy trạng thái
                        switch (objtrangThaiHientai.TrangThai)
                        {
                            case 0:
                                //Cập nhật => chưa nhập thong tin
                                returnVal = Check_UpdateTrangThai(id, TestingResultStatusConstant.ChuaNhapThongTin, trangthaiCheck, ref sbCapNhaTrangThai);
                                break;
                            case 1:
                                //Cập nhật => đã in
                                returnVal = Check_UpdateTrangThai(id, TestingResultStatusConstant.DaInKetQua, trangthaiCheck, ref sbCapNhaTrangThai);
                                break;
                            case 2:
                                if (chothem)
                                {
                                    if (Insert_ChiDinhChoThemThuongQuy(maTiepNhan, maXn, xnChinh, khuVucThucHien, maCaptren, objBenhNhan))
                                    {
                                        lstTrangThaiXetNghiem = ListTrangThaiKetQuaCLSXetNghiem(maTiepNhan);
                                        returnVal = Check_Update_AnalyzerResult(dr, trangThai, dtconvertResult, clsXetNghiemDinhDangKetqua, userId
                                           , khuVucThucHien, lstTrangThaiXetNghiem, lstCauHinh_CSBT, objBenhNhan, objSangLocSS, kieuLay
                                           , ref finishList, ref sbCapNhaTrangThai, toolAuto, deKetQuaChuaDuyet, tuXacNhan, khongXacNhanKQbatThuong);
                                    }
                                    else
                                        returnVal = Check_UpdateTrangThai(id, TestingResultStatusConstant.ChuaNhapChiDinh, trangthaiCheck, ref sbCapNhaTrangThai);
                                    break;
                                }
                                else
                                {
                                    //Cập nhật => chua nhap chi dinh
                                    returnVal = Check_UpdateTrangThai(id, TestingResultStatusConstant.ChuaNhapChiDinh, trangthaiCheck, ref sbCapNhaTrangThai);
                                    break;
                                }
                            case 3:
                                //Cập nhật => kết quả đã xác nhận
                                returnVal = Check_UpdateTrangThai(id, TestingResultStatusConstant.DaXacNhanKetQua, trangthaiCheck, ref sbCapNhaTrangThai);
                                break;
                            case 4:
                                //Cập nhật => đã có kết quả
                                if (deKetQuaChuaDuyet)
                                {
                                    //Xử lý ghi log kết quả và update kết quả mới => cờ sửa kết quả  = true
                                    returnVal = CapNhatKetQua(dtconvertResult, maTiepNhan, maXn, maxnCheck
                                                , idMay, maXnMay, ketQuaGoc, dinhtinh, layCo, flag
                                                , clsXetNghiemDinhDangKetqua, objtrangThaiHientai, userId
                                                , ref finishList, ref sbCapNhaTrangThai, id, true, qcout, tuXacNhan, khongXacNhanKQbatThuong);
                                }
                                else
                                {
                                    returnVal = Check_UpdateTrangThai(id, TestingResultStatusConstant.DaCoKetQua, trangthaiCheck, ref sbCapNhaTrangThai);
                                }
                                break;
                            default:
                                returnVal = CapNhatKetQua(dtconvertResult, maTiepNhan, maXn, maxnCheck
                                               , idMay, maXnMay, ketQuaGoc, dinhtinh, layCo, flag
                                               , clsXetNghiemDinhDangKetqua, objtrangThaiHientai, userId
                                               , ref finishList, ref sbCapNhaTrangThai, id, false, qcout, tuXacNhan, khongXacNhanKQbatThuong);
                                break;
                        }
                    }
                    else if (string.IsNullOrEmpty(ketQuaGoc) && string.IsNullOrEmpty(dinhtinh))
                    {
                        //Cập nhật => chưa map mã máy xn
                        return Check_UpdateTrangThai(id, TestingResultStatusConstant.XemLai, trangthaiCheck, ref sbCapNhaTrangThai);
                    }
                }
                return returnVal;
            }
        }
        private int CapNhatKetQua(DataTable dtconvertResult, string maTiepNhan, string maXn, string maxnCheck
            , string idMay, string maXnMay, string ketQuaGoc, string dinhtinh, bool layCo, string flag
            , string clsXetNghiemDinhDangKetqua, ThongTinHienTaiCuaXetNghiem objtrangThaiHientai, string userId
            , ref List<string> finishList, ref StringBuilder sbCapNhaTrangThai, string id
            , bool suaKetqua, bool QCOut, bool tuXacNhan, bool khongXacNhanKQbatThuong)
        {
            var posneg = string.Empty;
            string dinhDangBienDich = string.Empty;
            var ketQuaSauBienDich = Check_ConvertInstrumentresult(dtconvertResult, idMay, maXnMay,
                 ketQuaGoc, ref posneg);

            var ketQuaDinhtinhSauBienDich = Check_ConvertInstrumentresult(dtconvertResult, idMay, maXnMay,
                dinhtinh, ref posneg);

            var ketquafull = (clsXetNghiemDinhDangKetqua.Replace("{N}", ketQuaSauBienDich).Replace("{S}", ketQuaDinhtinhSauBienDich)).Trim().Replace("{F}", (layCo ? flag : string.Empty)).Trim();

            //Kiem tra cờ
            var co = LabResultService.SetColor(ketquafull, (objtrangThaiHientai.CanTren ?? (object)string.Empty).ToString(), (objtrangThaiHientai.CanDuoi ?? (object)string.Empty).ToString(), objtrangThaiHientai.DieuKienBatThuong);
            var coCanhBao = LabResultService.SetColor(ketquafull, (objtrangThaiHientai.CanTrenCanhBao ?? (object)string.Empty).ToString(), (objtrangThaiHientai.CanDuoiCanhBao ?? (object)string.Empty).ToString(), objtrangThaiHientai.DieuKienCanhBaoDinhTinh);
            float? Ketquaquidoi = null;
            var Ketquadtquidoi = string.Empty;
            if (objtrangThaiHientai.Hesoquidoi > 0)
            {
                var kqCheckQuiDoi = ketQuaSauBienDich.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(":", "").Replace("+", "").Replace("-", "").Replace(">", "").Replace("<", "").Replace("=", "");
                if (WorkingServices.IsNumeric(kqCheckQuiDoi))
                {
                    Ketquaquidoi = (float.Parse(kqCheckQuiDoi)) * objtrangThaiHientai.Hesoquidoi;
                    Ketquadtquidoi = (clsXetNghiemDinhDangKetqua.Replace("{N}", Math.Round(Ketquaquidoi.Value, objtrangThaiHientai.Lamtronsauquidoi).ToString()).Replace("{S}", ketQuaDinhtinhSauBienDich)).Trim().Replace("{F}", (layCo ? flag : string.Empty)).Trim();
                }
            }
            //định dạng làm tròn kết quả
            ketquafull = ConvertRoundResult(NumberConverter.ToInt(idMay), maXnMay, ketquafull,
               dtconvertResult);
            if ((co > 1 && khongXacNhanKQbatThuong && tuXacNhan) || QCOut)
                tuXacNhan = false;
            var sql = _xetnghiem.CapNhat_KQ_XN(
                new UpdateResultNormalInfo
                {
                    maTiepNhan = maTiepNhan,
                    maXN = maXn,
                    ketQua = ketquafull,
                    capNhatghiChu = false,
                    ghiChu = string.Empty,
                    co = co.ToString(),
                    userNhap = userId,
                    suaKQ = false,
                    round = (objtrangThaiHientai.LamTron == null ? "0": objtrangThaiHientai.LamTron.Value.ToString()),
                    userUpdate = userId,
                    coCapnhatHeso = false,
                    ketquaHeso = string.Empty,
                    iDMayXetNghiem = idMay,
                    modules = objtrangThaiHientai.ModuleName,
                    maXNMay = maXnMay,
                    updateCsbt = true,
                    chisoBT = objtrangThaiHientai.CSBinhThuong,
                    canTren = (objtrangThaiHientai.CanTren == null ? String.Empty : objtrangThaiHientai.CanTren.Value.ToString()),
                    canDuoi = (objtrangThaiHientai.CanDuoi == null ? String.Empty : objtrangThaiHientai.CanDuoi.Value.ToString()),
                    updateDVT = true,
                    dvTinh = objtrangThaiHientai.DVTinh,
                    dkBatThuong = objtrangThaiHientai.DieuKienBatThuong,
                    tuValid = tuXacNhan,
                    uservalid =(tuXacNhan ? userId: string.Empty),
                    tgValid = null,
                    capnhatDinhLuong = false,
                    ketquaDinhLuong = string.Empty,
                    capnhatDinhTinh = false,
                    ketquaDinhTinh = string.Empty,
                    capnhatCoKetQua = true,
                    coKetQua = flag,
                    chisoBTCanhBao = objtrangThaiHientai.GioiHanCanhBao,
                    canTrenCanhBao = (objtrangThaiHientai.CanTrenCanhBao == null ? String.Empty : objtrangThaiHientai.CanTrenCanhBao.Value.ToString()),
                    canDuoiCanhBao = (objtrangThaiHientai.CanDuoiCanhBao == null ? String.Empty : objtrangThaiHientai.CanDuoiCanhBao.Value.ToString()),
                    coCanhBao = coCanhBao,
                    Qcout = QCOut,
                    Hesoquydoi = objtrangThaiHientai.Hesoquidoi,
                    Ketquaquidoi = Ketquaquidoi,
                    Ketquadtquidoi = Ketquadtquidoi,
                    Csbtquidoi = objtrangThaiHientai.Csbtquidoi,
                    Donviquidoi = objtrangThaiHientai.Donviquidoi
                });
                
            //Cập nhật => đã cập nhật
            sbCapNhaTrangThai.Append(string.IsNullOrEmpty(sbCapNhaTrangThai.ToString()) ? string.Empty : ";\n");
            sbCapNhaTrangThai.Append(Update_KQMay_TrangThai(id, TestingResultStatusConstant.DaCapNhatKetQua));
            finishList.Add(maxnCheck);
            return 1;
        }
        #region Xử lý kết quả vi sinh
        public void Get_KetQuaviSinh(DataTable dataKetQuaMay, bool toolAuto, ProgressBar probar, AutoResetEvent LockUpdateAuto, ref int iNumAuto)
        {
            //var datatable 
            if (dataKetQuaMay.Rows.Count > 0)
            {
                var lstketquaKSD = new List<AnalyzerOrganismAndAntibiotic>();
                var lstdsQuyTrinhMau = new List<SampleTestMethod>();

                //lấy distinct vi khuẩn để so sánh với vk select => trường hợp lấy cập nhật chỉ 1 dòng kháng sinh đồ
                var distinctSID_ViKhuan = dataKetQuaMay.DefaultView.ToTable(true, "MaViKhuan", "TenViKhuan", "sid", "NgayXN");
                foreach (DataRow drSID in distinctSID_ViKhuan.Rows)
                {
                    var ketqua = new AnalyzerOrganismAndAntibiotic();
                    var sid = drSID["SID"].ToString();
                    var MaViKhuan = drSID["MaViKhuan"].ToString();
                    var NgayXN = DateTime.Parse(drSID["NgayXN"].ToString());

                    var matiepnhan = ConfigurationDetail.Get_MaTiepNhan(sid, NgayXN);
                    //Get danh sách vi khuẩn -> danh sách này có thông tin testkit 
                    var dataVikhuanCoKSD = WorkingServices.SearchResult_OnDatatable(dataKetQuaMay, string.Format("MaViKhuan = '{0}' and SID = '{1}' and NgayXN = '{2}' and MaXN is not null", MaViKhuan, sid, NgayXN));
                    if (dataVikhuanCoKSD.Rows.Count > 0)
                    {
                        var dataVikhuan = WorkingServices.SearchResult_OnDatatable(dataVikhuanCoKSD, "MaViKhuan is not null");
                        if (dataVikhuan.Rows.Count > 0)
                        {
                            ketqua.lstDSViKhuan = new List<Organism>();
                            foreach (DataRow drVk in dataVikhuan.Rows)
                            {
                                var viKhuan = new Organism();

                                viKhuan.ResultID = int.Parse(drVk["id"].ToString());
                                viKhuan.MaTiepNhan = matiepnhan;
                                //cần xử lý mã yêu cầu này cho chính xác
                                viKhuan.MaYeuCau = drVk["maxn"].ToString().Trim();
                                viKhuan.MaViKhuanMay = drVk["MaViKhuan"].ToString().Trim();
                                viKhuan.TenViKhuanMay = drVk["TenViKhuan"].ToString().Trim();
                                viKhuan.MaViKhuan = drVk["MaViKhuanLis"].ToString().Trim();
                                viKhuan.TestKitVK = drVk["mamay"].ToString().Trim();
                                viKhuan.NguoiNhap = drVk["idmay"].ToString().Trim();
                                viKhuan.idMayXn = drVk["idmay"].ToString().Trim();
                                viKhuan.QuyTrinhMau = drVk["QuyTrinhMau"].ToString().Trim();
                                if (!ketqua.lstDSViKhuan.Where(x => x.MaViKhuan.Equals(viKhuan.MaViKhuan, StringComparison.OrdinalIgnoreCase) && x.MaYeuCau.Equals(viKhuan.MaYeuCau, StringComparison.OrdinalIgnoreCase)).Any())
                                    ketqua.lstDSViKhuan.Add(viKhuan);
                                var objQuyTrinhMau = new SampleTestMethod();
                                objQuyTrinhMau.MaTiepNhan = matiepnhan;
                                objQuyTrinhMau.MaYeuCau = viKhuan.MaYeuCau;
                                objQuyTrinhMau.QuyTrinhMau = viKhuan.QuyTrinhMau;
                                objQuyTrinhMau.IdMayXn = viKhuan.idMayXn;
                                if (!lstdsQuyTrinhMau.Contains(objQuyTrinhMau))
                                    lstdsQuyTrinhMau.Add(objQuyTrinhMau);
                            }
                        }
                        //Xử lý kháng sinh đồ của vi khuẩn
                        var dataKSD = WorkingServices.SearchResult_OnDatatable(dataVikhuanCoKSD, "MaKhangSinh is not null");
                        if (dataKSD.Rows.Count > 0)
                        {
                            ketqua.lstDSKhangSinh = new List<AntiBiotic>();
                            ketqua.lstCoCheKhang = new List<CoCheKhangKhangSinh>();
                            var ks = new AntiBiotic();

                            foreach (DataRow drKS in dataKSD.Rows)
                            {
                                if (!string.IsNullOrEmpty(drKS["DeKhangKhangSinh"].ToString().Trim()))
                                {
                                    var coCheKhang = new CoCheKhangKhangSinh();
                                    coCheKhang.ResultID = int.Parse(drKS["id"].ToString());
                                    coCheKhang.MaTiepNhan = matiepnhan;
                                    coCheKhang.MaViKhuan = drKS["MaViKhuanLis"].ToString().Trim();
                                    coCheKhang.MaYeuCau = drKS["MaXN"].ToString(); // -> xử lý mã yêu cầu
                                    coCheKhang.CoCheKhang = drKS["TenKhangSinh"].ToString().Trim();//lấy tên kháng sinh để in hoa
                                    coCheKhang.KetquaCoCheKhang = drKS["KetQuaDeKhangKhangSinh"].ToString().Trim();
                                    coCheKhang.NguoiNhap = drKS["idmay"].ToString().Trim();
                                    if (!ketqua.lstCoCheKhang.Contains(coCheKhang))
                                        ketqua.lstCoCheKhang.Add(coCheKhang);
                                }
                                else
                                {
                                    ks = new AntiBiotic();
                                    ks.ResultID = int.Parse(drKS["id"].ToString());
                                    ks.MaKhangSinhMay = drKS["MaKhangSinh"].ToString().Trim();
                                    ks.TenKhangSinhMay = drKS["TenKhangSinh"].ToString().Trim();
                                    ks.MaKhangSinh = drKS["MaKhangSinhLis"].ToString().Trim();
                                    ks.KetQuaSIR = drKS["KetQua"].ToString().Trim();
                                    ks.KetQuaDinhLuong = drKS["DinhTinh"].ToString().Trim();
                                    ks.TestKitKS = drKS["mamay"].ToString().Trim();
                                    ks.KyThuat = drKS["MIC"].ToString().Trim();
                                    ks.KyThuat = string.IsNullOrEmpty(ks.KyThuat) ? "MIC" : ks.KyThuat; //kỹ thuật mặc định chạy máy là MIC, trừ khi máy chạy kỹ thuật khác
                                    ks.MaTiepNhan = matiepnhan;
                                    ks.MaYeuCau = drKS["MaXN"].ToString(); // -> xử lý mã yêu cầu
                                    ks.MaViKhuan = drKS["MaViKhuanLis"].ToString().Trim();
                                    ks.NguoiNhap = drKS["idmay"].ToString().Trim();
                                    ks.MaViKhuanMay = drKS["MaViKhuan"].ToString().Trim();
                                    ks.TenViKhuanMay = drKS["TenViKhuan"].ToString().Trim();
                                    ks.idMayXn = drKS["idmay"].ToString().Trim();
                                    ks.QuyTrinhKSD = drKS["QuyTrinhKSD"].ToString().Trim();
                                    ks.QuyTrinhMau = drKS["QuyTrinhMau"].ToString().Trim();
                                    ks.SiteInfection = drKS["SiteInfection"].ToString().Trim();
                                    ketqua.lstDSKhangSinh.Add(ks);
                                    var objQuyTrinhMau = new SampleTestMethod();
                                    objQuyTrinhMau.MaTiepNhan = matiepnhan;
                                    objQuyTrinhMau.MaYeuCau = ks.MaYeuCau;
                                    objQuyTrinhMau.QuyTrinhMau = ks.QuyTrinhMau;
                                    objQuyTrinhMau.IdMayXn = ks.idMayXn;
                                    if (!lstdsQuyTrinhMau.Contains(objQuyTrinhMau))
                                        lstdsQuyTrinhMau.Add(objQuyTrinhMau);
                                }
                            }
                        }
                    }

                    //Add kết quả vào danh sách
                    lstketquaKSD.Add(ketqua);
                    if (lstketquaKSD.Count > 0)
                    {
                        var sbUpdateKQ = new StringBuilder();
                        var sbUpdateTrangThai = new StringBuilder();
                        var finishList = new List<string>();
                        if (Update_KetQuaViSinh(lstketquaKSD, ref finishList, ref sbUpdateKQ, ref sbUpdateTrangThai, toolAuto) > -1)
                        {
                            if (!string.IsNullOrEmpty(sbUpdateKQ.ToString()))
                                DataProvider.ExecuteQuery(sbUpdateKQ.ToString());
                            if (!string.IsNullOrEmpty(sbUpdateTrangThai.ToString()))
                                DataProvider.ExecuteQuery(sbUpdateTrangThai.ToString());
                            // _xetnghiem.CapNhat_ThongTinMayXn_XnChinh(matiepnhan);
                            // _xetnghiem.CapNhat_DuKQ_XN(matiepnhan);
                            if (lstdsQuyTrinhMau.Count > 0)
                            {
                                CapNhat_ThongTinQUyTrinh_LoaiMau(lstdsQuyTrinhMau);
                            }
                        }
                    }
                }
            }
        }
        private void CapNhat_ThongTinQUyTrinh_LoaiMau(List<SampleTestMethod> lstQTMau)
        {
            if (lstQTMau.Count > 0)
            {
                var lst = lstQTMau.Select(x => new { x.MaTiepNhan, x.MaYeuCau, x.QuyTrinhMau, x.IdMayXn }).Distinct();
                foreach (var item in lst)
                {
                    var para = new SqlParameter[]
                        {
                            new SqlParameter("@MaTiepNhan",item.MaTiepNhan)
                            ,new SqlParameter("@MaYeuCau",item.MaYeuCau)
                            ,new SqlParameter("@QuyTrinh",item.QuyTrinhMau)
                            ,new SqlParameter("@IdMayXn",string.IsNullOrEmpty( item.IdMayXn)?"0":item.IdMayXn )
                        };
                    DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpXetNghiem_ViSinh_QuyTrinh", para);
                }
            }
        }
        private int Update_KetQuaViSinh(List<AnalyzerOrganismAndAntibiotic> lstKetqua
            , ref List<string> finishList, ref StringBuilder sbUpdateKQ, ref StringBuilder sbCapNhaTrangThai, bool toolAuto)
        {
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            var iCount = 0;
            if (lstKetqua.Count > 0)
            {
                var dataMaBoKhangSinh = new DataTable();
                foreach (var item in lstKetqua)
                {
                    if (item.lstDSViKhuan != null)
                    {
                        if (item.lstDSViKhuan.Count > 0)
                        {
                            int trangThai = -1;
                            var currentmaTiepnhan = string.Empty;
                            var currentMaYeuCau = string.Empty;

                            foreach (var itmVK in item.lstDSViKhuan)
                            {
                                if (!string.IsNullOrEmpty(itmVK.MaViKhuan))
                                {
                                    //Kiểm tra đã nhập chỉ định vi sinh
                                    if (currentmaTiepnhan != itmVK.MaTiepNhan || currentMaYeuCau != itmVK.MaYeuCau)
                                    {
                                        trangThai = TrangThaiViSinh(itmVK.MaTiepNhan, itmVK.MaYeuCau);
                                        currentmaTiepnhan = itmVK.MaTiepNhan;
                                        currentMaYeuCau = itmVK.MaYeuCau;
                                    }

                                    if (trangThai == 0)
                                    {
                                        //Cập nhật => đã in
                                        sbCapNhaTrangThai.Append(string.IsNullOrEmpty(sbCapNhaTrangThai.ToString()) ? string.Empty : ";\n");
                                        sbCapNhaTrangThai.Append(Update_KQMay_TrangThai(itmVK.ResultID.ToString(), TestingResultStatusConstant.ChuaNhapChiDinh));
                                    }
                                    else if (trangThai == 2)
                                    {
                                        //Cập nhật => đã in
                                        sbCapNhaTrangThai.Append(string.IsNullOrEmpty(sbCapNhaTrangThai.ToString()) ? string.Empty : ";\n");
                                        sbCapNhaTrangThai.Append(Update_KQMay_TrangThai(itmVK.ResultID.ToString(), TestingResultStatusConstant.DaInKetQua));
                                    }
                                    else if (trangThai == 3)
                                    {
                                        //Cập nhật => đã duyệt
                                        sbCapNhaTrangThai.Append(string.IsNullOrEmpty(sbCapNhaTrangThai.ToString()) ? string.Empty : ";\n");
                                        sbCapNhaTrangThai.Append(Update_KQMay_TrangThai(itmVK.ResultID.ToString(), TestingResultStatusConstant.DaXacNhanKetQua));
                                    }
                                    else if (trangThai == 1)
                                    {
                                        /*
                                         * @MaTiepNhan varchar(20)
                                            ,@MaYeuCau varchar(20)
                                            ,@MaPhanLoai varchar(20)
                                            ,@MaPhanLoaiMay varchar(20)
                                            ,@TenPhanLoaiMay varchar(20)
                                            ,@TestKitID varchar(20)
                                            ,@NguoiNhap varchar(25)
                                            ,@idMayXn int = 0 
                                         * */
                                        // đầu tiên insert vi khuẩn
                                        var para = new SqlParameter[]
                                    {
                                    WorkingServices.GetParaFromOject("@MaTiepNhan",itmVK.MaTiepNhan)
                                    ,WorkingServices.GetParaFromOject("@MaYeuCau",itmVK.MaYeuCau)
                                    ,WorkingServices.GetParaFromOject("@MaPhanLoai",itmVK.MaViKhuan)
                                    ,WorkingServices.GetParaFromOject("@MaPhanLoaiMay",itmVK.MaViKhuanMay)
                                    ,WorkingServices.GetParaFromOject("@TenPhanLoaiMay",itmVK.TenViKhuanMay)
                                    ,WorkingServices.GetParaFromOject("@TestKitID",itmVK.TestKitVK)
                                    ,WorkingServices.GetParaFromOject("@NguoiNhap",itmVK.NguoiNhap)
                                    ,WorkingServices.GetParaFromOject("@idMayXn",itmVK.idMayXn)
                                    ,WorkingServices.GetParaFromOject("@KyThuat","MIC")
                                    };
                                        iCount = (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insXetNghiem_ViKhuan", para);
                                        if (iCount > -1)
                                        {
                                            var paraQT = new SqlParameter[]
                                                   {
                                                            WorkingServices.GetParaFromOject("@MaTiepNhan",itmVK.MaTiepNhan)
                                                            ,WorkingServices.GetParaFromOject("@MaYeuCau",itmVK.MaYeuCau)
                                                            ,WorkingServices.GetParaFromOject("@QuyTrinh",(object)DBNull.Value)
                                                            ,WorkingServices.GetParaFromOject("@IdMayXn",itmVK.idMayXn )
                                                   };
                                            DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpXetNghiem_ViSinh_QuyTrinh", paraQT);
                                            //Cập nhật => đã cập nhật
                                            sbCapNhaTrangThai.Append(string.IsNullOrEmpty(sbCapNhaTrangThai.ToString()) ? string.Empty : ";\n");
                                            sbCapNhaTrangThai.Append(Update_KQMay_TrangThai(itmVK.ResultID.ToString(), TestingResultStatusConstant.DaCapNhatKetQua));
                                        }
                                    }
                                    //Nếu kết quả có kháng sinh thì insert kháng sinh đồ theo panel
                                    if (item.lstDSKhangSinh.Where(x => x.MaViKhuan.Equals(itmVK.MaViKhuan, StringComparison.OrdinalIgnoreCase) && x.MaYeuCau.Equals(itmVK.MaYeuCau, StringComparison.OrdinalIgnoreCase)).Any())
                                    {
                                        //Insert kháng sinh theo panel
                                        dataMaBoKhangSinh = sysConfigAntibiotic.Data_dm_xetnghiem_visinh_bo_by_mvk(itmVK.MaViKhuan);
                                        if (dataMaBoKhangSinh.Rows.Count > 0)
                                        {
                                            foreach (DataRow dr in dataMaBoKhangSinh.Rows)
                                            {
                                                var maBoKS = StringConverter.ToString(dr["MaBoKhangSinh"]);

                                                var sqlPara = new SqlParameter[]
                                                       {
                                                        WorkingServices.GetParaFromOject("@MaTiepNhan", itmVK.MaTiepNhan)
                                                        , WorkingServices.GetParaFromOject("@MaYeuCau",itmVK.MaYeuCau)
                                                        , WorkingServices.GetParaFromOject("@MaViKhuan", itmVK.MaViKhuan)
                                                        , WorkingServices.GetParaFromOject("@MaKhangSinh", (object)DBNull.Value)
                                                        , WorkingServices.GetParaFromOject("@MaKhangSinhMay", (object)DBNull.Value)
                                                        , WorkingServices.GetParaFromOject("@TenKhangSinhMay", (object)DBNull.Value)
                                                        , WorkingServices.GetParaFromOject("@KetQuaSIR", (object)DBNull.Value)
                                                        , WorkingServices.GetParaFromOject("@KetQuadinhluong", (object)DBNull.Value)
                                                        , WorkingServices.GetParaFromOject("@KyThuat", "MIC")
                                                        , WorkingServices.GetParaFromOject("@NguoiNhap", itmVK.NguoiNhap)
                                                        , WorkingServices.GetParaFromOject("@TestKitKS", (object)DBNull.Value)
                                                        , WorkingServices.GetParaFromOject("@MaBoKhangSinh", maBoKS)
                                                       };
                                                DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insXetNghiem_KhangSinhDo", sqlPara);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    //Cập nhật => chưa mapping mã
                                    sbCapNhaTrangThai.Append(string.IsNullOrEmpty(sbCapNhaTrangThai.ToString()) ? string.Empty : ";\n");
                                    sbCapNhaTrangThai.Append(Update_KQMay_TrangThai(itmVK.ResultID.ToString(), TestingResultStatusConstant.ChuaNhapMa));
                                }
                            }
                        }
                    }

                    //insert kháng sinh đồ -> insert trước để check chưa có vi khuẩn thì insert cho kháng kháng sinh luôn
                    if (item.lstDSKhangSinh != null)
                    {
                        if (item.lstDSKhangSinh.Count > 0)
                        {
                            /*
                              * @MaTiepNhan varchar (20)
                             ,@MaYeuCau varchar (25)
                             ,@MaViKhuan varchar(20)
                             ,@MaKhangSinh varchar(20)
                             ,@MaKhangSinhMay varchar(20)
                             ,@TenKhangSinhMay nvarchar(150)
                             ,@KetQuaSIR varchar(20)
                             ,@KetQuadinhluong varchar(20)
                             ,@KyThuat varchar(20)
                             ,@NguoiNhap varchar(20)
                             ,@TestKitKS varchar(20)
                             */
                            int trangThai = -1;
                            var currentmaTiepnhan = string.Empty;
                            var currentMaYeuCau = string.Empty;
                            foreach (var itemKS in item.lstDSKhangSinh)
                            {

                                if (!string.IsNullOrEmpty(itemKS.MaKhangSinh) && !string.IsNullOrEmpty(itemKS.MaViKhuan))
                                {
                                    if (currentmaTiepnhan != itemKS.MaTiepNhan || currentMaYeuCau != itemKS.MaYeuCau)
                                    {
                                        trangThai = TrangThaiViSinh(itemKS.MaTiepNhan, itemKS.MaYeuCau);
                                        currentmaTiepnhan = itemKS.MaTiepNhan;
                                        currentMaYeuCau = itemKS.MaYeuCau;
                                    }
                                    if (trangThai == 0)
                                    {
                                        //Cập nhật => đã in
                                        sbCapNhaTrangThai.Append(string.IsNullOrEmpty(sbCapNhaTrangThai.ToString()) ? string.Empty : ";\n");
                                        sbCapNhaTrangThai.Append(Update_KQMay_TrangThai(itemKS.ResultID.ToString(), TestingResultStatusConstant.ChuaNhapChiDinh));
                                    }
                                    else if (trangThai == 2)
                                    {
                                        //Cập nhật => đã in
                                        sbCapNhaTrangThai.Append(string.IsNullOrEmpty(sbCapNhaTrangThai.ToString()) ? string.Empty : ";\n");
                                        sbCapNhaTrangThai.Append(Update_KQMay_TrangThai(itemKS.ResultID.ToString(), TestingResultStatusConstant.DaInKetQua));
                                    }
                                    else if (trangThai == 3)
                                    {
                                        //Cập nhật => đã duyệt
                                        sbCapNhaTrangThai.Append(string.IsNullOrEmpty(sbCapNhaTrangThai.ToString()) ? string.Empty : ";\n");
                                        sbCapNhaTrangThai.Append(Update_KQMay_TrangThai(itemKS.ResultID.ToString(), TestingResultStatusConstant.DaXacNhanKetQua));
                                    }
                                    else if (trangThai == 1)
                                    {
                                        var count = 0;
                                        var coKetQua = (int)AntiBioticColor.Unidentified;
                                        if (!string.IsNullOrEmpty(itemKS.KetQuaSIR))
                                            coKetQua = (int)AnitBioticResultIndex.GetResultColorFlat(itemKS.KetQuaSIR);


                                        var sqlPara = new SqlParameter[]
                                           {
                                                    WorkingServices.GetParaFromOject("@MaTiepNhan", itemKS.MaTiepNhan)
                                                    , WorkingServices.GetParaFromOject("@MaYeuCau",itemKS.MaYeuCau)
                                                    , WorkingServices.GetParaFromOject("@MaViKhuan", itemKS.MaViKhuan)
                                                    , WorkingServices.GetParaFromOject("@MaKhangSinh", itemKS.MaKhangSinh)
                                                    , WorkingServices.GetParaFromOject("@MaKhangSinhMay", itemKS.MaKhangSinhMay)
                                                    , WorkingServices.GetParaFromOject("@TenKhangSinhMay", itemKS.TenKhangSinhMay)
                                                    , WorkingServices.GetParaFromOject("@KetQuaSIR",AnitBioticResultIndex.ConvertResultToSIR(itemKS.KetQuaSIR))
                                                    , WorkingServices.GetParaFromOject("@KetQuadinhluong",itemKS.KetQuaDinhLuong?? (object)DBNull.Value)
                                                    , WorkingServices.GetParaFromOject("@KyThuat", itemKS.KyThuat)
                                                    , WorkingServices.GetParaFromOject("@NguoiNhap", itemKS.NguoiNhap)
                                                    , WorkingServices.GetParaFromOject("@TestKitKS", itemKS.TestKitKS)
                                                    , WorkingServices.GetParaFromOject("@MaViKhuanMay",itemKS.MaViKhuanMay)
                                                    , WorkingServices.GetParaFromOject("@TenViKhuanMay",itemKS.TenViKhuanMay)
                                                    , WorkingServices.GetParaFromOject("@idMayXn",itemKS.idMayXn)
                                                    , WorkingServices.GetParaFromOject("@Flag",coKetQua)
                                                    , WorkingServices.GetParaFromOject("@LanXetNghiem",1)
                                                    , WorkingServices.GetParaFromOject("@MaBoKhangSinh", string.Empty)
                                                    , WorkingServices.GetParaFromOject("@SiteINF_WHONET",itemKS.SiteInfection)
                                           };
                                        count = (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insXetNghiem_KhangSinhDo", sqlPara);

                                        if (count > -1)
                                        {
                                            //Cập nhật => đã cập nhật
                                            sbCapNhaTrangThai.Append(string.IsNullOrEmpty(sbCapNhaTrangThai.ToString()) ? string.Empty : ";\n");
                                            sbCapNhaTrangThai.Append(Update_KQMay_TrangThai(itemKS.ResultID.ToString(), TestingResultStatusConstant.DaCapNhatKetQua));
                                        }
                                        iCount += count;
                                    }
                                }
                                else
                                {
                                    //Cập nhật => đã cập nhật
                                    sbCapNhaTrangThai.Append(string.IsNullOrEmpty(sbCapNhaTrangThai.ToString()) ? string.Empty : ";\n");
                                    sbCapNhaTrangThai.Append(Update_KQMay_TrangThai(itemKS.ResultID.ToString(), TestingResultStatusConstant.ChuaNhapMa));
                                }
                            }
                        }
                    }
                    //insert cơ chế kháng kháng sinh
                    if (item.lstCoCheKhang != null)
                    {
                        if (item.lstCoCheKhang.Count > 0)
                        {
                            int trangThai = -1;
                            var currentmaTiepnhan = string.Empty;
                            var currentMaYeuCau = string.Empty;
                            foreach (var itemKhang in item.lstCoCheKhang)
                            {
                                if (!string.IsNullOrEmpty(itemKhang.MaViKhuan))
                                {
                                    if (currentmaTiepnhan != itemKhang.MaTiepNhan || currentMaYeuCau != itemKhang.MaYeuCau)
                                    {
                                        trangThai = TrangThaiViSinh(itemKhang.MaTiepNhan, itemKhang.MaYeuCau);
                                        currentmaTiepnhan = itemKhang.MaTiepNhan;
                                        currentMaYeuCau = itemKhang.MaYeuCau;
                                    }
                                    if (trangThai == 0)
                                    {
                                        //Cập nhật => đã in
                                        sbCapNhaTrangThai.Append(string.IsNullOrEmpty(sbCapNhaTrangThai.ToString()) ? string.Empty : ";\n");
                                        sbCapNhaTrangThai.Append(Update_KQMay_TrangThai(itemKhang.ResultID.ToString(), TestingResultStatusConstant.ChuaNhapChiDinh));
                                    }
                                    else if (trangThai == 2)
                                    {
                                        //Cập nhật => đã in
                                        sbCapNhaTrangThai.Append(string.IsNullOrEmpty(sbCapNhaTrangThai.ToString()) ? string.Empty : ";\n");
                                        sbCapNhaTrangThai.Append(Update_KQMay_TrangThai(itemKhang.ResultID.ToString(), TestingResultStatusConstant.DaInKetQua));
                                    }
                                    else if (trangThai == 3)
                                    {
                                        //Cập nhật => đã duyệt
                                        sbCapNhaTrangThai.Append(string.IsNullOrEmpty(sbCapNhaTrangThai.ToString()) ? string.Empty : ";\n");
                                        sbCapNhaTrangThai.Append(Update_KQMay_TrangThai(itemKhang.ResultID.ToString(), TestingResultStatusConstant.DaXacNhanKetQua));
                                    }
                                    else if (trangThai == 1)
                                    {
                                        var para = new SqlParameter[]
                                     {
                                        WorkingServices.GetParaFromOject("@MaTiepNhan",itemKhang.MaTiepNhan)
                                        , WorkingServices.GetParaFromOject("@MaYeuCau",itemKhang.MaYeuCau)
                                        , WorkingServices.GetParaFromOject("@MaPhanLoai",itemKhang.MaViKhuan)
                                        , WorkingServices.GetParaFromOject("@Makhangkhangsinh",itemKhang.CoCheKhang)
                                        , WorkingServices.GetParaFromOject("@Ketqua",itemKhang.KetquaCoCheKhang)
                                        , WorkingServices.GetParaFromOject("@Ketquachu",(itemKhang.KetquaCoCheKhang.Contains("+")
                                        || itemKhang.KetquaCoCheKhang.ToLower().Contains("pos") ? "Positive" : (itemKhang.KetquaCoCheKhang.Contains("-")
                                        || itemKhang.KetquaCoCheKhang.ToLower().Contains("neg") ? "Negative" : "")) )
                                        ,WorkingServices.GetParaFromOject("@Nguoinhap",itemKhang.NguoiNhap)

                                     };
                                        var count = (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insXetNghiem_KhangKhangSinh", para);
                                        if (count > -1)
                                        {
                                            //Cập nhật => đã cập nhật
                                            sbCapNhaTrangThai.Append(string.IsNullOrEmpty(sbCapNhaTrangThai.ToString()) ? string.Empty : ";\n");
                                            sbCapNhaTrangThai.Append(Update_KQMay_TrangThai(itemKhang.ResultID.ToString(), TestingResultStatusConstant.DaCapNhatKetQua));
                                        }
                                        iCount += count;
                                    }
                                }
                                else
                                {
                                    //Cập nhật => đã cập nhật
                                    sbCapNhaTrangThai.Append(string.IsNullOrEmpty(sbCapNhaTrangThai.ToString()) ? string.Empty : ";\n");
                                    sbCapNhaTrangThai.Append(Update_KQMay_TrangThai(itemKhang.ResultID.ToString(), TestingResultStatusConstant.ChuaNhapMa));
                                }
                            }
                        }
                    }
                }
            }
            return iCount;
        }
        private int TrangThaiViSinh(string matiepnhan, string mayeucau)
        {
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selViSinh_TrangThaiChiDinh", false, new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@MaTiepNhan", matiepnhan)
                ,WorkingServices.GetParaFromOject("@MaYeuCau", mayeucau)
            });

            if (data != null)
            {
                var dt = data.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (bool.Parse(dt.Rows[0]["DaIn"].ToString()))
                        return 2;
                    else if (bool.Parse(dt.Rows[0]["DaXacNhan"].ToString()))
                        return 3;
                    else
                        return 1;
                }
                else
                    return 0;
            }
            else
                return -1;
        }
        #endregion
        #region Xử lý kết quả SHPT Gen
        private int Check_Update_AnalyzerResult_Gen(DataRow dr, int trangThai, DataTable dtconvertResult
            , string clsXetNghiemDinhDangKetqua, string userId, string khuVucThucHien
            , List<TrangThaiKetQua> lstTrangThaiXetNghiem, List<DM_XETNGHIEM_CSBT> lstCauHinh_CSBT
            , BENHNHAN_TIEPNHAN objBenhNhan, BENHNHAN_MAUSANGLOC objSangLocSS
            , EnumKieuLayKetQuaMay kieuLay
            , ref List<string> finishList
            , ref StringBuilder sbCapNhaTrangThai, bool toolAuto, string maxnChaSHPT ="")
        {
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            var maTiepNhan = ConfigurationDetail.Get_MaTiepNhan(StringConverter.ToString(dr["SID"]),
                      DateTimeConverter.ToDateTime(dr["NgayXN"]));
            var seq = StringConverter.ToString(dr["Seq"]);
            var resultType = StringConverter.ToString(dr["resulttype"]);
            int returnVal = 0;
            if (!resultType.Trim().Equals("Q", StringComparison.OrdinalIgnoreCase))
            {
                var id = StringConverter.ToString(dr["ID"]);
                var maXn = StringConverter.ToString(dr["MaXN"]).Trim();
                var maxnCheck = maXn.Replace("%", "Per");
                var layDinhTinh = bool.Parse(dr["LayDinhTinh"].ToString() == "0" ? false.ToString() : dr["LayDinhTinh"].ToString());
                var layDinhLuong = bool.Parse(dr["LayDinhLuong"].ToString() == "0" ? false.ToString() : dr["LayDinhLuong"].ToString());

                var ketQuaGoc = (layDinhLuong ? StringConverter.ToString(dr["KetQua"]) : string.Empty);
                var dinhtinh = (layDinhTinh ? StringConverter.ToString(dr["dinhtinh"]) : string.Empty);

                var canTren = string.Empty;
                var canDuoi = string.Empty;
                var dieuKienBatThuong = string.Empty;
                var csBinhThuong = string.Empty;
                var dvTinh = string.Empty;

                var canTrenCanhBao = string.Empty;
                var canDuoiCanhBao = string.Empty;
                var gioiHanCanhBao = string.Empty;
                var dieuKienCanhBaoDinhTinh = string.Empty;


                var maXnMay = StringConverter.ToString(dr["MaMay"]);
                var idMay = StringConverter.ToString(dr["IDMay"]);

                var statusId = NumberConverter.ToInt(dr["status_id"]);
                var chothem = bool.Parse(dr["chothem"].ToString() == "0" ? false.ToString() : dr["chothem"].ToString());
                var trangthaiCheck = StringConverter.ToString(dr["trangthai"]);
                var xnChinh = StringConverter.ToString(dr["MasterTest"]);
                var lamTron = "0";
                var modulename = StringConverter.ToString(dr["modules"]);
                var layCo = bool.Parse(string.IsNullOrEmpty(dr["GetFlag"].ToString()) ? false.ToString() : dr["GetFlag"].ToString());
                var flag = (layCo ? StringConverter.ToString(dr["FlagDescription"]) : string.Empty);
                var chapNhanKieuLay = false;
                if (kieuLay == EnumKieuLayKetQuaMay.TatCa)
                    chapNhanKieuLay = true;
                else if (kieuLay == EnumKieuLayKetQuaMay.ChiTuMayThongThuong)
                    chapNhanKieuLay = statusId.Equals(0);
                else if (kieuLay == EnumKieuLayKetQuaMay.ChiTuPhanMemTrungGian)
                    chapNhanKieuLay = statusId.Equals(2);
                var isHinhAnh = bool.Parse(dr["isimage"].ToString() == "0" ? false.ToString() : dr["isimage"].ToString());
                var chuoiHinhAnh = StringConverter.ToString(dr["imagestring"]);

                var quyTrinhMau = StringConverter.ToString(dr["QuyTrinhMau"]);
                var quyTrinhKSD = StringConverter.ToString(dr["QuyTrinhKSD"]);
                var maCaptren = StringConverter.ToString(dr["dekhangkhangsinh"]);
                var loaiXetNghiem = NumberConverter.ToInt(dr["LoaiXetNghiem"]);
                var objPatient = informationService.Get_Info_BenhNhan_TiepNhan(maTiepNhan, new string[] { });

                var objtrangThaiHientai = new ThongTinHienTaiCuaXetNghiem()
                {
                    MaTiepNhan = maTiepNhan,
                    MaXn = maXn,
                    IDMay = idMay,
                    ModuleName = modulename,
                    ToolAuto = toolAuto
                };

                if (string.IsNullOrEmpty(maXn))
                {
                    //Cập nhật => chưa map mã máy xn
                    return Check_UpdateTrangThai(id, TestingResultStatusConstant.ChuaNhapMa, trangthaiCheck, ref sbCapNhaTrangThai);
                }
                else if ((!string.IsNullOrEmpty(ketQuaGoc) || (!string.IsNullOrEmpty(dinhtinh))) && chapNhanKieuLay
                     && (trangthaiCheck.Equals(TestingResultStatusConstant.ChapNhan, StringComparison.OrdinalIgnoreCase)
                     || trangthaiCheck.Equals(TestingResultStatusConstant.ChuaNhapChiDinh, StringComparison.OrdinalIgnoreCase)
                     || trangthaiCheck.Equals(TestingResultStatusConstant.DaCapNhatKetQua, StringComparison.OrdinalIgnoreCase)
                     || trangthaiCheck.Equals(TestingResultStatusConstant.ChuaNhapThongTin, StringComparison.OrdinalIgnoreCase)))
                {
                    var posneg = string.Empty;
                    if (finishList.Contains(maxnCheck))
                    {
                        trangThai = 4;
                    }
                    else
                    {
                        LayGiaTriSoSanh_KiemTraTrangThaiXetNghiem(lstTrangThaiXetNghiem, lstCauHinh_CSBT, objBenhNhan, objSangLocSS, objtrangThaiHientai);

                    }
                    //Kiểm tra giá trị trả về sau khi lấy trạng thái
                    switch (objtrangThaiHientai.TrangThai)
                    {
                        case 0:
                            //Cập nhật => chưa nhập thong tin
                            returnVal = Check_UpdateTrangThai(id, TestingResultStatusConstant.ChuaNhapThongTin, trangthaiCheck, ref sbCapNhaTrangThai);
                            break;
                        case 1:
                            //Cập nhật => đã in
                            returnVal = Check_UpdateTrangThai(id, TestingResultStatusConstant.DaInKetQua, trangthaiCheck, ref sbCapNhaTrangThai);
                            break;
                        case 2:
                            if (chothem)
                            {
                                if (!string.IsNullOrEmpty(maCaptren))
                                {
                                    var datamapping = _analyzerConfigRepository.Data_h_bangmamayxn(int.Parse(idMay), maCaptren);
                                    if (datamapping != null)
                                    {
                                        if (datamapping.Rows.Count > 0)
                                        {
                                            maCaptren = datamapping.Rows[0]["Maxn"].ToString();
                                            foreach (DataRow dataRow in datamapping.Rows)
                                            {
                                                xnChinh += (string.IsNullOrEmpty(xnChinh) ? "" : "|");
                                                xnChinh += dataRow["Maxn"].ToString();
                                            }
                                        }
                                    }
                                }
                                var maXnCha = string.Empty;
                                if (Insert_ChiDinhChoThem_Gen(maTiepNhan, xnChinh, maXn, userId, ref maXnCha, objPatient) > 0)
                                {
                                    lstTrangThaiXetNghiem = ListTrangThaiKetQuaCLSXetNghiem(maTiepNhan);
                                    returnVal = Check_Update_AnalyzerResult_Gen(dr, trangThai, dtconvertResult, clsXetNghiemDinhDangKetqua, userId, khuVucThucHien
                                                    , lstTrangThaiXetNghiem, lstCauHinh_CSBT, objBenhNhan, objSangLocSS, kieuLay, ref finishList
                                                    , ref sbCapNhaTrangThai, toolAuto, maXnCha);
                                }
                                else
                                    returnVal = Check_UpdateTrangThai(id, TestingResultStatusConstant.ChuaNhapChiDinh, trangthaiCheck, ref sbCapNhaTrangThai);
                                break;
                            }
                            else
                            {
                                //Cập nhật => chua nhap chi dinh
                                returnVal = Check_UpdateTrangThai(id, TestingResultStatusConstant.ChuaNhapChiDinh, trangthaiCheck, ref sbCapNhaTrangThai);
                                break;
                            }
                        case 3:
                            //Cập nhật => kết quả đã xác nhận
                            returnVal = Check_UpdateTrangThai(id, TestingResultStatusConstant.DaXacNhanKetQua, trangthaiCheck, ref sbCapNhaTrangThai);
                            break;
                        case 4:
                            //Cập nhật => đã có kết quả
                            returnVal = Check_UpdateTrangThai(id, TestingResultStatusConstant.DaCoKetQua, trangthaiCheck, ref sbCapNhaTrangThai);
                            break;
                        default:
                            posneg = string.Empty;
                            string dinhDangBienDich = string.Empty;
                            var ketQuaSauBienDich = Check_ConvertInstrumentresult(dtconvertResult, idMay, maXnMay,
                                 ketQuaGoc, ref posneg);

                            var ketQuaDinhtinhSauBienDich = Check_ConvertInstrumentresult(dtconvertResult, idMay, maXnMay,
                                dinhtinh, ref posneg);

                            var cogen = 1;
                            if (!string.IsNullOrEmpty(ketQuaSauBienDich))
                                cogen = LabResultService.SetColor(ketQuaSauBienDich, canTren, canDuoi, dieuKienBatThuong);
                            else
                                cogen = LabResultService.SetColor(ketQuaDinhtinhSauBienDich, canTren, canDuoi, dieuKienBatThuong);

                            if (string.IsNullOrEmpty(ketQuaDinhtinhSauBienDich) && !WorkingServices.IsNumeric(ketQuaSauBienDich))
                            {
                                ketQuaDinhtinhSauBienDich = ketQuaSauBienDich;
                                ketQuaSauBienDich = String.Empty;
                            }
                            InsertUpdateKQ_GEN(maTiepNhan, maxnChaSHPT, maXn, ketQuaSauBienDich, ketQuaDinhtinhSauBienDich, userId, cogen);

                            //Cập nhật => đã cập nhật
                            sbCapNhaTrangThai.Append(string.IsNullOrEmpty(sbCapNhaTrangThai.ToString()) ? string.Empty : ";\n");
                            sbCapNhaTrangThai.Append(Update_KQMay_TrangThai(id, TestingResultStatusConstant.DaCapNhatKetQua));
                            finishList.Add(maxnCheck);
                            returnVal = 1;
                            break;
                    }
                }
                else if (string.IsNullOrEmpty(ketQuaGoc) && string.IsNullOrEmpty(dinhtinh))
                {
                    //Cập nhật => chưa map mã máy xn
                    return Check_UpdateTrangThai(id, TestingResultStatusConstant.XemLai, trangthaiCheck, ref sbCapNhaTrangThai);
                }
            }
            return returnVal;
        }
        public int Insert_ChiDinhChoThem_Gen(string matiepnhan
          , string maxnChinh, string magen
          , string userAction, ref string maXnChaSHPT,BENHNHAN_TIEPNHAN objPatient)
        {
            if (!string.IsNullOrEmpty(magen) && !string.IsNullOrEmpty(maxnChinh))
            {
                string maTiepNhan = matiepnhan;
              
                string[] xnSplit = maxnChinh.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string xn in xnSplit)
                {
                    //Xét nghiệm chính xác định = index 0
                    //ký tự định vị "->"
                    var splXNChinh = xn.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                    if (_xetnghiem.CheckExistsTest(matiepnhan, splXNChinh[0].Trim()))
                    {
                        maXnChaSHPT = splXNChinh[0];
                        return InsertUpdateKQ_GEN(matiepnhan, splXNChinh[0], magen, string.Empty, string.Empty, userAction, 0);
                    }
                }
            }
            return 0;
        }
        public int InsertUpdateKQ_GEN(string matiepnhan, string maxnChinh, string magen, string ketquaDinhLuong, string ketquaDinhTinh, string userAction, int flag)
        {
            var objChiDinh = new KETQUA_CLS_XETNGHIEM_SHPT_GEN();
            objChiDinh.Matiepnhan = matiepnhan;
            objChiDinh.Maxn = maxnChinh;
            objChiDinh.Magen = magen;
            objChiDinh.Ketquadinhluong = ketquaDinhLuong;
            objChiDinh.Ketquadinhtinh = ketquaDinhTinh;
            objChiDinh.Nguoinhap = userAction;
            objChiDinh.Nguoisua = userAction;
            return _xetnghiem.Insert_Update_SHPT_Gen(objChiDinh);
        }
        /// <summary>
        /// Lay chi cac gia tri de so sanh sánh cận - kiển tra trạng thái
        /// </summary>
        /// <param name="maTiepNhan">Mã tiếp nhận</param>
        /// <param name="maXn">Mã xét nghiệm</param>
        /// <param name="canTren">Ngưỡng trên</param>
        /// <param name="canDuoi">Ngưỡng dưới</param>
        /// <param name="trangThai">0: Chưa chỉ định - 1: Đã in - 2: Chưa nhập chỉ định -  3: XN đã valid - 4: XN Đã có KQ - 9: Chấp nhận</param>
        /// <param name="dieuKienBatThuong"></param>
        private void LayGiaTriSoSanh_KiemTraTrangThaiGen(string maTiepNhan, string maXn, ref string canTren,
            ref string canDuoi, ref int trangThai, ref string dieuKienBatThuong, ref string donViTinh
            , ref string lamTron, ref string CSBinhThuong
            , DataTable dataCurrentResultStatus, string idMay, string moduleId, bool toolAuto
            , ref string canTrenCanhBao, ref string canDuoiCanhBao, ref string gioiHanCanhBao
            , ref string dieuKienCanhBaoDinhTinh)
        {
            var dt = new DataTable();
            var dtTemp = new DataTable();
            if (dataCurrentResultStatus == null)
            {
                dtTemp = Data_TrangThaiKetQuaXN_Gen(maTiepNhan, maXn, toolAuto);
            }
            else
                dtTemp = dataCurrentResultStatus.Copy();

            dt = Data_LayThongTinXN(dtTemp, idMay, moduleId, maXn);

            canTren = string.Empty;
            canDuoi = string.Empty;

            if (dt.Rows.Count <= 0)
            {
                //nếu dữ liệu tìm theo test không có thì check tìm mã tiếp nhan ko tồn tại thì ko có nhận bn ngược chỉ định chưa có
                if (WorkingServices.SearchResult_OnDatatable_NoneSort(dtTemp, string.Format("MaTiepNhan = '{0}'", maTiepNhan)).Rows.Count > 0)
                    trangThai = 2; //chưa nhập chỉ định
                else
                    trangThai = 0;//chưa nhập thông tin sid
            }
            else
            {
                lamTron = dt.Rows[0]["lamtron"].ToString().Trim();
                //Bỏ kiểm tra đã in vì 108 kiểm soát theo bộ phận
                //if (bool.Parse(dt.Rows[0]["DaInKQXN"].ToString()))
                //{
                //    trangThai = 1;
                //}
                //else 
                if (bool.Parse(dt.Rows[0]["XacNhanKQ"].ToString()))
                {
                    trangThai = 3;
                }
                else if (!string.IsNullOrEmpty(dt.Rows[0]["KetQua"].ToString()) && !string.IsNullOrEmpty(dt.Rows[0]["ThoiGianNhapKQ"].ToString()))
                {
                    trangThai = 4;
                }
                else
                {
                    trangThai = 9;
                    dieuKienBatThuong = dt.Rows[0]["DKBatThuong"].ToString().Trim();
                    canTren = dt.Rows[0]["NguongTren"].ToString().Trim();
                    canDuoi = dt.Rows[0]["NguongDuoi"].ToString().Trim();
                    CSBinhThuong = dt.Rows[0]["csbt"].ToString().Trim();
                    donViTinh = dt.Rows[0]["DonVi"].ToString().Trim();

                    dieuKienCanhBaoDinhTinh = dt.Rows[0]["DinhTinhCanhBao"].ToString().Trim();
                    canTrenCanhBao = dt.Rows[0]["CanTrenCanhBao"].ToString().Trim();
                    canDuoiCanhBao = dt.Rows[0]["CanDuoiCanhBao"].ToString().Trim();
                    gioiHanCanhBao = dt.Rows[0]["GioiHanCanhBao"].ToString().Trim();
                }
            }
        }
        private DataTable Data_TrangThaiKetQuaXN_Gen(string maTiepNhan, string maXn, bool toolAuto)
        {
            var sqlPara = new SqlParameter[]
           {
                new SqlParameter("@maTiepNhan", maTiepNhan)
                , new SqlParameter("@maXn", maXn)
           };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure
             , "selTrangThaiXetNghiem"
             , !toolAuto
             , sqlPara);
            if (ds != null)
            {
                var data = ds.Tables[0];
                foreach (DataColumn dtc in data.Columns)
                {
                    dtc.ColumnName = dtc.ColumnName.ToLower();
                }

                return data;
            }
            else
                return null;
        }
        #endregion
        private DataTable DataTrangThai_ListMaTiepNhan(DataTable dataSID, int tuSo, ref int denSo, bool toolAuto)
        {
            DataTable dataTrangThaiAll = new DataTable();
            var maTiepNhanList = string.Empty;

            int count = -1;
            var maTiepNhan = string.Empty;
            for (int i = tuSo; i < dataSID.Rows.Count; i++)
            {
                count++;
                if (count < limitListMaTiepNhan)
                {
                    denSo = i;
                    maTiepNhan = ConfigurationDetail.Get_MaTiepNhan(StringConverter.ToString(dataSID.Rows[i]["SID"]),
                        DateTimeConverter.ToDateTime(dataSID.Rows[i]["NgayXN"]));
                    maTiepNhanList += (string.IsNullOrEmpty(maTiepNhanList) ? "" : ",") + maTiepNhan;
                }
                else
                    break;
            }
            if (!string.IsNullOrEmpty(maTiepNhanList))
                dataTrangThaiAll = Data_TrangThaiKetQuaXN(maTiepNhanList, string.Empty, toolAuto);

            return dataTrangThaiAll;
        }
        public void UpdateCLSResultFromDatatable(DataTable dtAnalyzerResult, DataTable dtconvertResult
            , ProgressBar probar, AutoResetEvent LockUpdateAuto, ref int iNumAuto
            , string clsXetNghiemDinhDangKetqua, string userId, string khuVucThucHien
            , EnumKieuLayKetQuaMay kieuLay, bool toolAuto, bool deKetQuaChuaDuyet, bool getLastRuntime, bool tuXacNhan, bool khongXacNhanKQbatThuong)
        {
            UpdateCLSResultFromDataView(dtAnalyzerResult.DefaultView, dtconvertResult
            , probar, LockUpdateAuto, ref iNumAuto
            , clsXetNghiemDinhDangKetqua, userId, khuVucThucHien, kieuLay, toolAuto, deKetQuaChuaDuyet, getLastRuntime, tuXacNhan, khongXacNhanKQbatThuong);
        }
        public void UpdateCLSResultFromDataView(DataView analyzerResult, DataTable dtconvertResult
            , ProgressBar probar, AutoResetEvent LockUpdateManual, ref int iNumManual
            , string clsXetNghiemDinhDangKetqua, string userId, string khuVucThucHien
            , EnumKieuLayKetQuaMay kieuLay, bool toolAuto, bool deKetQuaChuaDuyet, bool getLastRuntime, bool tuXacNhan, bool khongXacNhanKQbatThuong)
        {
            if (analyzerResult.Count <= 0) return;

            //Xử lý các kết quả thường qui
            var dataNormalResult = WorkingServices.SearchResult_OnDatatable(analyzerResult.ToTable(), "idPhanLoaiMay in (0,1)");
            probar.Invoke(new EventHandler(delegate
            {
                probar.Maximum = analyzerResult.Count;
                probar.Value = 0;
                probar.Visible = true;
            }));

            if (dataNormalResult.Rows.Count > 0)
            {
                var lstDanhMucCSBT = DataCauHinh_CSBT();
                var trangThai = -1;
                var dtSid = dataNormalResult.DefaultView.ToTable(true, new string[] { "sid", "NgayXN" });
                iNumManual = 0;
                StringBuilder sbUpdateTrangThai = new StringBuilder();
                if (LockUpdateManual != null)
                    LockUpdateManual.WaitOne();
                //if (toolAuto)
                //{
                ////doc danh sach ket qua dang cho upload trong bang ketqua_cls_xetnghiem
                //var maxConcurrency = 2;
                ////Dùng thread để upload Test nhanh hơn
                //using (SemaphoreSlim concurrencySemaphore = new SemaphoreSlim(maxConcurrency))
                //{
                //var tasks = new List<Task>();
                //concurrencySemaphore.Wait();
                foreach (DataRow dr2 in dtSid.Rows)
                {
                    iNumManual++;
                    var maTiepNhan = ConfigurationDetail.Get_MaTiepNhan(StringConverter.ToString(dr2["SID"]),
                       DateTimeConverter.ToDateTime(dr2["NgayXN"]));
                    var dataResultWithSid = WorkingServices.SearchResult_OnDatatable_NoneSort(analyzerResult.ToTable(), string.Format("SID = '{0}'", dr2["SID"].ToString()));
                    //var t = Task.Factory.StartNew(delegate
                    //{
                    UpdateKetQuaMauTheoSID(maTiepNhan
                                , dataResultWithSid, dtconvertResult
                                , ref sbUpdateTrangThai, lstDanhMucCSBT
                                , deKetQuaChuaDuyet, getLastRuntime
                                , null, null
                                , clsXetNghiemDinhDangKetqua, userId, khuVucThucHien
                                , kieuLay, toolAuto, trangThai, tuXacNhan, khongXacNhanKQbatThuong);
                    //});
                    //tasks.Add(t);
                    probar.Invoke(new EventHandler(delegate
                    {
                        if (probar.Value < probar.Maximum)
                            probar.Value++;
                    }));
                }
                // Task.WaitAll(tasks.ToArray());
                // }
                //}
                //else
                //{
                //    foreach (DataRow dr2 in dtSid.Rows)

                //    {
                //        sbUpdateTrangThai = new StringBuilder();

                //        var dataResultWithSid = WorkingServices.SearchResult_OnDatatable_NoneSort(analyzerResult.ToTable(), string.Format("SID = '{0}'", dr2["SID"].ToString()));
                //        var actionCount = 0;
                //        if (dataResultWithSid.Rows.Count > 0)
                //        {
                //            if (deKetQuaChuaDuyet)
                //                dataResultWithSid.DefaultView.Sort = "MaXN ASC, thoigianluu ASC";
                //            else if (getLastRuntime)
                //            {
                //                dataResultWithSid.DefaultView.Sort = "MaXN ASC, thoigianluu DESC";
                //            }
                //            else
                //                dataResultWithSid.DefaultView.Sort = "MaXN ASC, thoigianluu ASC";

                //            dataResultWithSid = dataResultWithSid.DefaultView.ToTable();
                //            var maTiepNhan = ConfigurationDetail.Get_MaTiepNhan(StringConverter.ToString(dr2["SID"]),
                //                DateTimeConverter.ToDateTime(dr2["NgayXN"]));

                //            var finishList = new List<string>();
                //            var lstChiDinhXetNghiem_KetQuaMay = ListTrangThaiKetQuaCLSXetNghiem(maTiepNhan);
                //            var objPatient = informationService.Get_Info_BenhNhan_TiepNhan(maTiepNhan, new string[] { });
                //            var objPatientSS = informationService.Get_ThongTinSLSoSinh(maTiepNhan);
                //            foreach (DataRow dr in dataResultWithSid.Rows)
                //            {
                //                iNumManual++;
                //                probar.Invoke(new EventHandler(delegate
                //                {
                //                    if (probar.Value < probar.Maximum)
                //                        probar.Value++;
                //                }));
                //                actionCount += Check_Update_AnalyzerResult(dr, trangThai, dtconvertResult, clsXetNghiemDinhDangKetqua, userId, khuVucThucHien
                //                    , lstChiDinhXetNghiem_KetQuaMay, lstDanhMucCSBT, objPatient, objPatientSS, kieuLay, ref finishList
                //                    , ref sbUpdateTrangThai, toolAuto, deKetQuaChuaDuyet, tuXacNhan, khongXacNhanKQbatThuong);
                //                if (LockUpdateManual != null)
                //                    LockUpdateManual.WaitOne();
                //            }
                //        }
                //        var sbCapNhaTrangThaiaction = sbUpdateTrangThai.ToString();
                //        if (actionCount > 0)
                //        {
                //            probar.Invoke(new EventHandler(delegate
                //            {
                //                var matiepnhan = ConfigurationDetail.Get_MaTiepNhan(dr2["SID"].ToString(),
                //               DateTime.Parse(dr2["NgayXN"].ToString()));
                //                if (!string.IsNullOrEmpty(sbCapNhaTrangThaiaction))
                //                    DataProvider.ExecuteQuery(sbCapNhaTrangThaiaction);
                //                _xetnghiem.CapNhat_ThongTinMayXn_XnChinh(matiepnhan);
                //                _xetnghiem.CapNhat_DuKQ_XN(matiepnhan);

                //            }));
                //        }
                //        if (LockUpdateManual != null)
                //            LockUpdateManual.WaitOne();
                //    }
                //}
            }
            //Xử lý các kết quả vi sinh
            var dataBioticResult = WorkingServices.SearchResult_OnDatatable(analyzerResult.ToTable(), "idPhanLoaiMay in (2)");
            if (dataBioticResult.Rows.Count > 0)
            {
                Get_KetQuaviSinh(dataBioticResult, toolAuto, probar, LockUpdateManual, ref iNumManual);
            }
            probar.Invoke(new EventHandler(delegate
            {
                probar.Visible = false;
            }));
        }
        private void UpdateKetQuaMauTheoSID(string maTiepNhan
            , DataTable dataResultWithSid, DataTable dtconvertResult
            , ref StringBuilder sbUpdateTrangThai, List<DM_XETNGHIEM_CSBT> lstDanhMucCSBT
            , bool deKetQuaChuaDuyet, bool getLastRuntime
            , ProgressBar probar, AutoResetEvent LockUpdateManual
            , string clsXetNghiemDinhDangKetqua, string userId, string khuVucThucHien
            , EnumKieuLayKetQuaMay kieuLay, bool toolAuto, int trangThai, bool tuXacNhan, bool khongXacNhanKQbatThuong)
        {
            sbUpdateTrangThai = new StringBuilder();
            var actionCount = 0;
            if (dataResultWithSid.Rows.Count > 0)
            {
                if (deKetQuaChuaDuyet)
                    dataResultWithSid.DefaultView.Sort = "MaXN ASC, thoigianluu ASC";
                else if (getLastRuntime)
                {
                    dataResultWithSid.DefaultView.Sort = "MaXN ASC, thoigianluu DESC";
                }
                else
                    dataResultWithSid.DefaultView.Sort = "MaXN ASC, thoigianluu ASC";

                dataResultWithSid = dataResultWithSid.DefaultView.ToTable();
                var finishList = new List<string>();
                var lstChiDinhXetNghiem_KetQuaMay = ListTrangThaiKetQuaCLSXetNghiem(maTiepNhan);
                var objPatient = informationService.Get_Info_BenhNhan_TiepNhan(maTiepNhan, new string[] { });
                var objPatientSS = informationService.Get_ThongTinSLSoSinh(maTiepNhan);
                foreach (DataRow dr in dataResultWithSid.Rows)
                {
                    if (probar != null)
                    {
                        probar.Invoke(new EventHandler(delegate
                        {
                            if (probar.Value < probar.Maximum)
                                probar.Value++;
                        }));
                    }
                    actionCount += Check_Update_AnalyzerResult(dr, trangThai, dtconvertResult, clsXetNghiemDinhDangKetqua, userId, khuVucThucHien
                    , lstChiDinhXetNghiem_KetQuaMay, lstDanhMucCSBT, objPatient, objPatientSS, kieuLay, ref finishList, ref sbUpdateTrangThai
                    , toolAuto, deKetQuaChuaDuyet, tuXacNhan, khongXacNhanKQbatThuong);
                }
            }
            var sbCapNhaTrangThaiaction = sbUpdateTrangThai.ToString();
            if (actionCount > 0)
            {
                if (!string.IsNullOrEmpty(sbCapNhaTrangThaiaction))
                    DataProvider.ExecuteQuery(sbCapNhaTrangThaiaction);
                _xetnghiem.CapNhat_ThongTinMayXn_XnChinh(maTiepNhan);
                _xetnghiem.CapNhat_DuKQ_XN(maTiepNhan);
            }
        }
        // Cập nhật tiến độ qua progress bar
        private void SetProbarInvoke(ProgressBar proBar, bool setVisible = false, bool visbileValue = true)
        {
            if (proBar.InvokeRequired)
            {
                proBar.Invoke(new MethodInvoker(delegate ()
                {
                    if (setVisible)
                    {
                        proBar.Visible = visbileValue;
                    }
                    else
                    {
                        if (proBar.Value < proBar.Maximum)
                            proBar.Value++;
                    }
                }));
            }
            else
            {
                if (setVisible)
                {
                    proBar.Visible = visbileValue;
                }
                else if (proBar.Value < proBar.Maximum)
                    proBar.Value++;
            }
        }
        public bool Insert_ChiDinhChoThemThuongQuy(string matiepnhan, string maxn, string xnChinh
            , string khuVucThucHien, string macapTren, BENHNHAN_TIEPNHAN objPatient)
        {
            int iCount = 0;
            if (!string.IsNullOrEmpty(maxn) && (!string.IsNullOrEmpty(xnChinh) || !string.IsNullOrEmpty(macapTren)))
            {
                
                var objChiDinh = new XetNghiemInfo();
                objChiDinh.maxn = maxn;
                objChiDinh.xetnghiemProfile = false;
                objChiDinh.Dongia = -1;
                objChiDinh.Khuvucnhanid = string.IsNullOrEmpty(khuVucThucHien) ? "A" : khuVucThucHien;
                objChiDinh.Khuvucthuchienid = string.IsNullOrEmpty(khuVucThucHien) ? "A" : khuVucThucHien;
                objChiDinh.ChiDinhNhapTuKQMay = true;
                objChiDinh.MaCaptren = macapTren;
                if (string.IsNullOrEmpty(xnChinh))
                    xnChinh = macapTren;

                string[] xnSplit = xnChinh.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string xn in xnSplit)
                {
                    //Xét nghiệm chính xác định = index 0
                    //ký tự định vị "->"
                    var splXNChinh = xn.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                    if (_xetnghiem.CheckExistsTest(matiepnhan, splXNChinh[0].Trim()))
                    {
                        objChiDinh.MaCaptren = splXNChinh[0].Trim();
                        _xetnghiem.InsertTest(objPatient, objChiDinh);
                        iCount += _xetnghiem.UpdateHISInfoForAutoInsertTest(matiepnhan, objChiDinh.maxn, splXNChinh[0].Trim());
                        if (splXNChinh.Length == 2)
                        {
                            objChiDinh.maxn = splXNChinh[1].Trim();
                            _xetnghiem.InsertTest(objPatient, objChiDinh);
                            iCount += _xetnghiem.UpdateHISInfoForAutoInsertTest(matiepnhan, objChiDinh.maxn, splXNChinh[0].Trim());
                        }
                        return iCount > -1;
                    }
                }
                //else
                //    return _xetnghiem.InsertTest(objPatient, objChiDinh);
            }
            return false;
        }
        public int UpdateResendInfinity(int ID)
        {
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, string.Format("Update h_ketquamay set status_id = 0  where id = {0} and status_id=1", ID));
        }
        private DataTable Data_LayThongTinXN(DataTable dataTrangThai, string IdMay, string moduleId, string maXn)
        {
            if (string.IsNullOrEmpty(moduleId))
            {
                var dataFound = WorkingServices.SearchResult_OnDatatable_NoneSort(dataTrangThai, string.Format("IDMayXn = {0} and MaXN = '{1}'", IdMay, maXn));
                if (dataFound.Rows.Count > 0)
                    return dataFound;
                else
                    return WorkingServices.SearchResult_OnDatatable_NoneSort(dataTrangThai, string.Format("IDMayXn = 0 and MaXN = '{1}'", IdMay, maXn));
            }
            else
            {
                //search theo module trước => không có data thì search theo id máy
                var dataFound = WorkingServices.SearchResult_OnDatatable_NoneSort(dataTrangThai, string.Format("moduleid = '{0}' and MaXN = '{1}'", moduleId, maXn));
                if (dataFound.Rows.Count > 0)
                    return dataFound;
                else
                {
                    dataFound = WorkingServices.SearchResult_OnDatatable_NoneSort(dataTrangThai, string.Format("IDMayXn = {0} and MaXN = '{1}'", IdMay, maXn));
                    if (dataFound.Rows.Count > 0)
                        return dataFound;
                    else
                        return WorkingServices.SearchResult_OnDatatable_NoneSort(dataTrangThai, string.Format("IDMayXn = 0 and MaXN = '{1}'", IdMay, maXn));
                }
            }
        }
        private DataTable Data_TrangThaiKetQuaXN(string maTiepNhan, string maXn, bool toolAuto)
        {
            var sqlPara = new SqlParameter[]
           {
                new SqlParameter("@maTiepNhan", maTiepNhan)
                , new SqlParameter("@maXn", maXn)
           };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure
             , "selTrangThaiXetNghiem"
             , !toolAuto
             , sqlPara);
            if (ds != null)
            {
                var data = ds.Tables[0];
                foreach (DataColumn dtc in data.Columns)
                {
                    dtc.ColumnName = dtc.ColumnName.ToLower();
                }

                return data;
            }
            else
                return null;
        }
        public string Check_ConvertInstrumentresult(DataTable dtConvert, string mamay, string maxnmay, string ketQuaGoc, ref string posneg)
        {
            string ketquaBienDich = ketQuaGoc.Trim();

            if (string.IsNullOrEmpty(ketquaBienDich))
                return "";
            var tempFormatResult = "{S}";
            //Kiểm tra thực hiện phép tính
            DataTable dtTemp = new DataTable();
            DataRow[] drt;
            if (WorkingServices.IsNumeric(ketQuaGoc))
            {
                drt =
                    dtConvert.Select(
                        string.Format(
                            " PhepTinh is not null and GiaTriTinh is not null and PhepTinh is not null and LoaiBienDich = 3 and MaXNMay = '{0}' and IDMay = {1}",
                            maxnmay, mamay));
                if (drt.Length > 0)
                {
                    dtTemp = drt.CopyToDataTable();
                    if (dtTemp.Rows.Count > 0)
                    {
                        int round = int.Parse(dtTemp.Rows[0]["LamTron"].ToString());
                        string valueCal = dtTemp.Rows[0]["GiaTriTinh"].ToString();
                        string calChar = dtTemp.Rows[0]["PhepTinh"].ToString();
                        tempFormatResult = !string.IsNullOrEmpty(dtTemp.Rows[0]["DinhDang"].ToString()) ? dtTemp.Rows[0]["DinhDang"].ToString() : tempFormatResult;
                        if (!string.IsNullOrEmpty(calChar))
                        {
                            var rs = EvaluateExpression.EvalExpression("(" + ketQuaGoc + ") " + calChar + " (" + valueCal + ")");
                            ketQuaGoc = Math.Round(rs, round).ToString();
                        }
                    }
                    ketquaBienDich = ketQuaGoc;
                    //Ghép kết quả sau khi biên dịch
                    ketquaBienDich = tempFormatResult.Replace("{N}", ketQuaGoc).Replace("{S}", ketquaBienDich);
                }
            }
            //Kiểm tra convert các loại theo điều kiện cận ngoài khoảng
            drt =
                dtConvert.Select(
                    string.Format(
                        "((DieuKienCanDuoi is not null and GiaTriCanDuoi is not null) or (DieuKienCanTren is not null and GiaTriCanTren is not null)) and LayKhoangTrong = false and LoaiBienDich = 2  and MaXNMay = '{0}' and IDMay = {1}",
                            maxnmay, mamay,
                        maxnmay));
            if (drt.Length > 0)
            {
                dtTemp = drt.CopyToDataTable();
                if (dtTemp.Rows.Count > 0)
                {
                    var nullCanDuoi = string.IsNullOrEmpty(dtTemp.Rows[0]["DieuKienCanDuoi"].ToString());
                    var nullCanTren = string.IsNullOrEmpty(dtTemp.Rows[0]["DieuKienCanTren"].ToString());
                    double dieuKienCanDuoi = double.Parse(nullCanDuoi ? "-10000000000000000000" : dtTemp.Rows[0]["DieuKienCanDuoi"].ToString());
                    string giaTriCanDuoi = dtTemp.Rows[0]["GiaTriCanDuoi"].ToString();
                    double dieuKienCanTren = double.Parse(nullCanTren ? "10000000000000000000" : dtTemp.Rows[0]["DieuKienCanTren"].ToString());
                    string giaTriCanTren = dtTemp.Rows[0]["GiaTriCanTren"].ToString();
                    tempFormatResult = !string.IsNullOrEmpty(dtTemp.Rows[0]["DinhDang"].ToString()) ? dtTemp.Rows[0]["DinhDang"].ToString() : tempFormatResult;
                    if (WorkingServices.IsNumeric(ketQuaGoc))
                    {
                        double tempketQuaGoc = double.Parse(ketQuaGoc);
                        if (tempketQuaGoc < dieuKienCanDuoi)
                        {
                            posneg = giaTriCanDuoi;
                        }
                        else if (tempketQuaGoc > dieuKienCanTren)
                        {
                            posneg = giaTriCanTren;
                        }
                        else
                        {
                            posneg = ketQuaGoc.ToString();
                        }
                    }
                    else
                    {
                        ketQuaGoc = ketQuaGoc.Trim();

                        string leftChars = ketQuaGoc.Substring(0, 2);
                        string temResult = ketQuaGoc.Substring(2, ketQuaGoc.Length - 2);
                        //kiểm tra trường hợp 2 ký tự trước
                        if (leftChars.Equals("<="))
                        {
                            if (WorkingServices.IsNumeric(temResult))
                            {
                                if (double.Parse(temResult) <= dieuKienCanDuoi)
                                {
                                    posneg = giaTriCanDuoi;
                                }
                                else if (double.Parse(temResult) >= dieuKienCanTren)
                                {
                                    posneg = giaTriCanTren;
                                }
                                else
                                {
                                    posneg = string.Empty;
                                }
                            }
                            else
                            {
                                posneg = string.Empty;
                            }
                        }
                        else if (leftChars.Equals(">="))
                        {
                            if (WorkingServices.IsNumeric(temResult))
                            {
                                if (double.Parse(temResult) >= dieuKienCanTren)
                                {
                                    posneg = giaTriCanTren;
                                }
                                else if (double.Parse(temResult) <= dieuKienCanDuoi)
                                {
                                    posneg = giaTriCanDuoi;
                                }

                                else
                                {
                                    posneg = string.Empty;
                                }
                            }
                            else
                            {
                                posneg = string.Empty;
                            }
                        }
                        else
                        {
                            leftChars = ketQuaGoc.Substring(0, 1);
                            temResult = ketQuaGoc.Substring(1, ketQuaGoc.Length - 1);
                            if (leftChars.Equals("<"))
                            {
                                if (WorkingServices.IsNumeric(temResult))
                                {
                                    if (double.Parse(temResult) <= dieuKienCanDuoi)
                                    {
                                        posneg = giaTriCanDuoi;
                                    }
                                    else if (double.Parse(temResult) >= dieuKienCanTren)
                                    {
                                        posneg = giaTriCanTren;
                                    }
                                    else
                                    {
                                        posneg = string.Empty;
                                    }
                                }
                                else
                                {
                                    posneg = string.Empty;
                                }
                            }
                            else if (leftChars.Equals(">"))
                            {
                                if (WorkingServices.IsNumeric(temResult))
                                {
                                    if (double.Parse(temResult) >= dieuKienCanTren)
                                    {
                                        posneg = giaTriCanTren;
                                    }
                                    else if (double.Parse(temResult) <= dieuKienCanDuoi)
                                    {
                                        posneg = giaTriCanDuoi;
                                    }

                                    else
                                    {
                                        posneg = string.Empty;
                                    }
                                }
                                else
                                {
                                    posneg = string.Empty;
                                }
                            }
                            else
                            {
                                posneg = string.Empty;
                            }
                        }
                    }
                    //Ghép kết quả sau khi biên dịch
                    if (!string.IsNullOrEmpty(posneg))
                        ketquaBienDich = tempFormatResult.Replace("{N}", ketQuaGoc).Replace("{S}", posneg);
                    else
                        ketquaBienDich = ketQuaGoc;
                }
            }
            if (string.IsNullOrEmpty(posneg))
            {
                //Kiểm tra convert các loại theo điều kiện cận lấy giới hạn TRONG
                drt =
                    dtConvert.Select(
                        string.Format(
                            "(DieuKienCanDuoi is not null and DieuKienCanTren is not null and (GiaTriCanDuoi is not null or GiaTriCanTren is not null)) and LayKhoangTrong = true and LoaiBienDich = 2  and MaXNMay = '{0}' and IDMay = {1}",
                                maxnmay, mamay,
                            maxnmay));
                if (drt.Length > 0)
                {
                    dtTemp = drt.CopyToDataTable();
                    if (dtTemp.Rows.Count > 0)
                    {
                        bool nullCanDuoi = string.IsNullOrEmpty(dtTemp.Rows[0]["DieuKienCanDuoi"].ToString());
                        bool nullCantren = string.IsNullOrEmpty(dtTemp.Rows[0]["DieuKienCanTren"].ToString());

                        double dieuKienCanDuoi = double.Parse(string.IsNullOrEmpty(dtTemp.Rows[0]["DieuKienCanDuoi"].ToString()) ? "-10000000000000000000" : dtTemp.Rows[0]["DieuKienCanDuoi"].ToString());
                        string giaTriCanDuoi = dtTemp.Rows[0]["GiaTriCanDuoi"].ToString();
                        double dieuKienCanTren = double.Parse(string.IsNullOrEmpty(dtTemp.Rows[0]["DieuKienCanTren"].ToString()) ? "10000000000000000000" : dtTemp.Rows[0]["DieuKienCanTren"].ToString());
                        string giaTriCanTren = dtTemp.Rows[0]["GiaTriCanTren"].ToString();
                        tempFormatResult = !string.IsNullOrEmpty(dtTemp.Rows[0]["DinhDang"].ToString()) ? dtTemp.Rows[0]["DinhDang"].ToString() : tempFormatResult;
                        posneg = string.Empty;
                        if (!nullCanDuoi && !nullCantren)
                        {
                            if (WorkingServices.IsNumeric(ketQuaGoc))
                            {
                                double tempketQuaGoc = double.Parse(ketQuaGoc);
                                if (tempketQuaGoc >= dieuKienCanDuoi && tempketQuaGoc <= dieuKienCanTren)
                                {
                                    posneg = string.IsNullOrEmpty(giaTriCanDuoi) ? giaTriCanTren : giaTriCanDuoi;
                                }
                            }
                            else
                            {
                                ketQuaGoc = ketQuaGoc.Trim();
                                string leftChars = ketQuaGoc.Substring(0, 2);
                                string temResult = ketQuaGoc.Substring(2, ketQuaGoc.Length - 2);
                                //kiểm tra trường hợp 2 ký tự trước
                                if (leftChars.Equals("<=") || leftChars.Equals(">="))
                                {
                                    if (WorkingServices.IsNumeric(temResult))
                                    {
                                        if (double.Parse(temResult) >= dieuKienCanDuoi && double.Parse(temResult) <= dieuKienCanTren)
                                        {
                                            posneg = string.IsNullOrEmpty(giaTriCanDuoi) ? giaTriCanTren : giaTriCanDuoi;
                                        }
                                    }
                                }
                                else
                                {
                                    leftChars = ketQuaGoc.Substring(0, 1);
                                    temResult = ketQuaGoc.Substring(1, ketQuaGoc.Length - 1);
                                    if (leftChars.Equals("<") || leftChars.Equals(">"))
                                    {
                                        if (WorkingServices.IsNumeric(temResult))
                                        {
                                            if (double.Parse(temResult) >= dieuKienCanDuoi && double.Parse(temResult) <= dieuKienCanTren)
                                            {
                                                posneg = string.IsNullOrEmpty(giaTriCanDuoi) ? giaTriCanTren : giaTriCanDuoi;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //Ghép kết quả sau khi biên dịch
                        if (!string.IsNullOrEmpty(posneg))
                            ketquaBienDich = tempFormatResult.Replace("{N}", ketQuaGoc).Replace("{S}", posneg);
                        else
                            ketquaBienDich = ketQuaGoc;
                    }
                }
            }

            //Biên dich kết quả
            //Kiểm tra convert các loại theo điều kiện kết quả
            drt =
                dtConvert.Select(
                    string.Format(
                        " KQMay is not null and KQBienDich is not null and LoaiBienDich = 1 and MaXNMay = '{0}' and IDMay = {1}",
                            maxnmay, mamay));
            if (drt.Length == 0)
            {
                drt = dtConvert.Select(
                            string.Format(
                                " KQMay is not null and KQBienDich is not null and LoaiBienDich = 1 and IDMay = {0} and (MaXNMay is null or MaXNMay = '') ",
                                mamay));
            }

            if (drt.Length > 0)
            {
                dtTemp = drt.CopyToDataTable();

                if (dtTemp.Rows.Count > 0)
                {
                    foreach (DataRow r in dtTemp.Rows)
                    {
                        string kqSoSanh = r["KQMay"].ToString();
                        string kqBienDich = r["KQBienDich"].ToString();
                        bool soSanhTuyetDoi = bool.Parse(r["SoSanhTuyetDoi"].ToString());
                        tempFormatResult = !string.IsNullOrEmpty(dtTemp.Rows[0]["DinhDang"].ToString()) ? dtTemp.Rows[0]["DinhDang"].ToString() : tempFormatResult;
                        ketquaBienDich = Convert_Result(ketquaBienDich, kqSoSanh, kqBienDich, soSanhTuyetDoi);
                    }
                    //Ghép kết quả sau khi biên dịch
                    ketquaBienDich = tempFormatResult.Replace("{N}", ketQuaGoc).Replace("{S}", ketquaBienDich);
                }
            }

            return ketquaBienDich;
        }
        //làm tròn kết quả
        public string ConvertRoundResult(int idmay, string maxnmay, string ketqua, DataTable dtResultRound)
        {
            ketqua = ketqua.Trim();
            var ketQuaFinal = string.Empty;
            decimal dKetQua = 0;
            var minKetQua = -1000000000;
            var maxKetQua = 1000000000;
            decimal tuKetQua;
            decimal denKetQua;
            var kyTu = "";
            var iKetQua = 0;
            var dinhDang = "";
            var sLamTron = "";
            int iLamTron;

            if (string.IsNullOrEmpty(ketqua)) return ketqua;

            if (dtResultRound.Rows.Count <= 0) return ketqua;

            var ketQuaLength = ketqua.Length;

            if (WorkingServices.IsNumeric(ketqua))
            {
                if (ketqua.Contains("E"))
                {
                    dKetQua = (decimal)double.Parse(ketqua);
                }
                else
                    dKetQua = decimal.Parse(ketqua);
                iKetQua = (int)dKetQua;
            }
            else
            {
                //set về kết quả min trước để nếu qua các đều kiện không thay đồi thì đến định dạng không thỏa điều kiện
                iKetQua = minKetQua - 1;
                var temCheckValue = string.Empty;
                if (ketqua.Trim().Length > 1)
                    temCheckValue = ketqua.Substring(0, 2);
                else
                    temCheckValue = ketqua;

                if (temCheckValue.Equals("<=")
                    || temCheckValue.Equals(">="))
                {
                    kyTu = ketqua.Substring(0, 2);
                    if (WorkingServices.IsNumeric(ketqua.Substring(2, ketQuaLength - 2).Trim()))
                    {
                        if (ketqua.Contains("E"))
                        {
                            dKetQua = (decimal)double.Parse(ketqua.Substring(2, ketQuaLength - 2).Trim());
                        }
                        else
                            dKetQua = decimal.Parse(ketqua.Substring(2, ketQuaLength - 2).Trim());
                        iKetQua = (int)dKetQua;
                    }
                }
                else
                {
                    decimal dKetQuaMoi;
                    if (ketqua.Substring(0, 1).Equals("<"))
                    {
                        kyTu = ketqua.Substring(0, 1);
                        if (WorkingServices.IsNumeric(ketqua.Substring(1, ketQuaLength - 1).Trim()))
                        {
                            dKetQua = NumberConverter.To<decimal>(ketqua.Substring(1, ketQuaLength - 1).Trim());
                            if (dKetQua == 1)
                            {
                                if (ketqua.Contains("E"))
                                {
                                    dKetQuaMoi = (decimal)double.Parse(ketqua.Substring(1, ketQuaLength - 1));
                                }
                                else
                                    dKetQuaMoi = NumberConverter.To<decimal>(ketqua.Substring(1, ketQuaLength - 1)) - 1;
                                iKetQua = (int)dKetQuaMoi;
                            }
                            else
                            {
                                iKetQua = (int)dKetQua;
                            }
                        }
                    }
                    else if (ketqua.Substring(0, 1).Equals(">"))
                    {
                        kyTu = ketqua.Substring(0, 1);
                        if (WorkingServices.IsNumeric(ketqua.Substring(1, ketQuaLength - 1).Trim()))
                        {
                            if (ketqua.Contains("E"))
                            {
                                dKetQua = (decimal)double.Parse(ketqua.Substring(1, ketQuaLength - 1).Trim());
                                dKetQuaMoi = (decimal)double.Parse(ketqua.Substring(1, ketQuaLength - 1).Trim()) + 1;
                            }
                            else
                            {
                                dKetQua = NumberConverter.To<decimal>(ketqua.Substring(1, ketQuaLength - 1).Trim());
                                dKetQuaMoi = NumberConverter.To<decimal>(ketqua.Substring(1, ketQuaLength - 1).Trim()) + 1;
                            }
                            iKetQua = (int)dKetQuaMoi;
                        }
                    }
                }
            }

            var d = dtResultRound.AsEnumerable().Where(w =>
                NumberConverter.ToInt(w["idmay"]) == idmay && NumberConverter.ToInt(w["LoaiBienDich"]) == 4 &&
                !string.IsNullOrEmpty(StringConverter.ToString(w["MaXNMay"]))).Select(row => new
                {
                    lamtron = NumberConverter.ToInt(row["lamtron"]),
                    maxnmay = StringConverter.ToString(row["MaXNMay"]),
                    tuKetQua = string.IsNullOrEmpty(StringConverter.ToString(row["DieuKienCanDuoi"]))
                    ? minKetQua
                    : NumberConverter.To<decimal>(row["DieuKienCanDuoi"]),
                    denKetQua = string.IsNullOrEmpty(StringConverter.ToString(row["DieuKienCanTren"]))
                    ? maxKetQua
                    : NumberConverter.To<decimal>(row["DieuKienCanTren"])
                }).ToList();
            if (d.Count > 0)
            {
                sLamTron = "0";
                foreach (var t in d)
                {
                    iLamTron = t.lamtron;
                    tuKetQua = t.tuKetQua;
                    denKetQua = t.denKetQua;

                    //Kiểm tra nếu set cho xét nghiệm
                    if (!t.maxnmay
                        .Equals(maxnmay.Trim(), StringComparison.OrdinalIgnoreCase)) continue;

                    if (iLamTron > 0)
                    {
                        for (var x = 0; x < iLamTron; x++)
                        {
                            dinhDang += "0";
                        }

                        sLamTron += "." + dinhDang;
                    }

                    if (iKetQua < tuKetQua || iKetQua >= denKetQua) continue;

                    ketQuaFinal = string.Format("{0}{1:" + sLamTron + "}", kyTu, dKetQua);
                    break;
                }
            }

            if (ketQuaFinal.Length != 0) return ketQuaFinal;
            {
                ketQuaFinal = ketqua;
                sLamTron = "0";
                d = dtResultRound.AsEnumerable().Where(w =>
                    NumberConverter.ToInt(w["idmay"]) == idmay && NumberConverter.ToInt(w["LoaiBienDich"]) == 4 &&
                    string.IsNullOrEmpty(StringConverter.ToString(w["MaXNMay"]))).Select(row => new
                    {
                        lamtron = NumberConverter.ToInt(row["lamtron"]),
                        maxnmay = StringConverter.ToString(row["MaXNMay"]),
                        tuKetQua = string.IsNullOrEmpty(StringConverter.ToString(row["DieuKienCanDuoi"]))
                        ? minKetQua
                        : NumberConverter.To<decimal>(row["DieuKienCanDuoi"]),
                        denKetQua = string.IsNullOrEmpty(StringConverter.ToString(row["DieuKienCanTren"]))
                        ? maxKetQua
                        : NumberConverter.To<decimal>(row["DieuKienCanTren"])
                    }).ToList();

                foreach (var t in d)
                {
                    iLamTron = t.lamtron;
                    tuKetQua = t.tuKetQua;
                    denKetQua = t.denKetQua;

                    if (iKetQua < tuKetQua || iKetQua >= denKetQua) continue;

                    if (iLamTron > 0)
                    {
                        for (var x = 0; x < iLamTron; x++)
                        {
                            dinhDang += "0";
                        }

                        sLamTron += "." + dinhDang;
                    }

                    ketQuaFinal = kyTu + string.Format("{0:" + sLamTron + "}", dKetQua);
                    break;
                }
            }
            return ketQuaFinal;
        }
        public string Convert_Result(string ketQuaGoc, string kqSoSanh, string kqBienDich, bool soSanhTuyetDoi)
        {
            string[] arraykqSoSanh = kqSoSanh.Split(new string[] { "|", ";" }, StringSplitOptions.RemoveEmptyEntries);

            if (string.IsNullOrEmpty(kqSoSanh))
            {
                return ketQuaGoc;
            }
            else if (arraykqSoSanh.Length > 0)
            {
                foreach (var str in arraykqSoSanh)
                {
                    if (soSanhTuyetDoi)
                    {
                        if (ketQuaGoc.Equals(str, StringComparison.OrdinalIgnoreCase))
                        {
                            return kqBienDich;
                        }
                    }
                    else if (ketQuaGoc.Contains(str))
                    {
                        return kqBienDich;
                    }
                }
            }
            return ketQuaGoc;
        }
        public int UpdateDownloadStatus(bool isDowloaded, string matiepnhan, List<string> maxn, string userID, bool isInfinity, bool normalAnalyzer)
        {
            //  Ghi log
            if ((int)_iWorkingLog.WriteLog_KetQua_CLS_XetNghiem(LogActionId.Update, userID, matiepnhan, maxn, string.Empty) > -1)
            {
                var sqlPara = new SqlParameter[]
                   {
                        new SqlParameter("@MaTiepNhan", matiepnhan)
                        , new SqlParameter("@lstMaXn", Utilities.ConvertStrinArryToInClauseSQLForSplitString(maxn))
                        , new SqlParameter("@userID", userID)
                        , new SqlParameter("@isDownloaded", isDowloaded)
                        , new SqlParameter("@isNormalAnalyzer", normalAnalyzer)
                        , new SqlParameter("@isMiddleware", isInfinity)
                   };
                return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updTrangThaiDownLoad_ChiDinh", sqlPara);
            }
            return 0;
        }
        public DataTable GetTestInDownloadList(DateTime? fromDate, DateTime? toDate, int downloaded, string seq
        , string idMayXetNghiem, string maXetNghiem, string nhomXn)
        {
            var paraFromDate = new SqlParameter();
            paraFromDate.ParameterName = "@tungay";
            paraFromDate.DbType = DbType.DateTime;
            paraFromDate.Value = (fromDate ?? (object)DBNull.Value);

            var paraToDate = new SqlParameter();
            paraToDate.ParameterName = "@denngay";
            paraToDate.DbType = DbType.DateTime;
            paraToDate.Value = (toDate ?? (object)DBNull.Value);

            //@danhsachBarcode,@maXN,@nhomXn,@danhsachMayXn,@daDownload
            var sqlPara = new SqlParameter[]
            {
                paraFromDate
                , paraToDate
                , new SqlParameter("@danhsachBarcode", seq)
                , new SqlParameter("@maXN", maXetNghiem)
                , new SqlParameter("@nhomXn", nhomXn)
                , new SqlParameter("@danhsachMayXn", idMayXetNghiem)
                , new SqlParameter("@daDownload", downloaded)
            };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure
             , "selDanhSachChiDinh_MayXN"
             , sqlPara);

            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }
        public DataTable GetTestingDownload(DateTime fromDate, DateTime toDate, bool dachidinh, bool downloaded, string maBenhNhan
        , string tenBenhNhan, string sid, string tenXetNghiem, string idMayXetNghiem, bool history = false)
        {
            var strSql = "select *, mxn.tenmay as tenmayxn  from {{TPH_Standard}}_Analyzer.dbo.h_ordertest(nolock) h";
            strSql += "\nleft join {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem (nolock) mxn on h.idmay = mxn.idmay";
            strSql += string.Format("\nwhere h.ngayluu between '{0:yyyy/MM/dd} 00:00:00' and '{1:yyyy/MM/dd} 23:59:59.99'", fromDate, toDate);
            if (dachidinh)
                strSql += "\nand h.thoigiandownload is not null and status_id=0";
            else if (downloaded)
                strSql += "\nand h.thoigiandownload is not null and status_id=1";
            else
                strSql += "\nand h.thoigiandownload is null";

            if (!string.IsNullOrWhiteSpace(maBenhNhan))
            {
                strSql += string.Format("\nand h.mabn like '%{0}'", maBenhNhan);
            }
            if (!string.IsNullOrWhiteSpace(tenBenhNhan))
            {
                strSql += string.Format("\nand h.tenbn like '%{0}'", tenBenhNhan);
            }
            if (!string.IsNullOrWhiteSpace(sid))
            {
                strSql += string.Format("\nand h.sid like '%{0}'", sid);
            }
            if (!string.IsNullOrWhiteSpace(tenXetNghiem))
            {
                strSql += string.Format("\nand h.tenxetnghiem like '%{0}'", tenXetNghiem);
            }
            if (!string.IsNullOrWhiteSpace(idMayXetNghiem))
            {
                strSql += string.Format("\nand h.idmay = '{0}'", idMayXetNghiem);
            }
            if (history)
            {
                strSql = string.Format("{0}\nunion all\n{1}", strSql, strSql.Replace("h_ordertest", "h_ordertest_history"));
            }
            using (var result = DataProvider.ExecuteDataset(CommandType.Text, strSql))
            {
                if (result != null && result.Tables.Count > 0)
                {
                    return result.Tables[0];
                }
            }

            return new DataTable();
        }
        public DataTable GetTestinCancel(DateTime fromDate, DateTime toDate, int downloaded, string maBenhNhan,
            string tenBenhNhan, string sid, string tenXetNghiem, string idMayXetNghiem)
        {
            var strSql = "select *, mxn.tenmay as tenmayxn from {{TPH_Standard}}_Analyzer.dbo.h_ordercancel(nolock) h";
            strSql += "\nleft join {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem (nolock) mxn on h.idmay = mxn.idmay";
            strSql += string.Format("\nwhere h.ngayluu between '{0:yyyy/MM/dd}' and '{1:yyyy/MM/dd}'", fromDate, toDate);
            strSql += downloaded > 1 ? "\nand h.thoigiandownload is not null" : "\nand h.thoigiandownload is null";
            if (!string.IsNullOrWhiteSpace(maBenhNhan))
            {
                strSql += string.Format("\nand h.mabn like '%{0}'", maBenhNhan);
            }
            if (!string.IsNullOrWhiteSpace(tenBenhNhan))
            {
                strSql += string.Format("\nand h.tenbn like '%{0}'", tenBenhNhan);
            }
            if (!string.IsNullOrWhiteSpace(sid))
            {
                strSql += string.Format("\nand h.sid like '%{0}'", sid);
            }
            if (!string.IsNullOrWhiteSpace(tenXetNghiem))
            {
                strSql += string.Format("\nand h.tenxetnghiem like '%{0}'", tenXetNghiem);
            }
            if (!string.IsNullOrWhiteSpace(idMayXetNghiem))
            {
                strSql += string.Format("\nand h.idmay in ({0})", idMayXetNghiem);
            }

            using (var result = DataProvider.ExecuteDataset(CommandType.Text, strSql))
            {
                if (result != null && result.Tables.Count > 0)
                {
                    return result.Tables[0];
                }
            }

            return new DataTable();
        }
        //#region Xử lý ghi chú tự động
        //private string GhiChuTuDong(string ketqua, int flat, int idMay, string maXN, string maXnMay)
        //{

        //}
        //#endregion
        #region Xử lý kết quả nhập lưới
        public string Lay_MatiepNhan(bool RepeatBarcode, int DayScanSID, string seq)
        {
            var sidFormated = seq;
            if (RepeatBarcode)
            {
                var data = DataProvider.ExecuteScalar(CommandType.Text, string.Format("select top 1 matiepnhan from benhnhan_tiepnhan where ngaytiepnhan >= dateadd (day,-{0},CONVERT(VARCHAR(10), getdate(), 111)) and SEQ = '{1}' order by ngaytiepnhan desc", DayScanSID, seq));
                if (data != null && !DBNull.Value.Equals(data))
                {
                    sidFormated = StringConverter.ToString(data);
                }
            }
            else
            {
                var data = DataProvider.ExecuteScalar(CommandType.Text, string.Format("select matiepnhan from benhnhan_tiepnhan where seq = '{0}'", seq));

                if (data != null && !DBNull.Value.Equals(data))
                {
                    sidFormated = StringConverter.ToString(data);
                }
            }

            return sidFormated;
        }
        public int CapNhat_MaTiepNhan(string oldSeq, string newSeq, string maTiepNhan, string idList, int statusID)
        {
            var sqlPara = new SqlParameter[]
            {
                new SqlParameter("@ID", idList)
                , new SqlParameter("@Seq", oldSeq)
                , new SqlParameter("@NewSEQ", oldSeq)
                , new SqlParameter("@NewSID", maTiepNhan)
                , new SqlParameter("@StatusID", statusID)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updUpdateSID_KetQuaMayTheoIdVaSeq", sqlPara);
        }
        public DataTable Data_KetQuaMayChoGhepCode(int IdMayXN, int statusID)
        {
            //selKetQuaMayXetNghiem_ChoGhepBarcode
            //@idMayXn int
            //,@statusID int
            var sqlPara = new SqlParameter[]
            {
                new SqlParameter("@idMayXn", IdMayXN)
                ,new SqlParameter("@statusID", statusID)
            };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selKetQuaMayXetNghiem_ChoGhepBarcode", sqlPara).Tables[0];
        }
        #endregion
        #region Cờ từ máy
        public DataTable Data_DanhSachCoTuMay(List<string> lstBoPhan, List<string> lstNhom, List<string> lstMay, string maTiepNhan)
        {
          var sqlPara = new SqlParameter[]
          {
                 new SqlParameter("@PhanQuyenMay", Utilities.ConvertStrinArryToInClauseSQLForSplitString(lstMay))
                , new SqlParameter("@PhanQuyenBoPhan",  Utilities.ConvertStrinArryToInClauseSQLForSplitString(lstBoPhan))
                , new SqlParameter("@PhanQuyenNhom",  Utilities.ConvertStrinArryToInClauseSQLForSplitString(lstNhom))
                , new SqlParameter("@MaTiepNhan", string.IsNullOrEmpty(maTiepNhan)?(object)DBNull.Value:maTiepNhan)
          };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure
             , "selKetQuaMay_Flag"
             , sqlPara);

            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }
        public int Update_DaXemCoTuMay(List<string> lstId)
        {
            var sqlPara = new SqlParameter[]
            {
                new SqlParameter("@IdList", Utilities.ConvertStrinArryToInClauseSQLForSplitString(lstId))
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpKetQuaMay_Flag_DaXem", sqlPara);
        }
        #endregion
        #region Xử lý data trạng thái từ thông tin bệnh nhân và cấu hình 
        public List<DM_XETNGHIEM_CSBT> DataCauHinh_CSBT()
        {
            return systemConfigService.ListNormalRange(systemConfigService.GetNormalRange(string.Empty, null));
        }
        public List<TrangThaiKetQua> ListTrangThaiKetQuaCLSXetNghiem(string matiepnhan)
        {
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure
                , "selDanhSachChiDinh_XetNghiem_KetQuaMay", new SqlParameter[] { WorkingServices.GetParaFromOject("@MaTiepNhan", matiepnhan) }).Tables[0];
            var lst = new List<TrangThaiKetQua>();
            if(data != null)
            {
                if(data.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in data.Rows)
                    {
                        lst.Add((TrangThaiKetQua)WorkingServices.Get_InfoForObject(new TrangThaiKetQua(), dataRow));
                    }
                }
            }
            return lst;
        }
        /// <summary>
        /// Lay chi cac gia tri de so sanh sánh cận - kiển tra trạng thái
        /// </summary>
        /// <param name="maTiepNhan">Mã tiếp nhận</param>
        /// <param name="maXn">Mã xét nghiệm</param>
        /// <param name="canTren">Ngưỡng trên</param>
        /// <param name="canDuoi">Ngưỡng dưới</param>
        /// <param name="trangThai">0: Chưa chỉ định - 1: Đã in - 2: Chưa nhập chỉ định -  3: XN đã valid - 4: XN Đã có KQ - 9: Chấp nhận</param>
        /// <param name="dieuKienBatThuong"></param>
        private void LayGiaTriSoSanh_KiemTraTrangThaiXetNghiem(
            List<TrangThaiKetQua> lstTrangThaiDuLieu
            , List<DM_XETNGHIEM_CSBT> lstDanhMucCSBT, BENHNHAN_TIEPNHAN objBenhNhan
            , BENHNHAN_MAUSANGLOC objSangLocSS, ThongTinHienTaiCuaXetNghiem objInfo)
        {
            var dt = new DataTable();
            var dtTemp = new DataTable();
            //lấy thông tin theo cấu hình bộ csbt
            var trangthaiDuLieu = lstTrangThaiDuLieu.Where(x => x.MaXN.Trim().Equals(objInfo.MaXn.Trim(), StringComparison.OrdinalIgnoreCase));

            dt = Data_LayThongTinXN(dtTemp, objInfo.IDMay, objInfo.ModuleName, objInfo.MaXn);

            objInfo.CanTren = null;
            objInfo.CanDuoi = null;

            if (string.IsNullOrEmpty(objBenhNhan.Matiepnhan))
                objInfo.TrangThai = 0;//chưa nhập thông tin sid
            else if (!trangthaiDuLieu.Any())
                objInfo.TrangThai = 2; //chưa nhập chỉ định
            else if (trangthaiDuLieu.Any())
            {
                var xetNghiemInfo = trangthaiDuLieu.First();
                if (xetNghiemInfo.XacNhanKQ)
                    objInfo.TrangThai = 3;
                else if (!string.IsNullOrEmpty(xetNghiemInfo.Ketqua) || !string.IsNullOrEmpty(xetNghiemInfo.KetQuaDinhLuong) || !string.IsNullOrEmpty(xetNghiemInfo.KetQuaDinhLuongGen))
                    objInfo.TrangThai = 4;
                else
                {
                    objInfo.TrangThai = 9;
                    objInfo.CanDuoi = xetNghiemInfo.NguongDuoi;
                    objInfo.CanTren = xetNghiemInfo.NguongTren;
                    objInfo.CanDuoiCanhBao = xetNghiemInfo.CanDuoiCanhBao;
                    objInfo.CanTrenCanhBao = xetNghiemInfo.CanTrenCanhBao;
                    objInfo.CSBinhThuong = xetNghiemInfo.csbt;
                    objInfo.DieuKienBatThuong = xetNghiemInfo.DKDanhGia;
                    objInfo.DieuKienCanhBaoDinhTinh = xetNghiemInfo.DinhTinhCanhBao;
                    objInfo.DVTinh = xetNghiemInfo.DonVi;
                    objInfo.GioiHanCanhBao = xetNghiemInfo.GioiHanCanhBao;
                    objInfo.LamTron = xetNghiemInfo.LamTron;

                    objInfo.Hesoquidoi = xetNghiemInfo.Hesoquidoi;
                    objInfo.Donviquidoi = xetNghiemInfo.Donviquidoi;
                    objInfo.Csbtquidoi = xetNghiemInfo.Csbtquidoi;
                    objInfo.Lamtronsauquidoi = xetNghiemInfo.LamTron ?? 0;

                    //Loại tuổi 1: Tháng tuổi - 2: Ngày tuổi 
                    var cauhinhCSBT = lstDanhMucCSBT.Where(x => x.Maxn.Equals(objInfo.MaXn, StringComparison.OrdinalIgnoreCase)
                   && ((x.Loaituoi == 1 && objBenhNhan.Sinhnhat != null
                        && ((((objBenhNhan.Sinhnhat ?? DateTime.Now).Year - objBenhNhan.Ngaytiepnhan.Year) * 12) + (objBenhNhan.Sinhnhat ?? DateTime.Now).Month - objBenhNhan.Ngaytiepnhan.Month) >= x.Tutuoi
                        && ((((objBenhNhan.Sinhnhat ?? DateTime.Now).Year - objBenhNhan.Ngaytiepnhan.Year) * 12) + (objBenhNhan.Sinhnhat ?? DateTime.Now).Month - objBenhNhan.Ngaytiepnhan.Month) <= x.Dentuoi)
                   || (x.Loaituoi == 2 && objBenhNhan.Sinhnhat != null
                        && ((objBenhNhan.Sinhnhat ?? DateTime.Now) - objBenhNhan.Ngaytiepnhan).Days >= x.Tutuoi
                        && ((objBenhNhan.Sinhnhat ?? DateTime.Now) - objBenhNhan.Ngaytiepnhan).Days <= x.Dentuoi)
                   || (x.Loaituoi == 0 && (objBenhNhan.Ngaytiepnhan.Year - objBenhNhan.Tuoi) >= x.Tutuoi && (objBenhNhan.Ngaytiepnhan.Year - objBenhNhan.Tuoi) <= x.Dentuoi))
                   && ((x.Csbttucannang == 0 && x.Csbtdencannang == 0) || (x.Csbttucannang > x.Csbtdencannang && objSangLocSS.Cannang >= x.Csbttucannang && objSangLocSS.Cannang <= x.Csbttucannang))
                   && (x.Gioitinh.Equals("A", StringComparison.OrdinalIgnoreCase) || x.Gioitinh.Equals(objBenhNhan.Gioitinh, StringComparison.OrdinalIgnoreCase)));
   
                    if (cauhinhCSBT.Any())
                    {
                        //danh sách theo máy
                        var idMay = int.Parse(objInfo.IDMay);
                        var cauhinhCSBT_May = cauhinhCSBT.Where(x => x.Idmayxn.Equals(idMay));
                        if (!cauhinhCSBT_May.Any())
                            cauhinhCSBT_May = cauhinhCSBT.Where(x => x.Idmayxn < 1);

                        if (cauhinhCSBT_May.Any())
                        {
                            var cauhinh = cauhinhCSBT_May.FirstOrDefault();
                            objInfo.CanDuoi = cauhinh.Nguongduoi;
                            objInfo.CanTren = cauhinh.Nguongtren;
                            objInfo.CanDuoiCanhBao = cauhinh.Canduoicanhbao;
                            objInfo.CanTrenCanhBao = cauhinh.Cantrencanhbao;
                            objInfo.CSBinhThuong = cauhinh.Csbt;
                            objInfo.DieuKienBatThuong = cauhinh.Dieukiendanhgia;
                            objInfo.DieuKienCanhBaoDinhTinh = cauhinh.Dinhtinhcanhbao;
                            objInfo.DVTinh = cauhinh.Donvi;
                            objInfo.GioiHanCanhBao = cauhinh.Gioihancanhbao;

                            objInfo.Hesoquidoi = cauhinh.Hesoquidoi;
                            objInfo.Donviquidoi = cauhinh.Donviquidoi;
                            objInfo.Csbtquidoi = cauhinh.Csbtquidoi;
                            objInfo.Lamtronsauquidoi = cauhinh.Lamtronsauquidoi;
                        }
                    }
                }
            }
        }
        #endregion
    }
}
