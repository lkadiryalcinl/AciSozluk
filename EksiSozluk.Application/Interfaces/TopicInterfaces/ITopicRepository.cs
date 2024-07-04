using EksiSozluk.Domain.Entities;
using System.Linq.Expressions;

namespace EksiSozluk.Application.Interfaces.TopicInterfaces
{
    public interface ITopicRepository
    {
        Task<List<Title>> GetByFilterAsync(Expression<Func<Title, bool>> filter);
        Task<List<Title>> GetByDailyEntryCountAsync();
        Task<List<Title>> GetByLastEntryAsync();
        Task<List<Title>> GetByTopLikedEntriesFromYesterdayAsync();

        Task<Title> GetByFilterWithEntriesAsync(Expression<Func<Title, bool>> filter);
        Task<List<Title>> GetByFilterWithFirstEntryAsync(Expression<Func<Title, bool>> filter);

    }
}
