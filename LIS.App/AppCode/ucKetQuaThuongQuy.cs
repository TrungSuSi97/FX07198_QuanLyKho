using System;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.Common.Extensions;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.App.ThucThi.BenhNhan;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using TPH.Lab.Middleware.LISConnect.Services;
using TPH.LIS.Common;
using System.Threading.Tasks;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.TestResult.Services;
using TPH.LIS.Patient.Model;
using TPH.LIS.Configuration.Models;
using System.Collections.Generic;
using TPH.Data.HIS.Models;
using DevExpress.XtraEditors;
using TPH.LIS.Analyzer.Services;
using TPH.LIS.ResultConvert.Service;
using TPH.LIS.Patient.Services;
using DevExpress.XtraGrid;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.TestResult.Model;
using TPH.Data.HIS.HISDataCommon;
using TPH.LIS.App.DailyUse.CanLamSang;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.ComponentModel;
using TPH.LIS.Log.Model;
using TPH.LIS.Log.Services.WorkingLog;
using TPH.WriteLog;
using DevExpress.XtraGrid.Columns;
using TPH.LIS.App.DailyUse.BenhNhan;
using TPH.Controls;
using TPH.Lab.Middleware.LISConnect.Models;
using TPH.Language;
using static TPH.LIS.Common.TestType;
using DevExpress.Utils.Extensions;
using TPH.Lab.Middleware.HISConnect.Models;
using DevExpress.Office.Utils;

namespace TPH.LIS.App.AppCode
{
    public partial class ucKetQuaThuongQuy : UserControl
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
        private readonly IWorkingLogService _writeDblog = new WorkingLogService();
        public TestType.EnumTestType[] _arrLoaiXetNghiem = new TestType.EnumTestType[] {
            TestType.EnumTestType.ThongThuong
            , TestType.EnumTestType.ViSinh_TQ
            , TestType.EnumTestType.HuyetDo
            , TestType.EnumTestType.HIV, TestType.EnumTestType.NIPT
            , TestType.EnumTestType.PLGF, TestType.EnumTestType.SFLT1
            , TestType.EnumTestType.SLSS };
        public DataTable _dtPatient = new DataTable();
        private DataTable _CurrentDataClSKetQua = new DataTable();
        private DataTable _dtCalculateConfig = new DataTable();
        private HisConnection _hisInfo;
        private bool _allowEdit;
        private bool _allowInsert;
        private bool _allowChangeAnalyzer;
        private bool _allowEditResulFromOtherUser;
        private string _maBn = "";
        private string _soHoSo = "";
        private string _barcode = "";
        public bool TuTinhToanKetQua = false;

        private string _currentValue = "";
        string _log = "";
        private bool _loading;
        private const int FoCusAfter = 300;
        int _countToFocus = 0;
        int _printCount = 0;

        private DataTable DataGhiChuTuDong = new DataTable();
        List<CAUHINH_MAYINKETQUA> _listCauHinhMayIn;
        public DateTime DtDateInG { get; set; }
        public string MatiepNhanG { get; set; }
        // private PrintResultService _inKetQua = new PrintResultService();
        private PrintResultHelper _inKetQua = new PrintResultHelper();
        private Image reportLogo;
        public List<string> lstDanhSachNhom = new List<string>();
        public int hisId = 0;
        public string CurrentMaTiepNhan = string.Empty;
        public DateTime CurrentNgayTiepNhan = DateTime.Now;
        private DataTable DataPatient = new DataTable();
        /// <summary>
        /// Chế độ hiển thị cho lưới
        /// 0: Thông thường - 1 SHPT
        /// </summary>
        private int cheDohienThi = 1;
        public string MaXn_DongDangChon = string.Empty;
        public string NguoiThucHien_DongDangChon = string.Empty;
        public string KetQua_DongDangChon = string.Empty;

        public string KetQuaDinhTinh_DongDangChon = string.Empty;
        public string TenSHPT_DongDangChon = string.Empty;

        public string DienGiaiDangChon = string.Empty;
        public string DeNghiDangChon = string.Empty;
        public int LimitRowHeight = 16;
        public bool XacNhanSuaKetQua = false;

