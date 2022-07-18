using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models;
using WildFarm.Models.Contracts;

namespace WildFarm.Factories
{
    public class FoodFactory
    {
        public IFood CreateFood(string[] args)
        {
            string foodType = args[0];
            int foodQuantity = int.Parse(args[1]);
            IFood food = null;
            if (foodType == nameof(Vegetable))
            {
                food = new Vegetable(foodQuantity);
            }
            else if (foodType == nameof(Fruit))
            {
                food = new Fruit(foodQuantity);
            }
            else if (foodType == nameof(Meat))
            {
                food = new Meat(foodQuantity);
            }
            else if (foodType == nameof(Seeds))
            {
                food = new Seeds(foodQuantity);
            }
            return food;
        }
    }
}
