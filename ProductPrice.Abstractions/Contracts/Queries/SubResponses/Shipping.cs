using System;

namespace ProductPrice.Abstractions.Contracts.Queries.SubResponses
{
    public class Shipping
    {
        public Guid Id { get; set; }
        public int PathLength { get; set; }
        public decimal Price { get; set; }
    }
}