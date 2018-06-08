using System.Collections.Generic;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Commands.Content.Localization
{
    public class AddOrUpdateLocalizedStringsCommand : ICommand
    {
        public IEnumerable<AddLocalizedStringCommand> AddLocalizedStringCommands { get; set; }
    }
}