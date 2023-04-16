using System.Data;
using TPH.LIS.Log.Repositories.PatientLog;

namespace TPH.LIS.Log.Services.PatientLog
{
    public class PatientLogService : IPatientLogService
    {
        private readonly IPatientLogRepository _patientLogRepository;
        public PatientLogService() : this(null)
        {
            
        }

        public PatientLogService(PatientLogRepository patientLogRepository)
        {
            _patientLogRepository = patientLogRepository ?? new PatientLogRepository();
        }

        public DataTable GetDeletedPatients(string fromDate, string toDate, string sequence)
        {
            return _patientLogRepository.GetDeletedPatients(fromDate, toDate, sequence);
        }
    }
}
