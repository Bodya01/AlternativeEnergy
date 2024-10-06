using AlternativeEnergy.Identity.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AlternativeEnergy.Identity.Application
{
    public static class Dependencies
    {
        public static IServiceCollection AddIdentityCommandHandlers(this IServiceCollection services)
        {
            services.AddMediatR(c =>
            {
                c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }

        public static IServiceCollection AddIdentityApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}
