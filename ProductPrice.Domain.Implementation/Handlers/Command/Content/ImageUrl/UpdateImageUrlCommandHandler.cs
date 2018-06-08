using System;
using System.Data.Entity;
using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands.Content.Image;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command.Content.ImageUrl
{
    public class UpdateImageUrlCommandHandler : DatabaseCommandHandlerBase<UpdateImageUrlCommand>
    {
        public UpdateImageUrlCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(UpdateImageUrlCommand context)
        {
            var localizedString =
                await DbContext.ImageUrls.FirstOrDefaultAsync(s => s.Key == context.Key);

            if (localizedString == null)
            {
                throw new NotImplementedException();
            }

            localizedString.Category = context.Category;
            localizedString.Value = context.Value;

            await DbContext.SaveChangesAsync();
        }
    }
}