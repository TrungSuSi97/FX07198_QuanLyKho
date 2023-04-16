using System;
using System.ComponentModel;
using System.Reflection;

namespace TPH.LIS.Patient.Model
{
    #region benhnhan
    public class BENHNHAN
    {
        string _benhnhan = "benhnhan";
        public string Benhnhan
        {
            get { return _benhnhan; }
            set { _benhnhan = value; }
        }

        public string Mabn { get; set; }

        public string Tenbn { get; set; }

        public DateTime? Ngaysinh { get; set; }
        int _namsinh = 0;
        public int Namsinh
        {
            get { return _namsinh; }
            set { _namsinh = value; }
        }
        bool _congaysinh = false;
        public bool Congaysinh
        {
            get { return _congaysinh; }
            set { _congaysinh = value; }
        }

        public string Gioitinh { get; set; }
        DateTime _thoigiannhap = DateTime.Now;
        public DateTime Thoigiannhap
        {
            get { return _thoigiannhap; }
            set { _thoigiannhap = value; }
        }

        public string Usernhap { get; set; }

        public string Diachi { get; set; }

        public string Sonha { get; set; }

        public string Phuongxa { get; set; }

        public int? Mahuyen { get; set; }

        public int? Matinh { get; set; }

        public string Email { get; set; }

        public string Sdt { get; set; }

        public DateTime? Ngaydk { get; set; }

        public string Usercapnhat { get; set; }
         public int Partitionid { get; set; }

        public string Ghichu { get; set; }

        public string Madoituongdv { get; set; }

        public string Doituongbn { get; set; }

        public string Idcongdan { get; set; }

        public DateTime? Ngaycapid { get; set; }

        public DateTime? Ngayhethan { get; set; }

        public string Quoctich { get; set; }

        public string Sobhyt { get; set; }

        public DateTime? Ngayhethanbhyt { get; set; }
        public BENHNHAN() { }
        public BENHNHAN(string mabn, string tenbn, DateTime? ngaysinh, int namsinh, bool congaysinh, string gioitinh, DateTime thoigiannhap, string usernhap, string diachi, string sonha
        , string phuongxa, int? mahuyen, int? matinh, string email, string sdt, DateTime? ngaydk, string usercapnhat, int partitionid, string ghichu, string madoituongdv
        , string doituongbn, string idcongdan, DateTime? ngaycapid, DateTime? ngayhethan, string quoctich, string sobhyt, DateTime? ngayhethanbhyt)
        {
            this.Mabn = mabn;
            this.Tenbn = tenbn;
            this.Ngaysinh = ngaysinh;
            this.Namsinh = namsinh;
            this.Congaysinh = congaysinh;
            this.Gioitinh = gioitinh;
            this.Thoigiannhap = thoigiannhap;
            this.Usernhap = usernhap;
            this.Diachi = diachi;
            this.Sonha = sonha;
            this.Phuongxa = phuongxa;
            this.Mahuyen = mahuyen;
            this.Matinh = matinh;
            this.Email = email;
            this.Sdt = sdt;
            this.Ngaydk = ngaydk;
            this.Usercapnhat = usercapnhat;
            this.Partitionid = partitionid;
            this.Ghichu = ghichu;
            this.Madoituongdv = madoituongdv;
            this.Doituongbn = doituongbn;
            this.Idcongdan = idcongdan;
            this.Ngaycapid = ngaycapid;
            this.Ngayhethan = ngayhethan;
            this.Quoctich = quoctich;
            this.Sobhyt = sobhyt;
            this.Ngayhethanbhyt = ngayhethanbhyt;
        }
        public BENHNHAN Copy()
        {
            return (BENHNHAN)this.MemberwiseClone();
        }
        public bool Compare_Differences(BENHNHAN objCompare)
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
    #region benhnhan_tiepnhan
    public class BENHNHAN_TIEPNHAN
    {
        string _benhnhan_tiepnhan = "benhnhan_tiepnhan";
        public string Benhnhan_tiepnhan
        {
            get { return _benhnhan_tiepnhan; }
            set { _benhnhan_tiepnhan = value; }
        }

