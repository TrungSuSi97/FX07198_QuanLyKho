using System;
using System.Reflection;

namespace TPH.LIS.Patient.Model
{
    public class KETQUA_CLS_XETNGHIEM
    {
        public string Matiepnhan { get; set; }

        public string Maxn { get; set; }

        public string Tenxn { get; set; }

        public string Ketqua { get; set; }

        public string Ghichu { get; set; }

        public string Manhomcls { get; set; }

        public string Csbt { get; set; }

        public string Donvi { get; set; }

        public float? Nguongtren { get; set; }

        public float? Nguongduoi { get; set; }
        int _sapxep = 1;
        public int Sapxep
        {
            get { return _sapxep; }
            set { _sapxep = value; }
        }
        bool _indam = false;
        public bool Indam
        {
            get { return _indam; }
            set { _indam = value; }
        }
        bool _indamkq = false;
        public bool Indamkq
        {
            get { return _indamkq; }
            set { _indamkq = value; }
        }
        int _kichcochu = 12;
        public int Kichcochu
        {
            get { return _kichcochu; }
            set { _kichcochu = value; }
        }
        int _kichcokq = 12;
        public int Kichcokq
        {
            get { return _kichcokq; }
            set { _kichcokq = value; }
        }
        int _canhle = 1;
        public int Canhle
        {
            get { return _canhle; }
            set { _canhle = value; }
        }
        int _thutuin = 1;
        public int Thutuin
        {
            get { return _thutuin; }
            set { _thutuin = value; }
        }
        bool _xnchinh = false;
        public bool Xnchinh
        {
            get { return _xnchinh; }
            set { _xnchinh = value; }
        }
        bool _khongsudung = false;
        public bool Khongsudung
        {
            get { return _khongsudung; }
            set { _khongsudung = value; }
        }

        public string Loaimau { get; set; }
        DateTime _thoigiannhap = DateTime.Now;
        public DateTime Thoigiannhap
        {
            get { return _thoigiannhap; }
            set { _thoigiannhap = value; }
        }

        public string Profileid { get; set; }
        int _flat = 1;
        public int Flat
        {
            get { return _flat; }
            set { _flat = value; }
        }
        string _trangthai = "Chưa xác nhận";
        public string Trangthai
        {
            get { return _trangthai; }
            set { _trangthai = value; }
        }
        bool _xacnhankq = false;
        public bool Xacnhankq
        {
            get { return _xacnhankq; }
            set { _xacnhankq = value; }
        }

        public string Nguoixacnhan { get; set; }

        public string Dkbatthuong { get; set; }
        int _tgcoketqua = 0;
        public int Tgcoketqua
        {
            get { return _tgcoketqua; }
            set { _tgcoketqua = value; }
        }
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
        int _hesoxn = 1;
        public int Hesoxn
        {
            get { return _hesoxn; }
            set { _hesoxn = value; }
        }
        int _madichvucls = 1;
        public int Madichvucls
        {
            get { return _madichvucls; }
            set { _madichvucls = value; }
        }

        public DateTime? Thoigiannhapkq { get; set; }

        public DateTime? Thoigiansuakq { get; set; }

        public string Usernhapkq { get; set; }

        public string Usersuakq { get; set; }
        bool _dathutien = false;
        public bool Dathutien
        {
            get { return _dathutien; }
            set { _dathutien = value; }
        }

        public string Usernhapcd { get; set; }

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
        float _hesoquidoi = 0;
        public float Hesoquidoi
        {
            get { return _hesoquidoi; }
            set { _hesoquidoi = value; }
        }

        public float? Ketquaquidoi { get; set; }

        public string Donviquidoi { get; set; }

        public string Csbtquidoi { get; set; }
        bool _dadownload = false;
        public bool Dadownload
        {
            get { return _dadownload; }
            set { _dadownload = value; }
        }
        int _idmaydownload = 0;
        public int Idmaydownload
        {
            get { return _idmaydownload; }
            set { _idmaydownload = value; }
        }
        int _idmayxetnghiem = 0;
        public int Idmayxetnghiem
        {
            get { return _idmayxetnghiem; }
            set { _idmayxetnghiem = value; }
        }

        public string Tenmayxetnghiem { get; set; }

        public string Maphanloai { get; set; }

        public DateTime? Datedownload { get; set; }

        public string Maxnmay { get; set; }
        bool? _uploadweb = false;
        public bool? Uploadweb
        {
            get { return _uploadweb; }
            set { _uploadweb = value; }
        }
        bool _khongin = false;
        public bool Khongin
        {
            get { return _khongin; }
            set { _khongin = value; }
        }

