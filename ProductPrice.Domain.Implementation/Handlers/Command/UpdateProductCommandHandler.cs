using System;
using System.Data.Entity;
using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command
{
    public class UpdateProductCommandHandler : DatabaseCommandHandlerBase<UpdateProductCommand>
    {
        public UpdateProductCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(UpdateProductCommand context)
        {
            var product = await DbContext.Products.FirstOrDefaultAsync(producttoup => producttoup.Id == context.Id);

            if (product == null)
            {
                throw new InvalidOperationException("EntityNotFound");
            }

            product.Title = context.Title ?? product.Title;
            product.Description = context.Description ?? product.Description;
            product.ProductPriceId = context.ProductPriceId ?? product.ProductPriceId;

            await DbContext.SaveChangesAsync();
        }
    }
}