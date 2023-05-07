using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        #endregion
    }
}
