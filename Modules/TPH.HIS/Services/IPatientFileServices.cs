using System.Data;

namespace TPH.HIS.Services
{
    public interface IPatientFileServices
    {
      
        DataTable LichSuChanDoan(string pid);
        DataTable LichSuDonThuoc(string pid);
        DataTable LichSuXetNghiem(string pid);
        DataTable LichSuXetNghiemViSinh(string pid);
        DataTable LichSuSieuAm(string pid, bool kieuluoi);
        DataTable LichSuNoiSoi(string pid);
        DataTable LichSuXQuang(string pid);
        DataTable LichSuDienTim(string pid);
    }
}
