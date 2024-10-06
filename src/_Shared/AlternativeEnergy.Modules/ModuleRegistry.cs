using Microsoft.Extensions.Logging;

namespace AlternativeEnergy.Modules
{
    internal sealed class ModuleRegistry : IModuleRegistry
    {
        private readonly IList<ModuleBroadcastRegistration> _broadcastActions;
        private readonly ILogger<IModuleRegistry> _logger;

        public ModuleRegistry(ILogger<IModuleRegistry> logger)
        {
            _broadcastActions = [];
            _logger = logger;
        }


        public IEnumerable<ModuleBroadcastRegistration> GetBroadcastRegistration(string path)
            => _broadcastActions.Where(r => r.Path == path);

        public void AddBroadcastAction(Type receiverType, Func<IServiceProvider, object, Task> action)
        {
            var registration = new ModuleBroadcastRegistration
            {
                ReceiverType = receiverType,
                Action = action
            };

            _broadcastActions.Add(registration);
            _logger.LogTrace($"Added broadcast of type {{{registration.ReceiverType.Name}}} to module registry");
        }
    }
}
