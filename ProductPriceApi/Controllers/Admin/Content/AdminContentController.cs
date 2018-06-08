using System.Globalization;
using System.Threading.Tasks;
using System.Web.Http;
using ProductPrice.Abstractions.Contracts.Commands.Content.Color;
using ProductPrice.Abstractions.Contracts.Commands.Content.Image;
using ProductPrice.Abstractions.Contracts.Commands.Content.Localization;
using ProductPrice.Abstractions.Contracts.Queries.Content;
using ProductPrice.Abstractions.CQRS.Buses;
using ProductPrice.Abstractions.Services.Security.AccessToken;
using ProductPriceApi.Attributes;
using ProductPriceApi.Controllers.Base;

namespace ProductPriceApi.Controllers.Admin.Content
{
    [ControllerName("Admin.Content")]
    [RoutePrefix("api/admin/content")]
    public class AdminContentController : SecureController
    {
        [Route("localization")]
        [HttpGet]
        public async Task<LocalizationObjectResponse> GetLocalizationObject(CultureInfo culture, string category = null)
        {
            return
                await QueryBus.Execute<LocalizationObjectQuery, LocalizationObjectResponse>(new LocalizationObjectQuery
                {
                    Culture = culture,
                    Category = category
                });
        }

        [Route("localization")]
        [HttpPost]
        public async Task AddLocalizedString(AddLocalizedStringCommand localizedString)
        {
            await CommandBus.Execute(localizedString);
        }

        [Route("localization/many")]
        [HttpPost]
        public async Task AddOrUpdateLocalizedStrings(AddOrUpdateLocalizedStringsCommand localizedString)
        {
            await CommandBus.Execute(localizedString);
        }

        [Route("localization")]
        [HttpDelete]
        public async Task DeleteLocalizedString(CultureInfo culture, string key)
        {
            await CommandBus.Execute(new RemoveLocalizedStringCommand
            {
                Culture = culture,
                Key = key
            });
        }

        [Route("localization")]
        [HttpPut]
        public async Task UpdateLocalizedString(UpdateLocalizedStringCommand command)
        {
            await CommandBus.Execute(command);
        }

        [Route("image")]
        [HttpPost]
        public async Task AddImage(AddImageUrlCommand localizedString)
        {
            await CommandBus.Execute(localizedString);
        }

        [Route("image")]
        [HttpDelete]
        public async Task DeleteImage(string key)
        {
            await CommandBus.Execute(new RemoveImageUrlCommand
            {
                Key = key
            });
        }

        [Route("image")]
        [HttpPut]
        public async Task UpdateImage(UpdateImageUrlCommand command)
        {
            await CommandBus.Execute(command);
        }

        [Route("color")]
        [HttpPost]
        public async Task AddColor(AddColorCommand localizedString)
        {
            await CommandBus.Execute(localizedString);
        }

        [Route("color")]
        [HttpDelete]
        public async Task DeleteColor(string key)
        {
            await CommandBus.Execute(new RemoveColorCommand
            {
                Key = key
            });
        }

        [Route("color")]
        [HttpPut]
        public async Task UpdateColor(UpdateColorCommand command)
        {
            await CommandBus.Execute(command);
        }

        public AdminContentController(IQueryBus queryBus, ICommandBus commandBus, IAccessTokenService accessTokenService) : base(queryBus, commandBus, accessTokenService)
        {
        }
    }
}