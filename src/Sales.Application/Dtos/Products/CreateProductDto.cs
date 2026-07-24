namespace Sales.Application.Dtos.Products
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Qty { get; set; }
        public DateTime? UseByDT { get; set; }
    }
}
