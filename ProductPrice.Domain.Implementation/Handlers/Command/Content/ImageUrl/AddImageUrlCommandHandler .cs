using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands.Content.Image;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command.Content.ImageUrl
{
    public class AddImageUrlCommandHandler : DatabaseCommandHandlerBase<AddImageUrlCommand>
    {
        public AddImageUrlCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(AddImageUrlCommand context)
        {
            DbContext.ImageUrls.Add(new Database.Entities.Content.ImageUrl
            {
                Key = context.Key,
                Category = context.Category,
                Value = context.Value
            });
            await DbContext.SaveChangesAsync();
        }
    }
}