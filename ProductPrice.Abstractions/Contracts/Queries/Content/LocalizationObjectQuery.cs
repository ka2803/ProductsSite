using System.ComponentModel.DataAnnotations;
using System.Globalization;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Queries.Content
{
    public class LocalizationObjectQuery : IQuery<LocalizationObjectResponse>
    {
        public string Category { get; set; }

        [Required(AllowEmptyStrings = false)]
        public CultureInfo Culture { get; set; }
    }
}