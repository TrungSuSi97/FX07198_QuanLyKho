using DevExpress.XtraReports.UI;
using System.Data;

namespace TPH.LIS.BarcodePrinting.Service
{
    public interface IBarcodeStandardInformation
    {
        int Insert_ThongTinbarcode(string nguoiNhap, string pcNhap, byte[] noidungTem, string tenMauBarcode, int loaiBarcode);
        int Update_ThongTinbarcode(int id, string tenMaubarcode, int loaibarcode, string nguoiSua, string pcSua);
        int Update_NoiDungTem(int id, byte[] noidungTem);
        int Delete_Report(int id);
        int Insert_TemBarcode_MayTinh(int IdBarcode, string TenMayTinh, string TenMayIn, string NguoiCapNhat, string PcCapNhat);
        int Update_TemBarcode_MayTinh(int IdBarcode, string TenMayTinh, string TenMayIn, string NguoiCapNhat, string PcCapNhat);
        int Delete_TemBarcode_MayTinh(int IdBarcode, string TenMayTinh);
        DataTable Data_TemBarcode_MayTinh(int IdBarcode, string TenMayTinh);
        DataTable Data_DanhSachThongTin(string id);
        XtraReport GetReport_SuDung_TheoCauHinh(string tenMayTinh, int loaiTem, ref string tenMayIn, ref byte[] datareport);
    }
}
