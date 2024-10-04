using AlternativeEnergy.Infrastructure;
using AlternativeEnergy.Regions.Application;
using AlternativeEnergy.Regions.Infrastructure;
using System.Reflection;

namespace AlternativeEnergy.Regions.API
{
    public static class Dependencies
    {
        public static IMvcBuilder UseRegionsApi(this IMvcBuilder builder) =>
            builder.AddApplicationPart(Assembly.GetExecutingAssembly());

        public static IServiceCollection AddRegionsApi(this IServiceCollection services, ApplicationConfigs configs)
        {
            services.AddRegionsDbContext(configs)
                .AddRegionsRepositories()
                .AddRegionsQueryHandlers()
                .AddRegionsCommandHandlers();

            return services;
        }
    }
}
