using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.User.Enum;
using TPH.LIS.Configuration.Models;
using TPH.LIS.User.Constants;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common;
using TPH.LIS.App.AppCode.Patient;
using TPH.LIS.App.AppCode.DAO;
using TPH.LIS.Patient.Services;
using TPH.LIS.TestResult.Services;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using TPH.LIS.Log;
using Newtonsoft.Json;
using TPH.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Patient.Model;
using TPH.Report.Models;
using TPH.Report.Services;
using TPH.Report.Services.Impl;
using TPH.Report.Constants;
using DevExpress.XtraReports.UI;
using TPH.LIS.BarcodePrinting;

namespace TPH.LIS.App.AppCode
{
    public partial class ucChiTietChiDinh : UserControl
    {
        ITestResultService _iTestResult = new TestResultService();
        IMicrobilogyTestResultService _iBioticResult = new MicrobilogyTestResultService();
        IPatientInformationService _iPatient = new PatientInformationService();
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
        private readonly ISystemConfigService _iSysConfig = new SystemConfigService();
        private readonly IReportService _reportInfo = new ReportServiceImpl();

        private Image logo;
        private static ReportModel resultReportInfo;
        private static XtraReport ticketReport;

        private C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();
        private C_Patient_SieuAm p_sieuam = new C_Patient_SieuAm();
        private C_Patient_XQuang p_xquang = new C_Patient_XQuang();
        private C_Patient_NoiSoi p_noisoi = new C_Patient_NoiSoi();
        private C_Patient_KhamBenh p_khambenh = new C_Patient_KhamBenh();
        private C_Patient_DichVu_Khac p_dvkhac = new C_Patient_DichVu_Khac();
        private THUPHI_THUOC_DAL thuphiThuocDAL = new THUPHI_THUOC_DAL();

        List<SeviceOrderedInformation> lstChiDinh = new List<SeviceOrderedInformation>();
        public string CurrentMatiepNhan { get; set; }
        private bool hienThiXoaChiDinh = true;
        private bool hienThiChonChiDinh = true;
        private ServiceType[] currentArrServiceTypeList;

        public bool HienThiChonChiDinh
        {
            get
            {
                return hienThiChonChiDinh;
            }
            set
            {
                hienThiChonChiDinh = value;
                gvChiDinh.OptionsSelection.MultiSelect = hienThiChonChiDinh;
                Check_HienThiPanelFunction();
            }
        }

        public bool HienThiXoaChiDinh
        {
            get
            {
                return hienThiXoaChiDinh;
            }
            set
            {
                hienThiXoaChiDinh = value;
                btnXoaChiDinh.Visible = hienThiXoaChiDinh;
                Check_HienThiPanelFunction();
            }
        }

        public bool HienThiInBarcode
        {
            get
            {
                return hienThiInBarcode;
            }

            set
            {
                hienThiInBarcode = value;
                pnPrintBarcode.Visible = hienThiInBarcode;
                Check_HienThiPanelFunction();
            }
        }

        public bool HienThiKetQua
        {
            get
            {
                return colKetQua.Visible;
            }
            set
            {
                colKetQua.Visible = value;
            }
        }

        private bool coThuPhi = false;
        public bool CoThuPhi
        {
            get
            {
                return coThuPhi;
            }

            set
            {
                coThuPhi = value;
                GiaRieng.Visible = coThuPhi;
                colMaBienLai.Visible = coThuPhi;
                gvChiDinh.OptionsView.ShowFooter = coThuPhi;
            }
        }

        public double TotalMoney { get; set; }
        private void Check_HienThiPanelFunction()
        {
            if (!hienThiXoaChiDinh && pnPrintBarcode.Visible == false)
                pnFunction.Visible = false;
            else
                pnFunction.Visible = true;
        }
        private bool hienThiInBarcode = false;

