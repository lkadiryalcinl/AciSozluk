using EksiSozluk.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.Persistence.Context
{
    public class EksiDbContext:IdentityDbContext<User>
    {
        public EksiDbContext(DbContextOptions<EksiDbContext> context) : base(context)
        {
        }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Title> Titles { get; set; }
    }
}
