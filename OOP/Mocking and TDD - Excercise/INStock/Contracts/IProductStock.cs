namespace INStock.Contracts
{
    public interface IProductStock
    {
        public int Count { get; }
        public void Add(Product product);
        public bool Contains(Product product);
        public Product Find(int index);
        public Product FindByLabel(string label);
        public Product[] FindAllInPriceRange(decimal rangeStart, decimal rangeEnd);
        public Product[] FindAllByPrice(decimal price);
        public Product FindMostExpensiveProduct();
        public Product[] FindAllByQuantity(int quantity);

        
    }
}
