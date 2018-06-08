using System;

namespace ProductPrice.Abstractions.Services.Security
{
    public interface IExpirableTokenGenerationService
    {
        string GenerateToken(DateTime expirationDate);
        void ValidateToken(string token);
    }
}