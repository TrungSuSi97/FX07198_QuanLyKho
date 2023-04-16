using TPH.HIS.WebAPI.Models.Logs;
using TPH.HIS.WebAPI.Models;

namespace TPH.LIS.API.Services
{
    public interface ILogsService
    {
        BaseResult Insert(LogMessageModel message);
        BaseResult Delete(string key);
        LogsReponse Search(LogFilter filter);
    }
}