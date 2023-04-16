namespace TPH.HIS.WebAPI.Models.Logs
{
    public class LogFilter
    {
        public string LogDate { get; set; }
        public string Filter { get; set; }
        public int PageIndex { get; set; }
        public int RowsPerPage { get; set; }
    }
}
