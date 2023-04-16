using System.Collections.Generic;
using System.Data;

namespace TPH.LIS.Configuration.Constants
{
    public class EmailConstant
    {
        public static int YahooPort = 25;
        public static int GmailPort = 587;

        public static string Yahoo = "Yahoo";
        public static string Gmail = "Gmail";
    }
    public class CommonConfigConstant
    {
        public static string AllComputer = "AllComputer";
        public static string TinhToanKetQua = "TinhToanKetQua";
        public static string TinhToanKetQuaSoSanh = "TinhToanKetQuaSoSanh";
        public static string DuyetKetQua = "DuyetKetQua";
        public static string DuyetKetQuaDinhTinh = "DuyetKetQuaDinhTinh";
    }
    public class LoaiTinhToan
    {
        public static DataTable DataLoaiTinhToan()
        {
            var data = new DataTable();
            data.Columns.Add("Id", typeof(string));
            data.Columns.Add("NoiDung", typeof(string));

            var dr = data.NewRow();
            dr["Id"] = CommonConfigConstant.TinhToanKetQua;
            dr["NoiDung"] = "Tính toán kết quả - Định lượng";
            data.Rows.Add(dr);

            dr = data.NewRow();
            dr["Id"] = CommonConfigConstant.TinhToanKetQuaSoSanh;
            dr["NoiDung"] = "Tính toán kết quả (so sánh) - Định tính";
            data.Rows.Add(dr);

            dr = data.NewRow();
            dr["Id"] = CommonConfigConstant.DuyetKetQua;
            dr["NoiDung"] = "Cảnh báo duyệt kết quả - Định lượng";
            data.Rows.Add(dr);

            dr = data.NewRow();
            dr["Id"] = CommonConfigConstant.DuyetKetQuaDinhTinh;
            dr["NoiDung"] = "Cảnh báo duyệt kết quả - Định tính";
            data.Rows.Add(dr);
            return data;
        }
    }
    public class ProfileTestContant
    {
        public static string ProfileChar = "[+]";
        public static string GroupChar = "[++]";
        public static string TestChar = "";
    }

