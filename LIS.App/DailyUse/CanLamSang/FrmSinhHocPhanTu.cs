using Common.Logging;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.Controls;
using TPH.Data.HIS.HISDataCommon;
using TPH.Data.HIS.Models;
using TPH.Lab.Middleware.LISConnect.Services;
using TPH.Language;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.Settings.DanhMucCLS;
using TPH.LIS.App.ThucThi;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Log.Services.WorkingLog;
using TPH.LIS.Patient.Services;
using TPH.LIS.TestResult.Controls;
using TPH.LIS.TestResult.Services;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Services.UserManagement;
using TPH.Report.Constants;
using TPH.Report.Models;
using TPH.Report.Services;
using TPH.Report.Services.Impl;
//using TPH.LIS.Common;

namespace TPH.LIS.App.DailyUse.CanLamSang
{
    public partial class FrmSinhHocPhanTu : FrmTemplate
    {
        public FrmSinhHocPhanTu()
        {
            InitializeComponent();
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            //lblPhieuIn2.BackColor = lblPhieuIn.BackColor = lblTruongKhoa.BackColor = lblKyLanhDao.BackColor = CommonAppColors.ColorMainAppFormColor;
            //lblPhieuIn2.ForeColor = lblPhieuIn.ForeColor = lblTruongKhoa.ForeColor = lblKyLanhDao.ForeColor = CommonAppColors.ColorTextCaption;
            // lblNgayInSHPTRoi.BackColor = lblNgayInSHPTLuoi.BackColor = TPH.Controls.CommonAppColors.ColorMainAppColor;

            pnChucNang.BackColor = CommonAppColors.ColorMainAppFormColor;
            xtraTabControl1.BackColor = CommonAppColors.ColorMainAppFormColor;
            xtraTabControl1.AppearancePage.PageClient.BackColor = CommonAppColors.ColorMainAppFormColor;
            xtraTabControl1.AppearancePage.Header.BackColor = CommonAppColors.ColorMainAppColor;
            //tabKetQuaBenhNhan.AppearancePage.Header.BackColor2 = Color.WhiteSmoke;
            xtraTabControl1.AppearancePage.Header.ForeColor = CommonAppColors.ColorTextNormal;
            xtraTabControl1.AppearancePage.HeaderActive.ForeColor = CommonAppColors.ColorTextSelected;
            xtraTabControl1.AppearancePage.HeaderActive.BackColor = CommonAppColors.ColorSelectedPage;
            splitContainer1.BackColor = CommonAppColors.ColorMainAppFormColor;
            splitContainer2.BackColor = CommonAppColors.ColorMainAppFormColor;
            splitContainer3.BackColor = CommonAppColors.ColorMainAppFormColor;
            splitContainer4.BackColor = CommonAppColors.ColorMainAppFormColor;
        }
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IConnectHISService _iHISData = new ConnectHISService();
        private readonly ISystemConfigService _isSysConfig = new SystemConfigService();
        private readonly ITestResultService _xetnghiem = new TestResultService();
        private readonly IPatientInformationService _patient = new PatientInformationService();
        private readonly IWorkingLogService workingLog = new WorkingLogService();
        private ucKetQua_SHPT_LuoiThuong ketquaLuoiThuong = new ucKetQua_SHPT_LuoiThuong();
        private ucKetQua_SHPT_5_Hinh ketqua5Hinh = new ucKetQua_SHPT_5_Hinh();
        private ucKetQua_SHPT_KetQuaThuong ketquaThuong = new ucKetQua_SHPT_KetQuaThuong();
        string currentMaXn = string.Empty;
        string currentKetQua = string.Empty;
        DataTable _dtPatient = new DataTable();
        bool _loading = false;
        string tempGhiChu = string.Empty;
        int tempidMayXn = 0;
        string tempKetQua = string.Empty;
        List<CAUHINH_MAYINKETQUA> ListCauHinhMayIn;

        private readonly IReportService _reportInfo = new ReportServiceImpl();
        private List<ReportModel> lstResultReportInfo = new List<ReportModel>();
        private ReportModel GetReportInList(string reportID)
        {
            var lst = lstResultReportInfo.Where(x => x.ReportId.Equals(reportID));
            if (lst.Any())
            {
                return lst.FirstOrDefault();
            }

            var rp = _reportInfo.Info_Report(reportID);
            if (!string.IsNullOrEmpty(rp.ReportId))
            {
                lstResultReportInfo.Add(rp);
                return rp;
            }
            return null;
        }
        private bool _allowLuuKetQua;
        private bool _allowXacNhan;
        private bool _allowBoXacNhan;
        private bool _allowInKetQua;
        private Image _reportLogo;

        void LoadChonNgonNguIn()
        {
            var lang1 = LanguageExtension.GetResourceValueFromValue("1: Tiếng Việt", LanguageExtension.AppLanguage);
            var lang2 = LanguageExtension.GetResourceValueFromValue("2: Tiếng Anh", LanguageExtension.AppLanguage);
            var lang3 = LanguageExtension.GetResourceValueFromValue("3: Tiếng Nhật", LanguageExtension.AppLanguage);
            var lang4 = LanguageExtension.GetResourceValueFromValue("4: Tiếng Trung", LanguageExtension.AppLanguage);
            var lang5 = LanguageExtension.GetResourceValueFromValue("5: Tiếng Pháp", LanguageExtension.AppLanguage);

            var lst = new Dictionary<string, string>
            {
                {lang1, lang1},
                {lang2, lang2},
                {lang3, lang3},
                {lang4, lang4},
                {lang5, lang5}
            };
            cboPhieuInSHPT.DataSource = new BindingSource(lst, null);
            cboPhieuInSHPT.DisplayMember = "Value";
            cboPhieuInSHPT.ValueMember = "Key";
        }
        private void FrmSinhHocPhanTu_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnLuuNguoiThucHienTQ,
                LanguageExtension.GetResourceValueFromValue("Lưu kết quả", LanguageExtension.AppLanguage));
            toolTip1.SetToolTip(btnXacNhanKQThuongQuy,
                LanguageExtension.GetResourceValueFromValue("Duyệt kết quả", LanguageExtension.AppLanguage));
            toolTip1.SetToolTip(btnHuyXacNhanKQThuongQuy,
                LanguageExtension.GetResourceValueFromValue("Bỏ duyệt kết quả", LanguageExtension.AppLanguage));
            toolTip1.SetToolTip(btnXemInKQThuongQuy,
                LanguageExtension.GetResourceValueFromValue("Xem in kết quả", LanguageExtension.AppLanguage));
            toolTip1.SetToolTip(btnInKetQuaThuognQuy,
                LanguageExtension.GetResourceValueFromValue("In kết quả", LanguageExtension.AppLanguage));
            toolTip1.SetToolTip(btnLayThongTinTruocTQ,
                LanguageExtension.GetResourceValueFromValue("Lấy thời gian thực hiện trước đó", LanguageExtension.AppLanguage));


            toolTip1.SetToolTip(btnLuu,
                LanguageExtension.GetResourceValueFromValue("Lưu kết quả", LanguageExtension.AppLanguage));
            toolTip1.SetToolTip(btnXacNhanKetQua,
                LanguageExtension.GetResourceValueFromValue("Duyệt kết quả", LanguageExtension.AppLanguage));
            toolTip1.SetToolTip(btnHuyXacNhanKetQua,
                LanguageExtension.GetResourceValueFromValue("Bỏ duyệt kết quả", LanguageExtension.AppLanguage));
            toolTip1.SetToolTip(btnXemIn,
                LanguageExtension.GetResourceValueFromValue("Xem in kết quả", LanguageExtension.AppLanguage));
            toolTip1.SetToolTip(btnInketQua,
                LanguageExtension.GetResourceValueFromValue("In kết quả", LanguageExtension.AppLanguage));
            toolTip1.SetToolTip(btnLayThongTinTruocSHPT,
                LanguageExtension.GetResourceValueFromValue("Lấy thời gian thực hiện trước đó", LanguageExtension.AppLanguage));


            LoadChonNgonNguIn();
            CheckEnabledFunction();
            ucKetQuaThuongQuy1._arrLoaiXetNghiem = new[] { TestType.EnumTestType.SHPTThuongQuy };
            ucKetQuaThuongQuy1.Load_Config();
            ucKetQuaThuongQuy1.DataGridview_KetQua_FocusColumnChanged += UcKetQuaThuongQuy1_DataGridview_KetQua_FocusColumnChanged;
            ucKetQuaThuongQuy1.DataGridview_KetQua_FocusRowChanged += UcKetQuaThuongQuy1_DataGridview_KetQua_FocusRowChanged;
            ListCauHinhMayIn = _isSysConfig.ListCauHinhMayIn(Environment.MachineName);
            LoadPrinterList();
            Load_DSMayXN();
            
            ucDanhSachBenhNhanXN1.ShowTuyChon = true;
            ucDanhSachBenhNhanXN1.DungUploadHIS = true;
            ucDanhSachBenhNhanXN1.ShowTuyChon = true;
            ucDanhSachBenhNhanXN1.DungInDanhSach = true;

            //Load user ký tên

