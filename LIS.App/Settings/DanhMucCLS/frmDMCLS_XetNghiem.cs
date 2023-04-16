using DevExpress.Xpo.DB.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TPH.Controls;
using TPH.Language;
using TPH.LIS.Analyzer.Services;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;

namespace TPH.LIS.App.CauHinh.DanhMucCLS
{
    public partial class frmDMCLS_XetNghiem : FrmTemplate
    {
        public frmDMCLS_XetNghiem()
        {
            InitializeComponent();
            tabLIS.Appearance = TabAppearance.FlatButtons;
            tabLIS.ItemSize = new Size(0, 1);
            tabLIS.SizeMode = TabSizeMode.Fixed;
            foreach (TabPage tab in tabLIS.TabPages)
            {
                tab.BackColor = CommonAppColors.ColorMainAppFormColor;
            }
            //pnMenu.BackColor = CommonAppColors.ColorMainAppFormColor;
        }

        C_NhanVien data = new C_NhanVien();
        DataTable _dtMaNhomCls = new DataTable();
        DataTable _dtLisCode = new DataTable();
        DataTable _dtProfile = new DataTable();
        DataTable _dtProfileTest = new DataTable();
        DataTable _dtChiSoBinhThuong = new DataTable();
        DataTable _dtTinhToan = new DataTable();
        private SqlDataAdapter _daDmXetNghiem = new SqlDataAdapter();
        private SqlDataAdapter _daProfile = new SqlDataAdapter();
        private SqlDataAdapter _daTinhToan = new SqlDataAdapter();
        private SqlDataAdapter _daChiSoBinhThuong = new SqlDataAdapter();

        private SqlDataAdapter daQuiTrinh = new SqlDataAdapter();
        private DataTable dataQuiTrinh = new DataTable();

        private DataTable dtChangedBP = new DataTable();
        SqlDataAdapter daBoPhan = new SqlDataAdapter();
        DataTable dtBoPhan = new DataTable();

        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();
        private readonly IAnalyzerConfigService _iAnalyzerConfig = new AnalyzerConfigService();

        public string TabName
        {
            get;
            set;
        }
       private void Load_DM_MayXetNghiem()
        {

            //var mayXetNghiemCombo = _iAnalyzerConfig.Data_h_mayxetnghiem(false, true);
            //qtIDMayXN.DataSource = mayXetNghiemCombo;
            //qtIDMayXN.ValueMember = "IdMay";
            //qtIDMayXN.DisplayMember = "TenMay2";

            ////  cbstIDMayXn
            //var mayXetNghiemComboCSBT = _iAnalyzerConfig.Data_h_mayxetnghiem(false, true);
            //cbstIDMayXn.DataSource = mayXetNghiemComboCSBT;
            //cbstIDMayXn.ValueMember = "IdMay";
            //cbstIDMayXn.DisplayMember = "TenMay2";
        }
        /// <summary>
        /// Load danh mục profile
        /// </summary>
        /// <param name="type">1: Profile ; 2: Profile cho Group</param>
        private void LoadProfile()
        {
            ucDanhMucBoChiDinh1.Load_danhmucprofile(ucProfile1.CurrentDataSource);
        }

