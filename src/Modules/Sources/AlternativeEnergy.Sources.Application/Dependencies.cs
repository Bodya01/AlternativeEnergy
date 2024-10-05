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
    }
}
