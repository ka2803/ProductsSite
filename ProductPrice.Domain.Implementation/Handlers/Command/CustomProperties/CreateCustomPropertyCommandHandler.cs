using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ProductPrice.Abstractions.Contracts.Commands.CustomProperties;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Entities;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command.CustomProperties
{
    public class CreateCustomPropertyCommandHandler : DatabaseCommandHandlerBase<CreateCustomPropertyCommand>
    {
        public CreateCustomPropertyCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(CreateCustomPropertyCommand context)
        {
            var customProperties = new List<CustomProperty>();
            foreach (var property in context.CustomProperties)
            {
                GetNextProperty(context.ProductId, customProperties, property);
            }

            DbContext.AddRange(customProperties);
            await DbContext.SaveChangesAsync();
        }

        private void GetNextProperty(Guid productId, ICollection<CustomProperty> customProperties,
            CreateCustomPropertyCommand.CustomProperty currentProperty, CustomProperty parentProperty = null)
        {
            var customProperty = new CustomProperty
            {
                Value = currentProperty.Value,
                Name = currentProperty.Name,
                ProductId = productId,
                ParentProperty = parentProperty
            };

            customProperties.Add(customProperty);

            if (currentProperty.ChildProperties == null || !currentProperty.ChildProperties.Any()) return;

            foreach (var property in currentProperty.ChildProperties)
            {
                GetNextProperty(productId, customProperties, property, customProperty);
            }
        }
    }
}