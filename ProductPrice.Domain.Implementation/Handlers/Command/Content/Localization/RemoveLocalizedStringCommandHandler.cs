using System.Data.Entity;
using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands.Content.Localization;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Entities.Content;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command.Content.Localization
{
    public class RemoveLocalizedStringCommandHandler : DatabaseCommandHandlerBase<RemoveLocalizedStringCommand>
    {
        public RemoveLocalizedStringCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(RemoveLocalizedStringCommand context)
        {
            var localizedString = await DbContext.LocalizedStrings.FirstOrDefaultAsync(
                str => str.Key == context.Key && str.IsoLanguageName == context.Culture.TwoLetterISOLanguageName);

            DbContext.LocalizedStrings.Remove(localizedString);

            await DbContext.SaveChangesAsync();
        }
    }
}