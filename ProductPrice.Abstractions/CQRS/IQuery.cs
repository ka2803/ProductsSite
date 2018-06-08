using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPrice.Abstractions.CQRS
{
    public interface IQuery<TResult> where TResult : IQueryResult
    {
    }
}
