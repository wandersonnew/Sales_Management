using Microsoft.AspNetCore.Mvc;
using Sales.Application.Dtos;
using Sales.Application.Dtos.Products;
using Sales.Application.Interfaces.Services;

namespace Sales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost]
        public async Task<ActionResult> CreateProduct(CreateProductDto create)
        {
            await _productService.Create(create);

            return Created();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductDto update)
        {
            await _productService.Update(id, update);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            await _productService.Delete(id);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(Guid id)
        {
            var product = await _productService.GetProduct(id);

            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<PagedResultDto<ProductDto>>> ListProducts(
            [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 10
        )
        {
            var products = await _productService.ListProduct(page, pageSize);

            return Ok(products);
        }
    }
}
