using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using ProductPrice.Abstractions.CQRS.DataBase;

namespace ProductPrice.Domain.Database.Entities
{
    public class Product : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        
        [ForeignKey(nameof(ProductPrice))]
        public Guid ProductPriceId { get; set; }
        public ProductPrice ProductPrice { get; set; }

        public ICollection<CustomProperty> CustomProperties { get; set; }
    }
}