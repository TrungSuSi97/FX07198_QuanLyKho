using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;
using TPH.Product.Model;
using TPH.Common.Converter;

namespace TPH.Product.Repositories
{
    public class ProductRepository : IProductRepository
    {

        #region dm hàng hóa
        public bool ThemDM(string madm, string tendm)
        {
            var sqlPara = new SqlParameter[]
             {
            WorkingServices.GetParaFromOject("@MaDM", madm)
            , WorkingServices.GetParaFromOject("@TenDM", tendm)
             };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_ins_DanhMucHangHoa"
             , sqlPara) > 0;
        }
        public bool XoaDM(string madm)
        {
            var sqlPara = new SqlParameter[]
            {
            WorkingServices.GetParaFromOject("@MaDM", madm)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_del_DanhMucHangHoa"
             , sqlPara) > 0;
        }
        public bool SuaDM(string madm, string tendm)
        {
            var sqlPara = new SqlParameter[]
             {
            WorkingServices.GetParaFromOject("@MaDM", madm)
            , WorkingServices.GetParaFromOject("@TenDM", tendm)
             };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_upd_DanhMucHangHoa"
             , sqlPara) > 0;
        }

        public DataTable GetDMHH(string madm)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@madm", madm)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "FX_sel_GetDMHH", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }


        #endregion

        #region dm đơn vị
        public bool ThemDonVi(string madv, string tendv)
        {
            var sqlPara = new SqlParameter[]
             {
            WorkingServices.GetParaFromOject("@MaDV", madv)
            , WorkingServices.GetParaFromOject("@TenDV", tendv)
             };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_ins_DanhMucDonVi"
             , sqlPara) > 0;
        }
        public bool XoaDonVi(string madv)
        {
            var sqlPara = new SqlParameter[]
            {
            WorkingServices.GetParaFromOject("@MaDV", madv)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_del_DanhMucDonVi"
             , sqlPara) > 0;
        }
        public bool SuaDonVi(string madv, string tendv)
        {
            var sqlPara = new SqlParameter[]
             {
            WorkingServices.GetParaFromOject("@MaDV", madv)
            , WorkingServices.GetParaFromOject("@TenDV", tendv)
             };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_upd_DanhMucDonVi"
             , sqlPara) > 0;
        }
        public DataTable GetDMDV(string madmdv)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@madmdv", madmdv)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "FX_sel_GetDMDV", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }


        #endregion


        #region hàng hóa
        public bool ThemItem(ItemModel model)
        {
            var sqlPara = new SqlParameter[]
        {
            WorkingServices.GetParaFromOject("@ItemCode", model.ItemCode)
            , WorkingServices.GetParaFromOject("@ItemName", model.ItemName)
            , WorkingServices.GetParaFromOject("@MaDonVi", model.MaDonVi)
            , WorkingServices.GetParaFromOject("@MaDanhMuc", model.MaDanhMuc)
            , WorkingServices.GetParaFromOject("@Cost", model.Cost)
        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_ins_ThemItem"
             , sqlPara) > 0;

        }
        public bool XoaItem(ItemModel model)
        {
            var sqlPara = new SqlParameter[]
         {
            WorkingServices.GetParaFromOject("@ItemCode", model.ItemCode)
             };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_del_XoaItem"
             , sqlPara) > 0;

        }
        public bool SuaItem(ItemModel model)
        {
            var sqlPara = new SqlParameter[]
        {
            WorkingServices.GetParaFromOject("@ItemCode", model.ItemCode)
            , WorkingServices.GetParaFromOject("@ItemName", model.ItemName)
            , WorkingServices.GetParaFromOject("@MaDonVi", model.MaDonVi)
            , WorkingServices.GetParaFromOject("@MaDanhMuc", model.MaDanhMuc)
            , WorkingServices.GetParaFromOject("@Cost", model.Cost)
        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_upd_SuaItem"
             , sqlPara) > 0;
        }
        public DataTable GetItems(ItemModel model)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@ItemCode", model.ItemCode)
                        ,WorkingServices.GetParaFromOject("@MaDanhMuc", model.MaDanhMuc)
                        
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "FX_sel_GetItems", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }

        #endregion

        #region đơn hàng
        public bool ThemDonHang(OrderModel model)
        {
            var sqlPara = new SqlParameter[]
        {
            WorkingServices.GetParaFromOject("@OrderCode", model.OrderCode)
            , WorkingServices.GetParaFromOject("@DateOrder", model.DateOrder)
            , WorkingServices.GetParaFromOject("@UserI", model.UserI)
            , WorkingServices.GetParaFromOject("@HinhThucThanhToan", model.HinhThucThanhToan)
            , WorkingServices.GetParaFromOject("@GhiChu", model.GhiChu)
            , WorkingServices.GetParaFromOject("@DiaChi", model.DiaChi)
            , WorkingServices.GetParaFromOject("@TenKhachHang", model.TenKhachHang)
            , WorkingServices.GetParaFromOject("@DienThoai", model.DienThoai)

        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_ins_ThemDonHang"
             , sqlPara) > 0;

        }
        public bool XoaDonHang(OrderModel model)
        {
            var sqlPara = new SqlParameter[]
         {
            WorkingServices.GetParaFromOject("@OrderCode", model.OrderCode)
             };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_del_XoaDonHang"
             , sqlPara) > 0;

        }
        public bool SuaDonHang(OrderModel model)
        {
            var sqlPara = new SqlParameter[]
        {
             WorkingServices.GetParaFromOject("@OrderCode", model.OrderCode)
            , WorkingServices.GetParaFromOject("@DateOrder", model.DateOrder)
            , WorkingServices.GetParaFromOject("@UserI", model.UserI)
            , WorkingServices.GetParaFromOject("@HinhThucThanhToan", model.HinhThucThanhToan)
            , WorkingServices.GetParaFromOject("@GhiChu", model.GhiChu)
            , WorkingServices.GetParaFromOject("@DiaChi", model.DiaChi)
            , WorkingServices.GetParaFromOject("@TenKhachHang", model.TenKhachHang)
            , WorkingServices.GetParaFromOject("@DienThoai", model.DienThoai)
        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_upd_SuaDonHang"
             , sqlPara) > 0;
        }
        public DataTable GetDonHang(OrderModel model)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@OrderCode", model.OrderCode)
                       , WorkingServices.GetParaFromOject("@FromDate", model.FromDate)
                       , WorkingServices.GetParaFromOject("@ToDate", model.ToDate)
                       , WorkingServices.GetParaFromOject("@UserI", model.UserI)

                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "FX_sel_GetDonHang", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }

        #endregion

        #region chi tiết đơn hàng
        public bool ThemDonHang_CT(OrderDetailModel model)
        {
            var sqlPara = new SqlParameter[]
        {
            WorkingServices.GetParaFromOject("@OrderCode", model.OrderCode)
            , WorkingServices.GetParaFromOject("@ItemCode", model.ItemCode)
            , WorkingServices.GetParaFromOject("@Quantity", model.Quantity)

        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_ins_ThemDonHang_CT"
             , sqlPara) > 0;

        }
        public bool XoaDonHang_CT(OrderDetailModel model)
        {
            var sqlPara = new SqlParameter[]
         {
            WorkingServices.GetParaFromOject("@AutoID", model.AutoID)
             };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_del_XoaDonHang_CT"
             , sqlPara) > 0;

        }
        public bool SuaDonHang_CT(OrderDetailModel model)
        {
            var sqlPara = new SqlParameter[]
        {
             WorkingServices.GetParaFromOject("@AutoID", model.AutoID)
            , WorkingServices.GetParaFromOject("@Quantity", model.Quantity)
        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_upd_SuaDonHang_CT"
             , sqlPara) > 0;
        }
        public DataTable GetDonHang_CT(OrderDetailModel model)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@AutoID", model.AutoID)
                       , WorkingServices.GetParaFromOject("@OrderID", model.OrderID)
                       , WorkingServices.GetParaFromOject("@OrderCode", model.OrderCode)

                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "FX_sel_GetDonHang_CT", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }

        #endregion
        public string GetInputCode(DateTime dateInput, string maNhapKho, string tableName, string column)
        {
            var id = "";
            var resultCode = string.Format("{0}{1:yyyy}.{1:MM}.", maNhapKho, dateInput);

            var sqlQuery = "select top 1 A.CodeSEQ from (";
            sqlQuery += $"\n select cast(right(rtrim({column}),len(rtrim({column})) - " + resultCode.Length + ") as int) as CodeSEQ";
            sqlQuery += $"\n from {tableName}(nolock)\n where {column} like '" + resultCode + "%'";
            sqlQuery += "\n) as A";
            sqlQuery += " order by  cast(A.CodeSEQ as int) DESC";

            var inputCodes = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            if (inputCodes != null && inputCodes.Rows.Count > 0)
            {
                var tempId = StringConverter.ToString(inputCodes.Rows[0]["CodeSEQ"]);
                var nextSEQ = NumberConverter.ToInt(tempId) + 1;

                if (nextSEQ < 10)
                    id = string.Format("0{0}", nextSEQ);
                else
                    id = nextSEQ.ToString();
            }
            else
            {
                id = "01";
            }

            return resultCode + id;
        }
    }
}