            //cboNguoiKyTen.SelectedIndexChanged -= cboNguoiKyTen_SelectedIndexChanged;
            //ControlExtension.BindDataToCobobox(
            //    userManagement.GetUsersKyTenCoPhanQuyen("",
            //        Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.BoPhanClsXetNghiem, true), true),
            //    ref cboNguoiKyTen, "MaNguoiDung", "MaNguoiDung", "MaNguoiDung, TenNhanVien", "50,150", txtNguoiKyTen,
            //    1);
            //cboNguoiKyTen.SelectedIndexChanged += cboNguoiKyTen_SelectedIndexChanged;
            ucSearchLookupEditor_KyTentruongKhoa.Load_TruongKhoa();
            ucSearchLookupEditor_KyTenlanhdao.Load_LanhDao();
            lblKyLanhDao.Visible = ucSearchLookupEditor_KyTenlanhdao.Visible = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemSuDungChuKyLanhDao;
            if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemSuDungChuKyLanhDao)
                ucSearchLookupEditor_KyTenlanhdao.SelectedValue = null;
            IUserManagementService userManagement = new UserManagementService();
            ucSearchLookupEditor_DoiChieuSHPT1.Load_NguoiDoiCHieuSHPT();

            ControlExtension.BindDataToCobobox(
            userManagement.GetUsersKyTenCoPhanQuyen("",
                Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.BoPhanClsXetNghiem, true), false, true),
            ref cboNguoiThcuHienTQ, "MaNguoiDung", "MaNguoiDung", "MaNguoiDung, TenNhanVien", "50,150",
            txtNguoiThucHienTQ, 1);

            //  cboNguoiKyTen.SelectedValue = CommonAppVarsAndFunctions.UserID;
            dtpNgayInKQLuoi.Value = CommonAppVarsAndFunctions.ServerTime;
            dtpGioInKQRoi.Value = CommonAppVarsAndFunctions.ServerTime;
            dtpNgayInKQLuoi.Checked = false;
            dtpGioInKQRoi.Checked = false;

            lblNgayInSHPTLuoi.Visible = dtpNgayInKQLuoi.Visible = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemChongioKySHPT;
            pnNgayInRoi.Visible = lblNgayInSHPTRoi.Visible = dtpGioInKQRoi.Visible = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemChongioKySHPT;
            _reportLogo = _isSysConfig.Load_Logo("XN");
            //thông tin cho uc kết quả máy xét nghiệm
            analyzerResult1.UserId = CommonAppVarsAndFunctions.UserID;
            analyzerResult1.arrAnalyzerAllow = CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem;
            analyzerResult1.PcWorkPlace = CommonAppVarsAndFunctions.PCWorkPlace;
            analyzerResult1.ClsXetNghiemDinhDangKetqua = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemDinhDangKetqua;
            analyzerResult1.ClsXetNghiemKieuLayKetQuaMay = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemKieuLayKetQuaMay;
            analyzerResult1.suDungLayTuDong = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemFormKQMayTuDong;
            analyzerResult1.Load_CauHinh(CommonAppVarsAndFunctions.ServerTime);
            analyzerResult1.gioiHanBarcode = int.Parse(CommonAppVarsAndFunctions.sysConfig.BenhNhanSoKyTuBarCode);
            //thông tin cho uc kiểm soát chỉ định máy
            bool showMiddelware = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemLoaiKetNoiMay == EnumLoaiKetNoiMay.CoPhanMemTrungGian;
            ucKiemSoatChiDinhChayMay.Set_ShowForConfig(showMiddelware);
            ucKiemSoatChiDinhChayMay.BarcodeLenght = int.Parse(string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.BenhNhanSoKyTuBarCode) ? "4" : CommonAppVarsAndFunctions.sysConfig.BenhNhanSoKyTuBarCode);
            ucKiemSoatChiDinhChayMay.arrPhanQuyenBoPhan = CommonAppVarsAndFunctions.BoPhanClsXetNghiem;
            ucKiemSoatChiDinhChayMay.arrPhanQuyenNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem;
            ucKiemSoatChiDinhChayMay.SetDate(CommonAppVarsAndFunctions.ServerTime);
            ucKiemSoatChiDinhChayMay.Load_DanhSach_XetNghiem();
            ucKiemSoatChiDinhChayMay.userLogin = CommonAppVarsAndFunctions.UserID;

            ucPatientInformation1.dtpDateIn.Value = CommonAppVarsAndFunctions.ServerTime;
            ucPatientInformation1.Load_DanhMucCauHinh();

            ucDanhSachBenhNhanXN1.ArrLoaiXetNghiem = new[] { TestType.EnumTestType.SinhHocPhanTu, TestType.EnumTestType.SHPTThuongQuy };
            ucDanhSachBenhNhanXN1.Load_CauHinh();
            ucDanhSachBenhNhanXN1.Load_DSBenhNhan();
            ucDanhSachBenhNhanXN1.DataGridview_DsBenhNhan_CellEnter += UcDanhSachBenhNhanXN1_DataGridview_DsBenhNhan_CellEnter;
            ucDanhSachBenhNhanXN1.Button_TuyChon_Click += UcDanhSachBenhNhanXN1_Button_TuyChon_Click;
            Load_DanhSachPhieuInChon();
            foreach (TabPage tab in tabControl1.TabPages)
            {
                tab.BackColor = this.BackColor;
            }
            HightLightButton(btnKQXetNghiem);
        }
        private void Load_DanhSachPhieuInChon()
        {
            var data = _isSysConfig.Data_dm_xetnghiem_mauphieuin_tuychon(string.Empty);
            var dr = data.NewRow();
            dr["idmauchon"] = "NONE";
            dr["tenmauchon"] = LanguageExtension.GetResourceValueFromValue("MẶC ĐỊNH", LanguageExtension.AppLanguage);
            dr["IdFormSuDung"] = 0;
            data.Rows.InsertAt(dr, 0);
            data = WorkingServices.SearchResult_OnDatatable(data, "IdFormSuDung = 0");
            cboPhieuIn.DataSource = data;
            cboPhieuIn.ValueMember = "idmauchon";
            cboPhieuIn.DisplayMember = "tenmauchon";
            cboPhieuIn.SelectedValue = "NONE";
            if (data.Rows.Count == 1)
            {
                cboPhieuIn.Enabled = false;
            }
        }
        private void Load_ReportSHPT(string IdRportCha)
        {
            string oldValue = "NONE";
            if (cboPhieuInSHPT.SelectedIndex > -1)
            {
                oldValue = cboPhieuInSHPT.SelectedValue.ToString();
            }
            var dataSource = _isSysConfig.Data_dm_xetnghiem_mauphieuin_tuychon_CoMauCha(string.Empty);
            var data = WorkingServices.SearchResult_OnDatatable(dataSource, string.Format("IdFormSuDung = 2 and IdReportCha = '{0}'", IdRportCha));
            if (data.Rows.Count == 0)
            {
                data = dataSource.Clone();
            }
            var dr2 = data.NewRow();
            dr2["idmauchon"] = "NONE";
            dr2["tenmauchon"] = LanguageExtension.GetResourceValueFromValue("MẶC ĐỊNH", LanguageExtension.AppLanguage);
            dr2["IdFormSuDung"] = 2;
            data.Rows.InsertAt(dr2, 0);

            cboPhieuInSHPT.DataSource = data;
            cboPhieuInSHPT.ValueMember = "idmauchon";
            cboPhieuInSHPT.DisplayMember = "tenmauchon";
            cboPhieuInSHPT.SelectedValue = oldValue;
            if (data.Rows.Count == 1)
            {
                cboPhieuInSHPT.Enabled = false;
            }
        }
        private void UcKetQuaThuongQuy1_DataGridview_KetQua_FocusRowChanged(object sender, EventArgs e)
        {
            Load_ChiTietNguoiThucHien_ThuongQuy();
            Load_DienGia_DeNghi();
        }

        private void UcKetQuaThuongQuy1_DataGridview_KetQua_FocusColumnChanged(object sender, EventArgs e)
        {
            Load_ChiTietNguoiThucHien_ThuongQuy();
            Load_DienGia_DeNghi();
        }

        private void UcDanhSachBenhNhanXN1_Button_TuyChon_Click(object sender, EventArgs e)
        {
            if (pnSignature.Tag != null)
                pnSignature.Height = int.Parse(pnSignature.Tag.ToString());
        }

        private void UcDanhSachBenhNhanXN1_DataGridview_DsBenhNhan_CellEnter(object sender, EventArgs e)
        {
            Load_ChiTietXetNghiem();
        }

        private void CheckEnabledFunction()
        {
            _allowLuuKetQua = (CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionMicroBiologyEditResult))
                 || (CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionMicroBiologyInsertResult));
            _allowInKetQua = btnXemIn.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionMicroBiologyPrintResult);

            _allowXacNhan = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionMicroBiologyValidResult);
            _allowBoXacNhan = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionMicroBiologyInValidResult);

            btnXacNhanKQThuongQuy.Enabled = _allowXacNhan;
            btnHuyXacNhanKQThuongQuy.Enabled = _allowBoXacNhan;

            btnInketQua.Enabled = _allowInKetQua;
            btnLuuNguoiThucHienTQ.Enabled = _allowLuuKetQua;
        }

        private void Load_DSMayXN()
        {
            var dataMayXn = _isSysConfig.Data_h_mayxetnghiem_chitiet_theo_phanloai((int)PhanLoaiMayXN.EnumLoaiMayXN.SinhHocPhanTu);
            cboMayXn.SelectedIndexChanged -= cboMayXn_SelectedIndexChanged;
            cboMayXn.DataSource = dataMayXn;
            cboMayXn.ValueMember = "idmayxn";
            cboMayXn.DisplayMember = "tenhienthi";

            //colMayXN.DataSource = dataMayXn.Copy();
            //colMayXN.ValueMember = "idmayxn";
            //colMayXN.DisplayMember = "tenhienthi";
            cboMayXn.SelectedIndexChanged += cboMayXn_SelectedIndexChanged;
        }
        //private void cboNguoiKyTen_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cboNguoiKyTen.SelectedIndex > -1)
        //    {
        //        CommonAppVarsAndFunctions.TempSignIdXetNghiemSHPT = cboNguoiKyTen.SelectedValue.ToString().Trim();
        //        CommonAppVarsAndFunctions.TempSignNameXetNghiemSHPT = txtNguoiKyTen.Text;
        //    }
        //    else
        //    {
        //        CommonAppVarsAndFunctions.TempSignIdXetNghiemSHPT = string.Empty;
        //        CommonAppVarsAndFunctions.TempSignNameXetNghiemSHPT = string.Empty;
        //    }
        //}

        private void Load_ChiTietXetNghiem()
        {
            dtgChiDInh.CellEnter -= dtgChiDInh_CellEnter;
            ClearData();
            if (string.IsNullOrEmpty(ucDanhSachBenhNhanXN1.MaTiepNhanDangChon)) return;
            currentMaXn = string.Empty;
            ucPatientInformation1.LoadInformation(ucDanhSachBenhNhanXN1.MaTiepNhanDangChon);
            var dataInfo = ucPatientInformation1.DataSource;
            var dataChitiet = _xetnghiem.DuLieuKetQua_XN(dataInfo, 0
                , false, CommonAppVarsAndFunctions.UserID, string.Empty, false, DateTime.Now
                , CommonAppVarsAndFunctions.UserWorkPlace, string.Empty, false
                , new Common.TestType.EnumTestType[] { Common.TestType.EnumTestType.SinhHocPhanTu }
                , Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.NhomClsXetNghiem, true)
                , false, true);

            var checkDalayMau = QuiTrinhLAB.GetTrangThaiLayMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh);
            var checkDaNhanMau = QuiTrinhLAB.GetTrangThaiNhanMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh);

            if (checkDalayMau || checkDaNhanMau)
            {
                if (dataChitiet != null)
                {
                    for (var i = 0; i < dataChitiet.Rows.Count; i++)
                    {
                        var rDalayMau = bool.Parse(dataChitiet.Rows[i]["DaLayMau"].ToString());
                        var rDaNhanMau = bool.Parse(dataChitiet.Rows[i]["DaNhanMau"].ToString());
                        if ((!checkDalayMau || rDalayMau) && (!checkDaNhanMau || rDaNhanMau)) continue;
                        dataChitiet.Rows.RemoveAt(i);
                        i--;
                    }
                    dataChitiet.AcceptChanges();
                }
            }
            ControlExtension.BindDataToGrid(dataChitiet, ref dtgChiDInh, bvChiDInh);
            BindDataresult();
            dtgChiDInh.CellEnter += dtgChiDInh_CellEnter;
            //LoadGen_ToCombox();
            //Load_ImageResult();
            //Load_KetQua_Gen();
            SetDataResult();
            SetEnabledWithResult();
            Load_ChiTietXetNghiemThuongQuy(ucDanhSachBenhNhanXN1.MaTiepNhanDangChon, ucPatientInformation1.dtpDateIn.Value, ucDanhSachBenhNhanXN1.HisIdDangChon, dataInfo);
        }
        private void Load_ChiTietXetNghiemThuongQuy(string matiepNhan, DateTime ngayTiepNhan, int hisId, DataTable databinding)
        {
            Reset_NguoiThucHien();
            ucKetQuaThuongQuy1.XoaThongTinDS();
            ucKetQuaThuongQuy1.CurrentMaTiepNhan = matiepNhan;
            ucKetQuaThuongQuy1.CurrentNgayTiepNhan = ngayTiepNhan;
            ucKetQuaThuongQuy1.hisId = hisId;
            ucKetQuaThuongQuy1.lstDanhSachNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem.ToList();
            ucKetQuaThuongQuy1.BindPatientInfo(databinding);
            ucKetQuaThuongQuy1._dtPatient = databinding;
            ucKetQuaThuongQuy1.Load_ChiTietXN(matiepNhan, databinding);
        }
        private void Reset_NguoiThucHien()
        {
            dtpNguoiThucHienTQ.Value = CommonAppVarsAndFunctions.ServerTime;
            dtpNguoiThucHienTQ.Checked = false;
            cboNguoiThcuHienTQ.SelectedIndex = -1;
            dtpNguoiThucHienTQ.Checked = false;
            btnLayThongTinTruocTQ.Enabled = btnLuuNguoiThucHienTQ.Enabled = _allowLuuKetQua;
        }
        private void Load_ChiTietNguoiThucHien_ThuongQuy()
        {
            Reset_NguoiThucHien();
            cboNguoiThcuHienTQ.SelectedValue = ucKetQuaThuongQuy1.NguoiThucHien_DongDangChon;
            var ngayThucHien = ucKetQuaThuongQuy1.TGThucHien_DongDangChon;
            if (ngayThucHien != null)
            {
                dtpNguoiThucHienTQ.Checked = true;
                dtpNguoiThucHienTQ.Value = (DateTime)ngayThucHien;
            }
            btnLuuNguoiThucHienTQ.Enabled = !ucKetQuaThuongQuy1.DaXacNhan_DongDangChon;

            if (btnLuuNguoiThucHienTQ.Enabled)
                btnLuuNguoiThucHienTQ.Enabled = _allowLuuKetQua;

            btnLayThongTinTruocTQ.Enabled = cboNguoiThcuHienTQ.Enabled = dtpNguoiThucHienTQ.Enabled = btnLuuNguoiThucHienTQ.Enabled;
        }
        private void Load_DienGia_DeNghi()
        {
            txtDienGiai.Text = ucKetQuaThuongQuy1.DienGiaiDangChon;
            txtDeNghi.Text = ucKetQuaThuongQuy1.DeNghiDangChon;
            txtDienGiai.ReadOnly = ucKetQuaThuongQuy1.DaXacNhan_DongDangChon;
            txtDeNghi.ReadOnly = ucKetQuaThuongQuy1.DaXacNhan_DongDangChon;
            btnThemDienGiai_Luoi.Enabled = btnLuuNX_DeNghi.Enabled = !ucKetQuaThuongQuy1.DaXacNhan_DongDangChon;
        }
        private void BindDataresult()
        {
            cboMayXn.SelectedIndexChanged -= cboMayXn_SelectedIndexChanged;
            cboMayXn.DataBindings.Clear();
            cboMayXn.SelectedIndex = -1;

            txtCSBT.DataBindings.Clear();
            txtCSBT.Text = string.Empty;

            txtDonViTinh.DataBindings.Clear();
            txtDonViTinh.Text = string.Empty;

            txtGhiChu.DataBindings.Clear();
            txtGhiChu.Text = string.Empty;

            rchThongTinXN_ThongThuong.DataBindings.Clear();
            rchThongTinXN_ThongThuong.Text = string.Empty;

            txtPhuongPhap.DataBindings.Clear();
            txtPhuongPhap.Text = string.Empty;
            chkKetQuaDaXacNhan.DataBindings.Clear();
            chkKetQuaDaXacNhan.Checked = false;

            if (dtgChiDInh.RowCount > 0)
            {
                cboMayXn.DataBindings.Add("SelectedValue", dtgChiDInh.DataSource, "IDMayXetNghiem", true, DataSourceUpdateMode.Never, string.Empty);
                txtPhuongPhap.DataBindings.Add("Text", dtgChiDInh.DataSource, "PhuongPhap", true, DataSourceUpdateMode.Never, string.Empty);
                txtCSBT.DataBindings.Add("Text", dtgChiDInh.DataSource, "CSBT", true, DataSourceUpdateMode.Never, string.Empty);
                txtDonViTinh.DataBindings.Add("Text", dtgChiDInh.DataSource, "DonVi", true, DataSourceUpdateMode.Never, string.Empty);
                txtGhiChu.DataBindings.Add("Text", dtgChiDInh.DataSource, "GhiChu", true, DataSourceUpdateMode.Never, string.Empty);

                chkKetQuaDaXacNhan.DataBindings.Add("Checked", dtgChiDInh.DataSource, "XacNhanKQ", true, DataSourceUpdateMode.Never, false);
                rchThongTinXN_ThongThuong.DataBindings.Add("Rtf", dtgChiDInh.DataSource, "NoiKiemTraChatLuong", true, DataSourceUpdateMode.Never, string.Empty);
            }
            cboMayXn.SelectedIndexChanged += cboMayXn_SelectedIndexChanged;
        }
        private void ClearData()
        {
            pnResult_Containt.Controls.Clear();
            txtMaSoMau.Text = string.Empty;
            cboMayXn.DataBindings.Clear();
            cboMayXn.SelectedIndex = -1;

            txtCSBT.DataBindings.Clear();
            txtCSBT.Text = string.Empty;

            txtDonViTinh.DataBindings.Clear();
            txtDonViTinh.Text = string.Empty;

            txtGhiChu.DataBindings.Clear();
            txtGhiChu.Text = string.Empty;

            rchThongTinXN_ThongThuong.DataBindings.Clear();
            rchThongTinXN_ThongThuong.Text = string.Empty;

            txtPhuongPhap.DataBindings.Clear();
            txtPhuongPhap.Text = string.Empty;
            chkKetQuaDaXacNhan.DataBindings.Clear();
            chkKetQuaDaXacNhan.Checked = false;
            ucSearchLookupEditor_DoiChieuSHPT1.DataBindings.Clear();
            ucSearchLookupEditor_DoiChieuSHPT1.SelectedValue = null;
            dtpTGDoiChieu.DataBindings.Clear();
            dtpTGDoiChieu.Checked = false;
        }

        private void XacNhanKetQua(bool valid)
        {
            if (dtgChiDInh.CurrentRow != null)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes((valid ? "Xác nhận " : "Hủy xác nhận ") + "kết quả?"))
                {
                    string validText = (valid
                    ? Common.CommonConstant.IsValided
                    : Common.CommonConstant.InValid);

                    string maTiepNhan = dtgChiDInh.CurrentRow.Cells[colMaTiepNhan.Name].Value.ToString();
                    string maXn = dtgChiDInh.CurrentRow.Cells[colMaXN.Name].Value.ToString();
                    _xetnghiem.XacNhan_KQ_XN(maTiepNhan, maXn, validText,
                        valid, CommonAppVarsAndFunctions.UserID, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXacNhanDe, (int)CommonAppVarsAndFunctions.sysConfig.LayNguoiThucHien);
                    if (valid)
                    {
                        if (chkInKhiXacNhanSHPT.Checked)
                        {
                            btnInketQua_Click(btnXacNhanKetQua, new EventArgs());
                        }
                    }
                    Load_ChiTietXetNghiem();
                    bvChiDInh.BindingSource.Position = bvChiDInh.BindingSource.Find("MaXN", maXn);
                    if (!valid)
                    {
                        HuyXacNhanHis(maTiepNhan, maXn);
                    }
                }
            }
        }
        private HisConnection _hisInfo;
        private readonly IConnectHISService _iHisData = new ConnectHISService();
        private void HuyXacNhanHis(string matiepNhan, string lstMaXn)
        {
            try
            {
                if (!string.IsNullOrEmpty(ucDanhSachBenhNhanXN1.MaTiepNhanDangChon))
                {
                    var hisId = ucDanhSachBenhNhanXN1.HisIdDangChon;
                    if (hisId != (int)HisProvider.Vimes) return;
                    var lst = new List<HISResultValid>();
                    var date = CommonAppVarsAndFunctions.ServerTime;
                    var data = _xetnghiem.Data_DanhSach_HuyXacNhanHIS(matiepNhan, lstMaXn, CommonAppVarsAndFunctions.UserID);
                    if (data.Rows.Count <= 0) return;
                    foreach (DataRow dr in data.Rows)
                    {
                        var obj = new HISResultValid();
                        obj.IDKhoaXetNghiem = dr["MaBoPhanHIS"].ToString();
                        obj.NguoiXacNhanKhoa = dr["MaNVHIS"].ToString();
                        obj.SoHoSo = dr["SohoSo"].ToString();
                        obj.SoPhieuChiDinh = dr["SoPhieuYeuCau"].ToString();
                        obj.ThoiGianXacNhanKhoa = date;
                        obj.TrangThaiXacNhanKhoa = false;
                        lst.Add(obj);
                    }
                    if (lst.Count <= 0) return;
                    _hisInfo = CommonAppVarsAndFunctions.HisConnectList.FirstOrDefault(x => x.HisID == HisProvider.Vimes);
                    Task.Factory.StartNew(() =>
                    {
                        _iHisData.UploadValidResult(_hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, lst);
                    });
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.CloseAlert();
                ErrorService.GetFrameworkErrorMessage(ex, "HuyXacNhanHIS");
            }
        }
        private void LuuNguoiThucHien()
        {
            if (dtgChiDInh.CurrentRow != null)
            {
                string maTiepNhan = dtgChiDInh.CurrentRow.Cells[colMaTiepNhan.Name].Value.ToString();
                string maXn = dtgChiDInh.CurrentRow.Cells[colMaXN.Name].Value.ToString();
                var nguoiDoiChieu = (ucSearchLookupEditor_DoiChieuSHPT1.SelectedValue ?? string.Empty).ToString();
                var ngayDoiChieu = dtpTGDoiChieu.Checked ? dtpTGDoiChieu.Value.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty;
                _xetnghiem.UpdateNguoiDoiChieu(maTiepNhan, maXn, nguoiDoiChieu, ngayDoiChieu);
                NguoiThucHienTruocSHPT = nguoiDoiChieu;
                if (!string.IsNullOrEmpty(ngayDoiChieu))
                    GioThucHientruocSHPT = DateTime.Parse(ngayDoiChieu);
            }
        }

        private void LuuKetQua()
        {
            if (dtgChiDInh.CurrentRow != null)
            {
                string maTiepNhan = dtgChiDInh.CurrentRow.Cells[colMaTiepNhan.Name].Value.ToString();
                string maXn = dtgChiDInh.CurrentRow.Cells[colMaXN.Name].Value.ToString();
                var nguoiDoiChieu = (ucSearchLookupEditor_DoiChieuSHPT1.SelectedValue ?? string.Empty).ToString();
                var nguongDuoi = dtgChiDInh.CurrentRow.Cells[colNguongDuoi.Name].Value.ToString();
                var nguongTren = dtgChiDInh.CurrentRow.Cells[colNguongTren.Name].Value.ToString();
                var dkDanhGia = dtgChiDInh.CurrentRow.Cells[colDKBatThuong.Name].Value.ToString();
                var idMayXN = (cboMayXn.SelectedIndex > -1 ? cboMayXn.SelectedValue.ToString() : string.Empty);
                var idMauIn = int.Parse(dtgChiDInh.CurrentRow.Cells[colMauInSHPT.Name].Value.ToString());
                var phuongphap = txtPhuongPhap.Text;
                var noiKiemTra = rchThongTinXN_ThongThuong.Rtf;
                var ghiChu = txtGhiChu.Text;
                if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_1
                    || idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_2
                    || idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_4)
                {
                    if (ketqua5Hinh != null)
                    {
                        ketqua5Hinh.Luu_KetQua(nguongTren, nguongDuoi, dkDanhGia, txtGhiChu.Text, idMayXN, phuongphap, noiKiemTra, tempGhiChu, tempidMayXn, tempKetQua);
                    }
                }
                if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_3)
                {
                    if (ketquaLuoiThuong != null)
                    {
                        ketquaLuoiThuong.Luu_KetQua(nguongTren, nguongDuoi, dkDanhGia, txtGhiChu.Text, idMayXN, phuongphap, noiKiemTra, tempGhiChu, tempidMayXn, tempKetQua);
                    }
                }
                else if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_5)
                {
                    if (ketquaLuoiThuong != null)
                    {
                        //phương pháp dùng làm cho đề nghị
                        ketquaThuong.Luu_KetQua(nguongTren, nguongDuoi, dkDanhGia, txtGhiChu.Text, idMayXN, noiKiemTra, tempGhiChu, tempidMayXn, tempKetQua);
                    }
                }
                LuuNguoiThucHien();
                //_xetnghiem.CapNhat_PhuongPhapThucHien (maTiepNhan, maXn, idMayxn);
                var oldMXN = dtgChiDInh.CurrentRow.Cells[colMaXN.Name].Value.ToString();
                Load_ChiTietXetNghiem();
                bvChiDInh.BindingSource.Position = bvChiDInh.BindingSource.Find("Maxn", oldMXN);
            }
        }
        private bool InKetQua(bool isPreview, bool isPrint, bool PrintAndExport, bool exportonly, ref string exportString, bool byList)
        {
            if (dtgChiDInh.CurrentRow != null)
            {
                if (chkInTheoChiDinh.Checked)
                {
                    if (Check_AllowPrint(chkKetQuaDaXacNhan.Checked, dtgChiDInh.CurrentRow.Cells[colTenXN.Name].Value.ToString()))
                        ThucHienInKetQua(dtgChiDInh.CurrentRow.Index, isPreview, isPrint, PrintAndExport, exportonly, ref exportString);
                }
                else
                {
                    for (int i = 0; i < dtgChiDInh.RowCount; i++)
                    {
                        if (Check_AllowPrint(bool.Parse(dtgChiDInh[colChiDinh_DaXacNhan.Name, i].Value.ToString()), dtgChiDInh[colTenXN.Name, i].Value.ToString()))
                            ThucHienInKetQua(i, isPreview, isPrint, PrintAndExport, exportonly, ref exportString);
                    }
                }
                if (!byList)
                {
                    var currentMaXn = dtgChiDInh.CurrentRow.Cells[colMaXN.Name].Value.ToString();
                    Load_ChiTietXetNghiem();
                    bvChiDInh.BindingSource.Position = bvChiDInh.BindingSource.Find("MaXN", currentMaXn);
                }
            }
            return true;
        }
        private bool Check_AllowPrint(bool isValid, string tenXN)
        {
            if (ucSearchLookupEditor_DoiChieuSHPT1.SelectedValue == null)
            {
                CustomMessageBox.MSG_Information_OK(string.Format("Hãy nhập thông tin người thực hiện.\nXN: {0}", tenXN));
                return false;
            }
            else if (!dtpTGDoiChieu.Checked)
            {
                CustomMessageBox.MSG_Information_OK(string.Format("Hãy nhập thời gian thực hiện.\nXN: {0}", tenXN));
                return false;
            }
            else if (!isValid && CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemChiInKetQuaDaDuyet)
            {
                CustomMessageBox.MSG_Information_OK(string.Format("Bạn chưa xác nhận kết quả.\nXN: {0}", tenXN));
                return false;
            }
            return true;
        }
        private void ThucHienInKetQua(int i, bool isPreview, bool isPrint, bool PrintAndExport, bool exportonly, ref string exportString)
        {
            var maureportChon = cboPhieuInSHPT.SelectedIndex > -1 ? cboPhieuInSHPT.SelectedValue.ToString() : string.Empty;
            maureportChon = (maureportChon.Equals("NONE") ? string.Empty : maureportChon);
            DM_XETNGHIEM_MAUPHIEUIN_TUYCHON objMauChonIn = null;
            if (!string.IsNullOrEmpty(maureportChon))
            {
                objMauChonIn = new DM_XETNGHIEM_MAUPHIEUIN_TUYCHON();
                objMauChonIn = _isSysConfig.Get_Info_dm_xetnghiem_mauphieuin_tuychon(maureportChon);
            }
            var idNgonNgu = (objMauChonIn != null ? objMauChonIn.MaNgonNgu : string.Empty);
            var resultReportInfo = new XtraReport();
            var reportUse = new ReportModel();

            string tenphieuIn = string.Empty;
            var dataInfo = ucDanhSachBenhNhanXN1.ThongTinBNDangChon;
            string testPrint = dtgChiDInh[colMaXN.Name, i].Value.ToString();

            var userSign = WorkingServices.ObjecToString(ucSearchLookupEditor_KyTentruongKhoa.SelectedValue);
            var dataChitiet = _xetnghiem.DuLieuIn_XN(dataInfo, 0
         , false, userSign, string.Format("'{0}'", testPrint), chkPrintTitle.Checked
         , (dtpGioInKQRoi.Checked ? dtpGioInKQRoi.Value : (DateTime?)null)
         , CommonAppVarsAndFunctions.UserWorkPlace, string.Empty, chkRePrint.Checked
         , new Common.TestType.EnumTestType[] { TestType.EnumTestType.SinhHocPhanTu }
         , Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.NhomClsXetNghiem, true)
         , CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemThoiGianInKetQuaLanDau, true, string.Empty, true, string.Empty);

            var f = new FrmPreViewReport();
            f.idNgonNgu = idNgonNgu;
            f.UserSign = userSign;
            int idMauIn = int.Parse(dataChitiet.Rows[0]["MauInSHPT"].ToString());
            var matiepNhan = dataChitiet.Rows[0]["MaTiepNhan"].ToString();
            var maxn = dataChitiet.Rows[0]["MaXN"].ToString();
            var reportname = string.Empty;
            if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_1)
            {
                reportname = (string.IsNullOrEmpty(maureportChon) ? ReportConstants.KetQuaXnSHPT_1 : maureportChon);
                reportUse = GetReportInList(reportname);
                if (reportUse == null) return;
            }
            else if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_2)
            {
                reportname = (string.IsNullOrEmpty(maureportChon) ? ReportConstants.KetQuaXnSHPT_2 : maureportChon);
                reportUse = GetReportInList(reportname);
                if (reportUse == null) return;
            }
            else if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_3)
            {
                reportname = (string.IsNullOrEmpty(maureportChon) ? ReportConstants.KetQuaXnSHPT_3 : maureportChon);
                reportUse = GetReportInList(reportname);
                if (reportUse == null) return;
            }
            else if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_4)
            {
                reportname = (string.IsNullOrEmpty(maureportChon) ? ReportConstants.KetQuaXnSHPT_4 : maureportChon);
                reportUse = GetReportInList(reportname);
                if (reportUse == null) return;
            }
            else if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_5)
            {
                reportname = (objMauChonIn == null ? ReportConstants.KetQuaXnSHPT_5 : objMauChonIn.Idreport);
                reportUse = GetReportInList(reportname);
                if (reportUse == null) return;
            }
            var printerName = string.Empty;
            if (ListCauHinhMayIn.Count > 0)
            {
                var objSelect = ListCauHinhMayIn.Where(x => x.Reporttemplateid.Equals(ReportResultTemplateConstant.Mau_TC_ThongThuong, StringComparison.OrdinalIgnoreCase));
                if (objSelect != null)
                {
                    var objPrinter = objSelect.First();
                    printerName = objPrinter.Printername;
                }
            }
            if (listPrinter.Items.Count > 0 && string.IsNullOrEmpty(printerName))
            {
                if (listPrinter.SelectedIndex == -1)
                {
                    listPrinter.SelectedIndex = 0;
                }
                printerName = listPrinter.SelectedItem.ToString();
            }
            var havePrint = false;
            var arrLogo = GraphicSupport.ImageToByteArray(_reportLogo);
            if (!dataChitiet.Columns.Contains("TenLanhDaoKy"))
                dataChitiet.Columns.Add("TenLanhDaoKy", typeof(string));
            if (!dataChitiet.Columns.Contains("ChucVuLanhDaoKyTen"))
                dataChitiet.Columns.Add("ChucVuLanhDaoKyTen", typeof(string));
            //convert 10^ : các gái trị E+
            foreach (DataRow drCo in dataChitiet.Rows)
            {
                var kq = drCo["KetQua"].ToString().Trim();
                var kqDinhLuong = drCo["KetQuaDinhLuong"].ToString().Trim();
                var kqQuiDoi = drCo["KetQuaNhanHeSo"].ToString().Trim();
                drCo["KetQuaDinhLuong"] = WorkingServices.Convert_SubSript(kqDinhLuong);
                drCo["KetQua"] = WorkingServices.Convert_SubSript(kq);
                drCo["KetQuaNhanHeSo"] = WorkingServices.Convert_SubSript(kqQuiDoi);
                drCo["ReportLogo"] = arrLogo;
                drCo["TenLanhDaoKy"] = ucSearchLookupEditor_KyTenlanhdao.GetSeletetedDoctorName();
                drCo["ChucVuLanhDaoKyTen"] = ucSearchLookupEditor_KyTenlanhdao.GetSeletetedDoctorPosition();
                if (!string.IsNullOrEmpty(idNgonNgu))
                {
                    var maXn = drCo["MaXn"].ToString();
                    var maKhoaPhong = drCo["MaDonVi"].ToString();
                    var maDoiTuong = drCo["MaDoiTuongDichVu"].ToString();
                    var maNhomXN = drCo["MaNhomCLS"].ToString();
                    var maboPhanXN = drCo["MaBoPhan"].ToString();
                    var nguoiXacNhan = drCo["NguoiXacNhan"].ToString();

                    var tenXnB = TimNgonNguBienDich(maXn, EnumLoaiDanhMucNgonNgu.DanhMucXetNghiem.ToString(), idNgonNgu);
                    if (!string.IsNullOrEmpty(tenXnB))
                        drCo["TenXN"] = tenXnB;
                    var tenKhoaPhongB = TimNgonNguBienDich(maKhoaPhong, EnumLoaiDanhMucNgonNgu.DanhMucKhoaPhong.ToString(), idNgonNgu);
                    if (!string.IsNullOrEmpty(tenKhoaPhongB))
                        drCo["TenKhoaPhong"] = tenKhoaPhongB;
                    var tendoiTuongB = TimNgonNguBienDich(maDoiTuong, EnumLoaiDanhMucNgonNgu.DanhMucDoiTuong.ToString(), idNgonNgu);
                    if (!string.IsNullOrEmpty(tendoiTuongB))
                        drCo["TenDoiTuongDichVu"] = tendoiTuongB;
                    var tenNhomXnB = TimNgonNguBienDich(maNhomXN, EnumLoaiDanhMucNgonNgu.DanhMucNhomXN.ToString(), idNgonNgu);
                    if (!string.IsNullOrEmpty(tenNhomXnB))
                        drCo["TenNhomCLS"] = tenNhomXnB;
                    var tenBoPhanXNB = TimNgonNguBienDich(maboPhanXN, EnumLoaiDanhMucNgonNgu.DanhMucBoPhan.ToString(), idNgonNgu);
                    if (!string.IsNullOrEmpty(tenNhomXnB))
                        drCo["TenBoPhan"] = tenBoPhanXNB;
                    var tenNguoiXacNhanB = TimNgonNguBienDich(nguoiXacNhan, EnumLoaiDanhMucNgonNgu.DanhMucNhanVien.ToString(), idNgonNgu);
                    if (!string.IsNullOrEmpty(tenNguoiXacNhanB))
                        drCo["TenNguoiXacNhan"] = tenNguoiXacNhanB;

                    var tenNguoiLanhDao = TimNgonNguBienDich(ucSearchLookupEditor_KyTenlanhdao.GetSeletetedDoctorName(), EnumLoaiDanhMucNgonNgu.DanhMucNhanVien.ToString(), idNgonNgu);
                    if (!string.IsNullOrEmpty(tenNguoiLanhDao))
                        drCo["TenLanhDaoKy"] = tenNguoiLanhDao;

                }
            }
            //if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_2 
            //    || idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_4
            //    || idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_5)
            //{
            var dataChitietSub = _xetnghiem.Data_SHPT_Gen_In(matiepNhan, maxn, string.Empty);
            var dataSubPrint = new DataTable();
            dataSubPrint.Columns.Add("TenTacNhan", typeof(string));
            dataSubPrint.Columns.Add("KetQuaTacNhan", typeof(string));
            dataSubPrint.Columns.Add("KetQuaDLTacNhan", typeof(string));

            if (dataChitietSub.Rows.Count > 0)
            {
                var dataTemp = dataSubPrint.Clone();
                //Thêm dòng default để tạo thông tin GEN, kết quả Ct
                if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_5)
                {
                    var dr1 = dataTemp.NewRow();
                    dr1["TenTacNhan"] = "Gen";
                    dr1["KetQuaTacNhan"] = "Giá trị Ct";
                    dr1["KetQuaDLTacNhan"] = "Giá trị Ct";
                    dataTemp.Rows.Add(dr1);
                }
                foreach (DataRow drCT in dataChitietSub.Rows)
                {
                    var dr = dataTemp.NewRow();
                    dr["TenTacNhan"] = drCT["TenXN"];
                    dr["KetQuaTacNhan"] = drCT["KetQua"];
                    dr["KetQuaDLTacNhan"] = drCT["KetQuaDinhLuong"];
                    dataTemp.Rows.Add(dr);
                }
                dataSubPrint = dataTemp;
            }
            //}
            resultReportInfo = _reportInfo.CreateReportFromStream(reportUse.ReportSuDung);
            if (resultReportInfo == null)
            {
                CustomMessageBox.MSG_Information_OK("Report chưa được khai báo.");
                return;
            }
            if (!string.IsNullOrEmpty(reportUse.ReportSub1))
            {
                var rpSubInfo1 = GetReportInList(reportUse.ReportSub1);
                if (rpSubInfo1 != null)
                {
                    var rpSub1 = _reportInfo.CreateReportFromStream(rpSubInfo1.ReportSuDung);
                    if (rpSub1 != null)
                    {
                        dataSubPrint.TableName = reportUse.TenDatatableSub1;
                        var dataSet2 = new DataSet(reportUse.TenDataSetSub1);
                        dataSet2.Tables.Add(dataSubPrint.Copy());
                        rpSub1.DataSource = dataSet2;
                        var subReport1 = resultReportInfo.FindControl(reportUse.ReportSub1, true);
                        if (subReport1 != null)
                        {
                            var sub = ((XRSubreport)subReport1);
                            sub.ReportSource = rpSub1;
                            sub.ReportSourceUrl = string.Empty;
                        }
                    }
                }
            }
            havePrint = f.ShowReport(resultReportInfo, dataChitiet, !isPreview, printerName, "XN", reportUse.TenDataset, reportUse.TenDatatable, reportname);
            if (havePrint)
            {
                var conditSomeTestPrint = string.Empty;
                for (int i2 = 0; i2 < dataChitiet.Rows.Count; i2++)
                {
                    conditSomeTestPrint += (string.IsNullOrEmpty(conditSomeTestPrint) ? "" : ",") + string.Format("'{0}'", dataChitiet.Rows[i2]["Maxn"].ToString());
                }
                string categoryPrint = string.Empty;
                var lanIn = 0;
                var dataDistincCategory = dataChitiet.AsDataView().ToTable(true, new string[] { "manhomcls", "LanInCuaXN" });
                foreach (DataRow drC in dataDistincCategory.Rows)
                {
                    categoryPrint += (string.IsNullOrEmpty(categoryPrint) ? "" : ",") + string.Format("{0}", drC["manhomcls"].ToString());
                    if (int.Parse(drC["LanInCuaXN"].ToString()) > lanIn)
                        lanIn = int.Parse(drC["LanInCuaXN"].ToString());
                }

                string maTiepNhan = dtgChiDInh.CurrentRow.Cells[colMaTiepNhan.Name].Value.ToString();
                _xetnghiem.CapNhatPrintOut_WithoutReportType(maTiepNhan, conditSomeTestPrint, string.Empty
                            , true, CommonAppVarsAndFunctions.UserID, string.Empty, chkValidWhenPrint.Checked
                            , CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXacNhanDe, CommonAppVarsAndFunctions.TempSignIdXetNghiemSHPT, (int)CommonAppVarsAndFunctions.sysConfig.LayNguoiThucHien);

                _xetnghiem.CapNhat_In_KQ_XN(maTiepNhan, CommonAppVarsAndFunctions.UserID, chkValidWhenPrint.Checked);

                _xetnghiem.UpdatePrintOutCategory(maTiepNhan, categoryPrint, true, CommonAppVarsAndFunctions.UserID);
                workingLog.NhatKy_InKetQua(maTiepNhan, CommonAppVarsAndFunctions.TempSignIdXetNghiemSHPT, CommonAppVarsAndFunctions.UserID, categoryPrint, conditSomeTestPrint, lanIn, Environment.MachineName);
                if (chkValidWhenPrint.Checked)
                {
                    if (!conditSomeTestPrint.Contains(";"))
                        conditSomeTestPrint = conditSomeTestPrint.Replace("'", "").Trim();

                    _xetnghiem.CapNhatValid_WithCondit(maTiepNhan,
                                                       conditSomeTestPrint, true, CommonAppVarsAndFunctions.UserID);
                    _xetnghiem.CapNhat_Valid_XN(maTiepNhan, CommonAppVarsAndFunctions.UserID);
                }
            }
        }
        private DataTable DataNgonNgu = new DataTable();
        private DataTable GetData_NgonNgu()
        {
            if (DataNgonNgu == null)
                DataNgonNgu = _isSysConfig.Data_dm_ngonngu_danhmuc(string.Empty, string.Empty, string.Empty);
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
        private void SetDataResult()
        {
            var pnManChe = new Panel { Size = pnResult_Containt.Size, BackColor = Color.FromArgb(224, 238, 243) };
            ucSearchLookupEditor_DoiChieuSHPT1.SelectedValue = null;
            dtpTGDoiChieu.Checked = false;

            ucGroupHeaderChuThich.GroupCaption =
                LanguageExtension.GetResourceValueFromValue("CHÚ THÍCH", LanguageExtension.AppLanguage);//"CHÚ THÍCH";
            if (dtgChiDInh.CurrentRow != null)
            {
                var idMauIn = int.Parse(dtgChiDInh.CurrentRow.Cells[colMauInSHPT.Name].Value.ToString());
                var maXN = dtgChiDInh.CurrentRow.Cells[colMaXN.Name].Value.ToString();
                if (maXN == currentMaXn)
                    return;
                txtMaSoMau.Text = "";
                currentMaXn = maXN;

                var imagSize = new Size(646, 380);
                if (!string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemKichCoHinhSHPT))
                {
                    var arr = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemKichCoHinhSHPT.Split('x');
                    if (arr.Length == 2)
                    {
                        imagSize = new Size(int.Parse(arr[0]), int.Parse(arr[1]));
                    }
                }
                pnResult_Containt.Controls.Clear();
                pnResult_Containt.Controls.Add(pnManChe);
                pnManChe.Location = new Point(0, 0);

                ketqua5Hinh = new ucKetQua_SHPT_5_Hinh();
                ketquaLuoiThuong = new ucKetQua_SHPT_LuoiThuong();
                ketquaThuong = new ucKetQua_SHPT_KetQuaThuong();

                var nguoiDoiChieu = dtgChiDInh.CurrentRow.Cells[colChiDinh_NguoiXacNhan2.Name].Value.ToString();
                var ngayDoichieu = dtgChiDInh.CurrentRow.Cells[colChiDinh_ThoiGianXacNhanKQ2.Name].Value.ToString();
                if (string.IsNullOrEmpty(ngayDoichieu))
                    dtpTGDoiChieu.Checked = false;
                else
                {
                    dtpTGDoiChieu.Value = DateTime.Parse(ngayDoichieu);
                    dtpTGDoiChieu.Checked = true;
                }
                ucSearchLookupEditor_DoiChieuSHPT1.SelectedValue = nguoiDoiChieu;
                txtGhiChu.Text = dtgChiDInh.CurrentRow.Cells[colGhiChu.Name].Value.ToString();
                txtMaSoMau.Text = dtgChiDInh.CurrentRow.Cells[colMaSoMau.Name].Value.ToString();
                tempGhiChu = txtGhiChu.Text;
                //var SHPTGenName = dtgChiDInh.CurrentRow.Cells[colSHPTGenName.Name].Value.ToString();
                //var intFlat = int.Parse(dtgChiDInh.CurrentRow.Cells[colCoKetQua.Name].Value.ToString());
                var maTiepNhan = dtgChiDInh.CurrentRow.Cells[colMaTiepNhan.Name].Value.ToString();
                var maChiDinh = dtgChiDInh.CurrentRow.Cells[colMaXN.Name].Value.ToString();
                var ketQua = dtgChiDInh.CurrentRow.Cells[colKetqua.Name].Value.ToString();
                var donViTinh = dtgChiDInh.CurrentRow.Cells[colDonViTinh.Name].Value.ToString();
                var daXacNhan = bool.Parse(dtgChiDInh.CurrentRow.Cells[colChiDinh_DaXacNhan.Name].Value.ToString());
                var dataPatient = _patient.Get_Data_BenhNhan_TiepNhan(null, null, maTiepNhan,
                       new string[] { });
                var strLamtron = dtgChiDInh.CurrentRow.Cells[colKetQua_Lamtron.Name].Value.ToString();
                var lamtron = int.Parse(string.IsNullOrEmpty(strLamtron) ? "0" : strLamtron);
                var strheso = dtgChiDInh.CurrentRow.Cells[colKetQua_HeSoNhan.Name].Value.ToString();
                var heso = float.Parse(string.IsNullOrEmpty(strheso) ? "-1" : strheso);
                var ketquaheso = dtgChiDInh.CurrentRow.Cells[colKetQua_KetQuaHeSo.Name].Value.ToString();
                var lanXn = int.Parse(dtgChiDInh.CurrentRow.Cells[colChiDinh_lanxn.Name].Value.ToString());
                var tgXacNhanThucHien = (string.IsNullOrEmpty(dtgChiDInh.CurrentRow.Cells[colChiDinh_ThoiGianXacNhanThucHien.Name].Value.ToString()) ? (DateTime?)null : DateTime.Parse(dtgChiDInh.CurrentRow.Cells[colChiDinh_ThoiGianXacNhanThucHien.Name].Value.ToString()));
                var nguoiNhapKQ = dtgChiDInh.CurrentRow.Cells[colChiDinh_NguoiNhap.Name].Value.ToString();
                var phuongPhap = dtgChiDInh.CurrentRow.Cells[colPhuongPhap.Name].Value.ToString();
                var idMaytemp = dtgChiDInh.CurrentRow.Cells[colDS_IdMayXn.Name].Value.ToString();
                tempidMayXn = int.Parse(string.IsNullOrEmpty(idMaytemp) ? "0" : idMaytemp);
                tempKetQua = ketQua;
                //_xetnghiem.Get_Patient_XN(maTiepNhan
                // , ucPatientInformation1.dtpDateIn.Value.ToString("yyyy-MM-dd"), enumThucHien.TatCa
                // , enumThucHien.TatCa, enumThucHien.TatCa
                // , CommonAppVarsAndFunctions.UserWorkPlace, TestType.EnumTestType.SinhHocPhanTu
                // , QuiTrinhLAB.GetTrangThaiLayMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh)
                // , QuiTrinhLAB.GetTrangThaiNhanMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh)
                // , string.Empty, Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.BoPhanClsXetNghiem, false)
                // , string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_1)
                {
                    pnResult_Containt.Controls.Add(ketqua5Hinh);
                    ketqua5Hinh.Dock = DockStyle.Fill;
                    ketqua5Hinh.KetQuaGen = false;
                    ketqua5Hinh.DaXacNhan = daXacNhan;
                    ketqua5Hinh.CurrentPCWorkPlace = CommonAppVarsAndFunctions.PCWorkPlace;
                    ketqua5Hinh.CurrentPCWorkPlace = CommonAppVarsAndFunctions.PCWorkPlace;
                    ketqua5Hinh.CurrentuserID = CommonAppVarsAndFunctions.UserID;
                    ketqua5Hinh.CurrentarrayAllowNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem;
                    ketqua5Hinh.Load_KetQua_Hinh(maTiepNhan, maChiDinh, ketQua, heso
                        , lamtron, ketquaheso, nguoiNhapKQ);

                    ketqua5Hinh.KichCoHinhSHPT = imagSize;
                    Load_ReportSHPT(ReportConstants.KetQuaXnSHPT_1);
                }
                else if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_2)
                {
                    pnResult_Containt.Controls.Add(ketqua5Hinh);
                    ketqua5Hinh.Dock = DockStyle.Fill;
                    ketqua5Hinh.KetQuaGen = true;
                    ketqua5Hinh.IsTacNhan = true;
                    ketqua5Hinh.DaXacNhan = daXacNhan;
                    ketqua5Hinh.CurrentPCWorkPlace = CommonAppVarsAndFunctions.PCWorkPlace;
                    ketqua5Hinh.CurrentPCWorkPlace = CommonAppVarsAndFunctions.PCWorkPlace;
                    ketqua5Hinh.CurrentuserID = CommonAppVarsAndFunctions.UserID;
                    ketqua5Hinh.CurrentarrayAllowNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem;

                    ketqua5Hinh.CurrentPCWorkPlace = CommonAppVarsAndFunctions.PCWorkPlace;
                    ketqua5Hinh.Load_KetQua_Hinh(maTiepNhan, maChiDinh, ketQua, heso, lamtron, ketquaheso, nguoiNhapKQ);
                    ketqua5Hinh.Load_KetQua_Gen(dataPatient, 0
                        , CommonAppVarsAndFunctions.UserID, CommonAppVarsAndFunctions.UserWorkPlace
                        , CommonAppVarsAndFunctions.NhomClsXetNghiem, maChiDinh, maTiepNhan, donViTinh);
                    ketqua5Hinh.KichCoHinhSHPT = imagSize;
                    Load_ReportSHPT(ReportConstants.KetQuaXnSHPT_2);
                }
                else if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_3)
                {
                    pnResult_Containt.Controls.Add(ketquaLuoiThuong);
                    ketquaLuoiThuong.DaXacNhan = daXacNhan;
                    ketquaLuoiThuong.CurrentPCWorkPlace = CommonAppVarsAndFunctions.PCWorkPlace;
                    ketquaLuoiThuong.CurrentPCWorkPlace = CommonAppVarsAndFunctions.PCWorkPlace;
                    ketquaLuoiThuong.CurrentuserID = CommonAppVarsAndFunctions.UserID;
                    ketquaLuoiThuong.CurrentarrayAllowNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem;

                    ketquaLuoiThuong.Dock = DockStyle.Fill;
                    ketquaLuoiThuong.Load_KetQua(dataPatient, 0
                   , CommonAppVarsAndFunctions.UserID, CommonAppVarsAndFunctions.UserWorkPlace
                   , CommonAppVarsAndFunctions.NhomClsXetNghiem, maChiDinh, maTiepNhan);
                    Load_ReportSHPT(ReportConstants.KetQuaXnSHPT_3);
                }
                else if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_4)
                {
                    pnResult_Containt.Controls.Add(ketqua5Hinh);
                    ketqua5Hinh.Dock = DockStyle.Fill;
                    ketqua5Hinh.DaXacNhan = daXacNhan;
                    ketqua5Hinh.KetQuaGen = true;
                    ketqua5Hinh.IsTacNhan = false;
                    ketqua5Hinh.CurrentPCWorkPlace = CommonAppVarsAndFunctions.PCWorkPlace;
                    ketqua5Hinh.CurrentPCWorkPlace = CommonAppVarsAndFunctions.PCWorkPlace;
                    ketqua5Hinh.CurrentuserID = CommonAppVarsAndFunctions.UserID;
                    ketqua5Hinh.CurrentarrayAllowNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem;

                    ketqua5Hinh.CurrentPCWorkPlace = CommonAppVarsAndFunctions.PCWorkPlace;
                    ketqua5Hinh.Load_KetQua_Hinh(maTiepNhan, maChiDinh, ketQua, heso, lamtron, ketquaheso, nguoiNhapKQ);
                    ketqua5Hinh.Load_KetQua_Gen(dataPatient, 0
                        , CommonAppVarsAndFunctions.UserID, CommonAppVarsAndFunctions.UserWorkPlace
                        , CommonAppVarsAndFunctions.NhomClsXetNghiem, maChiDinh, maTiepNhan, donViTinh);
                    ketqua5Hinh.KichCoHinhSHPT = imagSize;
                    Load_ReportSHPT(ReportConstants.KetQuaXnSHPT_4);
                }
                else if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_5)
                {
                    pnResult_Containt.Controls.Add(ketquaThuong);
                    ketquaThuong.Dock = DockStyle.Fill;
                    ketquaThuong.DaXacNhan = daXacNhan;
                    ketquaThuong.CurrentPCWorkPlace = CommonAppVarsAndFunctions.PCWorkPlace;
                    ketquaThuong.CurrentPCWorkPlace = CommonAppVarsAndFunctions.PCWorkPlace;
                    ketquaThuong.CurrentuserID = CommonAppVarsAndFunctions.UserID;
                    ketquaThuong.CurrentarrayAllowNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem;

                    ketquaThuong.CurrentPCWorkPlace = CommonAppVarsAndFunctions.PCWorkPlace;
                    ketquaThuong.Load_KetQua_ThuongQuy(maTiepNhan, maChiDinh, ketQua, phuongPhap, tgXacNhanThucHien, lanXn, nguoiNhapKQ);
                    ucGroupHeaderChuThich.GroupCaption =
                        LanguageExtension.GetResourceValueFromValue("CHÚ THÍCH / PHƯƠNG PHÁP",
                            LanguageExtension.AppLanguage);
                    Load_ReportSHPT(ReportConstants.KetQuaXnSHPT_5);
                }
            }

            pnResult_Containt.Controls.Remove(pnManChe);
            LabServices_Helper.SetControlColor(this);
        }
        private void dtgChiDInh_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //LoadGen_ToCombox();
            //Load_ImageResult();
            //Load_KetQua_Gen();
            SetDataResult();
            SetEnabledWithResult();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            LuuKetQua();
        }
        private void btnRefreshPrinter_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(delegate { ControlExtension.LoadPrinterNameNormal(listPrinter, UserConstant.RegistryPrinterResult, true); });
        }
        private void LoadPrinterList()
        {
            Task.Factory.StartNew(delegate { ControlExtension.LoadPrinterNameNormal(listPrinter, UserConstant.RegistryPrinterResult, true); });
        }

        private void btnXemIn_Click(object sender, EventArgs e)
        {
            string exportString = "";
            InKetQua(true, true, false, false, ref exportString, false);
        }

        private void btnInketQua_Click(object sender, EventArgs e)
        {
            string exportString = "";
            InKetQua(false, true, false, false, ref exportString, false);
        }

        private void btnXacNhanKetQua_Click(object sender, EventArgs e)
        {
            XacNhanKetQua(true);
        }

        private void btnHuyXacNhanKetQua_Click(object sender, EventArgs e)
        {
            XacNhanKetQua(false);
        }

        private void chkDaXacNhan_CheckedChanged(object sender, EventArgs e)
        {
            SetEnabledWithResult();
        }

        private void SetEnabledWithResult()
        {
            txtGhiChu.ReadOnly = chkKetQuaDaXacNhan.Checked;
            ucSearchLookupEditor_DoiChieuSHPT1.Enabled = !chkKetQuaDaXacNhan.Checked;
            dtpTGDoiChieu.Enabled = !chkKetQuaDaXacNhan.Checked;
            btnThemDienGiai_ToRoi.Enabled = btnLayThongTinTruocTQ.Enabled = btnLuu.Enabled = (!chkKetQuaDaXacNhan.Checked && _allowLuuKetQua);
            btnXacNhanKetQua.Enabled = (!chkKetQuaDaXacNhan.Checked && _allowXacNhan);
            btnHuyXacNhanKetQua.Enabled = (_allowBoXacNhan && chkKetQuaDaXacNhan.Checked);
            btnInketQua.Enabled = btnXemIn.Enabled = _allowInKetQua;

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnThemGenotype_Click(object sender, EventArgs e)
        {
            //if (dtgChiDInh.CurrentRow != null)
            //{
            //    if (cboMayXn.SelectedIndex > -1)
            //    {
            //        if (cboType.SelectedIndex > -1)
            //        {
            //            string maTiepNhan = dtgChiDInh.CurrentRow.Cells[colMaTiepNhan.Name].Value.ToString();
            //            var objPatient = _patient.Get_Info_BenhNhan_TiepNhan(maTiepNhan,
            //                new[] { string.Format("NgayTiepNhan = '{0}'", ucPatientInformation1.dtpDateIn.Value.ToString("yyyy-MM-dd")) });

            //            var objChiDinh = new Lab.BusinessService.Models.XetNghiemInfo();
            //            objChiDinh.maxn = cboType.SelectedValue.ToString();
            //            objChiDinh.xetnghiemProfile = false;
            //            objChiDinh.Dongia = float.Parse("-1");
            //            objChiDinh.Khuvucnhanid = CommonAppVarsAndFunctions.PCWorkPlace;
            //            objChiDinh.Khuvucthuchienid = CommonAppVarsAndFunctions.PCWorkPlace;

            //            bool allowUpdate = false;
            //            var insertFlat = _xetnghiem.Insert_Test_GenOfMicrobiology(objPatient, objChiDinh);
            //            if (insertFlat == 1)
            //            {
            //                allowUpdate = true;
            //            }
            //            else if (insertFlat == -1)
            //            {
            //                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Cập nhật thông tin Type?"))
            //                {
            //                    allowUpdate = true;
            //                }
            //            }

            //            if (allowUpdate)
            //            {
            //                string idMayXN = string.Empty;
            //                if (cboMayXn.SelectedIndex > -1)
            //                {
            //                    //Cập nhật chỉ số bình theo máy
            //                    idMayXN = cboMayXn.SelectedValue.ToString();
            //                    _xetnghiem.CapNhan_CSBT(maTiepNhan, cboMayXn.SelectedValue.ToString(), idMayXN);
            //                }
            //                //lấy dữ liệu xn 
            //                var data = _xetnghiem.Load_ChiDinhXetNghiem(maTiepNhan, cboType.SelectedValue.ToString());
            //                //var indexKq = 3;

            //                var ketQua = cboKetQua.Text;
            //                var maXn = cboType.SelectedValue.ToString();
            //                var ghiChu = string.Empty;
            //                var nguongTren = !string.IsNullOrEmpty(data.Rows[0]["NguongTren"].ToString())
            //                    ? data.Rows[0]["NguongTren"].ToString().ToString().Trim()
            //                    : string.Empty;
            //                var nguongDuoi = !string.IsNullOrEmpty(data.Rows[0]["NguongTren"].ToString())
            //                    ? data.Rows[0]["NguongTren"].ToString().ToString().Trim()
            //                    : string.Empty;
            //                var dieuKienBatThuong = !string.IsNullOrEmpty(data.Rows[0]["DKBatThuong"].ToString())
            //                    ? data.Rows[0]["DKBatThuong"].ToString().ToString().Trim()
            //                    : string.Empty;
            //                var flag = 0;
            //                var userNhap = !string.IsNullOrEmpty(data.Rows[0]["UserNhapKQ"].ToString())
            //                    ? data.Rows[0]["UserNhapKQ"].ToString().ToString().Trim() : CommonAppVarsAndFunctions.UserID;

            //                var xnChinh = !string.IsNullOrEmpty(data.Rows[0]["XNChinh"].ToString())
            //                    ? bool.Parse(data.Rows[0]["XNChinh"].ToString())
            //                    : false;

            //                var hesoquidoi = !string.IsNullOrEmpty(data.Rows[0]["HeSoQuiDoi"].ToString())
            //                    ? float.Parse(data.Rows[0]["HeSoQuiDoi"].ToString())
            //                    : 0;
            //                var lamtron = string.Empty;

            //                flag = LabResultService.SetColor(ketQua, nguongTren, nguongDuoi, dieuKienBatThuong);

            //                _xetnghiem.CapNhat_KQ_XN(maTiepNhan, maXn, ketQua,true, ghiChu, flag.ToString(), CommonAppVarsAndFunctions.UserID,
            //                    (!string.IsNullOrWhiteSpace(userNhap)), cboMayXn.SelectedValue.ToString(), string.Empty, false, string.Empty, CommonAppVarsAndFunctions.UserID);

            //                _xetnghiem.CapNhat_DuKQ_XN(maTiepNhan);
            //            }
            //            Load_KetQua_Gen();
            //        }
            //        else
            //        {
            //            CustomMessageBox.MSG_Information_OK("Hãy chọn Type");
            //        }
            //    }
            //    else
            //    {
            //        CustomMessageBox.MSG_Information_OK("Hãy chọn máy xét nghiệm");
            //    }
            //}
        }

        private void cboMayXn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtgChiDInh.CurrentRow != null)
            {
                var idMauIn = int.Parse(dtgChiDInh.CurrentRow.Cells[colMauInSHPT.Name].Value.ToString());
                currentKetQua = string.Empty;
                if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_2 || idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_1
                    || idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_4)
                    currentKetQua = ketqua5Hinh.Get_KetQua();
                else if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_3 || idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_5)
                    currentKetQua = ketquaLuoiThuong.Get_KetQua();
                var nguongTren = dtgChiDInh.CurrentRow.Cells[colNguongTren.Name].Value != null
                    ? dtgChiDInh.CurrentRow.Cells[colNguongTren.Name].Value.ToString().Trim()
                    : string.Empty;

                var nguongDuoi = dtgChiDInh.CurrentRow.Cells[colNguongDuoi.Name].Value != null
                    ? dtgChiDInh.CurrentRow.Cells[colNguongDuoi.Name].Value.ToString().Trim()
                    : string.Empty;

                var dieuKienBatThuong = dtgChiDInh.CurrentRow.Cells[colDKBatThuong.Name].Value != null
                    ? dtgChiDInh.CurrentRow.Cells[colDKBatThuong.Name].Value.ToString().Trim()
                    : string.Empty;
                int flag = 1;
                flag = LabResultService.SetColor(currentKetQua, nguongTren, nguongDuoi, dieuKienBatThuong);
                //string oldVal = TPH.Common.Converter.StringConverter.ToString(
                //    ((DataTable)bvChiDInh.BindingSource.DataSource).Rows[bvChiDInh.BindingSource.Position]["PhuongPhap"]) ;
                string oldVal = (DataTable)bvChiDInh.BindingSource.DataSource != null ?
                    TPH.Common.Converter.StringConverter.ToString(
                    ((DataTable)bvChiDInh.BindingSource.DataSource).Rows[bvChiDInh.BindingSource.Position]["PhuongPhap"])
                    : string.Empty;

                string ghiChu = txtGhiChu.Text;
                string maTiepNhan = dtgChiDInh.CurrentRow.Cells[colMaTiepNhan.Name].Value.ToString();
                string maXn = dtgChiDInh.CurrentRow.Cells[colMaXN.Name].Value.ToString();
                if (cboMayXn.SelectedIndex > -1)
                {
                    var data = _isSysConfig.Data_dm_xetngnghiem_phuongphap(null, maXn, int.Parse(cboMayXn.SelectedValue.ToString()));
                    if (data.Rows.Count > 0)
                    {
                        txtPhuongPhap.Text = data.Rows[0]["PhuongPhap"].ToString();
                        rchThongTinXN_ThongThuong.Rtf = data.Rows[0]["NoiKiemTraChatLuong"].ToString();
                    }
                    else
                        txtPhuongPhap.Text = oldVal;

                    //Load ghi chú
                    var dataGhiChu = _isSysConfig.Data_dm_xetnghiem_ghichutudong(null, maXn);
                    if (dataGhiChu.Rows.Count > 0)
                    {
                        txtGhiChu.Text = string.Empty;
                        var datagiaTri = WorkingServices.SearchResult_OnDatatable(dataGhiChu, string.Format("IdMayXn = {0} and LoaiGiaTriSoSanh = 0 and SoSanhTuyetDoi = true and ketqua = '{1}'", cboMayXn.SelectedValue.ToString(), WorkingServices.EscapeLikeValue(currentKetQua)));
                        if (datagiaTri.Rows.Count > 0)
                        {
                            txtGhiChu.Text = datagiaTri.Rows[0]["GhiChu"].ToString();
                            return;
                        }
                        datagiaTri = WorkingServices.SearchResult_OnDatatable(dataGhiChu, string.Format("IdMayXn = {0} and LoaiGiaTriSoSanh = 0 and SoSanhTuyetDoi = false and ketqua like '%{1}%'", cboMayXn.SelectedValue.ToString(), WorkingServices.EscapeLikeValue(currentKetQua)));
                        if (datagiaTri.Rows.Count > 0)
                        {
                            txtGhiChu.Text = datagiaTri.Rows[0]["GhiChu"].ToString();
                            return;
                        }
                        datagiaTri = WorkingServices.SearchResult_OnDatatable(dataGhiChu, string.Format("IdMayXn = {0} and LoaiGiaTriSoSanh = {1} ", cboMayXn.SelectedValue.ToString(), flag));
                        if (datagiaTri.Rows.Count > 0)
                        {
                            txtGhiChu.Text = datagiaTri.Rows[0]["GhiChu"].ToString();
                            return;
                        }
                    }
                }
                else
                    txtPhuongPhap.Text = oldVal;
            }
        }

        private void mnuLayHinhTuClipBoard_Click(object sender, EventArgs e)
        {
            //var obj = Clipboard.GetImage();
            //if (obj != null)
            //{
            //   // pbHinhKetQua.Image = GraphicSupport.ResizeImage(Clipboard.GetImage(), new Size(660, 360));
            //    pbHinhKetQua.Image = GraphicSupport.sharpen((Bitmap)Clipboard.GetImage());
            //}
            //else
            //    CustomMessageBox.MSG_Information_OK("Không có thông tin hình ảnh trong clipboard!");
        }

        private void rchThongTinXN_ThongThuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }
        private void rchThongTinXN_ThongThuong_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
        private void btnCloseSetting_Click(object sender, EventArgs e)
        {
            pnSignature.Tag = pnSignature.Height;
            pnSignature.Height = 0;
        }
        private void FrmSinhHocPhanTu_Shown(object sender, EventArgs e)
        {
            splitContainer1.SplitterPosition = btnCloseSetting.Location.X + btnCloseSetting.Width + 3;
            splitContainer3.SplitterPosition = 110;
            analyzerResult1.ReCalculateSpliter();
            ucKiemSoatChiDinhChayMay.ReCalculateSpliter();
            CheckAllowUse();
            this.Activated += FrmSinhHocPhanTu_Activated;
        }

        private void FrmSinhHocPhanTu_Activated(object sender, EventArgs e)
        {
            if (!isShowLogin)
                CheckAllowUse();
        }

        private bool isShowLogin = false;
        private void CheckAllowUse()
        {
            isShowLogin = true;
            if (!CommonAppVarsAndFunctions.formLoading)
            {
                if (CommonAppVarsAndFunctions.XacNhanKhiVaoketQua)
                {
                    var f = new frmIdentify();
                    f.pnMenu.Visible = true;
                    f.AdjustForm();
                    f.UserID = CommonAppVarsAndFunctions.UserID;
                    f.UserName = CommonAppVarsAndFunctions.UserName;
                    f.ShowDialog();
                    if (!f.Accepted)
                        this.Close();
                    else
                    {
                        f.Dispose();
                        AnManChe();
                        ucDanhSachBenhNhanXN1.Focus();
                        ucDanhSachBenhNhanXN1.SetFosToSeq();
                    }
                }
                else
                {
                    ucDanhSachBenhNhanXN1.Focus();
                    ucDanhSachBenhNhanXN1.SetFosToSeq();
                }
            }

            isShowLogin = false;
        }
        private void btnXacNhanKQThuongQuy_Click(object sender, EventArgs e)
        {
            ucKetQuaThuongQuy1.XacNhanKetQua(true, true, false);
            if (chkTQ_InKhiXacNhan.Checked)
            {
                CheckInThuongQuy(true);
            }
        }

        private void btnHuyXacNhanKQThuongQuy_Click(object sender, EventArgs e)
        {
            ucKetQuaThuongQuy1.XacNhanKetQua(false, true, false);
        }

        private void btnXamtruongKQThuongQuy_Click(object sender, EventArgs e)
        {
            CheckInThuongQuy(false);
        }
        private void CheckInThuongQuy(bool print)
        {
            var userSign = WorkingServices.ObjecToString(ucSearchLookupEditor_KyTentruongKhoa.SelectedValue);
            if (userSign.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase)
                && !CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemChoChuKyGiongUserDangNhap)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn người ký tên khác user đăng nhập!");
                return;
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
            var maureportChon = cboPhieuIn.SelectedIndex > 0 ? cboPhieuIn.SelectedValue.ToString() : string.Empty;
            ucKetQuaThuongQuy1.InKetQua(print, userSign, printerName, false, chkInMau.Checked
                , chkChiInCoKetQua.Checked, new ToolStripProgressBar(), maureportChon
                , ucSearchLookupEditor_KyTenlanhdao.GetSeletetedDoctorName()
                , ucSearchLookupEditor_KyTenlanhdao.GetSeletetedDoctorPosition(), (dtpNgayInKQLuoi.Checked ? dtpNgayInKQLuoi.Value : (DateTime?)null), chkPrintTitle.Checked);
        }

        private void btnInKetQuaThuognQuy_Click(object sender, EventArgs e)
        {
            CheckInThuongQuy(true);
        }

        private void FrmSinhHocPhanTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12 && xtraTabControl1.SelectedTabPage.Equals(xtraTabPageKQLuoi))
            {
                if (ucKetQuaThuongQuy1.HaveItem)
                {
                    ucKetQuaThuongQuy1.SelectAllXN();
                    ucKetQuaThuongQuy1.XacNhanKetQua(true, false, true);
                    if (!string.IsNullOrEmpty(ucDanhSachBenhNhanXN1.MaTiepNhanDangChon) && !chkTQ_InKhiXacNhan.Checked)
                    {
                        ucDanhSachBenhNhanXN1.Focus();
                        ucDanhSachBenhNhanXN1.SetFosToDataGrid();
                    }
                    if (chkTQ_InKhiXacNhan.Checked)
                    {
                        CheckInThuongQuy(true);
                        ucDanhSachBenhNhanXN1.Focus();
                        ucDanhSachBenhNhanXN1.SetFosToDataGrid();
                    }
                }
                ucDanhSachBenhNhanXN1.Focus();
                ucDanhSachBenhNhanXN1.SetFosToSeq();
            }
        }

        private void btnLuuNguoiThucHienTQ_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Cập nhật người thực hiện"))
                LuuNguoiThucHienTQ();
        }

        private void LuuNguoiThucHienTQ()
        {
            if (cboNguoiThcuHienTQ.SelectedIndex > -1)
            {

                var nguoiDoiChieu = cboNguoiThcuHienTQ.SelectedIndex > -1 ? cboNguoiThcuHienTQ.SelectedValue.ToString() : string.Empty;
                var ngayDoiChieu = dtpNguoiThucHienTQ.Checked ? dtpNguoiThucHienTQ.Value.ToString() : string.Empty;
                ucKetQuaThuongQuy1.CapNhatNguoiThucHien(nguoiDoiChieu, ngayDoiChieu);
                NguoiThucHienTruocTQ = nguoiDoiChieu;
                GioThucHientruocTQ = (string.IsNullOrEmpty(ngayDoiChieu) ? (DateTime?)null : DateTime.Parse(ngayDoiChieu));
                ucDanhSachBenhNhanXN1.Focus();
                ucDanhSachBenhNhanXN1.SetFosToDataGrid();
            }
            else
                CustomMessageBox.MSG_Waring_OK("Không có thông tin người thực hiện được chọn.");
        }

        private string NguoiThucHienTruocSHPT = string.Empty;
        private DateTime? GioThucHientruocSHPT = null;
        private string NguoiThucHienTruocTQ = string.Empty;
        private DateTime? GioThucHientruocTQ = null;
        private void SetNguoiThucHienTruocSHPT()
        {
            if (!chkKetQuaDaXacNhan.Checked)
            {
                ucSearchLookupEditor_DoiChieuSHPT1.SelectedValue = NguoiThucHienTruocSHPT;
                if (GioThucHientruocSHPT != null)
                {
                    dtpTGDoiChieu.Value = (DateTime)GioThucHientruocSHPT;
                    dtpTGDoiChieu.Checked = true;
                }
                else
                {
                    dtpTGDoiChieu.Checked = false;
                }
            }
            else
                CustomMessageBox.MSG_Information_OK("Không thể gán các giá trị người thực hiện do kết quả đã được duyệt.");
        }
        private void SetNguoiThucHienTruocTQ()
        {
            if (!ucKetQuaThuongQuy1.DaXacNhan_DongDangChon)
            {
                cboNguoiThcuHienTQ.SelectedValue = NguoiThucHienTruocTQ;
                if (GioThucHientruocTQ != null)
                {
                    dtpNguoiThucHienTQ.Value = (DateTime)GioThucHientruocTQ;
                    dtpNguoiThucHienTQ.Checked = true;
                }
                else
                {
                    dtpNguoiThucHienTQ.Checked = false;
                }
            }
            else
                CustomMessageBox.MSG_Information_OK("Không thể gán các giá trị người thực hiện do kết quả đã được duyệt.");
        }

        private void btnLayThongTinTruocSHPT_Click(object sender, EventArgs e)
        {
            SetNguoiThucHienTruocSHPT();
        }

        private void btnLayThongTinTruocTQ_Click(object sender, EventArgs e)
        {
            SetNguoiThucHienTruocTQ();
        }

        private void btnLuuNX_DeNghi_Click(object sender, EventArgs e)
        {
            ucKetQuaThuongQuy1.CapNhatMoTa(txtDienGiai.Text, txtDeNghi.Text);
        }

        private void ucDanhSachBenhNhanXN1_InTheoDanhSach_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("In kết quả theo danh sách đang chọn?"))
            {
                for (int i = 0; i < ucDanhSachBenhNhanXN1.gvDanhSach.RowCount; i++)
                {
                    if (i > 0)
                    {
                        ucDanhSachBenhNhanXN1.gvDanhSach.MoveNext();
                    }
                    else
                        ucDanhSachBenhNhanXN1.gvDanhSach.MoveFirst();

                    if (ucDanhSachBenhNhanXN1.RowIsChecked)
                    {
                        string exportString = string.Empty;
                        if (InKetQua(false, true, false, false, ref exportString, true))
                        {
                            ucDanhSachBenhNhanXN1.UnCheckCurrentRow();
                        }
                        else
                            return;
                    }
                }
                ucDanhSachBenhNhanXN1.Load_DSBenhNhan();
            }
        }

        private void FrmSinhHocPhanTu_FormClosing(object sender, FormClosingEventArgs e)
        {
            analyzerResult1.StopTimer();
        }

        private void btnKQXetNghiem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            HightLightButton((Button)sender);
        }

        private void btnKetQuaMay_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            HightLightButton((Button)sender);
        }

        private void btnChiDinhMay_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            HightLightButton((Button)sender);
        }
        private void LuuIdDienGiai(int idDiengiai, string maTiepNhan, string maXn)
        {
            if (!string.IsNullOrEmpty(maTiepNhan) && !string.IsNullOrEmpty(maXn))
            {
                _xetnghiem.LuuIdDienGiai(maTiepNhan, maXn, idDiengiai, CommonAppVarsAndFunctions.UserID);
            }
        }
        private void btnThemDienGiai_Luoi_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ucKetQuaThuongQuy1.CurrentMaTiepNhan))
            {
                if (!ucKetQuaThuongQuy1.DaXacNhan_DongDangChon)
                {
                    var f = new FrmDanhMucDienGiai();
                    f.MaXnChiDinh = ucKetQuaThuongQuy1.MaXn_DongDangChon;
                    f.GenBatThuong = String.Join(",", ucKetQuaThuongQuy1.lstDanhSachNhom);
                    f.IsConFigMode = false;
                    f.ShowDialog();
                    if (f.idChon > 0)
                    {
                        LuuIdDienGiai(f.idChon, ucKetQuaThuongQuy1.CurrentMaTiepNhan, ucKetQuaThuongQuy1.MaXn_DongDangChon);
                    }
                }
            }
        }

        private void btnXemDienGiai_Luoi_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ucDanhSachBenhNhanXN1.MaTiepNhanDangChon))
            {
                var data = _xetnghiem.DataThongTinDienGiai(ucDanhSachBenhNhanXN1.MaTiepNhanDangChon, ucKetQuaThuongQuy1.MaXn_DongDangChon);
                if (data.Rows.Count > 0)
                {
                    var f = new FrmSHPT_XemDienGiai();
                    f.DataSource = data;
                    f.ShowDialog();
                }
            }
        }

        private void btnThemDienGiai_ToRoi_Click(object sender, EventArgs e)
        {
            if (dtgChiDInh.CurrentRow != null)
            {
                if (!chkKetQuaDaXacNhan.Checked)
                {
                    var f = new FrmDanhMucDienGiai();
                    f.MaXnChiDinh = dtgChiDInh.CurrentRow.Cells[colMaXN.Name].Value.ToString();
                    var idMauIn = int.Parse(dtgChiDInh.CurrentRow.Cells[colMauInSHPT.Name].Value.ToString());
                    if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_1
                        || idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_2
                        || idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_4)
                    {
                        if (ketqua5Hinh != null)
                        {
                            f.GenBatThuong = ketqua5Hinh.GenBatThuong;
                        }
                    }
                    else if (idMauIn == (int)ReportMicrobiologyTemplateConstant.EnumReportMicrobiologyTemplatetype.Mau_5)
                    {
                        if (ketquaLuoiThuong != null)
                        {
                            //phương pháp dùng làm cho đề nghị
                            f.GenBatThuong = ketquaThuong.GenBatThuong;
                        }
                    }
                    f.IsConFigMode = false;
                    f.ShowDialog();
                    if (f.idChon > 0)
                    {
                        string maTiepNhan = dtgChiDInh.CurrentRow.Cells[colMaTiepNhan.Name].Value.ToString();
                        string maXn = dtgChiDInh.CurrentRow.Cells[colMaXN.Name].Value.ToString();
                        LuuIdDienGiai(f.idChon, maTiepNhan, maXn);
                    }
                }
            }
        }

        private void btnXemDienGiai_ToRoi_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ucDanhSachBenhNhanXN1.MaTiepNhanDangChon))
            {
                var data = _xetnghiem.DataThongTinDienGiai(ucDanhSachBenhNhanXN1.MaTiepNhanDangChon, dtgChiDInh.CurrentRow.Cells[colMaXN.Name].Value.ToString());
                if (data.Rows.Count > 0)
                {
                    var f = new FrmSHPT_XemDienGiai();
                    f.DataSource = data;
                    f.ShowDialog();
                }
            }
        }
    }
}
