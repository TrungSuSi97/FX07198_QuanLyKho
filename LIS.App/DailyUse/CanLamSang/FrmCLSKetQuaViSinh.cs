using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.Common.Extensions;
using TPH.Lab.Middleware.LISConnect.Services;
using TPH.LIS.Analyzer.Services;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Patient.Services;
using TPH.LIS.ResultConvert.Service;
using TPH.LIS.TestResult.Services;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Services.UserManagement;

namespace TPH.LIS.App.DailyUse.CanLamSang
{
    public partial class FrmCLSKetQuaViSinh : FrmTemplate
    {
        private readonly ITestResultService _xetnghiem = new TestResultService();
        private readonly IPatientInformationService _iPatient = new PatientInformationService();
        private readonly ISystemConfigService _isSysConfig = new SystemConfigService();
        private readonly IConnectHISService _iHisData = new ConnectHISService();
        private readonly IAnalyzerResultService _iAnalyzerResult = new AnalyzerResultService();
        private readonly IAnalyzerConfigService _iAnalyzerConfig = new AnalyzerConfigService();
        private readonly IResultConvertService _iResultConvert = new ResultConvertService();
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
        private readonly TestType.EnumTestType[] _arrLoaiXetNghiemThuongQuy = new TestType.EnumTestType[] { TestType.EnumTestType.ViSinh_TQ };
        private readonly TestType.EnumTestType[] _arrLoaiXetNghiemNuoiCay = new TestType.EnumTestType[] { TestType.EnumTestType.ViSinhNuoiCay
            , TestType.EnumTestType.ViSinh_TQ};
        private DataTable _dtCaldulate = new DataTable();
        private Image reportLogo;
        private int _countToFocus = 0;
        private bool _allowEdit;
        private bool _allowInsert;
        private bool _allowChangeAnalyzer;
        private bool _allowEditResulFromOtherUser;
        public DateTime DtDateInG { get; set; }
        public string MatiepNhanG { get; set; }
        public FrmCLSKetQuaViSinh()
        {
            InitializeComponent();
            MatiepNhanG = string.Empty;
            DtDateInG = new DateTime();
        }
        private void FrmCLSKetQuaViSinh_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }
        private void LoadConfig()
        {
            pnSignature.Height = 0;
            ucPatientInformation1.dtpDateIn.Value = CommonAppVarsAndFunctions.ServerTime;
            ucPatientInformation1.Load_DanhMucCauHinh();

            ucKetQuaThuongQuy1._arrLoaiXetNghiem = _arrLoaiXetNghiemThuongQuy;
            ucKetQuaThuongQuy1.Load_Config();
            ucKetQuaThuongQuy1.DataGridview_KetQua_FocusColumnChanged += UcKetQuaThuongQuy1_DataGridview_KetQua_FocusColumnChanged;
            ucKetQuaThuongQuy1.DataGridview_KetQua_FocusRowChanged += UcKetQuaThuongQuy1_DataGridview_KetQua_FocusRowChanged;
            ucKetQuaThuongQuy1.CheDoHienThi = 0;

            //dtgKetQuaXN.RowTemplate.MinimumHeight = 23;
            LabServices_Helper.LoadPrinterName(listPrinter, UserConstant.RegistryPrinterResult, false);
            chkPrintTitle.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryPrintTitle).Equals("1");
            chkAutoCalculateResult.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryAutoCalculateResult).Equals("1");
            chkChiInCoKetQua.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryPrintTestWithResult).Equals("1");
            chkInCoQuiDoi.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryPrintCoQuiDoi).Equals("1");
            chkInCoQuiDoi.CheckedChanged += chkInCoQuiDoi_CheckedChanged;
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
            cboNguoiKyTen.SelectedIndexAfterChange -= cboNguoiKyTen_SelectedIndexAfterChange;
            var dataKyten = userManagement.GetUsersKyTenCoPhanQuyen("", Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.BoPhanClsXetNghiem, true), true);
            DataRow dr = dataKyten.NewRow();
            dr["MaNguoiDung"] = string.Empty;
            dr["TenNhanVien"] = "---None---";
            dataKyten.Rows.InsertAt(dr, 0);
            ControlExtension.BindDataToCobobox(dataKyten.Copy(), ref cboNguoiKyTen, "MaNguoiDung", "MaNguoiDung", "MaNguoiDung, TenNhanVien", "50,150", txtNguoiKyTen, 1);
            cboNguoiKyTen.SelectedIndexAfterChange += cboNguoiKyTen_SelectedIndexAfterChange;
            if (!string.IsNullOrEmpty(currentUserSign))
                CommonAppVarsAndFunctions.TempSignIdXetNghiem = currentUserSign;
            else
                cboNguoiKyTen.SelectedValue = CommonAppVarsAndFunctions.UserID;
            Set_Sign();
            Set_SignNuoiCay();
            _dtCaldulate = _isSysConfig.GetTestCaculate(string.Empty);
            LoadPrinterList();

            analyzerResult1.UserId = CommonAppVarsAndFunctions.UserID;
            analyzerResult1.arrAnalyzerAllow = CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem;
            analyzerResult1.PcWorkPlace = CommonAppVarsAndFunctions.PCWorkPlace;
            analyzerResult1.ClsXetNghiemDinhDangKetqua = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemDinhDangKetqua;
            analyzerResult1.ClsXetNghiemKieuLayKetQuaMay = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemKieuLayKetQuaMay;
            analyzerResult1.suDungLayTuDong = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemFormKQMayTuDong;
            analyzerResult1.Load_CauHinh(CommonAppVarsAndFunctions.ServerTime);
            analyzerResult1.gioiHanBarcode = int.Parse(CommonAppVarsAndFunctions.sysConfig.BenhNhanSoKyTuBarCode);

            reportLogo = _isSysConfig.Load_Logo("XN");

            ucDanhSachBenhNhanXN1.ArrLoaiXetNghiem = _arrLoaiXetNghiemThuongQuy.Concat(_arrLoaiXetNghiemNuoiCay).ToArray();

            ucDanhSachBenhNhanXN1.LstDanhSachNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem.ToList();
            ucDanhSachBenhNhanXN1.Load_CauHinh();
            ucDanhSachBenhNhanXN1.Load_DSBenhNhan();
            ucDanhSachBenhNhanXN1.ShowCheckChon = true;
            ucDanhSachBenhNhanXN1.DataGridview_DsBenhNhan_CellEnter += UcDanhSachBenhNhanXN1_DataGridview_DsBenhNhan_CellEnter;
            ucDanhSachBenhNhanXN1.Button_TuyChon_Click += UcDanhSachBenhNhanXN1_Button_TuyChon_Click;
            ucDanhSachBenhNhanXN1.DoiNhomXN += UcDanhSachBenhNhanXN1_DoiNhomXN;

            ucKetQuaViSinh1._arrLoaiXetNghiem = _arrLoaiXetNghiemNuoiCay;
            ucKetQuaViSinh1.Load_CauHinh();
            ucKetQuaViSinh1._dataUserSign = (DataTable)cboNguoiKyTen.DataSource;

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
            ucDanhSachBenhNhanXN1.NgayNhanMau = CommonAppVarsAndFunctions.ServerTime;
            btnXacNhanKetQua.Click += btnXacNhanKetQua_Click;
            btnBoXacNhanKetQua.Click += btnBoXacNhanKetQua_Click;
            btnXemTruocKetQua.Click += btnXemTruocKetQua_Click;
            btnInKetQua.Click += btnInKetQua_Click;
            btnHDNhanh.Click += btnHDNhanh_Click;
            cmdRefreshPrinter.Click += CmdRefreshPrinter_Click;
            btnDongTuyChon.Click += btnDongTuyChon_Click;
        }
        private void Set_SignNuoiCay()
        {
            ucKetQuaViSinh1.userSign = (cboNguoiKyTen.SelectedValue == null ? string.Empty : cboNguoiKyTen.SelectedValue.ToString());
        }
        private void Set_Sign()
        {
            if (string.IsNullOrWhiteSpace(CommonAppVarsAndFunctions.TempSignIdXetNghiemViSinh)) return;
            cboNguoiKyTen.SelectedValue = CommonAppVarsAndFunctions.TempSignIdXetNghiemViSinh;
        }
        private void Check_EnableControl()
        {
            chkAutoCalculateResult.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, "XN10");
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
        private void CmdRefreshPrinter_Click(object sender, EventArgs e)
        {
            LabServices_Helper.LoadPrinterNameNormal(listPrinter, UserConstant.RegistryPrinterResult, true);
        }
        private void LoadPrinterList()
        {
            LabServices_Helper.LoadPrinterNameNormal(listPrinter, UserConstant.RegistryPrinterResult, true);
        }
        private void cboNguoiKyTen_SelectedIndexAfterChange(object sender, EventArgs e)
        {
            if (pnCHonKyTen.Visible)
            {
                if (cboNguoiKyTen.SelectedIndex > -1)
                {
                    CommonAppVarsAndFunctions.TempSignIdXetNghiemViSinh = cboNguoiKyTen.SelectedValue.ToString().Trim();
                    CommonAppVarsAndFunctions.TempSignNameXetNghiemViSinh = txtNguoiKyTen.Text;
                }
                else
                {
                    CommonAppVarsAndFunctions.TempSignIdXetNghiemViSinh = string.Empty;
                    CommonAppVarsAndFunctions.TempSignNameXetNghiemViSinh = string.Empty;
                }
                Set_SignNuoiCay();
            }
        }
        private void chkInCoQuiDoi_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(UserConstant.RegistryPrintCoQuiDoi, chkInCoQuiDoi.Checked ? "1" : "0");
        }
        private void ChkInKhiXacNhan_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(
                UserConstant.RegistryPrintWhenValid,
                chkInKhiXacNhan.Checked ? "1" : "0");
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
            pnSignature.Height = 75;
        }
        private void UcDanhSachBenhNhanXN1_DataGridview_DsBenhNhan_CellEnter(object sender, EventArgs e)
        {
            ucPatientInformation1.LoadInformation(ucDanhSachBenhNhanXN1.MaTiepNhanDangChon);
            Load_ChiTietXetNghiemThuongQuy();
            Load_ChiTietXetNghiemVSNC();
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
            ucKetQuaThuongQuy1.lstDanhSachNhom = ucDanhSachBenhNhanXN1.LstDanhSachNhom;
            ucKetQuaThuongQuy1.BindPatientInfo(databinding);
            ucKetQuaThuongQuy1._dtPatient = databinding;
            ucKetQuaThuongQuy1.Load_ChiTietXN(matiepNhan, databinding);
        }
        private void Load_ChiTietXetNghiemVSNC()
        {
            ucKetQuaViSinh1.XoaThongTinDS();
            if (!string.IsNullOrEmpty(ucDanhSachBenhNhanXN1.MaTiepNhanDangChon))
            {
                var matiepNhan = ucDanhSachBenhNhanXN1.MaTiepNhanDangChon;

                var ngayTiepNhan = ucDanhSachBenhNhanXN1.NgayNhanMau;

                var hisId = ucDanhSachBenhNhanXN1.HisIdDangChon;

                var databinding = ucDanhSachBenhNhanXN1.ThongTinBNDangChon;

                var barcode = ucDanhSachBenhNhanXN1.BarcodeDangChon;

                ucKetQuaViSinh1._arrLoaiXetNghiem = _arrLoaiXetNghiemNuoiCay;

                ucKetQuaViSinh1.CurrentMaTiepNhan = matiepNhan;

                ucKetQuaViSinh1.CurrentNgayTiepNhan = ngayTiepNhan;

                ucKetQuaViSinh1.CurrentBarcode = barcode;

                ucKetQuaViSinh1.CurrentMaBenhNhan = ucDanhSachBenhNhanXN1.MaBnDangChon;

                ucKetQuaViSinh1.hisId = hisId;

                ucKetQuaViSinh1.IsPrintTitle = chkPrintTitle.Checked;

                ucKetQuaViSinh1.SelectedPrinterName = (listPrinter.SelectedItem ?? (object)string.Empty).ToString();

                ucKetQuaViSinh1.userSign = (cboNguoiKyTen.SelectedValue == null ? string.Empty : cboNguoiKyTen.SelectedValue.ToString());

                ucKetQuaViSinh1.lstDanhSachNhom = ucDanhSachBenhNhanXN1.LstDanhSachNhom;

                ucKetQuaViSinh1._dtPatient = databinding;

                ucKetQuaViSinh1.Load_ChiTietXN(matiepNhan);
            }
        }
        private bool CheckInThuongQuy(bool print, bool byList = false)
        {
            var userSign = cboNguoiKyTen.SelectedIndex > -1 ? cboNguoiKyTen.SelectedValue.ToString().Trim() : string.Empty;
            if (userSign.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase)
                && !CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemChoChuKyGiongUserDangNhap)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn người ký tên khác user đăng nhập!");
                return false;
            }
            var printerName = string.Empty;
            if (listPrinter.Items.Count > 0 && string.IsNullOrEmpty(printerName))
            {
                if (listPrinter.SelectedIndex == -1)
                {
                    listPrinter.SelectedIndex = 0;
                }

                printerName = listPrinter.SelectedItem.ToString();
            }

            if (ucKetQuaThuongQuy1.InKetQua(print, userSign, printerName, chkInCoQuiDoi.Checked, chkPrintColor.Checked
                , chkChiInCoKetQua.Checked, new ToolStripProgressBar(), string.Empty, string.Empty, string.Empty, null, chkPrintTitle.Checked))
            {
                if (!byList)
                {
                    ucDanhSachBenhNhanXN1.Barcode = ucDanhSachBenhNhanXN1.BarcodeDangChon;
                    ucDanhSachBenhNhanXN1.Load_DSBenhNhan();
                }
            }
            return true;
        }
        private void Load_TiepNhan()
        {
            _countToFocus = 0;
            ucDanhSachBenhNhanXN1.Load_DSBenhNhan();
            _countToFocus = 0;
        }

        private void btnDongTuyChon_Click(object sender, EventArgs e)
        {
            pnSignature.Height = 0;
        }

        private void btnXacNhanKetQua_Click(object sender, EventArgs e)
        {
            ucKetQuaThuongQuy1.XacNhanKetQua(true, true, false);
            if (chkInKhiXacNhan.Checked)
            {
                CheckInThuongQuy(true);
            }
            else
            {
                ucDanhSachBenhNhanXN1.Barcode = ucDanhSachBenhNhanXN1.BarcodeDangChon;
                ucDanhSachBenhNhanXN1.Load_DSBenhNhan();
            }
        }

        private void btnBoXacNhanKetQua_Click(object sender, EventArgs e)
        {
            ucKetQuaThuongQuy1.XacNhanKetQua(false, true, false);
            ucDanhSachBenhNhanXN1.Barcode = ucDanhSachBenhNhanXN1.BarcodeDangChon;
            ucDanhSachBenhNhanXN1.Load_DSBenhNhan();
        }

        private void btnXemTruocKetQua_Click(object sender, EventArgs e)
        {
            CheckInThuongQuy(false);
        }

        private void btnInKetQua_Click(object sender, EventArgs e)
        {
            CheckInThuongQuy(true);
        }

        private void btnHDNhanh_Click(object sender, EventArgs e)
        {
            var f = new DailyUse.CanLamSang.FrmHuongDan_FormKetQuaTQ();
            f.ShowDialog();
        }
    }
}
