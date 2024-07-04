﻿using EksiSozluk.Application.Interfaces.EntryInterfaces;
using EksiSozluk.Domain.Entities;
using EksiSozluk.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EksiSozluk.Persistence.Repositories.EntryRepositories
{
    public class EntryRepository : IEntryRepository
    {
        private readonly EksiDbContext _context;

        public EntryRepository(EksiDbContext context)
        {
            _context = context;
        }

        public async Task<List<Entry>> GetByFilterAsync(Expression<Func<Entry, bool>> filter)
        {
            var values = await _context.Entries.Where(filter).Include(x => x.Title).Include(x => x.User).ToListAsync();
            return values;
        }

        public async Task<Entry> GetSingleByFilterAsync(Expression<Func<Entry, bool>> filter)
        {
            var values = await _context.Entries.Where(filter).Include(x => x.Title).ThenInclude(y=> y.Channel).FirstOrDefaultAsync();
            return values;
        }
    }
}
