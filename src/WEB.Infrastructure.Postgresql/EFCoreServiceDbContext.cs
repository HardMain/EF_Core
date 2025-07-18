using Microsoft.EntityFrameworkCore;
using WEB.Domain.Venue;

namespace WEB.Infrastructure.Postgresql
{
    public class EFCoreServiceDbContext : DbContext
    {
        private readonly string _connectionString;

        public EFCoreServiceDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFCoreServiceDbContext).Assembly);
        }
         
        public DbSet<Venue> Venues => Set<Venue>();
    }
}