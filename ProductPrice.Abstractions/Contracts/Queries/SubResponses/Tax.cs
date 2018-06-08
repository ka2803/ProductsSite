using System;

namespace ProductPrice.Abstractions.Contracts.Queries.SubResponses
{
    public class Tax
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Value { get; set; }
    }
}