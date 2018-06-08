using Autofac;
using Autofac.Integration.WebApi;

namespace ProductPriceApi
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(ThisAssembly);
        }
    }
}