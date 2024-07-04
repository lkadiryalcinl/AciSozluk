using EksiSozluk.Application.Interfaces.FollowChannelInterfaces;
using EksiSozluk.Domain.Entities;
using EksiSozluk.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EksiSozluk.Persistence.Repositories.FollowChannelRepositories
{
    public class FollowChannelRepository : IFollowChannelRepository
    {
        private readonly EksiDbContext _context;

        public FollowChannelRepository(EksiDbContext context)
        {
            _context = context;
        }

        public async Task<List<FollowChannel>> GetByFilterAsync(Expression<Func<FollowChannel, bool>> filter)
        {
            var values = await _context.FollowChannels.Where(filter).OrderByDescending(x => x.FollowedDate).ToListAsync();
            return values;
        }
    }
}
