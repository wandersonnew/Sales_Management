using Sales.Application.Dtos;
using Sales.Application.Dtos.Products;

namespace Sales.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task Create(CreateProductDto productDto);

        Task Update(Guid id, UpdateProductDto productDto);

        Task Delete(Guid id);

        Task<ProductDto> GetProduct(Guid id);

        Task<PagedResultDto<ProductDto>> SearchProduct(FilterProductDto filters, int page, int pageSize);
    }
}
