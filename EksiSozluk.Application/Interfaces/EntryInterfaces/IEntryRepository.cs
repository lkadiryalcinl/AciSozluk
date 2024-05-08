using EksiSozluk.Domain.Entities;
using System.Linq.Expressions;

namespace EksiSozluk.Application.Interfaces.EntryInterfaces
{
    public interface IEntryRepository
    {
        Task<List<Entry>> GetByFilterAsync(Expression<Func<Entry, bool>> filter);
    }
}
