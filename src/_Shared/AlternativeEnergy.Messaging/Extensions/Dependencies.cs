using AlternativeEnergy.Events.Extensions;
using AlternativeEnergy.Modules.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace AlternativeEnergy.Messaging.Extensions
{
    public static class Dependencies
    {
        public static IServiceCollection AddInMemoryMessaging(this IServiceCollection services)
        {
            services.AddModuleBroadcasting()
                .AddInMemoryEventDispatcher();
            services.AddTransient<IInMemoryMessageBus, InMemoryMessageBus>();

            return services;
        }
    }
}
