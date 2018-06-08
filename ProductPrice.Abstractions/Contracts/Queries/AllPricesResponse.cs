using System.Collections.Generic;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Queries
{
    public class AllPricesResponse : IQueryResult
    {
        public ICollection<SubResponses.ProductPrice> Prices { get; set; }
    }
}