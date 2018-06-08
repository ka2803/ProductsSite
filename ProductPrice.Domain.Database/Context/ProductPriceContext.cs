using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using ProductPrice.Abstractions.CQRS.DataBase;
using ProductPrice.Domain.Database.Entities;
using ProductPrice.Domain.Database.Entities.Content;
using Environment = ProductPrice.Domain.Database.Entities.Environment;

namespace ProductPrice.Domain.Database.Context
{
    public class ProductPriceContext : DbContext, IProductPriceContext
    {
        public IDbConnection Connection => Database.Connection;

        public IEnumerable<TEntity> AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            return Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            return Set<TEntity>().RemoveRange(entities);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            foreach (var dbEntityEntry in ChangeTracker.Entries())
            {
                var entityBase = dbEntityEntry.Entity as EntityBase;

                if (entityBase == null)
                {
                    continue;
                }

                if ((dbEntityEntry.State & EntityState.Added) != 0)
                {
                    entityBase.CreationDate = DateTime.UtcNow;
                    entityBase.UpdateDate = DateTime.UtcNow;
                }

                if ((dbEntityEntry.State & EntityState.Modified) != 0)
                {
                    entityBase.UpdateDate = DateTime.UtcNow;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        public IDbSet<Boxing> Boxes { get; set; }
        public IDbSet<Environment> Environments { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<Entities.ProductPrice> ProductPrices { get; set; }
        public IDbSet<Shipping> Shippings { get; set; }
        public IDbSet<Tax> Taxes { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<CustomProperty> CustomProperties { get; set; }
        public IDbSet<Color> Colors { get; set; }
        public IDbSet<ImageUrl> ImageUrls { get; set; }
        public IDbSet<LocalizedString> LocalizedStrings { get; set; }
    }
}