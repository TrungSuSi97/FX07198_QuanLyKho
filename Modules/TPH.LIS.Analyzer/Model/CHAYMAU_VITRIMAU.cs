using System;
using System.Reflection;

namespace TPH.LIS.Analyzer.Model
{
    #region chaymau_vitrimau
    public class CHAYMAU_VITRIMAU
    {
        string _chaymau_vitrimau = "chaymau_vitrimau";
        public string Chaymau_vitrimau
        {
            get { return _chaymau_vitrimau; }
            set { _chaymau_vitrimau = value; }
        }

        public int Id { get; set; }

        public int Idlantao { get; set; }

        public DateTime Ngaychaymau { get; set; }

        public int Insid { get; set; }

        public string Platecode { get; set; }

        public int Platecount { get; set; }
        int _vitridoc = 1;
        public int Vitridoc
        {
            get { return _vitridoc; }
            set { _vitridoc = value; }
        }
        int _vitringang = 1;
        public int Vitringang
        {
            get { return _vitringang; }
            set { _vitringang = value; }
        }

        public string Barcode { get; set; }

        public string Poscode { get; set; }

        public string Maxetnghiem { get; set; }

        public string Maxetnghiemmay { get; set; }
        int _samples = 0;
        public int Samples
        {
            get { return _samples; }
            set { _samples = value; }
        }
        public int Runtype { get; set; }
        public string Valuedisplay { get; set; }

        public CHAYMAU_VITRIMAU() { }
        public CHAYMAU_VITRIMAU(int id, int idlantao, DateTime ngaychaymau, int insid, string platecode, int platecount, int vitridoc, int vitringang, string barcode, string poscode
        , string maxetnghiem, string maxetnghiemmay, int samples)
        {
            this.Id = id;
            this.Idlantao = idlantao;
            this.Ngaychaymau = ngaychaymau;
            this.Insid = insid;
            this.Platecode = platecode;
            this.Platecount = platecount;
            this.Vitridoc = vitridoc;
            this.Vitringang = vitringang;
            this.Barcode = barcode;
            this.Poscode = poscode;
            this.Maxetnghiem = maxetnghiem;
            this.Maxetnghiemmay = maxetnghiemmay;
            this.Samples = samples;
        }
        public CHAYMAU_VITRIMAU Copy()
        {
            return (CHAYMAU_VITRIMAU)this.MemberwiseClone();
        }
        public bool Compare_Differences(CHAYMAU_VITRIMAU objCompare)
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
