using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;

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
        #endregion
    }
}
