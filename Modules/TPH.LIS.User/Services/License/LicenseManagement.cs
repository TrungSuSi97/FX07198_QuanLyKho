using TPH.LIS.User.Repositories.License;

namespace TPH.LIS.User.Services.License
{
    public class LicenseManagement : ILicenseManagement
    {
        private readonly ILicenseManagementRepository _license;
        public LicenseManagement(): this(null)
        {

        }
        public LicenseManagement(LicenseManagementRepository license)
        {
            _license = license ?? new LicenseManagementRepository();
        }
        public bool CheckValidSerial(string computerName, string applicationName, string serialNumber)
        {
            return _license.CheckValidSerial(computerName, applicationName, serialNumber);
        }

        public void UpdateSerialKey(string computerName, string applicationName, string serialNumber, string keyNumber)
        {
            _license.UpdateSerialKey(computerName, applicationName, serialNumber, keyNumber);
        }
    }
}
