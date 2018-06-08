using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using ProductPrice.Abstractions.Contracts.Queries.Calculations;
using ProductPrice.Abstractions.CQRS.Buses;
using ProductPrice.Abstractions.Services.Security.AccessToken;
using ProductPriceApi.Attributes;
using ProductPriceApi.Controllers.Base;

namespace ProductPriceApi.Controllers.Admin
{
    [ControllerName("Admin.Calculation")]
    [RoutePrefix("api/admin/calculate-price")]
    public class CalculatorController : SecureController
    {
        public CalculatorController(IQueryBus queryBus, ICommandBus commandBus,
            IAccessTokenService tokenGenerationService) : base(queryBus, commandBus,
            tokenGenerationService)
        {
        }

        [Route]
        [HttpGet]
        public async Task<CalculatedPriceResponse> Get(Guid productId)
        {
            return await QueryBus.Execute<GetCalculatedPriceQuery, CalculatedPriceResponse>(new GetCalculatedPriceQuery
            {
                ProductId = productId
            });
        }

        [Route("range")]
        [HttpGet]
        public async Task<CalculatedPriceRangeResponse> Get([FromUri] GetCalculatedPriceRangeQuery query)
        {
            return await QueryBus.Execute<GetCalculatedPriceRangeQuery, CalculatedPriceRangeResponse>(query);
        }
    }
}