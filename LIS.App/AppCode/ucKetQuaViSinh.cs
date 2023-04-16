using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TPH.Common.Extensions;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.ThucThi.BenhNhan;
using TPH.LIS.BarcodePrinting.Barcode;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Patient.Model;
using TPH.LIS.Patient.Services;
using TPH.LIS.TestResult.Services;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;
using StringConverter = TPH.Common.Converter.StringConverter;
using System.Collections.Generic;
using TPH.Report.Models;
using TPH.LIS.Configuration.Models;
using TPH.Report.Services;
using TPH.Report.Services.Impl;
using DevExpress.XtraReports.UI;
using TPH.Report.Constants;
using TPH.LIS.Common;
using TPH.Excel;

namespace TPH.LIS.App.DailyUse.CanLamSang
{
    public partial class ucKetQuaViSinh : UserControl
    {

        public ucKetQuaViSinh()
        {
            InitializeComponent();
            this.ucSearchLookupEditor_PhanLoaiVK_Loai.PhanLoaiViKhuan_EditValueChanged += new System.EventHandler(this.ucSearchLookupEditor_PhanLoaiViKhuan_EditValueChanged);
        }

        CustomBindingNavigator bvKqKhaoSat = new CustomBindingNavigator();
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
        private readonly IPatientInformationService _iPatient = new PatientInformationService();
        private readonly ITestResultService _xetnghiem = new TestResultService();
        private readonly IBacteriumAntibioticService _bioticConfig = new BacteriumAntibioticService();
        private readonly ISystemConfigService _iSysConfig = new SystemConfigService();
        private readonly IReportService _reportInfo = new ReportServiceImpl();
        private readonly IBacteriumAntibioticService _bacteriumAntibistic = new BacteriumAntibioticService();
        private readonly IMicrobilogyTestResultService _microbiologyTesresult = new MicrobilogyTestResultService();

        bool _allowEdit = false;
        bool _allowValid = false;
        bool _allowInValid = false;
        bool _allowPrint = false;

        public DataTable _dataUserSign = new DataTable();
        private int _loaiKy = 0;
        private int _countToFocus = 0;
        private static ReportModel resultReportInfo = new ReportModel();
        private static List<DM_XETNGHIEM_MAUPHIEUIN> lstThongTinPhieuIn;
        private static DM_XETNGHIEM_MAUPHIEUIN ThongTinPhieuIn;
        private static List<ReportModel> lstResultReportInfo = new List<ReportModel>();
        private static XtraReport resultReport;

        public string CurrentMaTiepNhan = "";
        public DateTime CurrentNgayTiepNhan = DateTime.Now;
        public int hisId = 0;
        public List<string> lstDanhSachNhom = new List<string>();
        public DataTable _dtPatient = new DataTable();
        public string CurrentMaBenhNhan = "";
        public string CurrentBarcode = "";
        public DateTime Datein = DateTime.Now;
        public string userSign = "";
        public bool IsPrintTitle = false;
        private Image reportLogo;
        public TestType.EnumTestType[] _arrLoaiXetNghiem =
        {
            TestType.EnumTestType.ViSinhNuoiCay
        };
        /// <summary>
        /// Sự kiện click button tùy chọn
        /// </summary>
        [Category("Custom")]
        public event EventHandler Button_GoiLenh_Click;
        public void Load_CauHinh()
        {
            SetPermission();
            Load_danhSachChiViKhuan();
            Load_danhSachLoaiViKhuan();
            Load_danhSachAntibioticPanel();
            ucSearchLookupEditor_LoaiMau1.Load_DanhMucLoaiMau(ServiceType.ClsXNViSinh.ToString(), "MaLoaiMau");
            //Load user ký tên
            ucSearchLookupEditor_MayXN2.arrAnalyzerAllow = CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem;
            ucSearchLookupEditor_MayXN2.Load_MayXN((int)PhanLoaiMayXN.EnumLoaiMayXN.ViSinh);
            Load_KetQuaKhaoSat();
            Load_DanhMucKHaoSat();
            Load_DMKhangKhangSinh();
            reportLogo = _iSysConfig.Load_Logo("XN");
        }
        private void Load_DMKhangKhangSinh()
        {
            var dataSource = _bacteriumAntibistic.Data_dm_xetnghiem_khangkhangsinh(string.Empty);
            cboKhangKhangSinh.DataSource = dataSource;
            cboKhangKhangSinh.DisplayMember = "MaKhangKhangSinh";
            cboKhangKhangSinh.ValueMember = "MaKhangKhangSinh";
            cboKhangKhangSinh.SelectedIndex = -1;
        }
        private void UcSearchLookupEditor_KyThuatNuoiCay1_EditValueChange(object sender, EventArgs e)
        {
            Load_KetQuaKhangSinh();
        }

        private void SetPermission()
        {
            btnInKetQua.Enabled = btnXemTruoc.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenViSinh, UserConstant.PermissionVSPrintResult);

