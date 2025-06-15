using MongoDB.Driver;

namespace PetSupportInfra.Persistence.Context;

public interface IMongoDbContext
{
    IMongoCollection<T> GetCollection<T>(string collectionName);
}
