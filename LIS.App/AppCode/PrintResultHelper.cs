using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.BarcodePrinting;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Patient.Services;
using TPH.LIS.TestResult.Services;
using System.Drawing;
using System.Threading.Tasks;
using DevExpress.XtraReports.UI;
using TPH.Report.Services;
using TPH.Report.Services.Impl;
using TPH.Report.Models;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.Common.Converter;
using TPH.LIS.User.Enum;
using System.Text;

namespace TPH.LIS.App.AppCode
{
    public class PrintResultHelper
    {
        private readonly ITestResultService _xetnghiem = new TestResultService();
        private readonly IPatientInformationService _iPatient = new PatientInformationService();
        private readonly ISystemConfigService _iSysConfig = new SystemConfigService();
        private readonly IReportService _reportInfo = new ReportServiceImpl();
        private static XtraReport resultReport;
        private static ReportModel resultReportInfo;
        private static DM_XETNGHIEM_MAUPHIEUIN ThongTinPhieuIn;
        private static List< DM_XETNGHIEM_MAUPHIEUIN> lstThongTinPhieuIn;
        private static List<ReportModel> lstResultReportInfo = new List<ReportModel>();
        //private readonly IDigitalSignature _digSign = new DigitalSignatureService();
        private ReportModel GetReportFromConfig(string reportemplateId, DM_XETNGHIEM_MAUPHIEUIN_TUYCHON objMauChonIn)
        {
            if (CommonAppVarsAndFunctions.RefreshReport)
            {
                lstThongTinPhieuIn = null;
                ThongTinPhieuIn = null;
                lstResultReportInfo = new List<ReportModel>();
            }
            var idUsed = (objMauChonIn == null ? string.Empty : (objMauChonIn.Idmauketqua == null ? string.Empty : (objMauChonIn.Idmauketqua.Equals(reportemplateId) ? (objMauChonIn.Idreport ?? string.Empty) : string.Empty)));
            if (lstThongTinPhieuIn == null)
            {
                lstThongTinPhieuIn = new List<DM_XETNGHIEM_MAUPHIEUIN>();
                var objreport = _iSysConfig.Get_Info_dm_xetnghiem_mauphieuin(reportemplateId);
                if (!string.IsNullOrEmpty(objreport.Idreport))
                {
                    ThongTinPhieuIn = objreport;
                    lstThongTinPhieuIn.Add(ThongTinPhieuIn);
                    return GetReportInList((string.IsNullOrEmpty(idUsed) ? objreport.Idreport : idUsed));
                }
            }
            else
            {
                var reportID = lstThongTinPhieuIn.Where(x => x.Idmauketqua.Equals(reportemplateId));
                if (reportID.Any())
                {
                    ThongTinPhieuIn = reportID.First();
                    return GetReportInList((string.IsNullOrEmpty(idUsed) ? ThongTinPhieuIn.Idreport : idUsed));
                }
                else
                {
                    var objreport = _iSysConfig.Get_Info_dm_xetnghiem_mauphieuin(reportemplateId);
                    if (!string.IsNullOrEmpty(objreport.Idreport))
                    {
                        ThongTinPhieuIn = objreport;
                        lstThongTinPhieuIn.Add(ThongTinPhieuIn);
                        return GetReportInList((string.IsNullOrEmpty(idUsed) ? objreport.Idreport : idUsed));
                    }
                }
            }
            return null;
        }
        private ReportModel GetReportInList(string reportID)
        {
            var lst = lstResultReportInfo.Where(x => x.ReportId.Equals(reportID));
            if (lst.Any())
            {
                return lst.FirstOrDefault();
            }
            else
            {
                var rp = _reportInfo.Info_Report(reportID);
                if (!string.IsNullOrEmpty(rp.ReportId))
                {
                    lstResultReportInfo.Add(rp);
                    return rp;
                }
            }
            return null;
        }
        public PrintResultFinishInfo Check_PrintResult(ref int printCount, Image imgLogo,  PrintResultInfo objPrintInfo)
        {
            var objFinish = new PrintResultFinishInfo();
            objPrintInfo.imgLogo = GraphicSupport.ImageToByteArray(imgLogo);
            if (objPrintInfo.userSign.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase)
                && !CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemChoChuKyGiongUserDangNhap)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn người ký tên khác user đăng nhập!");
                return objFinish;
            }
            else if (CommonAppVarsAndFunctions.sysConfig.YeuCauChonKyTen && string.IsNullOrEmpty(objPrintInfo.userSign))
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn người ký tên!");
                return objFinish;
            }

            printCount++;
            var dataPatient = _iPatient.Data_BenhNhan_TiepNhan(objPrintInfo.matiepnhan, null);
            var dtResult = _xetnghiem.DuLieuIn_XN(dataPatient, 0, false
              , objPrintInfo.userSign
              , objPrintInfo.conditSomeTestPrint
              , objPrintInfo.title, objPrintInfo.ngayIn
              , CommonAppVarsAndFunctions.UserWorkPlace
              , (objPrintInfo.reportType == null ? string.Empty : string.Join(",", objPrintInfo.reportType))
              , objPrintInfo.inlai
              , objPrintInfo.arrLoaiXetNghiem
              , objPrintInfo.category
              , CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemThoiGianInKetQuaLanDau
              , false, string.Empty
              , true
              , objPrintInfo.boPhan, objPrintInfo.chiInCoKetQua
              , (CommonAppVarsAndFunctions.IsAdmin ? string.Empty : CommonAppVarsAndFunctions.UserID)
              , false
              , TestType.EnumTestType.HuyetDo
              , objPrintInfo.soPhieuChiDinh
              , CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemInCoTienSu
              );
            if(dtResult.Rows.Count >0)
            {
                XuLyDataHienThivaInTheoQuyTrinh(dtResult);
                if (dtResult.Rows.Count == 0)
                    return objFinish;
                if (!dtResult.Columns.Contains("TenLanhDaoKy"))
                    dtResult.Columns.Add("TenLanhDaoKy", typeof(string));
                if (!dtResult.Columns.Contains("ChucVuLanhDaoKyTen"))
                    dtResult.Columns.Add("ChucVuLanhDaoKyTen", typeof(string));
                foreach (DataRow drP in dtResult.Rows)
                {
                    drP["TenLanhDaoKy"] = objPrintInfo.tenlanhdao;
                    drP["ChucVuLanhDaoKyTen"] = objPrintInfo.chuvuLanhdao;
                }
                DM_XETNGHIEM_MAUPHIEUIN_TUYCHON objMauChonIn = null;
                if(!string.IsNullOrEmpty(objPrintInfo.mauChonIn))
                {
                    objMauChonIn = new DM_XETNGHIEM_MAUPHIEUIN_TUYCHON();
                    objMauChonIn = _iSysConfig.Get_Info_dm_xetnghiem_mauphieuin_tuychon(objPrintInfo.mauChonIn);
                }
                var reportdataList = dtResult.DefaultView.ToTable(true, "IDMauKetQua");
                if(reportdataList.Rows.Count >0)
                {
                    foreach (DataRow dr in reportdataList.Rows)
                    {
                        if (!string.IsNullOrEmpty(dr["IDMauKetQua"].ToString()))
                        {
                            var dataPrint = WorkingServices.SearchResult_OnDatatable(dtResult, string.Format("IDMauKetQua = '{0}'", dr["IDMauKetQua"].ToString()));
                            dataPrint.DefaultView.Sort = "ThuTuNhom asc,SapXep asc,MaXN asc";
                            dataPrint = dataPrint.DefaultView.ToTable();

                            var hPrint = PrintResult_ByReportTemplate(objPrintInfo, dataPrint, objMauChonIn);
                            if (!objFinish.havePrint)
                            {
                                objFinish.havePrint = hPrint.havePrint;
                            }
                            if (!objFinish.coDaDuyet)
                            {
                                objFinish.coDaDuyet = hPrint.coDaDuyet;
                            }
                        }
                        else
                            CustomMessageBox.MSG_Information_OK("Có xét nghiệm chưa khai báo vào phiếu in!\nHãy vào cài đặt phiếu in để khai báo.");
                    }
                }
            }
            if (printCount >= 10)
            {
                printCount = 0;
                var task = new Task(new Action(WorkingServices.CleanTemporaryFolders));
                task.Start();
            }
            return objFinish;
        }
        private DataTable XuLyDataHienThivaInTheoQuyTrinh(DataTable dataIn)
        {
            if (dataIn != null)
            {
                if (dataIn.Rows.Count > 0)
                {
                    var checkDalayMau = QuiTrinhLAB.GetTrangThaiLayMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh);
                    var checkDaNhanMau = QuiTrinhLAB.GetTrangThaiNhanMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh);
                    if (checkDalayMau || checkDaNhanMau)
                    {
                        for (var i = 0; i < dataIn.Rows.Count; i++)
                        {
                            var rDalayMau = bool.Parse(dataIn.Rows[i]["DaLayMau"].ToString());
                            var rDaNhanMau = bool.Parse(dataIn.Rows[i]["DaNhanMau"].ToString());
                            if ((!checkDalayMau || rDalayMau) && (!checkDaNhanMau || rDaNhanMau)) continue;
                            dataIn.Rows.RemoveAt(i);
                            i--;
                        }
                        dataIn.AcceptChanges();
                    }
                }
            }
            return dataIn;
        }
        public bool KiemTraChoPhepInCacKetQua(DataTable dataKetQua, ref bool coDaDuyet, ref bool QCOut, ref bool DuMayXN)
        {
            bool duyetDu = true;
            DuMayXN = true;
            for (int i = 0; i < dataKetQua.Rows.Count; i++)
            {
                var qcOut = bool.Parse(dataKetQua.Rows[i]["QCOut"].ToString());
                var daduyet = bool.Parse(dataKetQua.Rows[i]["XacNhanKQ"].ToString());
                var idMay = WorkingServices.ValueString_Int_Zero(dataKetQua.Rows[i]["IDMayXetNghiem"].ToString());
                var kiemtraMay = bool.Parse(dataKetQua.Rows[i]["KiemTraMayChay"].ToString());
                if (!coDaDuyet)
                    coDaDuyet = daduyet;
                if (!daduyet)
                    duyetDu = false;
                if (!QCOut)
                    QCOut = qcOut;
                if (idMay == 0 && kiemtraMay)
                    DuMayXN = false;
            }
            return duyetDu;
        }
        public PrintResultFinishInfo PrintResult_ByReportTemplate(PrintResultInfo objPrintInfo, DataTable dtResult, DM_XETNGHIEM_MAUPHIEUIN_TUYCHON objMauChonIn)
        {
            var objFinish = new PrintResultFinishInfo();
            bool qcOut = false;
            bool coDaDuyet = false;
            bool duMay = false;
            if (dtResult != null)
            {
                if (dtResult.Rows.Count > 0)
                {
                   var reportTemplateID = dtResult.Rows[0]["IDMauKetQua"].ToString();
                    resultReportInfo = GetReportFromConfig(reportTemplateID, objMauChonIn);
                    var idNgonNgu = (objMauChonIn == null ? string.Empty : (objMauChonIn.MaNgonNgu == null ? string.Empty : objMauChonIn.MaNgonNgu));
                    if (resultReportInfo == null)
                    {
                        CustomMessageBox.MSG_Information_OK(string.Format("Phiếu in của mẫu: \"{0}\" chưa được khai báo.", reportTemplateID));
                        return objFinish;
                    }
                    var checkDalayMau = QuiTrinhLAB.GetTrangThaiLayMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh);
                    var checkDaNhanMau = QuiTrinhLAB.GetTrangThaiNhanMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh);
                    if (checkDalayMau || checkDaNhanMau)
                    {
                        for (var i = 0; i < dtResult.Rows.Count; i++)
                        {
                            var rDalayMau = bool.Parse(dtResult.Rows[i]["DaLayMau"].ToString());
                            var rDaNhanMau = bool.Parse(dtResult.Rows[i]["DaNhanMau"].ToString());
                            if ((!checkDalayMau || rDalayMau) && (!checkDaNhanMau || rDaNhanMau)) continue;
                            dtResult.Rows.RemoveAt(i);
                            i--;
                        }
                        dtResult.AcceptChanges();
                    }

                    if (objPrintInfo.userValidTheoUserDangNhap)
                    {
                        dtResult = WorkingServices.SearchResult_OnDatatable(dtResult, string.Format("NguoiXacNhan = '{0}'", CommonAppVarsAndFunctions.UserID));
                    }
                    if (dtResult.Rows.Count > 0)
                    {
                        var duyetDu = KiemTraChoPhepInCacKetQua(dtResult, ref coDaDuyet, ref qcOut, ref duMay);
                 
                        if (!CommonAppVarsAndFunctions.sysConfig.ChoPhepChonKyTenKhac)
                        {
                            if (!ChoPhepUserKyTen(dtResult, objPrintInfo.userSign))
                            {
                                CustomMessageBox.MSG_Information_OK("Người ký tên không giống người ký của lần in trước!");
                                return objFinish;
                            }
                        }
                      
                        if (objPrintInfo.userValidTheoUserDangNhap)
                        {
                            dtResult = WorkingServices.SearchResult_OnDatatable(dtResult, string.Format("NguoiXacNhan = '{0}'", CommonAppVarsAndFunctions.UserID));
                        }
                        if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemChiInKetQuaDaDuyet && !objPrintInfo.isAutoPrint)
                        {
                            if (!duyetDu)
                            {
                                CustomMessageBox.MSG_Information_OK("Các kết quả chưa được duyệt hết!");
                                return objFinish;
                            }
                        }
                        else if (qcOut && CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemKhongInQCFail)
                        {
                            CustomMessageBox.MSG_Information_OK("Không thể in kết quả có QC Fail!");
                            return objFinish;
                        }
                        else if (!duMay && CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemKiemTraMayXNKhiIn)
                        {
                            CustomMessageBox.MSG_Information_OK("Các kết quả chưa đủ thông tin máy xét nghiệm!");
                            return objFinish;
                        }
                        if (dtResult.Rows.Count > 0)
                        {
                            if (ThongTinPhieuIn.Tachbophan)
                            {
                                var distinctBoPhan = dtResult.DefaultView.ToTable(true, "MaBoPhan", "TachPhieuTheoBSChiDinh", "TachPhieuTheoOngMau", "TachPhieuTheoNhomIn", "CoChuKyUserValid");
                                foreach (DataRow drBP in distinctBoPhan.Rows)
                                {
                                    objPrintInfo.inTheoBS = bool.Parse(drBP["TachPhieuTheoBSChiDinh"].ToString());
                                    objPrintInfo.inTheoOngMau = bool.Parse(drBP["TachPhieuTheoOngMau"].ToString());
                                    objPrintInfo.intheoNhomIn = bool.Parse(drBP["TachPhieuTheoNhomIn"].ToString());
                                    objPrintInfo.intheoUserValid = bool.Parse(drBP["CoChuKyUserValid"].ToString());
                                    var dtprint = WorkingServices.SearchResult_OnDatatable_NoneSort(dtResult, string.Format("MaBoPhan = '{0}'", drBP["MaBoPhan"].ToString().Trim()));
                                    dtprint.DefaultView.Sort = "ThuTuNhom asc,SapXep asc,MaXN asc";
                                    dtprint = dtprint.DefaultView.ToTable();

                                    var hPrint = PrintResult_ByDepartment(objPrintInfo,dtprint);

                                    if (!objFinish.havePrint)
                                    {
                                        objFinish.havePrint = hPrint.havePrint;
                                    }
                                    if (!objFinish.coDaDuyet)
                                    {
                                        objFinish.coDaDuyet = hPrint.coDaDuyet;
                                    }
                                }
                            }
                            else
                            {
                                objFinish = StartPrint_PreviewResult(objPrintInfo, dtResult);
                            }
                        }
                    }
                }
            }
            objFinish.coDaDuyet = coDaDuyet;
            return objFinish;
        }
        private PrintResultFinishInfo PrintResult_ByDepartment(PrintResultInfo objPrintInfo, DataTable dtPrint)
        {
            var objFinish = new PrintResultFinishInfo();
            if (objPrintInfo.inTheoBS)
            {
                var dsBacSi = dtPrint.DefaultView.ToTable(true, "BSChiDinh");
                if (dsBacSi.Rows.Count > 0)
                {
                    foreach (DataRow drBacSi in dsBacSi.Rows)
                    {
                        var bsChiDinh = drBacSi["BSChiDinh"].ToString();
                        var dataPrint = SearchDataToPrint(dtPrint, "BSChiDinh", bsChiDinh);
                        if (dataPrint.Rows.Count > 0)
                        {
                            objPrintInfo.inTheoBS = false;

                            var hPrint = PrintResult_ByDepartment(objPrintInfo , dataPrint);
                            if (!objFinish.havePrint)
                                objFinish.havePrint = hPrint.havePrint;
                            if (!objFinish.coDaDuyet)
                                objFinish.coDaDuyet = hPrint.coDaDuyet;
                        }
                    }
                }
            }
            else if (objPrintInfo.intheoNhomIn)
            {
                var dsNhomIn = dtPrint.DefaultView.ToTable(true, "nhomin");
                if (dsNhomIn.Rows.Count > 0)
                {
                    foreach (DataRow drBacSi in dsNhomIn.Rows)
                    {
                        var nhomIn = drBacSi["nhomin"].ToString();
                        var dataPrint = SearchDataToPrint(dtPrint, "nhomin", nhomIn);
                        if (dataPrint.Rows.Count > 0)
                        {
                            objPrintInfo.intheoNhomIn = false;

                            var hPrint = PrintResult_ByDepartment(objPrintInfo, dataPrint);
                            if (!objFinish.havePrint)
                                objFinish.havePrint = hPrint.havePrint;
                            if (!objFinish.coDaDuyet)
                                objFinish.coDaDuyet = hPrint.coDaDuyet;
                        }
                    }
                }
            }
            else if (objPrintInfo.inTheoOngMau)
            {
                var dsLoaiMau = dtPrint.DefaultView.ToTable(true, "LoaiMau");
                if (dsLoaiMau.Rows.Count > 0)
                {
                    foreach (DataRow drLoaiMau in dsLoaiMau.Rows)
                    {
                        var loaiMmau = drLoaiMau["LoaiMau"].ToString();
                        var dataPrint = SearchDataToPrint(dtPrint, "LoaiMau", loaiMmau);
                        if (dataPrint.Rows.Count > 0)
                        {
                            objPrintInfo.inTheoOngMau = false;
                            var hPrint = PrintResult_ByDepartment(objPrintInfo, dataPrint);
                            if (!objFinish.havePrint)
                                objFinish.havePrint = hPrint.havePrint;
                            if (!objFinish.coDaDuyet)
                                objFinish.coDaDuyet = hPrint.coDaDuyet;
                        }
                    }
                }
            }
            else if (objPrintInfo.intheoUserValid)
            {
                var dsNguoiXacNhan = dtPrint.DefaultView.ToTable(true, "NguoiXacNhan");
                if (dsNguoiXacNhan.Rows.Count > 0)
                {
                    foreach (DataRow drLoaiMau in dsNguoiXacNhan.Rows)
                    {
                        var nguoiXacNhan = drLoaiMau["NguoiXacNhan"].ToString();
                        var dataPrint = SearchDataToPrint(dtPrint, "NguoiXacNhan", nguoiXacNhan);
                        if (dataPrint.Rows.Count > 0)
                        {
                            objPrintInfo.intheoUserValid = false;
                            var hPrint = PrintResult_ByDepartment(objPrintInfo, dataPrint);
                            if (!objFinish.havePrint)
                                objFinish.havePrint = hPrint.havePrint;
                            if (!objFinish.coDaDuyet)
                                objFinish.coDaDuyet = hPrint.coDaDuyet;
                        }
                    }
                }
            }
            else
            {
                objFinish = StartPrint_PreviewResult(objPrintInfo, dtPrint);
            }
            return objFinish;
        }
        private DataTable SearchDataToPrint(DataTable dataIn, string colName, string searchValue)
        {
            var dataSelect = new DataTable();
            if (string.IsNullOrEmpty(searchValue))
            {
                dataSelect = WorkingServices.SearchResult_OnDatatable_NoneSort(dataIn, string.Format("{0} is null", colName));
            }
            else
                dataSelect = WorkingServices.SearchResult_OnDatatable_NoneSort(dataIn, string.Format("{0} = '{1}'", colName, searchValue));

            dataSelect.DefaultView.Sort = "ThuTuNhom asc,SapXep asc,MaXN asc";
            dataSelect = dataSelect.DefaultView.ToTable();
            return dataSelect;
        }
        public PrintResultFinishInfo StartPrint_PreviewResult(PrintResultInfo objPrintInfo, DataTable dtPrintSource)
        {
            var objFinish = new PrintResultFinishInfo();
            var dtResult = dtPrintSource.Copy();
            string headerFlat = "XN";
            if (dtPrintSource != null && dtPrintSource.Rows.Count > 0)
            {    //Xử lý id ile ký số
                bool signFirst = false;
                var sampleId = StringConverter.ToString(dtPrintSource.Rows[0]["MaTiepNhan"]);
                var tenFileHIS = "";
                //Lấy các test sẽ in lưu ý co dấu ' cho hàm in
                objPrintInfo.conditSomeTestPrint = String.Empty;
                for (int i = 0; i < dtPrintSource.Rows.Count; i++)
                {
                    objPrintInfo.conditSomeTestPrint += ((string.IsNullOrEmpty(objPrintInfo.conditSomeTestPrint) ? "" : ",") + string.Format("'{0}'", dtPrintSource.Rows[i]["MaXn"].ToString()));
                }
                XuLyIDFileKySo(dtPrintSource, sampleId, objPrintInfo.conditSomeTestPrint, signFirst, ref tenFileHIS);
                //Tách data in theo từng ID File ký số
                var dtFileHis = dtPrintSource.DefaultView.ToTable(true, "TenFileHIS");
                foreach (DataRow dataFile in dtFileHis.Rows)
                {
                    var dtPrint = WorkingServices.SearchResult_OnDatatable(dtPrintSource, string.Format("TenFileHIS = '{0}'", dataFile["TenFileHIS"].ToString()));
                    if (dtPrint != null && dtPrint.Rows.Count > 0)
                    {
                        var CacMayChay = string.Empty;
                        string tenLoaiMau = string.Empty;
                        string tenBS = string.Empty;
                        string tenKhoa = string.Empty;
                        var barcode = BarcodeHelper.TextToBarcode(dtPrint.Rows[0]["Seq"].ToString());
                        string ghiChuISO = string.Empty;
                        var nguoiDuyetYKhoa = string.Empty;
                        var nguoiNhaKQ = string.Empty;
                        var SomeTestPrint = string.Empty;
                        var SomeRSoPhieuYeucau = string.Empty;
                        var reportTemplateID = objPrintInfo.idReport;

                        foreach (DataRow dr in dtPrint.Rows)
                        {
                            SomeTestPrint += string.IsNullOrEmpty(SomeTestPrint) ? "" : ",";
                            SomeTestPrint += string.Format("{0}", dr["MaXn"].ToString());
                            if (!string.IsNullOrEmpty(dr["RSoPhieuYeucau"].ToString()))
                            {
                                SomeRSoPhieuYeucau += string.IsNullOrEmpty(SomeRSoPhieuYeucau) ? "" : ",";
                                SomeRSoPhieuYeucau += string.Format("{0}", dr["RSoPhieuYeucau"].ToString());
                            }
                            dr["ReportLogo"] = objPrintInfo.imgLogo;
                        }
                        if (ThongTinPhieuIn.Chiacot)
                        {
                            CacMayChay = _xetnghiem.XuLytenMayChay(dtPrint);
                            tenLoaiMau = _xetnghiem.XuLytenLoaiMau(dtPrint);
                            tenBS = _xetnghiem.XuLyTenBS(dtPrint);
                            tenKhoa = _xetnghiem.XuLyTenKhoa(dtPrint);
                            ghiChuISO = _xetnghiem.XulyCommnetChung(dtPrint, ThongTinPhieuIn.Ghichuduoixn, ThongTinPhieuIn.Gheptenxnghichu, ThongTinPhieuIn.Ghepghichukhoavaochung);
                            nguoiDuyetYKhoa = _xetnghiem.XuLyNguoiDuyetYKhoa(dtPrint, false, ThongTinPhieuIn.Dinhdangghepduyetkq);
                            nguoiNhaKQ = _xetnghiem.XuLyNguoiNhapKetQua(dtPrint, false, ThongTinPhieuIn.Dinhdangghepnhapkq);

                            dtPrint = _xetnghiem.ConvertDataResultPrintFrom_RowToColumn(dtPrint, SomeTestPrint);
                            headerFlat = "XNBYT";
                            dtPrint = SetReportInfo(dtPrint, barcode, CacMayChay, tenBS, tenKhoa
                                , nguoiDuyetYKhoa, objPrintInfo.imgLogo, ghiChuISO, ThongTinPhieuIn.Ghichuduoixn
                                , nguoiNhaKQ, ghiChuISO, tenLoaiMau, objPrintInfo.idNgonNgu);
                            if (!dtPrint.Columns.Contains("MaXN"))
                            {
                                dtPrint.Columns.Add("MaXN", typeof(string));
                            }
                            dtPrint.Rows[0]["MaXN"] = SomeTestPrint;
                            if (!dtPrint.Columns.Contains("RSoPhieuYeucau"))
                            {
                                dtPrint.Columns.Add("RSoPhieuYeucau", typeof(string));
                            }
                            dtPrint.Rows[0]["RSoPhieuYeucau"] = SomeTestPrint;
                        }
                        else
                        {
                            if (ThongTinPhieuIn.Tachnhomin)
                            {
                                var dtNhomIn = dtPrint.DefaultView.ToTable(true, "NhomIn");
                                var dtFinal = dtPrint.Clone();
                                foreach (DataRow drNhomIn in dtNhomIn.Rows)
                                {
                                    DataTable dtXuLy = new DataTable();
                                    var nhomIn = drNhomIn["NhomIn"].ToString();
                                    if (string.IsNullOrEmpty(nhomIn))
                                        dtXuLy = WorkingServices.SearchResult_OnDatatable(dtPrint, string.Format("NhomIn ='' or NhomIn is null"));
                                    else
                                        dtXuLy = WorkingServices.SearchResult_OnDatatable(dtPrint, string.Format("NhomIn = '{0}'", nhomIn));
                                    dtFinal.Merge(_xetnghiem.DataPrintList_NotAutoSplit(dtXuLy
                                      , !ThongTinPhieuIn.Tachnhomin
                                      , ThongTinPhieuIn.Tachnhomin
                                      , ThongTinPhieuIn.Ghichuduoixn
                                      , ThongTinPhieuIn.Gheptenxnghichu
                                      , ThongTinPhieuIn.Ghepghichukhoavaochung
                                      , ThongTinPhieuIn.Dinhdangghepduyetkq
                                      , ThongTinPhieuIn.Dinhdangghepnhapkq));
                                }
                                dtPrint = dtFinal;
                            }
                            else
                            {
                                dtPrint = _xetnghiem.DataPrintList_NotAutoSplit(dtPrint
                                          , !ThongTinPhieuIn.Tachnhomin
                                          , ThongTinPhieuIn.Tachnhomin
                                          , ThongTinPhieuIn.Ghichuduoixn
                                          , ThongTinPhieuIn.Gheptenxnghichu
                                          , ThongTinPhieuIn.Ghepghichukhoavaochung
                                          , ThongTinPhieuIn.Dinhdangghepduyetkq
                                          , ThongTinPhieuIn.Dinhdangghepnhapkq);
                            }
                        }
                        if (dtPrint != null && dtPrint.Rows.Count > 0)
                        {
                            objPrintInfo.progressPrint.Maximum = 30;
                            objPrintInfo.progressPrint.Visible = true;
                            objPrintInfo.progressPrint.Value = 0;
                            objPrintInfo.progressPrint.Value++;
                            //Lấy thông tin các xn in sau cùng
                            var lstTestName = new StringBuilder();
                            if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXuatPDFKhiIn)
                            {
                                var lanin = dtPrint.AsEnumerable().Select(
                                    r => new
                                    {
                                        LanInXNTest = r["LanInXNTest"]
                                    }
                                ).Distinct().ToList();
                                if (lanin.Count > 1)
                                {
                                    var t = dtPrint.AsEnumerable()
                                        .Where(w => NumberConverter.ToInt(w["LanInXNTest"]) == 0).Select(
                                            r => new
                                            {
                                                TenXN = r["TenXN"]
                                            }
                                        ).Distinct().ToList();

                                    foreach (var r in t)
                                    {
                                        if (lstTestName.Length == 0)
                                        {
                                            lstTestName.Append(r.TenXN);
                                        }
                                        else
                                        {
                                            lstTestName.AppendFormat(", {0}", r.TenXN);
                                        }
                                    }
                                }
                            }
                            //Lấy thông tin các loại xn in sau cùng
                            List<int> lstLoaiXetNghiem = dtPrint.AsEnumerable().Select(
                                    r => new
                                    {
                                        LoaiXN = r["LoaiXetNghiem"]
                                    }
                                ).Distinct().Select(i => int.Parse(i.LoaiXN.ToString())).ToList();
                            //Lấy report type để gửi về HIS ReportFormID => Dùng cấu hình
                            //var reportType = GetReportTypeFromListLoaiXN(lstLoaiXetNghiem);
                            var LoaiXetNghiem = NumberConverter.ToInt(dtPrint.Rows[0]["LoaiXetNghiem"]);
                            var DaUpload = false;
                        
                            foreach (DataRow dr in dtPrint.Rows)
                            {
                                //Kiểm tra có LoaiXetNghiem là 24 không để set data upload cho phiếu va ketqua có dương tính ko.
                                if (StringConverter.ToString(dr["ketqua"]).ToUpper().Contains("DƯƠNG TÍNH")
                                    && NumberConverter.ToInt(dr["LoaiXetNghiem"]) == (int)TestType.EnumTestType.Covid19)
                                {
                                    DaUpload = true;
                                    break;
                                }
                            }
                            var _reportDex = new FrmPreViewReport();

                            _reportDex.SampleID = string.Format("Ketqua_{0}_{1}", reportTemplateID, dtPrint.Rows[0]["MaTiepNhan"].ToString().Trim());

                            _reportDex.TenBN = dtPrint.Rows[0]["TenBN"].ToString().Trim();
                            _reportDex.InMau = objPrintInfo.inMau;
                            _reportDex.PrintWithConvertUnit = objPrintInfo.inCoQuiDoi;
                            _reportDex.UserSign = objPrintInfo.userSign;

                            _reportDex.ClsXetNghiemPhieuInBatThuongInDam = ThongTinPhieuIn.Batthuongindam;
                            _reportDex.ClsXetNghiemPhieuInBatThuongInNghieng = ThongTinPhieuIn.Batthuonginnghieng;
                            _reportDex.ClsXetNghiemPhieuInBatThuongGachChan = ThongTinPhieuIn.Batthuonggachchan;
                            _reportDex.ClsXetNghiemPhieuInTachTheoBoPhan = ThongTinPhieuIn.Tachbophan;
                            _reportDex.ClsXetNghiemPhieuInTachTheoNhom = ThongTinPhieuIn.Tachnhomin;
                            _reportDex.ClsXetNghiemPhieuInTenNhomInDam = ThongTinPhieuIn.Tennhomindam;
                            _reportDex.ClsXetNghiemPhieuInTenNhomInNghieng = ThongTinPhieuIn.Tennhominnghieng;
                            _reportDex.ClsXetNghiemPhieuInTenNhomGachChan = ThongTinPhieuIn.Tennhomgachchan;
                            _reportDex.ClsXetNghiemPhieuInLeTenNhom = ThongTinPhieuIn.Lenhom;

                            _reportDex.ClsXetNghiemCanhLeBinhThuong = ThongTinPhieuIn.Lekqtrongnguong;
                            _reportDex.ClsXetNghiemCanhLeBatThuongTren = ThongTinPhieuIn.Lekqtrennguong;
                            _reportDex.ClsXetNghiemCanhLeBatThuongDuoi = ThongTinPhieuIn.Lekqduoinguong;
                            _reportDex.ClsXetNghiemPhieuInChuKyCuoiTrang = !ThongTinPhieuIn.Kytentheoluoi;
                            #region Thông tin dùng ký số
                            _reportDex.SampleID = CommonAppVarsAndFunctions.sysConfig.ConnectHIS
                                 ? dtPrint.Rows[0]["SEQ"].ToString().Trim()
                                 : string.Format("Ketqua_{0}_{1}", reportTemplateID, dtPrint.Rows[0]["MaTiepNhan"].ToString().Trim());
                            _reportDex.ReportType = (int)ServiceType.ClsXetNghiem;
                            _reportDex.HisPatientId = StringConverter.ToString(dtPrint.Rows[0]["MaBn"]);
                            _reportDex.HisOrderID = StringConverter.ToString(dtPrint.Rows[0]["SoPhieuYeuCau"]);
                            _reportDex.Seq = StringConverter.ToString(dtPrint.Rows[0]["Seq"]);
                            _reportDex.MaTiepNhan = dtPrint.Rows[0]["MaTiepNhan"].ToString().Trim();
                            _reportDex.TGIn = TPH.Common.Converter.DateTimeConverter.ToDateTime(dtPrint.Rows[0]["NgayInKQ"]);
                            _reportDex.ViewPdfAfterPrint = objPrintInfo.xemlaiChuKySo;
                            _reportDex.ExportPdfPath = CommonAppVarsAndFunctions.sysConfig.EmailPdfPath;
                            _reportDex.DungChuKySo = objPrintInfo.suDungChuKySo;
                            _reportDex.LoaiKy = objPrintInfo.kieuKyTen;
                            _reportDex.IdChuKySo = objPrintInfo.idChuKy;
                            _reportDex.MoTa = lstTestName.Length == 0 ? objPrintInfo.ghiChu : string.Format("{0}\r\n{1}", objPrintInfo.ghiChu, lstTestName);
                            _reportDex.DaUpload = DaUpload;
                            _reportDex.LoaiXetNghiem = LoaiXetNghiem;
                            _reportDex.LanIn = NumberConverter.ToInt(dtPrint.AsEnumerable().Max(r => r["LanInCuaXN"]));
                            _reportDex.lstLoaiXnIn = lstLoaiXetNghiem;
                            //Xử lý id report HIS lấy theo cấu hình
                            _reportDex.HISReportFormID = ThongTinPhieuIn.IdFormHIS;
                            _reportDex.TenFileHIS = tenFileHIS;
                            _reportDex.conditSomeTestPrint = objPrintInfo.conditSomeTestPrint;
                            #endregion

                            resultReport = _reportInfo.CreateReportFromStream(resultReportInfo.ReportSuDung);
                            objPrintInfo.idReport = (string.IsNullOrEmpty(objPrintInfo.idReport) ? ThongTinPhieuIn.Idmauketqua : objPrintInfo.idReport);
                            objFinish.havePrint = _reportDex.ShowReport(resultReport, dtPrint, objPrintInfo.print, objPrintInfo.printerName, headerFlat, resultReportInfo.TenDataset, resultReportInfo.TenDatatable, objPrintInfo.idReport, objPrintInfo.exportPdf, objPrintInfo.pdfPathList);

                            if (objFinish.havePrint)
                            {
                                BatCoTrangThaiSauKhiIn(dtResult, objPrintInfo.boPhan, reportTemplateID, SomeTestPrint, objPrintInfo.userSign);
                                if (!objFinish.coDaDuyet && CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemInTuXacNhan)
                                    objFinish.coDaDuyet = true;
                            }
                            objPrintInfo.progressPrint.Value++;
                            objPrintInfo.progressPrint.Visible = false;
                        }
                        else
                        {
                            if (objPrintInfo.showMess)
                                CustomMessageBox.MSG_Information_OK(string.Format("Không có dữ liệu để in mẫu: {0}", string.IsNullOrEmpty(reportTemplateID) ? "Thường qui" : reportTemplateID));
                        }
                    }
                }
            }
            return objFinish;
        }
        private void BatCoTrangThaiSauKhiIn(DataTable dtResult
          , string boPhan
          , string reportTemplateID
          , string conditSomeTestPrint
          , string kyTen)
        {
            string categoryPrint = string.Empty;
            var dataDistincCategory = dtResult.AsDataView().ToTable(true, new string[] { "manhomcls" });

            foreach (DataRow drC in dataDistincCategory.Rows)
            {
                categoryPrint += (string.IsNullOrEmpty(categoryPrint) ? "" : ",") + string.Format("{0}", drC["manhomcls"].ToString());
            }

            if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiem_LoaiPhieuKetQua == EnumReportResultTemplatetype.MauKetQua_BYT)
            {
                _xetnghiem.CapNhatPrintOut_WithReportType(dtResult.Rows[0]["MaTiepNhan"].ToString().Trim(), reportTemplateID, true
                    , CommonAppVarsAndFunctions.UserID, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemInTuXacNhan
                    , conditSomeTestPrint, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXacNhanDe, kyTen, (int)CommonAppVarsAndFunctions.sysConfig.LayNguoiThucHien);
            }
            else
            {
                _xetnghiem.CapNhatPrintOut_WithoutReportType(dtResult.Rows[0]["MaTiepNhan"].ToString().Trim()
                    , conditSomeTestPrint, categoryPrint, true, CommonAppVarsAndFunctions.UserID, boPhan
                    , CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemInTuXacNhan, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXacNhanDe, kyTen, (int)CommonAppVarsAndFunctions.sysConfig.LayNguoiThucHien);
            }

            _xetnghiem.UpdatePrintOutPatientAndCategoryAndDeparment(dtResult.Rows[0]["MaTiepNhan"].ToString().Trim(), categoryPrint, true, CommonAppVarsAndFunctions.UserID
                , false, kyTen, Environment.MachineName, CommonAppVarsAndFunctions.ServerTime, 0);
        }
        private DataTable SetReportInfo(DataTable dtPrint, byte[] barcode, string CacMayChay
            , string tenBS, string tenKhoa, string nguoiDuyetYkhoa, byte[] imgLogo
            , string ghiChu, bool ghichuDuoiKetQua, string nguoinhapKetQua
            , string ghiChuISO, string loaiMau, string idNgonNgu)
        {
            if(!dtPrint.Columns.Contains("NguoiInKetQua"))
            {
                dtPrint.Columns.Add("NguoiInKetQua", typeof(string));
            }
            for (var i = 0; i < dtPrint.Rows.Count; i++)
            {
                dtPrint.Rows[i]["Barcode"] = barcode;
                dtPrint.Rows[i]["TenMayGhep"] = CacMayChay;
                dtPrint.Rows[i]["TenNhanVien"] = tenBS;
                dtPrint.Rows[i]["TenKhoaPhong"] = tenKhoa;
                dtPrint.Rows[i]["DuyetYKhoa"] = nguoiDuyetYkhoa;
                dtPrint.Rows[i]["NhapKetQua"] = nguoinhapKetQua;
                dtPrint.Rows[i]["GhiChuISO"] = ghiChuISO;
                dtPrint.Rows[i]["GhiChuDuoiKetQua"] = ghichuDuoiKetQua;
                dtPrint.Rows[i]["ReportLogo"] = imgLogo;
                dtPrint.Rows[i]["GhiChuDuoiKetQua"] = ghichuDuoiKetQua;
                dtPrint.Rows[i]["NguoiInKetQua"] = CommonAppVarsAndFunctions.UserName;
                dtPrint.Rows[i]["LoaiMau"] = loaiMau;
                if (!string.IsNullOrEmpty(idNgonNgu))
                {
                    var maXn = dtPrint.Rows[i]["MaXn"].ToString();
                    var maKhoaPhong = dtPrint.Rows[i]["MaDonVi"].ToString();
                    var maDoiTuong = dtPrint.Rows[i]["MaDoiTuongDichVu"].ToString();
                    var maNhomXN = dtPrint.Rows[i]["MaNhomCLS"].ToString();
                    var maboPhanXN = dtPrint.Rows[i]["MaBoPhan"].ToString();
                    var nguoiXacNhan = dtPrint.Rows[i]["MaNguoiXacNhan"].ToString();

                    var tenXnB = TimNgonNguBienDich(maXn, EnumLoaiDanhMucNgonNgu.DanhMucXetNghiem.ToString(), idNgonNgu);
                    if (!string.IsNullOrEmpty(tenXnB))
                        dtPrint.Rows[i]["TenXN"] = tenXnB;
                    var tenKhoaPhongB = TimNgonNguBienDich(maKhoaPhong, EnumLoaiDanhMucNgonNgu.DanhMucKhoaPhong.ToString(), idNgonNgu);
                    if (!string.IsNullOrEmpty(tenKhoaPhongB))
                        dtPrint.Rows[i]["TenKhoaPhong"] = tenKhoaPhongB;
                    var tendoiTuongB = TimNgonNguBienDich(maDoiTuong, EnumLoaiDanhMucNgonNgu.DanhMucDoiTuong.ToString(), idNgonNgu);
                    if (!string.IsNullOrEmpty(tendoiTuongB))
                        dtPrint.Rows[i]["TenDoiTuongDichVu"] = tendoiTuongB;
                    var tenNhomXnB = TimNgonNguBienDich(maNhomXN, EnumLoaiDanhMucNgonNgu.DanhMucNhomXN.ToString(), idNgonNgu);
                    if (!string.IsNullOrEmpty(tenNhomXnB))
                        dtPrint.Rows[i]["TenNhomCLS"] = tenNhomXnB;
                    var tenBoPhanXNB = TimNgonNguBienDich(maboPhanXN, EnumLoaiDanhMucNgonNgu.DanhMucBoPhan.ToString(), idNgonNgu);
                    if (!string.IsNullOrEmpty(tenNhomXnB))
                        dtPrint.Rows[i]["TenBoPhan"] = tenBoPhanXNB;
                    var tenNguoiXacNhanB = TimNgonNguBienDich(nguoiXacNhan, EnumLoaiDanhMucNgonNgu.DanhMucBoPhan.ToString(), idNgonNgu);
                    if (!string.IsNullOrEmpty(tenNguoiXacNhanB))
                        dtPrint.Rows[i]["TenNguoiXacNhan"] = tenNguoiXacNhanB;
                }
            }
            return dtPrint;
        }
        private static DataTable DataNgonNgu = new DataTable();
        private DataTable GetData_NgonNgu()
        {
            if (DataNgonNgu == null)
                DataNgonNgu = _iSysConfig.Data_dm_ngonngu_danhmuc(string.Empty, string.Empty, string.Empty);
            return DataNgonNgu;
        }
        private string TimNgonNguBienDich(string cotMaDanhmuc, string idLoaiDanhMuc, string idNgonNgu)
        {
            var data = GetData_NgonNgu();
            if (data.Rows.Count > 0)
            {
                var dataFound = WorkingServices.SearchResult_OnDatatable(data, string.Format("IdDanhMuc = '{0}' and IdNgonNgu = '{1}' and MaDanhMuc = '{2}'", idLoaiDanhMuc, idNgonNgu, cotMaDanhmuc));
                if (dataFound.Rows.Count > 0)
                {
                    return dataFound.Rows[0]["NoiDung"].ToString().Trim();
                }
            }
            return string.Empty;
        }
        private bool ChoPhepUserKyTen(DataTable dataIn, string userKy)
        {
            var dataBSKyTen = dataIn.DefaultView.ToTable(true, "BSKyTen");
            if (dataBSKyTen.Rows.Count > 0)
            {
                bool daCoKyten = false;
                bool dungTen = false;
                foreach (DataRow dr in dataBSKyTen.Rows)
                {
                    if (!string.IsNullOrEmpty(dr["BSKyTen"].ToString()))
                    {
                        daCoKyten = true;
                        if (dr["BSKyTen"].ToString().Equals(userKy))
                        {
                            dungTen = true;
                            break;
                        }
                    }
                }
                if (dungTen || daCoKyten == false)
                    return true;
                else
                    return false;
            }
            return true;
        }
        //Xử lý ID file ký số 
        private bool XuLyIDFileKySo(DataTable dtPrint, string sampleId, string conditSomeTestPrint, bool signFirst
            , ref string tenFileHIS)
        {
            //Kiểm tra để lấy tên file ký số của các TEST đang ký
            var dtXnKySo = new DataTable();
            tenFileHIS = Guid.NewGuid().ToString();

            GetTenFileHIS(sampleId, conditSomeTestPrint, dtPrint, ref dtXnKySo, tenFileHIS);
            var dtTenFileHISUpdate = new DataTable();
            dtTenFileHISUpdate.Columns.Add("TenFileHIS", typeof(Guid));
            dtPrint = SetTenFileHisToDT(dtPrint, tenFileHIS, conditSomeTestPrint, ref dtTenFileHISUpdate);
            var dtTenFileHISs = WorkingServices.DataTable_DistinctValue(dtXnKySo, "TenFileHIS");
            dtTenFileHISs = WorkingServices.SearchResult_OnDatatable(dtTenFileHISs, "TenFileHIS IS NOT NULL");

            //Ký lần dau se ko có tenFileHISs
            if (dtTenFileHISs.Rows.Count <= 0)
            {
                signFirst = true;
                if (!dtTenFileHISs.Columns.Contains("TenFileHIS"))
                    dtTenFileHISs.Columns.Add("TenFileHIS", typeof(Guid));
                DataRow row1 = dtTenFileHISs.NewRow();
                dtTenFileHISs.Rows.Add(row1);
                dtTenFileHISs.Rows[0]["TenFileHIS"] = tenFileHIS;
            }
            //cập nhật TenFileHIS do có mã cha
            if (dtTenFileHISUpdate.Rows.Count > 0)
            {
                dtTenFileHISs.Merge(dtTenFileHISUpdate);
                dtTenFileHISs = WorkingServices.DataTable_DistinctValue(dtTenFileHISs, "TenFileHIS");
            }

            //lặp lại theo tenFileHIS để ký số
            foreach (DataRow rowTenFileHISs in dtTenFileHISs.Rows)
            {
                tenFileHIS = rowTenFileHISs["TenFileHIS"].ToString();
                var dtPrint_FileHIS = new DataTable();
                var dtXnKySoByTen = WorkingServices.SearchResult_OnDatatable(dtPrint, string.Format("TenFileHIS = '{0}'", tenFileHIS));
                //Nếu có chọn xn thì lấy tất cả xn đã ký trước ra
                if (dtXnKySoByTen.Rows.Count > 0)
                {
                    var lstMaXn = new List<string>();
                    foreach (DataRow item in dtXnKySoByTen.Rows)
                        lstMaXn.Add(item["MaXN"].ToString());
                    conditSomeTestPrint = Utilities.ConvertStrinArryToInClauseSQL(lstMaXn, true);
                }
                else
                    continue;

                if (!dtPrint.Columns.Contains("AnLogoISO"))
                    dtPrint.Columns.Add("AnLogoISO", typeof(bool));

                #region Lấy các xn được chọn ra
                if (!string.IsNullOrEmpty(conditSomeTestPrint))
                {
                    //Chổ này phải kiểm tra any vì có trường hợp xn tách ra in riêng nhưng chọn in lại là xn nghiệm khác 
                    //=> khi search sẽ ko có data
                    var dtSelect = dtPrint.Select($"MaXN in({conditSomeTestPrint})").AsEnumerable().OrderBy(o =>
                            NumberConverter.ToInt(o["ThuTuNhom"])).ThenBy(o => NumberConverter.ToInt(o["SapXep"]))
                        .ThenBy(o => StringConverter.ToString(o["MaXN"]));
                    if (dtSelect.Any())
                    {
                        dtPrint_FileHIS = dtSelect.CopyToDataTable();
                        //Lần đầu 
                        if (signFirst)
                        {
                            var lstMaXn = new List<string>();
                            foreach (DataRow item in dtPrint_FileHIS.Rows)
                                lstMaXn.Add(item["MaXN"].ToString());
                            conditSomeTestPrint = Utilities.ConvertStrinArryToInClauseSQL(lstMaXn, true);
                        }
                    }
                    else
                        return false;
                }

                #endregion
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sampleId"></param>
        /// <param name="conditSomeTestPrint">Các XN được chọn</param>
        /// <param name="dtPrint">Các XN đang in</param>
        /// <param name="dtXnKySo">Các XN đã ký số merge với các XN đang in</param>
        /// <returns></returns>
        private void GetTenFileHIS(string sampleId, string conditSomeTestPrint, DataTable dtPrint, ref DataTable dtXnKySo, string tenFileHIS)
        {
            ////var newGuidHIS = Guid.NewGuid().ToString();
            ////Lấy tên file HIS có sẵn, ko có thì new GUID, lấy các xn được Tick
            //dtXnKySo = _digSign.GetDataKySo(sampleId, conditSomeTestPrint, false);
            //if (dtXnKySo.Rows.Count > 0)
            //{
            //    var dt1 = WorkingServices.SearchResult_OnDatatable(dtXnKySo, string.Format("MaXN in ({0})", conditSomeTestPrint));
            //    var dtNotTenFileHIS = WorkingServices.SearchResult_OnDatatable(dt1, "TenFileHIS IS NOT NULL ");
            //    if (dtNotTenFileHIS.Rows.Count <= 0)
            //    {
            //        dtXnKySo = dt1;
            //        dtXnKySo = SetTenFileHisToDT(dtXnKySo, tenFileHIS);
            //        return;
            //    }

            //    //Chỗ này sẽ có TenFileHIS và Không có
            //    var dtTenFileHIS = WorkingServices.SearchResult_OnDatatable(dtXnKySo, string.Format("TenFileHIS IS NOT NULL OR MaXN IN ({0})", conditSomeTestPrint));
            //    if (dtTenFileHIS.Rows.Count <= 0)
            //    {
            //        dtXnKySo = dt1;
            //        dtXnKySo = SetTenFileHisToDT(dtXnKySo, tenFileHIS);
            //        return;
            //    }

            //    var listTenFileHIS = new List<string>();
            //    var arrTenFileHIS = string.Empty;
            //    var dtTenFileHIS1 = WorkingServices.DataTable_DistinctValue(dt1, new string[] { "TenFileHIS" });
            //    foreach (DataRow dr in dtTenFileHIS1.Rows)
            //        listTenFileHIS.Add(StringConverter.ToString(dr["TenFileHIS"]));
            //    //Convert thành VD 'SH','MD'
            //    arrTenFileHIS = Utilities.ConvertStrinArryToInClauseSQL(listTenFileHIS, true);
            //    if (string.IsNullOrEmpty(arrTenFileHIS))
            //    {
            //        arrTenFileHIS = string.Empty;
            //    }
            //    else if (arrTenFileHIS.Contains(','))
            //    {
            //        arrTenFileHIS = string.Format("TenFileHIS = {0}", arrTenFileHIS);
            //        arrTenFileHIS = arrTenFileHIS.Replace(",", " OR TenFileHIS = ");
            //        arrTenFileHIS += " OR ";
            //    }
            //    else
            //    {
            //        arrTenFileHIS = string.Format("TenFileHIS = {0}", arrTenFileHIS);
            //        arrTenFileHIS += " OR ";
            //    }

            //    //So sánh với các mã xn đang in và lấy ra TenFileHIS
            //    dtXnKySo = WorkingServices.SearchResult_OnDatatable(dtXnKySo, string.Format("{0} MaXN IN ({1})", arrTenFileHIS, conditSomeTestPrint));

            //    if (dtXnKySo.Rows.Count > 0)
            //        dtXnKySo = SetTenFileHisToDT(dtXnKySo, tenFileHIS);
            //}
        }

        private DataTable SetTenFileHisToDT(DataTable dtXnKySo, string tenFileHIS)
        {
            //Set Ten File HIS vào các row rỗng
            if (dtXnKySo == null || dtXnKySo.Rows.Count <= 0) return new DataTable();
            foreach (DataRow row in dtXnKySo.Rows)
            {
                if (string.IsNullOrEmpty(StringConverter.ToString(row["TenFileHIS"])))
                    row["TenFileHIS"] = tenFileHIS;
            }
            dtXnKySo.AcceptChanges();
            return dtXnKySo;
        }
        private DataTable SetTenFileHisToDT(DataTable dtPrint, string tenFileHIS, string conditSomeTestPrint, ref DataTable dtTenFileHISUpdate)
        {
            //Set Ten File HIS vào các row rỗng và có dieu kien xn chọn và co dieu kien mã cap tren
            if (dtPrint == null || dtPrint.Rows.Count <= 0) return new DataTable();
            //Tìm mã cấp trên cho xn
            var dtMaCapTren = (!string.IsNullOrEmpty(conditSomeTestPrint) ?
                WorkingServices.SearchResult_OnDatatable(dtPrint, string.Format("MaXN IN ('{0}') AND MaCapTren IS NOT NULL", conditSomeTestPrint.Replace("'", "").Replace(",", "','")))
                : WorkingServices.SearchResult_OnDatatable(dtPrint, string.Format("MaCapTren IS NOT NULL", conditSomeTestPrint.Replace("'", "").Replace(",", "','"))));
            if (dtMaCapTren.Rows.Count > 0)
            {
                dtMaCapTren = WorkingServices.DataTable_DistinctValue(dtMaCapTren, new string[] { "MaXN", "MaCapTren", "TenFileHIS" });
                //Lấy các mã cap trên ra, xong tìm lại người có mã cap tren đó mà TenPhieuHIS NOT NULL, 
                //Sau đó cập nhật lại cho Mã XN đang in
                foreach (DataRow row in dtMaCapTren.Rows)
                {
                    var maCapTren = row["MaCapTren"].ToString();
                    var maXN = row["MaXN"].ToString();

                    var dtUpdate = WorkingServices.SearchResult_OnDatatable(dtPrint, string.Format("MaCapTren = '{0}' AND TenFileHIS IS NOT NULL", maCapTren));
                    if (dtUpdate.Rows.Count <= 0) continue;
                    var tenFileHISUpdate = dtUpdate.Rows[0]["TenFileHIS"].ToString();
                    foreach (DataRow row1 in dtPrint.Rows)
                    {
                        if (string.IsNullOrEmpty(StringConverter.ToString(row1["TenFileHIS"]))
                                && maXN.Equals(StringConverter.ToString(row1["MaXN"]))
                                && maCapTren.Equals(StringConverter.ToString(row1["MaCapTren"])))
                        {
                            row1["TenFileHIS"] = tenFileHISUpdate;
                            DataRow rowUpdate = dtTenFileHISUpdate.NewRow();
                            rowUpdate["TenFileHIS"] = tenFileHISUpdate;
                            dtTenFileHISUpdate.Rows.Add(rowUpdate);
                        }
                    }
                }
                dtTenFileHISUpdate.AcceptChanges();
            }
            foreach (DataRow row in dtPrint.Rows)
            {
                if (string.IsNullOrEmpty(StringConverter.ToString(row["TenFileHIS"]))
                        && (string.IsNullOrEmpty(conditSomeTestPrint) || conditSomeTestPrint.Contains(StringConverter.ToString(row["MaXN"]))))
                    row["TenFileHIS"] = tenFileHIS;
            }
            dtPrint.AcceptChanges();
            return dtPrint;
        }
    }

}