            if (CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenViSinh, UserConstant.PermissionVSInputResult)
                || CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenViSinh, UserConstant.PermissionVSExportResult))
            {
                _allowEdit = true;
            }
            _allowInValid = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenViSinh, UserConstant.PermissionVSInValidResult);
            _allowValid = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenViSinh, UserConstant.PermissionVSValidResult);
            _allowPrint = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenViSinh, UserConstant.PermissionVSPrintResult);
            colKSD_KetQua.OptionsColumn.AllowEdit = _allowEdit;
            dtgKetQuaKhaoSat.ReadOnly = !_allowEdit;
            btnKSD_XoaKhangSinh.Enabled = btnThemKhangkhangSinh.Enabled = btnLuuKetQuaKhaoSat.Enabled = btnSaveAll.Enabled
                = btnThemKhaoSat.Enabled = btnXoaViKhuan.Enabled = ucSearchLookupEditor_PhanLoaiVK_Chi.Enabled = ucSearchLookupEditor_PhanLoaiVK_Loai.Enabled = _allowEdit;
            btnLamMoiDanhSachKSD.Enabled = _allowEdit;
            btnXemTruoc.Enabled = btnInKetQua.Enabled = _allowPrint;
            btnXacNhanKetQua.Enabled = _allowValid;
            btnBoXacNhanKetQua.Enabled = _allowInValid;
        }

        private BENHNHAN_TIEPNHAN _objBenhNhan = new BENHNHAN_TIEPNHAN();
        DataTable dtDanhSachBenhNhan = new DataTable();

        private void Load_danhSachChiViKhuan()
        {
            ucSearchLookupEditor_PhanLoaiVK_Chi.PhanLoaiViKhuan_EditValueChanged += ucSearchLookupEditor_PhanLoaiVK_Chi_PhanLoaiViKhuan_EditValueChanged;
            ucSearchLookupEditor_PhanLoaiVK_Chi.Load_PhanLoaiViKhuan(BacteriumCategory.genus.ToString(), string.Empty);
        }
        private void ucSearchLookupEditor_PhanLoaiVK_Chi_PhanLoaiViKhuan_EditValueChanged(object sender, EventArgs e)
        {
            Load_danhSachLoaiViKhuan();
        }
        private void Load_danhSachLoaiViKhuan()
        {
            string mahoViKhuan = string.Empty;
            if (ucSearchLookupEditor_PhanLoaiVK_Chi.SelectedValue != null)
                mahoViKhuan = ucSearchLookupEditor_PhanLoaiVK_Chi.SelectedValue.ToString().Trim();
            ucSearchLookupEditor_PhanLoaiVK_Loai.Load_PhanLoaiViKhuan(BacteriumCategory.species.ToString(), mahoViKhuan);
        }
        private void Load_danhSachAntibioticPanel()
        {
            string maPanel = string.Empty;
            string maViKhuan = string.Empty;
            if (ucSearchLookupEditor_AntibioticPanel.SelectedValue != null)
                maPanel = ucSearchLookupEditor_AntibioticPanel.SelectedValue.ToString().Trim();
            if (ucSearchLookupEditor_PhanLoaiVK_Loai.SelectedValue != null)
                maViKhuan = ucSearchLookupEditor_PhanLoaiVK_Loai.SelectedValue.ToString().Trim();
            ucSearchLookupEditor_AntibioticPanel.Load_AntibioticPanel(maPanel, maViKhuan);
        }
        private void Load_DanhMucKHaoSat()
        {
            cboKhaoSat.SelectedIndexChanged -= cboKhaoSat_SelectedIndexChanged;
            ControlExtension.BindDataToCobobox(_bacteriumAntibistic.Data_dm_xetnghiem_khaosatdaithe(string.Empty),
             ref cboKhaoSat, "MaKhaoSat", "MaKhaoSat", "MaKhaoSat,TenKhaoSat", "50,250", txtTenKhaoSat, 1);
            cboKhaoSat.SelectedIndexChanged += cboKhaoSat_SelectedIndexChanged;
        }
        private void cboKhaoSat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhaoSat.SelectedIndex > -1)
                Load_DanhMucKetqua(cboKhaoSat.SelectedValue.ToString());
            else
                Load_DanhMucKetqua("---NULL---");
        }
        private void Load_DanhMucKetqua(string maKhaoSat)
        {
            ControlExtension.BindDataToCobobox(_bacteriumAntibistic.Data_dm_xetnghiem_khaosatdaithe_ketqua(string.Empty, maKhaoSat),
            ref cboKetQuaKhaoSat, "KetQuaKhaoSat", "KetQuaKhaoSat", "KetQuaKhaoSat", "250", txtKetQuaKhaoSat, 0);
        }
        private void Load_YeuCauViSinh_List()
        {
            dtgDanhSachChiDinh.CellEnter -= dtgDanhSachChiDinh_CellEnter;
            ControlExtension.BindDataToGrid(_microbiologyTesresult.Data_ketqua_cls_xetnghiem_visinh(CurrentMaTiepNhan, string.Empty
                , false, true, string.Join(",", lstDanhSachNhom)), ref dtgDanhSachChiDinh, ref bvDanhSachChiDinh);
            BindThongTinKetQuaYeuCau();
            var daXacNhan = false;
            if (dtgDanhSachChiDinh.RowCount > 0)
            {
                for (var i = 0; i < dtgDanhSachChiDinh.RowCount; i++)
                {
                    daXacNhan = (bool)dtgDanhSachChiDinh.Rows[i].Cells[colChiDinh_DaXacNhanKQ.Name].Value;
                    dtgDanhSachChiDinh[colXacNhanKQ.Name, i].Value = (daXacNhan ? imageList1.Images[0] : imageList1.Images[1]);
                }
                dtgDanhSachChiDinh.CurrentCell = dtgDanhSachChiDinh[colXacNhanKQ.Name, 0];
            }
            if (dtgDanhSachChiDinh.Rows.Count > 0)
            {
                dtgDanhSachChiDinh.Rows[0].Selected = true;
                dtgDanhSachChiDinh_CellEnter(dtgDanhSachChiDinh, new DataGridViewCellEventArgs(0, 0));
            }
            dtgDanhSachChiDinh.CellEnter += dtgDanhSachChiDinh_CellEnter;
            if (dtgDanhSachChiDinh.CurrentRow != null)
            {
                bool XacNhan = bool.Parse(dtgDanhSachChiDinh.CurrentRow.Cells[colChiDinh_DaXacNhanKQ.Name].Value.ToString());
                if (_allowValid)
                    btnXacNhanKetQua.Enabled = !XacNhan;
                if (_allowInValid)
                    btnBoXacNhanKetQua.Enabled = XacNhan;
                if (_allowEdit)
                    Lock_ValidControl(XacNhan);
                colCoaKhaoSat.ReadOnly = XacNhan;
            }
            Load_KetQuaViKhuan();
        }
        private void Lock_ValidControl(bool isLock)
        {
            btnLuuGhiChuViKhuan.Enabled = !isLock;
            btnLuuKetQuaKhaoSat.Enabled = !isLock;
            btnSaveAll.Enabled = !isLock;
            btnThemCard.Enabled = !isLock;
            btnThemKhaoSat.Enabled = !isLock;
            btnLuuKetQuaKhaoSat.Enabled = !isLock;
            btnKSD_ThemKhangSinh.Enabled = !isLock;
            btnKSD_XoaKhangSinh.Enabled = !isLock;
            btnNhapVK_KSD.Enabled = !isLock;
            btnXoaViKhuan.Enabled = !isLock;
            colKSD_KetQua.OptionsColumn.AllowEdit = !isLock;
            colKSD_SRI.OptionsColumn.AllowEdit = !isLock;
            ucSearchLookupEditor_PhanLoaiVK_Chi.Enabled = ucSearchLookupEditor_PhanLoaiVK_Loai.Enabled = !isLock;
            btnXoaKhangKhangSinh.Enabled = !isLock;
            btnXoaCard.Enabled = !isLock;
            btnThemCard.Enabled = !isLock;
            btnThemKhangkhangSinh.Enabled = !isLock;
            btnLamMoiDanhSachKSD.Enabled = !isLock;
            mnuCapNhatMay_KSD.Enabled = !isLock;
        }
        public void Load_KetQuaViKhuan(string mavikhuanDangCheck = "")
        {
            dtgDanhSachViKhuan.CellEnter -= dtgDanhSachViKhuan_CellEnter;

            string maChiDinh = string.Empty;
            if (dtgDanhSachChiDinh.CurrentRow != null)
            {
                maChiDinh = dtgDanhSachChiDinh.CurrentRow.Cells[ycMaChiDinh.Name].Value.ToString().Trim();
            }
            ControlExtension.BindDataToGrid(_microbiologyTesresult.Get_DanhSach_ViKhuan(CurrentMaTiepNhan, maChiDinh, string.Empty, 1)
                , ref dtgDanhSachViKhuan, ref bvViKhuan);
            if (!string.IsNullOrEmpty(mavikhuanDangCheck))
            {
                bvViKhuan.BindingSource.Position = bvViKhuan.BindingSource.Find(vkMaPhanLoaiViKhuan.DataPropertyName, mavikhuanDangCheck);
            }
            dtgDanhSachViKhuan.CellEnter += dtgDanhSachViKhuan_CellEnter;
            if (dtgDanhSachViKhuan.RowCount > 0)
            {
                for (var i = 0; i < dtgDanhSachViKhuan.RowCount; i++)
                {
                    var mamauSac = dtgDanhSachViKhuan[colViKhuan_MaMauSac.Name, i].Value.ToString().Split(',');
                    if (mamauSac.Length == 3)
                    {
                        dtgDanhSachViKhuan[colViKHuan_MauSac.Name, i].Style.BackColor = Color.FromArgb(int.Parse(mamauSac[0]), int.Parse(mamauSac[1]), int.Parse(mamauSac[2]));
                        dtgDanhSachViKhuan[colViKHuan_MauSac.Name, i].Style.SelectionBackColor = dtgDanhSachViKhuan[colViKHuan_MauSac.Name, i].Style.BackColor;
                    }
                    var ngoainhiem = bool.Parse(dtgDanhSachViKhuan[colViKhuan_NgoaiNhiem.Name, i].Value.ToString());
                    if (ngoainhiem)
                    {
                        dtgDanhSachViKhuan[vkDanhPhap.Name, i].Style.BackColor = Color.LightPink;
                        dtgDanhSachViKhuan[vkTenPhanLoaiViKhuan.Name, i].Style.BackColor = Color.LightPink;
                    }
                }
            }

            Load_KetQuaKhangSinh();
            Load_KetQua_DeKhangKhangSinh();
            Load_TheDinhDanh();
        }
        private string GetKyThuat()
        {
            return (radDisk.Checked ? BioTestMethod.Disk.ToString() : (radMIC.Checked ? BioTestMethod.MIC.ToString() : BioTestMethod.ETEST.ToString()));
        }
        private void Load_KetQuaKhangSinh()
        {
            var maChiDinh = string.Empty;
            var maViKhuan = string.Empty;
            var kythuat = GetKyThuat();
            gcKhangDinhDo.DataSource = null;
            if (dtgDanhSachViKhuan.CurrentRow != null)
            {
                if (dtgDanhSachChiDinh.CurrentRow != null)
                {
                    maChiDinh = dtgDanhSachChiDinh.CurrentRow.Cells[ycMaChiDinh.Name].Value.ToString().Trim();
                    maViKhuan = dtgDanhSachViKhuan.CurrentRow.Cells[vkMaPhanLoaiViKhuan.Name].Value.ToString().Trim();
                    var lanXn = int.Parse(dtgDanhSachViKhuan.CurrentRow.Cells[colViKhuan_LanXN.Name].Value.ToString().Trim());
                    var data = _microbiologyTesresult.Get_DanhSach_KhangSinh(CurrentMaTiepNhan, maChiDinh, maViKhuan, string.Empty, lanXn, kythuat);
                    gcKhangDinhDo.DataSource = data;
                }
            }
            gvKhangSinhDo.ExpandAllGroups();
        }
        private void Load_KetQua_DeKhangKhangSinh()
        {
            var maChiDinh = string.Empty;
            var maViKhuan = string.Empty;
            dtgKhangKhangSinh.DataSource = null;
            bvKhangKhangSinh.BindingSource = null;
            if (dtgDanhSachViKhuan.CurrentRow == null) return;
            if (dtgDanhSachChiDinh.CurrentRow == null) return;
            maChiDinh = dtgDanhSachChiDinh.CurrentRow.Cells[ycMaChiDinh.Name].Value.ToString().Trim();
            maViKhuan = dtgDanhSachViKhuan.CurrentRow.Cells[vkMaPhanLoaiViKhuan.Name].Value.ToString().Trim();
            var lanXn = int.Parse(dtgDanhSachViKhuan.CurrentRow.Cells[colViKhuan_LanXN.Name].Value.ToString());
            ControlExtension.BindDataToGrid(_microbiologyTesresult.Data_ketqua_cls_xetnghiem_visinh_khangkhangsinh(CurrentMaTiepNhan
                , maChiDinh, maViKhuan, string.Empty), ref dtgKhangKhangSinh, ref bvKhangKhangSinh);
        }
        private void Load_KetQuaKhaoSat()
        {
            if (string.IsNullOrEmpty(CurrentMaTiepNhan)) return;
            if (dtgDanhSachChiDinh.CurrentRow == null) return;
            var maChiDinh = dtgDanhSachChiDinh.CurrentRow.Cells[ycMaChiDinh.Name].Value.ToString().Trim();
            ControlExtension.BindDataToGrid(_microbiologyTesresult.Data_ketqua_cls_xetnghiem_khaosatdaithe(CurrentMaTiepNhan, string.Empty, maChiDinh),
                ref dtgKetQuaKhaoSat, ref bvKqKhaoSat);
        }
        private void BindThongTinKetQuaYeuCau()
        {
            ucSearchLookupEditor_LoaiMau1.DataBindings.Clear();
            ucSearchLookupEditor_LoaiMau1.SelectedValue = null;
            if (bvDanhSachChiDinh.BindingSource != null)
                ucSearchLookupEditor_LoaiMau1.DataBindings.Add("SelectedValue", bvDanhSachChiDinh.BindingSource, "LoaiMauNhan");
        }
        private void LuuKetQuaViSinh()
        {
            if (dtgDanhSachChiDinh.CurrentRow != null)
            {
                var mayeucau = dtgDanhSachChiDinh.CurrentRow.Cells[ycMaChiDinh.Name].Value.ToString().Trim();
                _microbiologyTesresult.Update_ketqua_cls_xetnghiem_visinh_kqViSinh(dtgDanhSachChiDinh.CurrentRow.Cells[ycMaTiepNhan.Name].Value.ToString().Trim()
                    , mayeucau
                    , CommonAppVarsAndFunctions.UserID
                    , txtKetQuaViKhuan.Text, false, string.Empty, dtgDanhSachChiDinh.CurrentRow.Cells[colYeuCau_MaLoaiMauHis.Name].Value.ToString().Trim());
                Load_YeuCauViSinh_List();
                bvDanhSachChiDinh.BindingSource.Position = bvDanhSachChiDinh.BindingSource.Find("MaYeuCau", mayeucau);
            }
        }
        private void dtgDanhSachChiDinh_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Load_KetQuaViKhuan();
            Load_TheDinhDanh();
            Load_KetQuaKhaoSat();
            if (dtgDanhSachChiDinh.CurrentRow == null) return;
            var XacNhan = bool.Parse(dtgDanhSachChiDinh.CurrentRow.Cells[colChiDinh_DaXacNhanKQ.Name].Value.ToString());
            txtTenLoaiMauHIS.Text = dtgDanhSachChiDinh.CurrentRow.Cells[colYeuCau_TenLoaiMauHis.Name].Value.ToString();
            txtMaSoMau.Text = dtgDanhSachChiDinh.CurrentRow.Cells[colYeuCau_MaSoMau.Name].Value.ToString();
            if (_allowValid)
                btnXacNhanKetQua.Enabled = !XacNhan;
            if (_allowInValid)
                btnBoXacNhanKetQua.Enabled = XacNhan;
            colCoaKhaoSat.ReadOnly = XacNhan;
            if (_allowEdit)
            {
                Lock_ValidControl(XacNhan);
            }
        }

        private void dtgDanhSachViKhuan_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Load_KetQuaKhangSinh();
            Load_KetQua_DeKhangKhangSinh();
            txtKetQuaViKhuan.Text = string.Empty;
            if (dtgDanhSachViKhuan.CurrentRow != null)
            {
                txtKetQuaViKhuan.Text = StringConverter.ToString(dtgDanhSachViKhuan.CurrentRow.Cells[colVk_GhiChu.Name].Value);
            }
        }

        private void dtgDanhSachViKhuan_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //var ketQuaESBL = string.Empty;
            //var ESBL = false;
            //var MIC = false;
            //var machiDinh = dtgDanhSachViKhuan.CurrentRow.Cells[vkMaChiDinh.Name].Value.ToString().Trim();
            //var maViKhuan = dtgDanhSachViKhuan.CurrentRow.Cells[vkMaPhanLoaiViKhuan.Name].Value.ToString().Trim();
            //var maTiepNhan = CurrentMaTiepNhan;
            //var lanXn = int.Parse(dtgDanhSachViKhuan.CurrentRow.Cells[colViKhuan_LanXN.Name].Value.ToString().Trim());
          
            //ketQuaESBL = string.Empty;// dtgDanhSachViKhuan.CurrentRow.Cells[vkKetQuaESBL.Name].Value.ToString().Trim();
            //var ketQuaBetaLactamase = string.Empty;// dtgDanhSachViKhuan.CurrentRow.Cells[vkBetaLactamase.Name].Value.ToString().Trim();
            //MIC = false;
            //var dataVK = _microbiologyTesresult.Get_DanhSach_ViKhuan(maTiepNhan, machiDinh, maViKhuan, lanXn);
            //if (dataVK != null && dataVK.Rows.Count > 0)
            //{
            //    var objInfo = (KETQUA_CLS_XETNGHIEM_VIKHUAN)WorkingServices.Get_InfoForObject(new KETQUA_CLS_XETNGHIEM_VIKHUAN(), dataVK.Rows[0]);
            //    if (!string.IsNullOrEmpty(objInfo.Matiepnhan))
            //    {
            //        objInfo.Nguoisua = CommonAppVarsAndFunctions.UserName;
            //      // objInfo.Ngoainhiem =  bool.Parse(dtgDanhSachViKhuan[e.RowIndex, colViKhuan_NgoaiNhiem.Name].Value.ToString().Trim());
            //        _microbiologyTesresult.Update_KetQuaViKhuan(objInfo);
            //    }
            //}
        }
        private void btnXoaViKhuan_Click(object sender, EventArgs e)
        {
            if (dtgDanhSachViKhuan.CurrentRow == null) return;
            if (!CustomMessageBox.MSG_Question_YesNo_GetYes("Xoá vi khuẩn đang chọn?")) return;
            var machiDinh = dtgDanhSachViKhuan.CurrentRow.Cells[vkMaChiDinh.Name].Value.ToString().Trim();
            var maViKhuan = dtgDanhSachViKhuan.CurrentRow.Cells[vkMaPhanLoaiViKhuan.Name].Value.ToString().Trim();
            var maTiepNhan = CurrentMaTiepNhan;
            var lanXn = int.Parse(dtgDanhSachViKhuan.CurrentRow.Cells[colViKhuan_LanXN.Name].Value.ToString().Trim());
            _microbiologyTesresult.Delete_ViKhuan(maTiepNhan, machiDinh, maViKhuan);
            Load_KetQuaViKhuan();
        }

        private void gvKhangSinhDo_RowClick(object sender, RowClickEventArgs e)
        {
            //if (e.HitInfo.Column != colKSD_SRI) return;
            //var ketQua = StringConverter.ToString(gvKhangSinhDo.GetRowCellValue(e.RowHandle, colKSD_KetQua));
            //if (string.IsNullOrEmpty(ketQua))
            //{
            //    CustomMessageBox.MSG_Waring_OK("Vui lòng nhập kết quả!");
            //}
        }
        private bool check_1 = true;
        private void gvKhangSinhDo_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column == colKSD_KetQua)
            {
                Update_KetQuaKhangSinhTuLuoi(e.RowHandle);
            }
            if (e.Column == colKSD_SRI)
            {
                if (check_1)
                {
                    Update_KetQuaKhangSinhSIR(e.RowHandle);
                }
            }
            if (!check_1)
            {
                check_1 = true;
            }
        }

        private void Update_KetQuaKhangSinhSIR(int rowIndex)
        {
            if (gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_MaKhangSinh) == null) return;

            var machiDinh = gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_YeuCauViSinh).ToString();
            var maViKhuan = gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_MaViKhuan).ToString();
            var maTKhangSinh = gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_MaKhangSinh).ToString();
            var maTiepNhan = gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_MaTiepNhan).ToString();
            var kyThuat = gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_KyThuat).ToString();
            var lanXn = int.Parse(gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_LanXetNghiem).ToString());
            var updateSIR = StringConverter.ToString(gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_SRI));
            var ketQua = StringConverter.ToString(gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_KetQua));
            var SiteINF = gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_SiteInfection).ToString();

            //lấy thông tin quy trình 
            var data = _bacteriumAntibistic.Data_dm_visinh_quitrinh(maTKhangSinh, kyThuat, "0");
            if (data.Rows.Count > 0)
            {
                gvKhangSinhDo.SetRowCellValue(rowIndex, colKSD_QuiTrinh, data.Rows[0]["QuyTrinh"].ToString());
                gvKhangSinhDo.SetRowCellValue(rowIndex, colKSD_PhuongPhap, data.Rows[0]["PhuongPhap"].ToString());
            }
            else
            {
                gvKhangSinhDo.SetRowCellValue(rowIndex, colKSD_QuiTrinh, string.Empty);
                gvKhangSinhDo.SetRowCellValue(rowIndex, colKSD_PhuongPhap, string.Empty);
            }
            var coKetQua = (int)AntiBioticColor.Unidentified;
            if (!string.IsNullOrEmpty(updateSIR))
                coKetQua = (int)AnitBioticResultIndex.GetResultColorFlat(updateSIR);
            gvKhangSinhDo.SetRowCellValue(rowIndex, colKSD_CoKetQua, coKetQua);

            _microbiologyTesresult.Update_KetQuaKhangSinh(maTiepNhan, machiDinh, maViKhuan, maTKhangSinh, kyThuat
                , string.Empty, ketQua, coKetQua, CommonAppVarsAndFunctions.UserID, 1, "", 0, updateSIR, SiteINF);
        }

        private void Update_KetQuaKhangSinhTuLuoi(int rowIndex)
        {
            if (gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_MaKhangSinh) == null) return;
            var ketQua = StringConverter.ToString(gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_KetQua));
            if (ketQua.Length > 10)
            {
                CustomMessageBox.MSG_Waring_OK("Bạn đã nhập quá ký tự cho phép!");
                return;
            }
            var machiDinh = gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_YeuCauViSinh).ToString();
            var maViKhuan = gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_MaViKhuan).ToString();
            var maTKhangSinh = gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_MaKhangSinh).ToString();
            var maTiepNhan = gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_MaTiepNhan).ToString();
            var kyThuat = gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_KyThuat).ToString();
            var lanXn = int.Parse(gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_LanXetNghiem).ToString());
            var SiteINF = gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_SiteInfection).ToString();

            double canNhay = 0;
            double canKhang = 0;
            double cantrungGianDuoi = 0;
            double cantrungGianTren = 0;
            var strTempVal = string.Empty;

            //lấy thông tin quy trình 
            var data = _bacteriumAntibistic.Data_dm_visinh_quitrinh(maTKhangSinh, kyThuat, "0");
            if (data.Rows.Count > 0)
            {
                gvKhangSinhDo.SetRowCellValue(rowIndex, colKSD_QuiTrinh, data.Rows[0]["QuyTrinh"].ToString());
                gvKhangSinhDo.SetRowCellValue(rowIndex, colKSD_PhuongPhap, data.Rows[0]["PhuongPhap"].ToString());
            }
            else
            {
                gvKhangSinhDo.SetRowCellValue(rowIndex, colKSD_QuiTrinh, string.Empty);
                gvKhangSinhDo.SetRowCellValue(rowIndex, colKSD_PhuongPhap, string.Empty);
            }

            if (kyThuat.Equals(BioTestMethod.Disk.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                strTempVal = gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_CanNhay).ToString();
                canNhay = double.Parse(string.IsNullOrEmpty(strTempVal) ? "10000000000000000" : strTempVal);

                strTempVal = gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_CanKhang).ToString();
                canKhang = double.Parse(string.IsNullOrEmpty(strTempVal) ? "-10000000000000000" : strTempVal);

                strTempVal = gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_CanTrungGianDuoi).ToString();
                cantrungGianDuoi = double.Parse(string.IsNullOrEmpty(strTempVal) ? "10000000000000000" : strTempVal);

                strTempVal = gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_CanTrungGianTren).ToString();
                cantrungGianTren = double.Parse(string.IsNullOrEmpty(strTempVal) ? "-10000000000000000" : strTempVal);
            }
            else
            {
                strTempVal = gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_CanNhay).ToString();
                canNhay = double.Parse(string.IsNullOrEmpty(strTempVal) ? "-10000000000000000" : strTempVal);

                strTempVal = gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_CanKhang).ToString();
                canKhang = double.Parse(string.IsNullOrEmpty(strTempVal) ? "10000000000000000" : strTempVal);

                strTempVal = gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_CanTrungGianDuoi).ToString();
                cantrungGianDuoi = double.Parse(string.IsNullOrEmpty(strTempVal) ? "-10000000000000000" : strTempVal);

                strTempVal = gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_CanTrungGianTren).ToString();
                cantrungGianTren = double.Parse(string.IsNullOrEmpty(strTempVal) ? "10000000000000000" : strTempVal);
            }

            var SRI = DanhGiaKetQuaKSD(ketQua, canNhay, canKhang, cantrungGianDuoi, cantrungGianTren, kyThuat).Trim();
            var coKetQua = (int)AntiBioticColor.Unidentified;
            if (!string.IsNullOrEmpty(SRI))
                coKetQua = (int)AnitBioticResultIndex.GetResultColorFlat(SRI);
            gvKhangSinhDo.SetRowCellValue(rowIndex, colKSD_SRI, SRI);
            gvKhangSinhDo.SetRowCellValue(rowIndex, colKSD_CoKetQua, coKetQua);

            _microbiologyTesresult.Update_KetQuaKhangSinh(maTiepNhan, machiDinh, maViKhuan, maTKhangSinh, kyThuat
                , SRI, ketQua, coKetQua, CommonAppVarsAndFunctions.UserID, 1, "", 0, "", SiteINF);
            check_1 = false;
        }
        private string DanhGiaKetQuaKSD(string ketQua, double canNhay
            , double canKhang, double cantrungGianDuoi, double cantrungGianTren
            , string kyThuat)
        {

            string returnSRI = string.Empty;

            //Đánh giá S-R-I, nếu khác số thì chạy vào.
            if (!WorkingServices.IsNumeric(ketQua))
            {
                //Regex re = new Regex(@"([<>=]+)(\d+)");
                var re = new Regex(@"([<>=]+)((\d+.)?(\d+))");
                var result = re.Match(ketQua);

                var alphaPart = result.Groups[1].Value;
                var numberPart = result.Groups[2].Value;
                if (!WorkingServices.IsNumeric(numberPart))
                {
                    return AnitBioticResultIndex.ConvertResultToSIR(ketQua);
                }
                else
                {
                    switch (alphaPart)
                    {
                        case "=":
                            return ReturnResultSri(alphaPart, numberPart, canNhay
                            , canKhang, cantrungGianDuoi, cantrungGianTren, kyThuat);
                        case "<=":
                            return ReturnResultSri(alphaPart, numberPart, canNhay
                            , canKhang, cantrungGianDuoi, cantrungGianTren, kyThuat);
                        case ">=":
                            return ReturnResultSri(alphaPart, numberPart, canNhay
                           , canKhang, cantrungGianDuoi, cantrungGianTren, kyThuat);
                        case "<":
                            return ReturnResultSri(alphaPart, numberPart, canNhay
                           , canKhang, cantrungGianDuoi, cantrungGianTren, kyThuat);
                        case ">":
                            return ReturnResultSri(alphaPart, numberPart, canNhay
                            , canKhang, cantrungGianDuoi, cantrungGianTren, kyThuat);
                        default:
                            return AnitBioticResultIndex.ConvertResultToSIR(ketQua);
                    }
                }
                //return AnitBioticResultIndex.ConvertResultToSIR(ketQua);
            }
            else
            {
                //Đánh giá DISK
                var valKetQua = double.Parse(ketQua);
                if (kyThuat.Equals(BioTestMethod.Disk.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    if (valKetQua <= canKhang)
                    {
                        returnSRI = AnitBioticResultIndex.rR;
                    }
                    else if (valKetQua >= canNhay)
                    {
                        returnSRI = AnitBioticResultIndex.rS;
                    }
                    else if ((valKetQua >= cantrungGianDuoi && valKetQua <= cantrungGianTren)
                        || (valKetQua > canNhay && valKetQua < canKhang))
                    {
                        returnSRI = AnitBioticResultIndex.rI;
                    }
                    //Xuống chỗ này có nghĩa là chỉ có 1 giá trị ở cận kháng hay cận nhạy
                    else if (valKetQua < canNhay)
                    {
                        returnSRI = AnitBioticResultIndex.rR;
                    }
                    else if (valKetQua > canKhang)
                    {
                        returnSRI = AnitBioticResultIndex.rS;
                    }
                }
                else
                {
                    //đánh giá MIC ngược với DISK

                    if (valKetQua >= canKhang)
                    {
                        returnSRI = AnitBioticResultIndex.rR;
                    }
                    else if (valKetQua <= canNhay)
                    {
                        returnSRI = AnitBioticResultIndex.rS;
                    }
                    else if ((valKetQua <= cantrungGianTren && valKetQua >= cantrungGianDuoi)
                        || (valKetQua > canNhay && valKetQua < canKhang))
                    {
                        returnSRI = AnitBioticResultIndex.rI;
                    }
                    //Xuống chỗ này có nghĩa là chỉ có 1 giá trị ở cận kháng hay cận nhạy
                    else if (valKetQua < canKhang)
                    {
                        returnSRI = AnitBioticResultIndex.rR;
                    }
                    else if (valKetQua > canNhay)
                    {
                        returnSRI = AnitBioticResultIndex.rS;
                    }
                }
            }
            return returnSRI.ToUpper().Trim();
        }

        private string ReturnResultSri(string compare, string ketQua, double canNhay
            , double canKhang, double cantrungGianDuoi, double cantrungGianTren
            , string kyThuat)
        {
            var returnSRI = string.Empty;
            //kiểm tra neu 4 cái cận không có thì cho SIR là rỗng
            if (
                (canNhay == double.Parse("10000000000000000") && canKhang == double.Parse("-10000000000000000")
                && cantrungGianDuoi == double.Parse("10000000000000000") && cantrungGianTren == double.Parse("-10000000000000000"))
                ||
                (canNhay == double.Parse("-10000000000000000") && canKhang == double.Parse("10000000000000000")
                && cantrungGianDuoi == double.Parse("-10000000000000000") && cantrungGianTren == double.Parse("10000000000000000"))
                )
            {
                return returnSRI = string.Empty;
            }



            #region =
            if (string.Equals(compare, "="))
            {
                var valKetQua = double.Parse(ketQua);
                // đánh giá DISK
                if (kyThuat.Equals(BioTestMethod.Disk.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    if (valKetQua <= canKhang)
                    {
                        returnSRI = AnitBioticResultIndex.rR;
                    }
                    else if (valKetQua >= canNhay)
                    {
                        returnSRI = AnitBioticResultIndex.rS;
                    }
                    else if ((valKetQua >= cantrungGianDuoi && valKetQua <= cantrungGianTren)
                        || (valKetQua > canNhay && valKetQua < canKhang))
                    {
                        returnSRI = AnitBioticResultIndex.rI;
                    }
                }
                else
                {
                    //đánh giá MIC ngược với DISK
                    if (valKetQua >= canKhang)
                    {
                        returnSRI = AnitBioticResultIndex.rR;
                    }
                    else if (valKetQua <= canNhay)
                    {
                        returnSRI = AnitBioticResultIndex.rS;
                    }
                    //else if ((valKetQua <= cantrungGianTren && valKetQua >= cantrungGianDuoi)
                    //    || (valKetQua > canNhay && valKetQua < canKhang))
                    else if ((valKetQua > canNhay && valKetQua < canKhang))
                    {
                        returnSRI = AnitBioticResultIndex.rI;
                    }
                }
            }
            #endregion

            #region >=
            if (string.Equals(compare, ">="))
            {
                double valKetQua = double.Parse(ketQua);
                // đánh giá DISK
                if (kyThuat.Equals(BioTestMethod.Disk.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    if (valKetQua < canKhang)
                    {
                        returnSRI = AnitBioticResultIndex.rR;
                    }
                    else if (valKetQua >= canNhay)
                    {
                        returnSRI = AnitBioticResultIndex.rS;
                    }
                    else if ((valKetQua >= cantrungGianDuoi && valKetQua <= cantrungGianTren)
                        || (valKetQua >= canKhang && valKetQua < canNhay))
                    {
                        returnSRI = AnitBioticResultIndex.rI;
                    }
                }
                else
                {
                    //Đánh giá MIC
                    if (valKetQua >= canKhang)
                    {
                        returnSRI = AnitBioticResultIndex.rR;
                    }
                    else if (valKetQua < canNhay)
                    {
                        returnSRI = AnitBioticResultIndex.rS;
                    }
                    else if ((valKetQua >= canNhay && valKetQua < canKhang))
                    {
                        returnSRI = AnitBioticResultIndex.rI;
                    }
                }
            }


            #endregion

            #region >
            if (string.Equals(compare, ">"))
            {
                double valKetQua = double.Parse(ketQua);
                // đánh giá DISK
                if (kyThuat.Equals(BioTestMethod.Disk.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    if (valKetQua < canKhang)
                    {
                        returnSRI = AnitBioticResultIndex.rR;
                    }
                    else if (valKetQua >= canNhay)
                    {
                        returnSRI = AnitBioticResultIndex.rS;
                    }
                    else if ((valKetQua >= cantrungGianDuoi && valKetQua < cantrungGianTren)
                             || (valKetQua >= canKhang && valKetQua < canNhay))
                    {
                        returnSRI = AnitBioticResultIndex.rI;
                    }
                }
                else
                {
                    //Đánh giá MIC
                    if (valKetQua >= canKhang)
                    {
                        returnSRI = AnitBioticResultIndex.rR;
                    }
                    else if (valKetQua < canNhay)
                    {
                        returnSRI = AnitBioticResultIndex.rS;
                    }
                    else if (valKetQua >= canNhay && valKetQua < canKhang)
                    {
                        returnSRI = AnitBioticResultIndex.rI;
                    }
                }
            }
            #endregion

            #region <
            if (string.Equals(compare, "<"))
            {
                double valKetQua = double.Parse(ketQua);
                // đánh giá DISK
                if (kyThuat.Equals(BioTestMethod.Disk.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    if (valKetQua <= canKhang)
                    {
                        returnSRI = AnitBioticResultIndex.rR;
                    }
                    else if (valKetQua > canNhay)
                    {
                        returnSRI = AnitBioticResultIndex.rS;
                    }
                    else if ((valKetQua >= cantrungGianDuoi && valKetQua <= cantrungGianTren)
                             || (valKetQua > canKhang && valKetQua <= canNhay))
                    {
                        returnSRI = AnitBioticResultIndex.rI;
                    }
                }
                else
                {
                    //Đánh giá MIC
                    if (valKetQua > canKhang)
                    {
                        returnSRI = AnitBioticResultIndex.rR;
                    }
                    else if (valKetQua <= canNhay)
                    {
                        returnSRI = AnitBioticResultIndex.rS;
                    }
                    else if (valKetQua > canNhay && valKetQua <= canKhang)
                    {
                        returnSRI = AnitBioticResultIndex.rI;
                    }
                }
            }

            #endregion

            #region <=
            if (string.Equals(compare, "<="))
            {
                double valKetQua = double.Parse(ketQua);
                // đánh giá DISK
                if (kyThuat.Equals(BioTestMethod.Disk.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    if (valKetQua <= canKhang)
                    {
                        returnSRI = AnitBioticResultIndex.rR;
                    }
                    else if (valKetQua > canNhay)
                    {
                        returnSRI = AnitBioticResultIndex.rS;
                    }
                    else if ((valKetQua >= cantrungGianDuoi && valKetQua <= cantrungGianTren)
                             || (valKetQua > canKhang && valKetQua <= canNhay))
                    {
                        returnSRI = AnitBioticResultIndex.rI;
                    }
                }
                else
                {
                    //Đánh giá MIC
                    if (valKetQua > canKhang)
                    {
                        returnSRI = AnitBioticResultIndex.rR;
                    }
                    else if (valKetQua <= canNhay)
                    {
                        returnSRI = AnitBioticResultIndex.rS;
                    }
                    else if (valKetQua > canNhay && valKetQua <= canKhang)
                    {
                        returnSRI = AnitBioticResultIndex.rI;
                    }
                }
            }

            #endregion


            return returnSRI;
        }

        private void gvKhangSinhDo_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var view = sender as GridView;
            var coKetQua = 0;
            if (e.RowHandle < 0) return;
            if (e.Column.FieldName.Equals(colKSD_SRI.FieldName, StringComparison.OrdinalIgnoreCase)
                || e.Column.FieldName.Equals(colKSD_SRI_M.FieldName, StringComparison.OrdinalIgnoreCase))
            {
                coKetQua = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns[colKSD_CoKetQua.FieldName]).ToString());
                var kqLis = view.GetRowCellValue(e.RowHandle, view.Columns[colKSD_SRI.FieldName]).ToString().Trim();
                var kqM = view.GetRowCellValue(e.RowHandle, view.Columns[colKSD_SRI_M.FieldName]).ToString().Trim();
                switch (coKetQua)
                {
                    case (int)AntiBioticColor.Higher:
                        e.Appearance.Font = new Font(e.Appearance.Font.Name, e.Appearance.Font.Size, FontStyle.Bold);
                        e.Appearance.ForeColor = Color.Red;
                        break;
                    case (int)AntiBioticColor.Lower:
                        e.Appearance.Font = new Font(e.Appearance.Font.Name, e.Appearance.Font.Size, FontStyle.Bold);
                        e.Appearance.ForeColor = Color.Blue;
                        break;
                    default:
                        e.Appearance.Font = new Font(e.Appearance.Font.Name, e.Appearance.Font.Size, FontStyle.Bold);
                        e.Appearance.ForeColor = Color.Black;
                        break;
                }
                if (!kqLis.Equals(kqM))
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
                else
                {
                    e.Appearance.BackColor = Color.White;
                }

            }
            else
            {
                if (!e.Column.OptionsColumn.AllowEdit)
                    e.Appearance.BackColor = Color.LightGray;

            }
        }
        public string SelectedPrinterName = string.Empty;
        public void InketQua(bool print)
        {
            if (string.IsNullOrEmpty(CurrentMaTiepNhan)) return;
            var maYeuCau = string.Empty;
            var maViKhuan = string.Empty;
            if (chkInTheoChiDinh1.Checked && dtgDanhSachChiDinh.CurrentRow != null)
            {
                maYeuCau = dtgDanhSachChiDinh.CurrentRow.Cells[ycMaChiDinh.Name].Value.ToString();
            }
            if (chkInTheoViKhuan.Checked && dtgDanhSachViKhuan.CurrentRow != null)
            {
                maViKhuan = dtgDanhSachViKhuan.CurrentRow.Cells[vkMaPhanLoaiViKhuan.Name].Value.ToString();
            }
            var signName = userSign;
            var dtResult = _microbiologyTesresult.DuLieuIn(CurrentMaTiepNhan, maYeuCau, maViKhuan
                , false, false, false, true, signName, GetKyThuat());
            if (dtResult == null || dtResult.Rows.Count <= 0) return;
            { //XỬ LÝ GHI CHÚ
                if (dtResult.Rows.Count > 0)
                {
                    var lstGhiChu = new List<string>();
                    var dtGhiChu = dtResult.DefaultView.ToTable(true, "GhiChu");
                    foreach (DataRow dr in dtGhiChu.Rows)
                    {
                        var ghiChu = dr["GhiChu"].ToString();
                        if (!string.IsNullOrEmpty(ghiChu))
                        {
                            if (!lstGhiChu.Contains(ghiChu))
                            {
                                lstGhiChu.Add(ghiChu);
                            }
                        }
                    }

                    if (lstGhiChu.Count > 0)
                    {
                        var ghiChuChung = string.Join(", ", lstGhiChu);
                        foreach (DataRow drK in dtResult.Rows)
                        {
                            drK["GhiChu"] = ghiChuChung;
                        }
                    }
                    dtResult.AcceptChanges();
                }
                var arrLogo = GraphicSupport.ImageToByteArray(reportLogo);

                var ic = new ImageConverter();
                var barcode =
                    (byte[])
                    ic.ConvertTo(
                        Code128Rendering.MakeBarcodeImage(
                            string.Format("{0:yyMMdd}{1}",
                                DateTime.Parse(dtResult.Rows[0]["NgayTiepNhan"].ToString()),
                                dtResult.Rows[0]["SEQ"].ToString().Trim()), 1, true),
                        typeof(byte[]));
                for (var i = 0; i < dtResult.Rows.Count; i++)
                {
                    dtResult.Rows[i]["Barcode"] = barcode;
                    dtResult.Rows[i]["ReportLogo"] = arrLogo;
                    dtResult.Rows[i]["KetQuaViSinh"] = WorkingServices.Convert_SubSript(dtResult.Rows[i]["KetQuaViSinh"].ToString());
                }
                //Lấy danh sách mẩu phiếu in
                var reportdataList = dtResult.DefaultView.ToTable(true, "IDMauKetQua");

                if (reportdataList.Rows.Count <= 0) return;

                if (reportdataList.Rows.Count > 0)
                {
                    var rpView = new FrmPreViewReport();
                    foreach (DataRow dr in reportdataList.Rows)
                    {
                        var reportTemplateID = dr["IDMauKetQua"].ToString();
                        if (string.IsNullOrEmpty(reportTemplateID))
                        {
                            var dtPrintError = WorkingServices.SearchResult_OnDatatable(dtResult, "IDMauKetQua is null or IDMauKetQua = ''");
                            dtPrintError = dtPrintError.DefaultView.ToTable(true, "MaYeuCau", "TenYeuCau");
                            if (dtPrintError.Rows.Count > 0)
                            {
                                var messError = string.Empty;
                                foreach (DataRow dataRowE in dtPrintError.Rows)
                                {
                                    messError += (string.IsNullOrEmpty(messError) ? "" : "\n");
                                    messError += string.Format("{0} - {1}", dataRowE["MaYeuCau"].ToString(), dataRowE["TenYeuCau"].ToString());
                                }
                                CustomMessageBox.MSG_Information_OK(string.Format("Các chỉ định chưa được khai báo mẫu in:\n{0}", messError));
                            }
                            continue;
                        }
                        var dtPrint = WorkingServices.SearchResult_OnDatatable(dtResult, string.Format("IDMauKetQua = '{0}'", reportTemplateID));
                        dtPrint.DefaultView.Sort = "MaNhomKhangSinh,ThuTuIn,MaKhangSinh  asc";
                        if (resultReportInfo.ReportSuDung == null)
                            resultReportInfo = GetReportFromConfig(reportTemplateID, null);
                        //nếu sau khi load report vẫn null thì thoát
                        if (resultReportInfo == null || resultReportInfo.ReportSuDung == null)
                        {
                            CustomMessageBox.MSG_Information_OK(string.Format("Biểu mẫu in {0} chưa được khai báo", reportTemplateID));
                            continue;
                        }

                        rpView.SampleID = string.Format("Ketqua_Visinh_KSD_{0}", dtPrint.Rows[0]["MaTiepNhan"].ToString().Trim());
                        rpView.TenBN = dtPrint.Rows[0]["TenBN"].ToString().Trim();
                        rpView.UserSign = signName;
                        var report = _reportInfo.CreateReportFromStream(resultReportInfo.ReportSuDung);
                        var havePrint = rpView.ShowReport(report, dtPrint, print, SelectedPrinterName, "VS", resultReportInfo.TenDataset, resultReportInfo.TenDatatable);
                        if (havePrint)
                        {
                            var lsiMaYeuCau = new List<string>();
                            foreach (DataRow drPrint in dtPrint.Rows)
                            {
                                if (!lsiMaYeuCau.Where(x => x.Equals(drPrint["MaYeuCau"].ToString())).Any())
                                {
                                    lsiMaYeuCau.Add(drPrint["MaYeuCau"].ToString());
                                    _microbiologyTesresult.Update_ketqua_cls_xetnghiem_visinh_yeucau_DaIn(
                                CommonAppVarsAndFunctions.UserID, CurrentMaTiepNhan
                                , drPrint["MaYeuCau"].ToString(), true, signName
                                , CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemInTuXacNhan);
                                }
                            }
                        }
                    }
                }
                Load_YeuCauViSinh_List();
                if (chkInTheoChiDinh1.Checked)
                {
                    bvDanhSachChiDinh.BindingSource.Position = bvDanhSachChiDinh.BindingSource.Find("MaYeuCau", maYeuCau);
                }
            }
        }

        /// <summary>
        /// Khi dòng nào check chọn ở GridView, thì dòng đó được in kết quả.   
        /// </summary>
        /// <param name="dtPrint"></param>
        /// <param name="arrChecked"></param>
        /// <returns></returns>
        private DataTable XuLyCheckChonInKetQua(DataTable dtPrint, int[] arrChecked)
        {
            //Copy dt ra
            //Chỉnh dt chính các KQDL = empty
            //Nếu dòng đó được chọn, thì gán cái KQDL của cái copy vào
            var dtPrint_Copy = dtPrint.Copy();
            foreach (DataRow dr in dtPrint.Rows)
            {
                dr["KetQuaDinhLuong"] = string.Empty;
            }
            foreach (var iRow in arrChecked)
            {
                if (gvKhangSinhDo.GetRowCellValue(iRow, colKSD_MaKhangSinh) == null) continue;
                var maKhangSinh = StringConverter.ToString(gvKhangSinhDo.GetRowCellValue(iRow, colKSD_MaKhangSinh));
                var kyThuat = StringConverter.ToString(gvKhangSinhDo.GetRowCellValue(iRow, colKSD_KyThuat));
                var siteInfection = StringConverter.ToString(gvKhangSinhDo.GetRowCellValue(iRow, colKSD_SiteInfection));
                foreach (DataRow dr in dtPrint.Rows)
                {
                    var colMaKS = StringConverter.ToString(dr["MaKhangSinh"]);
                    var colKyThuat = StringConverter.ToString(dr["KyThuat"]);
                    var colSiteInfection = StringConverter.ToString(dr["SiteInfection"]);
                    if (colMaKS.Equals(maKhangSinh, StringComparison.OrdinalIgnoreCase)
                        && colKyThuat.Equals(kyThuat, StringComparison.OrdinalIgnoreCase)
                        && colSiteInfection.Equals(siteInfection, StringComparison.OrdinalIgnoreCase))
                    {
                        foreach (DataRow dr_Copy in dtPrint_Copy.Rows)
                        {
                            var colMaKS_2 = StringConverter.ToString(dr_Copy["MaKhangSinh"]);
                            var colKyThuat_2 = StringConverter.ToString(dr_Copy["KyThuat"]);
                            var colSiteInfection_2 = StringConverter.ToString(dr_Copy["SiteInfection"]);
                            if (colMaKS_2.Equals(maKhangSinh, StringComparison.OrdinalIgnoreCase)
                                && colKyThuat_2.Equals(kyThuat, StringComparison.OrdinalIgnoreCase)
                                && colSiteInfection_2.Equals(siteInfection, StringComparison.OrdinalIgnoreCase))
                            {
                                dr["KetQuaDinhLuong"] = dr_Copy["KetQuaDinhLuong"];
                            }
                        }
                    }
                }
            }
            return dtPrint;
        }

        private void dtgKetQuaKhaoSat_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgKetQuaKhaoSat.CurrentRow != null)
            {
                cboKetQuaKhaoSat.SelectedIndex = -1;
                txtKetQuaKhaoSat.Text = dtgKetQuaKhaoSat.CurrentRow.Cells[colKetQuaKhaoSat.Name].Value.ToString();
            }
        }

        private void btnLuuKetQuaKhaoSat_Click(object sender, EventArgs e)
        {
            if (dtgKetQuaKhaoSat.CurrentRow == null) return;
            if (dtgDanhSachChiDinh.CurrentRow == null) return;
            var maChiDinh = dtgDanhSachChiDinh.CurrentRow.Cells[ycMaChiDinh.Name].Value.ToString().Trim();
            var accept = true;
            if (!string.IsNullOrEmpty(dtgKetQuaKhaoSat.CurrentRow.Cells[colKetQuaKhaoSat.Name].Value.ToString()))
                accept = CustomMessageBox.MSG_Question_YesNo_GetYes("Thay đổi kết quả khảo sát ?");
            if (!accept) return;
            var objupdate = _microbiologyTesresult.Get_Info_ketqua_cls_xetnghiem_khaosatdaithe(CurrentMaTiepNhan
                , dtgKetQuaKhaoSat.CurrentRow.Cells[colMaKhaoSat.Name].Value.ToString(), maChiDinh);
            objupdate.Nguoinhapketqua = CommonAppVarsAndFunctions.UserID;
            objupdate.Nguoisuaketqua = CommonAppVarsAndFunctions.UserID;
            objupdate.Ketquakhaosat = txtKetQuaKhaoSat.Text;
            if (_microbiologyTesresult.Update_ketqua_cls_xetnghiem_khaosatdaithe(objupdate))
                Load_KetQuaKhaoSat();

            bvKqKhaoSat.BindingSource.Position = bvKqKhaoSat.BindingSource.Find("MaKhaoSat", objupdate.Makhaosat);
        }

        private void btnThemKhaoSat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CurrentMaTiepNhan) || cboKhaoSat.SelectedIndex <= -1) return;
            if (dtgDanhSachChiDinh.CurrentRow == null) return;
            var maChiDinh = dtgDanhSachChiDinh.CurrentRow.Cells[ycMaChiDinh.Name].Value.ToString().Trim();
            var objinsert = new KETQUA_CLS_XETNGHIEM_KHAOSATDAITHE
            {
                Matiepnhan = CurrentMaTiepNhan,
                Makhaosat = cboKhaoSat.SelectedValue.ToString(),
                Mayeucau = maChiDinh
            };
            if (_microbiologyTesresult.Insert_ketqua_cls_xetnghiem_khaosatdaithe(objinsert))
            {
                Load_KetQuaKhaoSat();
                string mavikhuanDangCheck = dtgDanhSachViKhuan.CurrentRow == null ? string.Empty : dtgDanhSachViKhuan.CurrentRow.Cells[vkMaPhanLoaiViKhuan.Name].Value.ToString();
                Load_KetQuaViKhuan(mavikhuanDangCheck);
            }
            bvKqKhaoSat.BindingSource.Position = bvKqKhaoSat.BindingSource.Find("MaKhaoSat", objinsert.Makhaosat);
        }

        private void dtgKetQuaKhaoSat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colCoaKhaoSat.Index)
            {
                if (!colCoaKhaoSat.ReadOnly)
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa kết quả khảo sát ?"))
                    {
                        var objdelete = _microbiologyTesresult.Get_Info_ketqua_cls_xetnghiem_khaosatdaithe(CurrentMaTiepNhan
                                                            , dtgKetQuaKhaoSat.CurrentRow.Cells[colMaKhaoSat.Name].Value.ToString(), dtgKetQuaKhaoSat.CurrentRow.Cells[colKhaoSat_MaYeuCau.Name].Value.ToString());
                        if (_microbiologyTesresult.Delete_ketqua_cls_xetnghiem_khaosatdaithe(objdelete))
                        {
                            Load_KetQuaKhaoSat();
                            string mavikhuanDangCheck = dtgDanhSachViKhuan.CurrentRow == null ? string.Empty: dtgDanhSachViKhuan.CurrentRow.Cells[vkMaPhanLoaiViKhuan.Name].Value.ToString();
                            Load_KetQuaViKhuan(mavikhuanDangCheck);
                        }
                    }
                }
            }
        }

        private void btnNhapVK_KSD_Click(object sender, EventArgs e)
        {
            InsertVK_KSD();
        }

        public void InsertVK_KSD(string maViKhuan = null, bool reCcalculate = false)
        {

            if (dtgDanhSachChiDinh.Rows.Count > 0)
            {
                var maChiDinh = StringConverter.ToString(dtgDanhSachChiDinh.CurrentRow.Cells[ycMaChiDinh.Name].Value);
                var successful_vk_amtinh = false;
                var aKyThuat = new string[3]
                {
                    BioTestMethod.Disk.ToString()
                    , BioTestMethod.MIC.ToString(), BioTestMethod.ETEST.ToString()
                };
                if (maViKhuan == null)
                    maViKhuan = StringConverter.ToString(ucSearchLookupEditor_PhanLoaiVK_Loai.SelectedValue).Trim();
                if (!string.IsNullOrEmpty(maViKhuan))
                {
                    var dataMaBoKhangSinh = _bioticConfig.Data_dm_xetnghiem_visinh_bo_by_mvk(maViKhuan);
                    if (dataMaBoKhangSinh.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dataMaBoKhangSinh.Rows)
                        {
                            foreach (var kyThuat in aKyThuat)
                            {
                                var maBoKhangSinh = StringConverter.ToString(dr["MaBoKhangSinh"]);
                                //Kiểm tra không có kỹ thuật trong Panel
                                if (!CheckExistedKyThuat(maBoKhangSinh, maViKhuan, kyThuat)) continue;
                                if (dtgDanhSachChiDinh.CurrentRow == null) continue;
                                _microbiologyTesresult.Insert_ketqua_cls_xetnghiem_vikhuan
                                     (CurrentMaTiepNhan
                                         , maChiDinh
                                         , maViKhuan
                                         , CommonAppVarsAndFunctions.UserID, kyThuat
                                         , (int)numLanThucHien.Value, maBoKhangSinh
                                     );
                            }
                        }
                    }
                    else
                    {
                        _microbiologyTesresult.Insert_ketqua_cls_xetnghiem_vikhuan_amtinh
                                (CurrentMaTiepNhan, maChiDinh
                                , maViKhuan
                                , CommonAppVarsAndFunctions.UserID, BioTestMethod.Disk.ToString().ToUpper()
                                , (int)numLanThucHien.Value);
                    }
                    if (reCcalculate)
                        DanhGiaKetQuaSauKhiNhapLaiPanel(maViKhuan, maChiDinh);
                    Load_KetQuaViKhuan(maViKhuan);
                }
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập yêu cầu xét nghiệm!");
            }
        }

        private bool CheckExistedKyThuat(string maBoKhangSinh, string maViKhuan, string kyThuat)
        {
            return _microbiologyTesresult.Check_Existed_dm_xetnghiem_khangsinh_bo_chitiet(maBoKhangSinh, maViKhuan, kyThuat);
        }

        private void cboKyThuat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
               // btnNhapVK_KSD.Focus();
                e.Handled = true;
            }
        }
        private void btnKSD_XoaKhangSinh_Click(object sender, EventArgs e)
        {
            if (gvKhangSinhDo.SelectedRowsCount <= 0) return;
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa các kháng sinh đang chọn?"))
            {
                var maKhangsinh = string.Empty;
                var maVikhuan = string.Empty;
                var maYeuCau = string.Empty;
                var kyThuat = string.Empty;
                var maTiepNhan = string.Empty;
                var siteINF = string.Empty;

                var intArr = gvKhangSinhDo.GetSelectedRows();
                foreach (var i in intArr)
                {
                    if (gvKhangSinhDo.GetRowCellValue(i, colKSD_MaKhangSinh) != null)
                    {
                        maKhangsinh = gvKhangSinhDo.GetRowCellValue(i, colKSD_MaKhangSinh).ToString().Trim();
                        siteINF = gvKhangSinhDo.GetRowCellValue(i, colKSD_SiteInfection).ToString().Trim();
                        maVikhuan = gvKhangSinhDo.GetRowCellValue(i, colKSD_MaViKhuan).ToString().Trim();
                        maYeuCau = gvKhangSinhDo.GetRowCellValue(i, colKSD_YeuCauViSinh).ToString().Trim();
                        kyThuat = gvKhangSinhDo.GetRowCellValue(i, colKSD_KyThuat).ToString().Trim();
                        maTiepNhan = gvKhangSinhDo.GetRowCellValue(i, colKSD_MaTiepNhan).ToString().Trim();
                        var lanXn = int.Parse(gvKhangSinhDo.GetRowCellValue(i, colKSD_LanXetNghiem).ToString());
                        _microbiologyTesresult.Delete_KhangSinh(maTiepNhan, maYeuCau, maVikhuan, maKhangsinh, kyThuat, lanXn, siteINF);
                    }
                }
                Load_KetQuaKhangSinh();
            }
        }

        private void gcKhangDinhDo_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            (gcKhangDinhDo.FocusedView as ColumnView).FocusedRowHandle++;
            //  (gcKhangDinhDo.FocusedView as ColumnView).ShowEditor();

            e.Handled = true;
        }

        private void bntXoaKhangKhangSinh_Click(object sender, EventArgs e)
        {
            if (dtgKhangKhangSinh.CurrentRow != null)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa kết quả kháng kháng sinh ?"))
                {

                    var maTiepNhan = dtgKhangKhangSinh.CurrentRow.Cells[colKhanhKhangSinh_MaTiepNhan.Name].Value.ToString();
                    var maViKhuan = dtgKhangKhangSinh.CurrentRow.Cells[colKhangKhangSinh_MaViKhuan.Name].Value.ToString();
                    var maYeuCau = dtgKhangKhangSinh.CurrentRow.Cells[colKhangKhangSinh_MaYeuCau.Name].Value.ToString();
                    var maKhangKhangSinh = dtgKhangKhangSinh.CurrentRow.Cells[colKhangKhangSinh_MaKhangKhangSinh.Name].Value.ToString();
                    var lanXn = int.Parse(dtgKhangKhangSinh.CurrentRow.Cells[colKhangKhangSinh_LaXn.Name].Value.ToString());
                    if (_microbiologyTesresult.Delete_ketqua_cls_xetnghiem_visinh_khangkhangsinh(new KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH(
                         maTiepNhan, maYeuCau, maViKhuan, maKhangKhangSinh, string.Empty
                         , string.Empty, DateTime.Now, string.Empty, null, lanXn)))
                        Load_KetQua_DeKhangKhangSinh();
                }
            }
        }

        private void cboKhangKhangSinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (cboKhangKhangSinh.SelectedIndex > -1)
                {
                    txtKetQuaKhangKhangSinh.Focus();
                    txtKetQuaKhangKhangSinh.SelectAll();
                }
                e.Handled = true;
            }
        }
        private void Insert_KetQuaKhangKhangSinh()
        {
            if (cboKhangKhangSinh.SelectedIndex > -1 && !string.IsNullOrEmpty(txtKetQuaKhangKhangSinh.Text))
            {
                if (dtgDanhSachViKhuan.CurrentRow != null)
                {
                    if (dtgDanhSachChiDinh.CurrentRow != null)
                    {
                        var maTiepNhan = dtgDanhSachViKhuan.CurrentRow.Cells[vkMaTiepNhan.Name].Value.ToString();
                        var maChiDinh = dtgDanhSachViKhuan.CurrentRow.Cells[vkMaChiDinh.Name].Value.ToString().Trim();
                        var maViKhuan = dtgDanhSachViKhuan.CurrentRow.Cells[vkMaPhanLoaiViKhuan.Name].Value.ToString().Trim();
                        var lanXn = int.Parse(dtgDanhSachViKhuan.CurrentRow.Cells[colViKhuan_LanXN.Name].Value.ToString().Trim());
                        var maKhangKhangSinh = cboKhangKhangSinh.SelectedValue.ToString();
                        var obj = new KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH();
                        obj.Matiepnhan = maTiepNhan;
                        obj.Mayeucau = maChiDinh;
                        obj.Maphanloai = maViKhuan;
                        obj.Makhangkhangsinh = maKhangKhangSinh;
                        obj.Ketqua = txtKetQuaKhangKhangSinh.Text.Trim();
                        obj.Ketquachu = (obj.Ketqua.Contains("+") || obj.Ketqua.ToLower().Contains("pos") ? "Positive" : (obj.Ketqua.Contains("-") || obj.Ketqua.ToLower().Contains("neg") ? "Negative" : ""));
                        obj.Nguoinhap = CommonAppVarsAndFunctions.UserID;
                        obj.LanXetNghiem = lanXn;
                        var ok = _microbiologyTesresult.Insert_ketqua_cls_xetnghiem_visinh_khangkhangsinh(obj);
                        if (ok.Id > -1)
                        {
                            txtKetQuaKhangKhangSinh.Text = string.Empty;
                            cboKhangKhangSinh.SelectedIndex = -1;

                            Load_KetQua_DeKhangKhangSinh();

                        }
                        else
                            CustomMessageBox.MSG_Information_OK(string.Format("Thêm kết quả kháng kháng sinh bị lỗi!\n{0}", ok.Name));
                    }
                }
            }
        }
        private void Update_KhangKhangSinh(int rowIndex)
        {
            var maTiepNhan = dtgKhangKhangSinh[colKhanhKhangSinh_MaTiepNhan.Name, rowIndex].Value.ToString();
            var maViKhuan = dtgKhangKhangSinh[colKhangKhangSinh_MaViKhuan.Name, rowIndex].Value.ToString();
            var maChiDinh = dtgKhangKhangSinh[colKhangKhangSinh_MaYeuCau.Name, rowIndex].Value.ToString();
            var maKhangKhangSinh = dtgKhangKhangSinh[colKhangKhangSinh_MaKhangKhangSinh.Name, rowIndex].Value.ToString();
            var ketQua = dtgKhangKhangSinh[colKhangKhangSinh_KetQua.Name, rowIndex].Value.ToString();
            var lanXn = int.Parse(dtgKhangKhangSinh[colKhangKhangSinh_LaXn.Name, rowIndex].Value.ToString());
            var obj = _microbiologyTesresult.Get_Info_ketqua_cls_xetnghiem_visinh_khangkhangsinh(maTiepNhan, maChiDinh, maViKhuan, maKhangKhangSinh);
            obj.Matiepnhan = maTiepNhan;
            obj.Mayeucau = maChiDinh;
            obj.Maphanloai = maViKhuan;
            obj.Makhangkhangsinh = maKhangKhangSinh;
            obj.Nguoinhap = CommonAppVarsAndFunctions.UserID;
            obj.Nguoisua = CommonAppVarsAndFunctions.UserID;
            obj.Ketqua = ketQua;
            obj.Ketquachu = (obj.Ketqua.Contains("+") || obj.Ketqua.ToLower().Contains("pos") ? "Positive" : (obj.Ketqua.Contains("-") || obj.Ketqua.ToLower().Contains("neg") ? "Negative" : ""));
            obj.LanXetNghiem = lanXn;
            obj.Tgsua = DateTime.Now;
            var ok = _microbiologyTesresult.Update_ketqua_cls_xetnghiem_visinh_khangkhangsinh(obj);

            if (ok)
            {
                dtgKhangKhangSinh[colKhangKhangSinh_NguoiSua.Name, rowIndex].Value = CommonAppVarsAndFunctions.UserID;
                dtgKhangKhangSinh[colKhangKhangSinh_TGSuaKetQua.Name, rowIndex].Value = DateTime.Now;
                dtgKhangKhangSinh[colKhangkhangSinh_KetQuaChu.Name, rowIndex].Value = obj.Ketquachu;
            }
        }
        private void Delete_KhangKhangSinh(int rowIndex)
        {
            var maTiepNhan = dtgKhangKhangSinh[colKhanhKhangSinh_MaTiepNhan.Name, rowIndex].Value.ToString();
            var maViKhuan = dtgKhangKhangSinh[colKhangKhangSinh_MaViKhuan.Name, rowIndex].Value.ToString();
            var maChiDinh = dtgKhangKhangSinh[colKhangKhangSinh_MaYeuCau.Name, rowIndex].Value.ToString();
            var maKhangKhangSinh = dtgKhangKhangSinh[colKhangKhangSinh_MaKhangKhangSinh.Name, rowIndex].Value.ToString();
            var lanXn = int.Parse(dtgKhangKhangSinh[colKhangKhangSinh_LaXn.Name, rowIndex].Value.ToString());
            if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Xóa kết quả: {0}", maKhangKhangSinh)))
            {
                var obj = _microbiologyTesresult.Get_Info_ketqua_cls_xetnghiem_visinh_khangkhangsinh(maTiepNhan, maChiDinh
                , maViKhuan, maKhangKhangSinh);
                obj.Matiepnhan = maTiepNhan;
                obj.Mayeucau = maChiDinh;
                obj.Maphanloai = maViKhuan;
                obj.Makhangkhangsinh = maKhangKhangSinh;
                obj.Nguoinhap = CommonAppVarsAndFunctions.UserID;
                obj.Nguoisua = CommonAppVarsAndFunctions.UserID;
                obj.LanXetNghiem = lanXn;
                var ok = _microbiologyTesresult.Delete_ketqua_cls_xetnghiem_visinh_khangkhangsinh(obj);
                if (ok)
                    Load_KetQua_DeKhangKhangSinh();
            }
        }
        private void btnXoaKhangKhangSinh_Click(object sender, EventArgs e)
        {
            if (dtgKhangKhangSinh.CurrentRow != null)
                Delete_KhangKhangSinh(dtgKhangKhangSinh.CurrentRow.Index);
        }
        private void txtKetQuaKhangKhangSinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtKetQuaKhangKhangSinh.Text) && cboKhangKhangSinh.SelectedIndex > -1)
                    Insert_KetQuaKhangKhangSinh();
                e.Handled = true;
            }
        }

        private void btnThemKhangkhangSinh_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtKetQuaKhangKhangSinh.Text) && cboKhangKhangSinh.SelectedIndex > -1)
                Insert_KetQuaKhangKhangSinh();
            else
                CustomMessageBox.MSG_Information_OK("Hãy nhập thông tin kháng kháng sinh và kết quả!");
        }

        private void dtgKhangKhangSinh_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colKhangKhangSinh_KetQua.Index)
                Update_KhangKhangSinh(e.RowIndex);
        }

        private void dtgKhangKhangSinh_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dtgKhangKhangSinh.RowCount > 0)
            {
                var ketQua = string.Empty;
                for (int i = 0; i < dtgKhangKhangSinh.RowCount; i++)
                {
                    ketQua = dtgKhangKhangSinh[colKhangKhangSinh_KetQua.Name, i].Value.ToString();
                    if (ketQua.Contains("+"))
                        dtgKhangKhangSinh.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    else if (ketQua.Contains("-"))
                        dtgKhangKhangSinh.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                }
            }
        }
        private void btnKSD_ThemKhangSinh_Click(object sender, EventArgs e)
        {
            if (dtgDanhSachChiDinh.CurrentRow != null && dtgDanhSachViKhuan.CurrentRow != null)
            {
                var f = new BenhNhan.FrmChonKhangSinh();
                f.ShowDialog();
                if (f.lstDSKhangSinh.Count > 0)
                {
                    var maTiepNhan = dtgDanhSachChiDinh.CurrentRow.Cells[ycMaTiepNhan.Name].Value.ToString();
                    var maYeuCau = dtgDanhSachChiDinh.CurrentRow.Cells[ycMaChiDinh.Name].Value.ToString();
                    var maViKhuan = dtgDanhSachViKhuan.CurrentRow.Cells[vkMaPhanLoaiViKhuan.Name].Value.ToString();
                    var lanXn = int.Parse(dtgDanhSachViKhuan.CurrentRow.Cells[colViKhuan_LanXN.Name].Value.ToString());
                    foreach (var item in f.lstDSKhangSinh)
                    {
                        _microbiologyTesresult.Insert_Ketqua_xetnghiem_khangsinhdo_khongvikhuan(maTiepNhan, maYeuCau, maViKhuan
                            , item, f.kyThuat, CommonAppVarsAndFunctions.UserID, lanXn);
                    }
                    Load_KetQuaKhangSinh();
                }
            }
        }
        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            Luu_LoaiMau();
            LuuKetQuaViSinh();
            Button_GoiLenh_Click?.Invoke(sender, e);
        }
        private void Luu_LoaiMau()
        {
            //if (dtgDanhSachChiDinh.CurrentRow != null)
            //{
            //    var maLoaiMauNhan = ucSearchLookupEditor_LoaiMau1.SelectedValue == null ? string.Empty : ucSearchLookupEditor_LoaiMau1.SelectedValue.ToString();
            //    _microbiologyTesresult.Update_Ketqua_Cls_XetNghiem_ViSinh_LoaiMauNhan(maLoaiMauNhan
            //        , dtgDanhSachChiDinh.CurrentRow.Cells[ycMaTiepNhan.Name].Value.ToString().Trim()
            //        , dtgDanhSachChiDinh.CurrentRow.Cells[ycMaChiDinh.Name].Value.ToString().Trim()
            //        , CommonAppVarsAndFunctions.UserID, true);
            //}
        }
        private void btnBoXacNhanKetQua_Click(object sender, EventArgs e)
        {
            XacNhan_BoXacNhan(false);
            Button_GoiLenh_Click?.Invoke(sender, e);
        }
        private void btnXacNhanKetQua_Click(object sender, EventArgs e)
        {
            XacNhan_BoXacNhan(true);
            Button_GoiLenh_Click?.Invoke(sender, e);
        }
        public void XacNhan_BoXacNhan(bool xacNhan, bool showMess = true)
        {
            string yeuCau = dtgDanhSachChiDinh.CurrentRow.Cells[ycTenChiDinh.Name].Value.ToString();
            var allow = !showMess;
            if (!allow)
                allow = CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("{0} kết quả của chỉ định:\n{1}", (xacNhan ? "Duyệt" : "Bỏ duyệt"), yeuCau));
            if (allow)
            {
                string maTiepNhan = dtgDanhSachChiDinh.CurrentRow.Cells[ycMaTiepNhan.Name].Value.ToString();
                string lstMaYeuCau = dtgDanhSachChiDinh.CurrentRow.Cells[ycMaChiDinh.Name].Value.ToString();
                string userUpdate = CommonAppVarsAndFunctions.UserID;

                bool xacNhanDe = false;
                bool kiemTraUser = true;
                if(xacNhan && _microbiologyTesresult.Get_DanhSach_ViKhuan(maTiepNhan, lstMaYeuCau, string.Empty,1).Rows.Count == 0)
                {
                    CustomMessageBox.MSG_Information_OK("Không thể duyệt khi chưa nhập kết quả");
                    return;
                }
                if (_microbiologyTesresult.Update_ketqua_cls_xetnghiem_visinh_XacNhan(maTiepNhan, lstMaYeuCau
                    , userUpdate, xacNhan, xacNhanDe, kiemTraUser, CommonAppVarsAndFunctions.PCWorkPlace) > 0)
                {
                    Load_YeuCauViSinh_List();
                    bvDanhSachChiDinh.BindingSource.Position = bvDanhSachChiDinh.BindingSource.Find("MaYeuCau", lstMaYeuCau);
                }
            }
        }
        private void btnThemCard_Click(object sender, EventArgs e)
        {
            //if (dtgDanhSachChiDinh.CurrentRow != null && !string.IsNullOrEmpty(txtTheDinhDanh.Text))
            //{
            //    var maTiepNhan = dtgDanhSachChiDinh.CurrentRow.Cells[ycMaTiepNhan.Name].Value.ToString();
            //    var maYeuCau = dtgDanhSachChiDinh.CurrentRow.Cells[ycMaChiDinh.Name].Value.ToString();
            //    if (_microbiologyTesresult.CapNhat_TheDinhDanh(maTiepNhan, maYeuCau, txtTheDinhDanh.Text, CommonAppVarsAndFunctions.UserID))
            //    {
            //        Load_TheDinhDanh();
            //        txtTheDinhDanh.Text = string.Empty;
            //        txtTheDinhDanh.Focus();
            //    }
            //}
        }

        private void btnXoaCard_Click(object sender, EventArgs e)
        {
            //if (dtgCardDinhDanh.CurrentRow != null)
            //{
            //    var maTiepNhan = dtgCardDinhDanh.CurrentRow.Cells[colICard_MaTiepNhan.Name].Value.ToString();
            //    var maYeuCau = dtgCardDinhDanh.CurrentRow.Cells[colIdCard_MaChiDinh.Name].Value.ToString();
            //    var maThe = dtgCardDinhDanh.CurrentRow.Cells[colIDCard_MaThe.Name].Value.ToString();
            //    if (_microbiologyTesresult.Delete_TheDinhDanh(maTiepNhan, maYeuCau, maThe, CommonAppVarsAndFunctions.UserID))
            //    {
            //        Load_TheDinhDanh();
            //        txtTheDinhDanh.Text = string.Empty;
            //        txtTheDinhDanh.Focus();
            //    }
            //}
        }
        private void Load_TheDinhDanh()
        {
            dtgCardDinhDanh.DataSource = null;
            if (dtgDanhSachChiDinh.CurrentRow != null)
            {
                var maTiepNhan = dtgDanhSachChiDinh.CurrentRow.Cells[ycMaTiepNhan.Name].Value.ToString();
                var maYeuCau = dtgDanhSachChiDinh.CurrentRow.Cells[ycMaChiDinh.Name].Value.ToString();
                var data = _microbiologyTesresult.DanhSach_TheDinhDanh(maTiepNhan, maYeuCau);
                dtgCardDinhDanh.AutoGenerateColumns = false;
                dtgCardDinhDanh.DataSource = data;
            }
        }

        private void dtgDanhSachViKhuan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dtgDanhSachChiDinh.CurrentRow != null && dtgDanhSachViKhuan.CurrentRow != null)
                {
                    if (e.ColumnIndex == colViKHuan_MauSac.Index)
                    {
                        ColorDialog cl = new ColorDialog();
                        cl.ShowDialog();
                        if (cl.Color != null)
                        {
                            var maTiepNhan = dtgDanhSachChiDinh.CurrentRow.Cells[ycMaTiepNhan.Name].Value.ToString();
                            var maYeuCau = dtgDanhSachChiDinh.CurrentRow.Cells[ycMaChiDinh.Name].Value.ToString();
                            var maViKhuan = dtgDanhSachViKhuan.CurrentRow.Cells[vkMaPhanLoaiViKhuan.Name].Value.ToString();

                            var lanXn = int.Parse(dtgDanhSachViKhuan.CurrentRow.Cells[colViKhuan_LanXN.Name].Value.ToString());

                            var colorString = string.Format("{0},{1},{2}", cl.Color.R, cl.Color.G, cl.Color.B);

                            _microbiologyTesresult.CapNhat_MauViKhuan(maTiepNhan, maYeuCau, maViKhuan, colorString, lanXn);

                            dtgDanhSachViKhuan[e.ColumnIndex, e.RowIndex].Style.BackColor = cl.Color;
                            dtgDanhSachViKhuan[colViKHuan_MauSac.Name, e.RowIndex].Style.SelectionBackColor = cl.Color;
                            dtgDanhSachViKhuan[colViKhuan_MaMauSac.Name, e.RowIndex].Value = colorString;
                        }
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnKetQuaTienSu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CurrentMaBenhNhan))
            {
                //var maTiepNhan = data
                FrmHoSoBenhAn f = new FrmHoSoBenhAn();
                f.maBienhNhanTim = CurrentMaBenhNhan;
                f.loaiDvXem = ServiceType.ClsXNViSinh;
                f.ShowDialog();
            }
        }

        private void btnXemKetQuaThuongQuy_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(CurrentBarcode))
            //{
            //    var f = new FrmXemKetQuaXetNghiem();
            //    f.Barcode = CurrentBarcode;
            //    f.ShowDialog();
            //}
        }

        private void btnLuuGhiChuViKhuan_Click(object sender, EventArgs e)
        {
            if (dtgDanhSachViKhuan.CurrentRow != null)
            {
                var maPhanLoai = dtgDanhSachViKhuan.CurrentRow.Cells[vkMaPhanLoaiViKhuan.Name].Value.ToString();
                var maTiepNhan = dtgDanhSachViKhuan.CurrentRow.Cells[vkMaTiepNhan.Name].Value.ToString();
                var maYeuCau = dtgDanhSachViKhuan.CurrentRow.Cells[vkMaChiDinh.Name].Value.ToString();
                var lanXN = int.Parse(dtgDanhSachViKhuan.CurrentRow.Cells[colViKhuan_LanXN.Name].Value.ToString());
                var ghiChu = txtKetQuaViKhuan.Text;
                _microbiologyTesresult.CapNhat_GhiChu_ViKhuan(maTiepNhan, maYeuCau, maPhanLoai, ghiChu, CommonAppVarsAndFunctions.UserID, lanXN);
                dtgDanhSachViKhuan.CurrentRow.Cells[colVk_GhiChu.Name].Value = ghiChu;
                dtgDanhSachViKhuan.CurrentRow.Cells[colVK_NguoiNhapGhiChu.Name].Value = CommonAppVarsAndFunctions.UserID;
                dtgDanhSachViKhuan.CurrentRow.Cells[colVK_GioNhapGhiChu.Name].Value = DateTime.Now;
            }
        }

        private void txtKetQuaViKhuan_TextChanged(object sender, EventArgs e)
        {

        }

        private void customLable4_Click(object sender, EventArgs e)
        {

        }

        private void mnuCapNhatMay_KSD_Click(object sender, EventArgs e)
        {
            if (btnSaveAll.Enabled)
            {
                ucSearchLookupEditor_MayXN2.SelectedValue = null;
                pnChonMayCapNhat.Visible = true;
                pnChonMayCapNhat.Tag = 2;
            }
            else
                CustomMessageBox.MSG_Information_OK("Không thể cập nhật cho kết quả đã duyệt.");
        }

        private void btnCapNhatMayXn_Click(object sender, EventArgs e)
        {
            var selectedVal = ucSearchLookupEditor_MayXN2.SelectedValue;
            if (selectedVal != null)
            {
                if (pnChonMayCapNhat.Tag.ToString() == "1")
                {
                    if (dtgDanhSachViKhuan.RowCount > 0)
                    {
                        var maViKhuan = dtgDanhSachViKhuan.CurrentRow.Cells[vkMaPhanLoaiViKhuan.Name].Value.ToString();
                        var tenViKhuan = dtgDanhSachViKhuan.CurrentRow.Cells[vkTenPhanLoaiViKhuan.Name].Value.ToString();
                        var maTiepNhan = dtgDanhSachViKhuan.CurrentRow.Cells[vkMaTiepNhan.Name].Value.ToString();
                        var maChiDinh = dtgDanhSachViKhuan.CurrentRow.Cells[vkMaChiDinh.Name].Value.ToString();
                        var lanXetNghiem = int.Parse(dtgDanhSachViKhuan.CurrentRow.Cells[colViKhuan_LanXN.Name].Value.ToString());
                        if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Cập nhật thông tin máy cho: {0}", tenViKhuan)))
                        {
                            _microbiologyTesresult.CapNhat_ThongTinMayXN_ViKhuan(maTiepNhan, maChiDinh, maViKhuan
                                , int.Parse(selectedVal == null ? "0" : selectedVal.ToString()), lanXetNghiem);
                            _microbiologyTesresult.CapNhat_ThongTinQuyTrinh_LoaiMau(maTiepNhan, maChiDinh, int.Parse(selectedVal == null ? "0" : selectedVal.ToString()));
                            pnChonMayCapNhat.Visible = false;
                            Load_YeuCauViSinh_List();
                            bvViKhuan.BindingSource.Position = bvViKhuan.BindingSource.Find(vkMaPhanLoaiViKhuan.DataPropertyName, maViKhuan);
                        }
                    }
                }
                else
                {
                    if (gvKhangSinhDo.SelectedRowsCount > 0)
                    {
                        if (CustomMessageBox.MSG_Question_YesNo_GetYes("Cập nhật thông tin máy cho các kháng sinh đang chọn?"))
                        {
                            var maTiepNhan = string.Empty;
                            foreach (var item in gvKhangSinhDo.GetSelectedRows())
                            {
                                if (gvKhangSinhDo.GetRowCellValue(item, colKSD_MaKhangSinh) != null)
                                {
                                    var maKhangSinh = gvKhangSinhDo.GetRowCellValue(item, colKSD_MaKhangSinh).ToString();
                                    var maViKhuan = gvKhangSinhDo.GetRowCellValue(item, colKSD_MaViKhuan).ToString();
                                    maTiepNhan = gvKhangSinhDo.GetRowCellValue(item, colKSD_MaTiepNhan).ToString();
                                    var maYeuCau = gvKhangSinhDo.GetRowCellValue(item, colKSD_YeuCauViSinh).ToString();
                                    var kyThuat = gvKhangSinhDo.GetRowCellValue(item, colKSD_KyThuat).ToString();
                                    var ketQuaDinhLuong = gvKhangSinhDo.GetRowCellValue(item, colKSD_KetQua).ToString();
                                    var coKetQua = gvKhangSinhDo.GetRowCellValue(item, colKSD_CoKetQua).ToString();
                                    var SIR = gvKhangSinhDo.GetRowCellValue(item, colKSD_SRI).ToString();
                                    var lanxetnghiem = int.Parse(gvKhangSinhDo.GetRowCellValue(item, colKSD_LanXetNghiem).ToString());
                                    _microbiologyTesresult.Update_KetQuaKhangSinh(maTiepNhan, maYeuCau, maViKhuan, maKhangSinh, kyThuat, SIR, ketQuaDinhLuong
                                        , int.Parse(coKetQua), CommonAppVarsAndFunctions.UserID, lanxetnghiem, string.Empty, int.Parse(selectedVal == null ? "0" : selectedVal.ToString()));
                                }
                            }
                            pnChonMayCapNhat.Visible = false;
                            Load_YeuCauViSinh_List();
                            bvViKhuan.BindingSource.Position = bvViKhuan.BindingSource.Find("MaTiepNhan", maTiepNhan);
                        }
                    }
                }
            }
        }

        private void btnHuyCapNhat_Click(object sender, EventArgs e)
        {
            pnChonMayCapNhat.Visible = false;
        }

        private void ucSearchLookupEditor_PhanLoaiVK_Loai_KeyDown(object sender, KeyEventArgs e)
        {
            bindingCbbAntibioticPanel();
        }

        private void bindingCbbAntibioticPanel()
        {
            var maViKhuan = string.Empty;
            var maBoKhangSinh = string.Empty;

            if (ucSearchLookupEditor_PhanLoaiVK_Loai.SelectedValue != null)
            {
                maViKhuan = ucSearchLookupEditor_PhanLoaiVK_Loai.SelectedValue.ToString().Trim();
            }
            var data = _bioticConfig.Data_dm_xetnghiem_khangsinh_bo_chitiet(maViKhuan);
            if (data.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(data.Rows[0]["MaBoKhangSinh"].ToString()))
                    maBoKhangSinh = data.Rows[0]["MaBoKhangSinh"].ToString();
                if (ucSearchLookupEditor_PhanLoaiVK_Loai.SelectedValue != null)
                    maViKhuan = ucSearchLookupEditor_PhanLoaiVK_Loai.SelectedValue.ToString().Trim();
                ucSearchLookupEditor_AntibioticPanel.Load_AntibioticPanel(maBoKhangSinh, maViKhuan);
            }
            if (string.IsNullOrEmpty(maBoKhangSinh))
            {
                ucSearchLookupEditor_AntibioticPanel.DataSource = null;
            }
        }

        private void ucSearchLookupEditor_PhanLoaiVK_Loai_Leave(object sender, EventArgs e)
        {
            bindingCbbAntibioticPanel();
        }

        private void ucSearchLookupEditor_PhanLoaiVK_Loai_Enter_1(object sender, EventArgs e)
        {
            bindingCbbAntibioticPanel();
        }

        private void ucSearchLookupEditor_PhanLoaiVK_Loai_CursorChanged(object sender, EventArgs e)
        {
            bindingCbbAntibioticPanel();
        }

        private void ucSearchLookupEditor_PhanLoaiViKhuan_EditValueChanged(object sender, EventArgs e)
        {
            InsertVK_KSD();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (gvKhangSinhDo.RowCount <= 0) return;
            ExportToExcel.Export(gcKhangDinhDo, string.Format("KhangSinhDo_BenhNhan_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")));
        }


        private void FrmCLSKetQuaViSinh_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F10)
            //{
            //    duyetCoKetQuaVeHIS();
            //}
        }
        private void dtgKetQuaKhaoSat_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgKetQuaKhaoSat.CurrentRow == null) return;
            var objupdate = _microbiologyTesresult.Get_Info_ketqua_cls_xetnghiem_khaosatdaithe(CurrentMaTiepNhan
                , dtgKetQuaKhaoSat.CurrentRow.Cells[colMaKhaoSat.Name].Value.ToString(), dtgKetQuaKhaoSat.CurrentRow.Cells[colKhaoSat_MaYeuCau.Name].Value.ToString());
            objupdate.GhiChu = StringConverter.ToString(dtgKetQuaKhaoSat.CurrentRow.Cells[colGhiChu.Name].Value);
            objupdate.Nguoisuaketqua = CommonAppVarsAndFunctions.UserID;
            if (_microbiologyTesresult.Update_ketqua_cls_xetnghiem_khaosatdaithe(objupdate))
                Load_KetQuaKhaoSat();

            bvKqKhaoSat.BindingSource.Position = bvKqKhaoSat.BindingSource.Find("MaKhaoSat", objupdate.Makhaosat);
        }

        public void XoaThongTinDS()
        {
            txtTenLoaiMauHIS.Text = string.Empty;
            txtMaSoMau.Text = string.Empty;
            ucSearchLookupEditor_PhanLoaiVK_Loai.SelectedValue = null;
            ucSearchLookupEditor_AntibioticPanel.SelectedValue = null;
            dtgDanhSachViKhuan.DataSource = null;
            txtKetQuaViKhuan.Text = string.Empty;
            txtTheDinhDanh.Text = string.Empty;
            dtgCardDinhDanh.DataSource = null;
            txtKetQuaKhangKhangSinh.Text = string.Empty;
            dtgKhangKhangSinh.DataSource = null;
            dtgKetQuaKhaoSat.DataSource = null;
            gcKhangDinhDo.DataSource = null;
        }

        public void Load_ChiTietXN(string maTiepNhan)
        {
            dtgDanhSachChiDinh.CellEnter -= dtgDanhSachChiDinh_CellEnter;
            ControlExtension.BindDataToGrid(_microbiologyTesresult.Data_ketqua_cls_xetnghiem_visinh(CurrentMaTiepNhan, string.Empty
                , false, true, string.Join(",", lstDanhSachNhom)), ref dtgDanhSachChiDinh, ref bvDanhSachChiDinh);
            BindThongTinKetQuaYeuCau();
            var daXacNhan = false;
            if (dtgDanhSachChiDinh.RowCount > 0)
            {
                for (var i = 0; i < dtgDanhSachChiDinh.RowCount; i++)
                {
                    daXacNhan = (bool)dtgDanhSachChiDinh.Rows[i].Cells[colChiDinh_DaXacNhanKQ.Name].Value;
                    dtgDanhSachChiDinh[colXacNhanKQ.Name, i].Value = (daXacNhan ? imageList1.Images[0] : imageList1.Images[1]);
                }
                dtgDanhSachChiDinh.CurrentCell = dtgDanhSachChiDinh[colXacNhanKQ.Name, 0];
            }
            if (dtgDanhSachChiDinh.Rows.Count > 0)
            {
                dtgDanhSachChiDinh.Rows[0].Selected = true;
                dtgDanhSachChiDinh_CellEnter(dtgDanhSachChiDinh, new DataGridViewCellEventArgs(0, 0));
            }
            dtgDanhSachChiDinh.CellEnter += dtgDanhSachChiDinh_CellEnter;
            if (dtgDanhSachChiDinh.CurrentRow != null)
            {
                bool XacNhan = bool.Parse(dtgDanhSachChiDinh.CurrentRow.Cells[colChiDinh_DaXacNhanKQ.Name].Value.ToString());
                if (_allowValid)
                    btnXacNhanKetQua.Enabled = !XacNhan;
                if (_allowInValid)
                    btnBoXacNhanKetQua.Enabled = XacNhan;
                if (_allowEdit)
                    Lock_ValidControl(XacNhan);
            }
            Load_KetQuaViKhuan();
        }

        private void ucKetQuaViSinh_Load(object sender, EventArgs e)
        {

        }
        private ReportModel GetReportFromConfig(string reportemplateId, DM_XETNGHIEM_MAUPHIEUIN_TUYCHON objMauChonIn)
        {
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

        private bool Check_SuDungCkSo(string userSign, ref string idChuKy)
        {

            idChuKy = string.Empty;
            if (chkInThongThuong_VSNC.Checked)
                return false;
            if (string.IsNullOrEmpty(userSign)) return false;

            if (_dataUserSign.Rows.Count <= 0) return false;

            var dataSel = WorkingServices.SearchResult_OnDatatable(_dataUserSign, string.Format("MaNguoiDung = '{0}'", userSign));
            if (dataSel.Rows.Count <= 0) return false;
            idChuKy = dataSel.Rows[0]["IDChuKySo"].ToString().Trim();
            var useCKS = bool.Parse(dataSel.Rows[0]["DungCKSo"].ToString());
            var signPicture = StringConverter.ToString(dataSel.Rows[0]["SignPicture"]);
            if (useCKS)
            {
                _loaiKy = 2;
            }
            else if (!string.IsNullOrEmpty(signPicture))
            {
                _loaiKy = 1;
            }
            else
            {
                _loaiKy = 0;
            }

            return useCKS;
        }
        private void btnXemTruoc_Click(object sender, EventArgs e)
        {
            InketQua(false);
            Button_GoiLenh_Click?.Invoke(sender, e);
        }
        private void btnInKetQua_Click(object sender, EventArgs e)
        {
            InketQua(true);
            Button_GoiLenh_Click?.Invoke(sender, e);
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnLamMoiDanhSachKSD_Click(object sender, EventArgs e)
        {
            UpdateKSDTheoPanel();
        }

        private void radKyThuat_CheckedChanged(object sender, EventArgs e)
        {
            var radiobutton = (RadioButton)sender;
            if(radiobutton.Checked)
            {
                Load_KetQuaKhangSinh();
                radiobutton.BackColor = Color.Yellow;
            }
            else
                radiobutton.BackColor = Color.Transparent;
        }
        private void UpdateKSDTheoPanel()
        {
            if (dtgDanhSachViKhuan.CurrentRow != null)
            {
                var vkDangChon = dtgDanhSachViKhuan.CurrentRow.Cells[vkMaPhanLoaiViKhuan.Name].Value.ToString();
                if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Cập nhật lại panel kháng sinh theo vi khuẩn: {0} ?", vkDangChon)))
                {
                    InsertVK_KSD(vkDangChon, true);
                }
            }
        }
        private void DanhGiaKetQuaSauKhiNhapLaiPanel(string maViKhuan, string maChiDinh)
        {
            var data = _microbiologyTesresult.Get_DanhSach_KhangSinh(CurrentMaTiepNhan, maChiDinh, maViKhuan, string.Empty, 1, string.Empty);
            //Chỉ đánh giá các kết quả có đường kính
            var dataCoDuongKinh = WorkingServices.SearchResult_OnDatatable(data, string.Format("KetQuaDinhLuong is not null and KetQuaDinhLuong <> ''"));
            if(dataCoDuongKinh.Rows.Count > 0)
            {
                foreach (DataRow drKetQua in dataCoDuongKinh.Rows)
                {
                    var ketQua = StringConverter.ToString(drKetQua[colKSD_KetQua.FieldName]);
                    var machiDinh = drKetQua[colKSD_YeuCauViSinh.FieldName].ToString();
                    var maTKhangSinh = drKetQua[colKSD_MaKhangSinh.FieldName].ToString();
                    var maTiepNhan = drKetQua[colKSD_MaTiepNhan.FieldName].ToString();
                    var kyThuat = drKetQua[colKSD_KyThuat.FieldName].ToString();
                    var lanXn = int.Parse(drKetQua[ colKSD_LanXetNghiem.FieldName].ToString());
                    var SiteINF = drKetQua[colKSD_SiteInfection.FieldName].ToString();

                    double canNhay = 0;
                    double canKhang = 0;
                    double cantrungGianDuoi = 0;
                    double cantrungGianTren = 0;
                    var strTempVal = string.Empty;
                    if (kyThuat.Equals(BioTestMethod.Disk.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        strTempVal = drKetQua[colKSD_CanNhay.FieldName].ToString();
                        canNhay = double.Parse(string.IsNullOrEmpty(strTempVal) ? "10000000000000000" : strTempVal);

                        strTempVal = drKetQua[colKSD_CanKhang.FieldName].ToString();
                        canKhang = double.Parse(string.IsNullOrEmpty(strTempVal) ? "-10000000000000000" : strTempVal);

                        strTempVal = drKetQua[colKSD_CanTrungGianDuoi.FieldName].ToString();
                        cantrungGianDuoi = double.Parse(string.IsNullOrEmpty(strTempVal) ? "10000000000000000" : strTempVal);

                        strTempVal = drKetQua[colKSD_CanTrungGianTren.FieldName].ToString();
                        cantrungGianTren = double.Parse(string.IsNullOrEmpty(strTempVal) ? "-10000000000000000" : strTempVal);
                    }
                    else
                    {
                        strTempVal = drKetQua[colKSD_CanNhay.FieldName].ToString();
                        canNhay = double.Parse(string.IsNullOrEmpty(strTempVal) ? "-10000000000000000" : strTempVal);

                        strTempVal = drKetQua[colKSD_CanKhang.FieldName].ToString();
                        canKhang = double.Parse(string.IsNullOrEmpty(strTempVal) ? "10000000000000000" : strTempVal);

                        strTempVal = drKetQua[colKSD_CanTrungGianDuoi.FieldName].ToString();
                        cantrungGianDuoi = double.Parse(string.IsNullOrEmpty(strTempVal) ? "-10000000000000000" : strTempVal);

                        strTempVal = drKetQua[colKSD_CanTrungGianTren.FieldName].ToString();
                        cantrungGianTren = double.Parse(string.IsNullOrEmpty(strTempVal) ? "10000000000000000" : strTempVal);
                    }

                    var SRI = DanhGiaKetQuaKSD(ketQua, canNhay, canKhang, cantrungGianDuoi, cantrungGianTren, kyThuat).Trim();
                    var coKetQua = (int)AntiBioticColor.Unidentified;
                    if (!string.IsNullOrEmpty(SRI))
                        coKetQua = (int)AnitBioticResultIndex.GetResultColorFlat(SRI);

                    _microbiologyTesresult.Update_KetQuaKhangSinh(maTiepNhan, machiDinh, maViKhuan, maTKhangSinh, kyThuat
                        , SRI, ketQua, coKetQua, CommonAppVarsAndFunctions.UserID, lanXn, "", 0, "", SiteINF);
                }
            }
        }

        private void btnChonMayNuoiCay_Click(object sender, EventArgs e)
        {
            if (btnSaveAll.Enabled)
            {
                ucSearchLookupEditor_MayXN2.SelectedValue = null;
                pnChonMayCapNhat.Visible = true;
                pnChonMayCapNhat.Tag = 1;
            }
            else
                CustomMessageBox.MSG_Information_OK("Không thể cập nhật cho kết quả đã duyệt.");
        }
    }
}
