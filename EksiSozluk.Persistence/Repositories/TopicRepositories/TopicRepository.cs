using EksiSozluk.Application.Interfaces.TopicInterfaces;
using EksiSozluk.Domain.Entities;
using EksiSozluk.Persistence.Context;
using EksiSozluk.Persistence.OtherFile;
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

        //Gündem Başlığı
        public async Task<List<Title>> GetByDailyEntryCountAsync()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            var titles = await _context.Titles
                .Include(t => t.Entries)
                .Include(x => x.Entries)
                    .ThenInclude(x => x.User)
                .Include(x => x.Entries)
                    .ThenInclude(x => x.EntryTransactionRelations)
                        .ThenInclude(x => x.EntryTransaction)
                .Include(e => e.Channel)
                .Where(t => t.Entries.Any(e => e.CreatedDate >= today && e.CreatedDate < tomorrow))
                .ToListAsync();

            titles = titles.OrderByDescending(t => t.Entries.Count).ToList();

            return titles;
        }

        //Bugün Başlığı
        public async Task<List<Title>> GetByLastEntryAsync()
        {
            var titles = await _context.Titles
                .Include(t => t.Entries)
                .Include(x => x.Entries)
                    .ThenInclude(x => x.User)
                .Include(x => x.Entries)
                    .ThenInclude(x => x.EntryTransactionRelations)
                        .ThenInclude(x => x.EntryTransaction)
                .Include(e => e.Channel)
                .Where(t => t.Entries.Any())
                .OrderByDescending(t => t.Entries.Max(e => e.CreatedDate))
                .ToListAsync();

            return titles;
        }

        //Debe Başlığı
        public async Task<List<Title>> GetByTopLikedEntriesFromYesterdayAsync()
        {
            var yesterday = DateTime.Today.AddDays(-1);
            var today = DateTime.Today;

            var titles = await _context.Titles
                .Include(e => e.Channel)
                .Include(x => x.Entries)
                    .ThenInclude(x => x.User)
                .Include(t => t.Entries)
                    .ThenInclude(e => e.EntryTransactionRelations)
                        .ThenInclude(etr => etr.EntryTransaction)
                .Where(t => t.Entries.Any(e => e.CreatedDate >= yesterday && e.CreatedDate < today))
                .OrderByDescending(t => t.Entries.SelectMany(e => e.EntryTransactionRelations)
                                                .Count(etr => etr.EntryTransaction.IsLiked))
                .ToListAsync();

            return titles;
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