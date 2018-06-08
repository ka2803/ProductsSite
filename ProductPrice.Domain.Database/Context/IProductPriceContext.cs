using System.Data.Entity;
using ProductPrice.Abstractions.CQRS.DataBase;
using ProductPrice.Domain.Database.Entities;
using ProductPrice.Domain.Database.Entities.Content;

namespace ProductPrice.Domain.Database.Context
{
    public interface IProductPriceContext : IDbContext
    {
        IDbSet<Boxing> Boxes { get; }
        IDbSet<Environment> Environments { get; }
        IDbSet<Product> Products { get; }
        IDbSet<Entities.ProductPrice> ProductPrices { get; }
        IDbSet<Shipping> Shippings { get; }
        IDbSet<Tax> Taxes { get; }
        IDbSet<User> Users { get; }
        IDbSet<CustomProperty> CustomProperties { get; }
        IDbSet<Color> Colors { get; }
        IDbSet<ImageUrl> ImageUrls { get; }
        IDbSet<LocalizedString> LocalizedStrings { get; }
    }
}