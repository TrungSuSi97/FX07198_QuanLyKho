using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Patient.Services;
using TPH.LIS.Common.Controls;
using TPH.LIS.User.Constants;
using TPH.Excel;
using TPH.Report.Constants;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.Common.Extensions;

namespace TPH.LIS.App.AppCode
{
    public partial class ucGuiMauXetNghiem : DevExpress.XtraEditors.XtraUserControl
    {
        public ucGuiMauXetNghiem()
        {
            InitializeComponent();
        }
        private Image logo;
        private readonly IPatientInformationService patient = new PatientInformationService();
        private readonly ISystemConfigService _iSysConfig = new SystemConfigService();
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
        public void Load_CauHinh()
        {
            ucPatientInformation1.Load_DanhMucCauHinh();
            ucSearchLookupEditor_Location1.Load_DonVi("GM");
            ucSearchLookupEditor_Location_TimNoiGui.Load_DonVi("GM");
            ucSearchLookupEditor_Location_DaXoa.Load_DonVi("GM");
            ControlExtension.SetLowerCaseForXGridColumns(gvDSXoaGui);
            ControlExtension.SetLowerCaseForXGridColumns(gvDanhSachChiDinh);
            btnInDanhSach.Enabled = btnXuatExcel.Enabled = btnLuuDanhSachGui.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
              CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
              UserConstant.PermissionCreateSentTest);
            btnXoaGui.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
             CommonAppVarsAndFunctions.PhanQuyenXetNghiem,
             UserConstant.PermissionDeleteSentTest);

