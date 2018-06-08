using System.Collections.Generic;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Queries.Content
{
    public class LocalizedValuesResponse : IQueryResult
    {
        public Dictionary<string, string> ResultDictionary { get; set; }
    }
}