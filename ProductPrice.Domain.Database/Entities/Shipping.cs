using ProductPrice.Abstractions.CQRS.DataBase;

namespace ProductPrice.Domain.Database.Entities
{
    public class Shipping : EntityBase
    {
        public int PathLength { get; set; }
        public decimal Price { get; set; }
    }
}