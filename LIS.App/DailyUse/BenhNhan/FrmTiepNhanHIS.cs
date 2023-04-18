using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.App.AppCode.Patient;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Patient.Services;
using TPH.LIS.User.Enum;
using TPH.Lab.Middleware.LISConnect.Services;
using System.Reflection;
using TPH.Common.Converter;
using TPH.Common.Extensions;
using TPH.LIS.Common;
using TPH.LIS.User.Constants;
using TPH.LIS.Configuration.Constants;
using DevExpress.XtraGrid.Columns;
using TPH.Lab.Middleware.HISConnect.Services;
using TPH.LIS.TestResult.Services;
using TPH.LIS.Patient.Model;
using TPH.Data.HIS.Models;
using TPH.Data.HIS.HISDataCommon;
using System.Collections.Generic;
using TPH.LIS.App.AppCode;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils.Drawing;
using System.Text;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Skins;
using TPH.LIS.App.DailyUse.BenhNhan;
using TPH.LIS.Patient.Constants;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.BarcodePrinting;
using TPH.WriteLog;
using System.Diagnostics;
using System.Threading.Tasks;
using TPH.Lab.Middleware.HISConnect.Models;
using TPH.LIS.Log;
using DateTimeConverter = TPH.Common.Converter.DateTimeConverter;
using StringConverter = TPH.Common.Converter.StringConverter;
using static TPH.LIS.Common.TestType;
using TPH.LIS.App.Settings.HeThong;
using TPH.Controls;
using TPH.Lab.Middleware.LISConnect.Models;
using TPH.Language;
using System.Management;
using DevExpress.Office.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.Data.Filtering;
using DevExpress.Data.Browsing;
using DevExpress.XtraReports.UI;
using TPH.Report.Models;
using TPH.Report.Services.Impl;
using TPH.Report.Services;
using TPH.Report.Constants;
using TPH.HIS.WebAPI.Models.HisReponses;
using DevExpress.Utils.About;

