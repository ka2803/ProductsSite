using System.Threading.Tasks;
using System.Web.Http;
using ProductPrice.Abstractions.Contracts.Commands;
using ProductPrice.Abstractions.Contracts.Queries;
using ProductPrice.Abstractions.CQRS.Buses;
using ProductPrice.Abstractions.Services.Security.AccessToken;
using ProductPriceApi.Attributes;
using ProductPriceApi.Controllers.Base;

namespace ProductPriceApi.Controllers.Admin.Products
{
    [ControllerName("Admin.Products")]
    [RoutePrefix("api/admin/products")]
    public class ProductsController : SecureController
    {
        public ProductsController(IQueryBus queryBus, ICommandBus commandBus,
            IAccessTokenService accessTokenService) : base(queryBus, commandBus,
            accessTokenService)
        {
        }

        [HttpGet]
        [Route]
        public async Task<AllProductsResponse> Get()
        {
            var products = await QueryBus.Execute<GetAllProductsQuery, AllProductsResponse>(new GetAllProductsQuery());
            return products;
        }
        [HttpPost]
        [Route]
        public async Task Create(CreateProductCommand command)
        {
            await CommandBus.Execute(command);
        }
        [HttpDelete]
        [Route]
        public async Task Delete(DeleteProductCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpPut]
        [Route]
        public async Task Update(UpdateProductCommand command)
        {
            await CommandBus.Execute(command);
        }
    }
}