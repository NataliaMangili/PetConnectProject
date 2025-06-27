using MongoDB.Driver;
using PetSupportDomain.Shared.Entitys;
using PetSupportInfra.Persistence.Context;
using PetSupportInfra.Persistence.Repositories.Base.Interfaces;
using System.Linq.Expressions;

namespace PetSupportInfra.Persistence.Repositories.Adoption;

public class AdoptionQueryRepository : IBaseQueryRepository<AdoptionPet>
{
    private readonly IMongoCollection<AdoptionPet> _collection;

    public AdoptionQueryRepository(MongoDbContext context)
    {
        _collection = context.GetCollection<AdoptionPet>("Adoptions");
    }

    public async Task<AdoptionPet> GetByIdAsync(string id)
    {
        return (await _collection.FindAsync(x => x.Id == id)).FirstOrDefault();
    }

    public async Task<IEnumerable<AdoptionPet>> GetAllAsync()
    {
        return (await _collection.FindAsync(_ => true)).ToList();
    }

    public async Task<IEnumerable<AdoptionPet>> FindAsync(Expression<Func<AdoptionPet, bool>> filter)
    {
        return (await _collection.FindAsync(filter)).ToList();
    }

    Task<List<AdoptionPet>> IBaseQueryRepository<AdoptionPet>.GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<AdoptionPet>> FilterAsync(Expression<Func<AdoptionPet, bool>> filter)
    {
        throw new NotImplementedException();
    }
}

