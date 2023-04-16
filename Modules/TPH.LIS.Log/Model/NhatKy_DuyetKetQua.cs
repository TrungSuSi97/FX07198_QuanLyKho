using System;

namespace TPH.LIS.Log.Model
{
    public class NhatKy_DuyetKetQua
    {
        public string MaTiepNhan { get; set; }
        public string NoiDung { get; set; }
    }
    public class NhatKy_DuyetKetQua_ChiTiet
    {
        public string MaXN { get; set; }
        public string TenXN { get; set; }
        public string KetQua { get; set; }
        public string NguoiDuyetTruoc { get; set; }
        public string NguoiDuyetMoi { get; set; }
        public string TenNguoiDuyetMoi { get; set; }
        public DateTime TGThucHien { get; set; }
        public string TenMayTinh { get; set; }
        public bool ThaoTacDuyet { get; set; }
    }
}
