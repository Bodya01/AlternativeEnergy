using AlternativeEnergy.Events;
using AlternativeEnergy.Pollutants.Application.Events.External;
using AlternativeEnergy.Pollutants.Application.Events.External.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace AlternativeEnergy.Pollutants.Application.Extensions
{
    public static class Dependencies
    {
        public static IServiceCollection AddPollutantHandlers(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddPollutantEventHandlers(this IServiceCollection services)
        {
            services.AddScoped<IEventHandler<RegionCreatedEvent>, RegionCreatedEventHandler>();

            return services;
        }
    }
}
