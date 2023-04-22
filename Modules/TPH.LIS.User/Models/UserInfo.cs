using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;

namespace TPH.LIS.User.Models
{
    public class UserInfo
    {
        public string LoginName { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
        public string Departement { get; set; }
        public string StaffID { get; set; }
        public string Password { get; set; }

        public string MaNhomNhanVien { get; set; }
        public string TenNhomNhanVien { get; set; }
        public string MaBoPhan { get; set; }
        public string TenBoPhan { get; set; }




    }
    #region ql_nguoidung
    public class QL_NGUOIDUNG
    {
        [Description("Mã đăng nhập")]
        public string Manguoidung { get; set; }
        [Description("Tên nhân viên")]
        public string Tennhanvien { get; set; }
        public bool Truc { get; set; } = false;
        public string Bophan { get; set; }
        [Description("Admin")]
        public bool Isadmin { get; set; } = false;
        public string Matkhau { get; set; }
        [Description("Hình chữ ký")]
        public Image Signpicture { get; set; }
        [Description("Hình chữ ký")]
        public bool Nhanmau { get; set; } = false;
        public string Idkhulaymau { get; set; } = "-1";
        public bool? Capnhatchucnangmoi { get; set; }
        [Description("Đối chiếu SHPT")]
        public bool DoiChieuSHPT { get; set; } = false;
        [Description("Ký tên trưởng khoa")]
        public bool Kyten { get; set; } = false;
        [Description("Ký tên lãnh đạo")]
        public bool Kytenlanhdao { get; set; } = false;     
        [Description("Dùng ký số")]
        public bool Dungkyso { get; set; } = false;
        [Description("Serial ký số")]
        public string Masochukyso { get; set; }
        [Description("Người tạo")]
        public string Nguoitao { get; set; }
        [Description("Giờ tạo")]
        public DateTime Tgtao { get; set; } = DateTime.Now;
        [Description("Người sửa")]
        public string Nguoisua { get; set; }
        [Description("Giờ sửa")]
        public DateTime? Tgsua { get; set; }
        [Description("Mã nhân viên")]
        public string Manhanvien { get; set; }
        public QL_NGUOIDUNG() { }
        public QL_NGUOIDUNG Copy()
        {
            return (QL_NGUOIDUNG)this.MemberwiseClone();
        }
        public bool Compare_Differences(QL_NGUOIDUNG objCompare)
        {
            PropertyInfo[] fiCheck = objCompare.GetType().GetProperties();
            foreach (PropertyInfo f in fiCheck)
            {
                if (objCompare.GetType().GetProperty(f.Name).GetValue(objCompare, null) != null && this.GetType().GetProperty(f.Name).GetValue(this, null) != null)
                {
                    if (objCompare.GetType().GetProperty(f.Name).GetValue(objCompare, null).Equals(this.GetType().GetProperty(f.Name).GetValue(this, null)) == false)
                        return true;
                }
                else if (objCompare.GetType().GetProperty(f.Name).GetValue(objCompare, null) != null || this.GetType().GetProperty(f.Name).GetValue(this, null) != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
    #endregion

}
