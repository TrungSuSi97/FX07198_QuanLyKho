using System.Collections.Generic;
using System.Data;
using DevExpress.LookAndFeel;
using TPH.Language;

namespace TPH.LIS.Common
{
    public class CommonConstant
    {
        public static string useRegContanst(string regConstant, string userId)
        {
            return string.Format("{0}_{1}", regConstant, userId);
        }

        public const string ApplicationName = "TPH.LabIMS";
        public const string RegistrySubKey = "SOFTWARE\\TPH.TPHLIS\\Properties\\";
        public const string RegistryLoginUsername = "TPHLISUserID";
        public const string RegistryUserPassword = "TPHLISPassword";
        public const string RegistryIsSavePassword = "TPHLISIsSavePass";
        public const string RegistryPdfPath = "TPHLISPDFPath";
        public const string RegistryPrintInvoiceDirect = "TPHLISPrintInvoiceDirect";
        public const string RegistryKhamBenhPrinter = "TPHLISKBPrinter";
        public const string RegistryOrtherPrinter = "TPHLISOrtherPrinter";
        public const string RegistryPrintInvoice = "TPHLISPrintInvoice";
        public const string RegistryPrinterResult = "TPHLISPrinterResult";
        public const string RegistryListPrinterCharge = "TPHLISListPrinterCharge";
        public const string RegistryOutputPrinter = "TPHLISOutputPrinter";
        public const string RegistryPreviewInvoice = "TPHLISPreviewInvoice";
        public const string RegistryAutoSave = "TPHLISAutoSave";
        public const string RegistryBarcodePrinter = "TPHLISBarcodePrinter";
        public const string RegistryHisBarcodePrinter = "TPHLISHisBarcodePrinter";
        public const string RegistryPrintBarcodePrinter = "TPHLISPrintBarcodePrinter";
        public const string RegistryPrintReturnTicket = "TPHLISPrintReturnTicket";
        public const string RegistryGetOrderWhenPressEnter = "TPHLISGetOrderWhenPressEnter";

        public const string Admin = "Admin";
        public const string DefaultDepartement = "A";

        public static string Hello = LanguageExtension.GetResourceValueFromKey(
            "Xinchao",
            LanguageExtension.AppLanguage); //Xin chào

        public static string InValid = LanguageExtension.GetResourceValueFromValue(
            "Chưa xác nhận",
            LanguageExtension.AppLanguage); //"Chưa xác nhận";

        public static string IsValided = LanguageExtension.GetResourceValueFromValue(
            "Đã xác nhận",
            LanguageExtension.AppLanguage); //"Đã xác nhận";

        public const string PDF = "PDF";
        public const string WORD = "WORD";
        public const byte DefaultHisBarcodePrinterId = 1;

        public const string RegistryNhomXetNghiem = "0";
        public const string RegistryTuTiepNhanKhiNhapBarcode = "TuTiepNhanKhiNhapBarcode";
        public const string RegistryBarcodeType = "BarcodeType";
        public const string RegistryAutoCompleteGetSample = "AutoCompleteGetSample";
        public const string RegistrySearchByPIDAndLisCode = "SearchByPIDAndLisCode";
        public const string RegistryAutoCompleteGetSample_OnGetSample = "AutoCompleteGetSample_OnGetSample";
        public const string RegistryAutoPrintBarcode_OnGetSample = "AutoPrintBarcode_OnGetSample";
        public const string RegistryPrinterBarcode_OnGetSample = "PrinterBarcode_OnGetSample";
        public const string RegistryReceptionHIS_ShowDetail = "ReceptionHIS_ShowDetail ";
        public const int TrangThaiKqMayTuMayKhac = 0;
        public const int TrangThaiKqMayGoiDiMiddleware = 1;
        public const int TrangThaiKqMayNhanTuMiddleware = 2;
        public const int TrangThaiKqMayChoGhepCode = 10;
        public const string DefaultLocationID = "-PK-";

