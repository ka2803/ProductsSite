using ProductPrice.Abstractions.CQRS.DataBase;

namespace ProductPrice.Domain.Database.Entities
{
    public class Boxing : EntityBase
    {
        public string SizeType { get; set; }
        public decimal Price { get; set; }
        public string Material { get; set; }
    }
}