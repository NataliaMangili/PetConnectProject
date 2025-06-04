using PetSupportDomain.Shared.Enums;
using PetSupportDomain.Shared.Interfaces;
using PetSupportDomain.Shared.ValueObjects;

namespace PetSupportInfra.Entitys;
public class AdoptionPet : EntityBase, IAggregateRoot
{
    public string PetId { get; set; }
    public string AdopterName { get; set; }
    public ContactInfo ContactInfo { get; set; }
    public AdoptionStatusEnum Status { get; set; }
    public DateTime RequestDate { get; set; }
    public DateTime? CompletionDate { get; set; }
}
