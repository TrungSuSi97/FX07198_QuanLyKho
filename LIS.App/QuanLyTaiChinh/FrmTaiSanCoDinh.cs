using System;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.Language;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.Product.Model;
using TPH.Product.Services;

namespace TPH.LIS.App.QuanLyTaiChinh
{
    public partial class FrmTaiSanCoDinh : FrmTemplateCommon
    {
        public FrmTaiSanCoDinh()
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
        private void XoaItem()
        {
            if (gvTSCD1.RowCount <= 0)
                return;
            var mats = StringConverter.ToString(gvTSCD1.GetFocusedRowCellValue(colMaTS));
            var model = new TaiSanCdModel { MaTaiSan = mats };
            _iFinance.XoaTSCD(model);
        }
        private void LoadLuoiTSCD(string maTS = "")
        {
            gcTSCD1.DataSource = null;
            gcTSCD1.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(_iFinance.GetDS_TSCD(new TaiSanCdModel() { MaTaiSan = maTS }), true);
        }
        private void LoadLuoiTSCD2()
        {
            gcTSCD2.DataSource = null;
            gcTSCD2.DataSource = WorkingServices.ConvertColumnNameToLower_Upper
                (_iFinance.GetDS_TSCD(new TaiSanCdModel() { MaTaiSan = txtMaDHTK.Text.Trim() }), true);
        }
        private void LuuThongTin()
        {
            if (!WorkingServices.IsNumeric(txtQuantity.Text) || NumberConverter.ToInt(txtQuantity.Text) <= 0)
            {
                CustomMessageBox.MSG_Information_OK(LanguageExtension.GetResourceValueFromKey("VuilongchonsoluongCHAMCAM", LanguageExtension.AppLanguage));
                return;
            }
            TaiSanCdModel model = new TaiSanCdModel();
            model.MaTaiSan = txtMaTS.Text.Trim();
            model.TenTaiSan = txtTenTS.Text;
            model.Quantity = NumberConverter.ToInt(txtQuantity.Text);
            model.TinhTrang = txtTT.Text;
            model.DonViSuDung = txtDVSD.Text;

            _iFinance.ThemTSCD(model);
            //CustomMessageBox.MSG_Information_OK("Thêm TSCD thành công!");

        }

        private void SuaItem(DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            TaiSanCdModel model = new TaiSanCdModel();
            model.MaTaiSan = StringConverter.ToString(gvTSCD1.GetRowCellValue(e.RowHandle, colMaTS));
            model.TenTaiSan = StringConverter.ToString(gvTSCD1.GetRowCellValue(e.RowHandle, colTenTS));
            model.Quantity = NumberConverter.ToInt(gvTSCD1.GetRowCellValue(e.RowHandle, colQuantity));
            model.TinhTrang = StringConverter.ToString(gvTSCD1.GetRowCellValue(e.RowHandle, colTinhTrang));
            model.DonViSuDung = StringConverter.ToString(gvTSCD1.GetRowCellValue(e.RowHandle, colDonViSD));
            _iFinance.SuaTSCD(model);
        }
        private void btnTimKiemTSCD_Click(object sender, EventArgs e)
        {
            LoadLuoiTSCD2();
        }

        private void gvTSCD1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle > -1)
            {
                SuaItem(e);
            }
        }

        private void FrmTaiSanCoDinh_Load(object sender, EventArgs e)
        {
            LoadLuoiTSCD();
            LoadLuoiTSCD2();

        }

        private void txtSearchMaTS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                LoadLuoiTSCD(txtMaTS.Text.Trim());
            }
        }


    }
}
