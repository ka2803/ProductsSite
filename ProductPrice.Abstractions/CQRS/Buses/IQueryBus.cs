using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPrice.Abstractions.CQRS.Buses
{
    public interface IQueryBus
    {
        Task<TResult> Execute<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
            where TResult : IQueryResult;
    }
}
