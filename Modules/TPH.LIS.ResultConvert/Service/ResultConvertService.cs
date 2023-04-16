using System.Data;
using System.Data.SqlClient;
using TPH.LIS.Common.Controls;
using TPH.LIS.ResultConvert.Repository;

namespace TPH.LIS.ResultConvert.Service
{
    public class ResultConvertService : IResultConvertService
    {
        private readonly IResultConvertRepository _iResultConvert = new ResultConvertRepository();
        public bool CalculateResult_XetNghiem(DataTable dtChiDinh, DataTable dtCalculate, string gioiTinh, string maSinhLy, string tuoi, string userId)
        {
           return _iResultConvert.CalculateResult_XetNghiem(dtChiDinh, dtCalculate, gioiTinh, maSinhLy, tuoi, userId);
        }
        public bool CalculateDuyetKQ(DataTable dtChiDinh, DataTable dtCalculate)
        {
            return _iResultConvert.CalculateDuyetKQ(dtChiDinh, dtCalculate);
        }
        public string Evaluate(string expression)
        {
            return _iResultConvert.Evaluate(expression);
        }

    }
}
