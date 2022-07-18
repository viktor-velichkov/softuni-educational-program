using System;
using System.Collections.Generic;
using System.Text;

namespace INStock
{
    public class Product : IStockable
    {
        private string label;
        private decimal price;
        private int quantity;
        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }
        public string Label
        {
            get { return this.label; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Label must not be null or empty!");
                }
                this.label = value;
            }
        }
        public decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Price must be a positive number!");
                }
                this.price = value;
            }
        }
        public int Quantity
        {
            get { return this.quantity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity must not be negative!");
                }
                this.quantity = value;
            }
        }
    }
}
