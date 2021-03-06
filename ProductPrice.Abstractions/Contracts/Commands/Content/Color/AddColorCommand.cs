﻿using System.ComponentModel.DataAnnotations;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Commands.Content.Color
{
    public class AddColorCommand : ICommand
    {
        [Required(AllowEmptyStrings = false)]
        public string Key { get; set; }

        public string Category { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Value { get; set; }
    }
}