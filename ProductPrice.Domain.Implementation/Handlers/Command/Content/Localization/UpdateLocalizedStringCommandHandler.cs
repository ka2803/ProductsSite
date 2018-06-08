using System.Data.Entity;
using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands.Content.Localization;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Entities.Content;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command.Content.Localization
{
    public class UpdateLocalizedStringCommandHandler : DatabaseCommandHandlerBase<UpdateLocalizedStringCommand>
    {
        public UpdateLocalizedStringCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(UpdateLocalizedStringCommand context)
        {
            var localizedString =
                await DbContext.LocalizedStrings.FirstOrDefaultAsync(s =>
                    s.Key == context.Key && s.IsoLanguageName == context.Culture.TwoLetterISOLanguageName);

            if (localizedString != null)
            {
                localizedString.Category = context.Category;
                localizedString.Value = context.Value;
            }

            await DbContext.SaveChangesAsync();
        }
    }
}