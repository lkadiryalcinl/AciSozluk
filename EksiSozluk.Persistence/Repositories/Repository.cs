using EksiSozluk.Application.Interfaces;
using EksiSozluk.Domain.Entities;
using EksiSozluk.Persistence.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
            try
            {
                // ChannelId özelliğini reflection ile al
                var channelIdProperty = typeof(T).GetProperty("ChannelId");
                if (channelIdProperty == null)
                {
                    throw new InvalidOperationException("Entity does not contain a property named 'ChannelId'.");
                }

                var channelId = channelIdProperty.GetValue(entity);

                // Var olan kaydı kontrol et
                var existingEntity = await _context.Set<T>().FindAsync(channelId);
                if (existingEntity != null)
                {
                    throw new InvalidOperationException("ChannelId already exists.");
                }

                // Yeni kaydı ekle
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2627)
            {
                // Duplicate key hatası
                throw new InvalidOperationException("ChannelId already exists.", ex);
            }
            catch (Exception ex)
            {
                // Diğer hatalar
                throw new Exception("An error occurred while saving the entity.", ex);
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(filter);
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

