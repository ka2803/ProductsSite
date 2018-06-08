using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Queries.Calculations
{
    public class CalculatedPriceResponse : IQueryResult
    {
        public decimal Price { get; set; }
    }
}