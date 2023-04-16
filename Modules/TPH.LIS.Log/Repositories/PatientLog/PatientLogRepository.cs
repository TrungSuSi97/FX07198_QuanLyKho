using System.Data;
using TPH.LIS.Data;

namespace TPH.LIS.Log.Repositories.PatientLog
{
    public class PatientLogRepository : IPatientLogRepository
    {
        public DataTable GetDeletedPatients(string fromDate, string toDate, string sequence)
        {
            var query = "select matiepnhan, seq, mabn, tenbn, tuoi, gioitinh, chandoan, bacsicd as 'ketluan', actionuser, actiondate \n" +
                " from BenhNhan_TiepNhan_Log with(nolock) where \n" +
                " actiondate between '" + fromDate + "' and '" + toDate + "' \n";

            if (!string.IsNullOrWhiteSpace(sequence))
            {
                query += " or seq ='" + sequence + "'";
            }

            using (var patients = DataProvider.ExecuteDataset(CommandType.Text, query))
            {
                if (patients != null && patients.Tables.Count > 0)
                {
                    return patients.Tables[0];
                }
            }

            return null;
        }
    }
}
