using System;
using System.Data.Entity;
using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Commands;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Entities;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Command
{
    internal class RegisterNewUserCommandHandler : DatabaseCommandHandlerBase<RegisterNewUserCommand>
    {
        public RegisterNewUserCommandHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(RegisterNewUserCommand context)
        {
            var user = await DbContext.Users.FirstOrDefaultAsync(user1 => user1.Email == context.Email);

            if (user != null)
            {
                //TODO throw smtng
                throw new NotImplementedException();
            }

            DbContext.Users.Add(new User
            {
                Email = context.Email,
                Password = context.Password
            });

            await DbContext.SaveChangesAsync();
        }
    }
}