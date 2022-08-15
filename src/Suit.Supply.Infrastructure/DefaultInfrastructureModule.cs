using System.Reflection;
using Autofac;
using Suit.Supply.Core.Interfaces;
using Suit.Supply.Infrastructure.Data;
using Suit.Supply.SharedKernel;
using Suit.Supply.SharedKernel.Interfaces;
using MediatR;
using MediatR.Pipeline;
using Module = Autofac.Module;
using Suit.Supply.Core.SalesAggregate.Models;
using Suit.Supply.Infrastructure.Services;

namespace Suit.Supply.Infrastructure
{
    public class DefaultInfrastructureModule : Module
    {
        private readonly bool _isDevelopment = false;
        private readonly List<Assembly> _assemblies = new();

        public DefaultInfrastructureModule(bool isDevelopment, Assembly? callingAssembly = null)
        {
            _isDevelopment = isDevelopment;
            var coreAssembly =
              Assembly.GetAssembly(typeof(SalesDetail));
            var infrastructureAssembly = Assembly.GetAssembly(typeof(StartupSetup));
            if (coreAssembly != null)
            {
                _assemblies.Add(coreAssembly);
            }

            if (infrastructureAssembly != null)
            {
                _assemblies.Add(infrastructureAssembly);
            }

            if (callingAssembly != null)
            {
                _assemblies.Add(callingAssembly);
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (_isDevelopment)
            {
                RegisterDevelopmentOnlyDependencies(builder);
            }
            else
            {
                RegisterProductionOnlyDependencies(builder);
            }

            RegisterCommonDependencies(builder);
        }

        private void RegisterCommonDependencies(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EntityFrameworkRepository<>))
              .As(typeof(IRepository<>))
              .As(typeof(IReadRepository<>))
              .InstancePerLifetimeScope();

            builder.RegisterType<AzureBusService>()
               .As(typeof(IAzureBusService))
               .InstancePerLifetimeScope();

            builder
              .RegisterType<Mediator>()
              .As<IMediator>()
              .InstancePerLifetimeScope();

            builder
              .RegisterType<DomainEventDispatcher>()
              .As<IDomainEventDispatcher>()
              .InstancePerLifetimeScope();

           

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();

                return t => c.Resolve(t);
            });

            var mediatrOpenTypes = new[]
            {
      typeof(IRequestHandler<,>),
      typeof(IRequestExceptionHandler<,,>),
      typeof(IRequestExceptionAction<,>),
      typeof(INotificationHandler<>),
    };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                  .RegisterAssemblyTypes(_assemblies.ToArray())
                  .AsClosedTypesOf(mediatrOpenType)
                  .AsImplementedInterfaces();
            }

            builder.RegisterType<EmailSender>().As<IEmailSender>()
              .InstancePerLifetimeScope();


        }

        private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
        {
         
        }

        private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
        {
        }
    }


}

