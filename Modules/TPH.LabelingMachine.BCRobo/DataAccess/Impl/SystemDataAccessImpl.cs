using System.Data;
using TPH.LIS.Data;

namespace TPH.LabelingMachine.BCRobo.DataAccess.Impl
{
    public class SystemDataAccessImpl : ISystemDataAccess
    {
        public DataTable GetBcRoboServiceConfig(string roboId)
        {
            var sqlQuery = string.Format("select top 1 * \nfrom cauhinh_hethong c \nwhere c.MaCauHinh ='{0}'", 
                roboId.Trim());

            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }
    }
}
