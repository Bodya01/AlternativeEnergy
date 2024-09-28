using AlternativeEnergy.Identity.Domain.Repositories;
using AlternativeEnergy.Identity.Infrastructure.Context;
using AlternativeEnergy.Identity.Infrastructure.Repositories;
using AlternativeEnergy.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AlternativeEnergy.Identity.Infrastructure
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services, ApplicationConfigs configs)
        {
            services.AddDbContext<IdentityModuleContext>(options =>
                options.UseSqlServer(configs.ConnectionStrings.AlternativeEnergy));

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            return services;
        }
    }
}
