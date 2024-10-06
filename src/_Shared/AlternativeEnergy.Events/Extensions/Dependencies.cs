using AlternativeEnergy.Events.Dispatchers;
using Microsoft.Extensions.DependencyInjection;

namespace AlternativeEnergy.Events.Extensions
{
    public static class Dependencies
    {
        public static IServiceCollection AddInMemoryEventDispatcher(this IServiceCollection services)
            => services.AddSingleton<IEventDispatcher, EventDispatcher>();
    }
}
