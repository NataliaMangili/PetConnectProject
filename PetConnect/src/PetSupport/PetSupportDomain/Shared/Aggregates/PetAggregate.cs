using PetSupportDomain.Adoption.Events;
using PetSupportDomain.Shared.Events;

namespace PetSupportDomain.Shared.Aggregates;

public class PetAggregate
{
    public string Id { get; private set; }
    public string Status { get; private set; }

    private readonly List<IEvent> _events = new();
    public IReadOnlyCollection<IEvent> Events => _events;

    public PetAggregate(string id, string status = "Available")
    {
        Id = id;
        Status = status;
    }

    public void RequestAdoption(string userId, string correlationId)
    {
        if (Status != "Available")
            throw new InvalidOperationException("Pet is not available for adoption.");

        var adoptionEvent = new AdoptionRequestedEvent("a", Id, userId, correlationId);
        Apply(adoptionEvent);
        _events.Add(adoptionEvent);
    }

    public void Apply(AdoptionRequestedEvent evt)
    {
        Status = "AdoptionRequested";
    }
}
