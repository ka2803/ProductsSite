using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Commands
{
    public class RegisterNewUserCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}