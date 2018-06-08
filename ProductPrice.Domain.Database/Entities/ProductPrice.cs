using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ProductPrice.Abstractions.CQRS.DataBase;

namespace ProductPrice.Domain.Database.Entities
{
    public class ProductPrice : EntityBase
    {
        public decimal StartPrice { get; set; }

        [ForeignKey(nameof(Boxing))]
        public Guid BoxingId{ get; set; }
        public Boxing Boxing{ get; set; }


        [ForeignKey(nameof(Environment))]
        public Guid EnvironmentId { get; set; }
        public Environment Environment{ get; set; }


        [ForeignKey(nameof(Shipping))]
        public Guid ShippingId { get; set; }
        public Shipping Shipping { get; set; }

        public ICollection<Tax> Taxes { get; set; }
    }
}