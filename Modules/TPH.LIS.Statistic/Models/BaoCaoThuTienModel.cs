using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPH.LIS.Statistics.Models
{
   public class BaoCaoThuTienModel
    {

        private double tongBienLaiThu = 0;
        private double tongBienLaiChuaThu = 0;
        private double tongBienLaiHoan = 0;

        private double tongTienDoanhThu = 0;
        private double tongTienDaThu = 0;
        private double tongTienConNo = 0;
        private double tongTienChuaThu = 0;

        private double tongTienHoan = 0;
        private double tongTienThuThuc = 0;

        public double TongBienLaiThu
        {
            get
            {
                return tongBienLaiThu;
            }

            set
            {
                tongBienLaiThu = value;
            }
        }

        public double TongBienLaiHoan
        {
            get
            {
                return tongBienLaiHoan;
            }

            set
            {
                tongBienLaiHoan = value;
            }
        }

        public double TongTienDoanhThu
        {
            get
            {
                return tongTienDoanhThu;
            }

            set
            {
                tongTienDoanhThu = value;
            }
        }

        public double TongTienDaThu
        {
            get
            {
                return tongTienDaThu;
            }

            set
            {
                tongTienDaThu = value;
            }
        }

        public double TongTienConNo
        {
            get
            {
                return tongTienConNo;
            }

            set
            {
                tongTienConNo = value;
            }
        }

        public double TongTienHoan
        {
            get
            {
                return tongTienHoan;
            }

            set
            {
                tongTienHoan = value;
            }
        }

        public double TongTienThuThuc
        {
            get
            {
                return tongTienThuThuc;
            }

            set
            {
                tongTienThuThuc = value;
            }
        }

        public double TongBienLaiChuaThu
        {
            get
            {
                return tongBienLaiChuaThu;
            }

            set
            {
                tongBienLaiChuaThu = value;
            }
        }

        public double TongTienChuaThu
        {
            get
            {
                return tongTienChuaThu;
            }

            set
            {
                tongTienChuaThu = value;
            }
        }
    }
}
