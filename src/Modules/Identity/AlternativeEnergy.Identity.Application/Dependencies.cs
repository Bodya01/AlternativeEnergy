using AlternativeEnergy.CQRS.Extensions;
using AlternativeEnergy.Identity.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AlternativeEnergy.Identity.Application
{
    public static class Dependencies
    {
        public static IServiceCollection AddIdentityCommandHandlers(this IServiceCollection services)
        {
            services.AddCQRSHandlersFromAssembly();
            return services;
        }

        public static IServiceCollection AddIdentityApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}
