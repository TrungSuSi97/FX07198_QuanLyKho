using System.Data;
using System.Data.SqlClient;
using TPH.LIS.Common.Controls;

namespace TPH.LIS.ResultConvert.Service
{
    public interface IResultConvertService
    {
        bool CalculateResult_XetNghiem(DataTable dtChiDinh,
         DataTable dtCalculate, string gioiTinh, string maSinhLy
            , string tuoi, string userId);
        bool CalculateDuyetKQ(DataTable dtChiDinh, DataTable dtCalculate);
        string Evaluate(string expression);
    }
}
