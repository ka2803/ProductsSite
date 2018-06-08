using System;

namespace ProductPrice.Abstractions.Contracts.Queries.SubResponses
{
    public class Boxing
    {
        public Guid Id { get; set; }
        public string SizeType { get; set; }
        public decimal Price { get; set; }
        public string Material { get; set; }
    }
}