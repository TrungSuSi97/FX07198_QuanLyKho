namespace TPH.LIS.Patient.Model
{
    using System.Collections.Generic;

    public class BenhNhanInfoForHIS : BENHNHAN_TIEPNHAN
    {
        public string userTransfer { get; set; }

        public string Tenbacsichidinh { get; set; }
        public string Tendoituongdichvu { get; set; }
        public string KetLuan { get; set; }
        public string Tenmayin { get; set; }
        public List<ChiDinhHISInfo> ChiDinh { get; set; }
        public string BacrodeDaTiepNhan { get; set; }

        public BenhNhanInfoForHIS()
        {
            ChiDinh = new List<ChiDinhHISInfo>();
        }
        public BenhNhanInfoForHIS CopyHISInfo()
        {
            return (BenhNhanInfoForHIS)this.MemberwiseClone();
        }
    }
}
