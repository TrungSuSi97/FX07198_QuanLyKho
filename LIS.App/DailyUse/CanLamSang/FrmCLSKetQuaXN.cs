using System;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using TPH.Common.Extensions;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.User.Constants;
using DevExpress.XtraGrid.Views.Grid;
using TPH.Lab.Middleware.LISConnect.Services;
using TPH.LIS.Common;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.TestResult.Services;
using TPH.LIS.Configuration.Models;
using System.Collections.Generic;
using TPH.Data.HIS.Models;
using TPH.LIS.User.Services.UserManagement;
using DevExpress.XtraEditors;
using TPH.LIS.Analyzer.Services;
using TPH.LIS.ResultConvert.Service;
using TPH.LIS.Patient.Services;
using System.Threading.Tasks;
using TPH.Controls;
using TPH.Language;

namespace TPH.LIS.App.ThucThi.CanLamSang
{
    public partial class frmCLSKetQuaXN : FrmTemplate
    {
        private readonly ITestResultService _xetnghiem = new TestResultService();
        private readonly IPatientInformationService _iPatient = new PatientInformationService();
        private readonly ISystemConfigService _isSysConfig = new SystemConfigService();
        private readonly IConnectHISService _iHisData = new ConnectHISService();
        private readonly IAnalyzerResultService _iAnalyzerResult = new AnalyzerResultService();
        private readonly IAnalyzerConfigService _iAnalyzerConfig = new AnalyzerConfigService();
        private readonly C_Config _config = new C_Config();
        private readonly IResultConvertService _iResultConvert = new ResultConvertService();
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
        private readonly TestType.EnumTestType[] _arrLoaiXetNghiem = new TestType.EnumTestType[] {
            TestType.EnumTestType.ThongThuong
            , TestType.EnumTestType.ViSinh_TQ
            , TestType.EnumTestType.HuyetDo
            , TestType.EnumTestType.HIV
            , TestType.EnumTestType.HIVKD
            , TestType.EnumTestType.HIVSP
            , TestType.EnumTestType.TienSan
        , TestType.EnumTestType.XNCoombs, TestType.EnumTestType.XNNacl9
            , TestType.EnumTestType.XNCoombs_2, TestType.EnumTestType.XNNacl9_2
        , TestType.EnumTestType.XNTuiMau, TestType.EnumTestType.XetNghiemTruyenMau
        ,TestType.EnumTestType.XNABONguoiNhanMau,TestType.EnumTestType.XNRhNguoiNhanMau};
        private DataTable _dtPatient = new DataTable();
        private DataTable _dtClsKetQua = new DataTable();
        private DataTable _dtCaldulate = new DataTable();
        private HisConnection _hisInfo;
        private bool _allowEdit;
        private bool _allowInsert;
        private bool _allowChangeAnalyzer;
        private bool _allowEditResulFromOtherUser;
        private bool _loading;
        private string _currentValue = "";
        string _log = "";
        private bool _gridWorking;
        private int FoCusAfter = 90;
        int _countToFocus = 0;
        int _printCount = 0;
        private DataTable _dataGhiChuTuDong = new DataTable();
        List<CAUHINH_MAYINKETQUA> _listCauHinhMayIn;
        public DateTime DtDateInG { get; set; }
        public string MatiepNhanG { get; set; }
        private Image reportLogo;
        public frmCLSKetQuaXN()
        {
            MatiepNhanG = string.Empty;
            DtDateInG = new DateTime();
            InitializeComponent();
            tabKetQuaBenhNhan.BackColor = CommonAppColors.ColorMainAppFormColor;
            tabKetQuaBenhNhan.AppearancePage.PageClient.BackColor = CommonAppColors.ColorMainAppFormColor;
            tabKetQuaBenhNhan.AppearancePage.Header.BackColor = CommonAppColors.ColorMainAppFormColor;

            //tabKetQuaBenhNhan.AppearancePage.Header.BackColor2 = Color.WhiteSmoke;
            tabKetQuaBenhNhan.AppearancePage.Header.ForeColor = CommonAppColors.ColorButtonTextForceColor;
            tabKetQuaBenhNhan.AppearancePage.HeaderActive.ForeColor = CommonAppColors.ColorTextSelected;
            tabKetQuaBenhNhan.AppearancePage.HeaderActive.BackColor = CommonAppColors.ColorTabActiveBackColor;
            // tabKetQuaBenhNhan.AppearancePage.HeaderActive.BackColor2 = Color.WhiteSmoke;
            pnChucNang.BackColor = CommonAppColors.MenuItemPrimaryColor;
            //lblKyLanhDao.BackColor = CommonAppColors.ColorMainAppFormColor;
            //lblNgayIn.BackColor = lblPhieuIn.BackColor = CommonAppColors.ColorMainAppFormColor;
            //lblTruongKhoa.BackColor = CommonAppColors.ColorMainAppFormColor;
            pnSignature.BackColor = CommonAppColors.MenuItemPrimaryColor;
        }

        private void Load_TiepNhan()
        {
            _countToFocus = 0;
            ucDanhSachBenhNhanXN1.Load_DSBenhNhan();
            _countToFocus = 0;
        }

