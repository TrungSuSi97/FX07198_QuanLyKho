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

        #region đơn hàng
        bool ThemDonHang(OrderModel model);

        bool XoaDonHang(OrderModel model);

        bool SuaDonHang(OrderModel model);

        DataTable GetDonHang(OrderModel model);


        #endregion

        #region chi tiết đơn hàng
        bool ThemDonHang_CT(OrderDetailModel model);

        bool XoaDonHang_CT(OrderDetailModel model);

        bool SuaDonHang_CT(OrderDetailModel model);

        DataTable GetDonHang_CT(OrderDetailModel model);


        #endregion

        string GetInputCode(DateTime dateInput, string maNhapKho, string tableName, string column);




    }
}
