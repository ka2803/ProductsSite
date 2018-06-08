using System;
using System.Collections.Generic;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Commands.CustomProperties
{
    public class CreateCustomPropertyCommand : ICommand
    {
        public Guid ProductId { get; set; }
        public ICollection<CustomProperty> CustomProperties { get; set; }

        public class CustomProperty
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public ICollection<CustomProperty> ChildProperties { get; set; }
        }
    }
}