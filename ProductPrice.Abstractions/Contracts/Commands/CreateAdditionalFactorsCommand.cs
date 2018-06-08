using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Commands
{
    public class CreateAdditionalFactorsCommand : ICommand
    {
        public Boxing Box { get; set; }
        public Environment EnvironmentForPrice { get; set; }
        public Shipping Logistic { get; set; }
        public Tax TaxForPrice { get; set; }


        public class Boxing
        {
            public string SizeType { get; set; }
            public decimal Price { get; set; }
            public string Material { get; set; }
        }
        public class Environment
        {
            public decimal TotalSalary { get; set; }
            public decimal TotalElectricity { get; set; }
            public decimal TotalAmortization { get; set; }
        }
        public class Shipping
        {
            public int PathLength { get; set; }
            public decimal Price { get; set; }
        }
        public class Tax
        {
            public string Title { get; set; }
            public decimal Value { get; set; }
        }
    }
}