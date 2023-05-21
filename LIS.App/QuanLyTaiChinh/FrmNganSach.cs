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
    public partial class FrmNganSach : FrmTemplateCommon
    {
        public FrmNganSach()
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

        private void FrmNganSach_Load(object sender, EventArgs e)
        {
            LoadLuoiTSCD();
            LoadLuoiTSCD2();

        }

        private void txtSearchMaNS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                LoadLuoiTSCD(txtSearchMaNS.Text.Trim());
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
            Excel.ExportToExcel.Export(gcTSCD2, string.Format("DanhSachNganSach_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")));
        }

        private void XoaItem()
        {
            if (gvTSCD1.RowCount <= 0)
                return;
            var mats = StringConverter.ToString(gvTSCD1.GetFocusedRowCellValue(colMaNS));
            var model = new NganSachModel { MaNganSach = mats };
            _iFinance.XoaNganSach(model);
        }
        private void LoadLuoiTSCD(string maTS = "")
        {
            gcTSCD1.DataSource = null;
            gcTSCD1.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(_iFinance.GetDS_NganSach(new NganSachModel() { MaNganSach = maTS }), true);
        }
        private void LoadLuoiTSCD2()
        {
            gcTSCD2.DataSource = null;
            gcTSCD2.DataSource = WorkingServices.ConvertColumnNameToLower_Upper
                (_iFinance.GetDS_NganSach(new NganSachModel() { MaNganSach = txtMaNSTK.Text.Trim() }), true);
        }
        private void LuuThongTin()
        {
            if (!WorkingServices.IsNumeric(txtTienMatHienCo.Text)
                || !WorkingServices.IsNumeric(txtNguonVonBank.Text)
                || !WorkingServices.IsNumeric(txtTienHangKho.Text)
                || !WorkingServices.IsNumeric(txtDTDB.Text)
                || !WorkingServices.IsNumeric(txtNganSachNH.Text)
                )
                return;
            NganSachModel model = new NganSachModel();
            model.MaNganSach = txtMaNS.Text.Trim();
            model.TienMatHienCo = NumberConverter.ToDecimal(txtTienMatHienCo.Text);
            model.NguonVonBank = NumberConverter.ToDecimal(txtNguonVonBank.Text);
            model.TienHangKho = NumberConverter.ToDecimal(txtTienHangKho.Text);
            model.DoanhThuDaBan = NumberConverter.ToDecimal(txtDTDB.Text);
            model.NganSachNhapHang = NumberConverter.ToDecimal(txtNganSachNH.Text);
            _iFinance.ThemNganSach(model);
        }

        private void SuaItem(DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            NganSachModel model = new NganSachModel();
            model.MaNganSach = StringConverter.ToString(gvTSCD1.GetRowCellValue(e.RowHandle, colMaNS));
            model.TienMatHienCo = NumberConverter.ToDecimal(gvTSCD1.GetRowCellValue(e.RowHandle, colTienMatHienCo));
            model.NguonVonBank = NumberConverter.ToDecimal(gvTSCD1.GetRowCellValue(e.RowHandle, colNguonVonBank));
            model.TienHangKho = NumberConverter.ToDecimal(gvTSCD1.GetRowCellValue(e.RowHandle, colTienHangKho));
            model.DoanhThuDaBan = NumberConverter.ToDecimal(gvTSCD1.GetRowCellValue(e.RowHandle, colDTDB));
            model.NganSachNhapHang = NumberConverter.ToDecimal(gvTSCD1.GetRowCellValue(e.RowHandle, colNganSachNH));
            _iFinance.SuaNganSach(model);
        }
    }
}
