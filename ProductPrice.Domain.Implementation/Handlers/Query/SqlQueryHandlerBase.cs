using System.Threading.Tasks;
using Dapper;
using ProductPrice.Abstractions.CQRS;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Query
{
    //Template Pattern
    public abstract class SqlQueryHandlerBase<TQuery, TResponse> : DatabaseQueryHandlerBase<TQuery, TResponse>
        where TResponse : IQueryResult 
        where TQuery : IQuery<TResponse>
    {
        protected SqlQueryHandlerBase(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task<TResponse> Execute(TQuery query)
        {
            var gridReader = await CallSqlScript(query);

            var response = await ProcessSqlResponse(query, gridReader);

            return response;
        }

        protected abstract Task<SqlMapper.GridReader> CallSqlScript(TQuery query);

        protected abstract Task<TResponse> ProcessSqlResponse(TQuery query, SqlMapper.GridReader gridReader);
    }
}