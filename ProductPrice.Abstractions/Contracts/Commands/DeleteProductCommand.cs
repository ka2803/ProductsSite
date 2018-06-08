using System;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Commands
{
    public class DeleteProductCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}