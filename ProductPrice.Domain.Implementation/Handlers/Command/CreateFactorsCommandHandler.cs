using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Entities;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command
{
    public class CreateFactorsCommandHandler : DatabaseCommandHandlerBase<CreateAdditionalFactorsCommand>
    {
        public CreateFactorsCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(CreateAdditionalFactorsCommand context)
        {
            if (context.Box != null)
            {
                DbContext.Boxes.Add(new Boxing
                {
                    Material = context.Box.Material,
                    SizeType = context.Box.SizeType,
                    Price = context.Box.Price
                });
            }
            if (context.EnvironmentForPrice != null)
            {
                DbContext.Environments.Add(new Environment
                {
                    TotalAmortization = context.EnvironmentForPrice.TotalAmortization,
                    TotalElectricity = context.EnvironmentForPrice.TotalElectricity,
                    TotalSalary = context.EnvironmentForPrice.TotalSalary
                });
            }
            if (context.Logistic != null)
            {
                DbContext.Shippings.Add(new Shipping
                {
                    Price = context.Logistic.Price,
                    PathLength = context.Logistic.PathLength
                });
            }
            if (context.TaxForPrice != null)
            {
                DbContext.Taxes.Add(new Tax
                {
                    Title = context.TaxForPrice.Title,
                    Value = context.TaxForPrice.Value
                });
            }

            await DbContext.SaveChangesAsync();
        }
    }
}