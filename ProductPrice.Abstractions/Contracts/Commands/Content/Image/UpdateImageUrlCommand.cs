using System.ComponentModel.DataAnnotations;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Commands.Content.Image
{
    public class UpdateImageUrlCommand : ICommand
    {
        [Required(AllowEmptyStrings = false)]
        public string Key { get; set; }

        public string Category { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Value { get; set; }
    }
}