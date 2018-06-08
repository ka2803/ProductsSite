using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command
{
    public class AddProductPriceCommandHandler : DatabaseCommandHandlerBase<AddPriceCommand>
    {
        public AddProductPriceCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(AddPriceCommand context)
        {
            var taxes = await DbContext.Taxes
                .Where(tax => context.TaxesIds.Contains(tax.Id))
                .ToListAsync();
            DbContext.ProductPrices.Add(new Database.Entities.ProductPrice
            {
                StartPrice = context.StartPrice,
                BoxingId = context.BoxingId,
                EnvironmentId = context.EnvironmentId,
                ShippingId = context.ShippingId,
                Taxes = taxes
            });

            await DbContext.SaveChangesAsync();
        }
    }
}