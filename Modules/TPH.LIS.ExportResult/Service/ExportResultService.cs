using System.Data;
using TPH.LIS.ExportResult.Models;
using TPH.LIS.ExportResult.Respository;

namespace TPH.LIS.ExportResult.Service
{
    public class ExportResultService : IExportResultService
    {
        private readonly IExportResultRepository _export = new ExportResultRepository();
        public DataTable XuatKEtQuaThuongQui(ExportCondition condit)
        {
            return _export.XuatKEtQuaThuongQui(condit);
        }
        public DataTable XuatThongTinMau_Normal(ExportCondition condit)
        {
            return _export.XuatThongTinMau_Normal(condit);
        }
        public DataTable XuatThongTinMau_SoGiaoNhan(ExportCondition condit)
        {
            return _export.XuatThongTinMau_SoGiaoNhan(condit);
        }
        public DataTable XuatThongTinMau_SoTuChoimau(ExportCondition condit)
        {
            return _export.XuatThongTinMau_SoTuChoimau(condit);
        }
        public DataTable XuatThongTinMau_GiaoNhanPhieuKQ(ExportCondition condit)
        {
            return _export.XuatThongTinMau_GiaoNhanPhieuKQ(condit);
        }
        public DataTable XuatKetQuaViSinh_KSD(ExportCondition condit)
        {
            return _export.XuatKetQuaViSinh_KSD(condit);
        }
        public DataTable DanhSachExport_SangLoc_SoSinh(ExportCondition condit)
        {
            return _export.DanhSachExport_SangLoc_SoSinh(condit);
        }
        public DataTable DanhSachExport_SangLoc_TruocSinh(ExportCondition condit)
        {
            return _export.DanhSachExport_SangLoc_TruocSinh(condit);
        }
        public DataTable XuatKetQuaViSinh_ThongTinMau(ExportCondition condit)
        {
            return _export.XuatKetQuaViSinh_ThongTinMau(condit);
        }
        public DataTable XuatThongTinMau_ViSinh(ExportCondition condit)
        {
            return _export.XuatThongTinMau_ViSinh(condit);
        }
        public DataTable XuatThongTinMau_ViSinh_PhieuTienTrinh(ExportCondition condit)
        {
            return _export.XuatThongTinMau_ViSinh_PhieuTienTrinh(condit);
        }

        public DataTable XuatThongTinMau_ViSinhThuongQui(ExportCondition condit)
        {
            return _export.XuatThongTinMau_ViSinhThuongQui(condit);
        }
    }
}
