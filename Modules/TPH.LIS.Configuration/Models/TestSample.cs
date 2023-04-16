using System;
using System.ComponentModel;
using System.Reflection;

namespace TPH.LIS.Configuration.Models
{
    #region dm_xetnghiem_loaimau
    public class DM_XETNGHIEM_LOAIMAU
    {
        [Description("Mã loại mẫu")]
        public string Maloaimau { get; set; }
        [Description("Tên loại mẫu")]
        public string Loaimau { get; set; }
        [Description("Loại mẫu chính")]
        public string Maloaimauchinh { get; set; }

        public string Hisid { get; set; }
        [Description("Phân loại")]
        public string Loaidvcls { get; set; } = "clsxetnghiem";
        [Description("Ống mẫu")]
        public string Manhomloaimau { get; set; }
        [Description("Sắp xếp")]
        public int Thutu { get; set; } = 0;

        public string Whonetid { get; set; }
        [Description("In tem tự động")]
        public bool Intemtudong { get; set; } = true;
        [Description("Người nhập")]
        public string Nguoinhap { get; set; }
        [Description("TG nhập")]
        public DateTime Tgnhap { get; set; } = DateTime.Now;
        public DM_XETNGHIEM_LOAIMAU() { }
 
        public DM_XETNGHIEM_LOAIMAU Copy()
        {
            return (DM_XETNGHIEM_LOAIMAU)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_LOAIMAU objCompare)
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
    #region dm_xetnghiem_loaimau_nhom
    public class DM_XETNGHIEM_LOAIMAU_NHOM
    {
        string _dm_xetnghiem_loaimau_nhom = "{{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_LOAIMAU_NHOM";
        public string Dm_xetnghiem_loaimau_nhom
        {
            get { return _dm_xetnghiem_loaimau_nhom; }
            set { _dm_xetnghiem_loaimau_nhom = value; }
        }

        public string Manhomloaimau { get; set; }

        public string Tennhomloaimau { get; set; }
        int _thutu = 0;
        public int Thutu
        {
            get { return _thutu; }
            set { _thutu = value; }
        }
        bool _hienthinhan = false;
        public bool Hienthinhan
        {
            get { return _hienthinhan; }
            set { _hienthinhan = value; }
        }
        string _loaidvcls = "ClsXetNghiem";
        public string Loaidvcls
        {
            get { return _loaidvcls; }
            set { _loaidvcls = value; }
        }

        public string Maunhanmau { get; set; }
        public string Id1 { get; set; }
        public string Id2 { get; set; }
        public string Id3 { get; set; }
        public int ThuTuUuTienLay { get; set; } = 1;
        public int TuInBarCodeKhiQuet { get; set; } = 0;
        public DM_XETNGHIEM_LOAIMAU_NHOM() { }
        public DM_XETNGHIEM_LOAIMAU_NHOM Copy()
        {
            return (DM_XETNGHIEM_LOAIMAU_NHOM)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_LOAIMAU_NHOM objCompare)
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
    #region dm_xetnghiem_loaimauchinh
    public class DM_XETNGHIEM_LOAIMAUCHINH
    {
        string _dm_xetnghiem_loaimauchinh = "{{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_LOAIMAUCHINH";
        public string Dm_xetnghiem_loaimauchinh
        {
            get { return _dm_xetnghiem_loaimauchinh; }
            set { _dm_xetnghiem_loaimauchinh = value; }
        }

        public string Maloaimauchinh { get; set; }

        public string Tenloaimauchinh { get; set; }
        public DM_XETNGHIEM_LOAIMAUCHINH() { }
        public DM_XETNGHIEM_LOAIMAUCHINH(string maloaimauchinh, string tenloaimauchinh)
        {
            this.Maloaimauchinh = maloaimauchinh;
            this.Tenloaimauchinh = tenloaimauchinh;
        }
        public DM_XETNGHIEM_LOAIMAUCHINH Copy()
        {
            return (DM_XETNGHIEM_LOAIMAUCHINH)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_XETNGHIEM_LOAIMAUCHINH objCompare)
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
    #region dm_tinhtrangmau
    public class DM_TINHTRANGMAU
    {
        string _dm_tinhtrangmau = "dm_tinhtrangmau";
        public string Dm_tinhtrangmau
        {
            get { return _dm_tinhtrangmau; }
            set { _dm_tinhtrangmau = value; }
        }
        [Description("ID")]
        public int Id { get; set; }
        [Description("Nội dung")]
        public string Tinhtrangmau { get; set; }
        int _loaixetnghiem = 0;
        [Description("Loại xét nghiệm")]
        public int Loaixetnghiem
        {
            get { return _loaixetnghiem; }
            set { _loaixetnghiem = value; }
        }
        [Description("Mã tình trạng")]
        public string Matinhtrang { get; set; }
        public DM_TINHTRANGMAU() { }
        public DM_TINHTRANGMAU(int id, string tinhtrangmau, int loaixetnghiem, string matinhtrang)
        {
            this.Id = id;
            this.Tinhtrangmau = tinhtrangmau;
            this.Loaixetnghiem = loaixetnghiem;
            this.Matinhtrang = matinhtrang;
        }
        public DM_TINHTRANGMAU Copy()
        {
            return (DM_TINHTRANGMAU)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_TINHTRANGMAU objCompare)
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
