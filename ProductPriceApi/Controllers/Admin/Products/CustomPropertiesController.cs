using System.Threading.Tasks;
using System.Web.Http;
using ProductPrice.Abstractions.Contracts.Commands.CustomProperties;
using ProductPrice.Abstractions.Contracts.Queries;
using ProductPrice.Abstractions.CQRS.Buses;
using ProductPrice.Abstractions.Services.Security.AccessToken;
using ProductPriceApi.Attributes;
using ProductPriceApi.Controllers.Base;

namespace ProductPriceApi.Controllers.Admin.Products
{
    [ControllerName("Admin.CustomProperties")]
    [RoutePrefix("api/admin/custom-properies")]
    public class CustomPropertiesController : SecureController
    {
        public CustomPropertiesController(IQueryBus queryBus, ICommandBus commandBus,
            IAccessTokenService accessTokenService) : base(queryBus, commandBus, accessTokenService)
        {
        }

        [HttpPost]
        [Route]
        public async Task Create(CreateCustomPropertyCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpPut]
        [Route]
        public async Task Update(UpdateCustomPropertyCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpDelete]
        [Route]
        public async Task Update([FromUri] DeleteCustomPropertyCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpGet]
        [Route]
        public async Task<CustomPropertiesResponse> GetProperties()
        {
            return await QueryBus.Execute<CustomPropertiesQuery, CustomPropertiesResponse>(new CustomPropertiesQuery());
        }
    }
}