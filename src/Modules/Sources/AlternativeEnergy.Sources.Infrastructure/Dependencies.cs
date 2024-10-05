using AlternativeEnergy.Infrastructure;
using AlternativeEnergy.Sources.Domain.Repositories;
using AlternativeEnergy.Sources.Infrastructure.EF.Context;
using AlternativeEnergy.Sources.Infrastructure.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AlternativeEnergy.Sources.Infrastructure
{
    public static class Dependencies
    {
        public static IServiceCollection AddSourcesContext(this IServiceCollection services, ApplicationConfigs configs)
        {
            services.AddDbContext<SourcesModuleContext>(options =>
            {
                options.UseSqlServer(configs.ConnectionStrings.AlternativeEnergy);
            });

            return services;
        }

        public static IServiceCollection AddSourcesRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISourceRepository, SourceRepository>();
            services.AddScoped<IUserEnergyChoiceRepository, UserEnergyChoiceRepository>();

            return services;
        }
    }
}
