using AlternativeEnergy.Sources.API.Controllers;

namespace AlternativeEnergy.Sources.API.Extensions
{
    public static class Extensions
    {
        public static IMvcBuilder UseSourcesApi(this IMvcBuilder builder)
        {
            var assembly = typeof(SourcesController).Assembly;
            builder.AddApplicationPart(typeof(SourcesController).Assembly);
            return builder;
        }

        public static IServiceCollection AddSourcesApi(this IServiceCollection services)
        {
            return services;
        }
    }
}
