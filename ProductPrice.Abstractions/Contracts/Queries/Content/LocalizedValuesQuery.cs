using System.Collections.Generic;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Queries.Content
{
    public class LocalizedValuesQuery : IQuery<LocalizedValuesResponse>
    {
        public ICollection<string> Keys { get; set; }
    }
}