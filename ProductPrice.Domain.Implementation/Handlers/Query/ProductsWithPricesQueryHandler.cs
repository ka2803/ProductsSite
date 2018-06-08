using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductPrice.Abstractions.Contracts.Queries;
using ProductPrice.Abstractions.Contracts.Queries.Calculations;
using ProductPrice.Abstractions.CQRS.Buses;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Query
{
    public class
        ProductsWithPricesQueryHandler : DatabaseQueryHandlerBase<ProductsWithPricesQuery, ProductsWithPricesResponse>
    {
        private readonly IQueryBus _queryBus;

        public ProductsWithPricesQueryHandler(IProductPriceContext dbContext, IQueryBus queryBus) : base(dbContext)
        {
            _queryBus = queryBus;
        }

        public override async Task<ProductsWithPricesResponse> Execute(ProductsWithPricesQuery query)
        {
            var products = await DbContext.Products
                .Include(product => product.CustomProperties)
                .OrderBy(product => product.Title)
                .Skip(query.ItemsOnPage * query.Page)
                .Take(query.ItemsOnPage)
                .ToListAsync();
            var count = await DbContext.Products.CountAsync();
            var calculatedPriceRangeResponse =
                await _queryBus.Execute<GetCalculatedPriceRangeQuery, CalculatedPriceRangeResponse>(
                    new GetCalculatedPriceRangeQuery
                    {
                        Ids = products.Select(product => product.Id).ToList()
                    });

            return new ProductsWithPricesResponse
            {
                Products = products.Select(product => new ProductsWithPricesResponse.Product
                {
                    Id = product.Id,
                    Name = product.Title,
                    Price = calculatedPriceRangeResponse.Prices[product.Id],
                    Description = product.Description,
                    CustomProperties = product.CustomProperties == null
                        ? null
                        : JToken.FromObject(
                            product.CustomProperties.Where(property => property.ParentPropetyId == null),
                            JsonSerializer.CreateDefault(new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                            }))
                }).ToList(),
                TotalPages = (int) Math.Round((double) (count / query.ItemsOnPage))
            };
        }
    }
}