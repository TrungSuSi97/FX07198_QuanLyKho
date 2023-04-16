using System.Collections.Generic;
using System.ComponentModel;

namespace TPH.LIS.Configuration.Models
{
    public class HienthiConstants
    {
        [Description("THÔNG TIN BỆNH NHÂN KQ")]
        public const string ThongTinBenhNhan = "ThongTinBenhNhan";
        [Description("LƯỚI KẾT QUẢ THƯỜNG QUY")]
        public const string LuoiKQThuongQui = "LuoiKQThuongQui";
        [Description("LƯỚI THÔNG TIN NHÓM")]
        public const string LuoiThongTinNhom = "LuoiThongTinNhom";
        [Description("LƯỚI THÔNG TIN BỘ PHẬN")]
        public const string LuoiThongTinBoPhan= "LuoiThongTinBoPhan";
        [Description("DANH SÁCH BỆNH NHÂN LẤY MẪU")]
        public const string DanhSachBNLayMau = "DanhSachBNLayMau";
        [Description("DANH SÁCH BỆNH NHÂN NHẬN MẪU")]
        public const string DanhSachBNNhanMau = "DanhSachBNNhanMau";
        [Description("DANH SÁCH BN KQ XÉT NGHIỆM")]
        public const string DanhSachBNKQXetNghiem = "DanhSachBNKQXetNghiem";
        public static Dictionary<string, string> HienthiConstantList = new Dictionary<string, string>()
        {
                        {ThongTinBenhNhan , "THÔNG TIN BỆNH NHÂN"},
                        {LuoiKQThuongQui , "LƯỚI KẾT QUẢ THƯỜNG QUY"},
                        {LuoiThongTinNhom , "LƯỚI THÔNG TIN NHÓM"},
                        {LuoiThongTinBoPhan , "LƯỚI THÔNG TIN BỘ PHẬN"},
                        {DanhSachBNLayMau , "DANH SÁCH BỆNH NHÂN LẤY MẪU"},
                        {DanhSachBNNhanMau , "DANH SÁCH BỆNH NHÂN NHẬN MẪU"},
                        {DanhSachBNKQXetNghiem , "DANH SÁCH BN KQ XÉT NGHIỆM"}
        };
    }
    public class HienThiModel
    {
        public string Idhienthi { get; set; }

        public string Idloaihienthi { get; set; }

        public string Mota { get; set; }
        int _dorong = 100;
        public int Dorong
        {
            get { return _dorong; }
            set { _dorong = value; }
        }
        bool _hienthi = false;
        public bool Hienthi
        {
            get { return _hienthi; }
            set { _hienthi = value; }
        }
        int _sapxep = 1000;
        public int Sapxep
        {
            get { return _sapxep; }
            set { _sapxep = value; }
        }
        public bool ChiThem { get; set; }
    }
}
