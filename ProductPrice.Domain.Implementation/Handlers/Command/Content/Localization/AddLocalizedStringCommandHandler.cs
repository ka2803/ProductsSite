using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands.Content.Localization;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Entities.Content;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command.Content.Localization
{
    public class AddLocalizedStringCommandHandler : DatabaseCommandHandlerBase<AddLocalizedStringCommand>
    {
        public AddLocalizedStringCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(AddLocalizedStringCommand context)
        {
            DbContext.LocalizedStrings.Add(new LocalizedString
            {
                Key = context.Key,
                Culture = context.Culture,
                Category = context.Category,
                Value = context.Value
            });
            await DbContext.SaveChangesAsync();
        }
    }
}