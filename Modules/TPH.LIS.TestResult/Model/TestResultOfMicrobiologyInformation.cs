using System;
using System.Reflection;

namespace TPH.LIS.Patient.Model
{

    public class KETQUA_CLS_XETNGHIEM_VISINH
    {
        string _ketqua_cls_xetnghiem_visinh = "ketqua_cls_xetnghiem_visinh";
        public string Ketqua_cls_xetnghiem_visinh
        {
            get { return _ketqua_cls_xetnghiem_visinh; }
            set { _ketqua_cls_xetnghiem_visinh = value; }
        }

        public string Matiepnhan { get; set; }

        public string Mayeucau { get; set; }

        public string Tenyeucau { get; set; }

        public string Manhomyeucau { get; set; }
        decimal _giachuan = 0;
        public decimal Giachuan
        {
            get { return _giachuan; }
            set { _giachuan = value; }
        }
        decimal _giarieng = 0;
        public decimal Giarieng
        {
            get { return _giarieng; }
            set { _giarieng = value; }
        }
        int _thutuin = 1000;
        public int Thutuin
        {
            get { return _thutuin; }
            set { _thutuin = value; }
        }
        DateTime _gionhap = DateTime.Now;
        public DateTime Gionhap
        {
            get { return _gionhap; }
            set { _gionhap = value; }
        }

        public string Nguoinhap { get; set; }

        public string Mavattu { get; set; }

        public string Dvttieuhao { get; set; }
        float _tieuhao = 1;
        public float Tieuhao
        {
            get { return _tieuhao; }
            set { _tieuhao = value; }
        }
        float _chietkhau = 0;
        public float Chietkhau
        {
            get { return _chietkhau; }
            set { _chietkhau = value; }
        }
        decimal _tiencong = 0;
        public decimal Tiencong
        {
            get { return _tiencong; }
            set { _tiencong = value; }
        }

        public string Ketquasoi { get; set; }

        public string Ketquacay { get; set; }

        public string Ketquanhuom { get; set; }

        public string Nguoinhapketquasoi { get; set; }

        public string Nguoinhapketquanhuom { get; set; }

        public string Nguoinhapketquacay { get; set; }

        public DateTime? Gionhapketquasoi { get; set; }

        public DateTime? Gionhapketquanhuom { get; set; }

        public DateTime? Gionhapketquacay { get; set; }

        public string Nguoisuaketquasoi { get; set; }

        public string Nguoisuaketquanhuom { get; set; }

        public string Nguoisuaketquacay { get; set; }

        public DateTime? Giosuaketquasoi { get; set; }

        public DateTime? Giosuaketquanhuom { get; set; }

        public DateTime? Giosuaketquacay { get; set; }
        bool _dain = false;
        public bool Dain
        {
            get { return _dain; }
            set { _dain = value; }
        }

        public DateTime? Gioin { get; set; }

        public string Nguoiin { get; set; }
        int _lanin = 0;
        public int Lanin
        {
            get { return _lanin; }
            set { _lanin = value; }
        }

        public DateTime? Gioindautien { get; set; }
        bool _daxacnhan = false;
        public bool Daxacnhan
        {
            get { return _daxacnhan; }
            set { _daxacnhan = value; }
        }
        bool _dathutien = false;
        public bool Dathutien
        {
            get { return _dathutien; }
            set { _dathutien = value; }
        }

        public string Maphanloai { get; set; }

        public string Ketquanam { get; set; }

        public string Nguoinhapketquanam { get; set; }

        public DateTime? Gionhapketquanam { get; set; }

        public string Nguoisuaketquanam { get; set; }

