using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace TPH.HIS.WebAPI.Extensions
{
    public class CachingExtension
    {
        private static volatile HashSet<string> _listKey;

        private static volatile ObjectCache _objCache;
        private static object _syncRoot = new object();

        public static int Count
        {
            get { return (int)CacheInstance.GetCount(); }
        }

        public static HashSet<string> Keys
        {
            get
            {
                if (_listKey != null) return _listKey;

                lock (_syncRoot)
                {
                    if (_listKey == null)
                    {
                        _listKey = new HashSet<string>();
                    }
                }

                return _listKey;
            }
        }

        private static ObjectCache CacheInstance
        {
            get
            {
                if (_objCache != null) return _objCache;

                lock (_syncRoot)
                {
                    if (_objCache == null)
                    {
                        _objCache = MemoryCache.Default;
                    }
                }

                return _objCache;
            }
        }

        public static bool Contains(string key)
        {
            return CacheInstance.Contains(key);
        }

        public static T Get<T>(string key)
        {
            return Contains(key) ? (T)CacheInstance[key] : default(T);
        }

        public static bool TryGet<T>(string key, out T value)
        {
            var checkTryGet = Contains(key);
            if (checkTryGet)
            {
                value = (T)Get<T>(key);
            }
            else
            {
                value = default(T);
            }

            return checkTryGet;
        }

        public static void Set<T>(string key, T value, CacheItemPolicy cacheItemPolicy)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException();
            }

            var cacheItem = new CacheItem(key, value);
            CacheInstance.Set(cacheItem, cacheItemPolicy);

            //// Because HashSet is not thread safe
            lock (_syncRoot)
            {
                Keys.Add(key);
            }
        }

        public static void Set<T>(string key, T value, int timeOut = 20)
        {
            Set<T>(key, value, DateTime.Now.AddMinutes(timeOut));
        }

        public static void Set<T>(string key, T value, DateTime absoluteExpiration)
        {
            var cacheItemPolicy = new CacheItemPolicy { AbsoluteExpiration = absoluteExpiration };
            Set<T>(key, value, cacheItemPolicy);
        }

        public static void Set<T>(string key, T value, TimeSpan slidingExpiration)
        {
            var cacheItemPolicy = new CacheItemPolicy { SlidingExpiration = slidingExpiration };

            Set<T>(key, value, cacheItemPolicy);
        }

        public static void Remove(string key)
        {
            Keys.Remove(key);
            CacheInstance.Remove(key);
        }

        public static void Clear()
        {
            while (Keys.Count > 0)
            {
                Remove(Keys.First());
            }
        }

        public static void Dispose()
        {
            _objCache = null;
            _listKey = null;
        }
    }
}
