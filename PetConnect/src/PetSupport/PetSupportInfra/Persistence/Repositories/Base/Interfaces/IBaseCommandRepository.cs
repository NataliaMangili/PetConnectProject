using PetSupportDomain.Shared.Interfaces;

namespace PetSupportInfra.Persistence.Repositories.Base.Interfaces;

public interface IBaseCommandRepository<T> where T : IAggregateRoot
{
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(string id);
}
