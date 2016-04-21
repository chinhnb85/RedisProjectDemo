using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedisMode.Mode;

namespace RedisMode.Repository.News
{
    public class NewsService
    {
        private RedisCacheSet<NewsEntity> _redisCacheSet;
        public NewsService()
        {
            _redisCacheSet = new RedisCacheSet<NewsEntity>(true);
        }

        public void Add(NewsEntity newsEntity)
        {           
            _redisCacheSet.Set(typeof(NewsEntity).Name,newsEntity);            
        }

        public NewsEntity Get(string key)
        {
            var obj= _redisCacheSet.Get(key);
            return obj;
        }

        public List<NewsEntity> GetList(string key)
        {
            var obj = _redisCacheSet.GetList(key);
            return obj;
        }
    }
}
