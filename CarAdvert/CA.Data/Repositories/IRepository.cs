using System.Collections.Generic;
using System.Threading.Tasks;
using CA.Data.Entities;

namespace CA.Data.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<int> InsertAsync(T entity);
        Task UpdateAsync(T entity);
    }
}