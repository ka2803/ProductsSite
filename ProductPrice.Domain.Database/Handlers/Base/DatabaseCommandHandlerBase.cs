using System.Threading.Tasks;
using ProductPrice.Abstractions.CQRS;
using ProductPrice.Abstractions.CQRS.Handlers;
using ProductPrice.Domain.Database.Context;

namespace ProductPrice.Domain.Database.Handlers.Base
{
    public abstract class DatabaseCommandHandlerBase<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        protected readonly IProductPriceContext DbContext;

        protected DatabaseCommandHandlerBase(IProductPriceContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract Task Execute(TCommand context);
    }
}