using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPrice.Abstractions.CQRS.DataBase
{
    public interface IDbContext
    {
        IDbConnection Connection { get; }

        IEnumerable<TEntity> AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;

        void Dispose();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        IEnumerable<TEntity> RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}