namespace TPH.LIS.App.ThucThi.BenhNhan
{
    public partial class FrmTiepNhanHIS : FrmTemplate
    {
        private readonly C_BenhNhan_TiepNhan _data = new C_BenhNhan_TiepNhan();
        private readonly IPatientInformationService _informationService = new PatientInformationService();
        private readonly IConnectHISService _iHisData = new ConnectHISService();
        private readonly IGetHISService _iHisService = new GetHISService();
        private readonly ITestResultService _iXetnghiem = new TestResultService();
        private readonly IMicrobilogyTestResultService _iBioticResult = new MicrobilogyTestResultService();
        private readonly ISystemConfigService _iSysConfig = new SystemConfigService();
        private readonly C_Patient _info = new C_Patient();
        private readonly C_Config _config = new C_Config();
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
        private HISDataColumnNames hColumnNames;
        HisConnection hisInfo;
        private DataTable DataOrder = new DataTable();
        bool showDebugData = false;
        private GridElementsPainter _PainterChuaLayMau;
        string idKhuLaymau = "-1";
        DataTable dataMapping = new DataTable();
        private DM_MAYTINH_MAYIN objPrintInfo;
        private DM_KHULAYMAU objKhuLayMau = new DM_KHULAYMAU();
        TrangThaiLayMau objTrangThaiCuaMau = new TrangThaiLayMau();
        DateTime tgLayMauSauCung = CommonAppVarsAndFunctions.ServerTime;
        int soLuongDaLay = 0;
        int banLayMau = 0;
        int soTTLayMau = 0;
        DateTime tgThucHienLayMau = CommonAppVarsAndFunctions.ServerTime;
        string nguoiLayMau = CommonAppVarsAndFunctions.UserID;
        List<string> LstColumnInfo = new List<string>();
        List<DM_KHUVUC> lstKhuVuc = new List<DM_KHUVUC>();
        List<DM_KHUVUC_XNKHONGTHUCHIEN> lstXnGui = new List<DM_KHUVUC_XNKHONGTHUCHIEN>();
        private void Load_XnGuiMau()
        {
            var data = _iSysConfig.Data_dm_khuvuc_xnkhongthuchien(CommonAppVarsAndFunctions.PCWorkPlace, string.Empty, string.Empty);
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dataRow in data.Rows)
                {
                    lstXnGui.Add(_iSysConfig.Get_Info_dm_khuvuc_xnkhongthuchien(dataRow));
                }
            }
        }
        private void Load_DSKhuVuc()
        {
            var data = _iSysConfig.Data_dm_khuvuc(string.Empty);
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dataRow in data.Rows)
                {
                    lstKhuVuc.Add(_iSysConfig.Get_Info_dm_khuvuc(dataRow));
                }
            }
        }
        private void Load_PrintConfig()
        {
            var idMayXN = 0;
            if (cboMayInTem1.SelectedIndex > -1)
                idMayXN = int.Parse(StringConverter.ToString(cboMayInTem1.SelectedValue));

            _registryExtension.WriteRegistry(CommonConstant.RegistryPrinterBarcode_OnGetSample, idMayXN.ToString());
            objPrintInfo = _iSysConfig.Get_info_CauHinh_MaInbarcode(Environment.MachineName, idMayXN, 1);
        }
        public FrmTiepNhanHIS()
        {
            InitializeComponent();
            LabServices_Helper.Set_Event_Focus(chkBarcodeInSan);
            LabServices_Helper.Set_Event_Focus(radChiDInhDaLay);
            LabServices_Helper.Set_Event_Focus(radHisChiDInhChuaLay);
            LabServices_Helper.Set_Event_Focus(radHisTatCaChiDinh);
            grbChiTietXetNghiem.BackColor = gbDanhSachHIS.BackColor = gbLanChiDinh.BackColor = CommonAppColors.ColorMainAppFormColor;
            grbChiTietXetNghiem.AppearanceCaption.ForeColor = gbDanhSachHIS.AppearanceCaption.ForeColor = gbLanChiDinh.AppearanceCaption.ForeColor = CommonAppColors.ColorTextCaption;
            chkInPhieuHen.BackColor = chkTiepNhanKhiNhapBarcode.BackColor =
                chkInPhieuHen.BackColor = CommonAppColors.ColorMainAppFormColor;
            pnChoTiepNhan.BackColor = CommonAppColors.ColorMainAppColor;
            //lblMessage.ForeColor = Color.White;
        }
        /// <summary>
        /// Lấy trạng thái theo radion button đang chọn
        /// </summary>
        /// <returns>0: Chưa lấy  - 1: Đã lấy - 2: Tất cả </returns>
        private int? Get_TrangtHaiChiDinh()
        {
            switch (CommonAppVarsAndFunctions.WorkingHis)
            {
                case HisProvider.DH_DHG:
                    return (radChiDInhDaLay.Checked ? 1 : (radHisChiDInhChuaLay.Checked ? 2 : 3));
                case HisProvider.FPT_SP:
                    return radChiDInhDaLay.Checked ? FPTTrangThaiChiDinh.DaCap : FPTTrangThaiChiDinh.ChuaCap;
                default:
                    return (radChiDInhDaLay.Checked ? 1 : (radHisChiDInhChuaLay.Checked ? 0 : 2));
            }
        }
        private void LoadPatientListFromHIS(bool fromTextInput = false, DataTable dataInput = null)
        {
            if (hisInfo == null) return;
            try
            {
                gvHisDanhSachBenhNhanCho.ActiveFilterString = string.Empty;
                ShowMessage(CommonAppVarsAndFunctions.LangMessageConstant.DanglaydanhsachtuHIS);
                var oderListData = new HISReturnBase();

                if (dataInput == null)
                {
                    if (!fromTextInput && this.hisInfo.HisID != HisProvider.ISofH)
                        txtSoPhieuYeuCau.Text = string.Empty;
                    txtBarcode.Text = string.Empty;
                    gChiTietChiDinh_His.DataSource = null;
                    TestGroup info = TestGroup.ALL;

                    var paraList = new HisParaGetList();
                    paraList.IDNhomXN = info;
                    paraList.NgayChiDinh = dtpHisTuNgayChiDinh.Value.Date;
                    paraList.TimTuNgayChiDinh = new DateTime(dtpHisTuNgayChiDinh.Value.Year, dtpHisTuNgayChiDinh.Value.Month, dtpHisTuNgayChiDinh.Value.Day, 0, 0, 0);
                    paraList.TimDenNgayChiDinh = new DateTime(dtpHisDenNgayChiDinh.Value.Year, dtpHisDenNgayChiDinh.Value.Month, dtpHisDenNgayChiDinh.Value.Day, 23, 59, 59);
                    paraList.SoPhieuChiDinh = string.IsNullOrEmpty(txtSoPhieuYeuCau.Text) ? null : txtSoPhieuYeuCau.Text;
                    paraList.TrangThai = Get_TrangtHaiChiDinh();
                    paraList.HoTen = txtTenBNHis.Text;
                    hColumnNames = _iHisData.GetHisThongTinMappingCot(hisInfo, CommonAppVarsAndFunctions.HisDataColumnsList);
                    dataMapping = _iHisData.DataMapping((int)CommonAppVarsAndFunctions.WorkingHis);

                    oderListData = _iHisData.GetPatientOrderedList(this.hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, paraList, hColumnNames);
                }
                else
                    oderListData.Data = dataInput;

                if (oderListData.Data != null)
                {
                    var dt = oderListData.Data;
                    DataOrder = dt.Copy();

                    if (dt.Rows.Count == 0)
                    {
                        gcHisDanhSachBenhNhanCho.DataSource = null;
                    }
                    else
                    {
                        ShowMessage(CommonAppVarsAndFunctions.LangMessageConstant.DangxulydanhsachtuHIS);
                        if (showDebugData)
                        {
                            CustomMessageBox.ShowRawData(dt, CommonAppVarsAndFunctions.LangMessageConstant.Dulieukhilayve);
                        }
                        if (dataInput != null && chkKhongLoadDanhSach.Checked)
                        {
                            for (var a = 0; a < dt.Columns.Count; a++)
                            {
                                if (!LstColumnInfo.Where(x => x.Equals(dt.Columns[a].ColumnName, StringComparison.CurrentCultureIgnoreCase)).Any())
                                {
                                    dt.Columns.RemoveAt(a);
                                    dt.AcceptChanges();
                                    a--;
                                }
                            }
                        }
                        var columns = new string[dt.Columns.Count];

                        for (var i = 0; i < dt.Columns.Count; i++)
                        {
                            columns[i] = dt.Columns[i].ColumnName;
                        }
                        dt.AcceptChanges();
                        dt = dt.DefaultView.ToTable(true, columns);
                        var dictinctDt = dt.DefaultView.ToTable(true);
                        dt = WorkingServices.ConvertColumnNameToLower_Upper(ConvertFont(dictinctDt), true);

                        if (showDebugData)
                            CustomMessageBox.ShowRawData(dt, CommonAppVarsAndFunctions.LangMessageConstant.Dulieusaukhixulyhienthi);
                        gcHisDanhSachBenhNhanCho.DataSource = dt;
                 
                        txtSoPhieuYeuCau.Focus();
                        txtSoPhieuYeuCau.SelectAll();
                    }
                    ShowMessage(string.Empty);
                }
                else
                {
                    ShowMessage(!string.IsNullOrEmpty(oderListData.Message)
                        ? oderListData.Message
                        : CommonAppVarsAndFunctions.LangMessageConstant.KHONGTIMTHAYTHONGTINTUHISTRAVE_Upper);
                }
            }
            catch (Exception ex)
            {
                LogService.RecordLogError(CommonAppVarsAndFunctions.UserID, "TiepNhanHis", ex, 0, ex.Message, (new StackTrace()).GetFrame(0).GetMethod().Name);
                ShowMessage(ex.Message);
            }
        }

        private DataTable ConvertFont(DataTable dtSource)
        {
            if (CommonAppVarsAndFunctions.sysConfig.ConnectHISWithConvertFont && dtSource.Rows.Count > 0)
            {
                var isVniFont = false;
                foreach (DataRow dr in dtSource.Rows)
                {
                    isVniFont = (bool)dr["font"];
                    if (isVniFont)
                    {
                        dr[hColumnNames.chidinhTenbenhnhan] = Utils.ConvertStringText(dr[hColumnNames.chidinhTenbenhnhan].ToString().Trim(), 2, 1);
                        dr[hColumnNames.chidinhDiachi] = Utils.ConvertStringText(dr[hColumnNames.chidinhDiachi].ToString().Trim(), 2, 1);
                        dr[hColumnNames.chidinhChandoan] = Utils.ConvertStringText(dr[hColumnNames.chidinhChandoan].ToString().Trim(), 2, 1);

                        dr[hColumnNames.chidinhTenbacsi] = Utils.ConvertStringText(dr[hColumnNames.chidinhTenbacsi].ToString().Trim(), 2, 1);
                        dr[hColumnNames.chidinhTendoituong] = Utils.ConvertStringText(dr[hColumnNames.chidinhTendoituong].ToString().Trim(), 2, 1);
                        dr[hColumnNames.chidinhTenkhoaphong] = Utils.ConvertStringText(dr[hColumnNames.chidinhTenkhoaphong].ToString().Trim(), 2, 1);
                    }
                }
            }
            dtSource.AcceptChanges();
            return dtSource;
        }
        private void LoadThongTinChiTiet(string maBenhNhan, string idBenhNhan, string sophieuChiDinh, DateTime? thoiGianChiDinh)
        {
            // dtgLanChiDinh.CellEnter -= DtgLanChiDinh_CellEnter;
            var paraList = new HisParaGetList
            {
                MaBenhAn = idBenhNhan,
                MaBenhNhan = maBenhNhan,
                NgayChiDinh = thoiGianChiDinh,
                TimDenNgayChiDinh = thoiGianChiDinh,
                TimTuNgayChiDinh = thoiGianChiDinh,
                SoPhieuChiDinh = sophieuChiDinh
            };
            var data = _iHisService.GetPatientInformationDetail(hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, paraList);
            ControlExtension.BindDataToGrid(data, ref dtgLanChiDinh, null);
            //  dtgLanChiDinh.CellEnter += DtgLanChiDinh_CellEnter;
            //Check_LoadChiTietTuDanhSachLanChiDinh();
        }

        private void DtgLanChiDinh_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Check_LoadChiTietTuDanhSachLanChiDinh();
        }

        private void Check_LoadChiTietTuDanhSachLanChiDinh()
        {
            if (dtgLanChiDinh.CurrentRow != null)
            {
                var SoPhieuYeuCau = gvDanhSach.GetFocusedRowCellValue(col_DanhSanh_chidinhSophieuyeucau).ToString();
                var thoiGianChiDinh = DateTime.Parse(dtgLanChiDinh.CurrentRow.Cells[col_ThongTin_chidinhThoigianchidinh.Name].Value.ToString());
                var maBenhNhan = dtgLanChiDinh.CurrentRow.Cells[col_ThongTin_chidinhMabenhnhan.Name].Value.ToString();
                var idBenhNhan = dtgLanChiDinh.CurrentRow.Cells[col_ThongTin_chidinhBNID.Name].Value.ToString();
                LoadOrderDetailFromHIS(SoPhieuYeuCau, false, null, thoiGianChiDinh.Date, thoiGianChiDinh.Date, false, idBenhNhan, maBenhNhan);
            }
            else
                gcChiDinh_Lis.DataSource = null;
        }
        private DataTable LoadOrderDetailFromHIS(string soPhieuYeuCau, bool showMess
            , DataTable dataOrder = null, DateTime? TuNgayNgayChiDinh = null
            , DateTime? DenNgayNgayChiDinh = null, bool NoiTru = false, string giaytoId = "", string maBenhNhan = "", string soHoSo = "", int iCount = 0)
        {
            gChiTietChiDinh_His.DataSource = null;
            DataTable dt = new DataTable();
            try
            {
                ShowMessage($"{CommonAppVarsAndFunctions.LangMessageConstant.Laychitietchidinh}: {soPhieuYeuCau}");
                TestGroup info = TestGroup.ALL;
                if (dataOrder != null)
                    dt = dataOrder;
                else
                {
                    var paraList = new HisParaGetList();
                    if (hisInfo.HisID.Equals(HisProvider.ISofH))
                    {
                        paraList.IDGiayto = giaytoId;
                        paraList.MaBenhNhan = (soPhieuYeuCau.Length == 10 ? soPhieuYeuCau : string.Empty);
                        paraList.IDNhomXN = info;
                        paraList.NgayChiDinh = TuNgayNgayChiDinh;
                        paraList.TimTuNgayChiDinh = TuNgayNgayChiDinh;
                        paraList.TimDenNgayChiDinh = DenNgayNgayChiDinh;
                        paraList.SoPhieuChiDinh = soPhieuYeuCau;
                        paraList.NoiTru = NoiTru;
                        paraList.TrangThai = Get_TrangtHaiChiDinh();
                        paraList.MaBenhAn = soHoSo;
                        paraList.HoTen = txtTenBNHis.Text;
                    }
                    else
                    {
                        paraList.IDGiayto = giaytoId;
                        paraList.MaBenhNhan = maBenhNhan;
                        paraList.IDNhomXN = info;
                        paraList.NgayChiDinh = TuNgayNgayChiDinh;
                        paraList.TimTuNgayChiDinh = TuNgayNgayChiDinh;
                        paraList.TimDenNgayChiDinh = DenNgayNgayChiDinh;
                        paraList.SoPhieuChiDinh = soPhieuYeuCau;
                        paraList.NoiTru = NoiTru;
                        paraList.TrangThai = Get_TrangtHaiChiDinh();
                        paraList.MaBenhAn = soHoSo;
                        paraList.HoTen = txtTenBNHis.Text;
                    }
                    if (iCount == 1)
                        paraList.ThangNamThucHien = string.Format("{0:MM/yyyy}", CommonAppVarsAndFunctions.ServerTime.AddMonths(-1));
                    else
                        paraList.ThangNamThucHien = string.Format("{0:MM/yyyy}", CommonAppVarsAndFunctions.ServerTime);

                    var orderDetail = _iHisData.GetPatientOrderedDetail(hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, paraList, CommonAppVarsAndFunctions.HisDataColumnsList, false, hColumnNames);
                    if (orderDetail.Data != null)
                    {
                        dt = orderDetail.Data;
                        if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.Vimes)
                        {
                            var trangThai = Get_TrangtHaiChiDinh() ?? 2;
                            if (trangThai == 0)
                            {
                                dt = WorkingServices.SearchResult_OnDatatable_NoneSort(dt, string.Format("{0} = {1} and ({2} = '{4}' or {3} = '{4}')", hColumnNames.chidinhTrangThaiChiDinh, trangThai, hColumnNames.chidinhTrangThaiPhieu, hColumnNames.chidinhTrangThaiKetQua, "S"));
                            }
                            else if (trangThai == 1)
                            {
                                dt = WorkingServices.SearchResult_OnDatatable_NoneSort(dt, string.Format("{0} = {1} and ({2} = '{4}' or {3} = '{4}')", hColumnNames.chidinhTrangThaiChiDinh, trangThai, hColumnNames.chidinhTrangThaiPhieu, hColumnNames.chidinhTrangThaiKetQua, "S"));
                            }
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(orderDetail.Message))
                            ShowMessage(string.Format(CommonAppVarsAndFunctions.LangMessageConstant.OrderNotFoundFromHis, soPhieuYeuCau));
                        else
                        {
                            ShowMessage(string.Format(CommonAppVarsAndFunctions.LangMessageConstant.HISResponse, orderDetail.Message));
                            return null;
                        }
                    }
                }

                if (dt.Rows.Count == 0)
                {
                    if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.DH_API && iCount == 0)
                    {
                        LoadOrderDetailFromHIS(soPhieuYeuCau, showMess, dataOrder, TuNgayNgayChiDinh, DenNgayNgayChiDinh, NoiTru, giaytoId, maBenhNhan, soHoSo, 1);
                    }

                    gChiTietChiDinh_His.DataSource = null;
                    ShowMessage(string.Format(CommonAppVarsAndFunctions.LangMessageConstant.OrderNotFoundFromHis, soPhieuYeuCau));

                    txtSoPhieuYeuCau.Focus();
                    txtSoPhieuYeuCau.SelectAll();
                }
                else
                {
                    if (CommonAppVarsAndFunctions.WorkingHis != HisProvider.DH_DHG && CommonAppVarsAndFunctions.WorkingHis != HisProvider.DH_API && hColumnNames.chidinhTrangThaiChiDinh != null)
                    {
                        if (!string.IsNullOrEmpty(hColumnNames.chidinhTrangThaiChiDinh))
                        {
                            foreach (DataRow dtR in dt.Rows)
                            {

                                if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.FPT_SP)
                                {
                                    var trangThai = dtR[hColumnNames.chidinhTrangThaiChiDinh].ToString();
                                    if (trangThai.Trim() == "0")
                                        dtR["trangthaichidinh"] = CommonAppVarsAndFunctions.LangMessageConstant.Dalaymau;
                                    else if (trangThai.Trim() == "4")
                                        dtR["trangthaichidinh"] = CommonAppVarsAndFunctions.LangMessageConstant.Cholaymau;
                                    else if (trangThai.Trim() == "2")
                                        dtR["trangthaichidinh"] = CommonAppVarsAndFunctions.LangMessageConstant.Dacoketqua2;
                                }
                                else
                                {
                                    var trangThai = dtR[hColumnNames.chidinhTrangThaiChiDinh].ToString();
                                    if (trangThai.Trim() == "1" || trangThai.Trim() == "True")
                                        dtR["trangthaichidinh"] = CommonAppVarsAndFunctions.LangMessageConstant.Dalaymau;
                                    else if (trangThai.Trim() == "0" || trangThai.Trim() == "False")
                                        dtR["trangthaichidinh"] = CommonAppVarsAndFunctions.LangMessageConstant.Cholaymau;
                                }
                                if (CommonAppVarsAndFunctions.sysConfig.ConnectHISWithConvertFont)
                                {
                                    var isVniFont = (bool)dtR["font"];
                                    if (isVniFont)
                                    {
                                        dtR[hColumnNames.chidinhTenbenhnhan] = Utils.ConvertStringText(dtR[hColumnNames.chidinhTenbenhnhan].ToString().Trim(), 2, 1);
                                        dtR[hColumnNames.chidinhDiachi] = Utils.ConvertStringText(dtR[hColumnNames.chidinhDiachi].ToString().Trim(), 2, 1);
                                        dtR[hColumnNames.chidinhChandoan] = Utils.ConvertStringText(dtR[hColumnNames.chidinhChandoan].ToString().Trim(), 2, 1);
                                        dtR[hColumnNames.chidinhTendv] = Utils.ConvertStringText(dtR[hColumnNames.chidinhTendv].ToString().Trim(), 2, 1);
                                        dtR[hColumnNames.chidinhTenbacsi] = Utils.ConvertStringText(dtR[hColumnNames.chidinhTenbacsi].ToString().Trim(), 2, 1);
                                        dtR[hColumnNames.chidinhTendoituong] = Utils.ConvertStringText(dtR[hColumnNames.chidinhTendoituong].ToString().Trim(), 2, 1);
                                        dtR[hColumnNames.chidinhTenkhoaphong] = Utils.ConvertStringText(dtR[hColumnNames.chidinhTenkhoaphong].ToString().Trim(), 2, 1);
                                    }
                                }
                            }
                            dt.AcceptChanges();
                        }
                    }
                    gChiTietChiDinh_His.DataSource = dt;
                    // gvChiTietChiDinh_His.BestFitColumns();
                    gvChiTietChiDinh_His.ExpandAllGroups();
                    gvChiTietChiDinh_His.SelectAll();
                    XuLyTrungChiDinh();
                    ShowMessage(string.Empty);

                    ShowChiTietChiDinh();
                    if (showMess)
                        txtBarcode.Focus();
                }
            }
            catch (Exception ex)
            {
                LogService.RecordLogError(CommonAppVarsAndFunctions.UserID, "TiepNhanHis", ex, 0, ex.Message, (new StackTrace()).GetFrame(0).GetMethod().Name);
                ShowMessage(ex.Message);
            }
            return dt;
        }
        private void XuLyTrungChiDinh()
        {
            if (!CommonAppVarsAndFunctions.sysConfig.SuDungBarcodeHIS)
            {
                string selectedCheck = string.Empty;
                string testCheck = string.Empty;
                if (gvChiTietChiDinh_His.RowCount > 0)
                {
                    for (int i = 0; i < gvChiTietChiDinh_His.RowCount; i++)
                    {
                        if (gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhMaDichVu) != null)
                        {
                            testCheck = string.Format("[Code:{0}]", gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhMaDichVu).ToString().Trim().ToUpper());
                            var daThuchien = false;
                            if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.Vimes)
                            {
                                var trangthaiKq = gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhTrangThaiKetQua).ToString();
                                var trangthaiphieu = gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhTrangThaiPhieu).ToString();
                                daThuchien = (trangthaiKq.Equals("t", StringComparison.OrdinalIgnoreCase) || trangthaiphieu.Equals("t", StringComparison.OrdinalIgnoreCase));
                            }
                            else if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.DH_API || CommonAppVarsAndFunctions.WorkingHis == HisProvider.DH_DHG)
                            {
                                var trangthaiphieu = (gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhTrangThaiChiDinh) == null ? "0" : gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhTrangThaiChiDinh).ToString());
                                daThuchien = int.Parse(string.IsNullOrEmpty(trangthaiphieu) ? "0" : trangthaiphieu) > 0;
                            }
                            if (selectedCheck.Contains(testCheck) || daThuchien)
                            {
                                gvChiTietChiDinh_His.UnselectRow(i);
                            }
                            else
                                selectedCheck += testCheck;
                        }
                    }
                }
            }
        }
        private DieuKienTimDanhSachBNTheoTrangThaiMau DieuKienLoad_DanhSachBN()
        {
            var obj = new DieuKienTimDanhSachBNTheoTrangThaiMau();
            //--- Tất cả ---
            //Chưa lấy mẫu
            //Đã lấy mẫu đủ
            //Chưa lấy mẫu đủ
            //Yêu cầu lấy lại
            obj.tungay = dtpDateIn.Value;
            obj.denngay = dtpDateIn.Value;
            obj.barcode = string.Empty;// txtSearch.Text;
            obj.maBN = string.Empty; //txtSearch.Text;
            obj.loaiDichVu = ServiceType.ClsXetNghiem;
            obj.sophieuHis = string.Empty;// txtBarcode.Text;

            var indexSelected = cboTrangThaiLayMau.SelectedIndex;
            if (indexSelected == 1)
            {
                obj.daLayMauTatCa = Common.enumThucHien.ChuaThucHien;
            }
            else if (indexSelected == 2)
            {
                obj.daLayMauTatCa = Common.enumThucHien.DaThucHien;
            }
            else if (indexSelected == 3)
            {
                obj.coLayMau = Common.enumThucHien.DaThucHien;
                obj.daLayMauTatCa = Common.enumThucHien.ChuaThucHien;
            }
            else if (indexSelected == 4)
            {
                obj.daTuChoiMau = Common.enumThucHien.DaThucHien;
            }

            return obj;
        }
        private void Get_DanhSachBenhNhan()
        {
            try
            {
                lblMsg.Text = string.Empty;
                gvDanhSach.FocusedRowChanged -= GvDanhSach_FocusedRowChanged;
                gvDanhSach.FocusedColumnChanged -= GvDanhSach_FocusedColumnChanged;
                var currentbarcode = txtSearch.Text; // txtBarcode.Text;

                var data = _informationService.DanhSach_BenhNhan_TheoTrangThaiMau(DieuKienLoad_DanhSachBN());

                gcDanhSach.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(data, true);

                colDS_TGNhap.SortMode = ColumnSortMode.Value;
                colDS_TGNhap.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                gvDanhSach.ActiveFilterString = String.Empty;
                if (gvDanhSach.RowCount == 0)
                {
                    lblMsg.Text = "";
                }
                else
                {
                    if (!string.IsNullOrEmpty(currentbarcode))
                    {
                        var filtter = string.Format("mabn = '{0}' or tenbn like '%{0}%' or seq like '%{0}%' or sophieuyeucau  = '{0}' or bn_id  = '{0}'", WorkingServices.EscapeLikeValue(currentbarcode));
                        gvDanhSach.ActiveFilterString = filtter;
                    }
                }
                gvDanhSach.FocusedRowChanged += GvDanhSach_FocusedRowChanged;
                gvDanhSach.FocusedColumnChanged += GvDanhSach_FocusedColumnChanged;
                gcChiDinh_Lis.DataSource = null;
                if (gvDanhSach.FocusedRowHandle > -1)
                {
                    //var date = (DateTime)dtgBenhNhan_DaLayMau.CurrentRow.Cells[colBN_DaLayMau_NgayTiepNhan.Name].Value;
                    //dtpDateIn.Value = date;
                    var maTiepNhan = gvDanhSach.GetFocusedRowCellValue(colDS_MaTiepNhan).ToString();
                    Load_DS_ChiDinh(maTiepNhan);
                    Get_TrangThaiLayMau();
                }
                //   LoadThongTinPhieuHen();
            }
            catch (Exception ex)
            {
                CustomMessageBox.MSG_Error_OK(ex.Message);
            }
        }
        private void GvDanhSach_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            LoadChiDinhXN();
        }

        private void GvDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadChiDinhXN();
        }

        private void LoadThongTinPhieuHen()
        {
            ucGioHenTraKetQua1.ClearDanhSach();
            if (gvDanhSach.FocusedRowHandle > -1)
            {
                var sohoSo = gvDanhSach.GetFocusedRowCellValue(colDS_SoHoSoHis).ToString();
                var barcode = gvDanhSach.GetFocusedRowCellValue(colDS_Barcode).ToString();
                var ngayTiepNhan = DateTime.Parse(gvDanhSach.GetFocusedRowCellValue(colDS_NgayTiepNhan).ToString());
                ucGioHenTraKetQua1.Load_DanhSachHenTraKetQua(true, string.Empty, sohoSo, ngayTiepNhan, barcode);
            }
        }
        private void Get_TrangThaiLayMau()
        {
            lblMsg.Text = string.Empty;
            if (gvDanhSach.FocusedRowHandle > -1)
            {
                var statusTQ = gvDanhSach.GetFocusedRowCellValue(colDS_TrangThaiLayMauTQ).ToString();
                var statusVS = gvDanhSach.GetFocusedRowCellValue(colDS_TrangThaiLayMauVS).ToString();
                GetLableTitle(statusTQ, statusVS);
            }
        }
        void GetLableTitle(string statusTQ, string statusVS)
        {
            objTrangThaiCuaMau = LayThongTintrangThai(statusTQ, statusVS);
            lblMsg.Text = objTrangThaiCuaMau.TrangThaiChung;
        }
        private TrangThaiLayMau LayThongTintrangThai(string statusTQ, string statusVS)
        {
            return SampleStatus.Get_TrangLayMau(statusTQ, statusVS);
        }
        private void Load_DS_ChiDinh(string maTiepNhan)
        {
            gcChiDinh_Lis.DataSource = null;
            if (!string.IsNullOrEmpty(maTiepNhan))
            {
                var data = _informationService.DanhSachChiDinh_OngMau(maTiepNhan, CommonAppVarsAndFunctions.IDLayLoaiMau);
                if (data != null)
                {
                    if (data.Rows.Count > 0)
                    {
                        data = XuLyDuLieu(data);
                        data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);

                        gcChiDinh_Lis.DataSource = data;
                        gvChiDinh_Lis.ExpandAllGroups();

                        if (!chkChiTietDaTiepNhan.Checked)
                        {
                            gvChiDinh_Lis.CollapseAllGroups();
                            gvChiDinh_Lis.ExpandGroupLevel(0);
                        }
                        else
                        {
                            gvChiDinh_Lis.ExpandAllGroups();
                        }
                    }
                }
            }
        }
        private DataTable XuLyDuLieu(DataTable DataIn)
        {
            DataIn.Columns.Add("HinhOngMau", typeof(Image));
            DataIn.Columns.Add("NoiDuKienThucHien", typeof(string));
            DataIn.Columns.Add("IdGui", typeof(long));
            DataIn.Columns.Add("IDNoiGuiMau", typeof(string));
            DataIn.Columns.Add("IDNoiNhanGuiMau", typeof(string));
            var maXN = string.Empty;
            var maKhuvucnhan = string.Empty;
            var manhomCls = string.Empty;

            var distinctMaTiepNhan = DataIn.DefaultView.ToTable(true, "MaTiepNhan");
            var dataMauGui = new DataTable();
            foreach (DataRow drT in distinctMaTiepNhan.Rows)
            {
                var temDT = _informationService.Data_XetNghiem_GuiMau(drT["MaTiepNhan"].ToString(), 2, CommonAppVarsAndFunctions.NhomClsXetNghiem);
                if (temDT != null)
                {
                    if (dataMauGui.Rows.Count == 0)
                        dataMauGui = temDT.Copy();
                    else
                    {
                        dataMauGui.Merge(temDT);
                    }
                }
            }
            var lstMauGui = new List<GuiMauNoiBoModel>();
            if (dataMauGui != null)
            {
                foreach (DataRow dataRow in dataMauGui.Rows)
                {
                    var obj = new GuiMauNoiBoModel();
                    lstMauGui.Add((GuiMauNoiBoModel)WorkingServices.Get_InfoForObject(obj, dataRow));
                }
            }

            for (int i = 0; i < DataIn.Rows.Count; i++)
            {
                DataRow dr = DataIn.Rows[i];
                if (!string.IsNullOrEmpty(dr["MauNhanMau"].ToString()))
                {
                    string[] split = dr["MauNhanMau"].ToString().Split(',');
                    if (split.Length == 3)
                    {
                        Bitmap b = new Bitmap(18, 28);
                        using (Graphics g = Graphics.FromImage(b))
                            g.Clear(Color.FromArgb(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])));
                        dr["HinhOngMau"] = b;
                    }
                }
                var maTiepNhan = dr["MaTiepNhan"].ToString();
                //Xử lý trạng thái gửi mẫu
                maXN = dr["MaDichVu"].ToString();
                long idGui = 0;
                if (lstMauGui.Count > 0)
                {
                    var mauGui = lstMauGui.Where(g => g.Madichvu.Equals(maXN, StringComparison.OrdinalIgnoreCase) && g.Matiepnhan.Equals(maTiepNhan));
                    if (mauGui.Any())
                    {
                        idGui = mauGui.First().Idgui;
                        dr["IDNoiGuiMau"] = mauGui.First().Khuvucguiid;
                        dr["IDNoiNhanGuiMau"] = mauGui.First().Khuvucnhanid;
                    }
                }
                dr["IdGui"] = idGui;
                var lstkhuNhan = lstXnGui.Where(x => x.Maxn.Equals(maXN.Trim(), StringComparison.OrdinalIgnoreCase));
                if (idGui > 0)
                {
                    var lstkhuGuiDen = lstKhuVuc.Where(x => x.Makhuvuc.Trim().Equals(dr["IDNoiNhanGuiMau"].ToString().Trim(), StringComparison.OrdinalIgnoreCase));
                    if (lstkhuGuiDen.Any())
                    {
                        dr["NoiDuKienThucHien"] = string.Format("{0} ({1}){2}", lstkhuGuiDen.FirstOrDefault().Tenkhuvuc, lstkhuGuiDen.FirstOrDefault().Makhuvuc, (idGui > 0 ? " - Gửi mẫu" : string.Empty));
                    }
                }
                else if (lstkhuNhan.Any())
                {
                    dr["NoiDuKienThucHien"] = string.Format("{0} ({1}){2}", lstkhuNhan.FirstOrDefault().Tenkhuvucnhan, lstkhuNhan.FirstOrDefault().Makhuvucnhan, (idGui > 0 ? " - Gửi mẫu" : string.Empty));

                }
                else
                {
                    dr["NoiDuKienThucHien"] = string.Format("{0} ({1}){2}", CommonAppVarsAndFunctions.PCWorkPlaceName, CommonAppVarsAndFunctions.PCWorkPlace, (idGui > 0 ? " - Gửi mẫu" : string.Empty));
                }
            }
            return DataIn;
        }
        int oldColMaBnIndex = -1;
        bool isSettingConfig = false;
        private void Set_HisConfig(HisProvider hisProvider)
        {
            isSettingConfig = true;
            gcHisDanhSachBenhNhanCho.DataSource = null;
            gcChiDinh_Lis.DataSource = null;
            pnDenNgay.Visible = true;
            chkKhongLoadDanhSach.Visible = chkKhongLoadDanhSach.Checked = HISKhongLoaDanhSach_DungSoPhieu();
            if (HISKhongLoaDanhSach_DungSoPhieu() && chkKhongLoadDanhSach.Checked)
            {
                pnDenNgay.Visible = false;
            }
            else if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.DBTG_HL7_FPT || CommonAppVarsAndFunctions.WorkingHis == HisProvider.FPT_SP)
            {
                var dispIndex = col_DanhSanh_chidinhSophieuyeucau.VisibleIndex;
                col_DanhSanh_chidinhMabenhnhan.Caption = LanguageExtension.GetResourceValueFromKey(
                    "Mayte",
                    LanguageExtension.AppLanguage); // "Mã y tế"
                //Ghi lại index lúc design để khoi phục lại đúng khi chuyển HIS
                oldColMaBnIndex = col_DanhSanh_chidinhMabenhnhan.VisibleIndex;

                col_DanhSanh_chidinhMabenhnhan.VisibleIndex = dispIndex;
                if (gvHisDanhSachBenhNhanCho.Columns.Contains(col_DanhSanh_chidinhSophieuyeucau))
                    gvHisDanhSachBenhNhanCho.Columns.Remove(col_DanhSanh_chidinhSophieuyeucau);
                col_DanhSanh_chidinhTrangThaiChiDinh.Visible = false;

                if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.FPT_SP)
                {
                    radHisTatCaChiDinh.Visible = false;
                    radHisChiDInhChuaLay.CheckedChanged -= radHisTrangThaiChiDinh_CheckedChanged;
                    radChiDInhDaLay.CheckedChanged -= radHisTrangThaiChiDinh_CheckedChanged;
                    radHisTatCaChiDinh.CheckedChanged -= radHisTrangThaiChiDinh_CheckedChanged;
                    radHisChiDInhChuaLay.Checked = true;

                    radHisChiDInhChuaLay.CheckedChanged += radHisTrangThaiChiDinh_CheckedChanged;
                    radChiDInhDaLay.CheckedChanged += radHisTrangThaiChiDinh_CheckedChanged;
                    radHisTatCaChiDinh.CheckedChanged += radHisTrangThaiChiDinh_CheckedChanged;
                }
            }
            else if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.Vimes)
            {
                chkKhongLoadDanhSach.Visible = true;
                dtpHisTuNgayChiDinh.CustomFormat = "dd/MM/yyyy HH:mm:ss";
                dtpHisDenNgayChiDinh.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            }
            else
            {
                //trả lại các cột đã xóa hoặc ẩn do chuyển HIS.
                var dispMabnIndex = oldColMaBnIndex == -1 ? col_DanhSanh_chidinhMabenhnhan.VisibleIndex : oldColMaBnIndex;
                var soPhieuIndex = oldColMaBnIndex == -1 ? col_DanhSanh_chidinhMabenhnhan.VisibleIndex : col_DanhSanh_chidinhMabenhnhan.VisibleIndex;

                col_DanhSanh_chidinhMabenhnhan.Caption = LanguageExtension.GetResourceValueFromKey(
                    "Mabenhnhan",
                    LanguageExtension.AppLanguage);  //"Mã bệnh nhân";

                col_DanhSanh_chidinhMabenhnhan.VisibleIndex = dispMabnIndex;
                if (!gvHisDanhSachBenhNhanCho.Columns.Contains(col_DanhSanh_chidinhSophieuyeucau))
                {
                    gvHisDanhSachBenhNhanCho.Columns.Add(col_DanhSanh_chidinhSophieuyeucau);
                    col_DanhSanh_chidinhMabenhnhan.VisibleIndex = soPhieuIndex;
                }
                col_DanhSanh_chidinhTrangThaiChiDinh.Visible = true;
                
                radHisTatCaChiDinh.Visible = true;
                radHisTatCaChiDinh.Checked = true;
            }

            ResetDate();
            hisInfo = CommonAppVarsAndFunctions.HisConnectList.Where(x => x.HisID == hisProvider).FirstOrDefault();
            hColumnNames = _iHisData.GetHisThongTinMappingCot(hisInfo, CommonAppVarsAndFunctions.HisDataColumnsList);
            Set_ColumnDataProperty(hisInfo);
            LstColumnInfo = new List<string>();
            foreach (GridColumn item in gvHisDanhSachBenhNhanCho.Columns)
            {
                if (!string.IsNullOrEmpty(item.FieldName))
                    LstColumnInfo.Add(item.FieldName);
            }
            if (col_DanhSanh_chidinhTrangThaiChiDinh.Visible)
            {
                radChiDInhDaLay.Enabled = true;
                radHisChiDInhChuaLay.Enabled = true;
                radHisTatCaChiDinh.Enabled = true;
                radHisChiDInhChuaLay.Checked = true;
            }
            else
            {
                radChiDInhDaLay.Enabled = false;
                radHisChiDInhChuaLay.Enabled = false;
                radHisTatCaChiDinh.Enabled = true;
                radHisTatCaChiDinh.Checked = true;
            }
            if (hisInfo != null)
            {
                lblTimHis.Text = (hisInfo.FindNameOnHIS ? "TÌM KIẾM HIS MÃ BN/ TÊN BN" : "TÌM KIẾM HIS MÃ BN");
                txtTenBNHis.Visible = hisInfo.FindNameOnHIS;
            }
            isSettingConfig = false;
        }
        private void ResetDate()
        {
            dtpHisDenNgayChiDinh.Value = CommonAppVarsAndFunctions.ServerTime;
            dtpHisTuNgayChiDinh.Value = dtpHisDenNgayChiDinh.Value.AddHours(-objKhuLayMau.SoGioLoadHis);
        }
        private void Load_HisProvider()
        {
            cboHISProvider.SelectedIndexChanged -= CboHISProvider_SelectedIndexChanged;
            var list = CommonData.GetEnumValuesAndDescriptions<HisProvider>().Where(x => CommonAppVarsAndFunctions.PCWorkPlaceOfHis.Contains(x.Key));
            cboHISProvider.DataSource = list.ToList();
            cboHISProvider.ValueMember = "Key";
            cboHISProvider.DisplayMember = "Value";
            cboHISProvider.SelectedIndex = 0;
            cboHISProvider.SelectedIndexChanged += CboHISProvider_SelectedIndexChanged;
            CommonAppVarsAndFunctions.WorkingHis = (HisProvider)Enum.Parse(typeof(HisProvider), list.FirstOrDefault().Key.ToString());
            if (list.Count() == 1)
                cboHISProvider.Enabled = false;
        }

        private void CboHISProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonAppVarsAndFunctions.WorkingHis = (HisProvider)Enum.Parse(typeof(HisProvider), cboHISProvider.SelectedValue.ToString());
            Set_HisConfig(CommonAppVarsAndFunctions.WorkingHis);
        }

        private void Set_ColumnDataProperty(HisConnection hisInfo)
        {
            col_ChiDinh_chidinhThoigianyeucau.GroupIndex = 0;
            col_ChiDinh_chidinhSophieuyeucauchitiet.GroupIndex = 1;
            colChiDinh_TenNhomCLS.GroupIndex = 2;
            for (int i = 0; i < gvChiTietChiDinh_His.Columns.Count; i++)
            {
                var col = gvChiTietChiDinh_His.Columns[i];
                SetDataPropertyNameForDatagriviewColumn(ref col, hisInfo);
            }
            SetDataPropertyNameForDatagriviewColumnNormal(hisInfo, gvHisDanhSachBenhNhanCho);

            if(hisInfo.HisID == HisProvider.VNPTMN)
                col_ChiDinh_chidinhThoigianyeucau.GroupIndex = -1;

            if (hisInfo.HisID == HisProvider.FPT_SP)
            {
                //  gbLanChiDinh.Visible = true;
                SetDataPropertyNameForDatagriviewColumnNormal(hisInfo, dtgLanChiDinh);
            }
            else
                gbLanChiDinh.Visible = false;
        }
        public void SetDataPropertyNameForDatagriviewColumnNormal(HisConnection hisInfo, GridView dtg)
        {
            for (int i = 0; i < dtg.Columns.Count; i++)
            {
                GridColumn dgc = dtg.Columns[i];

                string[] arrColName = dgc.Name.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                if (arrColName.Length > 2)
                {
                    if (dgc.Tag == null)
                        dgc.Tag = dgc.Visible;

                    var HisColumnsName = _iHisData.GetHisThongTinMappingCot(hisInfo, CommonAppVarsAndFunctions.HisDataColumnsList);
                    PropertyInfo[] fiCheck = HisColumnsName.GetType().GetProperties();
                    foreach (PropertyInfo f in fiCheck)
                    {
                        if (f.Name.Equals(arrColName[2], StringComparison.OrdinalIgnoreCase))
                        {
                            var obj = HisColumnsName.GetType().GetProperty(f.Name).GetValue(HisColumnsName, null) == null ? string.Empty : HisColumnsName.GetType().GetProperty(f.Name).GetValue(HisColumnsName, null);
                            if (string.IsNullOrEmpty(obj.ToString()))
                            {
                                dgc.FieldName = string.Empty;
                                dgc.Visible = false;
                            }
                            else
                            {
                                if (arrColName[2].Trim().Equals(hColumnNames.chidinhTrangThaiChiDinh, StringComparison.OrdinalIgnoreCase))
                                {
                                    if ((CommonAppVarsAndFunctions.WorkingHis == HisProvider.AHoi || CommonAppVarsAndFunctions.WorkingHis == HisProvider.PTT_SP || CommonAppVarsAndFunctions.WorkingHis == HisProvider.HangMinh) && dgc.UnboundDataType.GetType() != typeof(Boolean))
                                    {
                                     
                                        var HeaderText = dgc.Caption;
                                        var colName = dgc.Name;
                                        var colVisible = dgc.Visible;
                                        var colWidth = dgc.Width;
                                        var tag = dgc.Tag;
                                        var displayIndex = dgc.VisibleIndex;
                                        gvHisDanhSachBenhNhanCho.Columns.Remove(dgc);
                                        dgc = new GridColumn()
                                        {
                                            Caption = HeaderText,
                                            Name = colName,
                                            Visible = colVisible,
                                            Width = colWidth,
                                            Tag = tag,
                                            UnboundDataType = typeof(Boolean)
                                        };
                                        gvHisDanhSachBenhNhanCho.Columns.Add(dgc);
                                        dgc.VisibleIndex = displayIndex;
                                        i--;
                                    }
                                }
                                dgc.FieldName = HisColumnsName.GetType().GetProperty(f.Name).GetValue(HisColumnsName, null).ToString().ToLower().Trim();

                                dgc.Visible = (bool)dgc.Tag;
                            }
                            break;
                        }
                    }
                }
            }
        }
        public void SetDataPropertyNameForDatagriviewColumnNormal(HisConnection hisInfo, CustomDatagridView dtg)
        {
            for (int i = 0; i < dtg.Columns.Count; i++)
            {
                DataGridViewColumn dgc = dtg.Columns[i];

                string[] arrColName = dgc.Name.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                if (arrColName.Length > 2)
                {
                    if (dgc.Tag == null)
                        dgc.Tag = dgc.Visible;

                    var HisColumnsName = _iHisData.GetHisThongTinMappingCot(hisInfo, CommonAppVarsAndFunctions.HisDataColumnsList);
                    PropertyInfo[] fiCheck = HisColumnsName.GetType().GetProperties();
                    foreach (PropertyInfo f in fiCheck)
                    {
                        if (f.Name.Equals(arrColName[2], StringComparison.OrdinalIgnoreCase))
                        {
                            var obj = HisColumnsName.GetType().GetProperty(f.Name).GetValue(HisColumnsName, null) == null ? string.Empty : HisColumnsName.GetType().GetProperty(f.Name).GetValue(HisColumnsName, null);
                            if (string.IsNullOrEmpty(obj.ToString()))
                            {
                                dgc.DataPropertyName = string.Empty;
                                dgc.Visible = false;
                            }
                            else
                            {
                                if (arrColName[2].Trim().Equals(hColumnNames.chidinhTrangThaiChiDinh, StringComparison.OrdinalIgnoreCase))
                                {
                                    if ((CommonAppVarsAndFunctions.WorkingHis == HisProvider.AHoi || CommonAppVarsAndFunctions.WorkingHis == HisProvider.PTT_SP || CommonAppVarsAndFunctions.WorkingHis == HisProvider.HangMinh) && dgc.CellTemplate.GetType() != typeof(DataGridViewCheckBoxCell))
                                    {
                                        // DataGridViewColumn newCol = new DataGridViewCheckBoxColumn(); // add a column to the grid
                                        DataGridViewCell cell = new DataGridViewCheckBoxCell(); //Specify which type of cell in this column
                                        cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                                        var HeaderText = dgc.HeaderText;
                                        var colName = dgc.Name;
                                        var colVisible = dgc.Visible;
                                        var colWidth = dgc.Width;
                                        var tag = dgc.Tag;
                                        var displayIndex = dgc.DisplayIndex;
                                        dtg.Columns.Remove(dgc);

                                        dgc = new DataGridViewColumn(cell)
                                        {
                                            HeaderText = HeaderText,
                                            Name = colName,
                                            Visible = colVisible,
                                            Width = colWidth,
                                            Tag = tag
                                        };
                                        dtg.Columns.Add(dgc);
                                        dgc.DisplayIndex = displayIndex;
                                        i--;
                                    }
                                }
                                dgc.DataPropertyName = HisColumnsName.GetType().GetProperty(f.Name).GetValue(HisColumnsName, null).ToString().ToLower().Trim();

                                dgc.Visible = (bool)dgc.Tag;
                            }
                            break;
                        }
                    }
                }
            }
        }
        public void SetDataPropertyNameForDatagriviewColumn(ref GridColumn dgc, HisConnection hisInfo)
        {
            string[] arrColName = dgc.Name.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
            if (arrColName.Length > 2)
            {
                if (dgc.Tag == null)
                    dgc.Tag = dgc.Visible;
                var HisColumnsName = _iHisData.GetHisThongTinMappingCot(hisInfo, CommonAppVarsAndFunctions.HisDataColumnsList);
                //  HisColumnsName.chidinhMakhoahienthoi
                PropertyInfo[] fiCheck = HisColumnsName.GetType().GetProperties();
                foreach (PropertyInfo f in fiCheck)
                {
                    if (f.Name.Equals(arrColName[2], StringComparison.OrdinalIgnoreCase))
                    {
                        var obj = HisColumnsName.GetType().GetProperty(f.Name).GetValue(HisColumnsName, null) == null ? string.Empty : HisColumnsName.GetType().GetProperty(f.Name).GetValue(HisColumnsName, null);
                        if (string.IsNullOrEmpty(obj.ToString()))
                        {
                            dgc.FieldName = string.Empty;
                            dgc.Visible = false;
                            if (dgc.Name == colChiDinh_TenNhomCLS.Name)
                            {
                                dgc.GroupIndex = -1;
                            }
                        }
                        else
                        {
                            dgc.FieldName = obj.ToString().ToLower().Trim();
                            dgc.Visible = (bool)dgc.Tag;

                            if (dgc.Name == colChiDinh_TenNhomCLS.Name)
                            {
                                dgc.GroupIndex = 2;
                            }
                            else if (dgc.Name == col_ChiDinh_chidinhSophieuyeucauchitiet.Name)
                            {
                                dgc.GroupIndex = 1;
                                dgc.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
                                dgc.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                            }
                            else if (dgc.Name == col_ChiDinh_chidinhThoigianyeucau.Name)
                            {
                                dgc.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
                                dgc.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                                dgc.GroupIndex = 0;
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            try
            {
                LogService.RecordLogFile(LogFile.ActionLog,
                    string.Format("btnThucHien_Click Start: {0:yyyy/MM/dd HH:mm:ss fff}", DateTime.Now), this.Text);

                dtpDateIn.Value = C_Ultilities.ServerDate();

                LogService.RecordLogFile(LogFile.ActionLog,
                    string.Format("Get server date: {0:yyyy/MM/dd HH:mm:ss fff}", dtpDateIn.Value), this.Text);

                if (gvHisDanhSachBenhNhanCho.FocusedRowHandle < 0 && string.IsNullOrEmpty(txtSoPhieuYeuCau.Text) && !chkKhongLoadDanhSach.Checked &&
                    gvChiTietChiDinh_His.SelectedRowsCount <= 0) return;

                if (!string.IsNullOrEmpty(txtSearch.Text))
                {
                    txtSearch.Text = string.Empty;
                }

                if (cboTrangThaiLayMau.SelectedIndex != 0)
                {
                    cboTrangThaiLayMau.SelectedIndexChanged -= cboTrangThaiLayMau_SelectedIndexChanged;
                    cboTrangThaiLayMau.SelectedIndex = 0;
                    cboTrangThaiLayMau.SelectedIndexChanged += cboTrangThaiLayMau_SelectedIndexChanged;
                }

                var sophieuyeucau = string.Empty;
                var mabn = string.Empty;
                var sohoSo = string.Empty;
                if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.DBTG_HL7_FPT ||
                    CommonAppVarsAndFunctions.WorkingHis == HisProvider.FPT_SP)
                    sophieuyeucau = StringConverter
                        .ToString(gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSanh_chidinhMabenhnhan))
                        .Trim();
                else
                    sophieuyeucau = StringConverter
                        .ToString(gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSanh_chidinhSophieuyeucau))
                        .Trim();

                var tenBN = gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSanh_chidinhTenbenhnhan)
                    .ToString();
                sohoSo = string.IsNullOrEmpty(col_DanhSanh_chidinhMabenhan.FieldName)
                    ? ""
                    : StringConverter
                        .ToString(gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSanh_chidinhMabenhan));
                mabn = string.IsNullOrEmpty(col_DanhSanh_chidinhMabenhnhan.FieldName)
                   ? ""
                   : StringConverter
                       .ToString(gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSanh_chidinhMabenhnhan));
                if (!AllowBNTest(tenBN))
                    return;
                if (!string.IsNullOrEmpty(txtSoPhieuYeuCau.Text))
                {
                    if (!sophieuyeucau.Trim().Equals(txtSoPhieuYeuCau.Text.Trim(), StringComparison.OrdinalIgnoreCase) &&
                        !sohoSo.Trim().Equals(txtSoPhieuYeuCau.Text.Trim(), StringComparison.OrdinalIgnoreCase) &&
                        !mabn.Trim().Equals(txtSoPhieuYeuCau.Text.Trim(), StringComparison.OrdinalIgnoreCase)
                        ) return;
                }
                else
                    txtSoPhieuYeuCau.Text = sophieuyeucau.Trim();
                //với vimes cần check lấy số XN
                if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.Vimes)
                {
                    //gọi HIS để cấp code
                    var paraList = new HisParaGetList();
                    var idMayin = NumberConverter.To<int>(objPrintInfo.HisId);
                    idMayin = idMayin == 0 ? 2 : idMayin;

                    paraList.MaBenhAn = sohoSo;
                    paraList.SoPhieuChiDinh = sophieuyeucau;
                    paraList.IDMayInbarcode = idMayin.ToString();
                    LogService.RecordLogFile(LogFile.ActionLog,
                        string.Format("call _iHisService.GetBarcodeFromHis start: {0:yyyy/MM/dd HH:mm:ss fff}",
                            DateTime.Now), this.Text);
                    var data = _iHisService.GetBarcodeFromHis(hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, paraList);
                    LogService.RecordLogFile(LogFile.ActionLog,
                        string.Format("call _iHisService.GetBarcodeFromHis finish: {0:yyyy/MM/dd HH:mm:ss fff}",
                            DateTime.Now), this.Text);

                    if (data.Data != null)
                    {
                        if (data.Data.Rows.Count > 0)
                        {
                            var maLisCode = data.Data.AsEnumerable().Where(x => StringConverter
                                .ToString(x["BarcodeXn"]).Trim().Equals("0"));
                            if (maLisCode.Any())
                            {
                                var noiDung = string.Format(CommonAppVarsAndFunctions.LangMessageConstant.Barcodetrave, maLisCode);
                                if (data.Message != null)
                                {
                                    if (!string.IsNullOrEmpty(data.Message))
                                    {
                                        noiDung += $"\n{CommonAppVarsAndFunctions.LangMessageConstant.PhanhoituHISLA}\n->{data.Message}";
                                    }
                                }

                                ShowMessage(noiDung);
                                var f = new FrmWarningMessage
                                {
                                    NoiDung = $"{CommonAppVarsAndFunctions.LangMessageConstant.SohosoLA}:{txtSoPhieuYeuCau.Text}\n{noiDung}"
                                };
                                f.ShowDialog();

                                return;
                            }
                        }
                        else if (data.Message != null)
                        {
                            if (!string.IsNullOrEmpty(data.Message))
                            {
                                if (data.Code != 0)
                                {
                                    var mess = data.Message;
                                    if (!mess.Equals(CommonAppVarsAndFunctions.LangMessageConstant.Khongcosophieunaoduocmap,
                                        StringComparison.OrdinalIgnoreCase))
                                    {
                                        var noiDung = $"{CommonAppVarsAndFunctions.LangMessageConstant.PhanhoituHISLA}: {data.Message}";
                                        ShowMessage(noiDung);
                                        var f = new FrmWarningMessage
                                        {
                                            NoiDung =
                                                $"{CommonAppVarsAndFunctions.LangMessageConstant.SohosoLA}: {txtSoPhieuYeuCau.Text}\n{noiDung}"
                                        };
                                        f.ShowDialog();

                                        return;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        var noiDung = $"{CommonAppVarsAndFunctions.LangMessageConstant.PhanhoituHISLA}: {data.Message}";
                        ShowMessage(noiDung);
                        var f = new FrmWarningMessage
                        {
                            NoiDung = $"{CommonAppVarsAndFunctions.LangMessageConstant.SohosoLA}: {txtSoPhieuYeuCau.Text}\n{noiDung}"
                        };
                        f.ShowDialog();
                    }

                    if (CommonAppVarsAndFunctions.sysConfig.SuDungBarcodeHIS)
                    {
                        LogService.RecordLogFile(LogFile.ActionLog, "Sử dụng barcode của HIS - Vimes_LayBarcode", this.Text);
                        LogService.RecordLogFile(LogFile.ActionLog,
                            string.Format("call Vimes_LayBarcode({1}) start: {0:yyyy/MM/dd HH:mm:ss fff}",
                                DateTime.Now, sohoSo), this.Text);

                        Vimes_LayBarcode(sohoSo);

                        LogService.RecordLogFile(LogFile.ActionLog,
                            string.Format("call Vimes_LayBarcode({1}) finish: {0:yyyy/MM/dd HH:mm:ss fff}",
                                DateTime.Now, sohoSo), this.Text);
                    }
                }

                var daLayChiDinh = StringConverter.ToString(gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSanh_chidinhTrangThaiChiDinh));

                if (!Check_ChoPhepLayMau(daLayChiDinh)
                    && CommonAppVarsAndFunctions.WorkingHis != HisProvider.DH_DHG && CommonAppVarsAndFunctions.WorkingHis != HisProvider.DH_API
                    && hisInfo.HisID != HisProvider.FPT_SP && hisInfo.HisID != HisProvider.Vimes)
                {
                    CustomMessageBox.MSG_Waring_OK("Bệnh nhân đã tiếp nhận! Hãy hủy trước khi lấy lại.");
                }
                else
                {
                    var allow = true;
                    if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.DH_DHG || CommonAppVarsAndFunctions.WorkingHis == HisProvider.DH_API)
                    {
                        if (!bool.Parse(gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSach_chidinhDongTien).ToString()))
                        {
                            allow = CustomMessageBox.MSG_Question_YesNo_GetYes("BỆNH NHÂN CHƯA TẠM ỨNG HOẶC CHƯA ĐÓNG TIỀN. Tiếp tục tiếp nhận?");
                        }
                    }

                    if (allow)
                    {
                        //Kiểm tra cấp bàn lấy mẫu
                        if (LayBanLayMau(dtpDateIn.Value))
                        {
                            //Thực hiện lấy chỉ định
                            LogService.RecordLogFile(LogFile.ActionLog,
                                string.Format(
                                    "call TiepNhanChidinhHIS({1:yyyy/MM/dd HH:mm:ss fff}) start: {0:yyyy/MM/dd HH:mm:ss fff}",
                                    DateTime.Now, dtpDateIn.Value), this.Text);

                            TiepNhanChidinhHIS(dtpDateIn.Value);
                            if (hisInfo.HisID == HisProvider.PTT_API && chkLayMauKhiTiepNhan.Checked)
                            {
                                UpLoadThoiGianhenTraKQ();
                            }
                            LogService.RecordLogFile(LogFile.ActionLog,
                                string.Format(
                                    "call TiepNhanChidinhHIS({1:yyyy/MM/dd HH:mm:ss fff}) finish: {0:yyyy/MM/dd HH:mm:ss fff}",
                                    DateTime.Now, dtpDateIn.Value), this.Text);
                            CustomMessageBox.CloseAlert();

                            if (hisInfo.HisID == HisProvider.Vimes && chkTuDoiNgay.Checked)
                            {
                                ResetDate();
                            }

                            if ((hisInfo.HisID == HisProvider.AHoi
                                 || hisInfo.HisID == HisProvider.PTT_SP
                                 || hisInfo.HisID == HisProvider.DBTG_HL7_FPT
                                 || hisInfo.HisID == HisProvider.FPT_SP
                                 || hisInfo.HisID == HisProvider.Vimes
                                ) && !chkKhongLoadDanhSach.Checked)
                            {
                                LogService.RecordLogFile(LogFile.ActionLog,
                                    string.Format(
                                        "call btnHisDanhSachCho_Click(sender, e) start: {0:yyyy/MM/dd HH:mm:ss fff}",
                                        DateTime.Now), this.Text);

                                btnHisDanhSachCho_Click(sender, e);

                                LogService.RecordLogFile(LogFile.ActionLog,
                                    string.Format(
                                        "call btnHisDanhSachCho_Click(sender, e) start: {0:yyyy/MM/dd HH:mm:ss fff}",
                                        DateTime.Now), this.Text);
                            }
                            else
                            {
                                gcHisDanhSachBenhNhanCho.DataSource = null;
                                gChiTietChiDinh_His.DataSource = null;
                                txtSoPhieuYeuCau.Focus();
                            }
                        }
                    }
                }

                LogService.RecordLogFile(LogFile.ActionLog,
                    string.Format("btnThucHien_Click Finish: {0:yyyy/MM/dd HH:mm:ss fff}", DateTime.Now));
            }
            catch (Exception ex)
            {
                LogService.RecordLogFile(LogFile.ActionLog,
                    string.Format("btnThucHien_Click Exception: {0}", ex.Message), this.Text);
                CustomMessageBox.CloseAlert();
            }
        }
        private BenhNhanInfoForHIS XuLyChiDinhDaNhap(BenhNhanInfoForHIS bnInfo)
        {
            var bn = bnInfo.CopyHISInfo();
            if (objKhuLayMau.TuThemChiDinhVaoBarcodeGanNhat || objKhuLayMau.KhongChoTiepNhanNhieuLan)
            {
                var dataChinhCu = _informationService.Data_ChiDInhTheoSoHoSo(bnInfo.Bn_id, bnInfo.Sophieuyeucau, bnInfo.Mabn);

                if (dataChinhCu.Rows.Count > 0)
                {
                    var fData = dataChinhCu.AsEnumerable()
                   .Cast<DataRow>().Select(row => new
                   {
                       RSoPhieuYeuCau = StringConverter.ToString(row["RSoPhieuYeuCau"]),
                       BN_ID = StringConverter.ToString(row["bn_id"]),
                       MaBN = StringConverter.ToString(row["MaBN"]),
                       Seq = StringConverter.ToString(row["Seq"]),
                       thoigianchidinhhis = string.IsNullOrEmpty(StringConverter.ToString(row["thoigianchidinhhis"])) ? (DateTime?)null : DateTime.Parse(StringConverter.ToString(row["thoigianchidinhhis"])),
                       MaXN = StringConverter.ToString(row["MaXN"]),
                       MaXN_HIS = StringConverter.ToString(row["maxn_his"]),
                       ThoiGianNhap = DateTime.Parse(StringConverter.ToString(row["ThoiGianNhap"])),
                       NgayTiepNhan = DateTime.Parse(StringConverter.ToString(row["NgayTiepNhan"])),
                       MaTiepNhan = StringConverter.ToString(row["MaTiepNhan"])
                   }).OrderBy(x => x.NgayTiepNhan).ThenBy(n => n.MaXN_HIS);
                    var lstBarcode = new List<string>();
                    if (objKhuLayMau.KhongChoTiepNhanNhieuLan)
                    {  //loại bỏ các xét nghiệm đã tiếp nhận tương ứng số phiếu
                        for (int i = 0; i < bn.ChiDinh.Count; i++)
                        {
                            var item = bn.ChiDinh[i];
                            var found = fData.Where(x => x.MaXN_HIS.Equals(item.TestCode, StringComparison.OrdinalIgnoreCase)
                            && x.RSoPhieuYeuCau.Equals(item.SoPhieuChiDinh, StringComparison.OrdinalIgnoreCase));
                            if (found.Any())
                            {
                                var f = found.GroupBy( x => x.Seq).ToArray();
                                foreach (var s in f)
                                {
                                    if (!lstBarcode.Where(x => x.Equals(s.Key)).Any())
                                    {
                                        lstBarcode.Add(s.Key);
                                    }
                                }
                                bn.ChiDinh.RemoveAt(i);
                                i--;
                            }
                        }
                        if (lstBarcode.Count > 0)
                        {
                            bn.BacrodeDaTiepNhan = string.Join(",", lstBarcode.ToArray());
                        }
                    }
                    if (bn.ChiDinh.Count > 0)
                    {
                        if (objKhuLayMau.TuThemChiDinhVaoBarcodeGanNhat)
                        {
                            //Lấy barcode tiếp nhận gần nhất
                            //1. Tìm mã tiếp nhận gần nhất
                            var lstBarcodeGanNhat = fData.OrderByDescending(x => x.ThoiGianNhap).First();
                            //2. Kiềm tra các xn sẽ thêm không nằm trong mã tiếp nhận này
                            var lstMatiepNhan = fData.Where(x => x.MaTiepNhan.Equals(lstBarcodeGanNhat.MaTiepNhan) && bn.ChiDinh.Where(c => c.TestCode.Equals(x.MaXN_HIS)).Any());
                            if (!lstMatiepNhan.Any())
                            {
                                //Nếu thỏa điều kiện barcode gần nhất chưa có các chỉ định mới này thì lấy thông tin barcode để cho thêm
                                //Không thỏa thì tạo code mới.
                                bn.Seq = lstBarcodeGanNhat.Seq;
                                bn.Ngaytiepnhan = lstBarcodeGanNhat.NgayTiepNhan;
                                bn.Matiepnhan = lstBarcodeGanNhat.MaTiepNhan;
                            }
                        }
                    }
                 
                }
            }
            return bn;
        }
        private bool AllowBNTest(string tenBN)
        {
            if (!CommonAppVarsAndFunctions.sysConfig.TestHISMode) return true;

            if (tenBN.ToLower().Trim().Contains("test"))
                return true;
            CustomMessageBox.MSG_Information_OK("Chỉ cho phép lấy chỉ định các bệnh nhân TEST trong thời gian này!");
            return false;
        }
        private void Vimes_LayBarcode(string soHoSo)
        {
            var lstCheck = new List<string>();
            if (gvChiTietChiDinh_His.SelectedRowsCount > 0)
            {
                gvChiTietChiDinh_His.ExpandAllGroups();
                LogService.RecordLogFile(LogFile.ActionLog, string.Format(
                    "GET_HisOrder {0}:Số hồ sơ: {1} \n\t- Số dòng đang chọn: {2}",
                    DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss fff"), soHoSo,
                    gvChiTietChiDinh_His.SelectedRowsCount), this.Text);

                foreach (int i in gvChiTietChiDinh_His.GetSelectedRows())
                {
                    if (gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhMaDichVu) != null)
                    {
                        lstCheck.Add(string.Format("{0}^{1}^{2}",
                            gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhMaDichVu).ToString().Trim(),
                            gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhSophieuyeucauchitiet).ToString().Trim(),
                            gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhThoigianyeucau).ToString()));
                    }
                }
                if (lstCheck.Count > 0)
                {
                    LoadOrderDetailFromHIS(string.Empty, false, null, dtpHisTuNgayChiDinh.Value.Date, dtpHisTuNgayChiDinh.Value.Date, false, string.Empty, string.Empty, soHoSo);
                    LogService.RecordLogFile(LogFile.ActionLog, string.Format(
                        "GET_HisOrder    - Số dòng đang chọn sau khi load chi tiết: {0}",
                        gvChiTietChiDinh_His.SelectedRowsCount), this.Text);
                    if (gvChiTietChiDinh_His.RowCount > 0)
                    {
                        gvChiTietChiDinh_His.ExpandAllGroups();
                        gvChiTietChiDinh_His.ClearSelection();
                        LogService.RecordLogFile(LogFile.ActionLog, string.Format(
                            "GET_HisOrder    - Số dòng đang chọn sau khi clear select: {0}",
                            gvChiTietChiDinh_His.SelectedRowsCount), this.Text);
                        foreach (var item in lstCheck)
                        {
                            for (int i = 0; i < gvChiTietChiDinh_His.RowCount; i++)
                            {
                                if (gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhMaDichVu) != null)
                                {
                                    var id = string.Format("{0}^{1}^{2}",
                                        gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhMaDichVu).ToString().Trim(),
                                        gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhSophieuyeucauchitiet).ToString().Trim(),
                                        gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhThoigianyeucau).ToString());
                                    if (id.Equals(item))
                                    {
                                        gvChiTietChiDinh_His.SelectRow(i);
                                    }
                                }
                            }
                        }
                    }
                    gChiTietChiDinh_His.Refresh();
                    LogService.RecordLogFile(LogFile.ActionLog, string.Format(
                        "GET_HisOrder    - Số dòng đang chọn sau khi set lại: {0}",
                        gvChiTietChiDinh_His.SelectedRowsCount), this.Text);
                }
            }
        }

        private bool Check_ChoPhepLayMau(string trangThai)
        {
            bool allow;
            if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.FPT_SP)
            {
                allow = trangThai.Trim().Equals(FPTTrangThaiChiDinh.ChuaCap.ToString());
            }
            else
                allow = (!objKhuLayMau.KhongChoTiepNhanNhieuLan || trangThai.Equals("false", StringComparison.OrdinalIgnoreCase) ||
                         trangThai.Trim().Equals("0") || trangThai.Trim().Equals("NW") || string.IsNullOrEmpty(trangThai));

            return allow;
        }

        private void TiepNhanChidinhHIS(DateTime dateServer)
        {
            var sbLogFile = new StringBuilder();
            try
            {
                if (gvChiTietChiDinh_His.SelectedRowsCount <= 0) return;
                DataTable dataPatient = null;
                if(!HISKhongLoaDanhSach_DungSoPhieu())
                { 
                    int rGet = 0;
                    foreach (var i in gvChiTietChiDinh_His.GetSelectedRows())
                    {
                        if (gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhSophieuyeucauchitiet) != null)
                        {
                            rGet = i;
                            break;
                        }
                    }
                    sbLogFile.AppendLine("selectedMaBenhNhan");
                    var cotSophieuyeuCau = string.IsNullOrEmpty(hColumnNames.chidinhSophieuyeucau)
                        ? string.Empty
                        : hColumnNames.chidinhSophieuyeucau;
                    if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.DBTG_HL7_FPT
                        || CommonAppVarsAndFunctions.WorkingHis == HisProvider.FPT_SP)
                    {
                        cotSophieuyeuCau = "mayte";
                    }
                    //Lấy giá trị này đề lấy chính xác mã bệnh nhân của dòng được chọn => lấy đúng tông tin khi his bị lũng số phiếu
                    var selectedSoPhieu = string.Empty;
                    var selectedTenBn = string.Empty;
                    var selectedMaBS = string.Empty;
                    var dtOrder = new DataTable();
                    if (gbLanChiDinh.Visible)
                    {
                        sbLogFile.AppendLine(" - gbLanChiDinh.Visible|selectedSoPhieu ");
                        selectedSoPhieu = dtgLanChiDinh.CurrentRow.Cells[col_ThongTin_chidinhSophieuyeucau.Name].Value
                            .ToString();
                        selectedTenBn = dtgLanChiDinh.CurrentRow.Cells[col_ThongTin_chidinhTenbenhnhan.Name].Value
                            .ToString();
                        cotSophieuyeuCau = col_ThongTin_chidinhSophieuyeucau.DataPropertyName;
                        dtOrder = (DataTable)dtgLanChiDinh.DataSource;
                        sbLogFile.AppendFormat("cotSophieuyeuCau: {0} ", cotSophieuyeuCau);
                    }
                    else if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.FPT_SP)
                    {
                        sbLogFile.AppendLine(" - CommonAppVarsAndFunctions.workingHis == HisProvider.FPT_SP|selectedSoPhieu ");
                        selectedSoPhieu = gvChiTietChiDinh_His.GetRowCellValue(rGet,
                            col_ChiDinh_chidinhMabenhnhan).ToString();
                        selectedTenBn = gvChiTietChiDinh_His.GetRowCellValue(rGet,
                            col_ChiDinh_chidinhTenBenhNhan.Name).ToString();
                        cotSophieuyeuCau = col_ChiDinh_chidinhMabenhnhan.FieldName;
                        sbLogFile.AppendFormat(" - CommonAppVarsAndFunctions.workingHis == HisProvider.FPT_SP|selectedSoPhieu = {0}| selectedTenBn = {1}",
                            selectedSoPhieu, selectedTenBn);
                        var dtOrderTemp = gcHisDanhSachBenhNhanCho.DataSource as DataTable;
                        var dataOrderDetail = (DataTable)gChiTietChiDinh_His.DataSource;

                        var tables = new[] { dtOrderTemp, dataOrderDetail };
                        dtOrder = WorkingServices.MergeAll(tables, cotSophieuyeuCau);
                        if (showDebugData)
                        {
                            CustomMessageBox.ShowRawData(dtOrder, "Dữ liệu khi merge");
                        }
                        sbLogFile.AppendFormat("cotSophieuyeuCau: {0} ", cotSophieuyeuCau);
                        sbLogFile.AppendFormat("cotSophieuyeuCau: {0} ", cotSophieuyeuCau);
                    }
                    else if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.VNPTMN)
                    {
                        sbLogFile.AppendLine(" - CommonAppVarsAndFunctions.workingHis == HisProvider.VNPTMN|selectedSoPhieu ");
                        selectedSoPhieu = gvChiTietChiDinh_His.GetRowCellValue(rGet,
                            col_ChiDinh_chidinhSophieuyeucauchitiet).ToString();
                        //selectedTenBn = gvChiTietChiDinh_His.GetRowCellValue(rGet,
                        //    col_ChiDinh_chidinhTenBenhNhan.Name).ToString();
                        cotSophieuyeuCau = col_ChiDinh_chidinhSophieuyeucauchitiet.FieldName;
                        sbLogFile.AppendFormat(" - CommonAppVarsAndFunctions.workingHis == HisProvider.VNPTMN|selectedSoPhieu = {0}",
                            selectedSoPhieu);
                        var dtOrderTemp = gcHisDanhSachBenhNhanCho.DataSource as DataTable;
                        var dataOrderDetail = (DataTable)gChiTietChiDinh_His.DataSource;
                        if (!dtOrderTemp.Columns.Contains(col_ChiDinh_chidinhSophieuyeucauchitiet.FieldName))
                        {
                            dtOrderTemp.Columns.Add(col_ChiDinh_chidinhSophieuyeucauchitiet.FieldName);
                            foreach (DataRow dataRow in dtOrderTemp.Rows)
                            {
                                dataRow[col_ChiDinh_chidinhSophieuyeucauchitiet.FieldName] = dataRow[col_DanhSanh_chidinhSophieuyeucau.FieldName];
                            }
                        }

                        var tables = new[] { dtOrderTemp, dataOrderDetail };

                        dtOrder = WorkingServices.MergeAll(tables, cotSophieuyeuCau);
                        if (showDebugData)
                        {
                            CustomMessageBox.ShowRawData(dtOrder, "Dữ liệu khi merge");
                        }
                        sbLogFile.AppendFormat("cotSophieuyeuCau: {0} ", cotSophieuyeuCau);
                        sbLogFile.AppendFormat("cotSophieuyeuCau: {0} ", cotSophieuyeuCau);
                    }
                    else
                    {
                        sbLogFile.AppendLine(" - All|selectedSoPhieu ");
                        selectedSoPhieu = StringConverter.ToString(
                            gvChiTietChiDinh_His.GetRowCellValue(rGet,
                                col_ChiDinh_chidinhSophieuyeucauchitiet));

                        selectedTenBn = StringConverter.ToString(
                                gvChiTietChiDinh_His.GetRowCellValue(rGet
                                , col_ChiDinh_chidinhTenBenhNhan));

                        selectedTenBn = StringConverter.ToString(
                                gvChiTietChiDinh_His.GetRowCellValue(rGet
                                , col_ChiDinh_chidinhTenBenhNhan));
                        selectedMaBS = StringConverter.ToString(
                                gvChiTietChiDinh_His.GetRowCellValue(rGet
                                , col_ChiDinh_chidinhMaBacSi));
                        cotSophieuyeuCau = col_ChiDinh_chidinhSophieuyeucauchitiet.FieldName;
                        dtOrder = (DataTable)gChiTietChiDinh_His.DataSource;
                        sbLogFile.AppendFormat("cotSophieuyeuCau: {0} ", cotSophieuyeuCau);
                    }
                    //Lấy lại data table thông tin tương ứng chỉ định đang chọn
                    //Tìm theo số phiếu trước
                    dataPatient = new DataTable();
                    dataPatient = (string.IsNullOrEmpty(cotSophieuyeuCau) ? DataOrder.Copy() : WorkingServices.SearchResult_OnDatatable(dtOrder, string.Format("{0} = '{1}'", cotSophieuyeuCau, WorkingServices.EscapeLikeValue(selectedSoPhieu))));
                    //Tìm theo tên bệnh nhân
                    dataPatient = string.IsNullOrEmpty(selectedTenBn) ? dataPatient : WorkingServices.SearchResult_OnDatatable(dataPatient, string.Format("{0} = '{1}'", hColumnNames.chidinhTenbenhnhan, WorkingServices.EscapeLikeValue(selectedTenBn)));
                    //Tìm theo bs chỉ định
                    dataPatient = string.IsNullOrEmpty(selectedMaBS) ? dataPatient : WorkingServices.SearchResult_OnDatatable(dataPatient, string.Format("{0} = '{1}'", hColumnNames.chidinhMabacsi, WorkingServices.EscapeLikeValue(selectedMaBS)));
                }

                if (CommonAppVarsAndFunctions.sysConfig.SuDungBarcodeHIS)
                    InsertChiDinh_LISCodeTuHIS(dataPatient, dateServer);
                else
                    InsertChiDinh_TuSinhCode(dataPatient, dateServer);

            }
            catch (Exception ex)
            {
                txtBarcode.Text = string.Empty;
                //txtSoPhieuYeuCau.Text = string.Empty;
                gChiTietChiDinh_His.DataSource = null;
                txtSoPhieuYeuCau.Focus();
                txtSoPhieuYeuCau.SelectAll();
                LogService.RecordLogError(CommonAppVarsAndFunctions.UserID, "TiepNhanHis", ex , 0, ex.Message + Environment.NewLine + sbLogFile.ToString(),
                    new StackTrace().GetFrame(0).GetMethod().Name);
                ShowMessage(ex.Message);
                CustomMessageBox.CloseAlert();
            }
        }
        private void InsertChiDinh_TuSinhCode(DataTable dataPatient, DateTime dateServer)
        {
            List<string> lstLISCode = new List<string>();
            var data = DanhSachChiDinhDuocChon(ref lstLISCode);
            if (data.Rows.Count > 0)
            {
                XuLyParseThongTinVaNhapChiDinh(dataPatient, data, dateServer);
            }
        }
        private void InsertChiDinh_LISCodeTuHIS(DataTable dataPatient, DateTime dateServer)
        {
            List<string> lstLISCode = new List<string>();
            var data = DanhSachChiDinhDuocChon(ref lstLISCode);
            if (lstLISCode.Count > 0)
            {
                foreach (var item in lstLISCode)
                {
                    var dataChiDinh = WorkingServices.SearchResult_OnDatatable(data, string.Format("{0} = '{1}'", hColumnNames.chidinhLISCode, item));
                    if (dataChiDinh.Rows.Count > 0)
                    {
                        XuLyParseThongTinVaNhapChiDinh(dataPatient, dataChiDinh, dateServer);
                    }
                }
            }
        }
        private DataTable DanhSachChiDinhDuocChon(ref List<string> lstLISCode)
        {
            DataTable data = new DataTable();
            lstLISCode = new List<string>();
            if (gvChiTietChiDinh_His.SelectedRowsCount > 0)
            {
                data = ((DataTable)gChiTietChiDinh_His.DataSource).Clone();
                foreach (var i in gvChiTietChiDinh_His.GetSelectedRows())
                {
                    if (gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhMaDichVu) == null) continue;
                    var dataOrderRow = gvChiTietChiDinh_His.GetDataRow(i);
                    data.ImportRow(dataOrderRow);
                    var barcode = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhLISCode);
                    if (!lstLISCode.Where(x => x.Equals(barcode)).Any())
                        lstLISCode.Add(barcode);
                }
            }
            return data;
        }
        private bool XuLyParseThongTinVaNhapChiDinh(
            DataTable dataInfo, 
            DataTable dataOrderDetail
            , DateTime dateServer)
        {          
            //Lấy id cho lần tiếp nhận
            var id = ConfigurationDetail.GetNextReceptionTimesID();
            var bnInfo = new BenhNhanInfoForHIS { Giayto_id = id };
            StringBuilder sbLogFile = new StringBuilder();

            sbLogFile.AppendLine(" - Parse patient info ");
            bnInfo = _iHisData.ParseHisPatientInfo((dataInfo == null ? dataOrderDetail.Rows[0]: dataInfo.Rows[0]), hColumnNames, hisInfo.HisID);
            sbLogFile.AppendLine(" - Set special value  ");
            //bnInfo.Sophieuyeucau = selectedSoPhieu;
            bnInfo.Makhuvuc = CommonAppVarsAndFunctions.PCWorkPlace;
            bnInfo.Usernhap = CommonAppVarsAndFunctions.UserID;
            bnInfo.Nguonnhap = InputSourceEnum.ByHIS.ToString();
            bnInfo.Ngaytiepnhan = dateServer.Date;
            sbLogFile.AppendLine(" - Foreach ||\n");
            var chuaThuphi = string.Empty;
            var allowget = true;
            if (string.IsNullOrEmpty(bnInfo.Doituongdichvu))
            {
                CustomMessageBox.MSG_Information_OK("Không có thông tin đối tượng từ HIS trả về.");
                return false;
            }
            var currentOrderDate = dateServer;
            var lstGioChiDinh = new List<DateTime>();
            List<string> chiDinhChaAdded = new List<string>();
            foreach (DataRow dataOrderRow in dataOrderDetail.Rows)
            {
                if (!allowget) continue;
                var chiDInhInfo = new ChiDinhHISInfo();
                sbLogFile.AppendLine(" - LayMaCapTren");
                chiDInhInfo.LayMaCapTren = (CommonAppVarsAndFunctions.WorkingHis != HisProvider.DH_DHG && CommonAppVarsAndFunctions.WorkingHis != HisProvider.DH_API);
                sbLogFile.AppendLine(" - SoPhieuChiDinh");
                chiDInhInfo.SoPhieuChiDinh = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhSophieuyeucauchitiet);
                sbLogFile.AppendLine(" - IDDichVuChiDinh");
                chiDInhInfo.IDDichVuChiDinh = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhidDichvuchidinh);
                sbLogFile.AppendLine(" - TestCode");
                chiDInhInfo.TestCode = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhMadichvu);
                sbLogFile.AppendLine(" - TestName");
                chiDInhInfo.TestName = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhTendv);
                sbLogFile.AppendLine(" - Khuvucnhanid");
                chiDInhInfo.Khuvucnhanid = CommonAppVarsAndFunctions.PCWorkPlace;
                sbLogFile.AppendLine(" - Khuvucthuchienid");
                chiDInhInfo.Khuvucthuchienid = CommonAppVarsAndFunctions.PCWorkPlace;
                sbLogFile.AppendLine(" - Idloaichucnangcls");
                chiDInhInfo.Idloaichucnangcls = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhLoaiChucNangCLSID);
                sbLogFile.AppendLine(" - Idnhomchucnangcls");
                chiDInhInfo.Idnhomchucnangcls = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhNhomChucNangCLSID);
                sbLogFile.AppendLine(" - Iddmchiphi");
                chiDInhInfo.Iddmchiphi = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhDMChiPhiID);
                sbLogFile.AppendLine(" - Bangkeid");
                chiDInhInfo.Bangkeid = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhIdchidinh);
                sbLogFile.AppendLine(" - IDBenh");
                chiDInhInfo.IDBenh = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhMachandoan);
                sbLogFile.AppendLine(" - Thoigiangui");
                chiDInhInfo.Thoigiangui = WorkingServices.GetValueFromDataRow_DateTimeNull(dataOrderRow, hColumnNames.chidinhThoigianyeucau);
                sbLogFile.AppendLine(" - MaLoaiXN_His");
                chiDInhInfo.MaLoaiXN_His = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhMaloai);
                sbLogFile.AppendLine(" - Namkt");
                chiDInhInfo.Namkt = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhNamkt);
                sbLogFile.AppendLine(" - Thangkt");
                chiDInhInfo.Thangkt = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhThangkt);
                sbLogFile.AppendLine(" - MaNhanVienChiDinh");
                chiDInhInfo.MaNhanVienChiDinh = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chiDinhManvChidinh);
                sbLogFile.AppendLine(" - MaBSChiDinh");
                chiDInhInfo.MaBSChiDinh = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhMabacsi);
                sbLogFile.AppendLine(" - TenBSChiDinh");
                chiDInhInfo.TenBSChiDinh = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhTenbacsi);
                sbLogFile.AppendLine(" - MaKhoaChiDinh");
                chiDInhInfo.MaKhoaChiDinh = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhMakhoaphong);
                sbLogFile.AppendLine(" - TenKhoaChiDinh");
                chiDInhInfo.TenKhoaChiDinh = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhTenkhoaphong);
                sbLogFile.AppendLine(" - MaXNCha_His");
                chiDInhInfo.MaXNCha_His = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhidDichvuchidinhcaptren);
                sbLogFile.AppendLine(" - IdChiTiet");
                chiDInhInfo.IdChiTiet = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhIdChiTietChiDinh);
                sbLogFile.AppendLine(" - MaloaimauHIS");
                chiDInhInfo.Maloaimauhis = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhMaLoaiMau);
                sbLogFile.AppendLine(" - TenLoaimauHIS");
                chiDInhInfo.Tenloaimauhis = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhTenLoaiMau);
                sbLogFile.AppendLine(" - ThoiGianLayMau");
                chiDInhInfo.ThoiGianLayMau = WorkingServices.GetValueFromDataRow_DateTimeNull(dataOrderRow, hColumnNames.chidinhThoiGianLayMau);
                sbLogFile.AppendLine(" - NguoiLayMau");
                chiDInhInfo.NguoiLayMau = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhidNguoiLayMau);
                sbLogFile.AppendLine(" - TinhTrangMau");
                chiDInhInfo.TinhTrangMau = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhTinhTrangMau);
                sbLogFile.AppendLine(" - TTNguoiDuocLayMau");
                chiDInhInfo.TTNguoiDuocLayMau = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhTTNguoiDuocLayMau);
                sbLogFile.AppendLine(" - ThoiGianGiaoMau");
                chiDInhInfo.ThoiGianGiaoMau = WorkingServices.GetValueFromDataRow_DateTimeNull(dataOrderRow, hColumnNames.chidinhThoiGianGiaoMau);
                sbLogFile.AppendLine(" - NguoiGiaoMau");
                chiDInhInfo.NguoiGiaoMau = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhNguoiGiaoMau);
                sbLogFile.AppendLine(" - ThoiGianInTem");
                chiDInhInfo.ThoiGianInTem = WorkingServices.GetValueFromDataRow_DateTimeNull(dataOrderRow, hColumnNames.chidinhThoiGianInTem);
                sbLogFile.AppendLine(" - NguoiInTem");
                chiDInhInfo.NguoiInTem = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhNguoiInTem);
                sbLogFile.AppendLine(" - STT");
                chiDInhInfo.STT = WorkingServices.GetValueFromDataRow_IntNull(dataOrderRow, hColumnNames.chidinhBarcodexn);
                sbLogFile.AppendLine(" - Barcode xetnghiem");
                chiDInhInfo.Barcode = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhBarcodexn);
                sbLogFile.AppendLine(" - Mã khoa hiện thời");
                chiDInhInfo.MaKhoaHienThoi = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhMakhoahienthoi);
                sbLogFile.AppendLine(" - Tên khoa hiện thời");
                chiDInhInfo.TenKhoaHienThoi = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhTenkhoahienthoi);
                sbLogFile.AppendLine(" - Bệnh kèm theo");
                chiDInhInfo.BenhKemTheo = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhBenhkemtheo);
                sbLogFile.AppendLine(" - Ngày hết hạn BHYT");
                chiDInhInfo.NgayHetHanBHYT = WorkingServices.GetValueFromDataRow_DateTimeNull(dataOrderRow, hColumnNames.chidinhnNgayhethanbhy);
                sbLogFile.AppendLine(" - Ngày nhập viện");
                sbLogFile.AppendLine(" - Ngày nhập viện");
                chiDInhInfo.NgayNhapVien = WorkingServices.GetValueFromDataRow_DateTimeNull(dataOrderRow, hColumnNames.chidinhNgaynhapvien);
                sbLogFile.AppendLine(" - Ngày vào viện");
                chiDInhInfo.TgVaovien = WorkingServices.GetValueFromDataRow_DateTimeNull(dataOrderRow, hColumnNames.chidinhNgayvaovien);
                sbLogFile.AppendLine(" - Chẩn đoán");
                chiDInhInfo.Chandoan = WorkingServices.GetValueFromDataRow_String(dataOrderRow, hColumnNames.chidinhChandoan);
                sbLogFile.AppendLine(" - Loại xét nghiệm");
                chiDInhInfo.IDLoaiXetNghiem = WorkingServices.GetValueFromDataRow_Int(dataOrderRow, colChiDinh_Loaixetnghiemlis.FieldName); 
                sbLogFile.AppendLine(" - bnInfo.ChiDinh.Add");

                if (chkLayMauKhiTiepNhan.Checked)
                {
                    chiDInhInfo.Laymaukhitiepnhan = true;
                    chiDInhInfo.Pclaymau = Environment.MachineName;
                    chiDInhInfo.Idkhulaymau = idKhuLaymau;
                    chiDInhInfo.Banlaymau = banLayMau;
                    chiDInhInfo.ThoiGianLayMau = tgThucHienLayMau;
                    chiDInhInfo.NguoiLayMau = (string.IsNullOrEmpty(nguoiLayMau) ? CommonAppVarsAndFunctions.UserID : nguoiLayMau);
                }
                //Xử lý thêm xn cha cho trường hợp HL7 của IsofH
                if (hisInfo.HisID == HisProvider.ISofH)
                {
                    if (!string.IsNullOrEmpty(chiDInhInfo.MaXNCha_His) && hisInfo.HisID == HisProvider.ISofH)
                    {
                        if (!chiDinhChaAdded.Any(x => x.Equals(chiDInhInfo.MaXNCha_His)))
                        {
                            var itemCha = chiDInhInfo.CopyHISInfo();
                            itemCha.MaXN_His = itemCha.MaXNCha_His;
                            itemCha.MaXNCha_His = String.Empty;
                            itemCha.TestCode = itemCha.MaXN_His;
                            itemCha.LisAutoAdd = true;
                            bnInfo.ChiDinh.Add(itemCha);
                            chiDinhChaAdded.Add(chiDInhInfo.MaXNCha_His);
                        }
                    }
                }

                bnInfo.ChiDinh.Add(chiDInhInfo);
            }
            bnInfo = XuLyChiDinhDaNhap(bnInfo);

            if (bnInfo.ChiDinh.Count > 0)
            {
                //xử lý insert chỉ định
                if (CommonAppVarsAndFunctions.sysConfig.SuDungBarcodeHIS && !chkBarcodeInSan.Checked)
                {
                    TiepNhanHIS_DungBarcodeHIS(ref sbLogFile, chuaThuphi, bnInfo);
                }
                else
                {
                    var lstDSChuaCapCode = bnInfo.ChiDinh.Where(x => x.Barcode == "0");
                    var lstDSChiDinhDaCapCode = bnInfo.ChiDinh.Where(x => x.Barcode != "0");
                    if (lstDSChiDinhDaCapCode.Any())
                    {
                        bnInfo.ChiDinh = lstDSChiDinhDaCapCode.ToList();
                        StartInsertChiDinhHIS(ref sbLogFile, chuaThuphi, bnInfo, true);
                    }
                    if (lstDSChuaCapCode.Any())
                    {
                        lblMessage.Text =
                            $"{CommonAppVarsAndFunctions.LangMessageConstant.Khongthetiepnhancacchidinhcuasophieu}:\n{string.Join(",", lstDSChuaCapCode.ToList().Select(x => x.Barcode).ToList())}";
                        var f = new FrmWarningMessage { NoiDung = lblMessage.Text };
                        f.ShowDialog();
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(bnInfo.BacrodeDaTiepNhan))
                {
                    CustomMessageBox.MSG_Information_OK(string.Format("Các chỉ định đã được tiếp nhận vào barcode: {0}", bnInfo.BacrodeDaTiepNhan));
                    return false;
                }
            }
            return true;
        }
       
        private void TiepNhanHIS_DungBarcodeHIS(ref StringBuilder log, string chuaThuphi, BenhNhanInfoForHIS bnInfo)
        {
            try
            {
                LogService.RecordLogFile(LogFile.ActionLog,
                    string.Format(
                        "call TiepNhanHIS_DungBarcodeHIS(ref StringBuilder log, string chuaThuphi, BenhNhanInfoForHIS bnInfo) start: {0:yyyy/MM/dd HH:mm:ss fff}",
                        DateTime.Now), this.Text);
                var lstDSBarcode = bnInfo.ChiDinh.GroupBy(x => x.Barcode).Select(grp => grp.First().Barcode).ToList();
                if (lstDSBarcode.Count <= 0) return;
                {
                    //var lstBarcodeFinish = new List<string>();
                    var cannotInsert = false;
                    var haveInsert = false;
                    var lstBn = new List<BENHNHAN_TIEPNHAN>();
                    var lastBarcode = string.Empty;
                    foreach (var item in lstDSBarcode)
                    {
                        if (string.IsNullOrEmpty(item)) continue;

                        var inserObject = bnInfo.CopyHISInfo();
                        inserObject.Seq = item;
                        if (!inserObject.Seq.Trim().Equals("0"))
                        {
                            inserObject.Matiepnhan =
                                ConfigurationDetail.Get_MaTiepNhan(inserObject.Seq, inserObject.Ngaytiepnhan);
                           // chkBarcodeInSan.Checked = true;
                            txtBarcode.Text = item;
                            var objChiDinh = bnInfo.ChiDinh
                                .Where(x => x.Barcode.Equals(item, StringComparison.OrdinalIgnoreCase)).ToList();
                            if (!objChiDinh.Any()) continue;

                            inserObject.Sophieuyeucau = objChiDinh.First().SoPhieuChiDinh;
                            inserObject.ChiDinh = objChiDinh.ToList();

                            var obj = StartInsertChiDinhHIS(ref log, chuaThuphi, inserObject, false, true, true);

                            haveInsert = true;
                            if (chkInBarcodeKhiTiepNhan.Checked && obj != null)
                            {
                                log.AppendLine(" - check :  Add(bnTiepNhanInfo)");
                                lstBn.Add(obj);
                            }

                            lastBarcode = inserObject.Seq;
                        }
                        else
                        {
                            cannotInsert = true;
                        }
                    }

                    txtSoPhieuYeuCau.Text = string.Empty;
                    ShowMessage(string.Empty);
                    if (cannotInsert)
                    {
                        lblMessage.Text = CommonAppVarsAndFunctions.LangMessageConstant.KhongthetiepnhancacchidinhcoLISCode;
                        var f = new FrmWarningMessage {NoiDung = lblMessage.Text};
                        f.ShowDialog();
                    }

                    Get_DanhSachBenhNhan();

                    if (gcDanhSach.DataSource != null && !string.IsNullOrEmpty(lastBarcode))
                        gvDanhSach.FocusedRowHandle = gvDanhSach.LocateByValue(colDS_Barcode.FieldName, lastBarcode);

                    if (lstBn.Any())
                    {
                        log.AppendLine(" - check :  Inbarcode(lstBn)");
                        Inbarcode(lstBn);
                    }

                    if (chkInPhieuHen.Checked && haveInsert)
                    {
                        ShowMessage(string.Format(CommonAppVarsAndFunctions.LangMessageConstant.BANLAYMAULA, banLayMau, soTTLayMau));
                        LoadThongTinPhieuHen();
                        ucGioHenTraKetQua1.SoTTLayMau = soTTLayMau;
                        ucGioHenTraKetQua1.ThoiGianLayMau = tgThucHienLayMau;
                        ucGioHenTraKetQua1.InPhieuHen(false);
                    }
                    else if (hisInfo.HisID == HisProvider.PTT_API && haveInsert)
                    {
                        LoadThongTinPhieuHen();
                        ucGioHenTraKetQua1.SoTTLayMau = soTTLayMau;
                        ucGioHenTraKetQua1.ThoiGianLayMau = tgThucHienLayMau;
                        if (ucGioHenTraKetQua1.DataReturn != null)
                            ucGioHenTraKetQua1.Check_Update_HenTraKetQua(ucGioHenTraKetQua1.DataReturn);
                    }
                    banLayMau = 0;
                    soTTLayMau = 0;
                }
            }
            catch (Exception ex)
            {
                LogService.RecordLogFile(LogFile.ActionLog,
                    string.Format(
                        "call TiepNhanHIS_DungBarcodeHIS(ref StringBuilder log, string chuaThuphi, BenhNhanInfoForHIS bnInfo) error: {0:yyyy/MM/dd HH:mm:ss fff} - {1}",
                        DateTime.Now, ex.Message), this.Text);
            }
            finally
            {
                LogService.RecordLogFile(LogFile.ActionLog,
                    string.Format(
                        "call TiepNhanHIS_DungBarcodeHIS(ref StringBuilder log, string chuaThuphi, BenhNhanInfoForHIS bnInfo) finish: {0:yyyy/MM/dd HH:mm:ss fff}",
                        DateTime.Now), this.Text);
            }
        }
        public void UpLoadThoiGianhenTraKQ()
        {
            if (gvChiDinh_Lis.RowCount >0)
            {
                var paraList = new List<HisParaGetList>();
                
                for (int i = 0; i< gvChiDinh_Lis.RowCount; i++)
                {
                    if (gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_MaDichVu) != null)
                    {
                        if (!string.IsNullOrEmpty(gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_GioHenTraKetQua).ToString()))
                        {
                            var maXNHIS = gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_MaXnHis).ToString();
                            var RIdChiDinhChiTiet = gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_RIdChiDinhChiTiet).ToString();
                            var RidChiDinh = gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_RIdChiDinhHis).ToString();  
                            var RSoPhieuYeuCau = gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_RSoPhieuYeuCau).ToString();
                            var MaTiepNhan = gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_MaTiepNhan).ToString();
                            var TGHenTra = (string.IsNullOrEmpty(gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_GioHenTraKetQua).ToString()) ? (DateTime?)null : DateTime.Parse(gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_GioHenTraKetQua).ToString()));
                            /*
                            "CodeHeader": "1908130042",
                              "ServiceCode": "CLS.XN.0025",
                              "SlipPrintedDetailIdline": "31e28f25-4fef-49f6-9ba5-505bdc6f42af",
                              "ReceptionNumber": "Số tiếp nhận của LIS",
                              "AppointmentDate": "2019/08/12 15:30"
                          */
                            paraList.Add(
                                 new HisParaGetList
                                 {
                                     SoPhieuChiDinh = RSoPhieuYeuCau,
                                     IDChiDinhDichVu = RidChiDinh,
                                     IDChiDinh = RIdChiDinhChiTiet,
                                     MaXetNghiemLIS = maXNHIS,
                                     MaTiepNhanLIS = MaTiepNhan,
                                     NgayHenTraKQ = TGHenTra
                                 });
                        }
                    }
                }
                Task.Factory.StartNew(() =>
                {
                    _iHisService.Update_TGHenTraKetQua(hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, paraList);
                });
            }
        }
        private BENHNHAN_TIEPNHAN StartInsertChiDinhHIS(ref StringBuilder log
            , string chuaThuphi, BenhNhanInfoForHIS bnInfo
            , bool checkInbarcode, bool theoSHS = false, bool dungBarcodeLIS = false)
        {
            try
            {
                bool choThemTuDong = !string.IsNullOrEmpty(bnInfo.Matiepnhan) && !dungBarcodeLIS;

                LogService.RecordLogFile(LogFile.ActionLog,
                    string.Format(
                        "call StartInsertChiDinhHIS(...) start: {0:yyyy/MM/dd HH:mm:ss fff}",
                        DateTime.Now), this.Text);

                BENHNHAN_TIEPNHAN objReturn = null;
                if (chkBarcodeInSan.Checked || CommonAppVarsAndFunctions.sysConfig.SuDungBarcodeHIS)
                {
                    log.AppendLine(" - radBarcodeCoSan");
                    if (string.IsNullOrEmpty(txtBarcode.Text))
                    {
                        ShowMessage(CommonAppVarsAndFunctions.LangMessageConstant.Vuilongnhapsobarcodexetnghiem);
                        txtBarcode.Focus();
                        return null;
                    }

                    bnInfo.Seq = txtBarcode.Text;
                    bnInfo.Matiepnhan = ConfigurationDetail.Get_MaTiepNhan(txtBarcode.Text, bnInfo.Ngaytiepnhan);
                }
                else
                {
                    //Nếu đã có mã tiếp nhận sẵn => đã xử lý lấy barcode gần nhất và tự thêm chỉ định vào
                    if (string.IsNullOrEmpty(bnInfo.Matiepnhan))
                    {
                        log.AppendLine(" - radBarcodeTuDong");
                        var barcode = CommonAppVarsAndFunctions.sysConfig.GenerateSeq(bnInfo.Ngaytiepnhan);
                        if (string.IsNullOrEmpty(barcode))
                        {
                            ShowMessage(string.Format(CommonAppVarsAndFunctions.LangMessageConstant.Barcodetudongkhonghoplevuilongkiemtralai,
                                barcode));
                            return null;
                        }

                        bnInfo.Seq = barcode;
                        bnInfo.Matiepnhan = ConfigurationDetail.Get_MaTiepNhan(barcode, bnInfo.Ngaytiepnhan);
                    }
                }

                if (!string.IsNullOrEmpty(chuaThuphi))
                {
                    CustomMessageBox.MSG_Waring_OK($"{CommonAppVarsAndFunctions.LangMessageConstant.Cacchidinhchuadongtien}: {chuaThuphi}");
                }

                //kiểm tra trùng barcode chưa để xác định cho thêm chỉ định không.
                var allowInsertTest = false;
                log.AppendLine(" - allowInsertTest");
                if ((CommonAppVarsAndFunctions.sysConfig.BarcodeLapLai < 1 || CommonAppVarsAndFunctions.sysConfig.SuDungBarcodeHIS) &&
                    !_iHisData.ExistsBarcode(bnInfo.Seq))
                {
                    allowInsertTest = true;
                }
                else if (CommonAppVarsAndFunctions.sysConfig.BarcodeLapLai > 0 &&
                         !_iHisData.ExistsBarcodeWithday(bnInfo.Seq, CommonAppVarsAndFunctions.sysConfig.BarcodeLapLai))
                {
                    allowInsertTest = true;
                }
                else if (string.IsNullOrEmpty(bnInfo.Mabn))
                {
                    CustomMessageBox.MSG_Information_OK(string.Format(CommonAppVarsAndFunctions.LangMessageConstant.Barcodedasudung, bnInfo.Seq));
                    //allowInsertTest = false;
                }
                else
                {
                    log.AppendLine(" - check : _iHisData.ExistsMaBenhNhanVaBarcode");
                    if (_iHisData.ExistsMaBenhNhanVaBarcode(bnInfo.Mabn, bnInfo.Seq))
                    {
                        allowInsertTest = CustomMessageBox.MSG_Question_YesNo_GetYes(
                            string.Format(CommonAppVarsAndFunctions.LangMessageConstant.ThemchidinhchobenhnhanBarcode, bnInfo.Tenbn,
                                bnInfo.Seq));
                        if (allowInsertTest)
                        {
                            bnInfo.Matiepnhan = _informationService.Get_MaTiepNhanByBarcode(bnInfo.Seq);
                        }
                    }
                    else
                    {
                        CustomMessageBox.MSG_Information_OK(string.Format(
                            CommonAppVarsAndFunctions.LangMessageConstant.Barcodedasudungchobenhnhankhac,
                            bnInfo.Seq));
                        //allowInsertTest = false;
                    }
                }

                if (!allowInsertTest) return null;

                log.AppendLine(" - check : _iHisData.InsertPatientFromHIS");
                ShowMessage(CommonAppVarsAndFunctions.LangMessageConstant.Thuchientiepnhan);

                LogService.RecordLogFile(LogFile.ActionLog,
                    string.Format(
                        "call  _iHisData.InsertPatientFromHIS(...) start: {0:yyyy/MM/dd HH:mm:ss fff}",
                        DateTime.Now), this.Text);

                //set lại thông tin khoa phòng theo test đang cho để đảm bảo thông tin chính xác
                var objinfoFromnOrder = bnInfo.ChiDinh[0];
                bnInfo.Madonvi = objinfoFromnOrder.MaKhoaChiDinh;
                bnInfo.Tendonvi = objinfoFromnOrder.TenKhoaChiDinh;
                bnInfo.Makhoahienthoi = objinfoFromnOrder.MaKhoaHienThoi;
                bnInfo.Tenkhoahienthoi = objinfoFromnOrder.TenKhoaHienThoi;
                bnInfo.Ngayhethanbhyt = objinfoFromnOrder.NgayHetHanBHYT;

                LogService.RecordLogFile(LogFile.ActionLog,
                    string.Format(
                        "call  NgayHenHanBH(...) finish: {0:yyyy/MM/dd HH:mm:ss fff}",
                        objinfoFromnOrder.NgayHetHanBHYT), this.Text);

                bnInfo.Benhkemtheo = objinfoFromnOrder.BenhKemTheo;
                bnInfo.Chandoan = objinfoFromnOrder.Chandoan;
                bnInfo.Tgvaovien = objinfoFromnOrder.TgVaovien;

                LogService.RecordLogFile(LogFile.ActionLog,
                    string.Format(
                        "call  _iHisData.thoigianvaovien(...) finish: {0:yyyy/MM/dd HH:mm:ss fff}",
                         objinfoFromnOrder.TgVaovien), this.Text);

                bnInfo.Ngaynhapvien = objinfoFromnOrder.NgayNhapVien;
                LogService.RecordLogFile(LogFile.ActionLog,
              string.Format(
                  "call  _iHisData.Ngaynhapvien(...) finish: {0:yyyy/MM/dd HH:mm:ss fff}",
                   objinfoFromnOrder.NgayNhapVien), this.Text);

                //Thự hiện insert
                var objInsert = _iHisData.InsertPatientFromHIS(bnInfo
                    , (hisInfo.HisID != HisProvider.VNPTMN), hisInfo
                    , CommonAppVarsAndFunctions.HisFunctionConfigList, CommonAppVarsAndFunctions.sysConfig.SuDungBarcodeHIS);

                LogService.RecordLogFile(LogFile.ActionLog,
                    string.Format(
                        "call  _iHisData.InsertPatientFromHIS(...) finish: {0:yyyy/MM/dd HH:mm:ss fff}",
                        DateTime.Now), this.Text);

                if (string.IsNullOrEmpty(objInsert)) return null;
                {
                    if (CommonAppVarsAndFunctions.gioTinhTgThucHien == enumGioTinhThucHien.ThoiGianNhapCD)
                    {
                        _informationService.Update_ThoiGianThucHienXN(bnInfo.Matiepnhan);
                        LogService.RecordLogFile(LogFile.ActionLog,
                   string.Format(
                       "call  _iHisData.Update_ThoiGianThucHienXN(...) finish: {0:yyyy/MM/dd HH:mm:ss fff}",
                        objinfoFromnOrder.TgVaovien), this.Text);
                        _informationService.Update_ThoiGianThucHienXN_Nhom(bnInfo.Matiepnhan,
                            (int)CommonAppVarsAndFunctions.gioTinhTgThucHien);
                        LogService.RecordLogFile(LogFile.ActionLog,
                   string.Format(
                       "call  _iHisData.Update_ThoiGianThucHienXN_Nhom(...) finish: {0:yyyy/MM/dd HH:mm:ss fff}",
                        objinfoFromnOrder.TgVaovien), this.Text);
                    }

                    txtBarcode.Text = string.Empty;
                    txtSoPhieuYeuCau.Focus();
                    txtSoPhieuYeuCau.Text = string.Empty;

                    //lưu ý load danh sách bn trước khi duyệt để lấy thông tin chỉ định
                    //Bỏ sự kiện combobox trạng thái để set đúng trạng thái tất cả
                    cboTrangThaiLayMau.SelectedIndexChanged -= cboTrangThaiLayMau_SelectedIndexChanged;

                    cboTrangThaiLayMau.SelectedIndex = 0;

                    //if (!chkLayMauKhiTiepNhan.Checked)
                    //{
                    //Dùng cái này vì xử lý tư 5lấy mẫu khi nhận chỉ định rồi
                    LogService.RecordLogFile(LogFile.ActionLog,
                        string.Format(
                            "call   _informationService.Update_TrangThaiLayMau({1}) start: {0:yyyy/MM/dd HH:mm:ss fff}",
                            DateTime.Now, bnInfo.Matiepnhan), this.Text);
                    _informationService.Update_TrangThaiLayMau(bnInfo.Matiepnhan);
                    LogService.RecordLogFile(LogFile.ActionLog,
                        string.Format(
                            "call   _informationService.Update_TrangThaiLayMau({1}) finish: {0:yyyy/MM/dd HH:mm:ss fff}",
                            DateTime.Now, bnInfo.Matiepnhan), this.Text);
                    if(chkLayMauKhiTiepNhan.Checked)
                    {
                        if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCachTinhTAT == (int)enumGioTinhThucHien.ThoiGianLayMau)
                        {
                            _informationService.Update_ThoiGianThucHienXN(bnInfo.Matiepnhan);
                            _informationService.Update_ThoiGianThucHienXN_Nhom(bnInfo.Matiepnhan, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCachTinhTAT);
                        }
                        if (bnInfo.Hisproviderid == (int)HisProvider.DH_API || bnInfo.Hisproviderid == (int)HisProvider.ISofH || bnInfo.Hisproviderid == (int)HisProvider.VNPTMN)
                        {
                            //trả trạng thái về HIS
                            var objreturnHIS = _iHisData.GetDataUploadToHIS(new GetUploadCondit
                            {
                                userID = CommonAppVarsAndFunctions.UserID,
                                matiepnhan = bnInfo.Matiepnhan,
                                onlyValid = false,
                                onlyPrinted = false,
                                arrCatePrint = null,
                                arrtestCodePrint = null,
                                arrTestTypeID = new string[] { },
                                frombackup = false,
                                manualUpload = true,
                                forStatus = true
                            });
                            if(objreturnHIS != null)
                            {
                                if(objreturnHIS.ChiDinh != null)
                                {
                                    bnInfo.ChiDinh = objreturnHIS.ChiDinh;
                                    foreach (var itmChiDinh in bnInfo.ChiDinh)
                                    {
                                        itmChiDinh.TrangThaiMau = OrderStatus.SampleCollect;
                                    }
                                    Task.Factory.StartNew(() => { UpdateTrangThaiVeHIS(new List<BenhNhanInfoForHIS> { bnInfo }); });
                                }
                            }    
                        }
                    }
                    // }
                    //--> tất cả
                    log.AppendLine(" - Get_DanhSachBenhNhan();");
                    dtpDateIn.Value = bnInfo.Ngaytiepnhan;
                    Get_DanhSachBenhNhan();

                    if (gcDanhSach.DataSource != null)
                        gvDanhSach.FocusedRowHandle = gvDanhSach.LocateByValue(colDS_Barcode.FieldName, bnInfo.Seq);

                    //Xử lý lấy các thông tin bs lấy mẫu, vị trí pap
                    if (hisInfo.HisID == HisProvider.DH_API)
                        LayCacThongTinMauTuHIS();
                    cboTrangThaiLayMau.SelectedIndexChanged += cboTrangThaiLayMau_SelectedIndexChanged;

                    if (chkInPhieuHen.Checked)
                    {
                        ShowMessage(string.Format(CommonAppVarsAndFunctions.LangMessageConstant.BANLAYMAULA, banLayMau, soTTLayMau));
                        LoadThongTinPhieuHen();
                        ucGioHenTraKetQua1.SoTTLayMau = soTTLayMau;
                        ucGioHenTraKetQua1.ThoiGianLayMau = tgThucHienLayMau;
                        ucGioHenTraKetQua1.InPhieuHen(false);
                    }
                    else if (hisInfo.HisID == HisProvider.PTT_API)
                    {
                        LoadThongTinPhieuHen();
                        ucGioHenTraKetQua1.SoTTLayMau = soTTLayMau;
                        ucGioHenTraKetQua1.ThoiGianLayMau = tgThucHienLayMau;
                        if (ucGioHenTraKetQua1.DataReturn != null)
                            ucGioHenTraKetQua1.Check_Update_HenTraKetQua(ucGioHenTraKetQua1.DataReturn);
                    }

                    //if (chkLayMauKhiTiepNhan.Checked)
                    //{
                    //    LoadChiDinhXN();
                    //    log.AppendLine(" - UpdateLayMau();");
                    //    LogService.RecordLogFile(LogFile.ActionLog,
                    //        string.Format(
                    //            "call UpdateLayMau() start: {0:yyyy/MM/dd HH:mm:ss fff}",
                    //            DateTime.Now), this.Text);

                    //    UpdateLayMau();
                    //    if (chkInPhieuHen.Checked)
                    //    {
                    //        ShowMessage(string.Format(CommonAppVarsAndFunctions.LangMessageConstant.BANLAYMAULA, banLayMau, soTTLayMau));
                    //        LoadThongTinPhieuHen();
                    //        ucGioHenTraKetQua1.SoTTLayMau = soTTLayMau;
                    //        ucGioHenTraKetQua1.ThoiGianLayMau = tgThucHienLayMau;
                    //        ucGioHenTraKetQua1.InPhieuHen(false);
                    //    }
                    //    else if (hisInfo.HisID == HisProvider.PTT_API)
                    //    {
                    //        LoadThongTinPhieuHen();
                    //        ucGioHenTraKetQua1.SoTTLayMau = soTTLayMau;
                    //        ucGioHenTraKetQua1.ThoiGianLayMau = tgThucHienLayMau;
                    //        if (ucGioHenTraKetQua1.DataReturn != null)
                    //            ucGioHenTraKetQua1.Check_Update_HenTraKetQua(ucGioHenTraKetQua1.DataReturn);
                    //    }
                    //    LogService.RecordLogFile(LogFile.ActionLog,
                    //        string.Format(
                    //            "call UpdateLayMau() finish: {0:yyyy/MM/dd HH:mm:ss fff}",
                    //            DateTime.Now), this.Text);
                    //}
                    //Khi cho thêm tự động không tự in barcode
                    if (chkInBarcodeKhiTiepNhan.Checked && !choThemTuDong)
                    {
                        log.AppendLine(" - check :  Inbarcode(bnTiepNhanInfo)");
                        LogService.RecordLogFile(LogFile.ActionLog,
                            string.Format(
                                "call _informationService.Get_Info_BenhNhan_TiepNhan({1}, null) start: {0:yyyy/MM/dd HH:mm:ss fff}",
                                DateTime.Now, bnInfo.Matiepnhan), this.Text);

                        var bnTiepNhanInfo = _informationService.Get_Info_BenhNhan_TiepNhan(bnInfo.Matiepnhan, null);

                        LogService.RecordLogFile(LogFile.ActionLog,
                            string.Format(
                                "call _informationService.Get_Info_BenhNhan_TiepNhan({1}, null) finish: {0:yyyy/MM/dd HH:mm:ss fff}",
                                DateTime.Now, bnInfo.Matiepnhan), this.Text);

                        if (checkInbarcode)
                        {
                            LogService.RecordLogFile(LogFile.ActionLog,
                                string.Format(
                                    "call Inbarcode(...); start: {0:yyyy/MM/dd HH:mm:ss fff}",
                                    DateTime.Now), this.Text);
                            Inbarcode(new List<BENHNHAN_TIEPNHAN> { bnTiepNhanInfo });
                            LogService.RecordLogFile(LogFile.ActionLog,
                                string.Format(
                                    "call Inbarcode(...); finish: {0:yyyy/MM/dd HH:mm:ss fff}",
                                    DateTime.Now), this.Text);
                        }
                        //objReturn = new BENHNHAN_TIEPNHAN();
                        objReturn = bnTiepNhanInfo;
                    }

                    if (checkInbarcode)
                    {
                        log.AppendLine(" - Get_DanhSachBenhNhan();");

                        LogService.RecordLogFile(LogFile.ActionLog,
                            string.Format(
                                "call Get_DanhSachBenhNhan(...); start: {0:yyyy/MM/dd HH:mm:ss fff}",
                                DateTime.Now), this.Text);
                        Get_DanhSachBenhNhan();

                        LogService.RecordLogFile(LogFile.ActionLog,
                            string.Format(
                                "call Get_DanhSachBenhNhan(...); finish: {0:yyyy/MM/dd HH:mm:ss fff}",
                                DateTime.Now), this.Text);

                        if (gcDanhSach.DataSource != null)
                            gvDanhSach.FocusedRowHandle = gvDanhSach.LocateByValue(colDS_Barcode.FieldName, bnInfo.Seq);
                    }

                }
                if (theoSHS) return objReturn;
                LoadChiDinhXN();
                txtSoPhieuYeuCau.Text = string.Empty;
                ShowMessage(string.Empty);
                return objReturn;
            }
            catch (Exception ex)
            {
                LogService.RecordLogFile(LogFile.ActionLog,
                    string.Format(
                        "call StartInsertChiDinhHIS(...) error: {0:yyyy/MM/dd HH:mm:ss fff} - {1}",
                        DateTime.Now, ex.Message), this.Text);

                return null;
            }
            finally
            {
                LogService.RecordLogFile(LogFile.ActionLog,
                    string.Format(
                        "call StartInsertChiDinhHIS(...) finish: {0:yyyy/MM/dd HH:mm:ss fff}",
                        DateTime.Now), this.Text);
            }
        }
        private void LayCacThongTinMauTuHIS()
        {
            try
            {
                if (gvChiDinh_Lis.RowCount > 0)
                {
                    for (int i = 0; i < gvChiDinh_Lis.RowCount; i++)
                    {
                        if (!string.IsNullOrEmpty(WorkingServices.ObjecToString(gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_RThoiGianChiDinh)))
                            && !string.IsNullOrEmpty(WorkingServices.ObjecToString(gvDanhSach.GetFocusedRowCellValue(colDS_MaBN))))
                        {
                            var loaiXetnghiem = int.Parse(gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_LoaiXetNghiem).ToString());
                            var matiepNhan = gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_MaTiepNhan).ToString();
                            var maxn = gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_MaTiepNhan).ToString();
                            //gọi HIS để cấp code
                            var paraList = new HisParaGetList();
                            var idMayin = NumberConverter.To<int>(objPrintInfo.HisId);
                            idMayin = idMayin == 0 ? 2 : idMayin;
                            paraList.NgayChiDinh = DateTime.Parse(gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_RThoiGianChiDinh).ToString());
                            paraList.MaBenhNhan = gvDanhSach.GetFocusedRowCellValue(colDS_MaBN).ToString();
                            paraList.SoPhieuChiDinh = gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_RSoPhieuYeuCau).ToString();
                            paraList.MaXetNghiemLIS = gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_MaXnHis).ToString();
                            HISReturnBase data = new HISReturnBase();
                            if (loaiXetnghiem == (int)EnumTestType.SinhHocPhanTu)
                            {
                                LogService.RecordLogFile(LogFile.ActionLog,
                                    string.Format("call _iHisService.Get_BsLayMauThuThuat start: {0:yyyy/MM/dd HH:mm:ss fff}",
                                        DateTime.Now), this.Text);
                                data = _iHisService.Get_BsLayMauThuThuat(hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, new List<HisParaGetList>() { paraList });
                                if (data.Data != null)
                                {
                                    if (data.Data.Rows.Count > 0
                                        && !string.IsNullOrEmpty(hColumnNames.chidinhThuthuatBacsimochinh)
                                        && !string.IsNullOrEmpty(hColumnNames.chidinhThuthuatThoigianlaymau))
                                    {
                                        _iXetnghiem.Insert_Update_XetNghiem_LayMauThuThuat(new TestResult.Model.KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT()
                                        {
                                            Matiepnhan = matiepNhan,
                                            Maxn = maxn
                                            ,
                                            Bslaymau = data.Data.Rows[0][hColumnNames.chidinhThuthuatBacsimochinh].ToString()
                                            ,
                                            Thoigianlaymauthuthuat = DateTime.Parse(data.Data.Rows[0][hColumnNames.chidinhThuthuatThoigianlaymau].ToString())
                                        });
                                    }
                                }
                            }
                            else if (loaiXetnghiem == (int)EnumTestType.TBH)
                            {
                                LogService.RecordLogFile(LogFile.ActionLog,
                                    string.Format("call _iHisService.Get_BsLayMauThuThuat start: {0:yyyy/MM/dd HH:mm:ss fff}",
                                        DateTime.Now), this.Text);
                                data = _iHisService.Get_ViTriLayMauPAP(hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, new List<HisParaGetList>() { paraList });
                                if (data.Data != null)
                                {
                                    if (data.Data.Rows.Count > 0
                                        && !string.IsNullOrEmpty(hColumnNames.chidinhVitrimauAmdao)
                                        && !string.IsNullOrEmpty(hColumnNames.chidinhVitrimauCongoai)
                                        && !string.IsNullOrEmpty(hColumnNames.chidinhVitrimauCotrong))
                                    {
                                        _iXetnghiem.Insert_Update_XetNghiem_LayMauThuThuat(new TestResult.Model.KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT()
                                        {
                                            Matiepnhan = matiepNhan,
                                            Maxn = maxn
                                            ,
                                            Maucongoai = bool.Parse(data.Data.Rows[0][hColumnNames.chidinhVitrimauCongoai].ToString())
                                             ,
                                            Maucotrong = bool.Parse(data.Data.Rows[0][hColumnNames.chidinhVitrimauCotrong].ToString())
                                             ,
                                            Mauamdao = bool.Parse(data.Data.Rows[0][hColumnNames.chidinhVitrimauAmdao].ToString())
                                        });
                                    }
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogService.RecordLogFile(LogFile.ActionLog,
                    string.Format(
                        "call LayCacThongTinMauTuHIS(...) error: {0:yyyy/MM/dd HH:mm:ss fff} - {1}",
                        DateTime.Now, ex.Message), this.Text);
            }
        }
        private void Inbarcode(List< BENHNHAN_TIEPNHAN> lstBnInfo, bool isRePrint = false)
        {
            List<KETQUA_CLS_XETNGHIEM> objXetNghiem = null;
            if(objPrintInfo != null)
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
                        objXetNghiem = _iXetnghiem.lstXetnghiem(lstMaTiepNhan, string.Empty);
                        WriteLog.LogService.RecordLogFile(LogFile.ActionLog,
                            string.Format(" InBarcode : BCRoboMT - objXetNghiem -> Số record:{0}", objXetNghiem.Count),
                            this.Text);
                        PrintBarcodeHelper.PrintBarcode(new List<BENHNHAN_TIEPNHAN> { objPrint }, cboTrangThaiLayMau.SelectedIndex, objPrintInfo, isRePrint, null, objXetNghiem);
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
            PrintBarcodeHelper.PrintBarcode(lstBnInfo, cboTrangThaiLayMau.SelectedIndex, objPrintInfo, isRePrint, null, objXetNghiem, null, lblMessage);
        }
        private void txtSoPhieuYeuCau_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtTenBNHis.Text = string.Empty;
            if (e.KeyChar != (char)Keys.Enter) return;
            RemoveEvent_DSbenhNhancho();
            gvHisDanhSachBenhNhanCho.ActiveFilterString = string.Empty;
            LayDanhSachChiDinhTuSoPhieu();
            e.Handled = true;
        }
        private void LayDanhSachChiDinhTuSoPhieu()
        {
            var sophieuyeucau = string.Empty;
            var currentSoPhieuValue = txtSoPhieuYeuCau.Text;
            var currentTenValue = txtTenBNHis.Text;
            if (pnHisDanhSachCho.Visible && !chkKhongLoadDanhSach.Checked)
            {
                if (gvHisDanhSachBenhNhanCho.RowCount == 0)
                {
                    RemoveEvent_DSbenhNhancho();
                    TimBenhNhanCho(true);
                    AddEvent_DSbenhnhancho();
                }
                else
                {
                    RemoveEvent_DSbenhNhancho();
                    TimBenhNhanCho(false);
                    AddEvent_DSbenhnhancho();
                }

                if (gvHisDanhSachBenhNhanCho.RowCount > 0)
                {
                    RemoveEvent_DSbenhNhancho();
                    gvHisDanhSachBenhNhanCho.FocusedRowHandle = 0;
                    if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.DBTG_HL7_FPT || CommonAppVarsAndFunctions.WorkingHis == HisProvider.FPT_SP)
                    {
                        gvHisDanhSachBenhNhanCho.FocusedColumn = col_DanhSanh_chidinhMabenhnhan;
                    }
                    if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.Vimes)
                    {
                        gvHisDanhSachBenhNhanCho.FocusedColumn = col_DanhSanh_chidinhMabenhan;
                    }
                    else
                    {
                        gvHisDanhSachBenhNhanCho.FocusedColumn = col_DanhSanh_chidinhTenbenhnhan;
                    }
                    AddEvent_DSbenhnhancho();
                    //Dư laod detail do tìm đã xử lý load
                    // Check_LoadOrderDetail();
                    Check_TuLayChiDinh();

                }
                else
                    ShowMessage(string.Format(CommonAppVarsAndFunctions.LangMessageConstant.Khongtimthaysophieulammoidanhsach, btnHisDanhSachCho.Text));
            }
            else
            {
                if (!string.IsNullOrEmpty(txtSoPhieuYeuCau.Text) || !string.IsNullOrEmpty(txtTenBNHis.Text))
                {
                    gcHisDanhSachBenhNhanCho.DataSource = null;
                    gChiTietChiDinh_His.DataSource = null;
                    if (HISKHongLoadDanhSach_SoHoSo()
                        || (HISKhongLoaDanhSach_DungSoPhieu() && chkKhongLoadDanhSach.Checked))
                    {
                        var data = LoadOrderDetailFromHIS((HISKhongLoaDanhSach_DungSoPhieu() ? txtSoPhieuYeuCau.Text : string.Empty)
                            , true, null, dtpHisTuNgayChiDinh.Value
                            , null, false, string.Empty, string.Empty
                            , (HISKHongLoadDanhSach_SoHoSo() ? txtSoPhieuYeuCau.Text : string.Empty));
                        if (data == null) return;
                        LoadPatientListFromHIS(true, data.Copy());
                       
                        TimBenhNhanCho(false);
                        if (gvHisDanhSachBenhNhanCho.RowCount == 0)
                            gChiTietChiDinh_His.DataSource = null;

                        if (!objKhuLayMau.TuChonChiDinh)
                        {
                            gvChiTietChiDinh_His.ClearSelection();
                        }
                        Check_TuLayChiDinh();
                    }
                    else
                    {
                        LoadOrderDetailFromHIS(txtSoPhieuYeuCau.Text, true, null, dtpHisTuNgayChiDinh.Value, null, false, string.Empty, string.Empty, string.Empty);
                        Check_TuLayChiDinh();
                    }
                }
            }
            CustomMessageBox.CloseAlert();
            if(gvHisDanhSachBenhNhanCho.RowCount == 0)
            {
                txtSoPhieuYeuCau.Focus();
                txtSoPhieuYeuCau.SelectAll();
            }
        }
        private void Check_TuLayChiDinh()
        {
            gChiTietChiDinh_His.Refresh();

            if (chkTiepNhanKhiNhapBarcode.Checked && gvChiTietChiDinh_His.SelectedRowsCount > 0 && string.IsNullOrEmpty(txtTenBNHis.Text)) 
            {
                if (!string.IsNullOrEmpty(txtSearch.Text))
                {
                    txtSearch.Text = string.Empty;
                }
                if (cboTrangThaiLayMau.SelectedIndex != 0)
                {
                    cboTrangThaiLayMau.SelectedIndexChanged -= cboTrangThaiLayMau_SelectedIndexChanged;
                    cboTrangThaiLayMau.SelectedIndex = 0;
                    cboTrangThaiLayMau.SelectedIndexChanged += cboTrangThaiLayMau_SelectedIndexChanged;
                }
                if (!chkBarcodeInSan.Checked || CommonAppVarsAndFunctions.sysConfig.SuDungBarcodeHIS)
                {
                    btnThucHien_Click(txtSoPhieuYeuCau, new EventArgs());
                }
                else
                {
                    txtBarcode.Focus();
                }
            }
            else
            {
                txtBarcode.Focus();
            }
        }
        private void txtFromBarcode_Enter(object sender, EventArgs e)
        {
            txtSoPhieuYeuCau.SelectAll();
        }

        private void txtFromBarcode_Click(object sender, EventArgs e)
        {
            txtSoPhieuYeuCau.SelectAll();
        }

        private void dtgBenhNhan_DaLayMau_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
   
           // LoadThongTinPhieuHen(); 
        }
        void LoadChiDinhXN()
        {
            if (gvDanhSach.FocusedRowHandle < 0) return;
            var matiepnhan = gvDanhSach.GetFocusedRowCellValue(colDS_MaTiepNhan).ToString();
            Load_DS_ChiDinh(matiepnhan);
            Get_TrangThaiLayMau();
            if (pnPhieuHen.Width > 0)
                LoadThongTinPhieuHen();
        }
        private void CheckEnableBarcode()
        {
            if (chkBarcodeInSan.Checked)
            {
                //grbOption.Visible = false;
                lblBarcode.Text = CommonAppVarsAndFunctions.LangMessageConstant.BARCODELISINSAN_Upper;
                txtBarcode.Visible = true;
                txtBarcode.Enabled = true;
                txtBarcode.Focus();
               // txtSoTem.Enabled = false;
              //  chkTiepNhanKhiNhapBarcode.Checked = true;
              //  chkInBarcodeKhiTiepNhan.Checked = false;
                chkBarcodeInSan.BackColor = CommonAppColors.ColorCheckedSelectedBackColor;
            }
            else
            {
                //grbOption.Visible = true;
                lblBarcode.Text = CommonAppVarsAndFunctions.sysConfig.SuDungBarcodeHIS
                    ? CommonAppVarsAndFunctions.LangMessageConstant.BARCODETUHIS_Upper
                    : CommonAppVarsAndFunctions.LangMessageConstant.BARCODELISTUDONG_Upper;
                txtBarcode.Visible = false;
                txtBarcode.Enabled = false;
               // txtSoTem.Enabled = true;
               // chkInBarcodeKhiTiepNhan.Checked = true;
               // chkTiepNhanKhiNhapBarcode.Checked = false;
                chkBarcodeInSan.BackColor = Color.Empty;
            }
   
          //  _registryExtension.WriteRegistry(CommonConstant.RegistryBarcodeType, chkBarcodeInSan.Checked ? "1" : "0");
        }
        
        private void chkBarcodeCoSan_CheckedChanged(object sender, EventArgs e)
        {
            CheckEnableBarcode();
        }
       
        private void btnSearchSEQ_Click(object sender, EventArgs e)
        {
            var frm = new FrmTimBenhNhan();
            frm.DtDateFromG = dtpHisDenNgayChiDinh.Value;
            frm.WindowState = FormWindowState.Normal;
            frm.List = true;
            frm.pnMenu.Visible = true;
            frm.AdjustForm();
            frm.ShowDialog();
            if (!string.IsNullOrWhiteSpace(frm.ReturnSEQ))
            {
                dtpHisDenNgayChiDinh.Value = frm.ReturnDateIn;
                Load_DS_ChiDinh(ConfigurationDetail.Get_MaTiepNhan(frm.ReturnSEQ, frm.ReturnDateIn));
            }
            frm.Dispose();
        }

      
        private void txtSoTem_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (chkTiepNhanKhiNhapBarcode.Checked)
                {
                    btnThucHien_Click(sender, e);
                }
            }
        }

        private void GetPrinters()
        {
            //try
            //{
            //    ControlExtension.LoadPrinterName(cboPrinters);
            //    var selectedPrinter = _registryExtension.ReadRegistry(CommonConstant.RegistryHisBarcodePrinter);
            //    cboPrinters.SelectedValue = string.IsNullOrWhiteSpace(selectedPrinter) ? null : selectedPrinter;
            //}
            //catch
            //{

            //}
        }
      
        private void FrmTiepNhanHIS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                btnThucHien_Click(sender, e);
                e.Handled = true;
            }
            if (e.KeyCode == Keys.F9)
            {
                btnInBarcode_Click(sender, e);
                e.Handled = true;
            }
            else if (e.Control && e.Shift && e.KeyCode == Keys.D)
            {
                showDebugData = !showDebugData;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CommonAppVarsAndFunctions.ServerTime.Hour == 0 && CommonAppVarsAndFunctions.ServerTime.Minute == 0 && CommonAppVarsAndFunctions.ServerTime.Second < 2)
            {
                dtpDateIn.Value = CommonAppVarsAndFunctions.ServerTime;
                dtpHisTuNgayChiDinh.Value = AppCode.DateTimeConverter.StartOfDay(CommonAppVarsAndFunctions.ServerTime);
                dtpHisDenNgayChiDinh.Value = AppCode.DateTimeConverter.EndOfDay(CommonAppVarsAndFunctions.ServerTime);
            }
        }
     
  
        private void dtpDateIn_ValueChanged(object sender, EventArgs e)
        {
            Get_DanhSachBenhNhan();
        }
        private void gvChiTietChiDinh_His_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (gvChiTietChiDinh_His.FocusedRowHandle > -1)
            {
                if (col_ChiDinh_chidinhidDichvuchidinhcaptren.Visible)
                {
                    var macaptren = (gvChiTietChiDinh_His.GetFocusedRowCellValue(col_ChiDinh_chidinhidDichvuchidinhcaptren) ?? string.Empty).ToString().Trim();
                    var maxnCha = gvChiTietChiDinh_His.GetFocusedRowCellValue(col_ChiDinh_chidinhMaDichVu).ToString().Trim();
                    if (string.IsNullOrEmpty(macaptren))
                    {
                        for (int i = 0; i < gvChiTietChiDinh_His.RowCount; i++)
                        {
                            if (gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhidDichvuchidinhcaptren) != null)
                            {
                                var macaptrenXnCon = gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhidDichvuchidinhcaptren).ToString().Trim();
                                if (!string.IsNullOrEmpty(macaptrenXnCon) && macaptrenXnCon.Equals(maxnCha, StringComparison.OrdinalIgnoreCase))
                                {
                                    gvChiTietChiDinh_His.SelectionChanged -= gvChiTietChiDinh_His_SelectionChanged;
                                    if (e.Action == CollectionChangeAction.Add)
                                        gvChiTietChiDinh_His.SelectRow(i);
                                    else
                                        gvChiTietChiDinh_His.UnselectRow(i);
                                    gvChiTietChiDinh_His.SelectionChanged += gvChiTietChiDinh_His_SelectionChanged;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void btnHisDanhSachCho_Click(object sender, EventArgs e)
        {
            RemoveEvent_DSbenhNhancho();
            LoadPatientListFromHIS();
            TimBenhNhanCho(!(CommonAppVarsAndFunctions.WorkingHis == HisProvider.DH_DHG || CommonAppVarsAndFunctions.WorkingHis == HisProvider.DH_API || CommonAppVarsAndFunctions.WorkingHis == HisProvider.VNPTMN));
            AddEvent_DSbenhnhancho();
            CustomMessageBox.CloseAlert();
        }

        private void dtpHisTuNgayChiDinh_ValueChanged(object sender, EventArgs e)
        {
            gcHisDanhSachBenhNhanCho.DataSource = null;
            gChiTietChiDinh_His.DataSource = null;
        }
        private void dtpHisDenNgayChiDinh_ValueChanged(object sender, EventArgs e)
        {
            gcHisDanhSachBenhNhanCho.DataSource = null;
            gChiTietChiDinh_His.DataSource = null;
        }
        private void TimBenhNhanCho(bool refresh)
        {
            if (gcHisDanhSachBenhNhanCho.DataSource == null && !refresh)
                return;

            CriteriaOperator activeFilter = gvHisDanhSachBenhNhanCho.ActiveFilterCriteria;
            if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.DH_DHG || CommonAppVarsAndFunctions.WorkingHis == HisProvider.DH_API)
            {
                string dath = string.Empty;
                if (radChiDInhDaLay.Checked)
                    dath = string.Format(" and [{0}] = 1", hColumnNames.chidinhTrangThaiChiDinh);
                else if (radHisChiDInhChuaLay.Checked)
                    dath = string.Format(" and [{0}] = 0", hColumnNames.chidinhTrangThaiChiDinh);
                if (gcHisDanhSachBenhNhanCho.DataSource == null)
                    return;

                if (string.IsNullOrEmpty(txtSoPhieuYeuCau.Text))
                {
                    if (!string.IsNullOrEmpty(dath))
                        activeFilter = CriteriaOperator.Parse(dath.Replace("and", ""));
                }
                else
                {
                    var filterString = string.Format("([{1}] = '{0}' or [{2}] = '{0}' or Contains ([{3}],'{0}')){4}"
                        , WorkingServices.EscapeLikeValue(txtSoPhieuYeuCau.Text), hColumnNames.chidinhMabenhnhan
                        , hColumnNames.chidinhSophieuyeucau, hColumnNames.chidinhTenbenhnhan, dath);
                    activeFilter = CriteriaOperator.Parse(filterString);
                }
            }
            else
            {
                if (refresh)
                {
                    var currentSoPhieuValue = txtSoPhieuYeuCau.Text;
                    var currentTenValue = txtTenBNHis.Text;
                    LoadPatientListFromHIS();
                    txtSoPhieuYeuCau.Text = currentSoPhieuValue;
                    txtTenBNHis.Text = currentTenValue;
                }

                if (!string.IsNullOrEmpty(txtSoPhieuYeuCau.Text))
                {
                    var searchVal = WorkingServices.EscapeLikeValue(txtSoPhieuYeuCau.Text);
                    if (!string.IsNullOrEmpty(hColumnNames.chidinhMabenhnhan))
                    {
                        if (activeFilter is null)
                            activeFilter = activeFilter | CriteriaOperator.Parse(string.Format("Contains ([{0}],'{1}')", hColumnNames.chidinhMabenhnhan, searchVal));
                        else
                            activeFilter = CriteriaOperator.Parse(string.Format("Contains ([{0}],'{1}')", hColumnNames.chidinhMabenhnhan, searchVal));
                        activeFilter = activeFilter | CriteriaOperator.Parse(string.Format("{0}='{1}'", hColumnNames.chidinhMabenhnhan, searchVal));
                        activeFilter = activeFilter | CriteriaOperator.Parse(string.Format("Contains ([{0}],'{1}')", hColumnNames.chidinhMabenhnhan
                            , string.Format("{0}{1}{2}", CommonAppVarsAndFunctions.sysConfig.PreffixMaTiepNhanHIS.Replace("%", ""), searchVal, CommonAppVarsAndFunctions.sysConfig.SuffixMaTiepNhanHIS)));
                    }
                    if (!string.IsNullOrEmpty(hColumnNames.chidinhMabenhan))
                    {
                        if (activeFilter is null)
                            activeFilter = activeFilter | CriteriaOperator.Parse(string.Format("[{0}] = '{1}'", hColumnNames.chidinhMabenhan, searchVal));
                        else
                            activeFilter = CriteriaOperator.Parse(string.Format("[{0}] = '{1}'", hColumnNames.chidinhMabenhan, searchVal));
                    }
                    if (!string.IsNullOrEmpty(hColumnNames.chidinhSophieuyeucau) && CommonAppVarsAndFunctions.WorkingHis != HisProvider.DBTG_HL7_FPT && CommonAppVarsAndFunctions.WorkingHis != HisProvider.FPT_SP)
                    {
                        if (activeFilter is null)
                            activeFilter = CriteriaOperator.Parse(string.Format("Contains ([{0}],'{1}')", hColumnNames.chidinhSophieuyeucau, searchVal));
                        else
                            activeFilter = activeFilter | CriteriaOperator.Parse(string.Format("Contains ({0},'{1}')", hColumnNames.chidinhSophieuyeucau, searchVal));
                        activeFilter = activeFilter | CriteriaOperator.Parse(string.Format("[{0}]='{1}'", hColumnNames.chidinhSophieuyeucau, searchVal));
                        activeFilter = activeFilter | CriteriaOperator.Parse(string.Format("Contains ([{0}],'{1}')", hColumnNames.chidinhSophieuyeucau, string.Format("{0}{1}{2}", CommonAppVarsAndFunctions.sysConfig.PreffixMaTiepNhanHIS, searchVal, CommonAppVarsAndFunctions.sysConfig.SuffixMaTiepNhanHIS)));
                    }
                    if (!string.IsNullOrEmpty(hColumnNames.chidinhTenbenhnhan))
                    {
                        if (activeFilter is null)
                            activeFilter = CriteriaOperator.Parse(string.Format("[{0}] = '{1}'", hColumnNames.chidinhTenbenhnhan, searchVal));
                        else
                            activeFilter = activeFilter | CriteriaOperator.Parse(string.Format("[{0}] = '{1}'", hColumnNames.chidinhTenbenhnhan, searchVal));
                    }
                }
                if (hisInfo.HisID != HisProvider.ISofH)
                {
                    string tempFilter = string.Empty;
                    if (radChiDInhDaLay.Checked)
                        tempFilter = string.Format("{0} > 0", hColumnNames.chidinhTrangThaiChiDinh);
                    else if (radHisChiDInhChuaLay.Checked)
                        tempFilter = string.Format("{0} = 0", hColumnNames.chidinhTrangThaiChiDinh);
                    if (!string.IsNullOrEmpty(tempFilter))
                    {
                        if (activeFilter is null)
                            activeFilter = CriteriaOperator.Parse(tempFilter);
                        else
                            activeFilter = activeFilter & CriteriaOperator.Parse(tempFilter);
                    }
                }
                RemoveEvent_DSbenhNhancho();
                gvHisDanhSachBenhNhanCho.ActiveFilterCriteria = activeFilter;
                LogService.RecordLogError(CommonAppVarsAndFunctions.UserID, "TiepNhanHIS", null, 0, (activeFilter ?? string.Empty).ToString(), "");
                AddEvent_DSbenhnhancho();
                if (gvHisDanhSachBenhNhanCho.RowCount == 0 && !refresh)
                {
                    TimBenhNhanCho(true);
                    return;
                }
            }
            if (gvHisDanhSachBenhNhanCho.FocusedRowHandle > -1)
            {
              
                var sophieuyeucau = string.Empty;
                var fileterColumn = colDS_SoPhieu.FieldName;
                if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.DBTG_HL7_FPT || CommonAppVarsAndFunctions.WorkingHis == HisProvider.FPT_SP)
                {
                    sophieuyeucau = gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSanh_chidinhMabenhnhan).ToString();
                    fileterColumn = colDS_MaBN.FieldName;
                }
                else
                    sophieuyeucau = gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSanh_chidinhSophieuyeucau).ToString();
                Set_ViTriBNTiepNhan(fileterColumn, sophieuyeucau);
                GvHisDanhSachBenhNhanCho_FocusedRowChanged(gvHisDanhSachBenhNhanCho, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(-1, gvHisDanhSachBenhNhanCho.FocusedRowHandle));
            }
        }
        private void RemoveEvent_DSbenhNhancho()
        {
            gvHisDanhSachBenhNhanCho.FocusedRowChanged -= GvHisDanhSachBenhNhanCho_FocusedRowChanged;
            gvHisDanhSachBenhNhanCho.FocusedColumnChanged -= GvHisDanhSachBenhNhanCho_FocusedColumnChanged;
        }
        private void AddEvent_DSbenhnhancho()
        {
            //Gọi remove để đảm bảo các sự kiện bên trong có gọi add khôgn bị add nhiều lần làm load chậm
            RemoveEvent_DSbenhNhancho();
            gvHisDanhSachBenhNhanCho.FocusedRowChanged += GvHisDanhSachBenhNhanCho_FocusedRowChanged;
            gvHisDanhSachBenhNhanCho.FocusedColumnChanged += GvHisDanhSachBenhNhanCho_FocusedColumnChanged;
        }
        private void mnuMapMaXN_Click(object sender, EventArgs e)
        {
            if (gvChiTietChiDinh_His.GetRowCellValue(gvChiTietChiDinh_His.FocusedRowHandle, col_ChiDinh_chidinhMaDichVu) != null)
            {
                var f = new FrmCauHinh_MappingHIS();
                f.currentHis = CommonAppVarsAndFunctions.WorkingHis;
                f.ActiveSearchValue = gvChiTietChiDinh_His.GetRowCellValue(gvChiTietChiDinh_His.FocusedRowHandle, col_ChiDinh_chidinhMaDichVu).ToString().Trim(); //gvData.GetFocusedRowCellValue(col_ChiDinh_chidinhMaDichVu).ToString();
                f.pnFormControl.Visible = true;
                f.pnContaint.Padding = new Padding(3);
                f.ShowDialog();
            }
        }
        private void mnuThemXNMapping_Click(object sender, EventArgs e)
        {
            if (gvChiTietChiDinh_His.SelectedRowsCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Thêm mới mapping cho các chỉ định đang chọn?"))
                {
                    var mappingCheck = new Lab.BusinessService.Models.XetNghiemHISInfo();
                    string lastCode = string.Empty;
                    foreach (var i in gvChiTietChiDinh_His.GetSelectedRows())
                    {
                        if (gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhMaDichVu) == null)
                            continue;
                        mappingCheck = new Lab.BusinessService.Models.XetNghiemHISInfo();
                        var madmHIS = gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhMaDichVu).ToString();
                        var tendmHIS = gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhTenDV).ToString();
                        var masterId = (gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhidDichvuchidinhcaptren) ?? (string.Empty)).ToString();
                        var loaidvHIS = (gvChiTietChiDinh_His.GetRowCellValue(i, col_ChiDinh_chidinhMaloai) ?? (string.Empty)).ToString();
                        mappingCheck.HisProviderID = (int)hisInfo.HisID;
                        mappingCheck.madichvu = madmHIS;
                        mappingCheck.macaptren = masterId;
                        mappingCheck.tendichvu = tendmHIS;
                        mappingCheck.loaidvHIS = loaidvHIS;
                        mappingCheck.NguoiNhap = CommonAppVarsAndFunctions.UserID;
                        lastCode = madmHIS;
                        Lab.BusinessService.Services.XetNghiemHISService.GetInstance().SyncXetNghiem(mappingCheck);
                    }
                    var f = new FrmCauHinh_MappingHIS();
                    f.currentHis = hisInfo.HisID;
                    f.ActiveSearchValue = lastCode;
                    f.pnFormControl.Visible = true;
                    f.pnContaint.Padding = new Padding(3);
                    f.ShowDialog();
                }
            }
        }
        private void chkInBarcodeKhiTiepNhan_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(CommonConstant.RegistryPrintBarcodePrinter, chkInBarcodeKhiTiepNhan.Checked ? "1" : "0");
            chkInBarcodeKhiTiepNhan.BackColor = (chkInBarcodeKhiTiepNhan.Checked ? CommonAppColors.ColorCheckedSelectedBackColor : this.BackColor);
        }
        private void chkTiepNhanKhiNhapBarcode_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(CommonConstant.RegistryGetOrderWhenPressEnter, chkTiepNhanKhiNhapBarcode.Checked ? "1" : "0");
            chkTiepNhanKhiNhapBarcode.BackColor = (chkTiepNhanKhiNhapBarcode.Checked ? CommonAppColors.ColorCheckedSelectedBackColor : this.BackColor);
        }

        private void txtSoTem_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoPhieuYeuCau_KeyUp(object sender, KeyEventArgs e)
        {

            //if (!(e.KeyCode == Keys.Enter) && string.IsNullOrEmpty(txtSoPhieuYeuCau.Text.Trim()))
            //    bvHisDanhSachBenhNhanCho.BindingSource.RemoveFilter();
            //e.Handled = true;
        }

        private void radHisTrangThaiChiDinh_CheckedChanged(object sender, EventArgs e)
        {
            if (!isSettingConfig)
            {
                var rad = (RadioButton)sender;
                if (rad.Checked)
                {
                    if (chkKhongLoadDanhSach.Checked)
                    {
                        if (!string.IsNullOrEmpty(txtSoPhieuYeuCau.Text.Trim()))
                        {
                            LayDanhSachChiDinhTuSoPhieu();
                        }
                    }
                    else
                    {
                        TimBenhNhanCho(!(CommonAppVarsAndFunctions.WorkingHis == HisProvider.DH_DHG || CommonAppVarsAndFunctions.WorkingHis == HisProvider.DH_API));
                    }
                }
            }
        }
                

        private void Set_ViTriBNTiepNhan(string filterColumnName, string sophieuyeucau)
        {
            var posFind = gvDanhSach.LocateByValue(filterColumnName,
                     WorkingServices.EscapeLikeValue(sophieuyeucau));
            if (posFind > -1)
                gvDanhSach.FocusedRowHandle = posFind;
        }
        private void Check_LoadOrderDetail(bool findDaTiepNhan = true)
        {
            if (gvHisDanhSachBenhNhanCho.FocusedRowHandle > -1)
            {
                var sophieuyeucau = string.Empty;
                var fileterColumn = "SoPhieuYeuCau";
                if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.DBTG_HL7_FPT || CommonAppVarsAndFunctions.WorkingHis == HisProvider.FPT_SP)
                {
                    sophieuyeucau = gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSanh_chidinhMabenhnhan).ToString();
                    fileterColumn = "MaBN";
                }
                else
                    sophieuyeucau = gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSanh_chidinhSophieuyeucau).ToString();

                var ngaychiDinh = (gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSach_chidinhNgaychidinh) == null ? (DateTime?)null : DateTime.Parse(gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSach_chidinhNgaychidinh).ToString()));
                var noiTru = (string.IsNullOrEmpty(hColumnNames.chidinhNoitru) ? false : gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSach_chidinhNoitru) == null ? false
                    : (bool.Parse(gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSach_chidinhNoitru).ToString())));
                var noitruChu = string.IsNullOrEmpty(hColumnNames.chidinhNoitruchu) ? false : gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSach_chidinhNoitruchu).ToString().Equals("I");
                var trangThaichiDinh = gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSanh_chidinhTrangThaiChiDinh) == null ? "0" : gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSanh_chidinhTrangThaiChiDinh).ToString();
                var idBenhNhan = gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSach_chidinhGiayToID) == null ? string.Empty : gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSach_chidinhGiayToID).ToString();
                var maBenhNhan = gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSanh_chidinhMabenhnhan) == null ? string.Empty : gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSanh_chidinhMabenhnhan).ToString();
                var soHoSo = gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSanh_chidinhMabenhan) == null ? string.Empty : gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSanh_chidinhMabenhan).ToString();
             
                var maSotimKiem = string.Empty;
                if (hisInfo.HisID.Equals(HisProvider.Vimes) || hisInfo.HisID.Equals(HisProvider.ISofH))
                    maSotimKiem = soHoSo;
                else
                    maSotimKiem = sophieuyeucau;

                if (findDaTiepNhan)
                    Set_ViTriBNTiepNhan(fileterColumn, sophieuyeucau);

                if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.DH_DHG || CommonAppVarsAndFunctions.WorkingHis == HisProvider.DH_API)
                {
                    var DataOrderList = WorkingServices.SearchResult_OnDatatable_NoneSort(DataOrder, string.Format("{0} = '{1}' and {2} = {3} and {4} = '{5}'", hColumnNames.chidinhSophieuyeucau
                        , sophieuyeucau, hColumnNames.chidinhTrangThaiChiDinh, trangThaichiDinh
                        ,hColumnNames.chidinhNgaychidinh, ngaychiDinh));
                    DataOrderList =  _iHisData.MergeMappingLIS(DataOrderList, hColumnNames, (int)CommonAppVarsAndFunctions.WorkingHis, dataMapping);
                    foreach (DataRow dtR in DataOrderList.Rows)
                    {
                        var trangThai = dtR[hColumnNames.chidinhTrangThaiChiDinh].ToString();
                        if (trangThai.Trim() == "2")
                            dtR["trangthaichidinh"] = "Đã lấy mẫu";
                        else if (trangThai.Trim() == "1")
                            dtR["trangthaichidinh"] = "Đã có kết quả";
                        else if (trangThai.Trim() == "0")
                            dtR["trangthaichidinh"] = "Chờ lấy mẫu";
                    }

                    LoadOrderDetailFromHIS(sophieuyeucau, false, DataOrderList, ngaychiDinh);
                }
                else if (hisInfo.HisID.Equals(HisProvider.ISofH))
                {
                    var DataOrderList = WorkingServices.SearchResult_OnDatatable_NoneSort(DataOrder, string.Format("{0} = '{1}' and {2} = '{3}' and {4} = '{5}'", hColumnNames.chidinhSophieuyeucau
                        , sophieuyeucau, hColumnNames.chidinhTrangThaiChiDinh, trangThaichiDinh
                        , hColumnNames.chidinhNgaychidinh, ngaychiDinh));
                    DataOrderList = _iHisData.MergeMappingLIS(DataOrderList, hColumnNames, (int)CommonAppVarsAndFunctions.WorkingHis, dataMapping);
                    //foreach (DataRow dtR in DataOrderList.Rows)
                    //{
                    //    var trangThai = dtR[hColumnNames.chidinhTrangThaiChiDinh].ToString();
                    //    if (trangThai.Trim() == "2")
                    //        dtR["trangthaichidinh"] = "Đã lấy mẫu";
                    //    else if (trangThai.Trim() == "1")
                    //        dtR["trangthaichidinh"] = "Đã có kết quả";
                    //    else if (trangThai.Trim() == "0")
                    //        dtR["trangthaichidinh"] = "Chờ lấy mẫu";
                    //}

                    LoadOrderDetailFromHIS(String.Empty, false, DataOrderList, ngaychiDinh, soHoSo: soHoSo);
                }
                else if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.FPT_SP)
                {
                    if (gbLanChiDinh.Visible)
                    {
                        LoadThongTinChiTiet(maBenhNhan, idBenhNhan, sophieuyeucau, (ngaychiDinh == null ? ngaychiDinh : ngaychiDinh.Value.Date));
                    }
                    LoadOrderDetailFromHIS(string.Empty, false, null,
                        (ngaychiDinh == null ? ngaychiDinh : ngaychiDinh.Value.Date)
                        , (ngaychiDinh == null ? ngaychiDinh : ngaychiDinh.Value.Date)
                        , (noitruChu ? noitruChu : noiTru), idBenhNhan, maBenhNhan, soHoSo);
                }
                else
                    LoadOrderDetailFromHIS(sophieuyeucau, false, null
                        , (ngaychiDinh == null ? ngaychiDinh : ngaychiDinh.Value.Date)
                        , (ngaychiDinh == null ? ngaychiDinh : ngaychiDinh.Value.Date)
                        , (noitruChu ? noitruChu : noiTru), idBenhNhan, maBenhNhan, soHoSo);
            }
        }
       

        private void FrmTiepNhanHIS_Shown(object sender, EventArgs e)
        {
            ShowMessage(CommonAppVarsAndFunctions.LangMessageConstant.LoadingConfigHIS);
            objKhuLayMau = _iSysConfig.Get_Info_dm_khulaymau_Theomaytinh(Environment.MachineName);

            dtpHisTuNgayChiDinh.ValueChanged -= dtpHisTuNgayChiDinh_ValueChanged;
            Load_HisProvider();
            hisInfo = CommonAppVarsAndFunctions.HisConnectList.Where(x => x.HisID == CommonAppVarsAndFunctions.WorkingHis).FirstOrDefault();
            Set_HisConfig(CommonAppVarsAndFunctions.WorkingHis);
            chkBarcodeInSan.Enabled = objKhuLayMau.CoTemInSan; CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, UserConstant.PermissionReceptionFromHISWithManualCode);
            if (!chkBarcodeInSan.Enabled)
                chkBarcodeInSan.Checked = false;

            CheckEnableBarcode();

            chkInBarcodeKhiTiepNhan.Checked = _registryExtension.ReadRegistry(CommonConstant.RegistryPrintBarcodePrinter) == "1";
            chkTiepNhanKhiNhapBarcode.Checked = _registryExtension.ReadRegistry(CommonConstant.RegistryGetOrderWhenPressEnter) == "1";
            chkLayMauKhiTiepNhan.Checked = _registryExtension.ReadRegistry(CommonConstant.RegistryAutoCompleteGetSample) == "1";
            chkChiTietChiDinhHis.Checked = _registryExtension.ReadRegistry(CommonConstant.RegistryReceptionHIS_ShowDetail) == "1";
            chkInPhieuHen.Checked = _registryExtension.ReadRegistry(CommonConstant.RegistryPrintReturnTicket) == "1";
            chkInPhieuHen.Visible = objKhuLayMau.CoPhieuHen;
            btnShowPhieuHen.Visible = objKhuLayMau.CoPhieuHen;
            if (!chkInPhieuHen.Visible)
                chkInPhieuHen.Checked = false;
            Get_DanhSachBenhNhan();
            dtpHisTuNgayChiDinh.ValueChanged += dtpHisTuNgayChiDinh_ValueChanged;
            dtpDateIn.ValueChanged += dtpDateIn_ValueChanged;

            if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemChonKhuLayMau)
            {
                var f = new FmChonKhulayMau();
                f.pnMenu.Visible = true;
                f.AdjustForm();
                f.userId = CommonAppVarsAndFunctions.UserID;
                f.ShowDialog();
                if (!string.IsNullOrEmpty(f.IDKhuLayMau))
                {
                    idKhuLaymau = f.IDKhuLayMau;
                    lblTitle.Text += $"{CommonAppVarsAndFunctions.LangMessageConstant.MsgTRUKHULAYMAU_Upper}: {f.TenKhuLayMau.ToUpper()}";
                }
                else
                {
                    lblTitle.Text += CommonAppVarsAndFunctions.LangMessageConstant.TRUCHUAKHAIBAOKHULAYMAU_Upper;
                }
            }
            else
                idKhuLaymau = objKhuLayMau.Idkhulaymau;

            Load_DanhSachCauHinhMayin();

            if (!string.IsNullOrEmpty(objKhuLayMau.Tenkhulaymau))
                lblTitle.Text += string.Format(" - {0}", objKhuLayMau.Tenkhulaymau.ToUpper());
            if (objKhuLayMau.Tulaymaukhitiepnhan)
            {
                chkTiepNhanKhiNhapBarcode.Enabled = true;
                chkLayMauKhiTiepNhan.Enabled = true;
                btnLayLaiMau.Visible = true;
            }
            else
            {
                chkTiepNhanKhiNhapBarcode.Enabled = false;
                chkTiepNhanKhiNhapBarcode.Checked = false;
                btnLayLaiMau.Visible = false;
                chkLayMauKhiTiepNhan.Enabled = false;
                chkLayMauKhiTiepNhan.Checked = false;
            }
            ControlExtension.BindDataToCobobox(_iSysConfig.Data_DanhMucTinhTrangMau(0), ref cboLyDo, "MaTinhTrang", "MaTinhTrang", "MaTinhTrang,TinhTrangMau", "45,150", txtLyDo, 1);
            dtpDateIn.Value = CommonAppVarsAndFunctions.ServerTime;
            cboLyDo.SelectedIndexChanged += cboLyDo_SelectedIndexChanged;
            //splitContainer3.SplitterPosition = (flpNgayChiDinh.Visible ? splitContainer3.SplitterPosition : splitContainer3.SplitterPosition - flpNgayChiDinh.Height);
            ucGioHenTraKetQua1.LoadCauHinh();
            ucGioHenTraKetQua1.InGioHen = objKhuLayMau.InGiohen;
            splitContainer1.SplitterPosition = cboHISProvider.Location.X + cboHISProvider.Width;
            splitContainer3.SplitterPosition = (pnChoTiepNhan.Height + flowLayoutPanelTimHIS.Height + flpNgayChiDinh.Height);
            if(objKhuLayMau.ChonNguoiLayMau)
            {
                ucSearchLookupEditor_NguoiDungDKLayMau1.Enabled = true;
                ucSearchLookupEditor_NguoiDungDKLayMau1.Load_NhanVienDKLayMau();
            }
            else
                ucSearchLookupEditor_NguoiDungDKLayMau1.Enabled = false;

            txtSoPhieuYeuCau.Focus();
            ShowMessage(CommonAppVarsAndFunctions.LangMessageConstant.SanSang);
        }
        private void cboLyDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLyDo.SelectedIndex > -1)
            {
                var value = cboLyDo.SelectedValue.ToString();
                txtLyDo.ReadOnly = !value.Equals("lydokhac", StringComparison.OrdinalIgnoreCase);
            }
            else
                txtLyDo.ReadOnly = true;
        }
        private void Load_DanhSachCauHinhMayin()
        {
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
            cboMayInTem1.DataSource = data;
            cboMayInTem1.ValueMember = "IDMay";
            cboMayInTem1.DisplayMember = "TenMay";
            cboMayInTem1.ColumnNames = "IDMay,TenMay";
            cboMayInTem1.ColumnWidths = "15,150";
            cboMayInTem1.SelectedValue = string.IsNullOrEmpty(idMay) ? "0" : idMay;
            cboMayInTem1.SelectedIndexChanged += CboMayInTem_SelectedIndexChanged;
            Load_PrintConfig();
        }
        private void CboMayInTem_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_PrintConfig();
        }
        private void FrmTiepNhanHIS_Load(object sender, EventArgs e)
        {
           
            ControlExtension.SetLowerCaseForXGridColumns(gvChiDinh_Lis);
            ControlExtension.SetLowerCaseForXGridColumns(gvDanhSach);
            _PainterChuaLayMau = new GridSkinElementsPainter(gvChiDinh_Lis);
            chkUpdateAll.Visible = btnUpdateThongTin.Visible = CommonAppVarsAndFunctions.UserID.Trim().Equals("admin", StringComparison.OrdinalIgnoreCase);
            var fparent = (frmParent_old)this.TopLevelControl;
            mnuThemXNMapping.Enabled = mnuMapMaXN.Enabled = fparent.rbDanhMucXetNghiem.Enabled;
            pnPhieuHen.Size = new Size(pnPhieuHen.Width, 0);
            gvHisDanhSachBenhNhanCho.FocusedRowChanged += GvHisDanhSachBenhNhanCho_FocusedRowChanged;
            gvHisDanhSachBenhNhanCho.FocusedColumnChanged += GvHisDanhSachBenhNhanCho_FocusedColumnChanged;
            gvChiTietChiDinh_His.SelectionChanged += gvChiTietChiDinh_His_SelectionChanged;
            Load_XnGuiMau();
            Load_DSKhuVuc();
            
        }

        private void GvHisDanhSachBenhNhanCho_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (!chkKhongLoadDanhSach.Checked)
                Check_LoadOrderDetail();
        }

        private void GvHisDanhSachBenhNhanCho_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!chkKhongLoadDanhSach.Checked)
                Check_LoadOrderDetail();
        }

        private void btnUpdateThongTin_Click(object sender, EventArgs e)
        {
            CapNhat_NgayChiDinh();
        }
        private string KiemTraThemKhoatrangChoTenLoaiMau(string giaTriTen)
        {
            var returnTen = giaTriTen.Trim();
            giaTriTen = Utilities.ChuyenTvKhongDau(giaTriTen);
            var giatrilen = Encoding.Default.GetByteCount(giaTriTen);
            if (giaTriTen.Equals("PHAN", StringComparison.OrdinalIgnoreCase)
                || giaTriTen.Equals("DIEN DI", StringComparison.OrdinalIgnoreCase))
                giatrilen = 6;
            else if (giaTriTen.Equals("HEPARIN", StringComparison.OrdinalIgnoreCase)
                || giaTriTen.Equals("KHI MAU", StringComparison.OrdinalIgnoreCase))
            {
                returnTen = returnTen + "  ";
                giatrilen = Encoding.Default.GetByteCount(returnTen);
            }
            else if (giaTriTen.Equals("URINE", StringComparison.OrdinalIgnoreCase)
                || giaTriTen.Equals("SHPT", StringComparison.OrdinalIgnoreCase))
            {
                returnTen = returnTen + "   ";
                giatrilen = Encoding.Default.GetByteCount(returnTen);
            }
            else if (giaTriTen.Equals("VI SINH", StringComparison.OrdinalIgnoreCase))
            {
                returnTen = returnTen + "  ";
                giatrilen = Encoding.Default.GetByteCount(returnTen);
            }
            if (giatrilen < 16)
            {
                if (giatrilen >= 7)
                    returnTen += "\t";
                else
                    returnTen += "\t\t";
            }
            return returnTen;
        }
        #region Sự kiện cho lưới chưa lấy mẫu

        private void gvChiDinhLis_CustomDrawGroupRow(object sender,
            DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            var ghiChuLayMau = CommonAppVarsAndFunctions.LangMessageConstant.Ghichulaymau;
            var ongMau = CommonAppVarsAndFunctions.LangMessageConstant.Ongmau;
            var slMau = CommonAppVarsAndFunctions.LangMessageConstant.SLMau;
   
            if (!string.IsNullOrEmpty(info.GroupText))
            {
                if (info.Column.Name == colChiDinhLis_TenNhomLoaiMau.Name && info.Level == 2)
                {
                    // info.Bounds = new Rectangle(info.Bounds.Location.X, info.Bounds.Location.Y, info.Bounds.Width, 70);
                    // info.RowLineHeight = 70;
                    int handle = gvChiDinh_Lis.GetChildRowHandle(e.RowHandle, 0);
                    string text = gvChiDinh_Lis.GetGroupRowDisplayText(e.RowHandle);

                    text = text.Replace($"- {ghiChuLayMau}: ,", ",")
                        .Replace($"{CommonAppVarsAndFunctions.LangMessageConstant.Ongmau}:",
                            $"{ongMau}:        ").Replace(" - ", "\t-\t")
                        .Replace(", ", "\t-\t")
                        .Replace(info.GroupValueText, KiemTraThemKhoatrangChoTenLoaiMau(info.GroupValueText));

                    int textY = e.Bounds.Location.Y +
                                (e.Bounds.Height -
                                 Convert.ToInt32(e.Graphics.MeasureString(text, e.Appearance.Font).Height)) / 2;
                    info.ButtonBounds.Y = textY;

                    _PainterChuaLayMau.GroupRow.DrawGroupRowBackground(info);
                    _PainterChuaLayMau.OpenCloseButton.DrawObject(new OpenCloseButtonInfoArgs(e.Cache,
                        info.ButtonBounds, info.GroupExpanded, info.AppearanceGroupButton, ObjectState.Normal));

                    info.UpdateSelectorState();

                    var rect = info.SelectorInfo.Bounds;
                    rect.Y = textY;
                    rect.X = info.ButtonBounds.Right + 12;

                    info.SelectorInfo.Bounds = rect;
                    info.SelectorInfo.GlyphRect = rect;
                    info.SelectorInfo.CaptionRect = new Rectangle(rect.X + rect.Width, rect.Y, -3, 1);

                    ObjectPainter.DrawObject(e.Cache, info.SelectorPainter, info.SelectorInfo);
                    bool haveGhiChu =
                        text.Contains($"-\t{ghiChuLayMau}:");
                    Point textPos = GetTextPos(e, text, info);
                    e.Graphics.DrawRectangle(e.Cache.GetPen(gvChiDinh_Lis.Appearance.GroupRow.BackColor), e.Bounds);
                    e.Graphics.DrawString(text
                        , e.Appearance.Font,
                        e.Cache.GetSolidBrush((haveGhiChu ? Color.DarkRed : e.Appearance.ForeColor)), textPos);

                    Point imgPos = GetImgPos(info,
                        textPos.X + (int)e.Graphics
                            .MeasureString($"{ongMau}:",
                                e.Appearance.Font).Width,
                        Convert.ToInt32(e.Graphics.MeasureString(text, e.Appearance.Font).Width));
                    if (gvChiDinh_Lis.GetRowCellValue(handle, colChiDinhLis_HinhOngMau) != null &&
                        !string.IsNullOrEmpty(
                            gvChiDinh_Lis.GetRowCellValue(handle, colChiDinhLis_HinhOngMau).ToString()))
                    {
                        Image img = (Bitmap)(gvChiDinh_Lis.GetRowCellValue(handle, colChiDinhLis_HinhOngMau));
                        imgPos.Y = e.Bounds.Location.Y + e.Bounds.Height / 2 - img.Height / 2 - 1;
                        e.Graphics.DrawImage(img, imgPos);
                    }

                    e.Handled = true;

                }
                else if (info.Column.Name == colChiDinhLis_RSoPhieuYeuCau.Name)
                {
                    var arr = info.GroupText.Split('-');
                    info.Appearance.ForeColor = Color.Blue;
                    info.Appearance.Font = new Font("Arail", 10, FontStyle.Bold);
                    info.GroupText = arr[0].Replace($"- {ghiChuLayMau}: ,",
                                ","); ;

                }
                else if (info.Column.Name == colChiDinhLis_TenLoaiMau.Name && info.GroupText != null)
                {

                    info.GroupText = info.GroupText
                        .Replace($", {slMau}: 1", "")
                        .Replace($", {slMau}: 2", "")
                        .Replace($", {slMau}: 3", "")
                        .Replace($", {slMau}: 4", "")
                        .Replace($", {slMau}: 5", "")
                        .Replace($", {slMau}: 6", "")
                        .Replace($", {slMau}: 7", "");
                }
                else if (info.Column.Name == colChiDinhLis_TrangThai.Name)
                {
                    if (info.GroupText != null)
                    {
                        info.GroupText =
                            info.GroupText.Replace($"- {ghiChuLayMau}: ,",
                                ",");
                    }
                }
                else if (info.Column.Name == colChiDinhLis_NoiDuKienThucHien.Name && info.GroupText != null && info.Level == 0)
                {
                    // info.GroupText = info.GroupText.Replace(String.Format("- {0}: ,", colDaLayMau_NoiDungGhiChu.Caption), ",").Replace("  ,", ",").Replace(" ,", ",").Replace(", ", ",").Replace(",", ", ");

                    string text = gvChiDinh_Lis.GetGroupRowDisplayText(e.RowHandle);
                    var arr = text.Split(new string[] { String.Format("- {0}", colChiDinhLis_GhiChuLayMau.Caption) }, StringSplitOptions.RemoveEmptyEntries);
                    text = arr[0];

                    _PainterChuaLayMau.GroupRow.DrawGroupRowBackground(info);
                    _PainterChuaLayMau.OpenCloseButton.DrawObject(new OpenCloseButtonInfoArgs(e.Cache, info.ButtonBounds, info.GroupExpanded, info.AppearanceGroupButton, ObjectState.Normal));

                    info.UpdateSelectorState();
                    int textY = e.Bounds.Location.Y + (e.Bounds.Height - Convert.ToInt32(e.Graphics.MeasureString(text, e.Appearance.Font).Height)) / 2;
                    info.ButtonBounds.Y = textY;
                    var rect = info.SelectorInfo.Bounds;
                    rect.Y = textY;
                    rect.X = info.ButtonBounds.Right + 12;

                    info.SelectorInfo.Bounds = rect;
                    info.SelectorInfo.GlyphRect = rect;
                    info.SelectorInfo.CaptionRect = new Rectangle(rect.X + rect.Width, rect.Y, -3, 1);

                    ObjectPainter.DrawObject(e.Cache, info.SelectorPainter, info.SelectorInfo);
                    Point textPos = GetTextPos(e, text, info);
                    // e.Graphics.DrawRectangle(e.Cache.GetPen(Color.FromArgb(255, 128, 128)), e.Bounds);
                    e.Graphics.DrawString(text, new Font(e.Appearance.Font.FontFamily.Name, 13, FontStyle.Bold), e.Cache.GetSolidBrush(Color.DarkGreen), textPos);
                    e.Handled = true;
                }
            }
        }

        private Point GetTextPos(DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e, string text, GridGroupRowInfo info)
        {
            int height = Convert.ToInt32(e.Graphics.MeasureString(text, e.Appearance.Font).Height);
            Point textPos = new Point(info.SelectorInfo.Bounds.Right + 5, e.Bounds.Location.Y + (e.Bounds.Height - height) / 2);
            return textPos;
        }
        private Point GetImgPos(GridGroupRowInfo info, int textX, int textWidth)
        {
            Point imgPos = new Point(textX + 5, info.DataBounds.Y);
            return imgPos;
        }
        Int32 countDistinctChuaLayMau = 0;
        List<string> listChuaLayMau = new List<string>();
        List<string> listChuaLayMau_BSChiDinh = new List<string>();
        List<string> listChuaLayMau_BanLayMau = new List<string>();
        List<string> listChuaLayMau_GhiChuLayMau = new List<string>();
        string bsChiDinh = string.Empty;
        private void gvChiDinhLis_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {

            if (e.Item == gvChiDinh_Lis.GroupSummary.First(x => x.FieldName.Equals("MaLoaiMau", StringComparison.OrdinalIgnoreCase)))
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    countDistinctChuaLayMau = 0;
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!listChuaLayMau.Contains(e.FieldValue.ToString().Trim()))
                        {
                            countDistinctChuaLayMau++;
                            listChuaLayMau.Add(e.FieldValue.ToString().Trim());
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = countDistinctChuaLayMau;
                    listChuaLayMau.Clear();
                }
            }
            else if (e.Item == gvChiDinh_Lis.GroupSummary.First(x => x.FieldName.Equals("LoaiMauPhu", StringComparison.OrdinalIgnoreCase)))
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    countDistinctChuaLayMau = 0;
                    listChuaLayMau = new List<string>();
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!string.IsNullOrEmpty(e.FieldValue.ToString()))
                        {
                            if (!listChuaLayMau.Contains(e.FieldValue.ToString().Trim()))
                            {
                                countDistinctChuaLayMau++;
                                listChuaLayMau.Add(e.FieldValue.ToString().Trim());
                            }
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = countDistinctChuaLayMau;
                    listChuaLayMau.Clear();
                }
            }
            else if (e.Item == gvChiDinh_Lis.GroupSummary.First(x => x.FieldName.Equals("BSChiDinh", StringComparison.OrdinalIgnoreCase)))
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    listChuaLayMau_BSChiDinh.Clear();
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!listChuaLayMau_BSChiDinh.Contains(e.FieldValue.ToString().Trim()))
                        {
                            listChuaLayMau_BSChiDinh.Add(e.FieldValue.ToString().Trim());
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = string.Join("|", listChuaLayMau_BSChiDinh);
                    listChuaLayMau_BSChiDinh.Clear();
                }
            }
            else if (e.Item == gvChiDinh_Lis.GroupSummary.First(x => x.FieldName.Equals("BanLayMauSeq", StringComparison.OrdinalIgnoreCase)))
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    listChuaLayMau_BanLayMau.Clear();
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        var lst = e.FieldValue.ToString().Trim().Split('_')[0];
                        if (!listChuaLayMau_BanLayMau.Contains(lst))
                        {
                            listChuaLayMau_BanLayMau.Add(lst);
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = string.Join("|", listChuaLayMau_BanLayMau);
                    listChuaLayMau_BanLayMau.Clear();
                }
            }
            else if (e.Item == gvChiDinh_Lis.GroupSummary.First(x => x.FieldName.Equals("NoiDungGhiChu", StringComparison.OrdinalIgnoreCase)))
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    listChuaLayMau_GhiChuLayMau.Clear();
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!listChuaLayMau_GhiChuLayMau.Contains(e.FieldValue.ToString().Trim()))
                        {
                            listChuaLayMau_GhiChuLayMau.Add(e.FieldValue.ToString().Trim());
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = string.Join(", ", listChuaLayMau_GhiChuLayMau);
                    listChuaLayMau_GhiChuLayMau.Clear();
                }
            }
        }
        private void chkChiTietDaTiepNhan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChiTietDaTiepNhan.Checked)
            {
                gvChiDinh_Lis.ExpandAllGroups();
                chkChiTietDaTiepNhan.BackColor = CommonAppColors.ColorCheckedSelectedBackColor;
            }
            else
            {
                gvChiDinh_Lis.CollapseAllGroups();
                gvChiDinh_Lis.ExpandGroupLevel(0);
                gvChiDinh_Lis.ExpandGroupLevel(1);
                chkChiTietDaTiepNhan.BackColor = this.BackColor;
            }
        }
        #endregion
        private void CapNhat_NgayChiDinh()
        {
            if (gvDanhSach.FocusedRowHandle > -1)
            {
                if (chkUpdateAll.Checked)
                {
                    Get_DanhSachBenhNhan();
                    for (int i = 0; i < gvDanhSach.RowCount; i++)
                    {
                        Start_Update(i);
                    }
                    Get_DanhSachBenhNhan();
                }
                else
                {
                    Start_Update(gvDanhSach.FocusedRowHandle);
                }
            }
        }
        private void Start_Update(int index)
        {
            try
            {
                var MaBenhNhan = gvDanhSach.GetRowCellValue(index, colDS_MaBN).ToString();
                var matiepnhan = gvDanhSach.GetRowCellValue(index, colDS_MaTiepNhan).ToString(); 
                var soPhieuYCau = gvDanhSach.GetRowCellValue(index, colDS_SoPhieu).ToString(); 
                SearchHisLis(soPhieuYCau, MaBenhNhan);
                Check_LoadOrderDetail(false);
                if (gvHisDanhSachBenhNhanCho.RowCount > 0 && gvHisDanhSachBenhNhanCho.FocusedRowHandle > -1)
                {
                    var ngayChidinh = DateTime.Parse(gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSach_chidinhNgaychidinh).ToString());
                    _informationService.Update_NgayChiDinh(matiepnhan, ngayChidinh);
                    if (gvHisDanhSachBenhNhanCho.RowCount > 1)
                    {
                        var lisUpdated = new List<string>();
                        for (int r = 0; r < gvHisDanhSachBenhNhanCho.RowCount; r++)
                        {
                            gvHisDanhSachBenhNhanCho.FocusedRowHandle = r;
                            Check_LoadOrderDetail(false);
                            if (gvChiTietChiDinh_His.RowCount > 0)
                            {
                                for (int rD = 0; rD < gvChiTietChiDinh_His.RowCount; rD++)
                                {
                                    if (gvChiTietChiDinh_His.GetRowCellValue(rD, colChiDinh_MaDVLis) != null)
                                    {
                                        var mxnLis = gvChiTietChiDinh_His.GetRowCellValue(rD, colChiDinh_MaDVLis).ToString().Trim();
                                        if (!lisUpdated.Contains(mxnLis))
                                        {
                                            lisUpdated.Add(mxnLis);
                                            ngayChidinh = DateTime.Parse(gvChiTietChiDinh_His.GetRowCellValue(rD, col_ChiDinh_chidinhThoigianyeucau).ToString());
                                            _iXetnghiem.Update_ThongTinChiDinh(matiepnhan, mxnLis, ngayChidinh);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        _iXetnghiem.Update_ThongTinChiDinh(matiepnhan, string.Empty, ngayChidinh);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }
        private void SearchHisLis(string soPhieu,string mabn)
        {
            var filter = string.Format("[{0}] = '{1}' and [{2}] = '{3}'", hColumnNames.chidinhMabenhnhan, mabn, hColumnNames.chidinhSophieuyeucau, soPhieu);
            gvHisDanhSachBenhNhanCho.ActiveFilterCriteria = CriteriaOperator.Parse(filter);
        }

        private void btnDanhSachDaTN_Click(object sender, EventArgs e)
        {
            Get_DanhSachBenhNhan();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                txtSearch.Text = WorkingServices.GetBarcodeInString(txtSearch.Text, int.Parse(CommonAppVarsAndFunctions.sysConfig.BenhNhanSoKyTuBarCode));
                if (WorkingServices.IsNumeric(txtSearch.Text))
                {
                    var dateFound = _informationService.NgayTiepNhan_TheoBarcode(txtSearch.Text);
                    dtpDateIn.Value = dateFound;
                }
                Get_DanhSachBenhNhan();
                txtSearch.Focus();
                txtSearch.SelectAll();
                e.Handled = true;
            }
        }

        private void btnInBarcode_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.FocusedRowHandle > -1)
            {
                var matiepnhan = gvDanhSach.GetFocusedRowCellValue(colDS_MaTiepNhan).ToString();
                Inbarcode(new List<BENHNHAN_TIEPNHAN> { _informationService.Get_Info_BenhNhan_TiepNhan(matiepnhan, new string[] { }) }, true);
            }
        }

        private void cboTrangThaiLayMau_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_DanhSachBenhNhan();
        }
        private bool LayBanLayMau(DateTime dateServer)
        {
            try
            {
                LogService.RecordLogFile(LogFile.ActionLog,
                    string.Format("call LayBanLayMau(DateTime dateServer) start: {0:yyyy/MM/dd HH:mm:ss fff}",
                        DateTime.Now), this.Text);
                tgThucHienLayMau =
                    dateServer.AddMinutes(objKhuLayMau
                        .Sophutconglaymau); //C_Ultilities.ServerDate().AddMinutes(objKhuLayMau.Sophutconglaymau);
                if (objKhuLayMau.NhapDanhSachUserLayMau)
                {
                    var data = _informationService.LayMau_LaySoBan(objKhuLayMau.Idkhulaymau);
                    if (data == null) return true;

                    if (data.Rows.Count > 0)
                    {
                        banLayMau = int.Parse(data.Rows[0]["SoBanKeTiep"].ToString());
                        nguoiLayMau = data.Rows[0]["MaNguoiDung"].ToString();
                        soTTLayMau = int.Parse(data.Rows[0]["SoLuongDaCap"].ToString());
                    }
                    else
                    {
                        CustomMessageBox.MSG_Information_OK("Chưa có bàn đăng ký lấy mẫu.");
                        ShowMessage(CommonAppVarsAndFunctions.LangMessageConstant.Chuacobandangkylaymau);
                        return false;
                    }
                }
                else
                {
                    soTTLayMau = 0;
                    if (objKhuLayMau.ChonNguoiLayMau)
                    {
                        if (ucSearchLookupEditor_NguoiDungDKLayMau1.SelectedValue != null)
                        {
                            banLayMau = 0;
                            nguoiLayMau = ucSearchLookupEditor_NguoiDungDKLayMau1.SelectedValue.ToString();
                        }
                        else
                        {
                            CustomMessageBox.MSG_Information_OK("Chưa chọn thông tin người lấy mẫu");
                            ShowMessage("Chưa chọn thông tin người lấy mẫu");
                            return false;
                        }
                    }
                    else
                    {
                        banLayMau = 0;
                        nguoiLayMau = CommonAppVarsAndFunctions.UserID;
                    }
                }

                return true;
            }
            catch
            {
                return false;
                // ignored
            }
            finally
            {
                LogService.RecordLogFile(LogFile.ActionLog,
                    string.Format("call LayBanLayMau(DateTime dateServer) finish: {0:yyyy/MM/dd HH:mm:ss fff}",
                        DateTime.Now), this.Text);
            }
        }

        private void UpdateLayMau()
        {
            try
            {
                if (gvChiDinh_Lis.SelectedRowsCount <= 0) return;

                bool ok;
                ShowMessage(CommonAppVarsAndFunctions.LangMessageConstant.Thuchienduyetlaymau);

                //List<string> listCapNhatLayMau = new List<string>();
              //  var listMauInbarcode = new List<string>();
                var lstDSLayMau = new List<LayMauInfo>();

                var maloaiMau = string.Empty;
                var madichvu = string.Empty;
                var matiepNhan = string.Empty;
                var loaiXetNghiem = -1;
                bool daLayMau;
                bool tuChoiMau;
                var daNhanMau = false;
                var maCapTren = string.Empty;
                var profileID = string.Empty;
                var lstMaTiepNhanHL7 = new List<BenhNhanInfoForHIS>();
                var lstBnHL7Upate = new List<BenhNhanInfoForHIS>();
                var lstMatiepnhan = new List<string>();
                
                foreach (var i in gvChiDinh_Lis.GetSelectedRows())
                {
                    if (gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_MaDichVu) == null) continue;

                    maloaiMau = gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_MaLoaiMau).ToString().Trim();
                    madichvu = gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_MaDichVu).ToString().Trim();
                    matiepNhan = gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_MaTiepNhan).ToString().Trim();
                    loaiXetNghiem = int.Parse(gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_LoaiXetNghiem).ToString().Trim());
                    daLayMau = bool.Parse(gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_DalayMau).ToString().Trim());
                    tuChoiMau = bool.Parse(gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_TuChoiMau).ToString().Trim());
                    maCapTren = gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_MaXnHis).ToString().Trim();
                    profileID = gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_ProfileID).ToString().Trim();
                    //daNhanMau = bool.Parse(gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_DaNhanMau).ToString().Trim());
                    if (daLayMau && !tuChoiMau) continue;
                    if (!lstMatiepnhan.Contains(matiepNhan))
                    {
                        lstMatiepnhan.Add(matiepNhan);
                       
                    }
                    lstDSLayMau.Add(
                        new LayMauInfo
                        {
                            MaTiepNhan = matiepNhan,
                            TrangThai = enumThucHien.DaThucHien,
                            MaNhomLoaiMau = maloaiMau,
                            NguoiThucHien = (string.IsNullOrEmpty(nguoiLayMau) ? CommonAppVarsAndFunctions.UserID : nguoiLayMau),
                            Pcthuchien = Environment.MachineName,
                            CheckXacNhanHis = true,
                            Maxn = madichvu,
                            IDKhuLayMau = idKhuLaymau,
                            ThoiGianLayMau = tgThucHienLayMau,
                            LoaiXetNghiem = loaiXetNghiem,
                            IdLayLoaiMau = CommonAppVarsAndFunctions.IDLayLoaiMau,
                            BanLayMau = banLayMau,
                            MaCapTren = maCapTren,
                            ProfileId = profileID
                        });
                  
                    if (listChuaLayMau.Contains(maloaiMau)) continue;

                   // listMauInbarcode.Add(maloaiMau);
                    listChuaLayMau.Add(maloaiMau);

                }
                if (!string.IsNullOrEmpty(matiepNhan))
                {
                  
                    ok = _informationService.Update_MauXn_LayMau(lstDSLayMau);

                    if (lstMatiepnhan.Count > 0)
                    {
                        foreach (var matiepnhan in lstMatiepnhan)
                        {
                            lstMaTiepNhanHL7.Add(_iHisData.GetDataUploadToHIS(new GetUploadCondit
                            {
                                userID = CommonAppVarsAndFunctions.UserID,
                                matiepnhan = matiepNhan,
                                onlyValid = false,
                                onlyPrinted = false,
                                arrCatePrint = null,
                                arrtestCodePrint = null,
                                arrTestTypeID = new string[] { },
                                frombackup = false,
                                manualUpload = true,
                                forStatus = true
                            }));
                            //Thêm thông tin update HL7 về ISOFH
                            var bnExisted = lstBnHL7Upate.Where(x => x.Matiepnhan.Equals(matiepNhan));
                            if (bnExisted.Any())
                            {
                                var bnInfo = bnExisted.FirstOrDefault();
                                var fInfo = lstMaTiepNhanHL7.Where(x => x.Matiepnhan.Equals(matiepNhan)).First().ChiDinh.Where(c => c.MaXN.Equals(madichvu));
                                if (fInfo.Any())
                                {
                                    var chidinh = fInfo.First();
                                    chidinh.TrangThaiMau = OrderStatus.SampleCollect;
                                    bnInfo.ChiDinh.Add(chidinh);
                                }
                            }
                            else if (lstMaTiepNhanHL7.Any())
                            {
                                var bnAdd = lstMaTiepNhanHL7.Where(x => x.Matiepnhan.Equals(matiepNhan)).First().CopyHISInfo();
                                if (bnAdd.ChiDinh.Where(c => c.MaXN.Equals(madichvu) || (c.MaXNCha_His ?? string.Empty).Equals(maCapTren)).Any())
                                {
                                    var chidinh = bnAdd.ChiDinh.Where(c => c.MaXN.Equals(madichvu) || (c.MaXNCha_His ?? string.Empty).Equals(maCapTren)).ToList();
                                    foreach (var itmChiDinh in chidinh)
                                    {
                                        itmChiDinh.TrangThaiMau = OrderStatus.SampleCollect;
                                    }
                                    bnAdd.ChiDinh = chidinh;
                                    lstBnHL7Upate.Add(bnAdd);
                                }
                            }
                        }
                        if (lstBnHL7Upate.Count > 0)
                        {
                            Task.Factory.StartNew(() => { UpdateTrangThaiVeHIS(lstBnHL7Upate); });
                        }
                    }
                    //  _iXetnghiem.InsertCategoryOfTest(matiepNhan);
                    //Tùng > Cập nhật trạng thái
                    _informationService.Update_TrangThaiLayMau(matiepNhan);
                    //if (cboTrangThaiLayMau.SelectedIndex == 1)
                    //{
                    //    var data = (DataTable)gcChiDinh_Lis.DataSource;
                    //    if (data.Rows.Count > 0)
                    //    {
                    //        for (var c = 0; c < data.Rows.Count; c++)
                    //        {
                    //            maloaiMau = StringConverter.ToString(data.Rows[c]["MaLoaiMau"]).Trim();
                    //            var tuInKhiQuet = NumberConverter.ToInt(data.Rows[c]["TuInBarCodeKhiQuet"]);
                    //            if (tuInKhiQuet == 1 && !listChuaLayMau.Contains(maloaiMau))
                    //            {
                    //                listMauInbarcode.Add(maloaiMau);
                    //            }
                    //        }
                    //    }
                    //}
                    if (ok)
                    {
                        if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCachTinhTAT == (int)enumGioTinhThucHien.ThoiGianLayMau)
                        {
                            _informationService.Update_ThoiGianThucHienXN(matiepNhan);
                            _informationService.Update_ThoiGianThucHienXN_Nhom(matiepNhan, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCachTinhTAT);
                        }
                    }
                }
                ShowMessage(string.Empty);
            }
            catch (Exception ex)
            {
               ShowMessage(ex.Message);
            }
        }
        private readonly IGetHISService _iGetHisService = new GetHISService();
        private void UpdateTrangThaiVeHIS(List<BenhNhanInfoForHIS> lst)
        {
            foreach (var item in lst)
            {
                if (item.Hisproviderid.Equals((int)HisProvider.ISofH) || item.Hisproviderid.Equals((int)HisProvider.VNPTMN))
                {
                    var hisInfo = CommonAppVarsAndFunctions.HisConnectList.Where(x => ((int)x.HisID).Equals(item.Hisproviderid)).FirstOrDefault();
                    //Gọi về his nhận mẫu
                    _iHisData.LISCheckOrder(hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, item);
                }
                else if (item.Hisproviderid == (int)HisProvider.DH_API || item.Hisproviderid == (int)HisProvider.DH_DHG)
                {
                    var hisInfoparaInfoList = new List<HisParaGetList>();
                    foreach (var itmChiDinh in item.ChiDinh)
                    {
                        hisInfoparaInfoList.Add(new HisParaGetList()
                        {
                            IDChiDinh = itmChiDinh.IdChiTiet,
                            IDChiDinhDichVu = itmChiDinh.IDDichVuChiDinh,
                            SoPhieuChiDinh = itmChiDinh.SoPhieuChiDinh,
                            MaBenhAn = item.Bn_id,
                            IDGiayto = item.Giayto_id,
                            MaXetNghiemLIS = itmChiDinh.TestCode,
                            MaTiepNhanLIS = item.Matiepnhan,
                            NgayTiepNhan = item.Ngaytiepnhan,
                            NoiTru = item.Noitru,
                            TrangThai = 1,
                            TrangThaiHL7 = OrderStatus.OrderRecieved,
                            IDBangKe = itmChiDinh.Bangkeid,
                            IDUserThucHien = itmChiDinh.MaNhanVienThucHien,
                            NgayChiDinh = itmChiDinh.Thoigiangui,
                            TenDichVu = itmChiDinh.TenXN_His,
                            ThoiGianThucHien = itmChiDinh.Thoigianxacnhan,
                            IDUserLayMau = itmChiDinh.NguoiLayMauHIS,
                            ThoiGianLayMau = itmChiDinh.ThoiGianLayMau,
                            MaDichVu = itmChiDinh.MaXN_His
                        });
                    }
                    var para = hisInfoparaInfoList
                        .GroupBy(x => new { x.SoPhieuChiDinh, x.NgayChiDinh, x.IDUserThucHien })
                        .Select(g => new { g.Key.SoPhieuChiDinh, g.Key.NgayChiDinh, g.Key.IDUserThucHien }).ToList();
                    hisInfoparaInfoList = new List<HisParaGetList>();
                    foreach (var itemCollect in para)
                    {
                        hisInfoparaInfoList.Add(new HisParaGetList { SoPhieuChiDinh = itemCollect.SoPhieuChiDinh, NgayChiDinh = itemCollect.NgayChiDinh, IDUserThucHien = itemCollect.IDUserThucHien });
                    }
                    _iGetHisService.LISCheck(hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, hisInfoparaInfoList);
                }
            }
        }

        private void chkLayMauKhiTiepNhan_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(CommonConstant.RegistryAutoCompleteGetSample, chkLayMauKhiTiepNhan.Checked ? "1" : "0");
            chkLayMauKhiTiepNhan.BackColor = (chkLayMauKhiTiepNhan.Checked ? CommonAppColors.ColorCheckedSelectedBackColor : this.BackColor);
        }

        private void txtSearch_Click_1(object sender, EventArgs e)
        {
            txtSearch.SelectAll();
        }
        private void ShowMessage(string inputMess)
        {
            if (InvokeRequired)
            {
                lblMessage.Invoke((MethodInvoker)delegate
                {
                    lblMessage.Text = inputMess;
                    lblMessage.Refresh();
                });
            }
            lblMessage.Text = inputMess;
            lblMessage.Refresh();
           // pnMessage.Visible = !string.IsNullOrEmpty(inputMess);
        }

        private void chkKhongLoadDanhSach_CheckedChanged(object sender, EventArgs e)
        {
            pnDenNgay.Visible = !chkKhongLoadDanhSach.Checked;
            btnHisDanhSachCho.Visible = !chkKhongLoadDanhSach.Checked;
            chkTuDoiNgay.Visible = !chkKhongLoadDanhSach.Checked;
            splitContainer3.SplitterPosition = (flpNgayChiDinh.Visible ? splitContainer3.SplitterPosition : splitContainer3.SplitterPosition - flpNgayChiDinh.Height);
        }

        private void chkChiTietChiDinhHis_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(CommonConstant.RegistryReceptionHIS_ShowDetail, (chkChiTietChiDinhHis.Checked ? "1" : "0"));
            chkChiTietChiDinhHis.BackColor = (chkChiTietChiDinhHis.Checked ? CommonAppColors.ColorCheckedSelectedBackColor : this.BackColor);
            ShowChiTietChiDinh();
        }
        private void ShowChiTietChiDinh()
        {
            if (chkChiTietChiDinhHis.Checked)
                gvChiTietChiDinh_His.ExpandAllGroups();
            else
            {
                gvChiTietChiDinh_His.CollapseAllGroups();
                gvChiTietChiDinh_His.ExpandGroupLevel(0);
                gvChiTietChiDinh_His.ExpandGroupLevel(1);
            }
        }
        private void gvChiTietChiDinh_His_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            if(info.Level == 0)
            {
                e.Appearance.Font = new Font("Arial", 11, FontStyle.Bold);
                e.Appearance.ForeColor = Color.Red;
            }
            else if (info.Level == 1)
            {
                e.Appearance.Font = new Font("Arial", 11, FontStyle.Bold);
                e.Appearance.ForeColor = Color.Blue;
            }
            else
            {
                e.Appearance.BackColor = Color.LightGray;
            }
        }
        List<string> lstChiDinh_TenNhomCLS = new List<string>();
        List<string> lstChiDinh_LisCode = new List<string>();
        private void gvChiTietChiDinh_His_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            //if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.Vimes)
            //{
            //    if (e.Item == gvChiDinh_Lis.GroupSummary.First(x => x.FieldName.Equals("tennhomcls", StringComparison.OrdinalIgnoreCase)))
            //    {
            //        if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
            //        {
            //            lstChiDinh_TenNhomCLS.Clear();
            //        }
            //        else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
            //        {
            //            if (e.FieldValue != null)
            //            {
            //                if (!lstChiDinh_TenNhomCLS.Contains(e.FieldValue.ToString().Trim()))
            //                {
            //                    lstChiDinh_TenNhomCLS.Add(e.FieldValue.ToString().Trim());
            //                }
            //            }
            //        }
            //        else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            //        {
            //            e.TotalValue = string.Join("|", lstChiDinh_TenNhomCLS);
            //            lstChiDinh_TenNhomCLS.Clear();
            //        }
            //    }
            //    else if (e.Item == gvChiDinh_Lis.GroupSummary.First(x => x.FieldName.Equals("liscode", StringComparison.OrdinalIgnoreCase)))
            //    {
            //        if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
            //        {
            //            lstChiDinh_LisCode.Clear();
            //        }
            //        else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
            //        {
            //            if (e.FieldValue != null)
            //            {
            //                if (!lstChiDinh_LisCode.Contains(e.FieldValue.ToString().Trim()))
            //                {
            //                    lstChiDinh_LisCode.Add(e.FieldValue.ToString().Trim());
            //                }
            //            }
            //        }
            //        else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            //        {
            //            e.TotalValue = string.Join("|", lstChiDinh_LisCode);
            //            lstChiDinh_LisCode.Clear();
            //        }
            //    }
            //}
        }

        private void btnDongPhieuHen_Click(object sender, EventArgs e)
        {
            pnPhieuHen.Size = new Size(pnPhieuHen.Width, 0);
        }

        private void btnShowPhieuHen_Click(object sender, EventArgs e)
        {
            ucGioHenTraKetQua1.ClearDanhSach();
            if (pnPhieuHen.Size.Width == 0 && gvDanhSach.FocusedRowHandle > -1)
            {
                ucGioHenTraKetQua1.Load_DanhSachHenTraKetQua(true, String.Empty, String.Empty
                    , DateTime.Parse(gvDanhSach.GetFocusedRowCellValue(colDS_NgayTiepNhan).ToString()).Date
                    , gvDanhSach.GetFocusedRowCellValue(colDS_Barcode).ToString());
            }
            pnPhieuHen.Size = new Size(pnPhieuHen.Width, 160);
          //  pnPhieuHen.Location = new Point((grbChiTietXetNghiem.Location.X + grbChiTietXetNghiem.Width) - pnPhieuHen.Width, pnPhieuHen.Location.Y);
        }
        private void chkInPhieuHen_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(CommonConstant.RegistryPrintReturnTicket, chkInPhieuHen.Checked ? "1" : "0");
            chkInPhieuHen.BackColor = chkInPhieuHen.Checked
                ? CommonAppColors.ColorCheckedSelectedBackColor
                : this.BackColor;
        }

        private void ucGioHenTraKetQua1_Load(object sender, EventArgs e)
        {

        }

        private void mnuNhapGhiChuLayMau_Click(object sender, EventArgs e)
        {
            if(gvChiDinh_Lis.SelectedRowsCount > 0)
            {
                var lst = new List<string>();
                var noidung = string.Empty;
                foreach (var item in gvChiDinh_Lis.GetSelectedRows())
                {
                    if (gvChiDinh_Lis.GetRowCellValue(item, colChiDinhLis_MaDichVu) != null)
                    {
                        lst.Add(gvChiDinh_Lis.GetRowCellValue(item, colChiDinhLis_MaDichVu).ToString());
                        if(!string.IsNullOrEmpty(gvChiDinh_Lis.GetRowCellValue(item, colChiDinhLis_GhiChuLayMau).ToString()))
                        {
                            noidung = gvChiDinh_Lis.GetRowCellValue(item, colChiDinhLis_GhiChuLayMau).ToString();
                        }
                    }
                }
                var f = new DailyUse.CanLamSang.FrmNhapGhiChuLayMau();
                f.MaTiepNhan = gvDanhSach.GetFocusedRowCellValue(colDS_MaTiepNhan).ToString();
                f.NoiDung = noidung;
                f.lstDSXetNghiem = lst;
                f.ShowDialog();
                if (f.DialogResult == DialogResult.OK)
                {
                    LoadChiDinhXN();
                }
            }
        }
        private bool HISKhongLoaDanhSach_DungSoPhieu()
        {
            if (hisInfo == null)
                return false;
            return hisInfo.NotUsePatientList;
        }
        private bool HISKHongLoadDanhSach_SoHoSo()
        {
            return CommonAppVarsAndFunctions.WorkingHis == HisProvider.Vimes || hisInfo.HisID == HisProvider.ISofH;
        }
        private void gvMau_CalcRowHeight(object sender, RowHeightEventArgs e)
        {
            if (e.RowHandle > -1)
                return;
            else if (e.RowHandle != GridControl.InvalidRowHandle)
            {
                if (e.RowHeight < 35)
                    e.RowHeight = 35;
            }
        }
        private void gvChiTietHIS_CalcRowHeight(object sender, RowHeightEventArgs e)
        {
            if (e.RowHandle > -1)
                return;
            else if (e.RowHandle != GridControl.InvalidRowHandle)
            {
                if (e.RowHeight < 26)
                    e.RowHeight = 26;
            }
        }

        private void btnHuyTiepNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDanhSach.RowCount <= 0) return;
                if (cboLyDo.SelectedIndex == -1)
                {
                    CustomMessageBox.MSG_Information_OK(CommonAppVarsAndFunctions.LangMessageConstant.Haychonlydo);
                    return;
                }
                int total = 0, uncheck = 0;
                var matiepnhan = gvDanhSach.GetFocusedRowCellValue(colDS_MaTiepNhan).ToString();
                var HisProviderID = (HisProvider)Enum.Parse(typeof(HisProvider), gvDanhSach.GetFocusedRowCellValue(colDS_HisProviderID).ToString());
                if (HisProviderID == CommonAppVarsAndFunctions.WorkingHis)
                {
                    var selectedCode = string.Empty;
                    var loaiXetNghiem = 12;
                    var maChidinh = string.Empty;
                    var tenChidinh = string.Empty;
                    var sophieuchidinh = string.Empty;
                    var ngaychidinh = CommonAppVarsAndFunctions.ServerTime;
                    var idChiDinhnhHis = string.Empty;
                    var idChiDinhnhChiTietHis = string.Empty;
                    var maxnHIS = string.Empty;
                    var profileID = string.Empty;

                    if (gvChiDinh_Lis.RowCount == 0)
                    {
                        if (!CustomMessageBox.MSG_Question_YesNo_GetYes(
                            CommonAppVarsAndFunctions.LangMessageConstant.Banchacchanhuychidinhdangchon)) return;
                        if (_info.Delete_Patient(matiepnhan))
                        {
                            Get_DanhSachBenhNhan();
                            return;
                        }
                    }

                    ShowMessage(CommonAppVarsAndFunctions.LangMessageConstant.Dangthuchienhuytiepnhan);
                    var data = _informationService.Data_ChiDinhDaNhanMau(matiepnhan);
                    var lstDaNhan = data.AsEnumerable().Select(x => x["MaXN"].ToString().Trim()).ToList();
                    foreach (var i in gvChiDinh_Lis.GetSelectedRows())
                    {
                        if (gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_MaDichVu) != null)
                        {
                            loaiXetNghiem = (int)gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_LoaiXetNghiem);
                            maChidinh = (string)gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_MaDichVu);
                            tenChidinh = (string)gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_TenDichVu);
                            if (!_info.CheckFunction(CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                                UserConstant.PermissionReceptionDeleteOrderAndPatientWithResult))
                            {
                                if (_iXetnghiem.Check_HaveResult_XN(matiepnhan, maChidinh))
                                {
                                    CustomMessageBox.MSG_Error_OK(
                                        string.Format(CommonAppVarsAndFunctions.LangMessageConstant.ChidinhdacoketquaBankhongthehuy, tenChidinh));
                                    gvChiDinh_Lis.UnselectRow(i);
                                    uncheck++;
                                }
                                else if (lstDaNhan.Contains(maChidinh.Trim()))
                                {
                                    CustomMessageBox.MSG_Error_OK(
                                        string.Format(CommonAppVarsAndFunctions.LangMessageConstant.ChidinhdanhanmauBankhongthehuy, tenChidinh));
                                    gvChiDinh_Lis.UnselectRow(i);
                                    uncheck++;
                                }
                            }

                            selectedCode += (string.IsNullOrEmpty(selectedCode) ? "" : ";") +
                                            (string)gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_MaDichVu);
                            total++;
                        }
                    }

                    if (total > uncheck)
                    {
                        if (!CustomMessageBox.MSG_Question_YesNo_GetYes(
                            CommonAppVarsAndFunctions.LangMessageConstant.Banchacchanhuychidinhdangchon)) return;
                       
                      
                        var dataBNLIS = _informationService.Data_BenhNhan_TiepNhan(gvDanhSach.GetFocusedRowCellValue(colDS_MaTiepNhan).ToString(), null);
                        var bnInfo = (BenhNhanInfoForHIS)WorkingServices.Get_InfoForObject(new BenhNhanInfoForHIS(), dataBNLIS.Rows[0]);
                        var tgThucHien = C_Ultilities.ServerDate();
                        var coBoLayMau = false;
                        var bnInfoForHL7 = _iHisData.GetDataUploadToHIS(new GetUploadCondit
                        {
                            userID = CommonAppVarsAndFunctions.UserID,
                            matiepnhan = bnInfo.Matiepnhan,
                            onlyValid = false,
                            onlyPrinted = false,
                            arrCatePrint = null,
                            arrtestCodePrint = null,
                            arrTestTypeID = new string[] { },
                            frombackup = false,
                            manualUpload = true,
                            forStatus = true
                        });
                        foreach (var i in gvChiDinh_Lis.GetSelectedRows())
                        {
                            if (gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_MaDichVu) != null)
                            {
                                loaiXetNghiem = int.Parse(gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_LoaiXetNghiem)
                                    .ToString());
                                maChidinh = gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_MaDichVu) != null
                                    ? gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_MaDichVu).ToString()
                                    : "";
                                tenChidinh = gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_TenDichVu) != null
                                    ? gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_TenDichVu).ToString()
                                    : "";
                                sophieuchidinh = gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_RSoPhieuYeuCau) != null
                                    ? gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_RSoPhieuYeuCau).ToString()
                                    : "";
                                ngaychidinh = gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_RThoiGianChiDinh) != null
                                    ? (string.IsNullOrEmpty(gvChiDinh_Lis
                                        .GetRowCellValue(i, colChiDinhLis_RThoiGianChiDinh).ToString())
                                        ? CommonAppVarsAndFunctions.ServerTime
                                        : DateTime.Parse(gvChiDinh_Lis
                                            .GetRowCellValue(i, colChiDinhLis_RThoiGianChiDinh).ToString()))
                                    : CommonAppVarsAndFunctions.ServerTime;
                                idChiDinhnhHis = gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_RIdChiDinhHis) != null
                                    ? gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_RIdChiDinhHis).ToString()
                                    : "";
                                idChiDinhnhChiTietHis =
                                    gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_RIdChiDinhChiTiet) != null
                                        ? gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_RIdChiDinhChiTiet).ToString()
                                        : "";
                                maxnHIS = gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_MaXnHis) != null
                                    ? gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_MaXnHis).ToString()
                                    : "";
                                profileID = gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_ProfileID).ToString().Trim();
                                var maloaiMau = gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_MaLoaiMau).ToString()
                                    .Trim();
                                ShowMessage($"{CommonAppVarsAndFunctions.LangMessageConstant.Dangthuchienhuytiepnhan}\n{tenChidinh}");

                                //Thực hiện bỏ lấy mẫu
                                var daLayMau = bool.Parse(gvChiDinh_Lis.GetRowCellValue(i, colChiDinhLis_DalayMau)
                                    .ToString().Trim());
                                if (daLayMau)
                                {
                                    coBoLayMau = true;
                                    var lstBoLayMau =
                                        new LayMauInfo
                                        {
                                            MaTiepNhan = matiepnhan,
                                            TrangThai = enumThucHien.ChuaThucHien,
                                            MaNhomLoaiMau = maloaiMau,
                                            NguoiThucHien = CommonAppVarsAndFunctions.UserID,
                                            Pcthuchien = Environment.MachineName,
                                            CheckXacNhanHis =
                                                !CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                                                    CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
                                                    UserConstant.PermissionTestDeleteGetSampleValided),
                                            Maxn = maChidinh,
                                            IDKhuLayMau = idKhuLaymau,
                                            ThoiGianLayMau = tgThucHien,
                                            LoaiXetNghiem = loaiXetNghiem,
                                            IdLayLoaiMau = CommonAppVarsAndFunctions.IDLayLoaiMau,
                                            MaCapTren = maxnHIS,
                                            ProfileId = profileID
                                        };
                                    var lstnhatKyMau = new NHATKY_MAUXETNGHIEM
                                    {
                                        Matiepnhan = matiepnhan,
                                        Maxn = maChidinh,
                                        Lydo = cboLyDo.SelectedValue.ToString(),
                                        NoiDungLydo = txtLyDo.Text,
                                        Nguoithuchien = CommonAppVarsAndFunctions.UserID,
                                        Pcthuchien = Environment.MachineName,
                                        Idthuchien = (int)TrangThaiThongTinXetNghiem.HuyLayMau,
                                        Maphanloaidichvu = ServiceType.ClsXetNghiem.ToString(),
                                        Maloaimau = maloaiMau,
                                        Thoigianthuchien = tgThucHien,
                                        IdLayLoaiMau = CommonAppVarsAndFunctions.IDLayLoaiMau
                                    };
                                    var ok = _informationService.Insert_nhatky_mauxetnghiem(
                                        new List<NHATKY_MAUXETNGHIEM> { lstnhatKyMau });
                                    if (ok)
                                    {
                                        _informationService.Update_MauXn_LayMau(new List<LayMauInfo> { lstBoLayMau });
                                    }
                                }

                                //Thực hiện xóa chỉ định
                                //Truyền máu
                                if (loaiXetNghiem == 35
                                    || loaiXetNghiem == 36)
                                {
                                    _informationService.DeleteOrderOfElement(matiepnhan, maChidinh,
                                        CommonAppVarsAndFunctions.UserID, Environment.MachineName);
                                }
                                else if (loaiXetNghiem == 34)
                                {
                                    _informationService.DeleteOrderOfGPB(matiepnhan, maChidinh,
                                        CommonAppVarsAndFunctions.UserID, Environment.MachineName);
                                }
                                else if (loaiXetNghiem != 12
                                         && loaiXetNghiem != 13
                                         && loaiXetNghiem != 14
                                         && loaiXetNghiem != 15
                                         && loaiXetNghiem != 16)
                                {
                                    var stt = 0;

                                    if (!_iXetnghiem.Delete_ChiDinhCLS_XN(matiepnhan, maChidinh, string.Empty,
                                        CommonAppVarsAndFunctions.UserID)) continue;
                                    if (!string.IsNullOrEmpty(maxnHIS))
                                    {
                                        bnInfo.ChiDinh.Add(new ChiDinhHISInfo
                                        {
                                            SoPhieuChiDinh = sophieuchidinh,
                                            Thoigiangui = ngaychidinh,
                                            TestCode = maxnHIS,
                                            STT = stt,
                                            TrangThaiMau = OrderStatus.OrderCancel,
                                            IDDichVuChiDinh = idChiDinhnhHis,
                                            IdChiTiet = idChiDinhnhChiTietHis
                                        });
                                        var lstMaCon = bnInfoForHL7.ChiDinh.Where(x =>
                                            (x.MaXNCha_His ?? String.Empty).Equals(maxnHIS) &&
                                            !(x.MaXN_His ?? string.Empty).Equals(maxnHIS));
                                        if (lstMaCon.Any())
                                        {
                                            foreach (var drCon in lstMaCon)
                                            {
                                                var maxnCon = drCon.MaXN;
                                                var maxnHisCon = drCon.MaXN_His;
                                                var ngaychiDinhCon = drCon.Thoigiangui;
                                                var sttCon = drCon.STT;
                                                var idChiDInhHinCon = drCon.IDDichVuChiDinh;
                                                var idChiDinhnhChiTietHisCon = drCon.IdChiTiet;
                                                var soPhieuChiDinhCon = drCon.SoPhieuChiDinh;
                                                _iXetnghiem.Delete_ChiDinhCLS_XN(matiepnhan, maxnCon, string.Empty,
                                                    CommonAppVarsAndFunctions.UserID);
                                                bnInfo.ChiDinh.Add(new ChiDinhHISInfo
                                                {
                                                    SoPhieuChiDinh = soPhieuChiDinhCon,
                                                    Thoigiangui = ngaychiDinhCon,
                                                    TestCode = maxnHisCon,
                                                    STT = sttCon,
                                                    TrangThaiMau = OrderStatus.OrderCancel,
                                                    IDDichVuChiDinh = idChiDInhHinCon,
                                                    IdChiTiet = idChiDinhnhChiTietHisCon
                                                });

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (_iBioticResult.Delete_ketqua_cls_xetnghiem_visinh(matiepnhan, maChidinh))
                                    {
                                        bnInfo.ChiDinh.Add(new ChiDinhHISInfo
                                        {
                                            SoPhieuChiDinh = sophieuchidinh,
                                            Thoigiangui = ngaychidinh,
                                            TestCode = maxnHIS,
                                            STT = 0,
                                            TrangThaiMau = OrderStatus.OrderCancel,
                                            IDDichVuChiDinh = idChiDinhnhHis,
                                            IdChiTiet = idChiDinhnhChiTietHis
                                        });

                                    }
                                }
                            }
                        }

                        if (CommonAppVarsAndFunctions.gioTinhTgThucHien == enumGioTinhThucHien.ThoiGianLayMau &&
                            coBoLayMau)
                        {
                            _informationService.Update_ThoiGianThucHienXN(matiepnhan);
                            _informationService.Update_ThoiGianThucHienXN_Nhom(matiepnhan,
                                (int)CommonAppVarsAndFunctions.gioTinhTgThucHien);
                        }

                        ShowMessage(CommonAppVarsAndFunctions.LangMessageConstant.Danghoantathuytiepnhan);
                        //Gọi hàm hủy trên HIS
                        //Xử lý lấy danh sách theo chỉ định đang xử lý
                        var arrAction = bnInfo.ChiDinh.Select(x => x.TestCode).ToArray();
                        if (bnInfoForHL7 != null)
                        {
                            if (bnInfoForHL7.ChiDinh != null)
                            {
                                if (bnInfoForHL7.ChiDinh.Count > 0)
                                {
                                    var lst = bnInfoForHL7.ChiDinh.Where(x =>
                                        arrAction.Where(y => y.Equals(x.TestCode) || y.Equals(x.MaXNCha_His)).Any()).ToList();
                                    bnInfo.ChiDinh = lst;
                                    foreach (var item in lst)
                                    {
                                        item.TrangThaiMau = OrderStatus.OrderCancel;
                                    }
                                    //Gọi về his Hủy
                                    _iHisData.LISCheckOrder(hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, bnInfo);
                                }
                            }
                        }
                        //Load lại danh sách chỉ định
                        Load_DS_ChiDinh(matiepnhan);
                        cboLyDo.SelectedIndex = -1;
                        ShowMessage(CommonAppVarsAndFunctions.LangMessageConstant.MsgDathuchienhuytiepnhan);
                        if (gvChiDinh_Lis.RowCount == 0)
                        {
                            if (_info.Delete_Patient(matiepnhan))
                            {
                                _informationService.DeletePatientWithoutElement(matiepnhan,
                                    CommonAppVarsAndFunctions.UserID, Environment.MachineName);
                                _informationService.DeletePatientWithoutGPB(matiepnhan,
                                    CommonAppVarsAndFunctions.UserID, Environment.MachineName);
                                Get_DanhSachBenhNhan();
                            }
                        }

                        if (CommonAppVarsAndFunctions.WorkingHis != HisProvider.DH_DHG &&
                            CommonAppVarsAndFunctions.WorkingHis != HisProvider.DH_API && !chkKhongLoadDanhSach.Checked)
                        {
                            LoadPatientListFromHIS();
                            LoadChiDinhXN();
                        }
                    }
                }
                else
                    ShowMessage(CommonAppVarsAndFunctions.LangMessageConstant.BenhnhankhongdungvoiHISdangketnoi);
            }
            catch (Exception ex)
            {
                LogService.RecordLogError(CommonAppVarsAndFunctions.UserID, "TiepNhanHis", ex, 0, ex.Message, (new StackTrace()).GetFrame(0).GetMethod().Name);
                ShowMessage(ex.Message);
            }
        }

        private void btnLayLaiMau_Click(object sender, EventArgs e)
        {
            if (gvChiDinh_Lis.SelectedRowsCount > 0)
            {
                var dateServer = C_Ultilities.ServerDate().AddMinutes(objKhuLayMau.Sophutconglaymau);

                if (!LayBanLayMau(dateServer)) return;

                UpdateLayMau();
                LoadChiDinhXN();
                if (hisInfo.HisID == HisProvider.PTT_API)
                    UpLoadThoiGianhenTraKQ();
            }
            else
                ShowMessage(CommonAppVarsAndFunctions.LangMessageConstant.Khongcothongtinmaunaoduocchon);
        }

        private void gvHisDanhSachBenhNhanCho_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle > -1)
            {
                if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.Vimes)
                {
                    var barcode = WorkingServices.ObjecToString(gvHisDanhSachBenhNhanCho.GetRowCellValue(e.RowHandle, col_DanhSanh_chidinhBarcodexn));
                    if (string.IsNullOrEmpty(barcode) || barcode.Equals("0"))
                    {
                        e.Appearance.BackColor = Color.LightGray;
                    }
                }
                else
                {
                    var trangthai = WorkingServices.ObjecToString(gvHisDanhSachBenhNhanCho.GetRowCellValue(e.RowHandle, col_DanhSanh_chidinhTrangThaiChiDinh));
                    if (WorkingServices.IsNumeric(trangthai))
                    {
                        if (int.Parse(trangthai) == 1)
                            e.Appearance.BackColor = System.Drawing.Color.LightPink;
                        else if (int.Parse(trangthai) == 2)
                            e.Appearance.BackColor = System.Drawing.Color.LightBlue;
                    }
                    else
                    {
                        if (gvHisDanhSachBenhNhanCho.GetRowCellValue(e.RowHandle, col_DanhSanh_chidinhTrangThaiChiDinh) is bool)
                        {
                            if (bool.Parse(trangthai))
                                e.Appearance.BackColor = System.Drawing.Color.LightPink;
                            else
                                e.Appearance.BackColor = System.Drawing.Color.LightBlue;
                        }
                    }
                }

            }
        }
        private Image logo;
        private ReportModel resultReportInfo;
        private XtraReport ticketReport;
        private readonly IReportService _reportInfo = new ReportServiceImpl();
        private void btnInDAnhSachChiDinh_Click(object sender, EventArgs e)
        {
            if (gvChiDinh_Lis.RowCount > 0)
            {
                if (logo == null)
                {
                    logo = _iSysConfig.Load_Logo("BL");
                }

                var maTiepNhan = gvDanhSach.GetFocusedRowCellValue(colDS_MaTiepNhan).ToString();

                var lstChiDinh = _informationService.GetOrderServiceDetail(maTiepNhan, true, string.Empty, false, true);

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
                    var printerName = _registryExtension.ReadRegistry(UserConstant.RegistryPrinterOrderedList);
                    if (string.IsNullOrEmpty(printerName))
                    {
                        CustomMessageBox.MSG_Error_OK("hãy chọn máy in trên form chỉ định thủ công.");
                    }
                    else
                    {
                        ticketReport = _reportInfo.CreateReportFromStream(resultReportInfo.ReportSuDung);
                        var havePrint = crv.ShowReport(ticketReport, dataPrint, true, printerName, "BL", resultReportInfo.TenDataset, resultReportInfo.TenDatatable, isInChiDinh: true);
                    }
                }
            }
        }

        private void txtTenBNHis_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtSoPhieuYeuCau.Text = string.Empty;
            if (e.KeyChar == (char)Keys.Enter)
            {
                gvHisDanhSachBenhNhanCho.ActiveFilterString = string.Empty;
                e.Handled = true;
                LayDanhSachChiDinhTuSoPhieu();
                if (gvHisDanhSachBenhNhanCho.FocusedRowHandle > -1)
                    txtSoPhieuYeuCau.Text = gvHisDanhSachBenhNhanCho.GetFocusedRowCellValue(col_DanhSanh_chidinhSophieuyeucau).ToString();
            }
        }

        private void txtTenBNHis_Enter(object sender, EventArgs e)
        {
            txtTenBNHis.SelectAll();
        }
    }
}
