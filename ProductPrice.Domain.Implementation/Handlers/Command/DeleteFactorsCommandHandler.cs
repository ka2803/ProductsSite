using System;
using System.Data.Entity;
using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command
{
    public class DeleteFactorsCommandHandler : DatabaseCommandHandlerBase<DeleteAdditionalFactorsCommand>
    {
        public DeleteFactorsCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(DeleteAdditionalFactorsCommand context)
        {
            if (context.BoxingId != null)
            {
                var box = await DbContext.Boxes.FirstOrDefaultAsync(boxing => boxing.Id == context.BoxingId.Value);
                if (box == null)
                {
                    ThrowNullExcepton();;
                }

                DbContext.Boxes.Remove(box);
            }

            if (context.TaxId != null)
            {
                var tax = await DbContext.Taxes.FirstOrDefaultAsync(taxs => taxs.Id == context.TaxId.Value);
                if (tax == null)
                {
                    ThrowNullExcepton(); ;
                }

                DbContext.Taxes.Remove(tax);
            }

            if (context.EnvironmentId != null)
            {
                var environment = await DbContext.Environments.FirstOrDefaultAsync(env => env.Id == context.EnvironmentId.Value);
                if (environment == null)
                {
                    ThrowNullExcepton(); ;
                }

                DbContext.Environments.Remove(environment);
            }

            if (context.ShippingId != null)
            {
                var shipping = await DbContext.Shippings.FirstOrDefaultAsync(ship => ship.Id == context.ShippingId.Value);
                if (shipping == null)
                {
                    ThrowNullExcepton(); ;
                }

                DbContext.Shippings.Remove(shipping);
            }

            await DbContext.SaveChangesAsync();
        }

        private void ThrowNullExcepton()
        {
            throw new InvalidOperationException("Entity not found");
        }
    }
}