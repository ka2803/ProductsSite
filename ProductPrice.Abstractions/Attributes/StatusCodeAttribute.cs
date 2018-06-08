using System;
using System.Net;

namespace ProductPrice.Abstractions.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class StatusCodeAttribute : Attribute
    {
        public HttpStatusCode StatusCode { get; }

        public StatusCodeAttribute(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}