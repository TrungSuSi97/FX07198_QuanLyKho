using System.Data;

namespace TPH.LabelingMachine.BCRobo.DataAccess
{
    public interface ISystemDataAccess
    {
        DataTable GetBcRoboServiceConfig(string roboId);
    }
}
