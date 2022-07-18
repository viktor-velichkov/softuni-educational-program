using _04.PizzaCalories.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _04.PizzaCalories.Models
{
    public class Dough
    {
        private readonly Dictionary<string, double> DefaultFlourTypes = new Dictionary<string, double>()
        {
            {"white",1.5},
            {"wholegrain",1.0}
        };
        private readonly Dictionary<string, double> DefaultBakingTechniques = new Dictionary<string, double>()
        {
            {"crispy",0.9},
            {"chewy",1.1},
            {"homemade",1.0}
        };
        private const double MINIMUM_WEIGHT = 1;
        private const double MAXIMUM_WEIGHT = 200;
        private const double BASE_CALORIES_PER_GRAM = 2;
        private double weight;
        private string flourType;
        private string bakingTechnique;
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < MINIMUM_WEIGHT || value > MAXIMUM_WEIGHT)
                {
                    throw new ArgumentException(string.Format(GlobalConstants.DoughWeightOutOfRangeExceptionMessage, MINIMUM_WEIGHT, MAXIMUM_WEIGHT));
                }
                this.weight = value;
            }
        }
        private string FlourType
        {
            get { return this.flourType; }
            set
            {
                if (!DefaultFlourTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(GlobalConstants.InvalidDoughExceptionMessage);
                }
                this.flourType = value.ToLower();
            }
        }
        private string BakingTechnique
        {
            get { return this.bakingTechnique; }
            set
            {
                if (!DefaultBakingTechniques.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(GlobalConstants.InvalidDoughExceptionMessage);
                }
                this.bakingTechnique = value.ToLower();
            }
        }
        public double CaloriesPerGram
        {
            get
            {
                return BASE_CALORIES_PER_GRAM * DefaultFlourTypes[this.FlourType] * DefaultBakingTechniques[this.BakingTechnique];
            }
        }

    }
}
