using TPH.LIS.User.Repositories.ServiceSetting;

namespace TPH.LIS.User.Services.ServiceSetting
{
    public class ServiceSettingService : IServiceSettingService
    {
        private readonly IServiceSettingRepository _serviceSetting;

        public ServiceSettingService() : this(null)
        {

        }
        public ServiceSettingService(ServiceSettingRepository serviceSetting)
        {
            _serviceSetting = serviceSetting ?? new ServiceSettingRepository();
        }

        public string GetDefaultServiceCode()
        {
            return _serviceSetting.GetDefaultServiceCode();
        }
    }
}
