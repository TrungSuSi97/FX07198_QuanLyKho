using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH.Product.Services
{
    public interface IProductService
    {
        #region dm hàng hóa
        bool ThemDM(string madm, string tendm);
        bool XoaDM(string madm);
        bool SuaDM(string madm, string tendm);

        #endregion

        #region dm đơn vị
        bool ThemDonVi(string madv, string tendm);
        bool XoaDonVi(string madv);
        bool SuaDonVi(string madv, string tendv);
        #endregion
    }
}