        public string Matiepnhan { get; set; }

        public string Seq { get; set; }
        bool _noitru = false;
        public bool Noitru
        {
            get { return _noitru; }
            set { _noitru = value; }
        }

        public string Mabn { get; set; }

        public string Sobhyt { get; set; }

        public DateTime? Ngayhethanbhyt { get; set; }

        public string Tenbn { get; set; }

        public DateTime? Sinhnhat { get; set; }
        int _tuoi = 0;
        public int Tuoi
        {
            get { return _tuoi; }
            set { _tuoi = value; }
        }
        bool _congaysinh = false;
        public bool Congaysinh
        {
            get { return _congaysinh; }
            set { _congaysinh = value; }
        }

        public string Gioitinh { get; set; }

        public DateTime Ngaytiepnhan { get; set; }
        DateTime _thoigiannhap = DateTime.Now;
        public DateTime Thoigiannhap
        {
            get { return _thoigiannhap; }
            set { _thoigiannhap = value; }
        }

        public string Usernhap { get; set; }

        public string Doituongdichvu { get; set; }

        public string Diachi { get; set; }

        public string Sonha { get; set; }

        public string Phuongxa { get; set; }

        public int? Mahuyen { get; set; }

        public int? Matinh { get; set; }

        public string Email { get; set; }

        public string Sdt { get; set; }
        bool _daguimail = false;
        public bool Daguimail
        {
            get { return _daguimail; }
            set { _daguimail = value; }
        }

        public DateTime? Tgguimail { get; set; }
        bool _dichvukhambenh = false;
        public bool Dichvukhambenh
        {
            get { return _dichvukhambenh; }
            set { _dichvukhambenh = value; }
        }
        bool _dichvuxetnghiem = false;
        public bool Dichvuxetnghiem
        {
            get { return _dichvuxetnghiem; }
            set { _dichvuxetnghiem = value; }
        }
        bool _dichvuxquang = false;
        public bool Dichvuxquang
        {
            get { return _dichvuxquang; }
            set { _dichvuxquang = value; }
        }
        bool _dichvusieuam = false;
        public bool Dichvusieuam
        {
            get { return _dichvusieuam; }
            set { _dichvusieuam = value; }
        }
        bool _dichvunoisoi = false;
        public bool Dichvunoisoi
        {
            get { return _dichvunoisoi; }
            set { _dichvunoisoi = value; }
        }
        bool _dichvudientim = false;
        public bool Dichvudientim
        {
            get { return _dichvudientim; }
            set { _dichvudientim = value; }
        }
        bool _dichvukhac = false;
        public bool Dichvukhac
        {
            get { return _dichvukhac; }
            set { _dichvukhac = value; }
        }
        bool _khamlandau = false;
        public bool Khamlandau
        {
            get { return _khamlandau; }
            set { _khamlandau = value; }
        }

        public DateTime? Tgvaovien { get; set; }

        public string Yeucau { get; set; }

        public string Madonvi { get; set; }

        public string Tendonvi { get; set; }

        public string Tiensubenh { get; set; }

        public string Tinhtrangbenh { get; set; }

        public string Nhanxetbs { get; set; }

        public string Usercapnhat { get; set; }

        public string Bacsicd { get; set; }

        public string Chandoan { get; set; }
        bool _sent = false;
        public bool Sent
        {
            get { return _sent; }
            set { _sent = value; }
        }

        public string Nguonnhap { get; set; }

        public DateTime? Datesent { get; set; }
        decimal _chietkhau = 0;
        public decimal Chietkhau
        {
            get { return _chietkhau; }
            set { _chietkhau = value; }
        }

        public string Sophieuyeucau { get; set; }
        int? _mamayin = 1;
        public int? Mamayin
        {
            get { return _mamayin; }
            set { _mamayin = value; }
        }

        public DateTime? Ngaydk { get; set; }
        bool _allowdownload = false;
        public bool Allowdownload
        {
            get { return _allowdownload; }
            set { _allowdownload = value; }
        }

        public string Makhuvuc { get; set; }

        public string Dotkham_id { get; set; }

