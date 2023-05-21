using DevExpress.Office.Drawing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.Language;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.Product.Model;
using TPH.Product.Services;

namespace TPH.LIS.App.QuanLyTaiChinh
{
    public partial class FrmHopDong : FrmTemplateCommon
    {
        public FrmHopDong()
        {
            InitializeComponent();
        }
        private readonly IFinanceService _iFinance = new FinanceService();

        private void FrmHopDong_Load(object sender, EventArgs e)
        {
            LoadLuoiTSCD();
            LoadLuoiTSCD2();
        }

        private void gvTSCD2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
     
        }

        private void btnTimKiemTSCD_Click(object sender, EventArgs e)
        {
            LoadLuoiTSCD2();
        }

        private void txtSearchMaHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                LoadLuoiTSCD(txtSearchMaHD.Text.Trim());
            }
        }

        private void btnThemItem_Click_1(object sender, EventArgs e)
        {
            LuuThongTin();
            LoadLuoiTSCD();
        }

        private void btnXoaItem_Click_1(object sender, EventArgs e)
        {
            XoaItem();
            LoadLuoiTSCD();
        }

        private void btnRefreshItem_Click_1(object sender, EventArgs e)
        {
            LoadLuoiTSCD();
        }

        private void XoaItem()
        {
            if (gvTSCD1.RowCount <= 0)
                return;
            var mats = StringConverter.ToString(gvTSCD1.GetFocusedRowCellValue(colMaHD));
            var model = new HopDongModel { MaHopDong = mats };
            _iFinance.XoaHD(model);
        }
        private void LoadLuoiTSCD(string maTS = "")
        {
            gcTSCD1.DataSource = null;
            gcTSCD1.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(_iFinance.GetDS_HD(new HopDongModel() { MaHopDong = maTS }), true);
        }
        private void LoadLuoiTSCD2()
        {
            gcTSCD2.DataSource = null;
            gcTSCD2.DataSource = WorkingServices.ConvertColumnNameToLower_Upper
                (_iFinance.GetDS_HD(new HopDongModel() { MaHopDong = txtMaHDTK.Text.Trim() }), true);
        }
        private void LuuThongTin()
        {
            HopDongModel model = new HopDongModel();
            model.MaHopDong = txtMaHD.Text.Trim();
            model.NoiDung = txtNoiDung.Text;
            model.TinhTrang = txtTT.Text;
            model.GhiChu = txtGhiChu.Text;
            model.ThoiGianKetThuc = dtpTGKTHD.Value;
            model.ThoiGianKyKet = dtpTGKK.Value;
            model.ThoiGianThucHien = dtpTGTH.Value;
            _iFinance.ThemHD(model);
        }

        private void SuaItem(DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            HopDongModel model = new HopDongModel();
            model.MaHopDong = StringConverter.ToString(gvTSCD1.GetRowCellValue(e.RowHandle, colMaHD));
            model.NoiDung = StringConverter.ToString(gvTSCD1.GetRowCellValue(e.RowHandle, colNoiDung));
            model.TinhTrang = StringConverter.ToString(gvTSCD1.GetRowCellValue(e.RowHandle, colTinhTrang));
            model.GhiChu = StringConverter.ToString(gvTSCD1.GetRowCellValue(e.RowHandle, colGhiChu));
            model.ThoiGianKyKet = DateTimeConverter.ToDateTime(gvTSCD1.GetRowCellValue(e.RowHandle, colTGKK));
            model.ThoiGianKetThuc = DateTimeConverter.ToDateTime(gvTSCD1.GetRowCellValue(e.RowHandle, colTGKT));
            model.ThoiGianThucHien = DateTimeConverter.ToDateTime(gvTSCD1.GetRowCellValue(e.RowHandle, colTGTH));

            _iFinance.SuaHD(model);
        }

        private void gvTSCD1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle > -1)
            {
                SuaItem(e);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportToExcel.Export(gcTSCD2, string.Format("DanhSachHopDong_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")));

        }
    }
}
