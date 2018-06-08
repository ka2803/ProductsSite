using System;
using System.Collections.Generic;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Queries.Calculations
{
    public class CalculatedPriceRangeResponse : IQueryResult
    {
        public IDictionary<Guid, decimal> Prices { get; set; }
    }
}