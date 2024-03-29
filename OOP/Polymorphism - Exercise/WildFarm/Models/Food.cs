﻿using WildFarm.Models.Contracts;

namespace WildFarm.Models
{
    public abstract class Food : IFood
    {
        private int quantity;
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get { return this.quantity; } set { this.quantity = value; } }
    }
}
