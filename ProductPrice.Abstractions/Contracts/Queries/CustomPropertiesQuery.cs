using Newtonsoft.Json.Linq;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Queries
{
    public class CustomPropertiesQuery : IQuery<CustomPropertiesResponse>
    {
        
    }

    public class CustomPropertiesResponse : IQueryResult
    {
        public JToken CustomProperties { get; set; }
    }
}