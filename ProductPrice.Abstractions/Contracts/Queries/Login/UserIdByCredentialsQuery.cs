using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Queries.Login
{
    public class UserIdByCredentialsQuery : IQuery<UserIdByCredentialsResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}