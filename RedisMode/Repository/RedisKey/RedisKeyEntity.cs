using RedisMode.Base;

namespace RedisMode.Repository.RedisKey
{
    public class RedisKeyEntity:Entity
    {
        public string Name { get; set; }
        public int Status { get; set; }
    }
}