        public DateTime? Giosuaketquanam { get; set; }
        public KETQUA_CLS_XETNGHIEM_VISINH() { }
        public KETQUA_CLS_XETNGHIEM_VISINH(string matiepnhan, string mayeucau, string tenyeucau, string manhomyeucau, decimal giachuan, decimal giarieng, int thutuin, DateTime gionhap, string nguoinhap, string mavattu
        , string dvttieuhao, float tieuhao, float chietkhau, decimal tiencong, string ketquasoi, string ketquacay, string ketquanhuom, string nguoinhapketquasoi, string nguoinhapketquanhuom, string nguoinhapketquacay
        , DateTime? gionhapketquasoi, DateTime? gionhapketquanhuom, DateTime? gionhapketquacay, string nguoisuaketquasoi, string nguoisuaketquanhuom, string nguoisuaketquacay, DateTime? giosuaketquasoi, DateTime? giosuaketquanhuom, DateTime? giosuaketquacay, bool dain
        , DateTime? gioin, string nguoiin, int lanin, DateTime? gioindautien, bool daxacnhan, bool dathutien, string maphanloai, string ketquanam, string nguoinhapketquanam, DateTime? gionhapketquanam
        , string nguoisuaketquanam, DateTime? giosuaketquanam)
        {
            this.Matiepnhan = matiepnhan;
            this.Mayeucau = mayeucau;
            this.Tenyeucau = tenyeucau;
            this.Manhomyeucau = manhomyeucau;
            this.Giachuan = giachuan;
            this.Giarieng = giarieng;
            this.Thutuin = thutuin;
            this.Gionhap = gionhap;
            this.Nguoinhap = nguoinhap;
            this.Mavattu = mavattu;
            this.Dvttieuhao = dvttieuhao;
            this.Tieuhao = tieuhao;
            this.Chietkhau = chietkhau;
            this.Tiencong = tiencong;
            this.Ketquasoi = ketquasoi;
            this.Ketquacay = ketquacay;
            this.Ketquanhuom = ketquanhuom;
            this.Nguoinhapketquasoi = nguoinhapketquasoi;
            this.Nguoinhapketquanhuom = nguoinhapketquanhuom;
            this.Nguoinhapketquacay = nguoinhapketquacay;
            this.Gionhapketquasoi = gionhapketquasoi;
            this.Gionhapketquanhuom = gionhapketquanhuom;
            this.Gionhapketquacay = gionhapketquacay;
            this.Nguoisuaketquasoi = nguoisuaketquasoi;
            this.Nguoisuaketquanhuom = nguoisuaketquanhuom;
            this.Nguoisuaketquacay = nguoisuaketquacay;
            this.Giosuaketquasoi = giosuaketquasoi;
            this.Giosuaketquanhuom = giosuaketquanhuom;
            this.Giosuaketquacay = giosuaketquacay;
            this.Dain = dain;
            this.Gioin = gioin;
            this.Nguoiin = nguoiin;
            this.Lanin = lanin;
            this.Gioindautien = gioindautien;
            this.Daxacnhan = daxacnhan;
            this.Dathutien = dathutien;
            this.Maphanloai = maphanloai;
            this.Ketquanam = ketquanam;
            this.Nguoinhapketquanam = nguoinhapketquanam;
            this.Gionhapketquanam = gionhapketquanam;
            this.Nguoisuaketquanam = nguoisuaketquanam;
            this.Giosuaketquanam = giosuaketquanam;
        }
        public KETQUA_CLS_XETNGHIEM_VISINH Copy()
        {
            return (KETQUA_CLS_XETNGHIEM_VISINH)this.MemberwiseClone();
        }
        public bool Compare_Differences(KETQUA_CLS_XETNGHIEM_VISINH objCompare)
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
    public class KETQUA_CLS_XETNGHIEM_VIKHUAN
    {
        string _ketqua_cls_xetnghiem_vikhuan = "ketqua_cls_xetnghiem_vikhuan";
        public string Ketqua_cls_xetnghiem_vikhuan
        {
            get { return _ketqua_cls_xetnghiem_vikhuan; }
            set { _ketqua_cls_xetnghiem_vikhuan = value; }
        }

        public string Matiepnhan { get; set; }

        public string Mayeucau { get; set; }

        public string Maphanloai { get; set; }

        public string Tenphanloai { get; set; }

        public string Danhphap { get; set; }

        public string Tenthuonggoi { get; set; }
        int _thutuxapxep = 1000;
        public int Thutuxapxep
        {
            get { return _thutuxapxep; }
            set { _thutuxapxep = value; }
        }
        DateTime _gionhap = DateTime.Now;
        public DateTime Gionhap
        {
            get { return _gionhap; }
            set { _gionhap = value; }
        }

        public string Nguoinhap { get; set; }

        public DateTime? Giosua { get; set; }

        public string Nguoisua { get; set; }
        bool _esbl = false;
        public bool Esbl
        {
            get { return _esbl; }
            set { _esbl = value; }
        }
        bool _mic = false;
        public bool Mic
        {
            get { return _mic; }
            set { _mic = value; }
        }