    public enum DepartmentEnum
    {
        HH = 1,
        SH = 2,
        MD = 3,
        VS = 4
    }
    public enum EnumNghiCuoiTuan
    {
        KhongNghi = 0,
        ThuBayChuNhat = 1,
        ChieuThubayChuNhat = 2,
        ChuNhat = 3,
        ChieuChuNhat = 4
    }
    public class NghiCuoiTuan
    {
        public int Id { get; set; }
        public string NoiDung { get; set; }
        public static List<NghiCuoiTuan> LisNghiCuoiTuan()
        {
            var list = new List<NghiCuoiTuan>();

            list.Add(new NghiCuoiTuan
            {
                Id = (int)EnumNghiCuoiTuan.KhongNghi,
                NoiDung = "--Không nghỉ--"
            });

            list.Add(new NghiCuoiTuan
            {
                Id = (int)EnumNghiCuoiTuan.ThuBayChuNhat,
                NoiDung = "Thứ 7 & chủ nhật"
            });

            list.Add(new NghiCuoiTuan
            {
                Id = (int)EnumNghiCuoiTuan.ChieuThubayChuNhat,
                NoiDung = "Chiều thứ 7 & chủ nhật"
            });

            list.Add(new NghiCuoiTuan
            {
                Id = (int)EnumNghiCuoiTuan.ChuNhat,
                NoiDung = "Chủ nhật"
            });

            list.Add(new NghiCuoiTuan
            {
                Id = (int)EnumNghiCuoiTuan.ChieuChuNhat,
                NoiDung = "Chiều chủ nhật"
            });

            return list;
        }
    }
    public enum EnumLoaiBienDich
    {
        DichKetQuaMay = 1,
        DichTheoCan = 2,
        NhanHeSo = 3,
        LamTron = 4
    }
    public class LoaiBienDich
    {
        public static DataTable DataLoaiBienDich()
        {
            var data = new DataTable();
            data.Columns.Add("Id", typeof(int));
            data.Columns.Add("NoiDung", typeof(string));
            var dr = data.NewRow();
            dr["Id"] = (int)EnumLoaiBienDich.DichKetQuaMay;
            dr["NoiDung"] = "Dịch kết quả máy";
            data.Rows.Add(dr);

            dr = data.NewRow();
            dr["Id"] = (int)EnumLoaiBienDich.DichTheoCan;
            dr["NoiDung"] = "Dịch theo cận (lấy cả  bằng và các dấu  <,>)";
            data.Rows.Add(dr);

            dr = data.NewRow();
            dr["Id"] = (int)EnumLoaiBienDich.NhanHeSo;
            dr["NoiDung"] = "Nhân hệ số";
            data.Rows.Add(dr);

            dr = data.NewRow();
            dr["Id"] = (int)EnumLoaiBienDich.LamTron;
            dr["NoiDung"] = "Làm tròn kết quả";
            data.Rows.Add(dr);
            return data;
        }
    }
    public enum EnumQuiTrinhLAB
    {
        NhapTay_KetQua = 0,
        NhapTay_LayMau_KetQua = 1,
        NhapTay_NhanMau_KetQua = 2,
        NhapTay_LayMau_NhanMau_KetQua = 3,
        NhapTuHIS_KetQua = 4,
        NhapTuHIS_LayMau_KetQua = 5,
        NhapTuHIS_NhanMau_KetQua = 6,
        NhapTuHIS_LayMau_NhanMau_KetQua = 7,
        NhapTay_ThuTien_KetQua = 8,
        NhapTay_ThuTien_LayMau_KetQua = 9,
        NhapTay_ThuTien_LayMau_NhanMau_KetQua = 10,
        NhapTay_ThuTien_NhanMau_KetQua = 11
    }
    public class QuiTrinhLAB
    {
        public int Id { get; set; }
        public string NoiDung { get; set; }
        public static List<QuiTrinhLAB> ListQuiTrinhLAB()
        {
            var list = new List<QuiTrinhLAB>();

            list.Add(new QuiTrinhLAB
            {
                Id = (int)EnumQuiTrinhLAB.NhapTay_KetQua,
                NoiDung = "1:Tiếp nhận thủ công -> Kết quả"
            });

            list.Add(new QuiTrinhLAB
            {
                Id = (int)EnumQuiTrinhLAB.NhapTay_LayMau_KetQua,
                NoiDung = "2:Tiếp nhận thủ công -> Lấy mẫu -> Kết quả"
            });

            list.Add(new QuiTrinhLAB
            {
                Id = (int)EnumQuiTrinhLAB.NhapTay_NhanMau_KetQua,
                NoiDung = "3:Tiếp nhận thủ công -> Nhận mẫu -> Kết quả"
            });

            list.Add(new QuiTrinhLAB
            {
                Id = (int)EnumQuiTrinhLAB.NhapTay_LayMau_NhanMau_KetQua,
                NoiDung = "4:Tiếp nhận thủ công -> Lấy mẫu -> Nhận mẫu -> Kết quả"
            });

            list.Add(new QuiTrinhLAB
            {
                Id = (int)EnumQuiTrinhLAB.NhapTuHIS_KetQua,
                NoiDung = "5:Tiếp nhận từ HIS -> Kết quả"
            });

            list.Add(new QuiTrinhLAB
            {
                Id = (int)EnumQuiTrinhLAB.NhapTuHIS_LayMau_KetQua,
                NoiDung = "6:Tiếp nhận từ HIS -> Lấy mẫu -> Kết quả"
            });

            list.Add(new QuiTrinhLAB
            {
                Id = (int)EnumQuiTrinhLAB.NhapTuHIS_NhanMau_KetQua,
                NoiDung = "7:Tiếp nhận từ HIS -> Nhận mẫu -> Kết quả"
            });

            list.Add(new QuiTrinhLAB
            {
                Id = (int)EnumQuiTrinhLAB.NhapTuHIS_LayMau_NhanMau_KetQua,
                NoiDung = "8:Tiếp nhận từ HIS -> Lấy mẫu -> Nhận mẫu -> Kết quả"
            });

            list.Add(new QuiTrinhLAB
            {
                Id = (int)EnumQuiTrinhLAB.NhapTay_ThuTien_KetQua,
                NoiDung = "9:Tiếp nhận thủ công -> Thu tiền -> Kết quả"
            });

            list.Add(new QuiTrinhLAB
            {
                Id = (int)EnumQuiTrinhLAB.NhapTay_ThuTien_LayMau_KetQua,
                NoiDung = "10:Tiếp nhận thủ công -> Thu tiền -> Lấy mẫu -> Kết quả"
            });
            list.Add(new QuiTrinhLAB
            {
                Id = (int)EnumQuiTrinhLAB.NhapTay_ThuTien_LayMau_NhanMau_KetQua,
                NoiDung = "11:Tiếp nhận thủ công -> Thu tiền -> Lấy mẫu -> Nhận mẫu -> Kết quả"
            });
            list.Add(new QuiTrinhLAB
            {
                Id = (int)EnumQuiTrinhLAB.NhapTay_ThuTien_NhanMau_KetQua,
                NoiDung = "12:Tiếp nhận thủ công -> Thu tiền -> Nhận mẫu -> Kết quả"
            });
            return list;
        }
        public static bool GetTrangThaiLayMauTheoRule(EnumQuiTrinhLAB quitrinhCheck)
        {
            return
                     (quitrinhCheck == EnumQuiTrinhLAB.NhapTay_LayMau_KetQua
                     || quitrinhCheck == EnumQuiTrinhLAB.NhapTay_LayMau_NhanMau_KetQua
                     || quitrinhCheck == EnumQuiTrinhLAB.NhapTay_ThuTien_LayMau_KetQua
                     || quitrinhCheck == EnumQuiTrinhLAB.NhapTay_ThuTien_LayMau_NhanMau_KetQua
                     || quitrinhCheck == EnumQuiTrinhLAB.NhapTuHIS_LayMau_KetQua
                     || quitrinhCheck == EnumQuiTrinhLAB.NhapTuHIS_LayMau_NhanMau_KetQua);
        }
        public static bool GetTrangThaiNhanMauTheoRule(EnumQuiTrinhLAB quitrinhCheck)
        {
            return
                     (quitrinhCheck == EnumQuiTrinhLAB.NhapTay_NhanMau_KetQua
                     || quitrinhCheck == EnumQuiTrinhLAB.NhapTay_LayMau_NhanMau_KetQua
                     || quitrinhCheck == EnumQuiTrinhLAB.NhapTay_ThuTien_LayMau_NhanMau_KetQua
                     || quitrinhCheck == EnumQuiTrinhLAB.NhapTuHIS_NhanMau_KetQua
                     || quitrinhCheck == EnumQuiTrinhLAB.NhapTuHIS_LayMau_NhanMau_KetQua
                     || quitrinhCheck == EnumQuiTrinhLAB.NhapTay_ThuTien_NhanMau_KetQua);

        }
        public static bool GetTrangThaiThuTienRule(EnumQuiTrinhLAB quitrinhCheck)
        {
            return
                     (quitrinhCheck == EnumQuiTrinhLAB.NhapTay_ThuTien_KetQua
                     || quitrinhCheck == EnumQuiTrinhLAB.NhapTay_ThuTien_LayMau_KetQua
                     || quitrinhCheck == EnumQuiTrinhLAB.NhapTay_ThuTien_LayMau_NhanMau_KetQua
                     || quitrinhCheck == EnumQuiTrinhLAB.NhapTay_ThuTien_NhanMau_KetQua);

        }
    }
    public enum EnumKieuNhapChiDinh
    {
        ComboboxInput = 0,
        ListViewInput = 1,
        TreeViewInput = 2
    }
    public class KieuNhapChiDinh
    {
        public int Id { get; set; }
        public string NoiDung { get; set; }
        public static List<KieuNhapChiDinh> ListKieuNhapChiDinh()
        {
            var list = new List<KieuNhapChiDinh>();

            list.Add(new KieuNhapChiDinh
            {
                Id = (int)EnumKieuNhapChiDinh.ComboboxInput,
                NoiDung = "Chọn trên combobox"
            });

            list.Add(new KieuNhapChiDinh
            {
                Id = (int)EnumKieuNhapChiDinh.ListViewInput,
                NoiDung = "Chọn trên lưới dạng cột"
            });

            list.Add(new KieuNhapChiDinh
            {
                Id = (int)EnumKieuNhapChiDinh.TreeViewInput,
                NoiDung = "Chọn trên danh sách dạng cây"
            });

            return list;
        }
    }
    public class Department
    {
        public DepartmentEnum DepartmentID { get; set; }
        public string DepartementName { get; set; }
        public static List<Department> LisDepartment()
        {
            var list = new List<Department>();
            list.Add(new Department
            {
                DepartmentID = DepartmentEnum.HH,
                DepartementName = "Huyết học"
            });

            list.Add(new Department
            {
                DepartmentID = DepartmentEnum.SH,
                DepartementName = "Sinh hóa"
            });

            list.Add(new Department
            {
                DepartmentID = DepartmentEnum.MD,
                DepartementName = "Miễn dịch"
            });

            list.Add(new Department
            {
                DepartmentID = DepartmentEnum.VS,
                DepartementName = "Vi sinh"
            });

            return list;
        }
    }
    public enum EnumLoaiDieuTri
    {
        None = 0,
        NgoaiTru = 1,
        NoiTru = 2,
        CapCuu = 3,
        Vip = 4,
        CanBoCaoCap = 5
    }
    public class LoaiDieuTri
    {
        public int Id { get; set; }
        public string NoiDung { get; set; }
        public static List<LoaiDieuTri> ListLoaiDieuTri()
        {
            var list = new List<LoaiDieuTri>();
            list.Add(new LoaiDieuTri
            {
                Id = (int)EnumLoaiDieuTri.None,
                NoiDung = "--None--"
            });

            list.Add(new LoaiDieuTri
            {
                Id = (int)EnumLoaiDieuTri.NgoaiTru,
                NoiDung = "Ngoại trú"
            });

            list.Add(new LoaiDieuTri
            {
                Id = (int)EnumLoaiDieuTri.NoiTru,
                NoiDung = "Nội trú"
            });

            list.Add(new LoaiDieuTri
            {
                Id = (int)EnumLoaiDieuTri.CapCuu,
                NoiDung = "Cấp cứu"
            });
            list.Add(new LoaiDieuTri
            {
                Id = (int)EnumLoaiDieuTri.Vip,
                NoiDung = "Vip"
            });
            list.Add(new LoaiDieuTri
            {
                Id = (int)EnumLoaiDieuTri.CanBoCaoCap,
                NoiDung = "Cán bộ cao cấp"
            });
            return list;
        }
    }
    public enum EnumNoiLayMau
    {
        Chung = 0,
        NgoaiTru = 1,
        NoiTru = 2
    }
    public class NoiLayMau
    {
        public int Id { get; set; }
        public string NoiDung { get; set; }
        public static List<NoiLayMau> ListNoiLayMau()
        {
            var list = new List<NoiLayMau>();

            list.Add(new NoiLayMau
            {
                Id = (int)EnumNoiLayMau.Chung,
                NoiDung = "--Dùng chung--"
            });

            list.Add(new NoiLayMau
            {
                Id = (int)EnumNoiLayMau.NgoaiTru,
                NoiDung = "Ngoại trú"
            });

            list.Add(new NoiLayMau
            {
                Id = (int)EnumNoiLayMau.NoiTru,
                NoiDung = "Nội trú"
            });
            return list;
        }
    }
    public enum EnumNguoiThucHien
    {
        NguoiValid = 0,
        NguoiIn = 1,
        NguoiKy = 2
    }
    public class NguoiThucHien
    {
        public int Id { get; set; }
        public string NoiDung { get; set; }
        public static List<NguoiThucHien> ListNguoiThucHien()
        {
            var list = new List<NguoiThucHien>();

            list.Add(new NguoiThucHien
            {
                Id = (int)EnumNguoiThucHien.NguoiValid,
                NoiDung = "Người duyệt"
            });

            list.Add(new NguoiThucHien
            {
                Id = (int)EnumNguoiThucHien.NguoiIn,
                NoiDung = "Người in KQ"
            });

            list.Add(new NguoiThucHien
            {
                Id = (int)EnumNguoiThucHien.NguoiKy,
                NoiDung = "Người ký tên"
            });
            return list;
        }
    }
    public enum EnumCauHinhConfig
    {
        IDBarcode = 10,
        IDBienDichCo = 300,
        IDDeNghiNCC_SLSS = 400
    }
    public class CauHinhConfig
    {
        public int Id { get; set; }
        public string NoiDung { get; set; }
        public static List<CauHinhConfig> ListCauHinhConfig()
        {
            var list = new List<CauHinhConfig>();

            list.Add(new CauHinhConfig
            {
                Id = (int)EnumCauHinhConfig.IDBarcode,
                NoiDung = "Barcode hiện tại"
            });

            list.Add(new CauHinhConfig
            {
                Id = (int)EnumCauHinhConfig.IDBienDichCo,
                NoiDung = "Biên dịch cờ"
            });
            list.Add(new CauHinhConfig
            {
                Id = (int)EnumCauHinhConfig.IDDeNghiNCC_SLSS,
                NoiDung = "Đề nghị - NCC - Sàng lọc SS"
            });
            return list;
        }
    }

