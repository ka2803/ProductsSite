using System;
using ProductPrice.Domain.Redis.Attributes;
using ProductPrice.Domain.Redis.Enums;
using ProductPrice.Domain.Redis.Items.Base;

namespace ProductPrice.Domain.Redis.Items
{
    [Index(RedisIndex.Authorization)]
    public class UserAuthorizationRedisItem: IRedisItem<UserAuthorizationRedisKey, UserAuthorizationRedisValue>
    {
        public UserAuthorizationRedisKey Key { get; set; }
        public UserAuthorizationRedisValue Value { get; set; }
    }

    public class UserAuthorizationRedisKey : IRedisKey
    {
        public Guid UserId { get; set; }
    }

    public class UserAuthorizationRedisValue : IRedisValue
    {
        public string RefreshToken { get; set; }
    }
}