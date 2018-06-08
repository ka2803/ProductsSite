using System;
using System.Text;
using Jose;
using ProductPrice.Abstractions.Services;
using ProductPrice.Abstractions.Services.Security;

namespace ProductPrice.Domain.Implementation.Services
{
    public class ExpirableTokenGenerationService : IExpirableTokenGenerationService
    {
        public string GenerateToken(DateTime expirationDate)
        {
            var token = JWT.Encode(expirationDate, Encoding.UTF8.GetBytes("key"), JwsAlgorithm.HS512);
            return token;
        }

        public void ValidateToken(string token)
        {
            var dateTime = JWT.Decode<DateTime>(token, Encoding.UTF8.GetBytes("key"),
                JwsAlgorithm.HS512);
            if (dateTime.ToUniversalTime() < DateTime.UtcNow)
            {
                throw new InvalidOperationException("Token Expired");
            }
        }
    }
}