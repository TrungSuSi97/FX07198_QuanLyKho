using System.Drawing;
using System.Reflection;

namespace TPH.LIS.Configuration.Models
{
    #region dm_xetnghiem_mauphieuin
    public class DM_XETNGHIEM_MAUPHIEUIN
    {
        string _dm_xetnghiem_mauphieuin = "dm_xetnghiem_mauphieuin";
        public string Dm_xetnghiem_mauphieuin
        {
            get { return _dm_xetnghiem_mauphieuin; }
            set { _dm_xetnghiem_mauphieuin = value; }
        }

        public string Idmauketqua { get; set; }

        public string Mota { get; set; }

        public Image Hinhphieukq { get; set; }
        int _vitrisapxeptrai = -1;
        public int Vitrisapxeptrai
        {
            get { return _vitrisapxeptrai; }
            set { _vitrisapxeptrai = value; }
        }
        int _vitrisapxepphai = -1;
        public int Vitrisapxepphai
        {
            get { return _vitrisapxepphai; }
            set { _vitrisapxepphai = value; }
        }
        int _vitrisapxeptraigioihan = -1;
        public int Vitrisapxeptraigioihan
        {
            get { return _vitrisapxeptraigioihan; }
            set { _vitrisapxeptraigioihan = value; }
        }
        int _vitrisapxepphaigioihan = -1;
        public int Vitrisapxepphaigioihan
        {
            get { return _vitrisapxepphaigioihan; }
            set { _vitrisapxepphaigioihan = value; }
        }
        int _vitrisapxeptraingoai = -1;
        public int Vitrisapxeptraingoai
        {
            get { return _vitrisapxeptraingoai; }
            set { _vitrisapxeptraingoai = value; }
        }
        int _vitrisapxepphaingoai = -1;
        public int Vitrisapxepphaingoai
        {
            get { return _vitrisapxepphaingoai; }
            set { _vitrisapxepphaingoai = value; }
        }
        int _vitrisapxeptraigioihanngoai = -1;
        public int Vitrisapxeptraigioihanngoai
        {
            get { return _vitrisapxeptraigioihanngoai; }
            set { _vitrisapxeptraigioihanngoai = value; }
        }
        int _vitrisapxepphaigioihanngoai = -1;
        public int Vitrisapxepphaigioihanngoai
        {
            get { return _vitrisapxepphaigioihanngoai; }
            set { _vitrisapxepphaigioihanngoai = value; }
        }

        public string Tenctm { get; set; }

        public string Tendm { get; set; }

        public string Tennm { get; set; }
        int _thutuin = 0;
        public int Thutuin
        {
            get { return _thutuin; }
            set { _thutuin = value; }
        }

        public string Idreport { get; set; }
        bool _chiacot = false;
        public bool Chiacot
        {
            get { return _chiacot; }
            set { _chiacot = value; }
        }
        bool _kytentheoluoi = false;
        public bool Kytentheoluoi
        {
            get { return _kytentheoluoi; }
            set { _kytentheoluoi = value; }
        }
        bool _tachbschidinh = false;
        public bool Tachbschidinh
        {
            get { return _tachbschidinh; }
            set { _tachbschidinh = value; }
        }
        bool _tachnhomin = false;
        public bool Tachnhomin
        {
            get { return _tachnhomin; }
            set { _tachnhomin = value; }
        }
        bool _Tachtudong = false;
        public bool Tachtudong
        {
            get { return _Tachtudong; }
            set { _Tachtudong = value; }
        }
        bool _gheptenxnghichu = false;
        public bool Gheptenxnghichu
        {
            get { return _gheptenxnghichu; }
            set { _gheptenxnghichu = value; }
        }
        bool _ghichuduoixn = false;
        public bool Ghichuduoixn
        {
            get { return _ghichuduoixn; }
            set { _ghichuduoixn = value; }
        }
        bool _ghepghichukhoavaochung = false;
        public bool Ghepghichukhoavaochung
        {
            get { return _ghepghichukhoavaochung; }
            set { _ghepghichukhoavaochung = value; }
        }

        public string Dinhdangghepnhapkq { get; set; }

