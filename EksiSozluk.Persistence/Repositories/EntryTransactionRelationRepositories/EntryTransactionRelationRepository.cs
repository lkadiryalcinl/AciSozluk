using EksiSozluk.Application.Interfaces.EntryTransactionRelationInterfaces;
using EksiSozluk.Domain.Entities;
using EksiSozluk.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.Persistence.Repositories.EntryTransactionRelationRepositories
{
    public class EntryTransactionRelationRepository : IEntryTransactionRelationRepository
    {
        private readonly EksiDbContext _context;

        public EntryTransactionRelationRepository(EksiDbContext context)
        {
            _context = context;
        }

        public async Task<EntryTransactionRelation> GetByFilterAsync(Expression<Func<EntryTransactionRelation, bool>> filter)
        {
            var values = await _context.EntryTransactionRelations.Where(filter).FirstOrDefaultAsync();
            return values;
        }
    }
}