        public ucChiTietChiDinh()
        {
            InitializeComponent();
            LabServices_Helper.SetControlColor(this);
        }
        private bool IsLoadConfig = false;
        private DM_MAYTINH_MAYIN objPrintInfo;
        private void Load_Config()
        {
            IsLoadConfig = true;
            logo = _iSysConfig.Load_Logo("BL");
            LabServices_Helper.LoadPrinterName(listPrinter, UserConstant.RegistryPrinterOrderedList, false);

            var data = _iSysConfig.Data_DanhSach_CauHinhMayInbarcode(Environment.MachineName, 0, 1);
            if (data.Rows.Count == 0)
            {
                var dr = data.NewRow();
                dr["IDMay"] = "0";
                dr["TenMay"] = CommonAppVarsAndFunctions.LangMessageConstant.Barcodetieuchuan;
                data.Rows.Add(dr);
                data.AcceptChanges();
            }
            var idMay = _registryExtension.ReadRegistry(CommonConstant.RegistryPrinterBarcode_OnGetSample);

            cboMayInTem1.DataSource = data;

            cboMayInTem1.ValueMember = "IDMay";
            cboMayInTem1.DisplayMember = "TenMay";
            cboMayInTem1.ColumnNames = "IDMay,TenMay";
            cboMayInTem1.ColumnWidths = "15,150";
            cboMayInTem1.SelectedValue = string.IsNullOrEmpty(idMay) ? "0" : idMay;
            if (data != null & data.Rows.Count == 1)
                cboMayInTem1.SelectedIndex = 0;
            cboMayInTem1.SelectedIndexChanged += CboMayInTem_SelectedIndexChanged;
            LoadPrintbarcodeConfig();
        }
        private void LoadPrintbarcodeConfig()
        {
            var idMayXN = 0;
            if (cboMayInTem1.SelectedIndex > -1)
                idMayXN = WorkingServices.ValueString_Int_Zero(cboMayInTem1.SelectedValue.ToString());

            _registryExtension.WriteRegistry(CommonConstant.RegistryPrinterBarcode_OnGetSample, idMayXN.ToString());
            objPrintInfo = _iSysConfig.Get_info_CauHinh_MaInbarcode(Environment.MachineName, idMayXN, 1);
        }
        public void Get_ChiTietChiDinh(string maTiepNhan, ServiceType[] arrServiceTypeList)
        {
            if (!IsLoadConfig)
                Load_Config();
            CurrentMatiepNhan = maTiepNhan;
            TotalMoney = 0;
            lstChiDinh = _iPatient.GetOrderServiceDetail(maTiepNhan, !chkXemThongSoXetNghiem.Checked, string.Empty, false, true);

            if (arrServiceTypeList != null)
            {
                if (arrServiceTypeList.Length > 0)
                {
                    currentArrServiceTypeList = arrServiceTypeList;

                    string idMaphanloai = string.Empty;
                    for (int i = 0; i < arrServiceTypeList.Length; i++)
                    {
                        idMaphanloai += (string.IsNullOrEmpty(idMaphanloai) ? "" : ";") + arrServiceTypeList[i].ToString();
                    }
                    lstChiDinh = lstChiDinh.Where(x => idMaphanloai.Contains(x.MaPhanLoai)).ToList();
                }
                TotalMoney = lstChiDinh.Where(x => x.DaThuTien == false).Sum(item => item.GiaRieng * item.SoLuong);
            }
            gcChiDinh.DataSource = lstChiDinh;

            gvChiDinh.ExpandAllGroups();
            if (hienThiInBarcode)
                txtSLTem.Text = _iTestResult.SoLuongMau(maTiepNhan, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemTinhSoTemTheoNhom).ToString("N0");
        }

        public void Get_ChiTietChiDinh_TheoBienLai(string maTiepNhan, ServiceType[] arrServiceTypeList, string IDBienLai)
        {
            if (!IsLoadConfig)
                Load_Config();
            CurrentMatiepNhan = maTiepNhan;
            lstChiDinh = _iPatient.GetOrderServiceDetail(maTiepNhan, !chkXemThongSoXetNghiem.Checked, IDBienLai, false, true);
            if (arrServiceTypeList != null)
            {
                if (arrServiceTypeList.Length > 0)
                {
                    currentArrServiceTypeList = arrServiceTypeList;

                    string idMaphanloai = string.Empty;
                    for (int i = 0; i < arrServiceTypeList.Length; i++)
                    {
                        idMaphanloai += (string.IsNullOrEmpty(idMaphanloai) ? "" : ";") + arrServiceTypeList[i].ToString();
                    }
                    lstChiDinh = lstChiDinh.Where(x => idMaphanloai.Contains(x.MaPhanLoai)).ToList();
                }
            }
            gcChiDinh.DataSource = lstChiDinh;
            gvChiDinh.ExpandAllGroups();
        }

        public void SetNullDataGridControl()
        {
            gcChiDinh.DataSource = null;
        }

