using Microsoft.EntityFrameworkCore;
using ServiceA.Models;

namespace ServiceA.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Number> Numbers { get; set; }
    }
}