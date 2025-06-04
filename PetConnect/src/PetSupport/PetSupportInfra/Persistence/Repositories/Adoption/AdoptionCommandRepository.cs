using MongoDB.Driver;
using PetSupportInfra.Persistence.Context;
using PetSupportInfra.Persistence.Repositories.Base;
using PetSupportDomain.Adoption.Models;

namespace PetSupportInfra.Persistence.Repositories.Adoption;

public class AdoptionCommandRepository : IBaseCommandRepository<AdoptionPet>
{
    private readonly IMongoCollection<AdoptionPet> _collection;

    public AdoptionCommandRepository(MongoDbContext context)
    {
        _collection = context.GetCollection<AdoptionPet>("Adoptions");
    }

    public async Task AddAsync(AdoptionPet entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(string id, AdoptionPet entity)
    {
        await _collection.ReplaceOneAsync(x => x.Id == id, entity);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}