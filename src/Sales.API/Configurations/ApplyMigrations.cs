using Microsoft.EntityFrameworkCore;
using Sales.Infrastructure;

namespace Sales.API.Configurations
{
    public static class ApplyMigrations
    {
        public static void ApplyMigrationsInit(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
