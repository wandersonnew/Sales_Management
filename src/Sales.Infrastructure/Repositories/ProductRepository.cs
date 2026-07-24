using Sales.Application.Interfaces.Repositories;
using Sales.Domain.Entities;

namespace Sales.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
