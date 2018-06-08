using System;
using System.Net;
using ProductPrice.Abstractions.Attributes;

namespace ProductPrice.Abstractions.Exceptions.Authorization
{
    [StatusCode(HttpStatusCode.Unauthorized)]
    public class UserNotAuthorizedException : ProductPriceExceptionBase
    {
        public Guid UserId { get; }

        public UserNotAuthorizedException(Guid userId)
        {
            UserId = userId;
        }
    }
}