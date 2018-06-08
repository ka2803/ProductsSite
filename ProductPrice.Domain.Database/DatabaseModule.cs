using Autofac;
using ProductPrice.Domain.Database.Context;

namespace ProductPrice.Domain.Database
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductPriceContext>().AsImplementedInterfaces();
        }
    }
}