        public bool XoaChiDinh(bool question, bool autoSelect)
        {
            if (autoSelect)
                gvChiDinh.SelectAll();

            int total = 0, uncheck = 0;
            string matiepnhan = string.Empty;
            string _selected_Code = string.Empty;

            string _DV_CLS = string.Empty;
            string _maChidinh = string.Empty;
            string _tenChidinh = string.Empty;
            var data = _iPatient.Data_ChiDinhDaNhanMau(matiepnhan);
            var lstDaNhan = data.AsEnumerable().Select(x => x["MaXN"].ToString().Trim()).ToList();
            //Lấy danh sách mẫu đã lấy để đảm bảo ko bị sai
            var dataLayMau = _iPatient.Data_ChiDinhDaLayMau(matiepnhan);
            var lstDaLayMau = data.AsEnumerable().Select(x => x["MaXN"].ToString().Trim()).ToList();
            foreach (int i in gvChiDinh.GetSelectedRows())
            {
                _DV_CLS = (string)gvChiDinh.GetRowCellValue(i, MaPhanLoai);
                _maChidinh = (string)gvChiDinh.GetRowCellValue(i, MaChiDinh);
                _tenChidinh = (string)gvChiDinh.GetRowCellValue(i, TenChiDinh);
                matiepnhan = (string)gvChiDinh.GetRowCellValue(i, colMaTiepNhan);
                if (!string.IsNullOrEmpty(_DV_CLS))
                {
                    if (_DV_CLS.Equals(ServiceType.ClsXetNghiem.ToString()))
                    {
                        if (!ConfigurationDetail.CheckFunction(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, UserConstant.PermissionReceptionDeleteOrderAndPatientWithResult))
                        {
                            if (_iTestResult.Check_HaveResult_XN(matiepnhan, _maChidinh))
                            {
                                CustomMessageBox.MSG_Information_OK(string.Format("Chỉ định '{0}' đã có KQ.\nBạn không thể xóa chỉ định này!", _tenChidinh));
                                gvChiDinh.UnselectRow(i);
                                uncheck++;
                            }
                            else if (!string.IsNullOrEmpty(gvChiDinh.GetRowCellValue(i, colRSoPhieuYeuCau) == null ? string.Empty : gvChiDinh.GetRowCellValue(i, colRSoPhieuYeuCau).ToString()))
                            {
                                CustomMessageBox.MSG_Information_OK(string.Format("Chỉ định '{0}' tiếp nhận từ HIS.\nChỉ định phải được hủy từ form tiếp nhận từ HIS.", _tenChidinh));
                                gvChiDinh.UnselectRow(i);
                                uncheck++;
                            }
                            else if (lstDaNhan.Contains(_maChidinh.Trim()))
                            {
                                CustomMessageBox.MSG_Error_OK(string.Format("Chỉ định '{0}' đã nhận mẫu.\nBạn không thể xóa!", _maChidinh));
                                gvChiDinh.UnselectRow(i);
                                uncheck++;
                            }
                            else if (lstDaLayMau.Contains(_maChidinh.Trim()))
                            {
                                CustomMessageBox.MSG_Error_OK(string.Format("Chỉ định '{0}' đã lấy mẫu.\nBạn không thể xóa!", _maChidinh));
                                gvChiDinh.UnselectRow(i);
                                uncheck++;
                            }
                        }
                    }
                }
                _selected_Code += (string)gvChiDinh.GetRowCellValue(i, MaChiDinh) + ";";
                total++;
            }
            if (gvChiDinh.GetSelectedRows().Count() > 0)
            {
                var allow = !question;
                if (!allow)
                    allow = CustomMessageBox.MSG_Question_YesNo_GetYes(CommonAppVarsAndFunctions.LangMessageConstant.DeleteOrderQuestion);

                if (allow)
                {
                    string _isPaid_String = "";
                    bool _isPaid = false;
                    string _profileID = string.Empty;
                    int loaiXetNghiem = -1;
                    foreach (int i in gvChiDinh.GetSelectedRows())
                    {
                        _DV_CLS = (string)gvChiDinh.GetRowCellValue(i, MaPhanLoai);
                        _isPaid = gvChiDinh.GetRowCellValue(i, DaThuTien) == null ? false : (bool)gvChiDinh.GetRowCellValue(i, DaThuTien);

                        if (!_isPaid)
                        {
                            _profileID = gvChiDinh.GetRowCellValue(i, MaProfile) != null ? gvChiDinh.GetRowCellValue(i, MaProfile).ToString() : "";
                            _maChidinh = gvChiDinh.GetRowCellValue(i, MaChiDinh) != null ? gvChiDinh.GetRowCellValue(i, MaChiDinh).ToString() : "";
                            _tenChidinh = gvChiDinh.GetRowCellValue(i, TenChiDinh) != null ? gvChiDinh.GetRowCellValue(i, TenChiDinh).ToString() : "";
                            loaiXetNghiem = gvChiDinh.GetRowCellValue(i, colLoaiXetNghiem) != null ? int.Parse(gvChiDinh.GetRowCellValue(i, colLoaiXetNghiem).ToString()) : -1;
                            if (!string.IsNullOrEmpty(_DV_CLS))
                            {
                                var LoaiXetNghiem = gvChiDinh.GetRowCellValue(i, colLoaiXetNghiem).ToString();
                                var enumLoaiXn = (TestType.EnumTestType)Enum.Parse(typeof(TestType.EnumTestType), LoaiXetNghiem);
                                if (_DV_CLS.Equals(ServiceType.ClsXetNghiem.ToString()))
                                {
                                    if (loaiXetNghiem != 12
                                        && loaiXetNghiem != 13
                                        && loaiXetNghiem != 14
                                        && loaiXetNghiem != 15
                                        && loaiXetNghiem != 16 && loaiXetNghiem != (int)TestType.EnumTestType.ChiDinhTruyenMau)
                                    {
                                        if ((bool)gvChiDinh.GetRowCellValue(i, ChiDinhCha))
                                        {
                                            if (!_iTestResult.Check_HaveResult_For_XNChinh(matiepnhan, _profileID))
                                            {
                                                _iTestResult.Delete_ChiDinhCLS_XN(matiepnhan, _maChidinh, _profileID, CommonAppVarsAndFunctions.UserID, false);
                                            }
                                            else
                                            {
                                                if (CustomMessageBox.MSG_Question_YesNoCancel_GetYes(string.Format("Xét nghiệm: \"{0}\" đã có kết quả!\nBạn chắc chắn muốn xóa.", _tenChidinh)))
                                                {
                                                    _iTestResult.Delete_ChiDinhCLS_XN(matiepnhan, _maChidinh, string.Empty, CommonAppVarsAndFunctions.UserID, false);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            _iTestResult.Delete_ChiDinhCLS_XN(matiepnhan, _maChidinh, string.Empty, CommonAppVarsAndFunctions.UserID, false);
                                        }
                                    }
                                    else if (enumLoaiXn == TestType.EnumTestType.ChiDinhTruyenMau)
                                    {
                                        _iPatient.DeleteOrderOfElement(matiepnhan, _maChidinh, CommonAppVarsAndFunctions.UserID, Environment.MachineName);
                                    }
                                    else
                                    {
                                        _iBioticResult.Delete_ketqua_cls_xetnghiem_visinh(matiepnhan, _maChidinh);
                                    }
                                }
                                else if (_DV_CLS.Equals(ServiceType.ClsSieuAm.ToString()))
                                {
                                    p_sieuam.Delete_ChiDinhCLS_SieuAm(matiepnhan, _maChidinh);
                                }
                                else if (_DV_CLS.Equals(ServiceType.ClsXQuang.ToString()))
                                {
                                    p_xquang.Delete_ChiDinhCLS_XQuang(matiepnhan, _maChidinh);
                                }
                                else if (_DV_CLS.Equals(ServiceType.ClsNoiSoi.ToString()))
                                {
                                    p_noisoi.Delete_ChiDinhCLS_NoiSoi(matiepnhan, _maChidinh);
                                }
                                else if (_DV_CLS.Equals(ServiceType.KhamBenh.ToString()))
                                {
                                    p_khambenh.Delete_ChiDinh_KhamBenh(matiepnhan, "KB", _maChidinh);
                                }
                                else if (_DV_CLS.Equals(ServiceType.Duoc.ToString()))
                                {
                                    thuphiThuocDAL.Delete_THUPHI_THUOC(new PropertiesMember.THUPHI_THUOC(string.Empty,
                                        string.Empty, false, false, 0,
                                        string.Empty, string.Empty, string.Empty, string.Empty, _maChidinh,
                                        matiepnhan, string.Empty, string.Empty, 0, 0, 0, string.Empty,
                                        CommonAppVarsAndFunctions.ServerTime, 0, string.Empty, string.Empty, false));
                                }
                            }
                        }
                        else
                        {
                            _isPaid_String += string.IsNullOrWhiteSpace(_isPaid_String)
                                ? string.Empty
                                : Environment.NewLine;
                            _isPaid_String += "- " + _tenChidinh;
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(_isPaid_String))
                    {
                        CustomMessageBox.MSG_Information_OK("Các chỉ định đã thu phí không thể xóa:" +
                                                            Environment.NewLine +
                                                            _isPaid_String);
                        return false;
                    }
                    Get_ChiTietChiDinh(CurrentMatiepNhan, currentArrServiceTypeList);
                }
            }
            return gvChiDinh.RowCount == 0;
        }
        private void btnXoaChiDinh_Click(object sender, EventArgs e)
        {
            XoaChiDinh(true, false);
        }

        private void chkXemThongSoXetNghiem_CheckedChanged(object sender, EventArgs e)
        {
            Get_ChiTietChiDinh(CurrentMatiepNhan, currentArrServiceTypeList);
            if (chkXemThongSoXetNghiem.Checked)
                chkXemThongSoXetNghiem.BackColor = Color.Yellow;
            else
                chkXemThongSoXetNghiem.BackColor = Color.Empty;
        }

        private void btnInTemXN_Click(object sender, EventArgs e)
        {
            Inbarcode(false);
        }

        private void CboMayInTem_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPrintbarcodeConfig();
        }
        private void Inbarcode(bool isRePrint)
        {
            var bnInfo = _iPatient.Get_Info_BenhNhan_TiepNhan(CurrentMatiepNhan, new string[] { });
            List<BENHNHAN_TIEPNHAN> lstBnInfo = new List<LIS.Patient.Model.BENHNHAN_TIEPNHAN>() { bnInfo };
            List<KETQUA_CLS_XETNGHIEM> objXetNghiem = null;
            if (objPrintInfo != null)
            {
                if (objPrintInfo.Giaothuc != null)
                {
                    if (objPrintInfo.Giaothuc.Equals(PrintingSystemProtocolList.BCRoboMT))
                    {
                        WriteLog.LogService.RecordLogFile(LogFile.ActionLog, " InBarcode : BCRoboMT", this.Text);
                        var lstMaTiepNhan = new List<string>();
                        foreach (var obj in lstBnInfo)
                        {
                            lstMaTiepNhan.Add(obj.Matiepnhan);
                        }
                        var objPrint = lstBnInfo.First();
                        WriteLog.LogService.RecordLogFile(LogFile.ActionLog,
                            string.Format(
                                " InBarcode : BCRoboMT - Lấy danh sách chỉ dinh theo số hồ sơ:{0}{1}Các số code:{2} ",
                                objPrint.Bn_id, Environment.NewLine, lstMaTiepNhan), this.Text);
                        objXetNghiem = _iTestResult.lstXetnghiem(lstMaTiepNhan, string.Empty);
                        WriteLog.LogService.RecordLogFile(LogFile.ActionLog,
                            string.Format(" InBarcode : BCRoboMT - objXetNghiem -> Số record:{0}", objXetNghiem.Count),
                            this.Text);
                        PrintBarcodeHelper.PrintBarcode(new List<BENHNHAN_TIEPNHAN> { objPrint }, (isRePrint ? 3 : 1), objPrintInfo, isRePrint, null, objXetNghiem);
                        return;
                    }
                }
            }

            WriteLog.LogService.RecordLogFile(LogFile.ActionLog,
                string.Format(" InBarcode : {0} - objXetNghiem -> Số record:{1}",
                    objPrintInfo == null
                        ? "Normal"
                        : (objPrintInfo.Giaothuc == null ? "Normal" : objPrintInfo.Giaothuc),
                    objXetNghiem == null ? lstBnInfo.Count : objXetNghiem.Count), this.Text);
            PrintBarcodeHelper.PrintBarcode(lstBnInfo, (isRePrint ? 3 : 1), objPrintInfo, isRePrint, null, objXetNghiem, null, null);
        }

        private void gvChiDinh_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                if (e.Column.FieldName.Equals(colKetQua.FieldName, StringComparison.OrdinalIgnoreCase))
                {
                    if (view.GetRowCellValue(e.RowHandle, view.Columns[colFlat.FieldName]) != null)
                    {
                        int flag = (int)view.GetRowCellValue(e.RowHandle, view.Columns[colFlat.FieldName]);
                        FontStyle fs = new FontStyle();
                        var color = _MauKQ(flag, ref fs);
                        Font font = new Font("Arial", 10, fs);
                        e.Appearance.Font = font;
                        e.Appearance.ForeColor = color;

                        string kq = view.GetRowCellValue(e.RowHandle, view.Columns[colKetQua.FieldName]).ToString();
                        if (LabServices_Helper.IsNumeric(kq))
                        {
                            e.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
                        }
                    }
                }
            }
        }
        private Color _MauKQ(int co, ref FontStyle fstyle)
        {
            //1: Bình thường; 2: Dưới ngưỡng dưới ; 3: Ngưỡng trên
            switch (co)
            {
                case 2:
                    fstyle = FontStyle.Bold;
                    return Color.Blue;

                case 3:
                    fstyle = FontStyle.Bold;
                    return Color.Red;

                default:
                    fstyle = FontStyle.Regular;
                    return Color.Black;
            }
        }

