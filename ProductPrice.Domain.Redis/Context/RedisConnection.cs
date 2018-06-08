using ProductPrice.Domain.Redis.Configuration;
using StackExchange.Redis;

namespace ProductPrice.Domain.Redis.Context
{
    internal class RedisConnection : IRedisConnection
    {
        private readonly IRedisConfiguration _configuration;
        private IConnectionMultiplexer _connectionMultiplexer;

        public RedisConnection(IRedisConfiguration configuration)
        {
            _configuration = configuration;
            _connectionMultiplexer = ConnectionMultiplexer.Connect(configuration.ConnectionString);

            _connectionMultiplexer.ConnectionFailed += (sender, args) => Reconnect();
            _connectionMultiplexer.InternalError += (sender, args) => Reconnect();
        }

        public IConnectionMultiplexer GetConncetion()
        {
            return _connectionMultiplexer;
        }

        private void Reconnect()
        {
            _connectionMultiplexer = ConnectionMultiplexer.Connect(_configuration.ConnectionString);
        }

        public void Dispose()
        {
            _connectionMultiplexer?.Dispose();
        }
    }
}