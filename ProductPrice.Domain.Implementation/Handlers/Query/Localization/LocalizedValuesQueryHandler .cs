using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Queries.Content;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Query.Localization
{
    public class LocalizedValuesQueryHandler : DatabaseQueryHandlerBase<LocalizedValuesQuery, LocalizedValuesResponse>
    {
        public LocalizedValuesQueryHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task<LocalizedValuesResponse> Execute(LocalizedValuesQuery query)
        {
            var dictionary = await DbContext.LocalizedStrings.Where(
                    s =>
                        query.Keys.Contains(s.Key))
                .ToDictionaryAsync(s => s.Key, s => s.Value);

            if (query.Keys.Count != dictionary.Count)
            {
                throw new NotImplementedException();
            }

            return new LocalizedValuesResponse
            {
                ResultDictionary = dictionary
            };
        }
    }
}