using System.Data;
using TPH.HIS.Repositories;

namespace TPH.HIS.Services
{
    public class PatientFileServices : IPatientFileServices
    {
        private readonly IPatientFileRepositories _patientFile = new PatientFileRepositories();

        public DataTable LichSuChanDoan(string pid)
        {
            return _patientFile.LichSuChanDoan(pid);
        }
        public DataTable LichSuDonThuoc(string pid)
        {
            return _patientFile.LichSuDonThuoc(pid);
        }
        public DataTable LichSuXetNghiem(string pid)
        {
            return _patientFile.LichSuXetNghiem(pid);
        }
        public DataTable LichSuSieuAm(string pid, bool kieuluoi)
        {
            return _patientFile.LichSuSieuAm(pid, kieuluoi);
        }
        public DataTable LichSuXetNghiemViSinh(string pid)
        {
            return _patientFile.LichSuXetNghiemViSinh(pid);
        }
        public DataTable LichSuNoiSoi(string pid)
        {
            return _patientFile.LichSuNoiSoi(pid);
        }
        public DataTable LichSuXQuang(string pid)
        {
            return _patientFile.LichSuXQuang(pid);
        }
        public DataTable LichSuDienTim(string pid)
        {
            return _patientFile.LichSuDienTim(pid);
        }

    }
}
