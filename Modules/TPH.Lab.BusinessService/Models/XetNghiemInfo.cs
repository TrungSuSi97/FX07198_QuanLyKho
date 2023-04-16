namespace TPH.Lab.BusinessService.Models
{
    using System;
    public class XetNghiemInfo
    {
        public string maxn { get; set; }
        public string tenxn { get; set; }
        public string maprofile { get; set; }
        public string Khuvucnhanid { get; set; }
        public string Khuvucthuchienid { get; set; }
        public string nguoiNhap { get; set; }
        public float Dongia { get; set; }
        public bool xetnghiemProfile { get; set; }
        //thông tin xn map mã máy
        public int idmay { get; set; }
        public string mamay { get; set; }
        public string mamay2 { get; set; }
        public bool camdown { get; set; }
        public Nullable<float> heso { get; set; }
        public bool dinhluong { get; set; }
        public bool dinhtinh { get; set; }

        //Dùng cho sàn lọc NHM
        public string idABO { get; set; }
        public string ABOResult { get; set; }
        public string idRh { get; set; }
        public string RhResult { get; set; }

        public DateTime? Thoigianlaymau { get; set; }
        public string Nguoilaymau { get; set; }
        public string Pcthuchien { get; set; }
        public bool ChiDinhNhapTuKQMay
        {
            get
            {
                return chiDinhNhapTuKQMay;
            }

            set
            {
                chiDinhNhapTuKQMay = value;
            }
        }

        //dùng cho chỉ định cho thêm
        private bool chiDinhNhapTuKQMay = false;
        public string MaCaptren { get; set; }
    }
}
