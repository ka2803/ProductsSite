using System;

namespace ProductPrice.Abstractions.Contracts.Queries.SubResponses
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ProductPrice ProductPrice { get; set; }
    }
}