using System.ComponentModel.DataAnnotations;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Commands.Content.Color
{
    public class RemoveColorCommand : ICommand
    {
        [Required(AllowEmptyStrings = false)]
        public string Key { get; set; }
    }
}