        public string Ketquaesbl { get; set; }
        public KETQUA_CLS_XETNGHIEM_VIKHUAN() { }
        public KETQUA_CLS_XETNGHIEM_VIKHUAN(string matiepnhan, string mayeucau, string maphanloai, string tenphanloai, string danhphap, string tenthuonggoi, int thutuxapxep, DateTime gionhap, string nguoinhap, DateTime? giosua
        , string nguoisua, bool esbl, bool mic, string ketquaesbl)
        {
            this.Matiepnhan = matiepnhan;
            this.Mayeucau = mayeucau;
            this.Maphanloai = maphanloai;
            this.Tenphanloai = tenphanloai;
            this.Danhphap = danhphap;
            this.Tenthuonggoi = tenthuonggoi;
            this.Thutuxapxep = thutuxapxep;
            this.Gionhap = gionhap;
            this.Nguoinhap = nguoinhap;
            this.Giosua = giosua;
            this.Nguoisua = nguoisua;
            this.Esbl = esbl;
            this.Mic = mic;
            this.Ketquaesbl = ketquaesbl;
        }
        public KETQUA_CLS_XETNGHIEM_VIKHUAN Copy()
        {
            return (KETQUA_CLS_XETNGHIEM_VIKHUAN)this.MemberwiseClone();
        }
        public bool Compare_Differences(KETQUA_CLS_XETNGHIEM_VIKHUAN objCompare)
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
    public class KETQUA_XETNGHIEM_KHANGSINHDO
    {
        string _ketqua_xetnghiem_khangsinhdo = "ketqua_xetnghiem_khangsinhdo";
        public string Ketqua_xetnghiem_khangsinhdo
        {
            get { return _ketqua_xetnghiem_khangsinhdo; }
            set { _ketqua_xetnghiem_khangsinhdo = value; }
        }

        public string Matiepnhan { get; set; }

        public string Mayeucau { get; set; }

        public string Maphanloai { get; set; }

        public string Makhangsinh { get; set; }

        public string Tenkhangsinh { get; set; }

        public float? Cannhay { get; set; }

        public float? Cankhang { get; set; }

        public float? Cantrunggiantren { get; set; }

        public float? Cantrunggianduoi { get; set; }

        public string Donvitinh { get; set; }

        public float? Cannhaymic { get; set; }

        public float? Cankhangmic { get; set; }

        public float? Cantrunggiantrenmic { get; set; }

        public float? Cantrunggianduoimic { get; set; }

        public string Donvitinhmic { get; set; }
        DateTime _gionhap = DateTime.Now;
        public DateTime Gionhap
        {
            get { return _gionhap; }
            set { _gionhap = value; }
        }

        public string Nguoinhap { get; set; }

        public DateTime? Giosua { get; set; }

        public string Nguoisua { get; set; }

        public string Ketquasri { get; set; }

        public string Ketquadinhluong { get; set; }

        public string Trangthai { get; set; }
        int _coketqua = 0;
        public int Coketqua
        {
            get { return _coketqua; }
            set { _coketqua = value; }
        }
        public KETQUA_XETNGHIEM_KHANGSINHDO() { }
        public KETQUA_XETNGHIEM_KHANGSINHDO(string matiepnhan, string mayeucau, string maphanloai, string makhangsinh, string tenkhangsinh, float? cannhay, float? cankhang, float? cantrunggiantren, float? cantrunggianduoi, string donvitinh
        , float? cannhaymic, float? cankhangmic, float? cantrunggiantrenmic, float? cantrunggianduoimic, string donvitinhmic, DateTime gionhap, string nguoinhap, DateTime? giosua, string nguoisua, string ketquasri
        , string ketquadinhluong, string trangthai, int coketqua)
        {
            this.Matiepnhan = matiepnhan;
            this.Mayeucau = mayeucau;
            this.Maphanloai = maphanloai;
            this.Makhangsinh = makhangsinh;
            this.Tenkhangsinh = tenkhangsinh;
            this.Cannhay = cannhay;
            this.Cankhang = cankhang;
            this.Cantrunggiantren = cantrunggiantren;
            this.Cantrunggianduoi = cantrunggianduoi;
            this.Donvitinh = donvitinh;
            this.Cannhaymic = cannhaymic;
            this.Cankhangmic = cankhangmic;
            this.Cantrunggiantrenmic = cantrunggiantrenmic;
            this.Cantrunggianduoimic = cantrunggianduoimic;
            this.Donvitinhmic = donvitinhmic;
            this.Gionhap = gionhap;
            this.Nguoinhap = nguoinhap;
            this.Giosua = giosua;
            this.Nguoisua = nguoisua;
            this.Ketquasri = ketquasri;
            this.Ketquadinhluong = ketquadinhluong;
            this.Trangthai = trangthai;
            this.Coketqua = coketqua;
        }
        public KETQUA_XETNGHIEM_KHANGSINHDO Copy()
        {
            return (KETQUA_XETNGHIEM_KHANGSINHDO)this.MemberwiseClone();
        }
        public bool Compare_Differences(KETQUA_XETNGHIEM_KHANGSINHDO objCompare)
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

