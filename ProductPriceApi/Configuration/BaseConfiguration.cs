using Microsoft.Extensions.Configuration;

namespace ProductPriceApi.Configuration
{
    public abstract class BaseConfiguration
    {
        protected BaseConfiguration(IConfigurationRoot configurationRoot)
        {
            var section = configurationRoot.GetSection(GetType().Name);
            section.Bind(this);
        }
    }
}