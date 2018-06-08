using System;
using Autofac;
using Microsoft.Extensions.Configuration;

namespace ProductPriceApi.Configuration
{
    public class ConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(CreateConfigurationRoot)
                .SingleInstance()
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AssignableTo<BaseConfiguration>()
                .AsImplementedInterfaces()
                .SingleInstance()
                .AutoActivate();
        }

        private static IConfigurationRoot CreateConfigurationRoot(IComponentContext context)
        {
            var builder = new ConfigurationBuilder();

            var configurationBuilder = builder.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("settings.json", optional: false, reloadOnChange: true);

            var configurationRoot = configurationBuilder.Build();
            return configurationRoot;
        }
    }
}