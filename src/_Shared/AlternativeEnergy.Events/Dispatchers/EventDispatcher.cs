using Microsoft.Extensions.DependencyInjection;

namespace AlternativeEnergy.Events.Dispatchers
{
    internal sealed class EventDispatcher : IEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public EventDispatcher(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public async Task InvokeEventHandler<T>(T @event) where T : class, IEvent
        {
            using var scope = _serviceProvider.CreateScope();

            var handlers = scope.ServiceProvider.GetServices<IEventHandler<T>>();

            foreach (var handler in handlers) await handler.HandleAsync(@event);
        }
    }
}
