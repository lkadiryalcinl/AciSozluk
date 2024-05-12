using EksiSozluk.Application.Interfaces.TopicInterfaces;
using EksiSozluk.Domain.Entities;
using EksiSozluk.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EksiSozluk.Persistence.Repositories.TopicRepositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly EksiDbContext _context;

        public TopicRepository(EksiDbContext context)
        {
            _context = context;
        }

        public async Task<List<Title>> GetByFilterAsync(Expression<Func<Title, bool>> filter)
        {
            var values = await _context.Titles.Where(filter).Include(x => x.Channel).Include(x => x.Entries).ToListAsync();
            return values;
        }

        public async Task<Title> GetByFilterWithEntriesAsync(Expression<Func<Title, bool>> filter)
        {
            var values = await _context.Titles
                .Where(filter)
                .Include(x => x.Entries)
                    .ThenInclude(x => x.User)
                .Include(x => x.Entries)
                    .ThenInclude(x => x.EntryTransactionRelations)
                        .ThenInclude(x => x.EntryTransaction)
                .FirstOrDefaultAsync();

            return values;
        }

        public async Task<List<Title>> GetByFilterWithFirstEntryAsync(Expression<Func<Title, bool>> filter)
        {
            var values = await _context.Titles.Where(filter)
                .Include(x => x.Channel)
                .Include(x => x.Entries)
                    .ThenInclude(x => x.User)
                .Include(x => x.Entries)
                    .ThenInclude(x => x.EntryTransactionRelations)
                        .ThenInclude(x => x.EntryTransaction).ToListAsync();
            return values;
        }
    }
}