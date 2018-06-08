using System.Globalization;
using System.Threading.Tasks;
using System.Web.Http;
using ProductPrice.Abstractions.Contracts.Queries.Content;
using ProductPrice.Abstractions.CQRS.Buses;
using ProductPriceApi.Attributes;
using ProductPriceApi.Controllers.Base;

namespace ProductPriceApi.Controllers.Public
{
    [ControllerName("Public.Content")]
    [RoutePrefix("api/public/content")]
    public class PublicContentController : BaseController
    {
        public PublicContentController(IQueryBus queryBus, ICommandBus commandBus) : base(queryBus, commandBus)
        {
        }

        [HttpGet]
        [Route("localization")]
        public async Task<LocalizedValuesResponse> GetLocalization([FromUri] LocalizedValuesQuery query)
        {
            return await QueryBus.Execute<LocalizedValuesQuery, LocalizedValuesResponse>(query);
        }

        [Route("content")]
        [HttpGet]
        public async Task<LocalizationObjectResponse> GetLocalizationObject(CultureInfo culture, string category = null)
        {
            return await QueryBus.Execute<LocalizationObjectQuery, LocalizationObjectResponse>(new LocalizationObjectQuery
                {
                    Culture = culture,
                    Category = category
                });
        }
    }
}