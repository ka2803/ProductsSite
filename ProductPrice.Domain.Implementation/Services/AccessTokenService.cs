using System;
using System.Text;
using Jose;
using Newtonsoft.Json.Linq;
using ProductPrice.Abstractions.Configuration;
using ProductPrice.Abstractions.Exceptions.Authorization;
using ProductPrice.Abstractions.Services.Security.AccessToken;

namespace ProductPrice.Domain.Implementation.Services
{
    internal class AccessTokenService : IAccessTokenService
    {
        private readonly IAccessTokenConfiguration _configuration;
        private readonly IJsonMapper _jsonMapper;

        public AccessTokenService(IAccessTokenConfiguration configuration, IJsonMapper jsonMapper)
        {
            _configuration = configuration;
            _jsonMapper = jsonMapper;
        }

        public TPayload GetPayload<TPayload>(string accessToken) where TPayload : Payload
        {
            try
            {
                var payload = JWT.Payload<TPayload>(accessToken);

                if (payload.CreationTime.AddTicks(payload.Lifetime.Ticks) < DateTime.UtcNow)
                {
                    throw new AccessTokenExpiredException();
                }

                if (payload.Lifetime != _configuration.Lifetime)
                {
                    throw new AccessTokenExpiredException();
                }

                return payload;
            }
            catch (Exception e)
            {
                throw new AccessTokenVerificationException(e);
            }
        }

        public void Verify(string accessToken, string key)
        {
            try
            {
                var uniqueKey = key + _configuration.SecretKey;

                JWT.Decode(accessToken, Encoding.Unicode.GetBytes(uniqueKey));
            }
            catch (Exception e)
            {
                throw new AccessTokenVerificationException(e);
            }
        }

        public string Create<TPayload>(TPayload payload, string key) where TPayload : Payload
        {
            var payloadJsonObject = JObject.FromObject(payload);

            payloadJsonObject["CreationTime"] = DateTime.UtcNow;
            payloadJsonObject["Lifetime"] = _configuration.Lifetime;

            var uniqueKey = key + _configuration.SecretKey;

            var registerMapper = JWT.DefaultSettings.RegisterMapper(_jsonMapper);

            var token = JWT.Encode(payloadJsonObject, Encoding.Unicode.GetBytes(uniqueKey), JwsAlgorithm.HS512,
                settings: registerMapper);

            return token;
        }
    }
}