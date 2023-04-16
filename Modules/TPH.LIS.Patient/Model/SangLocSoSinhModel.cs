using System;
using System.Reflection;

namespace TPH.LIS.Patient.Model
{
    #region BenhNhan_MauSangLoc
    public class BENHNHAN_MAUSANGLOC
    {
        string _benhnhan_mausangloc = "BenhNhan_MauSangLoc";
        public string Benhnhan_mausangloc
        {
            get { return _benhnhan_mausangloc; }
            set { _benhnhan_mausangloc = value; }
        }

        public string Matiepnhan { get; set; }

        public string Barcodelaymau { get; set; }
        int _tuoithai = 0;
        public int Tuoithai
        {
            get { return _tuoithai; }
            set { _tuoithai = value; }
        }

        public string Noisinh { get; set; }
        float _cannang = 0;
        public float Cannang
        {
            get { return _cannang; }
            set { _cannang = value; }
        }
        float _chieucao = 0;
        public float Chieucao
        {
            get { return _chieucao; }
            set { _chieucao = value; }
        }
        float _chieucaome = 0;
        public float Chieucaome
        {
            get { return _chieucaome; }
            set { _chieucaome = value; }
        }
        public DateTime Ngaysinh { get; set; }

        public string Dantoc { get; set; }
        int _soluongsinh = 1;
        public int Soluongsinh
        {
            get { return _soluongsinh; }
            set { _soluongsinh = value; }
        }
        bool _ttbinhthuong = false;
        public bool Ttbinhthuong
        {
            get { return _ttbinhthuong; }
            set { _ttbinhthuong = value; }
        }
        bool _ttdangbenh = false;
        public bool Ttdangbenh
        {
            get { return _ttdangbenh; }
            set { _ttdangbenh = value; }
        }
        bool _ttdungkhangsinh = false;
        public bool Ttdungkhangsinh
        {
            get { return _ttdungkhangsinh; }
            set { _ttdungkhangsinh = value; }
        }
        bool _ttdungsteriod = false;
        public bool Ttdungsteriod
        {
            get { return _ttdungsteriod; }
            set { _ttdungsteriod = value; }
        }
        bool _tttruyenmau = false;
        public bool Tttruyenmau
        {
            get { return _tttruyenmau; }
            set { _tttruyenmau = value; }
        }

        public int? Ttluongtruyenmau { get; set; }
        bool _vitrigotchan = false;
        public bool Vitrigotchan
        {
            get { return _vitrigotchan; }
            set { _vitrigotchan = value; }
        }
        bool _vitritinhmach = false;
        public bool Vitritinhmach
        {
            get { return _vitritinhmach; }
            set { _vitritinhmach = value; }
        }
        bool _vitrikhac = false;
        public bool Vitrikhac
        {
            get { return _vitrikhac; }
            set { _vitrikhac = value; }
        }
        bool _dinhduongbume = false;
        public bool Dinhduongbume
        {
            get { return _dinhduongbume; }
            set { _dinhduongbume = value; }
        }
        bool _dinhduongbubinh = false;
        public bool Dinhduongbubinh
        {
            get { return _dinhduongbubinh; }
            set { _dinhduongbubinh = value; }
        }
        bool _dinhduongtinhmach = false;
        public bool Dinhduongtinhmach
        {
            get { return _dinhduongtinhmach; }
            set { _dinhduongtinhmach = value; }
        }
        bool _kieudethuong = false;
        public bool Kieudethuong
        {
            get { return _kieudethuong; }
            set { _kieudethuong = value; }
        }
        bool _kieudemo = false;
        public bool Kieudemo
        {
            get { return _kieudemo; }
            set { _kieudemo = value; }
        }
        bool _kieudekhac = false;
        public bool Kieudekhac
        {
            get { return _kieudekhac; }
            set { _kieudekhac = value; }
        }

        public string Hotenme { get; set; }

        public string Hotenbo { get; set; }

        public string Diachi { get; set; }
        int _namsinhme = 0;
        public int Namsinhme
        {
            get { return _namsinhme; }
            set { _namsinhme = value; }
        }
        int _namsinhbo = 0;
        public int Namsinhbo
        {
            get { return _namsinhbo; }
            set { _namsinhbo = value; }
        }
        int _matinh = 0;
        public int Matinh
        {
            get { return _matinh; }
            set { _matinh = value; }
        }
        int _mahuyen = 0;
        public int Mahuyen
        {
            get { return _mahuyen; }
            set { _mahuyen = value; }
        }

        public string Dienthoaiban { get; set; }

        public string Dienthoaididong { get; set; }

        public string Para1 { get; set; }

