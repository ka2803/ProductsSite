using System.Data.Entity;
using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands.Content.Image;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command.Content.ImageUrl
{
    public class RemoveImageUrlCommandHandler : DatabaseCommandHandlerBase<RemoveImageUrlCommand>
    {
        public RemoveImageUrlCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(RemoveImageUrlCommand context)
        {
            var localizedString = await DbContext.ImageUrls.FirstOrDefaultAsync(s => s.Key == context.Key);

            DbContext.ImageUrls.Remove(localizedString);
            await DbContext.SaveChangesAsync();
        }
    }
}