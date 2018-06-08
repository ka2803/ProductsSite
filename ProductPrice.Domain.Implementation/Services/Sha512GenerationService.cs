using System;
using System.Security.Cryptography;
using System.Text;
using ProductPrice.Abstractions.Services;
using ProductPrice.Abstractions.Services.Security;

namespace ProductPrice.Domain.Implementation.Services
{
    public class Sha512Service : ISha512Service
    {
        public string Calculate(string str)
        {
            using (var serviceProvider = new SHA512CryptoServiceProvider())
            {
                var bytes = Encoding.UTF8.GetBytes(str);

                var computeHash = serviceProvider.ComputeHash(bytes);

                var base64String = Convert.ToBase64String(computeHash);

                return base64String;
            }
        }
    }
}