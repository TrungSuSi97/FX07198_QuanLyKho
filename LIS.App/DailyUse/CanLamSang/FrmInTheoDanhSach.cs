using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using TPH.Common.Extensions;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Patient.Services;
using TPH.LIS.TestResult.Constants;
using TPH.LIS.TestResult.Services;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Services.UserManagement;

namespace TPH.LIS.App.DailyUse.CanLamSang
{
    public partial class FrmInTheoDanhSach : FrmTemplate
    {
        public FrmInTheoDanhSach()
        {
            InitializeComponent();
        }
        private readonly ITestResultService _iResultService = new TestResultService();
        private readonly IPatientInformationService _iPatient = new PatientInformationService();
        private readonly ISystemConfigService _sysConfig = new SystemConfigService();
        IUserManagementService userManagement = new UserManagementService();
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
        private DieuKienInTuDong _dieuKienIn = new DieuKienInTuDong();
        private PrintResultHelper _inKetQua = new PrintResultHelper();
        private readonly TestType.EnumTestType[] _arrLoaiXetNghiem = new TestType.EnumTestType[] { TestType.EnumTestType.ThongThuong
            , TestType.EnumTestType.HuyetDo
            , TestType.EnumTestType.HIV };
        List<CAUHINH_MAYINKETQUA> _listCauHinhMayIn;
        private Image reportLogo;
        DataTable dataDanhSachPhieuInBYT = new DataTable();
        DataTable dataDanhSachTim = new DataTable();
        DataTable dataPrint = null;
        private int _lastIndexPrinter = -1;
        private string _listKhoaChiDinh = string.Empty;
        private string _listKhoaHienThoi = string.Empty;
        private string _listKhuDieuTri = string.Empty;
        private string _listDoiTuong = string.Empty;
        private void LayKhoaChiDinh()
        {
            _listKhoaChiDinh = string.Empty;
            if (gvKhoaChiDinh.SelectedRowsCount <= 0) return;
            foreach (var i in gvKhoaChiDinh.GetSelectedRows())
            {
                if (gvKhoaChiDinh.GetRowCellValue(i, colMaKhoaChiDinh) == null) continue;
                _listKhoaChiDinh += string.IsNullOrEmpty(_listKhoaChiDinh) ? "" : ",";
                _listKhoaChiDinh += gvKhoaChiDinh.GetRowCellValue(i, colMaKhoaChiDinh).ToString();
            }
        }
        private void LayKhoaHienThoi()
        {
            _listKhoaHienThoi = string.Empty;
            if (gvKhoaHienThoi.SelectedRowsCount <= 0) return;
            foreach (var i in gvKhoaHienThoi.GetSelectedRows())
            {
                if (gvKhoaHienThoi.GetRowCellValue(i, colMaKhoaHienThoi) == null) continue;
                _listKhoaHienThoi += string.IsNullOrEmpty(_listKhoaHienThoi) ? "" : ",";
                _listKhoaHienThoi += gvKhoaHienThoi.GetRowCellValue(i, colMaKhoaHienThoi).ToString();
            }
        }
        private void LayDoiTuong()
        {
            _listDoiTuong = string.Empty;
            if (gvDoiTuong.SelectedRowsCount <= 0) return;
            foreach (var i in gvDoiTuong.GetSelectedRows())
            {
                if (gvDoiTuong.GetRowCellValue(i, colDoiTuong_MaDoiTuong) == null) continue;
                _listDoiTuong += string.IsNullOrEmpty(_listDoiTuong) ? "" : ",";
                _listDoiTuong += gvDoiTuong.GetRowCellValue(i, colDoiTuong_MaDoiTuong).ToString();
            }
        }
        private void LoadCauHinh()
        {
            dtpTuNgay.Value = WorkingServices.StartOfDay(CommonAppVarsAndFunctions.ServerTime);
            dtpDenNgay.Value = WorkingServices.EndOfDay(CommonAppVarsAndFunctions.ServerTime);
            var dataKyten = userManagement.GetUsersKyTenCoPhanQuyen("", Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.BoPhanClsXetNghiem, true), true);
            DataRow dr = dataKyten.NewRow();
            dr["MaNguoiDung"] = string.Empty;
            dr["TenNhanVien"] = "---None---";
            ControlExtension.BindDataToCobobox(dataKyten, ref cboNguoiKyTen, "MaNguoiDung", "MaNguoiDung", "MaNguoiDung, TenNhanVien", "50,150", txtNguoiKyTen, 1);
            cboNguoiKyTen.SelectedValue = CommonAppVarsAndFunctions.UserID;
            var dataBoPhan = _sysConfig.Data_dm_bophan(string.Empty, string.Empty);
            gcKhuVuc.DataSource = dataBoPhan;
            var dataDoiTuong = _sysConfig.Get_DoiTuongDichVu(string.Empty);
            gcDoiTuong.DataSource = dataDoiTuong;

