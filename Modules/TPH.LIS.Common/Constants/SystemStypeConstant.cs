namespace TPH.LIS.Common
{
    public class SystemStypeConstant
    {
        public static string DefaultImageSize = "640x480";
        public static string DefaultNumberOfBarcodeChar = "4";

        public static string ImageSize320X240 = "320x240";
        public static string ImageSize640X480 = "640x480";
        public static string ImageSize800X600 = "800x600";
        public static string ImageSize1024X768 = "1024x768";
        public static string ImageSize1280X768 = "1280x768";
        public static string ImageSize1280X1024 = "1280x1024";
        public static string ImageSize1366X768 = " 1366x768";
        public static string ImageSize1600X900 = "1600x900";
        public static string ImageSize1600X1200 = "1600x1200";
        public const int DefaultFontSize = 11;
        public static string DefaultFont = "Tahoma";

        public static string AutoBarcode = "AutoBarcode";
        public static string ManualBarcode = "ManualBarcode";
    }
    public enum TrangThaiThongTinXetNghiem
    {
        None = -1,
        ChuaLayMau = 0,
        DaLayMau = 1,
        HuyLayMau = 2,
        DaNhanMau = 3,
        TuChoiMau = 4,
        HoanDichVu = 9,
        ChoXacNhan = 5,
        XacNhanDongY = 6,
        XacNhanTuChoi = 7,
        HuyNhanMau = 8,
        OpenOrder = 22,
        TinhTrangMau = 23
    }
    public enum TrangThaiXacNhanHoan
    {
        None = 0,
        ChapNhan = 1,
        KhongChapNhan = 2
    }
    public enum SampleRunType
    {
        None = 0,
        Calibration = 1,
        QualityControl = 2,
        Result = 3
    }
}
