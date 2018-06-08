using System;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Commands.CustomProperties
{
    public class DeleteCustomPropertyCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}