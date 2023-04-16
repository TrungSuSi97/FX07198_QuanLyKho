namespace TPH.LIS.User.Services.License
{
    public interface ILicenseManagement
    {
        bool CheckValidSerial(string computerName, string applicationName, string serialNumber);
        void UpdateSerialKey(string computerNae, string applicationName, string serialNumber, string keyNumber);
    }
}
