using System.Reflection;

namespace TPH.LIS.Configuration.Models
{
    public class CAUHINH_MAYINKETQUA
    {
        string _cauhinh_mayinketqua = "{{TPH_Standard}}_Dictionary.dbo.CAUHINH_MAYINKETQUA";
        public string Cauhinh_mayinketqua
        {
            get { return _cauhinh_mayinketqua; }
            set { _cauhinh_mayinketqua = value; }
        }

        public string Pcname { get; set; }

        public string Printername { get; set; }

        public string Reporttemplateid { get; set; }

        public string Papersizetype { get; set; }
        public CAUHINH_MAYINKETQUA() { }
        public CAUHINH_MAYINKETQUA(string pcname, string printername, string reporttemplateid, string papersizetype)
        {
            this.Pcname = pcname;
            this.Printername = printername;
            this.Reporttemplateid = reporttemplateid;
            this.Papersizetype = papersizetype;
        }
        public CAUHINH_MAYINKETQUA Copy()
        {
            return (CAUHINH_MAYINKETQUA)this.MemberwiseClone();
        }
        public bool Compare_Differences(CAUHINH_MAYINKETQUA objCompare)
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
}
