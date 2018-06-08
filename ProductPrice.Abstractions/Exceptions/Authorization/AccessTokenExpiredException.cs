using System.Net;
using ProductPrice.Abstractions.Attributes;

namespace ProductPrice.Abstractions.Exceptions.Authorization
{
    [StatusCode(HttpStatusCode.Unauthorized)]
    public class AccessTokenExpiredException : ProductPriceExceptionBase
    {
        
    }
}