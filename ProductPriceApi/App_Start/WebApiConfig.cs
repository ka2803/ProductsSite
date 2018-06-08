using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using log4net.Config;
using Newtonsoft.Json;
using ProductPrice.Domain.Database;
using ProductPrice.Domain.Implementation;
using ProductPrice.Domain.Redis;
using ProductPriceApi.Configuration;
using ProductPriceApi.Logging;
using Swashbuckle.Application;

namespace ProductPriceApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "swagger_root",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler(message => message.RequestUri.ToString(), "swagger"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
            );

            

            var builder = new ContainerBuilder();

            builder.RegisterModule<DatabaseModule>();
            builder.RegisterModule<RedisModule>();
            builder.RegisterModule<ImplementationModule>();
            builder.RegisterModule<ApiModule>();
            builder.RegisterModule<LoggingModule>();
            builder.RegisterModule<ConfigurationModule>();


            builder.RegisterWebApiFilterProvider(config);

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            XmlConfigurator.Configure();

            config.EnsureInitialized();
        }
    }
}