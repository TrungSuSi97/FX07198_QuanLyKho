using System;
using TPH.Common.Converter;
using TPH.Language;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.Product.Model;
using TPH.Product.Services;

namespace TPH.LIS.App.QuanLyHangHoa
{
    public partial class FrmNhapHang : FrmTemplateCommon
    {
        public FrmNhapHang()
        {
            InitializeComponent();
        }
        private readonly IProductService _iProduct = new ProductService();

        private void btnTaoDH_Click(object sender, EventArgs e)
        {
            ClearInput();
            ClearInputDetail();
            txtOrderCode.Text = _iProduct.GetInputCode(dtpNgayTao.Value, "NH.", "TBL_Input", "InCode");

        }

        private void btnSuaDH_Click(object sender, EventArgs e)
        {
            SuaDH();
            LoadLuoiCTDH();
        }
        private void SuaDH()
        {
            var model = new InputModel();
            model.InCode = txtOrderCode.Text.Trim();
            model.DateIn = dtpNgayTao.Value;
            model.UserI = StringConverter.ToString(ucSearchLookupEditor_NhanVien1.SelectedValue);
            if (string.IsNullOrEmpty(model.InCode))
            {
                return;
            }
            if (_iProduct.SuaNhapKho(model))
                CustomMessageBox.MSG_Information_OK(LanguageExtension.GetResourceValueFromKey("SuanhaphangthanhcongCHAMCAM", LanguageExtension.AppLanguage));


        }
        private void FrmDonHang_Load(object sender, EventArgs e)
        {
            Load_NhanVien();
            Load_DanhMuc();
            Load_SP(string.Empty, string.Empty);
            TimKiem();
        }
        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            LuuThongTin();
            LoadLuoiCTDH();
        }

        private void btnXoaDH_Click(object sender, EventArgs e)
        {
            XoaDH();
            ClearInput();
            ClearInputDetail();
        }

