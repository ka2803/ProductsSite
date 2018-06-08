using System;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Queries.Authorization
{
    public class UserRefreshTokenQuery : IQuery<UserRefreshTokenResponse>
    {
        public Guid UserId { get; set; }
    }
}