        public decimal Giabenhnhan { get; set; }
        public string Rsophieuyeucau { get; set; }
        public string Stt { get; set; }
        public string Maxn_his { get; set; }
        public int Transferresultothis { get; set; }
        public bool Downloadanother { get; set; }
        public string TenNhomLoaimau { get; set; }
        public string BCRoBoTypeID { get; set; }
        public string TenNhomCLS { get; set; }
        public DateTime Thoigianlaymau { get; set; }
        public string Nguoilaymau { get; set; }
        public string Idchitiethis { get; set; }

        public KETQUA_CLS_XETNGHIEM() { }
        public KETQUA_CLS_XETNGHIEM(string matiepnhan, string maxn, string tenxn, string ketqua, string ghichu, string manhomcls, string csbt, string donvi, float? nguongtren, float? nguongduoi
        , int sapxep, bool indam, bool indamkq, int kichcochu, int kichcokq, int canhle, int thutuin, bool xnchinh, bool khongsudung, string loaimau
        , DateTime thoigiannhap, string profileid, int flat, string trangthai, bool xacnhankq, string nguoixacnhan, string dkbatthuong, int tgcoketqua, decimal giachuan, decimal giarieng
        , int hesoxn, int madichvucls, DateTime? thoigiannhapkq, DateTime? thoigiansuakq, string usernhapkq, string usersuakq, bool dathutien, string usernhapcd, string mavattu, string dvttieuhao
        , float tieuhao, float chietkhau, decimal tiencong, float hesoquidoi, float? ketquaquidoi, string donviquidoi, string csbtquidoi, bool dadownload, int idmaydownload, int idmayxetnghiem
        , string tenmayxetnghiem, string maphanloai, DateTime? datedownload, string maxnmay, bool? uploadweb, bool khongin)
        {
            this.Matiepnhan = matiepnhan;
            this.Maxn = maxn;
            this.Tenxn = tenxn;
            this.Ketqua = ketqua;
            this.Ghichu = ghichu;
            this.Manhomcls = manhomcls;
            this.Csbt = csbt;
            this.Donvi = donvi;
            this.Nguongtren = nguongtren;
            this.Nguongduoi = nguongduoi;
            this.Sapxep = sapxep;
            this.Indam = indam;
            this.Indamkq = indamkq;
            this.Kichcochu = kichcochu;
            this.Kichcokq = kichcokq;
            this.Canhle = canhle;
            this.Thutuin = thutuin;
            this.Xnchinh = xnchinh;
            this.Khongsudung = khongsudung;
            this.Loaimau = loaimau;
            this.Thoigiannhap = thoigiannhap;
            this.Profileid = profileid;
            this.Flat = flat;
            this.Trangthai = trangthai;
            this.Xacnhankq = xacnhankq;
            this.Nguoixacnhan = nguoixacnhan;
            this.Dkbatthuong = dkbatthuong;
            this.Tgcoketqua = tgcoketqua;
            this.Giachuan = giachuan;
            this.Giarieng = giarieng;
            this.Hesoxn = hesoxn;
            this.Madichvucls = madichvucls;
            this.Thoigiannhapkq = thoigiannhapkq;
            this.Thoigiansuakq = thoigiansuakq;
            this.Usernhapkq = usernhapkq;
            this.Usersuakq = usersuakq;
            this.Dathutien = dathutien;
            this.Usernhapcd = usernhapcd;
            this.Mavattu = mavattu;
            this.Dvttieuhao = dvttieuhao;
            this.Tieuhao = tieuhao;
            this.Chietkhau = chietkhau;
            this.Tiencong = tiencong;
            this.Hesoquidoi = hesoquidoi;
            this.Ketquaquidoi = ketquaquidoi;
            this.Donviquidoi = donviquidoi;
            this.Csbtquidoi = csbtquidoi;
            this.Dadownload = dadownload;
            this.Idmaydownload = idmaydownload;
            this.Idmayxetnghiem = idmayxetnghiem;
            this.Tenmayxetnghiem = tenmayxetnghiem;
            this.Maphanloai = maphanloai;
            this.Datedownload = datedownload;
            this.Maxnmay = maxnmay;
            this.Uploadweb = uploadweb;
            this.Khongin = khongin;
        }
        public KETQUA_CLS_XETNGHIEM Copy()
        {
            return (KETQUA_CLS_XETNGHIEM)this.MemberwiseClone();
        }
        public bool Compare_Differences(KETQUA_CLS_XETNGHIEM objCompare)
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
}
