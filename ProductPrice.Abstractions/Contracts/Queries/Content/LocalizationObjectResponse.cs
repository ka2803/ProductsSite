using System.Collections.Generic;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Queries.Content
{
    public class LocalizationObjectResponse : IQueryResult
    {
        public Dictionary<string, string> Text { get; set; }
        public Dictionary<string, string> Colors { get; set; }
        public Dictionary<string, string> Images { get; set; }
    }
}