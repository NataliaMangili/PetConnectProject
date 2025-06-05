namespace PetSupportDomain.Shared.Events;

public interface IEvent
{
    string EventId { get; }
    string AggregateId { get; }
    DateTime OccurredOn { get; }
    string CorrelationId { get; }
}
