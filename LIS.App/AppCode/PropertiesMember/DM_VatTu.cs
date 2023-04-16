namespace TPH.LIS.App.AppCode.PropertiesMember
{
    public class VT_DM_LOAIVT
    {

        public string Maloaivt { get; set; }

        public string Tenloaivt { get; set; }
        public VT_DM_LOAIVT() { }
        public VT_DM_LOAIVT(string maloaivt, string tenloaivt)
        {
            this.Maloaivt = maloaivt;
            this.Tenloaivt = tenloaivt;
        }
    }
    public class VT_DM_NHOMVT
    {

        public string Maloaivt { get; set; }

        public string Manhomvt { get; set; }

        public string Tennhomvt { get; set; }
        public VT_DM_NHOMVT() { }
        public VT_DM_NHOMVT(string maloaivt, string manhomvt, string tennhomvt)
        {
            this.Maloaivt = maloaivt;
            this.Manhomvt = manhomvt;
            this.Tennhomvt = tennhomvt;
        }
    }
    public class VT_DM_VATTU
    {

        public bool Cohsd { get; set; }

        public string Donvitinh { get; set; }

        public string Dvtquicachcap1 { get; set; }

        public string Dvtquicachcap2 { get; set; }

        public string Dvttieuhao { get; set; }

        public string Maloaivt { get; set; }

        public string Manhomvt { get; set; }

        public string Mavattu { get; set; }

        public int Slcothedung { get; set; }

        public int Sldgtieuhao { get; set; }

        public int? Slquicachcap1 { get; set; }

        public int? Slquicachcap2 { get; set; }

        public string Tenvattu { get; set; }

        public float Tieuhao { get; set; }

        public bool Xuattheoqcdg { get; set; }
        public VT_DM_VATTU() { }
        public VT_DM_VATTU(bool cohsd, string donvitinh, string dvtquicachcap1, string dvtquicachcap2, string dvttieuhao, string maloaivt, string manhomvt, string mavattu, int slcothedung, int sldgtieuhao
        , int? slquicachcap1, int? slquicachcap2, string tenvattu, float tieuhao, bool xuattheoqcdg)
        {
            this.Cohsd = cohsd;
            this.Donvitinh = donvitinh;
            this.Dvtquicachcap1 = dvtquicachcap1;
            this.Dvtquicachcap2 = dvtquicachcap2;
            this.Dvttieuhao = dvttieuhao;
            this.Maloaivt = maloaivt;
            this.Manhomvt = manhomvt;
            this.Mavattu = mavattu;
            this.Slcothedung = slcothedung;
            this.Sldgtieuhao = sldgtieuhao;
            this.Slquicachcap1 = slquicachcap1;
            this.Slquicachcap2 = slquicachcap2;
            this.Tenvattu = tenvattu;
            this.Tieuhao = tieuhao;
            this.Xuattheoqcdg = xuattheoqcdg;
        }
    }
    public class VT_DONVITINH
    {

        public string Id { get; set; }

        public string Unitname { get; set; }
        public VT_DONVITINH() { }
        public VT_DONVITINH(string id, string unitname)
        {
            this.Id = id;
            this.Unitname = unitname;
        }
    }
    public class VT_DM_NHACUNGCAP
    {

        public string Diachi { get; set; }

        public string Dienthoai { get; set; }

        public string Email { get; set; }

        public string Ghichu { get; set; }

        public string Gotat { get; set; }

        public string Manhacungcap { get; set; }

        public string Tennhacungcap { get; set; }
        public VT_DM_NHACUNGCAP() { }
        public VT_DM_NHACUNGCAP(string diachi, string dienthoai, string email, string ghichu, string gotat, string manhacungcap, string tennhacungcap)
        {
            this.Diachi = diachi;
            this.Dienthoai = dienthoai;
            this.Email = email;
            this.Ghichu = ghichu;
            this.Gotat = gotat;
            this.Manhacungcap = manhacungcap;
            this.Tennhacungcap = tennhacungcap;
        }
    }
    public class VT_NHACUNGCAP_VATTU
    {

        public string Maloaivattu { get; set; }

        public string Manhacungcap { get; set; }

        public string Mavattu { get; set; }
        public VT_NHACUNGCAP_VATTU() { }
        public VT_NHACUNGCAP_VATTU(string maloaivattu, string manhacungcap, string mavattu)
        {
            this.Maloaivattu = maloaivattu;
            this.Manhacungcap = manhacungcap;
            this.Mavattu = mavattu;
        }
    }

}