        private void frmLISTest_Load(object sender, EventArgs e)
        {
            ucDanhMucBoPhan_Nhom1.isAdmin = CommonAppVarsAndFunctions.IsAdmin;
            ucDanhMucBoPhan_Nhom1.arrPhanQuyenBoPhan = CommonAppVarsAndFunctions.BoPhanClsXetNghiem;
            ucDanhMucBoPhan_Nhom1.arrPhanQuyenNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem;
            ucDanhMucBoPhan_Nhom1.UserId = CommonAppVarsAndFunctions.UserID;
            ucDanhMucBoPhan_Nhom1.Load_Config();
            LanguageExtension.LocalizeSpecialControl(ucDanhMucBoPhan_Nhom1, LanguageExtension.AppLanguage);
            ucDanhMucXetNghiem1.arrPhanQuyenNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem;
            ucDanhMucXetNghiem1.isAdmin = CommonAppVarsAndFunctions.IsAdmin;
            ucDanhMucXetNghiem1.UserId = CommonAppVarsAndFunctions.UserID;
            ucDanhMucXetNghiem1.Load_Config();
            LanguageExtension.LocalizeSpecialControl(ucDanhMucXetNghiem1, LanguageExtension.AppLanguage);
            ucDanhMucXetNghiem1.GetDanhMuc();

            ucProfile1.arrPhanQuyenNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem;
            ucProfile1.isAdmin = CommonAppVarsAndFunctions.IsAdmin;
            ucProfile1.UserId = CommonAppVarsAndFunctions.UserID;
            ucProfile1.Load_Config();
            LanguageExtension.LocalizeSpecialControl(ucProfile1, LanguageExtension.AppLanguage);
            ucDanhMucGhiChuTuDong1.arrPhanQuyenNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem;
            ucDanhMucGhiChuTuDong1.isAdmin = CommonAppVarsAndFunctions.IsAdmin;
            ucDanhMucGhiChuTuDong1.UserId = CommonAppVarsAndFunctions.UserID;
            ucDanhMucGhiChuTuDong1.Load_Config(ucDanhMucXetNghiem1.CurrentDataSource);
            LanguageExtension.LocalizeSpecialControl(ucDanhMucGhiChuTuDong1, LanguageExtension.AppLanguage);
            ucDanhMucQuyTrinh_PhuongPhap1.arrPhanQuyenNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem;
            ucDanhMucQuyTrinh_PhuongPhap1.isAdmin = CommonAppVarsAndFunctions.IsAdmin;
            ucDanhMucQuyTrinh_PhuongPhap1.UserId = CommonAppVarsAndFunctions.UserID;
            ucDanhMucQuyTrinh_PhuongPhap1.Load_Config(ucDanhMucXetNghiem1.CurrentDataSource);
            LanguageExtension.LocalizeSpecialControl(ucDanhMucQuyTrinh_PhuongPhap1, LanguageExtension.AppLanguage);
            ucDanhMucBoChiDinh1.arrPhanQuyenNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem;
            ucDanhMucBoChiDinh1.isAdmin = CommonAppVarsAndFunctions.IsAdmin;
            ucDanhMucBoChiDinh1.UserId = CommonAppVarsAndFunctions.UserID;
            ucDanhMucBoChiDinh1.Load_Config(ucDanhMucXetNghiem1.CurrentDataSource);
            LanguageExtension.LocalizeSpecialControl(ucDanhMucBoChiDinh1, LanguageExtension.AppLanguage);
            ucDanhMucBoChiDinh1.Load_danhmucprofile(ucProfile1.CurrentDataSource);

            ucDanhMucSinhLy1.arrPhanQuyenNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem;
            ucDanhMucSinhLy1.isAdmin = CommonAppVarsAndFunctions.IsAdmin;
            ucDanhMucSinhLy1.UserId = CommonAppVarsAndFunctions.UserID;
            ucDanhMucSinhLy1.Load_Config();
            LanguageExtension.LocalizeSpecialControl(ucDanhMucSinhLy1, LanguageExtension.AppLanguage);
            ucDanhMucGioiHanThamChieu1.arrPhanQuyenNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem;
            ucDanhMucGioiHanThamChieu1.isAdmin = CommonAppVarsAndFunctions.IsAdmin;
            ucDanhMucGioiHanThamChieu1.UserId = CommonAppVarsAndFunctions.UserID;
            ucDanhMucGioiHanThamChieu1.Load_Config(ucDanhMucXetNghiem1.CurrentDataSource);
            LanguageExtension.LocalizeSpecialControl(ucDanhMucGioiHanThamChieu1, LanguageExtension.AppLanguage);
            //Load_DM_MayXetNghiem();
            //LanguageExtension.LocalizeControl(ucDanhMucGioiHanThamChieu1, LanguageExtension.AppLanguage);
            if (CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionManagementOfCalculateTest))
            {
                ucDanhMucTinhToan1.isAdmin = CommonAppVarsAndFunctions.IsAdmin;
                ucDanhMucTinhToan1.arrPhanQuyenNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem;
                ucDanhMucTinhToan1.UserId = CommonAppVarsAndFunctions.UserID;
                ucDanhMucTinhToan1.Load_Config(ucDanhMucXetNghiem1.CurrentDataSource);
            }
            else
                tabLIS.TabPages.Remove(tabCalculate);
            btnNhapXuatDanhMuc.Visible = CommonAppVarsAndFunctions.IsAdmin;

