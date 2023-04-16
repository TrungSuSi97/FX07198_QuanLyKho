using System;

namespace TPH.LIS.TestResult.Constants
{
    public class DieuKienInTuDong
    {
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }
        public string TuBarCode { get; set; }
        public string DenBarcode { get; set; }
        public string ListKhoaChiDinh { get; set; }
        public string ListKhoaHienthoi { get; set; }
        public string ListAllowBoPhan { get; set; }
        public string ListAllowNhom { get; set; }
        public string ListAllowDoiTuong { get; set; }
        public string ListAllowKhuDieuTri { get; set; }
        public bool XacNhanBenhNhan { get; set; }
        public bool XacNhanTheoKhoa { get; set; }
        public bool ChiInCoKetQua { get; set; }
        public  string PCName { get; set; }
        public string UserValid { get; set; }
        public bool XacNhanTheoNhom { get; set; }
        public int DaIn { get; set; } = 2;
        private int soPhutDaKiemTra = -1;
        public int SoPhutDaKiemTra
        {
            get { return soPhutDaKiemTra; }
            set { soPhutDaKiemTra = value; }
        }
        public bool DungChoCapNhat { get; set; }
        public bool showMessage = true;
        /// <summary>
        /// 0: Ngay nhap vien - 1: Ngay nhan mau - 2: Ngay duyet ket qua
        /// </summary>
        public int IdNgay { get; set; }

    }
}
