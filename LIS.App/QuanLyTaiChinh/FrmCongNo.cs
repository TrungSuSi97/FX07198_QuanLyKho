using DevExpress.Charts.Native;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.LIS.Common.Extensions;
using TPH.Product.Model;
using TPH.Product.Services;

namespace TPH.LIS.App.QuanLyTaiChinh
{
    public partial class FrmCongNo : FrmTemplateCommon
    {
        public FrmCongNo()
        {
            InitializeComponent();
        }
        private readonly IFinanceService _iFinance = new FinanceService();

        private void btnThemItem_Click(object sender, EventArgs e)
        {
            LuuThongTin();
            LoadLuoiTSCD();
        }

        private void btnXoaItem_Click(object sender, EventArgs e)
        {
            XoaItem();
            LoadLuoiTSCD();

        }

        private void btnRefreshItem_Click(object sender, EventArgs e)
        {
            LoadLuoiTSCD();
        }

        private void txtSearchMaCN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                LoadLuoiTSCD(txtSearchMaCN.Text.Trim());
            }
        }

        private void gvTSCD1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle > -1)
            {
                SuaItem(e);
            }
        }

        private void btnTimKiemTSCD_Click(object sender, EventArgs e)
        {
            LoadLuoiTSCD2();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportToExcel.Export(gcTSCD2, string.Format("DanhSachCongNo_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")));
        }

        private void XoaItem()
        {
            if (gvTSCD1.RowCount <= 0)
                return;
            var mats = StringConverter.ToString(gvTSCD1.GetFocusedRowCellValue(colMaCN));
            var model = new CongNoModel { MaCongNo = mats };
            _iFinance.XoaCN(model);
        }
        private void LoadLuoiTSCD(string maTS = "")
        {
            gcTSCD1.DataSource = null;
            gcTSCD1.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(_iFinance.GetDS_CN(new CongNoModel() { MaCongNo = maTS }), true);
        }
        private void LoadLuoiTSCD2()
        {
            gcTSCD2.DataSource = null;
            gcTSCD2.DataSource = WorkingServices.ConvertColumnNameToLower_Upper
                (_iFinance.GetDS_CN(new CongNoModel() { MaCongNo = txtMaCNTK.Text.Trim() }), true);
        }
        private void LuuThongTin()
        {
            if (!WorkingServices.IsNumeric(txtCNPT.Text))
                return;
            CongNoModel model = new CongNoModel();
            model.MaCongNo = txtMaCN.Text.Trim();
            model.LoaiHoaDon = txtLoaiHD.Text;
            model.MaHoaDon = txtMaHDCN.Text;
            model.ThongTinKhachHang = txtTTKH.Text;
            model.CongNoPhaiTra = NumberConverter.ToDecimal(txtCNPT.Text);
            model.ThoiHanTra = dtpTHPT.Value;
            _iFinance.ThemCN(model);
        }

        private void SuaItem(DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            CongNoModel model = new CongNoModel();
            model.MaCongNo = StringConverter.ToString(gvTSCD1.GetRowCellValue(e.RowHandle, colMaCN));
            model.LoaiHoaDon = StringConverter.ToString(gvTSCD1.GetRowCellValue(e.RowHandle, colLoaiHoaDon));
            model.MaHoaDon = StringConverter.ToString(gvTSCD1.GetRowCellValue(e.RowHandle, colMaHoaDon));
            model.ThongTinKhachHang = StringConverter.ToString(gvTSCD1.GetRowCellValue(e.RowHandle, colTTKH));
            model.ThoiHanTra = DateTimeConverter.ToDateTime(gvTSCD1.GetRowCellValue(e.RowHandle, colTGTra));
            model.CongNoPhaiTra = NumberConverter.ToDecimal(gvTSCD1.GetRowCellValue(e.RowHandle, colCongNoPT));

            _iFinance.SuaCN(model);
        }
    }
}
