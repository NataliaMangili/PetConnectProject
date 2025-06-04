using System.Linq.Expressions;

namespace PetSupportInfra.Persistence.Repositories.Base.Interfaces;

public interface IBaseQueryRepository<T> where T : class
{
    Task<T> GetByIdAsync(string id);
    Task<List<T>> GetAllAsync();
    Task<List<T>> FilterAsync(Expression<Func<T, bool>> filter);
}

