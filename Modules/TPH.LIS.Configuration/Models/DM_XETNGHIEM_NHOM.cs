using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TPH.LIS.Configuration.Models
{
    #region dm_xetnghiem_bophan
    public class DM_XETNGHIEM_BOPHAN
    {
        [Description("Mã bộ phận")]
        public string Mabophan { get; set; }
        [Description("Tên bộ phận")]
        public string Tenbophan { get; set; }
        [Description("Sắp xếp")]
        public int Sapxep { get; set; } = 0;
        [Description("Không sử dụng")]
        public bool Khongsd { get; set; } = false;
        [Description("Tên phiếu in")]
        public string Tenphieuin { get; set; }
        [Description("Mã số biểu mẫu")]
        public string Sobieumau { get; set; }
        [Description("Ngày hiệu lực")]
        public string Ngayhieuluc { get; set; }
        [Description("Tên người ký mặc định")]
        public string Chukymacdinh { get; set; }
        [Description("Chức vụ người ký mặc định")]
        public string Chucvumacdinh { get; set; }
        [Description("Mã số phiên bản")]
        public string Sophienban { get; set; }
        [Description("Tên phiếu in")]
        public string Tenbieumau { get; set; }
        [Description("Thông tin ISO")]
        public string Thongtiniso { get; set; }
        [Description("Logo ISO 1")]
        public Image Logoiso { get; set; }
        [Description("Logo ISO 2")]
        public Image Logoiso2 { get; set; }
        [Description("Ghi chú dưới kết quả")]
        public bool Ghichuduoiketqua { get; set; } = false;
        [Description("Có chữ ký user duyệt KQ")]
        public bool Cochukyuservalid { get; set; } = false;
        public string Hisid { get; set; }
        [Description("Phiếu in có nhóm")]
        public bool Phieuinconhom { get; set; } = false;
        [Description("Chỉ hiển thị thông tin trang 1")]
        public bool Chithongtintrang1 { get; set; } = false;
        public string Chucvuckykhoa { get; set; }
        public string Tennguoikykhoa { get; set; }
        [Description("Luôn in Logo ISO 1")]
        public bool Khongcheckisologo1 { get; set; } = false;
        [Description("Luôn in Logo ISO 2")]
        public bool Khongcheckisologo2 { get; set; } = false;
        [Description("Ghi chú phiếu in")]
        public string Ghichuphieuin { get; set; }
        [Description("Tách phiếu theo BS chỉ định")]
        public bool Tachphieutheobschidinh { get; set; } = false;
        [Description("Tách phiếu theo ống mẫu")]
        public bool Tachphieutheoongmau { get; set; } = false;
        [Description("Tách phiếu theo nhóm in")]
        public bool Tachphieutheonhomin { get; set; } = false;
        [Description("Ghép tên XN ghi chú")]
        public bool Gheptenxnghichu { get; set; } = false;
        [Description("Ghép ghi chú khoa")]
        public bool Ghepghichukhoa { get; set; } = false;
        [Description("Định dạng ghép duyệt kết quả")]
        public string Dinhdangghepduyetkq { get; set; }
        [Description("Định dạng ghép nhập kết quả")]
        public string Dinhdangghepnhapkq { get; set; }
        [Description("Người nhập")]
        public string Nguoinhap { get; set; }
        [Description("TG nhập")]
        public DateTime Thoigiannhap { get; set; } = DateTime.Now;

        public DM_XETNGHIEM_BOPHAN Copy()
        {
            return (DM_XETNGHIEM_BOPHAN)this.MemberwiseClone();
        }
    }
    #endregion
    #region dm_xetnghiem_nhom
    public class DM_XETNGHIEM_NHOM
    {
        [Description("Mã nhóm")]
        public string Manhomcls { get; set; }
        [Description("Tên nhóm")]
        public string Tennhomcls { get; set; }
        [Description("Thứ tự in")]
        public int Thutuin { get; set; } = 1;
        [Description("Mã nhóm in")]
        public string Nhomin { get; set; }
        [Description("Mã bộ phận")]
        public string Mabophan { get; set; }
        [Description("Số tem")]
        public int Sotem { get; set; } = 0;
        [Description("Mã nhóm tem")]
        public string Nhomtem { get; set; }
        public string Hethong { get; set; }
        public int Tgthuchien { get; set; } = -1;
        [Description("Màu ống lưu mẫu")]
        public string Mauongmauluu { get; set; }
        [Description("Cảnh báo giờ chuyển mẫu")]
        public bool Baogiochuyenmau { get; set; } = false;
        [Description("Ghi chú")]
        public string Ghichu { get; set; }
        [Description("Người nhập")]
        public string Nguoinhap { get; set; }
        [Description("TG nhập")]
        public DateTime Thoigiannhap { get; set; } = DateTime.Now;
        public DM_XETNGHIEM_NHOM Copy()
        {
            return (DM_XETNGHIEM_NHOM)this.MemberwiseClone();
        }
    }
    #endregion
}
