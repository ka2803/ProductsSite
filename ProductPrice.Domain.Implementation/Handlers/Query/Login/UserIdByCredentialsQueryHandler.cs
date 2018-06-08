using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Queries.Login;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Query.Login
{
    internal class
        UserIdByCredentialsQueryHandler : DatabaseQueryHandlerBase<UserIdByCredentialsQuery, UserIdByCredentialsResponse
        >
    {
        public UserIdByCredentialsQueryHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task<UserIdByCredentialsResponse> Execute(UserIdByCredentialsQuery query)
        {
            var userId = await DbContext.Users
                .Where(user => user.Email == query.Email && user.Password == query.Password).Select(user => user.Id)
                .FirstOrDefaultAsync();

            if (userId == default(Guid))
            {
                //TODO throw smthng
                throw new NotImplementedException();
            }

            return new UserIdByCredentialsResponse
            {
                UserId = userId
            };
        }
    }
}