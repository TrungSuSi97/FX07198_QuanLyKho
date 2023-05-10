using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
