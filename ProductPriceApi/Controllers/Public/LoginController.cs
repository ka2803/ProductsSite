using System;
using System.Threading.Tasks;
using System.Web.Http;
using ProductPrice.Abstractions.Contracts.Commands;
using ProductPrice.Abstractions.Contracts.Commands.Authorization;
using ProductPrice.Abstractions.Contracts.Queries.Authorization;
using ProductPrice.Abstractions.Contracts.Queries.Login;
using ProductPrice.Abstractions.CQRS.Buses;
using ProductPrice.Abstractions.Services;
using ProductPrice.Abstractions.Services.Security;
using ProductPrice.Abstractions.Services.Security.AccessToken;
using ProductPriceApi.Attributes;
using ProductPriceApi.AuthPayloads;
using ProductPriceApi.Controllers.Base;
using ProductPriceApi.Controllers.Models;

namespace ProductPriceApi.Controllers.Public
{
    [ControllerName("Public.Login")]
    [RoutePrefix("api/public/login")]
    public class LoginController : BaseController
    {
        private readonly IAccessTokenService _accessTokenService;
        private readonly ISha512Service _sha512Service;
        private readonly IRandomStringGenerationService _randomStringGenerationService;

        public LoginController(IQueryBus queryBus, ICommandBus commandBus, IAccessTokenService accessTokenService,
            ISha512Service sha512Service, IRandomStringGenerationService randomStringGenerationService) : base(queryBus,
            commandBus)
        {
            _accessTokenService = accessTokenService;
            _sha512Service = sha512Service;
            _randomStringGenerationService = randomStringGenerationService;
        }

        [HttpPost]
        [Route]
        public async Task<AccessTokenModel> LogIn(string email, string password)
        {
            var query = new UserIdByCredentialsQuery
            {
                Email = email,
                Password = _sha512Service.Calculate(password)
            };

            var userIdResponse = await QueryBus.Execute<UserIdByCredentialsQuery, UserIdByCredentialsResponse>(query);

            var accessToken = await GenerateRefreshAndAccessToken(userIdResponse.UserId);

            return accessToken;
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<AccessTokenModel> RefreshToken(string refreshToken, string accessToken)
        {
            var userId = _accessTokenService.GetPayload<AuthPayload>(accessToken).UserId;

            var refreshTokenResponse = await QueryBus.Execute<UserRefreshTokenQuery, UserRefreshTokenResponse>(
                new UserRefreshTokenQuery
                {
                    UserId = userId
                });

            if (refreshToken != refreshTokenResponse.RefreshToken)
            {
                //TODO
                throw new NotImplementedException();
            }

            return await GenerateRefreshAndAccessToken(userId);
        }


        private async Task<AccessTokenModel> GenerateRefreshAndAccessToken(Guid userId)
        {
            var refreshToken = _randomStringGenerationService.Generate(length: 128);

            var token = _accessTokenService.Create(new AuthPayload
                {
                    UserId = userId
                },
                refreshToken);

            await CommandBus.Execute(new SetRefreshTokenCommand
            {
                UserId = userId,
                RefreshToken = refreshToken
            });

            return new AccessTokenModel
            {
                RefreshToken = refreshToken,
                AccessToken = token
            };
        }


        [HttpPost]
        [Route("register")]
        public async Task Register(string email, string password)
        {
            var command = new RegisterNewUserCommand
            {
                Email = email,
                Password = _sha512Service.Calculate(password)
            };

            await CommandBus.Execute(command);
        }
    }
}