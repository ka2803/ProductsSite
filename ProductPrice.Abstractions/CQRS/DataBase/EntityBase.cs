using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductPrice.Abstractions.CQRS.DataBase
{
    public abstract class EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
