using System;
using System.Collections.Generic;
using System.Reflection;

namespace TPH.LIS.Configuration.Models
{
    public class LocationDepartmentModel
    {
        public string Makhoaphong { get; set; }

        public string Tenkhoaphong { get; set; }
        bool _khongsudung = false;
        public bool Khongsudung
        {
            get { return _khongsudung; }
            set { _khongsudung = value; }
        }

        public string Diachi { get; set; }

        public string Email { get; set; }

        public string Dienthoai { get; set; }

        public string Website { get; set; }
    }

    public class LaboratoyDepartmentModel
    {
        public const string HH = "HH";
        public const string SH = "SH";
        public const string MD = "MD";
        public const string VS = "VS";
        public const string SHPT = "SHPT";

        public static Dictionary<string, string> LaboratoyDepartmentsList = new Dictionary<string, string>()
        {
                                                                        {HH , "Huyết học"},
                                                                        {SH , "Sinh hóa"},
                                                                        {MD , "Miễn dịch"},
                                                                        {VS , "Vi sinh"},
                                                                        {SHPT , "Sinh học phân tử"}

        };
    }
    #region dm_bophan
    public class DM_BOPHAN
    {
        string _dm_bophan = "{{TPH_Standard}}_Dictionary.dbo.DM_BOPHAN";
        public string Dm_bophan
        {
            get { return _dm_bophan; }
            set { _dm_bophan = value; }
        }

        public string Mabophan { get; set; }

        public string Tenbophan { get; set; }

        public string Maphanloai { get; set; }
        bool _khongsudung = false;
        public bool Khongsudung
        {
            get { return _khongsudung; }
            set { _khongsudung = value; }
        }
        public DM_BOPHAN() { }
        public DM_BOPHAN(string mabophan, string tenbophan, string maphanloai, bool khongsudung)
        {
            this.Mabophan = mabophan;
            this.Tenbophan = tenbophan;
            this.Maphanloai = maphanloai;
            this.Khongsudung = khongsudung;
        }
        public DM_BOPHAN Copy()
        {
            return (DM_BOPHAN)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_BOPHAN objCompare)
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
    #region ql_nhanvien
    public class QL_NHANVIEN
    {
        string _ql_nhanvien = "ql_nhanvien";
        public string Ql_nhanvien
        {
            get { return _ql_nhanvien; }
            set { _ql_nhanvien = value; }
        }

        public string Manhanvien { get; set; }

        public string Tennhanvien { get; set; }

        public string Diachi { get; set; }

        public string Dienthoai { get; set; }

        public string Chucvu { get; set; }
        bool _danghi = false;
        public bool Danghi
        {
            get { return _danghi; }
            set { _danghi = value; }
        }
        bool _khamchuabenh = true;
        public bool Khamchuabenh
        {
            get { return _khamchuabenh; }
            set { _khamchuabenh = value; }
        }
        bool _guichidinh = false;
        public bool Guichidinh
        {
            get { return _guichidinh; }
            set { _guichidinh = value; }
        }
        DateTime _tgnhap = DateTime.Now;
        public DateTime Tgnhap
        {
            get { return _tgnhap; }
            set { _tgnhap = value; }
        }
        bool _thongke = false;
        public bool Thongke
        {
            get { return _thongke; }
            set { _thongke = value; }
        }

        public string His_id { get; set; }

        public string Chungchihanhnghe { get; set; }

        public string Nguoinhap { get; set; }

        public string Nguoisua { get; set; }

        public DateTime? Ngaysua { get; set; }

        public string Nhomnhanvien { get; set; }
        public string Makhoaphong { get; set; }
        public string Maphong { get; set; }
        public string MaBoPhan { get; set; }

        public QL_NHANVIEN() { }
        public QL_NHANVIEN(string manhanvien, string tennhanvien, string diachi, string dienthoai, string chucvu, bool danghi, bool khamchuabenh, bool guichidinh, DateTime tgnhap, bool thongke
        , string his_id, string chungchihanhnghe, string nguoinhap, string nguoisua, DateTime? ngaysua, string nhomnhanvien)
        {
            this.Manhanvien = manhanvien;
            this.Tennhanvien = tennhanvien;
            this.Diachi = diachi;
            this.Dienthoai = dienthoai;
            this.Chucvu = chucvu;
            this.Danghi = danghi;
            this.Khamchuabenh = khamchuabenh;
            this.Guichidinh = guichidinh;
            this.Tgnhap = tgnhap;
            this.Thongke = thongke;
            this.His_id = his_id;
            this.Chungchihanhnghe = chungchihanhnghe;
            this.Nguoinhap = nguoinhap;
            this.Nguoisua = nguoisua;
            this.Ngaysua = ngaysua;
            this.Nhomnhanvien = nhomnhanvien;
        }
        public QL_NHANVIEN Copy()
        {
            return (QL_NHANVIEN)this.MemberwiseClone();
        }
        public bool Compare_Differences(QL_NHANVIEN objCompare)
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
    #region dm_nhomphong
    public class DM_NHOMPHONG
    {
        string _dm_nhomphong = "dm_nhomphong";
        public string Dm_nhomphong
        {
            get { return _dm_nhomphong; }
            set { _dm_nhomphong = value; }
        }

        public string Manhomphong { get; set; }

        public string Tennhomphong { get; set; }
        public DM_NHOMPHONG() { }
        public DM_NHOMPHONG(string manhomphong, string tennhomphong)
        {
            this.Manhomphong = manhomphong;
            this.Tennhomphong = tennhomphong;
        }
        public DM_NHOMPHONG Copy()
        {
            return (DM_NHOMPHONG)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_NHOMPHONG objCompare)
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
    #region dm_phong
    public class DM_PHONG
    {
        string _dm_phong = "dm_phong";
        public string Dm_phong
        {
            get { return _dm_phong; }
            set { _dm_phong = value; }
        }

        public string Maphong { get; set; }

        public string Tenphong { get; set; }

        public string Makhoaphong { get; set; }
        int _loaidieutri = 0;
        public int Loaidieutri
        {
            get { return _loaidieutri; }
            set { _loaidieutri = value; }
        }

        public string Maphonghienthi { get; set; }
        public string Manhomphong { get; set; }

        public DM_PHONG() { }
        public DM_PHONG(string maphong, string tenphong, string makhoaphong, int loaidieutri, string maphonghienthi)
        {
            this.Maphong = maphong;
            this.Tenphong = tenphong;
            this.Makhoaphong = makhoaphong;
            this.Loaidieutri = loaidieutri;
            this.Maphonghienthi = maphonghienthi;
        }
        public DM_PHONG Copy()
        {
            return (DM_PHONG)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_PHONG objCompare)
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

