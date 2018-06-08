using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ProductPrice.Abstractions.Contracts.Queries.Content;
using ProductPrice.Domain.Database.Context;
using ProductPrice.Domain.Database.Handlers.Base;

namespace ProductPrice.Domain.Implementation.Handlers.Query.Localization
{
    public class LocalizationObjectQueryHandler : DatabaseQueryHandlerBase<LocalizationObjectQuery, LocalizationObjectResponse>
    {
        public LocalizationObjectQueryHandler(IProductPriceContext dbContext) : base(dbContext)
        {
        }

        public override async Task<LocalizationObjectResponse> Execute(LocalizationObjectQuery query)
        {
            var textQueryable = DbContext.LocalizedStrings.AsNoTracking();
            if (!string.IsNullOrEmpty(query.Category))
            {
                textQueryable = textQueryable.Where(s => s.Category == query.Category);
            }

            var text =
                await textQueryable.Where(s => s.IsoLanguageName == query.Culture.TwoLetterISOLanguageName)
                    .ToDictionaryAsync(s => s.Key, s => s.Value);

            var imagesQueryable = DbContext.ImageUrls.AsNoTracking();
            if (!string.IsNullOrEmpty(query.Category))
            {
                imagesQueryable = imagesQueryable.Where(s => s.Category == query.Category);
            }

            var images =
                await imagesQueryable.ToDictionaryAsync(s => s.Key, s => s.Value);

            var colorsQueryable = DbContext.Colors.AsNoTracking();
            if (!string.IsNullOrEmpty(query.Category))
            {
                colorsQueryable = colorsQueryable.Where(s => s.Category == query.Category);
            }

            var colors =
                await colorsQueryable.ToDictionaryAsync(s => s.Key, s => s.Value.ToString());
            return new LocalizationObjectResponse
            {
                Text = text,
                Colors = colors,
                Images = images
            };
        }
    }
}