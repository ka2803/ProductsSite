namespace ProductPrice.Domain.Redis.Configuration
{
    public interface IRedisConfiguration
    {
        string ConnectionString { get; }
    }
}