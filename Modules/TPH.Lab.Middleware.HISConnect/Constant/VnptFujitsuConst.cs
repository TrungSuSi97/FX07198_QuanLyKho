using TPH.LIS.Common.Extensions;

namespace TPH.Lab.Middleware.HISConnect.Constant
{
    public class VnptFujitsuConst{
        private static readonly CachingExtension Caching = new CachingExtension();
        public const string DefaultVftPostUrl = "http://ytedientu.com.vn:6060/mms/HihisApi";

        public const string ActionLogin = "token";
        public const string ActionGetDepartment = "dept";
        public const string ActionGetRoom = "room";
        public const string ActionGetService = "service";
        public const string ActionGetDoctor = "doctor";
        public const string ActionGetDisease = "disease";
        public const string ActionGetObject = "object";
        public const string ActionGetOrders = "lstOrder";
        public const string ActionUpdateOrderStatus = "updateStatus";
        public const string ActionGetOrderDetail = "orderDetail";
        public const string ActionUploadOrder = "lisReturn";

        public const string CacheKeyApiToken = "VnptFujitsuTokenKey";

    //    public const string VftUploadKetQuaUrl = "VftUploadKetQuaUrl";

        public static string VftUploadKetQuaUrl
        {
            get
            {
                var cachingValue = Caching.Get<string>("VftUploadKetQuaUrl");
                return string.IsNullOrWhiteSpace(cachingValue)
                    ? DefaultVftPostUrl
                    : cachingValue;
            }
            set { }
        }

        public static string ApiToken
        {
            get
            {
                var cachingValue = Caching.Get<string>(CacheKeyApiToken);
                return cachingValue;
            }
            set
            {
                Caching.Set<string>(CacheKeyApiToken, value);
            }
        }
    }
}
