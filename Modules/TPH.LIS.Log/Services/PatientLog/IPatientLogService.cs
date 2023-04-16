using System.Data;

namespace TPH.LIS.Log.Services.PatientLog
{
    public interface IPatientLogService
    {
        DataTable GetDeletedPatients(string fromDate, string toDate, string sequence);
    }
}
