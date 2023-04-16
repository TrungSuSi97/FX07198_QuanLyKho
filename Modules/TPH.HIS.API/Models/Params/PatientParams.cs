using System;

namespace TPH.HIS.WebAPI.Models.Params
{
    public class PatientParams
    {
        public int MaBenhNhan { get; set; }
        public string HoTen { get; set; }
        public int NamSinh { get; set; }
        public DateTime SinhNhat { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public int TrangThai { get; set; }
    }
}
