using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands.Authorization;
using ProductPrice.Domain.Redis.Context;
using ProductPrice.Domain.Redis.Extensions;
using ProductPrice.Domain.Redis.Handlers.Base;
using ProductPrice.Domain.Redis.Items;

namespace ProductPrice.Domain.Implementation.Handlers.Command.Redis
{
    public class SetRefreshTokenCommandHandler : RedisCommandHandlerBase<SetRefreshTokenCommand>
    {
        public SetRefreshTokenCommandHandler(IRedisContext redisContext) : base(redisContext)
        {
        }

        public override async Task Execute(SetRefreshTokenCommand context)
        {
            var database = RedisContext.GetDatabase<UserAuthorizationRedisItem>();

            await database.SetObjectAsync<UserAuthorizationRedisItem, UserAuthorizationRedisKey, UserAuthorizationRedisValue>(
                    new UserAuthorizationRedisItem
                    {
                        Value = new UserAuthorizationRedisValue
                        {
                            RefreshToken = context.RefreshToken
                        },
                        Key = new UserAuthorizationRedisKey
                        {
                            UserId = context.UserId
                        }
                    });
        }
    }
}