        public static DataTable DanhSachTrangThai()
        {
            var lang = new MessageConstant();
            var data = new DataTable();
            data.Columns.Add("ID", typeof(string));
            data.Columns.Add("Description", typeof(string));
            var dr = data.NewRow();
            dr["ID"] = "";
            dr["Description"] = lang.Tatca;
            data.Rows.Add(dr);
            //dr = data.NewRow();
            //dr["ID"] = "S";
            //dr["Description"] = "Chưa có kết quả";
            //data.Rows.Add(dr);
            // P: Đã in, V: Đã duyệt, F: Đã đủ kết quả, H: Đã có kết quả, G: đã nhận mẫu, c: Đã lấy mẫu
            dr = data.NewRow();
            dr["ID"] = "G";
            dr["Description"] = lang.Chuacoketqua; //"Chưa có kết quả";
            data.Rows.Add(dr);

            dr = data.NewRow();
            dr["ID"] = "H";
            dr["Description"] = lang.Dacoketqua; //"Đã có kết quả";
            data.Rows.Add(dr);

            dr = data.NewRow();
            dr["ID"] = "F";
            dr["Description"] = lang.Daduketqua; //"Đã đủ kết quả";
            data.Rows.Add(dr);

            dr = data.NewRow();
            dr["ID"] = "V";
            dr["Description"] = lang.Daduyetketqua; //"Đã duyệt kết quả";
            data.Rows.Add(dr);

            dr = data.NewRow();
            dr["ID"] = "P";
            dr["Description"] = lang.Dainketqua; //"Đã in kết quả";
            data.Rows.Add(dr);

            data.AcceptChanges();

            return data;
        }
    }

    public enum enumGioTinhThucHien
    {
        ThoiGianNhapCD = 0,
        ThoiGianLayMau = 1,
        ThoiGianNhanMau = 2
    }

    public enum enumUuTien
    {
        //  Mức độ ưu tiên (vd: 1: TW – 2: Cấp cao – 3: Cấp cứu – 0: Thường)
        Thuong = 0,
        TrungUong = 1,
        CaoCap = 2,
        CapCuu = 3
    }
    /// <summary>
    /// Kiểu ký tên : 0 - Thông thường ; 1 - Hình chữ ký; 2 - Chử ký số
    /// </summary>
    public enum KieuKySo
    {
        ThongThuong = 0,
        HinhChuKy = 1,
        DungKySo = 2,
    }
    public class PhanLoaiMayXN
    {
        public enum EnumLoaiMayXN
        {
            ThongThuong = 0,
            SinhHocPhanTu = 1,
            ViSinh = 2
        }

        public int IDLoai { get; set; }
        public string TenPhanLoaiMay { get; set; }

        public static List<PhanLoaiMayXN> ListPhanLoaiMayXN()
        {
            var list = new List<PhanLoaiMayXN>();
            list.Add(new PhanLoaiMayXN
            {
                IDLoai = (int) EnumLoaiMayXN.ThongThuong,
                TenPhanLoaiMay = LanguageExtension.GetResourceValueFromValue(
                    "Thông thường",
                    LanguageExtension.AppLanguage) //"Thông thường"
            });
            list.Add(new PhanLoaiMayXN
            {
                IDLoai = (int) EnumLoaiMayXN.SinhHocPhanTu,
                TenPhanLoaiMay = LanguageExtension.GetResourceValueFromValue(
                    "Sinh học phân tử",
                    LanguageExtension.AppLanguage) //"Sinh học phân tử"
            });
            list.Add(new PhanLoaiMayXN
            {
                IDLoai = (int) EnumLoaiMayXN.ViSinh,
                TenPhanLoaiMay = LanguageExtension.GetResourceValueFromValue(
                    "Vi sinh",
                    LanguageExtension.AppLanguage)//"Vi sinh"
            });
            return list;
        }
    }
}