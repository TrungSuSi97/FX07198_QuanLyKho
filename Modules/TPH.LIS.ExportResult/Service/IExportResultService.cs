using System.Data;
using TPH.LIS.ExportResult.Models;

namespace TPH.LIS.ExportResult.Service
{
    public interface IExportResultService
    {
        DataTable XuatKEtQuaThuongQui(ExportCondition condit);
        DataTable XuatThongTinMau_Normal(ExportCondition condit);
        DataTable XuatThongTinMau_SoGiaoNhan(ExportCondition condit);
        DataTable XuatThongTinMau_SoTuChoimau(ExportCondition condit);
        DataTable XuatThongTinMau_GiaoNhanPhieuKQ(ExportCondition condit);
        DataTable XuatKetQuaViSinh_KSD(ExportCondition condit);

        DataTable DanhSachExport_SangLoc_SoSinh(ExportCondition condit);
        DataTable DanhSachExport_SangLoc_TruocSinh(ExportCondition condit);
        DataTable XuatKetQuaViSinh_ThongTinMau(ExportCondition condit);
        DataTable XuatThongTinMau_ViSinh(ExportCondition condit);
        DataTable XuatThongTinMau_ViSinh_PhieuTienTrinh(ExportCondition condit);
        DataTable XuatThongTinMau_ViSinhThuongQui(ExportCondition condit);
    }
}
