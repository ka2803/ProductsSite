using System.Threading.Tasks;
using System.Web.Http;
using ProductPrice.Abstractions.Contracts.Commands.CustomProperties;
using ProductPrice.Abstractions.Contracts.Queries;
using ProductPrice.Abstractions.CQRS.Buses;
using ProductPriceApi.Attributes;
using ProductPriceApi.Controllers.Base;

namespace ProductPriceApi.Controllers.Public
{
    [ControllerName("Public.Products")]
    [RoutePrefix("api/public/products")]
    public class PublicProductsController : BaseController
    {
        public PublicProductsController(IQueryBus queryBus, ICommandBus commandBus) : base(queryBus, commandBus)
        {
        }

        [HttpGet]
        [Route]
        public async Task<ProductsWithPricesResponse> GetProducts(int page = 0, int itemsPerPage = 10)
        {
            var productsWithPricesQuery = new ProductsWithPricesQuery
            {
                ItemsOnPage = itemsPerPage,
                Page = page
            };

            return await QueryBus.Execute<ProductsWithPricesQuery, ProductsWithPricesResponse>(productsWithPricesQuery);
        }
    }
}