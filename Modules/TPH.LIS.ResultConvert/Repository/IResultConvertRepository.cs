using System.Data;
using System.Data.SqlClient;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Models;

namespace TPH.LIS.ResultConvert.Repository
{
    public interface IResultConvertRepository
    {
        bool CalculateResult_XetNghiem(DataTable dtChiDinh,
            DataTable dtCalculate, string gioiTinh, string maSinhLy, string tuoi, string userId);
        bool CalculateDuyetKQ(DataTable dtChiDinh, DataTable dtCalculate);
        string Evaluate(string expression);
       
    }
}
