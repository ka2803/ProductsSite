using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPrice.Abstractions.CQRS.Handlers
{
    public interface IQueryHandler<in TQuery, TResult>
        where TQuery : IQuery<TResult>
        where TResult : IQueryResult
    {
        Task<TResult> Execute(TQuery query);
    }
}
