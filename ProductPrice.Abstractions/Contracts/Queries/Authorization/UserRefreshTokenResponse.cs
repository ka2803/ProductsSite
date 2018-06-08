using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Queries.Authorization
{
    public class UserRefreshTokenResponse : IQueryResult
    {
        public string RefreshToken { get; set; }
    }
}