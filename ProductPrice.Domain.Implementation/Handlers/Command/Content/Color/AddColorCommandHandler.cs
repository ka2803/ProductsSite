using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands.Content.Color;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command.Content.Color
{
    public class AddColorCommandHandler : DatabaseCommandHandlerBase<AddColorCommand>
    {
        public AddColorCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(AddColorCommand context)
        {
            DbContext.Colors.Add(new Database.Entities.Content.Color
            {
                Key = context.Key,
                Category = context.Category,
                Value = context.Value
            });
            await DbContext.SaveChangesAsync();
        }
    }
}