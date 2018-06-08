using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using WebActivatorEx;
using ProductPriceApi;
using Swashbuckle.Application;
using ProductPriceApi.Attributes;
using ProductPriceApi.Attributes.Filters;
using Swashbuckle.Swagger;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ProductPriceApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(config =>
                    {
                        config.SingleApiVersion("v1", "ProductPriceApi");
                        config.OperationFilter<AccessTokenHeaderOperationFilter>();
                        config.UseFullTypeNameInSchemaIds();
                       
                        config.OperationFilter<ControllerNameOperationFilter>();

                        config.GroupActionsBy(apiDesc => apiDesc.GetControllerAndActionAttributes<ControllerNameAttribute>().FirstOrDefault()?.Name);
                        
                        config.DescribeAllEnumsAsStrings();
                    })
                .EnableSwaggerUi(uiConfig =>
                    {
                        uiConfig.InjectStylesheet(thisAssembly, $"ProductPriceApi.theme.css");
                    });
        }
    }
}