        #region In kết quả

        private void PrintResultFromAuto(string matiepnhan, bool title
            , string userSign, bool showMess
            , bool inCoQuiDoi, string printerName, bool inMau
            , bool chiInCoKetQua, DataTable dataReportType, ToolStripProgressBar progressPrint, bool userValidTheoUserDangNhap)
        {
            //bool coDuyet = false;
            //var category = Utilities.ConvertStrinArryToInClauseSQLForSplitString(CommonAppVarsAndFunctions.NhomClsXetNghiem.ToList());
            //var boPhan = string.Empty;// chlBoPhan.AllItemList("MaBoPhan");
            //var reporttype = string.Empty;//chlDanhSachPhieuKetQua.AllItemList("IDMauKetQua");
            //var havePrint = _inKetQua.Check_PrintResult(ref _printCount, ref _countToFocus, matiepnhan, true, title, true
            //     , dataReportType, userSign, reporttype, showMess, inCoQuiDoi
            //     , string.Empty, category, boPhan, printerName, inMau
            //     , null
            //     , false, chiInCoKetQua, _arrLoaiXetNghiem
            //     , _listCauHinhMayIn, progressPrint, reportLogo, userValidTheoUserDangNhap, string.Empty, ref coDuyet);
            ////Đưa vào danh sách upload khi chỉ cấu hình Upload khi duyệt
            //if (havePrint)
            //{
            //    if ((CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemUploadDaIn && !CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemUploadDaDuyet)
            //        || (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemUploadDaDuyet && CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemUploadDaIn && coDuyet)
            //        )
            //        _iPatient.DuaVaoDanhSachUploadHIS(matiepnhan);
            //}
        }
        #endregion
        Panel pnManche = new Panel();
        private void frmCLSKetQuaXN_Load(object sender, EventArgs e)
        {
            ucDanhSachBenhNhanXN1.ShowTuyChon = true;
            pnManche.Size = this.Size;
            pnManche.BackColor = this.BackColor;
            pnManche.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            xtabKetQua.Controls.Add(pnManche);
            pnManche.BringToFront();
            FoCusAfter = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemTuFocusBarcode;
          
            //tabKetQuaBenhNhan.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            LoadConfig();
            HightLightButton(btnKQXetNghiem);

        }
        private void frmCLSKetQuaXN_Shown(object sender, EventArgs e)
        {
            splitContainer1.SplitterPosition = btnCloseSetting.Location.X + btnCloseSetting.Width + 3;
            analyzerResult1.ReCalculateSpliter();
            ucKiemSoatChiDinhChayMay.ReCalculateSpliter();
            ucDanhSachBenhNhanXN1.Load_DSBenhNhan();
            if (!string.IsNullOrWhiteSpace(MatiepNhanG))
            {
                ucDanhSachBenhNhanXN1.NgayNhanMau = DtDateInG;
                ucDanhSachBenhNhanXN1.Barcode = MatiepNhanG;
                Load_TiepNhan();
            }
            else
            {
                Load_TiepNhan();
            }
            if (!CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemHienTuyChon)
            {
                pnSignature.Tag = pnSignature.Height;
                pnSignature.Height = 0;
            }
        }
        private void LoadConfig()
        {
            CustomMessageBox.ShowAlert(CommonAppVarsAndFunctions.LangMessageConstant.Dangnapcauhinhhethong, 8);
            chkXacNhanKhiSuaKetQua.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryConfirmBeforeUpdateResult).Equals("1");
            dtpNgayInKQ.Value = CommonAppVarsAndFunctions.ServerTime;
            dtpNgayInKQ.Checked = false;
            lblNgayIn.Visible = dtpNgayInKQ.Visible = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemChongioKyTQ;
            ucPatientInformation1.dtpDateIn.Value = CommonAppVarsAndFunctions.ServerTime;
            ucPatientInformation1.Load_DanhMucCauHinh();
            Load_DanhSachPhieuInChon();
            ucKetQuaThuongQuy1._arrLoaiXetNghiem = _arrLoaiXetNghiem;
            ucKetQuaThuongQuy1.CheDoHienThi = 0;
            ucKetQuaThuongQuy1.Load_Config();
            ucKetQuaThuongQuy1.DataGridview_KetQua_FocusColumnChanged += UcKetQuaThuongQuy1_DataGridview_KetQua_FocusColumnChanged;
            ucKetQuaThuongQuy1.DataGridview_KetQua_FocusRowChanged += UcKetQuaThuongQuy1_DataGridview_KetQua_FocusRowChanged;
            ucKetQuaThuongQuy1.XacNhanSuaKetQua = chkXacNhanKhiSuaKetQua.Checked;

