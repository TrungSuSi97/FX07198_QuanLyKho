using System;
using System.Reflection;

namespace TPH.LIS.Patient.Model
{
    #region xetnghiem_chuyenphieu_ketqua_chitiet
    public class CHUYENPHIEUKETQUA_CHITIET
    {
        public long Id { get; set; }

        public int Idchuyen { get; set; }

        public string Matiepnhan { get; set; }

        public string Barcode { get; set; }

        public string Maxn { get; set; }
        DateTime _thoigianchuyen = DateTime.Now;
        public DateTime Thoigianchuyen
        {
            get { return _thoigianchuyen; }
            set { _thoigianchuyen = value; }
        }

        public string Nguoichuyen { get; set; }

        public string Pcthuchien { get; set; }

        public bool? Dachuyen { get; set; }

        public DateTime? Tgxacnhanchuyen { get; set; }

        public string Nguoichuyenxacnhan { get; set; }

        public string Pcxacnhan { get; set; }

        public string Nguoinhanketqua { get; set; }

        public DateTime? Thoigiannhanketqua { get; set; }

        public string Pcnhanketqua { get; set; }
        bool _danhanketqua = false;
        public bool Danhanketqua
        {
            get { return _danhanketqua; }
            set { _danhanketqua = value; }
        }

        public bool Compare_Differences(CHUYENPHIEUKETQUA_CHITIET objCompare)
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
