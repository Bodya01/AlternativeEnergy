using AlternativeEnergy.Identity.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AlternativeEnergy.Identity.Application
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
