namespace TPH.Lab.BusinessService.Services
{
    public abstract class BaseService<T> where T : new()
    {
        private static T _instance = default(T);

        public static T GetInstance()
        {
            if (_instance == null)
            {
                _instance = new T();
            }

            return _instance;
        }
        protected K GetDbReaderValue<K>(object value)
        {
            if (System.DBNull.Value.Equals(value) == false && value != null)
            {
                return (K)value;
            }
            return default(K);
        }
    }
}