        public string Chuyenkhoa_id { get; set; }

        public string Giayto_id { get; set; }
        public string IDGiayto { get; set; }
        public string Bn_id { get; set; }

        public string Manoicapthebhyt { get; set; }

        public string Manoidangkythebhyt { get; set; }

        public string Giuong { get; set; }

        public string Buong { get; set; }
        bool _capcuu = false;
        public bool Capcuu
        {
            get { return _capcuu; }
            set { _capcuu = value; }
        }

        public string Idcongdan { get; set; }
        decimal _dathutien = 0;
        public decimal Dathutien
        {
            get { return _dathutien; }
            set { _dathutien = value; }
        }
        decimal _tongthanhtien = 0;
        public decimal Tongthanhtien
        {
            get { return _tongthanhtien; }
            set { _tongthanhtien = value; }
        }
        int _partitionid = int.Parse(DateTime.Now.ToString("yMM"));
        public int Partitionid
        {
            get { return _partitionid; }
            set { _partitionid = value; }
        }

        public string Doituong { get; set; }
        int _hisproviderid = 0;
        public int Hisproviderid
        {
            get { return _hisproviderid; }
            set { _hisproviderid = value; }
        }
        int _sott = 0;
        public int Sott
        {
            get { return _sott; }
            set { _sott = value; }
        }

        public string Abo { get; set; }

        public string Rh { get; set; }

        public string Madonvihopdong { get; set; }

        public string Tendonvihopdong { get; set; }

        public string Masophong { get; set; }

        public string Tenphong { get; set; }
        int _uutien = 0;
        public int Uutien
        {
            get { return _uutien; }
            set { _uutien = value; }
        }

        public string Benhkemtheo { get; set; }

        public string Makhoahienthoi { get; set; }

        public string Tenkhoahienthoi { get; set; }

        public string Noicongtac { get; set; }

        public bool? Khamsuckhoe { get; set; }

        public DateTime? Ngaynhapvien { get; set; }

        public string Sohochieu { get; set; }

        public DateTime? Ngaycaphochieu { get; set; }

        public string Ghichuhochieu { get; set; }
        public string TenBScd { get; set; }
        bool _taiKkham = false;
        public string Quoctich { get; set; }
        public bool TaiKham
        {
            get { return _taiKkham; }
            set { _taiKkham = value; }
        }

        public int SoLanTruyen { get; set; }
        public string LyDoTruyenMau { get; set; }
        public string MaCongTacVien { get; set; }
        public string Masinhly { get; set; }
        public string Tensinhly { get; set; }
        public float Cannang { get; set; } = 0;

        public float Chieucao { get; set; } = 0;
        public BENHNHAN_TIEPNHAN() { }

        public BENHNHAN_TIEPNHAN Copy()
        {
            return (BENHNHAN_TIEPNHAN)this.MemberwiseClone();
        }
        public bool Compare_Differences(BENHNHAN_TIEPNHAN objCompare)
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
    public class BENHNHAN_CLS_DVKHAC
    {
        string _benhnhan_cls_dvkhac = "BenhNhan_CLS_DVKhac";
        public string Benhnhan_cls_dvkhac
        {
            get { return _benhnhan_cls_dvkhac; }
            set { _benhnhan_cls_dvkhac = value; }
        }

        public string Matiepnhan { get; set; }

        public string Bacsicd { get; set; }

        public string Chandoan { get; set; }

        public string Bacsiklkhac { get; set; }

        public string Ketluankhac { get; set; }
        bool _dukqkhac = false;
        public bool Dukqkhac
        {
            get { return _dukqkhac; }
            set { _dukqkhac = value; }
        }
        bool _validkqkhac = false;
        public bool Validkqkhac
        {
            get { return _validkqkhac; }
            set { _validkqkhac = value; }
        }
        bool _dainkqkhac = false;
        public bool Dainkqkhac
        {
            get { return _dainkqkhac; }
            set { _dainkqkhac = value; }
        }

        public DateTime? Thoigianvalidkhac { get; set; }

        public DateTime? Thoigiandukqkhac { get; set; }

