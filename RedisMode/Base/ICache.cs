using System;
using System.Collections.Generic;

namespace RedisMode.Base
{
    public interface ICache<T> where T:Entity 
    {
        void SetString(string key, string objectToCache, TimeSpan? expiry = null);
        void Set(string key, T objectToCache, TimeSpan? expiry = null);
        string GetString(string key);
        T Get(string key);
        List<T> GetList(string key);
        void Delete(string key);
        void FlushAll();
    }
}