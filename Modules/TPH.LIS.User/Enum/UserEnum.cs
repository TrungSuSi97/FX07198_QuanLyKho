using System.ComponentModel;

namespace TPH.LIS.User.Enum
{
    public enum IMSModule
    {
        XetNghiemThuongQuy = 0,
        XetNghiemSHPT = 1,
        XetNghiemViSinhNuoicay = 2,
        XetNghiemSangLoc = 3,
        XetNghiemHuyetTuyDo = 4,
        ThuPhi = 5,
        SieuAm = 6,
        NoiSoi = 7,
        XQuang = 8
    }
    public enum ServiceType
    {
        None = 0,
        All = -1,
        KhuVuc = 18,
        ClsXetNghiem = 1,
        ClsSieuAm = 2,
        ClsXQuang = 3,
        ClsNoiSoi = 4,
        KhamBenh = 5,
        TaiChinh = 6,
        VatTu = 7,
        Enclitic = 8,
        ThuNgan = 9,
        ClsDienTim = 10,
        TiepNhan = 11,
        DvKhac = 12,
        Duoc = 13,
        QuanLy = 14,
        ClsXNViSinh = 15,
        ClsGiaiPhauBenh = 16,
        ClsSHPT = 17,
        ClsSLSS = 18,
        OtherService = 100
    }
    public enum FunctionGroup
    {
        [Description("Tất cả")]
        All = -1,
        [Description("Nhóm chức năng")]
        LoaiChucNang = 1,
        [Description("Khu vực")]
        KhuVuc = 2,
        [Description("Bộ phận")]
        BoPhan = 3,
        [Description("Nhóm")]
        Nhom = 4,
        [Description("Quyền thao tác")]
        PhanQuyen = 5,
        [Description("Máy xét nghiệm")]
        MayXetNghiem = 6,
        [Description("Quản lý cấu hình")]
        QLCH = 7,
        [Description("Quản lý máy")]
        QLM = 8,
        [Description("Quản lý xét nghiệm")]
        QLXN = 9,
        [Description("Quản lý vi sinh")]
        QLVS = 10,
        [Description("Quản lý SHPT")]
        QLSHPT = 11,
        [Description("Quản lý GPB")]
        GPB = 12,
        [Description("Quản lý xét siêu âm")]
        QLSA = 13,
        [Description("Quản lý xét nội soi")]
        QLNS = 14,
        [Description("Quản lý xét X-Quang")]
        QLXQuang = 15,
        [Description("Quản lý xét dược")]
        QLXDuoc = 16,
        [Description("Quản lý khám bệnh")]
        QLXKB = 17

    }
}
