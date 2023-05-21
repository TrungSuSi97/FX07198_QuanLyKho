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

        #region Hợp đồng
        bool ThemHD(HopDongModel model);
        bool XoaHD(HopDongModel model);
        bool SuaHD(HopDongModel model);
        DataTable GetDS_HD(HopDongModel model);

        #endregion

        #region Công nợ
        bool ThemCN(CongNoModel model);
        bool XoaCN(CongNoModel model);
        bool SuaCN(CongNoModel model);
        DataTable GetDS_CN(CongNoModel model);

        #endregion
        #region ngân sách
        bool ThemNganSach(NganSachModel model);
        bool XoaNganSach(NganSachModel model);
        bool SuaNganSach(NganSachModel model);
        DataTable GetDS_NganSach(NganSachModel model);

        #endregion
    }
}