        public DateTime? TGThucHien_DongDangChon = null;
        public bool DaXacNhan_DongDangChon = false;
        [Category("Custom")]
        public event EventHandler DataGridview_KetQua_FocusRowChanged;
        [Category("Custom")]
        public event EventHandler DataGridview_KetQua_FocusColumnChanged;
        [Category("Custom")]
        public event EventHandler UserWorking;
        [Category("Custom")]
        public bool HienThiGhiChuBoPhan
        {
            get { return pnGhiChu.Visible; }
            set { pnGhiChu.Visible = value; }
        }
        /// <summary>
        /// Chế độ hiển thị cho lưới
        /// 0: Thông thường - 1 SHPT
        /// </summary>
        public int CheDoHienThi
        {
            get
            {
                return cheDohienThi;
            }
            set
            {
                cheDohienThi = value;
                SetUpCheDoHienThiChoLuoi();
            }
        }
        [Category("Custom")]
        public bool HienThiDanhGiaNhom
        {
            get { return gbDanhGiaKetQuaTheoNhom.Visible; }
            set { gbDanhGiaKetQuaTheoNhom.Visible = value; }
        }
        private void SetUpCheDoHienThiChoLuoi()
        {
            if (cheDohienThi == 1)
            {
                colKetQua_GhiChu.Caption = "Chú thích";
                colKetQua_GhiChu.Width = 200;
                colKetQua_KetQua.Width = 200;
                colKetQua_MaSoMau.Visible = true;
                colKetQua_NguoiThucHien.Visible = true;
                colKetQua_GioThucHIen.Visible = true;
                colKetQua_CSBT.VisibleIndex = 9;
                colKetQua_CSBT.Caption = "Ngưỡng định lượng";
                colKetQua_DonVi.VisibleIndex = 10;
            }
            else
            {
                colKetQua_GhiChu.Caption = "Ghi chú";
                colKetQua_GhiChu.Width = 50;
                colKetQua_KetQua.Width = 122;

                colKetQua_MaSoMau.Visible = false;
                colKetQua_NguoiThucHien.Visible = false;
                colKetQua_GioThucHIen.Visible = false;
                colKetQua_DonVi.VisibleIndex = 7;
                colKetQua_CSBT.VisibleIndex = 8;
                colKetQua_CSBT.Caption = "Giới hạn tham chiếu";
            }
        }
        public ucKetQuaThuongQuy()
        {
            MatiepNhanG = string.Empty;
            DtDateInG = new DateTime();
            InitializeComponent();
            lblHinhAnh.BackColor = CommonAppColors.ColorMainAppColor;
            lblHinhAnh.ForeColor = CommonAppColors.ColorTextCaption;
            pnChonMayCapNhat.BackColor = CommonAppColors.ColorMainAppColor;
            lblChonMay.ForeColor = CommonAppColors.ColorTextCaption;
        }
        private void ClearControl()
        {
            chkDaIn.DataBindings.Clear();
            chkDaXacNhan.DataBindings.Clear();
            chkDuKQ.DataBindings.Clear();
            chkDuKQ.Checked = chkDaXacNhan.Checked = chkDaIn.Checked = false;
            txtLanIn.DataBindings.Clear();
            txtLanIn.Text = string.Empty;
            txtTGIn.DataBindings.Clear();
            txtTGIn.Text = string.Empty;
            txtComment.DataBindings.Clear();
            txtComment.Text = string.Empty;
        
            txtLanIn.DataBindings.Clear();
            txtLanIn.Text = string.Empty;
            txtTGIn.DataBindings.Clear();
            txtTGIn.Text = string.Empty;
        }
        private void gvBoPhan_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            var view = sender as GridView;
            if (e.RowHandle < 0) return;
            if (e.Column == colBoPhan_TemBoPhan)
            {
                var daIn = bool.Parse(view.GetRowCellValue(e.RowHandle, colBoPhan_DaInKetQua).ToString());
                var daDuyet = bool.Parse(view.GetRowCellValue(e.RowHandle, colBoPhan_DaXacNhan).ToString());
                var daCoKQ = bool.Parse(view.GetRowCellValue(e.RowHandle, colBoPhan_DaCoKetQua).ToString());
                var daDuKQ = bool.Parse(view.GetRowCellValue(e.RowHandle, colBoPhan_DuKetQua).ToString());
                e.Appearance.BackColor = ColorForGroup(daDuKQ, daDuyet, daCoKQ, daIn);
            }
        }
        private Color ColorForGroup(bool daDuKQ, bool daDuyet, bool daCoKQ, bool daIn)
        {
            if (daIn)
                return (string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauDaInKQ) ? Color.Empty :
                   ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauDaInKQ));
            else if (daDuyet)
                return (string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauDaDuyetKQ) ? Color.Empty :
                    ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauDaDuyetKQ));
            else if (daDuKQ)
                return (string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauDuKQ) ? Color.Empty :
                    ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauDuKQ));
            else if (daCoKQ)
                return  (string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauDaCoKQ) ? Color.Empty :
                    ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauDaCoKQ));
            else if (!daCoKQ)
                return (string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauChuaKQ) ? Color.Empty :
                    ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauChuaKQ));
            return Color.Empty;
        }
        private void ShowKetQuaXN(DataTable dt)
        {
            WorkingServices.ConvertColumnNameToLower_Upper(dt, true);
            gcKetQua.DataSource = dt;
            gvKetQua.ExpandAllGroups();
            _printCount = 0;
        }
        private void Load_DS_MayXN()
        {
            var mayXetNghiemCombo = from selectData in _iAnalyzerConfig.Data_h_mayxetnghiem(true).AsEnumerable()
                                    select new
                                    {
                                        IdMay = selectData["IDMay"]
                                    ,
                                        TenMay = selectData["TenMay2"]
                                    };
            colKetQua_ChonMayXetNghiem.DataSource = mayXetNghiemCombo;
            colKetQua_ChonMayXetNghiem.ValueMember = "IdMay";
            colKetQua_ChonMayXetNghiem.DisplayMember = "TenMay";
        }
        public void Load_DanhSachAlarm(string maTiepNhan)
        {
            if (CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem != null)
            {
                var data = _iAnalyzerResult.Data_DanhSachCoTuMay(CommonAppVarsAndFunctions.BoPhanClsXetNghiem.ToList()
                    , (lstDanhSachNhom.Count > 0 ? lstDanhSachNhom : CommonAppVarsAndFunctions.NhomClsXetNghiem.ToList())
                    , CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem.ToList(), maTiepNhan);
                if (data.Rows.Count > 0)
                {
                    ucAnalyzerAlarmList1.Visible = true;
                    ucAnalyzerAlarmList1.Location = new Point(this.Width - (ucAnalyzerAlarmList1.Width + 15) - pnResult_SubInformation.Width, ucAnalyzerAlarmList1.Location.Y);
                    ucAnalyzerAlarmList1.DataSource = data;
                }
                else
                    ucAnalyzerAlarmList1.Visible = false;
            }
            else
                ucAnalyzerAlarmList1.Visible = false;
        }
        public void XoaThongTinDS()
        {
            ucAnalyzerAlarmList1.Visible = false;
            ucHinhAnh_HuyetDo1.Xoa_BieuDo();
            gcNhomCLS.DataSource = null;
            gcBoPhan.DataSource = null;
            gcKetQua.DataSource = null;
        }
        private string LoadDeNghiNCC()
        {
            string idConfig = ((int)EnumCauHinhConfig.IDDeNghiNCC_SLSS).ToString();
            var data = _isSysConfig.Data_config(string.Empty, idConfig);
            if (data.Rows.Count > 0)
            {
                return data.Rows[0]["description"].ToString();
            }
            return string.Empty;
        }
        public void Load_ChiTietXN(string maTiepNhan, DataTable dataPatientIn, bool recall = false)
        {
            try
            {
                if (!string.IsNullOrEmpty(maTiepNhan))
                {
                    DataPatient = (dataPatientIn ?? _iPatient.Data_BenhNhan_TiepNhan(maTiepNhan, new string[] { }));
                    if (DataPatient.Rows.Count > 0)
                    {
                        _maBn = DataPatient.Rows[0]["MaBn"].ToString();
                        _barcode = DataPatient.Rows[0]["Seq"].ToString();
                        _soHoSo = DataPatient.Rows[0]["Bn_id"].ToString();

                        var reporttype = string.Empty;
                        if (chkXemXetTheoMauIn.Checked)
                            reporttype = chlDanhSachPhieuKetQua.ItemList("IDMauKetQua");
                        var category = lstDanhSachNhom.Count > 0 ? string.Join(",", lstDanhSachNhom) : string.Join(",", CommonAppVarsAndFunctions.NhomClsXetNghiem);
                        var bophan = string.Empty;
                        bophan = chkXemtheoBoPhan.Checked ? chlBoPhan.ItemList("MaBoPhan") : chlBoPhan.AllItemList("MaBoPhan");
                        if (string.IsNullOrEmpty(bophan))
                            bophan = chlBoPhan.AllItemList("MaNhomCLS");

                        //Load danh sách kết quả
                        _CurrentDataClSKetQua = _xetnghiem.DuLieuKetQua_XN(DataPatient, 0, false, CommonAppVarsAndFunctions.UserID, string.Empty, false
                                  , null, CommonAppVarsAndFunctions.UserWorkPlace, reporttype, false
                                  , _arrLoaiXetNghiem
                                  , category, false, false, string.Empty, false, String.Empty);
                        if (_CurrentDataClSKetQua == null)
                        {
                            XoaThongTinDS();
                            CustomMessageBox.MSG_Waring_OK("Có lỗi trong quá trình lấy thông tin kết quả, vui lòng thử lại.");
                            return;
                        }
                        else
                        {
                            _CurrentDataClSKetQua.DefaultView.Sort = "ThuTuNhom, SapXep";
                            _CurrentDataClSKetQua = _CurrentDataClSKetQua.DefaultView.ToTable();
                        }
                        var checkDalayMau = QuiTrinhLAB.GetTrangThaiLayMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh);
                        var checkDaNhanMau = QuiTrinhLAB.GetTrangThaiNhanMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh);
                        var checkDaThuTien = QuiTrinhLAB.GetTrangThaiThuTienRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh);

                        var distinctCatePrint = _CurrentDataClSKetQua.DefaultView.ToTable(true, new string[] { "ThuTuNhom", "TenNhomCLS" });
                        distinctCatePrint.DefaultView.Sort = "ThuTuNhom asc";
                        if (checkDalayMau || checkDaNhanMau || checkDaThuTien)
                        {
                            for (var i = 0; i < _CurrentDataClSKetQua.Rows.Count; i++)
                            {
                               
                                    var catePrint = _CurrentDataClSKetQua.Rows[i]["TenNhomCLS"].ToString().Trim();
                                    var currentIndex = 0;
                                    for (var a = 0; a < distinctCatePrint.Rows.Count; a++)
                                    {
                                        if (!catePrint.Trim().Equals(distinctCatePrint.Rows[a]["TenNhomCLS"].ToString().Trim()))
                                            continue;
                                        currentIndex = a + 1;
                                        break;
                                    }
                                _CurrentDataClSKetQua.Rows[i]["TenNhomCLS"] = string.Format("[{0}] - {1}", Utilities.LayStt(currentIndex, 1), catePrint.Trim().ToUpper());
                                var rDalayMau = bool.Parse(_CurrentDataClSKetQua.Rows[i]["DaLayMau"].ToString());
                                var rDaNhanMau = bool.Parse(_CurrentDataClSKetQua.Rows[i]["DaNhanMau"].ToString());
                                var rDaThuTien = bool.Parse(_CurrentDataClSKetQua.Rows[i]["DaThuTien"].ToString());


                                if ((!checkDalayMau || rDalayMau) && (!checkDaNhanMau || rDaNhanMau)&&(!checkDaThuTien || rDaThuTien)) continue;
                                _CurrentDataClSKetQua.Rows.RemoveAt(i);
                                i--;
                            }
                            _CurrentDataClSKetQua.AcceptChanges();
                        }
                        else
                        {
                            for (var i = 0; i < _CurrentDataClSKetQua.Rows.Count; i++)
                            {
                                var catePrint = _CurrentDataClSKetQua.Rows[i]["TenNhomCLS"].ToString().Trim();
                                var currentIndex = 0;
                                for (var a = 0; a < distinctCatePrint.Rows.Count; a++)
                                {
                                    if (!catePrint.Trim().Equals(distinctCatePrint.Rows[a]["TenNhomCLS"].ToString().Trim()))
                                        continue;
                                    currentIndex = a + 1;
                                    break;
                                }
                                _CurrentDataClSKetQua.Rows[i]["TenNhomCLS"] = string.Format("[{0}] - {1}", Utilities.LayStt(currentIndex, 1), catePrint.Trim().ToUpper());
                            }
                            _CurrentDataClSKetQua.AcceptChanges();
                        }
                        if (TuTinhToanKetQua && mnuTinhToanKetQua.Enabled)
                        {
                            if (Calculate(_CurrentDataClSKetQua))
                            {
                                Load_ChiTietXN(CurrentMaTiepNhan, DataPatient, true);
                            }
                        }
                        //Nếu không phải hàm gọi lại sau khi tính toán thì load tiếp các thông tin khác
                        if (!recall)
                        {
                            gvKetQua.RowCellStyle -= gvKetQua_RowCellStyle;
                            ShowKetQuaXN(_CurrentDataClSKetQua);
                            //load danh sach nhom
                            gvNhomCLS.FocusedRowChanged -= GvNhomCLS_FocusedRowChanged;
                            gvNhomCLS.FocusedColumnChanged -= GvNhomCLS_FocusedColumnChanged;
                            distinctCatePrint = _CurrentDataClSKetQua.DefaultView.ToTable(true, new string[] { "ThuTuNhom", "TenNhomCLS", "MaNhomCLS" });
                            var lstCateSelect = new List<string>();
                            foreach (DataRow dataC in distinctCatePrint.Rows)
                            {
                                lstCateSelect.Add(dataC["MaNhomCLS"].ToString().Trim());
                            }

                            var dataCategory = _xetnghiem.DataCategoryOrTest(maTiepNhan, (int)CommonAppVarsAndFunctions.gioTinhTgThucHien, string.Join(",", lstCateSelect));
                            WorkingServices.ConvertColumnNameToLower_Upper(dataCategory, true);
                            gcNhomCLS.DataSource = dataCategory;
                            if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemHienThiTrangThaiNhomTheoBoPhan && CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemHienThiTrangThaiNhom)
                            {
                                gvNhomCLS.ExpandAllGroups();
                            }
                            gvNhomCLS.FocusedRowChanged += GvNhomCLS_FocusedRowChanged;
                            gvNhomCLS.FocusedColumnChanged += GvNhomCLS_FocusedColumnChanged;
                            Load_DanhGiaNhom();
                            //load danh sách bộ phận
                            var dataDepartment = _xetnghiem.DataDepartmentOrTest(maTiepNhan, (int)CommonAppVarsAndFunctions.gioTinhTgThucHien, chlBoPhan.AllItemList("MaBoPhan").Replace("'", ""));
                            WorkingServices.ConvertColumnNameToLower_Upper(dataDepartment, true);
                            RemoveDataDepartment_NoInGroup(dataDepartment, (DataTable)chlViewWithCategory.DataSource);
                            gcBoPhan.DataSource = dataDepartment;
                            Load_DanhSachAlarm(maTiepNhan);
                            Load_HinhKetQua(maTiepNhan);
                            if (gvKetQua.RowCount > 0)
                                gvKetQua.FocusedRowHandle = 0;
                            gvKetQua.RowCellStyle += gvKetQua_RowCellStyle;
                        }
                    }
                    else
                    {
                        XoaThongTinDS();
                    }
                }
                else
                {
                    XoaThongTinDS();
                }
            }
            catch (Exception ex)
            {
                ErrorService.GetFrameworkErrorMessage(ex, "Load_ChiTietXN", true, CommonAppVarsAndFunctions.UserID);
            }
        }

        private void GvNhomCLS_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            Load_DanhGiaNhom();
        }

        private void GvNhomCLS_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            Load_DanhGiaNhom();
        }
        private void Load_DanhGiaNhom()
        {
            txtKetLuan.Text = string.Empty;
            txtDeNghi.Text = string.Empty;
            txtNhanXet.Text = string.Empty;
            chkNguyCoCao.Checked = false;
            chkLan2.Checked = false;
            chkThamGiaChanDoan.Checked = false;
            chkChanDoanBenh.Checked = false;
            Lock_TextDanhGia(true);
            btnLuuNX_DeNghi.Enabled = false;
            if (gvNhomCLS.FocusedRowHandle >-1)
            {
                if (gvNhomCLS.GetFocusedRowCellValue(colNhom_MaNhom)  != null)
                {
                    txtKetLuan.Text = gvNhomCLS.GetFocusedRowCellValue(colNhom_KetLuanSangLocNhom).ToString();
                    txtDeNghi.Text = gvNhomCLS.GetFocusedRowCellValue(colNhom_DeNghiSangLocNhom).ToString();
                    txtNhanXet.Text = gvNhomCLS.GetFocusedRowCellValue(colNhom_NhanXetSangLocNhom).ToString();
                    btnChinhSuaDeNghi.Enabled = !bool.Parse(gvNhomCLS.GetFocusedRowCellValue(colNhom_DaXacNhanKQ).ToString());
                    gbDanhGiaKetQuaTheoNhom.Text = string.Format(
                        $"{LanguageExtension.GetResourceValueFromValue("ĐÁNH GIÁ KẾT QUẢ: {0}", LanguageExtension.AppLanguage)} ",
                        gvNhomCLS.GetFocusedRowCellValue(colNhom_TenNhom).ToString().ToUpper());
                    chkNguyCoCao.CheckedChanged -= chkNguyCoCao_CheckedChanged;
                    chkNguyCoCao.Checked = bool.Parse(gvNhomCLS.GetFocusedRowCellValue(colNhom_NguyCoCao).ToString());
                    chkNguyCoCao.CheckedChanged += chkNguyCoCao_CheckedChanged;
                    chkLan2.Checked = bool.Parse(gvNhomCLS.GetFocusedRowCellValue(colNhom_XetNghiemLan2).ToString());
                    chkThamGiaChanDoan.Checked = bool.Parse(gvNhomCLS.GetFocusedRowCellValue(colNhom_ThamGiaChanDoan).ToString());
                    chkChanDoanBenh.Checked = bool.Parse(gvNhomCLS.GetFocusedRowCellValue(colNhom_ChanDoanCoBenh).ToString());
                }
            }
        }
        private void Lock_TextDanhGia(bool isLock)
        {
            txtKetLuan.ReadOnly = isLock;
            txtDeNghi.ReadOnly = isLock;
            txtNhanXet.ReadOnly = isLock;
            chkNguyCoCao.AutoCheck = !isLock;
            chkLan2.AutoCheck = !isLock;
            chkThamGiaChanDoan.AutoCheck = !isLock;
            chkChanDoanBenh.AutoCheck = !isLock;
        }
        private void btnChinhSuaDeNghi_Click(object sender, EventArgs e)
        {
            Lock_TextDanhGia(false);
            btnChinhSuaDeNghi.Enabled = false;
            btnLuuNX_DeNghi.Enabled = true;
        }

        private void btnLuuNX_DeNghi_Click(object sender, EventArgs e)
        {
            if (gvNhomCLS.FocusedRowHandle > -1)
            {
                if (gvNhomCLS.GetFocusedRowCellValue(colNhom_MaNhom) != null)
                {
                    _xetnghiem.Update_NhanXetDeNghi_Nhom(CurrentMaTiepNhan, gvNhomCLS.GetFocusedRowCellValue(colNhom_MaNhom).ToString(), txtNhanXet.Text
                                                            , CommonAppVarsAndFunctions.UserID, txtDeNghi.Text, CommonAppVarsAndFunctions.UserID, txtKetLuan.Text, CommonAppVarsAndFunctions.UserID
                                                            , chkNguyCoCao.Checked, chkLan2.Checked, chkThamGiaChanDoan.Checked, chkChanDoanBenh.Checked);
                    Lock_TextDanhGia(true);
                    btnChinhSuaDeNghi.Enabled = true;
                    btnLuuNX_DeNghi.Enabled = false;
                }
            }
        }
        private void Get_ThongTinDongDangChon()
        {
            MaXn_DongDangChon = string.Empty;
            NguoiThucHien_DongDangChon = string.Empty;
            KetQua_DongDangChon = string.Empty;
            TGThucHien_DongDangChon = null;
            DaXacNhan_DongDangChon = false;
            KetQuaDinhTinh_DongDangChon = string.Empty;
            TenSHPT_DongDangChon = string.Empty;
            DienGiaiDangChon = string.Empty;
            DeNghiDangChon = string.Empty;
            if (gvKetQua.GetFocusedRowCellValue(colKetQua_MaXN) !=null)
            {
                MaXn_DongDangChon = gvKetQua.GetFocusedRowCellValue(colKetQua_MaXN).ToString();
                NguoiThucHien_DongDangChon = gvKetQua.GetFocusedRowCellValue(colKetQua_NguoiThucHien).ToString();
                KetQua_DongDangChon = gvKetQua.GetFocusedRowCellValue(colKetQua_KetQua).ToString();
                KetQuaDinhTinh_DongDangChon = gvKetQua.GetFocusedRowCellValue(colKetQua_KQDinhTinh).ToString();
                TenSHPT_DongDangChon = gvKetQua.GetFocusedRowCellValue(colKetQua_TenSHPT).ToString();
                TGThucHien_DongDangChon = (string.IsNullOrEmpty(gvKetQua.GetFocusedRowCellValue(colKetQua_GioThucHIen).ToString()) ? (DateTime?)null : DateTime.Parse(gvKetQua.GetFocusedRowCellValue(colKetQua_GioThucHIen).ToString()));
                DaXacNhan_DongDangChon = bool.Parse(gvKetQua.GetFocusedRowCellValue(colKetQua_DaXacNhan).ToString());
                DienGiaiDangChon = gvKetQua.GetFocusedRowCellValue(colKetQua_DienGiai).ToString();
                DeNghiDangChon = gvKetQua.GetFocusedRowCellValue(colKetQua_DeNghi).ToString();

            }
        }
        private DataTable RemoveDataDepartment_NoInGroup(DataTable dataDepartment, DataTable dataCategory)
        {
            if (dataDepartment != null)
            {
                if (dataDepartment.Rows.Count > 0)
                {
                    var lstCate = lstDanhSachNhom.Count > 0 ? lstDanhSachNhom : CommonAppVarsAndFunctions.NhomClsXetNghiem.ToList();
                    List<string> list = dataCategory.AsEnumerable().Where(c => lstCate.Where(x => x.Equals(c.Field<string>("MaNhomCLS"), StringComparison.OrdinalIgnoreCase)).Any())
                              .Select(r => r.Field<string>("MaBoPhan"))
                              .ToList();
                    for (int i = 0; i < dataDepartment.Rows.Count; i++)
                    {
                        if (!list.Contains(dataDepartment.Rows[i]["MaBoPhan"].ToString()))
                        {
                            dataDepartment.Rows.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
            return dataDepartment;
        }

        public void BindPatientInfo(DataTable bs)
        {
            ClearControl();
            if (bs != null)
            {
                chkDuKQ.DataBindings.Add("Checked", bs, "DuKQXN".ToLower());
                chkDaXacNhan.DataBindings.Add("Checked", bs, "ValidKQXN".ToLower());
                chkDaIn.DataBindings.Add("Checked", bs, "DaInKQXN".ToLower());
                txtLanIn.DataBindings.Add("Text", bs, "LanInXN".ToLower());
                txtTGIn.DataBindings.Add("Text", bs, "ThoiGianInXN".ToLower(), true, DataSourceUpdateMode.Never, null, "dd/MM/yyyy HH:mm");
            }
        }
        private void UpdateIDAnalyzerResult(int rowIndex, string maTiepNhan)
        {
            if (gvKetQua.RowCount == 0 || _loading)
                return;
            var log = string.Empty;
            try
            {
                var maXn = gvKetQua.GetRowCellValue(rowIndex, colKetQua_MaXN) != null
                   ? gvKetQua.GetRowCellValue(rowIndex, colKetQua_MaXN).ToString().Trim()
                   : string.Empty;
                var idMay = gvKetQua.GetRowCellValue(rowIndex, colKetQua_IDMayXetNghiem) != null
                          ? gvKetQua.GetRowCellValue(rowIndex, colKetQua_IDMayXetNghiem).ToString().Trim() : "0";
                gvKetQua.SetRowCellValue(rowIndex, colKetQua_maythuchien, idMay);
                _xetnghiem.CapNhat_MayChay_Ketqua(maTiepNhan, maXn, idMay, CommonAppVarsAndFunctions.UserID);
            }
            catch (Exception ex)
            {
                LabServices_Helper.RecordError(log);
                ErrorService.GetFrameworkErrorMessage(ex, "CapNhatKQ_IDmayXetNghiem", CommonAppVarsAndFunctions.UserID);
            }
        }
        //Các biến toàn cục để giảm khởi tạo biến nhớ nhiều lần.
        string ketQua = string.Empty;
        string maXn = string.Empty;
        string ghiChu = string.Empty;
        string nguongTren = string.Empty;
        string nguongDuoi = string.Empty;
        string dieuKienBatThuong = string.Empty;
        int flag = 0;
        string userNhapKQ = string.Empty;
        float hesoquidoi = 0F;
        string lamtron = string.Empty;
        string nguongTrenCanhBao = string.Empty;
        string nguongDuoiCanhBao = string.Empty;
        string dieuKienBatThuongCanhBao = string.Empty;
        int flagCanhBao = 0;
        string macaptren = string.Empty;
        string logUpdateKQ = string.Empty;
        private void UpdateResult(int rowIndex, string maTiepNhan, bool fromAuto)
        {
            if (gvKetQua.RowCount == 0 || _loading)
                return;
            logUpdateKQ = string.Empty;
            try
            {
                gvKetQua.RowCellStyle -= gvKetQua_RowCellStyle;
                gvKetQua.CellValueChanged -= gvKetQua_CellValueChanged;
           //     gvKetQua.CalcRowHeight -= gvKetQua_CalcRowHeight;
                logUpdateKQ = "Lấy các giá trị";
                logUpdateKQ += Environment.NewLine + "     _indexKQ";
                //var indexKq = 3;
                logUpdateKQ += Environment.NewLine + "     _KetQua";
                ketQua = gvKetQua.GetRowCellValue(rowIndex, colKetQua_KetQua) != null
                    ? gvKetQua.GetRowCellValue(rowIndex, colKetQua_KetQua).ToString().Trim()
                    : string.Empty;
                logUpdateKQ += Environment.NewLine + "     _MaXN";
                maXn = gvKetQua.GetRowCellValue(rowIndex, colKetQua_MaXN) != null
                    ? gvKetQua.GetRowCellValue(rowIndex, colKetQua_MaXN).ToString().Trim()
                    : string.Empty;
                logUpdateKQ += Environment.NewLine + "     _GhiChu";
                ghiChu = gvKetQua.GetRowCellValue(rowIndex, colKetQua_GhiChu) != null
                    ? gvKetQua.GetRowCellValue(rowIndex, colKetQua_GhiChu).ToString().Trim()
                    : string.Empty;
                logUpdateKQ += Environment.NewLine + "     _NguongTren";
                nguongTren = gvKetQua.GetRowCellValue(rowIndex, colKetQua_NguongTren) != null
                    ? gvKetQua.GetRowCellValue(rowIndex, colKetQua_NguongTren).ToString().Trim()
                    : string.Empty;
                logUpdateKQ += Environment.NewLine + "     _NguongDuoi";
                nguongDuoi = gvKetQua.GetRowCellValue(rowIndex, colKetQua_NguongDuoi) != null
                    ? gvKetQua.GetRowCellValue(rowIndex, colKetQua_NguongDuoi).ToString().Trim()
                    : string.Empty;
                logUpdateKQ += Environment.NewLine + "     _DieuKienBatThuong";
                dieuKienBatThuong = gvKetQua.GetRowCellValue(rowIndex, colKetQua_DKBatThuong) != null
                    ? gvKetQua.GetRowCellValue(rowIndex, colKetQua_DKBatThuong).ToString().Trim()
                    : string.Empty;
                logUpdateKQ += Environment.NewLine + "     _Co";
                flag = gvKetQua.GetRowCellValue(rowIndex, colKetQua_Flat) != null
                    ? int.Parse(gvKetQua.GetRowCellValue(rowIndex, colKetQua_Flat).ToString())
                    : 0;
                logUpdateKQ += Environment.NewLine + "     _UserNhap";
                userNhapKQ = gvKetQua.GetRowCellValue(rowIndex, colKetQua_maythuchien) != null
                    ? gvKetQua.GetRowCellValue(rowIndex, colKetQua_maythuchien).ToString().Trim()
                    : string.Empty;    
                logUpdateKQ += Environment.NewLine + "     _XNChinh";
                hesoquidoi = gvKetQua.GetRowCellValue(rowIndex, colKetQua_HeSoQuiDoi) != null
                    ? float.Parse(gvKetQua.GetRowCellValue(rowIndex, colKetQua_HeSoQuiDoi).ToString())
                    : 0;
                lamtron = gvKetQua.GetRowCellValue(rowIndex, colKetQua_LamTron) != null
                    ? gvKetQua.GetRowCellValue(rowIndex, colKetQua_LamTron).ToString().Trim()
                    : string.Empty;
                // cờ cảnh báo
                logUpdateKQ += Environment.NewLine + "     _NguongTrenCanhBao";
                nguongTrenCanhBao = gvKetQua.GetRowCellValue(rowIndex, colKetQua_CanTrenCanhBao) != null
                    ? gvKetQua.GetRowCellValue(rowIndex, colKetQua_CanTrenCanhBao).ToString().Trim()
                    : string.Empty;
                logUpdateKQ += Environment.NewLine + "     _NguongDuoiCanhBao";
                nguongDuoiCanhBao = gvKetQua.GetRowCellValue(rowIndex, colKetQua_CanDuoicanhBao) != null
                    ? gvKetQua.GetRowCellValue(rowIndex, colKetQua_CanDuoicanhBao).ToString().Trim()
                    : string.Empty;
                logUpdateKQ += Environment.NewLine + "     _DieuKienCanhBaoDinhTinh";
                dieuKienBatThuongCanhBao = gvKetQua.GetRowCellValue(rowIndex, colKetQua_DieuKienCanhBaoDinhTinh) != null
                    ? gvKetQua.GetRowCellValue(rowIndex, colKetQua_DieuKienCanhBaoDinhTinh).ToString().Trim()
                    : string.Empty;
                logUpdateKQ += Environment.NewLine + "     _CoCanhBao";
                flagCanhBao = gvKetQua.GetRowCellValue(rowIndex, colKetQua_CoCanhBao) != null
                    ? int.Parse(gvKetQua.GetRowCellValue(rowIndex, colKetQua_CoCanhBao).ToString())
                    : 0;
                logUpdateKQ += Environment.NewLine + "      macaptren";
                macaptren = gvKetQua.GetRowCellValue(rowIndex, colKetQua_ProfileID) != null
                    ? gvKetQua.GetRowCellValue(rowIndex, colKetQua_ProfileID).ToString().Trim()
                    : string.Empty;
                if (string.IsNullOrEmpty(macaptren))
                    macaptren = gvKetQua.GetRowCellValue(rowIndex, colKetQua_MaCapTren) != null
                    ? gvKetQua.GetRowCellValue(rowIndex, colKetQua_MaCapTren).ToString().Trim()
                    : string.Empty;
                logUpdateKQ += Environment.NewLine + "Thực hiện kiểm tra đánh giá khi nhập hoặc sửa kết quả";
                logUpdateKQ += Environment.NewLine + "Đánh giá kết quả";
                flag = LabResultService.SetColor(ketQua, nguongTren, nguongDuoi, dieuKienBatThuong);
                flagCanhBao = LabResultService.SetColor(ketQua, nguongTrenCanhBao, nguongDuoiCanhBao, dieuKienBatThuongCanhBao);
                var obUpdate = new UpdateResultNormalInfo()
                {
                    maTiepNhan = maTiepNhan,
                    maXN = maXn,
                    ketQua = ketQua,
                    capNhatghiChu = true,
                    ghiChu = ghiChu,
                    co = flag.ToString(),
                    userNhap = CommonAppVarsAndFunctions.UserID,
                    suaKQ = (!string.IsNullOrWhiteSpace(userNhapKQ)),
                    round = lamtron,
                    userUpdate = CommonAppVarsAndFunctions.UserID,
                    coCanhBao = flagCanhBao,
                    Qcout = false
                };
                if (string.IsNullOrEmpty(ketQua))
                {
                    obUpdate.capnhatCoKetQua = true;
                    obUpdate.coKetQua = "";
                }
                _xetnghiem.CapNhat_KQ_XN(obUpdate);
                _xetnghiem.CapNhat_CSBT(maTiepNhan, maXn, "0", true);

                if (!fromAuto)
                {
                    logUpdateKQ += Environment.NewLine + "Gán các giá trị lên lưới";
                    Set_StatusToGrid(rowIndex, maTiepNhan, maXn, CommonAppVarsAndFunctions.UserID, lamtron, hesoquidoi, ketQua);
                }
                Check_AddEventValueChange();
                gvKetQua.RowCellStyle += gvKetQua_RowCellStyle;
            }
            catch (Exception ex)
            {
                Check_AddEventValueChange();
                gvKetQua.RowCellStyle += gvKetQua_RowCellStyle;
                LabServices_Helper.RecordError(logUpdateKQ);
                ErrorService.GetFrameworkErrorMessage(ex, "CapNhatKQ_KiemTraHienthi", CommonAppVarsAndFunctions.UserID);
            }
        }
        private void Set_StatusToGrid(int rowIndex, string maTiepNhan, string maXn, string userNhap, string lamtron, float hesoquidoi, string ketQua)
        {
            Task.Factory.StartNew(() => _xetnghiem.CapNhat_DuKQ_XN(maTiepNhan));
            var calheight = CalRowHeight(ketQua);
            var objInfo = _xetnghiem.Info_ThongTinKetQua(maTiepNhan, maXn);
            gvKetQua.SetRowCellValue(rowIndex, colKetQua_ThoiGianNhapKQ, CommonAppVarsAndFunctions.ServerTime);
            if (calheight > LimitRowHeight)
                gvKetQua.OptionsView.RowAutoHeight = true;
            gvKetQua.SetRowCellValue(rowIndex, colKetQua_Flat, objInfo.CoKetQua);
            gvKetQua.OptionsView.RowAutoHeight = false;
            gvKetQua.SetRowCellValue(rowIndex, colKetQua_CoCanhBao, objInfo.CoKetQuaCanhBao);
            gvKetQua.SetRowCellValue(rowIndex, colKetQua_NguongTren, objInfo.NguongTren);
            gvKetQua.SetRowCellValue(rowIndex, colKetQua_NguongDuoi, objInfo.NguongDuoi);
            gvKetQua.SetRowCellValue(rowIndex, colKetQua_CSBT, objInfo.GiaTriThamChieu);
            gvKetQua.SetRowCellValue(rowIndex, colKetQua_maythuchien, userNhap);
            gvKetQua.SetRowCellValue(rowIndex, colKetQua_GhiChu, objInfo.GhiChu);
            gvKetQua.SetRowCellValue(rowIndex, colKetQua_IDMayXetNghiem, objInfo.IdMayXetNghiem);

            gvKetQua.SetRowCellValue(rowIndex, colKetQua_HeSoQuiDoi, objInfo.HeSoQuiDoi);
            gvKetQua.SetRowCellValue(rowIndex, colKetQua_CSBTQuiDoi, objInfo.CSBTQuiDoi);
            gvKetQua.SetRowCellValue(rowIndex, colKetQua_KetQuaQuiDoi, objInfo.KetQuaQuiDoi);
            gvKetQua.SetRowCellValue(rowIndex, colKetQua_DonViQuiDoi, objInfo.DonViQuiDoi);
            gvKetQua.SetRowCellValue(rowIndex, colKetQua_KetQuaDTQuiDoi, objInfo.KQDinhTinhQuyDoi);
        }
        private bool _AllowEditCurrentRow(string userNhapKq, bool daXacNhan)
        {
            if (daXacNhan)
                return false;
            else
            {
                if (_allowInsert && string.IsNullOrWhiteSpace(userNhapKq))
                {
                    //Đảm bảo user có quyền nhập và vị trí chưa nhập kết quả lần nào
                    return true;
                }
                else if (_allowEdit)
                {
                    if (userNhapKq.Equals(CommonAppVarsAndFunctions.UserID, StringComparison.OrdinalIgnoreCase) || _allowEditResulFromOtherUser)
                        //Đảm bảo user có quyền sửa và vị trí có kết quả đã nhập
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
        }
        private void txtComment_Leave(object sender, EventArgs e)
        {
            _xetnghiem.CapNhat_KetLuan_XN(CurrentMaTiepNhan, txtComment.Text, txtGhiChu.Text);
        }
        public void SelectAllXN()
        {
            gvKetQua.SelectAll();
        }
        public bool HaveItem
        {
           get { return gvKetQua.RowCount > 0; }
        }
        public bool IsCalculate_Impossible_Valid()
        {
            if (gvKetQua.RowCount <= 0) return false;
            var dtcal = (DataTable)gcKetQua.DataSource;
            var dataCalConfig = WorkingServices.SearchResult_OnDatatable(_dtCalculateConfig, string.Format("{0} = '{1}' or {0} = '{2}'"
                , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Cachtinhtoan)
                , CommonConfigConstant.DuyetKetQua, CommonConfigConstant.DuyetKetQuaDinhTinh));
            if (dtcal.Rows.Count <= 0 || dataCalConfig.Rows.Count <= 0) return false;
            return _iResultConvert.CalculateDuyetKQ(dtcal, dataCalConfig);
        }
        public bool XacNhanKetQua(bool valid    
            , bool ask = true
            , bool fromHotKey = false)
        {
            var haveAction = false;
            if (gvKetQua.RowCount == 0) return false;

            var allow = !ask || CustomMessageBox.MSG_Question_YesNo_GetYes(
                             (valid
                                 ? $"{LanguageExtension.GetResourceValueFromValue("Xác nhận", LanguageExtension.AppLanguage)} "
                                 : $"{LanguageExtension.GetResourceValueFromValue("Hủy xác nhận", LanguageExtension.AppLanguage)} "
                             ) + "các kết quả được chọn?");
            if (allow)
            {
                if (valid)
                {
                    if (IsCalculate_Impossible_Valid()) return false;
                }

                gvKetQua.CellValueChanged -= gvKetQua_CellValueChanged;
                var maTiepNhan = string.Empty;
                string validText = (valid
                    ? Common.CommonConstant.IsValided
                    : Common.CommonConstant.InValid);
                CustomMessageBox.ShowAlert(string.Format(
                    $"{LanguageExtension.GetResourceValueFromValue("Đang thực hiện {0} xác nhận kết quả!", LanguageExtension.AppLanguage)}",
                    valid
                        ? ""
                        : $"{LanguageExtension.GetResourceValueFromValue("Hủy", LanguageExtension.AppLanguage)} "));
                string updateInsTring = string.Empty;
                var slectedRow = gvKetQua.GetSelectedRows();
                var lstNhatKyDuyet = new List<NhatKy_DuyetKetQua_ChiTiet>();
                bool coDain = false;
                var lstMaXn = new List<string>();
                var kqABOTM = string.Empty;
                var kqRhTM = string.Empty;
                var lstMaTiepNhanHL7 = new List<BenhNhanInfoForHIS>();
                var lstBnHL7Upate = new List<BenhNhanInfoForHIS>();
                if (hisId > 0)
                {
                    lstMaTiepNhanHL7.Add(_iHisData.GetDataUploadToHIS(new GetUploadCondit
                    {
                        userID = CommonAppVarsAndFunctions.UserID,
                        matiepnhan = CurrentMaTiepNhan,
                        onlyValid = false,
                        onlyPrinted = false,
                        arrCatePrint = null,
                        arrtestCodePrint = null,
                        arrTestTypeID = new string[] { },
                        frombackup = false,
                        manualUpload = true,
                        forStatus = true
                    }));
                }
                foreach (int i in slectedRow)
                {
                    _countToFocus = 0;
                    if (gvKetQua.GetRowCellValue(i, colKetQua_MaXN) != null)
                    {
                        var QCFail = bool.Parse(gvKetQua.GetRowCellValue(i, colKetQua_QCOut).ToString());
                        var loaiXn = int.Parse(gvKetQua.GetRowCellValue(i, colKetQua_LoaiXetNghiem).ToString().Trim());
                        if (valid)
                        {
                            if (QCFail)
                            {
                                if (!CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemChoDuyetQCFail)
                                    continue;
                                if (CustomMessageBox.MSG_Question_YesNo_GetNo(string.Format("Kết QC của xét nghiệm \"{0}\" đã FAIL.\nVẫn duyệt kết quả này?", gvKetQua.GetRowCellValue(i, colKetQua_TenXN).ToString().Trim()), Common.Controls.CustomMsgBox.CustomMessageBoxConstants.DefaultButton.NotAccept))
                                    continue;
                            }
                            if (!string.IsNullOrEmpty(gvKetQua.GetRowCellValue(i, colKetQua_KetQua) != null
                                ? gvKetQua.GetRowCellValue(i, colKetQua_KetQua).ToString() : string.Empty)
                                 || bool.Parse(gvKetQua.GetRowCellValue(i, colKetQua_XNChinh).ToString()))
                            {
                                var maXn = gvKetQua.GetRowCellValue(i, colKetQua_MaXN).ToString().Trim();
                                var maXnCaptren = gvKetQua.GetRowCellValue(i, colKetQua_MaCapTren).ToString().Trim();
                                updateInsTring += (string.IsNullOrEmpty(updateInsTring) ? "" : ",") + string.Format("{0}", maXn);
                                if ((loaiXn == (int)TestType.EnumTestType.XNTuiMau 
                                    || loaiXn == (int)TestType.EnumTestType.XetNghiemTruyenMau
                                    || loaiXn == (int)TestType.EnumTestType.XNABONguoiNhanMau
                                    || loaiXn == (int)TestType.EnumTestType.XNRhNguoiNhanMau
                                    || loaiXn == (int)TestType.EnumTestType.XNNacl9
                                    || loaiXn == (int) TestType.EnumTestType.XNCoombs
                                    || loaiXn == (int)TestType.EnumTestType.XNNacl9_2 
                                    || loaiXn == (int)TestType.EnumTestType.XNCoombs_2
                                     )
                                    && !bool.Parse(gvKetQua.GetRowCellValue(i, colKetQua_DaXacNhan).ToString()))
                                {
                                    lstMaXn.Add(maXn);
                                    if (loaiXn == (int)TestType.EnumTestType.XNABONguoiNhanMau)
                                        kqABOTM = gvKetQua.GetRowCellValue(i, colKetQua_KetQua).ToString().Trim();
                                   else if (loaiXn == (int)TestType.EnumTestType.XNRhNguoiNhanMau)
                                        kqRhTM = gvKetQua.GetRowCellValue(i, colKetQua_KetQua).ToString().Trim();
                                }
                                if (!coDain)
                                {
                                    var daIn = bool.Parse(gvKetQua.GetRowCellValue(i, colKetQua_DaInKQXN).ToString());
                                    coDain = daIn;
                                }
                            }
                        }
                        else
                        {
                            if (gvKetQua.GetRowCellValue(i, colKetQua_MaXN) != null || bool.Parse(gvKetQua.GetRowCellValue(i, colKetQua_XNChinh).ToString()))
                            {
                                var maXn = gvKetQua.GetRowCellValue(i, colKetQua_MaXN).ToString().Trim();
                                var maXnCaptren = gvKetQua.GetRowCellValue(i, colKetQua_MaCapTren).ToString().Trim();
                                updateInsTring += (string.IsNullOrEmpty(updateInsTring) ? "" : ",") + string.Format("{0}", maXn);
                                if (
                                    loaiXn == (int)TestType.EnumTestType.XNTuiMau || loaiXn == (int)TestType.EnumTestType.XetNghiemTruyenMau
                                    || loaiXn == (int)TestType.EnumTestType.XNNacl9 || loaiXn == (int)TestType.EnumTestType.XNCoombs
                                    || loaiXn == (int)TestType.EnumTestType.XNNacl9_2 || loaiXn == (int)TestType.EnumTestType.XNCoombs_2
                                    || loaiXn == (int)TestType.EnumTestType.XNABONguoiNhanMau
                                    || loaiXn == (int)TestType.EnumTestType.XNRhNguoiNhanMau)
                                {
                                    lstMaXn.Add(maXn);

                                    if (loaiXn == (int)TestType.EnumTestType.XNABONguoiNhanMau)
                                        kqABOTM = gvKetQua.GetRowCellValue(i, colKetQua_KetQua).ToString().Trim();
                                    else if (loaiXn == (int)TestType.EnumTestType.XNRhNguoiNhanMau)
                                        kqRhTM = gvKetQua.GetRowCellValue(i, colKetQua_KetQua).ToString().Trim();
                                }
                                if (hisId > 0)
                                {
                                    //Thêm thông tin update HL7 về ISOFH
                                    var bnExisted = lstBnHL7Upate.Where(x => x.Matiepnhan.Equals(CurrentMaTiepNhan));
                                    if (bnExisted.Any())
                                    {
                                        var bnInfo = bnExisted.FirstOrDefault();
                                        var chidinhF = lstMaTiepNhanHL7.Where(x => x.Matiepnhan.Equals(CurrentMaTiepNhan));
                                        if (chidinhF.Any())
                                        {
                                            var chidinhDetail = chidinhF.First().ChiDinh.Where(c => c.MaXN.Equals(maXn));
                                            if (chidinhDetail.Any())
                                            {
                                                var chidinh = chidinhDetail.First();
                                                chidinh.TrangThaiMau = OrderStatus.SampleGet;
                                                bnInfo.ChiDinh.Add(chidinh);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        var bnF = lstMaTiepNhanHL7.Where(x => x.Matiepnhan.Equals(CurrentMaTiepNhan));
                                        if (bnF.Any())
                                        {
                                            var bnAdd = bnF.First().CopyHISInfo();
                                            if (bnAdd.ChiDinh.Count > 0)
                                            {
                                                var chidinhF = bnAdd.ChiDinh.Where(c => c.MaXN.Equals(maXn) || (c.MaXNCha_His ?? string.Empty).Equals(maXnCaptren));
                                                if (chidinhF.Any())
                                                {
                                                    var chidinh = chidinhF.ToList();
                                                    foreach (var itmChiDinh in chidinh)
                                                    {
                                                        itmChiDinh.TrangThaiMau = OrderStatus.SampleGet;
                                                    }
                                                    bnAdd.ChiDinh = chidinh;
                                                    lstBnHL7Upate.Add(bnAdd);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (string.IsNullOrEmpty(maTiepNhan))
                            maTiepNhan = gvKetQua.GetRowCellValue(i, colKetQua_MaTiepNhan).ToString();

                        var obj = new NhatKy_DuyetKetQua_ChiTiet();
                        obj.MaXN = gvKetQua.GetRowCellValue(i, colKetQua_MaXN).ToString().Trim();
                        obj.NguoiDuyetMoi = CommonAppVarsAndFunctions.UserID;
                        obj.TenNguoiDuyetMoi = CommonAppVarsAndFunctions.UserName;
                        obj.TenMayTinh = Environment.MachineName;
                        obj.TGThucHien = CommonAppVarsAndFunctions.ServerTime;
                        obj.ThaoTacDuyet = valid;
                        obj.KetQua = gvKetQua.GetRowCellValue(i, colKetQua_KetQua).ToString().Trim();
                        obj.NguoiDuyetTruoc = gvKetQua.GetRowCellValue(i, colKetQua_NguoiXacNhan).ToString().Trim();
                        obj.TenXN = gvKetQua.GetRowCellValue(i, colKetQua_TenXN).ToString().Trim();

                        lstNhatKyDuyet.Add(obj);
                    }
                }

                if (!string.IsNullOrEmpty(updateInsTring))
                {
                    Task.Factory.StartNew(() =>
                    {
                        _writeDblog.WriteLog_KetQua_XetNghiem_Duyet(maTiepNhan, _barcode, _soHoSo, _maBn, lstNhatKyDuyet);

                    });
                    if (lstBnHL7Upate.Count > 0)
                    {
                        Task.Factory.StartNew(() => { UpdateTrangThaiVeHIS(lstBnHL7Upate); });
                    }
                    _xetnghiem.XacNhan_KQ_XN(maTiepNhan, updateInsTring, validText,
                              valid, CommonAppVarsAndFunctions.UserID, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXacNhanDe, (int)CommonAppVarsAndFunctions.sysConfig.LayNguoiThucHien);
                    //if (valid)
                    //{
                    //    //Insert NAT Infinity
                    //    _xetnghiem.InsertNATToInfinity(maTiepNhan, dtpNgayTiepNhan.Value);
                    //}

                    //Cập nhật đủ kết quả
                    _xetnghiem.CapNhat_DuKQ_XN(maTiepNhan);
                    if (valid)
                    {
                        //Đưa vào danh sách upload khi chỉ cấu hình Upload khi duyệt
                        if ((CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemUploadDaDuyet && !CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemUploadDaIn)
                            || (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemUploadDaDuyet && CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemUploadDaIn && coDain)
                            )
                            _iPatient.DuaVaoDanhSachUploadHIS(maTiepNhan);
                    }
                    //Cập nhật valid
                    ///_xetnghiem.CapNhat_Valid_XN(maTiepNhan, CommonAppVarsAndFunctions.UserID);
                    //Ghi kết quả vào LabBlood
                    if (lstMaXn.Count > 0)
                        InsertDelete_Result_LabBlood(maTiepNhan, lstMaXn, valid);
                    if (!string.IsNullOrEmpty(kqABOTM) && !string.IsNullOrEmpty(kqRhTM))
                    {
                        if (kqRhTM.Equals("dương", StringComparison.OrdinalIgnoreCase) || kqRhTM.Equals("pos", StringComparison.OrdinalIgnoreCase))
                            kqRhTM = "+";
                        else if (kqRhTM.Equals("âm", StringComparison.OrdinalIgnoreCase) || kqRhTM.Equals("neg", StringComparison.OrdinalIgnoreCase))
                            kqRhTM = "-";

                        _xetnghiem.Update_BnTruyenMau_KQNhomMau(maTiepNhan, (!valid ? string.Empty : kqABOTM),
                             (!valid ? string.Empty : kqRhTM), CommonAppVarsAndFunctions.UserID);
                    }
                    //cập nhật hủy xác nhận về HIS
                    if (!valid)
                    {
                        HuyXacNhanHis(maTiepNhan, updateInsTring);
                    }
                    if (!fromHotKey)
                        Load_ChiTietXN(CurrentMaTiepNhan, DataPatient);
                    haveAction = true;
                }
               
                CustomMessageBox.CloseAlert();
                Check_AddEventValueChange();
            }
            return haveAction;
        }
        private void UpdateTrangThaiVeHIS(List<BenhNhanInfoForHIS> lst)
        {
            if (hisId == (int)HisProvider.ISofH)
            {
                foreach (var item in lst)
                {
                    if (item.Hisproviderid.Equals((int)HisProvider.ISofH))
                    {
                        var hisInfo = CommonAppVarsAndFunctions.HisConnectList.Where(x => ((int)x.HisID).Equals(item.Hisproviderid)).FirstOrDefault();
                        //Gọi về his nhận mẫu
                        _iHisData.LISCheckOrder(hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, item);
                    }
                }
            }
            else if (hisId == (int)HisProvider.VNPTMN)
            {

                var hisInfoparaInfoList = new List<HisParaGetList>();
                foreach (var itmChiDinh in lst)
                {
                    foreach (var item in itmChiDinh.ChiDinh)
                    {
                        hisInfoparaInfoList.Add(new HisParaGetList()
                        {
                            IDChiDinh = item.IdChiTiet,
                            IDChiDinhDichVu = item.IDDichVuChiDinh,
                            SoPhieuChiDinh = item.SoPhieuChiDinh,
                            MaBenhAn = itmChiDinh.Bn_id,
                            IDGiayto = itmChiDinh.Giayto_id,
                            MaXetNghiemLIS = item.TestCode,
                            MaTiepNhanLIS = itmChiDinh.Matiepnhan,
                            NgayTiepNhan = itmChiDinh.Ngaytiepnhan,
                            NoiTru = itmChiDinh.Noitru,
                            TrangThai = 1,
                            TrangThaiHL7 = OrderStatus.OrderRecieved,
                            IDBangKe = item.Bangkeid,
                            IDUserThucHien = item.MaNhanVienThucHien,
                            NgayChiDinh = item.Thoigiangui,
                            TenDichVu = item.TenXN_His,
                            ThoiGianThucHien = item.Thoigianxacnhan,
                            IDUserLayMau = item.NguoiLayMauHIS,
                            ThoiGianLayMau = item.ThoiGianLayMau,
                            MaDichVu = item.MaXN_His
                        });
                    }
                    var hisInfo = CommonAppVarsAndFunctions.HisConnectList.Where(x => ((int)x.HisID).Equals(itmChiDinh.Hisproviderid)).FirstOrDefault();
                    //Gọi về his nhận mẫu
                    _iHisData.Update_HuyKetQua(hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, hisInfoparaInfoList);
                }

            }
        }
        private void InsertDelete_Result_LabBlood(string matiepnhan, List<string> lstMaXn, bool isInsert)
        {
            if (isInsert)
                _xetnghiem.Ins_KetQua_LabBlood(matiepnhan, string.Join(",", lstMaXn));
            else
                _xetnghiem.Del_KetQua_LabBlood(matiepnhan, string.Join(",", lstMaXn));
        }
        private void HuyXacNhanHis(string matiepNhan, string lstMaXn)
        {
            try
            {
                if (!string.IsNullOrEmpty(matiepNhan))
                {
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

        public void ClearShowingData()
        {
            gcBoPhan.DataSource = null;
            gcKetQua.DataSource = null;
            gcNhomCLS.DataSource = null;
        }

        #region In kết quả
        public bool InKetQua(
            bool print,
            string userSign
            , string printerName
            , bool inCoQuyDoi
            , bool inMau
            , bool chiInCoKQ
            , ToolStripProgressBar progressPrint
            , string mauChonIn
            , string tenlanhdao
            , string chuvuLanhdao
            , DateTime? GioIn
            , bool title)
        {
            if (_dtPatient == null) return false;

            var haveprint = false;
            if (_dtPatient.Rows.Count > 0 && gvKetQua.RowCount > 0)
            {
                var dataReporttype = ((DataTable)gcKetQua.DataSource).DefaultView.ToTable(true, "IDMauKetQua");

                haveprint =  Check_PrintResult(CurrentMaTiepNhan, print, title, false, dataReporttype, userSign
                    , printerName, inCoQuyDoi, inMau, chiInCoKQ, progressPrint, mauChonIn, tenlanhdao, chuvuLanhdao, GioIn);
            }
            return haveprint;
        }
        private bool Check_PrintResult(string matiepnhan
            , bool print, bool title
            , bool isAutpPrint
            , DataTable dataReportType
            , string userSign
            , string printerName
            , bool inCoQuyDoi
            , bool inMau
            , bool chiInCoKQ
            , ToolStripProgressBar progressPrint
            , string mauChonIn
            , string tenlanhdao
            , string chuvuLanhdao
            , DateTime? GioIn
            )
        {

            var objPrintInfo = new PrintResultInfo()
            {
                matiepnhan = matiepnhan,
                print = print,
                title = title,
                isAutoPrint = isAutpPrint,
                userSign = userSign,
                printerName = printerName,
                inCoQuiDoi = inCoQuyDoi,
                inMau = inMau,
                chiInCoKetQua = chiInCoKQ,
                progressPrint = progressPrint,
                mauChonIn = mauChonIn,
                tenlanhdao = tenlanhdao,
                chuvuLanhdao = chuvuLanhdao,
                ngayIn = GioIn
            };
            if (userSign.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase)
                && !CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemChoChuKyGiongUserDangNhap)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn người ký tên khác user đăng nhập!");
                return false;
            }
            objPrintInfo.reportType = chlDanhSachPhieuKetQua.ItemCheckedList("IDMauKetQua");

            if (!isAutpPrint)
                objPrintInfo.showMess = chkXemXetTheoMauIn.Checked;

            if (chkViewWithCategory.Checked)
                objPrintInfo.category = chlViewWithCategory.ItemList("MaNhomCLS");
            else
                objPrintInfo.category = chlViewWithCategory.AllItemList("MaNhomCLS");

            objPrintInfo.category = string.IsNullOrEmpty(objPrintInfo.category) ? chlViewWithCategory.AllItemList("MaNhomCLS") : objPrintInfo.category;
            if (chkXemtheoBoPhan.Checked)
                objPrintInfo.boPhan = chlBoPhan.ItemList("MaBoPhan");
            else
                objPrintInfo.boPhan = chlBoPhan.AllItemList("MaBoPhan");
            objPrintInfo.boPhan = string.IsNullOrEmpty(objPrintInfo.boPhan) ? chlBoPhan.AllItemList("MaNhomCLS") : objPrintInfo.boPhan;

            objPrintInfo.conditSomeTestPrint = Get_PrintTest();
            objPrintInfo.ListCauHinhMayIn = _listCauHinhMayIn;
            objPrintInfo.arrLoaiXetNghiem = _arrLoaiXetNghiem;

            var objPrintFinish = _inKetQua.Check_PrintResult(ref _printCount, reportLogo, objPrintInfo);

            //Đưa vào danh sách upload khi chỉ cấu hình Upload khi in
            if (objPrintFinish.havePrint)
            {
                if ((CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemUploadDaIn && !CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemUploadDaDuyet)
                     || (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemUploadDaDuyet && CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemUploadDaIn
                     && (objPrintFinish.coDaDuyet || CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemInTuXacNhan))
                     || (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemUploadDaDuyet && CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemInTuXacNhan)
                     )
                    _iPatient.DuaVaoDanhSachUploadHIS(matiepnhan);
            }

            return objPrintFinish.havePrint;
        }
        #endregion
        private void Set_ColumnDataPropertyLoweCase()
        {
        var alreadyFormatGrid = false;
            var objCauHinhLuoiKQ = _isSysConfig.lstThongTinHienThi(HienthiConstants.LuoiKQThuongQui);
            if (objCauHinhLuoiKQ != null)
            {
                if (objCauHinhLuoiKQ.Count > 0)
                {
                    foreach (GridColumn item in gvKetQua.Columns)
                    {
                        if (item.Fixed == FixedStyle.None)
                        {
                            item.Visible = false;
                            item.VisibleIndex = -1;
                            item.FieldName = item.FieldName.ToLower().Trim();
                        }
                        else
                            item.FieldName = item.FieldName.ToLower().Trim();
                    }

                    objCauHinhLuoiKQ = objCauHinhLuoiKQ.Where( x => x.Sapxep > -1).OrderBy(x => x.Sapxep).ToList();

                    foreach (var item in objCauHinhLuoiKQ)
                    {
                        var olFind = gvKetQua.Columns.Where(e => e.Name.Equals(item.Idhienthi, StringComparison.OrdinalIgnoreCase) && e.Fixed == FixedStyle.None);
                        if (olFind.Any())
                        {
                            var itemCol = olFind.First();
                            itemCol.Visible = item.Hienthi;
                            itemCol.Caption = item.Mota;
                            itemCol.Width = item.Dorong;

                            if (item.Hienthi && item.Sapxep > -1)
                            {
                                itemCol.VisibleIndex = item.Sapxep;
                                if (itemCol.Name == colKetQua_IDMayXetNghiem.Name)
                                {
                                    colKetQua_IDMayXetNghiem.Visible = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemChoPhepSuaMayXN;
                                }
                            }
                            else
                                itemCol.VisibleIndex = -1;

                            itemCol.FieldName = itemCol.FieldName.ToLower().Trim();

                            if (itemCol.Name == colKetQua_ThuTuNhom.Name && itemCol.Name == colKetQua_SapXep.Name)
                            {
                                itemCol.SortMode = ColumnSortMode.Value;
                                itemCol.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                            }
                            else
                                itemCol.OptionsColumn.AllowSort = DefaultBoolean.False;

                            if (itemCol.Name == colKetQua_GhiChu.Name)
                            {
                                colKetQua_GhiChu.Caption = (cheDohienThi == 1 ? "Chú thích" : colKetQua_GhiChu.Caption);
                            }
                            else if (itemCol.Name == colKetQua_MaSoMau.Name)
                            {
                                colKetQua_MaSoMau.Visible = (cheDohienThi == 1 ? true : false);
                            }
                            else if (itemCol.Name == colKetQua_KieuGen.Name)
                            {
                                colKetQua_KieuGen.Visible = (cheDohienThi == 1 ? true : false);
                            }
                            else if (itemCol.Name == colKetQua_CSBT.Name)
                            {
                                colKetQua_CSBT.Caption = (cheDohienThi == 1 ? "Ngưỡng định lượng" : colKetQua_CSBT.Caption);
                            }

                            if (itemCol.Name == colKetQua_ThuTuNhom.Name && itemCol.Name == colKetQua_SapXep.Name)
                            {
                                itemCol.SortMode = ColumnSortMode.Value;
                                itemCol.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                            }
                            else
                                itemCol.OptionsColumn.AllowSort = DefaultBoolean.False;

                            itemCol.Caption = LanguageExtension.GetResourceValueFromValue(item.Mota,
                                    LanguageExtension.AppLanguage);

                        }
                    }

                    gcKetQua.Refresh();
                    alreadyFormatGrid = true;
                }
            }
            if (!alreadyFormatGrid)
            {
                for (var i = 0; i < gvKetQua.Columns.Count; i++)
                {
                    var col = gvKetQua.Columns[i];
                    col.FieldName = col.FieldName.ToLower().Trim();

                    if (col.Name == colKetQua_ThuTuNhom.Name && col.Name == colKetQua_SapXep.Name)
                    {
                        col.SortMode = ColumnSortMode.Value;
                        col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    }
                    else
                        col.OptionsColumn.AllowSort = DefaultBoolean.False;
                    if (col.Name == colKetQua_GhiChu.Name)
                    {
                        col.Caption = (cheDohienThi == 1 ? "Chú thích" : colKetQua_GhiChu.Caption);
                    }
                    else if (col.Name == colKetQua_MaSoMau.Name)
                    {
                        col.Visible = (cheDohienThi == 1 ? true : false);
                    }
                    else if (col.Name == colKetQua_KieuGen.Name)
                    {
                        col.Visible = (cheDohienThi == 1 ? true : false);
                    }
                }
            }
            //Lưới nhóm
            alreadyFormatGrid = false;
            objCauHinhLuoiKQ = _isSysConfig.lstThongTinHienThi(HienthiConstants.LuoiThongTinNhom);
            if (objCauHinhLuoiKQ != null)
            {
                if (objCauHinhLuoiKQ.Count > 0)
                {
                    foreach (GridColumn item in gvNhomCLS.Columns)
                    {
                        item.Visible = false;
                        item.VisibleIndex = -1;
                        item.FieldName = item.FieldName.ToLower().Trim();
                    }
                    objCauHinhLuoiKQ = objCauHinhLuoiKQ.OrderBy(x => x.Sapxep).ToList();
                    foreach (var item in objCauHinhLuoiKQ)
                    {
                        foreach (GridColumn itemCol in gvNhomCLS.Columns)
                        {
                            if (itemCol.Name.Equals(item.Idhienthi, StringComparison.OrdinalIgnoreCase))
                            {
                                itemCol.Visible = item.Hienthi;
                                itemCol.Caption = LanguageExtension.GetResourceValueFromValue(item.Mota,
                                    LanguageExtension.AppLanguage);
                                itemCol.Width = item.Dorong;
                                if (item.Hienthi && item.Sapxep > 0)
                                {
                                    itemCol.VisibleIndex = item.Sapxep;
                                }

                                itemCol.FieldName = itemCol.FieldName.ToLower().Trim();
                                if (itemCol.Name == colKetQua_ThuTuNhom.Name && itemCol.Name == colKetQua_SapXep.Name)
                                {
                                    itemCol.SortMode = ColumnSortMode.Value;
                                    itemCol.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                                }
                                else
                                    itemCol.OptionsColumn.AllowSort = DefaultBoolean.False;
                            }
                        }
                        alreadyFormatGrid = true;
                    }
                }
            }
            if (!alreadyFormatGrid)
            {
                for (var b = 0; b < gvNhomCLS.Columns.Count; b++)
                {
                    var col = gvNhomCLS.Columns[b];
                    col.FieldName = col.FieldName.ToLower().Trim();
                }
            }
            //Lưới bộ phận
            alreadyFormatGrid = false;
            objCauHinhLuoiKQ = _isSysConfig.lstThongTinHienThi(HienthiConstants.LuoiThongTinBoPhan);
            if (objCauHinhLuoiKQ != null)
            {
                if (objCauHinhLuoiKQ.Count > 0)
                {
                    foreach (GridColumn item in gvBoPhan.Columns)
                    {
                        var colFind = objCauHinhLuoiKQ.Where(x => x.Idhienthi.Equals(item.Name, StringComparison.OrdinalIgnoreCase));
                        if (colFind.Any())
                        {
                            var colInfo = colFind.First();
                            item.Visible = colInfo.Hienthi;
                            item.Caption = LanguageExtension.GetResourceValueFromValue(colInfo.Mota,
                                LanguageExtension.AppLanguage);
                            item.Width = colInfo.Dorong;
                            if (colInfo.Hienthi && colInfo.Sapxep > 0)
                            {
                                item.VisibleIndex = colInfo.Sapxep;
                            }
                            item.FieldName = item.FieldName.ToLower().Trim();
                        }
                    }
                    alreadyFormatGrid = true;
                }
            }
            if (!alreadyFormatGrid)
            {
                for (var b = 0; b < gvBoPhan.Columns.Count; b++)
                {
                    var col = gvBoPhan.Columns[b];
                    col.FieldName = col.FieldName.ToLower().Trim();
                }
            }
        }

        public void Load_Config()
        {
            LabServices_Helper.SetControlColor(this);
            CustomMessageBox.ShowAlert(CommonAppVarsAndFunctions.LangMessageConstant.Dangnapcauhinhquanlyketqua, 8);
            //set cấu hình lưới kết quả
            Set_ColumnDataPropertyLoweCase();
            pnTongPhanTichTeBaoMau.Visible = false;
            pnHinhKetQua.Visible = false;
            pnResult_SubInformation.Width = 0;
            if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemHienThiTrangThaiBoPhan)
            {
                if (!CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemHienThiTrangThaiNhom)
                {
                    splitContainer2.CollapsePanel =  DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
                    splitContainer2.Collapsed = true;
                }
            }
            if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemHienThiTrangThaiNhom)
            {
                if (!CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemHienThiTrangThaiBoPhan)
                {
                    splitContainer2.CollapsePanel = SplitCollapsePanel.Panel1;
                    splitContainer2.Collapsed = true;
                }

                if(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemHienThiTrangThaiNhomTheoBoPhan)
                {
                    colNhom_TenBoPhan.GroupIndex = 0;
                }
            }
            splitContainerControl1.SplitterPosition = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemDoCaoLuoiThongTin;
            if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemHienThiDSBoLocHienThi)
            {
                if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiem_LoaiPhieuKetQua == EnumReportResultTemplatetype.MauKetQua_BYT)
                {
                    pnViewWithCategory.Width = 0;
                    pnXemtheoBoPhan.Width = 0;
                    chkXemXetTheoMauIn.Checked = true;
                    pnViewWithReportBYT.Width = 185;
                }
                else
                {
                    pnViewWithReportBYT.Width = 0;
                    if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemKetQuaTheoNhom)
                    {
                        pnViewWithCategory.Width = 185;
                        pnXemtheoBoPhan.Width = 0;
                        chkViewWithCategory.Checked = true;
                    }
                    else
                    {
                        pnViewWithCategory.Width = 0;
                        pnXemtheoBoPhan.Width = 185;
                        chkXemtheoBoPhan.Checked = true;
                    }
                }
            }

            cboImageSize.SelectedIndex = 1;
            cboImageSize.Enabled = false;

            Load_DS_MayXN();
            _listCauHinhMayIn = _isSysConfig.ListCauHinhMayIn(Environment.MachineName);
            Load_DSPhieuIn();
            Load_DSNhomIn(CommonAppVarsAndFunctions.NhomClsXetNghiem);
            Load_DSBophan();
            //trong hàm check enable này có kiểm tra ---> sẽ gỡ check tính tự động nếu không có quyền.
            Check_EnableControl();
            _dtCalculateConfig = _isSysConfig.GetTestCaculate(string.Empty);
            chkXemtheoBoPhan.CheckedChanged += chkXemtheoBoPhan_CheckedChanged;
            chkXemXetTheoMauIn.CheckedChanged += chkXemXetTheoMauIn_CheckedChanged;
            chkViewWithCategory.CheckedChanged += chkViewWithCategory_CheckedChanged;
            chlBoPhan.SelectedIndexChanged += chlBoPhan_SelectedIndexChanged;
            chlDanhSachPhieuKetQua.SelectedIndexChanged += chlDanhSachPhieuKetQua_SelectedIndexChanged;
            chlViewWithCategory.SelectedIndexChanged += chlViewWithCategory_SelectedIndexChanged;
            DataGhiChuTuDong = _isSysConfig.Data_dm_xetnghiem_ghichutudong(null ,string.Empty);


            reportLogo = _isSysConfig.Load_Logo("XN");
            ucSearchLookupEditor_MayXN1.arrAnalyzerAllow = CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem;
            ucSearchLookupEditor_MayXN1.Load_MayXN();
            ucSearchLookupEditor_MayXN2.arrAnalyzerAllow = CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem;
            ucSearchLookupEditor_MayXN2.Load_MayXN();

            repositoryItemMemoEdit1.WordWrap = true;
            repositoryItemMemoEdit1.AutoHeight = true;
            var dataXn = _isSysConfig.Data_dm_xetnghiem(string.Empty, false, string.Empty);
            var dataSHPTGen = WorkingServices.SearchResult_OnDatatable(dataXn, string.Format("LoaiXetNghiem = {0}", (int)EnumTestType.SHPTGenType));
            repositoryItemSearchLookUpEdit1.DataSource = dataSHPTGen;
            repositoryItemSearchLookUpEdit1.ValueMember = "MaXN";
            repositoryItemSearchLookUpEdit1.DisplayMember = "TenXN";
            CustomMessageBox.CloseAlert();
        }
        private void Load_DSPhieuIn()
        {
            chlDanhSachPhieuKetQua.DataSource = _isSysConfig.DSMauPhieuIn_ThaoTac();
            //cboPhieuIn.DataSource = _isSysConfig.DSMauPhieuIn_ThaoTac();
            chlDanhSachPhieuKetQua.ValueMember = "IDMauKetQua";
            chlDanhSachPhieuKetQua.DisplayMember = "Mota";
        }
        public void Load_DSNhomIn(string[] arrList)
        {
            chlViewWithCategory.DataSource = _isSysConfig.GetTestGroup(Utilities.ArrayToSqlValue(arrList));
            chlViewWithCategory.ValueMember = "MaNhomCLS";
            chlViewWithCategory.DisplayMember = "TenNhomCLS";
        }
        private void Load_DSBophan()
        {
            chlBoPhan.DataSource = _isSysConfig.Data_dm_xetnghiem_bophan(Utilities.ArrayToSqlValue(CommonAppVarsAndFunctions.BoPhanClsXetNghiem));
            chlBoPhan.ValueMember = "MaBoPhan";
            chlBoPhan.DisplayMember = "TenBoPhan";
        }
        private bool Calculate(DataTable dataKetQua)
        {
            if (dataKetQua == null) return false;
            if (dataKetQua.Rows.Count <= 0 || _dtCalculateConfig.Rows.Count < 0) return false;
            var tuoi = NumberConverter.ToInt(dataKetQua.Rows[0]["SoTuoi"].ToString());
            var gioiTinh = dataKetQua.Rows[0]["GTinh"].ToString();
            var masinhly = dataKetQua.Rows[0]["MaSinhLy"].ToString();
            var dataCalConfig = WorkingServices.SearchResult_OnDatatable(_dtCalculateConfig, string.Format("{0} = '{1}' or {0} = '{2}'"
                , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Cachtinhtoan), CommonConfigConstant.TinhToanKetQua, CommonConfigConstant.TinhToanKetQuaSoSanh));
            if (dataCalConfig.Rows.Count <= 0) return false;
            return _iResultConvert.CalculateResult_XetNghiem(dataKetQua, dataCalConfig, gioiTinh, masinhly, tuoi.ToString(), CommonAppVarsAndFunctions.UserID);
        }
        private string Get_PrintTest()
        {
            var result = string.Empty;
            if (gvKetQua.RowCount == 0) return result;
            foreach (var i in gvKetQua.GetSelectedRows())
            {
                if (gvKetQua.GetRowCellValue(i, colKetQua_MaXN) == null) continue;
                if (string.IsNullOrWhiteSpace(result))
                {
                    result = string.Format("{0}", gvKetQua.GetRowCellValue(i, colKetQua_MaXN).ToString().Trim());
                }
                else
                {
                    result += string.Format(",{0}", gvKetQua.GetRowCellValue(i, colKetQua_MaXN).ToString().Trim());
                }
            }
            return result;
        }
        public void Check_EnableControl()
        {
            //Quyền nhập kết quả
            _allowInsert = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestInsertResult);
            //Quyền sửa kết quả
            _allowEdit = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestEditResult);
            //Quyền sửa kết quả của user khác
            _allowEditResulFromOtherUser = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionEditResultOtherUser);
            //Quyền chọn máy xét nghiệm
            _allowChangeAnalyzer = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionChangeAnalyzer);
            mnuTinhToanKetQua.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestCalculateresult);
            mnuDoiNguoiKyTen.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionChangeUserSigned);
        }
        private void Load_HinhKetQua(string maTiepNhan)
        {
            ucHinhAnh_HuyetDo1.Xoa_BieuDo();
            var data = _xetnghiem.Data_HinhAnh_TuMay(maTiepNhan, string.Empty);
            if (data.Rows.Count > 0)
            {
                var dataDistinct = data.DefaultView.ToTable(true, "IDMay", "MaTiepNhan", "GiaoThucBieuDo");
                foreach (DataRow item in dataDistinct.Rows)
                {
                    var GiaoThucBieuDo = item["GiaoThucBieuDo"].ToString();
                    var idMayXn = item["IDMay"].ToString();
                    if (GiaoThucBieuDo.Equals(AnalyzerChart.Constants.GiaoThucVeHinh.ABX) 
                        || GiaoThucBieuDo.Equals(AnalyzerChart.Constants.GiaoThucVeHinh.ABOTT) 
                        || GiaoThucBieuDo.Equals(AnalyzerChart.Constants.GiaoThucVeHinh.CELLDIFF)
                        || GiaoThucBieuDo.Equals(AnalyzerChart.Constants.GiaoThucVeHinh.ELITE580)
                        || GiaoThucBieuDo.Equals(AnalyzerChart.Constants.GiaoThucVeHinh.NCC51))
                    {
                        ucHinhAnh_HuyetDo1.VeBieuDo(maTiepNhan, idMayXn, GiaoThucBieuDo);
                    }
                }
                pnTongPhanTichTeBaoMau.Visible = true;
            }
            else
            {
                pnTongPhanTichTeBaoMau.Visible = false;
            }
            Check_ShowHideSubInfo();
        }
        private void btnSaveComment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CurrentMaTiepNhan)) return;
            if (gvBoPhan.GetFocusedRowCellValue(colBoPhan_MaBoPhan) != null)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Lưu ghi chú?"))
                {
                    _xetnghiem.CapNhat_GhoChu_XNTheoBoPhan(CurrentMaTiepNhan, gvBoPhan.GetFocusedRowCellValue(colBoPhan_MaBoPhan).ToString()
                        , txtGhiChu.Text, CommonAppVarsAndFunctions.UserID);
                    gvBoPhan.SetRowCellValue(gvBoPhan.FocusedRowHandle, colBoPhan_GhiChu, txtGhiChu.Text);
                }
            }
        }
        private void gvKetQua_KeyDown(object sender, KeyEventArgs e)
        {

        }
        FontStyle fsForResult = new FontStyle();
        private void gvKetQua_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            var view = sender as GridView;
            if (e.RowHandle < 0) return;
            e.Appearance.Font = new Font("Arial", 9, FontStyle.Regular);
            if (view.GetRowCellValue(e.RowHandle, colKetQua_MaXN) != null)
            {   var flagCanhBao = int.Parse((view.GetRowCellValue(e.RowHandle, colKetQua_CoCanhBao) ?? "0").ToString());

                if (!string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauCanhBaoKetQua))
                {               
                    if (flagCanhBao > 1 && CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemKieuCanhBaoKQ == 1)
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauCanhBaoKetQua);
                    }
                }
                if (e.Column == colKetQua_TenXN)
                {
                    var rVal = view.GetRowCellValue(e.RowHandle, colKetQua_XNChinh);
                    var value = bool.Parse(rVal == null ? "false" : rVal.ToString());
                    if (value)
                    {
                        e.Appearance.Font = new Font("Arial", 9, FontStyle.Bold);
                    }
                    //1: Bình thường; 2: Dưới ngưỡng dưới ; 3: Ngưỡng trên
                    var mauDuoiNguong = view.GetRowCellValue(e.RowHandle, colKetQua_XN_MauTenBatThuongDuoi).ToString();
                    var mauTrenNguong = view.GetRowCellValue(e.RowHandle, colKetQua_XN_MauTenBatThuongTren).ToString();
                    var flag = (int)view.GetRowCellValue(e.RowHandle, colKetQua_Flat);
                    if (flag == 2 && WorkingServices.IsNumeric(mauDuoiNguong))
                        e.Appearance.ForeColor = Color.FromArgb(int.Parse(mauDuoiNguong));
                    else if (flag == 3 && WorkingServices.IsNumeric(mauTrenNguong))
                        e.Appearance.ForeColor = Color.FromArgb(int.Parse(mauTrenNguong));
                    if (!string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauCanhBaoKetQua))
                    {
                        if (flagCanhBao > 1 && CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemKieuCanhBaoKQ == 2)
                        {
                            e.Appearance.BackColor = ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauCanhBaoKetQua);
                        }
                    }
                }
                else if (e.Column == colKetQua_KetQua)
                {
                    if (view.GetRowCellValue(e.RowHandle, colKetQua_Flat) == null) return;
                    var flag = (int)view.GetRowCellValue(e.RowHandle, colKetQua_Flat);

                    var color = LabResultService.MauKQ(flag, ref fsForResult);
                    var font = new Font(e.Appearance.Font.Name, 9, fsForResult);
                    e.Appearance.Font = font;
                    e.Appearance.ForeColor = color;
                    e.Appearance.TextOptions.HAlignment = GetHorzAlignmentChoKetQua(view.GetRowCellValue(e.RowHandle, colKetQua_KetQua).ToString());
                    if (flagCanhBao > 1 && CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemKieuCanhBaoKQ == 3)
                    {
                        if (!string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauCanhBaoKetQua))
                        {
                            e.Appearance.BackColor = ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauCanhBaoKetQua);
                        }
                    }
                    else if ((bool)view.GetRowCellValue(e.RowHandle, colKetQua_DaXacNhan))
                    {
                        e.Appearance.BackColor = Color.LightGray;
                    }
                }
                else if (e.Column == colKetQua_TienSu
                         && view.GetRowCellValue(e.RowHandle, colKetQua_FlatTienSu) != null
                         && view.GetRowCellValue(e.RowHandle, colKetQua_TienSu) != null)
                {
                    if (!string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, colKetQua_TienSu).ToString()))
                    {
                        var fval = view.GetRowCellValue(e.RowHandle, colKetQua_FlatTienSu).ToString();
                        var flag = int.Parse(string.IsNullOrEmpty(fval) ? "0" : fval);
                        var color = LabResultService.MauKQ(flag, ref fsForResult);
                        var font = new Font(e.Appearance.Font.Name, 9, fsForResult);
                        e.Appearance.Font = font;
                        e.Appearance.ForeColor = color;
                        e.Appearance.TextOptions.HAlignment = GetHorzAlignmentChoKetQua(view.GetRowCellValue(e.RowHandle, colKetQua_TienSu).ToString());
                        e.Appearance.BackColor = Color.LightGray;
                    }
                }
                else if (e.Column == colKetQua_CSBT)
                {
                    if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCanhBaoNullCSBT)
                    {
                        //Cảnh báo null chỉ số bình thường
                        if (view.GetRowCellValue(e.RowHandle, colKetQua_CSBT) == null) return;
                        var rVal = view.GetRowCellValue(e.RowHandle, colKetQua_XNChinh);
                        var isNormalTest = bool.Parse(rVal == null ? "false" : rVal.ToString());
                        if (!isNormalTest)
                        {
                            //Chỉ alarm các xn thường
                            if (string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, colKetQua_CSBT).ToString()))
                            {
                                e.Appearance.BackColor = Color.Red;
                            }
                        }
                    }
                }
            }
        }
        private HorzAlignment GetHorzAlignmentChoKetQua(string ketQua)
        {
            if (string.IsNullOrEmpty(ketQua))
                return HorzAlignment.Center;
            else
            {
                if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCanhLeKetQuaTrenLuoi == 3 || CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCanhLeKetQuaTrenLuoi == 4)
                {
                    if (WorkingServices.IsNumeric(ketQua.Trim().Replace("\\r", "").Replace("\\n", "")))
                    {
                        return (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCanhLeKetQuaTrenLuoi == 3 ? HorzAlignment.Far : HorzAlignment.Near);
                    }
                    else
                    {
                        return (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCanhLeKetQuaTrenLuoi == 3 ? HorzAlignment.Near : HorzAlignment.Far);
                    }
                }
                else if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCanhLeKetQuaTrenLuoi == 1)
                {
                    return HorzAlignment.Center; //giữa
                }
                else if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCanhLeKetQuaTrenLuoi == 2)
                {
                    return HorzAlignment.Far; //bên phải
                }
                else
                {
                    return HorzAlignment.Near;
                }
            }
        }
        private void gvKetQua_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gvKetQua.RowCount == 0)
            {
                _currentValue = string.Empty;
                return;
            }
            if (e.Column.Name.Equals(colKetQua_KetQua.Name, StringComparison.OrdinalIgnoreCase))
            {
                _currentValue = gvKetQua.GetRowCellValue(e.RowHandle, colKetQua_KetQua).ToString().Trim();
            }
            else if (e.Column.Name.Equals(colKetQua_GhiChu.Name, StringComparison.OrdinalIgnoreCase))
            {
                _currentValue = gvKetQua.GetRowCellValue(e.RowHandle, colKetQua_GhiChu).ToString().Trim();
            }
        }
        bool actionResultValueChange = false;
        private void gvKetQua_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colKetQua_KetQua)
            {
                if (!actionResultValueChange)
                {
                    actionResultValueChange = true;
                    var newValue = (e.Value ?? string.Empty);
                    if (!newValue.Equals(_currentValue))
                    {
                        if (e.RowHandle > -1)
                        {
                            var nguoiNhapKQ = gvKetQua.GetRowCellValue(e.RowHandle, colKetQua_maythuchien) != null
                           ? gvKetQua.GetRowCellValue(e.RowHandle, colKetQua_maythuchien).ToString().Trim()
                           : string.Empty;
                            if (XacNhanSuaKetQua && !string.IsNullOrEmpty(nguoiNhapKQ))
                            {
                                var f = new FrmXacNhanCapNhatKetQua();
                                f.KetQuaCu = _currentValue;
                                f.KetQuaMoi = e.Value.ToString();
                                f.ShowDialog();
                                if (f.DialogResult == DialogResult.OK)
                                {
                                    UpdateResult(e.RowHandle, CurrentMaTiepNhan, false);
                                    _currentValue = e.Value.ToString();
                                }
                                else
                                {
                                    gvKetQua.SetRowCellValue(e.RowHandle, colKetQua_KetQua, _currentValue);
                                }
                            }
                            else
                            {
                                UpdateResult(e.RowHandle, CurrentMaTiepNhan, false);
                                _currentValue = e.Value.ToString();
                            }
                        }
                    }
                    actionResultValueChange = false;
                }
            }
            else if (e.Column == colKetQua_IDMayXetNghiem)
            {
                var newValue = (e.Value ?? string.Empty);
                if (!newValue.Equals(_currentValue))
                {
                    UpdateIDAnalyzerResult(e.RowHandle, CurrentMaTiepNhan);
                }
            }
            else if (e.Column == colKetQua_Download)
            {
                var newValue = (bool?)e.Value ?? false;

                var maXn = gvKetQua.GetRowCellValue(e.RowHandle, colKetQua_MaXN) != null ? gvKetQua.GetRowCellValue(e.RowHandle, colKetQua_MaXN).ToString().Trim() : "";

                _xetnghiem.UpdateDownload(CurrentMaTiepNhan, maXn, newValue);
            }
            else if (e.Column == colKetQua_GhiChu)
            {
                var newValue = (e.Value ?? string.Empty);

                var maXn = gvKetQua.GetRowCellValue(e.RowHandle, colKetQua_MaXN) != null ? gvKetQua.GetRowCellValue(e.RowHandle, colKetQua_MaXN).ToString().Trim() : "";
                if (!newValue.Equals(_currentValue))
                {
                    _xetnghiem.CapNhat_GhiChuKQ_XN(CurrentMaTiepNhan, maXn, newValue.ToString(), CommonAppVarsAndFunctions.UserID, CommonAppVarsAndFunctions.UserID);
                }
            }
        }
        private void gvKetQua_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
        }
        private void gcKetQua_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var currentRow = ((ColumnView)gcKetQua.FocusedView).FocusedRowHandle;
            if (currentRow < 0)
            {
                currentRow = gvKetQua.GetChildRowHandle(currentRow, 0);
                gvKetQua.FocusedRowHandle = currentRow;
                gvKetQua.FocusedColumn = gvKetQua.Columns[colKetQua_KetQua.FieldName];
            }
            else
                ((ColumnView)gcKetQua.FocusedView).FocusedRowHandle++;
            if (currentRow < ((ColumnView)gcKetQua.FocusedView).FocusedRowHandle)
                ((ColumnView)gcKetQua.FocusedView).ShowEditor(); e.Handled = true;
        }
        private void gvKetQua_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var rowHandle = ((ColumnView)gcKetQua.FocusedView).FocusedRowHandle;
            var colhandle = ((ColumnView)gcKetQua.FocusedView).FocusedColumn;
            if (colhandle.Name != colKetQua_KetQua.Name && colhandle.Name != colKetQua_IDMayXetNghiem.Name && colhandle.Name != colKetQua_GhiChu.Name) return;

            var daXacNhan = (bool)gvKetQua.GetRowCellValue(rowHandle, colKetQua_DaXacNhan);
            var userNhap = gvKetQua.GetRowCellValue(rowHandle, colKetQua_maythuchien).ToString();
            if (colhandle.Name == colKetQua_IDMayXetNghiem.Name)
            {
                e.Cancel = true;
                ucSearchLookupEditor_MayXN1.Enabled = true;
                if (!_allowChangeAnalyzer)
                {
                    ucSearchLookupEditor_MayXN1.Enabled = false;
                }
                else
                {
                    if (!_AllowEditCurrentRow(userNhap, daXacNhan))
                    {
                        ucSearchLookupEditor_MayXN1.Enabled = false;
                    }
                }
            }
            else
            {
                ucSearchLookupEditor_MayXN1.Enabled = true;
                if (!_AllowEditCurrentRow(userNhap, daXacNhan))
                {
                    e.Cancel = true;
                    ucSearchLookupEditor_MayXN1.Enabled = false;
                }
            }
        }
        private void gvKetQua_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Name.Equals(colKetQua_No.Name))
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }

        }
        private void chkXemXetTheoMauIn_CheckedChanged(object sender, EventArgs e)
        {
            Load_ChiTietXN(CurrentMaTiepNhan, DataPatient);
        }
        private void chlDanhSachPhieuKetQua_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_ChiTietXN(CurrentMaTiepNhan, DataPatient);
        }
        private void lblNhomVaInTuDong_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnResult_SubInformation.Width = 265;
        }
        private void btnCloseSubInformation_Click(object sender, EventArgs e)
        {
            pnResult_SubInformation.Width = 0;
        }
        private void chkViewWithCategory_CheckedChanged(object sender, EventArgs e)
        {
            Load_ChiTietXN(CurrentMaTiepNhan, DataPatient);
        }
        private void chlViewWithCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_ChiTietXN(CurrentMaTiepNhan, DataPatient);
        }
        private void mnuDoiMauDanhGiaDen_Click(object sender, EventArgs e)
        {
            if (gvKetQua.SelectedRowsCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Đổi trạng thái đánh giá các xét nghiệm đang chọn thành [Bình thường]?"))
                {
                    foreach (int i in gvKetQua.GetSelectedRows())
                    {
                        if (gvKetQua.GetRowCellValue(i, colKetQua_MaXN) != null)
                        {
                            var maXn = gvKetQua.GetRowCellValue(i, colKetQua_MaXN);
                            _xetnghiem.CapNhat_Co_Ketqua(CurrentMaTiepNhan, maXn.ToString(), "1", CommonAppVarsAndFunctions.UserID);
                            gvKetQua.SetRowCellValue(i, colKetQua_Flat, 1);
                        }
                    }
                    Load_ChiTietXN(CurrentMaTiepNhan, DataPatient);
                }
            }
        }
        private void mnuDoiMauDanhGiaDo_Click(object sender, EventArgs e)
        {
            if (gvKetQua.SelectedRowsCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Đổi trạng thái đánh giá các xét nghiệm đang chọn thành [Vượt ngưỡng trên]?"))
                {
                    foreach (int i in gvKetQua.GetSelectedRows())
                    {

                        if (gvKetQua.GetRowCellValue(i, colKetQua_MaXN) != null)
                        {
                            var maXn = gvKetQua.GetRowCellValue(i, colKetQua_MaXN);
                            _xetnghiem.CapNhat_Co_Ketqua(CurrentMaTiepNhan, maXn.ToString(), "3", CommonAppVarsAndFunctions.UserID);
                            gvKetQua.SetRowCellValue(i, colKetQua_Flat, 3);
                        }
                    }
                    Load_ChiTietXN(CurrentMaTiepNhan, DataPatient);
                }
            }
        }
        private void mnuDoiMauDanhGiaXanh_Click(object sender, EventArgs e)
        {
            if (gvKetQua.SelectedRowsCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Đổi trạng thái đánh giá các xét nghiệm đang chọn thành [Thấp hơn ngưỡng dưới]?"))
                {
                    foreach (int i in gvKetQua.GetSelectedRows())
                    {

                        if (gvKetQua.GetRowCellValue(i, colKetQua_MaXN) != null)
                        {
                            var maXn = gvKetQua.GetRowCellValue(i, colKetQua_MaXN);
                            _xetnghiem.CapNhat_Co_Ketqua(CurrentMaTiepNhan, maXn.ToString(), "2", CommonAppVarsAndFunctions.UserID);
                            gvKetQua.SetRowCellValue(i, colKetQua_Flat, 2);
                        }
                    }
                    Load_ChiTietXN(CurrentMaTiepNhan, DataPatient);
                }
            }
        }
        private void Check_AddEventValueChange()
        {
            gvKetQua.CellValueChanged -= gvKetQua_CellValueChanged;
            gvKetQua.CellValueChanged += gvKetQua_CellValueChanged;
        }
        private void mnuXoaKetQua_Click(object sender, EventArgs e)
        {
            if (gvKetQua.SelectedRowsCount > 0)
            {
                gvKetQua.CellValueChanged -= gvKetQua_CellValueChanged;
                try
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa các kết quả được chọn?"))
                    {
                        CustomMessageBox.ShowAlert("Đang thực hiện xóa kết quả được chọn!");
                        var notdeleteList = string.Empty;
                        var lstDSMaXN = new List<string>();

                        foreach (int i in gvKetQua.GetSelectedRows())
                        {
                            _countToFocus = 0;
                            if (gvKetQua.GetRowCellValue(i, colKetQua_DaXacNhan) != null)
                            {
                                var userNhap = gvKetQua.GetRowCellValue(i, colKetQua_maythuchien).ToString();
                                if ((bool)gvKetQua.GetRowCellValue(i, colKetQua_DaXacNhan))
                                {
                                    notdeleteList += (string.IsNullOrEmpty(notdeleteList) ? "" : "|") + gvKetQua.GetRowCellValue(i, colKetQua_TenXN).ToString();
                                }
                                else
                                {
                                    CustomMessageBox.ShowAlert(string.Format("Đang thực hiện xóa kết quả của:\n{0}", gvKetQua.GetRowCellValue(i, colKetQua_TenXN).ToString()));

                                    if (!string.IsNullOrEmpty(gvKetQua.GetRowCellValue(i, colKetQua_KetQua) != null ? gvKetQua.GetRowCellValue(i, colKetQua_KetQua).ToString() : string.Empty))
                                    {
                                        lstDSMaXN.Add(gvKetQua.GetRowCellValue(i, colKetQua_MaXN).ToString());
                                      
                                        gvKetQua.SetRowCellValue(i, colKetQua_KetQua, DBNull.Value);
                                        UpdateResult(i, CurrentMaTiepNhan, true);
                                    }
                                    if ((gvKetQua.GetRowCellValue(i, colKetQua_IDMayXetNghiem) != null ? gvKetQua.GetRowCellValue(i, colKetQua_IDMayXetNghiem).ToString() : "0") != "0")
                                    {
                                        gvKetQua.SetRowCellValue(i, colKetQua_IDMayXetNghiem, 0);
                                        UpdateIDAnalyzerResult(i, CurrentMaTiepNhan);
                                    }
                                }
                            }
                        }
                        _xetnghiem.CapNhat_DuKQ_XN(CurrentMaTiepNhan);
                        _xetnghiem.CapNhat_ThongTinMayXn_XnChinh(CurrentMaTiepNhan);
                        Check_AddEventValueChange();
                        if(lstDSMaXN.Count >0 && CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemReDownloadKhiXoaHangLoat)
                        {
                            CustomMessageBox.ShowAlert("Đang thực hiện bật trạng thái cho phép download.");
                            _iAnalyzerResult.UpdateDownloadStatus(false, CurrentMaTiepNhan, lstDSMaXN, CommonAppVarsAndFunctions.UserID, true, true);
                        }
                        if (!string.IsNullOrEmpty(notdeleteList))
                        {
                            CustomMessageBox.MSG_Waring_OK(string.Format("Không thể xóa các xét nghiệm đã xác nhận!\n{0}", notdeleteList));
                        }
                        Load_ChiTietXN(CurrentMaTiepNhan, DataPatient);
                    }
                    else
                        Check_AddEventValueChange();
                }
                catch (Exception ex)
                {
                    CustomMessageBox.CloseAlert();
                    Check_AddEventValueChange();
                }
                CustomMessageBox.CloseAlert();
            }
        }
        private void chkXemtheoBoPhan_CheckedChanged(object sender, EventArgs e)
        {
            Load_ChiTietXN(CurrentMaTiepNhan, DataPatient);
        }
        private void chlBoPhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_ChiTietXN(CurrentMaTiepNhan, DataPatient);
        }
        private void gvKetQua_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (gvKetQua.GetRowCellValue(gvKetQua.FocusedRowHandle, colKetQua_MaXN) == null) return;
            var isXnChinh = bool.Parse(gvKetQua.GetRowCellValue(gvKetQua.FocusedRowHandle, colKetQua_XNChinh).ToString());
            var profileId = gvKetQua.GetRowCellValue(gvKetQua.FocusedRowHandle, colKetQua_ProfileID).ToString();
            var idChiDinhHis = gvKetQua.GetRowCellValue(gvKetQua.FocusedRowHandle, colKetQua_IdChiDinhHis).ToString();
            var isSelect = gvKetQua.IsRowSelected(gvKetQua.FocusedRowHandle);
            var maXnhis = gvKetQua.GetRowCellValue(gvKetQua.FocusedRowHandle, colKetQua_maxn_his).ToString();
            if (!isXnChinh) return;
            for (var i = 0; i < gvKetQua.RowCount; i++)
            {
                if (gvKetQua.GetRowCellValue(i, colKetQua_MaXN) == null) continue;
                var profileIdItem = gvKetQua.GetRowCellValue(i, colKetQua_ProfileID).ToString();
                var idChiDinhHisIten = gvKetQua.GetRowCellValue(i, colKetQua_IdChiDinhHis).ToString();
                var maCaptren = gvKetQua.GetRowCellValue(i, colKetQua_MaCapTren).ToString();
                if ((!profileId.Equals(profileIdItem, StringComparison.OrdinalIgnoreCase) ||
                     (string.IsNullOrEmpty(profileId))) &&
                    (!idChiDinhHis.Equals(idChiDinhHisIten, StringComparison.OrdinalIgnoreCase) ||
                     (string.IsNullOrEmpty(idChiDinhHis))) &&
                    (!maXnhis.Equals(maCaptren, StringComparison.OrdinalIgnoreCase) ||
                     string.IsNullOrEmpty(maXnhis))) continue;
                if (isSelect)
                    gvKetQua.SelectRow(i);
                else
                    gvKetQua.UnselectRow(i);
            }
        }
        private void repositoryItemMemoEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is MemoEdit)
            {
                var obj = (MemoEdit)sender;
                if (e.Alt && e.KeyCode == Keys.Enter)
                {
                    obj.EditValue += Environment.NewLine;
                    obj.SelectionStart = obj.Text.Length;
                    obj.Height = CalRowHeight(obj.EditValue.ToString());
                    e.Handled = true;
                }
            }
        }
        private void gcKetQua_EditorKeyPress(object sender, KeyPressEventArgs e)
        {
            GridControl grid = sender as GridControl;
            gvKetQua_KeyPress(grid.FocusedView, e);

        }
        private void gvKetQua_KeyPress(object sender, KeyPressEventArgs e)
        {
            _countToFocus = 0;
        }
        private void gvKetQua_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            _countToFocus = 0;
            ShowLookup_MayXN();
            Get_ThongTinDongDangChon();
            DataGridview_KetQua_FocusColumnChanged?.Invoke(sender, e);
        }
        private void gvKetQua_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            _countToFocus = 0;
            if (gvKetQua.GetFocusedRowCellValue(colKetQua_CoHinhAnh) != null)
            {
                var show = bool.Parse(gvKetQua.GetFocusedRowCellValue(colKetQua_CoHinhAnh).ToString());
                pnHinhKetQua.Visible = show;
                if (show)
                {
                    var maxn = gvKetQua.GetFocusedRowCellValue(colKetQua_MaXN).ToString();
                    var maTiepNhan = gvKetQua.GetFocusedRowCellValue(colKetQua_MaTiepNhan).ToString();
                    var objHinh = _xetnghiem.Get_Info_ketqua_cls_xetnghiem_spht(maTiepNhan, maxn);
                    if (objHinh != null)
                        pbKetQuaHinh.Image = objHinh.Hinhanh1;
                }
                else
                {
                    pbKetQuaHinh.Image = null;
                }
                btnPasteImage.Enabled = btnAddHinh.Enabled = btnReMoveHinh.Enabled = btnSaveHinh.Enabled = !bool.Parse(gvKetQua.GetFocusedRowCellValue(colKetQua_DaXacNhan).ToString());
            }
            else
            {
                pbKetQuaHinh.Image = null;
                pnHinhKetQua.Visible = false;
            }
            Check_ShowHideSubInfo();
            ShowLookup_MayXN();
            Get_ThongTinDongDangChon();
            DataGridview_KetQua_FocusColumnChanged?.Invoke(sender, e);
        }
        private void Check_ShowHideSubInfo()
        {
            if (pnTongPhanTichTeBaoMau.Visible == false && pnHinhKetQua.Visible == false)
                pnResult_SubInformation.Width = 0;
            else
                pnResult_SubInformation.Width = 285;
        }
        private void ShowLookup_MayXN()
        {
            ucSearchLookupEditor_MayXN1.Visible = false;
            if (gvKetQua.FocusedColumn == colKetQua_IDMayXetNghiem)
            {
                GridViewInfo vInfo = gvKetQua.GetViewInfo() as GridViewInfo;
                var grInfo = vInfo.GetGridCellInfo(gvKetQua.FocusedRowHandle, colKetQua_IDMayXetNghiem);
                if (grInfo != null)
                {
                    var daXacNhan = (bool)gvKetQua.GetRowCellValue(gvKetQua.FocusedRowHandle, colKetQua_DaXacNhan);
                    var userNhap = gvKetQua.GetRowCellValue(gvKetQua.FocusedRowHandle, colKetQua_maythuchien).ToString();
                    if (_allowChangeAnalyzer && _AllowEditCurrentRow(userNhap, daXacNhan))
                    {
                        ucSearchLookupEditor_MayXN1.EditValueChange -= UcSearchLookupEditor_MayXN1_EditValueChange;
                        var giatri = gvKetQua.GetRowCellValue(gvKetQua.FocusedRowHandle, colKetQua_IDMayXetNghiem).ToString();
                        ucSearchLookupEditor_MayXN1.SelectedValue = giatri;
                        if (ucSearchLookupEditor_MayXN1.SelectedValue != null || string.IsNullOrEmpty(giatri))
                        {
                            ucSearchLookupEditor_MayXN1.ControlNext = gcKetQua;
                            ucSearchLookupEditor_MayXN1.CatchEnterKey = true;
                            ucSearchLookupEditor_MayXN1.Size = new Size(grInfo.Bounds.Size.Width, grInfo.Bounds.Size.Height < 23 ? 23 : grInfo.Bounds.Size.Height);
                            ucSearchLookupEditor_MayXN1.Location = grInfo.Bounds.Location;
                            ucSearchLookupEditor_MayXN1.Enabled = true;
                            ucSearchLookupEditor_MayXN1.Visible = true;
                            ucSearchLookupEditor_MayXN1.EditValueChange += UcSearchLookupEditor_MayXN1_EditValueChange; 
                        }
                    }
                }
            }
        }

        private void UcSearchLookupEditor_MayXN1_EditValueChange(object sender, EventArgs e)
        {
            if (gvKetQua.FocusedRowHandle > -1 && gvKetQua.FocusedColumn == colKetQua_IDMayXetNghiem)
            {
                var focusIndex = gvKetQua.FocusedRowHandle;
                gvKetQua.SetRowCellValue(focusIndex, colKetQua_IDMayXetNghiem, ucSearchLookupEditor_MayXN1.SelectedValue ?? 0);
                gvKetQua.FocusedRowHandle = focusIndex;
                gvKetQua.FocusedColumn = colKetQua_IDMayXetNghiem;
            }
        }
        private void gvKetQua_MouseWheel(object sender, MouseEventArgs e)
        {
            _countToFocus = 0;
        }
        private void dtgPatient_Scroll(object sender, ScrollEventArgs e)
        {
            _countToFocus = 0;
        }
        private void mnuKetQuaTienSu_Click(object sender, EventArgs e)
        {
            if (gvKetQua.RowCount > 0)
            {
                FrmHoSoBenhAn f = new FrmHoSoBenhAn();
                f.maBienhNhanTim = _maBn;
                f.loaiDvXem = ServiceType.ClsXetNghiem;
                f.ShowDialog();
            }
        }
        private void Check_SetColorSelectedMenu(Panel pnCheck, Panel pnSelected)
        {
            foreach (Control ctr in pnCheck.Controls)
            {
                if (pnSelected != ctr)
                {
                    Check_SetForControlChild(ctr);
                }
            }
            pnSelected.BackColor = Color.MidnightBlue;// Color.FromArgb(247, 148, 30);
            Set_ColorTextinSelectedMenu(pnSelected, true);
        }
        private void Check_SetForControlChild(Control mainCotrol)
        {
            mainCotrol.BackColor = Color.Transparent;
            Set_ColorTextinSelectedMenu(mainCotrol, false);
            if(mainCotrol.Controls.Count >0)
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
                    ((CustomLable)lbl).ForeColor = isSelected ? Color.OrangeRed : SystemColors.WindowText;
                    ((CustomLable)lbl)._oldColor = ((CustomLable)lbl).ForeColor;
                }
            }
        }
        private void gvBoPhan_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gvBoPhan.GetFocusedRowCellValue(colBoPhan_GhiChu) != null)
                txtGhiChu.Text = gvBoPhan.GetFocusedRowCellValue(colBoPhan_GhiChu).ToString();
            else
                txtGhiChu.Text = string.Empty;
        }
        private void btnAddHinh_Click(object sender, EventArgs e)
        {
            if (pbKetQuaHinh.Image != null)
                if (CustomMessageBox.MSG_Question_YesNo_GetNo("Bạn muốn đổi hình khác?"))
                    return;

            var imagSize = new Size(405, 250);
            if (cboImageSize.SelectedIndex > -1)
            {
                var arr = cboImageSize.Text.Split('x');
                if (arr.Length == 2)
                {
                    imagSize = new Size(int.Parse(arr[0]), int.Parse(arr[1]));
                }
            }
            ControlExtension.LoadImage_ToPicturebox(pbKetQuaHinh, imagSize);
            if (pbKetQuaHinh.Image != null)
            {
                LuuHinh();
            }
        }
        private void btnReMoveHinh_Click(object sender, EventArgs e)
        {
            if (pbKetQuaHinh.Image != null)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Bạn muốn xóa hình?"))
                {
                    pbKetQuaHinh.Image = null;
                    LuuHinh();
                }
            }
        }
        private void btnZoom_Click(object sender, EventArgs e)
        {
            if (pbKetQuaHinh.Image != null)
            {
                var f = new FrmZoomImage();
                f.pbImage.Image = pbKetQuaHinh.Image;
                f.ShowDialog();
            }
        }
        private void btnSaveHinh_Click(object sender, EventArgs e)
        {
            LuuHinh();
        }
        private void LuuHinh()
        {
            if (gvKetQua.RowCount > 0)
            {
                if (gvKetQua.GetFocusedRowCellValue(colKetQua_MaXN) != null)
                {
                    var maXN = gvKetQua.GetFocusedRowCellValue(colKetQua_MaXN).ToString();
                    var maTiepNhan = gvKetQua.GetFocusedRowCellValue(colKetQua_MaTiepNhan).ToString();
                    var obj = new KETQUA_CLS_XETNGHIEM_SPHT();
                    obj.Matiepnhan = maTiepNhan;
                    obj.Maxn = maXN;
                    obj.Hinhanh1 = pbKetQuaHinh.Image;
                    obj.Nguoinhap = CommonAppVarsAndFunctions.UserID;
                    obj.Nguoisua = CommonAppVarsAndFunctions.UserID;
                    _xetnghiem.LuuKetQua_SHPT(obj);
                }
            }
        }
        private void mnuTinhToanKetQua_Click(object sender, EventArgs e)
        {
            if (gvKetQua.RowCount <= 0) return;

            if (Calculate((DataTable)gcKetQua.DataSource))
                Load_ChiTietXN(CurrentMaTiepNhan, DataPatient);
        }
        private void btnXacNhanKetQua_Click(object sender, EventArgs e)
        {
            XacNhanKetQua(true);
        }
        private void btnBoXacNhanKetQua_Click(object sender, EventArgs e)
        {
            XacNhanKetQua(false);
        }

        private void btnKQHuyetTuyDo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CurrentMaTiepNhan))
            {
                var frm = new DailyUse.CanLamSang.FrmCLS_KetQua_HuyetTuyDo();
                frm.inputMatiepnhan = CurrentMaTiepNhan;
                frm.ngaytiepnhan = CurrentNgayTiepNhan;
                frm.ShowDialog();
            }
        }
        private void btnPasteImage_Click(object sender, EventArgs e)
        {
            GetImage_FromClipboard(true);
        }
        public bool GetImage_FromClipboard(bool showMess = false)
        {
            if (pnResult_SubInformation.Visible && btnAddHinh.Enabled)
            {
                var obj = Clipboard.GetImage();
                if (obj != null)
                {
                    //return true vì là hình
                    if (pbKetQuaHinh.Image != null)
                        if (CustomMessageBox.MSG_Question_YesNo_GetNo("Bạn muốn đổi hình khác?"))
                            return true;
                    var imagSize = new Size(405, 250);
                    if (cboImageSize.SelectedIndex > -1)
                    {
                        var arr = cboImageSize.Text.Split('x');
                        if (arr.Length == 2)
                        {
                            imagSize = new Size(int.Parse(arr[0]), int.Parse(arr[1]));
                        }
                    }
                    pbKetQuaHinh.Image = GraphicSupport.ResizeImage(Clipboard.GetImage(), imagSize);
                    LuuHinh();
                    return true;
                }
                else if (showMess)
                    CustomMessageBox.MSG_Information_OK("Không có thông tin hình ảnh trong clipboard!");
            }
            return false;
        }
        private void btnHDNhanh_Click(object sender, EventArgs e)
        {
            var f = new DailyUse.CanLamSang.FrmHuongDan_FormKetQuaTQ();
            f.ShowDialog();
        }
        private void lblInTudong_Click(object sender, EventArgs e)
        {
        }



        private void SeTrangThaiInTuDong()
        {
        }

        private void ucInTuDong1_BatTatinTuDongClick(object sender, EventArgs e)
        {
            SeTrangThaiInTuDong();
        }

        private void dtgPatient_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var ex = e.Exception;
            CustomMessageBox.MSG_Error_OK(ex.Message, ex);
        }

        private void gvKetQua_CalcRowHeight(object sender, RowHeightEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.RowHandle >= 0)
            {
                var ketqua = view.GetDataRow(e.RowHandle)[colKetQua_KetQua.FieldName].ToString();
                e.RowHeight = CalRowHeight(ketqua);
            }
        }
       private int CalRowHeight(string ketqua)
        {
            var arr = ketqua.Split(new string[] { "\r\n", "\r" }, StringSplitOptions.None);
            if (arr.Length > 1)
               return  LimitRowHeight * arr.Length;
            else if (ketqua.Trim().Length > 20)
                return LimitRowHeight * ketqua.Trim().Length / 20;
            else
                return LimitRowHeight;
        }
        private void mnuNhatKyXN_Click(object sender, EventArgs e)
        {
            var f = new FrmLogKetQua();
            f.pnMenu.Visible = true;
            f.AdjustForm();
            f.MaTiepNhan = CurrentMaTiepNhan;
            f.FromDate = CurrentNgayTiepNhan;
            if (f.Load_Log() > 0)
            {
                f.ShowDialog();
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Không tim thấy nhật ký chỉnh sửa kết quả.");
                f.Dispose();
            }
        }

        private void btnCapNhatMayXn_Click(object sender, EventArgs e)
        {
            if(gvKetQua.SelectedRowsCount >0)
            {
                var selectedVal = ucSearchLookupEditor_MayXN2.SelectedValue;
                pnChonMayCapNhat.Visible = false;
                bool haveUpdate = false;
                foreach (var item in gvKetQua.GetSelectedRows())
                {
                    _countToFocus = 0;
                    if (gvKetQua.GetRowCellValue(item, colKetQua_MaXN) != null)
                    {
                        var daXacNhan = (bool)gvKetQua.GetRowCellValue(item, colKetQua_DaXacNhan);
                        var userNhap = gvKetQua.GetRowCellValue(item, colKetQua_maythuchien).ToString();
                        if (_allowChangeAnalyzer && _AllowEditCurrentRow(userNhap, daXacNhan))
                        {
                            ucSearchLookupEditor_MayXN1.EditValueChange -= UcSearchLookupEditor_MayXN1_EditValueChange;
                            var giatri = gvKetQua.GetRowCellValue(item, colKetQua_IDMayXetNghiem).ToString();
                            ucSearchLookupEditor_MayXN1.SelectedValue = giatri;
                            if (ucSearchLookupEditor_MayXN1.SelectedValue != null || string.IsNullOrEmpty(giatri))
                            {
                                gvKetQua.CellValueChanged -= gvKetQua_CellValueChanged;
                                gvKetQua.SetRowCellValue(item, colKetQua_IDMayXetNghiem, selectedVal ?? 0);
                                UpdateIDAnalyzerResult(item, CurrentMaTiepNhan);
                                haveUpdate = true;
                            }
                        }
                    }
                }
                if(haveUpdate)
                {
                    Load_ChiTietXN(CurrentMaTiepNhan, DataPatient);
                }
                Check_AddEventValueChange();
            }
        }

        private void mnXoaXetNghiem_Click(object sender, EventArgs e)
        {

        }

        private void mnuCapNhatMayXN_Click(object sender, EventArgs e)
        {
            pnChonMayCapNhat.Visible = true;
            ucSearchLookupEditor_MayXN2.SelectedValue = null;
            ucSearchLookupEditor_MayXN2.Focus();
        }

        private void btnHuyCapNhat_Click(object sender, EventArgs e)
        {
            pnChonMayCapNhat.Visible = false;
        }

        private void gvNhomCLS_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            var view = sender as GridView;
            if (e.RowHandle < 0) return;
            if (e.Column == colNhom_TenNhom)
            {
                var daIn = bool.Parse(view.GetRowCellValue(e.RowHandle, colNhom_DaInKQ).ToString());
                var daDuyet = bool.Parse(view.GetRowCellValue(e.RowHandle, colNhom_DaXacNhanKQ).ToString());
                var daCoKQ = bool.Parse(view.GetRowCellValue(e.RowHandle, colNhom_DaCoKetQua).ToString());
                var daDuKQ = bool.Parse(view.GetRowCellValue(e.RowHandle, colNhom_DuKetQua).ToString());
                e.Appearance.BackColor = ColorForGroup(daDuKQ, daDuyet, daCoKQ, daIn);
            }
        }
        public void CapNhatNguoiThucHien(string nguoithucHien, string ngayThucHien)
        {
            if (gvKetQua.SelectedRowsCount > 0)
            {
                foreach (int i in gvKetQua.GetSelectedRows())
                {
                    if (gvKetQua.GetRowCellValue(i, colKetQua_MaXN) != null)
                    {
                        string maTiepNhan = gvKetQua.GetRowCellValue(i, colKetQua_MaTiepNhan).ToString();
                        string maXn = gvKetQua.GetRowCellValue(i, colKetQua_MaXN).ToString();
                        _xetnghiem.UpdateNguoiDoiChieu(maTiepNhan, maXn, nguoithucHien, ngayThucHien);
                    }
                }
            }
        }
        public void CapNhatMoTa(string danhgia, string denghi)
        {
            if (gvKetQua.GetFocusedRowCellValue(colKetQua_MaTiepNhan) != null)
            {
                string maTiepNhan = gvKetQua.GetFocusedRowCellValue(colKetQua_MaTiepNhan).ToString();
                string maXn = gvKetQua.GetFocusedRowCellValue(colKetQua_MaXN).ToString();
                _xetnghiem.UpdateDienGiai_DeNghi_XN(maTiepNhan, maXn, danhgia, denghi);
                gvKetQua.SetRowCellValue(gvKetQua.FocusedRowHandle, colKetQua_TenSHPT, denghi);
                gvKetQua.SetRowCellValue(gvKetQua.FocusedRowHandle, colKetQua_KQDinhTinh, danhgia);
                CustomMessageBox.MSG_Information_OK("Cập nhật thành công!");
            }
        }
        private readonly IConnectHISService _iHISData = new ConnectHISService();
        private void mnuUploadKetQuaVeHIS_Click(object sender, EventArgs e)
        {
            if (gvKetQua.RowCount > 0)
            {
                var bnInfo = _iHISData.GetDataUploadToHIS(new Lab.Middleware.LISConnect.Models.GetUploadCondit
                {
                    userID = CommonAppVarsAndFunctions.UserID,
                    matiepnhan = CurrentMaTiepNhan,
                    onlyValid = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemUploadDaDuyet,
                    onlyPrinted = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemUploadDaIn,
                    arrCatePrint = null,
                    arrtestCodePrint = null,
                    arrTestTypeID = new string[] { },
                    frombackup = false,
                    manualUpload = true,
                    forStatus = false
                });
                if (bnInfo != null)
                    if (bnInfo.Hisproviderid > 0)
                        Task.Factory.StartNew(delegate { TransferHisResult(bnInfo); });
            }
        }
        private void TransferHisResult(BenhNhanInfoForHIS info)
        {
            try
            {

                var hisReturn = (HisProvider)Enum.Parse(typeof(HisProvider), info.Hisproviderid.ToString());
                var hisInfo = CommonAppVarsAndFunctions.HisConnectList.Where(x => x.HisID.Equals(hisReturn)).FirstOrDefault();
                // hisInfo.JSonResultArray = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemUploadJSonArray;
                LogService.RecordLogFile("HISUploader", string.Format("HISProvider: {0}-{1}\nMã tiếp nhận: {2}"
                    , hisReturn, hisReturn.ToString(), info.Matiepnhan), "Auto upload to HIS: Transfer");
                _iHISData.LISTransferResult(hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, info);
                //_iHISData.UploadFileToHis(hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, info);

            }
            catch (Exception ex)
            {
                LogService.RecordLogError(CommonAppVarsAndFunctions.UserID, "HISUploader", ex, 0, ex.Message, "Manual upload to HIS: Transfer");
            }
        }

        private void gvKetQua_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            var view = sender as GridView;
            if (e.Column == colKetQua_TrangThai && view.GetRowCellValue(e.ListSourceRowIndex, view.Columns[colKetQua_CoCanhBao.FieldName]) != null)
            {
                var flagCanhBao = (int)view.GetRowCellValue(e.ListSourceRowIndex, view.Columns[colKetQua_CoCanhBao.FieldName]);
                var flag = (int)view.GetRowCellValue(e.ListSourceRowIndex, view.Columns[colKetQua_Flat.FieldName]);
                var ketqua = (view.GetRowCellValue(e.ListSourceRowIndex, view.Columns[colKetQua_KetQua.FieldName]) == DBNull.Value ? string.Empty : view.GetRowCellValue(e.ListSourceRowIndex, view.Columns[colKetQua_KetQua.FieldName]).ToString());
                var daxacnhan = (bool)view.GetRowCellValue(e.ListSourceRowIndex, view.Columns[colKetQua_DaXacNhan.FieldName]);
                var daIn = (bool)view.GetRowCellValue(e.ListSourceRowIndex, view.Columns[colKetQua_DaInKQXN.FieldName]);
                var dadownload = (bool)view.GetRowCellValue(e.ListSourceRowIndex, view.Columns[colKetQua_Download.FieldName]);
                var xnChinh = ((bool)view.GetRowCellValue(e.ListSourceRowIndex, view.Columns[colKetQua_XNChinh.FieldName]) || (bool)view.GetRowCellValue(e.ListSourceRowIndex, view.Columns[colKetQua_KhongDanhGia.FieldName]));
                var QCFail = (bool)view.GetRowCellValue(e.ListSourceRowIndex, view.Columns[colKetQua_QCOut.FieldName]);
                if (QCFail)
                {
                    e.Value = imgTrangThaiXn.Images[5];
                }
                else if (flagCanhBao > 1)
                {
                    e.Value = pictureBox1.Image;
                }
                else if (flag > 1)
                {
                    e.Value = imgTrangThaiXn.Images[1];
                }
                else if ((!string.IsNullOrEmpty(ketqua) || xnChinh) && (daxacnhan || daIn))
                {
                    e.Value = imgTrangThaiXn.Images[3];
                }
                else if ((!string.IsNullOrEmpty(ketqua) || xnChinh) && !daxacnhan && !daIn)
                {
                    e.Value = imgTrangThaiXn.Images[4];
                }
                else if (dadownload)
                {
                    e.Value = pictureBox2.Image;
                }
                else
                    e.Value = imgTrangThaiXn.Images[2];
            }
        }
        private List<string> DsXnDuoChon()
        {
            var lst = new List<string>();
            if (gvKetQua.SelectedRowsCount > 0)
            {
                foreach (int i in gvKetQua.GetSelectedRows())
                {
                    if (gvKetQua.GetRowCellValue(i, colKetQua_MaXN) != null)
                    {
                        var maXn = gvKetQua.GetRowCellValue(i, colKetQua_MaXN).ToString().Trim();
                        lst.Add(maXn);
                    }
                }
            }
            return lst;
        }
        private void mnuLichSuIn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CurrentMaTiepNhan))
            {
                var f = new FrmLichSuIn();
                f.MaTiepNhan = CurrentMaTiepNhan;
                f.pnMenu.Visible = true;
                f.AdjustForm();
                f.ShowDialog();
            }
        }

        private void mnuDoiNguoiKyTen_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Thay đổi người ký tên?"))
            {
                var lstXn = DsXnDuoChon();
                var nguoiKy = string.Empty;
                var f = new FrmChonBSKyTen();
                f.ShowDialog();
                nguoiKy = f.NguoiKyTen;
                if(!string.IsNullOrEmpty(nguoiKy))
                {
                    _xetnghiem.CapNhat_BSKyten(CurrentMaTiepNhan, string.Join(",", lstXn), nguoiKy, CommonAppVarsAndFunctions.UserID, Environment.MachineName, true);
                    Load_ChiTietXN(CurrentMaTiepNhan, DataPatient);
                }
            }
        }
        public void GetListNhom_BoPhan(ref List<string> lstNhom,ref List<string> lstBoPhan)
        {
            lstNhom = new List<string>();
            lstBoPhan = new List<string>();
            string matiepNhan = string.Empty;
            for (int i = 0; i < gvNhomCLS.RowCount; i++)
            {
                if (gvNhomCLS.GetRowCellValue(i, colNhom_MaNhom) != null)
                {
                    lstNhom.Add(gvNhomCLS.GetRowCellValue(i, colNhom_MaNhom).ToString());
                    var mabophan = gvNhomCLS.GetRowCellValue(i, colNhom_MaBoPhan).ToString();
                    if (!lstBoPhan.Contains(mabophan))
                    {
                        lstBoPhan.Add(mabophan);
                    }
                }
            }
        }

        private void chkNguyCoCao_CheckedChanged(object sender, EventArgs e)
        {
            var stringDeNghiNCC = LoadDeNghiNCC();
            if(!string.IsNullOrEmpty(stringDeNghiNCC))
            {
                if(chkNguyCoCao.Checked)
                {
                    if (!txtDeNghi.Text.Contains(stringDeNghiNCC))
                    {
                        txtDeNghi.Text += (string.IsNullOrEmpty(txtDeNghi.Text) ? string.Empty : Environment.NewLine);
                        txtDeNghi.Text += stringDeNghiNCC;
                    }
                }
                else
                {
                    txtDeNghi.Text = txtDeNghi.Text.Replace(Environment.NewLine + stringDeNghiNCC, "").Replace(stringDeNghiNCC, "");
                }
            }
        }

        private void chkChanDoanBenh_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkThamGiaChanDoan_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkLan2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
