using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using Newtonsoft.Json.Linq;
using ProductPrice.Abstractions.Attributes;
using ProductPrice.Abstractions.Exceptions;

namespace ProductPriceApi.Logging
{
    public class ExceptionHandler : IExceptionHandler
    {
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            var responseObject = new JObject
            {
                ["RequestId"] = context.Request.GetCorrelationId()
            };

            var statusCode = HttpStatusCode.InternalServerError;

            if (context.Exception is ProductPriceExceptionBase baseException)
            {
                var statusCodeAttribute = baseException.GetType().GetCustomAttribute<StatusCodeAttribute>();

                statusCode = statusCodeAttribute?.StatusCode ?? statusCode;

                responseObject["Message"] = baseException.Message;
                responseObject["Code"] = baseException.Code;
            }
            else
            {
                responseObject["Message"] = "Something went wrong, contact us with RequestId";
            }

            var jsonFormatter = context.RequestContext.Configuration.Formatters.JsonFormatter;

            var httpResponseMessage = new HttpResponseMessage
            {
                Content = new ObjectContent<JObject>(responseObject, jsonFormatter),
                StatusCode = statusCode
            };

            context.Result = new ResponseMessageResult(httpResponseMessage);

            return Task.FromResult(result: 0);
        }
    }
}