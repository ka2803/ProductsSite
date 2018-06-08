using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProductPrice.Abstractions.CQRS.DataBase;

namespace ProductPrice.Domain.Database.Entities.Content
{
    public abstract class ContentBase : EntityBase
    {
        [Index(IsUnique = true)]
        [StringLength(100)]
        public string Key { get; set; }

        public string Value { get; set; }
    }
}