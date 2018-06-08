﻿using System.ComponentModel.DataAnnotations;
using System.Globalization;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Commands.Content.Localization
{
    public class UpdateLocalizedStringCommand : ICommand
    {
        [Required(AllowEmptyStrings = false)]
        public string Key { get; set; }

        [Required(AllowEmptyStrings = false)]
        public CultureInfo Culture { get; set; }

        public string Category { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Value { get; set; }
    }
}