        public DateTime? Thoigianinkhac { get; set; }

        public string Userinkhac { get; set; }
        int _laninkhac = 0;
        public int Laninkhac
        {
            get { return _laninkhac; }
            set { _laninkhac = value; }
        }
        public BENHNHAN_CLS_DVKHAC() { }
        public BENHNHAN_CLS_DVKHAC(string matiepnhan, string bacsicd, string chandoan, string bacsiklkhac, string ketluankhac, bool dukqkhac, bool validkqkhac, bool dainkqkhac, DateTime? thoigianvalidkhac, DateTime? thoigiandukqkhac
        , DateTime? thoigianinkhac, string userinkhac, int laninkhac)
        {
            this.Matiepnhan = matiepnhan;
            this.Bacsicd = bacsicd;
            this.Chandoan = chandoan;
            this.Bacsiklkhac = bacsiklkhac;
            this.Ketluankhac = ketluankhac;
            this.Dukqkhac = dukqkhac;
            this.Validkqkhac = validkqkhac;
            this.Dainkqkhac = dainkqkhac;
            this.Thoigianvalidkhac = thoigianvalidkhac;
            this.Thoigiandukqkhac = thoigiandukqkhac;
            this.Thoigianinkhac = thoigianinkhac;
            this.Userinkhac = userinkhac;
            this.Laninkhac = laninkhac;
        }
        public BENHNHAN_CLS_DVKHAC Copy()
        {
            return (BENHNHAN_CLS_DVKHAC)this.MemberwiseClone();
        }
        public bool Compare_Differences(BENHNHAN_CLS_DVKHAC objCompare)
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
    public class BENHNHAN_CLS_NOISOI
    {
        string _benhnhan_cls_noisoi = "BenhNhan_CLS_NoiSoi";
        public string Benhnhan_cls_noisoi
        {
            get { return _benhnhan_cls_noisoi; }
            set { _benhnhan_cls_noisoi = value; }
        }

        public string Matiepnhan { get; set; }

        public string Bacsiklnoisoi { get; set; }

        public string Ketluannoisoi { get; set; }
        bool _dukqnoisoi = false;
        public bool Dukqnoisoi
        {
            get { return _dukqnoisoi; }
            set { _dukqnoisoi = value; }
        }
        bool _validkqnoisoi = false;
        public bool Validkqnoisoi
        {
            get { return _validkqnoisoi; }
            set { _validkqnoisoi = value; }
        }
        bool _dainkqnoisoi = false;
        public bool Dainkqnoisoi
        {
            get { return _dainkqnoisoi; }
            set { _dainkqnoisoi = value; }
        }

        public DateTime? Thoigiandukqnoisoi { get; set; }

        public DateTime? Thoigianinnoisoi { get; set; }

        public string Userinnoisoi { get; set; }
        int _laninnoisoi = 0;
        public int Laninnoisoi
        {
            get { return _laninnoisoi; }
            set { _laninnoisoi = value; }
        }
        public BENHNHAN_CLS_NOISOI() { }
        public BENHNHAN_CLS_NOISOI(string matiepnhan, string bacsiklnoisoi, string ketluannoisoi, bool dukqnoisoi, bool validkqnoisoi, bool dainkqnoisoi, DateTime? thoigiandukqnoisoi, DateTime? thoigianinnoisoi, string userinnoisoi, int laninnoisoi)
        {
            this.Matiepnhan = matiepnhan;
            this.Bacsiklnoisoi = bacsiklnoisoi;
            this.Ketluannoisoi = ketluannoisoi;
            this.Dukqnoisoi = dukqnoisoi;
            this.Validkqnoisoi = validkqnoisoi;
            this.Dainkqnoisoi = dainkqnoisoi;
            this.Thoigiandukqnoisoi = thoigiandukqnoisoi;
            this.Thoigianinnoisoi = thoigianinnoisoi;
            this.Userinnoisoi = userinnoisoi;
            this.Laninnoisoi = laninnoisoi;
        }
        public BENHNHAN_CLS_NOISOI Copy()
        {
            return (BENHNHAN_CLS_NOISOI)this.MemberwiseClone();
        }
        public bool Compare_Differences(BENHNHAN_CLS_NOISOI objCompare)
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
    public class BENHNHAN_CLS_SIEUAM
    {
        string _benhnhan_cls_sieuam = "BenhNhan_CLS_SieuAm";
        public string Benhnhan_cls_sieuam
        {
            get { return _benhnhan_cls_sieuam; }
            set { _benhnhan_cls_sieuam = value; }
        }

