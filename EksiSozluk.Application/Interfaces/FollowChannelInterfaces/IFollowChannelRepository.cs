using EksiSozluk.Domain.Entities;
using System.Linq.Expressions;

namespace EksiSozluk.Application.Interfaces.FollowChannelInterfaces
{
    public interface IFollowChannelRepository
    {
        Task<List<FollowChannel>> GetByFilterAsync(Expression<Func<FollowChannel, bool>> filter);
    }
}
