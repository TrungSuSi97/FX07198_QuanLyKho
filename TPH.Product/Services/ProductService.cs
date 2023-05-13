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
        public string GetInputCode(DateTime dateInput, string maNhapKho, string tableName, string column)
        {
            return _iProduct.GetInputCode(dateInput, maNhapKho,  tableName,  column);
        }
    }
}
