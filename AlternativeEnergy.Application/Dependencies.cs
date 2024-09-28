using AlternativeEnergy.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AlternativeEnergy.Application
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}
