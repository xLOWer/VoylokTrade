using Microsoft.EntityFrameworkCore;

namespace VoylokTrade.Models
{
    public class VoylokTradeDbContext : DbContext
    {
        public VoylokTradeDbContext (DbContextOptions<VoylokTradeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Good> Goods { get; set; }
    }
}
