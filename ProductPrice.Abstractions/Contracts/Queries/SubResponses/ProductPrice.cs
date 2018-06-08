using System;
using System.Collections.Generic;

namespace ProductPrice.Abstractions.Contracts.Queries.SubResponses
{
    public class ProductPrice
    {
        public Guid Id { get; set; }
        public decimal StartPrice { get; set; }
        public Boxing Boxing { get; set; }
        public Environment Environment { get; set; }
        public Shipping Shipping { get; set; }
        public ICollection<Tax> Taxes { get; set; }
    }
}