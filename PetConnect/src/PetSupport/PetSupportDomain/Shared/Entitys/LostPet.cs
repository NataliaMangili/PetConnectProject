using PetSupportDomain.Shared.Interfaces;
using PetSupportDomain.Shared.ValueObjects;

namespace PetSupportDomain.Shared.Entitys;

public class LostPet : EntityBase, IAggregateRoot
{
    public string PetId { get; set; }
    public string OwnerName { get; set; }
    public ContactInfo ContactInfo { get; set; }
    public Address LastSeenLocation { get; set; }
    public DateTime LostDate { get; set; }
    public string AdditionalInfo { get; set; }
}
