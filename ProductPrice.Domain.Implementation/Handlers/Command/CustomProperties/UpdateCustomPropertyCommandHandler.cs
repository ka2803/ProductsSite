using System;
using System.Data.Entity;
using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands.CustomProperties;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command.CustomProperties
{
    public class UpdateCustomPropertyCommandHandler : DatabaseCommandHandlerBase<UpdateCustomPropertyCommand>
    {
        public UpdateCustomPropertyCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(UpdateCustomPropertyCommand context)
        {
            var customProperty = await DbContext.CustomProperties.FirstOrDefaultAsync(c => c.Id == context.Id);

            if (customProperty == null)
            {
                throw new NotImplementedException();
            }

            customProperty.Name = context.Name ?? customProperty.Name;
            customProperty.Value = context.Value ?? customProperty.Value;

            await DbContext.SaveChangesAsync();
        }
    }
}