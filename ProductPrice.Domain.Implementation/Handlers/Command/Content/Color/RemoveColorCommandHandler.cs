using System.Data.Entity;
using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands.Content.Color;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command.Content.Color
{
    public class RemoveColorCommandHandler : DatabaseCommandHandlerBase<RemoveColorCommand>
    {
        public RemoveColorCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(RemoveColorCommand context)
        {
            var localizedString = await DbContext.Colors.FirstOrDefaultAsync(s => s.Key == context.Key);

            DbContext.Colors.Remove(localizedString);

            await DbContext.SaveChangesAsync();
        }
    }
}