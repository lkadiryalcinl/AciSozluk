using EksiSozluk.Domain.Entities;
using System.Linq.Expressions;

namespace EksiSozluk.Application.Interfaces.EntryTransactionRelationInterfaces
{
    public interface IEntryTransactionRelationRepository
    {
        Task<EntryTransactionRelation> GetByFilterAsync(Expression<Func<EntryTransactionRelation,bool>> filter);
    }
}
