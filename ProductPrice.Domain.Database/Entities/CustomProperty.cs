using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using ProductPrice.Abstractions.CQRS.DataBase;

namespace ProductPrice.Domain.Database.Entities
{
    public class CustomProperty : EntityBase
    {
        [Index("UX_CustomProperty_NameProduct", IsUnique = true, Order = 0)]
        [ForeignKey(nameof(Product))]
        public Guid? ProductId { get; set; }

        [JsonIgnore]
        public Product Product { get; set; }

        [ForeignKey(nameof(ParentProperty))]
        public Guid? ParentPropetyId { get; set; }

        [JsonIgnore]
        public CustomProperty ParentProperty { get; set; }

        [Index("UX_CustomProperty_NameProduct", IsUnique = true, Order = 1)]
        [StringLength(maximumLength: 100)]
        public string Name { get; set; }

        [Required]
        public string Value { get; set; }

        public ICollection<CustomProperty> ChildProperies { get; set; }
    }
}