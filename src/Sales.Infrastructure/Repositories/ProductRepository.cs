using Microsoft.EntityFrameworkCore;
using Sales.Application.Dtos.Products;
using Sales.Application.Interfaces.Repositories;
using Sales.Domain.Entities;

namespace Sales.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Product>> SearchProducts(FilterProductDto filters, int page, int pageSize)
        {
            var query = _dbSet.AsNoTracking();

            if (!string.IsNullOrEmpty(filters.Name))
                query = query.Where(p => p.Name.Contains(filters.Name));

            if (filters.MaxPrice.HasValue && filters.MaxPrice.Value > 0)
                query = query.Where(p => p.Price <= filters.MaxPrice.Value);

            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> CountByFilters(FilterProductDto filters)
        {
            var query = _dbSet.AsNoTracking();

            if (!string.IsNullOrEmpty(filters.Name))
                query = query.Where(p => p.Name.Contains(filters.Name));

            if (filters.MaxPrice.HasValue && filters.MaxPrice.Value > 0)
                query = query.Where(p => p.Price <= filters.MaxPrice.Value);

            return query.Count();
        }

    }
}
