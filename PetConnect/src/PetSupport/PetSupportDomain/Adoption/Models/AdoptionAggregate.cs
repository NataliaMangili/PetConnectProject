using PetSupportDomain.Adoption.Events;
using PetSupportDomain.Shared.Enums;
using PetSupportDomain.Shared.Events;
using PetSupportDomain.Shared.Interfaces;
using PetSupportDomain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSupportDomain.Adoption.Models;

public class AdoptionPetAggregate
{
    public string Id { get; private set; }
    public string Status { get; private set; }
    public string AdopterId { get; private set; }

    private readonly List<IEvent> _events = new();
    public IReadOnlyCollection<IEvent> Events => _events;

    public AdoptionPetAggregate(string id, string status = "Available", string adopterId = null)
    {
        Id = id;
        Status = status;
        AdopterId = adopterId;
    }

    public void RequestAdoption(string userId)
    {
        if (Status != "Available")
            throw new InvalidOperationException("Pet not available for adoption.");

        AdopterId = userId;
        Status = "AdoptionRequested";

        _events.Add(new AdoptionRequestedEvent(Id, userId, "a", "b"));
    }
}