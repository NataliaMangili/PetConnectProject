using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetSupportApplication;

public interface IBaseQueryRepository<T> where T : class
{
    Task<T> GetByIdAsync(string id);
    Task<List<T>> GetAllAsync();
    Task<List<T>> FilterAsync(Expression<Func<T, bool>> filter);
}