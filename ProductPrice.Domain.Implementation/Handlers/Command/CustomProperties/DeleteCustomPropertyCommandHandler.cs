using System;
using System.Data.Entity;
using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands.CustomProperties;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command.CustomProperties
{
    public class DeleteCustomPropertyCommandHandler : DatabaseCommandHandlerBase<DeleteCustomPropertyCommand>
    {
        public DeleteCustomPropertyCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(DeleteCustomPropertyCommand context)
        {
            var customProperty = await DbContext.CustomProperties.FirstOrDefaultAsync(c=>c.Id == context.Id);

            if (customProperty == null)
            {
                throw new NotImplementedException();
            }

            DbContext.CustomProperties.Remove(customProperty);

            await DbContext.SaveChangesAsync();
        }
    }
}