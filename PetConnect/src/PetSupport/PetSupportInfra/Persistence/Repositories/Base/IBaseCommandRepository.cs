]using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSupportInfra.Persistence.Repositories.Base;

public interface IBaseCommandRepository<T> where T : class
{
    Task<T> InsertAsync(T entity);
    Task UpdateAsync(string id, T entity);
    Task DeleteAsync(string id);
}
