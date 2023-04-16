using System;
using System.Reflection;

namespace TPH.LIS.Configuration.Models
{
    #region dm_khuvuc
    public class DM_KHUVUC
    {
        string _dm_khuvuc = "{{TPH_Standard}}_Dictionary.dbo.DM_KHUVUC";
        public string Dm_khuvuc
        {
            get { return _dm_khuvuc; }
            set { _dm_khuvuc = value; }
        }

        public string Makhuvuc { get; set; }

        public string Tenkhuvuc { get; set; }
        int _codebatdau = -1;
        public int Codebatdau
        {
            get { return _codebatdau; }
            set { _codebatdau = value; }
        }
        int _codeketthuc = -1;
        public int Codeketthuc
        {
            get { return _codeketthuc; }
            set { _codeketthuc = value; }
        }

        public string Kytuphanbiet { get; set; }
        bool _inbarcode = false;
        public bool Inbarcode
        {
            get { return _inbarcode; }
            set { _inbarcode = value; }
        }
        int _vitrikytu = 1;
        public int Vitrikytu
        {
            get { return _vitrikytu; }
            set { _vitrikytu = value; }
        }
        public bool ClsXetNghiemHienThiTrangThaiNhom { get; set; }
        public bool ClsXetNghiemHienThiTrangThaiBoPhan { get; set; }
        public bool ClsXetNghiemHienThiTrangThaiNhomTheoBoPhan { get; set; }
        public int ClsXetNghiemDoCaoLuoiThongTin { get; set; }

        public DM_KHUVUC() { }
        public DM_KHUVUC(string makhuvuc, string tenkhuvuc, int codebatdau, int codeketthuc, string kytuphanbiet, bool inbarcode, int vitrikytu)
        {
            this.Makhuvuc = makhuvuc;
            this.Tenkhuvuc = tenkhuvuc;
            this.Codebatdau = codebatdau;
            this.Codeketthuc = codeketthuc;
            this.Kytuphanbiet = kytuphanbiet;
            this.Inbarcode = inbarcode;
            this.Vitrikytu = vitrikytu;
        }
        public DM_KHUVUC Copy()
        {
            return (DM_KHUVUC)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_KHUVUC objCompare)
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
    #region dm_khuvuc_maytinh
    public class DM_KHUVUC_MAYTINH
    {
        string _dm_khuvuc_maytinh = "dm_khuvuc_maytinh";
        public string Dm_khuvuc_maytinh
        {
            get { return _dm_khuvuc_maytinh; }
            set { _dm_khuvuc_maytinh = value; }
        }

        public int Id { get; set; }

        public string Makhuvuc { get; set; }

        public string Tenmaytinh { get; set; }

        public string Mota { get; set; }
        int _hisproviderid = 0;
        public int Hisproviderid
        {
            get { return _hisproviderid; }
            set { _hisproviderid = value; }
        }

        public string Versionid { get; set; }

        public DateTime? Thoigianlogingannhat { get; set; }
        bool _yeucaucapnhat = false;
        public bool Yeucaucapnhat
        {
            get { return _yeucaucapnhat; }
            set { _yeucaucapnhat = value; }
        }

        public string Fileinfo { get; set; }

        public string Ip { get; set; }
        bool _khuvucchinh = false;
        public bool Khuvucchinh
        {
            get { return _khuvucchinh; }
            set { _khuvucchinh = value; }
        }
        string _idkhulaymau = "0";
        public string Makhuvucchinh { get; set; }

        public string Idkhulaymau
        {
            get { return _idkhulaymau; }
            set { _idkhulaymau = value; }
        }

        public int IDLayLoaiMau { get;  set; }
        public string Tenkhuvucchinh { get; set; }

