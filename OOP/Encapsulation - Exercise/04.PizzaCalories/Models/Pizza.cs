using _04.PizzaCalories.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _04.PizzaCalories.Models
{
    public class Pizza
    {
        private const double MINIMUM_TOPPINGS_COUNT = 0;
        private const double MAXIMUM_TOPPINGS_COUNT = 10;
        private string name;
        private Dough dough;
        private List<Topping> toppings;
        private double calories;
        public Pizza()
        {
            this.toppings = new List<Topping>();
        }
        public Pizza(string name) : this()
        {
            this.Name = name;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)||(value.Length>15))
                {
                    throw new ArgumentException(GlobalConstants.InvalidPizzaNameExceptionMessage);
                }
                this.name = value;
            }
        }
        public Dough Dough
        {
            get { return this.dough; }
            set
            {
                this.dough = value;
                this.calories += this.Dough.CaloriesPerGram * this.Dough.Weight;
            }
        }
        public double ToppingsCount { get { return toppings.Count; } }
        public double Calories { get { return this.calories; } }
        public void AddTopping(Topping topping)
        {
            if (this.ToppingsCount==10)
            {
                throw new InvalidOperationException(String.Format(GlobalConstants.InvalidToppingsCountExceptionMessage, MINIMUM_TOPPINGS_COUNT, MAXIMUM_TOPPINGS_COUNT));
            }
            this.toppings.Add(topping);
            this.calories += topping.CaloriesPerGram * topping.Weight;
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Calories:f2} Calories.";
        }
    }
}
