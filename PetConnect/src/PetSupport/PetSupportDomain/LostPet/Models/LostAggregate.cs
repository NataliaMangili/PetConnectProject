using PetSupportDomain.LostPet.Events;
using PetSupportDomain.Shared.Events;
using PetSupportDomain.Shared.Interfaces;
using PetSupportDomain.Shared.ValueObjects;

namespace PetSupportDomain.LostPet.Models;

public class LostPetAggregate : IAggregateRoot
{
    public string Id { get; private set; }
    public string PetId { get; private set; }
    public string OwnerName { get; private set; }
    public ContactInfo ContactInfo { get; private set; }
    public Address LastSeenLocation { get; private set; }
    public DateTime LostDate { get; private set; }
    public string AdditionalInfo { get; private set; }

    private readonly List<IEvent> _events = new();
    public IReadOnlyCollection<IEvent> Events => _events;

    public LostPetAggregate(string id, string petId, string ownerName,
                             ContactInfo contactInfo, Address lastSeenLocation,
                             DateTime lostDate, string additionalInfo)
    {
        Id = id;
        PetId = petId;
        OwnerName = ownerName;
        ContactInfo = contactInfo;
        LastSeenLocation = lastSeenLocation;
        LostDate = lostDate;
        AdditionalInfo = additionalInfo;
    }

    public void UpdateLastSeenLocation(Address newLocation)
    {
        LastSeenLocation = newLocation;
        _events.Add(new LostPetLocationUpdatedEvent(Id, newLocation, ""));
    }

    public void AddAdditionalInfo(string info)
    {
        AdditionalInfo = info;
        _events.Add(new LostPetInfoUpdatedEvent(Id, info, ""));
    }
}
