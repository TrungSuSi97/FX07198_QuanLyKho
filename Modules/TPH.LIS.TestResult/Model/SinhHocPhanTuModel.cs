using System;
using System.Drawing;
using System.Reflection;

namespace TPH.LIS.TestResult.Model
{
    #region ketqua_cls_xetnghiem_spht
    public class KETQUA_CLS_XETNGHIEM_SPHT
    {
        string _ketqua_cls_xetnghiem_spht = "ketqua_cls_xetnghiem_spht";
        public string Ketqua_cls_xetnghiem_spht
        {
            get { return _ketqua_cls_xetnghiem_spht; }
            set { _ketqua_cls_xetnghiem_spht = value; }
        }

        public string Matiepnhan { get; set; }

        public string Maxn { get; set; }

        public string KetLuan { get; set; }

        public string KetQuaHeSo { get; set; }
        public bool CapNhatKetQuaDinhTinh { get; set; }
        public bool CapNhatKetQuaDinhLuong { get; set; }
        public string KetQuaDinhTinh { get; set; }
        public string KetQuaDinhLuong { get; set; }
        public string GhiChu { get; set; }
        public bool CapNhatDonVi { get; set; }
        public string DonViTinh { get; set; }
        public string NguongTren { get; set; }

        public string NguongDuoi { get; set; }

        public string DKBatThuong { get; set; }

        public Image Hinhanh1 { get; set; }

        public Image Hinhanh2 { get; set; }

        public Image Hinhanh3 { get; set; }

        public Image Hinhanh4 { get; set; }

        public Image Hinhanh5 { get; set; }

        public DateTime Tgcokq { get; set; }

        public string Nguoinhap { get; set; }

        public string Nguoisua { get; set; }

        public DateTime? Tgsua { get; set; }
        public string IDMayXn { get; set; }
        public string KTQuaGenKhac { get; set; }
        public string PhuongPhap { get; set; }
        public string NoiKiemTra { get; set; }
        public bool withImage = false;
        public bool suaKetqua = false;
        public bool coNgaykhoiPhat = false;
        public bool CapNhatGhiChu = true;
        /// <summary>
        /// TG Xác nhận thực hiện => TG khởi phát
        /// </summary>
        public DateTime? ThoiGianXacNhanThucHien { get; set; }
        /// <summary>
        /// Lần xét nghiệm lưu vào sắp xếp
        /// </summary>
        public int LanXetNghiem { get; set; }
        public KETQUA_CLS_XETNGHIEM_SPHT() { }

        public KETQUA_CLS_XETNGHIEM_SPHT Copy()
        {
            return (KETQUA_CLS_XETNGHIEM_SPHT)this.MemberwiseClone();
        }
        public bool Compare_Differences(KETQUA_CLS_XETNGHIEM_SPHT objCompare)
        {
            PropertyInfo[] fiCheck = objCompare.GetType().GetProperties();
            foreach (PropertyInfo f in fiCheck)
            {
                if (objCompare.GetType().GetProperty(f.Name).GetValue(objCompare, null) != null && this.GetType().GetProperty(f.Name).GetValue(this, null) != null)
                {
                    if (objCompare.GetType().GetProperty(f.Name).GetValue(objCompare, null).Equals(this.GetType().GetProperty(f.Name).GetValue(this, null)) == false)
                        return true;
                }
                else if (objCompare.GetType().GetProperty(f.Name).GetValue(objCompare, null) != null || this.GetType().GetProperty(f.Name).GetValue(this, null) != null)
                {
                    return true;
                }
            }
            return false;
        }

    }
    #endregion
    #region ketqua_cls_xetnghiem_shpt_gen
    public class KETQUA_CLS_XETNGHIEM_SHPT_GEN
    {
        string _ketqua_cls_xetnghiem_shpt_gen = "ketqua_cls_xetnghiem_shpt_gen";
        public string Ketqua_cls_xetnghiem_shpt_gen
        {
            get { return _ketqua_cls_xetnghiem_shpt_gen; }
            set { _ketqua_cls_xetnghiem_shpt_gen = value; }
        }

        public string Matiepnhan { get; set; }

        public string Maxn { get; set; }

        public string Magen { get; set; }

        public string Ketquadinhtinh { get; set; }

        public string Ketquadinhluong { get; set; }
        string _nguoinhap = "DateTime.Now";
        public string Nguoinhap
        {
            get { return _nguoinhap; }
            set { _nguoinhap = value; }
        }

        public DateTime Tgnhap { get; set; }

        public string Nguoisua { get; set; }

        public DateTime? Tgsua { get; set; }

        public string Donvitinh { get; set; }

        public float? Cantren { get; set; }

        public float? Canduoi { get; set; }

        public string Dkdanhgia { get; set; }
        public KETQUA_CLS_XETNGHIEM_SHPT_GEN() { }
        public KETQUA_CLS_XETNGHIEM_SHPT_GEN(string matiepnhan, string maxn, string magen, string ketquadinhtinh, string ketquadinhluong, string nguoinhap, DateTime tgnhap, string nguoisua, DateTime? tgsua, string donvitinh
        , float? cantren, float? canduoi, string dkdanhgia)
        {
            this.Matiepnhan = matiepnhan;
            this.Maxn = maxn;
            this.Magen = magen;
            this.Ketquadinhtinh = ketquadinhtinh;
            this.Ketquadinhluong = ketquadinhluong;
            this.Nguoinhap = nguoinhap;
            this.Tgnhap = tgnhap;
            this.Nguoisua = nguoisua;
            this.Tgsua = tgsua;
            this.Donvitinh = donvitinh;
            this.Cantren = cantren;
            this.Canduoi = canduoi;
            this.Dkdanhgia = dkdanhgia;
        }
        public KETQUA_CLS_XETNGHIEM_SHPT_GEN Copy()
        {
            return (KETQUA_CLS_XETNGHIEM_SHPT_GEN)this.MemberwiseClone();
        }
        public bool Compare_Differences(KETQUA_CLS_XETNGHIEM_SHPT_GEN objCompare)
        {
            PropertyInfo[] fiCheck = objCompare.GetType().GetProperties();
            foreach (PropertyInfo f in fiCheck)
            {
                if (objCompare.GetType().GetProperty(f.Name).GetValue(objCompare, null) != null && this.GetType().GetProperty(f.Name).GetValue(this, null) != null)
                {
                    if (objCompare.GetType().GetProperty(f.Name).GetValue(objCompare, null).Equals(this.GetType().GetProperty(f.Name).GetValue(this, null)) == false)
                        return true;
                }
                else if (objCompare.GetType().GetProperty(f.Name).GetValue(objCompare, null) != null || this.GetType().GetProperty(f.Name).GetValue(this, null) != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
    #endregion
}
