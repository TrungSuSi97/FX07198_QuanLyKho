using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPH.Product.Model;

namespace TPH.Product.Services
{
    public interface IFinanceService
    {
        #region tài sản cd
        bool ThemTSCD(TaiSanCdModel model);
        bool XoaTSCD(TaiSanCdModel model);
        bool SuaTSCD(TaiSanCdModel model);
        DataTable GetDS_TSCD(TaiSanCdModel model);

        #endregion

    }
}
