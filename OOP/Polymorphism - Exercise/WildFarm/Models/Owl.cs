using System;
using WildFarm.Common;
using WildFarm.Exceptions;
using WildFarm.Models.Contracts;

namespace WildFarm.Models
{
    public class Owl : Bird, IMeatEater
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }
        protected override double WeightIncrement => 0.25;

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }
        public override void Eat(IFood food)
        {
            if (food.GetType().Name != nameof(Meat))
            {
                throw new WrongFoodTypeException(string.Format(ExceptionMessages.WRONG_FOOD_TYPE, this.GetType().Name, food.GetType().Name));
            }
            base.Eat(food);
        }
    }
}
