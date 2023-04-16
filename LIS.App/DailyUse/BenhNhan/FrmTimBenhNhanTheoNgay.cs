using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Patient.Services;
using TPH.LIS.TestResult.Services;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmTimBenhNhanTheoNgay : FrmTemplate
    {
        public FrmTimBenhNhanTheoNgay()
        {
            InitializeComponent();
        }
        public string MaTiepNhan = string.Empty;
        public string Barcode = string.Empty;
        public string SoPhieuYeuCau = string.Empty;
        public string SoHoSo = string.Empty;
        public string MaBenhNhan = string.Empty;
        private void gvChiTiet_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                if (gvChiTiet.GetRowCellValue(info.RowHandle, colChiTiet_Barcode) != null)
                {
                    MaTiepNhan = gvChiTiet.GetRowCellValue(info.RowHandle, colChiTiet_MaTiepNhan).ToString();
                    Barcode = gvChiTiet.GetRowCellValue(info.RowHandle, colChiTiet_Barcode).ToString();
                    SoPhieuYeuCau = gvChiTiet.GetRowCellValue(info.RowHandle, colChiTiet_SoPhieuYeuCau).ToString();
                    SoHoSo = gvChiTiet.GetRowCellValue(info.RowHandle, colChiTiet_SoHoSo).ToString();
                    MaBenhNhan = gvChiTiet.GetRowCellValue(info.RowHandle, colChiTiet_MaBN).ToString();
                    this.Close();
                }
            }
        }
        private readonly ITestResultService _xetnghiem = new TestResultService();
        private readonly IPatientInformationService _patient = new PatientInformationService();
        private void btnTim_Click(object sender, EventArgs e)
        {
            TimBenhNhan();
        }
        private void TimBenhNhan()
        {
            var dataDSBenhNhan = _patient.TimBenhNhan(new Patient.Model.SearchPatientCondit
            {
                tungay = dtpNgay.Value.Date,
                denngay = dtpNgay.Value.Date,
                tenBN = txtTimten.Text
            });
        WorkingServices.ConvertColumnNameToLower_Upper(dataDSBenhNhan, true);
            gcChiTiet.DataSource = dataDSBenhNhan;
            gvChiTiet.ExpandAllGroups();
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTimBenhNhanTheoNgay_Load(object sender, EventArgs e)
        {
            foreach (GridColumn item in gvChiTiet.Columns)
            {
                item.OptionsColumn.ReadOnly = true;
                item.OptionsColumn.AllowEdit = false;
                item.FieldName = item.FieldName.ToLower().Trim();
            }
        }

        private void txtTimten_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TimBenhNhan();
                e.Handled = true;
            }
        }

        private void dtpNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TimBenhNhan();
                e.Handled = true;
            }
        }

        private void btnLayThongTin_Click(object sender, EventArgs e)
        {
            if (gvChiTiet.GetFocusedRowCellValue(colChiTiet_Barcode) != null)
            {
                MaTiepNhan = gvChiTiet.GetFocusedRowCellValue(colChiTiet_MaTiepNhan).ToString();
                Barcode = gvChiTiet.GetFocusedRowCellValue(colChiTiet_Barcode).ToString();
                SoPhieuYeuCau = gvChiTiet.GetFocusedRowCellValue(colChiTiet_SoPhieuYeuCau).ToString();
                SoHoSo = gvChiTiet.GetFocusedRowCellValue(colChiTiet_SoHoSo).ToString();
                MaBenhNhan = gvChiTiet.GetFocusedRowCellValue(colChiTiet_MaBN).ToString();
                this.Close();
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Chưa có thông tin nào được chọn.");
            }
        }

        private void FrmTimBenhNhanTheoNgay_Shown(object sender, EventArgs e)
        {
            TimBenhNhan();
        }
    }
}
