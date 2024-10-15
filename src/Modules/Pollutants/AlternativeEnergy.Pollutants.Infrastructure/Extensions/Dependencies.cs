using AlternativeEnergy.Infrastructure;
using AlternativeEnergy.Pollutants.Domain.Repositories;
using AlternativeEnergy.Pollutants.Infrastructure.EF.Context;
using AlternativeEnergy.Pollutants.Infrastructure.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AlternativeEnergy.Pollutants.Infrastructure.Extensions
{
    public static class Dependencies
    {
        public static IServiceCollection AddPollutantsDbContext(this IServiceCollection services, ApplicationConfigs configs)
        {
            services.AddDbContext<PollutantsModuleContext>(o =>
            {
                o.UseSqlServer(configs.ConnectionStrings.AlternativeEnergy);
            });

            return services;
        }

        public static IServiceCollection AddPollutantRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRegionRepository, RegionRepository>();

            return services;
        }
    }
}
