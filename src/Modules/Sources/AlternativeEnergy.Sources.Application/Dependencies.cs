using AlternativeEnergy.CQRS.Extensions;
using AlternativeEnergy.Events;
using AlternativeEnergy.Sources.Application.Events.External;
using AlternativeEnergy.Sources.Application.Events.External.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace AlternativeEnergy.Sources.Application
{
    public static class Dependencies
    {
        public static IServiceCollection AddSourcesHandlers(this IServiceCollection services)
        {
            services.AddCQRSHandlersFromAssembly();

            return services;
        }

        public static IServiceCollection AddSourcesEventHandlers(this IServiceCollection services)
        {
            services.AddTransient<IEventHandler<RegionCreatedEvent>, RegionCreatedEventHandler>();
            services.AddTransient<IEventHandler<RegionUpdatedEvent>, RegionUpdatedEventHandler>();
            services.AddTransient<IEventHandler<RegionDeletedEvent>, RegionDeletedEventHandler>();

            return services;
        }
    }
}
