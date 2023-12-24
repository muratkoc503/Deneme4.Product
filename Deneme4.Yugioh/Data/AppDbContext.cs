using Microsoft.EntityFrameworkCore;
using Deneme4.Yugioh.Models;

namespace Deneme4.Yugioh.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<YugiohCard> Yugioh { get; set; }
    }
}
