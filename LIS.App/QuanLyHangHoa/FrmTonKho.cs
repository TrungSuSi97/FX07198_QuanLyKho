using System;
using TPH.Common.Converter;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.Product.Model;
using TPH.Product.Services;

namespace TPH.LIS.App.QuanLyHangHoa
{
    public partial class FrmTonKho : FrmTemplateCommon
    {
        public FrmTonKho()
        {
            InitializeComponent();
        }
        private readonly IProductService _iProduct = new ProductService();

        private void btnTaoDH_Click(object sender, EventArgs e)
        {
            ClearInput();
            ClearInputDetail();

        }

        private void btnSuaDH_Click(object sender, EventArgs e)
        {
            SuaDH();
            LoadLuoiCTDH();
        }
        private void SuaDH()
        {
    


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
            TonkhoModel model = new TonkhoModel();
            model.FromDate = dtpFromDate.Value;
            model.ToDate = dtpToDate.Value;
            model.ItemCode = StringConverter.ToString(ucSearchLookupEditor_HangHoaSanPham1.SelectedValue);
            model.MaDanhMuc = StringConverter.ToString(ucSearchLookupEditor_DanhMucHangHoa1.SelectedValue);

            gcDSDH.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(_iProduct.GetTonKho(model), true);
        }
        private void Load_NhanVien()
        {


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

        }

        private void LuuThongTin()
        {


        }
        private void LoadLuoiCTDH()
        {


        }

        private void ucSearchLookupEditor_DanhMucHangHoa1_EditValueChanged(object sender, EventArgs e)
        {
  
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
  
        }
        private void ThemDH_CT()
        {

        }
        private void gvDSDH_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
           
        }

        private void txtSearchMaDH_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

            }
        }
        private void ClearInput()
        {
        

        }
        private void ClearInputDetail()
        {
         

        }
        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            XoaSP();
            LoadLuoiCTDH();
        }
        private void XoaSP()
        {
         

        }

        private void txtSearchMaDH_TextChanged(object sender, EventArgs e)
        {

        }

        private void ucSearchLookupEditor_DanhMucHangHoa1_EditValueChanged_1(object sender, EventArgs e)
        {
            var madm = StringConverter.ToString(ucSearchLookupEditor_DanhMucHangHoa1.SelectedValue);
            ucSearchLookupEditor_HangHoaSanPham1.Load_SanPham(string.Empty, madm);
        }
    }
}
