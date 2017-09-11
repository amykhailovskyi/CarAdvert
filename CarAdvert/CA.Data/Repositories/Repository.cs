using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CA.Data.Db;
using CA.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CA.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }
        public async Task<T> GetAsync(int id)
        {
            return await _entities.FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<int> InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }
        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