    #region Ngôn ngữ danh mục
    public enum EnumLoaiDanhMucNgonNgu
    {
        DanhMucXetNghiem = 0,
        DanhMucKhoaPhong = 1,
        DanhMucDoiTuong = 2,
        DanhMucNhanVien = 3,
        DanhMucNhomXN = 4,
        DanhMucBoPhan = 5,
        DanhMucNhanVienChucVu = 6
    }
    public class LoaiDanhMucNgonNgu
    {
        public EnumLoaiDanhMucNgonNgu IDLoaiDnhMuc { get; set; }
        public string TenLoaiDanhMuc { get; set; }
        public static List<LoaiDanhMucNgonNgu> ListLoaiDanhMucNgonNgu()
        {
            var list = new List<LoaiDanhMucNgonNgu>();
            list.Add(new LoaiDanhMucNgonNgu
            {
                IDLoaiDnhMuc = EnumLoaiDanhMucNgonNgu.DanhMucXetNghiem,
                TenLoaiDanhMuc = "DM Xét nghiệm"
            });
            list.Add(new LoaiDanhMucNgonNgu
            {
                IDLoaiDnhMuc = EnumLoaiDanhMucNgonNgu.DanhMucNhomXN,
                TenLoaiDanhMuc = "DM Nhóm xét nghiệm"
            });
            list.Add(new LoaiDanhMucNgonNgu
            {
                IDLoaiDnhMuc = EnumLoaiDanhMucNgonNgu.DanhMucBoPhan,
                TenLoaiDanhMuc = "DM Bộ xét nghiệm"
            });

            list.Add(new LoaiDanhMucNgonNgu
            {
                IDLoaiDnhMuc = EnumLoaiDanhMucNgonNgu.DanhMucKhoaPhong,
                TenLoaiDanhMuc = "DM Khoa phòng"
            });

            list.Add(new LoaiDanhMucNgonNgu
            {
                IDLoaiDnhMuc = EnumLoaiDanhMucNgonNgu.DanhMucDoiTuong,
                TenLoaiDanhMuc = "DM Đối tượng"
            });

            list.Add(new LoaiDanhMucNgonNgu
            {
                IDLoaiDnhMuc = EnumLoaiDanhMucNgonNgu.DanhMucNhanVien,
                TenLoaiDanhMuc = "DM Nhân viên"
            });
            list.Add(new LoaiDanhMucNgonNgu
            {
                IDLoaiDnhMuc = EnumLoaiDanhMucNgonNgu.DanhMucNhanVienChucVu,
                TenLoaiDanhMuc = "DM Nhân viên chức vụ"
            });
            return list;
        }
    }
    #endregion
}
