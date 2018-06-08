using Autofac;
using ProductPrice.Domain.Redis.Context;

namespace ProductPrice.Domain.Redis
{
    public class RedisModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RedisConnection>()
                .AsImplementedInterfaces()
                .SingleInstance()
                .AutoActivate();

            builder.RegisterType<RedisContext>()
                .AsImplementedInterfaces();
        }
    }
}