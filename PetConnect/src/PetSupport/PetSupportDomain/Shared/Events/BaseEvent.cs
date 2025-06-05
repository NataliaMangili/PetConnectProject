namespace PetSupportDomain.Shared.Events;

public abstract class BaseEvent : IEvent
{
    public string EventId { get; init; } = Guid.NewGuid().ToString();
    public string AggregateId { get; init; }
    public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
    public string CorrelationId { get; init; }

    protected BaseEvent(string aggregateId, string correlationId)
    {
        AggregateId = aggregateId;
        CorrelationId = correlationId;
    }
}
