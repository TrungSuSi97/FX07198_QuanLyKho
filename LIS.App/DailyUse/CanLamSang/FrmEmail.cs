using TPH.LIS.BarcodePrinting;
using ImageMagick;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.App.AppCode.Patient;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.TestResult.Services;
using TPH.LIS.User.Enum;
using TPH.LIS.User.Services.UserManagement;
using static TPH.LIS.Common.ReportMicrobiologyTemplateConstant;
using System.Drawing;
using TPH.Report.Constants;
using DevExpress.XtraReports.UI;
using TPH.Report.Models;
using TPH.Report.Services;
using TPH.LIS.App.AppCode;
using TPH.Report.Services.Impl;
using System.Linq;

namespace TPH.LIS.App.ThucThi.CanLamSang
{
    public partial class frmEmail : FrmTemplate
    {
        private readonly IUserManagementService _userManagement = new UserManagementService();
        private C_Patient info = new C_Patient();
        private C_Patient_SieuAm sieuam = new C_Patient_SieuAm();
        private ITestResultService xetnghiem = new TestResultService();
        private readonly ISystemConfigService _isSysConfig = new SystemConfigService();
        private C_Patient_XQuang xquang = new C_Patient_XQuang();
        private C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();
        private DataTable dtService = new DataTable();
        private TestType.EnumTestType[] arrLoaiXetNghiem = new TestType.EnumTestType[] { TestType.EnumTestType.ThongThuong
            , TestType.EnumTestType.HuyetDo
            , TestType.EnumTestType.HIV };
        private bool _AllowEmail_XN = false,
            _AllowEmail_SieuAm = false,
            _AllowEmail_XQuang = false,
            _AllowEmail_NoiSoi = false;
        private readonly ITestResultService _xetnghiem = new TestResultService();
        private Image imgLogo;
        public frmEmail()
        {
            InitializeComponent();
        }

 

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadList();
        }

