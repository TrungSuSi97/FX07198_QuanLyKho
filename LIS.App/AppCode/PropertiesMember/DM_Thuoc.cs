using System;

namespace TPH.LIS.App.AppCode.PropertiesMember
{
    public class DM_THUOC
    {

        public string Cachdung { get; set; }

        public string Chieu { get; set; }

        public bool Cohsd { get; set; }

        public string Donvitinh { get; set; }

        public string Dvtquicachcap1 { get; set; }

        public string Dvtquicachcap2 { get; set; }

        public decimal? Gia { get; set; }

        public string Gotat { get; set; }

        public string Magocthuoc { get; set; }

        public string Mathuoc { get; set; }

        public string Mavattu { get; set; }

        public string Sang { get; set; }

        public int Sapxep { get; set; }

        public int? Slquicachcap1 { get; set; }

        public int? Slquicachcap2 { get; set; }

        public string Tenthuoc { get; set; }

        public string Toi { get; set; }

        public string Trua { get; set; }

        public bool Xuattheoqcdg { get; set; }
        public DM_THUOC() { }
        public DM_THUOC(string cachdung, string chieu, bool cohsd, string donvitinh, string dvtquicachcap1, string dvtquicachcap2, decimal? gia, string gotat, string magocthuoc
        , string mathuoc, string mavattu, string sang, int sapxep, int? slquicachcap1, int? slquicachcap2, string tenthuoc, string toi, string trua, bool xuattheoqcdg)
        {
            this.Cachdung = cachdung;
            this.Chieu = chieu;
            this.Cohsd = cohsd;
            this.Donvitinh = donvitinh;
            this.Dvtquicachcap1 = dvtquicachcap1;
            this.Dvtquicachcap2 = dvtquicachcap2;
            this.Gia = gia;
            this.Gotat = gotat;
            this.Magocthuoc = magocthuoc;
            this.Mathuoc = mathuoc;
            this.Mavattu = mavattu;
            this.Sang = sang;
            this.Sapxep = sapxep;
            this.Slquicachcap1 = slquicachcap1;
            this.Slquicachcap2 = slquicachcap2;
            this.Tenthuoc = tenthuoc;
            this.Toi = toi;
            this.Trua = trua;
            this.Xuattheoqcdg = xuattheoqcdg;
        }
    }
    public class DM_THUOC_CACHDUNG
    {

        public string Id { get; set; }

        public string Tencachdung { get; set; }
        public DM_THUOC_CACHDUNG() { }
        public DM_THUOC_CACHDUNG(string id, string tencachdung)
        {
            this.Id = id;
            this.Tencachdung = tencachdung;
        }
    }
    public class DM_THUOC_GOCTHUOC
    {

        public string Magocthuoc { get; set; }

        public string Manhomthuoc { get; set; }

        public string Tengocthuoc { get; set; }

        public int Thutuin { get; set; }
        public DM_THUOC_GOCTHUOC() { }
        public DM_THUOC_GOCTHUOC(string magocthuoc, string manhomthuoc, string tengocthuoc, int thutuin)
        {
            this.Magocthuoc = magocthuoc;
            this.Manhomthuoc = manhomthuoc;
            this.Tengocthuoc = tengocthuoc;
            this.Thutuin = thutuin;
        }
    }
    public class DM_THUOC_NHOMTHUOC
    {

        public string Manhomthuoc { get; set; }

        public string Tennhomthuoc { get; set; }
        public DM_THUOC_NHOMTHUOC() { }
        public DM_THUOC_NHOMTHUOC(string manhomthuoc, string tennhomthuoc)
        {
            this.Manhomthuoc = manhomthuoc;
            this.Tennhomthuoc = tennhomthuoc;
        }
    }
    public class DM_THUOC_PROFILE
    {

        public string Maprofile { get; set; }

        public string Tenprofile { get; set; }
        public DM_THUOC_PROFILE() { }
        public DM_THUOC_PROFILE(string maprofile, string tenprofile)
        {
            this.Maprofile = maprofile;
            this.Tenprofile = tenprofile;
        }
    }
    public class DM_THUOC_PROFILE_CHITIET
    {

        public string Cachdung { get; set; }

        public string Chieu { get; set; }

        public string Maprofile { get; set; }

        public string Mathuoc { get; set; }

        public string Sang { get; set; }

        public string Toi { get; set; }

        public string Trua { get; set; }
        public DM_THUOC_PROFILE_CHITIET() { }
        public DM_THUOC_PROFILE_CHITIET(string cachdung, string chieu, string maprofile, string mathuoc, string sang, string toi, string trua)
        {
            this.Cachdung = cachdung;
            this.Chieu = chieu;
            this.Maprofile = maprofile;
            this.Mathuoc = mathuoc;
            this.Sang = sang;
            this.Toi = toi;
            this.Trua = trua;
        }
    }
    //Kho thuốc
    public class VT_NHAPKHO_CHIETTIET_THUOC
    {

        public bool Cohsd { get; set; }

        public string Donvitinh { get; set; }

        public string Dvtquicachcap1 { get; set; }

        public string Dvtquicachcap2 { get; set; }

