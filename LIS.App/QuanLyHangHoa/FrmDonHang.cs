using System;
using TPH.Common.Converter;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.Product.Model;
using TPH.Product.Services;

namespace TPH.LIS.App.QuanLyHangHoa
{
    public partial class FrmDonHang : FrmTemplateCommon
    {
        public FrmDonHang()
        {
            InitializeComponent();
        }
        private readonly IProductService _iProduct = new ProductService();

        private void btnTaoDH_Click(object sender, EventArgs e)
        {
            txtOrderCode.Text = _iProduct.GetInputCode(dtpNgayTao.Value, "DH.", "TBL_Order", "OrderCode");
        }

        private void btnSuaDH_Click(object sender, EventArgs e)
        {
            SuaDH();
            LoadLuoiCTDH();
        }
        private void SuaDH()
        {
            var model = new OrderModel();
            model.OrderCode = txtOrderCode.Text.Trim();
            model.DateOrder = dtpNgayTao.Value;
            model.UserI = StringConverter.ToString(ucSearchLookupEditor_NhanVien1.SelectedValue);
            model.HinhThucThanhToan = txtHTTT.Text;
            model.GhiChu = txtGhiChu.Text;
            model.DiaChi = txtDiaChi.Text;
            model.TenKhachHang = txtTenKH.Text;
            model.DienThoai = txtPhone.Text;
            if (string.IsNullOrEmpty(model.OrderCode))
            {
                return;
            }
            if (_iProduct.SuaDonHang(model))
                CustomMessageBox.MSG_Information_OK("Sửa đơn hàng thành công!");


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
            OrderModel model = new OrderModel();
            model.OrderCode = txtMaDHTK.Text.Trim();
            model.FromDate = dtpFromDate.Value;
            model.ToDate = dtpToDate.Value;
            model.UserI = StringConverter.ToString(ucSearchLookupEditor_NhanVien2.SelectedValue);
            gcDSDH.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(_iProduct.GetDonHang(model), true);
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
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Bạn muốn xóa đơn hàng?"))
            {
                OrderModel model = new OrderModel();
                model.OrderCode = txtOrderCode.Text.Trim();
                _iProduct.XoaDonHang(model);
            }
        }

        private void LuuThongTin()
        {
            OrderModel model = new OrderModel();
            model.OrderCode = txtOrderCode.Text.Trim();
            model.DateOrder = dtpNgayTao.Value;
            model.UserI = StringConverter.ToString(ucSearchLookupEditor_NhanVien1.SelectedValue);
            model.HinhThucThanhToan = txtHTTT.Text;
            model.GhiChu = txtGhiChu.Text;
            model.DiaChi = txtDiaChi.Text;
            model.TenKhachHang = txtTenKH.Text;
            model.DienThoai = txtPhone.Text;
            if (string.IsNullOrEmpty(model.UserI))
            {
                CustomMessageBox.MSG_Information_OK("Chọn tên người nhập!");
                return;
            }
            if (_iProduct.ThemDonHang(model))
                CustomMessageBox.MSG_Information_OK("Thêm đơn hàng thành công!");



        }
        private void LoadLuoiCTDH()
        {
            gcDH.DataSource = null;
            OrderDetailModel model = new OrderDetailModel();
            model.OrderID = NumberConverter.ToInt(txtOrderID.Text);
            model.OrderCode = StringConverter.ToString(txtOrderCode.Text);
            if (model.OrderID<=0 &&string.IsNullOrEmpty(model.OrderCode))
                return;

            gcDH.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(_iProduct.GetDonHang_CT(model), true);


        }

        private void ucSearchLookupEditor_DanhMucHangHoa1_EditValueChanged(object sender, EventArgs e)
        {
            var madm = StringConverter.ToString(ucSearchLookupEditor_DanhMucHangHoa1.SelectedValue);
            ucSearchLookupEditor_HangHoaSanPham1.Load_SanPham(string.Empty, madm);
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            ThemDH_CT();
            LoadLuoiCTDH();
        }
        private void ThemDH_CT()
        {
            OrderDetailModel model = new OrderDetailModel();
            model.OrderCode = StringConverter.ToString(txtOrderCode.Text);
            model.ItemCode = StringConverter.ToString(ucSearchLookupEditor_HangHoaSanPham1.SelectedValue);
            model.Quantity = NumberConverter.ToInt(txtQuantity.Text);
            if (!WorkingServices.IsNumeric(model.Quantity))
                return;
            if (model.Quantity <= 0)
                return;

            _iProduct.ThemDonHang_CT(model);
        }

        private void gvDSDH_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (gvDSDH.RowCount <= 0)
                return;
            var orderid = NumberConverter.ToInt(gvDSDH.GetFocusedRowCellValue(colOrderID));
            var model = new OrderDetailModel { OrderID = orderid };
            gcDSDH_CT.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(_iProduct.GetDonHang_CT(model), true);
        }

        private void txtSearchMaDH_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // Enter key pressed
                ClearInput();
                ClearInputDetail();
                var dtDH = _iProduct.GetDonHang(new OrderModel() { OrderCode = txtSearchMaDH.Text.Trim() });
                if (dtDH == null || dtDH.Rows.Count <= 0)
                    return;

                var orderid = NumberConverter.ToInt(dtDH.Rows[0]["orderid"]);
                txtOrderID.Text = orderid.ToString();
                txtOrderCode.Text = StringConverter.ToString(dtDH.Rows[0]["ordercode"]);
                txtTenKH.Text = StringConverter.ToString(dtDH.Rows[0]["TenKhachHang"]);
                txtPhone.Text = StringConverter.ToString(dtDH.Rows[0]["DienThoai"]);
                txtDiaChi.Text = StringConverter.ToString(dtDH.Rows[0]["DiaChi"]);
                txtHTTT.Text = StringConverter.ToString(dtDH.Rows[0]["HinhThucThanhToan"]);
                txtGhiChu.Text = StringConverter.ToString(dtDH.Rows[0]["GhiChu"]);
                txtThoiGianTao.Text = StringConverter.ToString(dtDH.Rows[0]["DateOrder"]);
                txtTotal.Text = StringConverter.ToString(dtDH.Rows[0]["Total"]);
                ucSearchLookupEditor_NhanVien1.SelectedValue = StringConverter.ToString(dtDH.Rows[0]["UserI"]); ;

                gcDH.DataSource = WorkingServices.ConvertColumnNameToLower_Upper
                    (_iProduct.GetDonHang_CT(new OrderDetailModel() { OrderID = orderid }), true);
            }
        }
        private void ClearInput()
        {
            txtOrderCode.Text = string.Empty;
            txtTenKH.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtHTTT.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            txtThoiGianTao.Text = string.Empty;
            txtTenKH.Text = string.Empty;
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
            var model = new OrderDetailModel { AutoID = id };
            _iProduct.XoaDonHang_CT(model);

        }

        private void txtSearchMaDH_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
