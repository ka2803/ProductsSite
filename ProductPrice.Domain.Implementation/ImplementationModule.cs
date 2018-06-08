using Autofac;
using AutoMapper;
using FluentValidation;
using ProductPrice.Abstractions.CQRS.Handlers;
using ProductPrice.Domain.Implementation.Buses;
using ProductPrice.Domain.Implementation.Services;

namespace ProductPrice.Domain.Implementation
{
    public class ImplementationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandBus>().AsImplementedInterfaces();
            builder.RegisterType<QueryBus>().AsImplementedInterfaces();
            builder.RegisterType<JwtJsonMapper>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<ExpirableTokenGenerationService>().AsImplementedInterfaces();
            builder.RegisterType<AccessTokenService>().AsImplementedInterfaces();
            builder.RegisterType<Sha512Service>().AsImplementedInterfaces();
            builder.RegisterType<RandomStringGenerationService>().AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(InlineValidator<>))
                .As(typeof(IValidator<>));

            builder.RegisterType<JwtJsonMapper>().AsImplementedInterfaces().SingleInstance();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IQueryHandler<,>))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IValidator<>))
                .AsImplementedInterfaces();


            builder.Register(c => new MapperConfiguration(cfg => {})).AsSelf()
                .SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>()
                .SingleInstance();
        }
    }
}