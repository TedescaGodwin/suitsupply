using Autofac;
using Suit.Supply.Core.Interfaces;
using Suit.Supply.Core.Services;

namespace Suit.Supply.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderItemSearchService>()
                .As<IOrderItemSearchService>().InstancePerLifetimeScope();
        }
    }

}

