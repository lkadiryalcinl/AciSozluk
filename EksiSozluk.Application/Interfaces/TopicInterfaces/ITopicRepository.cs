using EksiSozluk.Domain.Entities;
using System.Linq.Expressions;

namespace EksiSozluk.Application.Interfaces.TopicInterfaces
{
    public interface ITopicRepository
    {
        Task<List<Title>> GetByFilterAsync(Expression<Func<Title, bool>> filter);
    }
}