        public string Matiepnhan { get; set; }

        public string Bacsiklsieuam { get; set; }

        public string Ketluansieuam { get; set; }
        bool _dukqsieuam = false;
        public bool Dukqsieuam
        {
            get { return _dukqsieuam; }
            set { _dukqsieuam = value; }
        }
        bool _validkqsieuam = false;
        public bool Validkqsieuam
        {
            get { return _validkqsieuam; }
            set { _validkqsieuam = value; }
        }
        bool _dainkqsieuam = false;
        public bool Dainkqsieuam
        {
            get { return _dainkqsieuam; }
            set { _dainkqsieuam = value; }
        }

        public DateTime? Thoigiandukqsieuam { get; set; }

        public DateTime? Thoigianinsieuam { get; set; }

        public string Userinsieuam { get; set; }
        int _laninsieuam = 0;
        public int Laninsieuam
        {
            get { return _laninsieuam; }
            set { _laninsieuam = value; }
        }
        public BENHNHAN_CLS_SIEUAM() { }
        public BENHNHAN_CLS_SIEUAM(string matiepnhan, string bacsiklsieuam, string ketluansieuam, bool dukqsieuam, bool validkqsieuam, bool dainkqsieuam, DateTime? thoigiandukqsieuam, DateTime? thoigianinsieuam, string userinsieuam, int laninsieuam)
        {
            this.Matiepnhan = matiepnhan;
            this.Bacsiklsieuam = bacsiklsieuam;
            this.Ketluansieuam = ketluansieuam;
            this.Dukqsieuam = dukqsieuam;
            this.Validkqsieuam = validkqsieuam;
            this.Dainkqsieuam = dainkqsieuam;
            this.Thoigiandukqsieuam = thoigiandukqsieuam;
            this.Thoigianinsieuam = thoigianinsieuam;
            this.Userinsieuam = userinsieuam;
            this.Laninsieuam = laninsieuam;
        }
        public BENHNHAN_CLS_SIEUAM Copy()
        {
            return (BENHNHAN_CLS_SIEUAM)this.MemberwiseClone();
        }
        public bool Compare_Differences(BENHNHAN_CLS_SIEUAM objCompare)
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

    #region benhnhan_cls_xetnghiem
    public class BENHNHAN_CLS_XETNGHIEM
    {
        string _benhnhan_cls_xetnghiem = "benhnhan_cls_xetnghiem";
        public string Benhnhan_cls_xetnghiem
        {
            get { return _benhnhan_cls_xetnghiem; }
            set { _benhnhan_cls_xetnghiem = value; }
        }

        public string Matiepnhan { get; set; }

        public string Bacsicd { get; set; }

        public string Chandoan { get; set; }

        public string Bacsiklxn { get; set; }

        public string Ketluanxn { get; set; }
        bool _dukqxn = false;
        public bool Dukqxn
        {
            get { return _dukqxn; }
            set { _dukqxn = value; }
        }
        bool _validkqxn = false;
        public bool Validkqxn
        {
            get { return _validkqxn; }
            set { _validkqxn = value; }
        }
        bool _dainkqxn = false;
        public bool Dainkqxn
        {
            get { return _dainkqxn; }
            set { _dainkqxn = value; }
        }

        public DateTime? Thoigianvalidxn { get; set; }

        public DateTime? Thoigiandukqxn { get; set; }

        public DateTime? Thoigianinxn { get; set; }

        public string Userinxn { get; set; }
        int _laninxn = 0;
        public int Laninxn
        {
            get { return _laninxn; }
            set { _laninxn = value; }
        }

        public DateTime? Thoigianhentrakq { get; set; }