        public decimal Gianhap { get; set; }

        public bool Hangtang { get; set; }

        public DateTime? Hansudung { get; set; }

        public string Magocthuoc { get; set; }

        public string Manhacungcap { get; set; }

        public string Maphieunhap { get; set; }

        public string Mavattu { get; set; }

        public int? Slquicachcap1 { get; set; }

        public int? Slquicachcap2 { get; set; }

        public string Solo { get; set; }

        public float Soluongnhap { get; set; }

        public float Soluongtheoquicach { get; set; }

        public float Soluongxuat { get; set; }

        public float Soluongxuattheoquicach { get; set; }

        public string Tenthuoc { get; set; }

        public DateTime Tgnhap { get; set; }

        public bool Xuattheoqcdg { get; set; }
        public VT_NHAPKHO_CHIETTIET_THUOC() { }
        public VT_NHAPKHO_CHIETTIET_THUOC(bool cohsd, string donvitinh, string dvtquicachcap1, string dvtquicachcap2, decimal gianhap, bool hangtang, DateTime? hansudung, string magocthuoc, string manhacungcap, string maphieunhap
        , string mavattu, int? slquicachcap1, int? slquicachcap2, string solo, float soluongnhap, float soluongtheoquicach, float soluongxuat, float soluongxuattheoquicach, string tenthuoc, DateTime tgnhap
        , bool xuattheoqcdg)
        {
            this.Cohsd = cohsd;
            this.Donvitinh = donvitinh;
            this.Dvtquicachcap1 = dvtquicachcap1;
            this.Dvtquicachcap2 = dvtquicachcap2;
            this.Gianhap = gianhap;
            this.Hangtang = hangtang;
            this.Hansudung = hansudung;
            this.Magocthuoc = magocthuoc;
            this.Manhacungcap = manhacungcap;
            this.Maphieunhap = maphieunhap;
            this.Mavattu = mavattu;
            this.Slquicachcap1 = slquicachcap1;
            this.Slquicachcap2 = slquicachcap2;
            this.Solo = solo;
            this.Soluongnhap = soluongnhap;
            this.Soluongtheoquicach = soluongtheoquicach;
            this.Soluongxuat = soluongxuat;
            this.Soluongxuattheoquicach = soluongxuattheoquicach;
            this.Tenthuoc = tenthuoc;
            this.Tgnhap = tgnhap;
            this.Xuattheoqcdg = xuattheoqcdg;
        }
    }

    public class VT_NHAPKHO_PHIEUNHAP_THUOC
    {

        public string Ghichu { get; set; }

        public string Maphieunhap { get; set; }

        public DateTime? Ngaynhap { get; set; }

        public string Nguoicapnhat { get; set; }

        public string Nguoinhap { get; set; }

        public DateTime? Tgcapnhat { get; set; }

        public DateTime? Tgnhap { get; set; }
        public VT_NHAPKHO_PHIEUNHAP_THUOC() { }
        public VT_NHAPKHO_PHIEUNHAP_THUOC(string ghichu, string maphieunhap, DateTime? ngaynhap, string nguoicapnhat, string nguoinhap, DateTime? tgcapnhat, DateTime? tgnhap)
        {
            this.Ghichu = ghichu;
            this.Maphieunhap = maphieunhap;
            this.Ngaynhap = ngaynhap;
            this.Nguoicapnhat = nguoicapnhat;
            this.Nguoinhap = nguoinhap;
            this.Tgcapnhat = tgcapnhat;
            this.Tgnhap = tgnhap;
        }
    }
    //Xuất thuốc
    public class VT_XUATKHO_PHIEUXUAT_THUOC
    {

        public string Ghichu { get; set; }

        public string Maphieuxuat { get; set; }

        public string Matiepnhan { get; set; }

        public DateTime? Ngaynhap { get; set; }

        public string Nguoicapnhat { get; set; }

        public string Nguoinhap { get; set; }

        public DateTime? Tgcapnhat { get; set; }

        public DateTime? Tgnhap { get; set; }
        public VT_XUATKHO_PHIEUXUAT_THUOC() { }
        public VT_XUATKHO_PHIEUXUAT_THUOC(string ghichu, string maphieuxuat, string matiepnhan, DateTime? ngaynhap, string nguoicapnhat, string nguoinhap, DateTime? tgcapnhat, DateTime? tgnhap)
        {
            this.Ghichu = ghichu;
            this.Maphieuxuat = maphieuxuat;
            this.Matiepnhan = matiepnhan;
            this.Ngaynhap = ngaynhap;
            this.Nguoicapnhat = nguoicapnhat;
            this.Nguoinhap = nguoinhap;
            this.Tgcapnhat = tgcapnhat;
            this.Tgnhap = tgnhap;
        }
    }
    public class THUPHI_THUOC
    {

        public string Cachdung { get; set; }

        public string Chieu { get; set; }

        public bool Dainbienlai { get; set; }

        public bool Dathutien { get; set; }

        public decimal Dongia { get; set; }

        public string Donvitinh { get; set; }

        public string Dvtquicachcap1 { get; set; }

        public string Dvtquicachcap2 { get; set; }

