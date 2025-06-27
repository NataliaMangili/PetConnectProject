using MongoDB.Driver;
using PetSupportDomain.Shared.Interfaces;
using PetSupportInfra.Persistence.Context;
using PetSupportInfra.Persistence.Repositories.Base.Interfaces;

namespace PetSupportInfra.Persistence.Repositories.Base;

public class BaseCommandRepository<T> : IBaseCommandRepository<T>
    where T : IAggregateRoot
{
    protected readonly IMongoCollection<T> _collection;

    public BaseCommandRepository(MongoDbContext context)
    {
        _collection = context.GetCollection<T>(typeof(T).Name);
    }

    public async Task AddAsync(T entity)
        => await _collection.InsertOneAsync(entity);

    public async Task UpdateAsync(T entity)
        => await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);

    public async Task DeleteAsync(string id)
        => await _collection.DeleteOneAsync(x => x.Id == id);
}
