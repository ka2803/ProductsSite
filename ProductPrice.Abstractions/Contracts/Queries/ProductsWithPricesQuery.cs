using ProductPrice.Abstractions.CQRS;

namespace ProductPrice.Abstractions.Contracts.Queries
{
    public class ProductsWithPricesQuery : IQuery<ProductsWithPricesResponse>
    {
        public int Page { get; set; }
        public int ItemsOnPage { get; set; }
    }
}