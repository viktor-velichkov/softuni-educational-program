using _04.PizzaCalories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories.Core
{
    public class Engine
    {
        public void Run()
        {
            string pizzaName = Console.ReadLine().Replace("Pizza", "").Trim();
            Pizza pizza = new Pizza(pizzaName);
            string[] doughTokens = Console.ReadLine().Replace("Dough", "").Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string flourType = doughTokens[0];
            string bakingTech = doughTokens[1];
            double doughWeight = double.Parse(doughTokens[2]);
            pizza.Dough = new Dough(flourType, bakingTech, doughWeight);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] toppingTokens = input.Replace("Topping", "").Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string type = toppingTokens[0];
                double toppingWeight = double.Parse(toppingTokens[1]);
                pizza.AddTopping(new Topping(type, toppingWeight));
            }
            Console.WriteLine(pizza.ToString());

        }
    }
}
