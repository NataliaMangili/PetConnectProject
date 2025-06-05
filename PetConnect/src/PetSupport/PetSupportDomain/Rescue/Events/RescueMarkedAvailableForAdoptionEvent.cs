using PetSupportDomain.Shared.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSupportDomain.Rescue.Events;

public class RescueMarkedAvailableForAdoptionEvent : IEvent
{
    public string EventId { get; } = Guid.NewGuid().ToString();
    public string AggregateId { get; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
    public string CorrelationId { get; }
    public string PetId { get; }

    public RescueMarkedAvailableForAdoptionEvent(string aggregateId, string petId, string correlationId)
    {
        AggregateId = aggregateId;
        PetId = petId;
        CorrelationId = correlationId;
    }
}
