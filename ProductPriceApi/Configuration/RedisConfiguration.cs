using Microsoft.Extensions.Configuration;
using ProductPrice.Domain.Redis.Configuration;

namespace ProductPriceApi.Configuration
{
    public class RedisConfiguration : BaseConfiguration, IRedisConfiguration
    {
        public string ConnectionString { get; set; }

        public RedisConfiguration(IConfigurationRoot configurationRoot) : base(configurationRoot)
        {
        }
    }
}