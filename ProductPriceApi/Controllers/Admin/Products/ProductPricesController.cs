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
    [ControllerName("Admin.ProductPrices")]
    [RoutePrefix("api/admin/prices")]
    public class ProductPricesController : SecureController
    {
        public ProductPricesController(IQueryBus queryBus, ICommandBus commandBus,
            IAccessTokenService accessTokenService) : base(queryBus, commandBus,
            accessTokenService)
        {
        }

        [HttpPost]
        [Route]
        public async Task Create(AddPriceCommand command)
        {
            await CommandBus.Execute(command);
        }
        [HttpGet]
        [Route]
        public async Task<AllPricesResponse> Get()
        {
            return await QueryBus.Execute<GetAllPricesQuery, AllPricesResponse>(new GetAllPricesQuery());
        }
        [HttpDelete]
        [Route]
        public async Task Delete(DeletePriceCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpPut]
        [Route]
        public async Task Update(UpdatePriceCommand command)
        {
            await CommandBus.Execute(command);
        }
    }
}