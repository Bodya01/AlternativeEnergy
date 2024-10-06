using AlternativeEnergy.Events;
using AlternativeEnergy.Sources.Application.Events.External;
using AlternativeEnergy.Sources.Application.Events.External.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AlternativeEnergy.Sources.Application
{
    public static class Dependencies
    {
        public static IServiceCollection AddSourcesHandlers(this IServiceCollection services)
        {
            services.AddMediatR(c =>
            {
                c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }

        public static IServiceCollection AddSourcesEventHandlers(this IServiceCollection services)
        {
            services.AddTransient<IEventHandler<RegionCreatedEvent>, RegionCreatedEventHandler>();

            return services;
        }
    }
}