            LabServices_Helper.LoadPrinterName(listPrinter, UserConstant.RegistryPrinterSentTest, false);
            logo = _iSysConfig.Load_Logo("XN");
            listPrinter.SelectedItem = _registryExtension.ReadRegistry(UserConstant.RegistryPrinterSentTest);
            listPrinter.SelectedIndexChanged += listPrinter_SelectedIndexChanged;
        }
        private void cmdRefreshPrinter_Click(object sender, EventArgs e)
        {
            LabServices_Helper.LoadPrinterName(listPrinter, UserConstant.RegistryPrinterSentTest, true);
        }
        private void listPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPrinter.Items.Count > 0)
            {
                _registryExtension.WriteRegistry(
                    UserConstant.RegistryPrinterSentTest,
                    listPrinter.SelectedItem.ToString());
            }
        }
        private void txtBarcodeThongTin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadThongTiNChiDinh();
            }
        }
        private void LoadThongTiNChiDinh()
        {
            if (!string.IsNullOrEmpty(txtBarcodeThongTin.Text))
            {
                ucPatientInformation1.LoadInfomationByBarcode(txtBarcodeThongTin.Text);
                ucChiTietChiDinh1.Get_ChiTietChiDinh(ucPatientInformation1.MaTiepNhan, null);
                if (chkTuChonmauGui.Checked)
                {
                    if (ucChiTietChiDinh1.gvChiDinh.RowCount > 0)
                    {
                        for (int i = 0; i < ucChiTietChiDinh1.gvChiDinh.RowCount; i++)
                        {
                            var mauGui = ucChiTietChiDinh1.gvChiDinh.GetRowCellValue(i, ucChiTietChiDinh1.colMauGui);
                            if (mauGui != null)
                            {
                                if (bool.Parse(mauGui.ToString()))
                                {
                                    ucChiTietChiDinh1.gvChiDinh.SelectRow(i);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                ucPatientInformation1.ClearControl();
                ucChiTietChiDinh1.SetNullDataGridControl();
            }
        }
        private void InsertDanhSachGui()
        {
            if (!string.IsNullOrEmpty((ucSearchLookupEditor_Location1.SelectedValue??string.Empty).ToString()))
            {
                if (ucChiTietChiDinh1.gvChiDinh.SelectedRowsCount > 0)
                {
                    var itemChecked = ucChiTietChiDinh1.gvChiDinh.GetSelectedRows();
                    foreach (var i in itemChecked)
                    {
                        if (ucChiTietChiDinh1.gvChiDinh.GetRowCellValue(i, ucChiTietChiDinh1.MaChiDinh) != null)
                        {
                            patient.Insert_xetnghiem_guimau(new LIS.Patient.Model.XETNGHIEM_GUIMAU
                            {
                                Matiepnhan = ucChiTietChiDinh1.CurrentMatiepNhan.ToString(),
                                Barcode = txtBarcodeThongTin.Text,
                                Madonvinhan = ucSearchLookupEditor_Location1.SelectedValue.ToString(),
                                Maxn = ucChiTietChiDinh1.gvChiDinh.GetRowCellValue(i, ucChiTietChiDinh1.MaChiDinh).ToString(),
                                Nguoichon = CommonAppVarsAndFunctions.UserID
                            });
                        }
                    }
                    ucChiTietChiDinh1.gvChiDinh.ClearSelection();
                    txtBarcodeThongTin.Focus();
                    txtBarcodeThongTin.Text = string.Empty;
                    LoadThongTiNChiDinh();
                }
            }
        }
        private void Load_DanhSachGui()
        {
            gcDanhSachChiDinh.DataSource = null;
            string matiepnhan = string.Empty;
            if (!string.IsNullOrEmpty(txtBarcodeTimDanhSach.Text))
            {
                matiepnhan = patient.Get_MaTiepNhanByBarcode(txtBarcodeTimDanhSach.Text);
                if (string.IsNullOrEmpty(matiepnhan))
                {
                    CustomMessageBox.MSG_Information_OK("Không tìm thấy thông tin barcode");
                    return;
                }
            }
            string donvinhan = (ucSearchLookupEditor_Location_TimNoiGui.SelectedValue ?? string.Empty).ToString();
            DateTime? ngaytao = (dtpNgayGui.EditValue != null ? (string.IsNullOrEmpty(matiepnhan) ? dtpNgayGui.DateTime.Date : (DateTime?)null) : (DateTime?)null);
            if (!string.IsNullOrEmpty(matiepnhan) || !string.IsNullOrEmpty(donvinhan) || ngaytao != null)
            {
                var data = patient.Data_xetnghiem_guimau(matiepnhan, string.Empty, donvinhan, ngaytao);
                gcDanhSachChiDinh.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
                gvDanhSachChiDinh.ExpandAllGroups();
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy nhập điều kiện tìm");
        }
        private void Load_DanhSachXoaGui()
        {
            gcDSXoaGui.DataSource = null;
            string matiepnhan = string.Empty;
            if (!string.IsNullOrEmpty(txtTimXoa_barcode.Text))
            {
                matiepnhan = patient.Get_MaTiepNhanByBarcode(txtTimXoa_barcode.Text);
                if (string.IsNullOrEmpty(matiepnhan))
                {
                    CustomMessageBox.MSG_Information_OK("Không tìm thấy thông tin barcode");
                    return;
                }
            }
            string donvinhan = (ucSearchLookupEditor_Location_DaXoa.SelectedValue ?? string.Empty).ToString();
            DateTime? ngaytao = (dtpTimXoa_ngayTao.EditValue != null ? (string.IsNullOrEmpty(matiepnhan) ? dtpTimXoa_ngayTao.DateTime.Date : (DateTime?)null) : (DateTime?)null);
            if (!string.IsNullOrEmpty(matiepnhan) || !string.IsNullOrEmpty(donvinhan) || ngaytao != null)
            {
                var data = patient.Data_xetnghiem_guimau_daxoa(matiepnhan, string.Empty, donvinhan, ngaytao);
                gcDSXoaGui.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
                gvDSXoaGui.ExpandAllGroups();
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy nhập điều kiện tìm");
        }
        private void btnXemDanhSach_Click(object sender, EventArgs e)
        {
            Load_DanhSachGui();
        }

        private void btnLuuDanhSachGui_Click(object sender, EventArgs e)
        {
            InsertDanhSachGui();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel.Export(gvDanhSachChiDinh);
        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            InDanhSach();
        }
        private void InDanhSach()
        {
            if (gvDanhSachChiDinh.RowCount > 0)
            {
                var data = (DataTable)gcDanhSachChiDinh.DataSource;
                GetReportConfigAndPrint.Print_Previewreport(ReportConstants.DanhSachGuiMau, null, null, !chkXemTruocPhieuIn.Checked, data);

            }
        }
        private void txtBarcodeTimDanhSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if(!string.IsNullOrEmpty(txtBarcodeTimDanhSach.Text))
                {
                    Load_DanhSachGui();
                }
            }
        }
        private void XoaGuiMau()
        {
            if (gvDanhSachChiDinh.SelectedRowsCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa gửi mẫu?"))
                {
                    foreach (var itm in gvDanhSachChiDinh.GetSelectedRows())
                    {
                        if (gvDanhSachChiDinh.GetRowCellValue(itm, colDSGui_MaXN) != null)
                        {
                            patient.Delete_xetnghiem_guimau(gvDanhSachChiDinh.GetRowCellValue(itm, colDSGui_MaTiepNhan).ToString(), gvDanhSachChiDinh.GetRowCellValue(itm, colDSGui_MaXN).ToString(),
                                CommonAppVarsAndFunctions.UserID, Environment.MachineName
                            );
                        }
                    }
                    Load_DanhSachGui();
                }
            }
        }
        private void btnXacNhanGui_Click(object sender, EventArgs e)
        {
            if (gvDanhSachChiDinh.SelectedRowsCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xác nhận gửi mẫu?"))
                {
                    foreach (var itm in gvDanhSachChiDinh.GetSelectedRows())
                    {
                        if (gvDanhSachChiDinh.GetRowCellValue(itm, colDSGui_MaXN) != null)
                        {
                            patient.Update_xetnghiem_guimau_xacnhangui(new LIS.Patient.Model.XETNGHIEM_GUIMAU
                            {
                                Matiepnhan = gvDanhSachChiDinh.GetRowCellValue(itm, colDSGui_MaTiepNhan).ToString(),
                                Maxn = gvDanhSachChiDinh.GetRowCellValue(itm, colDSGui_MaXN).ToString(),
                                Nguoigui = CommonAppVarsAndFunctions.UserID,
                                Pcthuchiengui = Environment.MachineName
                            });
                        }
                    }
                    Load_DanhSachGui();
                    if(chkInKhiXacNhan.Checked)
                    {
                        InDanhSach();
                    }
                }
            }
        }

        private void btnXoaGui_Click(object sender, EventArgs e)
        {
            XoaGuiMau();
        }

        private void btnDSGuiMauDaXoa_Click(object sender, EventArgs e)
        {
            Load_DanhSachXoaGui();
        }
    }
}
