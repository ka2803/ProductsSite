using System.Data.Entity;
using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands.Content.Color;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command.Content.Color
{
    public class UpdateColorCommandHandler : DatabaseCommandHandlerBase<UpdateColorCommand>
    {
        public UpdateColorCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(UpdateColorCommand context)
        {
            var localizedString =
                await DbContext.Colors.FirstOrDefaultAsync(s => s.Key == context.Key);

            if (localizedString != null)
            {
                localizedString.Category = context.Category;
                localizedString.Value = context.Value;
            }

            await DbContext.SaveChangesAsync();
        }
    }
}