namespace TPH.LIS.User.Repositories.License
{
    public interface ILicenseManagementRepository
    {
        bool CheckValidSerial(string computerName, string applicationName, string serialNumber);
        void UpdateSerialKey(string computerName, string applicationName, string serialNumber, string keyNumber);
    }
}
