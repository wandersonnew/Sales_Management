using Sales.Application.Dtos;
using Sales.Application.Dtos.Products;
using Sales.Application.Interfaces.Repositories;
using Sales.Application.Interfaces.Services;
using Sales.Domain.Entities;

namespace Sales.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;

        public ProductService(IProductRepository productRepository, IUnitOfWorkRepository unitOfWorkRepository)
        {
            _productRepository = productRepository;
            _unitOfWorkRepository = unitOfWorkRepository;
        }

        public async Task Create(CreateProductDto productDto)
        {
            var product = new Product(productDto.Name, productDto.Price, productDto.Qty, productDto.UseByDT);
            await _productRepository.Create(product);
            await _unitOfWorkRepository.SaveAsync();
        }

        public async Task Update(Guid id, UpdateProductDto productDto)
        {
            var product = await _productRepository.GetOne(id);

            if (product is null)
                throw new Exception("Product not found");

            product.Update(productDto.Name, productDto.Price, productDto.Qty, productDto.UseByDT);

            _productRepository.Update(product);
            await _unitOfWorkRepository.SaveAsync();
        }

        public async Task Delete(Guid id)
        {
            var product = await _productRepository.GetOne(id);

            if (product is null)
                throw new Exception("Product not found");

            _productRepository.Delete(product);
            await _unitOfWorkRepository.SaveAsync();
        }

        public async Task<ProductDto> GetProduct(Guid id)
        {
            var product = await _productRepository.GetOne(id);

            if (product is null)
                throw new Exception("Product not found");

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Qty = product.Qty,
                UseByDT = product.UseByDT
            };
        }

        public async Task<PagedResultDto<ProductDto>> SearchProduct(FilterProductDto filters, int page, int pageSize)
        {
            var products = await _productRepository.SearchProducts(filters, page, pageSize);

            var totalCounts = await _productRepository.CountByFilters(filters);

            return new PagedResultDto<ProductDto>
            {
                Items = products.Select(s => new ProductDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Price = s.Price,
                    Qty = s.Qty,
                    UseByDT = s.UseByDT
                }),
                TotalCount = 0,
                Page = page,
                PageSize = pageSize
            };
        }

    }
}
