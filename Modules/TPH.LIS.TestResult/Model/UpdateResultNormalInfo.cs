using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH.LIS.TestResult.Model
{
    public class UpdateResultNormalInfo
    {
        public string maTiepNhan { get; set; }
        public string maXN { get; set; }
        public string ketQua { get; set; }
        public bool capNhatghiChu { get; set; }
        public string ghiChu { get; set; }
        public string co { get; set; }
        public string userNhap { get; set; }
        public bool suaKQ { get; set; }
        public string round { get; set; }
        public string userUpdate { get; set; }
        public bool coCapnhatHeso { get; set; } = false;
        public string ketquaHeso { get; set; }
        public string iDMayXetNghiem { get; set; }
        public string modules { get; set; }
        public string maXNMay { get; set; }
        public bool updateCsbt = false;
        public string chisoBT { get; set; }
        public string canTren { get; set; }
        public string canDuoi { get; set; }
        public bool updateDVT { get; set; } = false;
        public string dvTinh { get; set; }
        public string dkBatThuong { get; set; }
        public bool tuValid { get; set; } = false;
        public string uservalid { get; set; }
        public DateTime? tgValid { get; set; } = null;
        public bool capnhatDinhLuong { get; set; } = false;
        public string ketquaDinhLuong { get; set; }
        public bool capnhatDinhTinh { get; set; } = false;
        public string ketquaDinhTinh { get; set; }
        public bool capnhatCoKetQua { get; set; } = false;
        public string coKetQua { get; set; }
        public string chisoBTCanhBao { get; set; }
        public string canTrenCanhBao { get; set; }
        public string canDuoiCanhBao { get; set; }
        public int coCanhBao { get; set; } = 0;
        public bool Qcout { get; set; } = false;
        public float Hesoquydoi { get; set; }
        public float? Ketquaquidoi { get; set; }
        public string Ketquadtquidoi { get; set; }
        public string Donviquidoi { get; set; }
        public string Csbtquidoi { get; set; }
    }
}
