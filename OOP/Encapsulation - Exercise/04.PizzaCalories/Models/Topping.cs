using _04.PizzaCalories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories.Models
{
    public class Topping
    {
        private readonly Dictionary<string, double> DefaultToppingModifiers = new Dictionary<string, double>()
        {
            {"meat",1.2},
            {"veggies",0.8},
            {"cheese",1.1},
            {"sauce",0.9},
        };
        private const double MINIMUM_WEIGHT = 1;
        private const double MAXIMUM_WEIGHT = 50;
        private const double BASE_CALORIES_PER_GRAM = 2;
        private string type;
        private double weight;
        private double caloriesPerGram;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < MINIMUM_WEIGHT || value > MAXIMUM_WEIGHT)
                {
                    string type = this.Type.First().ToString().ToUpper() + this.Type.Substring(1);
                    throw new ArgumentException(String.Format(GlobalConstants.ToppingWeightOutOfRangeExceptionMessage, type, MINIMUM_WEIGHT, MAXIMUM_WEIGHT));
                }
                this.weight = value;
            }
        }
        private string Type
        {
            get { return this.type; }
            set
            {
                if (!DefaultToppingModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(String.Format(GlobalConstants.InvalidToppingTypeExceptionMessage, value));
                }
                this.type = value.ToLower();
            }
        }
        public double CaloriesPerGram { get { return BASE_CALORIES_PER_GRAM *DefaultToppingModifiers[this.Type]; } }

    }
}
