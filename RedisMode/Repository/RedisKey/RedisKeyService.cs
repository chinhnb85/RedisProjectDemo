using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedisMode.Mode;

namespace RedisMode.Repository.RedisKey
{
    public class RedisKeyService
    {
        private RedisCacheString<RedisKeyEntity> _redisCacheString;
        public RedisKeyService()
        {
            _redisCacheString = new RedisCacheString<RedisKeyEntity>(true);
        }

        public void Add(RedisKeyEntity redisKeyEntity)
        {           
            _redisCacheString.Set(typeof(RedisKeyEntity).Name,redisKeyEntity,new TimeSpan(1,2,60,30));            
        }

        public RedisKeyEntity Get(string key)
        {
            var obj= _redisCacheString.Get(key);
            return obj;
        }
    }
}
