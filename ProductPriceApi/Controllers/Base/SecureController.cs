using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using ProductPrice.Abstractions.Contracts.Queries.Authorization;
using ProductPrice.Abstractions.CQRS.Buses;
using ProductPrice.Abstractions.Exceptions.Authorization;
using ProductPrice.Abstractions.Services;
using ProductPrice.Abstractions.Services.Security;
using ProductPrice.Abstractions.Services.Security.AccessToken;
using ProductPriceApi.AuthPayloads;

namespace ProductPriceApi.Controllers.Base
{
    public abstract class SecureController : BaseController
    {
        private readonly IAccessTokenService _accessTokenService;

        protected SecureController(IQueryBus queryBus, ICommandBus commandBus, IAccessTokenService accessTokenService) : base(queryBus, commandBus)
        {
            _accessTokenService = accessTokenService;
        }

        public override async Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext,
            CancellationToken cancellationToken)
        {
            if (!controllerContext.Request.Headers.TryGetValues("AccessToken", out var allTokens))
            {
                throw new AuthorizationRequiredException();
            }

            var token = allTokens.First();

            var payload = _accessTokenService.GetPayload<AuthPayload>(token);

            var refreshTokenResponse =  await QueryBus.Execute<UserRefreshTokenQuery, UserRefreshTokenResponse>(
                new UserRefreshTokenQuery
                {
                    UserId = payload.UserId
                });

            _accessTokenService.Verify(token, refreshTokenResponse.RefreshToken);

            return await base.ExecuteAsync(controllerContext, cancellationToken);
        }
    }
}