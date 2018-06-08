using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Queries
{
    public class ProductsWithPricesResponse : IQueryResult
    {
        public int TotalPages { get; set; }
        public ICollection<Product> Products { get; set; }

        public class Product
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public JToken CustomProperties { get; set; }
            public decimal Price { get; set; }
        }
    }
}