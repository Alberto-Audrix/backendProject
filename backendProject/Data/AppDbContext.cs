using backendProject.Models;
using Microsoft.EntityFrameworkCore;

namespace backendProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Admins> Admin { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
