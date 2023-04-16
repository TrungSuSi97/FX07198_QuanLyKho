using System.Reflection;

namespace TPH.LIS.Configuration.Models
{
    #region dm_maytinh_mayin
    public class DM_MAYTINH_MAYIN
    {
        string _dm_maytinh_mayin = "dm_maytinh_mayin";
        public string Dm_maytinh_mayin
        {
            get { return _dm_maytinh_mayin; }
            set { _dm_maytinh_mayin = value; }
        }

        public string Tenmaytinh { get; set; }

        public int Idmay { get; set; }

        public string Giaothuc { get; set; }

        public string Ipmayin { get; set; }

        public string Duongdan { get; set; }
        int _cong = 8989;
        public int Cong
        {
            get { return _cong; }
            set { _cong = value; }
        }
        private bool suDung = true;

        public string Taikhoan { get; set; }

        public string Matkhau { get; set; }

        public bool SuDung
        {
            get
            {
                return suDung;
            }

            set
            {
                suDung = value;
            }
        }
        public string HisId { get; set; }
        public string BanTiepNhan { get; set; }
        public DM_MAYTINH_MAYIN() { }
        public DM_MAYTINH_MAYIN Copy()
        {
            return (DM_MAYTINH_MAYIN)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_MAYTINH_MAYIN objCompare)
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
