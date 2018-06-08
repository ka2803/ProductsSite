using System.Threading.Tasks;
using ProductPrice.Abstractions.CQRS;
using ProductPrice.Abstractions.CQRS.Handlers;
using ProductPrice.Domain.Redis.Context;

namespace ProductPrice.Domain.Redis.Handlers.Base
{
    public abstract class RedisQueryHandlerBase<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TResult : IQueryResult
        where TQuery : IQuery<TResult>
    {
        protected readonly IRedisContext RedisContext;

        protected RedisQueryHandlerBase(IRedisContext redisContext)
        {
            RedisContext = redisContext;
        }

        public abstract Task<TResult> Execute(TQuery query);
    }
}