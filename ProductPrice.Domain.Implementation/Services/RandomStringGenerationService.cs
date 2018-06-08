using System;
using System.Security.Cryptography;
using ProductPrice.Abstractions.Services;

namespace ProductPrice.Domain.Implementation.Services
{
    internal class RandomStringGenerationService : IRandomStringGenerationService
    {
        public string Generate(int length)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var bytes = new byte[length];

                rngCryptoServiceProvider.GetBytes(bytes);

                var fromBase64String = Convert.ToBase64String(bytes);

                return fromBase64String;
            }
        }
    }
}