        public DateTime? Thoigiantrakq { get; set; }

        public string Usertrakq { get; set; }

        public string Ghichuxn { get; set; }

        public string Bacsiklvisinh { get; set; }

        public string Ketluanvisinh { get; set; }
        bool _dukqvisinh = false;
        public bool Dukqvisinh
        {
            get { return _dukqvisinh; }
            set { _dukqvisinh = value; }
        }
        bool _validkqvisinh = false;
        public bool Validkqvisinh
        {
            get { return _validkqvisinh; }
            set { _validkqvisinh = value; }
        }
        bool _dainkqvisinh = false;
        public bool Dainkqvisinh
        {
            get { return _dainkqvisinh; }
            set { _dainkqvisinh = value; }
        }

        public DateTime? Thoigianvalidvisinh { get; set; }

        public DateTime? Thoigiandukqvisinh { get; set; }

        public DateTime? Thoigianinvisinh { get; set; }

        public string Userinvisinh { get; set; }
        int _laninvisinh = 0;
        public int Laninvisinh
        {
            get { return _laninvisinh; }
            set { _laninvisinh = value; }
        }

        public DateTime? Thoigianhentrakqvisinh { get; set; }

        public DateTime? Thoigiantrakqvisinh { get; set; }

        public string Usertrakqvisinh { get; set; }

        public string Ghichuvisinh { get; set; }

        public string Userdanhgia { get; set; }

        public DateTime? Thoigiandanhgia { get; set; }

        public DateTime? Ngayphathanhketqua { get; set; }

        public string Userphathanh { get; set; }
        int _danhgia = 0;
        public int Danhgia
        {
            get { return _danhgia; }
            set { _danhgia = value; }
        }
        bool _phathanhkqlenweb = false;
        public bool Phathanhkqlenweb
        {
            get { return _phathanhkqlenweb; }
            set { _phathanhkqlenweb = value; }
        }

        public DateTime? Thoigianindautien { get; set; }

        public string Ketluanhuyettuydo { get; set; }

        public string Denghihuyettuydo { get; set; }

        public string Nhanxethuyettuydo { get; set; }

        public string Tomtatbenhli { get; set; }

        public string Nguoilamhuyettuydo { get; set; }

        public DateTime? Tglamhuyettuydo { get; set; }

        public DateTime? Tglamxylocain { get; set; }

        public string Ketquaxylocain { get; set; }

        public string Nguoidocxylocain { get; set; }

        public string Yeucauxetnghiem { get; set; }

        public string Ketluanhuyetdo { get; set; }

        public string Denghihuyetdo { get; set; }

        public string Nhanxethuyetdo { get; set; }

        public DateTime? Tgnhanmaumau { get; set; }

        public DateTime? Tgnhanmaunt { get; set; }

        public DateTime? Tgnhanmauvisinh { get; set; }

        public string Nguoinhanmaumau { get; set; }

        public string Nguoinhanmaunt { get; set; }

        public string Nguoinhanmauvisinh { get; set; }

        public DateTime? Tglaymaumau { get; set; }

        public DateTime? Tglaymaunt { get; set; }

        public DateTime? Tglaymauvisinh { get; set; }

        public string Nguoilaymaumau { get; set; }

        public string Nguoilaymaunt { get; set; }

        public string Nguoilaymauvisinh { get; set; }
        public string BienBanHTD { get; set; }
        public string NhanxethuyetdoText { get; set; }
        public string KetluanhuyetdoText { get; set; }
        public string DenghihuyetdoText { get; set; }
        public string NhanxethuyettuydoText { get; set; }
        public string KetluanhuyettuydoText { get; set; }
        public string DenghihuyettuydoText { get; set; }

