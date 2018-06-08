using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands.Content.Localization;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Entities.Content;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command.Content.Localization
{
    public class AddOrUpdateLocalizedStringsCommandHandler : DatabaseCommandHandlerBase<AddOrUpdateLocalizedStringsCommand>
    {
        public AddOrUpdateLocalizedStringsCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(AddOrUpdateLocalizedStringsCommand context)
        {
            DbContext.LocalizedStrings.AddOrUpdate(
                context.AddLocalizedStringCommands.Select(command => new LocalizedString
                {
                    Key = command.Key,
                    IsoLanguageName = command.Culture.TwoLetterISOLanguageName,
                    Category = command.Category,
                    Value = command.Value
                }).ToArray());
            await DbContext.SaveChangesAsync();
        }
    }
}