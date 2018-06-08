using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPrice.Abstractions.CQRS.Buses
{
    public interface ICommandBus
    {
        Task Execute<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}
