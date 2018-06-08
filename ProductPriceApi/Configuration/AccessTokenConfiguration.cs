using System;
using Microsoft.Extensions.Configuration;
using ProductPrice.Abstractions.Configuration;

namespace ProductPriceApi.Configuration
{
    public class AccessTokenConfiguration : BaseConfiguration, IAccessTokenConfiguration
    {
        public AccessTokenConfiguration(IConfigurationRoot configurationRoot) : base(configurationRoot)
        {
        }

        public string SecretKey { get; set; }
        public TimeSpan Lifetime { get; set; }
    }
}