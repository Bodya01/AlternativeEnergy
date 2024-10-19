using AlternativeEnergy.Events;
using AlternativeEnergy.Pollutants.Application.Events.External;
using AlternativeEnergy.Pollutants.Application.Events.External.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AlternativeEnergy.Pollutants.Application.Extensions
{
    public static class Dependencies
    {
        public static IServiceCollection AddPollutantHandlers(this IServiceCollection services)
        {
            services.AddMediatR(c =>
            {
                c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }

        public static IServiceCollection AddPollutantEventHandlers(this IServiceCollection services)
        {
            services.AddScoped<IEventHandler<RegionCreatedEvent>, RegionCreatedEventHandler>();

            return services;
        }
    }
}
