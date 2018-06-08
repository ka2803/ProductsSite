using System;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Commands
{
    public class DeleteAdditionalFactorsCommand : ICommand
    {
        public Guid? ShippingId { get; set; }
        public Guid? EnvironmentId { get; set; }
        public Guid? TaxId { get; set; }
        public Guid? BoxingId { get; set; }
    }
}