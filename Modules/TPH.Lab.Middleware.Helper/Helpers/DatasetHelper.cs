namespace TPH.Lab.Middleware.Helpers.Helpers
{
    using System.Data;
    public class DatasetHelper
    {
        public static DataTable GetTable(DataSet ds, string tableName)
        {
            return ds.Tables[tableName];
        }
    }
}
