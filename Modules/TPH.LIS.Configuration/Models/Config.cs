using System.Reflection;

namespace TPH.LIS.Configuration.Models
{
    #region config
    public class CONFIG
    {
        string _config = "config";
        public string Config
        {
            get { return _config; }
            set { _config = value; }
        }

        public int Id { get; set; }

        public int Idconfig { get; set; }

        public string Value1 { get; set; }

        public string Value2 { get; set; }

        public string Description { get; set; }
        int _flat = -1;
        public int Flat
        {
            get { return _flat; }
            set { _flat = value; }
        }
        bool _nattest = false;
        public bool Nattest
        {
            get { return _nattest; }
            set { _nattest = value; }
        }
        public CONFIG() { }
        public CONFIG(int id, int idconfig, string value1, string value2, string description, int flat, bool nattest)
        {
            this.Id = id;
            this.Idconfig = idconfig;
            this.Value1 = value1;
            this.Value2 = value2;
            this.Description = description;
            this.Flat = flat;
            this.Nattest = nattest;
        }
        public CONFIG Copy()
        {
            return (CONFIG)this.MemberwiseClone();
        }
        public bool Compare_Differences(CONFIG objCompare)
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
