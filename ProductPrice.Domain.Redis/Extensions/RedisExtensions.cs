using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ProductPrice.Domain.Redis.Items.Base;
using StackExchange.Redis;

namespace ProductPrice.Domain.Redis.Extensions
{
    public static class RedisExtensions
    {
        public static async Task SetObjectAsync<TItem, TKey, TValue>(this IDatabase database, TItem item)
            where TItem : IRedisItem<TKey, TValue> 
            where TKey : IRedisKey 
            where TValue : IRedisValue
        {
            if (item == null || item.Key == null || item.Value == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var keyString = ParseToStringViaJToken(item.Key);

            var valueString = ParseToStringViaJToken(item.Value);

            await database.StringSetAsync(keyString, valueString);
        }

        public static async Task<TItem> GetObjectAsync<TItem, TKey, TValue>(this IDatabase database, TKey key)
            where TItem : IRedisItem<TKey, TValue>, new()
            where TKey : IRedisKey
            where TValue : IRedisValue
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var keyString = ParseToStringViaJToken(key);

            var valueString = await database.StringGetAsync(keyString);

            if (!valueString.HasValue)
            {
                return default(TItem);
            }

            var value = JToken.Parse(valueString.ToString()).ToObject<TValue>();

            var item = new TItem
            {
                Value = value,
                Key = key
            };

            return item;
        }


        private static string ParseToStringViaJToken(object @object)
        {
            var jToken = JToken.FromObject(@object);

            return jToken.ToString();
        }
    }
}