namespace AlternativeEnergy.Events
{
    public interface IEventDispatcher
    {
        Task InvokeEventHandler<T>(T @event) where T : class, IEvent;
    }
}
