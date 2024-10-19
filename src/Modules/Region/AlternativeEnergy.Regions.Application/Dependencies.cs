using AlternativeEnergy.CQRS.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace AlternativeEnergy.Regions.Application
{
    public static class Dependencies
    {
        public static IServiceCollection AddRegionsCommandHandlers(this IServiceCollection services)
        {
            services.AddCQRSHandlersFromAssembly();

            return services;
        }
    }
}
