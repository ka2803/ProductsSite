using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Queries.Authorization;
using ProductPrice.Abstractions.Exceptions.Authorization;
using ProductPrice.Domain.Redis.Context;
using ProductPrice.Domain.Redis.Enums;
using ProductPrice.Domain.Redis.Extensions;
using ProductPrice.Domain.Redis.Handlers.Base;
using ProductPrice.Domain.Redis.Items;

namespace ProductPrice.Domain.Implementation.Handlers.Query.Authorization
{
    public class UserRefreshTokenQueryHandler : RedisQueryHandlerBase<UserRefreshTokenQuery, UserRefreshTokenResponse>
    {
        public UserRefreshTokenQueryHandler(IRedisContext redisContext) : base(redisContext)
        {
        }

        public override async Task<UserRefreshTokenResponse> Execute(UserRefreshTokenQuery query)
        {
            var refreshTokenItem = await RedisContext.GetDatabase<UserAuthorizationRedisItem>()
                .GetObjectAsync<UserAuthorizationRedisItem, UserAuthorizationRedisKey, UserAuthorizationRedisValue>(new UserAuthorizationRedisKey
                {
                    UserId = query.UserId
                });

            if (refreshTokenItem == null)
            {
                throw new UserNotAuthorizedException(query.UserId);
            }

            return new UserRefreshTokenResponse
            {
                RefreshToken = refreshTokenItem.Value.RefreshToken
            };
        }
    }
}