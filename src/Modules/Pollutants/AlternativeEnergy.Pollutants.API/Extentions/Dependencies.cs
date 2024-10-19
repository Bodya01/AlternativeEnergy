using AlternativeEnergy.Infrastructure;
using AlternativeEnergy.Pollutants.Application.Extensions;
using AlternativeEnergy.Pollutants.Infrastructure.Extensions;
using System.Reflection;

namespace AlternativeEnergy.Pollutants.API.Extentions
{
    public static class Dependencies
    {
        public static IMvcBuilder UsePollutantsApi(this IMvcBuilder builder)
        {
            builder.AddApplicationPart(Assembly.GetExecutingAssembly());
            return builder;
        }

        public static IServiceCollection AddPollutantsApi(this IServiceCollection services, ApplicationConfigs configs)
        {
            services
                .AddPollutantsDbContext(configs)
                .AddPollutantRepositories()
                .AddPollutantHandlers()
                .AddPollutantEventHandlers();

            return services;
        }
    }
}
