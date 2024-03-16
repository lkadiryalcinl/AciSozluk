
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.Persistence.Context
{
    public class EksiDbContext:IdentityDbContext
    {
        public EksiDbContext(DbContextOptions<EksiDbContext> context) : base(context)
        {
        }
    }
}
