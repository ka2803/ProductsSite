using ProductPrice.Abstractions.CQRS.DataBase;

namespace ProductPrice.Domain.Database.Entities
{
    public class Environment : EntityBase
    {
        public decimal TotalSalary { get; set; }
        public decimal TotalElectricity { get; set; }
        public decimal TotalAmortization { get; set; }
    }
}