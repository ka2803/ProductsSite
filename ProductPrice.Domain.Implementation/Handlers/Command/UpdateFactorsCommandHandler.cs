using System;
using System.Data.Entity;
using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Entities;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command
{
    public class UpdateFactorsCommandHandler : DatabaseCommandHandlerBase<UpdateAdditionalFactorsCommand>
    {
        public UpdateFactorsCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(UpdateAdditionalFactorsCommand context)
        {
            if (context.Box != null)
            {
                var box = await DbContext.Boxes.FirstOrDefaultAsync(boxing => boxing.Id == context.Box.Id);

                if (box == null)
                {
                    ThrowNullExcepton();
                }

                box.Price = context.Box.Price ?? box.Price;
                box.Material = context.Box.Material ?? box.Material;
                box.SizeType = context.Box.SizeType ?? box.SizeType;
            }

            if (context.EnvironmentForPrice != null)
            {
                var environment =
                    await DbContext.Environments.FirstOrDefaultAsync(env => env.Id == context.EnvironmentForPrice.Id);

                if (environment == null)
                {
                    ThrowNullExcepton();
                }

                environment.TotalAmortization =
                    context.EnvironmentForPrice.TotalAmortization ?? environment.TotalAmortization;
                environment.TotalElectricity =
                    context.EnvironmentForPrice.TotalElectricity ?? environment.TotalElectricity;
                environment.TotalSalary =
                    context.EnvironmentForPrice.TotalSalary ?? environment.TotalSalary;
            }

            if (context.Logistic != null)
            {
                var shipping = await DbContext.Shippings.FirstOrDefaultAsync(ship => ship.Id == context.Logistic.Id);
                if (shipping == null)
                {
                    ThrowNullExcepton();
                }

                shipping.Price = context.Logistic.Price ?? shipping.Price;
                shipping.PathLength = context.Logistic.PathLength ?? shipping.PathLength;
            }

            if (context.TaxForPrice != null)
            {
                var tax = await DbContext.Taxes.FirstOrDefaultAsync(taxs => taxs.Id == context.TaxForPrice.Id);
                if (tax == null)
                {
                    ThrowNullExcepton();
                }

                tax.Value = context.TaxForPrice.Value ?? tax.Value;
                tax.Title = context.TaxForPrice.Title ?? tax.Title;
            }


            await DbContext.SaveChangesAsync();
        }

        private void ThrowNullExcepton()
        {
            throw new InvalidOperationException("Entity not found");
        }
    }
}