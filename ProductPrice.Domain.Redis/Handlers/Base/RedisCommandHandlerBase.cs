using System.Threading.Tasks;
using ProductPrice.Abstractions.CQRS;
using ProductPrice.Abstractions.CQRS.Handlers;
using ProductPrice.Domain.Redis.Context;

namespace ProductPrice.Domain.Redis.Handlers.Base
{
    public abstract class RedisCommandHandlerBase<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        protected readonly IRedisContext RedisContext;

        protected RedisCommandHandlerBase(IRedisContext redisContext)
        {
            RedisContext = redisContext;
        }

        public abstract Task Execute(TCommand context);
    }
}