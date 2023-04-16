using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace TPH.LIS.Common.Extensions
{
    public class CachingExtension
    {
        private static volatile HashSet<string> _listKey;

        private static volatile ObjectCache _objCache;
        private static object _syncRoot = new object();

        public int Count
        {
            get { return (int) CacheInstance.GetCount(); }
        }
        public HashSet<string> Keys
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

        public bool Contains(string key)
        {
            return CacheInstance.Contains(key);
        }

        public T Get<T>(string key)
        {
            return this.Contains(key) ? (T) CacheInstance[key] : default(T);
        }

        public bool TryGet<T>(string key, out T value)
        {
            var checkTryGet = this.Contains(key);
            if (checkTryGet)
            {
                value = (T) Get<T>(key);
            }
            else
            {
                value = default(T);
            }

            return checkTryGet;
        }

        public void Set<T>(string key, T value, CacheItemPolicy cacheItemPolicy)
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
                this.Keys.Add(key);
            }
        }

        public void Set<T>(string key, T value, int timeOut = 120)
        {
            this.Set<T>(key, value, DateTime.Now.AddSeconds(timeOut));
        }

        public void Set<T>(string key, T value, DateTime absoluteExpiration)
        {
            var cacheItemPolicy = new CacheItemPolicy {AbsoluteExpiration = absoluteExpiration};
            this.Set<T>(key, value, cacheItemPolicy);
        }

        public void Set<T>(string key, T value, TimeSpan slidingExpiration)
        {
            var cacheItemPolicy = new CacheItemPolicy {SlidingExpiration = slidingExpiration};

            this.Set<T>(key, value, cacheItemPolicy);
        }

        public void Remove(string key)
        {
            this.Keys.Remove(key);
            CacheInstance.Remove(key);
        }

        public void Clear()
        {
            while (this.Keys.Count > 0)
            {
                this.Remove(this.Keys.First());
            }
        }

        public void Dispose()
        {
            _objCache = null;
            _listKey = null;
        }
    }
}
