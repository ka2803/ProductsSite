using System;

namespace ProductPrice.Abstractions.Configuration
{
    public interface IAccessTokenConfiguration
    {
        string SecretKey { get; }
        TimeSpan Lifetime { get; }
    }
}