using TPH.HIS.WebAPI.Models;
using TPH.HIS.WebAPI.Models.Params;

namespace TPH.HIS.WebAPI.DataAccess
{
    public interface ILisDataAccess
    {
        SystemConfigModel GetSystemConfig(int hisId);
        bool UpdatePatientInfo(PatientParams patient);
    }
}