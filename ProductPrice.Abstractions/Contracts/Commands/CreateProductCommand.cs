using System;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Commands
{
    public class CreateProductCommand : ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid ProductPriceId { get; set; }
    }
}