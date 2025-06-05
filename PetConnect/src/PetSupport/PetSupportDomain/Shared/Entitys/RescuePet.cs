using PetSupportDomain.Shared.Interfaces;
using PetSupportDomain.Shared.ValueObjects;

namespace PetSupportDomain.Shared.Entitys;

public class RescuePet : EntityBase, IAggregateRoot
{
    public string PetId { get; set; }
    public string RescuerName { get; set; }
    public ContactInfo ContactInfo { get; set; }
    public string SituationDescription { get; set; }
    public Address Location { get; set; }
    public DateTime RescueDate { get; set; }
    public bool AvailableForAdoption { get; set; }
}