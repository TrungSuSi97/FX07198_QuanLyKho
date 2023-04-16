using TPH.LIS.BarcodePrinting;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TPH.Common.Extensions;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Patient.Model;
using TPH.LIS.Patient.Services;
using TPH.LIS.User.Constants;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.Controls;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmXacNhanChuyenMau : FrmTemplate
    {
        public FrmXacNhanChuyenMau()
        {
            InitializeComponent();
            splitContainer1.Panel1.BackColor = gbChiTiet.BackColor = pnIn.BackColor = CommonAppColors.ColorMainAppFormColor;
            gbChiTiet.AppearanceCaption.ForeColor = CommonAppColors.ColorTextCaption;
            pnIn.BackColor = CommonAppColors.ColorMainAppFormColor;

        }
        private readonly IPatientInformationService _iPatient = new PatientInformationService();
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
        private static readonly TestResult.Services.ITestResultService _iTestResult = new TestResult.Services.TestResultService();
        private readonly ISystemConfigService _iSysConfig = new SystemConfigService();
        List<string> lstCurrentList = new List<string>();
        bool addingMode = false;
        string markBarcode = string.Empty;
        private DM_KHULAYMAU objKhuLayMau = new DM_KHULAYMAU();
        Image logo;
        private void FrmXacNhanChuyenMau_Load(object sender, EventArgs e)
        {
            ControlExtension.Set_CheckBox_Radio_CheckedEven(radXemThemIDChuyenMau);
            ControlExtension.Set_CheckBox_Radio_CheckedEven(radXemTheoNgay);
            SwitchMode(false);
            radXemTheoNgay.Checked = true;
            objKhuLayMau = _iSysConfig.Get_Info_dm_khulaymau_Theomaytinh(Environment.MachineName);
            LabServices_Helper.LoadPrinterName(listPrinter, UserConstant.RegistryListPrinterSendSample, false);
            chkInTructiep.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryPreviewPrintSendSample) == "1";
            chkTuInKhiChuyenMau.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryAutoPrintSendSample) == "1";
            chkTuDuaVaoDSChuyen.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryLAutoAddSendSample) == "1";
            chkTuDuaVaoDSChuyen.CheckedChanged += ChkTuDuaVaoDSChuyen_CheckedChanged;
            lblSLBN_Limit.Text = objKhuLayMau.GioHanChuyenMau.ToString();
            logo = _iSysConfig.Load_Logo("A");

            toolTip1.SetToolTip(btnLuuVaoDanhSach, CommonAppVarsAndFunctions.LangMessageConstant.Duavaodanhsach);
            toolTip1.SetToolTip(btnHuyChuyenMau, CommonAppVarsAndFunctions.LangMessageConstant.Huyduavaodanhsach);
            toolTip1.SetToolTip(btnThucHien, CommonAppVarsAndFunctions.LangMessageConstant.Xacnhanchuyenmau);
        }

        private void ChkTuDuaVaoDSChuyen_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(UserConstant.RegistryLAutoAddSendSample, chkTuDuaVaoDSChuyen.Checked ? "1" : "0");
        }

        private void btnTaoIDChuyenMau_Click(object sender, EventArgs e)
        {
            var obj = new TaoMoiChuyenMau {PCName = Environment.MachineName, UserTao = CommonAppVarsAndFunctions.UserID};
            obj = _iPatient.Create_ChuyenMau_IdChuyenMau(obj);
            if (obj.IDChuyenMau > -1)
            {
                txtTimIdChuyenMau.Text = obj.IDChuyenMau.ToString();
                lblIDChuyenMau.Text = obj.IDChuyenMau.ToString();
                radXemThemIDChuyenMau.Checked = true;
                Load_ChiTietGuiMau(null, string.Empty);
                SwitchMode(true);
                addingMode = true;
                txtBarcode.Focus();
                txtBarcode.SelectAll();
            }
            else
                CustomMessageBox.MSG_Information_OK("Có lỗi trong quá trình tạo mã chuyễn mẫu mới! Hãy thử lại.");
        }
        private void Load_DanhSachOngMau()
        {
            dtgDanhSachOngMau.DataSource = null;
            bvDanhSachOngMau.BindingSource = null;
            txtBarcode.TextChanged -= txtBarcode_TextChanged;
            if (string.IsNullOrEmpty(txtBarcode.Text)) return;
            chkSelectAll.Checked = false;
            var barcodeMain = txtBarcode.Text;
            var sampleCode = (string.IsNullOrEmpty(barcodeMain) ? string.Empty : barcodeMain.Replace(WorkingServices.SplitSampleCode(barcodeMain), ""));
            txtBarcode.Text = (string.IsNullOrEmpty(sampleCode) ? barcodeMain : barcodeMain.Replace(sampleCode, "").Trim());
            markBarcode = txtBarcode.Text;
            var maTiepNhan = _iPatient.Get_MaTiepNhanByBarcode(txtBarcode.Text);
            if (!string.IsNullOrEmpty(maTiepNhan))
            {
                var dataBarcode = _iTestResult.SoLuongMau_Data(maTiepNhan, true, CommonAppVarsAndFunctions.IDLayLoaiMau, true);
                if (dataBarcode.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(sampleCode) && CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemPhanBietMauTheobarcode)
                    {
                        dataBarcode = WorkingServices.SearchResult_OnDatatable(dataBarcode, string.Format("LoaiMau = '{0}'", sampleCode));
                    }
                    dataBarcode = Them_MauOngMau(dataBarcode, "MauOngMau", "MauNhanMau");
                    ControlExtension.BindDataToGrid(dataBarcode, ref dtgDanhSachOngMau, bvDanhSachOngMau);
                    chkSelectAll.Checked = true;
                    XuLyOngMauDaChuyen();
                }
            }
            else
                CustomMessageBox.MSG_Information_OK("KHÔNG TÌM THẤY THÔNG TIN CỦA BARCODE.");
            txtBarcode.Text = barcodeMain;
            AddTextChangedEvent();
        }
        private void AddTextChangedEvent()
        {
            txtBarcode.TextChanged -= txtBarcode_TextChanged;
            txtBarcode.TextChanged += txtBarcode_TextChanged;
        }
        private void XuLyOngMauDaChuyen()
        {
            if (dtgDanhSachOngMau.RowCount <= 0 || gvDanhSach_Barcode.RowCount <= 0) return;
            chkSelectAll.Focus();

            var d = ((DataTable) gcDanhSach_Barcode.DataSource).AsEnumerable()
                .Where(w => TPH.Common.Converter.StringConverter.ToString(w["barcode"]).Equals(txtBarcode.Text)).Select(
                    r => new
                    {
                        ongmau = TPH.Common.Converter.StringConverter.ToString(r["maongmau"]),
                        barcode = TPH.Common.Converter.StringConverter.ToString(r["barcode"])
                    }
                )
                .ToList();
            foreach (var r in d)
            {
                for (var i = 0; i < dtgDanhSachOngMau.RowCount; i++)
                {
                    var maOngMauCho =
                        TPH.Common.Converter.StringConverter.ToString(dtgDanhSachOngMau[colOngMau_MaOngMau.Name, i]
                            .Value);
                    if (!maOngMauCho.Equals(r.ongmau, StringComparison.OrdinalIgnoreCase) ||
                        !r.barcode.Equals(txtBarcode.Text)) continue;

                    dtgDanhSachOngMau[colChonOngMau.Name, i].Value = false;
                }
            }

            //for (var i = 0; i < gvDanhSach_Barcode.RowCount; i++)
            //{
            //    var maOngMauChuyen = TPH.Common.Converter.StringConverter.ToString(gvDanhSach_Barcode.GetRowCellValue(i, colDanhSach_MaOngMau));
            //    if (maOngMauChuyen == null) continue;
            //    var maBarcode =
            //        TPH.Common.Converter.StringConverter.ToString(
            //            gvDanhSach_Barcode.GetRowCellValue(i, colDanhSach_Barcode));

            //    for (var iM = 0; iM < dtgDanhSachOngMau.RowCount; iM++)
            //    {
            //        var maOngMauCho =
            //            TPH.Common.Converter.StringConverter.ToString(dtgDanhSachOngMau[colOngMau_MaOngMau.Name, iM]
            //                .Value);
            //        if (maOngMauCho.Equals(maOngMauChuyen, StringComparison.OrdinalIgnoreCase) && maBarcode == txtBarcode.Text)
            //        {
            //            dtgDanhSachOngMau[colChonOngMau.Name, i].Value = false;
            //            break;
            //        }
            //    }
            //}
        }
        private DataTable Them_MauOngMau(DataTable dataSource, string columnMau, string columnMaMau)
        {
            dataSource.Columns.Add(columnMau, typeof(Image));
            if (dataSource.Rows.Count > 0)
            {
                foreach (DataRow dr in dataSource.Rows)
                {
                    var bitmap = new Bitmap(35, 35);
                    Color color;
                    if (!string.IsNullOrEmpty(dr[columnMaMau].ToString()))
                    {
                        string[] split = dr[columnMaMau].ToString().Split(',');
                        if (split.Length == 3)
                        {
                            if (WorkingServices.IsNumeric(split[0]) && WorkingServices.IsNumeric(split[1]) && WorkingServices.IsNumeric(split[2]))
                            {

                                color = Color.FromArgb(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
                            }
                            else
                                color = Color.Empty;
                        }
                        else
                            color = Color.Empty;
                    }
                    else
                        color = Color.Empty;

                    using (Graphics g = Graphics.FromImage(bitmap))
                        g.Clear(color);

                    dr[columnMau] = bitmap;
                }
                dataSource.AcceptChanges();
            }
            return dataSource;
        }
        private void txtBarcode_Click(object sender, EventArgs e)
        {
            txtBarcode.SelectAll();
        }

        private void txtBarcode_Enter(object sender, EventArgs e)
        {
            txtBarcode.SelectAll();
        }

        private void SwitchMode(bool Addnew)
        {
            //btnTaoIDChuyenMau.Enabled = !Addnew;
            //btnThucHien.Enabled = Addnew;
            if (Addnew)
                radXemThemIDChuyenMau.Checked = true;
        }
        private void Insert_ChiTiet()
        {
            if (string.IsNullOrEmpty(txtBarcode.Text) || dtgDanhSachOngMau.RowCount <= 0) return;
            txtBarcode.TextChanged -= txtBarcode_TextChanged;
            var barcodeMain = txtBarcode.Text;
            var sampleCode = (string.IsNullOrEmpty(barcodeMain) ? string.Empty : barcodeMain.Replace(WorkingServices.SplitSampleCode(barcodeMain), ""));
            txtBarcode.Text = (string.IsNullOrEmpty(sampleCode) ? barcodeMain : barcodeMain.Replace(sampleCode, "").Trim());
            var obj = new ThemChuyenMauChiTiet
            {
                idChuyenMau = long.Parse(lblIDChuyenMau.Text),
                Barcode = txtBarcode.Text,
                UserTao = CommonAppVarsAndFunctions.UserID,
                PcTao = Environment.MachineName
            };
            DemSoBarcode();
            if (!lstCurrentList.Contains(obj.Barcode) && txtSLBenhNhan.Text.Trim() == lblSLBN_Limit.Text.Trim())
            {
                CustomMessageBox.MSG_Information_OK(string.Format("Đã đủ {0} bệnh nhân / 1 lần gửi. Hãy thực hiện xác nhận gửi trước khi tiếp tục.", txtSLBenhNhan.Text));
            }
            else
            {
                var ok = false;

                for (var i = 0; i < dtgDanhSachOngMau.RowCount; i++)
                {
                    if (dtgDanhSachOngMau[colChonOngMau.Name, i].Value == null) continue;
                    if (!bool.Parse(dtgDanhSachOngMau[colChonOngMau.Name, i].Value.ToString())) continue;
                    obj.MaLoaiMau = dtgDanhSachOngMau[colOngMau_MaOngMau.Name, i].Value.ToString();
                    obj.MaTiepNhan = dtgDanhSachOngMau[colOngMau_MaTiepNhan.Name, i].Value.ToString();
                    obj.SoLuong = int.Parse(dtgDanhSachOngMau[colOngMau_SoLuong.Name, i].Value.ToString());
                    ok = _iPatient.Insert_ChuyenMau_ChiTiet(obj);
                }

                if (ok)
                {
                    Load_ChiTietGuiMau(obj.idChuyenMau, string.Empty);
                    DemSoBarcode();
                    Load_DanhSachOngMau();
                }
            }
            txtBarcode.Text = barcodeMain;
            txtBarcode.Focus();
            txtBarcode.SelectAll();
            AddTextChangedEvent();
        }
        private void Load_ChiTietGuiMau(long? idChuyenMau, string barcode)
        {
            var barcodeMain = barcode;
            var sampleCode = (string.IsNullOrEmpty(barcodeMain) ? string.Empty : barcodeMain.Replace(WorkingServices.SplitSampleCode(barcodeMain), ""));
            barcode = (string.IsNullOrEmpty(sampleCode) ? barcodeMain : barcodeMain.Replace(sampleCode, "").Trim());

            if (radXemThemIDChuyenMau.Checked)
            {
                var data = _iPatient.Data_ChuyenMau_ChiTiet(idChuyenMau, string.Empty, null, null, (CommonAppVarsAndFunctions.IsAdmin ? string.Empty : CommonAppVarsAndFunctions.UserID));
                data = Them_MauOngMau(data, "MauOngMau", "MauNhanMau");
                gcDanhSach_Barcode.DataSource = data;
                gvDanhSach_Barcode.ExpandAllGroups();
            }
            else if (radXemtheoBarcode.Checked)
            {
                var data = _iPatient.Data_ChuyenMau_ChiTiet(null, barcode, null, null, (CommonAppVarsAndFunctions.IsAdmin ? string.Empty : CommonAppVarsAndFunctions.UserID));
                data = Them_MauOngMau(data, "MauOngMau", "MauNhanMau");
                gcDanhSach_Barcode.DataSource = data;
                gvDanhSach_Barcode.ExpandAllGroups();
            }
            else
            {
                var fromDate = new DateTime(dtpNgayChuyenMau.Value.Year, dtpNgayChuyenMau.Value.Month, dtpNgayChuyenMau.Value.Day, 0, 0, 0);
                var toDate = new DateTime(dtpNgayChuyenMau.Value.Year, dtpNgayChuyenMau.Value.Month, dtpNgayChuyenMau.Value.Day, 23, 59, 59);
                var data = _iPatient.Data_ChuyenMau_ChiTiet(null, string.Empty, fromDate, toDate);
                data = Them_MauOngMau(data, "MauOngMau", "MauNhanMau");
                gcDanhSach_Barcode.DataSource = data;
                gvDanhSach_Barcode.ExpandAllGroups();
                txtSLBenhNhan.Text = string.Empty;
            }
            gvDanhSach_Barcode.SelectAll();
        }
        private void DemSoBarcode()
        {
            lstCurrentList = new List<string>();
            var soLuong = 0;

            if (gvDanhSach_Barcode.RowCount > 0)
            {
                for (int i = 0; i < gvDanhSach_Barcode.RowCount; i++)
                {
                    if (gvDanhSach_Barcode.GetRowCellValue(i, colDanhSach_Barcode) != null)
                    {
                        var barcode = gvDanhSach_Barcode.GetRowCellValue(i, colDanhSach_Barcode).ToString();
                        if (!lstCurrentList.Contains(barcode))
                        {
                            lstCurrentList.Add(barcode);
                        }
                        soLuong += int.Parse(gvDanhSach_Barcode.GetRowCellValue(i, colDanhSach_SoLuong).ToString());
                    }
                }
            }
            txtSLBenhNhan.Text = lstCurrentList.Count.ToString();
            txtSLOngMau.Text = soLuong.ToString();
        }
        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char) Keys.Enter) return;
           // txtBarcode.Text = WorkingServices.GetBarcodeInString(txtBarcode.Text, int.Parse(CommonAppVarsAndFunctions.sysConfig.BenhNhanSoKyTuBarCode));
            if (!string.IsNullOrEmpty(lblIDChuyenMau.Text) && !string.IsNullOrEmpty(txtBarcode.Text))
            {
                //markBarcode = txtBarcode.Text;
                Load_DanhSachOngMau();
                if (chkTuDuaVaoDSChuyen.Checked)
                {
                    Insert_ChiTiet();
                }
                gvDanhSach_Barcode.SelectAll();
            }
            txtBarcode.Focus();
            txtBarcode.SelectAll();
            e.Handled = true;
        }

        private void radXemThemIDChuyenMau_CheckedChanged(object sender, EventArgs e)
        {
            pnXemTheoIDChuyen.Enabled = radXemThemIDChuyenMau.Checked;
            pnXemTheoNgay.Enabled = radXemTheoNgay.Checked;
            txtTimBarcode.Enabled = radXemtheoBarcode.Checked;
            if (!radXemtheoBarcode.Checked)
                txtTimBarcode.Text = string.Empty;
            if (!radXemThemIDChuyenMau.Checked)
                txtTimIdChuyenMau.Text = string.Empty;

            if (radXemThemIDChuyenMau.Checked)
                Load_ChiTietGuiMau(string.IsNullOrEmpty(txtTimIdChuyenMau.Text) ? (long?)null : long.Parse(txtTimIdChuyenMau.Text), txtTimBarcode.Text);
            else if (radXemtheoBarcode.Checked)
                Load_ChiTietGuiMau(null, txtTimBarcode.Text);
            else
                Load_ChiTietGuiMau(null, string.Empty);
        }

        private void btnLamMoiDS_Click(object sender, EventArgs e)
        {
            if (radXemThemIDChuyenMau.Checked)
                Load_ChiTietGuiMau(string.IsNullOrEmpty(txtTimIdChuyenMau.Text) ? (long?)null : long.Parse(txtTimIdChuyenMau.Text), txtTimBarcode.Text);
            else if (radXemtheoBarcode.Checked)
                Load_ChiTietGuiMau(null, txtTimBarcode.Text);
            else
                Load_ChiTietGuiMau(null, string.Empty);
        }

        private void txtTimIdChuyenMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtTimIdChuyenMau.Text))
                    Load_ChiTietGuiMau(long.Parse(txtTimIdChuyenMau.Text),string.Empty);
            }
        }

        private void gvDanhSach_Barcode_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //GridView view = sender as GridView;
            //if (e.Column.FieldName == GridView.CheckBoxSelectorColumnName)
            //{
            //    GridCellInfo cell = e.Cell as GridCellInfo;
            //    ObjectPainter p = cell.RowInfo.ViewInfo.Painter.ElementsPainter.DetailButton;
            //    if (!cell.CellButtonRect.IsEmpty)
            //    {
            //        ObjectPainter.DrawObject(e.Cache, p,
            //            new DevExpress.XtraGrid.Drawing.DetailButtonObjectInfoArgs(cell.CellButtonRect,
            //                view.GetMasterRowExpanded(cell.RowHandle), !cell.RowInfo.IsMasterRowEmpty));
            //    }
            //    e.Handled = true;
            //}
        }

        private void gvDanhSach_Barcode_MouseDown(object sender, MouseEventArgs e)
        {
            //GridView view = sender as GridView;
            //var hitInfo = view.CalcHitInfo(e.Location);
            //if (hitInfo.InRowCell && hitInfo.Column.FieldName == GridView.CheckBoxSelectorColumnName)
            //{
            //    GridViewInfo viewInfo = (gvDanhSach_Barcode.GetViewInfo() as GridViewInfo);
            //    GridCellInfo cellInfo = viewInfo.GetGridCellInfo(hitInfo);
            //    var rect = cellInfo.CellButtonRect;
            //    if (!rect.Contains(hitInfo.HitPoint))
            //        DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
            //}
        }
        private void Update_ChuyenMau()
        {
            var lstUpdate = new List<string>();
            var id = string.Empty;
            var lstDaChuyen = string.Empty;
            bool haveUpdate = false;
            if (gvDanhSach_Barcode.SelectedRowsCount > 0)
            {
                foreach (int i in gvDanhSach_Barcode.GetSelectedRows())
                {
                    if (gvDanhSach_Barcode.GetRowCellValue(i, colDanhSach_IDChuyenMau) != null)
                    {
                        id = gvDanhSach_Barcode.GetRowCellValue(i, colDanhSach_IDChuyenMau).ToString();
                        if (!lstUpdate.Contains(id))
                        {
                            lstUpdate.Add(id);
                            if (!bool.Parse(gvDanhSach_Barcode.GetRowCellValue(i, colDanhSach_DaChuyen).ToString()))
                            {
                                var obj = new CapNhatChuyenMau();
                                obj.IDChuyenMau = long.Parse(id);
                                obj.UserChuyen = CommonAppVarsAndFunctions.UserID;
                                obj.PcChuyen = Environment.MachineName;
                                obj.ChiCapNhatGhiChu = false;
                              var ok =_iPatient.Update_ChuyenMau_XacNhanChuyen(obj);
                                if (!haveUpdate)
                                    haveUpdate = ok;
                            }
                            else
                            {
                                lstDaChuyen += string.IsNullOrEmpty(lstDaChuyen) ? "" : "\n     ";
                                lstDaChuyen += id;
                            }
                        }
                    }
                }
                if (!string.IsNullOrEmpty(lstDaChuyen))
                    CustomMessageBox.MSG_Information_OK(string.Format("Các ID lần chuyển đã được xác nhận chuyển trước:\n       {0}", lstDaChuyen));
            }
            if (radXemThemIDChuyenMau.Checked)
            {
                Load_ChiTietGuiMau(string.IsNullOrEmpty(txtTimIdChuyenMau.Text) ? (long?)null : long.Parse(txtTimIdChuyenMau.Text), string.Empty);
            }
            else
            {
                Load_ChiTietGuiMau(null, string.Empty);
            }
            if (haveUpdate && chkTuInKhiChuyenMau.Checked)
            {
                gvDanhSach_Barcode.SelectAll();
                Print_DanhSachChuyenMau();
            }
        }
        private void Delete_ChuyenMau()
        {
            var lstUpdate = new List<string>();
            var id = string.Empty;
            var lstDaChuyen = string.Empty;

            if (gvDanhSach_Barcode.SelectedRowsCount > 0)
            {
                foreach (int i in gvDanhSach_Barcode.GetSelectedRows())
                {
                    if (gvDanhSach_Barcode.GetRowCellValue(i, colDanhSach_IDChuyenMau) != null)
                    {
                        id = gvDanhSach_Barcode.GetRowCellValue(i, colDanhSach_IDChuyenMauChiTiet).ToString();
                        if (!lstUpdate.Contains(id))
                        {
                            lstUpdate.Add(id);
                            if (!bool.Parse(gvDanhSach_Barcode.GetRowCellValue(i, colDanhSach_DaChuyen).ToString()))
                            {
                                _iPatient.Delete_ChuyenMau_ChiTiet(long.Parse(id));
                            }
                            else
                            {
                                lstDaChuyen += string.IsNullOrEmpty(lstDaChuyen) ? "" : "\n     ";
                                lstDaChuyen += id;
                            }
                        }
                    }
                }
                if (!string.IsNullOrEmpty(lstDaChuyen))
                    CustomMessageBox.MSG_Information_OK(string.Format("Không thể hủy các ID đã được xác nhận chuyển trước:\n       {0}", lstDaChuyen));
            }
            if (radXemThemIDChuyenMau.Checked)
            {
                Load_ChiTietGuiMau(string.IsNullOrEmpty(txtTimIdChuyenMau.Text) ? (long?)null : long.Parse(txtTimIdChuyenMau.Text), string.Empty);
            }
            else
            {
                Load_ChiTietGuiMau(null, string.Empty);
            }
            DemSoBarcode();
            Load_DanhSachOngMau();
        }
        private void btnThucHien_Click(object sender, EventArgs e)
        {
            Update_ChuyenMau();
            addingMode = false;
            txtBarcode.Text = string.Empty;
            markBarcode = string.Empty;
            lblIDChuyenMau.Text = string.Empty;
            txtSLBenhNhan.Text = string.Empty;
            txtSLOngMau.Text = string.Empty;
        }

        private void gvDanhSach_Barcode_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                if (e.Column == colDanhSach_SoLuong)
                {
                    var barcode = gvDanhSach_Barcode.GetRowCellValue(e.RowHandle, colDanhSach_Barcode).ToString();
                    if (!string.IsNullOrEmpty(markBarcode) && barcode.Trim().Equals(markBarcode))
                    {
                        e.Appearance.BackColor = Color.Yellow;
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
        }
        private bool Check_AllowAdd(long idChuyenMau)
        {
            var data = _iPatient.Data_ChuyenMau(idChuyenMau, null, null, (CommonAppVarsAndFunctions.IsAdmin ? string.Empty : CommonAppVarsAndFunctions.UserID));
            if (data.Rows.Count > 0)
            {
                var chuaChuyen = string.IsNullOrEmpty(data.Rows[0]["ThoiGianChuyen"].ToString());
                return chuaChuyen;
            }
            return false;
        }
        private void btnThemOngMau_Click(object sender, EventArgs e)
        {
            var f = new FrmNhapID();
            f.pnMenu.Visible=true;
            f.AdjustForm();
            f.ShowDialog();
            if (!string.IsNullOrEmpty(f.Result))
            {
                var id = f.Result;
                f.Dispose();
                if (Check_AllowAdd(long.Parse(id)))
                {
                    lblIDChuyenMau.Text = id;
                    txtBarcode.Focus();
                    txtBarcode.SelectAll();
                    radXemThemIDChuyenMau.Checked = true;
                    txtTimIdChuyenMau.Text = id;
                    Load_ChiTietGuiMau(long.Parse(id), string.Empty);
                    gvDanhSach_Barcode.SelectAll();
                }
                else
                    CustomMessageBox.MSG_Information_OK("Ống mẫu đã xác nhận chuyển hoặc ID chuyển không tồn tại.");
            }
        }

        private void btnHuyChuyenMau_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Hủy chuyển mẫu các ID đang chọn?"))
            {
                Delete_ChuyenMau();
            }
        }

        private void gvDanhSach_Barcode_CalcRowHeight(object sender, RowHeightEventArgs e)
        {
            e.RowHeight = 35;
        }

        private void btnGiam_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var daChuyen = bool.Parse(gvDanhSach_Barcode.GetFocusedRowCellValue(colDanhSach_DaChuyen).ToString());
            if (!daChuyen)
            {
                var barcode = gvDanhSach_Barcode.GetFocusedRowCellValue(colDanhSach_Barcode).ToString();
                var IdchuyenMau = gvDanhSach_Barcode.GetFocusedRowCellValue(colDanhSach_IDChuyenMau).ToString();
                var soLuong = int.Parse(gvDanhSach_Barcode.GetFocusedRowCellValue(colDanhSach_SoLuong).ToString());
                var maOngMau = gvDanhSach_Barcode.GetFocusedRowCellValue(colDanhSach_MaOngMau).ToString();
                markBarcode = barcode;
                if (soLuong - 1 > 0)
                {
                    _iPatient.Update_ChuyenMau_SoLuong(long.Parse(IdchuyenMau), barcode, maOngMau, false);

                    gvDanhSach_Barcode.SetFocusedRowCellValue(colDanhSach_SoLuong, soLuong - 1);
                }
                else
                    CustomMessageBox.MSG_Information_OK("Số lượng không hợp lệ!");
            }
            else
                CustomMessageBox.MSG_Information_OK("Không thể sửa số lượng mẫu đã xác nhận chuyển.");
            gvDanhSach_Barcode.CloseEditor();
        }

        private void btnTang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var daChuyen = bool.Parse(gvDanhSach_Barcode.GetFocusedRowCellValue(colDanhSach_DaChuyen).ToString());
            if (!daChuyen)
            {
                var barcode = gvDanhSach_Barcode.GetFocusedRowCellValue(colDanhSach_Barcode).ToString();
                var maOngMau = gvDanhSach_Barcode.GetFocusedRowCellValue(colDanhSach_MaOngMau).ToString();
                var IdchuyenMau = gvDanhSach_Barcode.GetFocusedRowCellValue(colDanhSach_IDChuyenMau).ToString();
                var soLuong = int.Parse(gvDanhSach_Barcode.GetFocusedRowCellValue(colDanhSach_SoLuong).ToString());
                markBarcode = barcode;
                _iPatient.Update_ChuyenMau_SoLuong(long.Parse(IdchuyenMau), barcode, maOngMau, true);
                gvDanhSach_Barcode.SetFocusedRowCellValue(colDanhSach_SoLuong, soLuong + 1);
            }
            else
                CustomMessageBox.MSG_Information_OK("Không thể sửa số lượng mẫu đã xác nhận chuyển.");
            gvDanhSach_Barcode.CloseEditor();
        }
   

        private void gvDanhSach_Barcode_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if(e.RowHandle >-1)
            {
                if (e.Column == colDanhSach_Giam || e.Column == colDanhSach_Tang)
                {
                    GridView view = sender as GridView;
                    var daChuyen = bool.Parse(view.GetRowCellValue(e.RowHandle, colDanhSach_DaChuyen).ToString());
                    if (daChuyen)
                    {
                        e.RepositoryItem = btnNull;
                        
                    }  
                }
            }
        }

        private void gvDanhSach_Barcode_ShowingEditor(object sender, CancelEventArgs e)
        {
            var daChuyen = bool.Parse(gvDanhSach_Barcode.GetFocusedRowCellValue(colDanhSach_DaChuyen).ToString());
            if (daChuyen)
                e.Cancel = true;
        }

        private void btnInDanhSachOngMau_Click(object sender, EventArgs e)
        {
            Print_DanhSachChuyenMau();
        }
        private void Print_DanhSachChuyenMau()
        {
            if (gvDanhSach_Barcode.SelectedRowsCount > 0)
            {
                if (gvDanhSach_Barcode.SelectedRowsCount <= 100)
                {
                    //IDChuyenMauChiTiet
                    var lstSelected = new List<string>();
                    foreach (var itm in gvDanhSach_Barcode.GetSelectedRows())
                    {
                        if (gvDanhSach_Barcode.GetRowCellValue(itm, colDanhSach_IDChuyenMauChiTiet) != null)
                        {
                            if (!string.IsNullOrEmpty(gvDanhSach_Barcode.GetRowCellValue(itm, colDanhSach_IDChuyenMauChiTiet).ToString()))
                            {
                                lstSelected.Add(gvDanhSach_Barcode.GetRowCellValue(itm, colDanhSach_IDChuyenMauChiTiet).ToString());
                            }
                        }
                    }
                    DataTable dataTemp = (DataTable)(gcDanhSach_Barcode.DataSource);
                    var dataPrint = WorkingServices.SearchResult_OnDatatable_NoneSort(dataTemp, "DaChuyen = 1");
                    if (dataPrint.Rows.Count > 0)
                    {
                        if (!dataPrint.Columns.Contains("BarcodeID"))
                            dataPrint.Columns.Add("BarcodeID", typeof(byte[]));
                        var logoAdd = GraphicSupport.ImageToByteArray(logo);
                        for (int i = 0; i < dataPrint.Rows.Count; i++)
                        {
                            var drS = dataPrint.Rows[i];
                            var idCHitiet = drS["IDChuyenMauChiTiet"].ToString();
                            if (lstSelected.Contains(idCHitiet))
                            {
                                var Id = drS["IDChuyenMau"].ToString();
                                var code = BarcodeHelper.TextToBarcode(Id);
                                drS["BarcodeID"] = code;
                                drS["ReportLogo"] = logoAdd;
                            }
                            else
                            {
                                dataPrint.Rows.RemoveAt(i);
                                i--;
                            }
                        }
                        dataPrint.AcceptChanges();
                        if (dataPrint.Rows.Count > 0)
                        {
                            //var rp = new rpDSChuyenMau();
                            //var crv = new FrmReport();
                            //crv.SampleID = string.Empty;
                            //crv.TenBN = string.Empty;
                            //crv.Excute_Show_Print_Report(rp, dataPrint, "A", false, false, !chkInTructiep.Checked, chkInTructiep.Checked, LabServices_Helper.Get_PrinterSelected(listPrinter), false);
                        }
                    }
                }
                else
                    CustomMessageBox.MSG_Information_OK("Số lượng mẫu chuyển lớn hơn 100.\nHãy chọn lại số lượng phù hợp với 1 lần chuyển.");
            }
            else
                CustomMessageBox.MSG_Information_OK("Không có thông tin chuyển mẫu nào được chọn.");
        }
        private void chkInTructiep_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(
             UserConstant.RegistryPreviewPrintSendSample,
             chkInTructiep.Checked ? "1" : "0");
        }

        private void chkTuInKhiChuyenMau_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(
             UserConstant.RegistryAutoPrintSendSample,
             chkTuInKhiChuyenMau.Checked ? "1" : "0");
        }

        private void cmdRefreshPrinter_Click(object sender, EventArgs e)
        {
            LabServices_Helper.LoadPrinterName(listPrinter, UserConstant.RegistryListPrinterSendSample, false);
        }

        private void listPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPrinter.Items.Count > 0)
            {
                _registryExtension.WriteRegistry(
                    UserConstant.RegistryListPrinterSendSample,
                    listPrinter.SelectedItem.ToString());
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            ControlExtension.Check_Uncheck_Datagrid(dtgDanhSachOngMau, colChonOngMau, chkSelectAll.Checked);
        }

        private void btnLuuVaoDanhSach_Click(object sender, EventArgs e)
        {
            Insert_ChiTiet();
        }
        int countDistinctBarcode = 0;
        List<string> listBarcode = new List<string>();
        private void gvDanhSach_Barcode_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.Item == gvDanhSach_Barcode.GroupSummary.Where(x => x.FieldName.Equals("Barcode", StringComparison.OrdinalIgnoreCase)).First() && e.GroupLevel == 0)
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    countDistinctBarcode = 0;
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!listBarcode.Contains(e.FieldValue.ToString().Trim()))
                        {
                            countDistinctBarcode++;
                            listBarcode.Add(e.FieldValue.ToString().Trim());
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = countDistinctBarcode;
                    listBarcode.Clear();
                }
            }
            else if (e.Item == gvDanhSach_Barcode.GroupSummary.Where(x => x.FieldName.Equals("Barcode", StringComparison.OrdinalIgnoreCase)).First())
            {
                e.TotalValue = string.Empty;
            }
           
        }

        private void gvDanhSach_Barcode_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            //- Số BN: 
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            if (info.Column == colDanhSach_Barcode)
            {
                if(info.Level > 0)
                {
                    if (info.GroupText != null)
                        info.GroupText = info.GroupText.Replace("- Số BN: ", "");
                }
            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            dtgDanhSachOngMau.DataSource = null;
        }

        private void txtTimBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtTimBarcode.Text))
                    Load_ChiTietGuiMau(null, txtTimBarcode.Text);
            }
        }

        private void FrmXacNhanChuyenMau_Shown(object sender, EventArgs e)
        {
            splitContainer1.SplitterPosition = btnLuuVaoDanhSach.Location.X + btnLuuVaoDanhSach.Width + 5;
        }
    }
}
