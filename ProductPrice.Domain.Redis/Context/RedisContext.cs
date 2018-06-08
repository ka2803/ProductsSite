using System.Reflection;
using ProductPrice.Domain.Redis.Attributes;
using ProductPrice.Domain.Redis.Enums;
using ProductPrice.Domain.Redis.Items.Base;
using StackExchange.Redis;

namespace ProductPrice.Domain.Redis.Context
{
    //Builder pattern
    internal class RedisContext : IRedisContext
    {
        private readonly IRedisConnection _connection;

        public RedisContext(IRedisConnection connection)
        {
            _connection = connection;
        }

        public IDatabase GetDatabase<TItem>()
        {
            var multiplexer = _connection.GetConncetion();

            var index = GetIndex<TItem>();

            var db = multiplexer.GetDatabase((int) index);

            return db;
        }

        protected virtual RedisIndex GetIndex<TItem>()
        {
            var itemIndex = typeof(TItem).GetCustomAttribute<IndexAttribute>();

            var index = itemIndex?.Index ?? RedisIndex.Stash;

            return index;
        }
    }
}