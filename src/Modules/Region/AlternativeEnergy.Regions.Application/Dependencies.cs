using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AlternativeEnergy.Regions.Application
{
    public static class Dependencies
    {
        public static IServiceCollection AddRegionsCommandHandlers(this IServiceCollection services)
        {
            services.AddMediatR(c =>
            {
                c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
