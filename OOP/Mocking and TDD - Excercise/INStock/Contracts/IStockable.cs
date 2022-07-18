using System;
using System.Collections.Generic;
using System.Text;

namespace INStock
{
    public interface IStockable
    {
        public string Label { get; }
        public decimal Price { get; }
        public int Quantity { get; }

    }
}
