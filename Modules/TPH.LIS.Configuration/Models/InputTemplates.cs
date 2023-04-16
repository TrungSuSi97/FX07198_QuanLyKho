using System.Reflection;

namespace TPH.LIS.Configuration.Models
{
    #region dm_mauchon
    public class DM_MAUCHON
    {
        string _dm_mauchon = "{{TPH_Standard}}_Dictionary.dbo.DM_MAUCHON";
        public string Dm_mauchon
        {
            get { return _dm_mauchon; }
            set { _dm_mauchon = value; }
        }

        public int Id { get; set; }

        public int Idloaimau { get; set; }

        public string Noidung { get; set; }
        public DM_MAUCHON() { }
        public DM_MAUCHON(int id, int idloaimau, string noidung)
        {
            this.Id = id;
            this.Idloaimau = idloaimau;
            this.Noidung = noidung;
        }
        public DM_MAUCHON Copy()
        {
            return (DM_MAUCHON)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_MAUCHON objCompare)
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
