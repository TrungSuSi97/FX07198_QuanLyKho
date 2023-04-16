namespace TPH.LIS.Patient.Model
{
    using System;
    public class BloodInfo
    {
        public BloodInfo() { }
        public string FBloodDB { get; set; }
        public string BloodID { get; set; }
        public string ABOResult { get; set; }
        public string RhResult { get; set; }
        public string UserInsert { get; set; }
        public DateTime DateInsert { get; set; }
        public string Comment { get; set; }
    }
}
