using EksiSozluk.Application.Interfaces;
using EksiSozluk.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly EksiDbContext _context;

        public Repository(EksiDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

