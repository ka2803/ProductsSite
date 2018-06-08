using System;

namespace ProductPrice.Abstractions.Contracts.Queries.SubResponses
{
    public class Environment
    {
        public Guid Id { get; set; }
        public decimal TotalSalary { get; set; }
        public decimal TotalElectricity { get; set; }
        public decimal TotalAmortization { get; set; }
    }
}