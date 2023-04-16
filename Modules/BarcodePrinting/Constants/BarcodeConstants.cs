using System.Collections.Generic;

namespace TPH.LIS.BarcodePrinting.Constants
{
    public class BarcodeConstants
    {
    }
    public class Loaibarcode
    {
        public enum EnumLoaiBarcode
        {
            ThongThuong = 0,
            KhamSucKhoe = 1,
            MaSoMauSHPT = 2,
            MaSoMauVSNC = 3
        }
        public int IdLoaiBarcode { get; set; }
        public string TenLoaiBarcode { get; set; }

        public static List<Loaibarcode> ListLoaibarcode()
        {
            var list = new List<Loaibarcode>();
            list.Add(new Loaibarcode
            {
                IdLoaiBarcode = (int)EnumLoaiBarcode.ThongThuong,
                TenLoaiBarcode = "Thông thường"
            });
            list.Add(new Loaibarcode
            {
                IdLoaiBarcode = (int)EnumLoaiBarcode.KhamSucKhoe,
                TenLoaiBarcode = "Khám sức khỏe"
            });
            list.Add(new Loaibarcode
            {
                IdLoaiBarcode = (int)EnumLoaiBarcode.MaSoMauSHPT,
                TenLoaiBarcode = "Mã số mẫu SHPT"
            });
            list.Add(new Loaibarcode
            {
                IdLoaiBarcode = (int)EnumLoaiBarcode.MaSoMauVSNC,
                TenLoaiBarcode = "Mã số mẫu VSNC"
            });
            return list;
        }
    }

}
