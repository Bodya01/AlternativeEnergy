using AlternativeEnergy.Events;

namespace AlternativeEnergy.Messaging
{
    public interface IInMemoryMessageBus
    {
        Task PublishAsync(IEvent @event);
        Task PublishAsync(IEnumerable<IEvent> events);
    }
}
