﻿using System;
using Newtonsoft.Json;
using StackExchange.Redis;
using Formatting = System.Xml.Formatting;

namespace RequireJsDemo.Responsive
{
    public class RedisCacheString: Cache
    {
        private ConnectionMultiplexer _redisConnections;

        private IDatabase RedisDatabase
        {
            get
            {
                if (this._redisConnections == null)
                {
                    InitializeConnection();
                }
                return this._redisConnections != null ? this._redisConnections.GetDatabase() : null;
            }
        }

        public RedisCacheString(bool isCacheEnabled) : base(isCacheEnabled)
        {
            InitializeConnection();
        }

        private void InitializeConnection()
        {
            try
            {
                this._redisConnections = ConnectionMultiplexer.Connect(System.Configuration.ConfigurationManager.AppSettings["CacheConnectionString"]);
            }
            catch (RedisConnectionException errorConnectionException)
            {
                //Log.Error("Error connecting the redis cache : " + errorConnectionException.Message, errorConnectionException);
            }
        }

        protected override string GetStringProtected(string key)
        {
            if (this.RedisDatabase == null)
            {
                return null;
            }
            var redisObject = this.RedisDatabase.StringGet(key);
            if (redisObject.HasValue)
            {
                return redisObject.ToString();
            }
            else
            {
                return null;
            }
        }

        protected override RedisValue[] GetListProtected(string key)
        {
            if (this.RedisDatabase == null)
            {
                return null;
            }
            var redisObject = this.RedisDatabase.SetMembers(key);
            if (redisObject.Length > 0)
            {
                return redisObject;
            }
            else
            {
                return null;
            }
        }

        protected override void SetStringProtected(string key, string objectToCache, TimeSpan? expiry = null)
        {
            if (this.RedisDatabase == null)
            {
                return;
            }

            this.RedisDatabase.StringSet(key, objectToCache, expiry);
        }

        protected override void DeleteProtected(string key)
        {
            if (this.RedisDatabase == null)
            {
                return;
            }
            this.RedisDatabase.KeyDelete(key);
        }

        protected override void FlushAllProtected()
        {
            if (this.RedisDatabase == null)
            {
                return;
            }
            var endPoints = this._redisConnections.GetEndPoints();
            foreach (var endPoint in endPoints)
            {
                var server = this._redisConnections.GetServer(endPoint);
                server.FlushAllDatabases();
            }
        }

        protected override void DeleteByPatternProtected(string key)
        {
            if (this.RedisDatabase == null)
            {
                return;
            }
            this.RedisDatabase.KeyDelete(key);
        }

        public override bool IsCacheRunning
        {
            get { return this._redisConnections != null && this._redisConnections.IsConnected; }
        }
    }
}