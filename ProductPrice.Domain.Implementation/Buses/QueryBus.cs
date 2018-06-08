using System;
using System.Threading.Tasks;
using Autofac;
using FluentValidation;
using ProductPrice.Abstractions.CQRS;
using ProductPrice.Abstractions.CQRS.Buses;
using ProductPrice.Abstractions.CQRS.Handlers;

namespace ProductPrice.Domain.Implementation.Buses
{
    public class QueryBus : IQueryBus
    {
        private readonly ILifetimeScope _lifetimeScope;

        public QueryBus(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public async Task<TResult> Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
            where TResult : IQueryResult
        {
            var resolveHandler = ResolveHandler<TQuery, TResult>(query);

            await Validate<TQuery, TResult>(query);

            var result = await resolveHandler.Execute(query);

            return result;
        }

        private IQueryHandler<TQuery, TResult> ResolveHandler<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
            where TResult : IQueryResult
        {
            var commandHandler = _lifetimeScope.ResolveOptional<IQueryHandler<TQuery, TResult>>();
            if (commandHandler == null)
            {
                throw new InvalidOperationException();
                //throw new QueryHandlerNotFoundException<TQuery, TResult>(query);
            }
            return commandHandler;
        }

        private async Task Validate<TQuery, TResult>(TQuery command)
            where TQuery : IQuery<TResult>
            where TResult : IQueryResult
        {
            var validator = _lifetimeScope.ResolveOptional<IValidator<TQuery>>();

            if (validator == null)
            {
                throw new InvalidOperationException();
                // throw new MissingQueryValidatorException<TQuery, TResult>(command);
            }

            var validationResult = await validator.ValidateAsync(command);

            if (validationResult == null)
            {
                throw new InvalidOperationException();
                //throw new CorruptedValidatorException<IValidator<TQuery>, TQuery>(validator, command);
            }

            if (!validationResult.IsValid)
            {
                throw new InvalidOperationException();
                //throw new ValidationException(validationResult.Errors, command);
            }
        }
    }
}