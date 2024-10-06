using AlternativeEnergy.Events.Dispatchers;
using Microsoft.Extensions.DependencyInjection;

namespace AlternativeEnergy.Events.Extensions
{
    public static class Dependencies
    {
        public static IServiceCollection AddInMemoryEventDispatcher(this IServiceCollection services)
        {
            services.AddSingleton<IEventDispatcher, EventDispatcher>();

            return services;
        }

        public static IServiceCollection AddEventHandlers(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes()
                    .Where(type => type.IsClass && !type.IsAbstract && typeof(IEventHandler<>)
                    .IsAssignableFrom(type));

                foreach (var type in types)
                {
                    var interfaces = type.GetInterfaces()
                        .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventHandler<>));

                    foreach (var @interface in interfaces)
                    {
                        services.AddTransient(@interface, type);
                    }
                }
            }

            return services;
        }
    }
}
