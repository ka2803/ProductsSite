using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ProductPrice.Abstractions.Contracts.Queries.Calculations;
using ProductPrice.Domain.Database.Context;

namespace ProductPrice.Domain.Implementation.Handlers.Query.Calculations
{
    internal class
        GetCalculatedRangePriceQueryHandler : SqlQueryHandlerBase<GetCalculatedPriceRangeQuery,
            CalculatedPriceRangeResponse>
    {
        public GetCalculatedRangePriceQueryHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        protected override async Task<SqlMapper.GridReader> CallSqlScript(GetCalculatedPriceRangeQuery query)
        {
            var tbl = CreateTable(query);

            var gridReader = await DbContext.Connection.QueryMultipleAsync(
                "SELECT * FROM dbo.PriceForRange(@Products)", new
                {
                    Products = tbl.AsTableValuedParameter("dbo.ProductIdTable")
                }, commandType: CommandType.Text);

            return gridReader;
        }

        private static DataTable CreateTable(GetCalculatedPriceRangeQuery query)
        {
            var tbl = new DataTable();
            tbl.Columns.Add("ProductId", typeof(Guid));

            foreach (var id in query.Ids)
            {
                tbl.Rows.Add(id);
            }

            return tbl;
        }

        protected override async Task<CalculatedPriceRangeResponse> ProcessSqlResponse(
            GetCalculatedPriceRangeQuery query, SqlMapper.GridReader gridReader)
        {
            using (gridReader)
            {
                var prices = (await gridReader.ReadAsync<decimal>()).ToList();

                var dict = CreateResponse(query, prices);

                return new CalculatedPriceRangeResponse
                {
                    Prices = dict
                };
            }
        }

        private static Dictionary<Guid, decimal> CreateResponse(GetCalculatedPriceRangeQuery query,
            IReadOnlyList<decimal> prices)
        {
            var dict = new Dictionary<Guid, decimal>();
            var queryIds = query.Ids.ToList();
            for (var i = 0; i < queryIds.Count; i++)
            {
                dict[queryIds[i]] = prices[i];
            }

            return dict;
        }
    }
}