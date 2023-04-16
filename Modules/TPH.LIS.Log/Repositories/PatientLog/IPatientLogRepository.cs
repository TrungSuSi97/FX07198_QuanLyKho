using System.Data;

namespace TPH.LIS.Log.Repositories.PatientLog
{
    public interface IPatientLogRepository
    {
        DataTable GetDeletedPatients(string fromDate, string toDate, string sequence);
    }
}
