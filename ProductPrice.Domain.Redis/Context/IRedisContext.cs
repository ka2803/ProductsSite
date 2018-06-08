using StackExchange.Redis;

namespace ProductPrice.Domain.Redis.Context
{
    public interface IRedisContext
    {
        IDatabase GetDatabase<TItem>();
    }
}