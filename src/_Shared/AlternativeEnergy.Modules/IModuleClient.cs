namespace AlternativeEnergy.Modules
{
    public interface IModuleClient
    {
        Task PublishAsync(object moduleBroadcast);
    }
}
