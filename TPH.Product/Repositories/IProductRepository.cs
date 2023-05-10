using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPH.Product.Model;

namespace TPH.Product.Repositories
{
    public interface IProductRepository
    {
        #region dm hàng hóa
        bool ThemDM(string madm, string tendm);
        bool XoaDM(string madm);
        bool SuaDM(string madm, string tendm);
        DataTable GetDMHH(string madm);

        #endregion

        #region dm đơn vị
        bool ThemDonVi(string madv, string tendm);
        bool XoaDonVi(string madv);
        bool SuaDonVi(string madv, string tendv);
        DataTable GetDMDV(string madmdv);
        #endregion
        #region hàng hóa
        bool ThemItem(ItemModel model);
        bool XoaItem(ItemModel model);
        bool SuaItem(ItemModel model);
        DataTable GetItems(ItemModel model);

        #endregion
    }
}