            HightLightButton(btnDmBoPhan);
        }
        private void LoadDanhSachXetNghiem()
        {
            var dataFirst = ucDanhMucXetNghiem1.CurrentDataSource;
            ucDanhMucTinhToan1.Load_DanhMucXetNghiem(dataFirst);
            ucDanhMucGioiHanThamChieu1.Load_DanhMucXetNghiem(dataFirst);
            ucDanhMucGhiChuTuDong1.Load_DanhMucXetNghiem(dataFirst);
            ucDanhMucQuyTrinh_PhuongPhap1.Load_DanhMucXetNghiem(dataFirst);
            ucDanhMucBoChiDinh1.Load_DanhMucXetNghiem(dataFirst);
        }
  
        private void frmLISTest_Activated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TabName)) return;

            tabLIS.TabPages[TabName].Focus();
            TabName = string.Empty;
        }
        private void ucDanhMucXetNghiem1_ButtonDMLoaiMauClick(object sender, EventArgs e)
        {
            var f = new Settings.DanhMucCLS.FrmDM_LoaiMau();
            f.pnMenu.Visible = true;
            f.AdjustForm();
            f.ShowDialog();
            ucDanhMucXetNghiem1.Load_LoaiMau();
        }
        private void ucDanhMucXetNghiem1_ButtonLuuXNMoiClick(object sender, EventArgs e)
        {
            LoadDanhSachXetNghiem();
        }
        private void ucDanhMucXetNghiem1_ButtonXoaXNClick(object sender, EventArgs e)
        {
            LoadDanhSachXetNghiem();
        }
        private void ucDanhMucXetNghiem1_LuoiDMChinhSua(object sender, EventArgs e)
        {
            LoadDanhSachXetNghiem();
        }
        private void ucProfile1_BuutonThemMoiProfileClick(object sender, EventArgs e)
        {
            LoadProfile();
        }
        private void ucProfile1_BuutonXoaProfileClick(object sender, EventArgs e)
        {
            LoadProfile();
        }
        private void ucProfile1_LuoiProfileChinhSua(object sender, EventArgs e)
        {
            LoadProfile();
        }

        private void btnDmBoPhan_Click(object sender, EventArgs e)
        {
            tabLIS.SelectedIndex = 0;
            HightLightButton((Button)sender);
        }

        private void btnDmXetNghiem_Click(object sender, EventArgs e)
        {
            tabLIS.SelectedIndex = 1;
            HightLightButton((Button)sender);
        }

        private void btnDmProfile_Click(object sender, EventArgs e)
        {
            tabLIS.SelectedIndex = 2;
            HightLightButton((Button)sender);
        }

        private void btnDmBoChiDinh_Click(object sender, EventArgs e)
        {
            tabLIS.SelectedIndex = 3;
            HightLightButton((Button)sender);
        }

        private void btnDmGiohanThamChieu_Click(object sender, EventArgs e)
        {
            tabLIS.SelectedIndex = 4;
            HightLightButton((Button)sender);
        }

        private void btnDmTinhToan_Click(object sender, EventArgs e)
        {
            tabLIS.SelectedIndex = 5;
            HightLightButton((Button)sender);
        }

        private void btnDmQuyTrinh_Click(object sender, EventArgs e)
        {
            tabLIS.SelectedIndex = 6;
            HightLightButton((Button)sender);
        }

        private void btnDMCongTy_Click(object sender, EventArgs e)
        {
            tabLIS.SelectedIndex = 7;
            HightLightButton((Button)sender);
        }

        private void btnDmSinhLy_Click(object sender, EventArgs e)
        {
            tabLIS.SelectedIndex = 8;
            HightLightButton((Button)sender);
        }
        private string tableLoaiMauChinh = "DMLoaiMauChinh";
        private string tableLoaiMauNhom = "DMLoaiMauNhom";
        private string tableLoaiMauChay = "DMLoaiMauChay";
        private string tableXetNghiem_BoPhan = "DMXetNghiem_BoPhan";
        private string tableXetNghiem_Nhom = "DMXetNghiem_Nhom";
        private string tableXetNghiem = "DMXetNghiem";
        private string tableXetNghiem_Profile = "DMXetNghiem_Profile";
        private string tableXetNghiem_Profile_ChiTiet = "DMXetNghiem_Profile_ChiTiet";
        private string tableXetNghiem_PhuongPhapQuyTrinh = "DMXetNghiem_PhuongPhapQuyTrinh";
        private string tableXetNghiem_GhiChu = "DMXetNghiem_GhiChu";
        private string tableXetNghiem_CSBT = "DMXetNghiem_CSBT";
        private string tableXetNghiem_TinhToan = "DMXetNghiem_TinhToan";
        private void btnExportXML_Click(object sender, EventArgs e)
        {
            //Lấy từng datatable của danh mục
               ISystemConfigService _systemConfigService = new SystemConfigService();
            var dataSet = new DataSet("TPH_DanhMuc");

            var dataLoaiMauChinh = _systemConfigService.Data_dm_xetnghiem_loaimauchinh(string.Empty).Copy();
            dataLoaiMauChinh.TableName = tableLoaiMauChinh;
            dataSet.Tables.Add(dataLoaiMauChinh);
            var dataLoaiMauNhom = _systemConfigService.Data_dm_xetnghiem_loaimau_nhom(string.Empty, false, string.Empty).Copy();
            dataLoaiMauNhom.TableName = tableLoaiMauNhom;
            dataSet.Tables.Add(dataLoaiMauNhom);
            var dataLoaiMauChay = _systemConfigService.Data_dm_xetnghiem_loaimau(string.Empty, string.Empty).Copy();
            dataLoaiMauChay.TableName = tableLoaiMauChay;
            dataSet.Tables.Add(dataLoaiMauChay);
            var dataBoPhan = _systemConfigService.Data_dm_xetnghiem_bophan(string.Empty).Copy();
            dataBoPhan.TableName = tableXetNghiem_BoPhan;
            dataSet.Tables.Add(dataBoPhan);
            var dataNhom = _systemConfigService.Data_dm_xetnghiem_nhom(string.Empty).Copy();
            dataNhom.TableName = tableXetNghiem_Nhom;
            dataSet.Tables.Add(dataNhom);
            var dataXetNghiem = _systemConfigService.Data_dm_xetnghiem(string.Empty, false, string.Empty).Copy();
            dataXetNghiem.TableName = tableXetNghiem;
            dataSet.Tables.Add(dataXetNghiem);
            var dataXetNghiem_Profile = _systemConfigService.Data_dm_xetnghiem_profile(string.Empty).Copy();
            dataXetNghiem_Profile.TableName = tableXetNghiem_Profile;
            dataSet.Tables.Add(dataXetNghiem_Profile);
            var dataXetNghiem_Profile_ChiTiet = _systemConfigService.Data_dm_xetnghiem_profile_chitiet(string.Empty, string.Empty).Copy();
            dataXetNghiem_Profile_ChiTiet.TableName = tableXetNghiem_Profile_ChiTiet;
            dataSet.Tables.Add(dataXetNghiem_Profile_ChiTiet);
            var dataXetNghiem_GhiChu = _systemConfigService.Data_dm_xetnghiem_ghichutudong(null, string.Empty).Copy();
            dataXetNghiem_GhiChu.TableName = tableXetNghiem_GhiChu;
            dataSet.Tables.Add(dataXetNghiem_GhiChu);
            var dataXetNghiem_PhuongPhap = _systemConfigService.Data_dm_xetngnghiem_phuongphap(null, string.Empty, null).Copy();
            dataXetNghiem_PhuongPhap.TableName = tableXetNghiem_PhuongPhapQuyTrinh;
            dataSet.Tables.Add(dataXetNghiem_PhuongPhap);
            var dataXetNghiem_CSBT = _systemConfigService.Data_dm_xetnghiem_csbt(null, string.Empty).Copy();
            dataXetNghiem_CSBT.TableName = tableXetNghiem_CSBT;
            dataSet.Tables.Add(dataXetNghiem_CSBT);
            var dataXetNghiem_TinhToan = _systemConfigService.Data_dm_xetnghiem_tinhtoan(null).Copy();
            dataXetNghiem_TinhToan.TableName = tableXetNghiem_TinhToan;
            dataSet.Tables.Add(dataXetNghiem_TinhToan);

            if (dataSet.Tables.Count > 0)
            {
                SaveFileDialog diag = new SaveFileDialog();
                diag.Filter = "XML|*.xml";
                diag.FileName = "TPH_DMXetNghiem.xml";
                diag.ShowDialog();
                if (diag.FileName != null)
                {
                    dataSet.WriteXml(diag.FileName, XmlWriteMode.WriteSchema);
                    CustomMessageBox.MSG_Information_OK("Xuất hoàn thành.");
                }
            }
        }

        private void btnImportDM_XML_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.Filter = "XML|*.xml";
            diag.ShowDialog();
            if (!string.IsNullOrEmpty(diag.FileName))
            {
                var xmlString = File.ReadAllText(diag.FileName);
                var stringReader = new StringReader(xmlString);
                var dsSet = new DataSet();
                dsSet.ReadXml(stringReader);
                if (dsSet.Tables.Count > 0)
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes("Thực hiện import danh mục?"))
                    {
                        //Xử lý từng datatable
                        bool haveError = false;
                        //Data danh mục loại mẫu - chính
                        if (dsSet.Tables.IndexOf(tableLoaiMauChinh) > -1)
                        {
                            var data = dsSet.Tables[tableLoaiMauChinh];
                            var lstObj = new List<DM_XETNGHIEM_LOAIMAUCHINH>();
                            foreach (DataRow dataRow in data.Rows)
                            {
                                var objAdd = (DM_XETNGHIEM_LOAIMAUCHINH)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_LOAIMAUCHINH(), dataRow);
                                if (!string.IsNullOrEmpty(objAdd.Maloaimauchinh))
                                {
                                    lstObj.Add(objAdd);
                                }
                            }
                            if (lstObj.Count > 0)
                            {
                                foreach (var obj in lstObj)
                                {
                                    if (_systemConfigService.Data_dm_xetnghiem_loaimauchinh(obj.Maloaimauchinh).Rows.Count == 0)
                                    {
                                        if (_systemConfigService.Insert_dm_xetnghiem_loaimauchinh(obj).Id < 1)
                                        {
                                            haveError = true;
                                            WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM loại mẫu chính import lỗi: {0}", obj.Maloaimauchinh));
                                        }
                                    }
                                    else
                                    {
                                        haveError = true;
                                        WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM loại mẫu chính import lỗi: {0} - Loại mẫu chính đã tồn tại", obj.Maloaimauchinh));
                                    }
                                }
                            }
                        }
                        //Data danh mục loại mẫu - Nhóm
                        if (dsSet.Tables.IndexOf(tableLoaiMauNhom) > -1)
                        {
                            var data = dsSet.Tables[tableLoaiMauNhom];
                            var lstObj = new List<DM_XETNGHIEM_LOAIMAU_NHOM>();
                            foreach (DataRow dataRow in data.Rows)
                            {
                                var objAdd = (DM_XETNGHIEM_LOAIMAU_NHOM)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_LOAIMAU_NHOM(), dataRow);
                                if (!string.IsNullOrEmpty(objAdd.Manhomloaimau))
                                {
                                    lstObj.Add(objAdd);
                                }
                            }
                            if (lstObj.Count > 0)
                            {
                                foreach (var obj in lstObj)
                                {
                                    if (_systemConfigService.Data_dm_xetnghiem_loaimau_nhom(obj.Manhomloaimau, false, string.Empty).Rows.Count == 0)
                                    {
                                        if (_systemConfigService.Insert_dm_xetnghiem_loaimau_nhom(obj).Id < 1)
                                        {
                                            haveError = true;
                                            WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM nhóm loại mẫu import lỗi: {0}", obj.Manhomloaimau));
                                        }
                                    }
                                    else
                                    {
                                        haveError = true;
                                        WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM nhóm loại mẫu import lỗi: {0} - Nhóm loại mẫu đã tồn tại", obj.Manhomloaimau));
                                    }
                                }
                            }
                        }
                        //Data danh mục loại mẫu chạy
                        if (dsSet.Tables.IndexOf(tableLoaiMauChay) > -1)
                        {
                            var data = dsSet.Tables[tableLoaiMauChay];
                            var lstObj = new List<DM_XETNGHIEM_LOAIMAU>();
                            foreach (DataRow dataRow in data.Rows)
                            {
                                var objAdd = (DM_XETNGHIEM_LOAIMAU)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_LOAIMAU(), dataRow);
                                if (!string.IsNullOrEmpty(objAdd.Maloaimau))
                                {
                                    lstObj.Add(objAdd);
                                }
                            }
                            if (lstObj.Count > 0)
                            {
                                foreach (var obj in lstObj)
                                {
                                    obj.Nguoinhap = CommonAppVarsAndFunctions.UserID;
                                    if (!_systemConfigService.CheckExists_dm_xetnghiem_loaimau(obj.Maloaimau))
                                    {
                                        if (_systemConfigService.Insert_dm_xetnghiem_loaimau(obj) < 1)
                                        {
                                            haveError = true;
                                            WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM loại mẫu import lỗi: {0}", obj.Maloaimau));
                                        }
                                    }
                                    else
                                    {
                                        haveError = true;
                                        WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM loại mẫu import lỗi: {0} - Loại mẫu đã tồn tại", obj.Maloaimau));
                                    }
                                }
                            }
                        }
                        //Data danh mục bộ phận xét nghiệm
                        if (dsSet.Tables.IndexOf(tableXetNghiem_Nhom) > -1)
                        {
                            var data = dsSet.Tables[tableXetNghiem_BoPhan];
                            var lstObj = new List<DM_XETNGHIEM_BOPHAN>();
                            foreach (DataRow dataRow in data.Rows)
                            {
                                var objAdd = (DM_XETNGHIEM_BOPHAN)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_BOPHAN(), dataRow);
                                if (!string.IsNullOrEmpty(objAdd.Mabophan))
                                {
                                    lstObj.Add(objAdd);
                                }
                            }
                            if (lstObj.Count > 0)
                            {
                                foreach (var obj in lstObj)
                                {
                                    obj.Nguoinhap = CommonAppVarsAndFunctions.UserID;
                                    if (!_systemConfigService.CheckExists_dm_xetnghiem_bophan(obj.Mabophan))
                                    {
                                        if (_systemConfigService.Insert_dm_xetnghiem_bophan(obj).Id < 1)
                                        {
                                            haveError = true;
                                            WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM bộ phận import lỗi: {0}", obj.Mabophan));
                                        }
                                    }
                                    else
                                    {
                                        haveError = true;
                                        WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM bộ phận import lỗi: {0} - Bộ phận đã tồn tại", obj.Mabophan));
                                    }
                                }
                            }
                        }
                        //Data danh mục nhóm xét nghiệm
                        if (dsSet.Tables.IndexOf(tableXetNghiem_Nhom) > -1)
                        {
                            var data = dsSet.Tables[tableXetNghiem_Nhom];
                            var lstObj = new List<DM_XETNGHIEM_NHOM>();
                            foreach (DataRow dataRow in data.Rows)
                            {
                                var objAdd = (DM_XETNGHIEM_NHOM)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_NHOM(), dataRow);
                                if (!string.IsNullOrEmpty(objAdd.Manhomcls))
                                {
                                    lstObj.Add(objAdd);
                                }
                            }
                            if (lstObj.Count > 0)
                            {
                                foreach (var obj in lstObj)
                                {
                                    obj.Nguoinhap = CommonAppVarsAndFunctions.UserID;
                                    if (!_systemConfigService.CheckExists_dm_xetnghiem_nhom(obj.Manhomcls))
                                    {
                                        if (_systemConfigService.Insert_dm_xetnghiem_nhom(obj) < 1)
                                        {
                                            haveError = true;
                                            WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM nhóm import lỗi: {0}", obj.Manhomcls));
                                        }
                                    }
                                    else
                                    {
                                        haveError = true;
                                        WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM nhóm import lỗi: {0} - Nhóm đã tồn tại", obj.Manhomcls));
                                    }
                                }
                            }
                        }
                        //Data danh mục xét nghiệm
                        if (dsSet.Tables.IndexOf(tableXetNghiem) > -1)
                        {
                            var data = dsSet.Tables[tableXetNghiem];
                            var lstObj = new List<DM_XETNGHIEM>();
                            foreach (DataRow dataRow in data.Rows)
                            {
                                var objAdd = (DM_XETNGHIEM)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM(), dataRow);
                                if (!string.IsNullOrEmpty(objAdd.Maxn))
                                {
                                    lstObj.Add(objAdd);
                                }
                            }
                            if (lstObj.Count > 0)
                            {
                                foreach (var obj in lstObj)
                                {
                                    obj.Nguoinhap = CommonAppVarsAndFunctions.UserID;
                                    if (!_systemConfigService.CheckExists_dm_xetnghiem(obj.Maxn))
                                    {
                                        if (_systemConfigService.Insert_dm_xetnghiem(obj) < 1)
                                        {
                                            haveError = true;
                                            WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM xét nghiệm import lỗi: {0}", obj.Maxn));
                                        }
                                    }
                                    else
                                    {
                                        haveError = true;
                                        WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM xét nghiệm import lỗi: {0} - Xét nghiệm đã tồn tại", obj.Maxn));
                                    }
                                }
                            }
                        }
                        //Data danh mục profile
                        if (dsSet.Tables.IndexOf(tableXetNghiem_Profile) > -1)
                        {
                            var data = dsSet.Tables[tableXetNghiem_Profile];
                            var lstObj = new List<DM_XETNGHIEM_PROFILE>();
                            foreach (DataRow dataRow in data.Rows)
                            {
                                var objAdd = (DM_XETNGHIEM_PROFILE)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_PROFILE(), dataRow);
                                if (!string.IsNullOrEmpty(objAdd.Profileid))
                                {
                                    lstObj.Add(objAdd);
                                }
                            }
                            if (lstObj.Count > 0)
                            {
                                foreach (var obj in lstObj)
                                {
                                    obj.Nguoinhap = CommonAppVarsAndFunctions.UserID;
                                    if (!_systemConfigService.CheckExists_dm_xetnghiem_profile(obj.Profileid))
                                    {
                                        if (_systemConfigService.Insert_dm_xetnghiem_profile(obj) < 1)
                                        {
                                            haveError = true;
                                            WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM xét nghiệm - profile import lỗi: {0}", obj.Profileid));
                                        }
                                    }
                                    else
                                    {
                                        haveError = true;
                                        WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM xét nghiệm - profile  import lỗi: {0} - Profile đã tồn tại", obj.Profileid));
                                    }
                                }
                            }
                        }
                        //Data danh mục profile - chi tiết
                        if (dsSet.Tables.IndexOf(tableXetNghiem_Profile_ChiTiet) > -1)
                        {
                            var data = dsSet.Tables[tableXetNghiem_Profile_ChiTiet];
                            var lstObj = new List<DM_XETNGHIEM_PROFILE_CHITIET>();
                            foreach (DataRow dataRow in data.Rows)
                            {
                                var objAdd = (DM_XETNGHIEM_PROFILE_CHITIET)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_PROFILE_CHITIET(), dataRow);
                                if (!string.IsNullOrEmpty(objAdd.Profileid))
                                {
                                    lstObj.Add(objAdd);
                                }
                            }
                            if (lstObj.Count > 0)
                            {
                                foreach (var obj in lstObj)
                                {
                                    obj.Nguoinhap = CommonAppVarsAndFunctions.UserID;
                                    if (!_systemConfigService.CheckExists_dm_xetnghiem_profile_chitiet(obj.Profileid, obj.Maxn))
                                    {
                                        if (_systemConfigService.Insert_dm_xetnghiem_profile_chitiet(obj) < 1)
                                        {
                                            haveError = true;
                                            WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM xét nghiệm - profile - chi tiết import lỗi: {0} - {1}", obj.Profileid, obj.Maxn));
                                        }
                                    }
                                    else
                                    {
                                        haveError = true;
                                        WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM xét nghiệm - profile - chi tiết import lỗi: {0} - {1} - Profile - chi tiết đã tồn tại", obj.Profileid, obj.Maxn));
                                    }
                                }
                            }
                        }
                        //Data danh mục tinh toán
                        if (dsSet.Tables.IndexOf(tableXetNghiem_TinhToan) > -1)
                        {
                            var data = dsSet.Tables[tableXetNghiem_TinhToan];
                            var lstObj = new List<DM_XETNGHIEM_TINHTOAN>();
                            foreach (DataRow dataRow in data.Rows)
                            {
                                var objAdd = (DM_XETNGHIEM_TINHTOAN)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_TINHTOAN(), dataRow);
                                if (!string.IsNullOrEmpty(objAdd.Maxn))
                                {
                                    lstObj.Add(objAdd);
                                }
                            }
                            if (lstObj.Count > 0)
                            {
                                foreach (var obj in lstObj)
                                {
                                    obj.Nguoinhap = CommonAppVarsAndFunctions.UserID;
                                    try
                                    {
                                        if (_systemConfigService.Insert_dm_xetnghiem_tinhtoan(obj) < 1)
                                        {
                                            haveError = true;
                                            WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM xét nghiệm - tính toán import lỗi: {0}", obj.Maxn));
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        haveError = true;
                                        WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM xét nghiệm - tính toán  import lỗi: {0} - {1}", obj.Maxn, ex.Message));
                                    }
                                }
                            }
                        }
                        //Data danh mục csbt
                        if (dsSet.Tables.IndexOf(tableXetNghiem_CSBT) > -1)
                        {
                            var data = dsSet.Tables[tableXetNghiem_CSBT];
                            var lstObj = new List<DM_XETNGHIEM_CSBT>();
                            foreach (DataRow dataRow in data.Rows)
                            {
                                var objAdd = (DM_XETNGHIEM_CSBT)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_CSBT(), dataRow);
                                if (!string.IsNullOrEmpty(objAdd.Maxn))
                                {
                                    lstObj.Add(objAdd);
                                }
                            }
                            if (lstObj.Count > 0)
                            {
                                foreach (var obj in lstObj)
                                {
                                    obj.Nguoinhap = CommonAppVarsAndFunctions.UserID;
                                    try
                                    {
                                        if (_systemConfigService.Insert_dm_xetnghiem_csbt(obj) < 1)
                                        {
                                            haveError = true;
                                            WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM xét nghiệm - CSBT import lỗi: {0}", obj.Maxn));
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        haveError = true;
                                        WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM xét nghiệm - CSBT import lỗi: {0} - {1}", obj.Maxn, ex.Message));
                                    }
                                }
                            }
                        }
                        //Data danh mục phương pháp, quy trình
                        if (dsSet.Tables.IndexOf(tableXetNghiem_PhuongPhapQuyTrinh) > -1)
                        {
                            var data = dsSet.Tables[tableXetNghiem_PhuongPhapQuyTrinh];
                            var lstObj = new List<DM_XETNGNGHIEM_PHUONGPHAP>();
                            foreach (DataRow dataRow in data.Rows)
                            {
                                var objAdd = (DM_XETNGNGHIEM_PHUONGPHAP)WorkingServices.Get_InfoForObject(new DM_XETNGNGHIEM_PHUONGPHAP(), dataRow);
                                if (!string.IsNullOrEmpty(objAdd.Maxn))
                                {
                                    lstObj.Add(objAdd);
                                }
                            }
                            if (lstObj.Count > 0)
                            {
                                foreach (var obj in lstObj)
                                {
                                    obj.Nguoinhap = CommonAppVarsAndFunctions.UserID;
                                    try
                                    {
                                        if (_systemConfigService.Insert_dm_xetngnghiem_phuongphap(obj) < 1)
                                        {
                                            haveError = true;
                                            WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM xét nghiệm - Phương pháp, quy trình import lỗi: {0}", obj.Maxn));
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        haveError = true;
                                        WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM xét nghiệm - Phương pháp, quy trình import lỗi: {0} - {1}", obj.Maxn, ex.Message));
                                    }
                                }
                            }
                        }
                        //Data danh mục ghi chú
                        if (dsSet.Tables.IndexOf(tableXetNghiem_GhiChu) > -1)
                        {
                            var data = dsSet.Tables[tableXetNghiem_GhiChu];
                            var lstObj = new List<DM_XETNGHIEM_GHICHUTUDONG>();
                            foreach (DataRow dataRow in data.Rows)
                            {
                                var objAdd = (DM_XETNGHIEM_GHICHUTUDONG)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_GHICHUTUDONG(), dataRow);
                                if (!string.IsNullOrEmpty(objAdd.Maxn))
                                {
                                    lstObj.Add(objAdd);
                                }
                            }
                            if (lstObj.Count > 0)
                            {
                                foreach (var obj in lstObj)
                                {
                                    obj.Nguoinhap = CommonAppVarsAndFunctions.UserID;
                                    try
                                    {
                                        if (_systemConfigService.Insert_dm_xetnghiem_ghichutudong(obj) < 1)
                                        {
                                            haveError = true;
                                            WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM xét nghiệm - Ghi chú tự động import lỗi: {0}", obj.Maxn));
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        haveError = true;
                                        WriteLog.LogService.RecordLogFile("Log_ImportXM_", string.Format("DM xét nghiệm - Ghi chú tự động import lỗi: {0} - {1}", obj.Maxn, ex.Message));
                                    }
                                }
                            }
                        }
                        if (haveError)
                            CustomMessageBox.MSG_Information_OK("Quá trình import có phát sinh lỗi, vui lòng kiểm tra log file: Log_ImportXM");
                        else
                            CustomMessageBox.MSG_Information_OK("Import hoàn thành.");
                    }
                }
            }
        }

        private void btnNhapXuatDanhMuc_Click(object sender, EventArgs e)
        {
            tabLIS.SelectedIndex = 9;
            HightLightButton((Button)sender);
        }
    }
}