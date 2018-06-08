using System;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Queries.Login
{
    public class UserIdByCredentialsResponse : IQueryResult
    {
        public Guid UserId { get; set; }
    }
}