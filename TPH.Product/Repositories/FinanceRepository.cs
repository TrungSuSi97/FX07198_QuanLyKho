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
    public class FinanceRepository : IFinanceRepository
    {
        #region dm tai san cd
        public bool ThemTSCD(TaiSanCdModel model)
        {
            var sqlPara = new SqlParameter[]
            {
            WorkingServices.GetParaFromOject("@MaTaiSan", model.MaTaiSan)
            , WorkingServices.GetParaFromOject("@TenTaiSan", model.TenTaiSan)
            , WorkingServices.GetParaFromOject("@Quantity", model.Quantity)
            , WorkingServices.GetParaFromOject("@TinhTrang", model.TinhTrang)
            , WorkingServices.GetParaFromOject("@DonViSuDung", model.DonViSuDung)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_ins_ThemTSCD"
             , sqlPara) > 0;
        }
        public bool XoaTSCD(TaiSanCdModel model)
        {
            var sqlPara = new SqlParameter[]
            {
            WorkingServices.GetParaFromOject("@MaTaiSan", model.MaTaiSan)
              };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_del_XoaTSCD"
             , sqlPara) > 0;
        }
        public bool SuaTSCD(TaiSanCdModel model)
        {
            var sqlPara = new SqlParameter[]
            {
            WorkingServices.GetParaFromOject("@MaTaiSan", model.MaTaiSan)
            , WorkingServices.GetParaFromOject("@TenTaiSan", model.TenTaiSan)
            , WorkingServices.GetParaFromOject("@Quantity", model.Quantity)
            , WorkingServices.GetParaFromOject("@TinhTrang", model.TinhTrang)
            , WorkingServices.GetParaFromOject("@DonViSuDung", model.DonViSuDung)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "FX_upd_SuaTSCD"
             , sqlPara) > 0;

        }
        public DataTable GetDS_TSCD(TaiSanCdModel model)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaTaiSan", model.MaTaiSan)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "FX_sel_GetDS_TSCD", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }


        #endregion
    }
}
