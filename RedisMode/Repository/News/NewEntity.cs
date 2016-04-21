using RedisMode.Base;

namespace RedisMode.Repository.News
{
    public class NewsEntity:Entity
    {
        public string Title { get; set; }
        public int Status { get; set; }
    }
}
