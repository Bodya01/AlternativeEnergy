using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AlternativeEnergy.Modules
{
    internal sealed class ModuleClient : IModuleClient
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IModuleRegistry _moduleRegistry;
        private readonly ILogger<IModuleClient> _logger;

        public ModuleClient(IServiceProvider serviceProvider, IModuleRegistry moduleRegistry, ILogger<IModuleClient> logger)
        {
            _serviceProvider = serviceProvider;
            _moduleRegistry = moduleRegistry;
            _logger = logger;
        }

        public async Task PublishAsync(object moduleBroadcast)
        {
            var tasks = new List<Task>();
            var path = moduleBroadcast.GetType().Name;
            var registrations = _moduleRegistry
                .GetBroadcastRegistration(path)
                .Where(r => r.ReceiverType != moduleBroadcast.GetType()); // filter out events inside of the application of same type

            _logger.LogTrace($"Publishing message of type {moduleBroadcast.GetType().Name} to " +
                             $"{registrations.Count()} module receivers");

            foreach (var registration in registrations)
            {
                var action = registration.Action;
                var receiverBroadcast = TranslateType(moduleBroadcast, registration.ReceiverType);
                tasks.Add(action(_serviceProvider, receiverBroadcast));
            }
            await Task.WhenAll(tasks);

            _logger.LogTrace($"Published message of type {moduleBroadcast.GetType().Name} to " +
                             $"{registrations.Count()} module receivers");
        }

        /// <summary>
        /// Parses published event into event listener event type
        /// </summary>
        /// <param name="object">Published event</param>
        /// <param name="type">Listener event type from application domain</param>
        /// <returns></returns>
        private static object TranslateType(object @object, Type type)
        {
            var json = JsonConvert.SerializeObject(@object);
            var receiverType = JsonConvert.DeserializeObject(json, type);
            return receiverType;
        }
    }
}
