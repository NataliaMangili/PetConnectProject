namespace PetSupportDomain.Shared.Events;

public interface IEventStore
{
    Task AppendEventAsync(IEvent @event);
    Task<List<IEvent>> GetEventAsync(string aggregateId);
}
