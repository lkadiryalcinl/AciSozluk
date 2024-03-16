
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.Persistence.Context
{
    public class DbContext:IdentityDbContext
    {
        public DbContext(DbContextOptions<DbContext> context) : base(context)
        {
            
            
        }

       

    }
}
