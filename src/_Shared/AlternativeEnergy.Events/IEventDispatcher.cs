namespace AlternativeEnergy.Events
{
    public interface IEventDispatcher
    {
        Task BroadcastToHandlerAsync<T>(T @event) where T : class, IEvent;
    }
}
