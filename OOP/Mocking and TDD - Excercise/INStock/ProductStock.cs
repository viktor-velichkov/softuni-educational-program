using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace INStock
{
    public class ProductStock : IProductStock, IEnumerable<Product>
    {
        private readonly List<Product> stockList;
        public ProductStock()
        {
            this.stockList = new List<Product>();
        }        
        public int Count { get => this.stockList.Count; }

        public void Add(Product product)
        {
            if (this.stockList.FirstOrDefault(x=>x.Label==product.Label)!=null)
            {
                throw new InvalidOperationException("There is already a product with the given label!");
            }
            this.stockList.Add(product);
        }

        public bool Contains(Product product)
        {
            return this.stockList.Contains(product);
        }

        public Product Find(int index)
        {
            if (index<0||index>=this.stockList.Count)
            {
                throw new IndexOutOfRangeException("The given index is out of range!");
            }
            return this.stockList[index];
        }

        public Product[] FindAllByPrice(decimal price)
        {
            return this.stockList.Where(x => x.Price == price).ToArray();
        }

        public Product[] FindAllByQuantity(int quantity)
        {
            return this.stockList.Where(x => x.Quantity == quantity).ToArray();
        }

        public Product[] FindAllInPriceRange(decimal rangeStart, decimal rangeEnd)
        {
            return this.stockList.Where(x => x.Price >= rangeStart && x.Price <= rangeEnd).OrderByDescending(x=>x.Price).ToArray();
        }

        public Product FindByLabel(string label)
        {
            Product[] products = this.stockList.Where(x => x.Label == label).ToArray();
            if (products.Length == 0)
            {
                throw new ArgumentException("There is not any product with the givel label!");
            }
            return products.First();
        }

        public Product FindMostExpensiveProduct()
        {
            if (this.stockList.Count==0)
            {
                throw new InvalidOperationException("There is not any product in stock!");
            }
            return this.stockList.OrderByDescending(x => x.Price).First();
        }

        public IEnumerator<Product> GetEnumerator()
        {
            for (int i = 0; i < this.stockList.Count; i++)
            {
                yield return this.stockList[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < this.stockList.Count; i++)
            {
                yield return this.stockList[i];
            }
        }
        public Product this[int index]
        {
            get { return this.stockList[index]; }
            private set { this.stockList[index] = value; }
        }


    }
}
