using System;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Commands
{
    public class DeletePriceCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}