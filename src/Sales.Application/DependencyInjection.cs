using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Sales.Application.Interfaces.Services;
using Sales.Application.Services;

namespace Sales.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}
