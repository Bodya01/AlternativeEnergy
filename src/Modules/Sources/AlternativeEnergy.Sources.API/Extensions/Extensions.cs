using AlternativeEnergy.Infrastructure;
using AlternativeEnergy.Sources.Application;
using AlternativeEnergy.Sources.Infrastructure;
using System.Reflection;

namespace AlternativeEnergy.Sources.API.Extensions
{
    public static class Extensions
    {
        public static IMvcBuilder UseSourcesApi(this IMvcBuilder builder) =>
            builder.AddApplicationPart(Assembly.GetExecutingAssembly());

        public static IServiceCollection AddSourcesApi(this IServiceCollection services, ApplicationConfigs configs)
        {
            services.AddSourcesContext(configs)
                .AddSourcesRepositories()
                .AddSourcesHandlers()
                .AddSourcesEventHandlers();

            return services;
        }
    }
}