        public BENHNHAN_CLS_XETNGHIEM() { }
        public BENHNHAN_CLS_XETNGHIEM(string matiepnhan, string bacsicd, string chandoan, string bacsiklxn, string ketluanxn, bool dukqxn, bool validkqxn, bool dainkqxn, DateTime? thoigianvalidxn, DateTime? thoigiandukqxn
        , DateTime? thoigianinxn, string userinxn, int laninxn, DateTime? thoigianhentrakq, DateTime? thoigiantrakq, string usertrakq, string ghichuxn, string bacsiklvisinh, string ketluanvisinh, bool dukqvisinh
        , bool validkqvisinh, bool dainkqvisinh, DateTime? thoigianvalidvisinh, DateTime? thoigiandukqvisinh, DateTime? thoigianinvisinh, string userinvisinh, int laninvisinh, DateTime? thoigianhentrakqvisinh, DateTime? thoigiantrakqvisinh, string usertrakqvisinh
        , string ghichuvisinh, string userdanhgia, DateTime? thoigiandanhgia, DateTime? ngayphathanhketqua, string userphathanh, int danhgia, bool phathanhkqlenweb, DateTime? thoigianindautien, string ketluanhuyettuydo, string denghihuyettuydo
        , string nhanxethuyettuydo, string tomtatbenhli, string nguoilamhuyettuydo, DateTime? tglamhuyettuydo, DateTime? tglamxylocain, string ketquaxylocain, string nguoidocxylocain, string yeucauxetnghiem, string ketluanhuyetdo, string denghihuyetdo
        , string nhanxethuyetdo, DateTime? tgnhanmaumau, DateTime? tgnhanmaunt, DateTime? tgnhanmauvisinh, string nguoinhanmaumau, string nguoinhanmaunt, string nguoinhanmauvisinh, DateTime? tglaymaumau, DateTime? tglaymaunt, DateTime? tglaymauvisinh
        , string nguoilaymaumau, string nguoilaymaunt, string nguoilaymauvisinh)
        {
            this.Matiepnhan = matiepnhan;
            this.Bacsicd = bacsicd;
            this.Chandoan = chandoan;
            this.Bacsiklxn = bacsiklxn;
            this.Ketluanxn = ketluanxn;
            this.Dukqxn = dukqxn;
            this.Validkqxn = validkqxn;
            this.Dainkqxn = dainkqxn;
            this.Thoigianvalidxn = thoigianvalidxn;
            this.Thoigiandukqxn = thoigiandukqxn;
            this.Thoigianinxn = thoigianinxn;
            this.Userinxn = userinxn;
            this.Laninxn = laninxn;
            this.Thoigianhentrakq = thoigianhentrakq;
            this.Thoigiantrakq = thoigiantrakq;
            this.Usertrakq = usertrakq;
            this.Ghichuxn = ghichuxn;
            this.Bacsiklvisinh = bacsiklvisinh;
            this.Ketluanvisinh = ketluanvisinh;
            this.Dukqvisinh = dukqvisinh;
            this.Validkqvisinh = validkqvisinh;
            this.Dainkqvisinh = dainkqvisinh;
            this.Thoigianvalidvisinh = thoigianvalidvisinh;
            this.Thoigiandukqvisinh = thoigiandukqvisinh;
            this.Thoigianinvisinh = thoigianinvisinh;
            this.Userinvisinh = userinvisinh;
            this.Laninvisinh = laninvisinh;
            this.Thoigianhentrakqvisinh = thoigianhentrakqvisinh;
            this.Thoigiantrakqvisinh = thoigiantrakqvisinh;
            this.Usertrakqvisinh = usertrakqvisinh;
            this.Ghichuvisinh = ghichuvisinh;
            this.Userdanhgia = userdanhgia;
            this.Thoigiandanhgia = thoigiandanhgia;
            this.Ngayphathanhketqua = ngayphathanhketqua;
            this.Userphathanh = userphathanh;
            this.Danhgia = danhgia;
            this.Phathanhkqlenweb = phathanhkqlenweb;
            this.Thoigianindautien = thoigianindautien;
            this.Ketluanhuyettuydo = ketluanhuyettuydo;
            this.Denghihuyettuydo = denghihuyettuydo;
            this.Nhanxethuyettuydo = nhanxethuyettuydo;
            this.Tomtatbenhli = tomtatbenhli;
            this.Nguoilamhuyettuydo = nguoilamhuyettuydo;
            this.Tglamhuyettuydo = tglamhuyettuydo;
            this.Tglamxylocain = tglamxylocain;
            this.Ketquaxylocain = ketquaxylocain;
            this.Nguoidocxylocain = nguoidocxylocain;
            this.Yeucauxetnghiem = yeucauxetnghiem;
            this.Ketluanhuyetdo = ketluanhuyetdo;
            this.Denghihuyetdo = denghihuyetdo;
            this.Nhanxethuyetdo = nhanxethuyetdo;
            this.Tgnhanmaumau = tgnhanmaumau;
            this.Tgnhanmaunt = tgnhanmaunt;
            this.Tgnhanmauvisinh = tgnhanmauvisinh;
            this.Nguoinhanmaumau = nguoinhanmaumau;
            this.Nguoinhanmaunt = nguoinhanmaunt;
            this.Nguoinhanmauvisinh = nguoinhanmauvisinh;
            this.Tglaymaumau = tglaymaumau;
            this.Tglaymaunt = tglaymaunt;
            this.Tglaymauvisinh = tglaymauvisinh;
            this.Nguoilaymaumau = nguoilaymaumau;
            this.Nguoilaymaunt = nguoilaymaunt;
            this.Nguoilaymauvisinh = nguoilaymauvisinh;
        }
        public BENHNHAN_CLS_XETNGHIEM Copy()
        {
            return (BENHNHAN_CLS_XETNGHIEM)this.MemberwiseClone();
        }
        public bool Compare_Differences(BENHNHAN_CLS_XETNGHIEM objCompare)
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
    public class BENHNHAN_CLS_XQUANG
    {
        string _benhnhan_cls_xquang = "BenhNhan_CLS_XQuang";
        public string Benhnhan_cls_xquang
        {
            get { return _benhnhan_cls_xquang; }
            set { _benhnhan_cls_xquang = value; }
        }

