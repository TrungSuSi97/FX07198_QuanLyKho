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
        #region HD
        public bool ThemHD(HopDongModel model)
        {
            return _iFinance.ThemHD(model);
        }
        public bool XoaHD(HopDongModel model)
        {
            return _iFinance.XoaHD(model);
        }
        public bool SuaHD(HopDongModel model)
        {
            return _iFinance.SuaHD(model);

        }
        public DataTable GetDS_HD(HopDongModel model)
        {
            return _iFinance.GetDS_HD(model);
        }


        #endregion
        #region Công nợ
        public bool ThemCN(CongNoModel model)
        {
            return _iFinance.ThemCN(model);
        }
        public bool XoaCN(CongNoModel model)
        {
            return _iFinance.XoaCN(model);
        }
        public bool SuaCN(CongNoModel model)
        {
            return _iFinance.SuaCN(model);

        }
        public DataTable GetDS_CN(CongNoModel model)
        {
            return _iFinance.GetDS_CN(model);
        }

        #endregion
        #region ngân sách
        public bool ThemNganSach(NganSachModel model)
        {
            return _iFinance.ThemNganSach(model);
        }
        public bool XoaNganSach(NganSachModel model)
        {
            return _iFinance.XoaNganSach(model);
        }
        public bool SuaNganSach(NganSachModel model)
        {
            return _iFinance.SuaNganSach(model);

        }
        public DataTable GetDS_NganSach(NganSachModel model)
        {
            return _iFinance.GetDS_NganSach(model);
        }

        #endregion
    }
}
