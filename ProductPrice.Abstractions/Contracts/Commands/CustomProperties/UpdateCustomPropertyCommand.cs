using System;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Commands.CustomProperties
{
    public class UpdateCustomPropertyCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}