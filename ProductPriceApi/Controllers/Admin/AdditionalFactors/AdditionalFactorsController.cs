using System.Threading.Tasks;
using System.Web.Http;
using ProductPrice.Abstractions.Contracts.Commands;
using ProductPrice.Abstractions.Contracts.Queries;
using ProductPrice.Abstractions.CQRS.Buses;
using ProductPrice.Abstractions.Services.Security.AccessToken;
using ProductPriceApi.Attributes;
using ProductPriceApi.Controllers.Base;

namespace ProductPriceApi.Controllers.Admin.AdditionalFactors
{
    [RoutePrefix("api/admin/additional-factors")]
    [ControllerName("Admin.AdditionalFactors")]
    public class AdditionalFactorsController : SecureController
    {
        public AdditionalFactorsController(IQueryBus queryBus, ICommandBus commandBus, IAccessTokenService tokenGenerationService) : base(queryBus, commandBus, tokenGenerationService)
        {
        }

        [HttpPost]
        [Route]
        public async Task Create(CreateAdditionalFactorsCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpGet]
        [Route("taxes")]
        public async Task<TaxesResponse> GetTaxes()
        {
           return await QueryBus.Execute<TaxesQuery, TaxesResponse>(new TaxesQuery());
        }

        [HttpGet]
        [Route("boxings")]
        public async Task<BoxingsResponse> GetBoxings()
        {
            return await QueryBus.Execute<BoxingsQuery, BoxingsResponse>(new BoxingsQuery());
        }


        [HttpGet]
        [Route("shippings")]
        public async Task<ShippingsResponse> GetShippings()
        {
            return await QueryBus.Execute<ShippingsQuery, ShippingsResponse>(new ShippingsQuery());
        }

        [HttpGet]
        [Route("environments")]
        public async Task<EnvironmentsResponse> GetEnvironments()
        {
            return await QueryBus.Execute<EnvironmentsQuery, EnvironmentsResponse>(new EnvironmentsQuery());
        }

        [HttpDelete]
        [Route]
        public async Task Delete([FromUri] DeleteAdditionalFactorsCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpPut]
        [Route]
        public async Task Update(UpdateAdditionalFactorsCommand command)
        {
            await CommandBus.Execute(command);
        }
    }
}