using AlternativeEnergy.CQRS.Extensions;
using AlternativeEnergy.Infrastructure;
using AlternativeEnergy.Regions.Domain.Repositories;
using AlternativeEnergy.Regions.Infrastructure.EF.Context;
using AlternativeEnergy.Regions.Infrastructure.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AlternativeEnergy.Regions.Infrastructure
{
    public static class Dependencies
    {
        public static IServiceCollection AddRegionsDbContext(this IServiceCollection services, ApplicationConfigs configs)
        {
            services.AddDbContext<RegionsModuleContext>(c =>
            {
                c.UseSqlServer(configs.ConnectionStrings.AlternativeEnergy);
            });

            return services;
        }

        public static IServiceCollection AddRegionsRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRegionRepository, RegionRepository>();

            return services;
        }

        public static IServiceCollection AddRegionsQueryHandlers(this IServiceCollection services)
        {
            services.AddCQRSHandlersFromAssembly();

            return services;
        }
    }
}
