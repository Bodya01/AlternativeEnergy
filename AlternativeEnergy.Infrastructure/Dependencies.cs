using AlternativeEnergy.Infrastructure.EFCore.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AlternativeEnergy.Infrastructure
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            return services;
        }
    }
}