        private void frmEmail_Load(object sender, EventArgs e)
        {
            _AllowEmail_SieuAm = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenSieuAm, "SA8");
            _AllowEmail_XN = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, "XN9");
            _AllowEmail_XQuang = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXQuang, "XQ9");

            chkSieuAm.Enabled = _AllowEmail_SieuAm;
            chkXQuang.Enabled = _AllowEmail_XQuang;
            chkXetNghiem.Enabled = _AllowEmail_XN;

            _isSysConfig.Get_DoiTuongDichVu(cboService, "", ref dtService);
            Load_User();
            imgLogo = _isSysConfig.Load_Logo("XN");
        }

        private void btnSenMailWithService_Click(object sender, EventArgs e)
        {
            CheckToSend(false);
        }

        private void btnSendMailPatient_Click(object sender, EventArgs e)
        {
            CheckToSend(true);
        }
        private void Load_User()
        {
            cboNguoiKy.ComboBox.DataSource = _userManagement.GetUsersByConditions(string.Empty);
            cboNguoiKy.ComboBox.ValueMember = "MaNguoiDung";
            cboNguoiKy.ComboBox.DisplayMember = "TenNhanVien";
            cboNguoiKy.ComboBox.SelectedIndex = -1;
        }
        private void CheckToSend(bool _EmailForPatient)
        {
            if (dtgPatient.RowCount > 0)
            {
                btnView.Focus();
                if (cboNguoiKy.ComboBox.SelectedIndex < 0)
                {
                    CustomMessageBox.MSG_Information_OK("Hãy chọn người ký trước khi gửi mail!");
                    return;
                }
                var frmmes = new TPH.LIS.App.FrmMessageBox_Process();
                frmmes.Msg = "Đang gửi email.\nVui lòng chờ !";
                frmmes.lblMsg.Visible = true;

                var totalRows = dtgPatient.RowCount;
                for (var i = 0; i < totalRows; i++)
                {
                    if ((bool)dtgPatient["Chon", i].Value)
                    {
                        frmmes.Max++;
                    }
                }

                frmmes.proBar.Visible = true;
                frmmes.TopMost = true;
                frmmes.proBar.Step = 1;
                frmmes.Show();
                string _step = "";
                DataTable dtPatient = (DataTable)((BindingSource)dtgPatient.DataSource).DataSource;
                for (var i = 0; i < totalRows; i++)
                {
                    if ((bool)dtgPatient["Chon", i].Value)
                    {
                        _step = dtgPatient["TenBN", i].Value.ToString().Trim();
                        frmmes.Perform_Percent(_step);
                        EmailResult(dtPatient, i, _EmailForPatient);
                    }
                }
                frmmes.Close();
            }
        }

        private void EmailResult(DataTable dtInfo, int _index, bool _EmailForPatient)
        {
            DataTable dtPrint = new DataTable();
            string _MatiepNhan = dtInfo.Rows[_index]["MaTiepNhan"].ToString().Trim();

            var attachFile = XuatPDFVaHinhAnh(dtInfo, _index, _EmailForPatient);

            if (attachFile.Count > 0)
            {
                string email = (_EmailForPatient ? dtInfo.Rows[_index]["EmailBenhNhan"].ToString().Trim() : dtInfo.Rows[_index]["EmailDichVu"].ToString().Trim());
                if (SendMailHelper.SendEmail((int)ServiceType.ClsXetNghiem, _MatiepNhan, CommonAppVarsAndFunctions.sysConfig.EmailPdfPath, email, attachFile))
                {
                    info.CapNhat_GuiMail(_MatiepNhan, true);
                }
            }
            //if (chkSieuAm.Checked && chkSieuAm.Enabled)
            //{
            //    dtPrint = sieuam.DuLieuIn_SieuAm(dtInfo, _index, _EmailForPatient, "");

            //    if (dtPrint.Rows.Count > 0)
            //    {
            //        if (report.IsDisposed)
            //        {
            //            report = new FrmReport();
            //        }
            //        Reports.rpKQSieuAm rp = new Reports.rpKQSieuAm();
            //        if (report.Excute_Show_Print_Report(rp, dtPrint, "SA", false, true, false,
            //            false, "", false))
            //        {
            //            info.CapNhat_GuiMail(_MatiepNhan, true);
            //        }
            //    }
            //}

            //if (chkXQuang.Checked && chkXQuang.Enabled)
            //{
            //    dtPrint = xquang.DuLieuIn_XQuang(dtInfo, "", _index, _EmailForPatient);
            //    if (dtPrint.Rows.Count > 0)
            //    {
            //        if (dtPrint.Rows.Count > 0)
            //        {
            //            if (report.IsDisposed)
            //            {
            //                report = new FrmReport();
            //            }
            //            Reports.rpKQXQuang rp = new Reports.rpKQXQuang();
            //            if (report.Excute_Show_Print_Report(rp, dtPrint, "XQ", false, true, false,
            //                false, "", false))
            //            {
            //                info.CapNhat_GuiMail(_MatiepNhan, true);
            //            }
            //        }
            //    }
            //}
        }
        int _printCount = 0;
        private const int FoCusAfter = 300;
        int _countToFocus = 0;
        private PrintResultHelper _inKetQua = new PrintResultHelper();
        private Image reportLogo;
        private readonly IReportService _reportInfo = new ReportServiceImpl();
        private List<ReportModel> lstResultReportInfo = new List<ReportModel>();
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
        private List<string> XuatPDFVaHinhAnh(DataTable dtInfo, int _index, bool _EmailForPatient)
        {
            var attachFile = new List<string>();
            DataTable dtPrint = new DataTable();
            var objPrintInfo = new PrintResultInfo();
            objPrintInfo.matiepnhan = dtInfo.Rows[_index]["MaTiepNhan"].ToString().Trim();
            string CacMayChay = string.Empty;
            string tenLoaiMau = string.Empty;
            string tenBS = string.Empty;
            string tenKhoa = string.Empty;
            string ghiChuISO = string.Empty;
            string nguoiDuyetYKhoa = string.Empty;
            var arrLogo = GraphicSupport.ImageToByteArray(reportLogo);
            var dataReportType = _isSysConfig.DSMauPhieuIn_ThaoTac();
            if (chkXetNghiem.Checked && chkXetNghiem.Enabled)
            {
                objPrintInfo.reportType = new List<string>();
                if (dataReportType.Rows.Count > 0)
                {
                    foreach (DataRow drRpType in dataReportType.Rows)
                    {
                        objPrintInfo.reportType.Add(drRpType["IDMauKetQua"].ToString());
                    }
                }

                objPrintInfo.userSign = cboNguoiKy.ComboBox.SelectedValue.ToString();
                objPrintInfo.category = Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.NhomClsXetNghiem, true);
                objPrintInfo.arrLoaiXetNghiem = arrLoaiXetNghiem;
                objPrintInfo.pdfPathList = new List<string>(); ;
                objPrintInfo.exportPdf = true;
                objPrintInfo.chiInCoKetQua = true;
                objPrintInfo.title = true;
                var havePrint = _inKetQua.Check_PrintResult(ref _printCount, reportLogo, objPrintInfo);

                //xuất mail sinh học phân tử
                var dataChitietSHPT = _xetnghiem.DuLieuIn_XN(dtInfo, _index
                    , _EmailForPatient, cboNguoiKy.ComboBox.SelectedValue.ToString(), "", true, DateTime.Now
                    , CommonAppVarsAndFunctions.UserWorkPlace, string.Empty, false
                    , new TestType.EnumTestType[] { TestType.EnumTestType.SinhHocPhanTu }
                    , Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.NhomClsXetNghiem, true)
                    , CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemThoiGianInKetQuaLanDau, true, string.Empty, true, string.Empty, true);
                if (dataChitietSHPT.Rows.Count > 0)
                {
                    var resultReportInfo = new XtraReport();
                    var reportUse = new ReportModel();
                    string tenphieuIn = string.Empty;
                    if (!dataChitietSHPT.Columns.Contains("QRCode"))
                    {
                        dataChitietSHPT.Columns.Add("QRCode", typeof(byte[]));
                    }
                    var f = new FrmPreViewReport();
                    foreach (DataRow drCtSHPT in dataChitietSHPT.Rows)
                    {
                        if (dataChitietSHPT.Rows.Count > 0)
                        {
                            int idMauIn = int.Parse(drCtSHPT["MauInSHPT"].ToString());
                            var maxn = drCtSHPT["MaXn"].ToString();
                            drCtSHPT["ReportLogo"] = arrLogo;
                            if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_1)
                            {
                                f.SampleID = string.Format("Ketqua_{0}_{1}", ReportConstants.KetQuaXnSHPT_1, drCtSHPT["MaTiepNhan"].ToString().Trim());
                                reportUse = GetReportInList(ReportConstants.KetQuaXnSHPT_1);
                            }
                            else if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_2)
                            {
                                f.SampleID = string.Format("Ketqua_{0}_{1}", ReportConstants.KetQuaXnSHPT_2, drCtSHPT["MaTiepNhan"].ToString().Trim());
                                reportUse = GetReportInList(ReportConstants.KetQuaXnSHPT_2);
                            }
                            else if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_3)
                            {
                                f.SampleID = string.Format("Ketqua_{0}_{1}", ReportConstants.KetQuaXnSHPT_3, drCtSHPT["MaTiepNhan"].ToString().Trim());
                                reportUse = GetReportInList(ReportConstants.KetQuaXnSHPT_3);
                            }
                            else if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_4)
                            {
                                f.SampleID = string.Format("Ketqua_{0}_{1}", ReportConstants.KetQuaXnSHPT_4, drCtSHPT["MaTiepNhan"].ToString().Trim());
                                reportUse = GetReportInList(ReportConstants.KetQuaXnSHPT_4);
                            }

                            var printerName = string.Empty;
                            var dataChitietSub = new DataTable();
                            if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_2 || idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_4)
                            {
                                dataChitietSub = _xetnghiem.Data_SHPT_Gen_In(objPrintInfo.matiepnhan, maxn, string.Empty);
                                dataChitietSHPT.Columns.Add("TenTacNhan", typeof(string));
                                dataChitietSHPT.Columns.Add("KetQuaTacNhan", typeof(string));
                                dataChitietSHPT.Columns.Add("KetQuaDLTacNhan", typeof(string));
                                if (dataChitietSub.Rows.Count > 0)
                                {
                                    var dataTemp = dataChitietSHPT.Clone();
                                    foreach (DataRow drCT in dataChitietSub.Rows)
                                    {
                                        var dr = dataTemp.NewRow();
                                        foreach (DataColumn dtcM in dataTemp.Columns)
                                        {
                                            dr[dtcM.ColumnName] = drCtSHPT[dtcM.ColumnName];
                                        }
                                        dr["TenTacNhan"] = drCT["TenXN"];
                                        dr["KetQuaTacNhan"] = drCT["KetQua"];
                                        dr["KetQuaDLTacNhan"] = drCT["KetQuaDinhLuong"];
                                        dataTemp.Rows.Add(dr);
                                    }
                                    dataChitietSHPT = dataTemp;
                                }
                            }

                            resultReportInfo = _reportInfo.CreateReportFromStream(reportUse.ReportSuDung);
                            if (resultReportInfo == null)
                            {
                                CustomMessageBox.MSG_Information_OK("Report Sinh học phân tử chưa được khai báo.");
                            }
                            else
                            {
                                var drArr = new DataRow[] { drCtSHPT };

                                f.ShowReport(resultReportInfo, drArr.CopyToDataTable(), false, printerName, "XN", reportUse.TenDataset, reportUse.TenDatatable, string.Empty, true, attachFile);
                                info.CapNhat_GuiMail(objPrintInfo.matiepnhan, true);

                            }
                        }
                    }
                }
            }
            var fileJPG = new List<string>();
            if (attachFile.Count > 0)
            {
                foreach (var s in attachFile)
                {
                    fileJPG.AddRange(PdfExtension.ConvertPdfToImage(s, CommonAppVarsAndFunctions.sysConfig.EmailPdfPath, true, 450, MagickFormat.Jpeg));
                }
            }
            return fileJPG;
        }
        
        private void Check_GetInfoUser(DataTable dtPrint, ref string CacMayChay, ref string tenLoaiMau
            , ref string tenBS, ref string tenKhoa, ref string ghiChuISO, ref string nguoiDuyetYKhoa
            , ref string nguoiNhapKQ)
        {
            if (!CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemPhieuInTuTachPhieu
                  || CommonAppVarsAndFunctions.sysConfig.ClsXetNghiem_LoaiPhieuKetQua == EnumReportResultTemplatetype.MauKetQua_BYT)
            {
                CacMayChay = _xetnghiem.XuLytenMayChay(dtPrint);
                tenLoaiMau = _xetnghiem.XuLytenLoaiMau(dtPrint);
                tenBS = _xetnghiem.XuLyTenBS(dtPrint);
                tenKhoa = _xetnghiem.XuLyTenKhoa(dtPrint);
                ghiChuISO = _xetnghiem.XulyCommnetChung(dtPrint);
                nguoiDuyetYKhoa = _xetnghiem.XuLyNguoiDuyetYKhoa(dtPrint, false, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemDinhDangGhepDuyetKQ);
                nguoiNhapKQ = _xetnghiem.XuLyNguoiNhapKetQua(dtPrint, false, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemDinhDangGhepNhapKQ);
            }
        }
        private DataTable SetReportInfo(DataTable dtPrint, byte[] barcode, string CacMayChay
           , string tenBS, string tenKhoa, string nguoiDuyetYkhoa, byte[] imgLogo
           , string ghiChu, bool ghichuDuoiKetQua, string nguoinhapKetQua, string ghiChuISO)
        {
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
            }
            return dtPrint;
        }
        private void dtgPatient_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn cl in dtgPatient.Columns)
            {
                if (cl.Name == "Chon")
                {
                    cl.ReadOnly = false;
                }
                else
                {
                    cl.ReadOnly = true;
                }
            }
        }
        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            txtName.Focus();
            if (dtgPatient.RowCount > 0)
            {
                if (btnCheckAll.Text == "Chọn hết")
                {
                    for (int i = 0; i < dtgPatient.RowCount; i++)
                    {
                        dtgPatient["Chon", i].Value = true;
                    }
                    btnCheckAll.Text = "Bỏ chọn";
                }
                else
                {
                    for (int i = 0; i < dtgPatient.RowCount; i++)
                    {
                        dtgPatient["Chon", i].Value = false;
                    }
                    btnCheckAll.Text = "Chọn hết";
                }
            }
        }

        private void Load_NhomCD_TheoDV()
        {
            if (cboDichVuCLS.SelectedIndex != -1)
            {
                pnFunction.Enabled = true;
                string _IDDVCLS = cboDichVuCLS.SelectedValue.ToString().Trim();
                data.Load_Nhom_TheoDVCLS(cboNhomCLS, _IDDVCLS);
                Load_ChiDinhCLS();
            }
            else
            {
                pnFunction.Enabled = false;
            }
        }

        private void Load_ChiDinhCLS()
        {
            if (cboDichVuCLS.SelectedIndex != -1)
            {
                string _dv = cboDichVuCLS.SelectedValue.ToString().Trim();
                string _nhom = (cboNhomCLS.SelectedIndex == -1 ? "" : cboNhomCLS.SelectedValue.ToString().Trim());
                data.Load_ChiDinhCLS(cboCLS_ChiDinh, _dv, _nhom, "", "");
            }
        }

        private void cboDichVuCLS_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Load_NhomCD_TheoDV();
        }

        private void cboNhomCLS_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Load_ChiDinhCLS();
        }

        private void btnChangeSign_Click(object sender, EventArgs e)
        {
            frmIdentify frm = new frmIdentify();
            frm.pnMenu.Visible = true;
            frm.AdjustForm();
            frm.ShowDialog();
            var userId = frm.UserID;
            var userName = frm.UserName;

            if (!string.IsNullOrWhiteSpace(userId))
            {
                cboNguoiKy.ComboBox.SelectedValue = userId;
            }
        }

        private void txtSeq_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadList();
                e.Handled = true;
            }
        }

        private void cboDichVuCLS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Load_NhomCD_TheoDV();
                cboNhomCLS.Focus();
                return;
            }
        }

        private void cboNhomCLS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Load_ChiDinhCLS();
                cboCLS_ChiDinh.Focus();
                return;
            }
        }

        private void LoadList()
        {
            bool _isProfile = (txtProfile.Text == "*" ? true : false);
            string _TestID = (cboCLS_ChiDinh.SelectedIndex == -1 ? "" : cboCLS_ChiDinh.SelectedValue.ToString().Trim());
            string _Category = (cboNhomCLS.SelectedIndex == -1 ? "" : cboNhomCLS.SelectedValue.ToString().Trim());
            if (cboDichVuCLS.SelectedIndex == -1)
            {
                info.Search_Patient(dtpDateFrom.Value, dtpDateTo.Value,
                    (cboService.SelectedIndex != -1 ? cboService.SelectedValue.ToString().Trim() : ""), txtName.Text,
                    txtSeq.Text, dtgPatient, bvPatient, string.Empty, string.Empty, string.Empty, chkEmailOnly.Checked);
            }
            else
            {
                string _IDDichVuCLS = cboDichVuCLS.SelectedValue.ToString().Trim();

                if (_IDDichVuCLS.Equals(ServiceType.ClsXetNghiem.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    //ID = 1 tìm BN Xét Nghiệm

                    xetnghiem.Search_PatientXN(dtpDateFrom.Value, dtpDateTo.Value,
                        (cboService.SelectedIndex != -1 ? cboService.SelectedValue.ToString().Trim() : ""), txtName.Text,
                        txtSeq.Text, chkFullResult.Checked, chkPrinted.Checked, _TestID, _Category, _isProfile,
                        chkNhapTheoDanhSach.Checked, dtgPatient, bvPatient);
                }
                else if (_IDDichVuCLS.Equals(ServiceType.ClsSieuAm.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    //ID = 2 tìm BN Siêu Âm
                    C_Patient_SieuAm sieuam = new C_Patient_SieuAm();
                    sieuam.Search_PatientSieuAm(dtpDateFrom.Value, dtpDateTo.Value,
                        (cboService.SelectedIndex != -1 ? cboService.SelectedValue.ToString().Trim() : ""), txtName.Text,
                        txtSeq.Text, chkFullResult.Checked, chkPrinted.Checked, _TestID, _Category,
                        chkNhapTheoDanhSach.Checked, dtgPatient, bvPatient);
                }
                else if (_IDDichVuCLS.Equals(ServiceType.ClsXQuang.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    //ID = 2 tìm BN noi soi
                    C_Patient_NoiSoi noisoi = new C_Patient_NoiSoi();
                    noisoi.Search_PatientNoiSoi(dtpDateFrom.Value, dtpDateTo.Value,
                        (cboService.SelectedIndex != -1 ? cboService.SelectedValue.ToString().Trim() : ""), txtName.Text,
                        txtSeq.Text, chkFullResult.Checked, chkPrinted.Checked, _TestID, _Category,
                        chkNhapTheoDanhSach.Checked, dtgPatient, bvPatient);
                }
                else if (_IDDichVuCLS.Equals(ServiceType.ClsXQuang.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    //ID = 2 tìm BN xquang
                    C_Patient_XQuang xquang = new C_Patient_XQuang();
                    xquang.Search_PatientXQuang(dtpDateFrom.Value, dtpDateTo.Value,
                        (cboService.SelectedIndex != -1 ? cboService.SelectedValue.ToString().Trim() : ""), txtName.Text,
                        txtSeq.Text, chkFullResult.Checked, chkPrinted.Checked, _TestID, _Category,
                        chkNhapTheoDanhSach.Checked, dtgPatient, bvPatient);
                }
            }
            btnCheckAll.Text = "Chọn hết";
        }
    }
}
