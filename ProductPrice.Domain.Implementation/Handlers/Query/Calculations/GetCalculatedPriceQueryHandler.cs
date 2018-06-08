using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ProductPrice.Abstractions.Contracts.Queries;
using ProductPrice.Abstractions.Contracts.Queries.Calculations;
using ProductPrice.Domain.Database.Context;

namespace ProductPrice.Domain.Implementation.Handlers.Query.Calculations
{
    internal class GetCalculatedPriceQueryHandler : SqlQueryHandlerBase<GetCalculatedPriceQuery, CalculatedPriceResponse>
    {
        public GetCalculatedPriceQueryHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        protected override async Task<SqlMapper.GridReader> CallSqlScript(GetCalculatedPriceQuery query)
        {
            var gridReader = await DbContext.Connection.QueryMultipleAsync(
                    "SELECT dbo.PriceByProductId(@ProductId) As Result", new
                    {
                        query.ProductId
                    },
                    commandType: CommandType.Text);

            return gridReader;
        }

        protected override async Task<CalculatedPriceResponse> ProcessSqlResponse(GetCalculatedPriceQuery query, SqlMapper.GridReader gridReader)
        {
            using (gridReader)
            {
                var prices = await gridReader.ReadAsync<decimal>();

                return new CalculatedPriceResponse
                {
                    Price = prices.FirstOrDefault()
                };
            }
        }
    }
}