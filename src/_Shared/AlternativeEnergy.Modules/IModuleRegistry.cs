namespace AlternativeEnergy.Modules
{
    public interface IModuleRegistry
    {
        IEnumerable<ModuleBroadcastRegistration> GetBroadcastRegistration(string path);
        void AddBroadcastAction(Type receiverType, Func<IServiceProvider, object, Task> action);
    }
}