        public string Matiepnhan { get; set; }

        public string Bacsiklxquang { get; set; }

        public string Ketluanxquang { get; set; }
        bool _dukqxquang = false;
        public bool Dukqxquang
        {
            get { return _dukqxquang; }
            set { _dukqxquang = value; }
        }
        bool _validkqxquang = false;
        public bool Validkqxquang
        {
            get { return _validkqxquang; }
            set { _validkqxquang = value; }
        }
        bool _dainkqxquang = false;
        public bool Dainkqxquang
        {
            get { return _dainkqxquang; }
            set { _dainkqxquang = value; }
        }

        public DateTime? Thoigiandukqxquang { get; set; }

        public DateTime? Thoigianvalidxquang { get; set; }

        public DateTime? Thoigianinxquang { get; set; }

        public string Userinxquang { get; set; }
        int _laninxquang = 0;
        public int Laninxquang
        {
            get { return _laninxquang; }
            set { _laninxquang = value; }
        }
        public BENHNHAN_CLS_XQUANG() { }
        public BENHNHAN_CLS_XQUANG(string matiepnhan, string bacsiklxquang, string ketluanxquang, bool dukqxquang, bool validkqxquang, bool dainkqxquang, DateTime? thoigiandukqxquang, DateTime? thoigianvalidxquang, DateTime? thoigianinxquang, string userinxquang
        , int laninxquang)
        {
            this.Matiepnhan = matiepnhan;
            this.Bacsiklxquang = bacsiklxquang;
            this.Ketluanxquang = ketluanxquang;
            this.Dukqxquang = dukqxquang;
            this.Validkqxquang = validkqxquang;
            this.Dainkqxquang = dainkqxquang;
            this.Thoigiandukqxquang = thoigiandukqxquang;
            this.Thoigianvalidxquang = thoigianvalidxquang;
            this.Thoigianinxquang = thoigianinxquang;
            this.Userinxquang = userinxquang;
            this.Laninxquang = laninxquang;
        }
        public BENHNHAN_CLS_XQUANG Copy()
        {
            return (BENHNHAN_CLS_XQUANG)this.MemberwiseClone();
        }
        public bool Compare_Differences(BENHNHAN_CLS_XQUANG objCompare)
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
