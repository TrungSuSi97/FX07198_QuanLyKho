using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.Excel;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Patient.Services;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;
using TPH.Report.Constants;
using TPH.Report.Models;
using TPH.Report.Services;
using TPH.Report.Services.Impl;

namespace TPH.LIS.App.DailyUse.CanLamSang
{
    public partial class FrmCLSViSinh_PhieuTienTrinh : FrmTemplate
    {
        public FrmCLSViSinh_PhieuTienTrinh()
        {
            InitializeComponent();
        }
        private Image reportLogo;
        private readonly ISystemConfigService _isSysConfig = new SystemConfigService();
        private readonly IBacteriumAntibioticService _bacteriumAntibistic = new BacteriumAntibioticService();
        private readonly IMicrobilogyTestResultService _microbiologyTesresult = new MicrobilogyTestResultService();
        private readonly IReportService _reportInfo = new ReportServiceImpl();
        private ReportModel lstResultReportInfo = new ReportModel();
        bool _allowEdit = false;
        bool _allowValid = false;
        bool _allowInValid = false;
        bool _allowPrint = false;
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

            btnXemTruoc.Enabled = btnInKetQua.Enabled = _allowPrint;
            //btnInKetQua.Enabled = _allowValid;
            //btnBoXacNhanKetQua.Enabled = _allowInValid;
        }
        private void FrmCLSViSinh_PhieuTienTrinh_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(delegate { ControlExtension.LoadPrinterNameNormal(listPrinter, UserConstant.RegistryPrinterResult, true); });
            ucSearchLookupEditor_KyTen1.Load_NguoiDungCungPhanQuyen();
            ucSearchLookupEditor_LoaiMau1.Load_DanhMucLoaiMau(ServiceType.ClsXNViSinh.ToString());
            dtpTGThucHien.Value = CommonAppVarsAndFunctions.ServerTime;
            ucPatientInformation1.dtpDateIn.Value = CommonAppVarsAndFunctions.ServerTime;
            ucPatientInformation1.Load_DanhMucCauHinh();
            reportLogo = _isSysConfig.Load_Logo("XN");

