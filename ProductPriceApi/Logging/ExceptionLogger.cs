using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using Autofac;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductPrice.Abstractions.Exceptions;

namespace ProductPriceApi.Logging
{
    public class ExceptionLogger : IExceptionLogger
    {
        private readonly ILifetimeScope _lifetimeScope;

        public ExceptionLogger(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(ExceptionLogger));
        private static readonly int MaxContentInLogs = 4096;

        private static JToken SerializeException(Exception e)
        {
            JToken exceptionToken;
            var serializer = JsonSerializer.CreateDefault();

            try
            {
                exceptionToken = JToken.FromObject(e, serializer);
            }
            catch (Exception exception)
            {
                exceptionToken = new JObject
                {
                    ["OriginalExceptionType"] = e.GetType().FullName,
                    ["SerializationExceptionType"] = exception.GetType().FullName,
                    ["Message"] = "Couldn't serialize original exception, failed with 'SerializationExceptionType'"
                };
            }

            return exceptionToken;
        }

        public async Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            try
            {
                var request = context.Request;
                var content = await request.Content.ReadAsStreamAsync();

                if (content.CanSeek)
                {
                    content.Seek(offset: 0, origin: SeekOrigin.Begin);
                }

                string contentString;

                var contentReader = new StreamReader(content);

                if (content.Length > MaxContentInLogs)
                {
                    var c = new char[100];
                    await contentReader.ReadAsync(c, index: 0, count: c.Length);

                    contentString = $"Content too long: {content.Length} characters, first 100 :: {new string(c)}";
                }
                else
                {
                    contentString = await contentReader.ReadToEndAsync();
                }

                var exceptionObject = new JObject
                {
                    ["RequestUrl"] = request.RequestUri,
                    ["Headers"] = JToken.FromObject(request.Headers),
                    ["Body"] = contentString,
                    ["Method"] = request.Method.Method,
                    ["RequestId"] = context.Request.GetCorrelationId(),
                    ["Exception"] = SerializeException(context.Exception)
                };

                if (context.Exception is ProductPriceExceptionBase exception)
                {
                    _logger.Warn(exceptionObject.ToString());
                }
                else
                {
                    _logger.Error(exceptionObject.ToString());
                }
            }
            catch (Exception e)
            {
                _logger.Fatal($"Exception log serialization error! RequestId {context.Request.GetCorrelationId()}", e);
            }
        }
    }
}