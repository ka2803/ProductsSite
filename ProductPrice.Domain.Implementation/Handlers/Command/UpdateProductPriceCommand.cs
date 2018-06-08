using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command
{
    public class UpdateProductPriceCommandHandler : DatabaseCommandHandlerBase<UpdatePriceCommand>
    {
        public UpdateProductPriceCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(UpdatePriceCommand context)
        {
            var entityToUpdate = await DbContext.ProductPrices
                .Include(price => price.Taxes)
                .FirstOrDefaultAsync(price => price.Id == context.Id);

            if (entityToUpdate == null)
            {
                throw new InvalidOperationException("Entity not found");
            }

            entityToUpdate.StartPrice = context.StartPrice ?? entityToUpdate.StartPrice;
            entityToUpdate.EnvironmentId = context.EnvironmentId ?? entityToUpdate.EnvironmentId;
            entityToUpdate.BoxingId = context.BoxingId ?? entityToUpdate.BoxingId;
            entityToUpdate.ShippingId = context.ShippingId ?? entityToUpdate.ShippingId;
            entityToUpdate.Taxes = context.TaxesIds == null
                ? entityToUpdate.Taxes
                : await DbContext.Taxes.Where(tax => context.TaxesIds.Contains(tax.Id)).ToListAsync();

            await DbContext.SaveChangesAsync();
        }
    }
}