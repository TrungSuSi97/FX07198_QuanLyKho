using System.Collections.Generic;

namespace TPH.HIS.WebAPI.Models.Logs
{
    public class LogsReponse
    {
        public IList<LogMessageModel> Logs { get; set; }
        public long TotalRows { get; set; }
    }
}