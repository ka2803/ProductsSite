using System.Collections.Generic;
using ProductPrice.Abstractions.CQRS.DataBase;

namespace ProductPrice.Domain.Database.Entities
{
    public class Tax : EntityBase
    {
        public string Title { get; set; }
        public decimal Value { get; set; }

        public ICollection<ProductPrice> ProductPrices { get; set; }
    }
}