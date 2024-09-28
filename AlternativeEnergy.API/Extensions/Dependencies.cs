using AlternativeEnergy.Identity.Application;
using AlternativeEnergy.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AlternativeEnergy.API.Extensions
{
    internal static class Dependencies
    {
        public static IServiceCollection RegisterIdentityModule(this IServiceCollection services, ApplicationConfigs configs)
        {
            services.RegisterIdentityDependencies(configs);
            return services;
        }
    }
}