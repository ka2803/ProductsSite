using System;

namespace ProductPrice.Abstractions.Exceptions.Authorization
{
    public class AccessTokenVerificationException : ProductPriceExceptionBase
    {
        public Exception Exception { get; }

        public AccessTokenVerificationException(Exception ex)
        {
            Exception = ex;
        }
    }
}