using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using OutlookStyleControls;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.App.AppCode.Patient;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Patient.Constants;
using TPH.LIS.Patient.Model;
using TPH.LIS.Patient.Services;
using TPH.LIS.User.Enum;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.TestResult.Services;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Common;
using TPH.LIS.Log;
using System.Collections.Generic;
using TPH.Data.HIS.HISDataCommon;
using TPH.Lab.Middleware.LISConnect.Services;
using TPH.Lab.Middleware.HISConnect.Services;
using TPH.Data.HIS.Models;
using TPH.WriteLog;
using System.Linq;
using System.Diagnostics;
using TPH.Common.Converter;
using System.Threading.Tasks;
using System.Text;
using TPH.Excel;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace TPH.LIS.App.ThucThi.BenhNhan
{

    public partial class FrmNhapKSK : FrmTemplate
    {
        private readonly C_BenhNhan_TiepNhan _data = new C_BenhNhan_TiepNhan();
        private DataTable _dtDanhMucDichVu = new DataTable();
        private DataTable _dtDanhsanhChiDinh = new DataTable();
        private readonly IPatientInformationService _informationService = new PatientInformationService();
        private readonly ITestResultService _pXetnghiem = new TestResultService();
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        User.Services.UserManagement.IUserManagementService user = new User.Services.UserManagement.UserManagementService();
        private readonly C_Patient_SieuAm _pSieuam = new C_Patient_SieuAm();

        private readonly C_Patient_XQuang _pXquang = new C_Patient_XQuang();
        private readonly C_Patient_NoiSoi _pNoisoi = new C_Patient_NoiSoi();
        private readonly C_Patient_KhamBenh _pKhambenh = new C_Patient_KhamBenh();
        private readonly C_Patient_DichVu_Khac _pDvkhac = new C_Patient_DichVu_Khac();

        private readonly IConnectHISService _iHisData = new ConnectHISService();
        private readonly IGetHISService _iHisService = new GetHISService();
        private HISDataColumnNames hColumnNames;
        private DM_KHULAYMAU objKhuLayMau = new DM_KHULAYMAU();
        HisConnection hisInfo;
        private string _displayMember = string.Empty;
        private string _valueMember = string.Empty;
        HisProvider hisWorking = HisProvider.DH_API;
        private const string NhapDanhSach_CheDoNhapDaySoLienTuc = "NhapDanhSach_CheDoNhapDaySoLienTuc";
        private const string NhapDanhSach_InBarcode = "NhapDanhSach_Inbarcode";
        private const string NhapDanhSach_LayThongTinHIS = "NhapDanhSach_LayThongTinHIS";
        private const string NhapDanhSach_LayThongTinHISChuaLaymau = "NhapDanhSach_LayThongTinHISChuaLaymau";
        private const string NhapDanhSach_ChiDinhTheoDanhSach = "NhapDanhSach_ChiDinhTheoDanhSach";
        private const string NhapDanhSach_CapBarcodeTuDong = "NhapDanhSach_CapBarcodeTuDong";
        public FrmNhapKSK()
        {
            InitializeComponent();
        }

        private void Load_NhomCLS()
        {
            if (cboLoaiDichVu.SelectedIndex > -1)
            {
                _data.Load_Nhom_TheoDVCLS(cboNhomDichVu, cboLoaiDichVu.SelectedValue.ToString());
                Load_ChiDinhCLS();
            }
        }
        BindingNavigator bvXetNghiem = new BindingNavigator();
        BindingSource bsXetNghiem = new BindingSource();
        private void Load_ChiDinhCLS()
        {
            if (cboLoaiDichVu.SelectedIndex > -1)
            {
                string doiTuongDv = (cboDoiTuongDichVu.SelectedIndex == -1
                    ? ""
                    : cboDoiTuongDichVu.SelectedValue.ToString().Trim());
                string loaiDichVu = cboLoaiDichVu.SelectedValue.ToString().Trim();
                string nhom = (cboNhomDichVu.SelectedIndex < 0 ? "" : cboNhomDichVu.SelectedValue.ToString().Trim());
                _dtDanhMucDichVu = _data.Load_ChiDinhCLS(null, loaiDichVu, nhom, "A", doiTuongDv);

                bsXetNghiem.DataSource = _dtDanhMucDichVu;
                dgvXetNghiem.DataSource = bsXetNghiem;
                bvXetNghiem.BindingSource = bsXetNghiem;

                SearchTest();

            }
        }
        void SearchTest()
        {
            if (bvXetNghiem.BindingSource != null)
            {
                bvXetNghiem.BindingSource.Filter = string.Format("TenXN like '%{0}%'", txtTimDichVu.Text);
            }
        }
        private void Get_Value_DisplayMember(string loaiDichVu, ref string displayMember, ref string valueMember)
        {
            if (loaiDichVu.Equals(ServiceType.ClsXetNghiem.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                displayMember = "TenXN";
                valueMember = "MaXN";
            }
            else if (loaiDichVu.Equals(ServiceType.ClsSieuAm.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                displayMember = "TenMauSieuAm";
                valueMember = "MaSoMau";
            }
            else if (loaiDichVu.Equals(ServiceType.ClsXQuang.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                displayMember = "TenVungChup";
                valueMember = "MaVungChup";
            }
            else if (loaiDichVu.Equals(ServiceType.ClsNoiSoi.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                displayMember = "TenMauNoiSoi";
                valueMember = "MaSoMauNoiSoi";
            }
            else if (loaiDichVu.Equals(ServiceType.KhamBenh.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                displayMember = "TenYeuCau";
                valueMember = "MaYeuCau";
            }
            else if (loaiDichVu.Equals(ServiceType.DvKhac.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                displayMember = "tendvkhac";
                valueMember = "madvkhac";
            }
            else if (loaiDichVu.Equals(ServiceType.Duoc.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                displayMember = "TenVatTu";
                valueMember = "MaVatTu";
            }
            else
            {
                displayMember = string.Empty;
                valueMember = string.Empty;
            }
        }

        private void Add_OrderToList()
        {
            if (dgvXetNghiem.RowCount > 0)
            {
                DataRow drAdd;
                //DataTable dt = (DataTable)chlDSDichVu.DataSource;

                string loaiDichVu = cboLoaiDichVu.SelectedValue.ToString().Trim();
                //string displayMember = string.Empty;
                //string valueMember = string.Empty;
                //Get_Value_DisplayMember(loaiDichVu, ref displayMember, ref valueMember);

                string maChiDinh = string.Empty;
                string tenChiDinh = string.Empty;
                string tenLoaiDichVu = string.Empty;
                bool isProfile = false;
                bool group = false;
                bool _allow = false;

                for (int i = 0; i < dgvXetNghiem.RowCount; i++)
                {
                    if ((bool)dgvXetNghiem.Rows[i].Cells[Checked.Name].Value == true)
                    {
                        maChiDinh = dgvXetNghiem.Rows[i].Cells[MaXN.Name].Value.ToString();
                        tenChiDinh = dgvXetNghiem.Rows[i].Cells[TenXN.Name].Value.ToString();
                        tenLoaiDichVu = txtLoaiDichVu.Text;
                        isProfile = dgvXetNghiem.Rows[i].Cells[TenXN.Name].Value.ToString().Contains(ProfileTestContant.ProfileChar);
                        group = dgvXetNghiem.Rows[i].Cells[TenXN.Name].Value.ToString().Contains(ProfileTestContant.GroupChar);
                        _allow = true;
                        if (group)
                        {
                            var dataChiTietBo = sysConfig.Data_dm_xetnghiem_bo_chitiet(maChiDinh, string.Empty, false);
                            if (dataChiTietBo.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dataChiTietBo.Rows)
                                {
                                    var isProfileSub = bool.Parse(dr["XNProfile"].ToString());
                                    var maChiDinhSub = dr["MaChiDinh"].ToString();
                                    var TenChiDinhsub = dr["TenXN"].ToString();
                                    var pChar = isProfileSub ? ProfileTestContant.ProfileChar : ProfileTestContant.TestChar;
                                    //Kiểm tra trùng
                                    if (_dtDanhsanhChiDinh.Rows.Count > 0)
                                    {
                                        for (int x = 0; x < _dtDanhsanhChiDinh.Rows.Count; x++)
                                        {
                                            if (_dtDanhsanhChiDinh.Rows[x]["MaChiDinh"].ToString()
                                                .Equals(maChiDinhSub, StringComparison.OrdinalIgnoreCase)
                                                &&
                                                _dtDanhsanhChiDinh.Rows[x]["MaLoaiDichVu"].ToString()
                                                    .Equals(loaiDichVu, StringComparison.OrdinalIgnoreCase)
                                                &&
                                                (bool)_dtDanhsanhChiDinh.Rows[x]["isProfile"] == isProfileSub)
                                            {
                                                _allow = false;
                                                break;
                                            }
                                        }
                                    }

                                    //Nếu sau kiểm tra cờ allow cho phép
                                    if (_allow)
                                    {
                                        drAdd = _dtDanhsanhChiDinh.NewRow();
                                        drAdd["MaChiDinh"] = maChiDinhSub;
                                        drAdd["TenChiDinh"] = TenChiDinhsub;
                                        drAdd["MaLoaiDichVu"] = loaiDichVu;
                                        drAdd["TenLoaiDichVu"] = tenLoaiDichVu;
                                        drAdd["IsProfile"] = isProfileSub;
                                        _dtDanhsanhChiDinh.Rows.Add(drAdd);
                                    }
                                }
                            }
                        }
                        else
                        {
                            //Kiểm tra trùng
                            if (_dtDanhsanhChiDinh.Rows.Count > 0)
                            {
                                for (int x = 0; x < _dtDanhsanhChiDinh.Rows.Count; x++)
                                {
                                    if (_dtDanhsanhChiDinh.Rows[x]["MaChiDinh"].ToString()
                                        .Equals(maChiDinh, StringComparison.OrdinalIgnoreCase)
                                        &&
                                        _dtDanhsanhChiDinh.Rows[x]["MaLoaiDichVu"].ToString()
                                            .Equals(loaiDichVu, StringComparison.OrdinalIgnoreCase)
                                        &&
                                        (bool)_dtDanhsanhChiDinh.Rows[x]["isProfile"] == isProfile)
                                    {
                                        _allow = false;
                                        break;
                                    }
                                }
                            }

                            //Nếu sau kiểm tra cờ allow cho phép
                            if (_allow)
                            {
                                drAdd = _dtDanhsanhChiDinh.NewRow();
                                drAdd["MaChiDinh"] = maChiDinh;
                                drAdd["TenChiDinh"] = tenChiDinh;
                                drAdd["MaLoaiDichVu"] = loaiDichVu;
                                drAdd["TenLoaiDichVu"] = tenLoaiDichVu;
                                drAdd["IsProfile"] = isProfile;
                                _dtDanhsanhChiDinh.Rows.Add(drAdd);
                            }

                            dgvXetNghiem.Rows[i].Cells[Checked.Name].Value = false;
                        }
                    }
                }
                _dtDanhsanhChiDinh.AcceptChanges();
                Set_DataOrder();
            }
        }
        private void Add_OrderToData()
        {

        }
        private void Set_DataOrder()
        {
            gcDanhSachChiDinh.DataSource = _dtDanhsanhChiDinh;
        }

        private void Delete_Order()
        {
            if (gvDanhSachChiDinh.RowCount > 0)
            {
                if (gvDanhSachChiDinh.FocusedRowHandle > -1)
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa chỉ định đang chọn ?"))
                    {
                        string loaiDichVu = gvDanhSachChiDinh.GetFocusedRowCellValue(MaLoaiDichVu).ToString().Trim();
       
                        string maDichVu = gvDanhSachChiDinh.GetFocusedRowCellValue(MaChiDinh).ToString().Trim();

                        bool isProfile = (bool)gvDanhSachChiDinh.GetFocusedRowCellValue(IsProfile);

                        for (int i = 0; i < _dtDanhsanhChiDinh.Rows.Count; i++)
                        {
                            if (_dtDanhsanhChiDinh.Rows[i]["MaChiDinh"].ToString()
                                .Equals(maDichVu, StringComparison.OrdinalIgnoreCase)
                                &&
                                _dtDanhsanhChiDinh.Rows[i]["MaLoaiDichVu"].ToString()
                                    .Equals(loaiDichVu, StringComparison.OrdinalIgnoreCase)
                                &&
                                (bool)_dtDanhsanhChiDinh.Rows[i]["isProfile"] == isProfile)
                            {
                                _dtDanhsanhChiDinh.Rows.RemoveAt(i);
                                break;
                            }
                        }
                        _dtDanhsanhChiDinh.AcceptChanges();
                        Set_DataOrder();
                    }

                }
            }
        }
        private void DocThongTinLuuReg()
        {
            radInputWithBarcodeRange.Checked = CommonAppVarsAndFunctions.RegistryExt.ReadRegistry(NhapDanhSach_CheDoNhapDaySoLienTuc) == "1";
            chkIncodeKhiNhap.Checked = CommonAppVarsAndFunctions.RegistryExt.ReadRegistry(NhapDanhSach_InBarcode) == "1";
            chkHISMode.Checked = CommonAppVarsAndFunctions.RegistryExt.ReadRegistry(NhapDanhSach_LayThongTinHIS) == "1";
            chkChiDInhChuaLayMau.Checked = CommonAppVarsAndFunctions.RegistryExt.ReadRegistry(NhapDanhSach_LayThongTinHISChuaLaymau) == "1";
            radChiDinhNhapDanhSach.Checked = CommonAppVarsAndFunctions.RegistryExt.ReadRegistry(NhapDanhSach_ChiDinhTheoDanhSach) == "1";
            chkTuTaoCode.Checked = CommonAppVarsAndFunctions.RegistryExt.ReadRegistry(NhapDanhSach_CapBarcodeTuDong) == "1";
        }
        private void GhiThongTinReg()
        {
          CommonAppVarsAndFunctions.RegistryExt.WriteRegistry(NhapDanhSach_CheDoNhapDaySoLienTuc, (radInputWithBarcodeRange.Checked ?"1" : "0"));
          CommonAppVarsAndFunctions.RegistryExt.WriteRegistry(NhapDanhSach_InBarcode, (chkIncodeKhiNhap.Checked ? "1" : "0"));
          CommonAppVarsAndFunctions.RegistryExt.WriteRegistry(NhapDanhSach_LayThongTinHIS, (chkHISMode.Checked ? "1" : "0"));
          CommonAppVarsAndFunctions.RegistryExt.WriteRegistry(NhapDanhSach_LayThongTinHISChuaLaymau, (chkChiDInhChuaLayMau.Checked ? "1" : "0"));
          CommonAppVarsAndFunctions.RegistryExt.WriteRegistry(NhapDanhSach_ChiDinhTheoDanhSach, (radChiDinhNhapDanhSach.Checked ? "1" : "0"));
          CommonAppVarsAndFunctions.RegistryExt.WriteRegistry(NhapDanhSach_CapBarcodeTuDong, (chkTuTaoCode.Checked ? "1" : "0"));
        }
        private void FrmNhapKSK_Load(object sender, EventArgs e)
        {
            dgvXetNghiem.AutoGenerateColumns = false;
            objKhuLayMau = sysConfig.Get_Info_dm_khulaymau_Theomaytinh(Environment.MachineName);
            Create_Datatble_DSChiDinh();
            sysConfig.Get_DoiTuongDichVu(cboDoiTuongDichVu, txtDoiTuongDichVu);
            ucSearchLookupEditor_BSChiDinh.Load_BacSi();
            TPH.LIS.Configuration.Services.SystemConfig.ISystemConfigService _systemConfig = new TPH.LIS.Configuration.Services.SystemConfig.SystemConfigService();
            _systemConfig.GetLocation(cboDonVi, "MaKhoaPhong", "MaKhoaPhong", "MaKhoaPhong,TenKhoaPhong", "50,200", txtDonVi, 1, string.Empty, string.Empty);

            if (cboDoiTuongDichVu.Items.Count > 0)
                cboDoiTuongDichVu.SelectedIndex = 0;

            _data.Get_CauHinh_PhanLoaiChucNang(cboLoaiDichVu, txtLoaiDichVu, "and PhanLoaiNhom in (1,2)");
            if (cboLoaiDichVu.Items.Count > 0)
            {
                cboLoaiDichVu.SelectedValue = "CLSXetNghiem";
                cboLoaiDichVu.Enabled = false;
                Load_ChiDinhCLS();
                Load_NhomCLS();
            }
            chkHISMode.Checked = false;
            DocThongTinLuuReg();
        }

        private void Create_Datatble_DSChiDinh()
        {
            _dtDanhsanhChiDinh = new DataTable();
            _dtDanhsanhChiDinh.Columns.Add("TenChiDinh", typeof(string));
            _dtDanhsanhChiDinh.Columns.Add("MaChiDinh", typeof(string));
            _dtDanhsanhChiDinh.Columns.Add("TenLoaiDichVu", typeof(string));
            _dtDanhsanhChiDinh.Columns.Add("MaLoaiDichVu", typeof(string));
            _dtDanhsanhChiDinh.Columns.Add("IsProfile", typeof(bool));
        }
        List<string> lstLimtTest = new List<string>() { "XE39", "XE42", "XE43", "XE44", "XE45", "XE46", "XE47" };
        private void InsertWithHISMode()
        {
            if (gvDanhSachImport.RowCount > 0)
            {
                var ngayLayMau = CommonAppVarsAndFunctions.ServerTime;
                var dataMapping = new DataTable();
                var dataDmXetNghiem = sysConfig.Data_dm_xetnghiem(string.Empty, false, string.Empty);
                hisInfo = CommonAppVarsAndFunctions.HisConnectList.Where(x => x.HisID == hisWorking).FirstOrDefault();
                hColumnNames = _iHisData.GetHisThongTinMappingCot(hisInfo, CommonAppVarsAndFunctions.HisDataColumnsList);
                dataMapping = _iHisData.DataMapping((int)hisWorking);
              
                for (int i = 0; i < gvDanhSachImport.RowCount; i++)
                {
                    try
                    {
                        var maSoPhieu = gvDanhSachImport.GetRowCellValue(i,colMaChiDinhHIS.Name).ToString().Trim();
                        var maBn = gvDanhSachImport.GetRowCellValue(i, colMaBN.Name).ToString().Trim();
                        var ngaychidinh = DateTime.Parse(gvDanhSachImport.GetRowCellValue(i, colNgayChiDinhHIS.Name).ToString());
                        var barcode = (gvDanhSachImport.GetRowCellValue(i, colBarcode.Name) ?? string.Empty).ToString();
                        var data = LoadOrderDetailFromHIS(maSoPhieu, true, null, ngaychidinh.Date, null, false, string.Empty, maBn, string.Empty);
                        if (data.Rows.Count > 0)
                        {
                            var idChuyenMau = TaoIdChuyenMau();
                            //Search lại data có ngày chỉ định tương ứng
                            var dataWithOrderDate = WorkingServices.SearchResult_OnDatatable(data, string.Format("{0} = '{1}'", hColumnNames.chidinhNgaychidinh, ngaychidinh));
                            if (dataWithOrderDate.Rows.Count > 0)
                            {
                                var bnInfo = new BenhNhanInfoForHIS { };
                                var row = dataWithOrderDate.Rows[0];
                                //Lấy thông tin bệnh nhân
                                string SoPhieuYeuCau = string.IsNullOrEmpty(hColumnNames.chidinhSophieuyeucau)
                             ? string.Empty
                             : StringConverter.ToString(row[hColumnNames.chidinhSophieuyeucau]),
                          MaBenhNhan = StringConverter.ToString(row[hColumnNames.chidinhMabenhnhan]),
                          TenBenhNhan = StringConverter.ToString(row[hColumnNames.chidinhTenbenhnhan]).ToUpper(),
                          NamSinh = string.IsNullOrEmpty(hColumnNames.chidinhNamsinh)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhNamsinh]),
                          GioiTinh = string.IsNullOrEmpty(hColumnNames.chidinhGioitinh)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhGioitinh]),
                          DiaChi = string.IsNullOrEmpty(hColumnNames.chidinhDiachi)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhDiachi]),
                          ChanDoan = string.IsNullOrEmpty(hColumnNames.chidinhChandoan)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhChandoan]),
                          MaDoiTuong = string.IsNullOrEmpty(hColumnNames.chidinhMadoituong)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhMadoituong]),
                          MaBacSi = string.IsNullOrEmpty(hColumnNames.chidinhMabacsi)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhMabacsi]),
                          MaKhoaPhong = string.IsNullOrEmpty(hColumnNames.chidinhMakhoaphong)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhMakhoaphong]),
                          TenDoiTuong = string.IsNullOrEmpty(hColumnNames.chidinhTendoituong)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhTendoituong]),
                          TenBacSi = string.IsNullOrEmpty(hColumnNames.chidinhTenbacsi)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhTenbacsi]),
                          TenKhoaPhong = string.IsNullOrEmpty(hColumnNames.chidinhTenkhoaphong)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhTenkhoaphong]),
                          MaChanDoan = string.IsNullOrEmpty(hColumnNames.chidinhMachandoan)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhMachandoan]),
                          MaDichVu = string.IsNullOrEmpty(hColumnNames.chidinhMadichvu)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhMadichvu]),
                          TenDV = string.IsNullOrEmpty(hColumnNames.chidinhTendv)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhTendv]),
                          Sothebhyt = string.IsNullOrEmpty(hColumnNames.chidinhSothebhyt)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhSothebhyt]),
                          Sophong = string.IsNullOrEmpty(hColumnNames.chidinhSophong)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhSophong]),
                          Buong = string.IsNullOrEmpty(hColumnNames.chidinhBuong)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhBuong]),
                          Giuong = string.IsNullOrEmpty(hColumnNames.chidinhGiuong)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhGiuong]),
                          DotKhamID = string.IsNullOrEmpty(hColumnNames.chidinhDotKhamID)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhDotKhamID]),
                          ChuyenKhoaID = string.IsNullOrEmpty(hColumnNames.chiDinhChuyenKhoaID)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chiDinhChuyenKhoaID]),
                          GiayToID = string.IsNullOrEmpty(hColumnNames.chidinhGiayToID)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhGiayToID]),
                          IdChuNangCLS = string.IsNullOrEmpty(hColumnNames.chidinhLoaiChucNangCLSID)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhLoaiChucNangCLSID]),
                          IdNhomChucNangCLS = string.IsNullOrEmpty(hColumnNames.chidinhNhomChucNangCLSID)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhNhomChucNangCLSID]),
                          BnID = string.IsNullOrEmpty(hColumnNames.chidinhMabenhan)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhMabenhan]),
                          MaNoiCapTheBHYT = string.IsNullOrEmpty(hColumnNames.chidinhMaNoiCapTheBhyt)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhMaNoiCapTheBhyt]),
                          MaNoiDangKyBHYT = string.IsNullOrEmpty(hColumnNames.chidinhMaNoiDangKyTheBhyt)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhMaNoiDangKyTheBhyt]),
                          IdDmChiPhi = string.IsNullOrEmpty(hColumnNames.chidinhDMChiPhiID)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhDMChiPhiID]),
                          ChiDinhID = string.IsNullOrEmpty(hColumnNames.chidinhIdchidinh)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhIdchidinh]),
                          DienThoai = string.IsNullOrEmpty(hColumnNames.chidinhSodienthoai)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhSodienthoai]),
                          MaLoaiXetNghiem = string.IsNullOrEmpty(hColumnNames.chidinhMaloai)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhMaloai]),
                          NamKT = string.IsNullOrEmpty(hColumnNames.chidinhNamkt)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhNamkt]),
                          ThangKT = string.IsNullOrEmpty(hColumnNames.chidinhThangkt)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhThangkt]),
                          MaNVChiDinh = string.IsNullOrEmpty(hColumnNames.chiDinhManvChidinh)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chiDinhManvChidinh]),
                         NhomMau = string.IsNullOrEmpty(hColumnNames.chidinhNhomMau)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhNhomMau]),
                          Rh = string.IsNullOrEmpty(hColumnNames.chidinhRh)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhRh]),
                          MaDVHD = string.IsNullOrEmpty(hColumnNames.chidinhMadvhd)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhMadvhd]),
                          TenDVHD = string.IsNullOrEmpty(hColumnNames.chidinhTendvhd)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhTendvhd]),
                          MaPhong = string.IsNullOrEmpty(hColumnNames.chidinhMaphong)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhMaphong]),
                          TenPhong = string.IsNullOrEmpty(hColumnNames.chidinhTenphong)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhTenphong]),
                          BenhKemTheo = string.IsNullOrEmpty(hColumnNames.chidinhBenhkemtheo)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhBenhkemtheo]),
                          NoiCongTac = string.IsNullOrEmpty(hColumnNames.chidinhNoicongtac)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhNoicongtac]);
                                bool KhamSucKhoe = !string.IsNullOrEmpty(hColumnNames.chidinhKhamsuckhoe) &&
                                        (bool)row[hColumnNames.chidinhKhamsuckhoe],
                               NoiTru = !string.IsNullOrEmpty(hColumnNames.chidinhNoitru) &&
                                   (bool)row[hColumnNames.chidinhNoitru];
                                var Uutien = string.IsNullOrEmpty(hColumnNames.chidinhUutien)
                              ? 0
                              : NumberConverter.ToInt(row[hColumnNames.chidinhUutien]);
                                string MaKhoaHienThoi = string.IsNullOrEmpty(hColumnNames.chidinhMakhoahienthoi)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhMakhoahienthoi]),
                          TenKhoaHienThoi = string.IsNullOrEmpty(hColumnNames.chidinhTenkhoahienthoi)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhTenkhoahienthoi]),
                          SoDienThoai = string.IsNullOrEmpty(hColumnNames.chidinhSodienthoai)
                              ? string.Empty
                              : StringConverter.ToString(row[hColumnNames.chidinhSodienthoai]);
                                DateTime? NgayHetHanBHYT = string.IsNullOrEmpty(hColumnNames.chidinhnNgayhethanbhy)
                              ? (DateTime?)null
                              : string.IsNullOrEmpty(StringConverter.ToString(row[hColumnNames.chidinhnNgayhethanbhy]))
                                  ? (DateTime?)null
                                  : TPH.Common.Converter.DateTimeConverter.ToDateTime(row[hColumnNames.chidinhnNgayhethanbhy]),
                          NgayVaoVien = string.IsNullOrEmpty(hColumnNames.chidinhNgayvaovien)
                              ? (DateTime?)null
                              : string.IsNullOrEmpty(StringConverter.ToString(row[hColumnNames.chidinhNgayvaovien]))
                                  ? (DateTime?)null
                                  : TPH.Common.Converter.DateTimeConverter.ToDateTime(row[hColumnNames.chidinhNgayvaovien]),
                          NgayNhapVien = string.IsNullOrEmpty(hColumnNames.chidinhNgaynhapvien)
                              ? (DateTime?)null
                              : string.IsNullOrEmpty(StringConverter.ToString(row[hColumnNames.chidinhNgaynhapvien]))
                                  ? (DateTime?)null
                                  : TPH.Common.Converter.DateTimeConverter.ToDateTime(row[hColumnNames.chidinhNgaynhapvien]),
                             NgayDK = string.IsNullOrEmpty(hColumnNames.chidinhNgaychidinh)
                              ? CommonAppVarsAndFunctions.ServerTime
                              : TPH.Common.Converter.DateTimeConverter.ToDateTime(row[hColumnNames.chidinhNgaychidinh]);

                                //Gán các giá trị vào thông tin bệnh nhân

                                bnInfo.Sophieuyeucau = SoPhieuYeuCau;
                                bnInfo.Mabn = MaBenhNhan;
                                bnInfo.Tenbn = TenBenhNhan;
                                bnInfo.Tuoi = int.Parse(NamSinh);
                                bnInfo.Sinhnhat = null;
                                if (GioiTinh.Trim().Equals("nữ", StringComparison.OrdinalIgnoreCase) ||
                                    GioiTinh.Equals("F", StringComparison.OrdinalIgnoreCase) ||
                                    GioiTinh.Equals("0", StringComparison.OrdinalIgnoreCase))
                                    bnInfo.Gioitinh = "F";
                                else if (GioiTinh.Trim().Equals("nam", StringComparison.OrdinalIgnoreCase) ||
                                         GioiTinh.Equals("m", StringComparison.OrdinalIgnoreCase) ||
                                         GioiTinh.Equals("1", StringComparison.OrdinalIgnoreCase))
                                    bnInfo.Gioitinh = "M";
                                else
                                    bnInfo.Gioitinh = string.Empty;
                                bnInfo.Diachi = DiaChi;
                                bnInfo.Chandoan = ChanDoan;
                                bnInfo.Doituongdichvu = MaDoiTuong;
                                bnInfo.Tendoituongdichvu = TenDoiTuong;
                                bnInfo.Bacsicd = MaBacSi;
                                bnInfo.Tenbacsichidinh = TenBacSi;
                                bnInfo.Madonvi = MaKhoaPhong;
                                bnInfo.Tendonvi = TenKhoaPhong;
                                bnInfo.Ngaytiepnhan = dtpDateIn.Value.Date;
                                bnInfo.Sobhyt = Sothebhyt;
                                bnInfo.Sdt = DienThoai;
                                bnInfo.Buong = Buong;
                                bnInfo.Giuong = Giuong;
                                bnInfo.Sdt = SoDienThoai;
                                bnInfo.Allowdownload = true;
                                //bnInfo.DateReceive = dtpNgayChiDinh.Value.Date;
                                bnInfo.Ngaydk = NgayDK;
                                bnInfo.Usernhap = CommonAppVarsAndFunctions.UserID;
                                bnInfo.Makhuvuc = CommonAppVarsAndFunctions.PCWorkPlace;
                                //DH CT
                                bnInfo.Dotkham_id = DotKhamID;
                                bnInfo.Chuyenkhoa_id = ChuyenKhoaID;
                                bnInfo.Giayto_id = GiayToID;
                                bnInfo.Bn_id = BnID;
                                bnInfo.Manoicapthebhyt = MaNoiCapTheBHYT;
                                bnInfo.Manoidangkythebhyt = MaNoiDangKyBHYT;
                                bnInfo.Madonvihopdong = MaDVHD;
                                bnInfo.Tendonvihopdong = TenDVHD;
                                bnInfo.Noitru = NoiTru;
                                bnInfo.Hisproviderid = (int)hisWorking;
                                bnInfo.Abo = NhomMau;
                                bnInfo.Rh = Rh;
                                bnInfo.Masophong = Sophong;
                                bnInfo.Noicongtac = NoiCongTac;
                                bnInfo.Tenphong = TenPhong;
                                bnInfo.Makhoahienthoi = MaKhoaHienThoi;
                                bnInfo.Tenkhoahienthoi = TenKhoaHienThoi;
                                bnInfo.Khamsuckhoe = KhamSucKhoe;
                                bnInfo.Bn_id = BnID;
                                //  Mức độ ưu tiên (vd: 1: TW – 2: Cấp cao – 3: Cấp cứu – 0: Thường)
                                bnInfo.Uutien = Uutien;
                                bnInfo.Capcuu = (Uutien == 3);
                                bnInfo.Ngayhethanbhyt = NgayHetHanBHYT;
                                bnInfo.Tgvaovien = NgayVaoVien;
                                bnInfo.Ngaynhapvien = NgayNhapVien;
                                var chuaThuphi = string.Empty;
                                var allowget = true;
                                bnInfo.Nguonnhap = InputSourceEnum.ByListHIS.ToString();
                                var currentOrderDate = CommonAppVarsAndFunctions.ServerTime;
                                var lstGioChiDinh = new List<DateTime>();
                                //Xử lý chỉ định
                                foreach (DataRow drDetail in dataWithOrderDate.Rows)
                                {
                                    //if (CommonAppVarsAndFunctions.WorkingHis == HisProvider.DH_DHG || CommonAppVarsAndFunctions.WorkingHis == HisProvider.DH_API)
                                    //{
                                    //    if (bool.Parse(drDetail[hColumnNames.chidinhDongTien).ToString()))
                                    //    {
                                    //        allowget = true;
                                    //    }
                                    //    else
                                    //    {
                                    //        allowget = false;
                                    //        chuaThuphi += string.IsNullOrEmpty(chuaThuphi)
                                    //            ? drDetail[hColumnNames.chidinhMaDichVu).ToString()
                                    //            : " | " + drDetail[hColumnNames.chidinhMaDichVu);
                                    //    }
                                    //}

                                    if (!allowget) continue;
                                    if (!lstLimtTest.Where(x => x.Equals(GetStringValueMapping(drDetail, hColumnNames.chidinhMadichvu), StringComparison.OrdinalIgnoreCase)).Any() && lstLimtTest.Count > 0)
                                        continue;
                                    var chiDInhInfo = new ChiDinhHISInfo();
                                    chiDInhInfo.LayMaCapTren = (CommonAppVarsAndFunctions.WorkingHis != HisProvider.DH_DHG && CommonAppVarsAndFunctions.WorkingHis != HisProvider.DH_API);
                                    chiDInhInfo.SoPhieuChiDinh = GetStringValueMapping(drDetail, hColumnNames.chidinhSophieuyeucau);

                                    chiDInhInfo.IDDichVuChiDinh = GetStringValueMapping(drDetail, hColumnNames.chidinhidDichvuchidinh);

                                    chiDInhInfo.TestCode = GetStringValueMapping(drDetail, hColumnNames.chidinhMadichvu);

                                    chiDInhInfo.TestName = GetStringValueMapping(drDetail, hColumnNames.chidinhTendv);
                                    chiDInhInfo.Khuvucnhanid = CommonAppVarsAndFunctions.PCWorkPlace;
                                    chiDInhInfo.Khuvucthuchienid = CommonAppVarsAndFunctions.PCWorkPlace;
                                    chiDInhInfo.Idloaichucnangcls = GetStringValueMapping(drDetail, hColumnNames.chidinhLoaiChucNangCLSID);
                                    chiDInhInfo.Idnhomchucnangcls = GetStringValueMapping(drDetail, hColumnNames.chidinhNhomChucNangCLSID);

                                    chiDInhInfo.Iddmchiphi = GetStringValueMapping(drDetail, hColumnNames.chidinhDMChiPhiID);
                                    chiDInhInfo.Bangkeid = GetStringValueMapping(drDetail, hColumnNames.chidinhIdchidinh);
                                    chiDInhInfo.IDBenh = GetStringValueMapping(drDetail, hColumnNames.chidinhMachandoan);
                                    chiDInhInfo.Thoigiangui = GetDateTimeValueMapping(drDetail, hColumnNames.chidinhThoigianyeucau);
                                    chiDInhInfo.MaLoaiXN_His = GetStringValueMapping(drDetail, hColumnNames.chidinhMaloai);
                                    chiDInhInfo.Namkt = GetStringValueMapping(drDetail, hColumnNames.chidinhNamkt);
                                    chiDInhInfo.Thangkt = GetStringValueMapping(drDetail, hColumnNames.chidinhThangkt);
                                    chiDInhInfo.MaNhanVienChiDinh = GetStringValueMapping(drDetail, hColumnNames.chiDinhManvChidinh);
                                    chiDInhInfo.MaBSChiDinh = GetStringValueMapping(drDetail, hColumnNames.chidinhMabacsi);
                                    chiDInhInfo.TenBSChiDinh = GetStringValueMapping(drDetail, hColumnNames.chidinhTenbacsi);
                                    chiDInhInfo.MaKhoaChiDinh = GetStringValueMapping(drDetail, hColumnNames.chidinhMakhoaphong);
                                    chiDInhInfo.TenKhoaChiDinh = GetStringValueMapping(drDetail, hColumnNames.chidinhTenkhoaphong);
                                    chiDInhInfo.MaXNCha_His = GetStringValueMapping(drDetail, hColumnNames.chidinhidDichvuchidinhcaptren);
                                    chiDInhInfo.IdChiTiet = GetStringValueMapping(drDetail, hColumnNames.chidinhIdChiTietChiDinh);
                                    chiDInhInfo.ThoiGianLayMau = GetDateTimeValueMapping(drDetail, hColumnNames.chidinhThoiGianLayMau);
                                    chiDInhInfo.NguoiLayMau = GetStringValueMapping(drDetail, hColumnNames.chidinhidNguoiLayMau);
                                    chiDInhInfo.TinhTrangMau = GetStringValueMapping(drDetail, hColumnNames.chidinhTinhTrangMau);
                                    chiDInhInfo.TTNguoiDuocLayMau = GetStringValueMapping(drDetail, hColumnNames.chidinhTTNguoiDuocLayMau);
                                    chiDInhInfo.ThoiGianGiaoMau = GetDateTimeValueMapping(drDetail, hColumnNames.chidinhThoiGianGiaoMau);
                                    chiDInhInfo.NguoiGiaoMau = GetStringValueMapping(drDetail, hColumnNames.chidinhNguoiGiaoMau);
                                    chiDInhInfo.ThoiGianInTem = GetDateTimeValueMapping(drDetail, hColumnNames.chidinhThoiGianInTem);
                                    chiDInhInfo.NguoiInTem = GetStringValueMapping(drDetail, hColumnNames.chidinhNguoiInTem);
                                    chiDInhInfo.STT = GetIntValueMapping(drDetail, hColumnNames.chidinhBarcodexn);
                                    chiDInhInfo.Barcode = GetStringValueMapping(drDetail, hColumnNames.chidinhBarcodexn);
                                    chiDInhInfo.MaKhoaHienThoi = GetStringValueMapping(drDetail, hColumnNames.chidinhMakhoahienthoi);
                                    chiDInhInfo.TenKhoaHienThoi = GetStringValueMapping(drDetail, hColumnNames.chidinhTenkhoahienthoi);
                                    chiDInhInfo.BenhKemTheo = GetStringValueMapping(drDetail, hColumnNames.chidinhBenhkemtheo);
                                    chiDInhInfo.NgayHetHanBHYT = GetDateTimeValueMapping(drDetail, hColumnNames.chidinhnNgayhethanbhy);
                                    chiDInhInfo.NgayNhapVien = GetDateTimeValueMapping(drDetail, hColumnNames.chidinhNgaynhapvien);
                                    chiDInhInfo.TgVaovien = GetDateTimeValueMapping(drDetail, hColumnNames.chidinhNgayvaovien);
                                    chiDInhInfo.Chandoan = GetStringValueMapping(drDetail, hColumnNames.chidinhChandoan);
                                    chiDInhInfo.IDLoaiXetNghiem = (GetIntValueMapping(drDetail, "Loaixetnghiemlis") ?? (int?)0).Value;
                                    bnInfo.ChiDinh.Add(chiDInhInfo);

                                    //    //Bật cờ lấy mẫu cho DH
                                    //    if (CommonAppVarsAndFunctions.WorkingHis != HisProvider.DH_DHG && CommonAppVarsAndFunctions.WorkingHis != HisProvider.DH_API) continue;
                                    //    if (chiDInhInfo.Thoigiangui == null)
                                    //        chiDInhInfo.Thoigiangui = bnInfo.Ngaydk;
                                    //    if (chiDInhInfo.Thoigiangui == null) continue;
                                    //    var checkDate = chiDInhInfo.Thoigiangui;
                                    //    if (currentOrderDate == checkDate) continue;

                                    //    currentOrderDate = checkDate.Value;
                                    //    if (!lstGioChiDinh.Contains(currentOrderDate))
                                    //    {
                                    //        lstGioChiDinh.Add(currentOrderDate);
                                    //        var sophieu = chiDInhInfo.SoPhieuChiDinh;
                                    //        var paraList = new List<HisParaGetList>();
                                    //        paraList.Add(
                                    //           new HisParaGetList
                                    //           {
                                    //               SoPhieuChiDinh = sophieu,
                                    //               NgayChiDinh = checkDate,
                                    //               IDChiDinhDichVu = chiDInhInfo.IDDichVuChiDinh,
                                    //               IDChiDinh = chiDInhInfo.IdChiTiet,
                                    //               MaDichVu = chiDInhInfo.MaXN_His,
                                    //               IDBangKe = chiDInhInfo.Bangkeid
                                    //           });
                                    //        Task.Factory.StartNew(() =>
                                    //        {
                                    //            _iHisService.LISCheck(hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, paraList);
                                    //        });
                                    //    }
                                }
                                //Xử lý insert bệnh nhân và chỉ định
                                if (bnInfo.ChiDinh.Any())
                                {
                                    StringBuilder sbLogFile = new StringBuilder();

                                    StartInsertChiDinhHIS(ref sbLogFile, chuaThuphi, bnInfo, chkIncodeKhiNhap.Checked
                                        , barcode, dataDmXetNghiem, ngayLayMau, idChuyenMau.IDChuyenMau);
                                }
                                ngayLayMau = ngayLayMau.AddSeconds(30);
                                gvDanhSachImport.SetRowCellValue(i, colBarcode, bnInfo.Seq);
                                gvDanhSachImport.SetRowCellValue(i, colHoTen, bnInfo.Tenbn);
                                gvDanhSachImport.SetRowCellValue(i, colDiaChi, bnInfo.Diachi);
                                gvDanhSachImport.SetRowCellValue(i, colNamSinh, bnInfo.Tuoi);
                                gvDanhSachImport.SetRowCellValue(i, colGioiTinh, bnInfo.Gioitinh);
                            }
                        }
                        else
                        {
                            gvDanhSachImport.SetRowCellValue(i, colBarcode.Name, "Đã khoá hoặc không có");
                        }
                    }
                    catch(Exception ex)
                    {
                        CustomMessageBox.MSG_Error_OK(string.Format("Lỗi trong quá trình lấy chỉ định:{0}", ex.Message, ex));
                    }
                }

            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy import danh sách trước khi thực hiện");
        }
        private string GetStringValueMapping(DataRow drDetail, string colId)
        {
          //return  (colId == null ? string.Empty : (drDetail.Table.Columns.IndexOf(colId) > -1?
          //                          drDetail[colId] == null
          //                              ? null
          //                              : drDetail[colId].ToString(): null));
            var obj = GetObject(drDetail, colId);
            return (obj ?? string.Empty).ToString();
        }
        private DateTime? GetDateTimeValueMapping(DataRow drDetail, string colId)
        {
            var obj = GetObject(drDetail, colId);
            return (DateTime?)(obj);

            //return (colId == null ? (DateTime?)null : (drDetail.Table.Columns.IndexOf(colId) > -1 ?
            //                          drDetail[colId] == null
            //                              ? (DateTime?)null
            //                              : (string.IsNullOrEmpty(drDetail[colId].ToString()) ? (DateTime?)null : DateTime.Parse(drDetail[colId].ToString())): (DateTime?)null));
        }
        private int? GetIntValueMapping(DataRow drDetail, string colId)
        {
            var obj = GetObject(drDetail, colId);
            if (obj == null)
                return (int?)null;
            else
                return int.Parse(obj.ToString());

            //return (colId == null ? (int?)null : (drDetail.Table.Columns.IndexOf(colId) > -1 ?
            //                          drDetail[colId] == null
            //                              ? (int?)null
            //                              : (string.IsNullOrEmpty(drDetail[colId].ToString()) ? (int?)null : int.Parse(drDetail[colId].ToString())): (int?)null));
        }
        private object GetObject(DataRow drDetail, string colId)
        {
            return (colId == null ? null : (drDetail.Table.Columns.IndexOf(colId) > -1 ?
                                   drDetail[colId] == null
                                       ? null
                                       : drDetail[colId] : null));
        }
        private BENHNHAN_TIEPNHAN StartInsertChiDinhHIS(ref StringBuilder log
            , string chuaThuphi, BenhNhanInfoForHIS bnInfo
            , bool checkInbarcode, string barcodeManual
            , DataTable dataDmXetNghiem, DateTime ngayThuchien, long idChuyenMau)
        {
            try
            {
                LogService.RecordLogFile(LogFile.ActionLog,
                    string.Format(
                        "call StartInsertChiDinhHIS(...) start: {0:yyyy/MM/dd HH:mm:ss fff}",
                        DateTime.Now), this.Text);

                BENHNHAN_TIEPNHAN objReturn = null;
                if (!chkTuTaoCode.Checked)
                {
                    log.AppendLine(" - Code theo danh sách");
                    if (string.IsNullOrEmpty(barcodeManual))
                    {
                        CustomMessageBox.MSG_Information_OK(string.Format("Số phiếu {0} chưa có barcode", bnInfo.Sophieuyeucau));
                           return null;
                    }

                    bnInfo.Seq = barcodeManual;
                    bnInfo.Matiepnhan = ConfigurationDetail.Get_MaTiepNhan(barcodeManual, bnInfo.Ngaytiepnhan);
                }
                else
                {
                    log.AppendLine(" - radBarcodeTuDong");
                    var barcode = CommonAppVarsAndFunctions.sysConfig.GenerateSeq(bnInfo.Ngaytiepnhan);
                    if (string.IsNullOrEmpty(barcode))
                    {
                        CustomMessageBox.MSG_Information_OK(string.Format("Barcode tự động [{0}] không hợp lệ, vui lòng kiểm tra lại",
                            barcode));
                        return null;
                    }

                    bnInfo.Seq = barcode;
                    bnInfo.Matiepnhan = ConfigurationDetail.Get_MaTiepNhan(barcode, bnInfo.Ngaytiepnhan);
                }

                if (!string.IsNullOrEmpty(chuaThuphi))
                {
                    CustomMessageBox.MSG_Waring_OK(string.Format("Các chỉ định chưa đóng tiền: {0}", chuaThuphi));
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
                    CustomMessageBox.MSG_Information_OK(string.Format("Barcode {0} đã sử dụng !", bnInfo.Seq));
                    //allowInsertTest = false;
                }
                else
                {
                    log.AppendLine(" - check : _iHisData.ExistsMaBenhNhanVaBarcode");
                    if (_iHisData.ExistsMaBenhNhanVaBarcode(bnInfo.Mabn, bnInfo.Seq))
                    {
                        allowInsertTest = CustomMessageBox.MSG_Question_YesNo_GetYes(
                            string.Format("Thêm chỉ định cho bệnh nhân:\n[{0}]\nBarcode:{1}", bnInfo.Tenbn,
                                bnInfo.Seq));
                        if (allowInsertTest)
                        {
                            bnInfo.Matiepnhan = _informationService.Get_MaTiepNhanByBarcode(bnInfo.Seq);
                        }
                    }
                    else
                    {
                        CustomMessageBox.MSG_Information_OK(string.Format("Barcode {0} đã sử dụng cho bệnh nhân khác!",
                            bnInfo.Seq));
                        //allowInsertTest = false;
                    }
                }

                if (!allowInsertTest) return null;

                log.AppendLine(" - check : _iHisData.InsertPatientFromHIS");
                CustomMessageBox.ShowAlert("Thực hiện tiếp nhận.....");

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
                    , true, hisInfo
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
                    CustomMessageBox.ShowAlert("Thực hiện cập nhật thao tác ống mẫu.....");
                    foreach (var item in bnInfo.ChiDinh)
                    {
                        var dtXn = WorkingServices.SearchResult_OnDatatable(dataDmXetNghiem, string.Format("MaXN = '{0}'", item.MaXN.Trim()));
                        var loaiXn = int.Parse(dtXn.Rows[0]["LoaiXetNghiem"].ToString());
                        var maloaiMau = dtXn.Rows[0]["LoaiMau"].ToString();
                        //Bật cờ lấy mẫu
                        var lstDSLayMau = new List<LayMauInfo>();
                        lstDSLayMau.Add(
                                       new LayMauInfo
                                       {
                                           MaTiepNhan = bnInfo.Matiepnhan,
                                           TrangThai = enumThucHien.DaThucHien,
                                           MaNhomLoaiMau = maloaiMau,
                                           NguoiThucHien = CommonAppVarsAndFunctions.UserID,
                                           Pcthuchien = Environment.MachineName,
                                           CheckXacNhanHis = true,
                                           Maxn = item.MaXN,
                                           IDKhuLayMau = objKhuLayMau.Idkhulaymau,
                                           ThoiGianLayMau = ngayThuchien,
                                           LoaiXetNghiem = loaiXn,
                                           IdLayLoaiMau = CommonAppVarsAndFunctions.IDLayLoaiMau,
                                           BanLayMau = 0,
                                           MaCapTren = string.Empty,
                                           ProfileId = string.Empty
                                       });
                        //Insert nhóm
                        _pXetnghiem.InsertCategoryOfTest(bnInfo.Matiepnhan);
                        //Cap nhat lay mau cho test
                        _informationService.Update_MauXn_LayMau(lstDSLayMau);
                        //Ghi dữ liệu chuyển mẫu
                        GhiDuLieuChuyenMau(idChuyenMau, bnInfo.Matiepnhan, bnInfo.Seq);

                        //Duyệt nhận mẫu
                        var lstDSNhanMau = new List<NhanMauInfo>();
                        lstDSNhanMau.Add(new NhanMauInfo()
                        {
                            MaTiepNhan = bnInfo.Matiepnhan,
                            NguoiThucHien = CommonAppVarsAndFunctions.UserID,
                            NguoiThucHienNhanMau = CommonAppVarsAndFunctions.UserID,
                            Pcthuchien = Environment.MachineName,
                            TrangThaiNhan = enumThucHien.DaThucHien,
                            LyDoTuChoi = string.Empty,
                            TinhTrangMau = "Đạt",
                            MaLoaiMau = maloaiMau,
                            CheckXacNhanHis = false,
                            Maxn = item.MaXN,
                            DeleteOrder = false,
                            ThoiGianNhanMau = ngayThuchien.AddMinutes(2),
                            LoaiXetNghiem = loaiXn,
                            MaLoaiMauNhan = maloaiMau,
                            IdLayLoaiMau = CommonAppVarsAndFunctions.IDLayLoaiMau,
                            KhuThucHienID = CommonAppVarsAndFunctions.PCWorkPlace,
                            MaCapTren = string.Empty,
                            ProfileId = string.Empty
                        });
                        //_informationService.Update_MauXn_NhanMau(lstDSNhanMau);
                    }
                    //Xác nhận chuyển mẫu
                   Update_ChuyenMau(idChuyenMau, ngayThuchien.AddSeconds(30));
                    //Tín > Cập nhật trạng thái lấy mẫu cho nhóm và bộ phận
                    _informationService.Update_TrangThaiLayMau(bnInfo.Matiepnhan);
                    //Tín > Cập nhật trạng thái nhận mẫu cho nhóm và bộ phận
                    _informationService.Update_TrangThaiNhanMau(bnInfo.Matiepnhan, true);

                    if (chkIncodeKhiNhap.Checked)
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
                            Inbarcode(false, bnInfo.Matiepnhan);
                            LogService.RecordLogFile(LogFile.ActionLog,
                                string.Format(
                                    "call Inbarcode(...); finish: {0:yyyy/MM/dd HH:mm:ss fff}",
                                    DateTime.Now), this.Text);
                        }

                        //objReturn = new BENHNHAN_TIEPNHAN();
                        objReturn = bnTiepNhanInfo;
                    }
                }
                return objReturn;
            }
            catch (Exception ex)
            {
                CustomMessageBox.CloseAlert();
                LogService.RecordLogFile(LogFile.ActionLog,
                   string.Format(
                       "call StartInsertChiDinhHIS(...) error: {0:yyyy/MM/dd HH:mm:ss fff} - {1}",
                       DateTime.Now, ex.Message), this.Text);
                CustomMessageBox.MSG_Error_OK(string.Format("Có lỗi trong quá trình xử lý:\n {0}", ex.Message), ex);
   
                return null;
            }
            finally
            {
                CustomMessageBox.CloseAlert();
                LogService.RecordLogFile(LogFile.ActionLog,
                    string.Format(
                        "call StartInsertChiDinhHIS(...) finish: {0:yyyy/MM/dd HH:mm:ss fff}",
                        DateTime.Now), this.Text);
            }
        }
        private void GhiDuLieuChuyenMau(long idChuyenMau, string maTiepNhan, string barcode)
        {
            var DSOngMau = _pXetnghiem.SoLuongMau_Data(maTiepNhan, true, CommonAppVarsAndFunctions.IDLayLoaiMau, true);
            var obj = new ThemChuyenMauChiTiet
            {
                idChuyenMau = idChuyenMau,
                Barcode = barcode,
                UserTao = CommonAppVarsAndFunctions.UserID,
                PcTao = Environment.MachineName
            };
            for (var i = 0; i < DSOngMau.Rows.Count; i++)
            {
                obj.MaLoaiMau = DSOngMau.Rows[i]["LoaiMau"].ToString();
                obj.MaTiepNhan = maTiepNhan;
                obj.SoLuong = int.Parse(DSOngMau.Rows[i]["SL"].ToString());
                _informationService.Insert_ChuyenMau_ChiTiet(obj);
            }
        }
        private TaoMoiChuyenMau TaoIdChuyenMau()
        {
            var obj = new TaoMoiChuyenMau { PCName = Environment.MachineName, UserTao = CommonAppVarsAndFunctions.UserID };
           return _informationService.Create_ChuyenMau_IdChuyenMau(obj);
        }
        private void Update_ChuyenMau(long idChuyenMau, DateTime tgThucHien)
        {
            var obj = new CapNhatChuyenMau();
            obj.IDChuyenMau = idChuyenMau;
            obj.UserChuyen = CommonAppVarsAndFunctions.UserID;
            obj.PcChuyen = Environment.MachineName;
            obj.ChiCapNhatGhiChu = false;
            obj.TgThucHien = tgThucHien;
            var ok = _informationService.Update_ChuyenMau_XacNhanChuyen(obj);
        }
        private DataTable DataDSBN = new DataTable();
        private string TimMaBN(string tenBN , string idCongdan, string ngaySinh, int namSinh)
        {
            if(DataDSBN.Rows.Count > 0)
            {
                var dataFound = new DataTable();
                if (!string.IsNullOrEmpty(ngaySinh))
                {
                    //Họ tên , ngày sinh, Số CMND/HC
                    if (!string.IsNullOrEmpty(idCongdan))
                    {
                        dataFound = WorkingServices.SearchResult_OnDatatable(DataDSBN, string.Format("TenBN = '{0}' and IdCongDan = '{1}' and NgaySinh = '{2}'"
                            , WorkingServices.EscapeLikeValue(tenBN), WorkingServices.EscapeLikeValue(idCongdan), ngaySinh));
                    }
                    else
                        dataFound = WorkingServices.SearchResult_OnDatatable(DataDSBN, string.Format("TenBN = '{0}' and IdCongDan is null and NgaySinh = '{1}'"
                                                  , WorkingServices.EscapeLikeValue(tenBN), ngaySinh));
                }
                else
                {
                    if (!string.IsNullOrEmpty(idCongdan))
                    {
                        dataFound = WorkingServices.SearchResult_OnDatatable(DataDSBN, string.Format("TenBN = '{0}' and IdCongDan = '{1}' and NgaySinh is null and Tuoi = '{2}'"
                      , WorkingServices.EscapeLikeValue(tenBN), WorkingServices.EscapeLikeValue(idCongdan), namSinh));
                    }
                    else
                    {
                        if(!string.IsNullOrEmpty(ngaySinh))
                        dataFound = WorkingServices.SearchResult_OnDatatable(DataDSBN, string.Format("TenBN = '{0}' and IdCongDan is null and NgaySinh is null and Tuoi = '{1}'"
                                                 , WorkingServices.EscapeLikeValue(tenBN), ngaySinh));
                        else
                            dataFound = WorkingServices.SearchResult_OnDatatable(DataDSBN, string.Format("TenBN = '{0}' and IdCongDan is null and NgaySinh is null"
                                                , WorkingServices.EscapeLikeValue(tenBN)));
                    }
                }
                if (dataFound.Rows.Count > 0)
                    return dataFound.Rows[0]["MaBn"].ToString();
            }
            return string.Empty;
        }
        private DataTable dataUser = new DataTable();
        private bool CheckUserLayMau(string manguoiDung)
        {
            if (dataUser.Rows.Count > 0)
            {
                var dataFound = WorkingServices.SearchResult_OnDatatable(dataUser, string.Format("MaNguoiDung = '{0}'", manguoiDung));
                return dataFound.Rows.Count > 0;
            }
            return false;
        }
        private bool CheckDataImport()
        {
            bool haveError = false;
            for (int i = 0; i < gvDanhSachImport.RowCount; i++)
            {
                var ngayHC = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colNgayCapCMND.Name));
                if (!string.IsNullOrEmpty(ngayHC))
                {
                    var date = WorkingServices.ConvertDate(ngayHC);
                    if (date.Equals(DateTime.MinValue))
                    {
                        if (!haveError)
                            haveError = true;
                    }
                }

                var dk = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colNgayDangKy));
                if (!string.IsNullOrEmpty(dk))
                {
                    var date = WorkingServices.ConvertDate(dk);
                    if (date.Equals(DateTime.MinValue))
                    {
                        if (!haveError)
                            haveError = true;
                    }
                }
                var sn = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colSinhNhat));
                if (!string.IsNullOrEmpty(sn))
                {
                    var date = WorkingServices.ConvertDate(sn);
                    if (date.Equals(DateTime.MinValue))
                    {
                        if (!haveError)
                            haveError = true;
                    }
                }
                var ngaylaymau = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colTglayMau));
                if (!string.IsNullOrEmpty(ngaylaymau))
                {
                    var date = WorkingServices.ConvertDate(ngaylaymau);
                    if (date.Equals(DateTime.MinValue))
                    {
                        if (!haveError)
                            haveError = true;
                    }
                }
                var nguoilaymau = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colNguoiLaymau));
                if (!CheckUserLayMau(nguoilaymau))
                {
                    if (!haveError)
                        haveError = true;
                }
                var dsXetnghiem = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colChiDinh));
                var dsProfile = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colimportProfile));
                if (string.IsNullOrEmpty(dsXetnghiem) && string.IsNullOrEmpty(dsProfile))
                {
                    if (!haveError)
                        haveError = true;
                }
            }
            return haveError;
        }
        private void InsertWithExcelMode()
        {
         
            var ucBacSi = new ucSearchLookupEditor_Doctor();
            ucBacSi.Load_BacSi();
            var ucCTV = new ucSearchLookupEditor_Doctor();
            ucCTV.Load_CongTacVien();

            if (gvDanhSachImport.RowCount > 0)
            {
                if(radChiDinhNhapDanhSach.Checked && gvDanhSachChiDinh.RowCount == 0)
                {
                    CustomMessageBox.MSG_Information_OK("Chưa có chỉ định được chọn.");
                    return;
                }
                //if (CheckDataImport())
                //{
                //    CustomMessageBox.MSG_Information_OK("Đã phát hiện dữ liệu không hợp lệ. Vui lòng kiểm tra các dòng có đánh dấu đỏ.");
                //    return;
                //}
                //if (dtgDanhSachChiDinh.RowCount > 0)
                //{
                //if (cboDoiTuongDichVu.SelectedIndex > -1)
                //{
                BENHNHAN_TIEPNHAN objBenhNhan;
                var lstDhiDinh = new List<ChiDinhXetNghiemKSK>();
                if (radChiDinhNhapDanhSach.Checked && gvDanhSachChiDinh.RowCount > 0)
                {
                    for (int y = 0; y < gvDanhSachChiDinh.RowCount; y++)
                    {

                        lstDhiDinh.Add(new ChiDinhXetNghiemKSK()
                        {
                            IsProfile = (bool)gvDanhSachChiDinh.GetRowCellValue(y, IsProfile),
                            MaDichVu = gvDanhSachChiDinh.GetRowCellValue(y, MaChiDinh).ToString().Trim(),
                            MaLoaiDichVu = gvDanhSachChiDinh.GetRowCellValue(y, MaLoaiDichVu).ToString()
                        });
                    }
                }
                ShowMess("Thực hiện nhập danh sách.");
                var rCount = gvDanhSachImport.RowCount;
                List<Task> tasks = new List<Task>();
                for (int i = 0; i < rCount; i++)
                {
                    objBenhNhan = new BENHNHAN_TIEPNHAN();
                    ShowMess(String.Format("Thực hiện nhập dòng {0}/{1}", i + 1, rCount));
                    objBenhNhan.Doituongdichvu = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colDoiTuongDichVu));
                    if (string.IsNullOrEmpty(objBenhNhan.Doituongdichvu))
                    {
                        objBenhNhan.Doituongdichvu = WorkingServices.ObjecToString(cboDoiTuongDichVu.SelectedValue);
                    }
                    if (string.IsNullOrEmpty(objBenhNhan.Doituongdichvu))
                    {
                        CustomMessageBox.MSG_Information_OK(string.Format("Khách hàng: {0} chưa có mã đối tượng", gvDanhSachImport.GetRowCellValue(i, colHoTen).ToString().Trim()));
                        return;
                    }
                 
                    var barcode = gvDanhSachImport.GetRowCellValue(i, colBarcode).ToString().Trim();
                    if (string.IsNullOrEmpty(barcode))
                    {
                        if (chkTuTaoCode.Checked && CommonAppVarsAndFunctions.sysConfig.BenhNhanCheDoSoThuTu.Equals(SystemStypeConstant.AutoBarcode.ToString()))
                        {
                            barcode = CommonAppVarsAndFunctions.sysConfig.GenerateSeq(dtpDateIn.Value);
                            gvDanhSachImport.SetRowCellValue(i, colBarcode, barcode);
                        }
                        else
                        {
                            CustomMessageBox.MSG_Information_OK(string.Format("Khách hàng: {0} chưa có barcoe", gvDanhSachImport.GetRowCellValue(i,colHoTen).ToString().Trim()));
                            return;
                        }
                    }

                    objBenhNhan.Seq = barcode;
                    if (WorkingServices.IsNumeric(objBenhNhan.Seq))
                    {
                        objBenhNhan.Tenbn = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colHoTen)).ToUpper();
                        objBenhNhan.Idcongdan = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colCMND_HC));
                        var ngayHC = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colNgayCapCMND));
                        if (!string.IsNullOrEmpty(ngayHC))
                        {
                            var date = WorkingServices.ConvertDate(ngayHC);
                            if (date.Equals(DateTime.MinValue))
                            {
                                CustomMessageBox.MSG_Information_OK(string.Format("Ngày cấp CMND/HC không hợp lệ -  KH: {0}", objBenhNhan.Tenbn));
                                continue;
                            }
                            else
                            {
                                objBenhNhan.Ngaycaphochieu = date;
                            }
                        }

                        var dk = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colNgayDangKy));
                        if (!string.IsNullOrEmpty(dk))
                        {
                            var date = WorkingServices.ConvertDate(dk);
                            if (date.Equals(DateTime.MinValue))
                            {
                                CustomMessageBox.MSG_Information_OK(string.Format("Ngày đăng ký không hợp lệ -  KH: {0}", objBenhNhan.Tenbn));
                                continue;
                            }
                            else
                            {
                                objBenhNhan.Ngaytiepnhan = date;
                            }
                        }
                        else
                        {
                            objBenhNhan.Ngaytiepnhan = dtpDateIn.Value;
                        }
                        objBenhNhan.Matiepnhan = ConfigurationDetail.Get_MaTiepNhan(objBenhNhan.Seq, objBenhNhan.Ngaytiepnhan);
                       
                        var sn = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colSinhNhat));
                        if (!string.IsNullOrEmpty(sn))
                        {
                            var date = WorkingServices.ConvertDate(sn);
                            if (date.Equals(DateTime.MinValue))
                            {
                                CustomMessageBox.MSG_Information_OK(string.Format("Sinh nhật không hợp lệ -  KH: {0}", objBenhNhan.Tenbn));
                                continue;
                            }
                            else
                            {
                                objBenhNhan.Sinhnhat = date;
                            }
                        }

                        objBenhNhan.Congaysinh = !(objBenhNhan.Sinhnhat == null);
                        if (objBenhNhan.Congaysinh)
                            objBenhNhan.Tuoi = objBenhNhan.Sinhnhat.Value.Year;
                        else
                            objBenhNhan.Tuoi = WorkingServices.ValueString_Int_Zero(WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colNamSinh)));

                        objBenhNhan.Mabn = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colMaBN));
                        if (string.IsNullOrEmpty(objBenhNhan.Mabn))
                        {
                            var mabnMoi = TimMaBN(objBenhNhan.Tenbn, objBenhNhan.Idcongdan, sn, objBenhNhan.Tuoi);
                            if (!string.IsNullOrEmpty(mabnMoi))
                                objBenhNhan.Mabn = mabnMoi;
                            else
                            {
                                var currentPidSeq = _informationService.Get_MaBnNhanGanNhat();
                                objBenhNhan.Mabn = CommonAppVarsAndFunctions.sysConfig.Get_MaBenhNhan(objBenhNhan.Ngaytiepnhan, currentPidSeq);
                                gvDanhSachImport.SetRowCellValue(i, colMaBN, objBenhNhan.Mabn);
                             //   gvDanhSachImport[colMaBN.Name, i].Style.BackColor = Color.LightGreen;
                            }
                        }

                        objBenhNhan.Doituong = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colDoituongBn));
                        objBenhNhan.Diachi = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colDiaChi));
                        objBenhNhan.Sdt = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colDienThoai));
                        //objBenhNhan.Email = dtgDanhSachKhachHang[cole.Name, i].Value.ToString().Trim();
                        objBenhNhan.Sobhyt = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colSoBHYT));
                        objBenhNhan.Gioitinh = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colGioiTinh));
                        if (objBenhNhan.Gioitinh.Equals("nam", StringComparison.OrdinalIgnoreCase) ||
                            objBenhNhan.Gioitinh.Equals("m", StringComparison.OrdinalIgnoreCase))
                            objBenhNhan.Gioitinh = "M";
                        else if (objBenhNhan.Gioitinh.Equals("nữ", StringComparison.OrdinalIgnoreCase) ||
                                 objBenhNhan.Gioitinh.Equals("f", StringComparison.OrdinalIgnoreCase))
                            objBenhNhan.Gioitinh = "F";
                        else
                            objBenhNhan.Gioitinh = string.Empty;


                        // int.Parse(string.IsNullOrEmpty(dtgDanhSachKhachHang[colNamSinh.Name, i].Value.ToString().Trim()) ? "0" : dtgDanhSachKhachHang[colNamSinh.Name, i].Value.ToString().Trim());
                        objBenhNhan.Madonvi = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colDonVi));

                        objBenhNhan.Nguonnhap = InputSourceEnum.ByList.ToString();
                        objBenhNhan.Makhuvuc = CommonAppVarsAndFunctions.PCWorkPlace;
                        objBenhNhan.Usernhap = CommonAppVarsAndFunctions.UserID;

                        objBenhNhan.Quoctich = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colQuocTich));
                        objBenhNhan.Chandoan = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colChanDoan));
                        objBenhNhan.Bacsicd = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colBSChiDinh));
                   
                        objBenhNhan.MaCongTacVien = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colCTV));
                        objBenhNhan.Giayto_id = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colMaNhanVien));
                        if (!string.IsNullOrEmpty(objBenhNhan.Bacsicd))
                        {
                            ucBacSi.SelectedValue = objBenhNhan.Bacsicd;
                            if (!string.IsNullOrEmpty(ucBacSi.GetDoctorLocation))
                                objBenhNhan.Madonvi = ucBacSi.GetDoctorLocation;
                            objBenhNhan.Masophong = ucBacSi.GetDoctorRoom;
                        }
                        else if (!string.IsNullOrEmpty(objBenhNhan.MaCongTacVien))
                        {
                            ucCTV.SelectedValue = objBenhNhan.MaCongTacVien;
                            if (!string.IsNullOrEmpty(ucBacSi.GetDoctorLocation))
                                objBenhNhan.Madonvi = ucBacSi.GetDoctorLocation;
                            objBenhNhan.Masophong = ucBacSi.GetDoctorRoom;
                        }
                        //Xử lý bs chỉ định sau
                        if (string.IsNullOrEmpty(objBenhNhan.Bacsicd))
                            objBenhNhan.Bacsicd = WorkingServices.ObjecToString(ucSearchLookupEditor_BSChiDinh.SelectedValue);
                        //Xử lý bs chỉ định sau
                        if (string.IsNullOrEmpty(objBenhNhan.Madonvi))
                            objBenhNhan.Madonvi = WorkingServices.ValueCombobox(cboDonVi);

                        var ngaylaymau = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colTglayMau));
                        DateTime? tgLaymau = null;
                        if (!string.IsNullOrEmpty(ngaylaymau))
                        {
                            var date = WorkingServices.ConvertDate(ngaylaymau);
                            if (date.Equals(DateTime.MinValue))
                            {
                                 CustomMessageBox.MSG_Information_OK(string.Format("Ngày lấy mẫu không hợp lệ -  KH: {0}", objBenhNhan.Tenbn));
                                continue;
                            }
                            else
                            {
                                tgLaymau = date;
                            }
                        }
                        var nguoilaymau = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colNguoiLaymau));
                        if (!CheckUserLayMau(nguoilaymau) && !string.IsNullOrEmpty(ngaylaymau))
                        {
                            CustomMessageBox.MSG_Information_OK(string.Format("Người lấy mẫu \"{1}\" chưa được khai báo -  KH: {0}", objBenhNhan.Tenbn, nguoilaymau));
                            continue;
                        }
                        var dsXetnghiem = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colChiDinh));
                        var dsProfile = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(i, colimportProfile));
                    
                        if (radChiDinhTuExcel.Checked)
                        {
                            if (string.IsNullOrEmpty(dsXetnghiem) && string.IsNullOrEmpty(dsProfile))
                            {
                                CustomMessageBox.MSG_Information_OK(string.Format("Không có thông tin chỉ định  -  KH: {0}", objBenhNhan.Tenbn));
                                continue;
                            }
                        }
                        if (_informationService.Insert_BenhNhan_TiepNhan(objBenhNhan, true))
                        {
                            var objAction = objBenhNhan.Copy();
                            var t = Task.Factory.StartNew(() =>
                            {
                                InsertTestInfoWithSelectedOrder(lstDhiDinh, objAction, chkIncodeKhiNhap.Checked, radChiDinhNhapDanhSach.Checked, tgLaymau, nguoilaymau, dsProfile, dsXetnghiem);
                            });
                            tasks.Add(t);
                        }
                    }
                    else
                    {
                        CustomMessageBox.MSG_Information_OK(string.Format("Barcode:{0} không hợp lệ.",
                            objBenhNhan.Seq));
                    }
                }
            
                Task.WaitAll(tasks.ToArray());
                if (rCount > 0)
                    CustomMessageBox.MSG_Information_OK("Nhập danh sách hoàn tất!");
                ShowMess("");
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập danh sách khách hàng!");
            }
        }
        private void ShowMess(string mess)
        {
            if (lblMess.InvokeRequired)
            {
                lblMess.BeginInvoke(new Action(() => lblMess.Text = mess));
            }
            else
            {
                lblMess.Text = mess;
                lblMess.Refresh();
            }
        }
        private void InsertBN(BENHNHAN_TIEPNHAN objBenhNhan)
        {
            _informationService.InsertBenhNhan(objBenhNhan.Mabn, objBenhNhan.Matiepnhan);
        }
        private void InsertTestInfoWithSelectedOrder(List<ChiDinhXetNghiemKSK> lstDhiDinh, BENHNHAN_TIEPNHAN objBenhNhan, bool printBarcode, bool nhapheoDanhSachChon, DateTime? tgLaymau, string nguoiLayMau, string dsProfile, string dsXetnghiem)
        {

            if (nhapheoDanhSachChon)
            {
                foreach (var item in lstDhiDinh)
                {
                    Insert_ChiDinh(item.MaDichVu, item.IsProfile, objBenhNhan, item.MaLoaiDichVu);
                }
            }
            else
            {
                InsertTestFromExcel(objBenhNhan, dsXetnghiem, dsProfile, tgLaymau, nguoiLayMau);
            }
            if (tgLaymau != null)
            {
                //Tín > Cập nhật trạng thái lấy mẫu cho nhóm và bộ phận
                _informationService.Update_TrangThaiLayMau(objBenhNhan.Matiepnhan);
                //Tín > Cập nhật trạng thái nhận mẫu cho nhóm và bộ phận
                _informationService.Update_TrangThaiNhanMau(objBenhNhan.Matiepnhan, true);
            }
            if (printBarcode)
            {
                var matiepnhan = objBenhNhan.Matiepnhan;
                Inbarcode(false, matiepnhan);
            }
            InsertBN(objBenhNhan);
        }
        private void InsertTestFromExcel(BENHNHAN_TIEPNHAN objBenhNhan,
            string dsXetnghiem, string dsProfile, DateTime? ngaylaymau, string nguoilaymau)
        {
            //Ưu tiên insert profile trước
            if (!string.IsNullOrEmpty(dsProfile))
            {
                var arrPro = dsProfile.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var itmPro in arrPro)
                {
                    var objChiDinh = new Lab.BusinessService.Models.XetNghiemInfo();
                    objChiDinh.maxn = itmPro;
                    objChiDinh.xetnghiemProfile = true;
                    objChiDinh.Dongia = -1;
                    objChiDinh.Khuvucnhanid = CommonAppVarsAndFunctions.PCWorkPlace;
                    objChiDinh.Khuvucthuchienid = CommonAppVarsAndFunctions.PCWorkPlace;
                    objChiDinh.Thoigianlaymau = ngaylaymau;
                    objChiDinh.Nguoilaymau = nguoilaymau;
                    objChiDinh.Pcthuchien = (!string.IsNullOrEmpty(nguoilaymau) ? Environment.MachineName : string.Empty);
                    _pXetnghiem.InsertTest(objBenhNhan, objChiDinh);
                }
            }
            if(!string.IsNullOrEmpty(dsXetnghiem))
            {
                var arrTest = dsXetnghiem.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var itmTest in arrTest)
                {
                    var objChiDinh = new Lab.BusinessService.Models.XetNghiemInfo();
                    objChiDinh.maxn = itmTest;
                    objChiDinh.xetnghiemProfile = false;
                    objChiDinh.Dongia = -1;
                    objChiDinh.Khuvucnhanid = CommonAppVarsAndFunctions.PCWorkPlace;
                    objChiDinh.Khuvucthuchienid = CommonAppVarsAndFunctions.PCWorkPlace;
                    objChiDinh.Thoigianlaymau = ngaylaymau;
                    objChiDinh.Nguoilaymau = nguoilaymau;
                    objChiDinh.Pcthuchien = (!string.IsNullOrEmpty(nguoilaymau) ? Environment.MachineName : string.Empty);
                    _pXetnghiem.InsertTest(objBenhNhan, objChiDinh);
                }
            }
        }
        private DataTable LoadOrderDetailFromHIS(string soPhieuYeuCau, bool showMess
           , DataTable dataOrder = null, DateTime? TuNgayNgayChiDinh = null
           , DateTime? DenNgayNgayChiDinh = null, bool NoiTru = false, string giaytoId = "", string maBenhNhan = "", string soHoSo = "", int iCount = 0)
        {
            DataTable dt = new DataTable();
            try
            {
                CustomMessageBox.ShowAlert((string.Format("Lấy chi tiết chỉ định: {0}", soPhieuYeuCau)));
                if (dataOrder != null)
                    dt = dataOrder;
                else
                {
                    var paraList = new HisParaGetList();
                    paraList.IDGiayto = giaytoId;
                    paraList.MaBenhNhan = maBenhNhan;
                    paraList.NgayChiDinh = TuNgayNgayChiDinh;
                    paraList.TimTuNgayChiDinh = TuNgayNgayChiDinh;
                    paraList.TimDenNgayChiDinh = DenNgayNgayChiDinh;

                    paraList.SoPhieuChiDinh = soPhieuYeuCau;
                    paraList.NoiTru = NoiTru;
                    paraList.TrangThai = 3;
                    paraList.MaBenhAn = soHoSo;
                    paraList.GiaiPhauBenh = 0;
                    if (iCount == 1)
                        paraList.ThangNamThucHien = string.Format("{0:MM/yyyy}", CommonAppVarsAndFunctions.ServerTime.AddMonths(-1));
                    else
                        paraList.ThangNamThucHien = string.Format("{0:MM/yyyy}", CommonAppVarsAndFunctions.ServerTime);
                    int errCount = 0;
                    var orderDetail = _iHisData.GetPatientOrderedDetail(hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, paraList, CommonAppVarsAndFunctions.HisDataColumnsList, false, hColumnNames);
                    if (orderDetail.Data != null)
                    {
                        dt = orderDetail.Data;
                        if (hisWorking == HisProvider.Vimes)
                        {
                            var trangThai = 3;
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
                        //if (hisWorking != HisProvider.DH_API)
                        //{
                            if (string.IsNullOrEmpty(orderDetail.Message))
                                CustomMessageBox.MSG_Information_OK(string.Format("Số phiếu {0} không tìm thấy dữ liệu từ HIS trả về!", soPhieuYeuCau));
                            else
                                CustomMessageBox.MSG_Information_OK(orderDetail.Message);
                        //}
                        //else
                        //    errCount = 1;
                    }
                    ////Gọi HIS lần 2 --> Giải phẫu bệnh
                    //if (hisWorking == HisProvider.DH_API)
                    //{
                    //    paraList.GiaiPhauBenh = 1;
                    //    orderDetail = _iHisData.GetPatientOrderedDetail(hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, paraList, CommonAppVarsAndFunctions.HisDataColumnsList,false, hColumnNames);
                    //    if (orderDetail != null)
                    //    {
                    //        if (orderDetail.Data != null)
                    //        {
                    //            if (dt.Rows.Count > 0)
                    //            {
                    //                var dt2 = orderDetail.Data;
                    //                //kiểm tra đồng bộ column cho bảng lấy lần 1
                    //                foreach (DataColumn dtc in dt2.Columns)
                    //                {
                    //                    if (!dt.Columns.Contains(dtc.ColumnName))
                    //                    {
                    //                        dt.Columns.Add(dtc.ColumnName, dtc.DataType);
                    //                    }
                    //                }
                    //                //Xử lý import row vào data lần 1
                    //                foreach (DataRow dr in dt2.Rows)
                    //                {
                    //                    var dr1 = dt.NewRow();
                    //                    foreach (DataColumn dtc2 in dt2.Columns)
                    //                    {
                    //                        dr1[dtc2.ColumnName] = dr[dtc2.ColumnName];
                    //                    }
                    //                    dt.Rows.Add(dr1);
                    //                }
                    //            }
                    //            else
                    //                dt = orderDetail.Data;
                    //        }
                    //        else
                    //        {
                    //            if (errCount == 1)
                    //            {
                    //                if (string.IsNullOrEmpty(orderDetail.Message))
                    //                    CustomMessageBox.MSG_Information_OK(string.Format("Số phiếu {0} không tìm thấy dữ liệu từ HIS trả về!", soPhieuYeuCau));
                    //                else
                    //                    CustomMessageBox.MSG_Information_OK(orderDetail.Message);
                    //            }
                    //        }
                    //    }
                    //}
                }

                if (dt.Rows.Count >0)
                {
                    if (hisWorking != HisProvider.DH_DHG && hisWorking != HisProvider.DH_API && hColumnNames.chidinhTrangThaiChiDinh != null)
                    {
                        if (!string.IsNullOrEmpty(hColumnNames.chidinhTrangThaiChiDinh))
                        {
                            foreach (DataRow dtR in dt.Rows)
                            {

                                if (hisWorking == HisProvider.FPT_SP)
                                {
                                    var trangThai = dtR[hColumnNames.chidinhTrangThaiChiDinh].ToString();
                                    if (trangThai.Trim() == "0")
                                        dtR["trangthaichidinh"] = "Đã lấy mẫu";
                                    else if (trangThai.Trim() == "4")
                                        dtR["trangthaichidinh"] = "Chờ lấy mẫu";
                                    else if (trangThai.Trim() == "2")
                                        dtR["trangthaichidinh"] = "Đã có kết quả";
                                }
                                else
                                {
                                    var trangThai = dtR[hColumnNames.chidinhTrangThaiChiDinh].ToString();
                                    if (trangThai.Trim() == "1" || trangThai.Trim() == "True")
                                        dtR["trangthaichidinh"] = "Đã lấy mẫu";
                                    else if (trangThai.Trim() == "0" || trangThai.Trim() == "False")
                                        dtR["trangthaichidinh"] = "Chờ lấy mẫu";
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
                    if (chkChiDInhChuaLayMau.Checked)
                    {
                        if (hisWorking == HisProvider.DH_API)
                        {
                            dt = WorkingServices.SearchResult_OnDatatable(dt, string.Format("{0} = 0", hColumnNames.chidinhTrangThaiChiDinh));
                        }
                    }
                }
                CustomMessageBox.CloseAlert();
            }
            catch (Exception ex)
            {
                CustomMessageBox.CloseAlert();
                LogService.RecordLogError(CommonAppVarsAndFunctions.UserID, "TiepNhanHis", ex, 0, ex.Message, (new StackTrace()).GetFrame(0).GetMethod().Name);
                CustomMessageBox.MSG_Error_OK(ex.Message, ex);
            }
            return dt;
        }
        private void Inbarcode(bool isRePrint, string matiepNhan)
        {
            var objPrintInfo = new DM_MAYTINH_MAYIN();
            var bnInfo = _informationService.Get_Info_BenhNhan_TiepNhan(matiepNhan, new string[] { });

            WriteLog.LogService.RecordLogFile(LogFile.ActionLog,
              string.Format(" InBarcode : {0} - Chỉ định KSK: {2} -> Số record:{1}",
                  objPrintInfo == null
                      ? "Normal"
                      : (objPrintInfo.Giaothuc == null ? "Normal" : objPrintInfo.Giaothuc), 1, matiepNhan), "Chi tiết chỉ định");
            PrintBarcodeHelper.PrintBarcode(new List<BENHNHAN_TIEPNHAN>() { bnInfo }, 0, objPrintInfo, isRePrint, null, null, null, null);
        }

        private void InsertWithbarcodeMode()
        {
            if (WorkingServices.IsNumeric(txtFromBarcode.Text) && WorkingServices.IsNumeric(txtTobarcode.Text))
            {
                if (int.Parse(txtFromBarcode.Text) < int.Parse(txtTobarcode.Text))
                {
                    if (gvDanhSachChiDinh.RowCount > 0)
                    {
                        if (cboDoiTuongDichVu.SelectedIndex > -1)
                        {
                            BENHNHAN_TIEPNHAN objBenhNhan;
                            int fromBarcode = int.Parse(txtFromBarcode.Text);
                            int toBarcode = int.Parse(txtTobarcode.Text);

                            var lstDhiDinh = new List<ChiDinhXetNghiemKSK>();
                           
                                for (int y = 0; y < gvDanhSachChiDinh.RowCount; y++)
                                {

                                    lstDhiDinh.Add(new ChiDinhXetNghiemKSK()
                                    {
                                        IsProfile = (bool)gvDanhSachChiDinh.GetRowCellValue(y, IsProfile),
                                        MaDichVu = gvDanhSachChiDinh.GetRowCellValue(y, MaChiDinh).ToString().Trim(),
                                        MaLoaiDichVu = gvDanhSachChiDinh.GetRowCellValue(y, MaLoaiDichVu).ToString()
                                    });

                                }
                            

                                for (int i = fromBarcode; i <= toBarcode; i++)
                            {
                                objBenhNhan = new BENHNHAN_TIEPNHAN();
                                objBenhNhan.Seq = i.ToString();

                                if (WorkingServices.IsNumeric(objBenhNhan.Seq))
                                {
                                    objBenhNhan.Ngaytiepnhan = dtpDateIn.Value;
                                    objBenhNhan.Matiepnhan = ConfigurationDetail.Get_MaTiepNhan(objBenhNhan.Seq,
                                        objBenhNhan.Ngaytiepnhan);
                                    objBenhNhan.Doituongdichvu = cboDoiTuongDichVu.SelectedValue.ToString();
                                    //objBenhNhan.Tenbn = dtgDanhSachKhachHang[HoTen.Name, i].Value.ToString().Trim();
                                    //objBenhNhan.Diachi = dtgDanhSachKhachHang[DiaChi.Name, i].Value.ToString().Trim();
                                    //objBenhNhan.Gioitinh = dtgDanhSachKhachHang[GioiTinh.Name, i].Value.ToString().Trim();
                                    //if (objBenhNhan.Gioitinh.Equals("nam", StringComparison.OrdinalIgnoreCase) ||
                                    //    objBenhNhan.Gioitinh.Equals("m", StringComparison.OrdinalIgnoreCase))
                                    //    objBenhNhan.Gioitinh = "M";
                                    //else if (objBenhNhan.Gioitinh.Equals("nữ", StringComparison.OrdinalIgnoreCase) ||
                                    //         objBenhNhan.Gioitinh.Equals("f", StringComparison.OrdinalIgnoreCase))
                                    //    objBenhNhan.Gioitinh = "F";
                                    //else
                                    objBenhNhan.Gioitinh = "?";
                                    objBenhNhan.Usernhap = CommonAppVarsAndFunctions.UserID;
                                    objBenhNhan.Makhuvuc = CommonAppVarsAndFunctions.PCWorkPlace;
                                    objBenhNhan.Nguonnhap = InputSourceEnum.ByList.ToString();
                                    if (cboDonVi.SelectedIndex > -1)
                                    {
                                        objBenhNhan.Tendonvi = txtDonVi.Text;
                                        objBenhNhan.Madonvi = cboDonVi.SelectedValue.ToString().Trim();
                                    }
                                    if (ucSearchLookupEditor_BSChiDinh.SelectedValue != null)
                                    {
                                        objBenhNhan.Bacsicd = ucSearchLookupEditor_BSChiDinh.SelectedValue.ToString().Trim();
                                    }
                                    if (_informationService.Insert_BenhNhan_TiepNhan(objBenhNhan, true))
                                    {
                                        var objAction = objBenhNhan.Copy();
                                        Task.Factory.StartNew(() =>
                                        {
                                            InsertTestInfoWithSelectedOrder(lstDhiDinh, objAction, radInputWithBarcodeRange.Checked, true, null, String.Empty, String.Empty, String.Empty);
                                        });
                                    }

                                    //if (_informationService.Insert_BenhNhan_TiepNhan(objBenhNhan, true))
                                    //{
                                    //    for (int y = 0; y < dtgDanhSachChiDinh.RowCount; y++)
                                    //    {
                                    //        if (!((OutlookGridRow)dtgDanhSachChiDinh.Rows[y]).IsGroupRow)
                                    //        {
                                    //            Insert_ChiDinh(
                                    //                dtgDanhSachChiDinh[MaChiDinh.Name, y].Value.ToString().Trim(),
                                    //                (bool)dtgDanhSachChiDinh[IsProfile.Name, y].Value
                                    //                , objBenhNhan, dtgDanhSachChiDinh[MaLoaiDichVu.Name, y].Value.ToString());
                                    //        }
                                    //    }
                                    //}
                                }
                                else
                                {
                                    CustomMessageBox.MSG_Information_OK(string.Format("Barcode:{0} không hợp lệ.",
                                        objBenhNhan.Seq));
                                }
                            }

                            CustomMessageBox.MSG_Information_OK("Nhập danh sách hoàn tất!");
                        }
                        else
                        {
                            CustomMessageBox.MSG_Information_OK("Hãy chọn đối tượng dịch vụ!");
                            cboDoiTuongDichVu.Focus();
                        }
                    }
                    else
                    {
                        CustomMessageBox.MSG_Information_OK("Hãy nhập danh sách chỉ định dịch vụ!");
                    }
                }
                else
                {
                    CustomMessageBox.MSG_Information_OK("Số thứ tự bắt đầu phải nhỏ hơn số kết thúc");
                }
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Số thứ tự không hợp lệ!");
            }
        }


        private void Insert_ChiDinh(string maDichVu, bool isProfile, BENHNHAN_TIEPNHAN objBenhNhan, string maLoaiDichVu)
        {
            if (maLoaiDichVu.Equals(ServiceType.ClsXetNghiem.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                InsertDichVuXn(maDichVu, isProfile, objBenhNhan);
            }
            else if (maLoaiDichVu.Equals(ServiceType.ClsSieuAm.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                InsertDichVuSieuAm(maDichVu, objBenhNhan);
            }
            else if (maLoaiDichVu.Equals(ServiceType.ClsXQuang.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                InsertDicVuXQuang(maDichVu, objBenhNhan);
            }
            else if (maLoaiDichVu.Equals(ServiceType.ClsNoiSoi.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                InsertDichVuNoiSoi(maDichVu, objBenhNhan);
            }
            else if (maLoaiDichVu.Equals(ServiceType.KhamBenh.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                InsertDichVuKhamBenh(maDichVu, objBenhNhan);
            }
            else if (maLoaiDichVu.Equals(ServiceType.DvKhac.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                InsertDichVuKhac(maDichVu, objBenhNhan);
            }
        }
        private void InsertDichVuXn(string maDichVu, bool isProfile, BENHNHAN_TIEPNHAN objBenhNhan)
        {
            var objChiDinh = new Lab.BusinessService.Models.XetNghiemInfo();
            objChiDinh.maxn = maDichVu;
            objChiDinh.xetnghiemProfile = isProfile;
            objChiDinh.Dongia = -1;
            objChiDinh.Khuvucnhanid = CommonAppVarsAndFunctions.PCWorkPlace;
            objChiDinh.Khuvucthuchienid = CommonAppVarsAndFunctions.PCWorkPlace;

            _pXetnghiem.InsertTest(objBenhNhan, objChiDinh);
        }

        private void InsertDichVuSieuAm(string maDichVu, BENHNHAN_TIEPNHAN objBenhNhan)
        {
            float dongia = -1;
            _pSieuam.Insert_ChiDinhSieuAm(objBenhNhan.Matiepnhan,
                maDichVu, objBenhNhan.Doituongdichvu, dongia);
        }

        private void InsertDichVuNoiSoi(string maDichVu, BENHNHAN_TIEPNHAN objBenhNhan)
        {

            float dongia = -1;
            _pNoisoi.Insert_ChiDinhNoiSoi(objBenhNhan.Matiepnhan,
                maDichVu, objBenhNhan.Doituongdichvu, dongia);
        }

        private void InsertDicVuXQuang(string maDichVu, BENHNHAN_TIEPNHAN objBenhNhan)
        {
            float dongia = -1;
            _pXquang.Insert_ChiDinhXQuang(objBenhNhan.Matiepnhan,
                maDichVu, objBenhNhan.Doituongdichvu, dongia);
        }

        private void InsertDichVuKhamBenh(string maDichVu, BENHNHAN_TIEPNHAN objBenhNhan)
        {
            float dongia = -1;
            _pKhambenh.Insert_ChiDinh_DichVu(objBenhNhan.Matiepnhan,
                maDichVu, objBenhNhan.Doituongdichvu, "KB",
                dongia);
        }

        private void InsertDichVuKhac(string maDichVu, BENHNHAN_TIEPNHAN objBenhNhan)
        {
            float dongia = -1;
            _pDvkhac.Insert_ChiDinhDVKhac(objBenhNhan.Matiepnhan,
                maDichVu, objBenhNhan.Doituongdichvu, dongia);
        }

        private void cboLoaiDichVu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Load_NhomCLS();
        }

        private void cboNhomDichVu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Load_ChiDinhCLS();
        }

        private void cboLoaiDichVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                Load_NhomCLS();
        }

        private void cboNhomDichVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                Load_ChiDinhCLS();
        }

        private void btnThemChiDinh_Click(object sender, EventArgs e)
        {
            Add_OrderToList();
        }

        private void btnXoaChiDinh_Click(object sender, EventArgs e)
        {
            Delete_Order();
        }

        private void btnBrowsePath_Click(object sender, EventArgs e)
        {
            DataTable dt = ExportToExcel.ReadAndGetData();

            foreach (GridColumn dgc in gvDanhSachImport.Columns)
            {
                dgc.FieldName = (Utils.ChuyenTVKhongDau(dgc.Caption).Replace(" ","").Trim()).ToLower();
            }
            if (dt != null)
            {
                foreach (DataColumn dtc in dt.Columns)
                {
                    dtc.ColumnName = Utils.ChuyenTVKhongDau(dtc.ColumnName.Trim().Replace(" ", "")).ToLower().Replace("pid", "mabn").Replace("mabenhnhan", "mabn").Replace("makb", "phieuchidinhhis")
                        .Replace("hovaten", "hoten").Replace("sothebhyt", "sobhyt").Replace("ngaychidinh", "ngaychidinhhis").Replace("ngaychidinhhishis", "ngaychidinhhis").Trim();
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bool delRow = true;
                    foreach (GridColumn dc in gvDanhSachImport.Columns)
                    {
                        if (dt.Columns.Contains(dc.FieldName) && dc.Visible)
                        {
                            if (!string.IsNullOrEmpty(dt.Rows[i][dc.FieldName].ToString()))
                            {
                                delRow = false;
                                break;
                            }
                        }
                    }
                    if (delRow)
                    {
                        dt.Rows.RemoveAt(i);
                        i--;
                    }
                }
            }
            gcDanhSachImport.DataSource = dt;
            ShowMess("");
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            GhiThongTinReg();
            if (radInputWithBarcodeRange.Checked)
            {
                InsertWithbarcodeMode();
            }
            else if (chkHISMode.Checked)
            {
                InsertWithHISMode();
            }
            else
            {
                DataDSBN = _informationService.DanhSachBenhNhan(string.Empty);
                dataUser = user.GetAllUsers();
                InsertWithExcelMode();
            }
        }

        private void txtTimDichVu_KeyUp(object sender, KeyEventArgs e)
        {
            //if (cboLoaiDichVu.SelectedIndex > -1 && _dtDanhMucDichVu.Rows.Count > 0)
            //{
            //    if (!string.IsNullOrEmpty(txtTimDichVu.Text))
            //    {
            //        var dtSearch = WorkingServices.SearchResult_OnDatatable(_dtDanhMucDichVu,
            //            "convert (" + _valueMember + ", 'System.String') = '" + txtTimDichVu.Text + "' or " +
            //            _displayMember + " like '" + txtTimDichVu.Text +
            //            "%'  or " +
            //            _displayMember + " like '%" + txtTimDichVu.Text +
            //            "'");
            //        chlDSDichVu.DataSource = dtSearch;
            //        chlDSDichVu.DisplayMember = _displayMember;
            //        chlDSDichVu.ValueMember = _valueMember;
            //    }
            //    else
            //    {
            //        chlDSDichVu.DataSource = _dtDanhMucDichVu;
            //        chlDSDichVu.DisplayMember = _displayMember;
            //        chlDSDichVu.ValueMember = _valueMember;
            //    }
            //}
        }

        private void txtTimDichVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 91 || (int)e.KeyChar == 93)
                e.Handled = true;
        }

        private void radInputWithBarcode_CheckedChanged(object sender, EventArgs e)
        {
            if (radInputWithBarcodeRange.Checked)
            {
                radInputWithBarcodeRange.BackColor = Color.Yellow;
                chkHISMode.Checked = false;
                splitContainer1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.None;
            }
            else
            {
                radInputWithBarcodeRange.BackColor = Color.Transparent;
            }

            pnBarcode.Visible = radInputWithBarcodeRange.Checked;
        }

        private void radInputWithExcelFile_CheckedChanged(object sender, EventArgs e)
        {
            if (radInputWithExcelFile.Checked)
            {
                radInputWithExcelFile.BackColor = Color.Yellow;
                if (chkHISMode.Checked)
                    splitContainer1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
                else if (radChiDinhTuExcel.Checked)
                    splitContainer1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
                else
                    splitContainer1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.None;
            }
            else
            {
                radInputWithExcelFile.BackColor = Color.Transparent;
                splitContainer1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.None;
            }
            pnExcel.Visible = radInputWithExcelFile.Checked;
            pnDonVi.Enabled = !chkHISMode.Checked;
    
        }

        private void btnDeleteMaNhomCLS_Click(object sender, EventArgs e)
        {
            Delete_Order();
        }

        private void txtTimDichVu_TextChanged(object sender, EventArgs e)
        {
            SearchTest();
        }

        private void check_CheckedChanged(object sender, EventArgs e)
        {
            SearchTest();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel.Export(gvDanhSachImport);
        }

        private void chkTuTaoCode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTuTaoCode.Checked && !CommonAppVarsAndFunctions.sysConfig.BenhNhanCheDoSoThuTu.Equals(SystemStypeConstant.AutoBarcode.ToString()))
            {
                CustomMessageBox.MSG_Information_OK("Không thể sử dụng chức năng này khi hệ thống đang cấu hình sử dụng code nhập tay!");
                chkTuTaoCode.Checked = false;
            }
        }

        private void chkHISMode_CheckedChanged(object sender, EventArgs e)
        {
            colMaChiDinhHIS.Visible = chkHISMode.Checked;
            colNgayChiDinhHIS.Visible = chkHISMode.Checked;
            if (chkHISMode.Checked)
                splitContainer1.CollapsePanel =  DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            else if (radChiDinhTuExcel.Checked)
                splitContainer1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            else
                splitContainer1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.None;
            pnNguonChiDinh.Enabled = !chkHISMode.Checked;
            cboDoiTuongDichVu.Enabled = !chkHISMode.Checked;
            ucSearchLookupEditor_BSChiDinh.Enabled = !chkHISMode.Checked;
            cboDonVi.Enabled = !chkHISMode.Checked;
            chkChiDInhChuaLayMau.Visible = chkHISMode.Checked;
        }

        private void radChiDinhNhapDanhSach_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHISMode.Checked)
                splitContainer1.CollapsePanel =  DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            else if (radChiDinhTuExcel.Checked)
                splitContainer1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            else
                splitContainer1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.None;
        }

        private void radChiDinhTuExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHISMode.Checked)
                splitContainer1.CollapsePanel =  DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            else if (radChiDinhTuExcel.Checked)
                splitContainer1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            else
                splitContainer1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.None;
        }

        private void gvDanhSachImport_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var view = sender as GridView;
            if (e.RowHandle < 0) return;
            if (e.Column.Equals(colBarcode))
            {
                bool haveError = false;
                var ngayHC = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(e.RowHandle, colNgayCapCMND));
                if (!string.IsNullOrEmpty(ngayHC))
                {
                    var date = WorkingServices.ConvertDate(ngayHC);
                    if (date.Equals(DateTime.MinValue))
                        haveError = true;
                }

                var dk = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(e.RowHandle, colNgayDangKy));
                if (!string.IsNullOrEmpty(dk))
                {
                    var date = WorkingServices.ConvertDate(dk);
                    if (date.Equals(DateTime.MinValue))
                        haveError = true;
                }
                var sn = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(e.RowHandle, colSinhNhat));
                if (!string.IsNullOrEmpty(sn))
                {
                    var date = WorkingServices.ConvertDate(sn);
                    if (date.Equals(DateTime.MinValue))
                        haveError = true;
                }
                var ngaylaymau = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(e.RowHandle, colTglayMau));
                if (!string.IsNullOrEmpty(ngaylaymau))
                {
                    var date = WorkingServices.ConvertDate(ngaylaymau);
                    if (date.Equals(DateTime.MinValue))
                        haveError = true;
                }
                var nguoilaymau = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(e.RowHandle, colNguoiLaymau));
                if (!CheckUserLayMau(nguoilaymau) && !string.IsNullOrEmpty(ngaylaymau))
                    haveError = true;
                if (!radChiDinhNhapDanhSach.Checked)
                {
                    var dsXetnghiem = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(e.RowHandle, colChiDinh));
                    var dsProfile = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(e.RowHandle, colimportProfile));
                    if (string.IsNullOrEmpty(dsXetnghiem) && string.IsNullOrEmpty(dsProfile))
                        haveError = true;
                }
                if (haveError)
                    e.Appearance.BackColor = Color.Red;
            }
            else if (e.Column.Equals(colNgayCapCMND))
            {
                var ngayHC = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(e.RowHandle, colNgayCapCMND));
                if (!string.IsNullOrEmpty(ngayHC))
                {
                    var date = WorkingServices.ConvertDate(ngayHC);
                    if (date.Equals(DateTime.MinValue))
                    {
                        e.Appearance.BackColor = Color.Yellow;
                    }
                }
            }
            else if (e.Column.Equals(colNgayDangKy))
            {
                var dk = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(e.RowHandle, colNgayDangKy));
                if (!string.IsNullOrEmpty(dk))
                {
                    var date = WorkingServices.ConvertDate(dk);
                    if (date.Equals(DateTime.MinValue))
                    {
                        e.Appearance.BackColor = Color.Yellow;
                    }
                }
            }
            else if (e.Column.Equals(colSinhNhat))
            {
                var sn = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(e.RowHandle, colSinhNhat));
                if (!string.IsNullOrEmpty(sn))
                {
                    var date = WorkingServices.ConvertDate(sn);
                    if (date.Equals(DateTime.MinValue))
                    {

                        e.Appearance.BackColor = Color.Yellow;

                    }
                }
            }
            else if (e.Column.Equals(colTglayMau))
            {
                var ngaylaymau = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(e.RowHandle, colTglayMau));
                if (!string.IsNullOrEmpty(ngaylaymau))
                {
                    var date = WorkingServices.ConvertDate(ngaylaymau);
                    if (date.Equals(DateTime.MinValue))
                    {
                        e.Appearance.BackColor = Color.Yellow;
                    }
                }
            }
            else if (e.Column.Equals(colNguoiLaymau))
            {
                var nguoilaymau = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(e.RowHandle, colNguoiLaymau));
                if (!CheckUserLayMau(nguoilaymau) && !string.IsNullOrEmpty(WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(e.RowHandle, colTglayMau))))
                {
                    e.Appearance.BackColor = Color.Yellow;

                }
            }
            else if (e.Column.Equals(colChiDinh) || e.Column.Equals(colimportProfile))
            {
                if (!radChiDinhNhapDanhSach.Checked)
                {
                    var dsXetnghiem = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(e.RowHandle, colChiDinh));
                    var dsProfile = WorkingServices.ObjecToString(gvDanhSachImport.GetRowCellValue(e.RowHandle, colimportProfile));
                    if (string.IsNullOrEmpty(dsXetnghiem) && string.IsNullOrEmpty(dsProfile))
                    {
                        e.Appearance.BackColor = Color.Yellow;
                    }
                }
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel.Export(gvDanhSachImport);
        }

        private void btnXoaChiDinh_Click_1(object sender, EventArgs e)
        {
            Delete_Order();
        }

        private void FrmNhapKSK_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

    }
}
