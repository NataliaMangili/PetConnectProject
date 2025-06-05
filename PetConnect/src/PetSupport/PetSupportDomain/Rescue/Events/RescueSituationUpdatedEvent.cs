using PetSupportDomain.Shared.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSupportDomain.Rescue.Events;

public class RescueSituationUpdatedEvent : IEvent
{
    public string EventId { get; } = Guid.NewGuid().ToString();
    public string AggregateId { get; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
    public string CorrelationId { get; }
    public string Description { get; }

    public RescueSituationUpdatedEvent(string aggregateId, string description, string correlationId)
    {
        AggregateId = aggregateId;
        Description = description;
        CorrelationId = correlationId;
    }
}
