using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TPH.LIS.Configuration.Models
{
    #region Bacterium
    public class DM_XETNGHIEM_VIKHUAN
    {
        string _dm_xetnghiem_vikhuan = "dm_xetnghiem_vikhuan";
        public string Dm_xetnghiem_vikhuan
        {
            get { return _dm_xetnghiem_vikhuan; }
            set { _dm_xetnghiem_vikhuan = value; }
        }
        public bool insertWithMess = true;
        public string Maphanloai { get; set; }

        public string Tenphanloai { get; set; }
        public string Gram { get; set; }
        public string Org_group { get; set; }

        public string Tenthuonggoi { get; set; }

        public string Danhphap { get; set; }

        public string Maphanloaicha { get; set; }

        public string Donviphanloai { get; set; }
        int _thutusapxep = 1000;
        public int Thutusapxep
        {
            get { return _thutusapxep; }
            set { _thutusapxep = value; }
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
        public int Loaiketqua { get; set; }

        public string Status { get; set; }
        public bool Common { get; set; }
        public string Sub_group { get; set; }
        public string Genus_code { get; set; }
        public string Sct_code { get; set; }
        public string Sct_text { get; set; }


        public DM_XETNGHIEM_VIKHUAN() { }
        public DM_XETNGHIEM_VIKHUAN(string maphanloai, string tenphanloai, string tenthuonggoi, string danhphap, string maphanloaicha, string donviphanloai, int thutusapxep, DateTime gionhap, string nguoinhap, DateTime? giosua
        , string nguoisua, string status, bool common, string sub_group, string genus_code, string sct_code, string sct_text)
        {
            this.Maphanloai = maphanloai;
            this.Tenphanloai = tenphanloai;
            this.Tenthuonggoi = tenthuonggoi;
            this.Danhphap = danhphap;
            this.Maphanloaicha = maphanloaicha;
            this.Donviphanloai = donviphanloai;
            this.Thutusapxep = thutusapxep;
            this.Gionhap = gionhap;
            this.Nguoinhap = nguoinhap;
            this.Giosua = giosua;
            this.Nguoisua = nguoisua;
            this.Common = common;
            this.Sub_group = sub_group;
            this.Genus_code = genus_code;
            this.Sct_code = sct_code;
            this.Sct_text = sct_text;
            this.Status = status;

        }
        public DM_XETNGHIEM_VIKHUAN Copy()
        {
            return (DM_XETNGHIEM_VIKHUAN)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_VIKHUAN objCompare)
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
    #region Antibiotic
    public class DM_XETNGHIEM_NHOMKHANGSINH
    {
        string _dm_xetnghiem_nhomkhangsinh = "DM_XETNGHIEM_NHOMKHANGSINH";
        public string Dm_xetnghiem_nhomkhangsinh
        {
            get { return _dm_xetnghiem_nhomkhangsinh; }
            set { _dm_xetnghiem_nhomkhangsinh = value; }
        }

        public string Manhomkhangsinh { get; set; }

        public string Tennhomkhangsinh { get; set; }
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

        public DateTime? Giosua { get; set; }

        public string Nguoisua { get; set; }
        public bool insertWithMess = true;
        public DM_XETNGHIEM_NHOMKHANGSINH() { }
        public DM_XETNGHIEM_NHOMKHANGSINH(string manhomkhangsinh, string tennhomkhangsinh, int thutuin, DateTime gionhap, string nguoinhap, DateTime? giosua, string nguoisua)
        {
            this.Manhomkhangsinh = manhomkhangsinh;
            this.Tennhomkhangsinh = tennhomkhangsinh;
            this.Thutuin = thutuin;
            this.Gionhap = gionhap;
            this.Nguoinhap = nguoinhap;
            this.Giosua = giosua;
            this.Nguoisua = nguoisua;
        }
        public DM_XETNGHIEM_NHOMKHANGSINH Copy()
        {
            return (DM_XETNGHIEM_NHOMKHANGSINH)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_NHOMKHANGSINH objCompare)
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
    #region dm_xetnghiem_khangsinh
    public class DM_XETNGHIEM_KHANGSINH
    {
        public bool insertWithMess;

        public string Dm_xetnghiem_khangsinh { get; set; } = "dm_xetnghiem_khangsinh";

        public string Makhangsinh { get; set; }

        public string Manhomkhangsinh { get; set; }

        public string Tenkhangsinh { get; set; }

        public int Sapxep { get; set; } = 1000;

        public DateTime Gionhap { get; set; } = DateTime.Now;

        public string Nguoinhap { get; set; }

        public DateTime? Giosua { get; set; }

        public string Nguoisua { get; set; }

        public string Hisid { get; set; }

        public string Whonetid { get; set; }

        public int Whonetversion { get; set; } = 0;

        public float? Clsi_dr { get; set; }

        public string Clsi_di { get; set; }

        public float? Clsi_ds { get; set; }

        public float? Clsi_mr { get; set; }

        public float? Clsi_ms { get; set; }

        public float? Eucst_dr { get; set; }

        public string Eucst_di { get; set; }

        public float? Eucst_ds { get; set; }

        public float? Eucst_mr { get; set; }

        public float? Eucst_ms { get; set; }

        public int Clsi_year { get; set; } = 0;

        public int Eucst_year { get; set; } = 0;

        public string Guidelines { get; set; } = "0";

        public string Guideline { get; set; }

        public float? Abx_number { get; set; }

        public bool Animal_gp { get; set; }

        public bool Betalactam { get; set; }

        public float? Canduoi { get; set; }

        public float? Cantren { get; set; }

        public float? Clsi_mic_r { get; set; }

        public float? Clsi_mic_s { get; set; }

        public string Din_code { get; set; }

        public string Guidelinetype { get; set; }

        public int? Guidelineyear { get; set; }

        public bool Human { get; set; }

        public string Jac_code { get; set; }

        public string Potency { get; set; }

        public string Prof_class { get; set; }

        public string Subclass { get; set; }

        public string User_code { get; set; }

        public bool Veterinary { get; set; }

        public string Who_code { get; set; }

        public bool Who_import { get; set; }

        public string Whon4_code { get; set; }
        public string OldWHONetCode { get; set; }

        public DM_XETNGHIEM_KHANGSINH() { }
        public DM_XETNGHIEM_KHANGSINH Copy()
        {
            return (DM_XETNGHIEM_KHANGSINH)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_KHANGSINH objCompare)
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
    #endregion
    #region dm_xetnghiem_vikhuan_khangsinh
    public class DM_XETNGHIEM_VIKHUAN_KHANGSINH
    {
        string _dm_xetnghiem_vikhuan_khangsinh = "DM_XETNGHIEM_VIKHUAN_KHANGSINH";
        public string Dm_xetnghiem_vikhuan_khangsinh
        {
            get { return _dm_xetnghiem_vikhuan_khangsinh; }
            set { _dm_xetnghiem_vikhuan_khangsinh = value; }
        }

        public string Mavikhuan { get; set; }

        public string Makhangsinh { get; set; }

        public float? Cannhay { get; set; }

        public float? Cankhang { get; set; }

        public float? Cantrunggiantren { get; set; }

        public float? Cantrunggianduoi { get; set; }

        public string Donvitinh { get; set; }
        DateTime _gionhap = DateTime.Now;
        public DateTime Gionhap
        {
            get { return _gionhap; }
            set { _gionhap = value; }
        }

        public string Nguoinhap { get; set; }

        public DateTime? Giosua { get; set; }

        public string Nguoisua { get; set; }

        public string Hisid { get; set; }

        public string Whonetid { get; set; }

        public string Guideline { get; set; }
        public string Potency { get; set; }
        public string Siteinfection { get; set; }


        public string Mabangkhangsinh { get; set; }

        string _kythuat = "DISK";
        public bool insertWithMess = true;

        public string Kythuat
        {
            get { return _kythuat; }
            set { _kythuat = value; }
        }

        public string Breakpoint_type { get; set; }
        public string Host { get; set; }
        public string Ref_table { get; set; }
        public string Ref_seq { get; set; }
        public string Whon5_test { get; set; }
        public int Guidelineyear { get; set; }
        public string Ghichu { get; internal set; }
        public string Makhangsinhchapnhankq { get; internal set; }

        public DM_XETNGHIEM_VIKHUAN_KHANGSINH() { }
        public DM_XETNGHIEM_VIKHUAN_KHANGSINH(string mavikhuan, string makhangsinh, float? cannhay, float? cankhang, float? cantrunggiantren, float? cantrunggianduoi, string donvitinh, DateTime gionhap, string nguoinhap, DateTime? giosua
        , string nguoisua, string hisid, string whonetid, string guideline, string mabangkhangsinh, string kythuat, string potency, string siteinfection
            , string breakpoint_type, string host, string ref_table, string ref_seq, string whon5_test, int GuideLineYear)
        {
            this.Mavikhuan = mavikhuan;
            this.Makhangsinh = makhangsinh;
            this.Cannhay = cannhay;
            this.Cankhang = cankhang;
            this.Cantrunggiantren = cantrunggiantren;
            this.Cantrunggianduoi = cantrunggianduoi;
            this.Donvitinh = donvitinh;
            this.Gionhap = gionhap;
            this.Nguoinhap = nguoinhap;
            this.Giosua = giosua;
            this.Nguoisua = nguoisua;
            this.Hisid = hisid;
            this.Whonetid = whonetid;
            this.Guideline = guideline;
            this.Mabangkhangsinh = mabangkhangsinh;
            this.Kythuat = kythuat;
            this.Potency = potency;
            this.Siteinfection = siteinfection;
            this.Breakpoint_type = breakpoint_type;
            this.Host = host;
            this.Ref_table = ref_table;
            this.Ref_seq = ref_seq;
            this.Whon5_test = whon5_test;
            this.Guidelineyear = GuideLineYear;
        }
        public DM_XETNGHIEM_VIKHUAN_KHANGSINH Copy()
        {
            return (DM_XETNGHIEM_VIKHUAN_KHANGSINH)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_VIKHUAN_KHANGSINH objCompare)
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
    #region Bacterium-Antibiotic
    #endregion
    #region Bacterium-Antibiotic-Test

    public class DM_XETNGHIEM_NHOMYEUCAUVISINH
    {
        string _dm_xetnghiem_nhomyeucauvisinh = "dm_xetnghiem_nhomyeucauvisinh";
        public string Dm_xetnghiem_nhomyeucauvisinh
        {
            get { return _dm_xetnghiem_nhomyeucauvisinh; }
            set { _dm_xetnghiem_nhomyeucauvisinh = value; }
        }

        public string Manhomyeucau { get; set; }

        public string Tennhomyeucau { get; set; }
        DateTime _gionhap = DateTime.Now;
        public DateTime Gionhap
        {
            get { return _gionhap; }
            set { _gionhap = value; }
        }

        public string Nguoinhap { get; set; }

        public DateTime? Giosua { get; set; }

        public string Nguoisua { get; set; }
        int _thutuin = 1000;
        public int Thutuin
        {
            get { return _thutuin; }
            set { _thutuin = value; }
        }
        public DM_XETNGHIEM_NHOMYEUCAUVISINH() { }
        public DM_XETNGHIEM_NHOMYEUCAUVISINH(string manhomyeucau, string tennhomyeucau, DateTime gionhap, string nguoinhap, DateTime? giosua, string nguoisua, int thutuin)
        {
            this.Manhomyeucau = manhomyeucau;
            this.Tennhomyeucau = tennhomyeucau;
            this.Gionhap = gionhap;
            this.Nguoinhap = nguoinhap;
            this.Giosua = giosua;
            this.Nguoisua = nguoisua;
            this.Thutuin = thutuin;
        }
        public DM_XETNGHIEM_NHOMYEUCAUVISINH Copy()
        {
            return (DM_XETNGHIEM_NHOMYEUCAUVISINH)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_NHOMYEUCAUVISINH objCompare)
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
    public class DM_XETNGHIEM_YEUCAUVISINH
    {
        string _dm_xetnghiem_yeucauvisinh = "dm_xetnghiem_yeucauvisinh";
        public string Dm_xetnghiem_yeucauvisinh
        {
            get { return _dm_xetnghiem_yeucauvisinh; }
            set { _dm_xetnghiem_yeucauvisinh = value; }
        }

        public string Mayeucau { get; set; }

        public string Tenyeucau { get; set; }
        decimal _giachuan = 0;
        public decimal Giachuan
        {
            get { return _giachuan; }
            set { _giachuan = value; }
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

        public DateTime? Giosua { get; set; }

        public string Nguoisua { get; set; }

        public string Manhomyeucau { get; set; }
        public DM_XETNGHIEM_YEUCAUVISINH() { }
        public DM_XETNGHIEM_YEUCAUVISINH(string mayeucau, string tenyeucau, decimal giachuan, int thutuin, DateTime gionhap, string nguoinhap, DateTime? giosua, string nguoisua, string manhomyeucau)
        {
            this.Mayeucau = mayeucau;
            this.Tenyeucau = tenyeucau;
            this.Giachuan = giachuan;
            this.Thutuin = thutuin;
            this.Gionhap = gionhap;
            this.Nguoinhap = nguoinhap;
            this.Giosua = giosua;
            this.Nguoisua = nguoisua;
            this.Manhomyeucau = manhomyeucau;
        }
        public DM_XETNGHIEM_YEUCAUVISINH Copy()
        {
            return (DM_XETNGHIEM_YEUCAUVISINH)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_YEUCAUVISINH objCompare)
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
    #region DM_XETNGHIEM_KHAOSATDAITHE
    public class DM_XETNGHIEM_KHAOSATDAITHE
    {
        string _dm_xetnghiem_khaosatdaithe = "DM_XETNGHIEM_KHAOSATDAITHE";
        public string Dm_xetnghiem_khaosatdaithe
        {
            get { return _dm_xetnghiem_khaosatdaithe; }
            set { _dm_xetnghiem_khaosatdaithe = value; }
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
        string _makhaosatcon;
        public string Makhaosatcon
        {
            get { return _makhaosatcon; }
            set { _makhaosatcon = value; }
        }
        bool _khaosatprofile = false;
        public bool Khaosatprofile
        {
            get { return _khaosatprofile; }
            set { _khaosatprofile = value; }
        }
        public DM_XETNGHIEM_KHAOSATDAITHE() { }
        public DM_XETNGHIEM_KHAOSATDAITHE(string makhaosat, string tenkhaosat, string makhaosatcon, bool khaosatprofile)
        {
            this.Makhaosat = makhaosat;
            this.Tenkhaosat = tenkhaosat;
            this.Makhaosatcon = makhaosatcon;
            this.Khaosatprofile = khaosatprofile;
        }
        public DM_XETNGHIEM_KHAOSATDAITHE Copy()
        {
            return (DM_XETNGHIEM_KHAOSATDAITHE)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_KHAOSATDAITHE objCompare)
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
    #region DM_XETNGHIEM_KHAOSATDAITHE_KETQUA
    public class DM_XETNGHIEM_KHAOSATDAITHE_KETQUA
    {
        string _dm_xetnghiem_khaosatdaithe_ketqua = "DM_XETNGHIEM_KHAOSATDAITHE_KETQUA";
        public string Dm_xetnghiem_khaosatdaithe_ketqua
        {
            get { return _dm_xetnghiem_khaosatdaithe_ketqua; }
            set { _dm_xetnghiem_khaosatdaithe_ketqua = value; }
        }
        int _autoid;
        public int Autoid
        {
            get { return _autoid; }
            set { _autoid = value; }
        }
        string _makhaosat;
        public string Makhaosat
        {
            get { return _makhaosat; }
            set { _makhaosat = value; }
        }
        string _ketquakhaosat;
        public string Ketquakhaosat
        {
            get { return _ketquakhaosat; }
            set { _ketquakhaosat = value; }
        }
        public DM_XETNGHIEM_KHAOSATDAITHE_KETQUA() { }
        public DM_XETNGHIEM_KHAOSATDAITHE_KETQUA(int autoid, string makhaosat, string ketquakhaosat)
        {
            this.Autoid = autoid;
            this.Makhaosat = makhaosat;
            this.Ketquakhaosat = ketquakhaosat;
        }
        public DM_XETNGHIEM_KHAOSATDAITHE_KETQUA Copy()
        {
            return (DM_XETNGHIEM_KHAOSATDAITHE_KETQUA)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_KHAOSATDAITHE_KETQUA objCompare)
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
    #region h_visinh_bangmayeucaumayxn
    public class H_VISINH_BANGMAYEUCAUMAYXN
    {

        public string H_visinh_bangmayeucaumayxn { get; set; } = "h_visinh_bangmayeucaumayxn";

        public int Id { get; set; }

        public string Mayeucau { get; set; }

        public string Maloaimau { get; set; }

        public int Idmay { get; set; } = -1;

        public string Idthe { get; set; }

        public string Idtheksd { get; set; }

        public string Gram { get; set; }

        public string Idloaimau { get; set; } = "?????";
        public H_VISINH_BANGMAYEUCAUMAYXN() { }
        public H_VISINH_BANGMAYEUCAUMAYXN(int id, string mayeucau, string maloaimau, int idmay, string idthe, string idtheksd, string gram, string idloaimau)
        {
            this.Id = id;
            this.Mayeucau = mayeucau;
            this.Maloaimau = maloaimau;
            this.Idmay = idmay;
            this.Idthe = idthe;
            this.Idtheksd = idtheksd;
            this.Gram = gram;
            this.Idloaimau = idloaimau;
        }
        public H_VISINH_BANGMAYEUCAUMAYXN Copy()
        {
            return (H_VISINH_BANGMAYEUCAUMAYXN)this.MemberwiseClone();
        }
        public bool Compare_Differences(H_VISINH_BANGMAYEUCAUMAYXN objCompare)
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
    #region dm_xetnghiem_khangsinh_bo_chitiet
    public class DM_XETNGHIEM_KHANGSINH_BO_CHITIET
    {
        string _dm_xetnghiem_khangsinh_bo_chitiet = "DM_XETNGHIEM_KHANGSINH_BO_CHITIET";


        public string Dm_xetnghiem_khangsinh_bo_chitiet
        {
            get { return _dm_xetnghiem_khangsinh_bo_chitiet; }
            set { _dm_xetnghiem_khangsinh_bo_chitiet = value; }
        }

        public string Mabokhangsinh { get; set; }

        public string Makhangsinh { get; set; }
        public string Mavikhuan { get; set; }
        public string Kythuat { get; set; }
        public string Guideline { get; set; }
        public float? Cannhay { get; set; }
        public float? Cankhang { get; set; }
        public float? Cantrunggiantren { get; set; }
        public float? Cantrunggianduoi { get; set; }
        public DateTime Gionhap { get; set; }
        public string Nguoinhap { get; set; }
        public DateTime? Giosua { get; set; }
        public string Nguoisua { get; set; }
        public string Potency { get; set; }
        public string Siteinfection { get; set; }
        public bool Hienthiphieu { get; set; }
        public string Mabangkhangsinh { get; set; }

        public DM_XETNGHIEM_KHANGSINH_BO_CHITIET() { }
        public DM_XETNGHIEM_KHANGSINH_BO_CHITIET(string mabokhangsinh, string makhangsinh, string mavikhuan, string kythuat,
            string guideline, float? cannhay, float? cankhang, float? cantrunggiantren, float? cantrunggianduoi, DateTime gionhap,
            string nguoinhap, DateTime? giosua, string nguoisua = "", string potency = "", string siteInfection = "", bool hienThiPhieu = false)
        {
            this.Mabokhangsinh = mabokhangsinh;
            this.Makhangsinh = makhangsinh;
            this.Mavikhuan = mavikhuan;
            this.Kythuat = kythuat;
            this.Guideline = guideline;
            this.Cannhay = cannhay;
            this.Cankhang = cankhang;
            this.Cantrunggiantren = cantrunggiantren;
            this.Cantrunggianduoi = cantrunggianduoi;
            this.Gionhap = gionhap;
            this.Nguoinhap = nguoinhap;
            this.Giosua = giosua;
            this.Nguoisua = nguoisua;
            this.Potency = potency;
            this.Siteinfection = siteInfection;
            this.Hienthiphieu = hienThiPhieu;
        }
        public DM_XETNGHIEM_KHANGSINH_BO_CHITIET Copy()
        {
            return (DM_XETNGHIEM_KHANGSINH_BO_CHITIET)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_KHANGSINH_BO_CHITIET objCompare)
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
    #region dm_xetnghiem_visinh_bo
    public class DM_XETNGHIEM_VISINH_BO
    {
        string _dm_xetnghiem_visinh_bo = "DM_XETNGHIEM_VISINH_BO";
        public string Dm_xetnghiem_visinh_bo
        {
            get { return _dm_xetnghiem_visinh_bo; }
            set { _dm_xetnghiem_visinh_bo = value; }
        }

        public string Mabokhangsinh { get; set; }

        public string Tenbokhangsinh { get; set; }
        int _sapxep = 1000;
        public int Sapxep
        {
            get { return _sapxep; }
            set { _sapxep = value; }
        }

        public string Nguoinhap { get; set; }
        DateTime _gionhap = DateTime.Now;
        public DateTime Gionhap
        {
            get { return _gionhap; }
            set { _gionhap = value; }
        }

        public string Nguoisua { get; set; }

        public DateTime? Giosua { get; set; }
        public DM_XETNGHIEM_VISINH_BO() { }
        public DM_XETNGHIEM_VISINH_BO(string mabokhangsinh, string tenbokhangsinh, int sapxep, string nguoinhap, DateTime gionhap, string nguoisua, DateTime? giosua)
        {
            this.Mabokhangsinh = mabokhangsinh;
            this.Tenbokhangsinh = tenbokhangsinh;
            this.Sapxep = sapxep;
            this.Nguoinhap = nguoinhap;
            this.Gionhap = gionhap;
            this.Nguoisua = nguoisua;
            this.Giosua = giosua;
        }
        public DM_XETNGHIEM_VISINH_BO Copy()
        {
            return (DM_XETNGHIEM_VISINH_BO)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_VISINH_BO objCompare)
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
    #region dm_xetnghiem_khangkhangsinh
    public class DM_XETNGHIEM_KHANGKHANGSINH
    {
        string _dm_xetnghiem_khangkhangsinh = "dm_xetnghiem_khangkhangsinh";
        public string Dm_xetnghiem_khangkhangsinh
        {
            get { return _dm_xetnghiem_khangkhangsinh; }
            set { _dm_xetnghiem_khangkhangsinh = value; }
        }

        public string Makhangkhangsinh { get; set; }
        public string Tenkhangkhangsinh { get; set; }

        public DM_XETNGHIEM_KHANGKHANGSINH() { }
        public DM_XETNGHIEM_KHANGKHANGSINH(string makhangkhangsinh, string tenkhangkhangsinh)
        {
            this.Makhangkhangsinh = makhangkhangsinh;
            this.Tenkhangkhangsinh = tenkhangkhangsinh;

        }
        public DM_XETNGHIEM_KHANGKHANGSINH Copy()
        {
            return (DM_XETNGHIEM_KHANGKHANGSINH)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_KHANGKHANGSINH objCompare)
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
    #region dm_visinh_maunhapnhanh
    public class DM_VISINH_MAUNHAPNHANH
    {
        string _dm_visinh_maunhapnhanh = "dm_visinh_maunhapnhanh";
        public string Dm_visinh_maunhapnhanh
        {
            get { return _dm_visinh_maunhapnhanh; }
            set { _dm_visinh_maunhapnhanh = value; }
        }

        public int Id { get; set; }
        public string Gotat { get; set; }
        public string Noidung { get; set; }
        public DM_VISINH_MAUNHAPNHANH() { }
        public DM_VISINH_MAUNHAPNHANH Copy()
        {
            return (DM_VISINH_MAUNHAPNHANH)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_VISINH_MAUNHAPNHANH objCompare)
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
    #region dm_xetnghiem_visinh_quitrinh
    public class DM_XETNGHIEM_VISINH_QUITRINH
    {
        string _dm_xetnghiem_visinh_quitrinh = "dm_xetnghiem_visinh_quitrinh";
        public string Dm_xetnghiem_visinh_quitrinh
        {
            get { return _dm_xetnghiem_visinh_quitrinh; }
            set { _dm_xetnghiem_visinh_quitrinh = value; }
        }

        public string Makhangsinh { get; set; }

        public string Kythuat { get; set; }

        public string Quytrinh { get; set; }

        public string Phuongphap { get; set; }
        bool _datchungnhan = true;
        public int Idmayxn { get; set; }
        public bool Datchungnhan
        {
            get { return _datchungnhan; }
            set { _datchungnhan = value; }
        }
        public DM_XETNGHIEM_VISINH_QUITRINH() { }
        public DM_XETNGHIEM_VISINH_QUITRINH(string makhangsinh, string kythuat, string quytrinh, string phuongphap, bool datchungnhan)
        {
            this.Makhangsinh = makhangsinh;
            this.Kythuat = kythuat;
            this.Quytrinh = quytrinh;
            this.Phuongphap = phuongphap;
            this.Datchungnhan = datchungnhan;
        }
        public DM_XETNGHIEM_VISINH_QUITRINH Copy()
        {
            return (DM_XETNGHIEM_VISINH_QUITRINH)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_VISINH_QUITRINH objCompare)
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
    #region dm_xetnghiem_visinh_quytrinh_loaimau
    public class DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU
    {
        string _dm_xetnghiem_visinh_quytrinh_loaimau = "dm_xetnghiem_visinh_quytrinh_loaimau";
        public string Dm_xetnghiem_visinh_quytrinh_loaimau
        {
            get { return _dm_xetnghiem_visinh_quytrinh_loaimau; }
            set { _dm_xetnghiem_visinh_quytrinh_loaimau = value; }
        }

        public string Maloaimau { get; set; }

        public int Idmayxn { get; set; }

        public string Quytrinh { get; set; }

        public string Phuongphap { get; set; }

        public bool Datchungnhan { get; set; }
        public DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU() { }
        public DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU(string maloaimau, int idmayxn, string quytrinh, string phuongphap, bool datchungnhan)
        {
            this.Maloaimau = maloaimau;
            this.Idmayxn = idmayxn;
            this.Quytrinh = quytrinh;
            this.Phuongphap = phuongphap;
            this.Datchungnhan = datchungnhan;
        }
        public DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU Copy()
        {
            return (DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU objCompare)
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
    #region dm_xetnghiem_gram
    public class DM_XETNGHIEM_GRAM
    {

        public string Dm_xetnghiem_gram { get; set; } = "dm_xetnghiem_gram";

        public int Id { get; set; }

        public string Gramvalue { get; set; }

        public string Gramdescription { get; set; }
        public DM_XETNGHIEM_GRAM() { }
        public DM_XETNGHIEM_GRAM(int id, string gramvalue, string gramdescription)
        {
            this.Id = id;
            this.Gramvalue = gramvalue;
            this.Gramdescription = gramdescription;
        }
        public DM_XETNGHIEM_GRAM Copy()
        {
            return (DM_XETNGHIEM_GRAM)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_GRAM objCompare)
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
