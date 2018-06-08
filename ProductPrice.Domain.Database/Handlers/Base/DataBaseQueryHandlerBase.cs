using System.Threading.Tasks;
using ProductPrice.Abstractions.CQRS;
using ProductPrice.Abstractions.CQRS.Handlers;
using ProductPrice.Domain.Database.Context;

namespace ProductPrice.Domain.Database.Handlers.Base
{
    public abstract class DatabaseQueryHandlerBase<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TResult : IQueryResult
        where TQuery : IQuery<TResult>
    {
        protected readonly IProductPriceContext DbContext;

        protected DatabaseQueryHandlerBase(IProductPriceContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract Task<TResult> Execute(TQuery query);
    }
}