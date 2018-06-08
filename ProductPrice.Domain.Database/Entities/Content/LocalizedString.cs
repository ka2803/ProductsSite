using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using ProductPrice.Abstractions.CQRS.DataBase;

namespace ProductPrice.Domain.Database.Entities.Content
{
    public class LocalizedString : EntityBase
    {
        [Index(IsUnique = true, Order = 0)]
        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        public string Key { get; set; }

        [NotMapped]
        public CultureInfo Culture { get; set; }

        [Index(IsUnique = true, Order = 1)]
        [StringLength(100)]
        public string IsoLanguageName
        {
            get => Culture?.TwoLetterISOLanguageName;
            set => Culture = CultureInfo.GetCultureInfo(value);
        }

        public string Category { get; set; }

        public string Value { get; set; }
    }

}