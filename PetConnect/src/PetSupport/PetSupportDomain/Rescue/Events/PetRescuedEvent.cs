using PetSupportDomain.Shared.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSupportDomain.Rescue.Events;

public class PetRescuedEvent : IEvent
{
    public string EventId { get; } = Guid.NewGuid().ToString();
    public string AggregateId { get; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
    public string CorrelationId { get; }
    public string RescuerName { get; }

    public PetRescuedEvent(string aggregateId, string rescuerName, string correlationId)
    {
        AggregateId = aggregateId;
        RescuerName = rescuerName;
        CorrelationId = correlationId;
    }
}
