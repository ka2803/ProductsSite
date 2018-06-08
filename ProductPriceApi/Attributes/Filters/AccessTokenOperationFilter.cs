using System.Collections.Generic;
using System.Web.Http.Description;
using ProductPriceApi.Controllers.Base;
using Swashbuckle.Swagger;

namespace ProductPriceApi.Attributes.Filters
{
    public class AccessTokenHeaderOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var controllerType =
                apiDescription.ActionDescriptor.ControllerDescriptor.ControllerType;

            if (!typeof(SecureController).IsAssignableFrom(controllerType))
            {
                return;
            }

            var attributeDescription = "Access token";
            operation.parameters = operation.parameters ?? new List<Parameter>();
            operation.parameters.Add(new Parameter
            {
                name = "AccessToken",
                @in = "header",
                description = attributeDescription,
                required = true,
                type = "string"
            });
        }
    }
}