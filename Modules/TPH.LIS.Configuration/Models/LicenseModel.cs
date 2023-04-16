using System;

namespace TPH.LIS.Configuration.Models
{
    public class LicenseModel
    {
        public string PcName { get; set; }
        public string CustomerId { get; set; }
        public bool CheckLicenseOnServer { get; set; }
        public bool HasLicense { get; set; }
        public bool FullLicense { get; set; }
        public bool ChangeLicense { get; set; }
        public DateTime StartDate { get; set; } = new DateTime(2017, 1, 1);
        public DateTime EndDate { get; set; } = new DateTime(2017, 1, 1);
        public string Serial { get; set; }

        public string StatusShortDescription { get; set; }
        public string StatusFullDescription { get; set; }
    }
}
