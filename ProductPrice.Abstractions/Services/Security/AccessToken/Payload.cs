using System;

namespace ProductPrice.Abstractions.Services.Security.AccessToken
{
    public abstract class Payload
    {
        public Guid UserId { get; set; }
        public TimeSpan Lifetime { get; set; }
        public DateTime CreationTime { get; set; }
    }
}