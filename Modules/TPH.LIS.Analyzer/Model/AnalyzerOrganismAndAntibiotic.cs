using System.Collections.Generic;

namespace TPH.LIS.Analyzer.Model
{
    public class AnalyzerOrganismAndAntibiotic
    {
        public List<Organism> lstDSViKhuan { get; set; }
        public List<AntiBiotic> lstDSKhangSinh { get; set; }
        public List<CoCheKhangKhangSinh> lstCoCheKhang { get; set; }
    }
    public class SampleTestMethod
    {
        public string MaTiepNhan { get; set; }
        public string MaYeuCau { get; set; }
        public string QuyTrinhMau { get; set; }
        public string IdMayXn { get; set; }
    }
    public class Organism
    {
        public int ResultID { get; set; }
        public string MaTiepNhan { get; set; }
        public string MaYeuCau { get; set; }
        public string MaViKhuanMay { get; set; }
        public string TenViKhuanMay { get; set; }
        public string MaViKhuan { get; set; }
        public string TestKitVK { get; set; }
        public string NguoiNhap { get; set; }
        public string idMayXn { get; set; }
        public string QuyTrinhMau { get; set; }
    }
    public class CoCheKhangKhangSinh
    {
        public int ResultID { get; set; }
        public string MaTiepNhan { get; set; }
        public string MaYeuCau { get; set; }
        public string MaViKhuan { get; set; }
        public string CoCheKhang { get; set; }
        public string KetquaCoCheKhang { get; set; }
        public string NguoiNhap { get; set; }
    }
    public class AntiBiotic
    {
        public  int ResultID { get; set; }
        public string MaTiepNhan { get; set; }
        public string MaYeuCau { get; set; }
        public string MaViKhuan { get; set; }
        public string MaKhangSinhMay { get; set; }
        public string TenKhangSinhMay { get; set; }
        public string MaKhangSinh { get; set; }
        public string KyThuat { get; set; }
        public string NguoiNhap { get; set; }
        public string TestKitKS { get; set; }
        public string KetQuaSIR { get; set; }
        public string KetQuaDinhLuong { get; set; }

        public string MaViKhuanMay { get; set; }
        public string TenViKhuanMay { get; set; }
        public string idMayXn { get; set; }
        public string QuyTrinhMau { get; set; }
        public string QuyTrinhKSD { get; set; }
        public string SiteInfection { get; set; }
    }
}
