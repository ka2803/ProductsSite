using System;
using System.Collections.Generic;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Queries.Calculations
{
    public class GetCalculatedPriceRangeQuery : IQuery<CalculatedPriceRangeResponse>
    {
        public ICollection<Guid> Ids { get; set; }
    }
}