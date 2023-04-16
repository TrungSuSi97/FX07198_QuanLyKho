using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TPH.LIS.Patient.Model
{
    #region xetnghiem_guimau
    public class XETNGHIEM_GUIMAU
    {

        public string Xetnghiem_guimau { get; set; } = "xetnghiem_guimau";

        public string Matiepnhan { get; set; }

        public string Maxn { get; set; }

        public string Madonvinhan { get; set; }

        public string Barcode { get; set; }

        public string Nguoichon { get; set; }

        public string Nguoigui { get; set; }

        public string Pcthuchiengui { get; set; }

        public DateTime Tgchon { get; set; } = DateTime.Now;

        public DateTime? Tggui { get; set; }
        public XETNGHIEM_GUIMAU() { }
        public XETNGHIEM_GUIMAU(string matiepnhan, string maxn, string madonvinhan, string barcode, string nguoichon, string nguoigui, string pcthuchiengui, DateTime tgchon, DateTime? tggui)
        {
            this.Matiepnhan = matiepnhan;
            this.Maxn = maxn;
            this.Madonvinhan = madonvinhan;
            this.Barcode = barcode;
            this.Nguoichon = nguoichon;
            this.Nguoigui = nguoigui;
            this.Pcthuchiengui = pcthuchiengui;
            this.Tgchon = tgchon;
            this.Tggui = tggui;
        }
        public XETNGHIEM_GUIMAU Copy()
        {
            return (XETNGHIEM_GUIMAU)this.MemberwiseClone();
        }
        public bool Compare_Differences(XETNGHIEM_GUIMAU objCompare)
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
    #region xetnghiem_guimau_ketqua
    public class XETNGHIEM_GUIMAU_KETQUA
    {

        public string Xetnghiem_guimau_ketqua { get; set; } = "xetnghiem_guimau_ketqua";

        public int Id { get; set; }

        public string Barcode { get; set; }

        public string Donvitra { get; set; }

        public string Maxn { get; set; }

        public string Ketqua { get; set; }

        public int Coketqua { get; set; } = 0;

        public string Csbt { get; set; }

        public string Nguoiky { get; set; }

        public string Chucvu { get; set; }

        public DateTime? Ngayky { get; set; }

        public DateTime Ngayguiketqua { get; set; }

        public int Trangthai { get; set; } = 0;

        public string Matiepnhan { get; set; }

        public string Matiepnhannoitra { get; set; }

        public string Barcodenoitra { get; set; }

        public string Idmayxn { get; set; }

        public string Tenmayxn { get; set; }

        public int Nguonnhan { get; set; } = 0;
        public XETNGHIEM_GUIMAU_KETQUA() { }
        public XETNGHIEM_GUIMAU_KETQUA(int id, string barcode, string donvitra, string maxn, string ketqua, int coketqua, string csbt, string nguoiky, string chucvu, DateTime? ngayky
        , DateTime ngayguiketqua, int trangthai, string matiepnhan, string matiepnhannoitra, string barcodenoitra, string idmayxn, string tenmayxn, int nguonnhan)
        {
            this.Id = id;
            this.Barcode = barcode;
            this.Donvitra = donvitra;
            this.Maxn = maxn;
            this.Ketqua = ketqua;
            this.Coketqua = coketqua;
            this.Csbt = csbt;
            this.Nguoiky = nguoiky;
            this.Chucvu = chucvu;
            this.Ngayky = ngayky;
            this.Ngayguiketqua = ngayguiketqua;
            this.Trangthai = trangthai;
            this.Matiepnhan = matiepnhan;
            this.Matiepnhannoitra = matiepnhannoitra;
            this.Barcodenoitra = barcodenoitra;
            this.Idmayxn = idmayxn;
            this.Tenmayxn = tenmayxn;
            this.Nguonnhan = nguonnhan;
        }
        public XETNGHIEM_GUIMAU_KETQUA Copy()
        {
            return (XETNGHIEM_GUIMAU_KETQUA)this.MemberwiseClone();
        }
        public bool Compare_Differences(XETNGHIEM_GUIMAU_KETQUA objCompare)
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