        public bool XacNhanVaoKetQua = false;
        public DM_KHUVUC_MAYTINH() { }
        public DM_KHUVUC_MAYTINH(int id, string makhuvuc, string tenmaytinh, string mota, int hisproviderid, string versionid, DateTime? thoigianlogingannhat, bool yeucaucapnhat, string fileinfo, string ip
        , bool khuvucchinh, string idkhulaymau)
        {
            this.Id = id;
            this.Makhuvuc = makhuvuc;
            this.Tenmaytinh = tenmaytinh;
            this.Mota = mota;
            this.Hisproviderid = hisproviderid;
            this.Versionid = versionid;
            this.Thoigianlogingannhat = thoigianlogingannhat;
            this.Yeucaucapnhat = yeucaucapnhat;
            this.Fileinfo = fileinfo;
            this.Ip = ip;
            this.Khuvucchinh = khuvucchinh;
            this.Idkhulaymau = idkhulaymau;
        }
        public DM_KHUVUC_MAYTINH Copy()
        {
            return (DM_KHUVUC_MAYTINH)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_KHUVUC_MAYTINH objCompare)
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
    #region dm_khulaymau
    public class DM_KHULAYMAU
    {
        string _dm_khulaymau = "dm_khulaymau";
        public string Dm_khulaymau
        {
            get { return _dm_khulaymau; }
            set { _dm_khulaymau = value; }
        }
        public string Idkhulaymau { get; set; }
        public string Tenkhulaymau { get; set; }
        public string Makhuvuc { get; set; }
        int _sophutconglaymau = 0;
        public int Sophutconglaymau
        {
            get { return _sophutconglaymau; }
            set { _sophutconglaymau = value; }
        }
        int _Gioihanlaymau = 0;
        public int Gioihanlaymau
        {
            get { return _Gioihanlaymau; }
            set { _Gioihanlaymau = value; }
        }
        bool _tulaymaukhitiepnhan = true;
        public bool Tulaymaukhitiepnhan
        {
            get { return _tulaymaukhitiepnhan; }
            set { _tulaymaukhitiepnhan = value; }
        }
        int _sophutgioihanlaymau = 0;
        public int Sophutgioihanlaymau
        {
            get { return _sophutgioihanlaymau; }
            set { _sophutgioihanlaymau = value; }
        }

        public int SoGioLoadHis { get; set; }
        public int GioHanChuyenMau { get; set; }
        bool _nhapDanhSachUserLayMau = true;
        public bool NhapDanhSachUserLayMau
        {
            get { return _nhapDanhSachUserLayMau; }
            set { _nhapDanhSachUserLayMau = value; }
        }

        bool _tuChonChiDinh = true;
        public bool TuChonChiDinh
        {
            get { return _tuChonChiDinh; }
            set { _tuChonChiDinh = value; }
        }

        bool _coPhieuHen = false;
        public bool CoPhieuHen
        {
            get { return _coPhieuHen; }
            set { _coPhieuHen = value; }
        }
        bool _userLayMauNhieuBan = false;
        public bool UserLayMauNhieuBan
        {
            get { return _userLayMauNhieuBan; }
            set { _userLayMauNhieuBan = value; }
        }
        bool _inGiohen = false;
        public bool InGiohen
        {
            get { return _inGiohen; }
            set { _inGiohen = value; }
        }

        public bool CoTemInSan { get; set; }
        public string TemBarcode { get; set; }
        public bool ChonNguoiLayMau { get; set; }
        public bool TuThemChiDinhVaoBarcodeGanNhat { get; set; }
        public bool KhongChoTiepNhanNhieuLan { get; set; }

        public DM_KHULAYMAU() { }
        public DM_KHULAYMAU Copy()
        {
            return (DM_KHULAYMAU)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_KHULAYMAU objCompare)
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
    #region dm_maytinh
    public class DM_MAYTINH
    {
        string _dm_maytinh = "{{TPH_Standard}}_Dictionary.dbo.dm_maytinh";
        public string Dm_maytinh
        {
            get { return _dm_maytinh; }
            set { _dm_maytinh = value; }
        }

        public string Tenmaytinh { get; set; }

        public string Mota { get; set; }

        public string Makhuvucchinh { get; set; }
        bool _chonkhuvuc = false;
        public bool Chonkhuvuc
        {
            get { return _chonkhuvuc; }
            set { _chonkhuvuc = value; }
        }

        public string Versionid { get; set; }

        public DateTime? Thoigianlogingannhat { get; set; }
        bool _yeucaucapnhat = false;
        public bool Yeucaucapnhat
        {
            get { return _yeucaucapnhat; }
            set { _yeucaucapnhat = value; }
        }

        public string Ip { get; set; }
        public DM_MAYTINH() { }
        public DM_MAYTINH(string tenmaytinh, string mota, string makhuvucchinh, bool chonkhuvuc, string versionid, DateTime? thoigianlogingannhat, bool yeucaucapnhat, string ip)
        {
            this.Tenmaytinh = tenmaytinh;
            this.Mota = mota;
            this.Makhuvucchinh = makhuvucchinh;
            this.Chonkhuvuc = chonkhuvuc;
            this.Versionid = versionid;
            this.Thoigianlogingannhat = thoigianlogingannhat;
            this.Yeucaucapnhat = yeucaucapnhat;
            this.Ip = ip;
        }
        public DM_MAYTINH Copy()
        {
            return (DM_MAYTINH)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_MAYTINH objCompare)
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
