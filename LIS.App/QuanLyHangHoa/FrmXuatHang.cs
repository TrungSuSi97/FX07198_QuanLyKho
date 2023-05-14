using System;
using System.Data;
using TPH.Common.Converter;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.Product.Model;
using TPH.Product.Services;

namespace TPH.LIS.App.QuanLyHangHoa
{
    public partial class FrmXuatHang : FrmTemplateCommon
    {
        public FrmXuatHang()
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
                CustomMessageBox.MSG_Information_OK("Sửa nhập hàng thành công!");


        }
        private void FrmDonHang_Load(object sender, EventArgs e)
        {
            Load_NhanVien();
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
            OutputModel model = new OutputModel();
            model.OutCode = txtMaDHTK.Text.Trim();
            model.FromDate = dtpFromDate.Value;
            model.ToDate = dtpToDate.Value;
            model.UserI = StringConverter.ToString(ucSearchLookupEditor_NhanVien2.SelectedValue);
            gcDSDH.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(_iProduct.GetXuatHang(model), true);
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

        private void XoaDH()
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Bạn muốn xóa nhập hàng?"))
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
                CustomMessageBox.MSG_Information_OK("Chọn tên người nhập!");
                return;
            }
            if (_iProduct.ThemNhapKho(model))
                CustomMessageBox.MSG_Information_OK("Thêm nhập hàng thành công!");



        }
        private void LoadLuoiCTDH()
        {
            gcDH.DataSource = null;
            InputDetailModel model = new InputDetailModel();
            model.InID = NumberConverter.ToInt(txtOrderID.Text);
            model.InCode = StringConverter.ToString(txtOrderCode.Text);
            if (model.InID <= 0 && string.IsNullOrEmpty(model.InCode))
                return;

            gcDH.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(_iProduct.GetNhapKho_CT(model), true);


        }

        private void ucSearchLookupEditor_DanhMucHangHoa1_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            //ThemDH_CT();
            //LoadLuoiCTDH();
            XuatHang();
        }
        private void XuatHang()
        {
            if (string.IsNullOrEmpty(txtOrderCode.Text))
                return;
            if (chkDaXH.Checked)
            {
                CustomMessageBox.MSG_Information_OK("Đơn hàng này đã xuất, không thể xuất nữa!");
                return;
            }
            //kiểm tra có đủ hàng không
            var dt = _iProduct.CheckDuHangTrongKho(txtOrderCode.Text.Trim());
            if (dt != null && dt.Rows.Count > 0)
            {
                string mess = "Không xuất được đơn này:";
                foreach (DataRow item in dt.Rows)
                {
                    mess += $"\nSản phẩm: {item["ItemName"]} còn {item["QuantityInput"]}";
                }
                CustomMessageBox.MSG_Information_OK(mess);
                return;
            }
            //nếu đủ hàng thì xuất và cập nhật đã xuát hàng cho đơn
            var outcode = _iProduct.GetInputCode(dtpNgayTao.Value, "XH.", "TBL_Output", "OutCode");
            var orderCode = txtOrderCode.Text.Trim();
            //tạo đơn xuất
            _iProduct.ThemXuatKho(new OutputModel() { OutCode = outcode, UserI = CommonAppVarsAndFunctions.UserID });
            //lay du lieu ra de xy ly
            var dtXuLy = _iProduct.GetXuatKho_CT_TheoDonHang(orderCode, outcode);
            if (dtXuLy == null || dtXuLy.Rows.Count <= 0)
                return;
            var dtItemCodeDis = WorkingServices.DataTable_DistinctValue(dtXuLy, "ItemCode");
            foreach (DataRow item in dtItemCodeDis.Rows)
            {
                var dtNhap = WorkingServices.SearchResult_OnDatatable(dtXuLy, string.Format("ItemCode = '{0}'", item["ItemCode"]));
                for (int i = 0; i < dtNhap.Rows.Count; i++)
                {
                    int quantity = NumberConverter.ToInt(dtNhap.Rows[i]["QuantityOrder"])
                        - NumberConverter.ToInt(dtNhap.Rows[i]["QuantityInput"]);
                    OutputDetailModel model = new OutputDetailModel();
                    model.OutID = NumberConverter.ToInt(dtNhap.Rows[i]["OutID"]);
                    model.InID = NumberConverter.ToInt(dtNhap.Rows[i]["InID"]);
                    model.ItemCode = StringConverter.ToString(dtNhap.Rows[i]["ItemCode"]);
                    model.Quantity = NumberConverter.ToInt(dtNhap.Rows[i]["OutID"]);
                    model.OrderDetailid = NumberConverter.ToInt(dtNhap.Rows[i]["OrderDetailid"]);

                    if (quantity <= 0)
                    {
                        model.Quantity = NumberConverter.ToInt(dtNhap.Rows[i]["QuantityOrder"]);
                        _iProduct.ThemXuatKho_CT(model);
                        //cap nhat lại so luong nhap kho
                        _iProduct.SuaNhapKho_CT_XuatHang(new InputDetailModel()
                        { InID = model.InID, ItemCode = model.ItemCode, QuantityOut = model.Quantity });
                        break;
                    }
                    else
                    {
                        model.Quantity = NumberConverter.ToInt(dtNhap.Rows[i]["QuantityInput"]);
                        _iProduct.ThemXuatKho_CT(model);
                        //cap nhat lại nhap kho
                        //cap nhat lại so luong nhap kho
                        _iProduct.SuaNhapKho_CT_XuatHang(new InputDetailModel()
                        { InID = model.InID, ItemCode = model.ItemCode, QuantityOut = model.Quantity });
                        dtNhap.Rows[i++]["QuantityOrder"] = quantity;
                    }
                }
            }
            //cap nhat don hàng da xuat
            _iProduct.CapNhatDhDaXuat(new OrderModel() { OrderCode = orderCode });
            CustomMessageBox.MSG_Information_OK("Xuất đơn hàng thành công!");
            bindingdata();
        }
        private void ThemDH_CT()
        {
            InputDetailModel model = new InputDetailModel();
            model.InCode = StringConverter.ToString(txtOrderCode.Text);

            if (string.IsNullOrEmpty(model.ItemCode))
                return;

            _iProduct.ThemNhapKho_CT(model);
        }

        private void gvDSDH_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (gvDSDH.RowCount <= 0)
                return;
            var orderid = NumberConverter.ToInt(gvDSDH.GetFocusedRowCellValue(colOutID));
            var model = new OutputDetailModel { OutID = orderid };
            gcDSDH_CT.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(_iProduct.GetXuatHang_CT(model), true);
        }

        private void txtSearchMaDH_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // Enter key pressed
                bindingdata();
            }
        }
        private void bindingdata() 
        {
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
            ucSearchLookupEditor_NhanVien1.SelectedValue = StringConverter.ToString(dtDH.Rows[0]["UserI"]);
            chkDaXH.Checked = NumberConverter.ToBool(dtDH.Rows[0]["isDaXuatHang"]);

            gcDH.DataSource = WorkingServices.ConvertColumnNameToLower_Upper
                (_iProduct.GetDonHang_CT(new OrderDetailModel() { OrderID = orderid }), true);

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
