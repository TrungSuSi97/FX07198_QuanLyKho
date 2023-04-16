using System.Reflection;

namespace TPH.LIS.Configuration.Models
{
    #region dm_email
    public class DM_EMAIL
    {
        string _dm_email = "{{TPH_Standard}}_Dictionary.dbo.DM_EMAIL";
        public string Dm_email
        {
            get { return _dm_email; }
            set { _dm_email = value; }
        }

        public string Email { get; set; }

        public string Madonvi { get; set; }
        public DM_EMAIL() { }
        public DM_EMAIL(string email, string madonvi)
        {
            this.Email = email;
            this.Madonvi = madonvi;
        }
        public DM_EMAIL Copy()
        {
            return (DM_EMAIL)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_EMAIL objCompare)
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