        public string Dinhdangghepduyetkq { get; set; }
        int _lekqduoinguong = 0;
        public int Lekqduoinguong
        {
            get { return _lekqduoinguong; }
            set { _lekqduoinguong = value; }
        }
        int _lekqtrennguong = 0;
        public int Lekqtrennguong
        {
            get { return _lekqtrennguong; }
            set { _lekqtrennguong = value; }
        }
        int _lekqtrongnguong = 0;
        public int Lekqtrongnguong
        {
            get { return _lekqtrongnguong; }
            set { _lekqtrongnguong = value; }
        }
        int _lenhom = 0;
        public int Lenhom
        {
            get { return _lenhom; }
            set { _lenhom = value; }
        }
        bool _batthuonggachchan = false;
        public bool Batthuonggachchan
        {
            get { return _batthuonggachchan; }
            set { _batthuonggachchan = value; }
        }
        bool _batthuongindam = false;
        public bool Batthuongindam
        {
            get { return _batthuongindam; }
            set { _batthuongindam = value; }
        }
        bool _batthuonginnghieng = false;
        public bool Batthuonginnghieng
        {
            get { return _batthuonginnghieng; }
            set { _batthuonginnghieng = value; }
        }
        bool _thoigianinlandau = false;
        public bool Thoigianinlandau
        {
            get { return _thoigianinlandau; }
            set { _thoigianinlandau = value; }
        }
        bool _tachbophan = false;
        public bool Tachbophan
        {
            get { return _tachbophan; }
            set { _tachbophan = value; }
        }
        bool _tennhomgachchan = false;
        public bool Tennhomgachchan
        {
            get { return _tennhomgachchan; }
            set { _tennhomgachchan = value; }
        }
        bool _tennhomindam = false;
        public bool Tennhomindam
        {
            get { return _tennhomindam; }
            set { _tennhomindam = value; }
        }
        bool _tennhominnghieng = false;
        public bool Tennhominnghieng
        {
            get { return _tennhominnghieng; }
            set { _tennhominnghieng = value; }
        }

        public string IdFormHIS { get; set; }

        public DM_XETNGHIEM_MAUPHIEUIN() { }
        public DM_XETNGHIEM_MAUPHIEUIN(string idmauketqua, string mota, Image hinhphieukq, int vitrisapxeptrai, int vitrisapxepphai, int vitrisapxeptraigioihan, int vitrisapxepphaigioihan, int vitrisapxeptraingoai, int vitrisapxepphaingoai, int vitrisapxeptraigioihanngoai
        , int vitrisapxepphaigioihanngoai, string tenctm, string tendm, string tennm, int thutuin, string idreport, bool chiacot, bool kytentheoluoi, bool tachbschidinh, bool tachnhomin
        , bool gheptenxnghichu, bool ghichuduoixn, bool ghepghichukhoavaochung, string dinhdangghepnhapkq, string dinhdangghepduyetkq, int lekqduoinguong, int lekqtrennguong, int lekqtrongnguong, int lenhom
        , bool batthuonggachchan, bool batthuongindam, bool batthuonginnghieng, bool thoigianinlandau, bool tachtudong, bool tachbophan, bool tennhomgachchan, bool tennhomindam, bool tennhominnghieng)
        {
            this.Idmauketqua = idmauketqua;
            this.Mota = mota;
            this.Hinhphieukq = hinhphieukq;
            this.Vitrisapxeptrai = vitrisapxeptrai;
            this.Vitrisapxepphai = vitrisapxepphai;
            this.Vitrisapxeptraigioihan = vitrisapxeptraigioihan;
            this.Vitrisapxepphaigioihan = vitrisapxepphaigioihan;
            this.Vitrisapxeptraingoai = vitrisapxeptraingoai;
            this.Vitrisapxepphaingoai = vitrisapxepphaingoai;
            this.Vitrisapxeptraigioihanngoai = vitrisapxeptraigioihanngoai;
            this.Vitrisapxepphaigioihanngoai = vitrisapxepphaigioihanngoai;
            this.Tenctm = tenctm;
            this.Tendm = tendm;
            this.Tennm = tennm;
            this.Thutuin = thutuin;
            this.Idreport = idreport;
            this.Chiacot = chiacot;
            this.Kytentheoluoi = kytentheoluoi;
            this.Tachbschidinh = tachbschidinh;
            this.Tachnhomin = tachnhomin;
            this.Gheptenxnghichu = gheptenxnghichu;
            this.Ghichuduoixn = ghichuduoixn;
            this.Ghepghichukhoavaochung = ghepghichukhoavaochung;
            this.Dinhdangghepnhapkq = dinhdangghepnhapkq;
            this.Dinhdangghepduyetkq = dinhdangghepduyetkq;
            this.Lekqduoinguong = lekqduoinguong;
            this.Lekqtrennguong = lekqtrennguong;
            this.Lekqtrongnguong = lekqtrongnguong;
            this.Lenhom = lenhom;
            this.Batthuonggachchan = batthuonggachchan;
            this.Batthuongindam = batthuongindam;
            this.Batthuonginnghieng = batthuonginnghieng;
            this.Thoigianinlandau = thoigianinlandau;
            this.Tachtudong = tachtudong;
            this.Tachbophan = tachbophan;
            this.Tennhomgachchan = tennhomgachchan;
            this.Tennhomindam = tennhomindam;
            this.Tennhominnghieng = tennhominnghieng;
        }
        public DM_XETNGHIEM_MAUPHIEUIN Copy()
        {
            return (DM_XETNGHIEM_MAUPHIEUIN)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_MAUPHIEUIN objCompare)
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
    #region dm_xetnghiem_mauphieuin_vitri
    public class DM_XETNGHIEM_MAUPHIEUIN_VITRI
    {
        string _dm_xetnghiem_mauphieuin_vitri = "DM_XETNGHIEM_MAUPHIEUIN_VITRI";
        public string Dm_xetnghiem_mauphieuin_vitri
        {
            get { return _dm_xetnghiem_mauphieuin_vitri; }
            set { _dm_xetnghiem_mauphieuin_vitri = value; }
        }

