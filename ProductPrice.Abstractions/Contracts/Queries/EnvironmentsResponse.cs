using System.Collections.Generic;
using ProductPrice.Abstractions.Contracts.Queries.SubResponses;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Queries
{
    public class EnvironmentsResponse : IQueryResult
    {
        public ICollection<Environment> Environments { get; set; }
    }
}