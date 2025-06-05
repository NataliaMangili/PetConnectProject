using PetSupportDomain.Rescue.Events;
using PetSupportDomain.Shared.Events;
using PetSupportDomain.Shared.Interfaces;
using PetSupportDomain.Shared.ValueObjects;

namespace PetSupportDomain.Rescue.Models;

public class RescueAggregate : IAggregateRoot
{
    public string Id { get; private set; }
    public string PetId { get; private set; }
    public string RescuerName { get; private set; }
    public ContactInfo ContactInfo { get; private set; }
    public string SituationDescription { get; private set; }
    public Address Location { get; private set; }
    public DateTime RescueDate { get; private set; }
    public bool AvailableForAdoption { get; private set; }

    private readonly List<IEvent> _events = new();
    public IReadOnlyCollection<IEvent> Events => _events;

    public RescueAggregate(string id, string petId, string rescuerName, ContactInfo contactInfo,
                            string situationDescription, Address location, DateTime rescueDate,
                            bool availableForAdoption = false)
    {
        Id = id;
        PetId = petId;
        RescuerName = rescuerName;
        ContactInfo = contactInfo;
        SituationDescription = situationDescription;
        Location = location;
        RescueDate = rescueDate;
        AvailableForAdoption = availableForAdoption;
    }

    public void MarkAsAvailableForAdoption()
    {
        if (AvailableForAdoption)
            throw new InvalidOperationException("Pet is already available for adoption.");

        AvailableForAdoption = true;
        _events.Add(new RescueMarkedAvailableForAdoptionEvent(Id, PetId, ""));
    }

    public void UpdateSituation(string description)
    {
        SituationDescription = description;
        _events.Add(new RescueSituationUpdatedEvent(Id, description, ""));
    }
}
