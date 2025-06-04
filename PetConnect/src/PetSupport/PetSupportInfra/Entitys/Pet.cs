using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PetSupportDomain.Shared.Enums;
using PetSupportDomain.Shared.Interfaces;
using PetSupportDomain.Shared.ValueObjects;

namespace PetSupportInfra.Entitys;

public class Pet : EntityBase, IAggregateRoot
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public SpeciesEnum Species { get; set; }
    public string Breed { get; set; }
    public int Age { get; set; }
    public GenderEnum Gender { get; set; }
    public string Description { get; set; }
    public List<Image> Images { get; set; } = new();
    public PetStatusEnum Status { get; set; }

}
