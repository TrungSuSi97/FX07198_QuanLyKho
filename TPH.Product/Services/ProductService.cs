using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;
using TPH.Product.Model;
using TPH.Product.Repositories;

namespace TPH.Product.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _iProduct = new ProductRepository();

        #region dm hàng hóa
        public bool ThemDM(string madm, string tendm)
        {
            return _iProduct.ThemDM(madm, tendm);
        }
        public bool XoaDM(string madm)
        { 
            return _iProduct.XoaDM(madm);
        }
        public bool SuaDM(string madm, string tendm)
        { 
            return _iProduct.SuaDM(madm,tendm);
        }
        public DataTable GetDMHH(string madm)
        { 
            return _iProduct.GetDMHH(madm);
        }


        #endregion

        #region dm đơn vị
        public bool ThemDonVi(string madv, string tendv)
        { 
            return _iProduct.ThemDonVi(madv, tendv);
        }
        public bool XoaDonVi(string madv)
        { 
            return _iProduct.XoaDonVi(madv);
        }
        public bool SuaDonVi(string madv, string tendv)
        { 
            return _iProduct.SuaDonVi(madv, tendv);
        }
        public DataTable GetDMDV(string madm)
        {
            return _iProduct.GetDMDV(madm);
        }
        #endregion

        #region hàng hóa
        public bool ThemItem(ItemModel model)
        {
            return _iProduct.ThemItem(model);

        }
        public bool XoaItem(ItemModel model)
        { 
            return _iProduct.XoaItem(model);

        }
        public bool SuaItem(ItemModel model)
        {
            return _iProduct.SuaItem(model);
        }
        public DataTable GetItems(ItemModel model)
        { 
            return _iProduct.GetItems(model);
        }

        #endregion

        #region đơn hàng
        public bool ThemDonHang(OrderModel model)
        {
            return _iProduct.ThemDonHang(model);


        }
        public bool XoaDonHang(OrderModel model)
        {
            return _iProduct.XoaDonHang(model);


        }
        public bool SuaDonHang(OrderModel model)
        {
            return _iProduct.SuaDonHang(model);

        }
        public bool CapNhatDhDaXuat(OrderModel model)
        { 
            return _iProduct.CapNhatDhDaXuat(model);
        }

        public DataTable GetDonHang(OrderModel model)
        {
            return _iProduct.GetDonHang(model);

        }

        #endregion

        #region chi tiết đơn hàng
        public bool ThemDonHang_CT(OrderDetailModel model)
        {
            return _iProduct.ThemDonHang_CT(model);
        }
        public bool XoaDonHang_CT(OrderDetailModel model)
        {
            return _iProduct.XoaDonHang_CT(model);
        }
        public bool SuaDonHang_CT(OrderDetailModel model)
        {
            return _iProduct.SuaDonHang_CT(model);
        }
        public DataTable GetDonHang_CT(OrderDetailModel model)
        {
            return _iProduct.GetDonHang_CT(model);
        }

        #endregion

        #region xuất hàng
        public bool ThemXuatKho(OutputModel model)
        { 
            return _iProduct.ThemXuatKho(model);
        }

        public DataTable GetXuatHang(OutputModel model)
        { 
            return _iProduct.GetXuatHang(model);

        }
        public DataTable CheckDuHangTrongKho(string code)
        { 
            return _iProduct.CheckDuHangTrongKho(code);

        }

        #endregion
        #region xuất hàng chi tiết
        public bool ThemXuatKho_CT(OutputDetailModel model)
        { 
            return _iProduct.ThemXuatKho_CT(model);
        }

        public DataTable GetXuatHang_CT(OutputDetailModel model)
        { 
            return _iProduct.GetXuatHang_CT(model);
        }
        public DataTable GetXuatKho_CT_TheoDonHang(string orderCode, string outCode)
        {
            return _iProduct.GetXuatKho_CT_TheoDonHang(orderCode, outCode);
        }

        #endregion

        public string GetInputCode(DateTime dateInput, string maNhapKho, string tableName, string column)
        {
            return _iProduct.GetInputCode(dateInput, maNhapKho,  tableName,  column);
        }

        #region nhap kho
        public bool ThemNhapKho(InputModel model)
        {
            return _iProduct.ThemNhapKho(model);
        }
        public bool XoaNhapKho(InputModel model)
        { 
            return _iProduct.XoaNhapKho(model);

        }
        public bool SuaNhapKho(InputModel model)
        {
            return _iProduct.SuaNhapKho(model);

        }
        public DataTable GetNhapKho(InputModel model)
        { 
            return _iProduct.GetNhapKho(model);

        }

        #endregion

        #region chi tiết nhap kho
        public bool ThemNhapKho_CT(InputDetailModel model)
        {
            return _iProduct.ThemNhapKho_CT(model);

        }
        public bool XoaNhapKho_CT(InputDetailModel model)
        {
            return _iProduct.XoaNhapKho_CT(model);

        }
        public bool SuaNhapKho_CT(InputDetailModel model)
        { 
            return _iProduct.SuaNhapKho_CT(model);

        }
        public bool SuaNhapKho_CT_XuatHang(InputDetailModel model)
        { 
            return _iProduct.SuaNhapKho_CT_XuatHang(model);
        }

        public DataTable GetNhapKho_CT(InputDetailModel model)
        {
            return _iProduct.GetNhapKho_CT(model);

        }

        #endregion
    }
}
