using System.Collections.Generic;
using ProductPrice.Abstractions.Contracts.Queries.SubResponses;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Queries
{
    public class AllProductsResponse : IQueryResult
    {
        public ICollection<Product> Products { get; set; }
    }

   
}