        public string Maxetnghiem { get; set; }

        public string Idmauketqua { get; set; }

        public string Mavitri { get; set; }

        public string Mota { get; set; }
        bool _luonhienthi = false;
        public bool Luonhienthi
        {
            get { return _luonhienthi; }
            set { _luonhienthi = value; }
        }
        bool _noicot = false;
        public bool Noicot
        {
            get { return _noicot; }
            set { _noicot = value; }
        }
        bool _indamten = false;
        public bool Indamten
        {
            get { return _indamten; }
            set { _indamten = value; }
        }
        int _hienthiten = 0;
        public int Hienthiten
        {
            get { return _hienthiten; }
            set { _hienthiten = value; }
        }
        int _hienthiketqua = 0;
        public int Hienthiketqua
        {
            get { return _hienthiketqua; }
            set { _hienthiketqua = value; }
        }
        int _hienthikqbatthuong = 0;
        public int Hienthikqbatthuong
        {
            get { return _hienthikqbatthuong; }
            set { _hienthikqbatthuong = value; }
        }
        public DM_XETNGHIEM_MAUPHIEUIN_VITRI() { }
        public DM_XETNGHIEM_MAUPHIEUIN_VITRI(string maxetnghiem, string idmauketqua, string mavitri, string mota, bool luonhienthi, bool noicot, bool indamten, int hienthiten, int hienthiketqua, int hienthikqbatthuong)
        {
            this.Maxetnghiem = maxetnghiem;
            this.Idmauketqua = idmauketqua;
            this.Mavitri = mavitri;
            this.Mota = mota;
            this.Luonhienthi = luonhienthi;
            this.Noicot = noicot;
            this.Indamten = indamten;
            this.Hienthiten = hienthiten;
            this.Hienthiketqua = hienthiketqua;
            this.Hienthikqbatthuong = hienthikqbatthuong;
        }
        public DM_XETNGHIEM_MAUPHIEUIN_VITRI Copy()
        {
            return (DM_XETNGHIEM_MAUPHIEUIN_VITRI)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_MAUPHIEUIN_VITRI objCompare)
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
    #region dm_xetnghiem_mauphieuin_tuychon
    public class DM_XETNGHIEM_MAUPHIEUIN_TUYCHON
    {
        string _dm_xetnghiem_mauphieuin_tuychon = "dm_xetnghiem_mauphieuin_tuychon";
        public string Dm_xetnghiem_mauphieuin_tuychon
        {
            get { return _dm_xetnghiem_mauphieuin_tuychon; }
            set { _dm_xetnghiem_mauphieuin_tuychon = value; }
        }

        public string Idmauchon { get; set; }

        public string Tenmauchon { get; set; }

        public string Idmauketqua { get; set; }
        public string MaNgonNgu { get; set; }
        int _idformsudung = 0;
        public int Idformsudung
        {
            get { return _idformsudung; }
            set { _idformsudung = value; }
        }

        public string Idreport { get; set; }
        public DM_XETNGHIEM_MAUPHIEUIN_TUYCHON() { }
        public DM_XETNGHIEM_MAUPHIEUIN_TUYCHON(string idmauchon, string tenmauchon, string idmauketqua, int idformsudung, string idreport)
        {
            this.Idmauchon = idmauchon;
            this.Tenmauchon = tenmauchon;
            this.Idmauketqua = idmauketqua;
            this.Idformsudung = idformsudung;
            this.Idreport = idreport;
        }
        public DM_XETNGHIEM_MAUPHIEUIN_TUYCHON Copy()
        {
            return (DM_XETNGHIEM_MAUPHIEUIN_TUYCHON)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_MAUPHIEUIN_TUYCHON objCompare)
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
