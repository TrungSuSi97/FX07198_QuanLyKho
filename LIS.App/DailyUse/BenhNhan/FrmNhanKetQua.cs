using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
    public partial class FrmNhanKetQua : FrmTemplate
    {
        public FrmNhanKetQua()
        {
            InitializeComponent();
        }
        private readonly IPatientInformationService iPatient = new PatientInformationService();
        private readonly ISystemConfigService _iSysConfig = new SystemConfigService();
        private Image logo;
        private static XtraReport ticketReport;
        private static ReportModel resultReportInfo;
        private readonly IReportService _reportInfo = new ReportServiceImpl();
        private void FrmNhanKetQua_Load(object sender, EventArgs e)
        {
            LabServices_Helper.LoadPrinterName(listPrinter, UserConstant.RegistryListPrinterSendSample, false);
            foreach (GridColumn item in gvDanhSach_Chuyen.Columns)
            {
                item.OptionsColumn.ReadOnly = true;
                item.OptionsColumn.AllowEdit = false;
                //item.FieldName = item.FieldName.ToLower().Trim();
            }
        }
        private void TaoLanNhanMoi()
        {
            txtIDChuyen.Text = string.Empty;
            txtIDChuyen.ReadOnly = false;
            txtIDChuyen.Focus();
        }
        string matiepNhanVuaUpdate = string.Empty;
        private void CapNhatChiTiet_NhanKQ()
        {
            matiepNhanVuaUpdate = string.Empty;
            if (!string.IsNullOrEmpty(txtBarcode.Text))
            {
                var row = gvChiTiet.LocateByValue(colChiTiet_Barcode.FieldName, txtBarcode.Text);
                if (row == DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    CustomMessageBox.MSG_Information_OK(string.Format("Barcode không có trong lần chuyển {0}.\nHãy đảm bảo bạn đang nhập đúng lần chuyển.", txtIDChuyen.Text));
                }
                else
                {
                    var maTiepNhan = gvChiTiet.GetRowCellValue(row, colChiTiet_MaTiepNhan).ToString();
                    var idChiTiet = long.Parse(gvChiTiet.GetRowCellValue(row, colChiTiet_IDchiTiet).ToString());
                    if (!string.IsNullOrEmpty(maTiepNhan))
                    {
                        iPatient.Update_PhieuChuyenKQ_DaNhanKetQua(idChiTiet, long.Parse(txtIDChuyen.Text)
                            , CommonAppVarsAndFunctions.UserID, Environment.MachineName, maTiepNhan);
                        Load_ChiTietChuyen();
                        matiepNhanVuaUpdate = maTiepNhan;
                        txtBarcode.Focus();
                    }
                }
                txtBarcode.SelectAll();
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
            data = WorkingServices.SearchResult_OnDatatable(data, "DaChuyen = True");
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
            TaoLanNhanMoi();
        }

        private void cmdRefreshPrinter_Click(object sender, EventArgs e)
        {
            LabServices_Helper.LoadPrinterName(listPrinter, UserConstant.RegistryListPrinterSendSample, false);
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            CapNhatChiTiet_NhanKQ();
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
        private void FrmChuyenKetQua_Shown(object sender, EventArgs e)
        {
            logo = _iSysConfig.Load_Logo("XN");
            Load_DanhSachChuyen();
        }

        private void FrmChuyenKetQua_FormClosing(object sender, FormClosingEventArgs e)
        {
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
                var dtPrint = iPatient.DanhSach_NhanKetQQua_InPhieu(long.Parse(gvDanhSach_Chuyen.GetFocusedRowCellValue(colThongTin_IdChuyen).ToString()));
            if (dtPrint.Rows.Count == 0) return;
                var logoAdd = GraphicSupport.ImageToByteArray(logo);
                foreach (DataRow dr in dtPrint.Rows)
                {
                    dr["Logo"] = logoAdd;
                }
                if (resultReportInfo == null)
                {
                    resultReportInfo = _reportInfo.Info_Report(ReportConstants.KetQuaXn_PhieuNhan);
                }
                var crv = new FrmPreViewReport();
                crv.SampleID = string.Format("KetQuaXn_PhieuNhanKetQua{0}", dtPrint.Rows[0]["IDChuyen"].ToString().Trim());
                crv.TenBN = "KetQuaXn_PhieuNhanKetQua";

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

        private void txtIDChuyen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtIDChuyen.Text) && WorkingServices.IsNumeric(txtIDChuyen.Text))
                {
                    txtBarcode.Text = string.Empty;
                    gvDanhSach_Chuyen.FocusedRowChanged -= GvDanhSach_Chuyen_FocusedRowChanged;
                    var data = iPatient.DanhSach_ThongTinChuyenChuyenKQ_TheoID(int.Parse(txtIDChuyen.Text));
                    if (data.Rows.Count > 0)
                    {
                        data = WorkingServices.SearchResult_OnDatatable(data, "DaChuyen = True");
                        if (data.Rows.Count > 0)
                        {
                            gcDanhSach_Chuyen.DataSource = data;
                            gvDanhSach_Chuyen.ExpandAllGroups();
                            Load_ChiTietChuyen();
                            txtBarcode.Focus();
                            txtBarcode.Text = string.Empty;
                        }
                        else
                            CustomMessageBox.MSG_Information_OK("Phiếu chuyển chưa được xác nhận!.");
                    }
                    else
                    {
                        CustomMessageBox.MSG_Information_OK("Không tìm thấy phiếu chuyển!.");
                        txtIDChuyen.Focus();
                        txtIDChuyen.SelectAll();
                    }
                    gvDanhSach_Chuyen.FocusedRowChanged += GvDanhSach_Chuyen_FocusedRowChanged;
                    
                }
            }
        }

        private void gvDanhSach_Chuyen_RowClick(object sender, RowClickEventArgs e)
        {
            //if(gvDanhSach_Chuyen.FocusedRowHandle>-1)
            //{
            //    if(gvDanhSach_Chuyen.GetFocusedRowCellValue(colThongTin_IdChuyen) != null)
            //    {
            //        txtIDChuyen.Text = gvDanhSach_Chuyen.GetFocusedRowCellValue(colThongTin_IdChuyen).ToString();
            //    }
            //}
        }

        private void gvDanhSach_Chuyen_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                if (gvDanhSach_Chuyen.GetRowCellValue(info.RowHandle, colThongTin_IdChuyen) != null)
                {
                    txtIDChuyen.Text = gvDanhSach_Chuyen.GetRowCellValue(info.RowHandle, colThongTin_IdChuyen).ToString();
                    txtBarcode.Focus();
                    txtBarcode.SelectAll();
                }
            }
        }

        private void gvChiTiet_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (string.IsNullOrEmpty(matiepNhanVuaUpdate))
                return;
            if (e.Column != view.Columns[colChiTiet_Barcode.FieldName])
                return;
            if (view.GetRowCellValue(e.RowHandle, colChiTiet_MaTiepNhan.FieldName).ToString().Equals(matiepNhanVuaUpdate))
            {
                e.Appearance.BackColor= Color.Green;
                e.Appearance.BackColor2 = Color.White;
            }
        }
    }
}
