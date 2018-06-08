using System;
using StackExchange.Redis;

namespace ProductPrice.Domain.Redis.Context
{
    public interface IRedisConnection : IDisposable
    {
        IConnectionMultiplexer GetConncetion();
    }
}