            ControlExtension.LoadPrinterNameNormal(listPrinter, UserConstant.RegistryPrinterResult, true);
            chkChiaTaiMayIn.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryPrinterShareJob) == "1";
            chkChiaTaiMayIn.CheckedChanged += ChkChiaTaiMayIn_CheckedChanged;
            listPrinter.SelectedIndexChanged += listPrinter_SelectedIndexChanged;
            chkTuInKhiChuyen.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryAutoPrintInPrintOfList) == "1";
            chkTuInKhiChuyen.CheckedChanged += ChkTuInKhiChuyen_CheckedChanged;
            reportLogo = _sysConfig.Load_Logo("XN");
            _listCauHinhMayIn = _sysConfig.ListCauHinhMayIn(Environment.MachineName);
            dataDanhSachPhieuInBYT = _sysConfig.DSMauPhieuIn_ThaoTac();
            var row = dataDanhSachPhieuInBYT.NewRow();
            row["IDMauKetQua"] = ReportResultTemplateConstant.Mau_TC_ThongThuong;
            dataDanhSachPhieuInBYT.Rows.Add(row);
        }

        private void ChkTuInKhiChuyen_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(UserConstant.RegistryAutoPrintInPrintOfList, (chkTuInKhiChuyen.Checked ? "1" : "0"));
        }

        private void btnXoaMayIn_Click(object sender, EventArgs e)
        {
            if (listPrinter.Items.Count <= 0) return;
            if (listPrinter.SelectedIndex > -1)
            {
                listPrinter.Items.RemoveAt(listPrinter.SelectedIndex);
            }
        }
        private void btnDSMayin_Click(object sender, EventArgs e)
        {
            ControlExtension.LoadPrinterNameNormal(listPrinter, UserConstant.RegistryPrinterResult, true);
        }

        private void listPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPrinter.Items.Count <= 0) return;
            if (listPrinter.SelectedItem != null)
            {
                _registryExtension.WriteRegistry(
                     UserConstant.RegistryPrinterResult,
                    listPrinter.SelectedItem.ToString());
            }
        }

        private void gvKhuVuc_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            Load_KhoaPhong();
        }

        private void LayDieuKienIn()
        {
            _dieuKienIn =
                new DieuKienInTuDong
                {
                    XacNhanBenhNhan = false
                    ,
                    XacNhanTheoKhoa = false
                    ,
                    ChiInCoKetQua = true
                    ,
                    ListKhoaChiDinh = _listKhoaChiDinh
                    ,
                    ListKhoaHienthoi = _listKhoaHienThoi
                    ,
                    ListAllowBoPhan = string.Join(",", CommonAppVarsAndFunctions.BoPhanClsXetNghiem.ToList())
                    ,
                    ListAllowDoiTuong = _listDoiTuong
                    ,
                    PCName = Environment.MachineName
                    ,
                    TuNgay = dtpTuNgay.Value
                    ,
                    DenNgay = dtpDenNgay.Value
                    ,
                    SoPhutDaKiemTra = 3
                    ,
                    DungChoCapNhat = false
                    ,
                    UserValid = string.Empty
                    ,
                    XacNhanTheoNhom = false
                    ,
                    ListAllowNhom = string.Join(",", CommonAppVarsAndFunctions.NhomClsXetNghiem.ToList())
                    ,
                    DaIn = (radChuaIn.Checked ? 0 : (radDaIn.Checked ? 1 : 2))
                    ,
                    IdNgay = (radNgayDuyetKetQua.Checked ? 2 : (radNgayNhanMau.Checked ? 1 : 0))
                };
        }
        private void ChkChiaTaiMayIn_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(UserConstant.RegistryPrinterShareJob, (chkChiaTaiMayIn.Checked ? "1" : "0"));
        }

        private void Load_KhoaPhong()
        {
            if (gvKhuVuc.SelectedRowsCount > 0)
            {
                var maBophan = new List<string>();
                foreach (var item in gvKhuVuc.GetSelectedRows())
                {
                    if (gvKhuVuc.GetRowCellValue(item, colKhuVuc_maBoPhan) != null)
                    {
                        maBophan.Add(gvKhuVuc.GetRowCellValue(item, colKhuVuc_maBoPhan).ToString());
                    }
                }
                var data = _sysConfig.GetLocation(string.Empty, string.Empty, Utilities.ConvertStrinArryToInClauseSQL(maBophan, true));
                gcKhoaChiDinh.DataSource = data;
                gvKhoaChiDinh.ExpandAllGroups();
                gcKhoaHienThoi.DataSource = data.Copy();
                gvKhoaHienThoi.ExpandAllGroups();
            }
            else
            {
                gcKhoaChiDinh.DataSource = null;
                gcKhoaHienThoi.DataSource = null;
            }
        }

        private void CopyRow()
        {
            if (gvDSTimKiem.SelectedRowsCount > 0)
            {
                gcDSIn.DataSource = null;
                if (dataPrint == null)
                {
                    dataPrint = new DataTable();
                    dataPrint = dataDanhSachTim.Clone();

                }
                foreach (var index in gvDSTimKiem.GetSelectedRows())
                {
                    if (gvDSTimKiem.GetRowCellValue(index, colDSTimKiem_MaTiepNhan) != null)
                    {
                        var matiepNhan = gvDSTimKiem.GetRowCellValue(index, colDSTimKiem_MaTiepNhan).ToString();
                        var soHoSo = gvDSTimKiem.GetRowCellValue(index, colDSTiemKiem_SoHoSo).ToString();
                        var soPhieu = gvDSTimKiem.GetRowCellValue(index, colDSTiemKiem_SoPhieu).ToString();
                        //tìm nếu chưa có thì mới add
                        var findExists = WorkingServices.SearchResult_OnDatatable(dataPrint, string.Format("MaTiepNhan = '{0}' and SoPhieu = '{1}' and Bn_ID = '{2}'", matiepNhan, soPhieu, soHoSo));
                        if (findExists.Rows.Count == 0)
                        {
                            var findData = WorkingServices.SearchResult_OnDatatable(dataDanhSachTim, string.Format("MaTiepNhan = '{0}' and SoPhieu = '{1}' and Bn_ID = '{2}'", matiepNhan, soPhieu, soHoSo));
                            if (findData.Rows.Count > 0)
                            {
                                foreach (DataRow dr in findData.Rows)
                                {
                                    dataPrint.Rows.Add(dr.ItemArray);
                                }
                            }
                        }
                        if (chkTuInKhiChuyen.Checked)
                            Check_PrintResult(matiepNhan, soPhieu, true, true, true, dataDanhSachPhieuInBYT.Copy());
                    }
                }
                dataPrint.AcceptChanges();
                gcDSIn.DataSource = dataPrint;
                gvDSIn.ExpandAllGroups();
            }
        }
        private void RemoveRow()
        {
            if (gvDSIn.SelectedRowsCount > 0)
            {
                gvDSIn.DeleteSelectedRows();
            }
        }
        private void  LoadDS_BenhNhan()
        {
            if (gvKhuVuc.SelectedRowsCount > 0 && gvKhoaChiDinh.SelectedRowsCount == 0 && gvKhoaHienThoi.SelectedRowsCount == 0)
            {
                CustomMessageBox.ShowAlert("Hãy chọn khoa phòng!");
            }
            else
            {
                LayDieuKienIn();
                dataDanhSachTim = _iResultService.DanhSachBenhNhanInHangLoat(_dieuKienIn);
                gcDSTimKiem.DataSource = dataDanhSachTim;
                gvDSTimKiem.ExpandAllGroups();
            }
        }
        int _printCount = 0;
        private void Check_PrintResult(string matiepnhan, string soPhieuChiDinh, bool print, bool title, bool isAutpPrint, DataTable dataReportType)
        {
            if (_printCount >= 10)
            {
                WorkingServices.CleanTemp();
                _printCount = 0;
            }
            var userSign = cboNguoiKyTen.SelectedIndex > -1 ? cboNguoiKyTen.SelectedValue.ToString().Trim() : string.Empty;
            if (userSign.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase)
                && !CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemChoChuKyGiongUserDangNhap)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn người ký tên khác user đăng nhập!");
                return;
            }
            var reporttype = string.Empty;
            bool showMess = false;
            // var havePrint = false;
            if (!isAutpPrint)
                showMess = false;
            var category = string.Empty;
            var boPhan = string.Empty;

            category = Utilities.ConvertStrinArryToInClauseSQLForSplitString(CommonAppVarsAndFunctions.NhomClsXetNghiem.ToList());
            boPhan = Utilities.ConvertStrinArryToInClauseSQLForSplitString(CommonAppVarsAndFunctions.BoPhanClsXetNghiem.ToList());
            var printerName = string.Empty; if (listPrinter.Items.Count > 0 && string.IsNullOrEmpty(printerName))
            {
                if (listPrinter.SelectedIndex == -1)
                {
                    listPrinter.SelectedIndex = 0;
                }

                printerName = listPrinter.SelectedItem.ToString();

                if (chkChiaTaiMayIn.Checked)
                {
                    if (listPrinter.SelectedIndex < listPrinter.Items.Count - 1)
                    {
                        _lastIndexPrinter = listPrinter.SelectedIndex + 1;
                        listPrinter.SelectedIndex = _lastIndexPrinter;
                    }
                    else
                    {
                        _lastIndexPrinter = 0;
                        listPrinter.SelectedIndex = _lastIndexPrinter;
                    }
                }
            }
            int _countToFocus = 0;
            bool coDuyet = false;
            var havePrint = false;
            //Xử lý sau
            //_inKetQua.Check_PrintResult(ref _printCount, ref _countToFocus, matiepnhan, print, title, false
            //    , dataReportType, userSign, reporttype, showMess, false
            //    , string.Empty, category, boPhan, printerName, false
            //    , (DateTime?)null
            //    , false, true, _arrLoaiXetNghiem
            //    , _listCauHinhMayIn
            //    , toolStripProgressBar1
            //    , reportLogo
            //    , false
            //    , soPhieuChiDinh, ref coDuyet, string.Empty, string.Empty);
            //Đưa vào danh sách upload khi chỉ cấu hình Upload khi duyệt
            if (havePrint)
            {
                if ((CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemUploadDaIn && !CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemUploadDaDuyet)
                    || (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemUploadDaDuyet && CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemUploadDaIn && coDuyet)
                    )
                    _iPatient.DuaVaoDanhSachUploadHIS(matiepnhan);
            }
        }

        private void FrmInTheoDanhSach_Load(object sender, EventArgs e)
        {
            LoadCauHinh();
        }

        private void btnXemDanhSach_Click(object sender, EventArgs e)
        {
            LoadDS_BenhNhan();
        }

        private void btnDuaVaoDanhSachCho_Click(object sender, EventArgs e)
        {
            CopyRow();
        }

        private void btnXoaKhoiDSCho_Click(object sender, EventArgs e)
        {
            RemoveRow();
        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            if(gvDSIn.SelectedRowsCount >0)
            {
                if(CustomMessageBox.MSG_Question_YesNoCancel_GetYes("In kết quả trong danh sách?"))
                {
                    foreach (var index in gvDSIn.GetSelectedRows())
                    {
                        if (gvDSIn.GetRowCellValue(index, colDSIn_MaTiepNhan) != null)
                        {
                            var maTiepNhan = gvDSIn.GetRowCellValue(index, colDSIn_MaTiepNhan).ToString();
                            var soPhieu = gvDSIn.GetRowCellValue(index, colDSIn_SoPhieu).ToString();
                            Check_PrintResult(maTiepNhan, soPhieu, true, true, true, dataDanhSachPhieuInBYT.Copy());
                            gvDSIn.UnselectRow(index);
                        }
                    }
                }
            }
        }
    }
}
