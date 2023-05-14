using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPH.Product.Model;

namespace TPH.Product.Services
{
    public interface IProductService
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
        bool CapNhatDhDaXuat(OrderModel model);

        DataTable GetDonHang(OrderModel model);


        #endregion

     

        #region chi tiết đơn hàng
        bool ThemDonHang_CT(OrderDetailModel model);

        bool XoaDonHang_CT(OrderDetailModel model);

        bool SuaDonHang_CT(OrderDetailModel model);

        DataTable GetDonHang_CT(OrderDetailModel model);


        #endregion
        #region xuất hàng
        bool ThemXuatKho(OutputModel model);

        DataTable GetXuatHang(OutputModel model);
        DataTable CheckDuHangTrongKho(string code);

        #endregion
        #region xuất hàng chi tiết
        bool ThemXuatKho_CT(OutputDetailModel model);

        DataTable GetXuatHang_CT(OutputDetailModel model);
        DataTable GetXuatKho_CT_TheoDonHang(string orderCode, string outCode);


        #endregion
        string GetInputCode(DateTime dateInput, string maNhapKho, string tableName, string column);

        #region nhap kho
        bool ThemNhapKho(InputModel model);

        bool XoaNhapKho(InputModel model);

        bool SuaNhapKho(InputModel model);

        DataTable GetNhapKho(InputModel model);


        #endregion

        #region chi tiết nhap kho
        bool ThemNhapKho_CT(InputDetailModel model);

        bool XoaNhapKho_CT(InputDetailModel model);

        bool SuaNhapKho_CT(InputDetailModel model);
        bool SuaNhapKho_CT_XuatHang(InputDetailModel model);


        DataTable GetNhapKho_CT(InputDetailModel model);


        #endregion

    }
}