            _listCauHinhMayIn = _isSysConfig.ListCauHinhMayIn(Environment.MachineName);
            chkPrintTitle.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryPrintTitle).Equals("1");
            chkInCoQuiDoi.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryPrintCoQuiDoi).Equals("1");
         

            chkAutoCalculateResult.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryAutoCalculateResult).Equals("1");
            chkChiInCoKetQua.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryPrintTestWithResult).Equals("1");
            if (CommonAppVarsAndFunctions.sysConfig.ChonInKhiDuyet)
            {
                chkInKhiXacNhan.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryPrintWhenValid).Equals("1"); ;
                chkInKhiXacNhan.CheckedChanged += ChkInKhiXacNhan_CheckedChanged;
            }
            else
                chkInKhiXacNhan.Visible = false;



            //trong hàm check enable này có kiểm tra ---> sẽ gỡ check tính tự động nếu không có quyền.
            Check_EnableControl();
            //Load user ký tên
            IUserManagementService userManagement = new UserManagementService();
            var currentUserSign = CommonAppVarsAndFunctions.TempSignIdXetNghiem;

            var dataKyten = userManagement.GetUsersKyTenCoPhanQuyen("", Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.BoPhanClsXetNghiem, true), true);
            DataRow dr = dataKyten.NewRow();
            dr["MaNguoiDung"] = string.Empty;
            dr["TenNhanVien"] = "---None---";
            dataKyten.Rows.InsertAt(dr, 0);
            ucSearchLookupEditor_KyTentruongKhoa.Load_TruongKhoa();
            ucSearchLookupEditor_KyTenlanhdao.Load_LanhDao();
            lblKyLanhDao.Visible = ucSearchLookupEditor_KyTenlanhdao.Visible = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemSuDungChuKyLanhDao;
            if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemSuDungChuKyLanhDao)
                ucSearchLookupEditor_KyTenlanhdao.SelectedValue = null;
            ucSearchLookupEditor_KyTentruongKhoa.SelectedValue = CommonAppVarsAndFunctions.UserID;

            _dtCaldulate = _isSysConfig.GetTestCaculate(string.Empty);

            bool showMiddelware = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemLoaiKetNoiMay == EnumLoaiKetNoiMay.CoPhanMemTrungGian;
            ucKiemSoatChiDinhChayMay.Set_ShowForConfig(showMiddelware);
            ucKiemSoatChiDinhChayMay.BarcodeLenght = int.Parse(string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.BenhNhanSoKyTuBarCode) ? "4" : CommonAppVarsAndFunctions.sysConfig.BenhNhanSoKyTuBarCode);
            ucKiemSoatChiDinhChayMay.arrPhanQuyenBoPhan = CommonAppVarsAndFunctions.BoPhanClsXetNghiem;
            ucKiemSoatChiDinhChayMay.arrPhanQuyenNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem;
            ucKiemSoatChiDinhChayMay.SetDate(CommonAppVarsAndFunctions.ServerTime);
            ucKiemSoatChiDinhChayMay.Load_DanhSach_XetNghiem();
            ucKiemSoatChiDinhChayMay.userLogin = CommonAppVarsAndFunctions.UserID;

            ucGhepBarcode1.userLogin = CommonAppVarsAndFunctions.IsAdmin ? string.Empty : CommonAppVarsAndFunctions.UserID;
            ucGhepBarcode1.repeatBarcode = CommonAppVarsAndFunctions.sysConfig.BarcodeLapLai > 0;
            ucGhepBarcode1.dayScan = CommonAppVarsAndFunctions.sysConfig.BarcodeLapLai;
            ucGhepBarcode1.Refresh();
            ucGhepBarcode1.Load_AllConfig();

            analyzerResult1.UserId = CommonAppVarsAndFunctions.UserID;
            analyzerResult1.arrAnalyzerAllow = CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem;
            analyzerResult1.PcWorkPlace = CommonAppVarsAndFunctions.PCWorkPlace;
            analyzerResult1.ClsXetNghiemDinhDangKetqua = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemDinhDangKetqua;
            analyzerResult1.ClsXetNghiemKieuLayKetQuaMay = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemKieuLayKetQuaMay;
            analyzerResult1.suDungLayTuDong = false;
            analyzerResult1.Load_CauHinh(CommonAppVarsAndFunctions.ServerTime);
            analyzerResult1.gioiHanBarcode = int.Parse(CommonAppVarsAndFunctions.sysConfig.BenhNhanSoKyTuBarCode);

            ucInTuDong1.Load_Config(Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.BoPhanClsXetNghiem, false), Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.NhomClsXetNghiem, false), dataKyten.Copy());
            ucInTuDong1.printResult += PrintResultFromAuto;
            ucInTuDong1.UserSign = CommonAppVarsAndFunctions.UserID;
            ucInTuDong1.UserLogin = CommonAppVarsAndFunctions.UserID;
            _dataGhiChuTuDong = _isSysConfig.Data_dm_xetnghiem_ghichutudong(null, string.Empty);

            dtpDownloadFrom.Value = CommonAppVarsAndFunctions.ServerTime;
            dtpDownloadTo.Value = CommonAppVarsAndFunctions.ServerTime;

            reportLogo = _isSysConfig.Load_Logo("XN");
            ucInTuDong1.SetDateForForm(CommonAppVarsAndFunctions.ServerTime);
            ucDanhSachBenhNhanXN1.NgayNhanMau = CommonAppVarsAndFunctions.ServerTime;
            ucDanhSachBenhNhanXN1.ArrLoaiXetNghiem = _arrLoaiXetNghiem;
            ucDanhSachBenhNhanXN1.LstDanhSachNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem.ToList();
            ucDanhSachBenhNhanXN1.Load_CauHinh();

            ucDanhSachBenhNhanXN1.DataGridview_DsBenhNhan_CellEnter += UcDanhSachBenhNhanXN1_DataGridview_DsBenhNhan_CellEnter;
            ucDanhSachBenhNhanXN1.Button_TuyChon_Click += UcDanhSachBenhNhanXN1_Button_TuyChon_Click;
            ucDanhSachBenhNhanXN1.DoiNhomXN += UcDanhSachBenhNhanXN1_DoiNhomXN;
            ucDanhSachBenhNhanXN1.BeforeReload_DSBenhNhan += UcDanhSachBenhNhanXN1_Reload_DSBenhNhan;
            ucDanhSachBenhNhanXN1.InTheoDanhSach_Click += UcDanhSachBenhNhanXN1_InTheoDanhSach_Click;
            ucDanhSachBenhNhanXN1.ShowTuyChon = true;
            ucDanhSachBenhNhanXN1.DungUploadHIS = true;
            ucDanhSachBenhNhanXN1.ShowTuyChon = true;
            ucDanhSachBenhNhanXN1.DungInDanhSach = true;

            CheckAllowUse();
            LoadPrinterList();
            CustomMessageBox.CloseAlert();
            this.Activated += frmCLSKetQuaXN_Activated;
            chkXacNhanKhiSuaKetQua.CheckedChanged += ChkXacNhanKhiSuaKetQua_CheckedChanged;
            xtabKetQua.Controls.Remove(pnManche);
        }

        private void UcDanhSachBenhNhanXN1_InTheoDanhSach_Click(object sender, EventArgs e)
        {
            if (ucDanhSachBenhNhanXN1.gvDanhSach.SelectedRowsCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("In kết quả theo danh sách đang chọn?"))
                {
                    try
                    {
                        var rowsSelected = ucDanhSachBenhNhanXN1.gvDanhSach.GetSelectedRows();
                        foreach (int i in rowsSelected)
                        {
                            if (i > -1)
                            {
                                ucDanhSachBenhNhanXN1.gvDanhSach.FocusedRowHandle = i;
                                CustomMessageBox.ShowAlert(string.Format("Đang in kết quả của barcode: {0}", ucDanhSachBenhNhanXN1.BarcodeDangChon));
                                if (CheckInThuongQuy(true, true))
                                {
                                    ucDanhSachBenhNhanXN1.gvDanhSach.UnselectRow(i);
                                }
                            }
                        }
                        CustomMessageBox.CloseAlert();
                        ucDanhSachBenhNhanXN1.Load_DSBenhNhan();
                    }
                    catch (Exception ex)
                    {
                        ErrorService.GetFrameworkErrorMessage(ex, "ucDanhSachBenhNhanXN1_InTheoDanhSach_Click");
                    }
                }
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy check chọn vào danh sách bệnh nhân cần in.");
        }

        private void ChkXacNhanKhiSuaKetQua_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(
                  UserConstant.RegistryConfirmBeforeUpdateResult,
                  chkXacNhanKhiSuaKetQua.Checked ? "1" : "0");
            ucKetQuaThuongQuy1.XacNhanSuaKetQua = chkXacNhanKhiSuaKetQua.Checked;
        }

        private void UcDanhSachBenhNhanXN1_Reload_DSBenhNhan(object sender, EventArgs e)
        {
            ucKetQuaThuongQuy1.ClearShowingData();
            ucPatientInformation1.ClearControl();
        }
        private void Load_ChiTietXetNghiemThuongQuy()
        {
            var matiepNhan = ucDanhSachBenhNhanXN1.MaTiepNhanDangChon;
            var ngayTiepNhan = ucDanhSachBenhNhanXN1.NgayTiepNhanDangChon;
            var hisId = ucDanhSachBenhNhanXN1.HisIdDangChon;
            var databinding = ucDanhSachBenhNhanXN1.ThongTinBNDangChon;
            ucKetQuaThuongQuy1.TuTinhToanKetQua = chkAutoCalculateResult.Checked;
            ucKetQuaThuongQuy1.XoaThongTinDS();
            ucKetQuaThuongQuy1.CurrentMaTiepNhan = matiepNhan;
            ucKetQuaThuongQuy1.CurrentNgayTiepNhan = ngayTiepNhan;
            ucKetQuaThuongQuy1.hisId = hisId;
            ucKetQuaThuongQuy1.lstDanhSachNhom = (ucDanhSachBenhNhanXN1.LstDanhSachNhom.Count == 0 ? CommonAppVarsAndFunctions.NhomClsXetNghiem.ToList() : ucDanhSachBenhNhanXN1.LstDanhSachNhom);
            ucKetQuaThuongQuy1.BindPatientInfo(databinding);
            ucKetQuaThuongQuy1._dtPatient = databinding;
            ucKetQuaThuongQuy1.Load_ChiTietXN(matiepNhan, databinding);
            ucDanhSachBenhNhanXN1.SetMenuContext(contextMenuCapNhatDangXuLy);
        }
        private void cmdRefreshPrinter_Click(object sender, EventArgs e)
        {
            LabServices_Helper.LoadPrinterNameNormal(listPrinter, UserConstant.RegistryPrinterResult, true);
        }
        private void LoadPrinterList()
        {
            Task.Factory.StartNew(delegate { LabServices_Helper.LoadPrinterNameNormal(listPrinter, UserConstant.RegistryPrinterResult, true); });
        }
        private void frmCLSKetQuaXN_Activated(object sender, EventArgs e)
        {
            CheckAllowUse();
        }
        private void CheckAllowUse()
        {
            if (!CommonAppVarsAndFunctions.formLoading)
            {
                if (CommonAppVarsAndFunctions.XacNhanKhiVaoketQua)
                {
                    var f = new frmIdentify
                    {
                        UserID = CommonAppVarsAndFunctions.UserID,
                        UserName = CommonAppVarsAndFunctions.UserName,
                        pnMenu = {Visible = true}
                    };
                    f.AdjustForm();
                    manche.Refresh();
                    f.ShowDialog();
                    if (!f.Accepted)
                        this.Close();
                    else
                    {
                        f.Dispose();
                        AnManChe();
                        //  txtSEQ.Focus();
                    }
                }
                else
                {
                    //  txtSEQ.Focus();
                }
            }
        }

        private void listPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPrinter.Items.Count > 0)
            {
                _registryExtension.WriteRegistry(
                    UserConstant.RegistryPrinterResult,
                    listPrinter.SelectedItem.ToString());
            }
        }
        private void Check_EnableControl()
        {
            btnTinhToanKetQua.Enabled = chkAutoCalculateResult.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, "XN10");
            if (!chkAutoCalculateResult.Enabled)
                chkAutoCalculateResult.Checked = false;

            btnBoXacNhanKetQua.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestInValidateResult);
            btnXacNhanKetQua.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestValidateResult);
            btnXemTruocKetQua.Enabled = btnInKetQua.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestViewResult);
            //Quyền nhập kết quả
            _allowInsert = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestInsertResult);
            //Quyền sửa kết quả
            _allowEdit = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestEditResult);
            //Quyền sửa kết quả của user khác
            _allowEditResulFromOtherUser = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionEditResultOtherUser);
            //Quyền chọn máy xét nghiệm
            _allowChangeAnalyzer = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionChangeAnalyzer);
        }
        private void dtgPatient_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (dtgPatient.RowCount <= 0) return;
            //if (dtgPatient.CurrentRow == null) return;
            //var maTiepNhan = dtgPatient.CurrentRow.Cells[colDS_MaTiepNhan.Name].Value.ToString();
            //Load_HinhKetQua(maTiepNhan);
            //Load_DanhSachAlarm(maTiepNhan);
            //if (chkAutoCalculateResult.Checked)
            //{
            //    Load_ChiTietXN();
            //    if (gvKetQua.RowCount <= 0) return;
            //    if (Calculate())
            //        Load_ChiTietXN();
            //}
            //else
            //{
            //    Load_ChiTietXN();
            //}
        }
        private void txtSEQ_KeyUp(object sender, KeyEventArgs e)
        {
            // SelectRow_SEQ();
        }
        private void frmCLSKetQuaXN_FormClosing(object sender, FormClosingEventArgs e)
        {
            analyzerResult1.StopTimer();
            ucGhepBarcode1.Stop_refreshTimer();
            timerCapNhatKQMay_TuDong.Enabled = false;
            timerCapNhatKQMay_TuDong.Stop();
            timerButtonStatus.Enabled = false;
            timerButtonStatus.Stop();
        }
        private void chkPrintTitle_Click(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(
                UserConstant.RegistryPrintTitle,
                chkPrintTitle.Checked ? "1" : "0");
        }
        private void chkAutoCalculateResult_Click(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(
             UserConstant.RegistryAutoCalculateResult,
             chkAutoCalculateResult.Checked ? "1" : "0");
        }
        private void gvKetQua_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void btnDownloadRefesh_Click(object sender, EventArgs e)
        {
            var mayXetNghiem = cboDownloadMayXN.SelectedIndex > 0 ? cboDownloadMayXN.SelectedValue.ToString() : string.Empty;
            var testings = _iAnalyzerResult.GetTestingDownload(dtpDownloadFrom.Value, dtpDownloadTo.Value, radDownloadCD.Checked, radDownload.Checked,
                txtDownloadMaBN.Text, txtDownloadTenBN.Text, txtDownloadSid.Text, txtDownloadTenXN.Text,
                mayXetNghiem, false);
            foreach (DataColumn dtc in testings.Columns)
            {
                dtc.ColumnName = dtc.ColumnName.ToLower();
            }
            gcDownload.DataSource = testings;
            gvDownload.ExpandAllGroups();
            gvDownload.BestFitColumns();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CommonAppVarsAndFunctions.ServerTime.Hour == 0 && CommonAppVarsAndFunctions.ServerTime.Minute == 0 && CommonAppVarsAndFunctions.ServerTime.Second < 2)
            {
                //   dtpDateIn.Value =
                dtpDownloadFrom.Value = dtpDownloadTo.Value = CommonAppVarsAndFunctions.ServerTime;
                ucInTuDong1.SetDateForForm(CommonAppVarsAndFunctions.ServerTime);
            }

            if (FoCusAfter > 0)
            {
                if (_countToFocus >= FoCusAfter)
                {
                    ucDanhSachBenhNhanXN1.Focus();
                    ucDanhSachBenhNhanXN1.SetFosToSeq();
                    _countToFocus = 0;
                }
                else
                    _countToFocus++;
            }
        }



        private void Load_DanhSachPhieuInChon()
        {
            var data = _isSysConfig.Data_dm_xetnghiem_mauphieuin_tuychon(string.Empty);
            var dr = data.NewRow();
            dr["idmauchon"] = "NONE";
            dr["tenmauchon"] = "PHIẾU MẶC ĐỊNH";
            dr["IdFormSuDung"] = 0;
            data.Rows.InsertAt(dr, 0);
            data = WorkingServices.SearchResult_OnDatatable(data, string.Format("IdFormSuDung = 0"));
            cboPhieuIn.DataSource = data;
            cboPhieuIn.ValueMember = "idmauchon";
            cboPhieuIn.DisplayMember = "tenmauchon";
            cboPhieuIn.SelectedValue = "NONE";
            if (data.Rows.Count == 1)
            {
                cboPhieuIn.Enabled = false;
            }
        }
        private void UcDanhSachBenhNhanXN1_DoiNhomXN(object sender, EventArgs e)
        {
            ucKetQuaThuongQuy1.Load_DSNhomIn(ucDanhSachBenhNhanXN1.LstDanhSachNhom.ToArray());
        }
        private void UcKetQuaThuongQuy1_DataGridview_KetQua_FocusRowChanged(object sender, EventArgs e)
        {
            _countToFocus = 0;
        }

        private void UcKetQuaThuongQuy1_DataGridview_KetQua_FocusColumnChanged(object sender, EventArgs e)
        {
            _countToFocus = 0;
        }

        private void UcDanhSachBenhNhanXN1_Button_TuyChon_Click(object sender, EventArgs e)
        {
            if (pnSignature.Tag != null)
                pnSignature.Height = int.Parse(pnSignature.Tag.ToString());
        }

        private void UcDanhSachBenhNhanXN1_DataGridview_DsBenhNhan_CellEnter(object sender, EventArgs e)
        {
            ucPatientInformation1.LoadInformation(ucDanhSachBenhNhanXN1.MaTiepNhanDangChon);
            Load_ChiTietXetNghiemThuongQuy();
        }
        private void btnXacNhanKQThuongQuy_Click(object sender, EventArgs e)
        {
            ucKetQuaThuongQuy1.XacNhanKetQua(true, true, false);
            if (chkInKhiXacNhan.Checked)
            {
                CheckInThuongQuy(true, false);
            }
            else
            {
                ucDanhSachBenhNhanXN1.Barcode = ucDanhSachBenhNhanXN1.BarcodeDangChon;
                ucDanhSachBenhNhanXN1.Load_DSBenhNhan();
            }
        }
        private void btnHuyXacNhanKQThuongQuy_Click(object sender, EventArgs e)
        {
            ucKetQuaThuongQuy1.XacNhanKetQua(false, true, false);
            ucDanhSachBenhNhanXN1.Barcode = ucDanhSachBenhNhanXN1.BarcodeDangChon;
            ucDanhSachBenhNhanXN1.Load_DSBenhNhan();
        }
        private void btnXemTruocKQThuongQuy_Click(object sender, EventArgs e)
        {
            CheckInThuongQuy(false, false);
        }
        private bool CheckInThuongQuy(bool print, bool byList)
        {
            var userSign = (ucSearchLookupEditor_KyTentruongKhoa.SelectedValue ?? (object)string.Empty).ToString();

            CommonAppVarsAndFunctions.TempSignIdXetNghiem = userSign;
            CommonAppVarsAndFunctions.TempSignNameXetNghiem = ucSearchLookupEditor_KyTentruongKhoa.GetSeletetedDoctorName();
            var tenLanhDao = ucSearchLookupEditor_KyTenlanhdao.GetSeletetedDoctorName();
            var chucvuLanhdao = ucSearchLookupEditor_KyTenlanhdao.GetSeletetedDoctorPosition();
            if (userSign.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase)
                && !CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemChoChuKyGiongUserDangNhap)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn người ký tên khác user đăng nhập!");
                return false;
            }

            progressPrint.Value = 0;
            var printerName = string.Empty;
            if (listPrinter.Items.Count > 0 && string.IsNullOrEmpty(printerName))
            {
                if (listPrinter.SelectedIndex == -1)
                {
                    listPrinter.SelectedIndex = 0;
                }
                progressPrint.Value++;
                printerName = listPrinter.SelectedItem.ToString();
            }
            var maureportChon = cboPhieuIn.SelectedIndex > 0 ? cboPhieuIn.SelectedValue.ToString() : string.Empty;
            if (ucKetQuaThuongQuy1.InKetQua(print, userSign, printerName, chkInCoQuiDoi.Checked
                , chkPrintColor.Checked, chkChiInCoKetQua.Checked, progressPrint
                , maureportChon, tenLanhDao, chucvuLanhdao, (dtpNgayInKQ.Checked ? dtpNgayInKQ.Value : (DateTime?)null), chkPrintTitle.Checked))
            {
                if (!byList)
                {
                    ucDanhSachBenhNhanXN1.Barcode = ucDanhSachBenhNhanXN1.BarcodeDangChon;
                    ucDanhSachBenhNhanXN1.Load_DSBenhNhan();
                }
            }
            return true;
        }

        private void btnInKetQuaThuognQuy_Click(object sender, EventArgs e)
        {
            CheckInThuongQuy(true, false);
        }
        private void ChkInKhiXacNhan_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(
                UserConstant.RegistryPrintWhenValid,
                chkInKhiXacNhan.Checked ? "1" : "0");
        }
        private void chkChiInCoKetQua_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(UserConstant.RegistryPrintTestWithResult, chkChiInCoKetQua.Checked ? "1" : "0");
        }
        private void chkPrintTitle_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void chkAutoCalculateResult_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void repositoryItemMemoEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is MemoEdit)
            {
                var obj = (MemoEdit)sender;
                if (e.Shift && e.KeyCode == Keys.Enter)
                {
                    obj.EditValue += Environment.NewLine;
                    obj.SelectionStart = obj.Text.Length;
                    e.Handled = true;
                }
            }
        }

        private void Check_SetForControlChild(Control mainCotrol)
        {
            mainCotrol.BackColor = Color.Transparent;
            Set_ColorTextinSelectedMenu(mainCotrol, false);
            if (mainCotrol.Controls.Count > 0)
            {
                foreach (Control ctr in mainCotrol.Controls)
                    Check_SetForControlChild(ctr);
            }
        }
        private void Set_ColorTextinSelectedMenu(Control pn, bool isSelected)
        {
            foreach (Control lbl in pn.Controls)
            {
                if (lbl is CustomLable)
                {
                    ((CustomLable)lbl).ForeColor = isSelected ? Color.White : SystemColors.WindowText;
                    ((CustomLable)lbl)._oldColor = ((CustomLable)lbl).ForeColor;
                }
            }
        }

        private void btnCloseSetting_Click(object sender, EventArgs e)
        {
            pnSignature.Tag = pnSignature.Height;
            pnSignature.Height = 0;
        }
        private void frmCLSKetQuaXN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P)
            {
                CheckInThuongQuy(true, false);
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                if (ucKetQuaThuongQuy1.HaveItem)
                {
                    ucKetQuaThuongQuy1.GetImage_FromClipboard(false);
                }
            }
            //else if (e.Control && e.Alt && e.KeyCode == Keys.D)
            //{
            //    if (ucKetQuaThuongQuy1.HaveItem)
            //    {
            //        ucKetQuaThuongQuy1.SelectAllXN();
            //        ucKetQuaThuongQuy1.XacNhanKetQua(true, false, true);
            //    }
            //    Load_ChiTietXetNghiemThuongQuy();
            //    ucDanhSachBenhNhanXN1.Focus();
            //    ucDanhSachBenhNhanXN1.SetFosToSeq();
            //}
            else if (e.Control && e.Alt && e.KeyCode == Keys.B)
            {
                if (ucKetQuaThuongQuy1.HaveItem)
                {
                    ucKetQuaThuongQuy1.SelectAllXN();
                    ucKetQuaThuongQuy1.XacNhanKetQua(false, false, true);
                }
                Load_ChiTietXetNghiemThuongQuy();
                ucDanhSachBenhNhanXN1.Focus();
                ucDanhSachBenhNhanXN1.SetFosToSeq();
            }
            else if (e.Control && e.KeyCode == Keys.D)
            {
                if (ucKetQuaThuongQuy1.HaveItem)
                {
                    ucKetQuaThuongQuy1.XacNhanKetQua(true, false, true);
                }
                Load_ChiTietXetNghiemThuongQuy();
                ucDanhSachBenhNhanXN1.Focus();
                ucDanhSachBenhNhanXN1.SetFosToSeq();
            }
            else if (e.Control && e.KeyCode == Keys.B)
            {
                if (ucKetQuaThuongQuy1.HaveItem)
                {
                    ucKetQuaThuongQuy1.XacNhanKetQua(false, false, true);
                }
                Load_ChiTietXetNghiemThuongQuy();
                ucDanhSachBenhNhanXN1.Focus();
                ucDanhSachBenhNhanXN1.SetFosToSeq();
            }
            else if (e.KeyCode == Keys.F12)
            {
                if (ucKetQuaThuongQuy1.HaveItem)
                {
                    ucKetQuaThuongQuy1.SelectAllXN();
                    if (ucKetQuaThuongQuy1.XacNhanKetQua(true, false, true))
                    {
                        if (chkInKhiXacNhan.Checked)
                        {
                            CheckInThuongQuy(true, false);
                        }
                        else
                            Load_ChiTietXetNghiemThuongQuy();
                    }
                }
                ucDanhSachBenhNhanXN1.Focus();
                ucDanhSachBenhNhanXN1.SetFosToSeq();
            }
        }
        private void btnHDNhanh_Click(object sender, EventArgs e)
        {
            var f = new DailyUse.CanLamSang.FrmHuongDan_FormKetQuaTQ();
            f.ShowDialog();
        }
        private void ucInTuDong1_BatInTuDonClick(object sender, EventArgs e)
        {
            SeTrangThaiInTuDong();
        }

        private void SeTrangThaiInTuDong()
        {
            var fm = (frmParent) this.TopLevelControl;
            fm.lblStatus.Text = !string.IsNullOrEmpty(ucInTuDong1.TrangThai)
                ? string.Format(CommonAppVarsAndFunctions.LangMessageConstant.Intudong, ucInTuDong1.TrangThai)
                : "";
        }

        private void ucInTuDong1_BatTatinTuDongClick(object sender, EventArgs e)
        {
            SeTrangThaiInTuDong();
        }

        public void CapNhatTrangThaiDangXuLy(bool dangXuly)
        {
            if (!string.IsNullOrEmpty(ucKetQuaThuongQuy1.CurrentMaTiepNhan))
            {
                var lstNhom = new List<string>();
                var lstBoPhan = new List<string>();
                string matiepNhan = ucKetQuaThuongQuy1.CurrentMaTiepNhan;
                ucKetQuaThuongQuy1.GetListNhom_BoPhan(ref lstNhom, ref lstBoPhan);
                if (lstBoPhan.Count > 0 && lstNhom.Count > 0)
                {
                    _xetnghiem.CapNhat_TrangThaiDangXuLy_ChoBoPhan(matiepNhan, lstBoPhan, dangXuly);
                    _xetnghiem.CapNhat_TrangThaiDangXuLy_ChoNhom(matiepNhan, lstNhom, dangXuly);
                }
            }
        }
        private void mnuDangXuLy_Click(object sender, EventArgs e)
        {
            CapNhatTrangThaiDangXuLy(true);
        }

        private void ucDanhSachBenhNhanXN1_InTheoDanhSach_Click(object sender, EventArgs e)
        {

            var maureportChon = cboPhieuIn.SelectedIndex > 0 ? cboPhieuIn.SelectedValue.ToString() : string.Empty;
            if (ucDanhSachBenhNhanXN1.gvDanhSach.SelectedRowsCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("In kết quả theo danh sách đang chọn?"))
                {
                    try
                    {
                        var rowsSelected = ucDanhSachBenhNhanXN1.gvDanhSach.GetSelectedRows();
                        foreach (int i in rowsSelected)
                        {
                            if (i > -1)
                            {
                                ucDanhSachBenhNhanXN1.gvDanhSach.FocusedRowHandle = i;
                                CustomMessageBox.ShowAlert(string.Format("Đang in kết quả của barcode: {0}", ucDanhSachBenhNhanXN1.BarcodeDangChon));
                                if (CheckInThuongQuy(true, true))
                                {
                                    ucDanhSachBenhNhanXN1.gvDanhSach.UnselectRow(i);
                                }
                            }
                        }
                        CustomMessageBox.CloseAlert();
                        ucDanhSachBenhNhanXN1.Load_DSBenhNhan();
                    }
                    catch (Exception ex)
                    {
                        ErrorService.GetFrameworkErrorMessage(ex, "ucDanhSachBenhNhanXN1_InTheoDanhSach_Click");
                    }
                }
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy check chọn vào danh sách bệnh nhân cần in.");
        }

        private void btnKQXetNghiem_Click(object sender, EventArgs e)
        {
            tabKetQuaBenhNhan.SelectedTabPageIndex = 0;
            HightLightButton((Button)sender);
        }

        private void btnKetQuaMay_Click(object sender, EventArgs e)
        {
            tabKetQuaBenhNhan.SelectedTabPageIndex = 1;
            HightLightButton((Button)sender);
        }

        private void btnChiDinhMay_Click(object sender, EventArgs e)
        {
            tabKetQuaBenhNhan.SelectedTabPageIndex = 2;
            HightLightButton((Button)sender);
        }

        private void btnLichSuDownLoad_Click(object sender, EventArgs e)
        {
            tabKetQuaBenhNhan.SelectedTabPageIndex = 3;
            HightLightButton((Button)sender);
        }

        private void btnNhapBarcode_Click(object sender, EventArgs e)
        {
            tabKetQuaBenhNhan.SelectedTabPageIndex = 4;
            HightLightButton((Button)sender);
        }

        private void btnInTuDong_Click(object sender, EventArgs e)
        {
            tabKetQuaBenhNhan.SelectedTabPageIndex = 5;
            HightLightButton((Button)sender);
        }

        private void chkInKhiXacNhan_CheckedChanged_1(object sender, EventArgs e)
        {
            chkInKhiXacNhan.BackColor = (chkInKhiXacNhan.Checked ? Color.Yellow : Color.Empty);
        }

        private void chkInCoQuiDoi_Click(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(
              UserConstant.RegistryPrintCoQuiDoi,
              chkInCoQuiDoi.Checked ? "1" : "0");
        }
    }
}