    public class KETQUA_CLS_XETNGHIEM_KHAOSATDAITHE
    {
        string _ketqua_cls_xetnghiem_khaosatdaithe = "ketqua_cls_xetnghiem_khaosatdaithe";
        public string Ketqua_cls_xetnghiem_khaosatdaithe
        {
            get { return _ketqua_cls_xetnghiem_khaosatdaithe; }
            set { _ketqua_cls_xetnghiem_khaosatdaithe = value; }
        }
        string _matiepnhan;
        public string Matiepnhan
        {
            get { return _matiepnhan; }
            set { _matiepnhan = value; }
        }
        string _makhaosat;
        public string Makhaosat
        {
            get { return _makhaosat; }
            set { _makhaosat = value; }
        }
        string _tenkhaosat;
        public string Tenkhaosat
        {
            get { return _tenkhaosat; }
            set { _tenkhaosat = value; }
        }
        string _ketquakhaosat;
        public string Ketquakhaosat
        {
            get { return _ketquakhaosat; }
            set { _ketquakhaosat = value; }
        }
        string _nguoinhapketqua;
        public string Nguoinhapketqua
        {
            get { return _nguoinhapketqua; }
            set { _nguoinhapketqua = value; }
        }
        DateTime? _thoigiannhap;
        public DateTime? Thoigiannhap
        {
            get { return _thoigiannhap; }
            set { _thoigiannhap = value; }
        }
        string _nguoisuaketqua;
        public string Nguoisuaketqua
        {
            get { return _nguoisuaketqua; }
            set { _nguoisuaketqua = value; }
        }
        DateTime? _thoigiansuaketqua;
        public DateTime? Thoigiansuaketqua
        {
            get { return _thoigiansuaketqua; }
            set { _thoigiansuaketqua = value; }
        }

        public string Mayeucau { get; set; }
        public string GhiChu { get; set; }

        public KETQUA_CLS_XETNGHIEM_KHAOSATDAITHE() { }
        public KETQUA_CLS_XETNGHIEM_KHAOSATDAITHE(string matiepnhan, string makhaosat, string tenkhaosat, string ketquakhaosat, string nguoinhapketqua, DateTime? thoigiannhap, string nguoisuaketqua, DateTime? thoigiansuaketqua)
        {
            this.Matiepnhan = matiepnhan;
            this.Makhaosat = makhaosat;
            this.Tenkhaosat = tenkhaosat;
            this.Ketquakhaosat = ketquakhaosat;
            this.Nguoinhapketqua = nguoinhapketqua;
            this.Thoigiannhap = thoigiannhap;
            this.Nguoisuaketqua = nguoisuaketqua;
            this.Thoigiansuaketqua = thoigiansuaketqua;
        }
        public KETQUA_CLS_XETNGHIEM_KHAOSATDAITHE Copy()
        {
            return (KETQUA_CLS_XETNGHIEM_KHAOSATDAITHE)this.MemberwiseClone();
        }
        public bool Compare_Differences(KETQUA_CLS_XETNGHIEM_KHAOSATDAITHE objCompare)
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
    #region ketqua_cls_xetnghiem_visinh_khangkhangsinh
    public class KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH
    {
        string _ketqua_cls_xetnghiem_visinh_khangkhangsinh = "ketqua_cls_xetnghiem_visinh_khangkhangsinh";
        public string Ketqua_cls_xetnghiem_visinh_khangkhangsinh
        {
            get { return _ketqua_cls_xetnghiem_visinh_khangkhangsinh; }
            set { _ketqua_cls_xetnghiem_visinh_khangkhangsinh = value; }
        }

        public string Matiepnhan { get; set; }

        public string Mayeucau { get; set; }

        public string Maphanloai { get; set; }

        public string Makhangkhangsinh { get; set; }

        public string Ketqua { get; set; }
        public string Ketquachu { get; set; }
        public string Nguoinhap { get; set; }
        DateTime _tgnhap = DateTime.Now;
        public DateTime Tgnhap
        {
            get { return _tgnhap; }
            set { _tgnhap = value; }
        }

        public string Nguoisua { get; set; }

        public DateTime? Tgsua { get; set; }
        public int LanXetNghiem { get; set; }
        public KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH() { }
        public KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH(string matiepnhan, string mayeucau
              , string maphanloai, string makhangkhangsinh, string ketqua, string nguoinhap
              , DateTime tgnhap, string nguoisua, DateTime? tgsua, int lanXetNghiem)
        {
            this.Matiepnhan = matiepnhan;
            this.Mayeucau = mayeucau;
            this.Maphanloai = maphanloai;
            this.Makhangkhangsinh = makhangkhangsinh;
            this.Ketqua = ketqua;
            this.Nguoinhap = nguoinhap;
            this.Tgnhap = tgnhap;
            this.Nguoisua = nguoisua;
            this.Tgsua = tgsua;
            this.LanXetNghiem = lanXetNghiem;
        }
        public KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH Copy()
        {
            return (KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH)this.MemberwiseClone();
        }
        public bool Compare_Differences(KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH objCompare)
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
