using System;
using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Commands
{
    public class UpdateAdditionalFactorsCommand : ICommand
    {
        public Boxing Box { get; set; }
        public Environment EnvironmentForPrice { get; set; }
        public Shipping Logistic { get; set; }
        public Tax TaxForPrice { get; set; }

        public class Boxing
        {
            public Guid Id { get; set; }
            public string SizeType { get; set; }
            public decimal? Price { get; set; }
            public string Material { get; set; }
        }
        public class Environment
        {
            public Guid Id { get; set; }
            public decimal? TotalSalary { get; set; }
            public decimal? TotalElectricity { get; set; }
            public decimal? TotalAmortization { get; set; }
        }
        public class Shipping
        {
            public Guid Id { get; set; }
            public int? PathLength { get; set; }
            public decimal? Price { get; set; }
        }
        public class Tax
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public decimal? Value { get; set; }
        }
    }
}