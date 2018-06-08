using System;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Queries.Calculations
{
    public class GetCalculatedPriceQuery : IQuery<CalculatedPriceResponse>
    {
        public Guid ProductId { get; set; }
    }
}