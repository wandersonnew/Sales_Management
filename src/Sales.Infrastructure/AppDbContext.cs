using Microsoft.EntityFrameworkCore;
using Sales.Application.Interfaces.Repositories;
using Sales.Domain.Entities;

namespace Sales.Infrastructure
{
    public class AppDbContext : DbContext, IUnitOfWorkRepository
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public async Task SaveAsync()
        {
            await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
