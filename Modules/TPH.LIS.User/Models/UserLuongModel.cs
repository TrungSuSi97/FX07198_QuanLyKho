using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH.LIS.User.Models
{
    public class UserLuongModel
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string MaNhanVien { get; set; }
        public string MaBoPhan { get; set; }
        public string MaChucVu { get; set; }

        public int SoNgayLam { get; set; }
        public int SoNgayTangCa { get; set; }
        public int SoNgayDiMuon { get; set; }

        public bool isTangCa { get; set; }
        public bool isFull { get; set; }
        public bool isMuon { get; set; }
        public bool isKhoaSo { get; set; }

        public decimal LuongCoBan { get; set; }
        public decimal LuongThang { get; set; }

        public decimal LuongTangCa { get; set; }

        public decimal LuongChucVu { get; set; }

        public decimal LuongDiTre { get; set; }

        public decimal LuongThucNhan { get; set; }

    }
}
