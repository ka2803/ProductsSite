using System;
using System.Threading.Tasks;using Autofac;
using FluentValidation;
using ProductPrice.Abstractions.CQRS;
using ProductPrice.Abstractions.CQRS.Buses;
using ProductPrice.Abstractions.CQRS.Handlers;

namespace ProductPrice.Domain.Implementation.Buses
{
    public class CommandBus : ICommandBus
    {
        private readonly ILifetimeScope _lifetimeScope;

        public CommandBus(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public async Task Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = ResolveHandler(command);

            await Validate(command);

            await commandHandler.Execute(command);
        }

        private ICommandHandler<TCommand> ResolveHandler<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = _lifetimeScope.ResolveOptional<ICommandHandler<TCommand>>();
            if (commandHandler == null)
            {
                throw new InvalidOperationException();
                //throw new CommandHandlerNotFoundException<TCommand>(command);
            }
            return commandHandler;
        }

        private async Task Validate<TCommand>(TCommand command) where TCommand : ICommand
        {
            var validator = _lifetimeScope.ResolveOptional<IValidator<TCommand>>();

            if (validator == null)
            {
                throw new InvalidOperationException();
                //throw new MissingCommandValidatorException<TCommand>(command);
            }

            var validationResult = await validator.ValidateAsync(command);

            if (validationResult == null)
            {
                throw new InvalidOperationException();
                //throw new CorruptedValidatorException<IValidator<TCommand>, TCommand>(validator, command);
            }

            if (!validationResult.IsValid)
            {
                throw new InvalidOperationException();
                //throw new ValidationException(validationResult.Errors, command);
            }
        }
    }
}