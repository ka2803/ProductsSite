using System.ComponentModel.DataAnnotations;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Commands.Content.Image
{
    public class RemoveImageUrlCommand : ICommand
    {
        [Required(AllowEmptyStrings = false)]
        public string Key { get; set; }
    }
}