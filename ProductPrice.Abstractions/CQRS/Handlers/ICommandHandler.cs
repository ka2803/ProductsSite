using System.Threading.Tasks;

namespace ProductPrice.Abstractions.CQRS.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task Execute(TCommand context);
    }
}
