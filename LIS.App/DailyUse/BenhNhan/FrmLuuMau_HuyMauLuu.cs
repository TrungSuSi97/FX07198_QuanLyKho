using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.Common.Extensions;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Patient.Controls;
using TPH.LIS.Patient.Services;
using TPH.LIS.User.Constants;
using TPH.Report.Constants;
using TPH.Report.Models;
using TPH.Report.Services;
using TPH.Report.Services.Impl;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmLuuMau_HuyMauLuu : FrmTemplate
    {
        public FrmLuuMau_HuyMauLuu()
        {
            InitializeComponent();
        }
        private readonly IPatientInformationService iPatient = new PatientInformationService();
        private readonly IReportService _reportInfo = new ReportServiceImpl();
        private List<ReportModel> lstResultReportInfo = new List<ReportModel>();
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
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
        private void btnTimMau_Click(object sender, EventArgs e)
        {
            Load_DanhSachMauLuu();
        }
        private void Load_DanhSachMauLuu()
        {
            var barcode = txtBarcode.Text;
            //Không cần cắt ký tự loại mẫu => xử lý like dưới sql
            //if (!WorkingServices.IsNumeric(barcode) && !string.IsNullOrEmpty(barcode))
            //    barcode = WorkingServices.SplitSampleCode(barcode);
            var data = iPatient.DanhSach_OngMauLuuTheoNgay((dtpNgayLuu.Checked ? dtpNgayLuu.Value : (DateTime?)null), (dtpNgayLuu.Checked ? dtpNgayLuu.Value : (DateTime?)null)
                , barcode
                , WorkingServices.ObjecToString(ucSearchLookupEditor_DanhSachKhayLuuMau1.SelectedValue), WorkingServices.ObjecToString(ucSearchLookupEditor_DanhSachTuLuuMau1.SelectedValue));
            gcDanhSach_DangLuu.DataSource = data;
            gvDanhSach_DangLuu.ExpandAllGroups();

            var dataHuy = iPatient.DanhSach_OngMauHuyTheoNgay((dtpNgayLuu.Checked ? dtpNgayLuu.Value : (DateTime?)null), (dtpNgayLuu.Checked ? dtpNgayLuu.Value : (DateTime?)null)
               , barcode
               , WorkingServices.ObjecToString(ucSearchLookupEditor_DanhSachKhayLuuMau1.SelectedValue), WorkingServices.ObjecToString(ucSearchLookupEditor_DanhSachTuLuuMau1.SelectedValue));
            gcDanhSach_MauDaHuy.DataSource = dataHuy;
            gvDanhSach_MauDaHuy.ExpandAllGroups();
        }

        private void dtpNgayLuu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Load_DanhSachMauLuu();
            }
        }

        private void btnHuyMau_Click(object sender, EventArgs e)
        {
            if (gvDanhSach_DangLuu.SelectedRowsCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Hủy các mẫu đang chọn?"))
                {
                    foreach (var item in gvDanhSach_DangLuu.GetSelectedRows())
                    {
                        if (gvDanhSach_DangLuu.GetRowCellValue(item, colThongTin_IdLuuMau) != null)
                        {
                            var id = long.Parse(gvDanhSach_DangLuu.GetRowCellValue(item, colThongTin_IdLuuMau).ToString());
                            iPatient.HuyOngMauLuu(id, CommonAppVarsAndFunctions.UserID, Environment.MachineName);
                        }
                    }
                    Load_DanhSachMauLuu();
                }
            }
        }
        bool mauBaoCaoTheoVitri = false;
        private void btnInBaoCaoHuyMau_Click(object sender, EventArgs e)
        {
            if (gvDanhSach_MauDaHuy.RowCount > 0)
            {
                if (mauBaoCaoTheoVitri)
                {
                    var data = new DataTable();
                    var column = 100;
                    for (int i = 0; i < column; i++)
                    {
                        data.Columns.Add(string.Format("Cot_{0}", i + 1), typeof(string));
                    }
                    data.Columns.Add("NguoiLuu", typeof(string));
                    data.Columns.Add("NguoiHuy", typeof(string));
                    data.Columns.Add("NgayLuu", typeof(DateTime));
                    data.Columns.Add("NgayHuy", typeof(DateTime));
                    data.Columns.Add("MaSoTuLuu", typeof(string));
                    data.Columns.Add("MaSoHop", typeof(string));
                    data.Columns.Add("NgayKiemTra", typeof(DateTime));
                    var dataHuy = (DataTable)gcDanhSach_MauDaHuy.DataSource;
                    var distinTuHopLuu = dataHuy.DefaultView.ToTable(true, "MaSoTuLuu", "MaHopLuuMau");
                    foreach (DataRow drT in distinTuHopLuu.Rows)
                    {
                        var dataH = WorkingServices.SearchResult_OnDatatable_NoneSort(dataHuy
                            , string.Format("MaSoTuLuu = '{0}' and MaHopLuuMau = '{1}'"
                            , WorkingServices.EscapeLikeValue(drT["MaSoTuLuu"].ToString())
                            , WorkingServices.EscapeLikeValue(drT["MaHopLuuMau"].ToString())));
                        var row = data.NewRow();
                        foreach (DataRow dr in dataH.Rows)
                        {
                            row[string.Format("Cot_{0}", dr["ViTri"].ToString())] = dr["Barcode"].ToString();
                        }
                        row["NguoiLuu"] = dataH.Rows[0]["TenNguoiLuu"];
                        row["NguoiHuy"] = dataH.Rows[0]["TenNguoiHuy"];
                        row["NgayLuu"] = dataH.Rows[0]["NgayLuu"];
                        row["NgayHuy"] = dataH.Rows[0]["NgayHuy"];
                        row["MaSoTuLuu"] = dataH.Rows[0]["MaSoTuLuu"];
                        row["MaSoHop"] = dataH.Rows[0]["MaHopLuuMau"];
                        row["NgayKiemTra"] = dataH.Rows[0]["NgayKiemTra"];
                        data.Rows.Add(row);
                    }
                    //string sql = "select ";
                    //foreach (DataColumn dc in data.Columns)
                    //{
                    //    if (dc.DataType == typeof(int))
                    //        sql += string.Format(",0 as {0}", dc.ColumnName);
                    //    else if (dc.DataType == typeof(bool))
                    //        sql += string.Format(",cast(0 as bit) as {0}", dc.ColumnName);
                    //    else
                    //        sql += string.Format(",'{0}' as {0}", dc.ColumnName);
                    //}
                    //Common.Controls.CustomMessageBox.MSG_Information_OK(sql.Replace("select ,", "select "));
                    GetReportConfigAndPrint.Print_Previewreport(ReportConstants.BaoCaoLuuHuyMau_Vitri, null, null, false, data);
                }
                else
                {
                    var data = (DataTable)gcDanhSach_MauDaHuy.DataSource;
                     GetReportConfigAndPrint.Print_Previewreport(ReportConstants.BaoCaoLuuHuyMau, null, null, false, data);
                }
            }
        }

        private void FrmLuuMau_HuyMauLuu_Load(object sender, EventArgs e)
        {
            ucSearchLookupEditor_DanhSachTuLuuMau1.Load_CauHinh();
            ucSearchLookupEditor_DanhSachTuLuuMau1.EditValueChange += UcSearchLookupEditor_DanhSachTuLuuMau1_EditValueChange;
            chkDuyetKhiIn.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryAutoValidArchivedSample).Equals("1");
            chkDuyetKhiIn.CheckedChanged += ChkDuyetKhiIn_CheckedChanged;
        }

        private void ChkDuyetKhiIn_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(
                  UserConstant.RegistryAutoValidArchivedSample,
                  chkDuyetKhiIn.Checked ? "1" : "0");
        }

        private void UcSearchLookupEditor_DanhSachTuLuuMau1_EditValueChange(object sender, EventArgs e)
        {
            if (ucSearchLookupEditor_DanhSachTuLuuMau1.SelectedValue == null)
            {
                ucSearchLookupEditor_DanhSachKhayLuuMau1.Load_CauHinh(ucSearchLookupEditor_DanhSachTuLuuMau1.SelectedValue.ToString());
            }
            else
                ucSearchLookupEditor_DanhSachKhayLuuMau1.Load_CauHinh(String.Empty);

        }

        private void btnDuyetLuuMau_Click(object sender, EventArgs e)
        {
            DuyetBoDuyetKiemTraMau(true, false);
        }

        private void btnBoDuyetLuuMau_Click(object sender, EventArgs e)
        {
            DuyetBoDuyetKiemTraMau(false, false);
        }
        private void DuyetBoDuyetKiemTraMau(bool duyet, bool fromAuto)
        {
            if (gvDanhSach_DangLuu.SelectedRowsCount > 0)
            {
                var allow = false;
                if (fromAuto)
                    allow = true;
                else
                    allow = CustomMessageBox.MSG_Question_YesNo_GetYes((duyet) ? "Duyệt kiểm tra các mẫu đang chọn?" : "Bỏ duyệt kiểm tra các mẫu đang chọn?");
                if (allow)
                {
                    foreach (var item in gvDanhSach_DangLuu.GetSelectedRows())
                    {
                        if (gvDanhSach_DangLuu.GetRowCellValue(item, colThongTin_IdLuuMau) != null)
                        {
                            var id = long.Parse(gvDanhSach_DangLuu.GetRowCellValue(item, colThongTin_IdLuuMau).ToString());
                            iPatient.DuyetMauLuu(id, CommonAppVarsAndFunctions.UserID, Environment.MachineName, duyet);
                        }
                    }
                    Load_DanhSachMauLuu();
                }
            }
        }

        private void btnInBaoCaoLuuMau_Click(object sender, EventArgs e)
        {
            if (gvDanhSach_DangLuu.RowCount > 0)
            {
                if (chkDuyetKhiIn.Checked)
                {
                    gvDanhSach_DangLuu.SelectAll();
                    DuyetBoDuyetKiemTraMau(true, true);
                }
            }
            if (mauBaoCaoTheoVitri)
            {
                var barcode = txtBarcode.Text;
                if (!WorkingServices.IsNumeric(barcode) && !string.IsNullOrEmpty(barcode))
                    barcode = WorkingServices.SplitSampleCode(barcode);
                var data = new DataTable();
                var column = 100;
                for (int i = 0; i < column; i++)
                {
                    data.Columns.Add(string.Format("Cot_{0}", i + 1), typeof(string));
                }
                data.Columns.Add("NguoiLuu", typeof(string));
                data.Columns.Add("NguoiHuy", typeof(string));
                data.Columns.Add("NgayLuu", typeof(DateTime));
                data.Columns.Add("NgayHuy", typeof(DateTime));
                data.Columns.Add("MaSoTuLuu", typeof(string));
                data.Columns.Add("MaSoHop", typeof(string));
                data.Columns.Add("NgayKiemTra", typeof(DateTime));
                var dataHuy = iPatient.DanhSach_OngMauLuuTheoNgay((dtpNgayLuu.Checked ? dtpNgayLuu.Value : (DateTime?)null), (dtpNgayLuu.Checked ? dtpNgayLuu.Value : (DateTime?)null)
                    , barcode
                    , WorkingServices.ObjecToString(ucSearchLookupEditor_DanhSachKhayLuuMau1.SelectedValue), WorkingServices.ObjecToString(ucSearchLookupEditor_DanhSachTuLuuMau1.SelectedValue));
                var distinTuHopLuu = dataHuy.DefaultView.ToTable(true, "MaSoTuLuu", "MaHopLuuMau");
                foreach (DataRow drT in distinTuHopLuu.Rows)
                {
                    var dataH = WorkingServices.SearchResult_OnDatatable_NoneSort(dataHuy
                        , string.Format("MaSoTuLuu = '{0}' and MaHopLuuMau = '{1}'"
                        , WorkingServices.EscapeLikeValue(drT["MaSoTuLuu"].ToString())
                        , WorkingServices.EscapeLikeValue(drT["MaHopLuuMau"].ToString())));
                    var row = data.NewRow();
                    foreach (DataRow dr in dataH.Rows)
                    {
                        row[string.Format("Cot_{0}", dr["ViTri"].ToString())] = dr["Barcode"].ToString();
                    }
                    row["NguoiLuu"] = dataH.Rows[0]["TenNguoiLuu"];
                    // row["NguoiHuy"] = dataH.Rows[0]["TenNguoiHuy"];
                    row["NgayLuu"] = dataH.Rows[0]["NgayLuu"];
                    // row["NgayHuy"] = dataH.Rows[0]["NgayHuy"];
                    row["MaSoTuLuu"] = dataH.Rows[0]["MaSoTuLuu"];
                    row["MaSoHop"] = dataH.Rows[0]["MaHopLuuMau"];
                    row["NgayKiemTra"] = dataH.Rows[0]["NgayKiemTra"];
                    data.Rows.Add(row);
                }
                //string sql = "select ";
                //foreach (DataColumn dc in data.Columns)
                //{
                //    if (dc.DataType == typeof(int))
                //        sql += string.Format(",0 as {0}", dc.ColumnName);
                //    else if (dc.DataType == typeof(bool))
                //        sql += string.Format(",cast(0 as bit) as {0}", dc.ColumnName);
                //    else
                //        sql += string.Format(",'{0}' as {0}", dc.ColumnName);
                //}
                //Common.Controls.CustomMessageBox.MSG_Information_OK(sql.Replace("select ,", "select "));
                GetReportConfigAndPrint.Print_Previewreport(ReportConstants.BaoCaoLuuMau_Vitri, null, null, false, data);
            }
            else
            {
                var barcode = txtBarcode.Text;
                if (!WorkingServices.IsNumeric(barcode) && !string.IsNullOrEmpty(barcode))
                    barcode = WorkingServices.SplitSampleCode(barcode);
                var data = iPatient.DanhSach_OngMauLuuTheoNgay((dtpNgayLuu.Checked ? dtpNgayLuu.Value : (DateTime?)null), (dtpNgayLuu.Checked ? dtpNgayLuu.Value : (DateTime?)null)
                    , barcode
                    , WorkingServices.ObjecToString(ucSearchLookupEditor_DanhSachKhayLuuMau1.SelectedValue), WorkingServices.ObjecToString(ucSearchLookupEditor_DanhSachTuLuuMau1.SelectedValue));

                GetReportConfigAndPrint.Print_Previewreport(ReportConstants.BaoCaoLuuMau, null, null, false, data);
               
            }
        }
    }
}
