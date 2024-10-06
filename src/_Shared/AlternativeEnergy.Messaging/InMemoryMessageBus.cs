using AlternativeEnergy.Events;
using AlternativeEnergy.Modules;
using Microsoft.Extensions.Logging;

namespace AlternativeEnergy.Messaging
{
    internal sealed class InMemoryMessageBus : IInMemoryMessageBus
    {
        private readonly IModuleClient _client;
        private readonly ILogger<InMemoryMessageBus> _logger;

        public InMemoryMessageBus(IModuleClient client, ILogger<InMemoryMessageBus> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task PublishAsync(IEvent @event)
        {
            _logger.LogTrace($"Publishing message of type {{{@event.GetType().Name}}}.");
            await _client.PublishAsync(@event);
            _logger.LogTrace($"Successfully published message of type {{{@event.GetType().Name}}}.");
        }

        public async Task PublishAsync(IEnumerable<IEvent> events)
        {
            var tasks = events.Select(PublishAsync).ToArray();
            await Task.WhenAll(tasks);
        }
    }
}
