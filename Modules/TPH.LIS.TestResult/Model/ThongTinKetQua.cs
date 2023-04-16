namespace TPH.LIS.TestResult.Model
{
    public class ThongTinKetQua
    {
        public string KetQua { get; set; }
        public int IdMayXetNghiem { get; set; }
        public float NguongDuoi { get; set; }
        public float NguongTren { get; set; }
        public string GiaTriThamChieu { get; set; }
        public int CoKetQua { get; set; }

        public float NguongDuoiCanhBao { get; set; }
        public float NguongTrenCanhBao { get; set; }
        public string GiaTriThamChieuCanhBao { get; set; }
        public int CoKetQuaCanhBao { get; set; }
        public string GhiChu { get; set; }

        public string KetQuaQuiDoi { get; set; }
        public string KQDinhTinhQuyDoi { get; set; }
        public string DonViQuiDoi { get; set; }
        public string CSBTQuiDoi { get; set; }
        public string HeSoQuiDoi { get; set; }

    }
}
