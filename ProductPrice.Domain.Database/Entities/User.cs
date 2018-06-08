using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProductPrice.Abstractions.CQRS.DataBase;

namespace ProductPrice.Domain.Database.Entities
{
    public class User : EntityBase
    {
        [StringLength(25)]
        [Index("UX_Users_Email",IsUnique = true)]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}