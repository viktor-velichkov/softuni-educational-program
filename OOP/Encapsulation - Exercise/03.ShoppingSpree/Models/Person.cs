using _03.ShoppingSpree.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree.Models
{
    public class Person
    {
        private const decimal MONEY_MIN_VALUE = 0;
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person()
        {
            this.bagOfProducts = new List<Product>();
        }
        public Person(string name, decimal money) : this()
        {
            this.Name = name;
            this.Money = money;
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException(GlobalConstants.InvalidNameExceptionMessage);
                }
                this.name = value;
            }
        }
        public decimal Money
        {
            get { return this.money; }
            set
            {
                if (value < MONEY_MIN_VALUE)
                {
                    throw new ArgumentException(GlobalConstants.InvalidMoneyExceptionMessage);
                }
                this.money = value;
            }
        }
        public IReadOnlyCollection<Product> BagOfProducts
        {
            get { return this.bagOfProducts.AsReadOnly(); }
        }
        public void Buy(Product product)
        {
            if (this.Money < product.Cost)
            {
                throw new InvalidOperationException(string.Format(GlobalConstants.InsufficientMoneyExceptionMessage, this.Name, product.Name));

            }
            else
            {
                this.bagOfProducts.Add(product);
                this.Money -= product.Cost;
            }
        }
        public override string ToString()
        {
            string productsOutput = this.BagOfProducts.Count > 0 ? String.Join(", ", this.BagOfProducts) : "Nothing bought";
            return $"{this.Name} - {productsOutput}";
        }


    }
}
