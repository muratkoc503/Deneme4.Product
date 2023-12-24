using Microsoft.EntityFrameworkCore;
using Deneme4.Product.Models;

namespace Deneme4.Product.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }
    }
}