        public string Para2 { get; set; }

        public string Para3 { get; set; }

        public string Para4 { get; set; }

        public string Para5 { get; set; }

        public DateTime? Thoigianlaymau { get; set; }
        public DateTime? Ngaydusinh { get; set; }
        public string Tennguoilaymau { get; set; }

        public string Manguoilaymau { get; set; }

        public string Noiguimau { get; set; }

        public string NhanXetSangLoc { get; set; }

        public string DeNghiSangLoc { get; set; }

        public string Diachinoiguimau { get; set; }
        int _matinhguimau = 0;
        public int Matinhguimau
        {
            get { return _matinhguimau; }
            set { _matinhguimau = value; }
        }
        int _mahuyenguimau = 0;
        public int Mahuyenguimau
        {
            get { return _mahuyenguimau; }
            set { _mahuyenguimau = value; }
        }

        public string KetLuanSangLoc { get; set; }
        public string NguoiKetLuan { get; set; }
        public string NguoiNhanXet { get; set; }
        public string NguoiDeNghi { get; set; }
        float _cannangme = 0;
        public float Cannangme
        {
            get { return _cannangme; }
            set { _cannangme = value; }
        }
        int _sothai = 0;
        public int Sothai
        {
            get { return _sothai; }
            set { _sothai = value; }
        }
        int _tuoithaime = 0;
        public int Tuoithaime
        {
            get { return _tuoithaime; }
            set { _tuoithaime = value; }
        }
        bool _ivf = false;
        public bool Ivf
        {
            get { return _ivf; }
            set { _ivf = value; }
        }
        bool _hutthuoc = false;
        public bool Hutthuoc
        {
            get { return _hutthuoc; }
            set { _hutthuoc = value; }
        }
        int _bpd = 0;
        public int Bpd
        {
            get { return _bpd; }
            set { _bpd = value; }
        }

        public string Chungtoc { get; set; }

        public string Daithaoduong { get; set; }

        public string Tiensu { get; set; }

        public string Bssieuam { get; set; }
        public DateTime? Ngaysieuam { get; set; }
        float _bmi = 0;
        public float Bmi
        {
            get { return _bmi; }
            set { _bmi = value; }
        }
        int _crl = 0;
        public int Crl
        {
            get { return _crl; }
            set { _crl = value; }
        }
        float _xuongmui = 0;
        public float Xuongmui
        {
            get { return _xuongmui; }
            set { _xuongmui = value; }
        }

        public string Daithaoduong2 { get; set; }
        bool _tanghamantinh = false;
        public bool Tanghamantinh
        {
            get { return _tanghamantinh; }
            set { _tanghamantinh = value; }
        }
        bool _thaiphumactsg = false;
        public bool Thaiphumactsg
        {
            get { return _thaiphumactsg; }
            set { _thaiphumactsg = value; }
        }
        bool _methaiphumactsg = false;
        public bool Methaiphumactsg
        {
            get { return _methaiphumactsg; }
            set { _methaiphumactsg = value; }
        }
        bool _antiphospholipid = false;
        public bool Antiphospholipid
        {
            get { return _antiphospholipid; }
            set { _antiphospholipid = value; }
        }
        bool _lupusbando = false;
        public bool Lupusbando
        {
            get { return _lupusbando; }
            set { _lupusbando = value; }
        }
        bool _daocothaihon24 = false;
        public bool Dacothaihon24
        {
            get { return _daocothaihon24; }
            set { _daocothaihon24 = value; }
        }

        public DateTime? Ngaysinhtruoc { get; set; }
        int _tuoithaisinhtruoc = 0;
        public int Tuoithaisinhtruoc
        {
            get { return _tuoithaisinhtruoc; }
            set { _tuoithaisinhtruoc = value; }
        }
        bool _sinhcont21t18t13 = false;
        public bool Sinhcont21t18t13
        {
            get { return _sinhcont21t18t13; }
            set { _sinhcont21t18t13 = value; }
        }
        public string Tenme { get; set; }
        bool _tiensan = false;
        public bool Tiensan
        {
            get { return _tiensan; }
            set { _tiensan = value; }
        }
        bool _sosinh = false;
        public bool Sosinh
        {
            get { return _sosinh; }
            set { _sosinh = value; }
        }

        public string Goixn { get; set; }

        public bool TraKQSLTaiNha;

        public BENHNHAN_MAUSANGLOC() { }
        public BENHNHAN_MAUSANGLOC Copy()
        {
            return (BENHNHAN_MAUSANGLOC)this.MemberwiseClone();
        }
        public bool Compare_Differences(BENHNHAN_MAUSANGLOC objCompare)
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
