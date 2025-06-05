using PetSupportDomain.Shared.Events;
using PetSupportDomain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSupportDomain.LostPet.Events;

public class LostPetLocationUpdatedEvent : IEvent
{
    public string EventId { get; } = Guid.NewGuid().ToString();
    public string AggregateId { get; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
    public string CorrelationId { get; }
    public Address NewLocation { get; }

    public LostPetLocationUpdatedEvent(string aggregateId, Address newLocation, string correlationId)
    {
        AggregateId = aggregateId;
        NewLocation = newLocation;
        CorrelationId = correlationId;
    }
}