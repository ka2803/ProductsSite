using System;
using System.Data.Entity;
using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command
{
    public class DeleteProductCommandHandler : DatabaseCommandHandlerBase<DeleteProductCommand>
    {
        public DeleteProductCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(DeleteProductCommand context)
        {
            var product = await DbContext.Products.FirstOrDefaultAsync(producttodel => producttodel.Id == context.Id);

            if (product == null)
            {
                throw new InvalidOperationException("EntityNotFound");
            }

            DbContext.Products.Remove(product);
            await DbContext.SaveChangesAsync();
        }
    }
}