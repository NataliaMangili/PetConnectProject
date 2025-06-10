namespace PetSupportApplication;

public interface IBaseCommandRepository<T> where T : class
{
    Task<T> InsertAsync(T entity);
    Task UpdateAsync(string id, T entity);
    Task DeleteAsync(string id);
}
