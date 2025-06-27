using PetSupportInfra.Persistence.Context;
using PetSupportInfra.Persistence.Repositories.Base;
using MongoDB.Driver;
using PetSupportDomain.Adoption.Models;
using PetSupportDomain.Adoption.Interfaces;

namespace PetSupportInfra.Persistence.Repositories.Adoption;

public class AdoptionCommandRepository : IAdoptionCommandRepository
{
    private readonly IMongoCollection<AdoptionPetAggregate> _collection;

    public AdoptionCommandRepository(MongoDbContext context)
    {
        _collection = context.GetCollection<AdoptionPetAggregate>("Adoptions");
    }

    public async Task InsertAsync(AdoptionPetAggregate aggregate)
    {
        await _collection.InsertOneAsync(aggregate);
    }
}