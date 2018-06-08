using System;
using System.Collections.Generic;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Commands
{
    public class AddPriceCommand : ICommand
    {
        public decimal StartPrice { get; set; }
        public Guid ShippingId { get; set; }
        public Guid BoxingId { get; set; }
        public Guid EnvironmentId { get; set; }
        public List<Guid> TaxesIds { get; set; }
    }
}