using PetSupportDomain.Shared.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSupportDomain.LostPet.Events;

public class LostPetInfoUpdatedEvent : IEvent
{
    public string EventId { get; } = Guid.NewGuid().ToString();
    public string AggregateId { get; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
    public string CorrelationId { get; }
    public string Info { get; }

    public LostPetInfoUpdatedEvent(string aggregateId, string info, string correlationId)
    {
        AggregateId = aggregateId;
        Info = info;
        CorrelationId = correlationId;
    }
}