        private void btnInThemBarcode_Click(object sender, EventArgs e)
        {
            Inbarcode(true);
        }
        private void XoaChiDinhTrenLabIMSWeb(string maXN, string maTiepNhan)
        {
            //if (CommonAppVarsAndFunctions.sysConfig.TPHLabIMSWeb_TuDongGuiChiDinh)
            //{               

            //    var donViNhanMau = JsonConvert.DeserializeObject<dynamic>(labIMSWebConfigInfo.UserName);
            //    var xnDetail = new Dictionary<string, object>
            //                {
            //                    {"ReceptionCodeByInputBranch", maTiepNhan},
            //                    {"InputByBranch", donViNhanMau.Value},
            //                    {"TestingCode", maXN},
            //                };

            //    _iHISService.ThemChiDinh(labIMSWebConfigInfo, xnDetail);
            //}
        }

        private void btnInDanhSachChiDinh_Click(object sender, EventArgs e)
        {
            if (gvChiDinh.RowCount > 0)
            {
                var dataPrint = WorkingServices.ConvertToDataTable(lstChiDinh);
                if (dataPrint.Rows.Count > 0)
                {
                    if (!dataPrint.Columns.Contains("Logo"))
                    {
                        dataPrint.Columns.Add("Logo", typeof(byte[]));
                    }
                    var logoAdd = GraphicSupport.ImageToByteArray(logo);
                    foreach (DataRow dr in dataPrint.Rows)
                    {
                        dr["Logo"] = logoAdd;
                    }
                    if (resultReportInfo == null)
                    {
                        resultReportInfo = _reportInfo.Info_Report(ReportConstants.DanhSachChiDinh);
                    }

                    if (resultReportInfo.ReportSuDung == null)
                        return;

                    ticketReport = _reportInfo.CreateReportFromStream(resultReportInfo.ReportSuDung);
                    var crv = new FrmPreViewReport
                    {
                        SampleID = string.Format("DanhSachChiDinh_{0}", dataPrint.Rows[0]["MaTiepNhan"].ToString().Trim()),
                        TenBN = dataPrint.Rows[0]["TenBenhNhan"].ToString().Trim()
                    };
                    var printerName = string.Empty;
                    if (listPrinter.Items.Count > 0)
                    {
                        if (listPrinter.SelectedIndex == -1)
                        {
                            listPrinter.SelectedIndex = 0;
                        }
                        printerName = listPrinter.SelectedItem.ToString();
                    }
                    ticketReport = _reportInfo.CreateReportFromStream(resultReportInfo.ReportSuDung);
                    var havePrint = crv.ShowReport(ticketReport, dataPrint, true, printerName, "BL", resultReportInfo.TenDataset, resultReportInfo.TenDatatable, isInChiDinh: true);
                }
            }
        }

        private void btnChonMayIn_Click(object sender, EventArgs e)
        {
            listPrinter.Visible = !listPrinter.Visible;
        }
  
        private void listPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPrinter.Items.Count > 0)
            {
                _registryExtension.WriteRegistry(
                    UserConstant.RegistryPrinterOrderedList,
                    listPrinter.SelectedItem.ToString());
            }
        }
    }
}
