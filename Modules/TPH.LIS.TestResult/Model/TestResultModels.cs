using System;
using System.Reflection;

namespace TPH.LIS.TestResult.Model
{
    #region ketqua_cls_xetnghiem_mauthuthuat
    public class KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT
    {
        string _ketqua_cls_xetnghiem_mauthuthuat = "ketqua_cls_xetnghiem_mauthuthuat";
        public string Ketqua_cls_xetnghiem_mauthuthuat
        {
            get { return _ketqua_cls_xetnghiem_mauthuthuat; }
            set { _ketqua_cls_xetnghiem_mauthuthuat = value; }
        }

        public string Matiepnhan { get; set; }

        public string Maxn { get; set; }
        bool _maucongoai = false;
        public bool Maucongoai
        {
            get { return _maucongoai; }
            set { _maucongoai = value; }
        }
        bool _maucotrong = false;
        public bool Maucotrong
        {
            get { return _maucotrong; }
            set { _maucotrong = value; }
        }
        bool _mauamdao = false;
        public bool Mauamdao
        {
            get { return _mauamdao; }
            set { _mauamdao = value; }
        }

        public string Bslaymau { get; set; }

        public DateTime? Thoigianlaymauthuthuat { get; set; }

        public string ViTriLayMauSinhThiet { get; set; }

        public string Mabslaymau { get; set; }

        public KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT() { }
        public KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT Copy()
        {
            return (KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT)this.MemberwiseClone();
        }
        public bool Compare_Differences(KETQUA_CLS_XETNGHIEM_MAUTHUTHUAT objCompare)
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
