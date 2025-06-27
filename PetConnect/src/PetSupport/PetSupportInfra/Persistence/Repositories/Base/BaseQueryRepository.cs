using MongoDB.Driver;
using PetSupportInfra.Persistence.Context;
using PetSupportInfra.Persistence.Repositories.Base.Interfaces;
using System.Linq.Expressions;

namespace PetSupportInfra.Persistence.Repositories.Base;

public class BaseQueryRepository<T> : IBaseQueryRepository<T> where T : class
{
    private readonly IMongoCollection<T> _collection;

    public BaseQueryRepository(IMongoDbContext context, string collectionName)
    {
        _collection = context.GetCollection<T>(collectionName);
    }

    public async Task<T> GetByIdAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<List<T>> FilterAsync(Expression<Func<T, bool>> filter)
    {
        return await _collection.Find(filter).ToListAsync();
    }
}
