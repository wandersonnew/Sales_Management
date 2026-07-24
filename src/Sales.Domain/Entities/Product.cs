namespace Sales.Domain.Entities
{
    public class Product : Entity
    {
        public Product(string name, decimal price, decimal qty, DateTime? useByDT)
        {
            ValidateDomain(name, price, qty);

            Name = name;
            Price = price;
            Qty = qty;
            UseByDT = useByDT;
        }

        protected Product()
        {
        }

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public decimal Qty { get; private set; }
        public DateTime? UseByDT { get; private set; }

        public void Update(string name, decimal price, decimal qty, DateTime? useByDT)
        {
            ValidateDomain(name, price, qty);

            Name = name;
            Price = price;
            Qty = qty;
            UseByDT = useByDT;
        }

        public void UpdatePrice(decimal price)
        {
            if (price <= 0)
                throw new Exception("Price cannot be zero or less than zero.");

            Price = price;
        }

        public void AddStock(decimal qty)
        {
            if (qty <= 0)
                throw new Exception("Qty cannot be zero or less than zero.");

            Qty += qty;
        }

        public void DebitStock(decimal qty)
        {
            if (qty <= 0)
                throw new Exception("Qty cannot be zero or less than zero.");

            Qty -= qty;
        }

        private void ValidateDomain(string name, decimal price, decimal amount)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Name cannot be empty or null.");

            if (price <= 0)
                throw new Exception("Price cannot be zero or less than zero.");

            if (amount < 0)
                throw new Exception("Amount cannot be less than zero.");
        }
    }
}
