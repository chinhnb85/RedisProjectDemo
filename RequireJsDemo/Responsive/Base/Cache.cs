using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoggingExtensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace RequireJsDemo.Responsive
{
    public abstract class Cache:ICache,ICacheStatus
    {
        private readonly bool _isCacheEnable;

        protected Cache(bool isCacheEnable)
        {
            this._isCacheEnable = isCacheEnable;
        }

        public void Set<T>(string key, T objectToCache, TimeSpan? expiry = null) where T : class
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }
            if (this._isCacheEnable)
            {
                try
                {
                    var serializedObjectToCache = JsonConvert.SerializeObject(objectToCache
                         , Formatting.Indented
                         , new JsonSerializerSettings
                         {
                             ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                             //PreserveReferencesHandling = PreserveReferencesHandling.Objects,//auto created $id
                             //TypeNameHandling = TypeNameHandling.All//auto created $type
                         });

                    this.SetStringProtected(key, serializedObjectToCache, expiry);
                }
                catch (Exception e)
                {
                    //Log.Error(string.Format("Cannot Set {0}", key), e);
                }
            }
        }

        public T Get<T>(string key) where T : class
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }
            if (this._isCacheEnable)
            {
                try
                {
                    var stringObject = this.GetStringProtected(key);
                    if (stringObject == null)
                    {
                        return default(T);
                    }
                    else
                    {
                        var obj = JsonConvert.DeserializeObject<T>(stringObject
                            , new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                                //PreserveReferencesHandling = PreserveReferencesHandling.Objects,//auto created $id
                                //TypeNameHandling = TypeNameHandling.All//auto created $type
                            });
                        return obj;
                    }
                }
                catch (Exception e)
                {
                    //Log.Error(string.Format("Cannot Set key {0}", key), e);
                }
            }
            return null;
        }

        public List<T> GetList<T>(string key) where T : class
        {
            var list = new List<T>();
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }
            if (this._isCacheEnable)
            {
                try
                {
                    var listObject = this.GetListProtected(key);
                    if (listObject == null)
                    {
                        return list;
                    }
                    else
                    {
                        foreach (var item in listObject)
                        {
                            if (item.HasValue)
                            {
                                var obj = JsonConvert.DeserializeObject<T>(item.ToString()
                                    , new JsonSerializerSettings
                                    {
                                        ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                                        //PreserveReferencesHandling = PreserveReferencesHandling.Objects,//auto created $id
                                        //TypeNameHandling = TypeNameHandling.All//auto created $type
                                    });
                                list.Add(obj);
                            }
                        }
                        
                        return list;
                    }
                }
                catch (Exception e)
                {
                    //Log.Error(string.Format("Cannot Set key {0}", key), e);
                }
            }
            return null;
        }

        public void Delete(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }
            if (this._isCacheEnable)
            {
                try
                {
                    this.DeleteProtected(key);
                }
                catch (Exception e)
                {
                    //Log.Error(string.Format("Cannot Delete key {0}", key), e);
                }
            }
        }

        public void DeleteByPattern(string prefixKey)
        {
            if (string.IsNullOrEmpty(prefixKey))
            {
                throw new ArgumentNullException("prefixKey");
            }
            if (this._isCacheEnable)
            {
                try
                {
                    this.DeleteByPatternProtected(prefixKey);
                }
                catch (Exception e)
                {
                    //Log.Error(string.Format("Cannot DeleteByPattern key {0}", prefixKey), e);
                }
            }
        }

        public void FlushAll()
        {
            if (this._isCacheEnable)
            {
                try
                {
                    this.FlushAllProtected();
                }
                catch (Exception e)
                {
                    //Log.Error("Cannot Flush", e);
                }
            }
        }

        public string GetString(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }
            if (this._isCacheEnable)
            {
                try
                {
                    return this.GetStringProtected(key);
                }
                catch (Exception e)
                {
                    //Log.Error(string.Format("Cannot Set key {0}", key), e);
                }
            }
            return null;
        }

        public void SetString(string key, string objectToCache, TimeSpan? expiry = null)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }
            if (this._isCacheEnable)
            {
                try
                {
                    this.SetStringProtected(key, objectToCache, expiry);
                }
                catch (Exception e)
                {
                    //Log.Error(string.Format("Cannot Set {0}", key), e);
                }
            }
        }
        public bool IsCacheEnabled
        {
            get { return this._isCacheEnable; }

        }

        protected abstract void SetStringProtected(string key, string objectToCache, TimeSpan? expiry = null);
        protected abstract string GetStringProtected(string key);
        protected abstract void DeleteProtected(string key);
        protected abstract void FlushAllProtected();
        protected abstract void DeleteByPatternProtected(string key);
        public abstract bool IsCacheRunning { get; }

        protected abstract RedisValue[] GetListProtected(string key);
    }
}