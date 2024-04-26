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
            var values = await _context.Titles.Where(filter).ToListAsync();
            return values;
        }
    }
}
