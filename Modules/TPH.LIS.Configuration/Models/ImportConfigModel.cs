using System.Reflection;

namespace TPH.LIS.Configuration.Models
{
    #region dm_loaiimport
    public class DM_LOAIIMPORT
    {
        string _dm_loaiimport = "dm_loaiimport";
        public string Dm_loaiimport
        {
            get { return _dm_loaiimport; }
            set { _dm_loaiimport = value; }
        }

        public string Maimport { get; set; }

        public string Tenimport { get; set; }
        int _dongtieude = 1;
        public int Dongtieude
        {
            get { return _dongtieude; }
            set { _dongtieude = value; }
        }
        int _dongbatdau = 2;
        public int Dongbatdau
        {
            get { return _dongbatdau; }
            set { _dongbatdau = value; }
        }
        int _loaiimport = 1;
        public int Loaiimport
        {
            get { return _loaiimport; }
            set { _loaiimport = value; }
        }
        public bool Noidong { get; set; }
        public string Cotindexnoidong { get; set; }
        public DM_LOAIIMPORT() { }
        public DM_LOAIIMPORT Copy()
        {
            return (DM_LOAIIMPORT)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_LOAIIMPORT objCompare)
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
    #region dm_loaiimport_mapping
    public class DM_LOAIIMPORT_MAPPING
    {
        string _dm_loaiimport_mapping = "dm_loaiimport_mapping";
        public string Dm_loaiimport_mapping
        {
            get { return _dm_loaiimport_mapping; }
            set { _dm_loaiimport_mapping = value; }
        }
        public int Id { get; set; }

        public string Maimport { get; set; }

        public string Liscolumn { get; set; }

        public string Excelcolumn { get; set; }
        bool _loaixetnghiem = false;
        public bool Loaixetnghiem
        {
            get { return _loaixetnghiem; }
            set { _loaixetnghiem = value; }
        }

        public string Ketluancuaxn { get; set; }
        public string Maxnlis { get; set; }
        public DM_LOAIIMPORT_MAPPING() { }
        public DM_LOAIIMPORT_MAPPING Copy()
        {
            return (DM_LOAIIMPORT_MAPPING)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_LOAIIMPORT_MAPPING objCompare)
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
