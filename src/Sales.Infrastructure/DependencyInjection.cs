using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sales.Application.Interfaces.Repositories;
using Sales.Infrastructure.Repositories;

namespace Sales.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IUnitOfWorkRepository>(provider => provider.GetRequiredService<AppDbContext>());

            return services;
        }
    }
}
