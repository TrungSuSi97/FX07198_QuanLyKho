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
    public class FinanceService : IFinanceService
    {
        private readonly IFinanceRepository _iFinance = new FinanceRepository();

        #region dm tai san cd
        public bool ThemTSCD(TaiSanCdModel model)
        {
            return _iFinance.ThemTSCD(model);
        }
        public bool XoaTSCD(TaiSanCdModel model)
        {
            return _iFinance.XoaTSCD(model);
        }
        public bool SuaTSCD(TaiSanCdModel model)
        {
            return _iFinance.SuaTSCD(model);

        }
        public DataTable GetDS_TSCD(TaiSanCdModel model)
        {
            return _iFinance.GetDS_TSCD(model);
        }


        #endregion
    }
}
