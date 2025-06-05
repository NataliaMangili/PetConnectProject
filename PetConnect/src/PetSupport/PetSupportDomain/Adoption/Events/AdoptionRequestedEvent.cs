using PetSupportDomain.Shared.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSupportDomain.Adoption.Events;

public class AdoptionRequestedEvent : BaseEvent
{
    public string PetId { get; }
    public string UserId { get; }

    public AdoptionRequestedEvent(string aggregateId, string petId, string userId, string correlationId)
        : base(aggregateId, correlationId)
    {
        PetId = petId;
        UserId = userId;
    }
}
