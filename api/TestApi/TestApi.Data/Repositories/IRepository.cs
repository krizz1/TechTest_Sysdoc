using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestApi.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int Id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        void Delete(T entity);
    }
}
