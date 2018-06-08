using System;
using System.Data.Entity;
using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command
{
    public class DeletePriceCommandHandler : DatabaseCommandHandlerBase<DeletePriceCommand>
    {
        public DeletePriceCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(DeletePriceCommand context)
        {
            var entity = await DbContext.ProductPrices.FirstOrDefaultAsync(price => price.Id == context.Id);
            if (entity == null)
            {
                throw new InvalidOperationException("Entity not found");
            }

            DbContext.ProductPrices.Remove(entity);

            await DbContext.SaveChangesAsync();
        }
    }
}