            ucDanhSachBenhNhanXN1.ShowTuyChon = false;
            ucDanhSachBenhNhanXN1.DungInDanhSach = false;
            ucDanhSachBenhNhanXN1.ShowCheckChon = false;
            ucDanhSachBenhNhanXN1.DungUploadHIS = false;
            ucDanhSachBenhNhanXN1.DSViSinh = true;
            ucDanhSachBenhNhanXN1.ArrLoaiXetNghiem = new TestType.EnumTestType[] { TestType.EnumTestType.ViSinhNuoiCay, TestType.EnumTestType.ViSinhSoiNhuom };
            ucDanhSachBenhNhanXN1.Load_CauHinh();
            ucDanhSachBenhNhanXN1.Load_DSBenhNhan();
            ucDanhSachBenhNhanXN1.DataGridview_DsBenhNhan_CellEnter += UcDanhSachBenhNhanXN1_DataGridview_DsBenhNhan_CellEnter;
            Load_ChiTietBenhNhan(ucDanhSachBenhNhanXN1.MaTiepNhanDangChon);
            Load_YeuCauViSinh_List();
        }
        private void Load_DanhSachBenhNhan()
        {
            ucDanhSachBenhNhanXN1.Load_DSBenhNhan();

            if (!string.IsNullOrEmpty(ucDanhSachBenhNhanXN1.MaTiepNhanDangChon))
            {
                Load_ChiTietBenhNhan(ucDanhSachBenhNhanXN1.MaTiepNhanDangChon);
            }
            Load_YeuCauViSinh_List();
        }
        private void Load_ChiTietBenhNhan(string maTiepNhan)
        {
            ucPatientInformation1.LoadInformation(ucDanhSachBenhNhanXN1.MaTiepNhanDangChon);
        }
        private void UcDanhSachBenhNhanXN1_DataGridview_DsBenhNhan_CellEnter(object sender, EventArgs e)
        {
            Load_ChiTietBenhNhan(ucDanhSachBenhNhanXN1.MaTiepNhanDangChon);
            Load_YeuCauViSinh_List();
        }
        private void Load_YeuCauViSinh_List()
        {
            dtgDanhSachChiDinh.DataSource = null;
            gcPhieuTienTrinh.DataSource = null;
            string matiepNhan = "-1";
            if (!string.IsNullOrEmpty(ucDanhSachBenhNhanXN1.MaTiepNhanDangChon))
            {
                dtgDanhSachChiDinh.CellEnter -= dtgDanhSachChiDinh_CellEnter;
                matiepNhan = ucDanhSachBenhNhanXN1.MaTiepNhanDangChon;

                ControlExtension.BindDataToGrid(_microbiologyTesresult.Data_ketqua_cls_xetnghiem_visinh_phieutientrinh(matiepNhan, string.Empty
                    , false, true), ref dtgDanhSachChiDinh, ref bvDanhSachChiDinh);
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
                dtgDanhSachChiDinh.CellEnter += dtgDanhSachChiDinh_CellEnter;
                if (dtgDanhSachChiDinh.Rows.Count > 0)
                {
                    dtgDanhSachChiDinh_CellEnter(dtgDanhSachChiDinh, new DataGridViewCellEventArgs(0, 0));
                }
            }
            
        }
    
        private void dtgDanhSachChiDinh_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgDanhSachChiDinh.CurrentRow == null) return;
            var XacNhan = NumberConverter.ToBool(dtgDanhSachChiDinh.CurrentRow.Cells[colChiDinh_DaXacNhanKQ.Name].Value);
          //  txtTenLoaiMauHIS.Text = TPH.Common.Converter.StringConverter.ToString(dtgDanhSachChiDinh.CurrentRow.Cells[colYeuCau_TenLoaiMauHis.Name].Value);
            txtMaSoMau.Text = TPH.Common.Converter.StringConverter.ToString(dtgDanhSachChiDinh.CurrentRow.Cells[ycCodeLoaiMau.Name].Value);
            ucSearchLookupEditor_LoaiMau1.SelectedValue = TPH.Common.Converter.StringConverter.ToString(dtgDanhSachChiDinh.CurrentRow.Cells[ycLoaiMauNhan.Name].Value);
            if (_allowEdit)
            {
                Lock_ValidControl(XacNhan);
            }
            else
                Lock_ValidControl(true);

            Load_PhieuTienTrinh();
        }
        private void Lock_ValidControl(bool isLock)
        {
            btnXoaTienTrinh.Enabled = !isLock;
            btnThemTinTrinh.Enabled = !isLock;
            btnCapNhatTienTrinh.Enabled = !isLock;
        }
        private void Load_PhieuTienTrinh()
        {
            if (string.IsNullOrEmpty(txtMaSoMau.Text))
            {
                gcPhieuTienTrinh.DataSource = null;
                Clear_NoiDung();
                return;
            }
            gcPhieuTienTrinh.DataSource = null;

            if (dtgDanhSachChiDinh.CurrentRow != null)
            {
                var maTiepNhan = ucDanhSachBenhNhanXN1.MaTiepNhanDangChon;
                var maXN = TPH.Common.Converter.StringConverter.ToString(dtgDanhSachChiDinh.CurrentRow.Cells[ycMaChiDinh.Name].Value);
                var maSoMau = TPH.Common.Converter.StringConverter.ToString(dtgDanhSachChiDinh.CurrentRow.Cells[ycCodeLoaiMau.Name].Value);
                var data = _microbiologyTesresult.Get_PhieuTienTrinh(maTiepNhan, maXN, maSoMau);
                Clear_NoiDung();
                gcPhieuTienTrinh.DataSource = data;
            }

            gvPhieuTienTrinh.ExpandAllGroups();
        }
        private void XoaPhieu()
        {
            if (gvPhieuTienTrinh.FocusedRowHandle <= 0) return;
            if (!CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa tiến trình được chọn ?")) return;
            //Lấy số dòng duoc check
            var arrChecked = gvPhieuTienTrinh.GetSelectedRows();
            List<int> Ids = new List<int>();
            foreach (var row in arrChecked)
            {
                //Nếu khong có ID thì bỏ qua
                if (gvPhieuTienTrinh.GetRowCellValue(row, colPTT_AutoID) == null) continue;
                var ID = NumberConverter.ToInt(gvPhieuTienTrinh.GetRowCellValue(row, colPTT_AutoID));
                Ids.Add(ID);
            }
            //Nếu có ID để xóa thì thuc hien xóa
            if (Ids.Count <= 0) return;
            _microbiologyTesresult.Delete_PhieuTienTrinh(string.Join(",", Ids));
            Load_PhieuTienTrinh();
        }
        private void ThemMoiTienTrinh()
        {
            if (dtgDanhSachChiDinh.RowCount <= 0) return;
            if (ucSearchLookupEditor_KyTen1.SelectedValue == null)
            {
                CustomMessageBox.MSG_Information_OK("Vui lòng chọn người thực hiện!");
                ucSearchLookupEditor_KyTen1.Focus();
            }
            else if (string.IsNullOrEmpty(txtMaSoMau.Text))
            {
                CustomMessageBox.MSG_Information_OK("Vui lòng chọn mã số mẫu!");
            }
            else
            {
                var nguoiThucHien = TPH.Common.Converter.StringConverter.ToString(ucSearchLookupEditor_KyTen1.SelectedValue);
                DateTime thoiGianThucHien = dtpTGThucHien.Value;
                var noiDung = txtNoiDungTienTrinh.Text.Trim();
                var maTiepNhan = ucPatientInformation1.MaTiepNhan;
                var maXN = TPH.Common.Converter.StringConverter.ToString(dtgDanhSachChiDinh.CurrentRow.Cells[ycMaChiDinh.Name].Value);
                var nguoiSua = CommonAppVarsAndFunctions.UserID;
                var maSoMau = txtMaSoMau.Text.Trim();
                // Lưu phiếu
                if (_microbiologyTesresult.Insert_Update_ViSinh_PhieuTienTrinh(maTiepNhan, maXN, maSoMau, nguoiThucHien, thoiGianThucHien, noiDung, nguoiSua))
                {
                    Load_PhieuTienTrinh();
                }
            }
        }
        private void SuaNoiDung()
        {
            if (gvPhieuTienTrinh.RowCount <= 0) return;
            if (ucSearchLookupEditor_KyTen1.SelectedValue == null)
            {
                CustomMessageBox.MSG_Information_OK("Vui lòng chọn người thực hiện!");
                ucSearchLookupEditor_KyTen1.Focus();
            }
            else if (string.IsNullOrEmpty(txtMaSoMau.Text))
            {
                CustomMessageBox.MSG_Information_OK("Vui lòng chọn mã số mẫu!");
            }
            else
            {
                var nguoiThucHien = TPH.Common.Converter.StringConverter.ToString(ucSearchLookupEditor_KyTen1.SelectedValue);
                DateTime thoiGianThucHien = dtpTGThucHien.Value;
                var noiDung = txtNoiDungTienTrinh.Text.Trim();
                var maTiepNhan = ucPatientInformation1.MaTiepNhan;
                var maXN = TPH.Common.Converter.StringConverter.ToString(dtgDanhSachChiDinh.CurrentRow.Cells[ycMaChiDinh.Name].Value);
                var nguoiSua = CommonAppVarsAndFunctions.UserID;
                var maSoMau = txtMaSoMau.Text.Trim();
                int ID = int.Parse(txtID.Text);
                // Sửa phiếu
                if (_microbiologyTesresult.Insert_Update_ViSinh_PhieuTienTrinh
                    (maTiepNhan, maXN, maSoMau, nguoiThucHien, thoiGianThucHien, noiDung, nguoiSua, ID))
                {
                    Load_PhieuTienTrinh();
                }
            }
        }
        private void Clear_NoiDung()
        {
            txtNoiDungTienTrinh.Text = string.Empty;
            ucSearchLookupEditor_KyTen1.SelectedValue = null;
            dtpTGThucHien.Value = C_Ultilities.ServerDate();
        }

        private void gvPhieuTienTrinh_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            ShowNoiDungTienTrinh();
        }
        private void ShowNoiDungTienTrinh()
        {
            Clear_NoiDung();
            if (gvPhieuTienTrinh.FocusedRowHandle <= 0) return;
            txtNoiDungTienTrinh.Text = TPH.Common.Converter.StringConverter.ToString(gvPhieuTienTrinh.GetFocusedRowCellValue(colPTT_NoiDung));
            ucSearchLookupEditor_KyTen1.SelectedValue = TPH.Common.Converter.StringConverter.ToString(gvPhieuTienTrinh.GetFocusedRowCellValue(colPTT_NguoiThucHien));
            dtpTGThucHien.Value = TPH.Common.Converter.DateTimeConverter.ToDateTime(gvPhieuTienTrinh.GetFocusedRowCellValue(colPTT_ThoiGianThucHien));
            txtID.Text = TPH.Common.Converter.StringConverter.ToString(gvPhieuTienTrinh.GetFocusedRowCellValue(colPTT_AutoID));
        }
        private void InketQua(bool print)
        {
            if (string.IsNullOrEmpty(ucPatientInformation1.MaTiepNhan)) return;
       
            var maYeuCau = string.Empty;
            var maViKhuan = string.Empty;
            var signName = string.Empty;
            var maSoMau = txtMaSoMau.Text.Trim();

            signName = CommonAppVarsAndFunctions.TempSignIdXetNghiemViSinh;

            var dtPrint = _microbiologyTesresult.DuLieuInPhieuTienTrinh(ucPatientInformation1.MaTiepNhan, true, maSoMau);
            if (dtPrint == null || dtPrint.Rows.Count <= 0) return;
            var printerName = string.Empty;
            if (listPrinter.SelectedIndex > -1)
                printerName = listPrinter.SelectedItem.ToString();

            // Dang ký sử dụng chữ ký số
            var idChuky = string.Empty;
            if (lstResultReportInfo.ReportSuDung == null)
                lstResultReportInfo = _reportInfo.Info_Report(ReportConstants.PhieuTienTrinhViSinh);
            //nếu sau khi load report vẫn null thì thoát
            if (lstResultReportInfo.ReportSuDung == null)
            {
                CustomMessageBox.MSG_Information_OK("Biểu mẫu in chưa được khai báo");
                return;
            }
            var rpView = new FrmPreViewReport();
            rpView.SampleID = string.Format("PhieuTienTrinh_Visinh_{0}", dtPrint.Rows[0]["MaTiepNhan"].ToString().Trim());
            rpView.TenBN = dtPrint.Rows[0]["TenBN"].ToString().Trim();
            rpView.UserSign = CommonAppVarsAndFunctions.TempSignIdXetNghiemViSinh;
            var resultReportInfo = _reportInfo.CreateReportFromStream(lstResultReportInfo.ReportSuDung);
             rpView.ShowReport(resultReportInfo, dtPrint, print, printerName, "VS", lstResultReportInfo.TenDataset, lstResultReportInfo.TenDatatable);
            Load_YeuCauViSinh_List();
        }
        private void gvPhieuTienTrinh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ShowNoiDungTienTrinh();
        }

        private void btnThemTinTrinh_Click(object sender, EventArgs e)
        {
            ThemMoiTienTrinh();
        }

        private void btnXoaTienTrinh_Click(object sender, EventArgs e)
        {
            XoaPhieu();
        }

        private void btnCapNhatTienTrinh_Click(object sender, EventArgs e)
        {
            SuaNoiDung();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (gvPhieuTienTrinh.RowCount <= 0) return;
            ExportToExcel.Export(gcPhieuTienTrinh, string.Format("PhieuTientrinh_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")));
        }

        private void btnXemTruoc_Click(object sender, EventArgs e)
        {
            InketQua(false);
        }

        private void btnInKetQua_Click(object sender, EventArgs e)
        {
            InketQua(true);
        }
    }
}