        private void btnTimKiemDSDH_Click(object sender, EventArgs e)
        {
            TimKiem();
        }
        private void TimKiem()
        {
            gcDSDH.DataSource = null;
            gcDSDH_CT.DataSource = null;
            InputModel model = new InputModel();
            model.InCode = txtMaDHTK.Text.Trim();
            model.FromDate = dtpFromDate.Value;
            model.ToDate = dtpToDate.Value;
            model.UserI = StringConverter.ToString(ucSearchLookupEditor_NhanVien2.SelectedValue);
            gcDSDH.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(_iProduct.GetNhapKho(model), true);
        }
        private void Load_NhanVien()
        {
            ucSearchLookupEditor_NhanVien1.Load_NhanVien();
            ucSearchLookupEditor_NhanVien1.CatchEnterKey = true;
            ucSearchLookupEditor_NhanVien1.CatchTabKey = true;

            ucSearchLookupEditor_NhanVien2.Load_NhanVien();
            ucSearchLookupEditor_NhanVien2.CatchEnterKey = true;
            ucSearchLookupEditor_NhanVien2.CatchTabKey = true;
        }
        private void Load_DanhMuc()
        {
            ucSearchLookupEditor_DanhMucHangHoa1.Load_DanhMucHH();
            ucSearchLookupEditor_DanhMucHangHoa1.CatchEnterKey = true;
            ucSearchLookupEditor_DanhMucHangHoa1.CatchTabKey = true;
        }
        private void Load_SP(string itemcode, string madanhmuc)
        {
            ucSearchLookupEditor_HangHoaSanPham1.Load_SanPham(string.Empty, string.Empty);
            ucSearchLookupEditor_HangHoaSanPham1.CatchEnterKey = true;
            ucSearchLookupEditor_HangHoaSanPham1.CatchTabKey = true;
        }
        private void XoaDH()
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes(LanguageExtension.GetResourceValueFromKey("BanmuonxoanhaphangHOI", LanguageExtension.AppLanguage)))
            {
                InputModel model = new InputModel();
                model.InCode = txtOrderCode.Text.Trim();
                _iProduct.XoaNhapKho(model);
            }
        }

        private void LuuThongTin()
        {
            InputModel model = new InputModel();
            model.InCode = txtOrderCode.Text.Trim();
            model.DateIn = dtpNgayTao.Value;
            model.UserI = StringConverter.ToString(ucSearchLookupEditor_NhanVien1.SelectedValue);
            if (string.IsNullOrEmpty(model.UserI))
            {
                CustomMessageBox.MSG_Information_OK(LanguageExtension.GetResourceValueFromKey("ChontennguoinhapCHAMCAM", LanguageExtension.AppLanguage));
                return;
            }
            if (_iProduct.ThemNhapKho(model))
                CustomMessageBox.MSG_Information_OK(LanguageExtension.GetResourceValueFromKey("ThemnhaphangthanhcongCHAMCAM", LanguageExtension.AppLanguage));



        }
        private void LoadLuoiCTDH()
        {
            gcDH.DataSource = null;
            InputDetailModel model = new InputDetailModel();
            model.InID = NumberConverter.ToInt(txtOrderID.Text);
            model.InCode = StringConverter.ToString(txtOrderCode.Text);
            if (model.InID <= 0 &&string.IsNullOrEmpty(model.InCode))
                return;

            gcDH.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(_iProduct.GetNhapKho_CT(model), true);


        }

        private void ucSearchLookupEditor_DanhMucHangHoa1_EditValueChanged(object sender, EventArgs e)
        {
            var madm = StringConverter.ToString(ucSearchLookupEditor_DanhMucHangHoa1.SelectedValue);
            ucSearchLookupEditor_HangHoaSanPham1.Load_SanPham(string.Empty, madm);
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(StringConverter.ToString(ucSearchLookupEditor_HangHoaSanPham1.SelectedValue)))
                return;
            ThemDH_CT();
            LoadLuoiCTDH();
        }
        private void ThemDH_CT()
        {
            InputDetailModel model = new InputDetailModel();
            model.InCode = StringConverter.ToString(txtOrderCode.Text);
            model.ItemCode = StringConverter.ToString(ucSearchLookupEditor_HangHoaSanPham1.SelectedValue);
            model.Quantity = NumberConverter.ToInt(txtQuantity.Text);
            if (!WorkingServices.IsNumeric(model.Quantity))
                return;
            if (model.Quantity <= 0)
                return;
            if (string.IsNullOrEmpty(model.ItemCode))
                return;

            _iProduct.ThemNhapKho_CT(model);
        }

        private void gvDSDH_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (gvDSDH.RowCount <= 0)
                return;
            var orderid = NumberConverter.ToInt(gvDSDH.GetFocusedRowCellValue(colInID));
            var model = new InputDetailModel { InID = orderid };
            gcDSDH_CT.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(_iProduct.GetNhapKho_CT(model), true);
        }

        private void txtSearchMaDH_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // Enter key pressed
                ClearInput();
                ClearInputDetail();
                var dtDH = _iProduct.GetNhapKho(new InputModel() { InCode = txtSearchMaDH.Text.Trim() });
                if (dtDH == null || dtDH.Rows.Count <= 0)
                    return;

                var InID = NumberConverter.ToInt(dtDH.Rows[0]["InID"]);
                txtOrderID.Text = InID.ToString();
                txtOrderCode.Text = StringConverter.ToString(dtDH.Rows[0]["InCode"]);

                txtThoiGianTao.Text = StringConverter.ToString(dtDH.Rows[0]["DateIn"]);
                txtTotal.Text = StringConverter.ToString(dtDH.Rows[0]["Total"]);
                ucSearchLookupEditor_NhanVien1.SelectedValue = StringConverter.ToString(dtDH.Rows[0]["UserI"]); ;

                gcDH.DataSource = WorkingServices.ConvertColumnNameToLower_Upper
                    (_iProduct.GetNhapKho_CT(new InputDetailModel() { InID = InID }), true);
            }
        }
        private void ClearInput()
        {
            txtOrderCode.Text = string.Empty;

            txtThoiGianTao.Text = string.Empty;

            txtTotal.Text = string.Empty;
            ucSearchLookupEditor_NhanVien1.SelectedValue = null;

        }
        private void ClearInputDetail()
        {
            gcDH.DataSource = null;
            ucSearchLookupEditor_DanhMucHangHoa1.SelectedValue = null;
            ucSearchLookupEditor_HangHoaSanPham1.SelectedValue = null;
            txtQuantity.Text = string.Empty;

        }
        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            XoaSP();
            LoadLuoiCTDH();
        }
        private void XoaSP()
        {
            if (gvDH.RowCount <= 0)
                return;
            var id = NumberConverter.ToInt(gvDH.GetFocusedRowCellValue(colID));
            var model = new InputDetailModel { AutoID = id };
            _iProduct.XoaNhapKho_CT(model);

        }

        private void txtSearchMaDH_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
