using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Description;
using Swashbuckle.Swagger;
using Swashbuckle.Swagger.Annotations;

namespace ProductPriceApi.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ControllerNameAttribute : Attribute
    {
        public string Name { get; }

        public ControllerNameAttribute(string name)
        {
            Name = name;
        }
    }

    public class ControllerNameOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var controllerNameAttribute =
                apiDescription.GetControllerAndActionAttributes<ControllerNameAttribute>()
                    .FirstOrDefault();

            if (controllerNameAttribute == null)
            {
                return;
            }

            operation.tags = new List<string>()
            {
                controllerNameAttribute.Name
            };
        }
    }
}