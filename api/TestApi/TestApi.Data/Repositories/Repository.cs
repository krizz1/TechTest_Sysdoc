using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestApi.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SysdocContext context;
        private DbSet<T> _entities;

        public Repository(SysdocContext context)
        {
            this.context = context;
            _entities = context.Set<T>();
        }

        public virtual async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public virtual async Task AddRange(IEnumerable<T> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        public virtual void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetById(int Id)
        {
            return await _entities.FindAsync(Id);
        }
    }
}
