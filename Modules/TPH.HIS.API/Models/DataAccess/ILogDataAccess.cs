using System.Data;
using TPH.HIS.WebAPI.Models;
using TPH.HIS.WebAPI.Models.Logs;

namespace TPH.HIS.WebAPI.DataAccess
{
    public interface ILogDataAccess
    {
        BaseResult InsertHisTracking(LogMessageModel message);
        DataTable GetHisTracking(LogFilter filter);
    }
}
