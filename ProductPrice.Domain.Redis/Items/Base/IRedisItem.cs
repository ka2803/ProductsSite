namespace ProductPrice.Domain.Redis.Items.Base
{
    public interface IRedisItem<TKey, TValue> where TKey : IRedisKey where TValue : IRedisValue
    {
        TKey Key { get; set; }
        TValue Value { get; set; }
    }
}