        public string Magocthuoc { get; set; }

        public string Mathuoc { get; set; }

        public string Matiepnhan { get; set; }

        public string Nguoinhap { get; set; }

        public string Sang { get; set; }

        public int? Slquicachcap1 { get; set; }

        public int? Slquicachcap2 { get; set; }

        public int Soluong { get; set; }

        public string Tenthuoc { get; set; }

        public DateTime Tgnhap { get; set; }

        public decimal Thanhtien { get; set; }

        public string Toi { get; set; }

        public string Trua { get; set; }

        public bool Xuattheoqcdg { get; set; }
        public THUPHI_THUOC() { }
        public THUPHI_THUOC(string cachdung, string chieu, bool dainbienlai, bool dathutien, decimal dongia, string donvitinh, string dvtquicachcap1, string dvtquicachcap2, string magocthuoc, string mathuoc
        , string matiepnhan, string nguoinhap, string sang, int? slquicachcap1, int? slquicachcap2, int soluong, string tenthuoc, DateTime tgnhap, decimal thanhtien, string toi
        , string trua, bool xuattheoqcdg)
        {
            this.Cachdung = cachdung;
            this.Chieu = chieu;
            this.Dainbienlai = dainbienlai;
            this.Dathutien = dathutien;
            this.Dongia = dongia;
            this.Donvitinh = donvitinh;
            this.Dvtquicachcap1 = dvtquicachcap1;
            this.Dvtquicachcap2 = dvtquicachcap2;
            this.Magocthuoc = magocthuoc;
            this.Mathuoc = mathuoc;
            this.Matiepnhan = matiepnhan;
            this.Nguoinhap = nguoinhap;
            this.Sang = sang;
            this.Slquicachcap1 = slquicachcap1;
            this.Slquicachcap2 = slquicachcap2;
            this.Soluong = soluong;
            this.Tenthuoc = tenthuoc;
            this.Tgnhap = tgnhap;
            this.Thanhtien = thanhtien;
            this.Toi = toi;
            this.Trua = trua;
            this.Xuattheoqcdg = xuattheoqcdg;
        }
    }
    public class VT_XUATKHO_CHITIET_THUOC
    {

        public string Cachdung { get; set; }

        public string Chieu { get; set; }

        public bool Dain { get; set; }

        public decimal Dongia { get; set; }

        public string Donvitinh { get; set; }

        public string Dvtquicachcap1 { get; set; }

        public string Dvtquicachcap2 { get; set; }

        public string Ghichu { get; set; }

        public string Magocthuoc { get; set; }

        public string Manhacungcap { get; set; }

        public string Manhomthuoc { get; set; }

        public string Maphieunhap { get; set; }

        public string Maphieuxuat { get; set; }

        public string Mathuoc { get; set; }

        public string Mavattu { get; set; }

        public string Sang { get; set; }

        public int? Slquicachcap1 { get; set; }

        public int? Slquicachcap2 { get; set; }

        public string Solo { get; set; }

        public float Soluong { get; set; }

        public string Tenthuoc { get; set; }

        public DateTime? Tgcapnhat { get; set; }

        public DateTime Tgnhap { get; set; }

        public decimal Thanhtien { get; set; }

        public string Toi { get; set; }

        public string Trua { get; set; }

        public bool Xuattheoqcdg { get; set; }
        public VT_XUATKHO_CHITIET_THUOC() { }
        public VT_XUATKHO_CHITIET_THUOC(string cachdung, string chieu, bool dain, decimal dongia, string donvitinh, string dvtquicachcap1, string dvtquicachcap2, string ghichu, string magocthuoc, string manhacungcap
        , string manhomthuoc, string maphieunhap, string maphieuxuat, string mathuoc, string mavattu, string sang, int? slquicachcap1, int? slquicachcap2, string solo, float soluong
        , string tenthuoc, DateTime? tgcapnhat, DateTime tgnhap, decimal thanhtien, string toi, string trua, bool xuattheoqcdg)
        {
            this.Cachdung = cachdung;
            this.Chieu = chieu;
            this.Dain = dain;
            this.Dongia = dongia;
            this.Donvitinh = donvitinh;
            this.Dvtquicachcap1 = dvtquicachcap1;
            this.Dvtquicachcap2 = dvtquicachcap2;
            this.Ghichu = ghichu;
            this.Magocthuoc = magocthuoc;
            this.Manhacungcap = manhacungcap;
            this.Manhomthuoc = manhomthuoc;
            this.Maphieunhap = maphieunhap;
            this.Maphieuxuat = maphieuxuat;
            this.Mathuoc = mathuoc;
            this.Mavattu = mavattu;
            this.Sang = sang;
            this.Slquicachcap1 = slquicachcap1;
            this.Slquicachcap2 = slquicachcap2;
            this.Solo = solo;
            this.Soluong = soluong;
            this.Tenthuoc = tenthuoc;
            this.Tgcapnhat = tgcapnhat;
            this.Tgnhap = tgnhap;
            this.Thanhtien = thanhtien;
            this.Toi = toi;
            this.Trua = trua;
            this.Xuattheoqcdg = xuattheoqcdg;
        }
    }



}
