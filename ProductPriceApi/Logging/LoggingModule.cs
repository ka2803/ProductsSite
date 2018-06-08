using Autofac;

namespace ProductPriceApi.Logging
{
    public class LoggingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ExceptionLogger>().AsImplementedInterfaces();
            builder.RegisterType<ExceptionHandler>().AsImplementedInterfaces();
        }
    }
}