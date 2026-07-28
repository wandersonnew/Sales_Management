using Sales.Application.Dtos.Products;
using Sales.Domain.Entities;

namespace Sales.Application.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> SearchProducts(FilterProductDto filters, int page, int pageSize);

        Task<int> CountByFilters(FilterProductDto filters);
    }
}
