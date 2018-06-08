using System;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Commands.Authorization
{
    public class SetRefreshTokenCommand : ICommand
    {
        public Guid UserId { get; set; }
        public string RefreshToken { get; set; }
    }
}