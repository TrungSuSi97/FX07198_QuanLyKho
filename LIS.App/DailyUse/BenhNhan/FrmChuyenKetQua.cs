using DevExpress.XtraReports.UI;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Patient.Services;
using TPH.LIS.User.Constants;
using TPH.Report.Constants;
using TPH.Report.Models;
using TPH.Report.Services;
using TPH.Report.Services.Impl;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmChuyenKetQua : FrmTemplate
    {
        public FrmChuyenKetQua()
        {
            InitializeComponent();
        }
        private readonly IPatientInformationService iPatient = new PatientInformationService();
        private readonly ISystemConfigService _iSysConfig = new SystemConfigService();
        private Image logo;
        private static XtraReport ticketReport;
        private static ReportModel resultReportInfo;
        private readonly IReportService _reportInfo = new ReportServiceImpl();
        private void FrmChuyenKetQua_Load(object sender, EventArgs e)
        {
            LabServices_Helper.LoadPrinterName(listPrinter, UserConstant.RegistryListPrinterSendSample, false);
        }
        private void TaoIDLanChuyenMoi()
        {
            if (string.IsNullOrEmpty(lblIDChuyen.Text))
            {
                var id = iPatient.Insert_PhieuChuyenKQ(CommonAppVarsAndFunctions.UserID, Environment.MachineName);
                if (id > 0)
                {
                    dtpNgayTao.Value = CommonAppVarsAndFunctions.ServerTime;
                    Load_DanhSachChuyen();
                    for (int i = 0; i < gvDanhSach_Chuyen.RowCount; i++)
                    {
                        if (gvDanhSach_Chuyen.GetRowCellValue(i, colThongTin_IdChuyen) != null)
                        {
                            if (long.Parse(gvDanhSach_Chuyen.GetRowCellValue(i, colThongTin_IdChuyen).ToString()) == id)
                            {
                                gvDanhSach_Chuyen.FocusedRowHandle = i;
                                break;
                            }
                        }
                    }
                    btnHuyLanChuyen.Enabled = true;
                    btnTaoIDChuyen.Enabled = false;
                    lblIDChuyen.Text = id.ToString();
                    txtBarcode.Focus();
                }
                else
                    CustomMessageBox.MSG_Information_OK("Có lỗi trong quá trình tạo lần chuyển mới.\nHãy thử lại.");
            }
            else
                CustomMessageBox.MSG_Information_OK("Đang trong chế độ nhập chi tiết.");
        }
        private void ThemChiTiet_ChuyenKQ()
        {
            if(!string.IsNullOrEmpty(txtBarcode.Text))
            {
                var row = gvChiTiet.LocateByValue(colChiTiet_Barcode.FieldName, txtBarcode.Text);
                if (row != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    CustomMessageBox.MSG_Information_OK("Barcode cho lần chuyển đã được nhập.");
                }
                else
                {
                    var maTiepNhan = iPatient.Get_MaTiepNhanByBarcode(txtBarcode.Text);

                    if (!string.IsNullOrEmpty(maTiepNhan))
                    {
                        iPatient.Insert_PhieuChuyenMau_ChiTiet(new Patient.Model.CHUYENPHIEUKETQUA_CHITIET
                        {
                            Barcode = txtBarcode.Text,
                            Idchuyen = int.Parse(lblIDChuyen.Text),
                            Nguoichuyen = CommonAppVarsAndFunctions.UserID,
                            Pcthuchien = Environment.MachineName,
                            Matiepnhan = maTiepNhan
                        });
                        Load_ChiTietChuyen();
                        txtBarcode.Text = string.Empty;
                    }
                }
                txtBarcode.Focus();
            }
        }
        private void Load_ChiTietChuyen()
        {
            gcChiTiet.DataSource = null;
            if (gvDanhSach_Chuyen.FocusedRowHandle > -1)
            {
                if (gvDanhSach_Chuyen.GetRowCellValue(gvDanhSach_Chuyen.FocusedRowHandle, colThongTin_IdChuyen) != null)
                {
                    var data = iPatient.DanhSach_ChuyenChuyenKQ_TheoID(int.Parse(gvDanhSach_Chuyen.GetRowCellValue(gvDanhSach_Chuyen.FocusedRowHandle, colThongTin_IdChuyen).ToString()));
                    gcChiTiet.DataSource = data;
                    gvChiTiet.ExpandAllGroups();
                }
            }
        }
        private void Load_DanhSachChuyen()
        {
            gvDanhSach_Chuyen.FocusedRowChanged -= GvDanhSach_Chuyen_FocusedRowChanged;
            var data = iPatient.DanhSach_PhieuChuyenKetQua(dtpNgayTao.Value.Date, txtTimBarcode.Text) ;
            gcDanhSach_Chuyen.DataSource = data;
            gvDanhSach_Chuyen.ExpandAllGroups();
            Load_ChiTietChuyen();
            gvDanhSach_Chuyen.FocusedRowChanged += GvDanhSach_Chuyen_FocusedRowChanged;
        }

        private void GvDanhSach_Chuyen_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Load_ChiTietChuyen();
        }

        private void btnTaoIDChuyen_Click(object sender, EventArgs e)
        {
            TaoIDLanChuyenMoi();
        }

        private void cmdRefreshPrinter_Click(object sender, EventArgs e)
        {
            LabServices_Helper.LoadPrinterName(listPrinter, UserConstant.RegistryListPrinterSendSample, false);
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            ThemChiTiet_ChuyenKQ();
        }

        private void btnLoadDanhSachChuyen_Click(object sender, EventArgs e)
        {
            Load_DanhSachChuyen();
        }

        private void txtTimBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                Load_DanhSachChuyen();
            }
        }

        private void btnXoaChiTiet_Click(object sender, EventArgs e)
        {
           if(gvChiTiet.SelectedRowsCount >0)
            {
                if(CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa thông tin chuyển của của barcode đang chọn?"))
                {
                    foreach (var rowIndex in gvChiTiet.GetSelectedRows())
                    {
                        if(gvChiTiet.GetRowCellValue(rowIndex, colChiTiet_Barcode) != null)
                        {
                            var id = long.Parse(gvChiTiet.GetRowCellValue(rowIndex, colChiTiet_IDchiTiet).ToString());
                            var daChuyen = bool.Parse((gvChiTiet.GetRowCellValue(rowIndex, colChiTiet_DaChuyen) == null || string.IsNullOrEmpty(gvChiTiet.GetRowCellValue(rowIndex, colChiTiet_DaChuyen).ToString()) ? "false" : gvChiTiet.GetRowCellValue(rowIndex, colChiTiet_DaChuyen).ToString()));
                            var nguoiTao = gvChiTiet.GetRowCellValue(rowIndex, colChiTiet_NguoiTao).ToString();
                            if (daChuyen)
                            {
                                CustomMessageBox.MSG_Information_OK("Không thể xóa thông tin đã xác nhận chuyển!");
                            }
                            else if (!nguoiTao.Trim().Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase)
                                 && !CommonAppVarsAndFunctions.IsAdmin)
                            {
                                CustomMessageBox.MSG_Information_OK(string.Format("Không thể xóa thông tin do người khác tạo!\nTài khoản tạo:{0}", nguoiTao.Trim()));
                            }
                            else
                                iPatient.Xoa_ChuyenChuyenK_ChiTiet(id);
                        }
                    }
                    Load_ChiTietChuyen();
                }
            }
        }

        private void btnXacNhanGui_Click(object sender, EventArgs e)
        {
            if(gvDanhSach_Chuyen.GetFocusedRowCellValue(colThongTin_IdChuyen) != null && gvChiTiet.RowCount >0)
            {
                if(CustomMessageBox.MSG_Question_YesNo_GetYes("Xác nhận chuyển kết quả?"))
                {
                    var id = long.Parse(gvDanhSach_Chuyen.GetFocusedRowCellValue(colThongTin_IdChuyen).ToString());
                    iPatient.Update_PhieuChuyenKQ_XacNhanChuyen(id, CommonAppVarsAndFunctions.UserID, Environment.MachineName, true);
                    Load_DanhSachChuyen();
                    var row =  gvDanhSach_Chuyen.LocateByValue(colThongTin_IdChuyen.FieldName, id);
                    if(row != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        gvDanhSach_Chuyen.FocusedRowHandle = row;
                    }
                    txtBarcode.Text = string.Empty;
                    lblIDChuyen.Text = string.Empty;
                    btnHuyLanChuyen.Enabled = false;
                    btnTaoIDChuyen.Enabled = true;
                }
            }
        }

        private void FrmChuyenKetQua_Shown(object sender, EventArgs e)
        {
            logo = _iSysConfig.Load_Logo("XN");
            Load_DanhSachChuyen();
            btnHuyLanChuyen.Enabled = false;
        }

        private void btnHuyLanChuyen_Click(object sender, EventArgs e)
        {
            HuyLenhChuyen();
        }
        private void HuyLenhChuyen()
        {
            if (!string.IsNullOrEmpty(lblIDChuyen.Text))
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Hủy thao tác chuyển kết quả ?"))
                {
                    if (iPatient.Delete_PhieuChuyenKQ(long.Parse(lblIDChuyen.Text)) > 0)
                    {
                        txtBarcode.Text = string.Empty;
                        lblIDChuyen.Text = string.Empty;
                        Load_DanhSachChuyen();
                        btnHuyLanChuyen.Enabled = false;
                        btnTaoIDChuyen.Enabled = true;
                    }
                }
            }
        }

        private void FrmChuyenKetQua_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnHuyLanChuyen.Enabled && !string.IsNullOrEmpty(lblIDChuyen.Text))
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Lệnh chuyển chưa hoàn thành.\nBạn muốn hủy lệnh?"))
                {
                    HuyLenhChuyen();
                }
                else
                    e.Cancel = true;
            }
        }

        private void btnXoaLanChuyen_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(lblIDChuyen.Text))
            {
                CustomMessageBox.MSG_Information_OK("Không thể xóa khi đang trong chế độ nhập.");
            }
            else
            {
                if(gvDanhSach_Chuyen.GetFocusedRowCellValue(colThongTin_IdChuyen) != null)
                {
                    var daxacNhan = bool.Parse(gvDanhSach_Chuyen.GetFocusedRowCellValue(colThongTin_DaChuyen).ToString());
                    var nguoiTao = gvDanhSach_Chuyen.GetFocusedRowCellValue(colThongTin_NguoiTao).ToString();
                    if (daxacNhan)
                    {
                        CustomMessageBox.MSG_Information_OK("Không thể xóa thông tin đã chuyển.");
                    }
                    else if (!nguoiTao.Trim().Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase)
                                 && !CommonAppVarsAndFunctions.IsAdmin)
                    {
                        CustomMessageBox.MSG_Information_OK(string.Format("Không thể xóa thông tin do người khác tạo!\nTài khoản tạo:{0}", nguoiTao.Trim()));
                    }
                    else
                    {
                        if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa thông tin chuyển kết quả đang chọn ?"))
                        {
                            if (iPatient.Delete_PhieuChuyenKQ(long.Parse(gvDanhSach_Chuyen.GetFocusedRowCellValue(colThongTin_IdChuyen).ToString())) > 0)
                            {
                                txtBarcode.Text = string.Empty;
                                lblIDChuyen.Text = string.Empty;
                                Load_DanhSachChuyen();
                                btnHuyLanChuyen.Enabled = false;
                                btnTaoIDChuyen.Enabled = true;
                            }
                            else
                            {
                                CustomMessageBox.MSG_Information_OK("Có lỗi trong quá trình xóa\nHãy thử lại.");
                            }
                        }
                    }
                }
            }
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnThemChiTiet_Click(sender, e);
        }

        private void btnInPhieuChuyen_Click(object sender, EventArgs e)
        {
            if (gvDanhSach_Chuyen.GetFocusedRowCellValue(colThongTin_IdChuyen) != null)
            {
                var dtPrint = iPatient.DanhSach_ChuyenKQ_InPhieu(long.Parse(gvDanhSach_Chuyen.GetFocusedRowCellValue(colThongTin_IdChuyen).ToString()));
            if (dtPrint.Rows.Count == 0) return;
                var logoAdd = GraphicSupport.ImageToByteArray(logo);
                foreach (DataRow dr in dtPrint.Rows)
                {
                    dr["Logo"] = logoAdd;
                }
                if (resultReportInfo == null)
                {
                    resultReportInfo = _reportInfo.Info_Report(ReportConstants.KetQuaXn_PhieuChuyen);
                }
                var crv = new FrmPreViewReport();
                crv.SampleID = string.Format("KetQuaXn_PhieuChuyen{0}", dtPrint.Rows[0]["IDChuyen"].ToString().Trim());
                crv.TenBN = "KetQuaXn_PhieuChuyen";

                var printerName = string.Empty;
                if (listPrinter.Items.Count > 0)
                {
                    if (listPrinter.SelectedIndex == -1)
                    {
                        listPrinter.SelectedIndex = 0;
                    }
                    printerName = listPrinter.SelectedItem.ToString();
                }
                dtPrint.AcceptChanges();
                ticketReport = _reportInfo.CreateReportFromStream(resultReportInfo.ReportSuDung);
                var havePrint = crv.ShowReport(ticketReport, dtPrint, chkInTructiep.Checked, printerName, "XN", resultReportInfo.TenDataset, resultReportInfo.TenDatatable);
            }
        }

        private void txtBarcode_Enter(object sender, EventArgs e)
        {
            txtBarcode.SelectAll();
        }

        private void txtBarcode_Click(object sender, EventArgs e)
        {
            txtBarcode.SelectAll();
        }
    }
}
