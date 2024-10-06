using AlternativeEnergy.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AlternativeEnergy.Modules.Extensions
{
    public static class Extenstions
    {
        public static IServiceCollection AddModuleBroadcasting(this IServiceCollection services)
        {
            services.AddModuleRegistry()
                .AddTransient<IModuleClient, ModuleClient>();

            return services;
        }

        private static IServiceCollection AddModuleRegistry(this IServiceCollection services)
        {
            var eventTypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(a => a.FullName!.Contains("AlternativeEnergy"))
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsClass && typeof(IEvent).IsAssignableFrom(t))
                .ToList();

            services.AddSingleton<IModuleRegistry>(provider =>
            {
                var logger = provider.GetService<ILogger<IModuleRegistry>>();
                var registry = new ModuleRegistry(logger!);

                foreach (var type in eventTypes)
                {
                    registry.AddBroadcastAction(type, (sp, @event) =>
                    {
                        var dispatcher = sp.GetService<IEventDispatcher>();
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.

                        // invoke event dispatcher
                        return (Task)dispatcher!.GetType()
                            .GetMethod(nameof(dispatcher.BroadcastToHandlerAsync))!
                            .MakeGenericMethod(type) //set type of event listener object
                            .Invoke(dispatcher, [@event]);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8603 // Possible null reference return.
                    });
                }

                return registry;
            });

            return services;
        }
    }
}
