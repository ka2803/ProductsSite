using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Entities;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command
{
    public class CreateProductCommandHandler : DatabaseCommandHandlerBase<CreateProductCommand>
    {
        public CreateProductCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(CreateProductCommand context)
        {
            DbContext.Products.Add(new Product
            {
                ProductPriceId = context.ProductPriceId,
                Title = context.Title,
                Description = context.Description
            });
            await DbContext.SaveChangesAsync();
        }
    }
}